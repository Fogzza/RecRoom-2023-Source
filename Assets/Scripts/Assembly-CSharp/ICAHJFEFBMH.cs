using System;
using System.Collections.Generic;
using RRUI.Data;
using RRUI.Dialogs;
using RecRoom.Core.Creation;
using RecRoom.Core.Storefronts;
using RecRoom.Systems.PlayerRoles;
using TMPro;
using UnityEngine;

public static class ICAHJFEFBMH
{
	public enum NJBHDPOJINB
	{
		SERVER = 0,
		ENABLED = 1,
		DISABLED = 2
	}

	public delegate ValueType KHGNFLAKFLA<InstanceType, ValueType>(InstanceType HALGBNCPBPN);

	public delegate void KAGMLMLEFBL<InstanceType, ValueType>(InstanceType HALGBNCPBPN, ValueType COPJLEBADIN);

	private sealed class DHCKBIKAHNM
	{
		public Func<float> valueGetter;

		public bool clampRange;

		public float minValue;

		public float maxValue;

		public Action<float> valueSetter;

		internal string _003CCreateFloatInputFieldData_003Eb__0()
		{
			return null;
		}

		internal void _003CCreateFloatInputFieldData_003Eb__1(string v)
		{
		}
	}

	private sealed class HCJILJFDGEM<ObjectType>
	{
		public List<ObjectType> objects;

		public Func<float> valueGetter;

		public bool clampRange;

		public float minValue;

		public float maxValue;

		public Action<float> valueSetter;

		internal global::AIKFPDCGNMF<string> _003CCreateFloatInputFieldData_003Eb__0()
		{
			return default;
		}

		internal void _003CCreateFloatInputFieldData_003Eb__1(string v)
		{
		}
	}

	private sealed class CCGCGIOJJLB
	{
		public Func<int> valueGetter;

		public bool clampRange;

		public int minValue;

		public int maxValue;

		public Action<int> valueSetter;

		internal string _003CCreateIntInputFieldData_003Eb__0()
		{
			return null;
		}

		internal void _003CCreateIntInputFieldData_003Eb__1(string v)
		{
		}
	}

	private sealed class JCDMOLHHDNF<ObjectType>
	{
		public List<ObjectType> objects;

		public Func<int> valueGetter;

		public bool clampRange;

		public int minValue;

		public int maxValue;

		public Action<int> valueSetter;

		internal global::AIKFPDCGNMF<string> _003CCreateIntInputFieldData_003Eb__0()
		{
			return default;
		}

		internal void _003CCreateIntInputFieldData_003Eb__1(string v)
		{
		}
	}

	private sealed class KIAIINEJACF
	{
		public Func<int> valueGetter;

		public Action<int> valueSetter;

		internal float _003CCreateIntSliderData_003Eb__0()
		{
			return 0f;
		}

		internal void _003CCreateIntSliderData_003Eb__1(float value)
		{
		}
	}

	private sealed class OBCOAEOLDKD<ObjectType>
	{
		public Action<List<ObjectType>, bool> invokeOnceBeforeSet;

		public List<ObjectType> objects;

		public Action<bool> valueSetter;

		internal void _003CCreateToggleData_003Eb__0(bool value)
		{
		}
	}

	private sealed class GJOEHCDELIM
	{
		public JMEBCLBPNLN dynamicPropertyPanelData;

		internal bool _003CCreatePropertyPanel_003Eb__0()
		{
			return false;
		}
	}

	private sealed class NNOHGBGPAII<DataClassType, EnumType> where EnumType : Enum
	{
		public List<DataClassType> objects;

		public Func<int> selectedItemGetter;

		public BAGBAGLIICE dropdownData;

		internal global::AIKFPDCGNMF<object> _003CCreateOneLineDropdownDataFromEnum_003Eb__1()
		{
			return default;
		}

		internal bool _003CCreateOneLineDropdownDataFromEnum_003Eb__0()
		{
			return false;
		}
	}

	private sealed class EBPJFNDJNCH<T> where T : Enum
	{
		public Func<T> selectedItemGetter;

		public Action<T> selectedItemSetter;

		public JOHDOPKIANF dropdownData;

		internal object _003CCreateOneLineDropdownDataFromEnum_003Eb__1()
		{
			return null;
		}

		internal void _003CCreateOneLineDropdownDataFromEnum_003Eb__2(object value)
		{
		}

		internal bool _003CCreateOneLineDropdownDataFromEnum_003Eb__0()
		{
			return false;
		}
	}

	private sealed class GDAJEABHNED<T> where T : Enum
	{
		public Func<T> selectedItemGetter;

		public Action<T> selectedItemSetter;

		public ELHLLACGIOJ dropdownData;

		internal object _003CCreateDropdownTwoLineDataFromEnum_003Eb__1()
		{
			return null;
		}

		internal void _003CCreateDropdownTwoLineDataFromEnum_003Eb__2(object value)
		{
		}

		internal bool _003CCreateDropdownTwoLineDataFromEnum_003Eb__0()
		{
			return false;
		}
	}

	private sealed class AHCPGIGEDIK<T>
	{
		public Func<T, string> itemToString;

		public Func<T> selectedItemGetter;

		public Action<T> selectedItemSetter;

		public Func<List<T>> sourceGetter;

		internal string _003CCreateOneLineDropdownData_003Eg__itemToStringDelegate_007C0(object value)
		{
			return null;
		}

		internal object _003CCreateOneLineDropdownData_003Eb__1()
		{
			return null;
		}

		internal void _003CCreateOneLineDropdownData_003Eb__2(object value)
		{
		}

		internal IReadOnlyList<object> _003CCreateOneLineDropdownData_003Eb__3()
		{
			return null;
		}

		internal bool _003CCreateOneLineDropdownData_003Eb__4()
		{
			return false;
		}
	}

	private sealed class LIGKNCHMKJM<T>
	{
		public Func<T, string> itemToString;

		public Func<T> selectedItemGetter;

		public Action<T> selectedItemSetter;

		public Func<List<T>> sourceGetter;

		internal string _003CCreateDropdownData_003Eg__itemToStringDelegate_007C0(object value)
		{
			return null;
		}

		internal object _003CCreateDropdownData_003Eb__1()
		{
			return null;
		}

		internal void _003CCreateDropdownData_003Eb__2(object value)
		{
		}

		internal IReadOnlyList<object> _003CCreateDropdownData_003Eb__3()
		{
			return null;
		}

		internal bool _003CCreateDropdownData_003Eb__4()
		{
			return false;
		}
	}

