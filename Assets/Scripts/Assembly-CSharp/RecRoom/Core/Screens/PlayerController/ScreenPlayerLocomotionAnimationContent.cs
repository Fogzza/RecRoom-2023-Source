using System;
using UnityEngine;

namespace RecRoom.Core.Screens.PlayerController
{
	public class ScreenPlayerLocomotionAnimationContent : ScriptableObject
	{
		[Serializable]
		public struct FidgetWeights
		{
			public int lowEnergyWeight;

			public int mediumEnergyWeight;

			public int highEnergyWeight;
		}

		public PlayerFidgetAnimationSet FidgetAnimationSet;

		public FidgetWeights ActiveFidgetWeights;

		public FidgetWeights PassiveFidgetWeights;

		public float FidgetFadeTime;

		public float MinActiveFidgetDuration;

		public PlayerAnimation IdleHeldToolDefaultAnimation;

		public AdditiveAnimationWeight WalkCameraAnimationWeight;

		public SerializableBlendedPlayerAnimation AdditiveWalkAnimation;

		public AdditiveAnimationWeight AdditiveWalkAnimationCameraWeight;

		public PlayerAnimation AdditiveSprintAnimation;

		public AdditiveAnimationWeight AdditiveSprintAnimationCameraWeight;

		public AdditiveAnimationWeight StandCameraAnimationWeight;

		public PlayerAnimation AdditiveStandAnimation;

		public AdditiveAnimationWeight AdditiveStandAnimationCameraWeight;

		public AdditiveAnimationWeight CrouchCameraAnimationWeight;

		public PlayerAnimation AdditiveCrouchAnimation;

		public AdditiveAnimationWeight AdditiveCrouchAnimationCameraWeight;

		public PlayerAnimation CrouchIdleAnimation;

		public float ProneMinPitchAngleFromGroundNormalDownForToolUse;

		public float ProneHeightAnimationThreshold;

		public DynamicBlendedPlayerAnimationData ProneAnimationParameters;

		public PlayerAnimationAsset ProneIdleAnimation;

		public PlayerAnimationAsset ProneRightAnimation;

		public PlayerAnimationAsset ProneForwardAnimation;

		public PlayerAnimationAsset ProneLeftAnimation;

		public PlayerAnimationAsset ProneBackwardAnimation;

		public AdditiveAnimationWeight ProneCameraAnimationWeight;

		public float ProneMaxIdleSpeedSqr;

		public float ProneMaxMovingSpeedSqr;

		public AnimationCurve ProneSpeedAnimationCurve;

		public float ProneSpeedSmoothTime;

		public PlayerAnimation AdditiveProneAnimation;

		public AdditiveAnimationWeight AdditiveProneAnimationCameraWeight;

		public PlayerAnimation AdditiveGetUpFailedAnimation;

		public AdditiveAnimationWeight AdditiveGetUpFailedAnimationCameraWeight;

		public PlayerAnimation JumpAnimation;

		public AdditiveAnimationWeight JumpAnimationCameraWeight;

		public PlayerAnimation FlyAnimation;

		public AdditiveAnimationWeight FlyAnimationCameraWeight;

		public PlayerAnimation AdditiveJumpAnimation;

		public AdditiveAnimationWeight AdditiveJumpAnimationCameraWeight;

		public PlayerAnimation JumpSprintAnimation;

		public AdditiveAnimationWeight JumpSprintAnimationCameraWeight;

		public PlayerAnimation AdditiveJumpSprintAnimation;

		public AdditiveAnimationWeight AdditiveJumpSprintAnimationCameraWeight;

		public PlayerAnimation AdditiveLandAnimation;

		public AdditiveAnimationWeight AdditiveLandAnimationCameraWeight;

		public PlayerAnimation WallRunAnimation;

		public AdditiveAnimationWeight WallRunAnimationCameraWeight;

		public DynamicBlendedPlayerAnimationData WallClimbAnimationParameters;

		public PlayerAnimationAsset WallClimbIdleAnimation;

		public PlayerAnimationAsset WallClimbRightAnimation;

		public PlayerAnimationAsset WallClimbUpAnimation;

		public PlayerAnimationAsset WallClimbLeftAnimation;

		public PlayerAnimationAsset WallClimbDownAnimation;

		public PlayerAnimation WallClimbHoldingToolAnimation;

		public AdditiveAnimationWeight WallClimbCameraAnimationWeight;

		public float WallClimbMaxIdleSpeedSqr;

		public float WallClimbMovingSpeedSqr;

		public float WallClimbAnimationSmoothTime;

		public AnimationCurve WallClimbAnimationCurve;

		public PlayerAnimation WallClimbLookAnimation;

		public AdditiveAnimationWeight WallClimbJumpCameraAnimationWeight;

		public DynamicBlendedPlayerAnimationData WallClimbJumpReleaseAnimationParameters;

		public PlayerAnimationAsset WallClimbJumpReleaseRightPose;

		public PlayerAnimationAsset WallClimbJumpReleaseUpPose;

		public PlayerAnimationAsset WallClimbJumpReleaseLeftPose;

		public PlayerAnimationAsset WallClimbJumpReleaseDownPose;

		public float WallClimbJumpReleaseHoldDuration;

		public DynamicBlendedPlayerAnimationData WallClimbJumpRegrabAnimationParameters;

		public PlayerAnimationAsset WallClimbJumpRegrabRightPose;

		public PlayerAnimationAsset WallClimbJumpRegrabUpPose;

		public PlayerAnimationAsset WallClimbJumpRegrabLeftPose;

		public PlayerAnimationAsset WallClimbJumpRegrabDownPose;

		public float WallClimbJumpRegrabHoldDuration;

		public PlayerAnimation LowClamberAnimation;

		public PlayerAnimation MediumClamberAnimation;

		public PlayerAnimation HighClamberAnimation;

		public PlayerAnimation LowMantleAnimation;

		public PlayerAnimation MediumMantleAnimation;

		public PlayerAnimation HighMantleAnimation;

		public PlayerAnimation ClimbLadderAnimation;

		public PlayerAnimation ClimbLadderFinishAnimation;

		public float ClimbLadderFinishDelay;
	}
}
