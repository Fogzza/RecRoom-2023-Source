using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RRUI.Data;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecNet;
using RecRoom.Core;
using RecRoom.Core.Comfort;
using RecRoom.Inputs;
using UnityEngine;

public class SettingsModel : RRUIModel
{
	private sealed class LMECLOHCBFF
	{
		public WatchUI watchUI;

		internal void _003CRestorePurchases_003Eb__0()
		{
		}

		internal void _003CRestorePurchases_003Eb__1(string error)
		{
		}
	}

	private sealed class BLGLAKGEDEJ
	{
		public int cachedIndex;

		public SettingsModel _003C_003E4__this;

		internal bool _003CShowMobileNotificationsDialog_003Eb__1()
		{
			return false;
		}

		internal void _003CShowMobileNotificationsDialog_003Eb__2(bool value)
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct EBNPPOOHCIP : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public SettingsModel _003C_003E4__this;

		private DialogListModel _003C_003E7__wrap1;

		private TaskAwaiter<DHAPPKCJJCA> _003C_003Eu__1;

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

	private sealed class GOECKAPKOBA
	{
		public AECAHLPIFOC input;

		public string currentKey;

		public SettingsModel _003C_003E4__this;

		internal bool _003CShowScreenControlSchemesDialog_003Eb__0(ScreenPlayerActionInputMap scheme)
		{
			return false;
		}

		internal bool _003CShowScreenControlSchemesDialog_003Eb__1(ScreenPlayerActionInputMap scheme)
		{
			return false;
		}

		internal object _003CShowScreenControlSchemesDialog_003Eb__5()
		{
			return null;
		}

		internal void _003CShowScreenControlSchemesDialog_003Eb__6(object key)
		{
		}

		internal void _003CShowScreenControlSchemesDialog_003Eb__2(BaseDialogModel<DHAPPKCJJCA> dialog)
		{
		}
	}

	private sealed class OPDCHLANLBO
	{
		public AECAHLPIFOC input;

		public string currentKey;

		internal bool _003CGetBindingListUIElements_003Eb__0(ScreenPlayerActionInputMap scheme)
		{
			return false;
		}

		internal bool _003CGetBindingListUIElements_003Eb__1(ScreenPlayerActionInputMap scheme)
		{
			return false;
		}
	}

	private sealed class GLINLPBPMCC
	{
		public ScreenPlayerActionDefinitions.ScreenPlayerActionDefinition actionInputBinding;

		public Func<ScreenPlayerActionInputMap.ActionInputBinding, bool> _003C_003E9__2;

