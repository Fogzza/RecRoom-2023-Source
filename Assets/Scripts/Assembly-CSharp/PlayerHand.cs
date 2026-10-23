using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom;
using RecRoom.Avatars;
using RecRoom.Core.Gestures;
using RecRoom.Core.UI;
using UnityEngine;

public class PlayerHand : MonoBehaviourPun, KFLNCOLKJEM
{
	public enum ICBKGDOJNDN
	{
		Unknown = -1,
		Left = 0,
		Right = 1
	}

	public enum IMHNMIBDONP
	{
		HEAD_TO_HAND = 0,
		HAND_HALF_VECTOR = 1
	}

	public enum NDABKGBECKM
	{
		ALWAYS_DISABLED = 0,
		ALWAYS_ENABLED = 1,
		DEFAULT_DISABLED = 2
	}

	public enum PJAINFJHBKP : byte
	{
		Default = 0,
		Invisible = 1,
		HoldingTool = 2,
		InteractingWithUI = 3,
		PointGesture = 4,
		ExpressoGestureActive = 5,
		TargetingInteractableBroadPhase = 6,
		TargetingInteractablePrecisePhase = 7
	}

	public enum KAHFBNFFHGG
	{
		NotInteracting = 0,
		HoldingForDelayedInteraction = 1,
		ReadyForInteraction = 2
	}

	public class CBJGKDIEDAM
	{
		private readonly LMFLCFFHNOF PCNPMPMHGHF;

		private readonly PIHMPBGNBHB HEGJIEFALMF;

		private GNEENOANCIM.IMNMCGGINJG AAIFODBMOHF;

public float HNFEAIEDKPB
{
get 		{
			return 0f;
		}

}

public LMFLCFFHNOF JJIOEPAGKEK
{
get 		{
			return null;
		}

}

public PIHMPBGNBHB JMJKLABFEML
{
get 		{
			return PIHMPBGNBHB.Use;
		}

}

public GNEENOANCIM.IMNMCGGINJG BFHOAKEACCO
{
get 		{
			return GNEENOANCIM.IMNMCGGINJG.PrecisePhase;
		}

private set {
		}
}

public bool BJEPCCBLAPH
{
get 		{
			return false;
		}

}

		public CBJGKDIEDAM(LMFLCFFHNOF PCNPMPMHGHF, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
		{
		}
	}

	public delegate bool AIMACJCJAJN();

	private delegate PlayerAvatarDisplay.LMIHKAEHAPA DJGPIJDNBKH(PlayerHand PMNLJGLDMJN);

	private struct FCEAAIABLGH
	{
		public readonly int LDHIBGALEDK;

		public readonly PJAINFJHBKP OBJJDOENIDH;

		public FCEAAIABLGH(int LAGADKBKLAD, PJAINFJHBKP KJLHOPEHJCI)
		{
			LDHIBGALEDK = 0;
			OBJJDOENIDH = PJAINFJHBKP.Default;
		}

		public override string ToString()
		{
			return null;
		}
	}

	private struct ONIEMECBGJN
	{
		public readonly int LDHIBGALEDK;

		public readonly PlayerAvatarDisplay.LMIHKAEHAPA OBJJDOENIDH;

		public ONIEMECBGJN(int LAGADKBKLAD, PlayerAvatarDisplay.LMIHKAEHAPA KJLHOPEHJCI)
		{
			LDHIBGALEDK = 0;
			OBJJDOENIDH = PlayerAvatarDisplay.LMIHKAEHAPA.Default;
		}

		public override string ToString()
		{
			return null;
		}
	}

	[Flags]
	public enum EDAHFCFBODP
	{
		NOT_CONNECTED = 0,
		NOT_TRACKING = 1,
		CONNECTED_AND_TRACKING = 2
	}

	public enum CJJEEOGMEAB
	{
		Default = 0,
		ScreensSocial = 1,
		ScreensWavingActive = 2
	}

	[SerializeField]
	private ICBKGDOJNDN type;

	[SerializeField]
	private float worldCollisionRadius;

	[SerializeField]
	private Rigidbody dynamicPhysicsRigidbody;

	[SerializeField]
	private Collider[] interactionTriggeringColliders;

	[SerializeField]
	private float defaultGravityPickupFingerOffset;

	[SerializeField]
	private float defaultGravityPickupCapsuleLength;

	[SerializeField]
	private float defaultGravityPickupCapsuleRadius;

