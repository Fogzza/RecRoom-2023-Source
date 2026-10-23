using System;
using System.Runtime.CompilerServices;
using RRUI;
using RRUI.Data;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom;
using RecRoom.Core.Comfort;
using RecRoom.Inputs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsModelController : ModelController<SettingsModel>
{
	[Serializable]
	private class ShowIfARImpl : HideableControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfGraphicsLockedImpl : HideableControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoRegisteredCachedAccountImpl : HideableControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfControlSchemeCantBeChangedImpl : HideableControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class InvertCameraToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private bool Horizontal;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class CameraAccelerationToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableSeatRecenteringToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class StreamingCameraToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRWalkingToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable lockedLabel;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class StrafeToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class TouchToTeleportToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRShowTouchGridToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRHideTouchCursorToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRTouchClickOnCancelToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VignetteToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VignetteSpecificToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		private enum IDLEOECHIPH : byte
		{
			Walk = 0,
			Sprint = 1,
			Rotate = 2,
			Climb = 3,
			Fly = 4,
			Vehicle = 5
		}

		[SerializeField]
		private IDLEOECHIPH Type;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class SystemMicrophoneToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableInteractLabelsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ThumbstickScrollingToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableGripRotationToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableThumbstickRotationToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableInstantThumbstickRotationToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableTapWatchToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class TapToOpenMakerPenToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableShareCamGestureToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableHandMuteToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnablePlayAreaCenterToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableHandStabilizationToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableLegacyFlyingToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class NaturalGripToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRExteriorScrollbarsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void BNFEJGHHHLO()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class EnableDarkModeToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableHideHudToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableSubtitlesToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnablePlayerNamesToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableOwnPlayerNameToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class RecRoomPlusNametagDisplayToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableVoiceLinesToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class WatchNotificationsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class SendFriendNotifToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ReceiveFriendNotifToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class NotifCategoryToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private BJCIKFCDBFN.JGBHDFADCMI category;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class GiftNotifsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class MotionControlsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class AutoFireToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class AutoSprintToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ShowSprintModeSelectionButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		[SerializeField]
		private TextMeshProUGUI text;

		private DHAPPKCJJCA dialogData;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}

		[CompilerGenerated]
		private object AKCPGOLIFLC()
		{
			return null;
		}

		[CompilerGenerated]
		private void FANEDAKPLCG(object IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class ThirdPersonOptInToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class PerHandInteractControlsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ModeratorDisplayToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class FPSMonitorToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class IgnoreBubbleToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private ONCCFHECNKK Default;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnablePersonalSpaceBubbleFriendsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class EnableVSyncToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class AutosaveToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private int defaultAutosaveIntervalMinutes;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class AvoidJuniorsToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}

		[CompilerGenerated]
		private void JGDBHMOFKOH(bool GLJCGBGNMJF)
		{
		}
	}

	[Serializable]
	private class SiloMatchmakingToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		private const string SILOED_MATCHMAKING_XBOX_CONFIRM_PROMPT_TITLE = "Matching only on Xbox Live";

		private const string SILOED_MATCHMAKING_PS_CONFIRM_PROMPT_TITLE = "Matching only on PlayStation™Netwo";

		private const string SILOED_MATCHMAKING_XBOX_CONFIRM_PROMPT_BODY = "Rec Room friends on Xbox Live who have not checked this or are on another platform will become unreachable. You will NOT be able to play with them.";

		private const string SILOED_MATCHMAKING_PS_CONFIRM_PROMPT_BODY = "Rec Room friends on PlayStation™Network who have not checked this or are on another platform will become unreachable. You will NOT be able to play with the";

		private const string SILOED_MATCHMAKING_XBOX_SETTING_UPDATED_TITLE = "Matching only on Xbox Live";

		private const string SILOED_MATCHMAKING_PS_SETTING_UPDATED_TITLE = "Matching only on PlayStation™Netwo";

		private const string SILOED_MATCHMAKING_SETTING_UPDATED_BODY = "You need to quit and restart Rec Room for this change to take effect.";

		protected override void NGFFCLPHKJN()
		{
		}

		private void MOEFEIDKDDI(bool IPMIIEAGJKC)
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}

		[CompilerGenerated]
		private void OKKNKJGDLJE(HGKINAOMNIF MLDANHIGANI)
		{
		}
	}

	[Serializable]
	private class VRComfortEffectSizeSliderImpl : SliderControllerImpl<SettingsModel>
	{
		protected override void IHEKMEOIBOI()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float GADDGJANIGG)
		{
		}
	}

	[Serializable]
	private class CameraVerticalSensitivitySliderImpl : SliderControllerImpl<SettingsModel>
	{
		private enum MMJNJJECDEB : byte
		{
			OVERALL = 0,
			X = 1,
			Y = 2
		}

		[SerializeField]
		private MMJNJJECDEB axis;

		private bool ignoreSliderValueChanged;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class HeadBobSliderImpl : SliderControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float GADDGJANIGG)
		{
		}
	}

	[Serializable]
	private class DeveloperDisplaySliderImpl : SliderControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class AutosaveFrequencySliderImpl : SliderControllerImpl<SettingsModel>
	{
		[SerializeField]
		private byte[] SliderValuesInMinutes;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class VolumeSliderImpl : SliderControllerImpl<SettingsModel>
	{
		private enum OMDMOMKFNOE : byte
		{
			Overall = 0,
			Voices = 1,
			SFX = 2,
			Music = 3,
			Ambience = 4
		}

		[SerializeField]
		private OMDMOMKFNOE Type;

		[SerializeField]
		private Hideable overridenLabel;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float GADDGJANIGG)
		{
		}
	}

	[Serializable]
	private class VoicesICanHearSliderImpl : SliderControllerImpl<SettingsModel>
	{
		[SerializeField]
		private FOFOHMMFILG[] sliderMapping;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class AppearOnlineToSliderImpl : SliderControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class VRScrollSidePreferenceSliderImpl : SliderControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class VRMakerPenScrollSidePreferenceSliderImpl : SliderControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class VRWatchMenuSizePreferenceSliderImpl : SliderControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void FHPNDLFMODO(float IPMIIEAGJKC)
		{
		}
	}

	[Serializable]
	private class IgnoreBubbleRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private ONCCFHECNKK Size;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class PersonalSpaceBubbleRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private PINLDPIKLLE Size;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class GraphicsQualityToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[Flags]
		private enum GPBCCCBPODH
		{
			ANDROID = 1,
			IOS = 2,
			EDITOR = 4,
			PC_AND_PCVR = 8
		}

		[SerializeField]
		private Hideable radioOptionHideable;

		[SerializeField]
		private GPBCCCBPODH supportedPlatforms;

		[SerializeField]
		private GHCCKFEJDOA androidQualityMapping;

		[SerializeField]
		private GHCCKFEJDOA iosQualityMapping;

		[SerializeField]
		private GHCCKFEJDOA defaultQualityMapping;

		private GHCCKFEJDOA QualitySettingForPlatform => GHCCKFEJDOA.Fastest;

		private bool ShowOptionForPlatform => false;

		private bool NCOBMGFDCJI(GPBCCCBPODH PANELIGGJGM)
		{
			return false;
		}

		private bool NLDPJHOAHNP(GPBCCCBPODH PANELIGGJGM)
		{
			return false;
		}

		private bool PCPAIKGMMND(GPBCCCBPODH PANELIGGJGM)
		{
			return false;
		}

		private bool PCALJGMKNFI(GPBCCCBPODH PANELIGGJGM)
		{
			return false;
		}

		private bool DGPIGAJABCK(GPBCCCBPODH PANELIGGJGM)
		{
			return false;
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRSeatedModeRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private bool IsSeated;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRWalkModeRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private NAODPIKMKHK ThumbstickWalkMode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRWalkingHandRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private GOIFPBJAGOG HandMode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRVehicleInputRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private BMKCHGCBDCO InputMethod;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ExpressoMenuHandednessRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private BOLFHKKILPB Handedness;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class GripRotationRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private JIFNNGHEDND RotationMode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ThumbstickRotationModeRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		private enum NGBBGFJGBFK : byte
		{
			Off = 0,
			Smooth = 1,
			Snap_Custom = 2,
			Snap_45 = 3,
			Snap_90 = 4
		}

		[SerializeField]
		private NGBBGFJGBFK Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ThumbstickRotationIncrementRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private byte SnapRotation;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRComfortModeRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private VRLocomotionComfortMode.HIBCGAAJJPA Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRComfortTechniqueRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private VRLocomotionComfortMode.OACKHDNDIMI Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRMovementModeRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private NLOBDKDEACH Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRComfortVignetteTeleportRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private DPIDGEICOAI Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRComfortVignetteFallRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private DPIDGEICOAI Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRComfortVignetteForcesRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private DPIDGEICOAI Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VoiceChatRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private DPDBLMENBLF Mode;

		[SerializeField]
		private Hideable playerRoleMutedLabel;

		[SerializeField]
		private Hideable deviceNeedsPermissionsLabel;

		[SerializeField]
		private Hideable platformMuted;

		[SerializeField]
		private Hideable recRoomMuted;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VoicePitchRadioToggleImpl : ToggleControllerImpl<SettingsModel>
	{
		[SerializeField]
		private NOMDJBMGHMJ Mode;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ForgetAccountButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		private sealed class EGBLKNENJEF
		{
			public ForgetAccountButtonImpl _003C_003E4__this;

			public BaseDialogModel<IPGOOJIFBAB> dialogModel;

			internal void _003CShowConfirmationDialog_003Eg__OnConfirm_007C0()
			{
			}

			internal void _003CShowConfirmationDialog_003Eb__2(string error)
			{
			}

			internal void _003CShowConfirmationDialog_003Eb__3()
			{
			}

			internal void _003CShowConfirmationDialog_003Eb__1(BaseDialogModel<IPGOOJIFBAB> dialog)
			{
			}
		}

		[SerializeField]
		private string ConfirmationDialogText;

		[SerializeField]
		private Sprite confirmationDialogImage;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}

		private void NPMFLBCALDE()
		{
		}
	}

	[Serializable]
	private class RestorePurchaseButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ViewControlsButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ShowHelpPageButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ShowIOSControllerHelpPageButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		private const string IOS_CONTROLLER_HELP_URL = "https://support.apple.com/en-us/HT210414";

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ShowDiagnosticsButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		[SerializeField]
		private PsvrDiagnosticsDialog psvrDiagnosticsDialog;

		private LHMPPJKHCJG _player;

		private LHMPPJKHCJG Player => null;

		protected override void IHEKMEOIBOI()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class RecalibrateVRButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Hideable hideable;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class MeasureHeightButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		[SerializeField]
		private Route measureHeightRoute;

		protected override void BNFEJGHHHLO()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class PlatformNotificationButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		protected override void BNFEJGHHHLO()
		{
		}

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class ScreenControlSchemeButtonImpl : ButtonControllerImpl<SettingsModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class VRHeightTextImpl : TextControllerImpl<SettingsModel>
	{
		private float lastKnownPlayerHeight;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class BindingLabelTextImpl : TextControllerImpl<SettingsModel>
	{
		private sealed class OJAGBDJIECC
		{
			public AECAHLPIFOC input;

			public string currentKey;

			internal bool _003COnModelChanged_003Eb__0(ScreenPlayerActionInputMap scheme)
			{
				return false;
			}

			internal bool _003COnModelChanged_003Eb__1(ScreenPlayerActionInputMap scheme)
			{
				return false;
			}
		}

		[SerializeField]
		private KCPKKLFAKBP gamepadInputType;

		[SerializeField]
		private Image icon;

		protected override void NGFFCLPHKJN()
		{
		}
	}
}
