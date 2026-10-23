using RecRoom.Audio;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAudio : MonoBehaviour
{
	public const int DEFAULT_PLAYER_VOICE_AUDIO_ROLLOFF_PRIORITY = 1000;

	[SerializeField]
	private RecRoomAudioClip partyInvite;

	[SerializeField]
	private RecRoomAudioClip handClap;

	[SerializeField]
	private RecRoomAudioClip fistBump;

	[SerializeField]
	private RecRoomAudioClip stopGestureCharge;

	[SerializeField]
	private RecRoomAudioClip stopGestureSuccess;

	[SerializeField]
	private RecRoomAudioClip cheerGestureCharge;

	[SerializeField]
	private RecRoomAudioClip cheerGestureSuccess;

	[SerializeField]
	private RecRoomAudioClip levelUp;

	[SerializeField]
	private RecRoomAudioClip cheered;

	[SerializeField]
	private RecRoomAudioClip objectiveComplete;

	[SerializeField]
	private RecRoomAudioClip pushToTalkOn;

	[SerializeField]
	private RecRoomAudioClip pushToTalkOff;

	[SerializeField]
	private RecRoomAudioClip baseTeleport;

	[SerializeField]
	private RecRoomAudioClip[] teleportSounds;

	[SerializeField]
	private RecRoomAudioClip[] defaultWalkFootstepSounds;

	[SerializeField]
	private RecRoomAudioClip sprintHeartbeatUp;

	[SerializeField]
	private RecRoomAudioClip sprintHeartbeatDown;

	[SerializeField]
	private RecRoomAudioClip clamberSFX;

	[SerializeField]
	private RecRoomAudioClip jumpSFX;

	[SerializeField]
	private RecRoomAudioClip landSFX;

	[SerializeField]
	private float jumpFootstepAudio;

	[SerializeField]
	private float landFootstepAudio;

	[SerializeField]
	private float getUpFailedFootstepAudio;

	[SerializeField]
	private RecRoomAudioClip[] defaultProneStepSounds;

	[SerializeField]
	private RecRoomAudioClip transitionStandToCrouch;

	[SerializeField]
	private RecRoomAudioClip transitionStandToProne;

	[SerializeField]
	private RecRoomAudioClip transitionCrouchToStand;

	[SerializeField]
	private RecRoomAudioClip transitionCrouchToProne;

	[SerializeField]
	private RecRoomAudioClip transitionProneToStand;

	[SerializeField]
	private RecRoomAudioClip transitionProneToCrouch;

	[SerializeField]
	private RecRoomAudioClip rotateLeft;

	[SerializeField]
	private Vector3 rotateLeftHeadRelativePosition;

	[SerializeField]
	private RecRoomAudioClip rotateRight;

	[SerializeField]
	private Vector3 rotateRightHeadRelativePosition;

	[SerializeField]
	private RecRoomAudioClip rotate180;

	[SerializeField]
	private Vector3 rotate180HeadRelativePosition;

	[SerializeField]
	private RecRoomAudioClip transitionStandToSit;

	[SerializeField]
	private RecRoomAudioClip transitionCrouchToSit;

	[SerializeField]
	private RecRoomAudioClip transitionProneToSit;

	[SerializeField]
	private RecRoomAudioClip transitionSitToStand;

	[SerializeField]
	private RecRoomAudioClip transitionChangeSeats;

	[SerializeField]
	private RecRoomAudioClip emoteUp;

	[SerializeField]
	private RecRoomAudioClip emoteDown;

	[SerializeField]
	private RecRoomAudioClip emoteLeft;

	[SerializeField]
	private RecRoomAudioClip emoteRight;

	[SerializeField]
	private float radioSpatialBlend;

	[SerializeField]
	private Player player;

	private global::AFHOAHNAMGF<AudioRolloff> FLAAGNHKJGE;

	private static RecRoomAudioClip[] PBLPIEPGNIJ;

	private static RecRoomAudioClip[] HLCGCAEHMNF;

	private bool GPCNBGBODAF;

public static RecRoomAudioClip[] CustomTeleportSounds
{
get 	{
		return null;
	}

set {
	}
}

public static RecRoomAudioClip[] CustomWalkFootstepSounds
{
get 	{
		return null;
	}

set {
	}
}

public bool IsRadioVoiceEnabled
{
get 	{
		return false;
	}

private set {
	}
}

public AudioRolloff CurrentAudioRolloff
{
get 	{
		return null;
	}

}

	private void Start()
	{
	}

	public void OnTeleport()
	{
	}

	public void OnLedgeClimb()
	{
	}

	public void OnJump()
	{
	}

	public void OnLand()
	{
	}

	public void OnGetUpFailed()
	{
	}

	public void OnLocomotionStateTransition(FCANHOEFNGD JOFPPIPFGKP)
	{
	}

	private RecRoomAudioClip CKOJIJPBGMM(FCANHOEFNGD JOFPPIPFGKP)
	{
		return null;
	}

	public void OnLevelUp()
	{
	}

	public void OnCheered()
	{
	}

	public void OnObjectiveComplete()
	{
	}

	public void OnInPlaceRotateLeft()
	{
	}

	public void OnInPlaceRotateRight()
	{
	}

	public void OnInPlaceRotate180()
	{
	}

	public void OnPartyInvite()
	{
	}

	public void PlayLocalFootstepAudio(float COFONCKAJCK, bool ECKMAMKFGPL = true)
	{
	}

	public void PlayRemoteFootstepAudio(float COFONCKAJCK, bool ECKMAMKFGPL = true)
	{
	}

	private RecRoomAudioClip[] PKFEOANAONF(bool ECKMAMKFGPL)
	{
		return null;
	}

	public void PlaySprintHeartbeatUpAudio(float COFONCKAJCK)
	{
	}

	public void PlaySprintHeartbeatDownAudio(float COFONCKAJCK)
	{
	}

	public void OnHighFive(Vector3 INLGLHIPOMC)
	{
	}

	public void OnFistBump(Vector3 INLGLHIPOMC)
	{
	}

	public SFXAudioSource OnStopGestureCharging(Vector3 INLGLHIPOMC)
	{
		return null;
	}

	public void OnStopGestureSuccess(Vector3 INLGLHIPOMC)
	{
	}

	public SFXAudioSource OnCheerGestureCharging(Vector3 INLGLHIPOMC)
	{
		return null;
	}

	public void OnCheerGestureSuccess(Vector3 INLGLHIPOMC)
	{
	}

	public void OnPushToTalk(bool POHIMIPCMKA)
	{
	}

	public void SetFilterType(NOMDJBMGHMJ HNGJGPJCNBJ)
	{
	}

	public void SetRadioVoice(bool ONKNGGKGPLH, float IGBJEKBBGKL = 1f)
	{
	}

	public void UpdateVoiceRolloffOverride(bool PJONNMOKJBN, float NMLBMMHEPGI, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void AddVoiceAudioRolloff(AudioRolloff EOFMABJLPAB, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveVoiceAudioRolloff(object IALNODEHBNN)
	{
	}

	private void GHFAGBPFLAG()
	{
	}

	public float GetVoiceLinearRolloffToLocalPlayerNormalized()
	{
		return 0f;
	}
}
