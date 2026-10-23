using UnityEngine;

namespace RecRoom.Core.AvatarSkeleton
{
	public class AvatarSkeletonContent : ScriptableObject
	{
		public Vector3 HeadPivotOffset;

		public float HeadPositionalFollowTime;

		public float HeadPositionalDeadZoneRadius;

		public float HeadPositionalInnerDeadZoneRadius;

		public float HeadPositionalInnerDeadZoneDelayTime;

		public float HeadPositionalReenterDeadZoneRadius;

		[Space]
		public float HeadRotationalFollowTime;

		public float HeadRotationalDeadZoneAngle;

		public float HeadRotationalInnerDeadZoneAngle;

		public float HeadRotationalInnerDeadZoneDelayTime;

		public float HeadRotationalReenterDeadZoneAngle;

		public float HeadRotationalMaxFollowAngle;

		[Space]
		public float TypicalFollowTimeSmoothTime;

		public float FlyingFollowTimeSmoothTime;

		public float SkeletonPitchFollowTime;

		public AnimationCurve HandEffectorWeight;

		public float MinWalkingBackwardAngleThreshold;

		public float MaxWalkingForwardAngleThreshold;

		public float WalkingForwardBackwardBlendTime;

		public float SteeringBlendTime;

		public float SpeedChangeTime;

		public float DirectionChangeDampTime;

		public float TurnInPlaceDampTime;
	}
}