	private sealed class ADNBNPGOFBA<T>
	{
		public Func<T, string> itemToString;

		public Func<T> selectedItemGetter;

		public Action<T> selectedItemSetter;

		public List<T> source;

		internal string _003CCreateDropdownData_003Eg__itemToStringDelegate_007C0(object value)
		{
			return null;
		}

		internal object _003CCreateDropdownData_003Eb__1()
		{
			return null;
		}

		internal void _003CCreateDropdownData_003Eb__2(object value)
		{
		}

		internal bool _003CCreateDropdownData_003Eb__4()
		{
			return false;
		}
	}

	private sealed class LPKCGLJKKCI
	{
		public Func<int> selectedKeyGetter;

		public Action<int> selectedKeySetter;

		public Dictionary<int, string> localSource;

		internal object _003CCreateOneLineDropdownDataFromDictionary_003Eb__1()
		{
			return null;
		}

		internal void _003CCreateOneLineDropdownDataFromDictionary_003Eb__2(object value)
		{
		}

		internal string _003CCreateOneLineDropdownDataFromDictionary_003Eb__3(object key)
		{
			return null;
		}

		internal bool _003CCreateOneLineDropdownDataFromDictionary_003Eb__5()
		{
			return false;
		}
	}

	private sealed class NANCOOKKPEL
	{
		public Func<int> selectedKeyGetter;

		public Action<int> selectedKeySetter;

		public Func<int, string> toStringOverride;

		public Dictionary<int, string> localSource;

		internal object _003CCreateDropdownDataFromDictionary_003Eb__6()
		{
			return null;
		}

		internal void _003CCreateDropdownDataFromDictionary_003Eb__7(object value)
		{
		}

		internal string _003CCreateDropdownDataFromDictionary_003Eb__8(object key)
		{
			return null;
		}

		internal bool _003CCreateDropdownDataFromDictionary_003Eb__10()
		{
			return false;
		}
	}

	private sealed class CJFPMDDECHK<ObjectType>
	{
		public List<ObjectType> objects;

		public Func<int> selectedKeyGetter;

		public Func<int, string> toStringOverride;

		public Dictionary<int, string> localSource;

		internal global::AIKFPDCGNMF<object> _003CCreateDropdownDataFromDictionary_003Eb__3()
		{
			return default;
		}

		internal string _003CCreateDropdownDataFromDictionary_003Eb__4(object key)
		{
			return null;
		}

		internal bool _003CCreateDropdownDataFromDictionary_003Eb__6()
		{
			return false;
		}
	}

	private sealed class BKDOFJONLEA
	{
		public Func<global::AIKFPDCGNMF<int>> selectedKeyGetter;

		public Func<int, string> toStringOverride;

		public Dictionary<int, string> localSource;

		internal global::AIKFPDCGNMF<object> _003CCreateDropdownDataFromDictionary_003Eb__3()
		{
			return default;
		}

		internal string _003CCreateDropdownDataFromDictionary_003Eb__4(object key)
		{
			return null;
		}

		internal bool _003CCreateDropdownDataFromDictionary_003Eb__6()
		{
			return false;
		}
	}

	private sealed class BBFKOPDJPCH
	{
		public Dictionary<int, string> cachedReverseLookup;

		public List<object> cachedItemList;

		public Func<Dictionary<string, MIBJNNKFLND>> sourceGetter;

		public bool sortStringsInDropdown;

		public Func<bool> sourceDirtyGetter;

		public Func<int> selectedKeyGetter;

		public Action<int> selectedKeySetter;

		public Func<int, string> toStringOverride;

		internal void _003CCreateDropdownDataFromDictionary_003Eg__RecacheData_007C0()
		{
		}

		internal void _003CCreateDropdownDataFromDictionary_003Eg__RecacheIfRequired_007C1()
		{
		}

		internal object _003CCreateDropdownDataFromDictionary_003Eb__3()
		{
			return null;
		}

		internal void _003CCreateDropdownDataFromDictionary_003Eb__4(object value)
		{
		}

		internal string _003CCreateDropdownDataFromDictionary_003Eb__5(object key)
		{
			return null;
		}

		internal IReadOnlyList<object> _003CCreateDropdownDataFromDictionary_003Eb__6()
		{
			return null;
		}

		internal bool _003CCreateDropdownDataFromDictionary_003Eb__7()
		{
			return false;
		}
	}

	private sealed class JAFHBLJIOEI
	{
		public Dictionary<int, string> cachedReverseLookup;

		public List<object> cachedItemList;

		public Func<List<KeyValuePair<string, MIBJNNKFLND>>> sourceGetter;

		public bool sortStringsInDropdown;

		public Func<bool> sourceDirtyGetter;

		public Func<int> selectedKeyGetter;

		public Action<int> selectedKeySetter;

		public Func<int, string> toStringOverride;

		internal void _003CCreateDropdownDataFromList_003Eg__RecacheData_007C0()
		{
		}

		internal void _003CCreateDropdownDataFromList_003Eg__RecacheIfRequired_007C1()
		{
		}

		internal object _003CCreateDropdownDataFromList_003Eb__3()
		{
			return null;
		}

		internal void _003CCreateDropdownDataFromList_003Eb__4(object value)
		{
		}

		internal string _003CCreateDropdownDataFromList_003Eb__5(object key)
		{
			return null;
		}

		internal IReadOnlyList<object> _003CCreateDropdownDataFromList_003Eb__6()
		{
			return null;
		}

		internal bool _003CCreateDropdownDataFromList_003Eb__7()
		{
			return false;
		}
	}

	private sealed class JKILIIGCPOL
	{
		public bool allowDefaultRoles;

		public Func<HashSet<Guid>> selectedFlagsGetter;

		public string primaryLabel;

		public Action<IEnumerable<Guid>> selectedFlagsSetter;

		public Action<CLKEJFGKNDK, KCOKPCOFDIM> fireDialogListPicker;

		public Func<GameRole, bool> _003C_003E9__1;

		internal void _003CCreateRoleToggleSetData_003Eb__0()
		{
		}

		internal bool _003CCreateRoleToggleSetData_003Eb__1(GameRole r)
		{
			return false;
		}
	}

	private sealed class GANBFFDCHCK
	{
		public List<GameRole> roomRoles;

		public HashSet<int> selected;

		public JKILIIGCPOL CS_0024_003C_003E8__locals1;

		public Func<int, Guid> _003C_003E9__6;

