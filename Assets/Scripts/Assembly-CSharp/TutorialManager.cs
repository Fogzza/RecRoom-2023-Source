using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using RecRoom.Core.UI;
using RecRoom.Tutorials;
using RecRoom.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : SingletonMonoBehaviour<TutorialManager>
{
	public enum DCOLLEIEDOJ
	{
		TeleportButton = 0,
		SwipeButton = 1,
		GrabButton = 2,
		DropItemButton = 3,
		OpenWatch = 4,
		Laser = 5,
		Stop = 6,
		FistBump = 7,
		ShakeHands = 8,
		WalkButton = 9
	}

	public enum ACLOGGPNLDF
	{
		Great = 5,
		Perfect = 6,
		LookAtWristToViewWatch = 25,
		OpenWatch = 31,
		PleaseEnterYourBirthday = 43,
		Thanks = 44,
		RegisterNonJunior = 45,
		RegisterJunior = 46,
		Excellent = 47,
		VerifyAccount = 66,
		ThereAreTwoWaysToMove = 178,
		PickWhichWayYoudLikeToMove = 179,
		WeRecommendTeleport = 180,
		YouCanChangeBetweenWalkingAndTeleporting = 181,
		ExploreNUX_WelcomeToRecRoom = 190,
		ExploreNUX_ThisIsYourDormRoom = 191,
		ExploreNUX_FeelFreeToPlayAround = 192,
		WhatIsYourAge = 195,
		WhatDoYouWantYourNameToBe = 196,
		FeelFreeToPlayAround = 197,
		UseMirrorToCustomizeLook = 200,
		WelcomeToPaintball = 201,
		WhatWouldYouLikeYourPasswordToBe = 202,
		DoYouWantUsToConnectYou = 220,
		WeNeedMoreInfo = 221,
		LooksLikeYouKnowPlayers = 222,
		WellLetYouKnowWhenFriendsJoin = 223,
		CompleteChallengesToEarnRewards = 230,
		KeepCompletingChallengesToEarnRewards = 231,
		Mirror_FromTheMirror = 250,
		Mirror_LookingGood = 251,
		BulletinBoard_AtTheCommunityBoard = 300,
		Intro_WelcomeToRecRoom = 350,
		Intro_ThisIsYourDormRoom = 351,
		Watch_BeforeYouHeadOut = 400,
		Watch_ThisIsYourWatchMenu = 401,
		Watch_TryTappingPlay = 402,
		Watch_ExcellentRooms = 403
	}

	public enum LIHDGFHPCID
	{
		NotRan = 0,
		TutorialStart = 1,
		Registration = 2,
		ChooseVRPlayerType = 77,
		IosImportFriends = 78,
		ExploratoryTutorials = 80,
		CohortNUX = 81,
		DressUpChoice = 83,
		DressUpMirror = 84,
		ConfirmAvatar = 85,
		Complete = 100
	}

	[Flags]
	public enum ALCNDBPABEO
	{
		INVALID = 0,
		RecCenter = 1
	}

	[Flags]
	public enum KHLOHEJAJFJ
	{
		INVALID = 0,
		HasVisitedCustomRoom = 1,
		Tutorial_CustomRoomBrowser = 2,
		Tutorial_CreateCustomRoom = 4,
		HasUsedUGCShortcut = 8,
		HasLearnedAboutNewWatch_2018_04_23 = 0x10,
		HasLearnedAboutNewWatch_2018_08_20 = 0x20
	}

	[Serializable]
	public class VOClip
	{
		[SerializeField]
		private RecRoomAudioClip recClip;

		public float preDuration;

		public float postDuration;

		public RecRoomAudioClip AudioClip => null;
	}

	public enum AGHBFNEFPAA
	{
		NUX_INTRO = 0,
		NUX_MIRROR = 1,
		NUX_BULLETIN_BOARD = 2,
		NUX_WATCH = 3,
		NUX_MICROPHONE = 4,
		NUX_CODE_OF_CONDUCT = 5,
		TAP_TO_OPEN_PROFILE = 6,
		PROGRESSION_EVENT_INTRO = 7,
		PROGRESSION_EVENT_REWARD = 8,
		PROGRESSION_EVENT_BACKUP_INTRO = 9,
		PROGRESSION_EVENT_BACKUP_REWARD = 10
	}

	private sealed class EMJHBEFDNDF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TutorialManager _003C_003E4__this;

		public Tool tool;

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
		public EMJHBEFDNDF(int _003C_003E1__state)
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

	private sealed class KDBCCJIJFIJ
	{
		public TutorialManager _003C_003E4__this;

		public Vector3? positionOverride;

		internal void _003CShowHelpPopup_003Eb__0(Texture2D texture2D)
		{
		}
	}

	private sealed class EOHGJMKMOLH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TutorialManager _003C_003E4__this;

		public RecRoomAudioClip audioClip;

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
		public EOHGJMKMOLH(int _003C_003E1__state)
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

	private sealed class GMMNMJMLKMH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public TutorialManager _003C_003E4__this;

		public RecRoomAudioClip audioClip;

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
		public GMMNMJMLKMH(int _003C_003E1__state)
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

	private sealed class FIHGNKINKCB : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public FIHGNKINKCB(int _003C_003E1__state)
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

	private sealed class MMPCFCCELKK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TutorialManager _003C_003E4__this;

		public ACLOGGPNLDF audioType;

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
		public MMPCFCCELKK(int _003C_003E1__state)
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

	private sealed class AFBODEFLMDK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VOClip vo;

		public TutorialManager _003C_003E4__this;

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
		public AFBODEFLMDK(int _003C_003E1__state)
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

	public const string PREF_PROGRESSION_EVENT_TUTORIAL_START_DATE = "ProgressionEventTutorial_StartDate";

	[SerializeField]
	private AudioSource voAudioSource;

	[SerializeField]
	private AudioSource voAudioSource3D;

	[SerializeField]
	private TutorialAudioConfigs tutorialAudioConfigs;

	[SerializeField]
	private SubtitlePlayer subtitlePlayer;

	[SerializeField]
	private HelpPopup helpPopupPrefab;

	[SerializeField]
	private HelpPopupConfigs helpPopupConfigs;

	[SerializeField]
	private GameObject dropItemNotePrefab;

	private GameObject OHNGFGMPFAK;

	[SerializeField]
	[Space]
	private MakerPenIntro makerPenIntro;

	[Space]
	[SerializeField]
	private ChatPartyInviteTutorial chatPartyInviteTutorial;

	[SerializeField]
	[Space]
	private ChangeControlSchemeTutorial changeControlSchemeTutorial;

	[SerializeField]
	[Space]
	private ChatPlusButtonTutorial chatPlusButtonTutorial;

	[Space]
	[SerializeField]
	private SpeechToTextTranscriptionTutorial speechToTextTranscriptionTutorial;

	[Space]
	[SerializeField]
	private ProgressionEventIntroTutorial progressionEventIntroTutorial;

	[Space]
	[SerializeField]
	private ProgressionEventRewardTutorial progressionEventRewardTutorial;

	[SerializeField]
	[Space]
	private ProgressionEventBackupIntroTutorial progressionEventBackupIntroTutorial;

	[SerializeField]
	[Space]
	private ProgressionEventBackupRewardTutorial progressionEventBackupRewardTutorial;

	private const string NBPPPNLDHCP = "USER_TRACKING";

	private float GMNKOFGCCOL;

	private static bool? DGCOMEDDLGE;

	private const int FKMMKINBHEP = 5;

	private const string NGMHPKKLCPE = "PICKED_UP_STICKY_TOOL_BEFORE";

	private const string CNIIBOAOLJH = "HAS_OPENED_WATCH_MENU_BEFORE";

	private HelpPopup AKFCGPAHCGI;

	private const string HAIENEDAMHM = "TUTORIAL_COMPLETE_MASK";

	private const int DBNEFDEBDOL = 0;

	private bool PDINOMPJDOM;

	private string LCKBGLGOGEE;

	private string INHODJGNHEO;

	private const string NDAJGAEBODN = "MakerPenIntroCompleted";

	private const string IEIFHKJMBFA = "MakerPenIntroDismissed";

	private const string CBAPDOGEJMP = "MakerPenIntroCompletionTime";

	private bool GPEDINGIBKP;

	private LIHDGFHPCID FCBEAHKONDL;

	public const string OOBEFLOW_PREF = "Recroom.OOBE";

	private bool JAKCENIABKH;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private global::EHOCIICLNGN<Texture2D> ANDMFONOENI;

	private const float FKPLLBKMBKJ = 1f;

public bool IsPlayingVO
{
get 	{
		return false;
	}

}

public MakerPenIntro MakerPenIntro
{
get 	{
		return null;
	}

}

public ChatPartyInviteTutorial ChatPartyInviteTutorial
{
get 	{
		return null;
	}

}

public ChangeControlSchemeTutorial ChangeControlSchemeTutorial
{
get 	{
		return null;
	}

}

public ChatPlusButtonTutorial ChatPlusButtonTutorial
{
get 	{
		return null;
	}

}

public SpeechToTextTranscriptionTutorial SpeechToTextTranscriptionTutorial
{
get 	{
		return null;
	}

}

public ProgressionEventIntroTutorial ProgressionEventIntroTutorial
{
get 	{
		return null;
	}

}

public ProgressionEventRewardTutorial ProgressionEventRewardTutorial
{
get 	{
		return null;
	}

}

public ProgressionEventBackupIntroTutorial ProgressionEventBackupIntroTutorial
{
get 	{
		return null;
	}

}

public ProgressionEventBackupRewardTutorial ProgressionEventBackupRewardTutorial
{
get 	{
		return null;
	}

}

public bool HasBeenPromptedForEmail
{
get 	{
		return false;
	}

set {
	}
}

public static bool? DebugOverrideFastNux
{
get 	{
		return null;
	}

private set {
	}
}

private int HLIKCKMIHLB
{
get 	{
		return 0;
	}

set {
	}
}

public static bool HasOpenedWatchMenuBefore
{
get 	{
		return false;
	}

set {
	}
}

private HelpPopup NEGCEBIPEJM
{
get 	{
		return null;
	}

}

public bool HasCompletedNUXTutorial
{
get 	{
		return false;
	}

}

public bool IsPlayingQuickOrientation
{
get 	{
		return false;
	}

set {
	}
}

public bool HasReceivedWatch
{
get 	{
		return false;
	}

set {
	}
}

public bool HasCompletedOrientation
{
get 	{
		return false;
	}

set {
	}
}

public DateTime? OrientationCompletionTime
{
get 	{
		return null;
	}

private set {
	}
}

public bool HasCompletedMakerPenIntro
{
get 	{
		return false;
	}

set {
	}
}

public bool HasDismissedMakerPenIntro
{
get 	{
		return false;
	}

set {
	}
}

public DateTime? MakerPenIntroCompletionTime
{
get 	{
		return null;
	}

private set {
	}
}

public bool HasStartedATutorialThisSession
{
get 	{
		return false;
	}

private set {
	}
}

public LIHDGFHPCID NUXState
{
get 	{
		return LIHDGFHPCID.NotRan;
	}

set {
	}
}

public bool UseScreensModeNUX
{
get 	{
		return false;
	}

}

public bool HasDeferredActionScreenActive
{
get 	{
		return false;
	}

private set {
	}
}

private global::EHOCIICLNGN<Texture2D> KEBFANOLMKA
{
get 	{
		return null;
	}

set {
	}
}

	private static string BLBFEFCDIIM()
	{
		return null;
	}

	public bool IsLegacyTutorialComplete()
	{
		return false;
	}

	public void SetTutorialComplete(AGHBFNEFPAA ECKBHLKPGEE)
	{
	}

	public void SetTutorialIncomplete(AGHBFNEFPAA ECKBHLKPGEE)
	{
	}

	public bool IsTutorialComplete(AGHBFNEFPAA ECKBHLKPGEE)
	{
		return false;
	}

	private void EOFEGDAHOMH(string OPCKJKNEHGA, long IPMIIEAGJKC)
	{
	}

	private long PCNGHFPGKHN(string OPCKJKNEHGA, long GFLAEOLMKMC = 0L)
	{
		return 0L;
	}

	public bool HasStartedTutorial(MAJPKEBMCFC EEFAMMOHGIJ)
	{
		return false;
	}

	public void RecordTutorialStarted(MAJPKEBMCFC EEFAMMOHGIJ)
	{
	}

	private string HLECHGAHNEL(string KBJFPKNHPEL)
	{
		return null;
	}

	public void Initialize()
	{
	}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public bool HasUserTried(KHLOHEJAJFJ IBKGKDECOEG)
	{
		return false;
	}

	public void MarkUserTried(KHLOHEJAJFJ IBKGKDECOEG, bool LKLFGIIKMJJ = true)
	{
	}

	private void PNNLIHOKFCJ()
	{
	}

	private void KKJEGDFFILL(Scene FEGPGPHCDJD)
	{
	}

	private void PPKOLGPELII(bool GHCPICMIHDP)
	{
	}

	private void GEIAKCIBMDO(Player EKOFNPFCLMO)
	{
	}

	private void BDDNGJLGMCI(Tool IEGMBEPJMGC)
	{
	}

	private IEnumerator IJAOAGCCCFL(Tool IEGMBEPJMGC)
	{
		return null;
	}

	private void BADODPLCJNK(Tool IEGMBEPJMGC)
	{
	}

	public global::EHOCIICLNGN<Texture2D> GetHelpTexture(DCOLLEIEDOJ LJIIPEFKOHE, CILEIOOHEOB? HJJCLNMFBMC = null)
	{
		return null;
	}

	public HelpPopup ShowHelpPopup(DCOLLEIEDOJ LJIIPEFKOHE, Vector3? GNBODNIAKLK = null, CILEIOOHEOB? HJJCLNMFBMC = null)
	{
		return null;
	}

	public void HideHelpPopup()
	{
	}

	private ScreenHUDDialog.PIJJNPBAEAK? NLIGOLPAAIB(DCOLLEIEDOJ LJIIPEFKOHE)
	{
		return null;
	}

	public void StopVO()
	{
	}

	public RecRoomAudioClip GetTutorialAudio(ACLOGGPNLDF PLCOIGCJCEF)
	{
		return null;
	}

	public AudioSource PlayTutorialVO(ACLOGGPNLDF PLCOIGCJCEF)
	{
		return null;
	}

	public IEnumerator RunPlayVOClip(RecRoomAudioClip HFMBEKEICOC)
	{
		return null;
	}

	public IEnumerator<EGGPGCCKPCO> RunPlayVOClipOnScheduler(RecRoomAudioClip HFMBEKEICOC)
	{
		return null;
	}

	public IEnumerator RunVODelay()
	{
		return null;
	}

	public IEnumerator RunPlayVOClip(ACLOGGPNLDF PLCOIGCJCEF)
	{
		return null;
	}

	public IEnumerator RunPlayVO(VOClip DEJGDLEKKLF)
	{
		return null;
	}

	public AudioSource PlayVO(RecRoomAudioClip OAAADBMOMNE)
	{
		return null;
	}

	[CompilerGenerated]
	private void EPGEOPEPEIG()
	{
	}

	[CompilerGenerated]
	private bool BIFGHAHAKPM()
	{
		return false;
	}
}
