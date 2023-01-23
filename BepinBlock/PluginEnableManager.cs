using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BepInEx;
using BepInEx.Bootstrap;

namespace BepinBlock;

public static class PluginEnableManager {
	static Dictionary<string, PluginInfo> disabledPlugins = new();

	public static void SetPluginEnabled(string guid, bool enabled) {
		if(!PluginSupportsDisabling(guid)) {
			throw new ArgumentException("Plugin does not support unloading.", nameof(guid));
		}

		if(enabled) {
			Chainloader.PluginInfos.Add(guid, disabledPlugins[guid]);
			disabledPlugins[guid].Instance.enabled = true;
			disabledPlugins.Remove(guid);
		} else {
			Chainloader.PluginInfos[guid].Instance.enabled = false;
			disabledPlugins.Add(guid, Chainloader.PluginInfos[guid]);
			Chainloader.PluginInfos.Remove(guid);
		}
	}

	public static bool PluginSupportsDisabling(string guid) {
		return Chainloader.PluginInfos[guid].Instance.GetType().GetCustomAttribute<SupportsDisableAttribute>() != null;
	}
}