		internal int _003CCreateRoleToggleSetData_003Eb__2(Guid t)
		{
			return 0;
		}

		internal void _003CCreateRoleToggleSetData_003Eb__3(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
		{
		}

		internal void _003CCreateRoleToggleSetData_003Eb__5()
		{
		}

		internal Guid _003CCreateRoleToggleSetData_003Eb__6(int g)
		{
			return default;
		}
	}

	private sealed class FIPEBNFIHLI
	{
		public Guid t;

		internal bool _003CCreateRoleToggleSetData_003Eb__4(GameRole r)
		{
			return false;
		}
	}

	private sealed class ACAOCHLMCDN
	{
		public Func<int> selectedValueGetter;

		public Dictionary<string, MIBJNNKFLND> sourceEnumChoiceData;

		public DCAJBJOAALL dropdownButtonData;

		public string defaultButtonLabel;

		public Action<int> selectedValueSetter;

		public string dialogTitle;

		public Action<CLKEJFGKNDK, KCOKPCOFDIM> fireDialogListPicker;

		internal void _003CCreateEnumDropdownButtonData_003Eb__0()
		{
		}

		internal void _003CCreateEnumDropdownButtonData_003Eb__1()
		{
		}
	}

	private sealed class IONAJMFAHIM
	{
		public KeyValuePair<string, MIBJNNKFLND>[] sourcePairs;

		public KCOKPCOFDIM pickerDialogData;

		public ACAOCHLMCDN CS_0024_003C_003E8__locals1;

		internal void _003CCreateEnumDropdownButtonData_003Eb__2(GameObject instance, int index, TextMeshProUGUI label)
		{
		}

		internal int _003CCreateEnumDropdownButtonData_003Eb__3()
		{
			return 0;
		}

		internal void _003CCreateEnumDropdownButtonData_003Eb__4(int index)
		{
		}
	}

	private sealed class IDIHHDHHNNN
	{
		public int selectedValue;

		internal bool _003CCreateEnumDropdownButtonData_003Eb__5(KeyValuePair<string, MIBJNNKFLND> pair)
		{
			return false;
		}
	}

	private sealed class BNPMOLLFJLP
	{
		public Func<IEnumerable<GameRole>> selectedRolesGetter;

		public DCAJBJOAALL dropdownButtonData;

		public string defaultButtonLabel;

		public Func<IEnumerable<GameRole>> sourceRolesGetter;

		public Func<string> dialogTitleGetter;

		public Action<IEnumerable<GameRole>> selectedRolesSetter;

		public Action<CLKEJFGKNDK, KCOKPCOFDIM> fireDialogListPicker;

		internal void _003CCreateRoleDropdownButtonData_003Eb__0()
		{
		}

		internal void _003CCreateRoleDropdownButtonData_003Eb__1()
		{
		}
	}

	private sealed class CECLONKDDLA
	{
		public GameRole[] sourceRoles;

		internal string _003CCreateRoleDropdownButtonData_003Eb__2(GameRole r)
		{
			return null;
		}
	}

	private sealed class MMOMFKMIDNI
	{
		public GameRole r;

		internal bool _003CCreateRoleDropdownButtonData_003Eb__3(GameRole s)
		{
			return false;
		}
	}

	private sealed class JIFBMKMAPHA
	{
		public GameRole[] sourceRoles;

		public HashSet<int> selectedRoleIndices;

		public BNPMOLLFJLP CS_0024_003C_003E8__locals1;

		public Func<int, GameRole> _003C_003E9__8;

		internal int _003CCreateRoleDropdownButtonData_003Eb__4(GameRole s)
		{
			return 0;
		}

		internal void _003CCreateRoleDropdownButtonData_003Eb__5(GameObject instance, int index, TextMeshProUGUI label)
		{
		}

		internal void _003CCreateRoleDropdownButtonData_003Eb__7()
		{
		}

		internal GameRole _003CCreateRoleDropdownButtonData_003Eb__8(int i)
		{
			return null;
		}
	}

	private sealed class JDMJAFLEFAD
	{
		public GameRole s;

		internal bool _003CCreateRoleDropdownButtonData_003Eb__6(GameRole r)
		{
			return false;
		}
	}

	private sealed class DEPPDEAPDBG
	{
		public bool showingPrimaryMessage;

		public EHEJPNFKNAL primaryButton;

		public string confirmMessage;

		public string primaryLabel;

		public Action onClick;

		internal void _003CCreateConfirmationButtonData_003Eb__0()
		{
		}

		internal bool _003CCreateConfirmationButtonData_003Eb__1()
		{
			return false;
		}

		internal bool _003CCreateConfirmationButtonData_003Eb__2()
		{
			return false;
		}

		internal void _003CCreateConfirmationButtonData_003Eb__3()
		{
		}
	}

	private sealed class JPPCBLKLBEN
	{
		public List<ShapeColorInfo> colors;

		public Func<int> selectedKeyGetter;

		public Action<int> selectedKeySetter;

		public Action<CLKEJFGKNDK, AMFPEDOFIGE> fireDialogListPicker;

		public Action doneButtonPressed;

		public string primaryLabel;

		public bool allowCustomColors;

		public bool allowDefault;

		internal void _003CCreateColorPickerButton_003Eb__0()
		{
		}

		internal Color _003CCreateColorPickerButton_003Eb__1()
		{
			return default;
		}
	}

	private sealed class MAOBNPMCGGG
	{
		public Func<int> selectedKeyGetter;

		public Action<CLKEJFGKNDK, AMFPEDOFIGE> fireDialogListPicker;

		public Action<int> selectedKeySetter;

		public Action doneButtonPressed;

		public Action<ShapeColorInfo> _003C_003E9__1;

		internal void _003CCreateCustomColorPickerButton_003Eb__0()
		{
		}

		internal void _003CCreateCustomColorPickerButton_003Eb__1(ShapeColorInfo x)
		{
		}
	}

	private sealed class KPKNMPPFOMO
	{
		public IReadOnlyList<ShapeColorInfo> colors;

		public Func<int> selectedKeyGetter;

		public Action<int> selectedKeySetter;

		public Predicate<ShapeColorInfo> _003C_003E9__3;

		internal void _003CGetColorPickerGridDialogData_003Eb__0(GameObject instance, int index, CardModel cardModel, ShapeColorInfoModel fromModel, JLOCLGGLOPP toController)
		{
		}

		internal int _003CGetColorPickerGridDialogData_003Eb__1()
		{
			return 0;
		}

