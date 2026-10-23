using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RecRoom.AGUI;
using RecRoom.Core;
using RecRoom.Core.Animation;
using RecRoom.Core.Controllers.ScreenBehaviors;
using RecRoom.Core.Controllers.ScreenModes;
using RecRoom.Core.Screens;
using RecRoom.Core.Screens.PlayerController;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom
{
	[Serializable]
	public class ScreenPlayerController : PlayerController
	{
		[OFENKFBEDDN]
		public enum HHBGPIOBFFJ
		{
			INVALID = -1,
			MAIN = 0,
			INSPECT_TOOL = 1,
			DRAWING_SURFACE = 2,
			THIRD_PERSON = 3,
			SEATED = 4,
			GESTURE = 5,
			MENU = 50,
			PAUSED = 100
		}

		[OFENKFBEDDN]
		public enum CGPIDNEDJAK
		{
			COMBAT_DEATH = 0,
			ANDROID_BACK_BUTTON_ACTIONS = 1,
			MOBILE_HOME = 2,
			TOOL_PRIMARY_ACTION_PASSIVE = 3,
			TOOL_BLOCK_ACTION = 4,
			HAND_PILOT_PASSIVE = 5,
			INSPECT_TOOL = 6,
			TOOL_SECONDARY_ACTION_ACTIVE = 7,
			OPEN_PROFILE = 8,
			INTERACTABLE_TARGETING = 9,
			SEATED = 10,
			PREFER_PRONE_CRAWL_ANIMATION = 11,
			USE_WORLD_SPACE_UI = 12,
			HAND_PILOT_ACTIVE = 13,
			SOCIAL_GESTURE_HIGH_FIVE = 14,
			SOCIAL_GESTURE_FIST_BUMP = 15,
			SOCIAL_GESTURE_HANDSHAKE = 16,
			COMBAT_REVIVE = 17,
			TOOL_PRIMARY_ACTION_ACTIVE = 18,
			TOOL_DROP = 19,
			BLOCK_TOOL_ACTIONS = 20,
			HEAD_CONTROLS = 21,
			THIRD_PERSON = 22,
			TOGGLE_THIRD_PERSON_MODE = 23,
			TOGGLE_VEHICLE = 24,
			HANDED_RADIAL_MENUS = 25,
			MENUS = 26,
			ALWAYS_AVAILABLE = 27
		}

		[OFENKFBEDDN]
		public enum OKKOMNMEDEH
		{
			DISABLED = -1,
			DEFAULT = 0,
			ANDROID_BACK_BUTTON_ACTIONS = 1,
			MOBILE_HOME = 2,
			HAND_PILOT_PASSIVE = 3,
			INTERACTABLE_TARGETING_HANDED_SWAP = 4,
			TOOL_DROP_PASSIVE = 5,
			TOOL_TERTIARY_ACTION_PASSIVE = 6,
			TOOL_SECONDARY_ACTION_PASSIVE = 7,
			TOOL_PRIMARY_ACTION_PASSIVE = 8,
			INTERACTABLE_TARGETING = 9,
			TOOL_CONTEXTUAL = 10,
			TOOL_EQUIPMENT_SHORTCUT = 11,
			HAND_PILOT_POSE_PASSIVE = 12,
			OPEN_PROFILE = 13,
			USE_WORLD_SPACE_UI_OFFHAND = 14,
			USE_WORLD_SPACE_UI_DOMINANT = 15,
			TOOL_CANCEL = 16,
			HANDED_MENU = 17,
			TOOL_MENU_TOGGLE = 18,
			HAND_PILOT_ACTIVE = 19,
			SOCIAL_GESTURE_HIGH_FIVE = 20,
			SOCIAL_GESTURE_FIST_BUMP = 21,
			SOCIAL_GESTURE_HANDSHAKE = 22,
			GESTURE_CANCEL = 23,
			RADIAL_MENU_ACTIVE = 24,
			COMBAT_REVIVE_HANDED = 25,
			COMBAT_REVIVE_SMART = 26,
			TOOL_SECONDARY_ACTION_ACTIVE = 27,
			TOOL_PRIMARY_ACTION_ACTIVE = 28,
			TOOL_DROP_ACTIVE = 29,
			SEATED = 30,
			TOGGLE_THIRD_PERSON_MODE = 31,
			MENUS = 32,
			ALWAYS_AVAILABLE = 33
		}

		[OFENKFBEDDN]
		public enum JGABDNCALLD
		{
			DEFAULT = 0,
			FLY = 1,
			SPRINT = 2,
			CLAMBER = 3,
			SLIDE = 4,
			SLIDE_JUMP = 5,
			WALL_RUN = 6,
			WALL_CLIMB = 7,
			WALL_CLIMB_JUMP = 8,
			SIT = 9,
			GESTURES = 10,
			SEAT = 11,
			SEAT_ACCELERATING = 12,
			VEHICLE = 13,
			THIRD_PERSON = 14,
			TOOL_AIMING = 15,
			SELF_SCALE = 16,
			SHARE_CAM = 17,
			DRAWING = 18,
			MENU = 19,
			PAUSE = 20,
			RESPAWN = 21,
			AR_TRACKING = 22,
			CONTROLLER_DISCONNECTED = 23
		}

		[OFENKFBEDDN]
		public enum MDICNIOLNIE
		{
			DEFAULT = -1,
			COMBAT_DEATH = 0,
			ANDROID_BACK_BUTTON_ACTIONS = 1,
			TOOL_PRIMARY_ACTION_PASSIVE = 2,
			TOOL_BLOCK_ACTION = 3,
			HAND_PILOT_PASSIVE = 4,
			INSPECT_TOOL = 5,
			TOOL_SECONDARY_ACTION_ACTIVE = 6,
			OPEN_PROFILE = 7,
			INTERACTABLE_TARGETING = 8,
			SEATED = 9,
			PREFER_PRONE_CRAWL_ANIMATION = 10,
			USE_WORLD_SPACE_UI = 11,
			HAND_PILOT_ACTIVE = 12,
			SOCIAL_GESTURE = 13,
			COMBAT_REVIVE = 14,
			TOOL_PRIMARY_ACTION_ACTIVE = 15,
			TOOL_DROP = 16,
			TOOL_DROP_DISABLED = 17,
			HEAD_CONTROLS = 18,
			THIRD_PERSON = 19,
			TOGGLE_THIRD_PERSON_MODE = 20,
			TOGGLE_VEHICLE = 21,
			HANDED_RADIAL_MENUS = 22,
			MENUS = 23,
			ALWAYS_AVAILABLE = 24,
			FLY = 25,
			SPRINT = 26,
			CLAMBER = 27,
			SLIDE = 28,
			SLIDE_JUMP = 29,
			WALL_RUN = 30,
			WALL_CLIMB = 31,
			WALL_CLIMB_JUMP = 32,
			SIT = 33,
			PAUSE = 34,
			MAX = 35
		}

		[OFENKFBEDDN]
		public enum BOPAMKELCAJ
		{
			DEFAULT_HEIGHT_PRIORITY = 1,
			CROUCH_HEIGHT_PRIORITY = 2,
			PRONE_HEIGHT_PRIORITY = 3,
			SLIDE_HEIGHT_PRIORITY = 4,
			WALL_CLIMB_HEIGHT_PRIORITY = 5
		}

		private struct JMJOGGPAJPH : IEquatable<JMJOGGPAJPH>
		{
			public GHCICEFBOGM AEBIACPKIKH;

			public CIKFJOFIPLL KLBONOOHBND;

			public Player MBFJFNELEGB;

			public JMJOGGPAJPH(GHCICEFBOGM AEBIACPKIKH, CIKFJOFIPLL KLBONOOHBND, Player MBFJFNELEGB)
			{
				this.AEBIACPKIKH = GHCICEFBOGM.None;
				this.KLBONOOHBND = CIKFJOFIPLL.OFFERER;
				this.MBFJFNELEGB = null;
			}

			public bool Equals(JMJOGGPAJPH HNPEBINPOBO)
			{
				return false;
			}
		}

		private struct CGJLNPGFCKB
		{
			public JMJOGGPAJPH LODABDHPBMM;

			private float MPBGBAFBPAI;

			public CGJLNPGFCKB(JMJOGGPAJPH LODABDHPBMM, float MPBGBAFBPAI)
			{
				this.LODABDHPBMM = default;
				this.MPBGBAFBPAI = 0f;
			}

			public bool DJDIOKGMOCG(float CJCLLNNMCFL)
			{
				return false;
			}
		}

		public enum DBLFNBLEEAO
		{
			GLOBAL = 0,
			RIGHT_HAND = 1,
			LEFT_HAND = 2
		}

		private readonly struct CPLFGHJPDDN
		{
			public readonly MJEKKBPKMCB GNLNNDHBBDI;

			public readonly DBLFNBLEEAO IMPDHJBOLBF;

			public CPLFGHJPDDN(MJEKKBPKMCB GNLNNDHBBDI, DBLFNBLEEAO IMPDHJBOLBF)
			{
				this.GNLNNDHBBDI = null;
				this.IMPDHJBOLBF = DBLFNBLEEAO.GLOBAL;
			}
		}

		private readonly struct EMCENKBGJJN
		{
			public readonly bool ILJAKJPGPJA;

			public readonly DrawingSurface FAMNKOFMEAL;

public static EMCENKBGJJN DPPJPBMGLNA
{
get 			{
				return default;
			}

}

			public EMCENKBGJJN(bool ILJAKJPGPJA, DrawingSurface FAMNKOFMEAL)
			{
				this.ILJAKJPGPJA = false;
				this.FAMNKOFMEAL = null;
			}
		}

		private sealed class ALGOKCKHJGD
		{
			public bool shouldReport;

			public float now;

			public JMJOGGPAJPH signature;

			internal bool _003CShouldReportGesture_003Eb__0(CGJLNPGFCKB report)
			{
				return false;
			}
		}

		private sealed class EOKHELKNEPB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ScreenPlayerController _003C_003E4__this;

			public Player player;

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
			public EOKHELKNEPB(int _003C_003E1__state)
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

		private sealed class CEABIBGPMHO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ScreenPlayerController _003C_003E4__this;

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
			public CEABIBGPMHO(int _003C_003E1__state)
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

		public const float DEFAULT_GAZE_TARGET_DISTANCE = 30f;

		private const float DEFAULT_PLAYER_HEAD_HEIGHT = 1.6f;

		private const float DEFAULT_PLAYER_HAND_HEIGHT = 0.96000004f;

		private const float DEFAULT_PLAYER_HAND_FORWARD_OFFSET = 0.05f;

		private const float DEFAULT_PLAYER_WINGSPAN = 0.66f;

		private static readonly Vector3 DEFAULT_PLAYER_HEAD_POSITION;

		private static readonly Quaternion DEFAULT_PLAYER_HEAD_ROTATION;

		private static readonly Vector3 DEFAULT_PLAYER_RIGHT_HAND_POSITION;

		private static readonly Vector3 DEFAULT_PLAYER_LEFT_HAND_POSITION;

		private static readonly Quaternion DEFAULT_PLAYER_HAND_ROTATION;

		public static readonly string SCREEN_PLAYER_HOLDING_TOOL_TOKEN;

		public static readonly string SCREEN_PLAYER_EQUIPPED_TOOL_TOKEN;

		[SerializeField]
		private ScreenPlayerModeConfigBase[] modeConfigs;

		[SerializeField]
		private ScreenToolBehaviorConfigBase toolDefaultBehaviorControllerConfig;

		[SerializeField]
		private ScreenPlayerBehaviorConfigBase[] globalPlayerBehaviors;

		[SerializeField]
		private PerHandScreenPlayerBehaviorConfigBase[] globalPerHandBehaviors;

		[SerializeField]
		private ScreenPlayerCameraSettings defaultCameraSettings;

		[SerializeField]
		private ScreenPlayerCursorSettings defaultGameplayCursorSettings;

		[SerializeField]
		private ScreensCameraInputGamepadSettings defaultCameraGamepadInputSettings;

		[SerializeField]
		private ScreenInteractableTargetingSystemConfig defaultTargetingSystemConfig;

		[SerializeField]
		private float defaultCameraBlendTime;

		[SerializeField]
		private float screenFillPortion;

		[SerializeField]
		private float defaultMinMenuViewportMarginOnEitherAxis;

		[SerializeField]
		private float touchMinMenuViewportMarginOnEitherAxis;

		[SerializeField]
		private float minGazeDistance;

		[SerializeField]
		private float maxGazeDistance;

		[SerializeField]
		private float gazeTargetCollisionRadius;

		[SerializeField]
		private ScreenPlayerLocomotionContent locomotionContent;

		[SerializeField]
		private ScreenPlayerLocomotionAnimationContent locomotionAnimationContent;

		[SerializeField]
		private ScreenAimAssistSettings aimAssistSettings;

		[SerializeField]
		private ScreenPlayerLookLeanAnimationContent lookLeanAnimationContent;

		[SerializeField]
		private AdditiveAnimationWeight additiveAnimationWeight;

		[SerializeField]
		private AdditiveAnimationWeight defaultAdditveCameraAnimationWeight;

		[SerializeField]
		private Vector3 cameraShakeMaxLinearDisplacement;

		[SerializeField]
		private Vector3 cameraShakeMaxAngularDisplacement;

		private AECAHLPIFOC inputHandler;

		private ECBLPMNNCOF locomotionController;

		private CBJIHCIDPGO defaultSteering;

		private LGPLMNGEAGA defaultCameraController;

		private OBLFPAAMGKM respawnCameraController;

		[SerializeField]
		private const float aspectRatioMinDiff = 0.1f;

		private static readonly Lazy<FEIKFKAICHC> statsig;

		[CompilerGenerated]
		private Action<Player> PlayerMovementCompleted;

		private JCHCNCODBEK _controlsLayer;

		private static readonly string DEDUPE_HAND_GESTURE_EVENTS_PERIOD;

		private const float DEDUPE_HAND_GESTURE_EVENTS_PERIOD_DISABLED = -1f;

		private List<CGJLNPGFCKB> gestureEventReports;

		private JCHCNCODBEK _touchControlsLayer;

		private JCHCNCODBEK _thirdPersonLayer;

		private const string THIRD_PERSON_ENABLED = "ENABLED";

		private const string THIRD_PERSON_DISABLED = "DISABLED";

		private const string THIRD_PERSON_OPT_IN = "OPT_IN";

		private global::AFHOAHNAMGF<ScreenPlayerSteeringController> steeringControllerMap;

		private readonly global::MKJNCDLHHNA<CIDCICNCOHB> menuRequestMap;

		private EMCENKBGJJN latestDrawingSurfaceRequest;

		private bool isThirdPersonRequested;

		private readonly FIHGBEHGLGB menuOpeningRestrictedFlag;

		private readonly FIHGBEHGLGB openPlayerProfileRestrictionFlag;

		private readonly FIHGBEHGLGB flyToggleRestrictionFlag;

		private readonly FIHGBEHGLGB leftHandPilotRestriction;

		private readonly FIHGBEHGLGB rightHandPilotRestriction;

		private readonly FIHGBEHGLGB leftHandInventoryRestriction;

		private readonly FIHGBEHGLGB rightHandInventoryRestriction;

		private readonly FIHGBEHGLGB holsterShortcutRowRestriction;

		private readonly FIHGBEHGLGB emotesRestriction;

		private readonly FIHGBEHGLGB gestureRadialMenuRestriction;

		private readonly FIHGBEHGLGB thirdPersonRestrictionFlag;

		private readonly FIHGBEHGLGB contextSensitiveToolRestrictionFlag;

		private readonly FIHGBEHGLGB arRoomScaleRestrictionFlag;

		private readonly FIHGBEHGLGB locomotiveHeightShorteningRestrictionFlag;

		private readonly FIHGBEHGLGB seatedLeanRestriction;

		private HDLEKEPDDEJ modeSystem;

		private HDIHEKDHDLC[] modeRuntimes;

		private readonly NEIMPKOMKGL globalBehaviorSystem;

		private readonly NEIMPKOMKGL leftHandBehaviorSystem;

		private readonly NEIMPKOMKGL rightHandBehaviorSystem;

		private readonly FIHGBEHGLGB toolBehaviorsEnabledFlag;

		private readonly List<MJEKKBPKMCB> toolBehaviorRuntimesMarkedForDispose;

		private readonly List<MJEKKBPKMCB> globalPlayerBehaviorRuntimes;

		private readonly List<MJEKKBPKMCB> rightHandPlayerBehaviorRuntimes;

		private readonly List<MJEKKBPKMCB> leftHandPlayerBehaviorRuntimes;

		private readonly Dictionary<Tool, CPLFGHJPDDN> toolPlayerBehaviors;

		private bool isImmediatelyDisposingToolControllers;

		private static bool gazeInheritPlayerVelocity;

		public static bool LogGestureEvents;

		public GFLJPBGELNJ AnimationSystem { get; private set; }

		public DNNLBFPKCKL CameraSystem { get; private set; }

		public LCCBIPHKLJG CursorSystem { get; private set; }

		public APFJMIGKGPB AimAssistSystem { get; private set; }

		public LKBMAJKLMML InteractableTargetingSystem { get; private set; }

		public Vector3 GazeTarget { get; private set; }

		public Vector3 GazeDirection { get; private set; }

		public float NormalizedGazeTargetDistance { get; private set; }

		public float GazeTargetDistance => 0f;

		private float MinViewPortMarginOnEitherAxis => 0f;

		public bool IsThirdPersonCamera => false;

		public override bool HasInputThisFrame => false;

		private bool IsScreens => false;

		private bool IsTouch => false;

		private bool IsSmartInteract => false;

		private JCHCNCODBEK ControlsLayer => null;

		public bool CanChangeControlSchemes => false;

		private float DedupeHandGestureEventsPeriod => 0f;

		private JCHCNCODBEK TouchControlsLayer => null;

		public bool TouchFloatingInteractPrompt => false;

		public bool TouchRecenterWalkStick => false;

		private JCHCNCODBEK ThirdPersonLayer => null;

		private string ThirdPersonStatsigAvailability => null;

		public bool IsThirdPersonOptInRequired => false;

		public bool IsThirdPersonModeAvailable => false;

		public bool FlyToggleEnabled => false;

		public bool MenuOpeningRestricted => false;

		public bool IsOpenPlayerProfileRestricted => false;

		public bool IsHolsterShortcutRowRestricted => false;

		public bool AreHandPilotPosesSupported => false;

		public bool AreEmotesRestricted => false;

		public bool IsGestureRadialMenuRestricted => false;

		public bool IsThirdPersonRestricted => false;

		public bool ContextSensitiveToolsRestricted => false;

		public bool ARRoomScaleMovementRestricted => false;

		public bool IsLocomotiveHeightShorteningEnabled => false;

		public bool IsSeatedLeanRestricted => false;

public event Action<Player> OAPDMLNMAPC {
add {
		}
remove {
		}
}

		public bool IDDJEIBPLOC(GHCICEFBOGM AEBIACPKIKH, CIKFJOFIPLL KLBONOOHBND, Player MBFJFNELEGB)
		{
			return false;
		}

		public void JHBJHMPDOPD(ScreenPlayerSteeringController COEKBMDIOPJ, object IALNODEHBNN, MDICNIOLNIE LAGADKBKLAD)
		{
		}

		public void OHCCLMDHOKB(object IALNODEHBNN)
		{
		}

		private void AIAIIKHMHGJ(Player EKOFNPFCLMO)
		{
		}

		public void IHBMMHDKLMJ(object IALNODEHBNN, StackedUIBase MKKCBNBNGEM, MenuProjector MKKCNJHGIGA, Action NLIHNAMNCHH = null, Action HPKGEKLIFMF = null, bool ALBFLJNCMAD = false)
		{
		}

		private void IHBMMHDKLMJ(object IALNODEHBNN, StackedUIBase MKKCBNBNGEM, MenuProjector MKKCNJHGIGA, float FFOLAIDDHGI, float GGLNKLDABOO, Action NLIHNAMNCHH, Action HPKGEKLIFMF, bool ALBFLJNCMAD)
		{
		}

		public void GCBIDHEOONP(object IALNODEHBNN, Action HPKGEKLIFMF)
		{
		}

		public void HOJOPNOJLMC(object IALNODEHBNN, Canvas NGHMKGJCELB, Action NLIHNAMNCHH, Action HPKGEKLIFMF)
		{
		}

		public void KPNKPLHOPNA()
		{
		}

		public void KGGBJMFJOPA(object IALNODEHBNN)
		{
		}

		public bool OOGFPJBLJDA(out CIDCICNCOHB OLFJAIPBLID)
		{
			OLFJAIPBLID = null;
			return false;
		}

		public object IMNAOMGGNIK()
		{
			return null;
		}

		public bool CHCLHBHIPND()
		{
			return this.isThirdPersonRequested;
		}

		public void ILGJKHNKCHK()
		{
		}

		public void JCDGGPLINEN()
		{
		}

		public void BKLOPFPCLEB(DrawingSurface FAMNKOFMEAL)
		{
		}

		public void GOMFJGCNDMJ()
		{
		}

		public bool JPEPLEPOKPP(out DrawingSurface FAMNKOFMEAL)
		{
			FAMNKOFMEAL = null;
			return false;
		}

		public override void IHEKMEOIBOI(LocalPlayerController HOIIBHDNAJI)
		{
		}

		public override void FCCAJFNJBLH()
		{
		}

		public override void LIDHELJBOFC()
		{
		}

		private void GOKMPELCDBH()
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

		public override void HADBNNANGFK()
		{
		}

		public override void NMJKIJBBDKO(Player MHCOBIPKGNI)
		{
		}

		public override void JMHMIEACMHH(LoginScreenSpawnPoint FPDAFHFAEIC)
		{
		}

		public override Player JPAGHPDCEFL(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
		{
			return null;
		}

		public override void PPGOLHLBGGH()
		{
		}

		public void BPHAODMFAKE(object IALNODEHBNN)
		{
		}

		public void AFNAMNNELBK(object IALNODEHBNN)
		{
		}

		public void KECCMAFJJAM(object IALNODEHBNN)
		{
		}

		public void JNDGNEOFPNI(object IALNODEHBNN)
		{
		}

		public void PGNAGAOLNIF(object IALNODEHBNN)
		{
		}

		public void KAEBDOLHAPO(object IALNODEHBNN)
		{
		}

		public bool JMALLLCCFLG(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return false;
		}

		public void MAPOFFBFAOC(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, object IALNODEHBNN)
		{
		}

		public void KHKFOPFMAIE(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, object IALNODEHBNN)
		{
		}

		public void JAFJICPHHMN(object IALNODEHBNN)
		{
		}

		public void LDKEIBCLHMJ(object IALNODEHBNN)
		{
		}

		public bool LAKAKHPMDFA(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return false;
		}

		public void GDPBNBPOEJH(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, object IALNODEHBNN)
		{
		}

		public void FHBNNPGJDKE(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, object IALNODEHBNN)
		{
		}

		public void FHBNNPGJDKE(object IALNODEHBNN)
		{
		}

		public void NDDJCMFGIBH(object IALNODEHBNN)
		{
		}

		public void CJPCDNAJHLF(object IALNODEHBNN)
		{
		}

		public void ICGJJFCLJCE(object IALNODEHBNN)
		{
		}

		public void BHLPLNGGIPB(object IALNODEHBNN)
		{
		}

		public void GLJPCEECDGK(object IALNODEHBNN)
		{
		}

		public void JCCKLFCFOOH(object IALNODEHBNN)
		{
		}

		public void EOKGNFJFEFL(object IALNODEHBNN)
		{
		}

		public void OOGEHPKJLFP(object IALNODEHBNN)
		{
		}

		public void DOMDOMBICAO(object IALNODEHBNN)
		{
		}

		public void NOPIMMFDFHK(object IALNODEHBNN)
		{
		}

		public void GHLBKPENPBF(object IALNODEHBNN)
		{
		}

		public void JMDKGMCLMAG(object IALNODEHBNN)
		{
		}

		public void AIJHJNNDBHA(object IALNODEHBNN)
		{
		}

		public void JNMHKPMIOHL(object IALNODEHBNN)
		{
		}

		private void HBIFKDJKFHO(ScreenPlayerModeConfigBase[] JJLGBIGENJK)
		{
		}

		private void GHKJEEJOLKJ()
		{
		}

		public void FMDKMEMMBPN(DBLFNBLEEAO IMPDHJBOLBF, List<MJEKKBPKMCB> BGHDDLFKNKF, object IALNODEHBNN)
		{
		}

		public void JGFCHBJJJHD(DBLFNBLEEAO IMPDHJBOLBF, List<MJEKKBPKMCB> BGHDDLFKNKF, object IALNODEHBNN)
		{
		}

		private void KEPCPNHOLEI()
		{
		}

		public void NIENMLMOILC(object IALNODEHBNN)
		{
		}

		public void MFGBJINHNIH(object IALNODEHBNN)
		{
		}

		internal NEIMPKOMKGL HCNCMHMKDNM(DBLFNBLEEAO NIFOGEBEDNG)
		{
			return null;
		}

		private void EBICOLNLMBC()
		{
		}

		private void CLBHPIDGGGE()
		{
		}

		private void LEBGONOKHEF()
		{
		}

		private void BHFCBJFJFEH(PlayerHand PMNLJGLDMJN, Tool IEGMBEPJMGC)
		{
		}

		private void ADJPCIECDLH(Tool IEGMBEPJMGC)
		{
		}

		private void HDJJJKHFMGD()
		{
		}

		private void GGLOHDGKMFG()
		{
		}

		private void HCLGAACIBKC(Player EKOFNPFCLMO, Camera GAPPCJHIBEK, ScreenHUD JOGBBEAGAAN)
		{
		}

		private void GGLOGJANACC(Player EKOFNPFCLMO)
		{
		}

		private void OCPGEBHECOC(Player EKOFNPFCLMO, Camera GAPPCJHIBEK)
		{
		}

		private bool GHLHLLHMJCF(Collider ADMCDJKKCIA)
		{
			return false;
		}

		public override void KBHEHEFFOKF(GNEENOANCIM.ABLDJLKKHJP NHJPBHJLFOD)
		{
		}

		public override void KPFCKHNHGPC(GNEENOANCIM.ABLDJLKKHJP NHJPBHJLFOD)
		{
		}

		public bool JPMALGIFINJ(LMFLCFFHNOF PCNPMPMHGHF, PlayerHand.ICBKGDOJNDN CPPLPMHNHMJ, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN = GNEENOANCIM.IMNMCGGINJG.PrecisePhase)
		{
			return false;
		}

		public bool NHANKJIPLCI(Tool IEGMBEPJMGC, float BANFMEKJLPI)
		{
			return false;
		}

		public bool NHANKJIPLCI(Tool IEGMBEPJMGC, float BANFMEKJLPI, Vector3 MEBJBANMPLK)
		{
			return false;
		}

		public bool NHANKJIPLCI(Tool IEGMBEPJMGC, Vector3 MCBCBMFBKCA)
		{
			return false;
		}

		public bool NHANKJIPLCI(Tool IEGMBEPJMGC, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK)
		{
			return false;
		}

		public Vector3 BCHENOGAMHM(PlayerHand BJBDPCNDCLN)
		{
			return default;
		}

		private void DHAHBPCPDMK(Player EKOFNPFCLMO, AECAHLPIFOC KAEDAICECGN)
		{
		}

		private void ODODHOAIIAC(Player EKOFNPFCLMO, ScreenHUD JOGBBEAGAAN, AECAHLPIFOC KAEDAICECGN)
		{
		}

		private void EAKILJEMILG(ScreenHUD JOGBBEAGAAN, AECAHLPIFOC KAEDAICECGN)
		{
		}

		private void PDAPACGLCJL()
		{
		}

		private void KOGEEAGDLPG()
		{
		}

		private void LAELCNBNDND()
		{
		}

		private IEnumerator<EGGPGCCKPCO> KEHHNCOHJDE(Player EKOFNPFCLMO)
		{
			return null;
		}

		private void HMIGLPHOLDG(PlayerHand PMNLJGLDMJN, Tool IEGMBEPJMGC)
		{
		}

		private void NJNPAIJEJPF(PlayerHand PMNLJGLDMJN, Tool IEGMBEPJMGC)
		{
		}

		private void MKAOCDPBMKP(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
		{
		}

		private void FCMFBLHFAAO(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
		{
		}

		[CompilerGenerated]
		private IEnumerator<EGGPGCCKPCO> FKAHPKOLCNM()
		{
			return null;
		}
	}
}
