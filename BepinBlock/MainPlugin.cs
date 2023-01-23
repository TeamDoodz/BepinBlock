using System;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace BepinBlock;

[BepInPlugin(GUID, NAME, VERSION)]
public sealed class MainPlugin : BaseUnityPlugin {

	public const string GUID = "io.github.TeamDoodz.BepinBlock"; // Place zeros at start of GUID so that this mod is loaded first
	public const string NAME = "BepinBlock";
	public const string VERSION = "1.0.0";

	internal static ManualLogSource? logger;

	private void Awake() {
		Logger.LogMessage("BepinBlock was loaded.");
		logger = Logger;
	}
}
