using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AGUI.StackedUI;
using JetBrains.Annotations;
using Pathfinding;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Creation.Tags;
using RecRoom.Core.DataStructures;
using RecRoom.Tools;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	[DisallowMultipleComponent]
	public class CreationObject : MonoBehaviourPun, DJLCHGFCFAD, EPGHHBOAKOM, IDHANFFPOIF, JICDMECOFLC, GMHHJCFIMML, DHJLEHBOGBG, JGLPGIIHGIM, JKKPILGMECP, MGPMJALOCBB, AKBNDDCCILB, FHOCFMCHHJF, MPEMFIPALDL, HFCCIAENGHB, NADHPLMICLB, MJJLJOABJIP, PEJNMGDGGAF, KJGJNBDHLED, HGNMOPCBKOI, FKFAGIFPJAE, BAJJBGMMMFA, BANEAOEMGBA, LKJAJFEHDDD, MHDKIPJKDBC, BKPFMIKGFKP, NEKJJEGPHFG, GOHLPMEFMDL.EJCKFNMCGAM, KLCFHMGAPPO
	{
		public delegate IONEOHGOAML PPGIADNOFPO(CreationObject FHDPOGAOHBN);

		public delegate bool IPLFEHPGFPI(CreationObject FHDPOGAOHBN, Collider ADMCDJKKCIA);

		private sealed class HJPFFNMCOED
		{
			public DNCOGHGDMAF permission;

			internal void _003Cget_inventionPermission_003Eb__0(ODPHMCBLPNJ.OIKOMAFBJDC result)
			{
			}
		}

		private sealed class AMBIGNEIAMM
		{
			public CreationObject _003C_003E4__this;

			public DNCOGHGDMAF minimumInventionPermission;

			public AKCHPHOMHLH dynamicFoldoutMenu;

			internal bool _003CAddFoldoutMenu_003Eb__0()
			{
				return false;
			}
		}

		private sealed class DCEDEALHLHC
		{
			public ECAABEAGIAL property;

			internal bool _003CWrapProperties_003Eb__0()
			{
				return false;
			}
		}

		private sealed class CNMDMBGEKGE
		{
			public string[] existingMenus;

			internal bool _003CMergeFoldoutMenus_003Eg__predicate_007C0(DGMPBIPKJEB e)
			{
				return false;
			}
		}

		private sealed class OFNOFPILMIA
		{
			public JICDMECOFLC configurableAddOn;

			public Predicate<JICDMECOFLC> _003C_003E9__19;

			internal bool _003CGetConfigurableDynamicUI_003Eb__19(JICDMECOFLC x)
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct IKILMHECKCN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CreationObject _003C_003E4__this;

			private TaskAwaiter<MFEHAEMCKCJ> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct OFPIJPECKDK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CreationObject _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private const string ICKDOBEJNBC = "Frozen";

		private const int JHHGHCFMAEH = -1;

		public const string COLOR_PROPERTY_ID = "Color";

		public const string SPAWNABLE_TOOL_TYPE_INSTANTIATION_KEY = "CO_STT";

		public const string CIRCUIT_NODE_KEY = "CO_CN";

		public const IALAJKBOKBN SELECTION_LAYER = IALAJKBOKBN.DynamicPhysicsIgnoreDynamicAndPlayerAndEnemyPhysics;

		private static readonly Dictionary<string, MIBJNNKFLND> AHAELDPILAA;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private SandboxDeformableShape shapeDeformation;

		[SerializeField]
		private bool defaultFrozenInScene;

		[SerializeField]
		private bool canBeScaled;

		[SerializeField]
		private bool scalingRestricted;

		[SerializeField]
		private Vector3 minScaleRestriction;

		[SerializeField]
		private Vector3 maxScaleRestriction;

		[SerializeField]
		private bool canBeRotated;

		[SerializeField]
		private bool canBeCloned;

		[SerializeField]
		private bool supportsLocomotionConfig;

		[SerializeField]
		private bool supportsCenterPivotOperation;

		[SerializeField]
		private LocomotionSettings locomotionSettings;

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		private readonly List<PPGIADNOFPO> KILFPBMKFKE;

		private readonly List<IPLFEHPGFPI> HKBONGAAKGK;

		private bool DEJMDOODBPK;

		[NonSerialized]
		public bool ClearVelocitiesOnFrozenChange;

		private Func<Collider, BJIJHMNPDCH> HKCFGGOGALC;

		private CreationObjectSettingBooleanUIControl INLKOEADGAK;

		private CreationObjectSettingBooleanUIControl NBNKIEELOLN;

		private CreationObjectSettingBooleanUIControl MNEIMFCMLPJ;

		private KeyGuidEditableUIControl POHINAEHMDM;

		private TaskCompletionSource<MFEHAEMCKCJ> AMFDFDKEHCB;

		public global::HHOBPMOCKMJ<CreationObject> LockedStatusChangedEvent;

		public EEANDDJEMJC ObjectDeformed;

		public global::HHOBPMOCKMJ<bool> OnFrozenChanged;

		private Action<string> JGKHNNDBKJA__BackingField;

		private Action<CLKEJFGKNDK, AMFPEDOFIGE> NEJPHEFJCKD__BackingField;

		private Action IAFHLFDPFKJ__BackingField;

		private JBGFOIKBKED DCKFDNLHFFG;

		private Dictionary<object, Func<CostInfo>> BIMHMIGPHNL;

		private bool HOCFFNMCCJJ;

		private global::MOBDJNEDDKC<bool> CGMGNKDKEKH;

		private global::MOBDJNEDDKC<bool> OKEGJCEEDFA;

		private global::MOBDJNEDDKC<bool> JBCFCDOMDDO;

		private global::MOBDJNEDDKC<bool> IOIEIDNNDMJ;

		private global::MOBDJNEDDKC<int> LDGGNFMAMPO;

		private NGJPBEEINBG BJHFGBFCCEO;

		private global::MOBDJNEDDKC<KLNOBKBCIEK> MNMKHFGPJPH;

		private global::MOBDJNEDDKC<bool> HHPONOEHDJE;

		private global::MOBDJNEDDKC<Guid> FAEJJOJDLNA;

		private RecastMeshObj PKPJGEEJBEI;

		private Color? OCPINCLCLOG;

		private GIBEGHKMCIE? IDJLFOOGGFI;

		private GKGPHHHJLML HHGBOKAPFLH;

		private global::MOBDJNEDDKC<bool> ILCIELBICMN;

		private global::MOBDJNEDDKC<bool> ELKGIJAOGBE;

		private global::MOBDJNEDDKC<bool> AEFPGOHCIHP;

		private readonly FIHGBEHGLGB FMOFIALFFHO;

		private bool JKIDDAPJBOJ;

		private bool ONCNLPAAGMJ;

		private object NKLDLMLCEPP;

		private object GFKOMMOIHIC;

		private bool DOOGEOFKMEM;

		private ObjectGroup ICFMBNGICPN;

		private bool JBDIHOABJPO;

		public BoxCollider boundsOverrideCollider;

		private List<DGMPBIPKJEB> GIOPHJHDPJP;

		private List<JICDMECOFLC> ILDCGFEDANB;

		private const DNCOGHGDMAF MGIOBGGDDMO = DNCOGHGDMAF.EditAndSave;

		private Dictionary<Collider, ConfigurableSubpiece> ECLGAKOHDIE;

		private PFOKMDIIIPA GLOMFHOOFFF;

		private PCOCEPINJKE GEELFKBGELJ;

		private Action<CreationObject> FNPOODELEIJ__BackingField;

		private KNMIJNLBPLC HHBLCBOCLBE;

		private Action EOIGMDDEDDC__BackingField;

		private Action<DHJLEHBOGBG> NEOJCLBPMLI__BackingField;

		private const string KJFNGJPFOII = "Transformation";

		public EEANDDJEMJC OnSelectedEvent;

public Tool Tool
{
get 		{
			return null;
		}

}

public TaggedEntity TaggedEntity
{
get 		{
			return null;
		}

}

public bool TaggableProviderPresent
{
get 		{
			return false;
		}

}

public ToolHierarchyCache ToolHierarchyCache
{
get 		{
			return null;
		}

}

public JBGFOIKBKED SpawnableToolType
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

private set {
		}
}

public CostInfo SandboxResourceCost
{
get 		{
			return default;
		}

}

public bool ItemSavingForbiddenByServer
{
get 		{
			return false;
		}

}

public bool CanSaveIntoInventions
{
get 		{
			return false;
		}

}

public bool Initialized
{
get 		{
			return false;
		}

}

public bool IsGrabbable
{
get 		{
			return false;
		}

set {
		}
}

private bool OELFNOAJBEG
{
get 		{
			return false;
		}

set {
		}
}

private bool BHGMJKABJNO
{
get 		{
			return false;
		}

set {
		}
}

private bool ADCHBBAHIDN
{
get 		{
			return false;
		}

set {
		}
}

private EKECIHAKNLL GNBFPEMOFBK
{
get 		{
			return EKECIHAKNLL.NavMeshGenerator;
		}

set {
		}
}

public EKECIHAKNLL NavMeshMode
{
get 		{
			return EKECIHAKNLL.NavMeshGenerator;
		}

}

public bool InteractionFilterEnabled
{
get 		{
			return false;
		}

}

public KLNOBKBCIEK MakerPenInteractionGameRoleId
{
get 		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

}

private Guid IIFNKJBKJEJ
{
get 		{
			return default;
		}

set {
		}
}

private bool GNFJDPKCIBE
{
get 		{
			return false;
		}

}

public RecastMeshObj NavMeshIncluder
{
get 		{
			return null;
		}

set {
		}
}

public bool FirstInstanceIgnoreSandboxResourceCost
{
get 		{
			return false;
		}

}

public bool SupportsRotation
{
get 		{
			return false;
		}

}

public bool SupportsScaling
{
get 		{
			return false;
		}

}

public bool ScalingRestricted
{
get 		{
			return false;
		}

}

public Vector3 MinScalingRestriction
{
get 		{
			return default;
		}

}

public Vector3 MaxScalingRestriction
{
get 		{
			return default;
		}

}

public SandboxDeformableShape ShapeDeformation
{
get 		{
			return null;
		}

}

public bool SupportsDeformation
{
get 		{
			return false;
		}

}

public bool SupportsCloning
{
get 		{
			return false;
		}

}

public bool SupportsMirroring
{
get 		{
			return false;
		}

}

public bool SupportsCenterPivotOperation
{
get 		{
			return false;
		}

}

public bool SupportsRespawn
{
get 		{
			return false;
		}

}

public bool SupportsMerging
{
get 		{
			return false;
		}

}

public bool SupportsSplitting
{
get 		{
			return false;
		}

}

public bool SupportsKeys
{
get 		{
			return false;
		}

}

public bool CanEditWithMakerPen
{
get 		{
			return false;
		}

}

public bool SupportsRecoloring
{
get 		{
			return false;
		}

}

public Color? ColorOverride
{
get 		{
			return null;
		}

set {
		}
}

public GIBEGHKMCIE? TeamOverride
{
get 		{
			return null;
		}

set {
		}
}

public bool DynamicCollisionEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool UsesLegacyUndo
{
get 		{
			return false;
		}

}

public bool IsFrozen
{
get 		{
			return false;
		}

set {
		}
}

public bool IsLockedByRoomOwners
{
get 		{
			return false;
		}

set {
		}
}

public bool IsLockedForLocalPlayer
{
get 		{
			return false;
		}

}

public bool UsesBoundsOverride
{
get 		{
			return false;
		}

}

public FIHGBEHGLGB ShouldPersistWhenDestroyingAllFlag
{
get 		{
			return null;
		}

}

public bool CanDestroy
{
get 		{
			return false;
		}

set {
		}
}

public bool AlwaysCountCost
{
get 		{
			return false;
		}

set {
		}
}

private object EADIDNJPPKC
{
get 		{
			return null;
		}

}

private object GEKIFNDNAAF
{
get 		{
			return null;
		}

}

public NLOGLNAFFOA InventionPiece
{
get 		{
			return null;
		}

}

public ObjectGroup OwningGroup
{
get 		{
			return null;
		}

set {
		}
}

public bool IsPreviewObject
{
get 		{
			return false;
		}

private set {
		}
}

public string Title
{
get 		{
			return null;
		}

}

public string Subtitle
{
get 		{
			return null;
		}

}

public bool IsValid
{
get 		{
			return false;
		}

}

public IReadOnlyList<DGMPBIPKJEB> DynamicUIElements
{
get 		{
			return null;
		}

}

private DNCOGHGDMAF KPKLPFPIHPF
{
get 		{
			return DNCOGHGDMAF.Unassigned;
		}

}

public DNCOGHGDMAF InventionPermission
{
get 		{
			return DNCOGHGDMAF.Unassigned;
		}

}

public Dictionary<Collider, ConfigurableSubpiece> ColliderToSubPieces
{
get 		{
			return null;
		}

}

public string UniqueSynchronizedFieldKey
{
get 		{
			return null;
		}

}

public IEnumerable<PFOKMDIIIPA.MPADAPGBBII> NavMeshSupportRestrictions
{
get 		{
			return null;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public bool IsAnimated
{
get 		{
			return false;
		}

}

public GameObject GameObject
{
get 		{
			return null;
		}

}

public Guid Guid
{
get 		{
			return default;
		}

}

public string Name
{
get 		{
			return null;
		}

}

public Vector3 WorldPosition
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 LocalPosition
{
get 		{
			return default;
		}

set {
		}
}

public Quaternion WorldRotation
{
get 		{
			return default;
		}

set {
		}
}

public Quaternion LocalRotation
{
get 		{
			return default;
		}

set {
		}
}

public float WorldUniformScale
{
get 		{
			return 0f;
		}

set {
		}
}

public float LocalUniformScale
{
get 		{
			return 0f;
		}

set {
		}
}

public Vector3 LocalDeformationScale
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 WorldDeformationScale
{
get 		{
			return default;
		}

set {
		}
}

public DHJLEHBOGBG Parent
{
get 		{
			return null;
		}

}

public IDHANFFPOIF Configurable
{
get 		{
			return null;
		}

}

		[NotNull]

public GKGPHHHJLML SynchedLock
{
get 		{
			return null;
		}

}

public Type BulkDeleteHandlerType
{
get 		{
			return null;
		}

}

public object BulkDeleteObject
{
get 		{
			return null;
		}

}

public Guid BulkDeletableId
{
get 		{
			return default;
		}

}

public IEnumerable<Collider> SelectionColliders
{
get 		{
			return null;
		}

}

public BoxCollider SelectionBoundsOverride
{
get 		{
			return null;
		}

}

public bool UsesSelectionBoundsOverride
{
get 		{
			return false;
		}

}

public ControlPanelCircuitObject ControlPanelCircuitObject
{
get 		{
			return null;
		}

}

 GMHHJCFIMML global::NEKJJEGPHFG.CV2CreationObject
{
get 		{
			return null;
		}

}

public BOALOIBLNEO ObjectBoard
{
get 		{
			return null;
		}

}

public bool IsContainer
{
get 		{
			return false;
		}

}

public int SelectionPriority
{
get 		{
			return 0;
		}

}

public bool SupportsCustomEditControls
{
get 		{
			return false;
		}

}

 Transform global::GMHHJCFIMML.transform
{
get 		{
			return null;
		}

}

 PhotonView global::GMHHJCFIMML.photonView
{
get 		{
			return null;
		}

}

 CHILKDJABBF global::GMHHJCFIMML.authority
{
get 		{
			return null;
		}

}

public event Action<string> ObjectSettingsToast {
add {
		}
remove {
		}
}

 event Action<IDHANFFPOIF> global::IDHANFFPOIF.CBAGNBFFBLE {
add {
		}
remove {
		}
}

public event Action<CLKEJFGKNDK, AMFPEDOFIGE> ShowDialog {
add {
		}
remove {
		}
}

public event Action DismissAllDialogs {
add {
		}
remove {
		}
}

public event Action<CreationObject> IsGrabbableChanged {
add {
		}
remove {
		}
}

public event Action AnimatedStatusChanged {
add {
		}
remove {
		}
}

public event Action<bool> FrozenChangedEvent {
add {
		}
remove {
		}
}

public event Action ObjectScaled {
add {
		}
remove {
		}
}

public event Action<DHJLEHBOGBG> LockStatusChangeEvent {
add {
		}
remove {
		}
}

public event Action<DHJLEHBOGBG> OnCreationObjectWillDelete {
add {
		}
remove {
		}
}

		public static bool IsTrophyType(JBGFOIKBKED NIFOGEBEDNG)
		{
			return false;
		}

		private bool BBPPKLIJMGB()
		{
			return false;
		}

		private void JOKCBJOEBJH(bool IPMIIEAGJKC)
		{
		}

		private bool PGOLDGAHAKC(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public void EnsureInventionPieceRegistered()
		{
		}

		public void RegisterConfigurableAddOn(JICDMECOFLC AMDDOIBIADE)
		{
		}

		public void UnRegisterConfigurableAddOn(JICDMECOFLC NLNCJENEAOJ)
		{
		}

		private void BIHOGKINAHD()
		{
		}

		private global::NCOKFFGPIJM<ODPHMCBLPNJ.OIKOMAFBJDC> AAKBKHDBLBF()
		{
			return null;
		}

		private void PFOAPKJFCEK()
		{
		}

		public AKCHPHOMHLH CreateFoldoutMenu(string OEPJBAJNCNJ, int LAGADKBKLAD, DNCOGHGDMAF LEEIMOJMOCL = DNCOGHGDMAF.EditAndSave, List<DGMPBIPKJEB> GIOPHJHDPJP = null)
		{
			return null;
		}

		public AKCHPHOMHLH AddFoldoutMenu(string OEPJBAJNCNJ, int LAGADKBKLAD, List<DGMPBIPKJEB> GIOPHJHDPJP, DNCOGHGDMAF LEEIMOJMOCL = DNCOGHGDMAF.EditAndSave, bool IKJGMFDHCGF = true)
		{
			return null;
		}

		private DGMPBIPKJEB AOFEBAGEMJO(DGMPBIPKJEB FJILMJHCIDM)
		{
			return null;
		}

		public AKCHPHOMHLH AddFoldoutMenu(string OEPJBAJNCNJ, int LAGADKBKLAD, DNCOGHGDMAF LEEIMOJMOCL, bool IKJGMFDHCGF = true, params DGMPBIPKJEB[] GIOPHJHDPJP)
		{
			return null;
		}

		public AKCHPHOMHLH AddFoldoutMenu(string OEPJBAJNCNJ, int LAGADKBKLAD, DNCOGHGDMAF LEEIMOJMOCL, params DGMPBIPKJEB[] GIOPHJHDPJP)
		{
			return null;
		}

		public AKCHPHOMHLH AddFoldoutMenu(string OEPJBAJNCNJ, int LAGADKBKLAD, params DGMPBIPKJEB[] GIOPHJHDPJP)
		{
			return null;
		}

		private List<DGMPBIPKJEB> HMLPPPINFAD(List<DGMPBIPKJEB> DKIPBFCBBBG)
		{
			return null;
		}

		public AKCHPHOMHLH MergeFoldoutMenus(string OEPJBAJNCNJ, bool BFJABCPAOHE, params string[] MLEOCOENLFN)
		{
			return null;
		}

		public bool RemoveDynamicUIElement(DGMPBIPKJEB FJILMJHCIDM)
		{
			return false;
		}

		public void ClearDynamicUIElements()
		{
		}

		public void RegisterConfigurablePiece(ConfigurableSubpiece OLAHJEEGADB)
		{
		}

		private void MIOFFBMAFMD(ConfigurableSubpiece OLAHJEEGADB, Collider[] ONFEJOFFJNP, Collider[] IBPLCFAACKF)
		{
		}

		public void UnregisterConfigurablePiece(ConfigurableSubpiece OLAHJEEGADB)
		{
		}

		public ConfigurableSubpiece GetConfigurableSubpiece(Collider ADMCDJKKCIA)
		{
			return null;
		}

		public void FireObjectSettingsToast(string FGFCBOHADKH)
		{
		}

		public void FireDialog(CLKEJFGKNDK HNPFAOFHHII, AMFPEDOFIGE CIFKJLJDLOP)
		{
		}

		public void DismissDialogs()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void GBKDLPKLNMB(KLNOBKBCIEK GEHNEOOGNLP)
		{
		}

		public IReadOnlyList<DGMPBIPKJEB> GetConfigurableDynamicUI(List<JICDMECOFLC> GLPABBNKNEO = null)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		private void FLBLLLBEIHC(PhotonView CIPJGOKLPNK)
		{
		}

		private void BKFECPEBNCM(Guid KELOEDBAGAI, Guid CFOLBNPNOBN)
		{
		}

		private bool LJOOLGIDNDF()
		{
			return false;
		}

		private void NBJFLHJBOGJ(bool CNLKNKEAGHM)
		{
		}

		private int ODCBCOIONAC()
		{
			return 0;
		}

		private void EAFEIMILPCC(object NIFOGEBEDNG)
		{
		}

		private string MNGDJFJIMOP(object ICHBECDKHOJ)
		{
			return null;
		}

		private bool HHJLHFGFAIH()
		{
			return false;
		}

		private void NLCCFOMKDJN(bool ANEENECCADG)
		{
		}

		private bool FCCMBLLNAEK()
		{
			return false;
		}

		private void NJFMBOEAHFO(bool ADCHBBAHIDN)
		{
		}

		private bool OJAEDKBJMOB()
		{
			return false;
		}

		private void LHDJDPHHDGN(bool BHGMJKABJNO)
		{
		}

		private void MICALKBGDMG(bool JKHCBGNBGMF)
		{
		}

		private void NOCFPDJALLI(List<CreationObject> GLPABBNKNEO, bool JKHCBGNBGMF)
		{
		}

		private bool PIEELBHJEMO()
		{
			return false;
		}

		private bool AEGAIGFKOAJ()
		{
			return false;
		}

		private void FNJCLHECDHA(bool IMNGCLCHDDL)
		{
		}

		private bool BGKCEIHFIAB()
		{
			return false;
		}

		private int HPGGPADDGMJ()
		{
			return 0;
		}

		private void NHAJLAFBFLI(object KPAJLHPBFBL)
		{
		}

		private Guid EKCGOGONPJH()
		{
			return default;
		}

		private void CCCDIGJCHIK(Guid IBFKGINGICK)
		{
		}

		private void JIPPAJABMPH()
		{
		}

		public Bounds GetWorldBounds()
		{
			return default;
		}

		private Bounds CLOFDOLDACG()
		{
			return default;
		}

		public BJIJHMNPDCH GetShapeContainerForCollider(Collider ADMCDJKKCIA)
		{
			return null;
		}

		public void SetShapeContainerForColliderGetter(Func<Collider, BJIJHMNPDCH> GOIOJEGDINC)
		{
		}

		public void AddCustomSelectionCondition(PPGIADNOFPO NHJPBHJLFOD)
		{
		}

		public void RemoveCustomSelectionCondition(PPGIADNOFPO NHJPBHJLFOD)
		{
		}

		public IONEOHGOAML CanBeSelected()
		{
			return IONEOHGOAML.Success;
		}

		public bool CanBeSelected(out IONEOHGOAML PEJNHHBEBPH, out CHILKDJABBF CGKHDFHDBBP)
		{
			PEJNHHBEBPH = default;
			CGKHDFHDBBP = null;
			return false;
		}

		public void AddNavMeshSupportRestriction(PFOKMDIIIPA.MPADAPGBBII NAOILMPNIEO)
		{
		}

		public void RemoveNavMeshSupportRestriction(PFOKMDIIIPA.MPADAPGBBII NAOILMPNIEO)
		{
		}

		public void AddCustomRaycastFilter(IPLFEHPGFPI HNGJGPJCNBJ)
		{
		}

		public void RemoveCustomRaycastFilter(IPLFEHPGFPI HNGJGPJCNBJ)
		{
		}

		public bool CanBeRaycasted(Collider ADMCDJKKCIA)
		{
			return false;
		}

		public Task RequestMasterDespawn()
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcMasterDespawn()
		{
		}

		public void MasterDespawn()
		{
		}

		public void AddResourceCostModifier(Func<CostInfo> OMGEPKBDCKI, object IALNODEHBNN)
		{
		}

		public void RemoveResourceCostModifier(object IALNODEHBNN)
		{
		}

		public void AddPropertyHandler(string IDBLFHOOMPH, PCOCEPINJKE.NBEMBFBLMBB ODEFKCPHGJD)
		{
		}

		public void RemovePropertyHandler(string IDBLFHOOMPH, PCOCEPINJKE.NBEMBFBLMBB ODEFKCPHGJD)
		{
		}

		public ECMNCNMENKO ModifyProperty(GGHECEJBHPI DELCOFCGDFF, string IDBLFHOOMPH, params object[] HMJOKPKOPCN)
		{
			return null;
		}

		public bool CanModifyProperty(string OPCKJKNEHGA)
		{
			return false;
		}

		private void ABNBIDBMFNO()
		{
		}

		private void ACLCNCJHABG()
		{
		}

		public void OnIsClimbableChanged()
		{
		}

		private void GBIPGFDEIIH()
		{
		}

		private void GEJKCHEPGDJ()
		{
		}

		private void LAENJEAACHM()
		{
		}

		private bool COJDGJCNHJE(Tool IEGMBEPJMGC, Player DHPGNFBDHKH, CHNLCOIEBMH JMEEAMAPEDC)
		{
			return false;
		}

		public bool CheckPickupLockedByKeyForLocalPlayer(bool BAMKPFEDILP)
		{
			return false;
		}

		private void LEMMPKPKJKO(EOHADGOEBOD NKEGLGHKOJC)
		{
		}

		private void EDBKEMIPOJN()
		{
		}

		private void DPENMFABAIA()
		{
		}

		private void LHCHDELKIFM(CHILKDJABBF HIGOLKPFBPL)
		{
		}

		public void Reset()
		{
		}

		[PBOMGCLBFHF]
		private void RpcReset()
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Reset(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		private void FCCACMGJLNO()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public void AddIsAnimated(object IALNODEHBNN)
		{
		}

		public void RemoveIsAnimated(object IALNODEHBNN)
		{
		}

		public bool CanUpdateDeformation(Vector3 JMAKKPDDJFK, float MCNOMGBOOJI, float MKGJNLNNAKO)
		{
			return false;
		}

		public void UpdateDeformation(Vector3 JMAKKPDDJFK, float MCNOMGBOOJI)
		{
		}

		public void RenderSelection(PPKCAMHKMLL? LIHCICHMNHE)
		{
		}

		public void RenderOutline(LMKFOACECEG? IEMMIFODLAI)
		{
		}

		public void RenderWorldFadeMask()
		{
		}

		public IONEOHGOAML CanPerformUndoRedoOnObject()
		{
			return IONEOHGOAML.Success;
		}

		public void GetTransformationDataForUndoRedo(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float PDNBMOJFPKO, out Vector3 IGMDHMAILAN)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
			PDNBMOJFPKO = default;
			IGMDHMAILAN = default;
		}

		public void SetTransformationDataForUndoRedo(Vector3? INLGLHIPOMC, Quaternion? HEGBBJCMANH, float? PDNBMOJFPKO, Vector3? IGMDHMAILAN)
		{
		}

		public CHILKDJABBF GetCulprit(IONEOHGOAML KEHFEFMDBHI)
		{
			return null;
		}

		public void Translate(Vector3 FDHEPLEOFLI)
		{
		}

		public void Rotate(Quaternion INFCJCBKCCF)
		{
		}

		public bool Scale(float LJCAHLAFIEP)
		{
			return false;
		}

		public Task DeleteAsync()
		{
			return null;
		}

		public void OnTranslationStart()
		{
		}

		public void OnRotationStart()
		{
		}

		public void OnScaleStart()
		{
		}

		public void OnDeformStart()
		{
		}

		public void OnMoveStart()
		{
		}

		public void OnTranslated()
		{
		}

		public void OnRotated()
		{
		}

		public void OnScaled()
		{
		}

		public void OnDeformed(Vector3 BEEINBKHHBI)
		{
		}

		public void OnTranslationFinished()
		{
		}

		public void OnRotationFinished()
		{
		}

		public void OnScaleFinished()
		{
		}

		public void OnDeformationFinished()
		{
		}

		public void OnMoveFinished()
		{
		}

		public void OnHoverStart(FBEHJNCKJPN CIMCLAFMGFE, Collider LPGAJGPGKFM)
		{
		}

		public void OnHovering(FBEHJNCKJPN CIMCLAFMGFE, Collider LPGAJGPGKFM)
		{
		}

		public void OnHoverFinished(FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		private void LPFKIGOMPEL()
		{
		}

		private void KFIFKDNJFBN(bool MLDFDBPMBMG)
		{
		}

		public void OnCreatedBySpawning()
		{
		}

		public void AuthoritySetMakerPenInteractionFilter(KLNOBKBCIEK GEHNEOOGNLP)
		{
		}

		private static OBIIECHNFJK KMNDAGHAGDM()
		{
			return OBIIECHNFJK.NotSupported;
		}

		public void OnSelected()
		{
		}

		public void OnDeselected()
		{
		}

		public void LocalPlayerTakeAuthority()
		{
		}

		public AHCBMDMIAAM AsGroup()
		{
			return null;
		}

		public void TransferOwnership(int LFKIHFDBJNI)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2AddImpulse(Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2ReflectImpulse(Vector3 HLFIBIDOLEF, float DPIEOJGBCAN, float DMIPMFMPLAP, float MJJDNDIGKOE)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2ReflectImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HLFIBIDOLEF, float DPIEOJGBCAN, float DMIPMFMPLAP, float MJJDNDIGKOE)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2SetImpulse(Vector3 GDBGENEPKJJ, float BGDNNHOLJIH)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float BGDNNHOLJIH)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2SetAngularVelocity(Vector3 MEBJBANMPLK)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 MEBJBANMPLK, out bool EGJEBAFNALL)
		{
			EGJEBAFNALL = default;
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2AddAngularVelocity(Vector3 MEBJBANMPLK, float OIOPGDDKGKH)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 MEBJBANMPLK, float OIOPGDDKGKH, out bool EGJEBAFNALL)
		{
			EGJEBAFNALL = default;
			return default;
		}

		[Obsolete]
		[PBOMGCLBFHF]
		private void DEPRECATEDRpcAuthorityCV2SetAngularVelocity(Vector3 HEGBBJCMANH, float COHBNIGJJKO)
		{
		}

		[Obsolete]
		public global::FAIKNKAIPLB<MFEHAEMCKCJ> DEPRECATEDCV2SetAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HEGBBJCMANH, float COHBNIGJJKO)
		{
			return default;
		}

		[Obsolete]
		[PBOMGCLBFHF]
		private void DEPRECATEDRpcAuthorityCV2AddAngularVelocity(Vector3 HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
		}

		[Obsolete]
		public global::FAIKNKAIPLB<MFEHAEMCKCJ> DEPRECATEDCV2AddAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
			return default;
		}

		[Obsolete]
		[PBOMGCLBFHF]
		private void DEPRECATEDRpcAuthorityCV2SetAngularVelocity(Quaternion HEGBBJCMANH, float COHBNIGJJKO)
		{
		}

		[Obsolete]
		public global::FAIKNKAIPLB<MFEHAEMCKCJ> DEPRECATEDCV2SetAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Quaternion HEGBBJCMANH, float COHBNIGJJKO)
		{
			return default;
		}

		[Obsolete]
		[PBOMGCLBFHF]
		private void DEPRECATEDRpcAuthorityCV2AddAngularVelocity(Quaternion HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
		}

		[Obsolete]
		public global::FAIKNKAIPLB<MFEHAEMCKCJ> DEPRECATEDCV2AddAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Quaternion HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2SetPosition(Vector3 BAGMHHCMNNF)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetPosition(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2SetRotation(Quaternion DNEFKBEHEEC)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetRotation(JEGAPHLGBJA GCBHEJANCJK, in Quaternion DNEFKBEHEEC)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2SetTransform(Vector3 BAGMHHCMNNF, Quaternion DNEFKBEHEEC)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetTransform(JEGAPHLGBJA GCBHEJANCJK, in Vector3 BAGMHHCMNNF, in Quaternion DNEFKBEHEEC)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcAuthorityCV2Respawn(Vector3 BAGMHHCMNNF, Quaternion DNEFKBEHEEC, bool KBDPBKJKFGJ, bool LPKBKDOMDNB)
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Respawn(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, in bool KBDPBKJKFGJ, in bool LPKBKDOMDNB)
		{
			return default;
		}

		[PBOMGCLBFHF]
		private void RpcCV2RespawnRezEffects(Vector3 EILIODLCPLN, Quaternion HEBBLPEBPME, Vector3 OMDONGEAJAI, Quaternion GEAKEADKFIO)
		{
		}

		private bool NHOHKALPOEN(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		bool KLCFHMGAPPO.ALJKCFGGOJH(CHILKDJABBF EKOFNPFCLMO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NHOHKALPOEN
			return this.NHOHKALPOEN(EKOFNPFCLMO);
		}

		private bool NOLKIFHOPBO(in Vector3 EDGHCIEJHLG, in Vector3 HLFIBIDOLEF, ref Vector3 BBOLIJMGKDH, ref Vector3 CHEKLLFMKBP)
		{
			return false;
		}

		bool MHDKIPJKDBC.BOGNPBBACOL(in Vector3 EDGHCIEJHLG, in Vector3 HLFIBIDOLEF, ref Vector3 BBOLIJMGKDH, ref Vector3 CHEKLLFMKBP)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NOLKIFHOPBO
			return this.NOLKIFHOPBO(in EDGHCIEJHLG, in HLFIBIDOLEF, ref BBOLIJMGKDH, ref CHEKLLFMKBP);
		}

		public void SetCustomEditControls(MakerPen BHCCDMJFHEO, FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public void ConfigurableWillShow()
		{
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> POBBGLLCMPE(JEGAPHLGBJA GCBHEJANCJK, in Vector3 MEBJBANMPLK, float OIOPGDDKGKH, out bool EGJEBAFNALL)
		{
			EGJEBAFNALL = default;
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2AddAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 MEBJBANMPLK, float OIOPGDDKGKH, out bool EGJEBAFNALL)
		{
			//ILSpy generated this explicit interface implementation from .override directive in POBBGLLCMPE
			return this.POBBGLLCMPE(GCBHEJANCJK, in MEBJBANMPLK, OIOPGDDKGKH, out EGJEBAFNALL);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> ENPKHDMEKKM(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2AddImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ENPKHDMEKKM
			return this.ENPKHDMEKKM(GCBHEJANCJK, in GDBGENEPKJJ, JCOIPNJNGNL, MJJDNDIGKOE);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> JOBKNANPKME(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HLFIBIDOLEF, float DPIEOJGBCAN, float DMIPMFMPLAP, float MJJDNDIGKOE)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2ReflectImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HLFIBIDOLEF, float DPIEOJGBCAN, float DMIPMFMPLAP, float MJJDNDIGKOE)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JOBKNANPKME
			return this.JOBKNANPKME(GCBHEJANCJK, in HLFIBIDOLEF, DPIEOJGBCAN, DMIPMFMPLAP, MJJDNDIGKOE);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> AKJCDNNDGPG(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, in bool KBDPBKJKFGJ, in bool LPKBKDOMDNB)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2Respawn(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, in bool KBDPBKJKFGJ, in bool LPKBKDOMDNB)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AKJCDNNDGPG
			return this.AKJCDNNDGPG(GCBHEJANCJK, in INLGLHIPOMC, in HEGBBJCMANH, in KBDPBKJKFGJ, in LPKBKDOMDNB);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> DKHBEFADINA(JEGAPHLGBJA GCBHEJANCJK, in Vector3 MEBJBANMPLK, out bool EGJEBAFNALL)
		{
			EGJEBAFNALL = default;
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2SetAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 MEBJBANMPLK, out bool EGJEBAFNALL)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DKHBEFADINA
			return this.DKHBEFADINA(GCBHEJANCJK, in MEBJBANMPLK, out EGJEBAFNALL);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> BKIGOHELMNP(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float BGDNNHOLJIH)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2SetImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float BGDNNHOLJIH)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BKIGOHELMNP
			return this.BKIGOHELMNP(GCBHEJANCJK, in GDBGENEPKJJ, BGDNNHOLJIH);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> ACIHICFIJLN(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2SetPosition(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ACIHICFIJLN
			return this.ACIHICFIJLN(GCBHEJANCJK, in INLGLHIPOMC);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> FCPNJMLKBOH(JEGAPHLGBJA GCBHEJANCJK, in Quaternion DNEFKBEHEEC)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2SetRotation(JEGAPHLGBJA GCBHEJANCJK, in Quaternion DNEFKBEHEEC)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FCPNJMLKBOH
			return this.FCPNJMLKBOH(GCBHEJANCJK, in DNEFKBEHEEC);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> PAHFDFMEMFF(JEGAPHLGBJA GCBHEJANCJK, in Vector3 BAGMHHCMNNF, in Quaternion DNEFKBEHEEC)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.CV2SetTransform(JEGAPHLGBJA GCBHEJANCJK, in Vector3 BAGMHHCMNNF, in Quaternion DNEFKBEHEEC)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PAHFDFMEMFF
			return this.PAHFDFMEMFF(GCBHEJANCJK, in BAGMHHCMNNF, in DNEFKBEHEEC);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> IJKMCBACGMB(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.DEPRECATEDCV2AddAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IJKMCBACGMB
			return this.IJKMCBACGMB(GCBHEJANCJK, in HEGBBJCMANH, MJJDNDIGKOE, COHBNIGJJKO);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> IJKMCBACGMB(JEGAPHLGBJA GCBHEJANCJK, in Quaternion HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.DEPRECATEDCV2AddAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Quaternion HEGBBJCMANH, float MJJDNDIGKOE, float COHBNIGJJKO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IJKMCBACGMB
			return this.IJKMCBACGMB(GCBHEJANCJK, in HEGBBJCMANH, MJJDNDIGKOE, COHBNIGJJKO);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> BHBOGGHFJFI(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HEGBBJCMANH, float COHBNIGJJKO)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.DEPRECATEDCV2SetAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HEGBBJCMANH, float COHBNIGJJKO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BHBOGGHFJFI
			return this.BHBOGGHFJFI(GCBHEJANCJK, in HEGBBJCMANH, COHBNIGJJKO);
		}

		private global::FAIKNKAIPLB<MFEHAEMCKCJ> BHBOGGHFJFI(JEGAPHLGBJA GCBHEJANCJK, in Quaternion HEGBBJCMANH, float COHBNIGJJKO)
		{
			return default;
		}

		global::FAIKNKAIPLB<MFEHAEMCKCJ> GMHHJCFIMML.DEPRECATEDCV2SetAngularVelocity(JEGAPHLGBJA GCBHEJANCJK, in Quaternion HEGBBJCMANH, float COHBNIGJJKO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BHBOGGHFJFI
			return this.BHBOGGHFJFI(GCBHEJANCJK, in HEGBBJCMANH, COHBNIGJJKO);
		}

		[CompilerGenerated]
		private bool FMKAKGFFCPH()
		{
			return false;
		}

		[CompilerGenerated]
		private bool PNPCFBDIHPD()
		{
			return false;
		}

		[CompilerGenerated]
		private bool KOAFGDMHFPD()
		{
			return false;
		}

		[CompilerGenerated]
		private KLNOBKBCIEK OIIBJELBDPO()
		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

		[CompilerGenerated]
		private void AGDKMBCHCAI(KLNOBKBCIEK IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private bool IFODLPAEHGM()
		{
			return false;
		}

		[CompilerGenerated]
		private bool NFIMHFEOPKI()
		{
			return false;
		}

		[CompilerGenerated]
		private bool MNIMGJODJIN()
		{
			return false;
		}

		[CompilerGenerated]
		private bool CCNNFODHDFO()
		{
			return false;
		}

		[CompilerGenerated]
		private bool DHEBECMILFE()
		{
			return false;
		}

		[CompilerGenerated]
		private bool NLBDBEKEPGN()
		{
			return false;
		}

		[CompilerGenerated]
		private bool KAHCOFEDHIO()
		{
			return false;
		}

		[CompilerGenerated]
		private bool PPIOLCAIFBD()
		{
			return false;
		}

		[CompilerGenerated]
		private bool GDDOGMICKIG()
		{
			return false;
		}

		[CompilerGenerated]
		private bool DEAMLELKNEO()
		{
			return false;
		}

		[CompilerGenerated]
		private bool LDAKPBLKGMJ()
		{
			return false;
		}

		[CompilerGenerated]
		private bool DJIMMHJDGBN()
		{
			return false;
		}
	}
}
