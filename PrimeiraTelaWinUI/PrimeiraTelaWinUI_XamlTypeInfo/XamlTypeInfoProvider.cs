using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.XamlTypeInfo;
using PrimeiraTelaWinUI.Views;
using Windows.Globalization.NumberFormatting;
using Windows.UI;

namespace PrimeiraTelaWinUI.PrimeiraTelaWinUI_XamlTypeInfo;

[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
[DebuggerNonUserCode]
internal class XamlTypeInfoProvider
{
	private Dictionary<string, IXamlType> _xamlTypeCacheByName = new Dictionary<string, IXamlType>();

	private Dictionary<Type, IXamlType> _xamlTypeCacheByType = new Dictionary<Type, IXamlType>();

	private Dictionary<string, IXamlMember> _xamlMembers = new Dictionary<string, IXamlMember>();

	private string[] _typeNameTable;

	private Type[] _typeTable;

	private List<IXamlMetadataProvider> _otherProviders;

	private List<IXamlMetadataProvider> OtherProviders
	{
		get
		{
			if (_otherProviders == null)
			{
				List<IXamlMetadataProvider> otherProviders = new List<IXamlMetadataProvider>();
				IXamlMetadataProvider provider = new XamlControlsXamlMetaDataProvider();
				otherProviders.Add(provider);
				_otherProviders = otherProviders;
			}
			return _otherProviders;
		}
	}

	public IXamlType GetXamlTypeByType(Type type)
	{
		IXamlType xamlType;
		lock (_xamlTypeCacheByType)
		{
			if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
			{
				return xamlType;
			}
			int typeIndex = LookupTypeIndexByType(type);
			if (typeIndex != -1)
			{
				xamlType = CreateXamlType(typeIndex);
			}
			XamlUserType userXamlType = xamlType as XamlUserType;
			if (xamlType == null || (userXamlType != null && userXamlType.IsReturnTypeStub && !userXamlType.IsLocalType))
			{
				IXamlType libXamlType = CheckOtherMetadataProvidersForType(type);
				if (libXamlType != null && (libXamlType.IsConstructible || xamlType == null))
				{
					xamlType = libXamlType;
				}
			}
			if (xamlType != null)
			{
				_xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
				_xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
			}
		}
		return xamlType;
	}

	public IXamlType GetXamlTypeByName(string typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return null;
		}
		IXamlType xamlType;
		lock (_xamlTypeCacheByType)
		{
			if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
			{
				return xamlType;
			}
			int typeIndex = LookupTypeIndexByName(typeName);
			if (typeIndex != -1)
			{
				xamlType = CreateXamlType(typeIndex);
			}
			XamlUserType userXamlType = xamlType as XamlUserType;
			if (xamlType == null || (userXamlType != null && userXamlType.IsReturnTypeStub && !userXamlType.IsLocalType))
			{
				IXamlType libXamlType = CheckOtherMetadataProvidersForName(typeName);
				if (libXamlType != null && (libXamlType.IsConstructible || xamlType == null))
				{
					xamlType = libXamlType;
				}
			}
			if (xamlType != null)
			{
				_xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
				_xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
			}
		}
		return xamlType;
	}

	public IXamlMember GetMemberByLongName(string longMemberName)
	{
		if (string.IsNullOrEmpty(longMemberName))
		{
			return null;
		}
		IXamlMember xamlMember;
		lock (_xamlMembers)
		{
			if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
			{
				return xamlMember;
			}
			xamlMember = CreateXamlMember(longMemberName);
			if (xamlMember != null)
			{
				_xamlMembers.Add(longMemberName, xamlMember);
			}
		}
		return xamlMember;
	}

	private void InitTypeTables()
	{
		_typeNameTable = new string[27];
		_typeNameTable[0] = "Microsoft.UI.Xaml.Controls.XamlControlsResources";
		_typeNameTable[1] = "Microsoft.UI.Xaml.ResourceDictionary";
		_typeNameTable[2] = "Object";
		_typeNameTable[3] = "Boolean";
		_typeNameTable[4] = "Windows.UI.Color";
		_typeNameTable[5] = "System.ValueType";
		_typeNameTable[6] = "Byte";
		_typeNameTable[7] = "PrimeiraTelaWinUI.Views.MainPage";
		_typeNameTable[8] = "Microsoft.UI.Xaml.Controls.Page";
		_typeNameTable[9] = "Microsoft.UI.Xaml.Controls.UserControl";
		_typeNameTable[10] = "Microsoft.UI.Xaml.Controls.NumberBox";
		_typeNameTable[11] = "Microsoft.UI.Xaml.Controls.Control";
		_typeNameTable[12] = "Double";
		_typeNameTable[13] = "Microsoft.UI.Xaml.Controls.NumberBoxSpinButtonPlacementMode";
		_typeNameTable[14] = "System.Enum";
		_typeNameTable[15] = "Microsoft.UI.Xaml.DataTemplate";
		_typeNameTable[16] = "Windows.Globalization.NumberFormatting.INumberFormatter2";
		_typeNameTable[17] = "String";
		_typeNameTable[18] = "Microsoft.UI.Xaml.Controls.Primitives.FlyoutBase";
		_typeNameTable[19] = "Microsoft.UI.Xaml.Media.SolidColorBrush";
		_typeNameTable[20] = "Microsoft.UI.Xaml.TextReadingOrder";
		_typeNameTable[21] = "Microsoft.UI.Xaml.Controls.NumberBoxValidationMode";
		_typeNameTable[22] = "PrimeiraTelaWinUI.Views.ProjectDetailsPage";
		_typeNameTable[23] = "Microsoft.UI.Xaml.Controls.TreeViewNode";
		_typeNameTable[24] = "Microsoft.UI.Xaml.DependencyObject";
		_typeNameTable[25] = "System.Collections.Generic.IList`1<Microsoft.UI.Xaml.Controls.TreeViewNode>";
		_typeNameTable[26] = "Int32";
		_typeTable = new Type[27];
		_typeTable[0] = typeof(XamlControlsResources);
		_typeTable[1] = typeof(ResourceDictionary);
		_typeTable[2] = typeof(object);
		_typeTable[3] = typeof(bool);
		_typeTable[4] = typeof(Color);
		_typeTable[5] = typeof(ValueType);
		_typeTable[6] = typeof(byte);
		_typeTable[7] = typeof(MainPage);
		_typeTable[8] = typeof(Page);
		_typeTable[9] = typeof(UserControl);
		_typeTable[10] = typeof(NumberBox);
		_typeTable[11] = typeof(Control);
		_typeTable[12] = typeof(double);
		_typeTable[13] = typeof(NumberBoxSpinButtonPlacementMode);
		_typeTable[14] = typeof(Enum);
		_typeTable[15] = typeof(DataTemplate);
		_typeTable[16] = typeof(INumberFormatter2);
		_typeTable[17] = typeof(string);
		_typeTable[18] = typeof(FlyoutBase);
		_typeTable[19] = typeof(SolidColorBrush);
		_typeTable[20] = typeof(TextReadingOrder);
		_typeTable[21] = typeof(NumberBoxValidationMode);
		_typeTable[22] = typeof(ProjectDetailsPage);
		_typeTable[23] = typeof(TreeViewNode);
		_typeTable[24] = typeof(DependencyObject);
		_typeTable[25] = typeof(IList<TreeViewNode>);
		_typeTable[26] = typeof(int);
	}

	private int LookupTypeIndexByName(string typeName)
	{
		if (_typeNameTable == null)
		{
			InitTypeTables();
		}
		for (int i = 0; i < _typeNameTable.Length; i++)
		{
			if (string.CompareOrdinal(_typeNameTable[i], typeName) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	private int LookupTypeIndexByType(Type type)
	{
		if (_typeTable == null)
		{
			InitTypeTables();
		}
		for (int i = 0; i < _typeTable.Length; i++)
		{
			if (type == _typeTable[i])
			{
				return i;
			}
		}
		return -1;
	}

	private object Activate_0_XamlControlsResources()
	{
		return new XamlControlsResources();
	}

	private object Activate_7_MainPage()
	{
		return new MainPage();
	}

	private object Activate_10_NumberBox()
	{
		return new NumberBox();
	}

	private object Activate_22_ProjectDetailsPage()
	{
		return new ProjectDetailsPage();
	}

	private object Activate_23_TreeViewNode()
	{
		return new TreeViewNode();
	}

	private void StaticInitializer_0_XamlControlsResources()
	{
		RuntimeHelpers.RunClassConstructor(typeof(XamlControlsResources).TypeHandle);
	}

	private void StaticInitializer_4_Color()
	{
		RuntimeHelpers.RunClassConstructor(typeof(Color).TypeHandle);
	}

	private void StaticInitializer_5_ValueType()
	{
		RuntimeHelpers.RunClassConstructor(typeof(ValueType).TypeHandle);
	}

	private void StaticInitializer_6_Byte()
	{
		RuntimeHelpers.RunClassConstructor(typeof(byte).TypeHandle);
	}

	private void StaticInitializer_7_MainPage()
	{
		RuntimeHelpers.RunClassConstructor(typeof(MainPage).TypeHandle);
	}

	private void StaticInitializer_10_NumberBox()
	{
		RuntimeHelpers.RunClassConstructor(typeof(NumberBox).TypeHandle);
	}

	private void StaticInitializer_13_NumberBoxSpinButtonPlacementMode()
	{
		RuntimeHelpers.RunClassConstructor(typeof(NumberBoxSpinButtonPlacementMode).TypeHandle);
	}

	private void StaticInitializer_14_Enum()
	{
		RuntimeHelpers.RunClassConstructor(typeof(Enum).TypeHandle);
	}

	private void StaticInitializer_16_INumberFormatter2()
	{
		RuntimeHelpers.RunClassConstructor(typeof(INumberFormatter2).TypeHandle);
	}

	private void StaticInitializer_21_NumberBoxValidationMode()
	{
		RuntimeHelpers.RunClassConstructor(typeof(NumberBoxValidationMode).TypeHandle);
	}

	private void StaticInitializer_22_ProjectDetailsPage()
	{
		RuntimeHelpers.RunClassConstructor(typeof(ProjectDetailsPage).TypeHandle);
	}

	private void StaticInitializer_23_TreeViewNode()
	{
		RuntimeHelpers.RunClassConstructor(typeof(TreeViewNode).TypeHandle);
	}

	private void StaticInitializer_25_IList()
	{
		RuntimeHelpers.RunClassConstructor(typeof(IList<TreeViewNode>).TypeHandle);
	}

	private void MapAdd_0_XamlControlsResources(object instance, object key, object item)
	{
		((IDictionary<object, object>)instance).Add(key, item);
	}

	private void VectorAdd_25_IList(object instance, object item)
	{
		ICollection<TreeViewNode> obj = (ICollection<TreeViewNode>)instance;
		TreeViewNode newItem = (TreeViewNode)item;
		obj.Add(newItem);
	}

	private IXamlType CreateXamlType(int typeIndex)
	{
		XamlSystemBaseType xamlType = null;
		string typeName = _typeNameTable[typeIndex];
		Type type = _typeTable[typeIndex];
		switch (typeIndex)
		{
		case 0:
		{
			XamlUserType xamlUserType11 = new XamlUserType(this, typeName, type, GetXamlTypeByName("Microsoft.UI.Xaml.ResourceDictionary"));
			xamlUserType11.Activator = Activate_0_XamlControlsResources;
			xamlUserType11.StaticInitializer = StaticInitializer_0_XamlControlsResources;
			xamlUserType11.DictionaryAdd = MapAdd_0_XamlControlsResources;
			xamlUserType11.AddMemberName("UseCompactResources");
			xamlType = xamlUserType11;
			break;
		}
		case 1:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 2:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 3:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 4:
		{
			XamlUserType xamlUserType10 = new XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
			xamlUserType10.StaticInitializer = StaticInitializer_4_Color;
			xamlUserType10.AddMemberName("A");
			xamlUserType10.AddMemberName("R");
			xamlUserType10.AddMemberName("G");
			xamlUserType10.AddMemberName("B");
			xamlType = xamlUserType10;
			break;
		}
		case 5:
			xamlType = new XamlUserType(this, typeName, type, GetXamlTypeByName("Object"))
			{
				StaticInitializer = StaticInitializer_5_ValueType
			};
			break;
		case 6:
		{
			XamlUserType xamlUserType9 = new XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
			xamlUserType9.StaticInitializer = StaticInitializer_6_Byte;
			xamlUserType9.SetIsReturnTypeStub();
			xamlType = xamlUserType9;
			break;
		}
		case 7:
		{
			XamlUserType xamlUserType8 = new XamlUserType(this, typeName, type, GetXamlTypeByName("Microsoft.UI.Xaml.Controls.Page"));
			xamlUserType8.Activator = Activate_7_MainPage;
			xamlUserType8.StaticInitializer = StaticInitializer_7_MainPage;
			xamlUserType8.SetIsLocalType();
			xamlType = xamlUserType8;
			break;
		}
		case 8:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 9:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 10:
		{
			XamlUserType xamlUserType7 = new XamlUserType(this, typeName, type, GetXamlTypeByName("Microsoft.UI.Xaml.Controls.Control"));
			xamlUserType7.Activator = Activate_10_NumberBox;
			xamlUserType7.StaticInitializer = StaticInitializer_10_NumberBox;
			xamlUserType7.AddMemberName("Minimum");
			xamlUserType7.AddMemberName("Maximum");
			xamlUserType7.AddMemberName("SmallChange");
			xamlUserType7.AddMemberName("Value");
			xamlUserType7.AddMemberName("SpinButtonPlacementMode");
			xamlUserType7.AddMemberName("AcceptsExpression");
			xamlUserType7.AddMemberName("Description");
			xamlUserType7.AddMemberName("Header");
			xamlUserType7.AddMemberName("HeaderTemplate");
			xamlUserType7.AddMemberName("IsWrapEnabled");
			xamlUserType7.AddMemberName("LargeChange");
			xamlUserType7.AddMemberName("NumberFormatter");
			xamlUserType7.AddMemberName("PlaceholderText");
			xamlUserType7.AddMemberName("PreventKeyboardDisplayOnProgrammaticFocus");
			xamlUserType7.AddMemberName("SelectionFlyout");
			xamlUserType7.AddMemberName("SelectionHighlightColor");
			xamlUserType7.AddMemberName("Text");
			xamlUserType7.AddMemberName("TextReadingOrder");
			xamlUserType7.AddMemberName("ValidationMode");
			xamlType = xamlUserType7;
			break;
		}
		case 11:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 12:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 13:
		{
			XamlUserType xamlUserType6 = new XamlUserType(this, typeName, type, GetXamlTypeByName("System.Enum"));
			xamlUserType6.StaticInitializer = StaticInitializer_13_NumberBoxSpinButtonPlacementMode;
			xamlUserType6.AddEnumValue("Hidden", NumberBoxSpinButtonPlacementMode.Hidden);
			xamlUserType6.AddEnumValue("Compact", NumberBoxSpinButtonPlacementMode.Compact);
			xamlUserType6.AddEnumValue("Inline", NumberBoxSpinButtonPlacementMode.Inline);
			xamlType = xamlUserType6;
			break;
		}
		case 14:
			xamlType = new XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"))
			{
				StaticInitializer = StaticInitializer_14_Enum
			};
			break;
		case 15:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 16:
		{
			XamlUserType xamlUserType5 = new XamlUserType(this, typeName, type, null);
			xamlUserType5.StaticInitializer = StaticInitializer_16_INumberFormatter2;
			xamlUserType5.SetIsReturnTypeStub();
			xamlType = xamlUserType5;
			break;
		}
		case 17:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 18:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 19:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 20:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 21:
		{
			XamlUserType xamlUserType4 = new XamlUserType(this, typeName, type, GetXamlTypeByName("System.Enum"));
			xamlUserType4.StaticInitializer = StaticInitializer_21_NumberBoxValidationMode;
			xamlUserType4.AddEnumValue("InvalidInputOverwritten", NumberBoxValidationMode.InvalidInputOverwritten);
			xamlUserType4.AddEnumValue("Disabled", NumberBoxValidationMode.Disabled);
			xamlType = xamlUserType4;
			break;
		}
		case 22:
		{
			XamlUserType xamlUserType3 = new XamlUserType(this, typeName, type, GetXamlTypeByName("Microsoft.UI.Xaml.Controls.Page"));
			xamlUserType3.Activator = Activate_22_ProjectDetailsPage;
			xamlUserType3.StaticInitializer = StaticInitializer_22_ProjectDetailsPage;
			xamlUserType3.SetIsLocalType();
			xamlType = xamlUserType3;
			break;
		}
		case 23:
		{
			XamlUserType xamlUserType2 = new XamlUserType(this, typeName, type, GetXamlTypeByName("Microsoft.UI.Xaml.DependencyObject"));
			xamlUserType2.Activator = Activate_23_TreeViewNode;
			xamlUserType2.StaticInitializer = StaticInitializer_23_TreeViewNode;
			xamlUserType2.AddMemberName("Children");
			xamlUserType2.AddMemberName("Content");
			xamlUserType2.AddMemberName("Depth");
			xamlUserType2.AddMemberName("HasChildren");
			xamlUserType2.AddMemberName("HasUnrealizedChildren");
			xamlUserType2.AddMemberName("IsExpanded");
			xamlUserType2.AddMemberName("Parent");
			xamlUserType2.SetIsBindable();
			xamlType = xamlUserType2;
			break;
		}
		case 24:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		case 25:
		{
			XamlUserType xamlUserType = new XamlUserType(this, typeName, type, null);
			xamlUserType.StaticInitializer = StaticInitializer_25_IList;
			xamlUserType.CollectionAdd = VectorAdd_25_IList;
			xamlUserType.SetIsReturnTypeStub();
			xamlType = xamlUserType;
			break;
		}
		case 26:
			xamlType = new XamlSystemBaseType(typeName, type);
			break;
		}
		return xamlType;
	}

	private IXamlType CheckOtherMetadataProvidersForName(string typeName)
	{
		IXamlType xamlType = null;
		IXamlType foundXamlType = null;
		foreach (IXamlMetadataProvider otherProvider in OtherProviders)
		{
			xamlType = otherProvider.GetXamlType(typeName);
			if (xamlType != null)
			{
				if (xamlType.IsConstructible)
				{
					return xamlType;
				}
				foundXamlType = xamlType;
			}
		}
		return foundXamlType;
	}

	private IXamlType CheckOtherMetadataProvidersForType(Type type)
	{
		IXamlType xamlType = null;
		IXamlType foundXamlType = null;
		foreach (IXamlMetadataProvider otherProvider in OtherProviders)
		{
			xamlType = otherProvider.GetXamlType(type);
			if (xamlType != null)
			{
				if (xamlType.IsConstructible)
				{
					return xamlType;
				}
				foundXamlType = xamlType;
			}
		}
		return foundXamlType;
	}

	private object get_0_XamlControlsResources_UseCompactResources(object instance)
	{
		return ((XamlControlsResources)instance).UseCompactResources;
	}

	private void set_0_XamlControlsResources_UseCompactResources(object instance, object Value)
	{
		((XamlControlsResources)instance).UseCompactResources = (bool)Value;
	}

	private object get_1_Color_A(object instance)
	{
		return ((Color)instance).A;
	}

	private void set_1_Color_A(object instance, object Value)
	{
		Color that = (Color)instance;
		that.A = (byte)Value;
	}

	private object get_2_Color_R(object instance)
	{
		return ((Color)instance).R;
	}

	private void set_2_Color_R(object instance, object Value)
	{
		Color that = (Color)instance;
		that.R = (byte)Value;
	}

	private object get_3_Color_G(object instance)
	{
		return ((Color)instance).G;
	}

	private void set_3_Color_G(object instance, object Value)
	{
		Color that = (Color)instance;
		that.G = (byte)Value;
	}

	private object get_4_Color_B(object instance)
	{
		return ((Color)instance).B;
	}

	private void set_4_Color_B(object instance, object Value)
	{
		Color that = (Color)instance;
		that.B = (byte)Value;
	}

	private object get_5_NumberBox_Minimum(object instance)
	{
		return ((NumberBox)instance).Minimum;
	}

	private void set_5_NumberBox_Minimum(object instance, object Value)
	{
		((NumberBox)instance).Minimum = (double)Value;
	}

	private object get_6_NumberBox_Maximum(object instance)
	{
		return ((NumberBox)instance).Maximum;
	}

	private void set_6_NumberBox_Maximum(object instance, object Value)
	{
		((NumberBox)instance).Maximum = (double)Value;
	}

	private object get_7_NumberBox_SmallChange(object instance)
	{
		return ((NumberBox)instance).SmallChange;
	}

	private void set_7_NumberBox_SmallChange(object instance, object Value)
	{
		((NumberBox)instance).SmallChange = (double)Value;
	}

	private object get_8_NumberBox_Value(object instance)
	{
		return ((NumberBox)instance).Value;
	}

	private void set_8_NumberBox_Value(object instance, object Value)
	{
		((NumberBox)instance).Value = (double)Value;
	}

	private object get_9_NumberBox_SpinButtonPlacementMode(object instance)
	{
		return ((NumberBox)instance).SpinButtonPlacementMode;
	}

	private void set_9_NumberBox_SpinButtonPlacementMode(object instance, object Value)
	{
		((NumberBox)instance).SpinButtonPlacementMode = (NumberBoxSpinButtonPlacementMode)Value;
	}

	private object get_10_NumberBox_AcceptsExpression(object instance)
	{
		return ((NumberBox)instance).AcceptsExpression;
	}

	private void set_10_NumberBox_AcceptsExpression(object instance, object Value)
	{
		((NumberBox)instance).AcceptsExpression = (bool)Value;
	}

	private object get_11_NumberBox_Description(object instance)
	{
		return ((NumberBox)instance).Description;
	}

	private void set_11_NumberBox_Description(object instance, object Value)
	{
		((NumberBox)instance).Description = Value;
	}

	private object get_12_NumberBox_Header(object instance)
	{
		return ((NumberBox)instance).Header;
	}

	private void set_12_NumberBox_Header(object instance, object Value)
	{
		((NumberBox)instance).Header = Value;
	}

	private object get_13_NumberBox_HeaderTemplate(object instance)
	{
		return ((NumberBox)instance).HeaderTemplate;
	}

	private void set_13_NumberBox_HeaderTemplate(object instance, object Value)
	{
		((NumberBox)instance).HeaderTemplate = (DataTemplate)Value;
	}

	private object get_14_NumberBox_IsWrapEnabled(object instance)
	{
		return ((NumberBox)instance).IsWrapEnabled;
	}

	private void set_14_NumberBox_IsWrapEnabled(object instance, object Value)
	{
		((NumberBox)instance).IsWrapEnabled = (bool)Value;
	}

	private object get_15_NumberBox_LargeChange(object instance)
	{
		return ((NumberBox)instance).LargeChange;
	}

	private void set_15_NumberBox_LargeChange(object instance, object Value)
	{
		((NumberBox)instance).LargeChange = (double)Value;
	}

	private object get_16_NumberBox_NumberFormatter(object instance)
	{
		return ((NumberBox)instance).NumberFormatter;
	}

	private void set_16_NumberBox_NumberFormatter(object instance, object Value)
	{
		((NumberBox)instance).NumberFormatter = (INumberFormatter2)Value;
	}

	private object get_17_NumberBox_PlaceholderText(object instance)
	{
		return ((NumberBox)instance).PlaceholderText;
	}

	private void set_17_NumberBox_PlaceholderText(object instance, object Value)
	{
		((NumberBox)instance).PlaceholderText = (string)Value;
	}

	private object get_18_NumberBox_PreventKeyboardDisplayOnProgrammaticFocus(object instance)
	{
		return ((NumberBox)instance).PreventKeyboardDisplayOnProgrammaticFocus;
	}

	private void set_18_NumberBox_PreventKeyboardDisplayOnProgrammaticFocus(object instance, object Value)
	{
		((NumberBox)instance).PreventKeyboardDisplayOnProgrammaticFocus = (bool)Value;
	}

	private object get_19_NumberBox_SelectionFlyout(object instance)
	{
		return ((NumberBox)instance).SelectionFlyout;
	}

	private void set_19_NumberBox_SelectionFlyout(object instance, object Value)
	{
		((NumberBox)instance).SelectionFlyout = (FlyoutBase)Value;
	}

	private object get_20_NumberBox_SelectionHighlightColor(object instance)
	{
		return ((NumberBox)instance).SelectionHighlightColor;
	}

	private void set_20_NumberBox_SelectionHighlightColor(object instance, object Value)
	{
		((NumberBox)instance).SelectionHighlightColor = (SolidColorBrush)Value;
	}

	private object get_21_NumberBox_Text(object instance)
	{
		return ((NumberBox)instance).Text;
	}

	private void set_21_NumberBox_Text(object instance, object Value)
	{
		((NumberBox)instance).Text = (string)Value;
	}

	private object get_22_NumberBox_TextReadingOrder(object instance)
	{
		return ((NumberBox)instance).TextReadingOrder;
	}

	private void set_22_NumberBox_TextReadingOrder(object instance, object Value)
	{
		((NumberBox)instance).TextReadingOrder = (TextReadingOrder)Value;
	}

	private object get_23_NumberBox_ValidationMode(object instance)
	{
		return ((NumberBox)instance).ValidationMode;
	}

	private void set_23_NumberBox_ValidationMode(object instance, object Value)
	{
		((NumberBox)instance).ValidationMode = (NumberBoxValidationMode)Value;
	}

	private object get_24_TreeViewNode_Children(object instance)
	{
		return ((TreeViewNode)instance).Children;
	}

	private object get_25_TreeViewNode_Content(object instance)
	{
		return ((TreeViewNode)instance).Content;
	}

	private void set_25_TreeViewNode_Content(object instance, object Value)
	{
		((TreeViewNode)instance).Content = Value;
	}

	private object get_26_TreeViewNode_Depth(object instance)
	{
		return ((TreeViewNode)instance).Depth;
	}

	private object get_27_TreeViewNode_HasChildren(object instance)
	{
		return ((TreeViewNode)instance).HasChildren;
	}

	private object get_28_TreeViewNode_HasUnrealizedChildren(object instance)
	{
		return ((TreeViewNode)instance).HasUnrealizedChildren;
	}

	private void set_28_TreeViewNode_HasUnrealizedChildren(object instance, object Value)
	{
		((TreeViewNode)instance).HasUnrealizedChildren = (bool)Value;
	}

	private object get_29_TreeViewNode_IsExpanded(object instance)
	{
		return ((TreeViewNode)instance).IsExpanded;
	}

	private void set_29_TreeViewNode_IsExpanded(object instance, object Value)
	{
		((TreeViewNode)instance).IsExpanded = (bool)Value;
	}

	private object get_30_TreeViewNode_Parent(object instance)
	{
		return ((TreeViewNode)instance).Parent;
	}

	private IXamlMember CreateXamlMember(string longMemberName)
	{
		XamlMember xamlMember = null;
		switch (longMemberName)
		{
		case "Microsoft.UI.Xaml.Controls.XamlControlsResources.UseCompactResources":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.XamlControlsResources");
			xamlMember = new XamlMember(this, "UseCompactResources", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_0_XamlControlsResources_UseCompactResources;
			xamlMember.Setter = set_0_XamlControlsResources_UseCompactResources;
			break;
		case "Windows.UI.Color.A":
			_ = (XamlUserType)GetXamlTypeByName("Windows.UI.Color");
			xamlMember = new XamlMember(this, "A", "Byte");
			xamlMember.Getter = get_1_Color_A;
			xamlMember.Setter = set_1_Color_A;
			break;
		case "Windows.UI.Color.R":
			_ = (XamlUserType)GetXamlTypeByName("Windows.UI.Color");
			xamlMember = new XamlMember(this, "R", "Byte");
			xamlMember.Getter = get_2_Color_R;
			xamlMember.Setter = set_2_Color_R;
			break;
		case "Windows.UI.Color.G":
			_ = (XamlUserType)GetXamlTypeByName("Windows.UI.Color");
			xamlMember = new XamlMember(this, "G", "Byte");
			xamlMember.Getter = get_3_Color_G;
			xamlMember.Setter = set_3_Color_G;
			break;
		case "Windows.UI.Color.B":
			_ = (XamlUserType)GetXamlTypeByName("Windows.UI.Color");
			xamlMember = new XamlMember(this, "B", "Byte");
			xamlMember.Getter = get_4_Color_B;
			xamlMember.Setter = set_4_Color_B;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.Minimum":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "Minimum", "Double");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_5_NumberBox_Minimum;
			xamlMember.Setter = set_5_NumberBox_Minimum;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.Maximum":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "Maximum", "Double");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_6_NumberBox_Maximum;
			xamlMember.Setter = set_6_NumberBox_Maximum;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.SmallChange":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "SmallChange", "Double");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_7_NumberBox_SmallChange;
			xamlMember.Setter = set_7_NumberBox_SmallChange;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.Value":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "Value", "Double");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_8_NumberBox_Value;
			xamlMember.Setter = set_8_NumberBox_Value;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.SpinButtonPlacementMode":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "SpinButtonPlacementMode", "Microsoft.UI.Xaml.Controls.NumberBoxSpinButtonPlacementMode");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_9_NumberBox_SpinButtonPlacementMode;
			xamlMember.Setter = set_9_NumberBox_SpinButtonPlacementMode;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.AcceptsExpression":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "AcceptsExpression", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_10_NumberBox_AcceptsExpression;
			xamlMember.Setter = set_10_NumberBox_AcceptsExpression;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.Description":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "Description", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_11_NumberBox_Description;
			xamlMember.Setter = set_11_NumberBox_Description;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.Header":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "Header", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_12_NumberBox_Header;
			xamlMember.Setter = set_12_NumberBox_Header;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.HeaderTemplate":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "HeaderTemplate", "Microsoft.UI.Xaml.DataTemplate");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_13_NumberBox_HeaderTemplate;
			xamlMember.Setter = set_13_NumberBox_HeaderTemplate;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.IsWrapEnabled":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "IsWrapEnabled", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_14_NumberBox_IsWrapEnabled;
			xamlMember.Setter = set_14_NumberBox_IsWrapEnabled;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.LargeChange":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "LargeChange", "Double");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_15_NumberBox_LargeChange;
			xamlMember.Setter = set_15_NumberBox_LargeChange;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.NumberFormatter":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "NumberFormatter", "Windows.Globalization.NumberFormatting.INumberFormatter2");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_16_NumberBox_NumberFormatter;
			xamlMember.Setter = set_16_NumberBox_NumberFormatter;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.PlaceholderText":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "PlaceholderText", "String");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_17_NumberBox_PlaceholderText;
			xamlMember.Setter = set_17_NumberBox_PlaceholderText;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.PreventKeyboardDisplayOnProgrammaticFocus":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "PreventKeyboardDisplayOnProgrammaticFocus", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_18_NumberBox_PreventKeyboardDisplayOnProgrammaticFocus;
			xamlMember.Setter = set_18_NumberBox_PreventKeyboardDisplayOnProgrammaticFocus;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.SelectionFlyout":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "SelectionFlyout", "Microsoft.UI.Xaml.Controls.Primitives.FlyoutBase");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_19_NumberBox_SelectionFlyout;
			xamlMember.Setter = set_19_NumberBox_SelectionFlyout;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.SelectionHighlightColor":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "SelectionHighlightColor", "Microsoft.UI.Xaml.Media.SolidColorBrush");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_20_NumberBox_SelectionHighlightColor;
			xamlMember.Setter = set_20_NumberBox_SelectionHighlightColor;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.Text":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "Text", "String");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_21_NumberBox_Text;
			xamlMember.Setter = set_21_NumberBox_Text;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.TextReadingOrder":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "TextReadingOrder", "Microsoft.UI.Xaml.TextReadingOrder");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_22_NumberBox_TextReadingOrder;
			xamlMember.Setter = set_22_NumberBox_TextReadingOrder;
			break;
		case "Microsoft.UI.Xaml.Controls.NumberBox.ValidationMode":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.NumberBox");
			xamlMember = new XamlMember(this, "ValidationMode", "Microsoft.UI.Xaml.Controls.NumberBoxValidationMode");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_23_NumberBox_ValidationMode;
			xamlMember.Setter = set_23_NumberBox_ValidationMode;
			break;
		case "Microsoft.UI.Xaml.Controls.TreeViewNode.Children":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember = new XamlMember(this, "Children", "System.Collections.Generic.IList`1<Microsoft.UI.Xaml.Controls.TreeViewNode>");
			xamlMember.Getter = get_24_TreeViewNode_Children;
			xamlMember.SetIsReadOnly();
			break;
		case "Microsoft.UI.Xaml.Controls.TreeViewNode.Content":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember = new XamlMember(this, "Content", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_25_TreeViewNode_Content;
			xamlMember.Setter = set_25_TreeViewNode_Content;
			break;
		case "Microsoft.UI.Xaml.Controls.TreeViewNode.Depth":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember = new XamlMember(this, "Depth", "Int32");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_26_TreeViewNode_Depth;
			xamlMember.SetIsReadOnly();
			break;
		case "Microsoft.UI.Xaml.Controls.TreeViewNode.HasChildren":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember = new XamlMember(this, "HasChildren", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_27_TreeViewNode_HasChildren;
			xamlMember.SetIsReadOnly();
			break;
		case "Microsoft.UI.Xaml.Controls.TreeViewNode.HasUnrealizedChildren":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember = new XamlMember(this, "HasUnrealizedChildren", "Boolean");
			xamlMember.Getter = get_28_TreeViewNode_HasUnrealizedChildren;
			xamlMember.Setter = set_28_TreeViewNode_HasUnrealizedChildren;
			break;
		case "Microsoft.UI.Xaml.Controls.TreeViewNode.IsExpanded":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember = new XamlMember(this, "IsExpanded", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_29_TreeViewNode_IsExpanded;
			xamlMember.Setter = set_29_TreeViewNode_IsExpanded;
			break;
		case "Microsoft.UI.Xaml.Controls.TreeViewNode.Parent":
			_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember = new XamlMember(this, "Parent", "Microsoft.UI.Xaml.Controls.TreeViewNode");
			xamlMember.Getter = get_30_TreeViewNode_Parent;
			xamlMember.SetIsReadOnly();
			break;
		}
		return xamlMember;
	}
}
