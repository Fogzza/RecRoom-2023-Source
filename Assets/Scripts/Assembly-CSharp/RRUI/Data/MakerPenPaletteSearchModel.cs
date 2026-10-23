using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Core.Creation;
using RecRoom.Systems.PlayerRoles;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class MakerPenPaletteSearchModel : MakerPenModelBase, GLFJBMLAONM, LOBCAJAIIJD
	{
		private sealed class CCBCHIKPDPJ
		{
			public MakerPenPaletteSearchModel _003C_003E4__this;

			public string category;

			internal void _003CGetPropListByCategory_003Eb__0(IEnumerable<FKHIHDBONBB> items, IReadOnlyList<bool> matches)
			{
			}

			internal void _003CGetPropListByCategory_003Eb__1(IEnumerable<FKHIHDBONBB> items, IReadOnlyList<bool> matches)
			{
			}
		}

		private sealed class LGIJNGPMHHI
		{
			public OMEIEHCDNDP makerPenPaletteSearchItemData;

			public PMBKBAONKPJ favoriteType;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal void _003COnPropListSearchComplete_003Eb__1()
			{
			}
		}

		private sealed class HICDIAPHOEA
		{
			public NECHJDDBINM node;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal bool _003CTryRebuildSearchContext_003Eb__4()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__5()
			{
			}

			internal void _003CTryRebuildSearchContext_003Eb__6()
			{
			}

			internal void _003CTryRebuildSearchContext_003Eb__7()
			{
			}
		}

		private sealed class CHEHIJDAGGA
		{
			public string groupStr;

			internal (string, SpawnableToolCategoryConfig.CategoryConfig) _003CTryRebuildSearchContext_003Eb__8(SpawnableToolCategoryConfig.CategoryConfig category)
			{
				return default;
			}
		}

		private sealed class JJJBBLANLAA
		{
			public string groupStr;

			public string categoryStr;

			internal (string[][], string, RuntimeSpawnableToolConfig) _003CTryRebuildSearchContext_003Eb__10(RuntimeSpawnableToolConfig tool)
			{
				return default;
			}
		}

		private sealed class MBJBMNLODJH
		{
			public JBGFOIKBKED spawnableToolType;

			public RuntimeSpawnableToolConfig config;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal bool _003CTryRebuildSearchContext_003Eb__11()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__12()
			{
			}

			internal void _003CTryRebuildSearchContext_003Eb__13()
			{
			}

			internal void _003CTryRebuildSearchContext_003Eb__14()
			{
			}
		}

		private sealed class AFKELOFKFAK
		{
			public string[][] inventionFilters;

			public string[][] certifiedInventionFilters;

			public string[][] myInventionFilters;

			public string[][] publishedInventionFilters;

			public string[][] downloadedInventionFilters;

			public string certifiedInventionFormat;

			public string inventionFormat;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal IReadOnlyList<IReadOnlyList<string>> _003CTryRebuildSearchContext_003Eg__GetFilters_007C15(OEBAEGDPBLA invention)
			{
				return null;
			}

			internal BEIANCHHAJA _003CTryRebuildSearchContext_003Eb__16(OEBAEGDPBLA invention)
			{
				return null;
			}
		}

		private sealed class HJBCGGINJMJ
		{
			public OEBAEGDPBLA invention;

			public AFKELOFKFAK CS_0024_003C_003E8__locals1;

			internal bool _003CTryRebuildSearchContext_003Eb__17()
			{
				return false;
			}

			internal void _003CTryRebuildSearchContext_003Eb__18()
			{
			}

			internal void _003CTryRebuildSearchContext_003Eb__19()
			{
			}

			internal void _003CTryRebuildSearchContext_003Eb__20()
			{
			}

			internal void _003CTryRebuildSearchContext_003Eb__21()
			{
			}
		}

		private sealed class NKAOMFMAONC
		{
			public ANOEOICCMDH category;

			internal bool _003CGetAuthorizedRestrictedToolTypesForCategory_003Eb__1(RuntimeSpawnableToolConfig config)
			{
				return false;
			}
		}

		private sealed class OKFJHCEDEHP
		{
			public string[][] shapeFilters;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal ENILADICJJL _003CShapeSearchContext_003Eb__2(AMEPDCGKFOG shapeType)
			{
				return null;
			}
		}

		private sealed class ONNNLBBKHJO
		{
			public AMEPDCGKFOG shapeType;

			public OKFJHCEDEHP CS_0024_003C_003E8__locals1;

			internal bool _003CShapeSearchContext_003Eb__3()
			{
				return false;
			}

			internal void _003CShapeSearchContext_003Eb__4()
			{
			}

			internal void _003CShapeSearchContext_003Eb__5()
			{
			}

			internal void _003CShapeSearchContext_003Eb__6()
			{
			}
		}

		private sealed class IFPHMNLJCKH
		{
			public IReadOnlyList<bool> matches;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal OMEIEHCDNDP _003COnSearchComplete_003Eb__0(FKHIHDBONBB psi)
			{
				return null;
			}
		}

		private sealed class BCIOGNOJKJJ
		{
			public OMEIEHCDNDP item;

			public PMBKBAONKPJ favoriteType;

			public IFPHMNLJCKH CS_0024_003C_003E8__locals1;

			internal void _003COnSearchComplete_003Eb__1()
			{
			}
		}

		private sealed class IIJBFLCDFCG
		{
			public Action<JNODIIINKKJ.GEKLJFFEACO> sortOptionSetter;

			public DHAPPKCJJCA sortDialogData;

			public Func<JNODIIINKKJ.GEKLJFFEACO> sortOptionGetter;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal void _003CTryShowSortDialogPopUp_003Eb__0(object key)
			{
			}

			internal object _003CTryShowSortDialogPopUp_003Eb__1()
			{
				return null;
			}

			internal void _003CTryShowSortDialogPopUp_003Eb__2()
			{
			}
		}

		private sealed class OAJLEIKNFMH
		{
			public string certifiedInventionFormat;

			public string inventionFormat;

			public string[][] certifiedInventionFilters;

			public string[][] inventionFilters;

			internal OMEIEHCDNDP _003CCheckInventionStore_003Eb__1(OEBAEGDPBLA invention)
			{
				return null;
			}
		}

		private sealed class KGJKBINLKKK
		{
			public OEBAEGDPBLA invention;

			internal bool _003CCheckInventionStore_003Eb__2()
			{
				return false;
			}

			internal void _003CCheckInventionStore_003Eb__3()
			{
			}

			internal void _003CCheckInventionStore_003Eb__4()
			{
			}
		}

		private sealed class FMECOBJKDIO
		{
			public ShapeMaterialInfo[] materials;

			public ShapeColorInfo selectedColorInfo;

			public bool forceTransparentQueue;

			public bool cameraLit;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			public BaseDialogModel dialog;

			public Func<ShapeMaterialInfo, bool> _003C_003E9__4;

			internal void _003CShowSwatchMaterialDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, ShapeMaterialInfoModel fromModel, JLOCLGGLOPP toController)
			{
			}

			internal int _003CShowSwatchMaterialDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CShowSwatchMaterialDialog_003Eb__4(ShapeMaterialInfo color)
			{
				return false;
			}

			internal void _003CShowSwatchMaterialDialog_003Eb__2(int index)
			{
			}

			internal void _003CShowSwatchMaterialDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> d)
			{
			}
		}

		private sealed class HCKGMGNJNDL
		{
			public GLMCMJAALJD favorite;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal void _003Cget_MakerPenUsableFavorites_003Eb__5()
			{
			}

			internal bool _003Cget_MakerPenUsableFavorites_003Eb__0(NECHJDDBINM nto)
			{
				return false;
			}

			internal bool _003Cget_MakerPenUsableFavorites_003Eb__6(NECHJDDBINM nto)
			{
				return false;
			}

			internal void _003Cget_MakerPenUsableFavorites_003Eb__8()
			{
			}
		}

		private sealed class LMPEMIFLKFN
		{
			public JBGFOIKBKED spawnableToolType;

			public HCKGMGNJNDL CS_0024_003C_003E8__locals1;

			internal bool _003Cget_MakerPenUsableFavorites_003Eb__1()
			{
				return false;
			}

			internal void _003Cget_MakerPenUsableFavorites_003Eb__2()
			{
			}

			internal void _003Cget_MakerPenUsableFavorites_003Eb__3()
			{
			}

			internal void _003Cget_MakerPenUsableFavorites_003Eb__4()
			{
			}
		}

		private sealed class FEGCKCPHEPI
		{
			public NECHJDDBINM node;

			public MakerPenPaletteSearchModel _003C_003E4__this;

			internal bool _003Cget_MakerPenUsableFavorites_003Eb__9()
			{
				return false;
			}

			internal void _003Cget_MakerPenUsableFavorites_003Eb__10()
			{
			}

			internal void _003Cget_MakerPenUsableFavorites_003Eb__11()
			{
			}

			internal void _003Cget_MakerPenUsableFavorites_003Eb__12()
			{
			}
		}

		private sealed class ABOIAOACPJI
		{
			public Guid uniqueId;

			internal bool _003CIsItemFavorite_003Eb__0(GLMCMJAALJD f)
			{
				return false;
			}
		}

		private sealed class ABOGJDBHCBF
		{
			public Guid uniqueId;

			public PMBKBAONKPJ favoriteType;

			internal bool _003CToggleIsFavorite_003Eb__0(GLMCMJAALJD f)
			{
				return false;
			}

			internal bool _003CToggleIsFavorite_003Eb__1(GLMCMJAALJD f)
			{
				return false;
			}
		}

		[SerializeField]
		private BrowserModel _paletteBrowser;

		private uint NICKFCGMCJK;

		[SerializeField]
		private TMP_InputField searchInputField;

		private bool DBLNJCIGGDE;

		private NNBAJLCGAOK FOBAEINAHEB;

		[SerializeField]
		private bool showAllShapesByDefault;

		private static readonly Dictionary<string, List<OMEIEHCDNDP>> PJPLEKDFGHD;

		private static readonly Dictionary<string, Dictionary<JNODIIINKKJ.GEKLJFFEACO, List<OMEIEHCDNDP>>> CJPOLPEONCL;

		private static readonly Dictionary<string, EGIIJEIOLHB> LLOMAKILICL;

		private static readonly Dictionary<string, List<OMEIEHCDNDP>> EICGKGBGMFJ;

		private static List<JBGFOIKBKED> ANFCNMKLOHF;

		public Sprite isFavoriteIcon;

		public Sprite isNotFavoriteIcon;

		public Sprite makerPenFolderIcon;

		private Material HIBLHCDMBNM;

		private bool LEEFOENBAPM;

		private ANOEOICCMDH NGOFGOJHFBH;

		private HHNPLBOFAGE JOAAEDHFIFB;

		private bool HPFMKICIADC;

		private BDHJHNNAEEB HLBMAEEEJLD;

		private BDHJHNNAEEB APJOENCIDII;

		private IEnumerable<OMEIEHCDNDP> PCIPGEEHJFN;

		private IReadOnlyList<FKHIHDBONBB> GKNLAEDLAJP;

		private string HOPMPIDNHJM;

		private string FICLMOLCKMP;

		private bool IGONFICFCDF;

		private uint EGMLDENONPM;

		[SerializeField]
		private Route paletteSearchRoute;

		private IEnumerable<FOIBLFIPHNF> HJGAEBICMAI;

		private IEnumerable<FOIBLFIPHNF> LJPIMJFDMIO;

		private IEnumerable<FOIBLFIPHNF> JJNJEGNKCIA;

		private IEnumerable<FOIBLFIPHNF> HKMAOCCDMBK;

		private uint PJEPGAJFBHF;

		private uint IICIFKENLIL;

		private IEnumerable<ENILADICJJL> PEFLNKAKKKJ;

		private List<OMEIEHCDNDP> CBOAPKCHHIJ;

		private TMP_InputField BHGFJCCJECH;

		private IEnumerable<OEBAEGDPBLA> PLFACONPPDM;

		private List<OEBAEGDPBLA> JJHHIFECGFO;

		private List<OMEIEHCDNDP> DAAADPPGKFC;

		private uint DIAMJOBGPAI;

		private ShapeSwatchInfo FGEGCNOOOOF;

		private IReadOnlyList<ShapeSwatchInfo> BBKFLAKNIPO;

		private static IReadOnlyList<GLMCMJAALJD> BJCMAAKIJPN;

		private IReadOnlyList<LFIOJFLIPFC> IBIBBNNKKKJ;

		private static Dictionary<string, double> OAHFEMMCKNA;