		internal bool _003CGetColorPickerGridDialogData_003Eb__3(ShapeColorInfo color)
		{
			return false;
		}

		internal void _003CGetColorPickerGridDialogData_003Eb__2(int value)
		{
		}
	}

	private sealed class DDDGCAJPPPL
	{
		public List<ShapeMaterialInfo> materials;

		public Func<int> selectedColorGetter;

		public bool forceTransparentQueue;

		public bool cameraLit;

		public Func<int> selectedMaterialGetter;

		public Action<int> selectedMaterialSetter;

		public string primaryLabel;

		public Action<CLKEJFGKNDK, KCOKPCOFDIM> fireDialogListPicker;

		public Action<GameObject, int, CardModel, ShapeMaterialInfoModel, JLOCLGGLOPP> _003C_003E9__3;

		public Predicate<ShapeMaterialInfo> _003C_003E9__6;

		public Func<int> _003C_003E9__4;

		public Action<int> _003C_003E9__5;

		internal void _003CCreateMaterialPicker_003Eb__0()
		{
		}

		internal void _003CCreateMaterialPicker_003Eb__3(GameObject instance, int index, CardModel cardModel, ShapeMaterialInfoModel fromModel, JLOCLGGLOPP toController)
		{
		}

		internal int _003CCreateMaterialPicker_003Eb__4()
		{
			return 0;
		}

		internal bool _003CCreateMaterialPicker_003Eb__6(ShapeMaterialInfo mat)
		{
			return false;
		}

		internal void _003CCreateMaterialPicker_003Eb__5(int value)
		{
		}

		internal Color _003CCreateMaterialPicker_003Eb__1()
		{
			return default;
		}

		internal Material _003CCreateMaterialPicker_003Eb__2()
		{
			return null;
		}
	}

	private sealed class EIBGONMPAJL<T>
	{
		public Func<List<T>> source;

		public Func<T, string> itemToStringGetter;

		public Func<T> selectedKeyGetter;

		public Action<T> selectedKeySetter;

		public bool dismissOnSelection;

		public string primaryLabel;

		public Action<CLKEJFGKNDK, KCOKPCOFDIM> fireDialogListPicker;

		internal void _003CCreatePickerData_003Eb__0()
		{
		}
	}

	private sealed class BAIMNNCNMLF<T>
	{
		public List<T> localSource;

		public KCOKPCOFDIM pickerDialogData;

		public EIBGONMPAJL<T> CS_0024_003C_003E8__locals1;

		internal void _003CCreatePickerData_003Eb__1(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
		{
		}

		internal int _003CCreatePickerData_003Eb__2()
		{
			return 0;
		}

		internal void _003CCreatePickerData_003Eb__3(int value)
		{
		}
	}

	private sealed class EOIFLECFEHO
	{
		public EOHADGOEBOD emptyRoomKey;

		public Func<Guid> selectedKeyGetter;

		public Action<Guid> selectedKeySetter;

		internal List<EOHADGOEBOD> _003CCreateRoomKeyPicker_003Eb__0()
		{
			return null;
		}

		internal EOHADGOEBOD _003CCreateRoomKeyPicker_003Eb__1()
		{
			return null;
		}

		internal void _003CCreateRoomKeyPicker_003Eb__2(EOHADGOEBOD value)
		{
		}
	}

	private sealed class CHGMKHDIAOE
	{
		public Func<Guid> selectedRoleGetter;

		public Action<Guid> selectedRoleSetter;

		internal GameRole _003CCreateRoomRolePicker_003Eb__0()
		{
			return null;
		}

		internal void _003CCreateRoomRolePicker_003Eb__1(GameRole value)
		{
		}
	}

	private sealed class ODDCBODCFBH
	{
		public Func<int> selectedFlagsGetter;

		public Dictionary<int, string> localSource;

		public List<int> sourceValues;

		public Action<int> selectedFlagsSetter;

		public string primaryLabel;

		public Action<CLKEJFGKNDK, KCOKPCOFDIM> fireDialogListPicker;

		public Action<GameObject, int, TextMeshProUGUI> _003C_003E9__3;

		internal void _003CCreateFlagToggleGroup_003Eb__2()
		{
		}

		internal void _003CCreateFlagToggleGroup_003Eb__3(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
		{
		}
	}

	private sealed class DGKLKGLAAHP
	{
		public HashSet<int> selected;

		public ODDCBODCFBH CS_0024_003C_003E8__locals1;

		internal void _003CCreateFlagToggleGroup_003Eb__4()
		{
		}
	}

	private sealed class DBBKFLLOCHO
	{
		public UGCStorefront storefront;

		public string primaryLabel;

		public Action<CLKEJFGKNDK, FBCFAGMKPGP> fireDialog;

		internal void _003CCreateUGCStorefrontConfig_003Eb__0()
		{
		}
	}

	private sealed class ECLCBDNLDJP<T>
	{
		public List<T> objects;

		public Func<bool> getFunction;

		internal global::AIKFPDCGNMF<bool> _003CGetBoolFuncForMultipleObjects_003Eb__0()
		{
			return default;
		}
	}

	private sealed class OLOEPMHEJII<T>
	{
		public List<T> objects;

		public Func<T, bool> getFunction;

		internal global::AIKFPDCGNMF<bool> _003CGetBoolFuncForMultipleObjects_003Eb__0()
		{
			return default;
		}
	}

	private sealed class LCNIAHBBHNB<T>
	{
		public List<T> objects;

		public Func<bool> getFunction;

		public bool valueOnMismatch;

		internal bool _003CGetBoolFuncForMultipleObjects_003Eb__0()
		{
			return false;
		}
	}

	private sealed class ODGBNNCPNFL<T>
	{
		public List<T> objects;

		public Func<T, bool> getFunction;

		public bool valueOnMismatch;

		internal bool _003CGetBoolFuncForMultipleObjects_003Eb__0()
		{
			return false;
		}
	}

	private sealed class IHMAHANJFMM<T>
	{
		public List<T> objects;

		public Action<bool> setFunction;

		internal void _003CSetBoolFuncForMultipleObjects_003Eb__0(bool setValue)
		{
		}
	}

	private sealed class GMMGPIHAGIG<T>
	{
		public List<T> objects;

		public Action<T, bool> setFunction;

		internal void _003CSetBoolFuncForMultipleObjects_003Eb__0(bool setValue)
		{
		}
	}

	private sealed class NAPPILGBKJD<T>
	{
		public List<T> objects;

		public Func<float> getFunction;

