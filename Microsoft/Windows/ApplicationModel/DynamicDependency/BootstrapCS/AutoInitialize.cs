using System;

namespace Microsoft.Windows.ApplicationModel.DynamicDependency.BootstrapCS;

internal class AutoInitialize
{
	internal static Bootstrap.InitializeOptions Options => Bootstrap.InitializeOptions.OnNoMatch_ShowUI;

	internal static void AccessWindowsAppSDK()
	{
		string versionTag = "";
		PackageVersion minVersion = new PackageVersion(2251803120872128512uL);
		Bootstrap.InitializeOptions options = Options;
		int hr = 0;
		if (!Bootstrap.TryInitialize(65544u, versionTag, minVersion, options, out hr))
		{
			Environment.Exit(hr);
		}
	}
}
