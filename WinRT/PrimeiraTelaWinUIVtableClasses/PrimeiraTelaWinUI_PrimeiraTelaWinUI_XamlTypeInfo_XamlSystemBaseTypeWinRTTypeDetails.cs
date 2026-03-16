using System.Runtime.InteropServices;
using ABI.Microsoft.UI.Xaml.Markup;

namespace WinRT.PrimeiraTelaWinUIVtableClasses;

internal sealed class PrimeiraTelaWinUI_PrimeiraTelaWinUI_XamlTypeInfo_XamlSystemBaseTypeWinRTTypeDetails : IWinRTExposedTypeDetails
{
	public ComWrappers.ComInterfaceEntry[] GetExposedInterfaces()
	{
		return new ComWrappers.ComInterfaceEntry[1]
		{
			new ComWrappers.ComInterfaceEntry
			{
				IID = IXamlTypeMethods.IID,
				Vtable = IXamlTypeMethods.AbiToProjectionVftablePtr
			}
		};
	}
}
