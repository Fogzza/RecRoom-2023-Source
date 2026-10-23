using System;
using RecRoom.Core.Locomotion;
using RecRoom.Core.UI;
using RecRoom.Core.VR;
using RecRoom.Core.VR.PlayerController;
using RecRoom.Core.VR.UI;
using RecRoom.Inputs;
using RecRoom.Tools;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RecRoom
{
	[Serializable]
	public class VRPlayerController : PlayerController
	{
		public enum FGLGPIAHKCC
		{
			INVALID = 0,
			PAUSED = 1,
			IDLE = 2,
			VEHICLE = 3
		}

		public enum DANMLPODGMN
		{
			DEFAULT = 0,
			OPEN_PROFILE = 1,
			QUICK_ACCEPT = 2,
			MAKERPEN_VR_SHORTCUT = 3,
			SCROLL = 4,
			ALWAYS_AVAILABLE = 5
		}

		private const float HAIR_TRIGGER_REACTION_WINDOW = 0.25f;

		private const float BOTH_HAND_BUTTON_PRESS_WINDOW = 0.2f;

		private const float HAND_OPEN_CLOSE_LERP_THRESHOLD = 0.1f;

		private const float HAND_OPEN_CLOSE_LERP_SPEED_FAST = 30f;

		private const float HAND_OPEN_CLOSE_LERP_SPEED_SLOW = 10f;

		private const int NUMBER_OF_HANDS = 2;

		private static string STATIONARY_TOKEN;

		private const int STATIONARY_PRIORITY = 0;

		private const float INCHES_TO_METERS = 0.0254f;

		[SerializeField]
		private float minHeightVariationThresholdInches;

		[SerializeField]
		private float minHeightVariationDerivativeThreshold;

		[SerializeField]
		private float heightSmoothtime;

		[SerializeField]
		private float heightApplySmoothTime;

		[SerializeField]
		private float shortenApplySmoothTime;

		[SerializeField]
		private float heightLimitAboveGround;

		[SerializeField]
		private float heightLimitAboveMeasuredHeight;

		[SerializeField]
		private PlayerHeightConfig heightConfig;

		[SerializeField]
		private VRPlayerRotationContent rotationContent;

		[SerializeField]
		private VRPlayerLocomotionContent locomotionContent;

		[SerializeField]
		private WalkVRPlayerSteeringController walkSteering;

		[SerializeField]
		private StationaryVRPlayerSteeringController stationarySteering;

		[SerializeField]
		private float maxUIInteractionDistance;

		[SerializeField]
		private float maxUIPushButtonDistance;

		[SerializeField]
		private int uiRaycastUpdateHz;

		[SerializeField]
		private VRInteractableTargetingSystemConfig defaultTargetingSystemConfig;

		[SerializeField]
		private WatchNotificationVRController watchNotificationController;

		[SerializeField]
		private OpenProfileVRController openProfileController;

		[SerializeField]
		private SubtitleVRController subtitleController;

		[SerializeField]
		private VRInteractDialog leftHandInteractDialog;

		[SerializeField]
		private VRInteractDialog rightHandInteractDialog;

		[SerializeField]
		private Vector3 leftHandInteractDialogOffset;

		[SerializeField]
		private Vector3 rightHandInteractDialogOffset;

		[SerializeField]
		private float interactDialogIdealSurfaceDistance;

		[SerializeField]
		private float interactDialogMinDistance;

		[SerializeField]
		private float interactDialogMaxDistance;

		private JBHDBPAKAMM locomotionController;

		private FGDBPPOIGEP rotationController;

		private global::AFHOAHNAMGF<VRPlayerSteeringController> steeringControllerMap;

		private FIHGBEHGLGB pointGestureRestrictionFlag;

		private bool delayedReleaseOfLeftHandHeldTool;

		private bool delayedReleaseOfRightHandHeldTool;

		private bool delayedLeftHandVelocityTriggerRelease;

		private bool delayedRightHandVelocityTriggerRelease;

		private FIHGBEHGLGB strafeRestrictionFlag;

		private FIHGBEHGLGB watchOpenGestureRestrictionFlag;

		private FIHGBEHGLGB shareCameraGestureRestrictionFlag;

		private FIHGBEHGLGB expressoRestrictionFlag;

		private global::AFHOAHNAMGF<global::CNANNICAHPN<MBIAJJCDFHP>> leftHandPlacementControllerMap;

		private global::AFHOAHNAMGF<global::CNANNICAHPN<MBIAJJCDFHP>> rightHandPlacementControllerMap;

		private global::AFHOAHNAMGF<global::CNANNICAHPN<BEANOPBGFLA>> cameraPlacementControllerMap;

		private FIHGBEHGLGB handUpdateRequiresEarlyCameraRigUpdateFlag;

		private int lastEarlyCameraRigUpdateFrame;

		private JIKMFOFNIMF leftHandPlacementSystem;

		private JIKMFOFNIMF rightHandPlacementSystem;

		private FAFHFPNEADL cameraPlacementSystem;

		private VRToolController currentRightHandToolActionController;

		private VRToolController currentLeftHandToolActionController;

		private VRInputHandler leftHandInput;

		private VRInputHandler rightHandInput;

		private string leftHandScrollingToken;

		private string rightHandScrollingToken;

		private FIHGBEHGLGB vrSeatedModeEnabledOverrideFlag;

		private global::AFHOAHNAMGF<float> vrSeatedModeHeightOverrideMap;

		private MDEJADHJOEJ playerStateMachine;

		private readonly UIInputModule.GJFEIPEOFAK[] cachedInputResultPerHand;

		private ShareCamera _shareCam;

		private IRecRoomQualityConfigProvider qualityConfigProvider;

		private static JNKNMMDAHCF _settingsManager;

		private FMDMKFFJHNM _photonClient;

		private bool handAlternator;

		private bool leftHandToolToggleLockButtonUpPending;

		private bool rightHandToolToggleLockButtonUpPending;

		private bool leftHandToolUnlockButtonUpPending;

		private bool rightHandToolUnlockButtonUpPending;

		private bool[] secondaryMenuButtonRequiresRelease;

		private bool[] pointGestureDownDetected;

		private float _stablePlayerHeight;

		private float maxStablePlayerHeight;

		private float seatedHeightOffsetAdjustment;

		private bool requestStableHeightUpdate;

		private CGOBNNIEKLB standHeightSpring;

		private CGOBNNIEKLB shortenSpring;

		public override bool HasInputThisFrame => false;

		private VRPlayerSteeringController ActiveSteeringController => null;

		public FGDBPPOIGEP RotationController => null;

		public static GOIFPBJAGOG WalkHandMode => (GOIFPBJAGOG)0;

		public VRInputHandler LeftHandInputHandler => null;

		public VRInputHandler RightHandInputHandler => null;

		public VRInputHandler WalkHandInputHandler => null;

		public VRInputHandler OffHandInputHandler => null;

		public EGGHDNKHKIO InteractableTargetingSystem { get; private set; }

		private ShareCamera ShareCam => null;

		private static JNKNMMDAHCF SettingsManager => null;

		private FMDMKFFJHNM PhotonClient => null;

		public static bool GlobalJointPickupEnabledDefault => false;

		private bool HandUpdateRequiresEarlyCameraRigUpdate => false;

		public bool IsStrafeRestricted => false;

		public bool IsExpressoRestricted => false;

		public bool IsVRSeatedModeOverridden => false;

		private bool IsSeatedModeEnabled => false;

		public float AdjustedPlayerHeightForPlayerScale => 0f;

		public override float DesiredPlayerScale => 0f;

		private float StablePlayerHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override void KBHEHEFFOKF(GNEENOANCIM.ABLDJLKKHJP NHJPBHJLFOD)
		{
		}

		public override void KPFCKHNHGPC(GNEENOANCIM.ABLDJLKKHJP NHJPBHJLFOD)
		{
		}

		public void OIIHECHOBML(object IALNODEHBNN)
		{
		}

		public void NMBJJKLDDCH(object IALNODEHBNN)
		{
		}

		public void PIDGNNGEOHC(object IALNODEHBNN)
		{
		}

		public void AIGJHADHIAA(object IALNODEHBNN)
		{
		}

		public void OEICIKBKEEF(object IALNODEHBNN)
		{
		}

		public void CELCHDCPAAM(object IALNODEHBNN)
		{
		}

		public void DGMIKNFNMKG(object IALNODEHBNN)
		{
		}

		public void JHFOBNOOGLP(object IALNODEHBNN)
		{
		}

		public void JHPEJNBEOBA(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, MBIAJJCDFHP KABFAJJCNHG, float DHGKDPBMONF, object IALNODEHBNN, JIKMFOFNIMF.MHNFHPCPFJI LAGADKBKLAD)
		{
		}

		public void JHPEJNBEOBA(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, MBIAJJCDFHP KABFAJJCNHG, float DHGKDPBMONF, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void GACGPBFPHMK(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, object IALNODEHBNN)
		{
		}

		public void HPLLBCMHOHG(MBIAJJCDFHP KABFAJJCNHG, float DHGKDPBMONF, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void IEFMHADDOFP(object IALNODEHBNN)
		{
		}

		public void EMLHJGKELGK(MBIAJJCDFHP KABFAJJCNHG, float DHGKDPBMONF, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void GFHCJKAGFDF(object IALNODEHBNN)
		{
		}

		public void MMIEFLEGBAH(BEANOPBGFLA KPJMOBBPAHE, float DHGKDPBMONF, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void IECMCOMKDHL(object IALNODEHBNN)
		{
		}

		public void BJALGMLPAIJ(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, bool GILAGKBHFJP)
		{
		}

		public void JHBJHMPDOPD(VRPlayerSteeringController COEKBMDIOPJ, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void OHCCLMDHOKB(object IALNODEHBNN)
		{
		}

		public void MBHBFICFHCP(object IALNODEHBNN)
		{
		}

		public void NDELOEBIPPA(object IALNODEHBNN)
		{
		}

		public void OJEDOLNGDPG(object IALNODEHBNN)
		{
		}

		public void GACODMBPAHF(object IALNODEHBNN)
		{
		}

		public void MPLIBFKEIDO(float BICGJAOHKIJ, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void KIFJGEJBMBP(object IALNODEHBNN)
		{
		}

		public override void IHEKMEOIBOI(LocalPlayerController HOIIBHDNAJI)
		{
		}

		public override void FCCAJFNJBLH()
		{
		}

		private void KDELGLNBFAF(GHCCKFEJDOA ICHBECDKHOJ)
		{
		}

		public override void LIDHELJBOFC()
		{
		}

		public override void HAFMJAPFCGD()
		{
		}

		public override void GIHKGIMINNE()
		{
		}

		public override void AKFBGKGEGGF()
		{
		}

		public override void ALBLCLBPGMJ()
		{
		}

		public override void HADBNNANGFK()
		{
		}

		public override void NMJKIJBBDKO(Player MHCOBIPKGNI)
		{
		}

		public override void JMHMIEACMHH(LoginScreenSpawnPoint FPDAFHFAEIC)
		{
		}

		public override Player JPAGHPDCEFL(Vector3 KNAEKDOAJLP, Quaternion IMOAIMDLDEM)
		{
			return null;
		}

		public override void PPGOLHLBGGH()
		{
		}

		private void PMIDBMAIOLN()
		{
		}

		private void GGLOGJANACC(Player EKOFNPFCLMO)
		{
		}

		private void IGPIOODFBLP(Player EKOFNPFCLMO, PlayerMovement EJGAMFOKJOO)
		{
		}

		private void PNKNNGBLONO(Player EKOFNPFCLMO, PlayerMovement EJGAMFOKJOO)
		{
		}

		private void DNOKMNHPIAG(Player EKOFNPFCLMO, PlayerMovement EJGAMFOKJOO)
		{
		}

		private void PELJDJIBCJD(PlayerTrackingSpace CIOGCKMINJE)
		{
		}

		private void IKEEFMGOHAN(PlayerHead HJKMGMBILCI)
		{
		}

		private void NOPKIKHBCKM()
		{
		}

		private void NIKAJCCJFHO()
		{
		}

		private VRToolController APFOGMLLNHF(PlayerHand PMNLJGLDMJN)
		{
			return null;
		}

		private void HGEGGFBCNGJ(VRToolController IJIAEDONGKE, PlayerHand LIEHAPOPALF, PlayerHand MCGMBMMJMBM, VRInputHandler COHAGCOFPIE, VRInputHandler INDBPAJCIDC)
		{
		}

		private void HJKFNDDDGLO(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
		}

		private void LLGGJGFONGM(PlayerHand PMNLJGLDMJN)
		{
		}

		private void LADOAPFFEBF(VRInputHandler KAEDAICECGN)
		{
		}

		private void JHBJNDBPJNL(VRInputHandler KAEDAICECGN)
		{
		}

		private void LNBLAGEAPOG(PlayerHand FOFPLOLGNHJ, PlayerHand MCGMBMMJMBM, VRInputHandler BMBCJDHMCGF, VRInputHandler INDBPAJCIDC)
		{
		}

		private void NKBNPPGDGGI(PlayerHand PMNLJGLDMJN, int HIJKHPMDNMK, float DOEJGDJILAD)
		{
		}

		private void BCEDJEEJLFM(PlayerHand PMNLJGLDMJN)
		{
		}

		private UIInputModule.GJFEIPEOFAK CDGGLCHEEEA(PlayerHand PMNLJGLDMJN)
		{
			return default;
		}

		private void IGFILICMDOM(Player EKOFNPFCLMO, bool AFELAGCJFDK, PlayerHand FOFPLOLGNHJ, PlayerHand MCGMBMMJMBM, VRInputHandler BMBCJDHMCGF, VRInputHandler INDBPAJCIDC)
		{
		}

		private LMFLCFFHNOF DAKMNNLKAHJ(Player EKOFNPFCLMO, PlayerHand PMNLJGLDMJN, out bool PKGLOHCOLHB, out Collider FIJIODDNINO)
		{
			PKGLOHCOLHB = default;
			FIJIODDNINO = null;
			return null;
		}

		private LMFLCFFHNOF ILABPAPBPED(Player EKOFNPFCLMO, PlayerHand PMNLJGLDMJN, out bool PKGLOHCOLHB, out Collider FIJIODDNINO)
		{
			PKGLOHCOLHB = default;
			FIJIODDNINO = null;
			return null;
		}

		private void MPJDKBNHHCI(Player EKOFNPFCLMO, PlayerHand PMNLJGLDMJN, LMFLCFFHNOF PCNPMPMHGHF, bool PKGLOHCOLHB, Collider FIJIODDNINO)
		{
		}

		private bool LDGBGAMNAAJ(Player EKOFNPFCLMO, PlayerHand FOFPLOLGNHJ, PIHMPBGNBHB IFEOGBCJEBI)
		{
			return false;
		}

		private bool GFPJLCCLCIA(Player EKOFNPFCLMO, PlayerHand PMNLJGLDMJN, float DANBOMOBPOI, float PHFIDJEDAOM)
		{
			return false;
		}

		private void OCFPODNLMDL(PlayerHand PMNLJGLDMJN, Collider ADMCDJKKCIA, out Vector3 MKJDDNHGKAM, out Quaternion EPAJPIMEHIA)
		{
			MKJDDNHGKAM = default;
			EPAJPIMEHIA = default;
		}

		private void MABJKJGGLCN(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
		}

		private void BKAENGGPJNB(PlayerHand PMNLJGLDMJN, bool HKJHAGPFEGA)
		{
		}

		private bool ICJNIEMOLOB(PlayerHand PMNLJGLDMJN)
		{
			return false;
		}

		private void CBNOKGJGECO(PlayerHand PMNLJGLDMJN, bool HKJHAGPFEGA)
		{
		}

		private bool GJLAMALMDHK(PlayerHand PMNLJGLDMJN)
		{
			return false;
		}

		private void JMNHMHDLOIA(Player EKOFNPFCLMO, PlayerHand KOMMPCGEMAP, PlayerHand MCGMBMMJMBM, VRInputHandler AGODMDILEPA, VRInputHandler INDBPAJCIDC)
		{
		}

		private bool GKGOLMAIOEB(Player EKOFNPFCLMO, Tool IEGMBEPJMGC, PlayerHand LIEHAPOPALF, PlayerHand MCGMBMMJMBM, VRInputHandler COHAGCOFPIE, VRInputHandler INDBPAJCIDC, out VRToolController BCKFJNDHCCH)
		{
			BCKFJNDHCCH = null;
			return false;
		}

		private void NAKEDJELIMB(Player EKOFNPFCLMO, PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
		}

		private void ELIDPLNBGBM(Player EKOFNPFCLMO, PlayerHand FOFPLOLGNHJ, VRInputHandler BMBCJDHMCGF)
		{
		}

		private void DDPJCEEBOPO(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
		}

		private void BEABALFLGIO(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
		}

		private void LAJCNELBGMC(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
		}

		private void FBKJODEDFIF(PlayerHand LIEHAPOPALF, PlayerHand MCGMBMMJMBM, VRInputHandler COHAGCOFPIE, VRInputHandler INDBPAJCIDC)
		{
		}

		private void EBENNNPOAJK(PlayerHand LIEHAPOPALF, PlayerHand MCGMBMMJMBM, VRInputHandler COHAGCOFPIE, VRInputHandler INDBPAJCIDC)
		{
		}

		private void PGKDCECMJDM(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN, Vector3 BDMDMPALFNC, bool PLPECLIMBGC, out Vector3 MCBCBMFBKCA, out Vector3 MEBJBANMPLK)
		{
			MCBCBMFBKCA = default;
			MEBJBANMPLK = default;
		}

		private void AMMMDJIEFLH()
		{
		}

		private void GLFFJGFDBON(Player EKOFNPFCLMO, PlayerHand GBHOAABLEKO, VRInputHandler APCLONJLBKH, PlayerHand BCLLPMALPJK, VRInputHandler LLFLHHOFILH)
		{
		}

		private void DOAHCOCOBKB(Player EKOFNPFCLMO, PlayerHand GBHOAABLEKO, VRInputHandler APCLONJLBKH, PlayerHand BCLLPMALPJK, VRInputHandler LLFLHHOFILH)
		{
		}

		private void JNCGPHFDGMH(Player EKOFNPFCLMO, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE)
		{
		}

		private void JDACLIKNLEH(Player EKOFNPFCLMO, VRInputHandler HDBKANLLDFE, VRInputHandler BEPMOMADFIE)
		{
		}

		private bool KEAEJONGIDP(PlayerHand PMNLJGLDMJN, VRInputHandler KAEDAICECGN)
		{
			return false;
		}

		private void OGEAHEMIKKE()
		{
		}

		private void OFELKNEDILC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EFJMLGOJPDJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private bool OMFOIPANCEP()
		{
			return false;
		}

		private void GJPHLCEIJLB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EGJHFBPPNKP()
		{
		}

		private void IELMJDKEJAJ(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void ELGGFNPHPDN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DIBFEKOMCOG()
		{
		}

		private void EONEKGEKLKE(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KIAIIOEOLOE()
		{
		}

		private void IDMGCEHMFFI()
		{
		}

		private void CEPHJOHLLIM()
		{
		}

		private void DJKLIEAEOAE()
		{
		}

		private bool HHJPPLGLJJF(out float DBAFLDGMBKN)
		{
			DBAFLDGMBKN = default;
			return false;
		}

		private void CNOOIAFJPGN()
		{
		}

		private bool PIJBPJIDMKK(out float NNOEBLCOLNK)
		{
			NNOEBLCOLNK = default;
			return false;
		}

		private void CIICEHCPDEE()
		{
		}

		private void BAAPNBECCFH()
		{
		}

		private float JLDECAMBIJB()
		{
			return 0f;
		}

		private float LDPOFEHPCLF()
		{
			return 0f;
		}

		private float MIDALCPPFGL()
		{
			return 0f;
		}

		private void JDANPEJMNJM()
		{
		}
	}
}
