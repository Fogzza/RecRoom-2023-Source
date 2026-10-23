using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class DartScreenToolBehaviorConfig : ScreenToolBehaviorConfig<NDPFINLADBO, DartScreenToolBehaviorConfig>
	{
		public SerializableBlendedPlayerAnimation chargeAnimationBlend;

		public PlayerAnimation lightThrowAnimation;

		public PlayerAnimation heavyThrowAnimation;

		public float maxChargeDuration;

		public AnimationCurve chargeCurve;

		public float minHeavyThrowCharge;

		public AnimationCurve throwSpeedCurve;

		public AnimationCurve throwAngularSpeedNormalizedCurve;

		public AnimationCurve throwCurveNormalizedAngleCurve;

		public float maxThrowCurveAngle;

		public float maxXZRotationForMaxCurve;
	}
}
