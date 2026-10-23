using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class JNODIIINKKJ : NNBAJLCGAOK, IDisposable
{
	public enum PBDGIEELIHN
	{
		NO_SNAPPING = 0,
		OBJECT_SNAPPING = 1,
		GRID_SNAPPING = 2
	}

	public enum IGACCMOLGBK
	{
		Off = 0,
		ObjectDefault = 1,
		On = 2
	}

	public enum LDMOGNMAHNL
	{
		Off = 0,
		BrushAnalog = 1,
		RawAnalog = 2
	}

	public enum NGMJKOKKHNG
	{
		Precise = 0,
		Small = 1,
		Medium = 2,
		Large = 3,
		Analog = 4
	}

	public enum AEILKDDEOJH
	{
		Scale = 0,
		Move = 1
	}

	public enum GEKLJFFEACO
	{
		None = 0,
		NameAZ = 1,
		NameZA = 2,
		InkCostAsc = 3,
		InkCostDesc = 4,
		Oldest = 5,
		Newest = 6
	}

	public enum PPDDHHHCIBC
	{
		None = 0,
		Empty = 1,
		Default = 2
	}

	public enum IANJAPBFBCF
	{
		None = 0,
		Expresso_FullMenu = 1,
		Expresso_WidgetsOnly = 2
	}

	public enum LKLEIOPKNKL
	{
		None = 0,
		OnClick = 1,
		OnDrag = 2
	}

	public enum GHKBKNFNDDG
	{
		None = 0,
		Move = 1,
		BackToOriginalAlways = 2,
		BackToRotateTransformMoveConnect = 3
	}

	[Flags]
	public enum BLCIGIHGEAC
	{
		None = 0,
		All = -1,
		Default = 1,
		CPULimit = 2,
		NetLimit = 4,
		Unconfigured = 8,
		InvalidInput = 0x10,
		Warning = 0x20
	}

	private readonly BHNJIBDJFAL NJPJBDDAEFH;

	private GALKGFMGIKP PKMJGIEDJPO;

	public static readonly Dictionary<string, MIBJNNKFLND> EPHLOLGLNDL;

	[SerializeField]
	public static readonly Dictionary<GEKLJFFEACO, string> SortOptionsFriendlyNameMapping;

	private const string HECGJIKAAFG = "MakerPen_WorldAxisActive";

	private const string APLICGJLFGB = "MakerPen_RotateAroundPivot";

	private const string GLMKCMGHMHE = "MakerPen_RotateInPlace";

	private const string CACFPHJBPIF = "MakerPen_ScaleInPlace";

	private const string LBIFHNMPOON = "MakerPen_SnappingMode";

	private const string LCGANPMOPOA = "MakerPen_SnappingAlignToEdges";

	private const string IFPAIHBLGKP = "MakerPen_SnapToCenter";

	private const string CBHHINDKEPE = "MakerPen_FreezeRotationOnMove";

	private const string FGFLEHGMHPC = "MakerPen_SmoothTwistOnMove";

	private const string IBFPJMNHPKC = "MakerPen_UseProUX";

	private const string NDLKLFFAPNA = "MakerPen_SnappingShowGrid";

	private const string HILHPNGCAJH = "MakerPen_SnappingAdaptiveGrid";

	private const string CAEGJMIEEOO = "MakerPen_AdaptiveCreationSize";

	private const string JPLOKJPCBJD = "MakerPen_RoundedTubes";

	private const string IENOJFIGKKA = "MakerPen_ConnectTubes";

	private const string MBMHLIFCDPA = "MakerPen_SelfScalingEnabled";

	private const string DAIAHLJHEKI = "MakerPen_TubeAnalogMode";

	private const string LFJPOCKIODH = "MakerPen_DesaturateWorldInShapeMode";

	private const string HJKDJAMMBAH = "MakerPen_UniformShapes";

	public const string NJCJAANMEAC = "MakerPen_GridSnap";

	public const string IHOPHFHBBAA = "MakerPen_GridSnap_V2";

	public const string EJEECJLJNIB = "MakerPen_AngleSnap";

	public const string ELLMIGNNLFP = "MakerPen_AngleSnap_V2";

	public const string AOCCPKCMABI = "MakerPen_CurveThickness";

	public const string ICMEANKPDCD = "MakerPen_CurveThickness_V2";

	public const string GGHIGIJBKLB = "MakerPen_TubeHeightScale";

	public const string OMHEONADAGO = "MakerPen_TubeHeightScale_V2";

	public const string CPLDHEEOICN = "MakerPen_TubeRingPoints";

	public const string MDMNIFMMIIO = "MakerPen_TubeRingPoints_V2";

	public const string FKKOOLEDHFN = "MakerPen_DragSelectSize";

	public const string CBOJAEEFBON = "MakerPen_ShowPivot";

	private const string INOOFBMCMIA = "MakerPen_CreateGrabbableObjects";

	private const string OLFPNNIJFNA = "MakerPen_ShowGadgetsWithoutMakerPen";

	private const string AMJIHBGCBGK = "MakerPen_ShowSelectionBounds";

	private const string GCOCDCLKIAJ = "MakerPen_UseAnchors";

	private const string KOJMOCJHAAA = "MakerPen_EnableTranslationTransform";

	private const string JPKPJEDBFKH = "MakerPen_EnableRotationTransform";

	private const string BDJFHNGNDHJ = "MakerPen_EnableScaleTransform";

	private const string CMIGPMGJKOA = "MakerPen_DefaultShape";

	private const string JMFPEDLPMID = "MakerPen_CreationMode";

	private const string KAONIKGCKPP = "MakerPen_ShowOptimizedColliderOnSelection";

	private const string ELCEKEJEAGM = "MakerPen_ObjectBoardCreationMode";

	private const string IHEHBMHFBHC = "MakerPen_CV2_ShowExecHighlights";

	private const string KPCGLCFADEB = "MakerPen_CV2_ShowDataHighlights";

	private const string CEDKHADILPI = "MakerPen_CV2_ShowHoverHighlights";

	private const string NPBKCCHKHAH = "MakerPen_CV2_ShowOutOfScope";

	private const string MOOOKBIPIEO = "MakerPen_CV2_ExecPortRun";

	private const string HJIDHNOJBJL = "MakerPen_CV2_PlayErrorSFX";

	private const string MBAGDDGABFB = "MakerPen_EnableVROffhandTransformation";

	private const string JOICFLJFBCP = "MakerPen_Search_GeneralSortOption";

	private const string KOHPILDHMEE = "MakerPen_Search_InventionsSortOption";

	private const string LBMNFAOMIMH = "MakerPen_Hand_AllowUIInteractions";

	private const string DMJBMBDMKCD = "MakerPen_Search_AutoFouseInputField";

	private const string JJKIDOFJMKL = "MakerPen_Permission_EnforceForCreator";

	private const string BMHOGDIHIMM = "Tap_To_Open_MakerPen";

	private const string FBODFOPOLPD = "Show_Advanced_Shapes";

	private const string GLIADCIOFBL = "MakerPen_VR_QuickSwitchBehavior";

	private Action<NNBAJLCGAOK> IJEMKGFDICO__BackingField;

	private const string EHMNBFGHGLC = "VR_Quick_Switch_Align_To_Hand";

	private Action<NNBAJLCGAOK, bool> FNOPGLIKHCO__BackingField;

	private const string CGOOEEJKDEN = "MakerPen_AlwaysEnableCircuitsSnapping";

	public const string PIJCCAGKAEE = "MakerPen_DevOnlyIgnoreInk";

	public const string FKEFMAELOCF = "MakerPen_AutoDetachControlPanelBoardOnMove";

	private const string DBCGBADBJKO = "MakerPen_PluckAndPlaceChipsBehavior";

	private const string FALKPMFAIEJ = "MakerPen_PluckAndPlaceChipsAutoSwitchToToolBehavior";

	private const string AELFNHPKBFO = "MakerPen_PluckAndPlaceDistance";

	private const string ECHFMCAIIFI = "MakerPen_PluckAndPlaceScale";

	public const string PICDCFIOBPF = "MakerPen_LogCircuitErrorsToUnityConsole";

	private const string NEHOOBKKJDG = "MakerPen_RRUI_VRDetachedPersistentData";

	private const string ADENGFBJOKI = "MakerPen_RRUI_ToolsPersistentData";

	private const string BGKNLNFANPA = "MakerPen_RRUI_PalettePersistentData";

	private const string MNHNJIKJOIH = "MakerPen_RRUI_ConfigPersistentData";

	private const string ADPCOBIHAEG = "MakerPen_RRUI_LoggingPersistentData";

	private const string KHDAKHHBEFI = "MakerPen_RRUI_MorePersistentData";

public bool GEKEGCEELCD
{
get 	{
		return false;
	}

set {
	}
}

public bool MOEAPPIHJFN
{
get 	{
		return false;
	}

set {
	}
}

public bool ECENKMLOEHE
{
get 	{
		return false;
	}

set {
	}
}

public bool PONIEOEDJLC
{
get 	{
		return false;
	}

set {
	}
}

public PBDGIEELIHN KGBGEKDIICF
{
get 	{
		return PBDGIEELIHN.NO_SNAPPING;
	}

set {
	}
}

public bool LKEICCIDFPM
{
get 	{
		return false;
	}

set {
	}
}

public bool LIBFOOIIJHF
{
get 	{
		return false;
	}

set {
	}
}

public bool HFAEINDCOGL
{
get 	{
		return false;
	}

set {
	}
}

public bool JMMILIMHAHG
{
get 	{
		return false;
	}

set {
	}
}

public bool MKEOBNALEOI
{
get 	{
		return false;
	}

set {
	}
}

public bool EDDEAKDELLA
{
get 	{
		return false;
	}

set {
	}
}

public bool ABFIHMGIDJO
{
get 	{
		return false;
	}

set {
	}
}

public bool KGNEFMFLOIG
{
get 	{
		return false;
	}

set {
	}
}

public bool NBPIFMAHMGJ
{
get 	{
		return false;
	}

set {
	}
}

public bool NLJIDIHCOLN
{
get 	{
		return false;
	}

set {
	}
}

public bool DDFCPDLKJAH
{
get 	{
		return false;
	}

set {
	}
}

public LDMOGNMAHNL OLFGDNFCDIB
{
get 	{
		return LDMOGNMAHNL.Off;
	}

set {
	}
}

public bool GDJKLPKICBG
{
get 	{
		return false;
	}

set {
	}
}

public bool ACFMCLOMKHK
{
get 	{
		return false;
	}

set {
	}
}

public float OLJOJPFJBLA
{
get 	{
		return 0f;
	}

set {
	}
}

public float HOKDNLAIBIM
{
get 	{
		return 0f;
	}

set {
	}
}

public float NIDNOEOJMAC
{
get 	{
		return 0f;
	}

set {
	}
}

public float HJDELCHHGAG
{
get 	{
		return 0f;
	}

set {
	}
}

public int KBPJJIGLDBP
{
get 	{
		return 0;
	}

set {
	}
}

public NGMJKOKKHNG AHLBFCAILGF
{
get 	{
		return NGMJKOKKHNG.Precise;
	}

set {
	}
}

public bool EJEOPHDBNLN
{
get 	{
		return false;
	}

set {
	}
}

public IGACCMOLGBK ELJFMGJHGLB
{
get 	{
		return IGACCMOLGBK.Off;
	}

set {
	}
}

public bool OIBBMAFEDJB
{
get 	{
		return false;
	}

set {
	}
}

public bool PLPAKOIDHPK
{
get 	{
		return false;
	}

set {
	}
}

public bool CAKFACEFNOF
{
get 	{
		return false;
	}

set {
	}
}

public bool DOFDFFJKAGJ
{
get 	{
		return false;
	}

set {
	}
}

public bool CBDEFNOMHHJ
{
get 	{
		return false;
	}

set {
	}
}

public bool MOMAIDEKHKM
{
get 	{
		return false;
	}

set {
	}
}

public AMEPDCGKFOG IGNJFPOEGNB
{
get 	{
		return AMEPDCGKFOG.CURVE_Tube;
	}

}

public AEILKDDEOJH FEGHGOCNCEN
{
get 	{
		return AEILKDDEOJH.Scale;
	}

set {
	}
}

public bool NGBMMJBBFHA
{
get 	{
		return false;
	}

set {
	}
}

public PPDDHHHCIBC KPCJKOKMGCH
{
get 	{
		return PPDDHHHCIBC.None;
	}

set {
	}
}

public bool GHNMABEMBKL
{
get 	{
		return false;
	}

set {
	}
}

public bool ACJGCDJGHOG
{
get 	{
		return false;
	}

set {
	}
}

public bool MOFKKHHDCBB
{
get 	{
		return false;
	}

set {
	}
}

public bool IHFLAKDFHGK
{
get 	{
		return false;
	}

set {
	}
}

public bool OEDPCKPDEOG
{
get 	{
		return false;
	}

set {
	}
}

public BLCIGIHGEAC IKCPENBNIMA
{
get 	{
		return BLCIGIHGEAC.None;
	}

set {
	}
}

public bool GJPFGEPLBBC
{
get 	{
		return false;
	}

set {
	}
}

public GEKLJFFEACO IDJKBLBDCLH
{
get 	{
		return GEKLJFFEACO.None;
	}

set {
	}
}

public GEKLJFFEACO OFBIMKACFJP
{
get 	{
		return GEKLJFFEACO.None;
	}

set {
	}
}

public bool KHDGJNOLMKB
{
get 	{
		return false;
	}

set {
	}
}

public bool KGABAJOACPI
{
get 	{
		return false;
	}

set {
	}
}

public bool GBJGFCNDNDJ
{
get 	{
		return false;
	}

set {
	}
}

public bool EPNDAAJGJFF
{
get 	{
		return false;
	}

set {
	}
}

public bool GGCHIEFFOKD
{
get 	{
		return false;
	}

set {
	}
}

public IANJAPBFBCF GOMAIGDFBNH
{
get 	{
		return IANJAPBFBCF.None;
	}

set {
	}
}

public bool JFDAEEBGCMI
{
get 	{
		return false;
	}

set {
	}
}

public bool LJMNLCDIIBN
{
get 	{
		return false;
	}

set {
	}
}

public bool KCODDLCPIEC
{
get 	{
		return false;
	}

set {
	}
}

public bool JEOKFNLALNB
{
get 	{
		return false;
	}

set {
	}
}

public LKLEIOPKNKL NIPGGMGLKHH
{
get 	{
		return LKLEIOPKNKL.None;
	}

set {
	}
}

public GHKBKNFNDDG BEFHKGAAIMD
{
get 	{
		return GHKBKNFNDDG.None;
	}

set {
	}
}

public float LMLLGAPNPFF
{
get 	{
		return 0f;
	}

set {
	}
}

public float MIOIDAOMKPI
{
get 	{
		return 0f;
	}

set {
	}
}

public bool JMLKFEPGHNK
{
get 	{
		return false;
	}

set {
	}
}

public INHOMKPMAGA.TetheredUITransformData HJPGIJHLFED
{
get 	{
		return default;
	}

set {
	}
}

public INHOMKPMAGA.TetheredUITransformData JOFOOJCOKDJ
{
get 	{
		return default;
	}

set {
	}
}

public INHOMKPMAGA.TetheredUITransformData KNOFGNPCPLP
{
get 	{
		return default;
	}

set {
	}
}

public INHOMKPMAGA.TetheredUITransformData JGHNDFAPLGC
{
get 	{
		return default;
	}

set {
	}
}

public INHOMKPMAGA.TetheredUITransformData CEHJHLMEEFL
{
get 	{
		return default;
	}

set {
	}
}

public INHOMKPMAGA.TetheredUITransformData JOEFLICMPKE
{
get 	{
		return default;
	}

set {
	}
}

 event Action<NNBAJLCGAOK> global::NNBAJLCGAOK.IJEMKGFDICO {
add {
	}
remove {
	}
}

 event Action<NNBAJLCGAOK, bool> global::NNBAJLCGAOK.FNOPGLIKHCO {
add {
	}
remove {
	}
}

	private static void EDLMAOJJALF(MNALHHOLFGL FMPHDMAKDKP)
	{
	}

	[Preserve]
	private JNODIIINKKJ(BHNJIBDJFAL FMMEGIJPELJ)
	{
	}

	public void Dispose()
	{
	}
}
