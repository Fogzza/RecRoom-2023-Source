using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CodeStage.AntiCheat.ObscuredTypes;
using Photon.Pun;
using Photon.Voice.Unity;
using RecRoom;
using RecRoom.Audio;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Consumable;
using RecRoom.Core;
using RecRoom.Core.AvatarSkeleton;
using RecRoom.Core.Combat;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.Tags;
using RecRoom.Core.Locomotion;
using RecRoom.Networking;
using RecRoom.Players;
using RecRoom.Settings;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviourPun, IBINLLOMNPN, HNGAMKHHDOD, GFLPAFBGELM, BKPFMIKGFKP, PHCICIGDDPA
{
	[Flags]
	public enum DKJFPCIPGBD
	{
		None = 0,
		CreationObject_Invalid = 2,
		Tool_Attached = 4,
		Tool_Invisible = 8,
		Tool_RigidbodyAncestor = 0x10,
		Tool_HeldByOtherPlayer = 0x20,
		Tool_LockedByKey = 0x40,
		Tool_SomeoneElsesProperty = 0x80,
		Tool_CustomCondition = 0x100,
		Tool_NotGrabbable = 0x200,
		Tool_Frozen = 0x400,
		Tool_CannotBePickedUp = 0x800,
		Tool_CannotBeHolstered = 0x1000,
		Tool_PickupDisabled = 0x2000,
		Player_CannotInteract = 0x4000,
		Player_LacksEquipRolePermission = 0x8000,
		Player_LacksHolsterRolePermission = 0x10000,
		Hand_Restricted = 0x20000,
		Hand_Full = 0x40000,
		Slot_Full = 0x80000,
		Max = Slot_Full
	}

	public enum NBPIPAJOGLC
	{
		None = -1,
		Head = 0,
		Torso = 1,
		LeftHand = 2,
		RightHand = 3,
		Mouth = 4,
		Legs = 5,
		LeftFoot = 6,
		RightFoot = 7
	}

	[Flags]
	public enum JLLGKBEJLOF
	{
		None = 0,
		Head = 1,
		Torso = 2,
		LeftHand = 4,
		RightHand = 8,
		Mouth = 0x10,
		Legs = 0x20,
		LeftFoot = 0x40,
		RightFoot = 0x80
	}

	[Flags]
	public enum BMHJDGKCMBJ
	{
		NONE = 0,
		RELATIONSHIP_MUTE = 1,
		VOICE_TYPE_MUTE = 2,
		GESTURE_MUTE = 4,
		PTT_MUTE = 8,
		AFK_MUTE = 0x10,
		MUTED_BY_ROOM_ROLE = 0x20,
		EXPRESSO_MUTE = 0x40,
		MUTED_BY_ROLLOFF = 0x80,
		AUTO_MUTED_FOR_SPAM = 0x100,
		VOICES_I_CAN_HEAR_MUTE = 0x200,
		GAME_BACKGROUNDED_MUTE = 0x400,
		PLATFORM_RESTRICTIONS_LOCAL = 0x800,
		PLATFORM_RESTRICTIONS_REMOTE = 0x1000,
		SCRIPTED_RESTRICTION = 0x2000,
		BANNED_VOICE_CHAT = 0x4000,
		SPEECH_TO_TEXT_ENABLED = 0x8000
	}

	public delegate void DJMAONAGPDM(Player EKOFNPFCLMO, AMBBOEBJPNH MOCEBLJHGPF, AMBBOEBJPNH ELOPMNNDIJD);

	private sealed class APGKIIGDGCP
	{
		public DHJLEHBOGBG creationObject;

		public Player _003C_003E4__this;

		internal void _003CArrangeObjectToBeEquipped_003Eb__1()
		{
		}

		internal void _003CArrangeObjectToBeEquipped_003Eb__2()
		{
		}

		internal void _003CArrangeObjectToBeEquipped_003Eb__3()
		{
		}
	}

	private sealed class MEDBPOJCOHJ
	{
		public PlayerHand cacheHand;

		internal void _003CArrangeHandForPickingUpObject_003Eb__1()
		{
		}
	}

	private sealed class LGEAHJMEDLK
	{
		public PlayerToolEquipSlot cacheToolSlot;

		internal void _003CArrangeSlotForEquippingTool_003Eb__1()
		{
		}
	}

	private sealed class KLBBKLHPPIN
	{
		public Tool tool;

		internal bool _003CRpcAuthorityCV2UnequipObject_003Eb__0(PlayerToolEquipSlot s)
		{
			return false;
		}
	}

	private sealed class GNOEEFGOOEL : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Player _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public GNOEEFGOOEL(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class BLLNCFJFFPO
	{
		public Player _003C_003E4__this;

		public bool blockedByPlatform;

		public bool mutedByPlatform;

		public bool blockedByRelationship;

		public bool mutedByRelationship;

		internal void _003CRefreshRelationship_003Eb__0(PlatformManager.BMNBAINOBHA restricted)
		{
		}
	}

	private sealed class CJAGDEDBBEG
	{
		public int friendId;

		internal void _003COnFriendAdded_003Eb__0(DFDECAEJBIO friendAccount)
		{
		}
	}

	private sealed class KLMKKOEAFFF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public Player _003C_003E4__this;

		public bool restricted;

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
		public KLMKKOEAFFF(int _003C_003E1__state)
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

	private sealed class PDNKGAAMLNA
	{
		public Player _003C_003E4__this;

		public PlayerEventNotificationManager.MBALCKKOIKK currentEvent;

		internal void _003CProcessPlayerEventNotifications_003Eb__0(HGKINAOMNIF r)
		{
		}
	}

	private sealed class JJDGAOCAHDL : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Player _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public JJDGAOCAHDL(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class MBFNJCNOOOK
	{
		public DBECJLAIPEL joinSource;

		public Player _003C_003E4__this;

		public Action _003C_003E9__1;

		internal void _003CJoinPlayerEvent_003Eb__0(IMIJPHJKLIM playerEvent)
		{
		}

		internal void _003CJoinPlayerEvent_003Eb__1()
		{
		}
	}

	private sealed class EOPKLKAPPCN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DBECJLAIPEL joinSource;

		public Player _003C_003E4__this;

		public long playerEventId;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public EOPKLKAPPCN(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class EOEIMFGFJFO
	{
		public float startTime;

		internal bool _003CWaitForCameraFadeCoroutine_003Eb__0()
		{
			return false;
		}
	}

	private sealed class GJFOFLPAGGB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

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
		public GJFOFLPAGGB(int _003C_003E1__state)
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

	private sealed class KPEOLCDGKBP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public Player _003C_003E4__this;

		public bool dropTools;

		public bool suppressAnimation;

		public PhotonView parentPhotonView;

		public Vector3 parentRelativePosition;

		public Quaternion parentRelativeRotation;

		public SeatManagement seatToEnter;

		public bool preserveVelocity;

		public Tool leftHandSpawnTool;

		public string leftHandToolSkinId;

		public Tool rightHandSpawnTool;

		public string rightHandToolSkinId;

		public int[] equipSlotIds;

		public Tool[] equipSlotTools;

		public string[] equipSlotToolSkinIds;

		public bool requestGiftSpawn;

		private Vector3 _003ColdPhysicsVelocity_003E5__2;

		private bool _003CwasFlying_003E5__3;

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
		public KPEOLCDGKBP(int _003C_003E1__state)
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

	private sealed class INJFMBBILID : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public Player _003C_003E4__this;

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
		public INJFMBBILID(int _003C_003E1__state)
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

	private sealed class LNEPBIMDNJE
	{
		public GPLMEJAFFFO destination;

		public Player _003C_003E4__this;

		public string welcomeMatName;

		internal void _003CRpcLocalCV2GoToRoom_003Eb__0(LCEKCFEIEGJ room)
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct GNEAEMCMLAO : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

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

	public static Dictionary<DKJFPCIPGBD, Func<Player, DHJLEHBOGBG, string>> FailureReasonStrings;

	public const string PREFAB_NAME = "[Player]";

	private static global::HHOBPMOCKMJ<Player> FPBFGPEHIIH;

	private static global::HHOBPMOCKMJ<Player> MFBLDCIGEBJ;

	private static global::BPEPJJDICII<Player, bool> ODKAFAEKMOM;

	private static global::HHOBPMOCKMJ<Player> MHBMBALEGGB;

	private static global::KAJFMPHPBGO<Player, NBPIPAJOGLC, Player, NBPIPAJOGLC> OCKJNPMAMMO;

	private static global::HHOBPMOCKMJ<Killzone> GJKMJCIFGNF;

	private static List<PlayerCollider> EDANHJJLMDF;

	private const string GMOLBGHBMCA = "Player";

	private const float ALPPMAJNIHG = 10f;

	private JNKNMMDAHCF DHCLACKALOF;

	private readonly EEANDDJEMJC BDOONPJPEPD;

	private readonly EEANDDJEMJC BCIGEBHIGJP;

	private readonly EEANDDJEMJC KEKDOOENEKA;

	private readonly EEANDDJEMJC LNLGJMNKKDA;

	private bool KLKCHIOJECB;

	private int AFGPGEKAMJK;

	[SerializeField]
	private PlayerTrackingSpace trackingSpace;

	[SerializeField]
	private PlayerHead head;

	private Vector3 OONCDDKLBAB;

	[SerializeField]
	private PlayerBody body;

	[SerializeField]
	private PlayerHand leftHand;

	[SerializeField]
	private PlayerHand rightHand;

	[SerializeField]
	private GameObject[] hideInFirstPerson;

	[SerializeField]
	private Transform voiceObject;

	[SerializeField]
	private Texture2D defaultProfileImage;

	[SerializeField]
	private PlayerToolEquipSlots toolEquipSlots;

	[SerializeField]
	private string afkWarningMessageTitle;

	private string OPGKHMAMHCF;

	[SerializeField]
	private string afkIntroMessage;

	[SerializeField]
	public GameObject[] localPlayerOnlyObjects;

	[SerializeField]
	public GameObject[] remotePlayerOnlyObjects;

	[SerializeField]
	private AnimateInOut animateInOut;

	[SerializeField]
	private UGCPlayerAudioManagement ugcPlayerAudioManagement;

	[SerializeField]
	private PlayerAudio playerAudio;

	[SerializeField]
	private PlayerAvatar playerAvatar;

	[SerializeField]
	private PlayerUI playerUI;

	[SerializeField]
	private PlayerNameTag playerNameTag;

	[SerializeField]
	private PlayerParty playerParty;

	[SerializeField]
	private PlayerModeration playerModeration;

	[SerializeField]
	private PlayerObjectiveTracker dailiesObjectiveTracker;

	[SerializeField]
	private PlayerProgression playerProgression;

	[SerializeField]
	private PlayerEmotes playerEmotes;

	[SerializeField]
	private PlayerEvents playerEvents;

	[SerializeField]
	private PlayerMovement playerMovement;

	[SerializeField]
	private PlayerMovementFeedback playerMovementFeedback;

	[SerializeField]
	private CustomKOConsumableEffect customKOEffect;

	[SerializeField]
	private PlayerBackpack backpack;

	[SerializeField]
	private PlayerVisibleInCamera visibleInCamera;

	[SerializeField]
	private TaggedPlayer taggedPlayer;

	[SerializeField]
	private PlayerInteractable playerInteractable;

	[SerializeField]
	private UGCProgression ugcProgression;

	[SerializeField]
	private PlayerChaperone playerChaperone;

	[SerializeField]
	private PlayerPersonalSpace playerPersonalSpace;

	[SerializeField]
	private Recorder voiceRecorder;

	[SerializeField]
	private Speaker voiceSpeaker;

	[SerializeField]
	private AgPhotonMicListener photonMicEvents;

	[SerializeField]
	private PlayerSynchronizedData synchedData;

	[SerializeField]
	protected AvatarSkeleton avatarSkeleton;

	[SerializeField]
	private AvatarUpdateLODSystem updateLODSystem;

	private float NMHDDGNHGNE;

	private float HPMLIHNIJGJ;

	private bool ADAKAFLDBJL;

	private PlayerHand[] HIHINEDMGCC;

	private PlayerHand JGCMGDFOFGE;

	private GameObject LBEGKBKLKLE;

	private PlayerHand.ICBKGDOJNDN GIEKKMKALBP;

	private IOMDCIACIMF HNIGDADPNAN;

	private readonly EEANDDJEMJC CDIKBCOEKNM;

	private NetworkCullingArea.NJEIMFKBBEG MCDPGOMMEDG;

	[NonSerialized]
	private Vector3 JLMFKEDOMNL;

	[NonSerialized]
	private Collider HEDHGOGLFKL;

	private float DAEOGDFDMOB;

	[SerializeField]
	private RespawnLoopDetector respawnLoopDetector;

	private bool GLBBHPGJPAI;

	private FIHGBEHGLGB PFNCAPPMLGE;

	private readonly EEANDDJEMJC GLMFKCMALPL;

	[NonSerialized]
	private IILJLGFHLGK CCFKEPHBDDL;

	[NonSerialized]
	private FIHGBEHGLGB FIMGJIKOAIJ;

	private readonly FIHGBEHGLGB PJFHGLFDDLG;

	private BMHJDGKCMBJ HMLBLAONHIP;

	public static DJMAONAGPDM OnDistanceBandChanged;

	private global::ADOKDOGIPIF<ONCCFHECNKK> OGBAFCGMNNE;

	private global::ADOKDOGIPIF<bool> INOCPKCJOHH;

	private global::MOBDJNEDDKC<bool> IJGMOAIOIIM;

	private IgnoreBufferSize ILIBMBEJABL;

	public ObscuredInt _playerId;

	public const string HARDWARE_TYPE_PROP = "HardwareType";

	public const string DEVICE_CLASS_PROP = "DeviceClass";

	public const string IS_APP_BACKGROUNDED_PROP = "IsBackgrounded";

	public const string NETWORK_REACHABILITY_PROP = "NetworkReachability";

	public const string IS_BROADCASTING_PROP = "IsBroadcasting";

	public const string HAS_REC_ROOM_PLUS_PROP = "HasRecRoomPlus";

	private const string PMLPGAFBOFG = "ControllerDisplayMode";

	private const float NLPFFIGDNGH = 4f;

	private const float CBCFKCICCHM = 20f;

	private const float GEEPCOBDFDB = 1f;

	private const float OCOBJCFEELD = 0.5f;

	private const float BBKOLOCJLDA = 0.1f;

	private global::ADOKDOGIPIF<NetworkReachability> BNHONONJGIJ;

	private global::ADOKDOGIPIF<bool> PENEAMCFHNA;

	private global::ADOKDOGIPIF<bool> GDBPDNAJBNK;

	private global::ADOKDOGIPIF<bool> FEHEPCKBMJK;

	private global::ADOKDOGIPIF<CILEIOOHEOB> LEDKBDCIJCA;

	private global::ADOKDOGIPIF<HBEFBLGGFMC> CLAHKAPFNBJ;

	private global::ADOKDOGIPIF<MJLJBHNFNAP> KGDNEJMCFDH;

	private global::ADOKDOGIPIF<MPKEDKHLCLJ> IPECBAGGDJI;

	private global::ADOKDOGIPIF<bool> CLDGHHHFDDO;

	private AudioSource MFIIKOEDIGC;

	private NCIMIGIHJDN NAICCNHHLHK;

	private NCIMIGIHJDN EAMEGKOAEKA;

	private global::MKJNCDLHHNA<bool> DEJAAPEMMOE;

	private global::MKJNCDLHHNA<bool> KGHNLBJOFFL;

	private bool PHBIHODBCCG;

	private global::ADOKDOGIPIF<NOMDJBMGHMJ> PNADPGNIAOI;

	private global::ADOKDOGIPIF<int> MCPNBHFGCMP;

	private Animator NFDIHCEOKHG;

	private Renderer BHBBLOFPEMC;

	private Animator KODOKPDPEML;

	private Renderer HJLOGMPAGDF;

	private Renderer IKFCDLBLPKC;

	private EOKKPHLOBBD JMHEMHFGKNA;

	private global::AFHOAHNAMGF<string> CPALPELKLGP;

	private global::AFHOAHNAMGF<string> IIPFGANJILF;

	private Stack<float> LEFGNNFHMGN;

	private Stack<float> OIEEJCKDJPN;

	private bool IJFHJPDKHCG;

	private global::ADOKDOGIPIF<bool> HGMJFFFLBDA;

	private int LCKKIGLMEGL;

	private float NBFGCILDDPL;

	private float GHLKNMAAPKK;

	private FIHGBEHGLGB LCLDDDBMFFN;

	private FIHGBEHGLGB IPIOPBKPKGA;

	private List<Tool> JEBDLKMDALE;

	private Vector3 PPAAKGMCIDB;

	private Quaternion HMMCFBCBJEL;

	[SerializeField]
	private PlayerLogicComponent _playerLogicComponent;

	public readonly EEANDDJEMJC DisplayAsBlockedChanged;

	private bool ILCBNCAMBBN;

	public readonly EEANDDJEMJC OnVisibilityChangedEvent;

	private readonly FIHGBEHGLGB OHAFCMIDJLK;

	private float NLCFOGOIEGE;

	private bool FMBNJBJEABC;

	private float AJDHFDMGGFF;

	private global::MOBDJNEDDKC<float> LAFDLGKGDII;

public static LHMPPJKHCJG PlayerProvider
{
get 	{
		return null;
	}

}

public static global::HHOBPMOCKMJ<Player> PlayerCreatedEvent
{
get 	{
		return null;
	}

set {
	}
}

public static global::HHOBPMOCKMJ<Player> PlayerDestroyedEvent
{
get 	{
		return null;
	}

set {
	}
}

public static global::BPEPJJDICII<Player, bool> PlayerSpawnEvent
{
get 	{
		return null;
	}

set {
	}
}

public static global::HHOBPMOCKMJ<Player> LocalPlayerDestroyedEvent
{
get 	{
		return null;
	}

set {
	}
}

public static global::KAJFMPHPBGO<Player, NBPIPAJOGLC, Player, NBPIPAJOGLC> PlayerCollidedWithOtherPlayerEvent
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC LocalPlayerSpawnEvent
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC LocalPlayerDespawnEvent
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC LocalPlayerFadedInAfterSpawnEvent
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC LocalPlayerCreatedEvent
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC LocalPlayerUpdatedValidGroundPosition
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC LocalPlayerSelfScalingChanged
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC LocalPlayerAvatarSkeletonIsEnabledChanged
{
get 	{
		return null;
	}

set {
	}
}

public static EEANDDJEMJC PreLoadSceneAssetsEvent
{
get 	{
		return null;
	}

set {
	}
}

public static global::HHOBPMOCKMJ<Killzone> LocalPlayerEnteredKillzoneEvent
{
get 	{
		return null;
	}

set {
	}
}

public static Player LocalPlayer
{
get 	{
		return null;
	}

}

public static bool LocalPlayerExists
{
get 	{
		return false;
	}

}

public static bool LocalPlayerCanOpenWatchUI
{
get 	{
		return false;
	}

}

public static bool LocalPlayerWatchUIAllElementsRestricted
{
get 	{
		return false;
	}

}

public static bool LocalPlayerIsSpawnedAndNotFading
{
get 	{
		return false;
	}

}

public EEANDDJEMJC DisablePersonalBubbleForFriendsChangedEvent
{
get 	{
		return null;
	}

}

public EEANDDJEMJC BroadcastingStateChanged
{
get 	{
		return null;
	}

}

public EEANDDJEMJC RecRoomPlusStateChanged
{
get 	{
		return this.KEKDOOENEKA;
	}

}

public EEANDDJEMJC DeveloperDisplayChanged
{
get 	{
		return this.LNLGJMNKKDA;
	}

}

public int PlayerIndex
{
get 	{
		return 0;
	}

}

public static float RespawnDuration
{
get 	{
		return 0f;
	}

}

public static float DespawnDuration
{
get 	{
		return 0f;
	}

}

public static float SpawnDuration
{
get 	{
		return 0f;
	}

}

public AvatarSkeleton AvatarSkeleton
{
get 	{
		return this.avatarSkeleton;
	}

}

public bool IsRespawning
{
get 	{
		return this.ADAKAFLDBJL;
	}

private set {
		this.ADAKAFLDBJL = value;
	}
}

public PlayerBackpack Backpack
{
get 	{
		return this.backpack;
	}

}

public UGCPlayerAudioManagement UGCPlayerAudioManagement
{
get 	{
		return this.ugcPlayerAudioManagement;
	}

}

public PlayerAudio PlayerAudio
{
get 	{
		return this.playerAudio;
	}

}

public PlayerAvatar PlayerAvatar
{
get 	{
		return this.playerAvatar;
	}

}

public bool UsesFullBodyAvatar
{
get 	{
		return false;
	}

}

public PlayerUI PlayerUI
{
get 	{
		return null;
	}

}

public PlayerNameTag PlayerNameTag
{
get 	{
		return this.playerNameTag;
	}

}

public PlayerParty PlayerParty
{
get 	{
		return null;
	}

}

public bool IsInParty
{
get 	{
		return false;
	}

}

public PlayerModeration PlayerModeration
{
get 	{
		return this.playerModeration;
	}

}

public PlayerChaperone PlayerChaperone
{
get 	{
		return this.playerChaperone;
	}

}

public PlayerPersonalSpace PlayerPersonalSpace
{
get 	{
		return this.playerPersonalSpace;
	}

}

public PlayerObjectiveTracker DailiesObjectiveTracker
{
get 	{
		return this.dailiesObjectiveTracker;
	}

}

public PlayerProgression PlayerProgression
{
get 	{
		return this.playerProgression;
	}

}

public PlayerEmotes EmotesManager
{
get 	{
		return this.playerEmotes;
	}

}

public PlayerMovement PlayerMovement
{
get 	{
		return this.playerMovement;
	}

}

public PlayerMovementFeedback PlayerMovementFeedback
{
get 	{
		return this.playerMovementFeedback;
	}

}

public Recorder PhotonVoiceRecorder
{
get 	{
		return this.voiceRecorder;
	}

}

public AgPhotonMicListener PhotonMicListener
{
get 	{
		return this.photonMicEvents;
	}

}

public PlayerVisibleInCamera VisibleInCamera
{
get 	{
		return this.visibleInCamera;
	}

}

public TaggedEntity TaggedEntity
{
get 	{
		return null;
	}

}

public PlayerInteractable PlayerInteractable
{
get 	{
		return this.playerInteractable;
	}

}

public UGCProgression UGCProgression
{
get 	{
		return this.ugcProgression;
	}

}

public PlayerSynchronizedData SynchedData
{
get 	{
		return this.synchedData;
	}

}

public CustomKOConsumableEffect CustomKOEffect
{
get 	{
		return this.customKOEffect;
	}

}

public PlayerEvents PlayerEvents
{
get 	{
		return null;
	}

}

public AnimateInOut AnimateInOut
{
get 	{
		return this.animateInOut;
	}

}

public PlayerHead Head
{
get 	{
		return this.head;
	}

}

public PlayerBody Body
{
get 	{
		return this.body;
	}

}

public Vector3 CurrentHeadPosition
{
get 	{
		return default;
	}

}

public PlayerHand LeftHand
{
get 	{
		return this.leftHand;
	}

}

public PlayerHand RightHand
{
get 	{
		return this.rightHand;
	}

}

public PlayerToolEquipSlots ToolEquipSlots
{
get 	{
		return this.toolEquipSlots;
	}

}

public Texture2D DefaultProfileImage
{
get 	{
		return this.defaultProfileImage;
	}

}

public IReadOnlyList<PlayerHand> BothHands
{
get 	{
		return null;
	}

}

public PlayerHand DominantHand
{
get 	{
		return this.JGCMGDFOFGE;
	}

private set {
	}
}

public PlayerHand OffHand
{
get 	{
		return null;
	}

}

public Vector3 CurrentFloorPosition
{
get 	{
		return default;
	}

}

public Quaternion CurrentTrackingSpaceRotation
{
get 	{
		return default;
	}

}

public PlayerTrackingSpace TrackingSpace
{
get 	{
		return this.trackingSpace;
	}

}

public float CurrentFloorHeightFromHead
{
get 	{
		return 0f;
	}

}

public GameObject Root
{
get 	{
		return this.LBEGKBKLKLE;
	}

private set {
	}
}

public PlayerHand.ICBKGDOJNDN FixedDominantHandType
{
get 	{
		return PlayerHand.ICBKGDOJNDN.Left;
	}

set {
	}
}

public IOMDCIACIMF BoardedVehicle
{
get 	{
		return null;
	}

set {
	}
}

public EEANDDJEMJC BoardedVehicleChanged
{
get 	{
		return null;
	}

}

public bool IsInVehicle
{
get 	{
		return false;
	}

}

public Tool[] AllToolsHeld
{
get 	{
		return null;
	}

}

public Tool[] AllToolsOnPlayer
{
get 	{
		return null;
	}

}

public NetworkCullingArea.NJEIMFKBBEG EditorInterestRegion
{
get 	{
		return NetworkCullingArea.NJEIMFKBBEG.Global;
	}

set {
	}
}

public bool IsInHighInterestRegion
{
get 	{
		return false;
	}

set {
	}
}

public bool IsUsingNetworkCulling
{
set {
	}
}

public Vector3 LastLocalPlayerValidGroundPosition
{
get 	{
		return default;
	}

set {
	}
}

public Collider LastLocalPlayerValidGroundCollider
{
get 	{
		return this.HEDHGOGLFKL;
	}

set {
	}
}

public bool CanBeGestureTarget
{
get 	{
		return false;
	}

}

public EEANDDJEMJC CurrentSocialModeDancePoseSetSelectedEvent
{
get 	{
		return null;
	}

}

public IILJLGFHLGK CurrentSocialModeDancePoseSet
{
get 	{
		return IILJLGFHLGK.CELEBRATE;
	}

set {
	}
}

public bool IsMuted
{
get 	{
		return false;
	}

}

public bool IsTalking
{
get 	{
		return false;
	}

}

public float AudioMaxForFrame
{
get 	{
		return 0f;
	}

}

private bool JBNHJJDOCKN
{
get 	{
		return false;
	}

}

public ONCCFHECNKK IgnoreBuffer
{
get 	{
		return ONCCFHECNKK.Disabled;
	}

set {
	}
}

public bool IsFriend
{
get 	{
		return false;
	}

}

public bool DisablePersonalBubbleForFriends
{
get 	{
		return false;
	}

set {
	}
}

public bool IsSelfScaling
{
get 	{
		return false;
	}

set {
	}
}

public IgnoreBufferSize IgnoreBufferSize
{
get 	{
		return default;
	}

private set {
	}
}

public string PlayerName
{
get 	{
		return null;
	}

}

public JDCIJIEOFOL NetworkedPlayer
{
get 	{
		return null;
	}

}

public CHILKDJABBF PhotonPlayer
{
get 	{
		return null;
	}

}

public int PlayerAccountId
{
get 	{
		return 0;
	}

}

public int PlayerId
{
get 	{
		return 0;
	}

private set {
	}
}

public NetworkReachability NetworkReachability
{
get 	{
		return NetworkReachability.NotReachable;
	}

set {
	}
}

public bool IsGameBackgrounded
{
get 	{
		return false;
	}

}

public bool IsBroadcasting
{
get 	{
		return false;
	}

set {
	}
}

public bool HasVisibleRecRoomPlus
{
get 	{
		return false;
	}

set {
	}
}

public CILEIOOHEOB HardwareType
{
get 	{
		return CILEIOOHEOB.Desktop_Valve;
	}

}

public HBEFBLGGFMC RecNetDeviceClass
{
get 	{
		return HBEFBLGGFMC.Unknown;
	}

}

public MJLJBHNFNAP ControllerDisplayMode
{
get 	{
		return MJLJBHNFNAP.UNINITIALIZED;
	}

set {
	}
}

public MPKEDKHLCLJ DeveloperDisplayMode
{
get 	{
		return MPKEDKHLCLJ.None;
	}

set {
	}
}

public bool IsJunior
{
get 	{
		return false;
	}

set {
	}
}

private AudioSource OBIMHADKAPD
{
get 	{
		return null;
	}

set {
	}
}

public bool IsInitialized
{
get 	{
		return false;
	}

private set {
		this.PHBIHODBCCG = value;
	}
}

public NOMDJBMGHMJ VOIPFilter
{
get 	{
		return NOMDJBMGHMJ.LowPitch;
	}

set {
	}
}

public bool IsRecNetBot
{
get 	{
		return false;
	}

}

public int Ping
{
get 	{
		return 0;
	}

private set {
	}
}

public string RichPresence
{
get 	{
		return null;
	}

}

public string LocalPlayerStatus
{
get 	{
		return null;
	}

}

private float JPCBPPMJLNM
{
get 	{
		return 0f;
	}

}

private float LMDICMLAHOO
{
get 	{
		return 0f;
	}

}

private bool MFLGAFAKDGP
{
get 	{
		return this.IJFHJPDKHCG;
	}

set {
	}
}

public bool IsVoiceChatRestricted
{
get 	{
		return false;
	}

}

public bool UserIsPresent
{
get 	{
		return false;
	}

set {
	}
}

public bool CanInteractWithTools
{
get 	{
		return false;
	}

}

public bool CanInteractWithNonOwnedTools
{
get 	{
		return false;
	}

}

public List<Tool> AllToolsAttached
{
get 	{
		return null;
	}

}

public static float LocalPlayerSpawnInTime
{
get 	{
		return 0f;
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

public PlayerLogicComponent PlayerLogicComponent
{
get 	{
		return this._playerLogicComponent;
	}

}

public bool IsSpawning
{
get 	{
		return false;
	}

}

private bool PPCKJCAFPFE
{
get 	{
		return this.ILCBNCAMBBN;
	}

set {
	}
}

public bool IsVisible
{
get 	{
		return false;
	}

}

public bool DisplayAsBlocked
{
get 	{
		return false;
	}

}

public bool AvatarSkeletonIsEnabled
{
get 	{
		return false;
	}

set {
	}
}

public Vector3 TorsoForwardOverride
{
get 	{
		return default;
	}

}

public float TorsoForwardOverrideWeight
{
get 	{
		return 0f;
	}

}

public bool IsTorsoForwardOverridden
{
get 	{
		return false;
	}

}

public Vector3 PelvisAnchorPosition
{
get 	{
		return default;
	}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 	{
		return default;
	}

}

public float CostumeScale
{
get 	{
		return 0f;
	}

set {
	}
}

public float DesiredAvatarSkeletonTrackingSpaceScale
{
get 	{
		return 0f;
	}

}

private float IMNOBJLNJIC
{
get 	{
		return 0f;
	}

set {
	}
}

	private DKJFPCIPGBD PBFANLFPCCH(DHJLEHBOGBG BPEGJLIMPPJ, PlayerHand PMNLJGLDMJN, bool LFFBNDCOJCN, bool LHJMPFEEBJF)
	{
		return DKJFPCIPGBD.None;
	}

	public DKJFPCIPGBD CanPlayerPickupObject(DHJLEHBOGBG BPEGJLIMPPJ, PlayerHand PMNLJGLDMJN, bool LFFBNDCOJCN, bool LHJMPFEEBJF)
	{
		return DKJFPCIPGBD.None;
	}

	public DKJFPCIPGBD CanPlayerHolsterObject(DHJLEHBOGBG BPEGJLIMPPJ, PlayerToolEquipSlot JMEEAMAPEDC, bool COPOILGLIAJ, bool LHJMPFEEBJF, bool GONLBBNBGEC)
	{
		return DKJFPCIPGBD.None;
	}

	[PBOMGCLBFHF]
	private void RpcAuthorityCV2EquipObject(Tool IEGMBEPJMGC, bool KHKGHIDGIFN, bool LFFBNDCOJCN, bool LHJMPFEEBJF)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2EquipObject(JEGAPHLGBJA GCBHEJANCJK, DHJLEHBOGBG BPEGJLIMPPJ, bool KHKGHIDGIFN, bool LFFBNDCOJCN, bool LHJMPFEEBJF, ref BGAFDAOKLIM LADBGPBNBHB)
	{
		return default;
	}

	private bool HEGJDEHGDCN(DHJLEHBOGBG BPEGJLIMPPJ, bool LHJMPFEEBJF, bool EANMCGJIANF, out Action OILBAAAPIAP)
	{
		OILBAAAPIAP = null;
		return false;
	}

	private bool EJAANLOCJIK(DHJLEHBOGBG BPEGJLIMPPJ, bool KHKGHIDGIFN, bool LFFBNDCOJCN, out PlayerHand PMNLJGLDMJN, out Action OHLLBEJKDCO)
	{
		PMNLJGLDMJN = null;
		OHLLBEJKDCO = null;
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcAuthorityCV2HolsterObject(Tool IEGMBEPJMGC, bool LFFBNDCOJCN, bool LHJMPFEEBJF, bool OJEINJGPKHM, EAJPDHFNCOB HHOGFBCFGAB)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2HolsterObject(JEGAPHLGBJA GCBHEJANCJK, DHJLEHBOGBG BPEGJLIMPPJ, bool LFFBNDCOJCN, bool LHJMPFEEBJF, bool OJEINJGPKHM, EAJPDHFNCOB HHOGFBCFGAB, ref BGAFDAOKLIM LADBGPBNBHB)
	{
		return default;
	}

	private bool GCCEICDLAKL(Tool IEGMBEPJMGC, bool ILFKAPMMBGF, bool GONLBBNBGEC, ref PlayerToolEquipSlot GAIBCOOKNMD, out Action CKCFKDPCEMK)
	{
		CKCFKDPCEMK = null;
		return false;
	}

	[PBOMGCLBFHF]
	private void RpcAuthorityCV2UnequipObject(Tool IEGMBEPJMGC)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2UnequipObject(JEGAPHLGBJA GCBHEJANCJK, DHJLEHBOGBG BPEGJLIMPPJ, ref BGAFDAOKLIM LADBGPBNBHB)
	{
		return default;
	}

	[PBOMGCLBFHF]
	private void RpcAuthorityCV2UnequipSlots(bool KHKGHIDGIFN, bool AOBDJCJLKOL, bool GLEACFKMLMG, bool HCFFMGAEEEB, bool EIJMBBKMEFB)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2UnequipSlots(JEGAPHLGBJA GCBHEJANCJK, bool KHKGHIDGIFN, bool AOBDJCJLKOL, bool GLEACFKMLMG, bool HCFFMGAEEEB, bool EIJMBBKMEFB)
	{
		return default;
	}

	private void INEPLAFKIPF()
	{
	}

	public static AEGILPLHPKJ ConvertToAvatarBodyPart(NBPIPAJOGLC MKLOBAIKINA)
	{
		return AEGILPLHPKJ.Head;
	}

	public bool IsInVehicleOfType<T>() where T : class, IOMDCIACIMF
	{
		return false;
	}

	public void AddGestureTargetingRestriction(object IALNODEHBNN)
	{
	}

	public bool RemoveGestureTargetingRestriction(object IALNODEHBNN)
	{
		return false;
	}

	public bool SetMuteFlag(BMHJDGKCMBJ NCJCLJGCIMF, bool BFDBCMGIOBG = true)
	{
		return false;
	}

	private void IIGHAOFOLIP()
	{
	}

	public bool MutedBy(BMHJDGKCMBJ NCJCLJGCIMF)
	{
		return false;
	}

	public bool MutedOnlyBy(BMHJDGKCMBJ NCJCLJGCIMF)
	{
		return false;
	}

	private void DJFDAOOGECN()
	{
	}

	public static void SavePlayerMuted(int PCKCPNGPNBJ, bool FPNALMLOHHH)
	{
	}

	private void DEKLMPMBHBG()
	{
	}

	public static void SetSynchronizedHardwareInfo(CILEIOOHEOB DGOOEGDMPLP, HBEFBLGGFMC NGBLANOILDA)
	{
	}

	private void GLCIFLDAJAE()
	{
	}

	void PHCICIGDDPA.ALCBOOGGMHC()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GLCIFLDAJAE
		this.GLCIFLDAJAE();
	}

	private void LJEPIPPPFJL()
	{
	}

	protected override void Awake()
	{
	}

	private void JDOPPEDNGNG(float OKBAJEAPIHG)
	{
	}

	private void CNBKBBGBOCN()
	{
	}

	private void MNALMDDLONC(RigidbodyEx BJHLKOMIJEL)
	{
	}

	private IEnumerator Start()
	{
		return null;
	}

	private void BJGAMLLJGBH()
	{
	}

	private void BFFNNLKPIAH()
	{
	}

	private void BLIHKEPMHBH()
	{
	}

	private bool IBKIAMCNFEG()
	{
		return false;
	}

	private Transform DGGNDMEDEOO()
	{
		return null;
	}

	private void NPMKBOLHHCN(bool IJGHHBPBMGD)
	{
	}

	private void OnDisable()
	{
	}

	public static void RaisePlayerCollidedWithOtherPlayerEvent(Player EKOFNPFCLMO, NBPIPAJOGLC MKLOBAIKINA, Player PLNGHFIMCDB, NBPIPAJOGLC GFDCGAJJHML)
	{
	}

	private void NJMCOMBNPLN()
	{
	}

	private void CMOAMLKCGCN()
	{
	}

	private void IPLHCJDLGPG()
	{
	}

	private void MDGDGOKECJH()
	{
	}

	private void IDFOLOJILBM()
	{
	}

	private void LJOIALMAFBL()
	{
	}

	private void NKENJINLDDD()
	{
	}

	private void AJEBOOGBIOP()
	{
	}

	private void CDBBOHBGNNP(int? PCKCPNGPNBJ)
	{
	}

	private void JJANAHDFOOA()
	{
	}

	private void HFFNNMBLMOL(POPLPJGHHIA.IBLMGFBJMDI EGMCJKCDCNC)
	{
	}

	private void EFKCHFGJHAK()
	{
	}

	private void BLKJJBIOCEC()
	{
	}

	private void BGFPBKFHIDA(LMFLCFFHNOF PCNPMPMHGHF)
	{
	}

	private void LPKNKEOPMDG(LMFLCFFHNOF PCNPMPMHGHF)
	{
	}

	private void OIADLNJOBLM(LMFLCFFHNOF PCNPMPMHGHF)
	{
	}

	public void RefreshRelationship()
	{
	}

	public void OnFriendAdded(int OBCFBKKCBFH, ODCEOIGDCAH.AIFBEBFNDOK GLLFHCCFIGK)
	{
	}

	private IEnumerator<EGGPGCCKPCO> ALNKMCFKKEN(bool LAPONHMPGON)
	{
		return null;
	}

	private void DDJIEEPEKJL(float HJACHMCNGBL)
	{
	}

	public void SetParentPlayerRoot(Transform LEJMJKJGFLD)
	{
	}

	protected override void OnDestroy()
	{
	}

	protected void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void MHIAMJKBAOG()
	{
	}

	public void BroadcastFacialExpression(int MAFEEIEHLEI)
	{
	}

	[PBOMGCLBFHF]
	private void RpcSetFacialExpression(int MAFEEIEHLEI)
	{
	}

	[PBOMGCLBFHF]
	private void RpcCanPlatformCommunicate(bool LAPONHMPGON)
	{
	}

	private bool IEEGGPMAPKH(out Killzone FELFEGFKCCD)
	{
		FELFEGFKCCD = null;
		return false;
	}

	public void AddRichPresence(string JDMKLBCHDHJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveRichPresence(object IALNODEHBNN)
	{
	}

	public void AddLocalPlayerStatus(string JJGDPHEIOJB, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveLocalPlayerStatus(object IALNODEHBNN)
	{
	}

	public void PushAfkKickToIntroTimeout(float JHHEDLPJBLL)
	{
	}

	public void PopAfkKickToIntroTimeout()
	{
	}

	public void PushAfkWarningStartTimeout(float JHHEDLPJBLL)
	{
	}

	public void PopAfkWarningStartTimeout()
	{
	}

	public void SetPushToTalkActive(bool GNGKKJPOAPJ, object IALNODEHBNN)
	{
	}

	public void ActivatePushToTalk(object IALNODEHBNN)
	{
	}

	public void DeactivatePushToTalk(object IALNODEHBNN)
	{
	}

	private void CKGLOHIPOOM()
	{
	}

	private void GHMPAHIMIND(bool FBHDABEFLKL, bool MIOAKFMPLPI = true)
	{
	}

	public void SetLocalVoiceChatMode(DPDBLMENBLF KJIJAABOEKI)
	{
	}

	private void IOJEJAMEKNG()
	{
	}

	public void UpdateVoicesICanHear()
	{
	}

	public void AddVoiceChatRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveVoiceChatRestriction(object IALNODEHBNN)
	{
	}

	public void AddVoiceVolumeMultiplier(float COEPFINFOAM, object IALNODEHBNN)
	{
	}

	public void RemoveVoiceVolumeMultiplier(object IALNODEHBNN)
	{
	}

	private void DCAJPDMDLJE()
	{
	}

	public void AddVoiceSpatialBlendMultiplier(float GDBGAEFICHD, object IALNODEHBNN)
	{
	}

	public void RemoveVoiceSpatialBlendMultiplier(object IALNODEHBNN)
	{
	}

	private void LOMAEBODGDA()
	{
	}

	public void AddVoiceHighPassFilterEnabled(object IALNODEHBNN)
	{
	}

	public void RemoveVoiceHighPassFilterEnabled(object IALNODEHBNN)
	{
	}

	private void KCJPFKAGBDI()
	{
	}

	public void AddVoiceReverbFilterEnabled(object IALNODEHBNN)
	{
	}

	public void RemoveVoiceReverbFilterEnabled(object IALNODEHBNN)
	{
	}

	private void JDIDFGOLGAF()
	{
	}

	public void SetVoiceAudioRolloff(AudioRolloff GIKIKBPOJNI)
	{
	}

	public void SetVoiceFilter(NOMDJBMGHMJ HNGJGPJCNBJ)
	{
	}

	private void CNFMJEDLDGN()
	{
	}

	public void UpdateAFKStatus(bool JMKGIJLHBKI)
	{
	}

	public void ProcessPlayerEventNotifications()
	{
	}

	private IEnumerator NLFHDLKBACF()
	{
		return null;
	}

	private IEnumerator JFEGCLNCJPJ(long NJJFDENHGKK, DBECJLAIPEL KKJBHNGEBOD)
	{
		return null;
	}

	public T GetHeldToolComponent<T>() where T : MonoBehaviour
	{
		return null;
	}

	public void AddToolInteractionRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveToolInteractionRestriction(object IALNODEHBNN)
	{
	}

	public void AddNonOwnedToolInteractionRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveNonOwnedToolInteractionRestriction(object IALNODEHBNN)
	{
	}

	public void AddAttachedTool(Tool IPLOENKLJMA)
	{
	}

	public void RemoveAttachedTool(Tool IPLOENKLJMA)
	{
	}

	public void OnRecRoomSceneManagerDestroyed()
	{
	}

	public void ReleaseToolsFromBothHands()
	{
	}

	private bool LPCLEENKIFG(PlayerHand PMNLJGLDMJN)
	{
		return false;
	}

	public void ReleaseToolsFromAllEquipSlots()
	{
	}

	public bool TryDisarm(Tool IEGMBEPJMGC)
	{
		return false;
	}

	public PlayerHand GetHand(NBPIPAJOGLC MKLOBAIKINA)
	{
		return null;
	}

	public PlayerHand GetHand(PlayerHand.ICBKGDOJNDN IKHNIJKGJFD)
	{
		return null;
	}

	public PlayerHand GetHand(int IKHNIJKGJFD)
	{
		return null;
	}

	public PlayerHand GetOtherHand(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
	{
		return null;
	}

	private void HMIGLPHOLDG(PlayerHand PMNLJGLDMJN, Tool IEGMBEPJMGC)
	{
	}

	private void AGNJFMDLJNM()
	{
	}

	public LKGILLBEJEK Respawn(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool CDEPAJILBJA = true)
	{
		return null;
	}

	public LKGILLBEJEK Respawn(Vector3 DGJCABHFKEJ, Quaternion GFHLNIABLFP, PhotonView AIOFMEAOKIA, SeatManagement MNEMPOCLCOJ, bool CDEPAJILBJA = true, Tool BIJAGFKFCOP = null, string JDKGLCNMDIB = null, Tool FBJKKGGEBGC = null, string EMAILLAEEAB = null, int[] CBCHJMCEHOH = null, Tool[] FHAENFIMKBB = null, string[] IOIHLNGMHEN = null, bool MIHGKCBLLFJ = false, bool KBDPBKJKFGJ = false, bool LPKBKDOMDNB = false)
	{
		return null;
	}

	public void RespawnAtLastValidGroundPosition(bool CDEPAJILBJA)
	{
	}

	public LKGILLBEJEK SpawnLocal(float HJOLODPNIPI, bool MJGDPADJBEG, Vector3 FCNGMPHKHAE, bool LPKBKDOMDNB)
	{
		return null;
	}

	public LKGILLBEJEK DespawnLocal(bool CDEPAJILBJA, bool LPKBKDOMDNB, CameraFade.BAIBOJEOOGB CKHHGBNHHCK = CameraFade.BAIBOJEOOGB.Misc)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> AGFAEPHCBPP()
	{
		return null;
	}

	private void FOGHFCGGHHO(bool OAGEINLKKMB)
	{
	}

	public IEnumerator<EGGPGCCKPCO> RespawnLocal(Vector3 DGJCABHFKEJ, Quaternion GFHLNIABLFP, PhotonView AIOFMEAOKIA, SeatManagement MNEMPOCLCOJ, bool CDEPAJILBJA, Tool BIJAGFKFCOP, string OOEDCOKCDFC, Tool FBJKKGGEBGC, string LAODEIOOBGB, int[] CBCHJMCEHOH, Tool[] FHAENFIMKBB, string[] CHCEBDMAFIL, bool MIHGKCBLLFJ, bool KBDPBKJKFGJ, bool LPKBKDOMDNB)
	{
		return null;
	}

	private void LJKFELEBGIG(PlayerHand PMNLJGLDMJN, Tool LKMPNJODPOE, string AMGNCEMOBLK)
	{
	}

	private void APCMFJGBDDJ(int ODEEBNEMACB, Tool LKMPNJODPOE, string AMGNCEMOBLK)
	{
	}

	private void ALLJJFGNEMA(bool MJGDPADJBEG, Vector3 FCNGMPHKHAE)
	{
	}

	private IEnumerator<EGGPGCCKPCO> KEJPIJJAIKK()
	{
		return null;
	}

	[PBOMGCLBFHF]
	private void RpcBroadcastSpawnPlayer(bool MJGDPADJBEG, Vector3 FCNGMPHKHAE, bool LPKBKDOMDNB)
	{
	}

	[PBOMGCLBFHF]
	private void RpcBroadcastDespawnPlayer(bool LPKBKDOMDNB)
	{
	}

	private void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
	{
	}

	private void OnPhotonPlayerDisconnected(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	private void AFDHPIJIFFG()
	{
	}

	public bool IsOverValidGround(Vector3 INLGLHIPOMC, out Vector3 IPJDKLEDJDP, out Collider PMCCMKOANDG)
	{
		IPJDKLEDJDP = default;
		PMCCMKOANDG = null;
		return false;
	}

	private bool DHDCHJKIFDN(Collider ADMCDJKKCIA)
	{
		return false;
	}

	private void FOJOALFEPAA(bool CPIIOIOENNJ)
	{
	}

	public void SetDisplayAsBlocked(object IALNODEHBNN, bool CHEHHIMIPCJ)
	{
	}

	public static void SavePlayerIgnored(int PCKCPNGPNBJ, bool CHEHHIMIPCJ)
	{
	}

	public void SetHeadScale(float KBFGDHBNMLA)
	{
	}

	private void GHMCHEPOHAI()
	{
	}

	public void OnMicSpamStateChange(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
	{
	}

	public static Player FindClosest(Vector3 INLGLHIPOMC, bool AKJNMCNFJHK)
	{
		return null;
	}

	public static Player FindClosest(Vector3 INLGLHIPOMC, IEnumerable<CHILKDJABBF> IGFHADFNPPM)
	{
		return null;
	}

	public static Player GetFromActorNumber(int FJLMLOGLNGL)
	{
		return null;
	}

	public static Player GetFromAccountId(int PCKCPNGPNBJ, bool AKJNMCNFJHK)
	{
		return null;
	}

	public static Player GetFromViewId(int CHMFPFHLENB)
	{
		return null;
	}

	public static IEnumerable<Player> GetAllPlayers(bool BCPKMEPMHLE = false)
	{
		return null;
	}

	public static bool IsCloseToAnyPlayer(Vector3 INLGLHIPOMC, bool AKJNMCNFJHK)
	{
		return false;
	}

	public static bool IsCloseToAnyPlayer(Vector3 INLGLHIPOMC, float DAMOGGANOJL, bool AKJNMCNFJHK)
	{
		return false;
	}

	public static float DistanceSqrBetweenPlayers(Player BLFKABPCHLN, Player NPFMAENOPCH)
	{
		return 0f;
	}

	public static void CalculateTrackingSpacePositionToMakeTargetAppearBelowHead(Transform LJCHEFCPDAE, Transform CEJJKGMIIPA, Vector3 JPHJIFJCCMF, Vector3 LNMOOCBAAIM, Vector3 HACDFDCCGNF, out Vector3 AGGJDJHMGJM, out Quaternion HFIBFIDJIKE)
	{
		AGGJDJHMGJM = default;
		HFIBFIDJIKE = default;
	}

	public static void CalculateTrackingSpacePositionToMakeTargetAppearBelowHead(Player EKOFNPFCLMO, Vector3 JPHJIFJCCMF, Vector3 LNMOOCBAAIM, out Vector3 AGGJDJHMGJM, out Quaternion HFIBFIDJIKE)
	{
		AGGJDJHMGJM = default;
		HFIBFIDJIKE = default;
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
	private void RpcAuthorityCV2SetPosition(Vector3 INLGLHIPOMC)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetPosition(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC)
	{
		return default;
	}

	[PBOMGCLBFHF]
	private void RpcAuthorityCV2Respawn(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool KBDPBKJKFGJ, bool LPKBKDOMDNB)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Respawn(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, in bool KBDPBKJKFGJ, in bool LPKBKDOMDNB)
	{
		return default;
	}

	[PBOMGCLBFHF]
	private void RpcAuthorityCV2SetRotation(Quaternion HEGBBJCMANH)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetRotation(JEGAPHLGBJA GCBHEJANCJK, in Quaternion HEGBBJCMANH)
	{
		return default;
	}

	[PBOMGCLBFHF]
	private void RpcAuthorityCV2SetTransform(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetTransform(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH)
	{
		return default;
	}

	[PBOMGCLBFHF]
	private void RpcLocalCV2GoToRoom(string LBGBFPDNKOL, string GOLAFNFADNL, string OCLDAGFLIEO, KKAPOPJBDOA.PKCADEJAJPO.CLMOBELOGEP KHIJCFMFKHI, bool JDMCCJPEFCK)
	{
	}

	private int APAPKAJFNLJ(string IBALDFBGBGL)
	{
		return 0;
	}

	public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2GoToRoom(JEGAPHLGBJA GCBHEJANCJK, in GPLMEJAFFFO FMECHJDDNAF)
	{
		return default;
	}

	private void FAAHJPPLMAP()
	{
	}

	public void UpdateBody()
	{
	}

	private void JMIBLMCJPCB()
	{
	}

	public global::FAIKNKAIPLB<OHAJOLBEFND> Self(JEGAPHLGBJA GCBHEJANCJK)
	{
		return default;
	}

	private void CCPBODPIEJP()
	{
	}

	private void MHJNPEFJNEJ()
	{
	}

	public void ProjectileHitPlayerCV2Invoke(CHILKDJABBF EKMGJPMBLCP, RangedWeapon NBFEDFDFEIM, CHILKDJABBF KJCCPIIFNGO, int AAEAKJPHADF, int FDDPFMJOHLO, in Vector3 OGENEKOENLC, in Vector3 OMGOEKPFJCM)
	{
	}

	public void ExplosionHitPlayerCV2Invoke(ExplosionEmitter CMCPHKIMEML, CHILKDJABBF KJCCPIIFNGO, int AAEAKJPHADF, int FDDPFMJOHLO, in Vector3 OGENEKOENLC, in Vector3 OMGOEKPFJCM)
	{
	}

	public void PlayerGrabbedObjectCV2Invoke(DHJLEHBOGBG BMDDJIDADKN)
	{
	}

	private void JPMBEHJPAJO()
	{
	}

	private void POAHHGOHMLO()
	{
	}

	private void GECPNDNEAPO()
	{
	}

	private void OnTransformParentChanged()
	{
	}

	public AMBBOEBJPNH GetUpdateLOD()
	{
		return AMBBOEBJPNH.TwoPointFiveMeters;
	}

	public void SetAvatarLOD(int NGIOBOKPMPM)
	{
	}

	private global::FAIKNKAIPLB<MFEHAEMCKCJ> DPMLFCHKOEH(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE)
	{
		return default;
	}

	global::FAIKNKAIPLB<MFEHAEMCKCJ> IBINLLOMNPN.CV2AddImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE)
	{
		//ILSpy generated this explicit interface implementation from .override directive in DPMLFCHKOEH
		return this.DPMLFCHKOEH(GCBHEJANCJK, in GDBGENEPKJJ, JCOIPNJNGNL, MJJDNDIGKOE);
	}

	private global::FAIKNKAIPLB<MFEHAEMCKCJ> EOACMEOBFAN(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HLFIBIDOLEF, float DPIEOJGBCAN, float DMIPMFMPLAP, float MJJDNDIGKOE)
	{
		return default;
	}

	global::FAIKNKAIPLB<MFEHAEMCKCJ> IBINLLOMNPN.CV2ReflectImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HLFIBIDOLEF, float DPIEOJGBCAN, float DMIPMFMPLAP, float MJJDNDIGKOE)
	{
		//ILSpy generated this explicit interface implementation from .override directive in EOACMEOBFAN
		return this.EOACMEOBFAN(GCBHEJANCJK, in HLFIBIDOLEF, DPIEOJGBCAN, DMIPMFMPLAP, MJJDNDIGKOE);
	}

	private global::FAIKNKAIPLB<MFEHAEMCKCJ> JEJNKFEGAAL(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, in bool KBDPBKJKFGJ, in bool LPKBKDOMDNB)
	{
		return default;
	}

	global::FAIKNKAIPLB<MFEHAEMCKCJ> IBINLLOMNPN.CV2Respawn(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, in bool KBDPBKJKFGJ, in bool LPKBKDOMDNB)
	{
		//ILSpy generated this explicit interface implementation from .override directive in JEJNKFEGAAL
		return this.JEJNKFEGAAL(GCBHEJANCJK, in INLGLHIPOMC, in HEGBBJCMANH, in KBDPBKJKFGJ, in LPKBKDOMDNB);
	}

	private global::FAIKNKAIPLB<MFEHAEMCKCJ> KAMDGBJDBLO(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float BGDNNHOLJIH)
	{
		return default;
	}

	global::FAIKNKAIPLB<MFEHAEMCKCJ> IBINLLOMNPN.CV2SetImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float BGDNNHOLJIH)
	{
		//ILSpy generated this explicit interface implementation from .override directive in KAMDGBJDBLO
		return this.KAMDGBJDBLO(GCBHEJANCJK, in GDBGENEPKJJ, BGDNNHOLJIH);
	}

	private global::FAIKNKAIPLB<MFEHAEMCKCJ> GBMCEGJIJLI(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC)
	{
		return default;
	}

	global::FAIKNKAIPLB<MFEHAEMCKCJ> IBINLLOMNPN.CV2SetPosition(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GBMCEGJIJLI
		return this.GBMCEGJIJLI(GCBHEJANCJK, in INLGLHIPOMC);
	}

	private global::FAIKNKAIPLB<MFEHAEMCKCJ> OGMODEHCNJJ(JEGAPHLGBJA GCBHEJANCJK, in GPLMEJAFFFO FMECHJDDNAF)
	{
		return default;
	}

	global::FAIKNKAIPLB<MFEHAEMCKCJ> IBINLLOMNPN.CV2GoToRoom(JEGAPHLGBJA GCBHEJANCJK, in GPLMEJAFFFO FMECHJDDNAF)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OGMODEHCNJJ
		return this.OGMODEHCNJJ(GCBHEJANCJK, in FMECHJDDNAF);
	}

	[CompilerGenerated]
	internal static void BFONCNJMBLF(PlayerHand PMNLJGLDMJN)
	{
	}

	[CompilerGenerated]
	internal static void NCNEIGIKCEA(PlayerToolEquipSlot HHOGFBCFGAB)
	{
	}

	[CompilerGenerated]
	private void PABMACLOIEH()
	{
	}

	[CompilerGenerated]
	private void PPPKKGALEGP(DFDECAEJBIO ACBGBAAHOIM)
	{
	}

	[CompilerGenerated]
	private void KDIFHMACFDN()
	{
	}

	[CompilerGenerated]
	private void FNHCPECHMEO(DFDECAEJBIO ACBGBAAHOIM)
	{
	}

	[CompilerGenerated]
	private bool LFMIMPFJJNP()
	{
		return false;
	}

	[CompilerGenerated]
	internal static void NLEJDGEHDKG()
	{
	}

	[CompilerGenerated]
	private void BMPONJOJIKI()
	{
	}

	[CompilerGenerated]
	internal static Task DFIEOLIEKMB()
	{
		return null;
	}

	[CompilerGenerated]
	private bool IBHEEGKNPFP()
	{
		return false;
	}

	[CompilerGenerated]
	private void FPIIPAGPDHJ()
	{
	}

	[CompilerGenerated]
	internal static SessionManager.PFPFLMJDKIB NJGAGFJCBDN(KKAPOPJBDOA.PKCADEJAJPO.CLMOBELOGEP HLJNIHALEIP)
	{
		return SessionManager.PFPFLMJDKIB.None;
	}
}
