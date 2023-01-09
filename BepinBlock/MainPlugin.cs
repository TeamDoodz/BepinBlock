using System;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace BepinBlock;

[BepInPlugin(GUID, NAME, VERSION)]
public sealed class MainPlugin : BaseUnityPlugin {

	public const string GUID = "00io.github.TeamDoodz.BepinBlock"; // Place zeros at start of GUID so that this mod is loaded first
	public const string NAME = "BepinBlock";
	public const string VERSION = "1.0.0";

	internal static ManualLogSource? logger;

	// Awake is called the moment the plugin component is created.
	private void Awake() {
		Logger.LogMessage("BepinBlock was loaded.");
		logger = Logger;
		BlockPluginPatch.Initialize();
	}

	// Start is called on the first update frame, i.e. some time after all plugins are loaded.
	private void Start() {
		Logger.LogMessage("All plugins finished loading.");
	}
}