	[SerializeField]
	private float defaultGravityPickupSphereRadius;

	[SerializeField]
	private float defaultPhysicalPickupSphereRadius;

	[SerializeField]
	private float toolSwapDropArcTime;

	[SerializeField]
	private float toolSwapDropTossingRange;

	[SerializeField]
	private float remoteHandAnimationCullingDistance;

	private float EEGONAACCBO;

	[SerializeField]
	private Transform defaultHandRoot;

	[SerializeField]
	private Transform pointingHandRoot;

	[SerializeField]
	private Transform menuRaycastOrigin;

	public static readonly float HOVERED_INTERACTABLE_INTERACTION_SLOP_WINDOW;

	private const float EMFBDNEKLJB = 3f;

	private const float KDGOCLNAPAF = 0.1f;

	private const int MPBAPGPLDME = 10;

	private const float MOKFFDAFIOF = 0.025f;

	public global::BPEPJJDICII<PlayerHand, Tool> PickupToolEvent;

	public global::BPEPJJDICII<PlayerHand, Tool> ReleaseToolEvent;

	public global::CBEFDECGNBJ<PlayerHand, int, float> VibrateEvent;

	private Action LNOHDHJCOEM__BackingField;

	public AIMACJCJAJN CanRunToolMenuButtonBehaviorOverride;

	public AIMACJCJAJN RunToolMenuButtonBehaviorOverride;

	private static readonly Dictionary<PJAINFJHBKP, DJGPIJDNBKH> LJDOEKCGKEA;

	public static NDABKGBECKM ConcaveMeshWorldCollisionMode;

	[SerializeField]
	private Transform watchMenuOrigin;

	[SerializeField]
	private Transform watchAnchor;

	[SerializeField]
	private Transform watchFaceTransform;

	[SerializeField]
	private Transform handCenter;

	[SerializeField]
	private Transform meshRoot;

	[SerializeField]
	private Transform handshakeConnectionTransform;

	[SerializeField]
	private Transform fistbumpConnectionTransform;

	[SerializeField]
	private Transform highFiveConnectionTransform;

	private readonly List<PlayerHandCollider> MCPBBOCGEJE;

	private PlayerCollider JHDJINPKIOO;

	private PlayerCollider PDPALBOLPMK;

	[SerializeField]
	private Player _thisPlayer;

	[SerializeField]
	private PlayerHandGestures _gestures;

	[SerializeField]
	private Animator _handAnimator;

	[SerializeField]
	private NetworkTransform _networkTransform;

	[SerializeField]
	private RigidbodyPickup _rigidbodyPickup;

	[SerializeField]
	private RigidbodyEx _rigidbodyEx;

	[SerializeField]
	private LaserTeleporter _laserTeleporter;

	[SerializeField]
	private MenuFinger _localMenuFinger;

	private NDNDHMIKFJI CJDMGEHAEFA;

	private float LGBFIHGINHA;

	private float EHKLFOEFNJF;

	private float POCKEAHPHBK;

	private float AFODDJMHLJC;

	private float OOAHHBLLNMD;

	private IMHNMIBDONP BLPKCNKLDLK;

	private static readonly FCEAAIABLGH JLNGKBLDBOK;

	private static readonly FCEAAIABLGH AOPKPDOPBFG;

	private static readonly FCEAAIABLGH ONDMNFCAPPC;

	private static readonly FCEAAIABLGH JGJOJPMGBDD;

	private static readonly FCEAAIABLGH LEJEFAFGFGO;

	private static readonly FCEAAIABLGH OFCKIHJFOEC;

	private static readonly FCEAAIABLGH EKHBDEBKFCG;

	private static readonly FCEAAIABLGH KMBLAKOIEGO;

	private static readonly FCEAAIABLGH FDMBFDLHNCF;

	private static readonly FCEAAIABLGH FHEHGNCMHLE;

	private static readonly FCEAAIABLGH DKKHNDKDEAJ;

	private static readonly FCEAAIABLGH GGLGBHLLAAN;

	private static readonly FCEAAIABLGH AGKMOFFABIJ;

	private static readonly FCEAAIABLGH IHCDDMIIACD;

	private static readonly FCEAAIABLGH EPPMAMEEKOB;

	private static readonly ONIEMECBGJN MNCKCLOBMEJ;

	private readonly global::AFHOAHNAMGF<PlayerAvatarDisplay.LMIHKAEHAPA> BANOICHHDNF;

