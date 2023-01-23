using System;
using System.Collections.Generic;
using System.Text;

namespace BepinBlock;

/// <summary>
/// Tells the plugin enabling system that this plugin can be enabled/disabled at runtime. If you add this sttribute to a plugin, make sure to place your initialization code in <c>OnEnable</c> and cleanup code in <c>OnDisable</c>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class SupportsDisableAttribute : Attribute {
    public SupportsDisableAttribute() {
       
    }
}
