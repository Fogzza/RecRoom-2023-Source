using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class BowlingBallScreenToolBehaviorConfig : ScreenToolBehaviorConfig<CGDBACOPGCE, BowlingBallScreenToolBehaviorConfig>
	{
		public PlayerAnimation bowlWindUpAnimation;

		public PlayerAnimation bowlReleaseAnimation;

		public float minChargeTimeForValidThrow;

		public AnimationCurve windUpSpeedCurve;

		public AnimationCurve releaseSpeedCurve;

		public float minThrowSpeed;

		public float maxThrowSpeed;

		public float maxWalkSpeedThrowSpeedMultiplier;

		public float maxThrowWalkSpeed;

		public float minChargeCrosshairDistance;

		public float maxChargeCrosshairDistance;

		public AnimationCurve windUpCrosshairDistanceCurve;

		public AnimationCurve releaseCrosshairDistanceCurve;
	}
}