		internal global::AIKFPDCGNMF<float> _003CGetFloatFuncForMultipleObjects_003Eb__0()
		{
			return default;
		}
	}

	private sealed class CPADLBNNMFM<T>
	{
		public List<T> objects;

		public Func<T, float> getFunction;

		internal global::AIKFPDCGNMF<float> _003CGetFloatFuncForMultipleObjects_003Eb__0()
		{
			return default;
		}
	}

	private sealed class PDAAPGDOCKE<T>
	{
		public List<T> objects;

		public Action<float> setFunction;

		internal void _003CSetFloatFuncForMultipleObjects_003Eb__0(float setValue)
		{
		}
	}

	private sealed class JCEGFBMJKCI<T>
	{
		public List<T> objects;

		public Action<T, float> setFunction;

		internal void _003CSetFloatFuncForMultipleObjects_003Eb__0(float setValue)
		{
		}
	}

	private sealed class ICGGDHKFEFC<T>
	{
		public List<T> objects;

		public Func<int> getFunction;

		internal global::AIKFPDCGNMF<int> _003CGetIntFuncForMultipleObjects_003Eb__0()
		{
			return default;
		}
	}

	private sealed class HOEEECFDOCM<T>
	{
		public List<T> objects;

		public Func<T, int> getFunction;

		internal global::AIKFPDCGNMF<int> _003CGetIntFuncForMultipleObjects_003Eb__0()
		{
			return default;
		}
	}

	private sealed class CLKEPNAONHP<T>
	{
		public List<T> objects;

		public Action<int> setFunction;

		internal void _003CSetIntFuncForMultipleObjects_003Eb__0(int setValue)
		{
		}
	}

	private sealed class LHKANKHNECO<T>
	{
		public List<T> objects;

		public Action<T, int> setFunction;

		internal void _003CSetIntFuncForMultipleObjects_003Eb__0(int setValue)
		{
		}
	}

	private sealed class BJOCOPAJKIA<T>
	{
		public List<T> objects;

		public Action<object> setFunction;

		internal void _003CSetEnumFuncForMultipleObjects_003Eb__0(object setValue)
		{
		}
	}

	private sealed class GJOHOAICLJC<T>
	{
		public List<T> objects;

		public Action<T, object> setFunction;

		internal void _003CSetEnumFuncForMultipleObjects_003Eb__0(object setValue)
		{
		}
	}

	private const int LCBLNHHPJGP = 12;

	private const int CLHBAAHALCC = 5;

	private const int HFKKIILNEBI = 375;

	private const string CLGNONFECFK = "(INVALID DATA)";

	private static readonly ShapeColorInfo BAILMPOOLDK;

	private static readonly GameRole FJOHOKGMIEM;

	private static bool BFEOPEMCNLB()
	{
		return false;
	}

	private static bool GKLAGFDMKAE()
	{
		return false;
	}

	public static bool OKNMIKICIOB(this NJBHDPOJINB ELEDBKFAFCC)
	{
		return false;
	}