	private readonly global::AFHOAHNAMGF<PJAINFJHBKP> ECBJEOIJCJB;

	private readonly global::MKJNCDLHHNA<bool> CNPIMOADDGM;

	private LKGILLBEJEK LGPLFKKHJFO;

	private bool ADLGCMDKOND;

	private Tool CDEKLJDEHHA;

	private bool JGANBJEENIK;

	private bool LDGKKICBLKM;

	private FIHGBEHGLGB KBHFGCLDGFL;

	private bool DOPOGAMKEDH;

	private bool FCBHCOMMGDJ;

	private readonly List<object> HMBDEAMHLMB;

	private readonly List<object> BPIONJKAJGM;

	private LMFLCFFHNOF JGHDAFJHDJN;

	private LMFLCFFHNOF BHEJAHPHFMG;

	private bool EBGGNDIOFLH;

	private bool PBLNDHLFKGK;

	private float MMMHNBEEGDN;

	private CBJGKDIEDAM JBBMJEEFFBD;

	private global::MOBDJNEDDKC<EDAHFCFBODP> HKIJAPOIHGI;

	private global::MOBDJNEDDKC<PJAINFJHBKP> OFPMEEDFDCO;

	private global::JPEBBAFCBEP<GHCICEFBOGM, bool> CFLFPGCIEDF;

	private float FBPLIBIGBAM;

	private readonly FIHGBEHGLGB OLHCJPBIHAN;

	private readonly FIHGBEHGLGB CJHJBKEMNJK;

	private readonly FIHGBEHGLGB AFENJDPHOHO;

	private readonly FIHGBEHGLGB GJHFKKJKENF;

	private readonly FIHGBEHGLGB KNIMDBMKCPC;

	private readonly FIHGBEHGLGB KGCOEGLOCMD;

	private readonly FIHGBEHGLGB GMBEACMJDFK;

	private readonly FIHGBEHGLGB FOMJFPKDMIP;

	public readonly global::HHOBPMOCKMJ<Player> RemotePlayerRequestedGestureEvent;

	private readonly global::AFHOAHNAMGF<GHCICEFBOGM> AJCHBBBNMLM;

	private const float DLGLIIBHDIC = 100f;

	private const float FLCIJCBBHKD = 0.5f;

	private const float IAEOIAMFOLC = 0.3f;

