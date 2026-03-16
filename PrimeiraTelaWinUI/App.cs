using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Navigation;
using PrimeiraTelaWinUI.PrimeiraTelaWinUI_XamlTypeInfo;
using PrimeiraTelaWinUI.Views;
using WinRT;
using WinRT.Interop;
using WinRT.PrimeiraTelaWinUIVtableClasses;

namespace PrimeiraTelaWinUI;

[WinRTRuntimeClassName("Microsoft.UI.Xaml.IApplicationOverrides")]
[WinRTExposedType(typeof(PrimeiraTelaWinUI_AppWinRTTypeDetails))]
public class App : Application, IXamlMetadataProvider
{
	private Window window = Window.Current;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private bool _contentLoaded;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private XamlMetaDataProvider __appProvider;

	public static Window? MainWindowInstance { get; private set; }

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	private XamlMetaDataProvider _AppProvider
	{
		get
		{
			if (__appProvider == null)
			{
				__appProvider = new XamlMetaDataProvider();
			}
			return __appProvider;
		}
	}

	public App()
	{
		InitializeComponent();
	}

	protected override void OnLaunched(LaunchActivatedEventArgs e)
	{
		if ((object)window == null)
		{
			window = new Window();
		}
		MainWindowInstance = window;
		window.Title = "SADMAT - Sistema de Apoio à Decisão Multicritério AHP-TOPSIS";
		Frame rootFrame = window.Content as Frame;
		if ((object)rootFrame == null)
		{
			rootFrame = new Frame();
			rootFrame.NavigationFailed += OnNavigationFailed;
			window.Content = rootFrame;
		}
		rootFrame.Navigate(typeof(MainPage), e.Arguments);
		window.Activate();
		SetWindowIcon(window);
	}

	private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
	{
		throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
	}

	private static void SetWindowIcon(Window targetWindow)
	{
		try
		{
			string iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "SADMAT.ico");
			if (File.Exists(iconPath))
			{
				AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(targetWindow))).SetIcon(iconPath);
			}
		}
		catch
		{
		}
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("ms-appx:///App.xaml");
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	public IXamlType GetXamlType(Type type)
	{
		return _AppProvider.GetXamlType(type);
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	public IXamlType GetXamlType(string fullName)
	{
		return _AppProvider.GetXamlType(fullName);
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	public XmlnsDefinition[] GetXmlnsDefinitions()
	{
		return _AppProvider.GetXmlnsDefinitions();
	}
}
