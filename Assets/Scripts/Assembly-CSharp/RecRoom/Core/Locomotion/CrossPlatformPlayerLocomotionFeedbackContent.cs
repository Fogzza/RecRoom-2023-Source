using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.Locomotion
{
	public class CrossPlatformPlayerLocomotionFeedbackContent : ScriptableObject
	{
		public AnimationCurve LocalPlayerFootstepAudioVolumeCurve;

		public AnimationCurve RemotePlayerFootstepAudioVolumeCurve;

		public AnimationCurve FootstepAudioFrequencyCurve;

		public AnimationCurve LocalPlayerProneStepAudioVolumeCurve;

		public AnimationCurve RemotePlayerProneStepAudioVolumeCurve;

		public AnimationCurve ProneStepAudioFrequencyCurve;

		public float SprintFootstepAudioVolumeScalar;

		public float SprintFootstepAudioFrequencyScalar;

		public float MaxDistanceForRemotePlayerFootstepAudio;

		public AnimationCurve HeartbeatAudioVolumeCurve;

		public AnimationCurve HeartbeatAudioPeriodCurve;

		public AnimationCurve HeartbeatAudioBeatSpacingCurve;

		public float HeartbeatAudioCurveDuration;

		public float HeartbeatAudioStartDelay;

		public float HeartbeatWindDownDuration;

		public RecRoomAudioClip SprintWindSfx;

		public AnimationCurve SprintWindLoopSfxVolumeCurve;

		public float SprintWindLoopSfxFadeDuration;

		public RecRoomAudioClip SprintSonicBoomSfx;

		public RecRoomAudioClip PushSfx;

		public RecRoomAudioClip SlideStartSfx;

		public RecRoomAudioClip SlideLoopSfx;

		public AnimationCurve SlideLoopSfxVolumeCurve;

		public float SlideLoopSfxFadeOutDuration;

		public RecRoomAudioClip WallRunStartSfx;

		public RecRoomAudioClip WallRunStopSfx;

		public RecRoomAudioClip WallRunLoopSfx;

		public float WallRunLoopSfxFadeOutDuration;

		public PooledParticle WallRunTrailVfxPrefab;

		public PooledParticle SlideSparksVfsPrefab;

		public Vector3 SlideSparksPositionOffset;

		public Vector3 SlideSparksRotationOffsetEuler;

		public float MinAutomaticWallClimbFeedbackPeriod;

		public float MinAutomaticWallClimbFeedbackSpeed;

		public RecRoomAudioClip WallClimbContactSfx;

		public PooledParticle WallClimbContactVfxPrefab;

		public PlayerTrail TeleportTrailPrefab;

		public PooledParticle SprintWindLineVfxPrefab;

		public float SprintWindLineVfxCameraOffset;

		public float SprintWindLineFadeTime;

		public float SprintWindLineMinDotVisibility;

		public PlayerMovementFeedback.WindLineVFXSettings EmptyWindLineVfxSettings;

		public PlayerMovementFeedback.WindLineVFXSettings SprintWindLineVfxSettings;

		public PlayerMovementFeedback.WindLineVFXSettings SlideWindLineVfxSettings;

		public PooledParticle SlideStartVfxPrefab;

		public PooledParticle SprintSonicBoomVfxPrefab;
	}
}