	private const float OGEELJJLFCK = 0.09f;

public Transform WatchMenuOrigin
{
get 	{
		return this.watchMenuOrigin;
	}

}

public Transform WatchAnchor
{
get 	{
		return this.watchAnchor;
	}

}

public Transform WatchFaceTransform
{
get 	{
		return this.watchFaceTransform;
	}

}

public Player ThisPlayer
{
get 	{
		return this._thisPlayer;
	}

}

public PlayerHandGestures Gestures
{
get 	{
		return this._gestures;
	}

}

public Animator HandAnimator
{
get 	{
		return this._handAnimator;
	}

}

public List<PlayerHandCollider> HandColliders
{
get 	{
		return null;
	}

}

public Transform DefaultHandRoot
{
get 	{
		return this.defaultHandRoot;
	}

}

public NetworkTransform NetworkTransform
{
get 	{
		return this._networkTransform;
	}

}

public RigidbodyPickup RigidbodyPickup
{
get 	{
		return this._rigidbodyPickup;
	}

}

public RigidbodyEx RigidbodyEx
{
get 	{
		return this._rigidbodyEx;
	}

}

public Rigidbody DynamicPhysicsRigidbody
{
get 	{
		return this.dynamicPhysicsRigidbody;
	}

}

public LaserTeleporter LaserTeleporter
{
get 	{
		return this._laserTeleporter;
	}

}

public MenuFinger LocalMenuFinger
{
get 	{
		return this._localMenuFinger;
	}

}

public Vector3 MenuRaycastFingertipPosition
{
get 	{
		return default;
	}

}

public Vector3 MenuRaycastFingertipDirection
{
get 	{
		return default;
	}

}

public NDNDHMIKFJI VelocityTracker
{
get 	{
		return this.CJDMGEHAEFA;
	}

private set {
	}
}

public float GravityPickupFingerOffset
{
get 	{
		return this.LGBFIHGINHA;
	}

set {
		this.LGBFIHGINHA = value;
	}
}

public float GravityPickupCapsuleLength
{
get 	{
		return this.EHKLFOEFNJF;
	}

set {
		this.EHKLFOEFNJF = value;
	}
}

public float GravityPickupCapsuleRadius
{
get 	{
		return this.POCKEAHPHBK;
	}

set {
		this.POCKEAHPHBK = value;
	}
}

public float GravityPickupSphereRadius
{
get 	{
		return this.AFODDJMHLJC;
	}

set {
		this.AFODDJMHLJC = value;
	}
}

public float PhysicalPickupSphereRadius
{
get 	{
		return this.OOAHHBLLNMD;
	}

set {
		this.OOAHHBLLNMD = value;
	}
}

public float ScaledPhysicalPickupSphereRadius
{
get 	{
		return 0f;
	}

}

public IMHNMIBDONP GravityPickupDirectionMode
{
get 	{
		return IMHNMIBDONP.HEAD_TO_HAND;
	}

set {
	}
}

public float OpenClosedAxis
{
get 	{
		return 0f;
	}

set {
	}
}

public bool IsClosed
{
get 	{
		return false;
	}

}

public bool IsOpen
{
get 	{
		return false;
	}

}

public ICBKGDOJNDN Type
{
get 	{
		return ICBKGDOJNDN.Left;
	}

}

public Vector3 PalmDirection
{
get 	{
		return default;
	}

}

public Vector3 FingerDirection
{
get 	{
		return default;
	}

}

public Vector3 ThumbDirection
{
get 	{
		return default;
	}

}

public Transform PhysicalPickupOriginTransform
{
get 	{
		return this.handCenter;
	}

}

public Vector3 PhysicalPickupOrigin
{
get 	{
		return default;
	}

}

public Vector3 PhysicalPickupOriginLocalSpace
{
get 	{
		return default;
	}

}

public Quaternion PhysicalPickupRotationLocalSpace
{
get 	{
		return default;
	}

}

public Vector3 GravityPickupOrigin
{
get 	{
		return default;
	}

}

public Vector3 GravityPickupOriginLocalSpace
{
get 	{
		return default;
	}

}

public Vector3 GravityPickupDirection
{
get 	{
		return default;
	}

}

public Vector3 GravityPickupDirectionLocalSpace
{
get 	{
		return default;
	}

}

public Vector3 HandOnlyVelocity
{
get 	{
		return default;
	}

}

private LKGILLBEJEK AKGPIHCJCKE
{
get 	{
		return null;
	}

set {
	}
}

public bool LocalHasMenuTarget
{
get 	{
		return this.ADLGCMDKOND;
	}

set {
	}
}

public bool LocalExpressoMenuInputActive
{
get 	{
		return false;
	}

set {
	}
}

public bool LocalPointGestureInputActive
{
get 	{
		return false;
	}

set {
	}
}

public bool LocalScreensSocialGestureActive
{
get 	{
		return false;
	}

set {
	}
}

public bool LocalScreensPointGestureActive
{
get 	{
		return false;
	}

set {
	}
}

public bool LocalScreensWavingGestureActive
{
get 	{
		return false;
	}

set {
	}
}

public Tool HeldTool
{
get 	{
		return this.CDEKLJDEHHA;
	}

set {
	}
}

public bool HasUIRegions
{
get 	{
		return this.JGANBJEENIK;
	}

private set {
	}
}

public bool HasForcedUIRegions
{
get 	{
		return this.LDGKKICBLKM;
	}

private set {
	}
}

public bool IsExitSeatInputRestricted
{
get 	{
		return false;
	}

}

public bool IsHoldingTool
{
get 	{
		return false;
	}

}

public bool HandInUIRegion
{
get 	{
		return false;
	}

}

public CBJGKDIEDAM QueuedDelayedInteraction
{
get 	{
		return this.JBBMJEEFFBD;
	}

private set {
	}
}

public EDAHFCFBODP HandConnectedState
{
get 	{
		return EDAHFCFBODP.NOT_CONNECTED;
	}

set {
	}
}

public PJAINFJHBKP CurrentHandState
{
get 	{
		return PJAINFJHBKP.Default;
	}

private set {
	}
}

public GHCICEFBOGM CurrentGestureType
{
get 	{
		return GHCICEFBOGM.None;
	}

private set {
	}
}

public bool IsRunningGesture
{
get 	{
		return false;
	}

private set {
	}
}

private PlayerAvatarDisplay.LMIHKAEHAPA FGPDILJDHBI
{
get 	{
		return PlayerAvatarDisplay.LMIHKAEHAPA.Default;
	}

}

private bool MEJAFKLNGOD
{
get 	{
		return false;
	}

}

public bool HandVisualsActive
{
get 	{
		return false;
	}

}

public bool VisualStateAllowsGestureCollisions
{
get 	{
		return false;
	}

}

public bool HandshakeAnimationEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool ThumbsUpAnimationEnabled
{
get 	{
		return false;
	}

set {
	}
}

public float AvatarSkeletonAnimationMaskLocalOnly
{
get 	{
		return this.FBPLIBIGBAM;
	}

set {
		this.FBPLIBIGBAM = value;
	}
}

public Player.NBPIPAJOGLC BodyPart
{
get 	{
		return Player.NBPIPAJOGLC.Head;
	}

}

public bool ActsAsDominantForInteraction
{
get 	{
		return false;
	}

}

public bool ActsAsOffHandForInteraction
{
get 	{
		return false;
	}

}

public bool CanSwapTools
{
get 	{
		return false;
	}

}

public bool CanInteractWhileHoldingUnlockedTool
{
get 	{
		return false;
	}

}

public bool CanUseMenuLaser
{
get 	{
		return false;
	}

}

public bool HeldToolUseRestricted
{
get 	{
		return false;
	}

}

public bool InteractionWithInteractablesRestricted
{
get 	{
		return false;
	}

}

public bool ToolManualPickupRestricted
{
get 	{
		return false;
	}

}

public bool IsManualToolDropRestricted
{
get 	{
		return false;
	}

}

public bool IsPointAtWorldUIRestricted
{
get 	{
		return false;
	}

}

public bool IsLaserButtonPropsRestricted
{
get 	{
		return false;
	}

}

public bool IsBehaviorRestricted
{
get 	{
		return false;
	}

}

public bool IsProneCrawlAnimationPreferred
{
get 	{
		return false;
	}

}

public bool HasCurrentGesture
{
get 	{
		return false;
	}

}

public event Action VisualStateChangedEvent {
add {
	}
remove {
	}
}

