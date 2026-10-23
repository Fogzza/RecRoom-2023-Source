using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AGUI.StackedUI;
using CodeStage.AntiCheat.ObscuredTypes;
using Photon.Pun;
using RecRoom;
using RecRoom.AGUI;
using RecRoom.AGUI.ToolUIs;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.Controllers.ScreenBehaviors;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.Tags;
using RecRoom.Core.DataStructures;
using RecRoom.Core.Imposters;
using RecRoom.Core.Rendering;
using RecRoom.Persistence;
using RecRoom.Tools;
using UnityEngine;
using UnityEngine.Localization;

[DisallowMultipleComponent]
public sealed class Tool : MonoBehaviourPun, LEJOPAFDMEE, DJLCHGFCFAD, GCLGKPAJPCP, IIGIJFLHENF, JGPDIPBCBHK, LMFLCFFHNOF
{
	public delegate void JAAFBCHNJJO(Vector3 JOFBEGDENCK, Vector3 KGHKNCFKKMB, Vector3 OFKIOHHAEAC, float HNBOEPGMOJB, float EIGIKPJOLPF, IReadOnlyList<Camera> HFEBOPAJBLM, HGILLFNKECL MDILDPALOMC);

	public enum AMDKBHIGCGF
	{
		Unknown = 0,
		Manual = 1,
		Automatic = 2
	}

	public delegate bool ABEOEDGKNAN(out PlayerAnimation CKPMAHHPKPD);

	public enum PKKBKELPEFA
	{
		STARTING = 0,
		DEFAULT = 1,
		HELD = 2,
		EQUIPPED = 3,
		ATTACHED = 4,
		DISABLED = 5,
		CUSTOM = 6
	}

	public enum ABDEOLMIPDK
	{
		SNAP_POSITION_SNAP_ORIENTATION = 0,
		SNAP_POSITION_MAINTAIN_ORIENTATION = 1,
		MAINTAIN_POSITION_MAINTAIN_ORIENTATION = 2,
		DISABLED = -1
	}

	public enum ELEENIHEJOG
	{
		DEFAULT = 0,
		MELEE_WEAPON = 1
	}

	public delegate void AHGMEIEAKFM(Transform FDKMCMAKDOD, bool OEBFFAPHGAM, ref Vector3 INLGLHIPOMC, ref Quaternion HEGBBJCMANH);

	public delegate void MOAHFHCAKNP();

	public delegate float GPAIKGFBJDF(Collider ADMCDJKKCIA, Vector3 JJFGOCBHLOH, Quaternion CADNEKFKMNC, out bool NOEJBPDABAI);

	public delegate bool GCHLNDIIADB(Tool PMEFICGEDFK, Killzone FOOPALEAEGM);

	public delegate void PKJIOLGHELD(ref Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH, ForceMode OJOAKAEAKAC, DJBEHNDMJDL IKEDGLGPGEA);

	public delegate void BCHLGIHGLDM(ref Vector3 MCBCBMFBKCA, ref Vector3 MEBJBANMPLK, Vector3 PDFEDMAOMNH);

	public delegate bool BDLBBECKIGB(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA);

	public delegate bool DBIBEPDHDDG(Tool PMEFICGEDFK, Player DHPGNFBDHKH, CHNLCOIEBMH JMEEAMAPEDC);

	public delegate bool GMKEMCKCIAK();

	public delegate Tool FMCLKCGDIAB();

	public delegate void OJGFAHAFJAF(LMKFOACECEG? IEMMIFODLAI);

	public delegate void LLOGKNJFMNB();

	public delegate void HNDLEINDBIO(ref Vector3 NFNPPFFOJMO, ref Vector3 EBJPIKPGHIB, ELEENIHEJOG NIFOGEBEDNG);

	public delegate bool AFIGGGHEABH(Player BBHMKAPPKOD);

	private struct CNNOIGENBHN
	{
		public float HJGPGAGEJFN;

		public Vector3 LIPJJPPEAGN;

		public float OLFPCPKNFDG;
	}

	[Serializable]
	public struct InteractionSettings
	{
		public bool CanBePickedUp;

		public bool LockOnPickup;

		public bool ShowHandWhenHeld;

		public CCEOABIKJHK Handedness;

		[HideInInspector]
		public bool OptimizedPickupTransforms;

		public PickupTransforms LeftHandPickupTransforms;

		public PickupTransforms RightHandPickupTransforms;

		public Transform HipEquipSlotOrientationTransform;

		public Transform ShoulderEquipSlotOrientationTransform;

		[HideInInspector]
		public bool HasHipEquipSlot;

		[HideInInspector]
		public Vector3 HipEquipSlotPosition;

		[HideInInspector]
		public Quaternion HipEquipSlotRotation;

		[HideInInspector]
		public bool HasShoulderEquipSlot;

		[HideInInspector]
		public Vector3 ShoulderEquipSlotPosition;

		[HideInInspector]
		public Quaternion ShoulderEquipSlotRotation;

		public float ThrowSpeedMultiplier;

		public bool HasMaxThrowSpeed;

		public float MaxThrowSpeed;

		public bool CanBeEquipped;

		public bool CanHolderHandClimb;

		public static InteractionSettings Default => default;
	}

	[Serializable]
	public class PickupTransforms
	{
		public Transform Default;

		public Transform SteamVrVive;

		public Transform SteamVrOculus;

		public Transform SteamVrMicrosoft;

		public Transform Oculus;

		public Transform SteamVrIndex;

		[HideInInspector]
		public bool HasDefault;

		[HideInInspector]
		public Vector3 DefaultPosition;

		[HideInInspector]
		public Quaternion DefaultRotation;

		[HideInInspector]
		public bool HasSteamVrVive;

		[HideInInspector]
		public Vector3 SteamVrVivePosition;

		[HideInInspector]
		public Quaternion SteamVrViveRotation;

		[HideInInspector]
		public bool HasSteamVrOculus;

		[HideInInspector]
		public Vector3 SteamVrOculusPosition;

		[HideInInspector]
		public Quaternion SteamVrOculusRotation;

		[HideInInspector]
		public bool HasSteamVrMicrosoft;

		[HideInInspector]
		public Vector3 SteamVrMicrosoftPosition;

		[HideInInspector]
		public Quaternion SteamVrMicrosoftRotation;

		[HideInInspector]
		public bool HasOculus;

		[HideInInspector]
		public Vector3 OculusPosition;

		[HideInInspector]
		public Quaternion OculusRotation;

		[HideInInspector]
		public bool HasSteamVrIndex;

		[HideInInspector]
		public Vector3 SteamVrIndexPosition;

		[HideInInspector]
		public Quaternion SteamVrIndexRotation;
	}

	[Serializable]
	public struct CollisionSettings
	{
		public Collider[] IgnoredColliders;

		public List<Collider> ForceIncludeColliders;

		public bool UseExistingToolColliderLayerForDefaultLayer;

		public bool DynamicKinematicCollisionsCanBeApplied;

		public bool CanApplyDynamicKinematicCollisions;

		public float DynamicKinematicCollisionSpin;

		public bool applyForceToRemoteToolsOnAttack;

		public static CollisionSettings Default => default;
	}

	[Serializable]
	public struct AudioSettings
	{
		public RecRoomAudioClip PickupAudio;

		public RecRoomAudioClip ThrowAudio;

		public RecRoomAudioClip DropAudio;

		public RecRoomAudioClip ResetAudio;

		public RecRoomAudioClip LocalAttackAppliedAudio;

		public RecRoomAudioClip RemoteAttackAppliedAudio;

		public static AudioSettings Default => default;
	}

	[Serializable]
	public struct RenderSettings
	{
		public Renderer[] RenderersThatDoNotHoverHighlight;

		public Renderer[] RenderersThatAlwaysHoverHighlight;

		public bool VisibleWhileTeleporterVisible;

		public bool SuppressAnimateInOut;

