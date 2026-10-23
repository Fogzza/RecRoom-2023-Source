using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Core.Screens.PlayerController
{
	public class ScreenPlayerLocomotionContent : ScriptableObject
	{
		public float HeightChangeSpeed;

		public float SlideHeightChangeSpeed;

		public ScreenPlayerCameraSettings SprintCameraSettings;

		public float SprintCameraSettingsBlendTime;

		public float SprintHandPitchAngleLowerBound;

		public float SprintHandPitchAngleUpperBound;

		public ScreenPlayerCameraSettings SlideCameraSettings;

		public float SlideCameraSettingsBlendTime;

		public float SlideCameraMaxRoll;

		public float SlideCameraRollSmoothTime;

		public float SlideCameraFadeOutNormalizedSpeed;

		public AnimationCurve SlideCameraRollCurve;

		public AnimationCurve SlideCameraFadeOutCurve;

		public ScreenPlayerCameraSettings SlideJumpCameraSettings;

		public float SlideJumpCameraSettingsBlendTime;

		public WallRunScreenPlayerSteering WallRunSteering;

		public float WallRunCameraRoll;

		public float WallRunCameraFadeDuration;

		public float WallRunCameraMaxRotationFromForward;

		public bool WallRunCameraHasAutomaticYaw;

		public float WallRunCameraAutomaticYawFromWall;

		public float WallClimbCollisionDetectionChestParameter;

		public ScreenPlayerCameraSettings WallClimbCameraSettings;

		public WallClimbScreenPlayerSteering WallClimbSteering;

		public float WallClimbCameraFadeDuration;

		public float WallClimbCameraMaxRotationFromWall;

		public float WallClimbCameraMaxRoll;

		public float WallClimbCameraRollSmoothTime;

		public float WallClimbNormalizedPlayerHeight;

		public readonly CBJIHCIDPGO ClamberSteering;

		public ScreensCameraInputGamepadSettings FlyingCameraGamepadInputSettings;

		public readonly EGAGOFALKOC FlyingSteering;

		public float SeatTransitionFadeDuration;
	}
}
