using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;

namespace BepinBlock.DisableSample;

[SupportsDisable]
[BepInPlugin("thingy", "weywy8efgwe", "1.0.0")]
[BepInDependency("io.github.TeamDoodz.BepinBlock")]
public sealed class MainPlugin : BaseUnityPlugin {
	private void OnEnable() {
		Logger.LogMessage("Plugin Enabled");
	}

	private void OnDisable() {
		Logger.LogMessage("Plugin Disabled");
	}
}