		public bool ShouldAnimateWhileNotHeld;

		public bool SkipIncludeRenderersOutsideLODGroup;

		public static RenderSettings Default => default;
	}

	[Serializable]
	public struct ScreenActionSettings
	{
		public bool HasPickupTooltipString;

		public string PickupTooltipString;

		public LocalizedString LocalizedPickupTooltipString;

		public PlayerAnimation IdleAnimation;

		public PlayerAnimation FocusAnimation;

		public ScreenToolBehaviorConfigBase ScreenBehaviorConfig;

		public static ScreenActionSettings Default => default;
	}

	[Serializable]
	public struct VRActionSettings
	{
		public VRToolController[] ActionControllers;

		public static VRActionSettings Default => default;
	}

	[Serializable]
	public struct MenuSettings
	{
		public ToolUI menuPrefab;

		public Transform menuAnchorTransform;

		public ToolMenuProjector menuProjector;

		public static MenuSettings Default => default;
	}

	[Serializable]
	public struct RendererInstance
	{
		public Renderer Renderer;

		public Mesh Mesh;

		public int SubMeshCount;

		public RendererInstance(Renderer LPCBHIEOFOB)
		{
			Renderer = null;
			Mesh = null;
			SubMeshCount = 0;
		}
	}

	private enum ILHLLEEOBMO
	{
		Grab = 0,
		Swap = 1
	}

	private sealed class LIDMLLNHCBK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public Tool _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public LIDMLLNHCBK(int _003C_003E1__state)
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

	private sealed class PGFNBKAOAFO
	{
		public Tool _003C_003E4__this;

		public Space space;

		public Vector3 position;

		public Quaternion rotation;

		internal object _003CAuthorityResetToDefault_003Eb__0()
		{
			return null;
		}
	}

	private sealed class ONIOIJNCNLJ
	{
		public Tool _003C_003E4__this;

		public Vector3 position;

		public Quaternion rotation;

		internal object _003CAuthorityResetToToolCleanup_003Eb__0()
		{
			return null;
		}
	}

	private sealed class POMNBKPJHPH
	{
		public Renderer renderer;