public BrowserModel PaletteBrowser
{
get 		{
			return null;
		}

}

public uint BackingDataVersion
{
get 		{
			return 0u;
		}

private set {
		}
}

private NNBAJLCGAOK CAOIPCMMNMJ
{
get 		{
			return null;
		}

}

public Material UIShapeMaterialInstance
{
get 		{
			return null;
		}

}

public ANOEOICCMDH SelectedPropCategory
{
get 		{
			return ANOEOICCMDH.WEAPON;
		}

set {
		}
}

public HHNPLBOFAGE SelectedTargetMode
{
get 		{
			return HHNPLBOFAGE.Object;
		}

set {
		}
}

public AMEPDCGKFOG SelectedShapeType
{
get 		{
			return AMEPDCGKFOG.CURVE_Tube;
		}

}

public float UVScale
{
get 		{
			return 0f;
		}

}

public OEBAEGDPBLA SelectedInvention
{
get 		{
			return null;
		}

}

public BDHJHNNAEEB PaletteSearchContext
{
get 		{
			return null;
		}

}

public BDHJHNNAEEB PropSpawnerSearchContext
{
get 		{
			return null;
		}

}

public IEnumerable<OMEIEHCDNDP> LatestResults
{
get 		{
			return null;
		}

private set {
		}
}