	public static EEKMBJBLIHN GNOJNOGJIFG(Func<float> ILMGPHBOONB, Action<float> PAPJPNIHFIF, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", bool EIMOPIPELLK = false, float KOMPMCPODJM = 0f, float AFALOODLEEP = 1000f, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EEKMBJBLIHN GNOJNOGJIFG<ObjectType>(List<ObjectType> GLPABBNKNEO, Func<float> ILMGPHBOONB, Action<float> PAPJPNIHFIF, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", bool EIMOPIPELLK = false, float KOMPMCPODJM = 0f, float AFALOODLEEP = 1000f, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static FDGDCNLMACK JAHBPLJKMEG(Func<int> ILMGPHBOONB, Action<int> PAPJPNIHFIF, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", bool EIMOPIPELLK = false, int KOMPMCPODJM = 0, int AFALOODLEEP = 1000, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static FDGDCNLMACK JAHBPLJKMEG<ObjectType>(List<ObjectType> GLPABBNKNEO, Func<int> ILMGPHBOONB, Action<int> PAPJPNIHFIF, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", bool EIMOPIPELLK = false, int KOMPMCPODJM = 0, int AFALOODLEEP = 1000, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<bool> JPJLGDNKPKB = null, bool AMONBCLNDBD = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EEKMBJBLIHN DDDICDNIJPN(Func<string> ILMGPHBOONB, Action<string> PAPJPNIHFIF, int MPPKBKCGBKL = 1000, TMP_InputField.ContentType PANLMPDMCKG = TMP_InputField.ContentType.Alphanumeric, Func<string, bool> IECKGIBPFHD = null, TMP_InputField.CharacterValidation LCFHBGGAHLO = TMP_InputField.CharacterValidation.Alphanumeric, string AHJAJMMOJAL = null, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", bool JPEOFADOKHD = false, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EOBABDDMCAM JMJNFDDNLNO(Func<string> ILMGPHBOONB, Action<string> PAPJPNIHFIF, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, int? AJKIHPMKPPI = null, bool JPEOFADOKHD = false, string OEPJBAJNCNJ = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EMGKENGMCAG OLMPLOEBHPL(Func<string> ILMGPHBOONB, Action<string> PAPJPNIHFIF, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, int? AJKIHPMKPPI = null, bool JPEOFADOKHD = false, string OEPJBAJNCNJ = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static LFHCAENGLBN HNDMKFNKDBF(Func<int> ILMGPHBOONB, Action<int> PAPJPNIHFIF, int KOMPMCPODJM, int AFALOODLEEP, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> JPJLGDNKPKB = null, Func<float, float> BBAEMLGKBEM = null, Func<float, float> DGBAFONMCCM = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static LFHCAENGLBN FECGHOKOIGH(Func<float> ILMGPHBOONB, Action<float> PAPJPNIHFIF, float KOMPMCPODJM = 0f, float AFALOODLEEP = 1000f, Func<bool> ENMNOKIJMCE = null, int OPJIDFHAOMD = -1, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<float, float> DGBAFONMCCM = null, Func<float, float> BBAEMLGKBEM = null, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static GKLBOIOFAAG FECGHOKOIGH<ObjectType>(List<ObjectType> GLPABBNKNEO, Func<float> ILMGPHBOONB, Action<float> PAPJPNIHFIF, float KOMPMCPODJM = 0f, float AFALOODLEEP = 1000f, Func<bool> KIOMKOPLEEH = null, int OPJIDFHAOMD = -1, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<float, float> DGBAFONMCCM = null, Func<float, float> BBAEMLGKBEM = null, Func<bool> JPJLGDNKPKB = null, bool AMONBCLNDBD = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static GKLBOIOFAAG FECGHOKOIGH(Func<global::AIKFPDCGNMF<float>> ILMGPHBOONB, Action<float> PAPJPNIHFIF, float KOMPMCPODJM = 0f, float AFALOODLEEP = 1000f, Func<bool> KIOMKOPLEEH = null, int OPJIDFHAOMD = -1, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string PHIGIMEIKPF = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<float, float> DGBAFONMCCM = null, Func<float, float> BBAEMLGKBEM = null, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static JKKIGLPEJFG KJLMFNPDFNK(Func<float> ILMGPHBOONB, Action<float> PAPJPNIHFIF, List<float> KIACJIBMPJD, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", int OPJIDFHAOMD = -1, int LAGADKBKLAD = 999, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static CKJJCJAPLEH DILJBFGKECD(Func<float> ILMGPHBOONB, Action<float> PAPJPNIHFIF, float[] KIACJIBMPJD, float? LCECCMOCGIH = null, float? GJNDBPAADNJ = null, float AMFFJCOCMCL = 0f, float FBJPIOHIMLB = 1f, int OPJIDFHAOMD = -1, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool? NHKEABKMHEL = null, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", int LAGADKBKLAD = 999, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static GMHIPMHFHHL LDEGNJDADPE(Func<bool> ILMGPHBOONB, Action<bool> PAPJPNIHFIF, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", int LAGADKBKLAD = 999, Func<bool> JPJLGDNKPKB = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static PFALPAKGKGG LDEGNJDADPE<ObjectType>(List<ObjectType> GLPABBNKNEO, Func<bool> ILMGPHBOONB, Action<bool> PAPJPNIHFIF, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", int LAGADKBKLAD = 999, Func<bool> JPJLGDNKPKB = null, Action<List<ObjectType>, bool> GJGDKLEPFLO = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static JMEBCLBPNLN BDDGIONEIBO(Func<bool> JPJLGDNKPKB, int LAGADKBKLAD, params DGMPBIPKJEB[] DKIPBFCBBBG)
	{
		return null;
	}

	public static KLKCFJOABIM BMGMLPCJKKB(string OEPJBAJNCNJ = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, params DGMPBIPKJEB[] DKIPBFCBBBG)
	{
		return null;
	}

	public static PPFOPDEDHPP MNOHCOLKOBD(Func<string> ILMGPHBOONB, Action<string> PAPJPNIHFIF, Action CCLGFCNAFEB, Func<bool> KIOMKOPLEEH = null, TMP_InputField.ContentType PANLMPDMCKG = TMP_InputField.ContentType.Alphanumeric, Func<string, bool> IECKGIBPFHD = null, TMP_InputField.CharacterValidation LCFHBGGAHLO = TMP_InputField.CharacterValidation.Alphanumeric, string AHJAJMMOJAL = null, List<DGMPBIPKJEB> FBOIKBEOGHI = null, string OEPJBAJNCNJ = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", string GHMOJBEPDPE = "", string IMLPCJAAGDL = "", bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static AKCHPHOMHLH EODFOGBJPAB(int LAGADKBKLAD, string OEPJBAJNCNJ, Sprite MDECPMJIFKB = null, string HADMIMJGCHD = "", string FPJJFMMAEEO = "", List<DGMPBIPKJEB> DKIPBFCBBBG = null, Func<bool> KIOMKOPLEEH = null, bool HHGPNNEAIHE = true, Func<bool> HLHBEFFKGKO = null, Action<bool> FHCGFOHIOFJ = null)
	{
		return null;
	}

	public static BAGBAGLIICE IIPPDPHDBDA<DataClassType, EnumType>(List<DataClassType> GLPABBNKNEO, Func<int> PPHBOIAIPFA, Action<object> HCJLCCGACIM, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<object, string> DANEIMNDLBP = null, bool GHGJBJNHFNM = true, bool NJJFJLIGHHJ = true) where EnumType : Enum
	{
		return null;
	}

	public static JOHDOPKIANF IIPPDPHDBDA<T>(Func<T> PPHBOIAIPFA, Action<T> HCJLCCGACIM, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<object, string> DANEIMNDLBP = null, bool GHGJBJNHFNM = true, bool NJJFJLIGHHJ = true) where T : Enum
	{
		return null;
	}

	public static ELHLLACGIOJ PBKDFCHOLFB<T>(Func<T> PPHBOIAIPFA, Action<T> HCJLCCGACIM, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<object, string> DANEIMNDLBP = null, bool GHGJBJNHFNM = true, bool NJJFJLIGHHJ = true) where T : Enum
	{
		return null;
	}

	public static JOHDOPKIANF KJPCCPCKMDA<T>(Func<List<T>> CCEMPFHBINE, Func<T> PPHBOIAIPFA, Action<T> HCJLCCGACIM, Func<T, string> DANEIMNDLBP, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool GHGJBJNHFNM = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static ELHLLACGIOJ EHHOLBGAFMM<T>(Func<List<T>> CCEMPFHBINE, Func<T> PPHBOIAIPFA, Action<T> HCJLCCGACIM, Func<T, string> DANEIMNDLBP, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool GHGJBJNHFNM = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static ELHLLACGIOJ EHHOLBGAFMM<T>(List<T> GLLFHCCFIGK, Func<T> PPHBOIAIPFA, Action<T> HCJLCCGACIM, Func<T, string> DANEIMNDLBP, string OEPJBAJNCNJ = "", string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool GHGJBJNHFNM = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static JOHDOPKIANF LPABAJNMHEC(Dictionary<string, MIBJNNKFLND> GLLFHCCFIGK, Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, string OEPJBAJNCNJ, string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Action GDBAPBAOCEO = null, Action IJMNBCAFCOP = null, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool GHGJBJNHFNM = true, bool FFDIBIBAIBA = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static ELHLLACGIOJ OPBPKPGIBJH(Dictionary<string, MIBJNNKFLND> GLLFHCCFIGK, Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, string OEPJBAJNCNJ, string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Action GDBAPBAOCEO = null, Action IJMNBCAFCOP = null, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<int, string> KNMBJEGOGOM = null, bool GHGJBJNHFNM = true, bool FFDIBIBAIBA = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static OEOOLFMMHJG OPBPKPGIBJH<ObjectType>(List<ObjectType> GLPABBNKNEO, Dictionary<string, MIBJNNKFLND> GLLFHCCFIGK, Func<int> CIADBJKPBDB, Action<object> KCMJMKCNPBK, string OEPJBAJNCNJ, string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Action GDBAPBAOCEO = null, Action IJMNBCAFCOP = null, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<int, string> KNMBJEGOGOM = null, bool GHGJBJNHFNM = true, bool FFDIBIBAIBA = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static OEOOLFMMHJG OPBPKPGIBJH(Dictionary<string, MIBJNNKFLND> GLLFHCCFIGK, Func<global::AIKFPDCGNMF<int>> CIADBJKPBDB, Action<object> KCMJMKCNPBK, string OEPJBAJNCNJ, string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Action GDBAPBAOCEO = null, Action IJMNBCAFCOP = null, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<int, string> KNMBJEGOGOM = null, bool GHGJBJNHFNM = true, bool FFDIBIBAIBA = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static ELHLLACGIOJ OPBPKPGIBJH(Func<Dictionary<string, MIBJNNKFLND>> CCEMPFHBINE, Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, string OEPJBAJNCNJ, string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<bool> HOGJCELBAJG = null, Func<int, string> KNMBJEGOGOM = null, bool GHGJBJNHFNM = true, bool FFDIBIBAIBA = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static ELHLLACGIOJ PIIADOFHJJI(Func<List<KeyValuePair<string, MIBJNNKFLND>>> CCEMPFHBINE, Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, string OEPJBAJNCNJ, string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<bool> HOGJCELBAJG = null, Func<int, string> KNMBJEGOGOM = null, Action GDBAPBAOCEO = null, Action IJMNBCAFCOP = null, bool GHGJBJNHFNM = true, bool FFDIBIBAIBA = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EHEJPNFKNAL BPHLMECDLAF(Func<HashSet<Guid>> CKOAJGCPMND, Action<IEnumerable<Guid>> OCIEOKJJFHE, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, string OEPJBAJNCNJ, string KODDOGEEFCI = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool JICGJECEIBJ = false, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static DCAJBJOAALL CJOIIJJLHPC(Dictionary<string, MIBJNNKFLND> GENNEJGLILK, Func<int> ECALIBKNDIM, Action<int> GGNJBPPPKEE, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, string PIIMPPKEALA, string HDJGLOGPCHF, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, BGMIHEHEHNF JLCPAKMHLIG = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static DCAJBJOAALL IFNFPPHFBGH(Func<IEnumerable<GameRole>> FCIENMJENAM, Func<IEnumerable<GameRole>> MHLOLCOAJHF, Action<IEnumerable<GameRole>> IJDCHBNIPFG, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, string PIIMPPKEALA, Func<string> BLIALCKEJAP, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, BGMIHEHEHNF JLCPAKMHLIG = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static HELFEDOLCOM MBICDOHABFF(string HLIGBKANEEA = "", TextAlignmentOptions? BIJKGDNCEEA = null, Func<bool> KIOMKOPLEEH = null)
	{
		return null;
	}

	public static EHEJPNFKNAL DJHLANGPGGK(Action CCLGFCNAFEB, string OEPJBAJNCNJ = "", Sprite MDECPMJIFKB = null, Func<Color> HOCLODDKGME = null, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, Func<bool> JPJLGDNKPKB = null, Func<Material> OCAMKMFGPGE = null, bool IEFFCLNOKGO = false, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static FDGDCNLMACK IGJFFIJGKCM(Action CCLGFCNAFEB, string OEPJBAJNCNJ = "", string PHEPNPGJDKE = "Confirm", string IDCAKHEMLFE = "Cancel", EEMHKKCPPNI? BAMCAINCIJC = null, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null)
	{
		return null;
	}

	public static EHEJPNFKNAL NOKMOBLIGLN(Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, Action<CLKEJFGKNDK, AMFPEDOFIGE> GFNPBKFLPEB, Action OCCBIGPKKML, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool GNLABHCDIFM = false, string OEPJBAJNCNJ = "Color", Func<bool> JPJLGDNKPKB = null, bool IEJJDAOJNEC = true, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EHEJPNFKNAL EFNPEEDLOBL(Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, Action<CLKEJFGKNDK, AMFPEDOFIGE> GFNPBKFLPEB, Action OCCBIGPKKML, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static void INAINKPIJFG(IReadOnlyList<ShapeColorInfo> FOIHMCAGNFG, Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, Action<CLKEJFGKNDK, AMFPEDOFIGE> GFNPBKFLPEB, Action OCCBIGPKKML, string OEPJBAJNCNJ = "Color", bool IEJJDAOJNEC = true, OMGIPOLPCND CICBLBFGPGH = OMGIPOLPCND.Large)
	{
	}

	public static KCOKPCOFDIM BCKFOAMNLFE(IReadOnlyList<ShapeColorInfo> FOIHMCAGNFG, Func<int> CIADBJKPBDB, Action<int> KCMJMKCNPBK, Action<CLKEJFGKNDK, AMFPEDOFIGE> GFNPBKFLPEB, Action OCCBIGPKKML, string OFMGPNLDCAB = "Color", bool IEJJDAOJNEC = true, OMGIPOLPCND CICBLBFGPGH = OMGIPOLPCND.Large)
	{
		return null;
	}

	public static void EPOBCICDBCH(this DialogListModel DJDIJKOIFCC, CLKEJFGKNDK HNPFAOFHHII, AMFPEDOFIGE CIFKJLJDLOP)
	{
	}

	public static DGMPBIPKJEB PFMMCIOLEKP(Func<int> OCGLKIFBCNL, Action<int> MPCKPGCLBAK, Func<int> DNJCHLOLMMA, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, Func<bool> KIOMKOPLEEH = null, Func<bool> JPJLGDNKPKB = null, Func<bool> FPEOAKJKHMN = null, bool GNLABHCDIFM = false, string OEPJBAJNCNJ = "Material", string HADMIMJGCHD = "", bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EHEJPNFKNAL POLHKMOILBI<T>(Func<List<T>> GLLFHCCFIGK, Func<T> CIADBJKPBDB, Action<T> KCMJMKCNPBK, Func<T, string> EHHBCIKHMJM, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, string OEPJBAJNCNJ = "", string HADMIMJGCHD = "", string FPJJFMMAEEO = "", bool GHGJBJNHFNM = false, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EHEJPNFKNAL OCLBBMCPKIF(Func<Guid> CIADBJKPBDB, Action<Guid> KCMJMKCNPBK, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, Func<bool> KIOMKOPLEEH = null, string OEPJBAJNCNJ = "", string HADMIMJGCHD = "", bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static List<GameRole> BFMOLNPPEPH()
	{
		return null;
	}

	public static EHEJPNFKNAL LDKAEGCPKBK(Func<Guid> EOFPBJHHBBN, Action<Guid> BHBFPEPFFDC, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, string OEPJBAJNCNJ = "", string HADMIMJGCHD = "", bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EHEJPNFKNAL OFFEOPFPAGG(Dictionary<string, MIBJNNKFLND> GLLFHCCFIGK, Func<int> CKOAJGCPMND, Action<int> OCIEOKJJFHE, Action<CLKEJFGKNDK, KCOKPCOFDIM> GFNPBKFLPEB, string OEPJBAJNCNJ, string HADMIMJGCHD = "", string FPJJFMMAEEO = "", Func<bool> KIOMKOPLEEH = null, Func<bool> FPEOAKJKHMN = null, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	public static EHEJPNFKNAL LHAPHEGCLDK(Action<CLKEJFGKNDK, FBCFAGMKPGP> BNFHCCNEODD, UGCStorefront OCNGKLDCJKG, string OEPJBAJNCNJ, bool NJJFJLIGHHJ = true)
	{
		return null;
	}

	private static HashSet<int> OGHAGGBNIAA(int KCAPLJEHMMI, Dictionary<int, string> GHEJJKOFGHH, List<int> FJLICCPIANA)
	{
		return null;
	}

	private static int GGHOGBEIMIB(HashSet<int> KCAPLJEHMMI, List<int> FJLICCPIANA)
	{
		return 0;
	}

	public static DGMPBIPKJEB FKNDGONICLH()
	{
		return null;
	}

	public static List<T> EIJPKHHJLAM<T>(List<JICDMECOFLC> OKGFHDGAPBM, T AMKLLPPOKFM)
	{
		return null;
	}

	public static global::AIKFPDCGNMF<bool> BGOAJMCCDMC<T>(List<T> GLPABBNKNEO, KHGNFLAKFLA<T, bool> FJANACGGCCA)
	{
		return default;
	}

	public static bool BGOAJMCCDMC<T>(List<T> GLPABBNKNEO, KHGNFLAKFLA<T, bool> FJANACGGCCA, bool MILHHAKHDHK)
	{
		return false;
	}

	public static Func<global::AIKFPDCGNMF<bool>> GJDPFJNPLJJ<T>(List<T> GLPABBNKNEO, Func<bool> DIABKPHLMPK)
	{
		return null;
	}

	public static Func<global::AIKFPDCGNMF<bool>> GJDPFJNPLJJ<T>(List<T> GLPABBNKNEO, Func<T, bool> DIABKPHLMPK)
	{
		return null;
	}

	public static Func<bool> GJDPFJNPLJJ<T>(List<T> GLPABBNKNEO, Func<bool> DIABKPHLMPK, bool MILHHAKHDHK)
	{
		return null;
	}

	public static Func<bool> GJDPFJNPLJJ<T>(List<T> GLPABBNKNEO, Func<T, bool> DIABKPHLMPK, bool MILHHAKHDHK)
	{
		return null;
	}

	public static void DCDMDMAJJDG<T>(List<T> GLPABBNKNEO, KAGMLMLEFBL<T, bool> FJANACGGCCA, bool IPMIIEAGJKC)
	{
	}

	public static Action<bool> DHDGBEHKFFN<T>(List<T> GLPABBNKNEO, Action<bool> CLAOEMFPFEB)
	{
		return null;
	}

	public static Action<bool> DHDGBEHKFFN<T>(List<T> GLPABBNKNEO, Action<T, bool> CLAOEMFPFEB)
	{
		return null;
	}

	public static global::AIKFPDCGNMF<float> JFGCNDJICCC<T>(List<T> GLPABBNKNEO, KHGNFLAKFLA<T, float> FJANACGGCCA)
	{
		return default;
	}

	public static Func<global::AIKFPDCGNMF<float>> JEPIFANLGCE<T>(List<T> GLPABBNKNEO, Func<float> DIABKPHLMPK)
	{
		return null;
	}

	public static Func<global::AIKFPDCGNMF<float>> JEPIFANLGCE<T>(List<T> GLPABBNKNEO, Func<T, float> DIABKPHLMPK)
	{
		return null;
	}

	public static void JPODGCJICKA<T>(List<T> GLPABBNKNEO, KAGMLMLEFBL<T, float> FJANACGGCCA, float IPMIIEAGJKC)
	{
	}

	public static Action<float> HJCKIPPCHPI<T>(List<T> GLPABBNKNEO, Action<float> CLAOEMFPFEB)
	{
		return null;
	}

	public static Action<float> HJCKIPPCHPI<T>(List<T> GLPABBNKNEO, Action<T, float> CLAOEMFPFEB)
	{
		return null;
	}

	public static global::AIKFPDCGNMF<int> DGLBJPCFJIE<T>(List<T> GLPABBNKNEO, KHGNFLAKFLA<T, int> FJANACGGCCA)
	{
		return default;
	}

	public static Func<global::AIKFPDCGNMF<int>> IDMBMEKNPOA<T>(List<T> GLPABBNKNEO, Func<int> DIABKPHLMPK)
	{
		return null;
	}

	public static Func<global::AIKFPDCGNMF<int>> IDMBMEKNPOA<T>(List<T> GLPABBNKNEO, Func<T, int> DIABKPHLMPK)
	{
		return null;
	}

	public static void DKMMGONAJOE<T>(List<T> GLPABBNKNEO, KAGMLMLEFBL<T, int> FJANACGGCCA, int IPMIIEAGJKC)
	{
	}

	public static Action<int> OJFNKLGNIGB<T>(List<T> GLPABBNKNEO, Action<int> CLAOEMFPFEB)
	{
		return null;
	}

	public static Action<int> OJFNKLGNIGB<T>(List<T> GLPABBNKNEO, Action<T, int> CLAOEMFPFEB)
	{
		return null;
	}

	public static void FJDHFDIFMLI<T>(List<T> GLPABBNKNEO, KAGMLMLEFBL<T, object> FJANACGGCCA, object IPMIIEAGJKC)
	{
	}

	public static Action<object> HDJLAOPJHCO<T>(List<T> GLPABBNKNEO, Action<object> CLAOEMFPFEB)
	{
		return null;
	}

	public static Action<object> HDJLAOPJHCO<T>(List<T> GLPABBNKNEO, Action<T, object> CLAOEMFPFEB)
	{
		return null;
	}
}
