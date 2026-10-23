using System;
using UnityEngine;

namespace RecRoom.Core.VR.PlayerController
{
	public class VRPlayerLocomotionContent : ScriptableObject
	{
		[Serializable]
		public class VRPlayerSeatedCameraContent
		{
			public enum CGANKHAJMIC
			{
				SEAT = 0,
				HEAD = 1
			}

			public bool DampingEnabled;

			public float RollSmoothTime;

			public AnimationCurve RollRemapCurve;

			public float PitchSmoothTime;

			public AnimationCurve PitchRemapCurve;

			public CGANKHAJMIC RotationOrigin;
		}

		public WallRunVRPlayerSteeringController WallRunSteering;

		public float WallRunRoll;

		public float WallRunRollStartBlendTime;

		public float WallRunRollEndBlendTime;

		public float WallRunStartHapticsDuration;

		public float WallRunStartHapticsIntensity;

		public float WallRunLoopingHapticsDuration;

		public float WallRunLoopingHapticsIntensity;

		public FlyVRPlayerSteeringController FlyingSteering;

		public PlayerFlyIndicator FlyIndicatorPrefab;

		public SelfScaleFlyVRPlayerSteeringController SelfScaleFlyingSteering;

		public float WallClimbGrabInputSlopDuration;

		public float WallClimbHandCollisionDetectionRadius;

		public float WallClimbHandCollisionMinSearchDistance;

		public float WallClimbHandSnapBlendDuration;

		public float WallClimbHandSnapPitch;

		public float WallClimbHandMinSlowdownDistanceFromWall;

		public float WallClimbHandMaxSlowdownDistanceFromWall;

		public float WallClimbHandAttachHapticsDuration;

		public float WallClimbHandAttachHapticsIntensity;

		public float WallClimbThrowHapticsDuration;

		public float WallClimbThrowHapticsIntensity;

		public float SlideStartHapticsDuration;

		public float SlideStartHapticsIntensity;

		public float SlideLoopingHapticsDuration;

		public float SlideLoopingHapticsIntensity;

		public float SlideVignetteFadeInTime;

		public float SlideVignetteFadeOutTime;

		public AnimationCurve SlideVignetteCurve;

		public float ShortenButtonMinLongPressDelay;

		public float DownToCrouchNormalizedHeight;

		public float UpFromCrouchNormalizedHeight;

		public float DownToProneNormalizedHeight;

		public float UpFromProneNormalizedHeight;

		public float ImpulseHapticsDuration;

		public float ImpulseHapticsIntensity;

		public float RoomScaleCollisionDisplacementCooldown;

		public float RoomScaleCollisionVignetteFadeInTime;

		public float RoomScaleCollisionVignetteFadeOutTime;

		public float SeatedMovementVelocityForFullVignette;

		public float SeatedMovementAngularVelocityForFullVignette;

		public float SeatedMovementVignetteInterpolationSpeed;

		public VRPlayerSeatedCameraContent SeatedCameraContent;
	}
}
