using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using Mono.Cecil;
using System.Reflection;

namespace BepinBlock;

// Whenever GameObject.AddComponent(Type) is called, look at the parameter and object.
// If the gameobject in question is Chainloader.ManagerObject and the parameter is a type assignable to BaseUnityPlugin (and isn't our plugin, although that shouldn't matter)
// throw an exception if the type in question is blocked by the config. (If an exception is thrown when creating a plugin component, that plugin will be unloaded)

internal static class BlockPluginPatch {
	static ConfigFile cfg = new ConfigFile(Path.Combine(Paths.ConfigPath, "block-plugins.cfg"), false);
	static string HarmonyID => MainPlugin.GUID + ".blocker";
	static Harmony harmony = new(HarmonyID);

	public static void Initialize() {
		harmony.PatchAll(typeof(BlockPluginPatch));
	}

	static MethodBase TargetMethod() {
		return typeof(GameObject).GetMethod("AddComponent", new Type[] { typeof(Type) });
	}

	static void Prefix(GameObject __instance, Type componentType) {
		if(__instance != Chainloader.ManagerObject) {
			return;
		}
		if(componentType.GetCustomAttribute<BepInPlugin>() is not BepInPlugin attribute) {
			return;
		}
		if(GetModCfg(attribute)) {
			return;
		}

		throw new Exception("This plugin has been disabled.");
	}

	static bool GetModCfg(BepInPlugin plugin) {
		return cfg.Bind(new ConfigDefinition("plugins", plugin.GUID), true, new ConfigDescription(plugin.Name)).Value;
	}
}