		internal bool _003CGetBindingListUIElements_003Eb__2(ScreenPlayerActionInputMap.ActionInputBinding binding)
		{
			return false;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct EMIJHIJBNCN : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public SettingsModel _003C_003E4__this;

		private TaskAwaiter<DHAPPKCJJCA> _003C_003Eu__1;

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

	private IILDCCEMGBA LCPOIILBNLD;

	private JNKNMMDAHCF DHCLACKALOF;

	private NNBAJLCGAOK JGEGKOOCOEH;

	private CGOPOAFDIDN FIJHCMLFKJH;

	private DPDBLMENBLF? LCCFBMMPLMH;

	private LAHBDKNMNHN GNOHIOHODHG;

	private MeasurePlayerHeightModel GLKBJPHLICF;

	private global::NCOKFFGPIJM<DHAPPKCJJCA> IDFNHNLJHKA;

	private PlatformNotificationPreferencesDTO PHPEJLGMHDJ;

	private List<PlatformNotificationCategoryConfigDTO> MIPIBPECBBL;

	private BaseDialogModel KJKMJMPOJLN;

	private BaseDialogModel CIKOILJCBKN;

public bool UsingGamepad
{
get 	{
		return false;
	}

}

public bool UsingKeyboardMouse
{
get 	{
		return false;
	}

}

public bool UsingTouch
{
get 	{
		return false;
	}

}

public bool SupportsAR
{
get 	{
		return false;
	}

}

public bool InScreensMode
{
get 	{
		return false;
	}

}

public bool InVRMode
{
get 	{
		return false;
	}

}

public bool IsJunior
{
get 	{
		return false;
	}

}

public PJCMOOCCFCF PlayerRoleDef
{
get 	{
		return null;
	}

}

public bool IsAccountCached
{
get 	{
		return false;
	}

}

public bool CanRestorePurchases
{
get 	{
		return false;
	}

}

public bool CanChangeControlScheme
{
get 	{
		return false;
	}

}

public bool HasMicrophoneAccess
{
get 	{
		return false;
	}

}

public bool AllowedToVoiceChat
{
get 	{
		return false;
	}

}

public bool IsPlatformCommunicationRestricted
{
get 	{
		return false;
	}

}

public bool IsVoiceChatBanned
{
get 	{
		return false;
	}

}

public bool CanRequestMicrophoneAccess
{
get 	{
		return false;
	}

}

public FOFOHMMFILG VoicesICanHear
{
get 	{
		return FOFOHMMFILG.None;
	}

set {
	}
}

public NOMDJBMGHMJ PitchModifier
{
get 	{
		return NOMDJBMGHMJ.LowPitch;
	}

set {
	}
}

public DPDBLMENBLF VoiceChat
{
get 	{
		return DPDBLMENBLF.Mute;
	}

set {
	}
}

public bool UseSystemMicrophone
{
get 	{
		return false;
	}

set {
	}
}

public float SfxVolume
{
get 	{
		return 0f;
	}

set {
	}
}

public bool VoiceVolumeOverriden
{
get 	{
		return false;
	}

}

public float VoiceVolume
{
get 	{
		return 0f;
	}

set {
	}
}

public float MusicVolume
{
get 	{
		return 0f;
	}

set {
	}
}

public float AmbienceVolume
{
get 	{
		return 0f;
	}

set {
	}
}

public bool SubtitlesEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool ShowVoiceLines
{
get 	{
		return false;
	}

set {
	}
}

public float CameraSensitivityMax
{
get 	{
		return 0f;
	}

}

public Vector2 CameraSensitivity
{
get 	{
		return default;
	}

set {
	}
}

public bool InvertCameraHorizontal
{
get 	{
		return false;
	}

set {
	}
}

public bool InvertCameraVertical
{
get 	{
		return false;
	}

set {
	}
}

public bool ScreensSeatCameraRecenteringEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool CameraAccelerationGamepad
{
get 	{
		return false;
	}

set {
	}
}

public float ScreensHeadBobAmount
{
get 	{
		return 0f;
	}

set {
	}
}

public bool CanUseStreamingCamera
{
get 	{
		return false;
	}

}

public bool StreamingCamera
{
get 	{
		return false;
	}

set {
	}
}

public bool CanUseNewHomeUI
{
get 	{
		return false;
	}

}

public bool ScreensMinimalHUD
{
get 	{
		return false;
	}

set {
	}
}

public bool ShowNames
{
get 	{
		return false;
	}

set {
	}
}

public bool ShowRecRoomPlusNametagSurfacing
{
get 	{
		return false;
	}

set {
	}
}

public bool ShowOwnNameInThirdPerson
{
get 	{
		return false;
	}

set {
	}
}

public bool ScreensVsyncEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool QualitySettingsHardwareOverriden
{
get 	{
		return false;
	}

}

public GHCCKFEJDOA QualitySetting
{
get 	{
		return GHCCKFEJDOA.Fastest;
	}

set {
	}
}

public ENNMDECGGLP.AIOBJLFJIMF RRUITheme
{
get 	{
		return ENNMDECGGLP.AIOBJLFJIMF.Light;
	}

set {
	}
}

public bool EnableWatchNotifications
{
get 	{
		return false;
	}

set {
	}
}

public bool SendFriendOnlineStatus
{
get 	{
		return false;
	}

set {
	}
}

public bool ReceiveFriendOnlineStatus
{
get 	{
		return false;
	}

set {
	}
}

public bool DisableGiftNotifications
{
get 	{
		return false;
	}

set {
	}
}

public JFAAGFOLICM AppearOnlineTo
{
get 	{
		return JFAAGFOLICM.Public;
	}

set {
	}
}

public bool AutoSprint
{
get 	{
		return false;
	}

set {
	}
}

public KFIAEIHFGII ManualSprintInputMode
{
get 	{
		return KFIAEIHFGII.Hold;
	}

set {
	}
}

public bool ThirdPersonOptIn
{
get 	{
		return false;
	}

set {
	}
}

public bool AutoFire
{
get 	{
		return false;
	}

set {
	}
}

public bool ScreensMotionControls
{
get 	{
		return false;
	}

set {
	}
}

public bool CanChangeMovementMode
{
get 	{
		return false;
	}

}

public string ScreensControlSchemeKey
{
get 	{
		return null;
	}

set {
	}
}

public bool ShowPerHandInteractControlsTouch
{
get 	{
		return false;
	}

set {
	}
}

public bool FPSMonitor
{
get 	{
		return false;
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

public ONCCFHECNKK IgnoreBubble
{
get 	{
		return ONCCFHECNKK.Disabled;
	}

set {
	}
}

public PINLDPIKLLE PersonalSpaceBubble
{
get 	{
		return PINLDPIKLLE.Small;
	}

set {
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

public bool SiloedMatchmaking
{
get 	{
		return false;
	}

set {
	}
}

public bool VRUsesRoomCalibration
{
get 	{
		return false;
	}

}

public float MeasuredPlayerHeightMeters
{
get 	{
		return 0f;
	}

}

public float MaxPlayerHeightMeters
{
get 	{
		return 0f;
	}

}

public float MinPlayerHeightMeters
{
get 	{
		return 0f;
	}

}

public bool VRSeatedMode
{
get 	{
		return false;
	}

set {
	}
}

public bool VRStabilizeHandsEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRThumbstickScrolling
{
get 	{
		return false;
	}

set {
	}
}

public bool RoomSupportsWalkAndTeleport
{
get 	{
		return false;
	}

}

public NLOBDKDEACH VRMovementMode
{
get 	{
		return NLOBDKDEACH.TELEPORT;
	}

set {
	}
}

public NAODPIKMKHK VRThumbstickWalkMode
{
get 	{
		return NAODPIKMKHK.OFF;
	}

set {
	}
}

public GOIFPBJAGOG VRWalkHandMode
{
get 	{
		return (GOIFPBJAGOG)0;
	}

set {
	}
}

public bool VRStrafeModeAllowed
{
get 	{
		return false;
	}

}

public bool VRStrafe
{
get 	{
		return false;
	}

set {
	}
}

public BMKCHGCBDCO VRVehicleInputMethod
{
get 	{
		return BMKCHGCBDCO.MOTION_INPUT;
	}

set {
	}
}

public BOLFHKKILPB ExpressoMenuHandedness
{
get 	{
		return BOLFHKKILPB.LEFT;
	}

set {
	}
}

public bool VRSwipeRotateEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRMotionTurnEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRTouchpadTeleportSupported
{
get 	{
		return false;
	}

}

public bool VRTouchpadTeleportEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRSwipeRotateSnap
{
get 	{
		return false;
	}

set {
	}
}

public byte VRSwipeRotateSnapIncrement
{
get 	{
		return 0;
	}

set {
	}
}

public JIFNNGHEDND VRContinuousRotationMode
{
get 	{
		return JIFNNGHEDND.DISABLED;
	}

set {
	}
}

public bool VRTapToOpenWatch
{
get 	{
		return false;
	}

set {
	}
}

public bool VRTapToOpenMakerPen
{
get 	{
		return false;
	}

set {
	}
}

public bool VRShareCameraGestureEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRMuteWithHandEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRLegacyFlyingEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRTouchShowTactileCursor
{
get 	{
		return false;
	}

set {
	}
}

public bool VRTouchShowTactileGrid
{
get 	{
		return false;
	}

set {
	}
}

public bool VRTouchTreatCancelAsClick
{
get 	{
		return false;
	}

set {
	}
}

public bool VRNaturalGrip
{
get 	{
		return false;
	}

set {
	}
}

public bool VRExteriorScrollbar
{
get 	{
		return false;
	}

set {
	}
}

public MFEHGEJOLDL VRScrollbarSidePreference
{
get 	{
		return MFEHGEJOLDL.Left;
	}

set {
	}
}

public MFEHGEJOLDL VRMakerPenScrollbarSidePreference
{
get 	{
		return MFEHGEJOLDL.Left;
	}

set {
	}
}

public MAKDBNOCAAD VRWatchMenuSize
{
get 	{
		return MAKDBNOCAAD.Small;
	}

set {
	}
}

public bool VRInteractLabels
{
get 	{
		return false;
	}

set {
	}
}

public bool VRShowRoomCenter
{
get 	{
		return false;
	}

set {
	}
}

public bool VRComfortEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool VRComfortWalk
{
get 	{
		return false;
	}

set {
	}
}

public bool VRComfortSprint
{
get 	{
		return false;
	}

set {
	}
}

public bool VRComfortRotate
{
get 	{
		return false;
	}

set {
	}
}

public bool VRComfortClimb
{
get 	{
		return false;
	}

set {
	}
}

public bool VRComfortFly
{
get 	{
		return false;
	}

set {
	}
}

public bool VRComfortVehicles
{
get 	{
		return false;
	}

set {
	}
}

public DPIDGEICOAI VRComfortTeleport
{
get 	{
		return DPIDGEICOAI.OFF;
	}

set {
	}
}

public DPIDGEICOAI VRFallComfortMode
{
get 	{
		return DPIDGEICOAI.OFF;
	}

set {
	}
}

public DPIDGEICOAI VRForcesComfortMode
{
get 	{
		return DPIDGEICOAI.OFF;
	}

set {
	}
}

public VRLocomotionComfortMode.HIBCGAAJJPA VRComfortMode
{
get 	{
		return VRLocomotionComfortMode.HIBCGAAJJPA.Off;
	}

set {
	}
}

public VRLocomotionComfortMode.OACKHDNDIMI VRComfortTechnique
{
get 	{
		return VRLocomotionComfortMode.OACKHDNDIMI.Screen;
	}

set {
	}
}

public float VRComfortEffectSize
{
get 	{
		return 0f;
	}

set {
	}
}

public float AutosaveInterval
{
get 	{
		return 0f;
	}

set {
	}
}

protected override bool GIHBNOOCJDD
{
get 	{
		return false;
	}

}

	private void CGIHMCCGNGM()
	{
	}

	private void LOGCDMFMOCI(JDCIJIEOFOL EKOFNPFCLMO)
	{
	}

	private void CHAMFLGOACB(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
	{
	}

	private void DOFPHAFNJFA()
	{
	}

	private void EFPDHIAMJJE()
	{
	}

	protected override void DHHOMFCCFKP()
	{
	}

	protected override void DCEBFEOEHGG()
	{
	}

	protected override void KPOHBHPPGBM()
	{
	}

	protected override void LPBNNNGFPIF()
	{
	}

	protected override LAHBDKNMNHN KANNLKCLIOF()
	{
		return null;
	}

	public LAHBDKNMNHN SignOut()
	{
		return null;
	}

	public global::NCOKFFGPIJM<bool> GetAvoidJuniors()
	{
		return null;
	}

	public LAHBDKNMNHN ToggleAvoidJuniors(bool GLJCGBGNMJF)
	{
		return null;
	}

	public LAHBDKNMNHN RestorePurchases()
	{
		return null;
	}

	public static LAHBDKNMNHN RestorePurchases(WatchUI CPELKAGLFFJ)
	{
		return null;
	}

	public bool IsWatchNotificationCategoryEnabled(BJCIKFCDBFN.JGBHDFADCMI JNKJFJLJKNJ)
	{
		return false;
	}

	public void SetWatchNotificationCategory(BJCIKFCDBFN.JGBHDFADCMI JNKJFJLJKNJ, bool IPMIIEAGJKC)
	{
	}

	public global::ONFKCPBPLPM<PlatformNotificationPreferencesDTO, List<PlatformNotificationCategoryConfigDTO>> GetPlatformNotifications()
	{
		return null;
	}

	public void ShowMobileNotificationsDialog()
	{
	}

	public void MeasureHeight(Route FIMIDHBEOEL)
	{
	}

	public void ShowScreenControlSchemesDialog()
	{
	}

	private List<DGMPBIPKJEB> LKIKGEMGMDP()
	{
		return null;
	}

	private void PEFMCEDBJOC()
	{
	}

	public void ViewControls()
	{
	}

	[CompilerGenerated]
	private void OELPJMFEBKK()
	{
	}

	[CompilerGenerated]
	private void PNKLHMIFDMC()
	{
	}

	[CompilerGenerated]
	private void EBAJOJCAMPG()
	{
	}

	[CompilerGenerated]
	private void KNGANEJBAML(string NLJOHEKGNDH)
	{
	}

	[CompilerGenerated]
	private DHAPPKCJJCA GBFLEEDMKNI(Tuple<PlatformNotificationPreferencesDTO, List<PlatformNotificationCategoryConfigDTO>> JBMINGMBHOH)
	{
		return null;
	}

	[CompilerGenerated]
	private void JDCBDOODKFD()
	{
	}

	[CompilerGenerated]
	private void IIDODBDLNOP()
	{
	}

	[CompilerGenerated]
	private void DBAFGHOPJHG(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
	{
	}

	[CompilerGenerated]
	private void AHJEDOFFFIP(BaseDialogModel<AMFPEDOFIGE> GDMKJGAKCND)
	{
	}
}
