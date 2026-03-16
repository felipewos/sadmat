using System.Runtime.CompilerServices;
using Microsoft.Windows.ApplicationModel.DynamicDependency.BootstrapCS;

namespace Microsoft.Windows.ApplicationModel.WindowsAppRuntime.Common;

internal class AutoInitialize
{
	[ModuleInitializer]
	internal static void InitializeWindowsAppSDK()
	{
		Microsoft.Windows.ApplicationModel.DynamicDependency.BootstrapCS.AutoInitialize.AccessWindowsAppSDK();
	}
}