	private static PlayerAvatarDisplay.LMIHKAEHAPA DHDCALGCOMM(PlayerHand PMNLJGLDMJN)
	{
		return PlayerAvatarDisplay.LMIHKAEHAPA.Default;
	}

	private static PlayerAvatarDisplay.LMIHKAEHAPA DMLEAAAHLPC(PlayerHand PMNLJGLDMJN)
	{
		return PlayerAvatarDisplay.LMIHKAEHAPA.Default;
	}

	private void GPHKNIOKANK(FCEAAIABLGH IALNODEHBNN, bool IDDBOJHDPBC)
	{
	}

	private void LKIDCBJMCCG(ONIEMECBGJN IALNODEHBNN, bool IDDBOJHDPBC)
	{
	}

	public void SetIsPerformingMakerPenMove(bool LCHMOFOLLHG)
	{
	}

	private void CPNINDMPJID()
	{
	}

	public void AddExitSeatInputRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveExitSeatInputRestriction(object IALNODEHBNN)
	{
	}

	protected override void Awake()
	{
	}

	public void AddHandColliders(PlayerHandCollider[] AFKJEBPKILM)
	{
	}

	private void JBINIGKJKNF(PlayerHandCollider IMFMONDJMCH)
	{
	}

	private void CHPCCLCLAMM(PlayerHandCollider IMFMONDJMCH)
	{
	}

	public void RemoveHandColliders(PlayerHandCollider[] AFKJEBPKILM)
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void LateUpdate()
	{
	}

	private Vector3 HBKCLPFILBB(Vector3 CDCEFBJHIAN, Vector3 ONCLMGDKJDF, Quaternion KCFJAJOJBBG)
	{
		return default;
	}

	private bool ALLAEINLPPK(Collider ADMCDJKKCIA)
	{
		return false;
	}

	private void Update()
	{
	}

	private void GIAOFJPEPHF()
	{
	}

	private void HIOMGOBCKBM()
	{
	}

	private void EADOJBHGPBL()
	{
	}

	public LMFLCFFHNOF GetHoveredInteractable(out bool PKGLOHCOLHB, out float JLEBGJLFHLC)
	{
		PKGLOHCOLHB = default;
		JLEBGJLFHLC = default;
		return null;
	}

