using System;
using System.Collections.Generic;
using System.Text;

namespace BepinBlock.RuntimeUnloading;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class SupportsRuntimeUnloadingAttribute : Attribute {
    public SupportsRuntimeUnloadingAttribute() {
    }
}