public IReadOnlyList<FKHIHDBONBB> FilterResults
{
get 		{
			return null;
		}

private set {
		}
}

public string SearchString
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsSearchActive
{
get 		{
			return false;
		}

set {
		}
}

public bool ShapePaletteSearchItemDataDirty
{
get 		{
			return false;
		}

}

public bool ShowAdvancedShapes
{
get 		{
			return false;
		}

set {
		}
}

public static bool AlwaysFocusSearchInputField
{
get 		{
			return false;
		}

}

public JNODIIINKKJ.GEKLJFFEACO SelectedSortOption
{
get 		{
			return JNODIIINKKJ.GEKLJFFEACO.None;
		}

set {
		}
}

public IEnumerable<OEBAEGDPBLA> CachedInventions
{
get 		{
			return null;
		}

private set {
		}
}

public List<OMEIEHCDNDP> InventionStoreSearchItemData
{
get 		{
			return null;
		}

private set {
		}
}

public ShapeSwatchInfo TempSwatch
{
get 		{
			return null;
		}

}

public IReadOnlyList<ShapeSwatchInfo> ShapeSwatchInfos
{
get 		{
			return null;
		}

}

private static IReadOnlyList<GLMCMJAALJD> MCNLJEMBCGI
{
get 		{
			return null;
		}

set {
		}
}