	public void SetHoveredInteractable(LMFLCFFHNOF PCNPMPMHGHF, bool PKGLOHCOLHB)
	{
	}

	public void ClearHoveredInteractable()
	{
	}

	public void QueueInteractionWithInteractable(LMFLCFFHNOF PCNPMPMHGHF, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN)
	{
	}

	public KAHFBNFFHGG GetCurrentQueuedInteractionState(LMFLCFFHNOF JJMMFGFIIMJ, PIHMPBGNBHB IFEOGBCJEBI, bool DPHMEPFJAGM)
	{
		return KAHFBNFFHGG.NotInteracting;
	}

	public void ClearQueuedInteraction(bool EGLOMEGHIGK)
	{
	}

	public float GetQueuedInteractionProgress()
	{
		return 0f;
	}

	public bool TryPickupTool(Tool IEGMBEPJMGC, bool PKGLOHCOLHB, bool LAHAOOBPBID = false)
	{
		return false;
	}

	public bool TrySwapTool(Tool IEGMBEPJMGC, bool PKGLOHCOLHB, bool LAHAOOBPBID, BCPOPPHNIMF CDBHBJEBFDL = BCPOPPHNIMF.Smart)
	{
		return false;
	}

	public void LocalLockHeldTool()
	{
	}

	public bool LocalUnlockHeldTool(bool IPGPHMBEMAM = false)
	{
		return false;
	}

	public void LocalLockHeldToolOnRespawn(bool OAGEINLKKMB)
	{
	}

	private void KAJCGCMEILF(Tool IEGMBEPJMGC, bool KIPCMECPDCD, bool IEPKMBGDMCN, bool LAHAOOBPBID, out Vector3 NPJKCFKEFAG, out Quaternion LKIBHMIIOIC)
	{
		NPJKCFKEFAG = default;
		LKIBHMIIOIC = default;
	}

	public bool TryReleaseTool(Vector3 LGJCOFNEBOA, Vector3 PGKKBDOKBHK, Tool.AMDKBHIGCGF LBMIBCKALKJ = Tool.AMDKBHIGCGF.Unknown)
	{
		return false;
	}

	public void ResetGravityPickupParameters()
	{
	}

	private void LEEFALIDDHP(bool MJECMKNMBEF, bool PKGLOHCOLHB)
	{
	}

	private void DHFMMNIGGCO()
	{
	}

	public void AddHeldToolUseRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveHeldToolUseRestriction(object IALNODEHBNN)
	{
	}

	public void AddInteractableRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveInteractableRestriction(object IALNODEHBNN)
	{
	}

	public void AddToolManualPickupRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveToolManualPickupRestriction(object IALNODEHBNN)
	{
	}

	public void AddManualToolDropRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveManualToolDropRestriction(object IALNODEHBNN)
	{
	}

	public void AddPointAtWorldUIRestriction(object IALNODEHBNN)
	{
	}

	public void RemovePointAtWorldUIRestriction(object IALNODEHBNN)
	{
	}

	public void AddLaserButtonPropsRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveLaserButtonPropsRestriction(object IALNODEHBNN)
	{
	}

	public void AddBehaviorRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveBehaviorRestriction(object IALNODEHBNN)
	{
	}

	public void AddIntersectingUIRegion(object AKMHLIMHNEK, bool KFDLGPMACLN = false)
	{
	}

	public void RemoveIntersectingUIRegion(object AKMHLIMHNEK, bool KFDLGPMACLN = false)
	{
	}

	public void UpdateMenuLaser(UIInputModule.GJFEIPEOFAK CDNLFEOBNKB, bool LBDAEPILOFM, bool GNCKIAEEHLH, bool GPKFJMEIBHN)
	{
	}

	public GestureTarget FindGestureTarget(Ray HAAAJDJGEFF, float KHJLILGGADK, out Vector3 OAMILMKJELF, float GKJHODLJDHD = 40f)
	{
		OAMILMKJELF = default;
		return null;
	}

	public void UpdateGestureLaser(bool ICMGDMLINGL)
	{
	}

	public void AddProneCrawlAnimationPreference(object IALNODEHBNN)
	{
	}

	public void RemoveProneCrawlAnimationPreference(object IALNODEHBNN)
	{
	}

	public void ToggleClimbableWallHighlight(bool GHNHDFGBJPC)
	{
	}