		internal bool _003CInLodGroup_003Eb__0(LOD x)
		{
			return false;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct NNDBFKICALD
	{
		public PlayerHand interactingHand;

		public Tool _003C_003E4__this;

		public BCPOPPHNIMF interactionParadigm;
	}

	[StructLayout((LayoutKind)3)]
	private struct EGPNPMGBNFM : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public Tool tool;

		public RenderTexture renderTexture;

		public ImposterRenderConfig imposterConfig;

		public CancellationToken cancellationToken;

		private GameObject _003Cimposter_003E5__2;

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

	private ObscuredInt CFDNLAGEIGN;

	private bool APODLHFBCGP;

	private readonly EEANDDJEMJC NIBKHEKMJBK;

	private readonly EEANDDJEMJC KECKFEPNCDD;

	private readonly EEANDDJEMJC AHBPMNLNHDF;

	private readonly EEANDDJEMJC IEJJNIJKLED;

	private bool ACCDAPEBJBO;

	private bool MMIKJMHOIMD;

	private static int MKLDADHBKME;

	public Func<Transform> BoneTransformProvider;

	public JAAFBCHNJJO RenderAsIgnoredOverride;

	private static readonly Dictionary<JBGFOIKBKED, int> HOCOJECHIPG;

	private static readonly List<Material> MKKGDCCGHIP;

	private static readonly string PEDENFNNKJA;

	[SerializeField]
	private InteractionSettings interactionSettings;

	[SerializeField]
	private CollisionSettings collisionSettings;

	[SerializeField]
	private AudioSettings audioSettings;

	[SerializeField]
	private RenderSettings renderSettings;

	[SerializeField]
	private MenuSettings menuSettings;

	[SerializeField]
	private VRActionSettings vrSettings;

	[SerializeField]
	private ScreenActionSettings screenSettings;

	[SerializeField]
	private ToolEntity toolEntity;

	[SerializeField]
	private TaggedTool tags;

	[SerializeField]
	private AnimateInOut animateInOut;

	[SerializeField]
	private LODGroup lodGroup;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private NetworkTransform networkTransform;

	[SerializeField]
	private RigidbodyEx rigidbodyEx;

	[SerializeField]
	private RigidbodyPickup rigidbodyPickup;

	[SerializeField]
	private ToolSkinMapper toolSkinMapper;

	[SerializeField]
	private VisibleInCamera visibleInCamera;

	[SerializeField]
	private ConnectableTool connectableTool;

	[SerializeField]
	private PersistenceView persistenceView;

	[SerializeField]
	private CreationObject creationObject;

	[SerializeField]
	private MoveableToolMenu moveableToolMenu;

	private const int GJKKNLBBABO = 4;

	private const float IOMNBNIBAMI = 0.25f;

	private const int AAAALPAGIGI = 4;

	private const float OEBLCIELEAB = 0.25f;

	private static readonly string EJPLCGLBDOH;

	public const IALAJKBOKBN DEFAULT_LAYER = IALAJKBOKBN.DynamicPhysics;

	public const IALAJKBOKBN DEFAULT_HELD_LAYER = IALAJKBOKBN.DynamicPhysicsIgnorePlayerPhysics;

	public const IALAJKBOKBN DEFAULT_EQUIPPED_LAYER = IALAJKBOKBN.DynamicPhysicsIgnoreDynamicAndPlayerAndEnemyPhysics;

	public const IALAJKBOKBN DEFAULT_ATTACHED_LAYER = IALAJKBOKBN.DynamicPhysics;

	public const IALAJKBOKBN TOOL_COLLISION_DISABLED_LAYER = IALAJKBOKBN.DynamicPhysicsIgnoreDynamicPhysics;

	public const string RUNTIME_SPAWN_PARAM = "RS";

	public static Transform DoDestroyOnLoadParentTransform;

	private bool ABCJLNLLLCJ;

	private global::MOBDJNEDDKC<bool> NMNMONHBBFB;

	private global::MOBDJNEDDKC<bool> OKCLCNNHJGC;

	private global::MOBDJNEDDKC<bool> BAIAAACPLMI;

	private AMDKBHIGCGF FFKKIAKLAJG;

	private FIHGBEHGLGB CLOCJJEFKPH;

	private readonly object HAHGFMFFLLI;

	private FIHGBEHGLGB FPPAFKPIDCC;

	private readonly FIHGBEHGLGB NCBCPLBNGPG;

	private Collider NEIINKGCINI;

	private FIHGBEHGLGB AIHHPGODNML;

	private bool PEDGBHJKBCI;

	private KLCFHMGAPPO HHOEMJCPBKI;

	[EFEFIKFHIDK]
	[SerializeField]
	private bool _supportsAnimateIn;

	[EFEFIKFHIDK]
	[SerializeField]
	private bool _supportsAnimateOut;

	[SerializeField]
	[EFEFIKFHIDK]
	private bool _suppressAnimateInOut;

	private FIHGBEHGLGB FGKLMGOOHJG;

	private bool PLDKCCGJLFP;

	private bool GOKEJMMMDPB;

	private bool APGJNNGMJLH;

	private ALKAGGGCOMH EJPECHFKCKM;

	private PlayerHand.ICBKGDOJNDN JBIOAOGBGEH;

	private PlayerHand.ICBKGDOJNDN DOOLDLHPEHC;

	private global::MOBDJNEDDKC<ALKAGGGCOMH> OONFHMLJNAN;

	private bool BJGJHDGAOOI;

	private bool BAMAOAFMAMA;

	private bool NDCPFFIHNGA;

	private PhotonView MDJLIAOHFKO;

	private Player ODBIKFDCKLH;

	private Tool IJFBJPHECFD;

	private PlayerHand FFDKBFHMGLB;

	private Player EJPCPHKDFAN;

	private bool IKHHAPDLLHG;

	private bool NJLKFMFHHMK;

	private global::MKJNCDLHHNA<ABEOEDGKNAN> MIEMGDHOENL;

	private DHJLEHBOGBG DDHDDKBHLJC;

	private PlayerSpawnedEquipment GFLKDCNCCJI;

	[SerializeField]
	[EFEFIKFHIDK]
	private List<ToolCollider> colliders;

	private HashSet<ToolCollider> AGOPGLFIGFF;

	private ToolUI MIECNBHANGP;

	private bool OFOCLGBAMBE;

	private FIHGBEHGLGB GHNJBFIGDFA;

	private Vector3 PPAAKGMCIDB;

	private Quaternion HMMCFBCBJEL;

	private Player GKIIIDJHFHP;

	private CameraIgnoreBubble NKBMAKJGEMI;

	private IgnoredRendererEffect.EDOKFCMFOJO? JCAENJPDFOD;

	private FIHGBEHGLGB NANLDMMEADF;

	private object DDCGJJLIPLF;

	private object HOKBACBCDGB;

	private FIHGBEHGLGB JMDGDOFBINJ;

	[EFEFIKFHIDK]
	[SerializeField]
	private Tool _parentTool;

	[SerializeField]
	[EFEFIKFHIDK]
	private ToolCleanup _toolCleanup;

	private object PJIMIHFCPIL;

	private object NCDPDHJPNJH;

	private object FJHNKHIFILA;

	public static global::HHOBPMOCKMJ<Tool> StaticHolderChangedEvent;

	public static global::HHOBPMOCKMJ<Tool> StaticToolInstantiatedEvent;

	public static global::HHOBPMOCKMJ<Tool> StaticLockedToolPickedUpEvent;

	public static global::HHOBPMOCKMJ<Tool> StaticToolPostReleaseEvent;

	public static global::BPEPJJDICII<Tool, Collision> GenericCollisionEvent;

	public static global::BPEPJJDICII<Tool, Collision> LocalPlayerCollisionEvent;

	public global::HHOBPMOCKMJ<Tool> PostAwakeEvent;

	public global::HHOBPMOCKMJ<Tool> PostStartEvent;

	public global::HHOBPMOCKMJ<Tool> DestroyEvent;

	public global::HHOBPMOCKMJ<Tool> EnabledChangeEvent;

	public global::HHOBPMOCKMJ<Tool> HolderChangedEvent;

	public global::BPEPJJDICII<Tool, bool> IgnoredChangeEvent;

	public global::GOFBGHMGCLI<Tool, Vector3, Quaternion, Vector3, bool> PostResetEvent;

	public global::HHOBPMOCKMJ<Tool> PrePickupEvent;

	public global::HHOBPMOCKMJ<Tool> PostPickupEvent;

	public global::HHOBPMOCKMJ<Tool> PreReleaseEvent;

	public global::HHOBPMOCKMJ<Tool> PostReleaseEvent;

	public global::HHOBPMOCKMJ<Tool> PreAttachEvent;

	public global::HHOBPMOCKMJ<Tool> PostAttachEvent;

	public global::HHOBPMOCKMJ<Tool> PreDetachEvent;

	public global::HHOBPMOCKMJ<Tool> PostDetachEvent;

	public global::HHOBPMOCKMJ<Tool> HolderHandVelocityUpdateEvent;

	public global::HHOBPMOCKMJ<Tool> HoverStartEvent;

	public global::HHOBPMOCKMJ<Tool> HoverEndEvent;

	public global::HHOBPMOCKMJ<Tool> LockEvent;

	public global::HHOBPMOCKMJ<Tool> UnlockEvent;

	public global::HHOBPMOCKMJ<Tool> InputDownEvent;

	public global::HHOBPMOCKMJ<Tool> InputPressedEvent;

	public global::HHOBPMOCKMJ<Tool> InputUpEvent;

	public global::CBEFDECGNBJ<Tool, Vector3, Vector3> InputUpWithVelocityEvent;

	public global::HHOBPMOCKMJ<Tool> InputCancelledEvent;

	public global::HHOBPMOCKMJ<Tool> ShakeEvent;

	public global::KAJFMPHPBGO<Tool, Vector2, float, bool> RemoteControlInputEvent;

	public global::BPEPJJDICII<Tool, float> OwnerTeleportEvent;

	public global::CBEFDECGNBJ<Tool, float, float> OwnerRotateInPlaceEvent;

	public global::IOFEIMHAMHJ<Tool, MonoBehaviourPun, DJBEHNDMJDL, Vector3, Vector3, ForceMode> AttackAppliedEvent;

	public global::CBEFDECGNBJ<Tool, Vector3, Vector3> AuthorityForceAppliedEvent;

	public global::CBEFDECGNBJ<Tool, Vector3, Vector3> AuthorityVelocityChangeEvent;

	public global::HHOBPMOCKMJ<bool> VisibilityChangeEvent;

	public readonly global::HHOBPMOCKMJ<Tool> IsMutedChangedEvent;

	private global::BPEPJJDICII<Tool, bool> JFMHKMDPPGB;

	public AHGMEIEAKFM CustomHandSpacePickupTransformModifier;

	public MOAHFHCAKNP CustomSnapToHandBehavior;

	public GPAIKGFBJDF CustomDistanceToTransformBehavior;

	public GCHLNDIIADB CustomAuthorityResetOnKillzoneBehavior;

	public PKJIOLGHELD CustomApplyForceModifier;

	public BCHLGIHGLDM CustomVelocityChangeModifier;

	public FMCLKCGDIAB CustomSelectionForwarding;

	public GMKEMCKCIAK CustomVisibilityBehavior;

	public OJGFAHAFJAF CustomHighlightingBehavior;

	public LLOGKNJFMNB CustomSelectionRenderingBehavior;

	public OJGFAHAFJAF CustomTutorialHighlightingBehavior;

	public HNDLEINDBIO CustomResponseToImpulse;

	public AFIGGGHEABH CustomTargetingOcclusionBehavior;

	private readonly List<BDLBBECKIGB> CGDGOJONJDP;

	private readonly List<DBIBEPDHDDG> CCDMFMJELDJ;

	private static Dictionary<AMBBOEBJPNH, float> HKPPLBIOEDH;

	[NonSerialized]
	public IALAJKBOKBN HeldCollisionLayer;

	private IALAJKBOKBN BDEEGLGLKLH;

	[NonSerialized]
	private IALAJKBOKBN DBEODAGMKJH;

	[NonSerialized]
	public IALAJKBOKBN EquippedCollisionLayer;

	[NonSerialized]
	public IALAJKBOKBN AttachedCollisionLayer;

	private bool JJMPGMCNGMP;

	[NonSerialized]
	public float InputAmount;

	[NonSerialized]
	public Vector2 StickInput;

	[NonSerialized]
	public bool SprintButtonPressed;

	[NonSerialized]
	public bool CanBeLocked;

	[NonSerialized]
	public bool ReleaseWithVelocity;

	[NonSerialized]
	public bool SpawnedFromPool;

	[NonSerialized]
	public bool SupportsToolOverlap;

	[NonSerialized]
	public bool AllowedToTransferOwnershipOnCollision;

	[NonSerialized]
	public bool AlwaysPhysicalPickupOffCenter;

	[NonSerialized]
	public ABDEOLMIPDK GravityPickupMode;

	[NonSerialized]
	public bool SupportsPlayerLocomotionAttacks;

	[NonSerialized]
	public float PlayerLocomotionAttackMinForce;

	[NonSerialized]
	public float PlayerLocomotionAttackMaxForce;

	[NonSerialized]
	public bool KinematicOnReset;

	[NonSerialized]
	public bool KinematicOnSleep;

	[NonSerialized]
	public bool CapAngularVelocity;

	[NonSerialized]
	public Vector3 LastWorldSpacePickupPosition;

	[NonSerialized]
	public Quaternion LastWorldSpacePickupRotation;

	[NonSerialized]
	public bool SleepOnStart;

	[NonSerialized]
	public bool SleepOnCleanup;

	[NonSerialized]
	public bool SupportsRemoteControlInput;

	[NonSerialized]
	public bool ClearVelocitiesOnFrozenChange;

	private readonly FIHGBEHGLGB NIBLABIHNEG;

	[NonSerialized]
	public bool RemotelyRunRigidbodyPickupWhenHeld;

	private List<Tool> OBKAEJLNDOA;

	private AMBBOEBJPNH JIEAFINGALJ;

	private bool DCHMCODNKOK;

	private global::MKJNCDLHHNA<bool> GMENCPIJCCF;

	[NonSerialized]
	public LMKFOACECEG OutlineType;

	[NonSerialized]
	public PPKCAMHKMLL SelectionType;

	[SerializeField]
	[EFEFIKFHIDK]
	private List<RendererInstance> allRenderers;

	[EFEFIKFHIDK]
	[SerializeField]
	private List<RendererInstance> particleEffectRenderers;

	[EFEFIKFHIDK]
	[SerializeField]
	private List<RendererInstance> highlightRenderers;

	[HideInInspector]
	public Func<IEnumerable<Renderer>> PictureInPictureRenderers;

	[NonSerialized]
	private List<RendererInstance> JCKCIMFAOID;

	[EFEFIKFHIDK]
	[SerializeField]
	private List<Canvas> uiCanvases;

	[EFEFIKFHIDK]
	[SerializeField]
	private Renderer[] lod0Renderers;

	private IDisposable JBIHOLPCHMC;

	private IDisposable PCCGHCAHCEK;

	private IDisposable OBFNIPGNOKL;

	private IDisposable BEGJPICDGMI;

	private IDisposable LELCBOKOJIN;

	private IDisposable KAKIPGJPOPJ;

	private IDisposable AHPAIKCCJOH;

	private OEEBBDJIDDP MJNFAMDDPON;

	private Transform EIDGGAAOPFD;

	private bool MFCLFKEFBHN;

	private bool IBNFPOOOKHD;

	private Vector3 HGPJOCDDCBA;

	private Vector3 PGKKBDOKBHK;

	private bool KHKOHHIJCDP;

	private List<Killzone> EBDNJJOJIKH;

	private int EJPDHACHJMB;

	private LKGILLBEJEK KHLBBAOGEIB;

	private float FAFEDONFKNH;

	private bool DCNEDDLBHEM;

	private float FGBMNAGMFHK;

	private Vector3 DBHMGEPIKLH;

	private Vector3 EDHGMKJBGOE;

	private float BIFHAMBIEMG;

	private RigidbodyEx PKLINJEGMJD;

	private Vector3 EAMJALDJBDM;

	private Vector3 FLIPJEKOMMK;

	private bool EIKEOIDPKDH;

	[SerializeField]
	[EFEFIKFHIDK]
	private List<Tool> childTools;

	[SerializeField]
	private bool updatesSkinWhenFavorited;

	private Space? HIGHJCCBKMJ;

	private Action NINBAGJKJAM__BackingField;

	private CNNOIGENBHN HOLOOMBCHGA;

	private Vector3 PKNNMLBENLN;

	private global::MOBDJNEDDKC<bool> KFOGPGHOIGK;

	public global::BPEPJJDICII<Tool, BLPAFKLBBCF.PKFOGHJLHNG.NPLOFMDCKEH> RecordingEventOccurredEvent;

	private string HJMDEKNDCOE;

	private string FKAIFEMLNLM;

	private bool LNLOIHFGINB;

	private global::MOBDJNEDDKC<int> OGKIFCIHMEL;

	private readonly FIHGBEHGLGB OKOHNFHIGNP;

public JBGFOIKBKED SpawnableToolType
{
get 	{
		return JBGFOIKBKED.AC_UNIT;
	}

}

public int PhotonViewId
{
get 	{
		return 0;
	}

}

public EEANDDJEMJC OnDestroyed
{
get 	{
		return null;
	}

}

public EEANDDJEMJC OnEnabled
{
get 	{
		return null;
	}

}

public EEANDDJEMJC OnDisabled
{
get 	{
		return null;
	}

}

public EEANDDJEMJC OnToolSpawnedByObjectRespawner
{
get 	{
		return this.IEJJNIJKLED;
	}

}

public bool IsActiveAndEnabled
{
get 	{
		return false;
	}

}

public new bool IsDestroyed
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsRuntimeSpawned
{
get 	{
		return false;
	}

private set {
	}
}

public static int ToolCount
{
get 	{
		return 0;
	}

private set {
	}
}

public bool IsLocked
{
get 	{
		return false;
	}

set {
	}
}

public bool IsEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool IsMuted
{
get 	{
		return false;
	}

set {
	}
}

public bool IsFrozen
{
get 	{
		return false;
	}

}

public bool ManagesOwnIgnoreState
{
get 	{
		return false;
	}

set {
	}
}

public Player Owner
{
get 	{
		return null;
	}

}

public bool IsVisible
{
get 	{
		return false;
	}

}

public AMDKBHIGCGF LastReleaseType
{
get 	{
		return AMDKBHIGCGF.Unknown;
	}

set {
	}
}

public bool IsCollisionLayerLocked
{
get 	{
		return false;
	}

}

public bool IsHoverHighlighted
{
get 	{
		return false;
	}

}

public Collider HighlightedCollider
{
get 	{
		return null;
	}

set {
	}
}

public bool PickupEnabled
{
get 	{
		return false;
	}

}

public bool AttachEnabled
{
get 	{
		return false;
	}

set {
	}
}

public KLCFHMGAPPO InteractionFilter
{
get 	{
		return this.HHOEMJCPBKI;
	}

set {
	}
}

public bool SupportsAnimateIn
{
get 	{
		return false;
	}

set {
	}
}

public bool SupportsAnimateOut
{
get 	{
		return false;
	}

set {
	}
}

public bool SuppressAnimateInOut
{
get 	{
		return false;
	}

set {
	}
}

public bool IsUnderhandTossSupported
{
get 	{
		return false;
	}

}

public bool PostAwake
{
get 	{
		return false;
	}

private set {
	}
}

public bool PostStart
{
get 	{
		return false;
	}

private set {
	}
}

public int InstantiatorPhotonViewId
{
get 	{
		return 0;
	}

}

public Dictionary<string, object> InstantiationParameters
{
get 	{
		return null;
	}

}

public bool RunCollisionDetectionWhileExtrapolating
{
get 	{
		return false;
	}

set {
	}
}

public ALKAGGGCOMH HolderInfo
{
get 	{
		return null;
	}

set {
	}
}

public bool HasHolder
{
get 	{
		return false;
	}

}

public bool IsHeldByPlayer
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsEquippedOnPlayer
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsAttachedToObject
{
get 	{
		return false;
	}

private set {
	}
}

public PhotonView HolderView
{
get 	{
		return this.MDJLIAOHFKO;
	}

private set {
	}
}

public Player HolderPlayer
{
get 	{
		return this.ODBIKFDCKLH;
	}

private set {
	}
}

public Tool HolderTool
{
get 	{
		return this.IJFBJPHECFD;
	}

private set {
	}
}

public PlayerHand HolderHand
{
get 	{
		return this.FFDKBFHMGLB;
	}

private set {
	}
}

public bool IsHeldInUIRegion
{
get 	{
		return false;
	}

}

public Player PreviousNonNullHolderPlayer
{
get 	{
		return this.EJPCPHKDFAN;
	}

private set {
	}
}

public bool AllowsAttachToEquipSlot
{
get 	{
		return false;
	}

}

public bool AllowsClimbingWithHolderHand
{
get 	{
		return false;
	}

}

public bool CanBePickedUp
{
get 	{
		return false;
	}

set {
	}
}

public bool ShowHandWhenHeld
{
get 	{
		return false;
	}

}

public bool CanVRInteractUsingHandPickupAxis
{
get 	{
		return false;
	}

set {
	}
}

public bool CanDropForTwoHandedDualWielding
{
get 	{
		return false;
	}

set {
	}
}

public bool AllowedToTakeOwnership
{
get 	{
		return false;
	}

}

public PlayerHand.ICBKGDOJNDN LatestHolderHandType
{
get 	{
		return PlayerHand.ICBKGDOJNDN.Left;
	}

}

public KBEDPKIBCNN ScreensOneHandedAnimationHandedness
{
get 	{
		return KBEDPKIBCNN.RIGHT_ONLY;
	}

}

public KBEDPKIBCNN ScreensTwoHandedAnimationHandedness
{
get 	{
		return KBEDPKIBCNN.RIGHT_ONLY;
	}

}

public PlayerAnimation ScreenIdleAnimation
{
get 	{
		return null;
	}

}

public PlayerAnimation ScreenFocusAnimation
{
get 	{
		return null;
	}

}

public ScreenToolBehaviorConfigBase ScreenBehaviorConfig
{
get 	{
		return null;
	}

}

public VRToolController[] VRActionControllers
{
get 	{
		return null;
	}

}

public ToolHierarchyCache ToolHierarchyCache
{
get 	{
		return null;
	}

}

public ToolEntity ToolEntity
{
get 	{
		return this.toolEntity;
	}

}

public RigidbodyEx RigidbodyEx
{
get 	{
		return this.rigidbodyEx;
	}

}

public CreationObject CreationObject
{
get 	{
		return this.creationObject;
	}

}

public DHJLEHBOGBG CreationContextObject
{
get 	{
		return null;
	}

}

public NetworkTransform NetworkTransform
{
get 	{
		return this.networkTransform;
	}

}

public RigidbodyPickup RigidbodyPickup
{
get 	{
		return this.rigidbodyPickup;
	}

}

public TaggedTool Tags
{
get 	{
		return this.tags;
	}

}

public ToolSkinMapper SkinMapper
{
get 	{
		return this.toolSkinMapper;
	}

}

public Animator Animator
{
get 	{
		return this.animator;
	}

}

public VisibleInCamera VisibleInCamera
{
get 	{
		return this.visibleInCamera;
	}

}

public ConnectableTool ConnectableTool
{
get 	{
		return this.connectableTool;
	}

}

public PersistenceView PersistenceView
{
get 	{
		return this.persistenceView;
	}

}

public PlayerSpawnedEquipment PlayerSpawnedEquipment
{
get 	{
		return this.GFLKDCNCCJI;
	}

set {
	}
}

public IReadOnlyList<ToolCollider> Colliders
{
get 	{
		return null;
	}

}

public Collider[] CollisionIgnoredColliders
{
get 	{
		return null;
	}

}

public ToolUI Menu
{
get 	{
		return null;
	}

}

public ToolMenuProjector MenuProjector
{
get 	{
		return null;
	}

}

public MoveableToolMenu MoveableToolMenu
{
get 	{
		return this.moveableToolMenu;
	}

}

public bool HasMenuOrMoveableMenu
{
get 	{
		return false;
	}

}

public bool WasRuntimeInstantiated
{
get 	{
		return false;
	}

private set {
	}
}

private bool FIFCELPAKGA
{
get 	{
		return false;
	}

}

public bool IsSubTool
{
get 	{
		return false;
	}

}

public Vector3 LastSpawnPosition
{
get 	{
		return default;
	}

private set {
	}
}

public Quaternion LastSpawnRotation
{
get 	{
		return default;
	}

private set {
	}
}

private bool DDFHIPNGFLK
{
get 	{
		return false;
	}

}

public bool SupportsEnemyDisarm
{
get 	{
		return false;
	}

}

public Tool ParentTool
{
get 	{
		return this._parentTool;
	}

private set {
	}
}

public ToolCleanup ToolCleanup
{
get 	{
		return this._toolCleanup;
	}

private set {
	}
}

private object OBFJBDNJAOF
{
get 	{
		return null;
	}

}

private object FIIENGGJPOO
{
get 	{
		return null;
	}

}

private object JAOMKFAKLAH
{
get 	{
		return null;
	}

}

public IALAJKBOKBN DefaultCollisionLayer
{
get 	{
		return IALAJKBOKBN.Default;
	}

private set {
	}
}

public bool ExcludeFromTriggerVolume
{
get 	{
		return false;
	}

}

public IReadOnlyList<Tool> AssociatedTools
{
get 	{
		return null;
	}

}

public bool CanBeIgnored
{
get 	{
		return false;
	}

set {
	}
}

public bool LockOnPickup
{
get 	{
		return false;
	}

}

public IReadOnlyList<RendererInstance> ParticleEffectRenderers
{
get 	{
		return null;
	}

}

public IReadOnlyList<RendererInstance> HighlightRenderers
{
get 	{
		return null;
	}

}

public IReadOnlyList<RendererInstance> CustomFadeMaskRenderers
{
get 	{
		return null;
	}

}

public bool IsInputPressed
{
get 	{
		return false;
	}

}

public List<Tool> ChildTools
{
get 	{
		return null;
	}

}

public bool UpdatesSkinWhenFavorited
{
get 	{
		return false;
	}

}

public Space? ResetSpace
{
get 	{
		return null;
	}

private set {
	}
}

public Vector3 BoundsCenter
{
get 	{
		return default;
	}

}

public Vector3 CachedHighlightRendererLocalBoundsCenter
{
get 	{
		return default;
	}

private set {
	}
}

public Vector3 HighlightRendererBoundsCenter
{
get 	{
		return default;
	}

}

public bool BlockObjectPersistance
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

public bool SendMasterRecordingEvents
{
get 	{
		return false;
	}

set {
	}
}

 int global::IIGIJFLHENF.PCEHGLCLDDI
{
get 	{
		return 0;
	}

}

public GameObject GameObject
{
get 	{
		return null;
	}

}

public Bounds Bounds
{
get 	{
		return default;
	}

}

public KENMLGIKKPD Priority
{
get 	{
		return KENMLGIKKPD.Tool;
	}

}

public bool CanBeInteracted
{
get 	{
		return false;
	}

}

public bool CanBeTargetedForInteraction
{
get 	{
		return false;
	}

}

public bool CanBeTargetedWhileOccluded
{
get 	{
		return false;
	}

}

public bool IgnoreTargetingDirection
{
get 	{
		return false;
	}

set {
	}
}

public bool ShouldPlayInteractAnimation
{
get 	{
		return true;
	}

}

public bool MaintainInteractionAfterCompletionUntilInputReleased
{
get 	{
		return false;
	}

}

public CCEOABIKJHK PreferredHandedness
{
get 	{
		return CCEOABIKJHK.Dominant;
	}

set {
	}
}

public CCEOABIKJHK DefaultAuthoredHandedness
{
get 	{
		return CCEOABIKJHK.Dominant;
	}

}

public bool RequiresHoldToInteract
{
get 	{
		return false;
	}

}

public Vector3 ColliderBoundsCenter
{
get 	{
		return default;
	}

}

public event Action LocalScaleChangedEvent {
add {
	}
remove {
	}
}

	public void SetRenderersEnabled(bool IPMIIEAGJKC, object IALNODEHBNN)
	{
	}

	private void FOJOALFEPAA(bool GMEKKCPLMOB)
	{
	}

	public void SetCollisionLayersLocked(bool IPMIIEAGJKC, object IALNODEHBNN)
	{
	}

	public void ForceBestLOD(bool AMCKAOIBFJO)
	{
	}

	public void PlayAnimateInOutEffect(bool NLEOLDJOANA, Vector3? INLGLHIPOMC = null, Quaternion? HEGBBJCMANH = null, bool DGMMGMMCBPM = false)
	{
	}

	public void AuthoritySetAnimateInOut(bool LCIKFFNBHFB, bool BOOMHPPJJAO)
	{
	}

	public void EnableUnderhandToss(bool OBFHBDLKFPA, object IALNODEHBNN)
	{
	}

	public bool TryGetPickupTooltipString(out string GKGMOLFBKAL)
	{
		GKGMOLFBKAL = null;
		return false;
	}

	public void AddScreenIdleAnimationProvider(ABEOEDGKNAN BNGABNMEAEA, object IALNODEHBNN)
	{
	}

	public void RemoveScreenIdleAnimationProvider(object IALNODEHBNN)
	{
	}

	public void AddScreensEnemyDisarmEnabled(object IALNODEHBNN)
	{
	}

	public void RemoveScreensEnemyDisarmEnabled(object IALNODEHBNN)
	{
	}

	public void SetDefaultCollisionLayer(IALAJKBOKBN KOADGMIKBAB)
	{
	}

	public void SetDefaultCollisionLayer(IALAJKBOKBN JFPAECOAPCB, IALAJKBOKBN AGLIFNOGAHH)
	{
	}

	public bool SetExcludeFromTriggerVolume(object IALNODEHBNN, bool FMCDAEEODFH)
	{
		return false;
	}

	public void AddAssociatedTool(Tool ANBGIALDMKO)
	{
	}

	public void RemoveAssociatedTool(Tool ANBGIALDMKO)
	{
	}

	public void AddLockOnPickup(bool DLEMNBPMGBG, object IALNODEHBNN)
	{
	}

	public void RemoveLockOnPickup(object IALNODEHBNN)
	{
	}

	protected override void Awake()
	{
	}

	private void EJDLHEGOFDI(CHILKDJABBF HIGOLKPFBPL)
	{
	}

	private void JBHPPFDPEGB()
	{
	}

	private void Start()
	{
	}

	private void GFBDBNLFPGB(float OKBAJEAPIHG)
	{
	}

	protected override void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void CAKLAKOEBAH()
	{
	}

	private IEnumerator<EGGPGCCKPCO> LHEKNFDIGHL()
	{
		return null;
	}

	private void DGOKPOHGOHD()
	{
	}

	public void KillzoneResetImmediately(Killzone FOOPALEAEGM)
	{
	}

	public void QueueKillzoneReset(Killzone FOOPALEAEGM)
	{
	}

	public void RemoveQueuedKillzone(Killzone FOOPALEAEGM)
	{
	}

	private void FECPLCCIINC()
	{
	}

	private void FKEHLEEMCBA(float OKBAJEAPIHG)
	{
	}

	public void AddCustomPickupCondition(BDLBBECKIGB NHJPBHJLFOD)
	{
	}

	public void RemoveCustomPickupCondition(BDLBBECKIGB NHJPBHJLFOD)
	{
	}

	public void AddCustomEquipCondition(DBIBEPDHDDG NHJPBHJLFOD)
	{
	}

	public void RemoveCustomEquipCondition(DBIBEPDHDDG NHJPBHJLFOD)
	{
	}

	public void SetParentTransform(Transform BDBBMBMDCFP, bool GBDGBMCMBHI)
	{
	}

	public void Disable()
	{
	}

	public void MasterDisableAndMoveToLastSpawnPosition()
	{
	}

	public void AuthorityDisableAndMovetoLastSpawnPoint()
	{
	}

	private void KLCOBPOFAHL()
	{
	}

	public void MasterDisableAndMove(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	public void AuthorityDisableAndMove(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	public void LocalTakeOwnershipAndResetToDefault(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool EOMPBNCBADP = false)
	{
	}

	public void LocalTakeOwnershipAndResetToLastSpawnPosition()
	{
	}

	public void MasterResetToDefault(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool MMKIGMCGGMB = true)
	{
	}

	public void MasterResetToLastSpawnPosition()
	{
	}

	public void MasterResetToLastPickup()
	{
	}

	public bool AuthorityResetToDefault(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool MMKIGMCGGMB, bool EOMPBNCBADP = false, Space CFOHFHCKNNM = Space.World)
	{
		return false;
	}

	public void AuthorityResetToLastSpawnPosition(bool LMCNBJDLBDO = false)
	{
	}

	public void AuthorityResetToLastPickup(bool LMCNBJDLBDO = false)
	{
	}

	public void AuthorityResetToToolCleanup(bool LMCNBJDLBDO = false)
	{
	}

	private void PLLGKABPABI(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool DFAOAOMFDKE, Vector3 JJOPIKLAKMM, Quaternion LHAKJJMIEJI, bool EOMPBNCBADP, Space CFOHFHCKNNM, bool LMKNNPLAPOJ)
	{
	}

	private void NJHBNKMJDEH()
	{
	}

	public void EnablePickup(object IALNODEHBNN)
	{
	}

	public void DisablePickup(object IALNODEHBNN)
	{
	}

	public void SetPickupEnabled(bool BFDBCMGIOBG, object IALNODEHBNN)
	{
	}

	public bool CheckPickupLockedByKeyForLocalPlayer(bool BAMKPFEDILP)
	{
		return false;
	}

	public void AuthorityEquipToPlayer(PhotonView BDBBMBMDCFP, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, float KIJDIOHEBHG)
	{
	}

	public void AuthorityAttachToObject(PhotonView BDBBMBMDCFP, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, float KIJDIOHEBHG)
	{
	}

	public void SetReleaseVelocity(Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
	{
	}

	public void SetSpeedMultiplierBypass(bool NNKLGCNGIDF)
	{
	}

	public bool TryGetRequiredHolderTransform(Vector3 ONCLMGDKJDF, Quaternion KCFJAJOJBBG, out Vector3 DCDDOMJFDJP, out Quaternion GLDLJOGMGBI)
	{
		DCDDOMJFDJP = default;
		GLDLJOGMGBI = default;
		return false;
	}

	private void NHIJNFCFLEH()
	{
	}

	private void MHOLPPJHJPI()
	{
	}

	private void AGABFPPJFMF(CHILKDJABBF HIGOLKPFBPL)
	{
	}

	private void BGJLJIHFHIO()
	{
	}

	private void IEELJEBHDEI(bool PAFNKLLCFCF, bool ADKJMMGODJA)
	{
	}

	private void JFGMIGPAJNO()
	{
	}

	private Transform PADBGOHDCIB()
	{
		return null;
	}

	private void GGBKANLJGCH()
	{
	}

	private void PJJJHOBABJO()
	{
	}

	private void OMBDAKKKODI(Tool PMEFICGEDFK, bool BFDBCMGIOBG)
	{
	}

	private void AILCJAJGILE()
	{
	}

	private void CENICDCMODO()
	{
	}

	private void PFDFABBAOIJ()
	{
	}

	public void InputDown()
	{
	}

	public void InputPressed()
	{
	}

	public void InputUp()
	{
	}

	public void InputUpWithVelocity(Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
	{
	}

	public void InputCancelled()
	{
	}

	public void Shake()
	{
	}

	public void RemoteControlInput(Vector2 GECMPFFKOHJ, float FJNAAEFPLBO, bool NEAJIKCNMKF)
	{
	}

	public void OnPlayerRotateInPlace(float MILGOCGHFJG, float FGBPJMKCMAO)
	{
	}

	public void OnPlayerTeleport(float FGBPJMKCMAO)
	{
	}

	public void OnHolderHandVelocityUpdate()
	{
	}

	private void ODNNIPNLGHG(float EGPHDMFCNBD)
	{
	}

	private void CDJHFNBPAOB()
	{
	}

	public void HoverStart(object IALNODEHBNN)
	{
	}

	public void HoverEnd(object IALNODEHBNN)
	{
	}

	private void PENPCFOJPIK()
	{
	}

	public void GetHolderSpaceHandPickupTransform(Transform FDKMCMAKDOD, bool OEBFFAPHGAM, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
	{
		INLGLHIPOMC = default;
		HEGBBJCMANH = default;
	}

	private void FAGJHEJPLGA(bool OEBFFAPHGAM, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
	{
		INLGLHIPOMC = default;
		HEGBBJCMANH = default;
	}

	public void GetEquipSlotPickupTransform(CHNLCOIEBMH.FJPCKOJNOFJ FDJNEODEEOJ, out Vector3 JHLBHEAPNNH, out Quaternion PHHCNGHOCBI)
	{
		JHLBHEAPNNH = default;
		PHHCNGHOCBI = default;
	}

	public float SquareDistanceToTransform(Collider ADMCDJKKCIA, Vector3 JJFGOCBHLOH, Quaternion CADNEKFKMNC, out bool MPFJOMFHPCA)
	{
		MPFJOMFHPCA = default;
		return 0f;
	}

	public bool IsValidAttach()
	{
		return false;
	}

	public bool IsValidEquip(Player DHPGNFBDHKH, CHNLCOIEBMH JMEEAMAPEDC)
	{
		return false;
	}

	public void UpdateCachedApproximateSize()
	{
	}

	private void PAFHHDAIHEE(Bounds DBPFJELGIGI)
	{
	}

	private void NNINCPLIACJ()
	{
	}

	public Bounds GetColliderBounds(bool AAADJPJJFDJ = false)
	{
		return default;
	}

	public bool AddToolCollider(ToolCollider ADMCDJKKCIA)
	{
		return false;
	}

	public bool RemoveToolCollider(ToolCollider ADMCDJKKCIA)
	{
		return false;
	}

	private void BLAGANBLLGC(RigidbodyEx FNBMGBEMKPE)
	{
	}

	private void FLMGLCOOJHM()
	{
	}

	public void ResetToDefaultCollisionLayer()
	{
	}

	public IALAJKBOKBN GetCollisionLayerForMode(PKKBKELPEFA DNLPIHIBJDP, IALAJKBOKBN PBKGNAHJEAO = IALAJKBOKBN.Default)
	{
		return IALAJKBOKBN.Default;
	}

	public void SetToSpecificCollisionLayer(IALAJKBOKBN KOADGMIKBAB)
	{
	}

	public void SetToHeldCollisionLayer()
	{
	}

	public void SetToToolCollisionDisableLayer()
	{
	}

	public void SetToEquippedCollisionLayer()
	{
	}

	public void SetToAttachedCollisionLayer()
	{
	}

	private void FENNLJGHNFO(PKKBKELPEFA DNLPIHIBJDP, IALAJKBOKBN PBKGNAHJEAO = IALAJKBOKBN.Default)
	{
	}

	public void IgnoreCollision(Tool HBBJGPLMAFC, bool CHEHHIMIPCJ)
	{
	}

	public void IgnoreCollision(Collider HNPEBINPOBO, bool CHEHHIMIPCJ)
	{
	}

	public void EnableCollision(object IALNODEHBNN)
	{
	}

	public void DisableCollision(object IALNODEHBNN)
	{
	}

	public void SetCollisionEnabled(bool BFDBCMGIOBG, object IALNODEHBNN)
	{
	}

	private bool ODDAEMFNHFI(CHILKDJABBF EOKGJHJNFPK)
	{
		return false;
	}

	public void ForceIncludeColliders(IEnumerable<Collider> GHKNKHCKPII)
	{
	}

	public void InitializeColliders()
	{
	}

	private void LDBLHBHCDIA(GameObject BMNLOPDIJGF)
	{
	}

	private void OnCollisionEnter(Collision KDGCDLJEAMD)
	{
	}

	private void OnCollisionExit(Collision KDGCDLJEAMD)
	{
	}

	private void OnTriggerEnter(Collider ADMCDJKKCIA)
	{
	}

	private void OnTriggerExit(Collider ADMCDJKKCIA)
	{
	}

	private void PGAFHBMPLEC()
	{
	}

	public void AddRenderer(Renderer LPCBHIEOFOB)
	{
	}

	private void FJBPBDGFBMD(Renderer LPCBHIEOFOB, bool BKELFGLCBHC)
	{
	}

	private static bool LLPGELFADHJ(LODGroup CIFHMNKCLNG, Renderer LPCBHIEOFOB)
	{
		return false;
	}

	public void RemoveRenderer(Renderer LPCBHIEOFOB)
	{
	}

	public void AddCustomFadeMaskRenderer(Renderer LPCBHIEOFOB)
	{
	}

	public void RemoveCustomFadeMaskRenderer(Renderer LPCBHIEOFOB)
	{
	}

	public void RenderPreview(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	public void SetHideInActiveCameraAndFirstPersonCameraIgnoreSettings()
	{
	}

	public void SetCustomIgnoredSettings(IgnoredRendererEffect.EDOKFCMFOJO CAOIPCMMNMJ)
	{
	}

	public void ClearCustomIgnoredSettings()
	{
	}

	private void OJKGOJMHOCE(bool DMFMGOGDIML, object IALNODEHBNN)
	{
	}

	public void InitializeRenderers()
	{
	}

	private void PMNDBHMKLNO()
	{
	}

	public void RenderOutline(LMKFOACECEG? IEMMIFODLAI = null, bool CLHNEFFBGPD = true)
	{
	}

	private void IIEOBOKMIOD(LMKFOACECEG? IEMMIFODLAI = null)
	{
	}

	public void RenderSelection(PPKCAMHKMLL? LIHCICHMNHE)
	{
	}

	public void RenderTutorialOutline()
	{
	}

	private void LMDODPIPFFL()
	{
	}

	private void KDNICLHHFLN(AMBBOEBJPNH AFDMEBIHCFJ, AMBBOEBJPNH IOJBIPLNMIP)
	{
	}

	private void NJOPCEBNGCB(float OKBAJEAPIHG)
	{
	}

	private void NJOPCEBNGCB()
	{
	}

	private void ONCFGBNHPLA()
	{
	}

	private bool MLEADPPICON(out Player GKIIIDJHFHP, out CameraIgnoreBubble NKBMAKJGEMI)
	{
		GKIIIDJHFHP = null;
		NKBMAKJGEMI = null;
		return false;
	}

	private Player FLNFCELLKAD()
	{
		return null;
	}

	private CameraIgnoreBubble GEPCIHLKCLN()
	{
		return null;
	}

	private void DHEINEJINPN(Player GKIIIDJHFHP)
	{
	}

	private void EDGLEMCIEPA(CameraIgnoreBubble NKBMAKJGEMI)
	{
	}

	private void LGEJEJBHMNM(IgnoredRendererEffect.EDOKFCMFOJO INDFAHOKEHG)
	{
	}

	private void HBHBBKEGGJC(Vector3 JOFBEGDENCK, Vector3 KGHKNCFKKMB, Vector3 OFKIOHHAEAC, float HNBOEPGMOJB, float EIGIKPJOLPF, IReadOnlyList<Camera> HFEBOPAJBLM, HGILLFNKECL MDILDPALOMC)
	{
	}

	public void SetRenderSortFirst()
	{
	}

	public void RevertRenderSortToDefault()
	{
	}

	private void LIHKDDCAPEE(int MHAKGFHBBPF)
	{
	}

	private void AMFOPOEMMOJ(bool GMEKKCPLMOB)
	{
	}

	public bool ApplyAttackAndTryTakeOwnership(MonoBehaviourPun GLLFHCCFIGK, DJBEHNDMJDL IKEDGLGPGEA, Vector3 PDFEDMAOMNH, Vector3 COPOILGLIAJ, bool IJEBKGDCLFN = true, ForceMode OJOAKAEAKAC = ForceMode.Impulse)
	{
		return false;
	}

	private void JEINDBGNCKH(MonoBehaviourPun GLLFHCCFIGK, DJBEHNDMJDL IKEDGLGPGEA, Vector3 PDFEDMAOMNH, bool IJEBKGDCLFN, Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC)
	{
	}

	private void EDGGODHKBOE()
	{
	}

	private void CPABFGBOPBG()
	{
	}

	public void ApplyPlayerLocomotionAttack(Vector3 INLGLHIPOMC, Vector3 HLFIBIDOLEF, float OLEDABMDNHG)
	{
	}

	public void AuthorityApplyForce(Vector3 COPOILGLIAJ, Vector3 INLGLHIPOMC, ForceMode OJOAKAEAKAC, DJBEHNDMJDL IKEDGLGPGEA)
	{
	}

	public void AuthorityReceiveImpulse(Vector3 NFNPPFFOJMO, Vector3 EBJPIKPGHIB, ELEENIHEJOG NIFOGEBEDNG = ELEENIHEJOG.DEFAULT)
	{
	}

	private void MFMOCBFNFDP(Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
	{
	}

	public void SetDynamicMaxSpeed(float MJJDNDIGKOE)
	{
	}

	public void ClearDynamicMaxSpeed()
	{
	}

	public void SnapToHand()
	{
	}

	public void Snap()
	{
	}

	private void FGCECCNOHHA()
	{
	}

	public void SetUsingGravityRigidBody(bool NGBKFBEFAJK)
	{
	}

	private void KPMDEELJEFP(RigidbodyEx IDCFALFGPFP)
	{
	}

	private OBIIECHNFJK MFOANFJEMHC()
	{
		return OBIIECHNFJK.NotSupported;
	}

	public Tool SelectForwardedTool()
	{
		return null;
	}

	public DHJLEHBOGBG SelectForwardedCreationObject(Collider FFKFCMEFDFE)
	{
		return null;
	}

	private void HNDKHPADBLP()
	{
	}

	private void PLGPPGDFMHN(RigidbodyEx IDCFALFGPFP, Collision KDGCDLJEAMD)
	{
	}

	private void OPMFIMBCPFC(RigidbodyEx IDCFALFGPFP, Collision KDGCDLJEAMD, out Vector3 MCBCBMFBKCA, out Vector3 MEBJBANMPLK)
	{
		MCBCBMFBKCA = default;
		MEBJBANMPLK = default;
	}

	public void DisableDynamicKinematicCollisions(bool FMGMDPHCPJE)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnReset(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool DFAOAOMFDKE, Vector3 JJOPIKLAKMM, Quaternion LHAKJJMIEJI, bool EOMPBNCBADP, Space CFOHFHCKNNM, bool LMKNNPLAPOJ)
	{
	}

	[PBOMGCLBFHF]
	private void RpcApplyAttack(MonoBehaviourPun GLLFHCCFIGK, DJBEHNDMJDL IKEDGLGPGEA, Vector3 PDFEDMAOMNH, bool IJEBKGDCLFN, Vector3 COPOILGLIAJ, ForceMode OJOAKAEAKAC)
	{
	}

	[PBOMGCLBFHF]
	private void RpcSetAnimateInOut(bool LCIKFFNBHFB, bool BOOMHPPJJAO)
	{
	}

	private void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
	{
	}

	private void OnPhotonPlayerDisconnected(CHILKDJABBF KHKPIOPFEKF)
	{
	}

	private void OnMasterClientSwitched(CHILKDJABBF MMHMLFJPMDC)
	{
	}

	private void ANBLLNFDMDE(PhotonView BKFJMCAAIKF)
	{
	}

	public static Tool PhotonInstantiate(string FFFFBKEMJIL, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO = 1f, int PAECKOPBNFH = -1, Dictionary<string, object> FHFHNAEPAPE = null)
	{
		return null;
	}

	public static Tool PhotonInstantiateForRoom(string FFFFBKEMJIL, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO = 1f, int PAECKOPBNFH = -1, Dictionary<string, object> FHFHNAEPAPE = null)
	{
		return null;
	}

	public static Tool Find(int CKCOCAAHHNH)
	{
		return null;
	}

	private void DDMECHOMHFN(GNFJMCHKBIK ALCJDCGEBLM)
	{
	}

	void LEJOPAFDMEE.PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
	{
		//ILSpy generated this explicit interface implementation from .override directive in DDMECHOMHFN
		this.DDMECHOMHFN(ALCJDCGEBLM);
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	public static int GetToolCount(JBGFOIKBKED CKEPLIBLBFJ)
	{
		return 0;
	}

	private static void NPFMCGPKKDF(JBGFOIKBKED CKEPLIBLBFJ)
	{
	}

	private static void LPEJKECCFPC(JBGFOIKBKED CKEPLIBLBFJ)
	{
	}

	public void TryPlay3DSFX(RecRoomAudioClip DLLECDOAMDE, Vector3? PDFEDMAOMNH = null)
	{
	}

	public void SendMasterRecordingEvent(BLPAFKLBBCF.PKFOGHJLHNG.NPLOFMDCKEH PANNBMDMIEG)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterSendRecordingEvent(BLPAFKLBBCF.PKFOGHJLHNG.NPLOFMDCKEH PANNBMDMIEG)
	{
	}

	public bool GetInteractionPromptString(PIHMPBGNBHB IFEOGBCJEBI, BCPOPPHNIMF HACBGNEIIIL, PlayerHand KOMMPCGEMAP, out string DKHEOGKHDKK)
	{
		DKHEOGKHDKK = null;
		return false;
	}

	public Sprite GetInteractionSprite(PIHMPBGNBHB IFEOGBCJEBI)
	{
		return null;
	}

	public PIHMPBGNBHB GetInteractionType(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, BCPOPPHNIMF HACBGNEIIIL)
	{
		return PIHMPBGNBHB.Use;
	}

	public bool InteractingRequiresDroppingOffhandTool(PlayerHand PMNLJGLDMJN, BCPOPPHNIMF HACBGNEIIIL)
	{
		return false;
	}

	public Vector3 GetInteractionPromptPosition()
	{
		return default;
	}

	public bool OccludesTargetingForPlayer(Player EKOFNPFCLMO)
	{
		return false;
	}

	public bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
	{
		return false;
	}

	public bool CanSatisfyCustomPickupConditions(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, bool KIPCMECPDCD)
	{
		return false;
	}

	public bool CanBeInteractedByTargetingHand(Player BBHMKAPPKOD, PlayerHand GHODAKHBECE)
	{
		return false;
	}

	public bool IsPreferredHandForInteraction(PlayerHand PMNLJGLDMJN)
	{
		return false;
	}

	public LMFLCFFHNOF GetForwardedInteractable()
	{
		return null;
	}

	public void EnableTargetingForInteraction(object IALNODEHBNN)
	{
	}

	public void DisableTargetingForInteraction(object IALNODEHBNN)
	{
	}

	public void Interact(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN, bool CAEGKCMDDNC)
	{
	}

	public void StartHoldingForInteraction(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI)
	{
	}

	public void CancelHoldingForInteraction()
	{
	}

	public float GetHoldToInteractProgress()
	{
		return 0f;
	}

	public bool IsValidPickup(PlayerHand PMNLJGLDMJN)
	{
		return false;
	}

	public static Task CreateTemporaryToolImposterAndRenderPreviewToTexture(Tool IEGMBEPJMGC, RenderTexture KAACGMLIKHK, ImposterRenderConfig HHMCKFOAFIL, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	[CompilerGenerated]
	private void BHDGIEFPCLG()
	{
	}

	[CompilerGenerated]
	private void OAAGEFAINJK()
	{
	}

	[CompilerGenerated]
	private bool EHFAPIBMEEM()
	{
		return false;
	}

	[CompilerGenerated]
	private void DIBAFHEPDGL()
	{
	}

	[CompilerGenerated]
	private string ICHMFBBLHMI(string HHNMDIGPGKO, ref NNDBFKICALD P_1)
	{
		return null;
	}

	[CompilerGenerated]
	private string PAELJKLBLHJ(string HHNMDIGPGKO, ref NNDBFKICALD P_1)
	{
		return null;
	}
}
