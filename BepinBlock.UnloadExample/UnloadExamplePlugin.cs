using System;
using BepInEx;
using BepInEx.Bootstrap;
using UnityEngine;
using BepinBlock.RuntimeUnloading;

namespace BepinBlock.UnloadExample;

[BepInPlugin(GUID, NAME, VERSION), BepInDependency("00io.github.TeamDoodz.BepinBlock"), SupportsRuntimeUnloading]
public sealed class UnloadExamplePlugin : BaseUnityPlugin {

	public const string GUID = "io.github.TeamDoodz.BepinBlock.UnloadExample";
	public const string NAME = "BepinBlock.UnloadExample";
	public const string VERSION = "1.0.0";

	bool isQuitting = false;

	private void Awake() {
		Application.quitting += () => isQuitting = true;
		Logger.LogMessage("Mod being loaded");
	}

	private void OnDestroy() {
		if(isQuitting) {
			return;
		}
		Logger.LogMessage("Mod being unloaded");
	}
}