public IReadOnlyList<OMEIEHCDNDP> MakerPenUsableFavorites
{
get 		{
			return null;
		}

}

public IReadOnlyList<LFIOJFLIPFC> ObjectClipboardItems
{
get 		{
			return null;
		}

}

public Dictionary<string, double> CarouselsToPositions
{
get 		{
			return null;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		public List<OMEIEHCDNDP> GetPropListByCategory(string JNKJFJLJKNJ, JNODIIINKKJ.GEKLJFFEACO IOOFIJENAKG)
		{
			return null;
		}

		public List<OMEIEHCDNDP> GetFilterListByCategory(string JNKJFJLJKNJ)
		{
			return null;
		}

		private void CAHFJCGDECF(IEnumerable<FKHIHDBONBB> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI, string JNKJFJLJKNJ)
		{
		}

		private void HKOENLECJBD(IEnumerable<FKHIHDBONBB> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI, string JNKJFJLJKNJ)
		{
		}

		public List<string> GetFiltersFromCurrentSearchString()
		{
			return null;
		}

		public void SelectCreationData(JLHLKDMLBPK? HMCAFGCGFJF = null, MJGMBIJIKFH? PMPDPBDKGPF = null, float? PALJJNGJNBE = null)
		{
		}

		private void IBOOKMCGJIP(bool BKJEKHGCKGF = true)
		{
		}

		private void IBOOKMCGJIP()
		{
		}

		public void OnUsedPaletteItem(JDNHCJEAMBI KDAFDKBCGIO, long IKHNIJKGJFD)
		{
		}

		public void SelectPropButton(JBGFOIKBKED KDHBALDHKBN, bool ACNGCJMCHJL)
		{
		}

		public void SelectInvention(OEBAEGDPBLA EGDOIKMDMJM, bool ACNGCJMCHJL)
		{
		}

		private void NGEPPJKACKJ(AMEPDCGKFOG LJGNKMONIGD, bool ACNGCJMCHJL)
		{
		}

		private void JCAMNJGMPAG()
		{
		}

		private void OFKPEIELNKN(Guid KKBFAENPLID, bool ACNGCJMCHJL)
		{
		}

		private void KDIMBMMPBCO<T>(FBEHJNCKJPN CIMCLAFMGFE, bool ACNGCJMCHJL)
		{
		}

		private void ALDOPCAJBEJ<T>()
		{
		}

		private void FHPNGFPFGDD<T>(bool COPOILGLIAJ)
		{
		}

		private FBEHJNCKJPN FPNJDONPBDL(FBEHJNCKJPN CIMCLAFMGFE)
		{
			return FBEHJNCKJPN.CreateShape;
		}

		public void OnSelectClipboardItem()
		{
		}

		public static string FormatDescription(string GKHMKKBKEKC)
		{
			return null;
		}

		private void OHHCAHENLHE()
		{
		}

		private IEnumerable<RuntimeSpawnableToolConfig> JEOMLHDKBPD(ANOEOICCMDH JNKJFJLJKNJ)
		{
			return null;
		}

		private IEnumerable<ENILADICJJL> EKHBKLNMFON(bool JCKJPDHHFPO = false)
		{
			return null;
		}

		public List<OMEIEHCDNDP> GetShapePaletteSearchItemData()
		{
			return null;
		}

		public void Search(string JDPGCELOKNO)
		{
		}

		public void AutoFocusSearchInputField()
		{
		}

		public void UnfocusSearchInputField()
		{
		}

		private void BPECCLHFLEN(IEnumerable<FKHIHDBONBB> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI)
		{
		}

		private void KIKCMKIMBHK(IEnumerable<FKHIHDBONBB> JNAAHMPCPAB, IReadOnlyList<bool> LKCAJHNIMJI)
		{
		}

		private void OGILHLLNFON(string JDPGCELOKNO)
		{
		}

		public void MoveToEndIfNecessary()
		{
		}

		public void TryShowSortDialogPopUp(List<JNODIIINKKJ.GEKLJFFEACO> HIEFLGNKKBD, Func<JNODIIINKKJ.GEKLJFFEACO> HIGAMIHGJON, Action<JNODIIINKKJ.GEKLJFFEACO> AKDHDCAKNJE)
		{
		}

		public static void SortListBySortOption(ref List<OMEIEHCDNDP> LBFIOJJNBDC, JNODIIINKKJ.GEKLJFFEACO IOOFIJENAKG)
		{
		}

		private void NJMCOMBNPLN()
		{
		}

		private void LDMKAJGPLEP(CHILKDJABBF EKOFNPFCLMO, GameRole DHFJFGFHFEG)
		{
		}

		public bool InventionStoreSearchDataVersionChanged(ref uint JDOGIAFDMEO, bool IACCHJPDNFF = true)
		{
			return false;
		}

		private void EKEKIDEMOGJ()
		{
		}

		private void NFDOIHDPAGM(long KBPFKPGOCFN)
		{
		}

		private global::NCOKFFGPIJM<List<OEBAEGDPBLA>> DEDDPGGJAIK()
		{
			return null;
		}

		public global::NCOKFFGPIJM<List<OMEIEHCDNDP>> CheckInventionStore()
		{
			return null;
		}

		public void OnSwatchesChanged()
		{
		}

		public void RestoreSwatch()
		{
		}

		public void ShowSwatchColorDialog()
		{
		}

		public void ShowSwatchMaterialDialog()
		{
		}

		public static bool IsItemFavorite(Guid NINKNHBPCIP)
		{
			return false;
		}

		public static bool IsItemFavorite(Guid? NINKNHBPCIP)
		{
			return false;
		}

		private bool CLBLPKCBEIH(Guid NINKNHBPCIP, PMBKBAONKPJ HDLNPHMNAMG)
		{
			return false;
		}

		public void OnFavoritesChanged()
		{
		}

		private void ABHDADALLHO()
		{
		}

		public double GetPositionByCarousel(string BPBBBCMGPOG)
		{
			return 0.0;
		}

		public void SetCarouselPosition(string BPBBBCMGPOG, double INLGLHIPOMC)
		{
		}

		public INHOMKPMAGA.KLOEKEPDEHC GetMakerPenMenuModelData()
		{
			return null;
		}

		public void OnMakerPenBackingDataChanged(MakerPenMenuModel.IEKCDJICBLP LGCAHNMIPGB = MakerPenMenuModel.IEKCDJICBLP.Palette)
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void BJPPPBGBLAO()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(RRUIModel.AAHMEOHNDKA KMDKPCPJKJH)
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		public void OnInstantiate()
		{
		}

		private void EJGPLPGHDGK()
		{
		}

		[CompilerGenerated]
		private HACHHNIILOO ACGBINLBHKM(NECHJDDBINM KNBPIEINLIG)
		{
			return null;
		}

		[CompilerGenerated]
		private IEnumerable<(string[][], string, RuntimeSpawnableToolConfig)> JHEECBFIFOG((string, SpawnableToolCategoryConfig.CategoryConfig) CECJODLPMCK)
		{
			return null;
		}

		[CompilerGenerated]
		private GEMEIEHGLIO EOIOGDJPLBP((string[][], string, RuntimeSpawnableToolConfig) PKHLCLEPCEI)
		{
			return null;
		}

		[CompilerGenerated]
		private bool EOKOFFBHJIF(AMEPDCGKFOG LJGNKMONIGD)
		{
			return false;
		}

		[CompilerGenerated]
		private void BOBJDAPNJCI(List<OEBAEGDPBLA> CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void FAOCIHKGNOD(List<OEBAEGDPBLA> CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void MIFCCKAHKNM(List<OEBAEGDPBLA> OHMFGFMNMEN)
		{
		}

		[CompilerGenerated]
		private void LCINEBIFFHN(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private List<OMEIEHCDNDP> NLGKHOOPIEA(List<OEBAEGDPBLA> AMIAEMLONAO)
		{
			return null;
		}

		[CompilerGenerated]
		private int BFKLLDOCAMJ()
		{
			return 0;
		}

		[CompilerGenerated]
		private void PMDPJIOOIAP(int HMCAFGCGFJF)
		{
		}

		[CompilerGenerated]
		private void JIHHEJEHBOD(CLKEJFGKNDK NIFOGEBEDNG, AMFPEDOFIGE PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private void JFGHGDBJBCM()
		{
		}

		[CompilerGenerated]
		private HACHHNIILOO HNDFHHPNIPE(NECHJDDBINM KNBPIEINLIG)
		{
			return null;
		}

		[CompilerGenerated]
		private void LHKLIJMCKKL(List<OEBAEGDPBLA> CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void PGOEPHLMEOD(List<OMEIEHCDNDP> HMJKFBLHGAA)
		{
		}

		[CompilerGenerated]
		private void FIBGHIDMDEL(List<OEBAEGDPBLA> CDNLFEOBNKB)
		{
		}
	}
}
