using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Photon.Pun;
using RRUI.Data;
using RRUI.Navigation;
using RecRoom.AGUI.Expresso;
using RecRoom.AGUI.ToolUIs;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.UndoStack;
using RecRoom.Inputs;
using RecRoom.QuickActions;
using RecRoom.Systems.PlayerRoles;
using RecRoom.Tools.MakerPenTools;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RecRoom.Tools
{
	public class MakerPen : MonoBehaviourPun, LDHIPCJOMAD
	{
		private struct LABBJLNNHIM
		{
			public IONEOHGOAML CDNLFEOBNKB;

			public string PEOLHGGDCPN;

			public DHJLEHBOGBG GLHOACNHHMF;

			public int MCDPAJNKCOG;

			public DateTime OODFMOEGFLB;

			public bool INCHEEOFHCK(LABBJLNNHIM HNPEBINPOBO)
			{
				return false;
			}

			public static LABBJLNNHIM NCPALOADJGK()
			{
				return default;
			}
		}

		private sealed class EGOCHFGAPGC
		{
			public Func<global::NCOKFFGPIJM<string>> promise;

			internal void _003CAddProUXQuickActionMenuButton_003Eb__0()
			{
			}
		}

		private sealed class LNJOFLFDIIJ
		{
			public Func<global::NCOKFFGPIJM<string>> promise;

			internal void _003CAddProUXQuickActionMenuButton_003Eb__0()
			{
			}
		}

		private sealed class JDDHCEDFHCB
		{
			public Action promise;

			public MakerPen _003C_003E4__this;

			internal void _003CGetQuickActionButton_003Eb__0()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct KMAGLJLFLLB
		{
			public bool instantiateContainerIfNeeded;

			public MakerPen _003C_003E4__this;

			public MakerPenMenuModel.IEKCDJICBLP tab;
		}

		private sealed class MFLFABGHJGG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MakerPen makerPen;

			public int initialHoldingPlayerActorNumber;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MFLFABGHJGG(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class POEFHIBHHAE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MakerPen _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public POEFHIBHHAE(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private global::MOBDJNEDDKC<int> KPIKPPNCGEP;

		private CreationContext MANGENLHFMH;

		private GMPBDONHNBM FPOJNBADNCI;

		private HCOHEJBJCCA BFIFCDBONAB;

		private ABIODHNCLIG KGGPKCIPMCJ;

		private static MakerPen AEIEDIBCNAO;

		public static EEANDDJEMJC LocalMakerPenInstantiated;

		public static readonly EEANDDJEMJC LocalMakerPenDestroyed;

		private static Action JMLIMPNONOA__BackingField;

		private static Action BJGHGAELIAF__BackingField;

		private static INHOMKPMAGA CMFDOIKKKMN;

		public global::BPEPJJDICII<FBEHJNCKJPN, HHNPLBOFAGE> OnModeChanged;

		public readonly EEANDDJEMJC UIQueueEvent;

		public readonly EEANDDJEMJC InventionUpdateQueueEvent;

		public readonly EEANDDJEMJC InventionObjectsSelectionStarted;

		public readonly global::HHOBPMOCKMJ<bool> InventionObjectsSelectionCompleted;

		public readonly EEANDDJEMJC InventionObjectsSelectionCancelled;

		public readonly EEANDDJEMJC ExitEditMode;

		public readonly EEANDDJEMJC OnCreationDataChanged;

		[SerializeField]
		private bool fadeWorldInShapeMode;

		[SerializeField]
		private JLHLKDMLBPK defaultColor;

		[SerializeField]
		private MakerPenPaletteMoveableToolMenu paletteMenu;

		[SerializeField]
		private ExpressoUI expressoMenuFullPrefab;

		[SerializeField]
		private ExpressoUI expressoMenuWidgetsOnlyPrefab;

		[SerializeField]
		private QuickActionMenu quickActionMenuPrefab;

		[SerializeField]
		private TetheredUIBase detachedTetheredUIMainMenuPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIToolsTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIPaletteTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUILogScreenTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIConfigTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIMoreTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIPerfMonitorTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIProUXMainTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIProUXLogTabPrefab;

		[SerializeField]
		private TetheredUIBase tetheredUIProUXQAMTabPrefab;

		private MakerPenMenuModel JAOCPOGHAFK;

		private TetheredUIBase KBMCAGBGEGP;

		private INHOMKPMAGA GJFDNHIKCAA;

		private bool PFBBFELNBIN;

		private FOEIHCMEHMP JABLDCKACMN;

		private OEBAEGDPBLA ACJNCFJJHJI;

		[SerializeField]
		private MakerPenMergeOperation mergeOperation;

		[SerializeField]
		private MakerPenSplitOperation splitOperation;

		[SerializeField]
		private MakerPenSelectInventionOperation selectInventionOperation;

		[SerializeField]
		private MakerPenCreateInventionFromSelectionOperation createInventionFromSelectionOperation;

		[SerializeField]
		private MakerPenGroupCircuitsV1Operation groupCircuitsV1Operation;

		[SerializeField]
		private MakerPenGroupCircuitsV2Operation groupCircuitsV2Operation;

		[SerializeField]
		private MakerPenAddCircuitToGroupOperation addCircuitToGroupOperation;

		[SerializeField]
		private MakerPenUngroupCircuitsV1Operation ungroupCircuitsV1Operation;

		[SerializeField]
		private MakerPenRemoveFromGroupOperation removeFromGroupOperation;

		[SerializeField]
		private MakerPenCenterPivotOperation centerPivotOperation;

		[SerializeField]
		private MakerPenRepeatCloneOperation repeatCloneOperation;

		private DIPBHNJMADC CEGEGJBNNHE;

		private NFHGMFGKPNI IELMEPDODFI;

		private DAHDHEMCEGC PGJBMHHBHMG;

		private readonly FIHGBEHGLGB NLDIHMKBMOK;

		[SerializeField]
		private MakerPenCreateStateOperation createStateOperation;

		private PFOHJANPLPA BLICBINLAEM;

		private readonly Stack<FBEHJNCKJPN> FJHGIINNNEE;

		private DBIPHDIEBCM JFOODNJBIKO;

		[SerializeField]
		private MakerPenVisuals _penVisuals;

		private LHCDLLKKBEP LINHOHNHNPO;

		private bool OHJPFICBAJD;

		private global::JPEBBAFCBEP<FBEHJNCKJPN, HHNPLBOFAGE> LGCOFDAGDPD;

		private HHNPLBOFAGE EGLFIGABPEG;

		private FBEHJNCKJPN INBJGOHNAIP;

		private ObscuredInt GGGDDKHHCNI;

		private Guid ELIDFHJJNAA;

		private OEBAEGDPBLA KELFEKAJHHD;

		private OEBAEGDPBLA BFIOICKCJHB;

		private LFIOJFLIPFC ONHGDGLIKPH;

		private ObscuredInt FEKHDBINDIF;

		private BHICABGJFMG FDEPENAMHAE;

		private FBEHJNCKJPN ELDIEFCOBKK;

		private LKDMDLACMHN KLPJCNPJHEA;

		private IILDCCEMGBA LCPOIILBNLD;

		private LKGILLBEJEK NLCBMGNCLMD;

		private NNBAJLCGAOK AANMALIEFGI;

		public FNBOLCOIACC Snapping;

		private CGOPOAFDIDN AAKFKPKFDJJ;

		private readonly float APEIBDHBCFB;

		[SerializeField]
		private UndoStack _undoStack;

		[SerializeField]
		private Tool _tool;

		private MakerPenMainScreen MKPMBFMEOPC;

		private MakerPenPaletteMainScreen FHOMMHGIAJC;

		private float KLJKCKMAOJM;

		private JLHLKDMLBPK DJDHEPOIDCP;

		private MJGMBIJIKFH HPGMEMBOHEH;

		private JECDPJHHBNL EMGCLLGMAMF;

		private QuickActionMenu NPBHLEGHFKB;

		public List<DGMPBIPKJEB> QAMElements;

		private TetheredUIModel BGNACIOPGOE;

		private readonly TetheredUIModel[] FDLCOAOPIEN;

		public DHJLEHBOGBG[] RestorableSelectionContext;

		private bool BJNLJNBNDDL;

		private VRInputHandler BOBOECHNCEK;

		private ALFNPNHKGCE ILONNMLPPCN;

		private bool KBHAMJLPOKA;

		private bool FLLABDPBADB;

		[TextArea]
		[SerializeField]
		private string localAnalytics;

		[TextArea]
		[SerializeField]
		private string eventString;

		private const float EIHGPBEDDFL = 0.08f;

		private IDisposable CKDJCFEFIJC;

		private int ALCGNPHAGAD;

		private LABBJLNNHIM MPMPFNPJLEL;

		private const float CJAHMHHKMME = 3f;

		private bool ICFDLDGENDA;

public global::AIGGMOPIIKJ<DHJLEHBOGBG> ObjectSelection
{
get 		{
			return null;
		}

}

public global::AIGGMOPIIKJ<Guid> ShapeSelection
{
get 		{
			return null;
		}

}

public AHAGBOCIINO ShapeConfiguration
{
get 		{
			return null;
		}

}

public CreationContext CreationContext
{
get 		{
			return null;
		}

private set {
		}
}

public GMPBDONHNBM AnimationCreationContext
{
get 		{
			return null;
		}

private set {
		}
}

public HCOHEJBJCCA CurveCreationContext
{
get 		{
			return null;
		}

private set {
		}
}

public ABIODHNCLIG CircuitsEditingContext
{
get 		{
			return null;
		}

private set {
		}
}

public static MakerPen LocalPlayerMakerPen
{
get 		{
			return null;
		}

private set {
		}
}

public static bool IsLocalPlayerMakerPenHeldOrEquipped
{
get 		{
			return false;
		}

}

public static bool IsLocalPlayerMakerPenHeldInHand
{
get 		{
			return false;
		}

}

public static INHOMKPMAGA LocalPlayerMakerPenMenuData
{
get 		{
			return null;
		}

private set {
		}
}

public static bool IsProUXActive
{
get 		{
			return false;
		}

}

public static bool IsProUXSettingEnabled
{
get 		{
			return false;
		}

}

public static bool IsProUXAvailable
{
get 		{
			return false;
		}

}

public MakerPenMenuModel MakerPenMenuModel
{
get 		{
			return null;
		}

private set {
		}
}

public MakerPenPaletteSearchModel MakerPenPaletteSearchModelProUX
{
get 		{
			return null;
		}

}

public MakerPenMenuModel MakerPenMenuModelProUX
{
get 		{
			return null;
		}

}

public INHOMKPMAGA MakerPenMenuData
{
get 		{
			return null;
		}

private set {
		}
}

public bool AreTetheredMenusReady
{
get 		{
			return false;
		}

private set {
		}
}

public MakerPenMergeOperation MergeOperation
{
get 		{
			return null;
		}

}

public MakerPenSplitOperation SplitOperation
{
get 		{
			return null;
		}

}

public MakerPenSelectInventionOperation SelectInventionOperation
{
get 		{
			return null;
		}

}

public MakerPenCreateInventionFromSelectionOperation CreateInventionFromSelectionOperation
{
get 		{
			return null;
		}

}

public MakerPenGroupCircuitsV1Operation GroupCircuitsV1Operation
{
get 		{
			return null;
		}

}

public MakerPenGroupCircuitsV2Operation GroupCircuitsV2Operation
{
get 		{
			return null;
		}

}

public MakerPenAddCircuitToGroupOperation AddCircuitToGroupOperation
{
get 		{
			return null;
		}

}

public MakerPenUngroupCircuitsV1Operation UngroupCircuitsV1Operation
{
get 		{
			return null;
		}

}

public MakerPenRemoveFromGroupOperation RemoveFromGroupOperation
{
get 		{
			return null;
		}

}

public MakerPenCenterPivotOperation CenterPivotOperation
{
get 		{
			return null;
		}

}

public MakerPenRepeatCloneOperation RepeatCloneOperation
{
get 		{
			return null;
		}

}

public DIPBHNJMADC AlignOperation
{
get 		{
			return null;
		}

private set {
		}
}

public NFHGMFGKPNI InsertPointOperation
{
get 		{
			return null;
		}

private set {
		}
}

public DAHDHEMCEGC SmoothPointOperation
{
get 		{
			return null;
		}

private set {
		}
}

public bool OffhandMovementEnabled
{
get 		{
			return false;
		}

}

public MakerPenCreateStateOperation CreateStateOperation
{
get 		{
			return null;
		}

}

public PFOHJANPLPA ToolTypeChangeReason
{
get 		{
			return PFOHJANPLPA.Default;
		}

private set {
		}
}

public bool PenToolStackIsEmpty
{
get 		{
			return false;
		}

}

public FBEHJNCKJPN PenToolStackPeek
{
get 		{
			return FBEHJNCKJPN.CreateShape;
		}

}

public MakerPenVisuals PenVisuals
{
get 		{
			return null;
		}

}

public Vector3 RawPointerPosition
{
get 		{
			return default;
		}

}

public Vector3 RawPointerForward
{
get 		{
			return default;
		}

}

public LHCDLLKKBEP ActionTracker
{
get 		{
			return null;
		}

private set {
		}
}

public bool ToolModeLocked
{
get 		{
			return false;
		}

set {
		}
}

public FBEHJNCKJPN CurrentToolMode
{
get 		{
			return FBEHJNCKJPN.CreateShape;
		}

}

public HHNPLBOFAGE CurrentTargetMode
{
get 		{
			return HHNPLBOFAGE.Object;
		}

}

public HHNPLBOFAGE LastTargetMode
{
get 		{
			return HHNPLBOFAGE.Object;
		}

private set {
		}
}

public FBEHJNCKJPN LastToolMode
{
get 		{
			return FBEHJNCKJPN.CreateShape;
		}

private set {
		}
}

public JBGFOIKBKED SelectedSpawnableToolType
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

}

public Guid SelectedCircuitV2ObjectTypeId
{
get 		{
			return default;
		}

private set {
		}
}

public OEBAEGDPBLA SelectedInvention
{
get 		{
			return null;
		}

private set {
		}
}

public OEBAEGDPBLA EditedInvention
{
get 		{
			return null;
		}

private set {
		}
}

public LFIOJFLIPFC SelectedObjectSnapshot
{
get 		{
			return null;
		}

private set {
		}
}

public AMEPDCGKFOG CurrentShapeType
{
get 		{
			return AMEPDCGKFOG.CURVE_Tube;
		}

}

public BHICABGJFMG CurrentConstraintMode
{
get 		{
			return BHICABGJFMG.Free;
		}

private set {
		}
}

public FBEHJNCKJPN LastCreationToolMode
{
get 		{
			return FBEHJNCKJPN.CreateShape;
		}

private set {
		}
}

public NNBAJLCGAOK MakerPenSettings
{
get 		{
			return null;
		}

private set {
		}
}

public bool AlignToObjects
{
get 		{
			return false;
		}

}

public bool AlignToEdges
{
get 		{
			return false;
		}

}

public float CurveRadiusModifier
{
get 		{
			return 0f;
		}

}

public UndoStack UndoStack
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

public MakerPenMainScreen MainScreen
{
get 		{
			return null;
		}

private set {
		}
}

public MakerPenPaletteMainScreen PaletteMainScreen
{
get 		{
			return null;
		}

private set {
		}
}

public MakerPenPaletteMoveableToolMenu MoveablePaletteMenu
{
get 		{
			return null;
		}

}

public MakerPenPaletteUI PaletteMenuToolUI
{
get 		{
			return null;
		}

}

public float UVScale
{
get 		{
			return 0f;
		}

set {
		}
}

public JLHLKDMLBPK SelectedColor
{
get 		{
			return JLHLKDMLBPK.RRO_MIN_VALUE;
		}

set {
		}
}

public MJGMBIJIKFH SelectedMaterial
{
get 		{
			return MJGMBIJIKFH.CARDBOARD;
		}

set {
		}
}

public JECDPJHHBNL SelectedColorableSnapshot
{
get 		{
			return null;
		}

set {
		}
}

public bool IsMine
{
get 		{
			return false;
		}

}

public QuickActionMenu QuickActionMenu
{
get 		{
			return null;
		}

private set {
		}
}

public BKMDFCCNPGE PlayerBackpackToolType
{
get 		{
			return BKMDFCCNPGE.MAKER_PEN;
		}

}

private int GPFBKJOOKNF
{
get 		{
			return 3;
		}

}

public bool IsSelectingInventionObjects
{
get 		{
			return false;
		}

private set {
		}
}

private bool CDILNHKICOJ
{
get 		{
			return false;
		}

}

public static event Action LocalMakerPenHolderChanged {
add {
		}
remove {
		}
}

public static event Action ProUXQAMContentsChanged {
add {
		}
remove {
		}
}

		private void NILNOPFIADH(bool BMGEHFPFCBJ)
		{
		}

		private float BPNGPOJDBGJ()
		{
			return 0f;
		}

		public void ChangeModeAndSelectCircuitV2Object(in Guid DAAPPDPMFDF)
		{
		}

		private void FIAOPNIGECE()
		{
		}

		private bool HMBHCNMMHCI()
		{
			return false;
		}

		private void CLJCGMHDDLO()
		{
		}

		private void PMJJOFFBGOG()
		{
		}

		private void ADALBKBMLGC()
		{
		}

		private void DACACDJLIKD()
		{
		}

		public IDHANFFPOIF GetSelectedConfigurable()
		{
			return null;
		}

		public static bool SetSelectionBoundsDirtyIfSelected(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		public void EnableOffhandMovement(bool OBFHBDLKFPA, object IALNODEHBNN)
		{
		}

		public static bool IsCreationToolMode(FBEHJNCKJPN CIMCLAFMGFE)
		{
			return false;
		}

		public ShapeSwatchInfo GetSwatchInfoFromCurrentSelections()
		{
			return null;
		}

		public void ClearQuickActionMenu()
		{
		}

		public void AddProUXQuickActionMenuButton(string IEACNHGAIIE, Func<global::NCOKFFGPIJM<string>> BOJDPAGLBLI)
		{
		}

		public void AddProUXQuickActionMenuButton(string IEACNHGAIIE, QuickActionMenu.AEKKCJLBGNF MDECPMJIFKB, Func<global::NCOKFFGPIJM<string>> BOJDPAGLBLI)
		{
		}

		public void AddProUXQuickActionMenuButton(string IEACNHGAIIE, Action BOJDPAGLBLI)
		{
		}

		public void AddProUXQuickActionMenuButtonTree(string IEACNHGAIIE, List<DGMPBIPKJEB> KBADGGMGDJM, CFONBKGDGHJ KLCMEDDGHME)
		{
		}

		public DGMPBIPKJEB GetQuickActionButton(string IEACNHGAIIE, Action BOJDPAGLBLI, Sprite MDECPMJIFKB = null)
		{
			return null;
		}

		public TetheredUIModel GetOrInstantiateTetheredMainMenu()
		{
			return null;
		}

		public TetheredUIModel GetPrimaryTabTetheredMenu(MakerPenMenuModel.IEKCDJICBLP GOBCPANADIG, bool BJFGLAMKMFC)
		{
			return null;
		}

		private void ODBJJNCODOK()
		{
		}

		public bool PrimaryTabTetheredTransformDataExsists(MakerPenMenuModel.IEKCDJICBLP GOBCPANADIG)
		{
			return false;
		}

		public void SetPrimaryTabTetheredTransformData(TetheredUIBase OODKHJEMACH, MakerPenMenuModel.IEKCDJICBLP KOCNDPLELLL)
		{
		}

		public string GetNameOfTetheredUI(TetheredUIModel AMKMGAKMNND)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private bool PIELJHOGOIN()
		{
			return false;
		}

		private void Update()
		{
		}

		public void AddNewEvent(string CBNIPJLHACH)
		{
		}

		private void LCBDJFJCJDD()
		{
		}

		private void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void AddVRInputHandler(VRInputHandler JLFMCCADIKH)
		{
		}

		public void ClearVRInputHandler()
		{
		}

		private static void JCBEJCHIJFI()
		{
		}

		private static void JNPDCLHLMIJ()
		{
		}

		private static void NEIPBLPJMCP()
		{
		}

		public bool CustomPickupCondition(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		public void ShowCannotUseFeedback()
		{
		}

		public static bool CanPlayerCreateWithMakerPen(CHILKDJABBF EKOFNPFCLMO, MakerPen BHCCDMJFHEO)
		{
			return false;
		}

		public static void ShowCanUseFeedback()
		{
		}

		private void IEELJEBHDEI(Tool IEGMBEPJMGC)
		{
		}

		private void HGOBLFHDAME(bool CKKFGGLGODM)
		{
		}

		public void ToggleQAMProUXTab(bool GNGKKJPOAPJ)
		{
		}

		private static IEnumerator<EGGPGCCKPCO> FPMPLJEOIIH(int PHPMBPCAKBC, MakerPen BHCCDMJFHEO)
		{
			return null;
		}

		private void NNALCHFEBDC(Tool IEGMBEPJMGC)
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		private void BEKFIMLGKMB(Tool IEGMBEPJMGC)
		{
		}

		public void ResetOnCreationControllerStop()
		{
		}

		private void PMGLLLEOHOI()
		{
		}

		public void AuthorityResetToDefaults()
		{
		}

		public void AuthorityEnableDefaultToolIfHeldAndAllowed()
		{
		}

		private void GEPCPCGELBI(bool EAAHJEKFJCN)
		{
		}

		private void OEOGICGBPPI(IONEOHGOAML CDNLFEOBNKB, string PEOLHGGDCPN, DHJLEHBOGBG GLHOACNHHMF, JDCIJIEOFOL FOILEMDKKCC)
		{
		}

		public void RaiseInvalidActionPerformed(IONEOHGOAML CDNLFEOBNKB, string PEOLHGGDCPN, JDCIJIEOFOL FOILEMDKKCC, PCBHIGOMCDE LAGADKBKLAD = PCBHIGOMCDE.Medium, float FNIBECHGHJA = 3f)
		{
		}

		public void AuthoritySelectMode(FBEHJNCKJPN ICFLEDHNLLN, HHNPLBOFAGE KHECHJJFPJJ)
		{
		}

		public void AuthoritySelectModeForce(FBEHJNCKJPN ICFLEDHNLLN, HHNPLBOFAGE KHECHJJFPJJ)
		{
		}

		private void CPJNPBANMKF(FBEHJNCKJPN ICFLEDHNLLN, HHNPLBOFAGE KHECHJJFPJJ, PFOHJANPLPA CKHHGBNHHCK, bool COPOILGLIAJ)
		{
		}

		public LAHBDKNMNHN AuthorityPushPenTool(FBEHJNCKJPN CIMCLAFMGFE)
		{
			return null;
		}

		public void AuthorityPopPenTool()
		{
		}

		public void SelectShapeColor(JLHLKDMLBPK HKGAFJNGJIH)
		{
		}

		public void SelectShapeMaterial(MJGMBIJIKFH CLHKJCGHCNC)
		{
		}

		public void SelectColorableSnapshot(JECDPJHHBNL HDMIPGPFAPH)
		{
		}

		public void SelectShapeType(AMEPDCGKFOG LJGNKMONIGD)
		{
		}

		public void SelectSpawnableToolTypeToCreate(JBGFOIKBKED GANCINDCLMO)
		{
		}

		public void SelectCircuitV2Object(in Guid DAAPPDPMFDF)
		{
		}

		public void SelectInventionToCreate(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		public void SelectInventionToEdit(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		public void SelectSnapshotToCreate(LFIOJFLIPFC EEKOIHMJIDP)
		{
		}

		public void SelectConstraintMode(BHICABGJFMG ALBPJCHJNLM)
		{
		}

		public void SelectCurveThicknessModifier(float JJACHIBPMHA)
		{
		}

		public FBEHJNCKJPN GetCreationButtonToolModeOnClick()
		{
			return FBEHJNCKJPN.CreateShape;
		}

		public bool IsUndoAllowed()
		{
			return false;
		}

		public bool IsRedoAllowed()
		{
			return false;
		}

		public void TriggerUndo()
		{
		}

		public void TriggerRedo()
		{
		}

		public global::NCOKFFGPIJM<CreationManager.HGDLKGAFGLC.PODFOMGJNCI> SaveCurrentSelectionAsNewInvention(string KNOPFGAGMCN, string GKHMKKBKEKC, ManagedTexture IECDHEIBMJN, Guid FGCKBNAKAFN)
		{
			return null;
		}

		public global::NCOKFFGPIJM<CreationManager.HGDLKGAFGLC.PODFOMGJNCI> SaveCurrentSelectionAsNewVersionOfInvention(long KBPFKPGOCFN, Guid FGCKBNAKAFN)
		{
			return null;
		}

		private void MOOOFANFBEF(SessionManager.BEJCOLBHFDI ALMNGBDAACG)
		{
		}

		public void QueueUI(FOEIHCMEHMP JABLDCKACMN)
		{
		}

		public FOEIHCMEHMP PeekQueuedUI()
		{
			return null;
		}

		public FOEIHCMEHMP DequeueUI()
		{
			return null;
		}

		public void CloseInventionDetailsUI()
		{
		}

		public void QueueInventionUpdate(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		public OEBAEGDPBLA DequeueInventionUpdate()
		{
			return null;
		}

		public void ShowEditTagsUI(CreationObject GIDAIENJGII)
		{
		}

		public void ShowEditRolesUI(KLNOBKBCIEK GEHNEOOGNLP)
		{
		}

		public void AuthorityShowPaletteMenu()
		{
		}

		public void AuthorityHidePaletteMenu()
		{
		}

		public void AuthorityShowPaletteMainScreen(MakerPenPaletteMainScreen.CEPGPOCJAMC AIDOCIKAKCJ)
		{
		}

		public void ShowProUXFlow(MakerPenMenuModel.IEKCDJICBLP GOBCPANADIG)
		{
		}

		private void KPCAGGJIHED(MakerPenMenuModel.IEKCDJICBLP GOBCPANADIG, bool EEIBOCKNHCE)
		{
		}

		private void OPOAHOFFBNL(MakerPenMenuModel.IEKCDJICBLP GOBCPANADIG, bool EEIBOCKNHCE, TetheredUIModel JBFFEGAEBME, RRUI.Navigation.Uri FKFKJOJNCLM)
		{
		}

		public void ShowDataTableFlow(in Guid ELPGNKBFFKC)
		{
		}

		public void ShowConfigFlow(IDHANFFPOIF ICBGPHGDMFH, bool EEIBOCKNHCE)
		{
		}

		public void ShowToolsFlow(bool EEIBOCKNHCE)
		{
		}

		public void ShowSearchFlow(bool EEIBOCKNHCE)
		{
		}

		public void AuthorityHideTetheredMenus(bool MCMIOCDMGFC = false, bool COPOILGLIAJ = false)
		{
		}

		public void AuthorityRestoreTetheredMenus()
		{
		}

		public void StartInventionObjectsSelection()
		{
		}

		public bool CompleteInventionObjectsSelection(bool CCOMONEJEGO, bool LKJPBPFBAMN = false)
		{
			return false;
		}

		public void CancelInventionObjectsSelection()
		{
		}

		private void LBGBDOOANIB()
		{
		}

		private void BIAKABOEDHM()
		{
		}

		private void FKBIKOIEECB()
		{
		}

		private void BDJMKHNCCFI()
		{
		}

		private void PLDPBMENCDO()
		{
		}

		private void CLHIBJLHKPM()
		{
		}

		private bool ELOHDHNIKHM(out ExpressoUI IHDEBPNMOLM)
		{
			IHDEBPNMOLM = null;
			return false;
		}

		private void GMKGPHLFCBN(NNBAJLCGAOK CAOIPCMMNMJ)
		{
		}

		private void HFKFFDIFEBP()
		{
		}

		private void OFGHLFEKMAC()
		{
		}

		private void LLDBKCHBHOO(NNBAJLCGAOK CAOIPCMMNMJ, bool JAKKNNLMBDP)
		{
		}

		private void GNGPHCAINCL()
		{
		}

		private void KNEPLEFDMBG()
		{
		}

		private void MMGPNPCHCPP(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		private void NPEEOEMNBCI(CHILKDJABBF EKOFNPFCLMO, GameRole DGNFCCOMMEL)
		{
		}

		public void CheckMakerPenPermissionAndUpdateMode()
		{
		}

		private void JMGJDKOHAKE()
		{
		}

		private void JFDADCJDKOK()
		{
		}

		private void NDKAOCFFEED()
		{
		}

		public static void ClearClipboards()
		{
		}

		private void ANDMFPDPAKK()
		{
		}

		private void PBDGFPENAOI()
		{
		}

		private void GONCKPFEBPL()
		{
		}

		private void JBEIMNIPMAJ()
		{
		}

		private void DIFCKLALOAO(CHILKDJABBF HIGOLKPFBPL)
		{
		}

		public bool IsTapToOpen()
		{
			return false;
		}

		[CompilerGenerated]
		internal static bool BHGJDNGDBLL(JLHLKDMLBPK JGFCLDGKBAO)
		{
			return false;
		}

		[CompilerGenerated]
		private TetheredUIModel IPCGAALDGNC(ref TetheredUIModel JBEDDFCPPMG, ref KMAGLJLFLLB P_1)
		{
			return null;
		}

		[CompilerGenerated]
		private void LMIMHAOGIAE()
		{
		}

		[CompilerGenerated]
		private void MILAAIEGFEE(IONEOHGOAML CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void CHCBNKOALOG(IONEOHGOAML CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void ODPAFAJONJE()
		{
		}

		[CompilerGenerated]
		private void DOIIELOBKEG()
		{
		}

		[CompilerGenerated]
		private bool HBKGMIHGAJE()
		{
			return false;
		}

		[CompilerGenerated]
		private IEnumerator<EGGPGCCKPCO> PEHNNOKGBKB()
		{
			return null;
		}

		[CompilerGenerated]
		private bool IHCLLLKMABD()
		{
			return false;
		}
	}
}