	private void GMKONMHMEPA(Tool IEGMBEPJMGC)
	{
	}

	private void KLFFLKILPOB()
	{
	}

	private void MBBLCAHADON()
	{
	}

	public void DisableCollisionForThrowRelease(Tool IEGMBEPJMGC, bool HHLOKJCPCPK)
	{
	}

	public void AddCollisionDisabled(object IALNODEHBNN)
	{
	}

	public void RemoveCollisionDisabled(object IALNODEHBNN)
	{
	}

	private void AGBDHBLGDHA()
	{
	}

	public bool IsInteractionTriggeringCollider(Collider HFPHBCLGAMC)
	{
		return false;
	}

	public void Vibrate(int HIJKHPMDNMK = 1, float DOEJGDJILAD = 1f)
	{
	}

	public void RequestHandVibrate(CHILKDJABBF EKOFNPFCLMO, short FGBPJMKCMAO, float DOEJGDJILAD)
	{
	}

	[PBOMGCLBFHF]
	private void RpcHandVibrate(short FGBPJMKCMAO, float DOEJGDJILAD)
	{
	}

	public void AddGestureToken(object IALNODEHBNN, GHCICEFBOGM GBNJJMNDNAA, CJJEEOGMEAB LAGADKBKLAD)
	{
	}

	public void RemoveGestureToken(object IALNODEHBNN)
	{
	}

	public void SetGesture(GHCICEFBOGM GBNJJMNDNAA)
	{
	}

	public void ClearGesture()
	{
	}

	public void StartRunningGesture()
	{
	}

	public void StopRunningGesture()
	{
	}

	public void RespondToPlayerGesture(Player CBDPEOAABOH)
	{
	}

	private void NHGHCBGILLD(PlayerHand PLCMNAMENCJ)
	{
	}

	[PBOMGCLBFHF]
	private void RPCPlayerRespondedToGesture(int NMIGHAMFAJE)
	{
	}

	public static void ConnectHandshake(PlayerHand BLFKABPCHLN, PlayerHand NPFMAENOPCH)
	{
	}

	public static void BreakHandshake(PlayerHand BLFKABPCHLN, PlayerHand NPFMAENOPCH)
	{
	}

	public static void ConnectCollisionGesture(PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, PlayerHand BLFKABPCHLN, PlayerHand NPFMAENOPCH)
	{
	}

	public static void BreakCollisionGesture(PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, PlayerHand BLFKABPCHLN, PlayerHand NPFMAENOPCH)
	{
	}

	public static void ConnectNonPlayerGesture(PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, PlayerHand PMNLJGLDMJN, NonPlayerGestureTarget GFCPAMJILIO)
	{
	}

	public static void BreakNonPlayerGesture(PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, PlayerHand PMNLJGLDMJN, NonPlayerGestureTarget GFCPAMJILIO)
	{
	}

	private static void GAKIKJEGNNF(PlayerHand PHDEFCGOFCO, PlayerHand KMABFIICKHL, out PlayerHand LALEGMNHADF, out PlayerHand KDLBBNBPDIH)
	{
		LALEGMNHADF = null;
		KDLBBNBPDIH = null;
	}

	public void OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
	{
	}

	private void OnDrawGizmos()
	{
	}

	public static PlayerHand Find(int CHMFPFHLENB)
	{
		return null;
	}

	public static void GetHandTransformBasedOnTool(Vector3 GLIFFGKMDKN, Quaternion CDNABPNAHGK, Vector3 KAGAOPMKPAB, Quaternion BHCPCPFHHEA, out Vector3 KLCDCMHPFFF, out Quaternion OIJHJMDDEIH)
	{
		KLCDCMHPFFF = default;
		OIJHJMDDEIH = default;
	}

	public void UpdateHandPlacement(PlayerHeightConfig PBAGNPAIIDE, BICMBDLFAPG DBLJELPOHAC)
	{
	}

	private Vector3 GOIMKNMMPOH(PlayerHeightConfig OPLDCMKEOEO, Vector3 INKGHPCDMCG)
	{
		return default;
	}

	private void OnTransformParentChanged()
	{
	}

	[CompilerGenerated]
	private void GPHDKFENPLA()
	{
	}

	[CompilerGenerated]
	internal static bool KEAKAAKKKDN(PlayerHand OEHDLIALDDC, Vector3 INKGHPCDMCG)
	{
		return false;
	}
}
