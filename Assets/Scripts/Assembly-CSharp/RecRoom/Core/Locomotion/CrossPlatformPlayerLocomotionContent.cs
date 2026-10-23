using UnityEngine;

namespace RecRoom.Core.Locomotion
{
	public class CrossPlatformPlayerLocomotionContent : ScriptableObject
	{
		public float SkinThickness;

		public float FitTestSkinReduction;

		public float ClampDistance;

		public float GroundClampMaxDeltaAngle;

		public float WallClampMaxDeltaAngle;

		public float WalkDefaultMaxSpeed;

		public float WalkAccelerationDuration;

		public float SprintMaxSpeedDefaultWalkSpeedMultiplier;

		public float SprintAccelerationDuration;

		public float SprintMaxLateralScaler;

		public float SprintPauseAngleFromForward;

		public float SprintCancelAngleFromForward;

		public float StepHeight;

		public float StepMinForwardSearchDistance;

		public float FallTerminalSpeed;

		public float FallDefaultAirControlPercentage;

		public float LandingPredictionTime;

		public float AirDragAcceleration;

		public float GroundDragAcceleration;

		public float WallDragAcceleration;

		public float ClamberMinSpeed;

		public AnimationCurve ClamberForwardSpeedCurve;

		public AnimationCurve ClamberUpSpeedCurve;

		public float CrouchNormalizedHeight;

		public float CrouchDefaultSpeedMultiplier;

		public float ProneNormalizedHeight;

		public float ProneDefaultSpeedMultiplier;

		public float SlideDefaultMinDuration;

		public float SlideDefaultMaxSpeedSprintSpeedMultiplier;

		public float SlideDefaultAirControlPercentage;

		public float SlideDefaultStartSpeedBoost;

		public float SlideDefaultSteeringParameter;

		public float SlideNormalizedHeight;

		public float SlideMinSlopeAngle;

		public float SlideFrictionDelayFraction;

		public float SlideStartFallSpeedRestitution;

		public float SlideMaxWallContactAbruptStopAngleFromNormal;

		public float SlideStartInputSlopTime;

		public float SlideGravityLateralAccelerationDuration;

		public float SlideGravityForwardAccelerationDuration;

		public float SlideSteeringForwardAccelerationDuration;

		public float SlideSteeringMinLateralAccelerationDuration;

		public float SlideSteeringMaxLateralAccelerationDuration;

		public AnimationCurve SlideSteeringForwardInputRemapCurve;

		public AnimationCurve SlideSteeringBrakeInputRemapCurve;

		public AnimationCurve SlideSteeringParameterCurve;

		public float JumpCutoffHeightMultiplier;

		public float ImpulseAirControlPercentage;

		public float WallRunDefaultDuration;

		public float WallRunDefaultDropRateParameter;

		public float WallRunDefaultSpeedBoost;

		public float WallRunGazeMaxAngleFromTangent;

		public float WallRunMaxAngleFromTangent;

		public float WallRunMinDropRateGravityMulitplier;

		public float WallRunMaxDropRateGravityMultiplier;

		public float WallRunMaxFallSpeed;

		public float WallRunStartMaxVerticalSpeedJumpSpeedMultiplier;

		public float WallRunStartVerticalSpeedBoostJumpSpeedMultiplier;

		public float WallRunJumpDefaultHeight;

		public float WallRunJumpDefaultDirectionParameter;

		public float WallRunJumpDefaultAirControlAccelerationMultiplier;

		public float WallRunJumpSteeringSpeedBoost;

		public float WallClimbStartFallMinSpeed;

		public float WallClimbStartSteeringMinSpeed;

		public float WallClimbStandingStartMaxGazeAngle;

		public float WallClimbFallingStartMaxGazeAngle;

		public float WallClimbMaxSpeed;

		public float WallClimbAccelerationDuration;

		public float WallClimbCliffDetectionCapsuleHeightParameter;

		public float WallClimbMaxFallSlideDistance;

		public float WallClimbDropForwardSpeed;

		public float WallClimbJumpAirControlAccelerationMultiplier;

		public float WallClimbJumpAlongWallDistance;

		public float WallClimbJumpAlongWallDuration;

		public float WallClimbJumpAlongWallMinEarlyInputTime;

		public float WallClimbJumpAlongWallMaxEarlyInputTime;

		public float wallClimbJumpOffWallForwardSpeed;

		public float WallClimbJumpOffWallHeight;

		public float ManualWallClimbJumpMinInputSpeed;

		public float ManualWallClimbJumpMaxInputSpeed;

		public float ManualWallClimbJumpMinOutputSpeed;

		public float ManualWallClimbJumpMaxOutputSpeed;

		public float ManualWallClimbJumpLedgeDetectionDistance;

		public float[] LedgeDetectionHeights;

		public float LedgeMinHeight;

		public float LedgeMantleMaxWidth;

		public float LedgeMantleMinWindowHeight;

		public float LedgeInitialDetectOffset;

		public float ShortClamberRestitution;

		public float MediumClamberRestituion;

		public float TallClamberRestitution;

		public float ShortMantleRestitution;

		public float MediumMantleRestituion;

		public float TallMantleRestitution;

		public float LadderRestitution;

		public float TeleportMaxDuration;

		public float FlyMaxSpeed;

		public float FlyForwardAccelerationDuration;

		public float FlyBrakeAccelerationDuration;

		public float FlyMaxSpeedNormalizedCurveMaxDuration;

		public AnimationCurve FlyMaxSpeedNormalizedCurve;

		public AnimationCurve LocomotionSpeedMultiplierBySelfScale;

		public float RoomScaleCollisionDisplacementHeadRadius;

		public float RoomScaleSeatedConfinedDisplacementRadius;
	}
}
