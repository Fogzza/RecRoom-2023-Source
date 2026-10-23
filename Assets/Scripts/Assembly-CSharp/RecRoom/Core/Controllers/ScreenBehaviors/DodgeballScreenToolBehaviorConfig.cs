using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class DodgeballScreenToolBehaviorConfig : ScreenToolBehaviorConfig<PCFBNLIOLGI, DodgeballScreenToolBehaviorConfig>
	{
		public enum CNDBLGGIABD
		{
			GAZE_TARGET = 0,
			ARBITRARY_TARGET = 1,
			HYBRID = 2
		}

		public SerializableBlendedPlayerAnimation chargeAnimationBlend;

		public PlayerAnimation initialThrowAnimation;

		public PlayerAnimation followThroughThrowAnimation;

		public float maxChargeDuration;

		public float minChargeDuration;

		public AnimationCurve chargeCurve;

		public AnimationCurve throwAngularSpeedNormalizedCurve;

		public float throwSpeed;

		public float throwGravityCompensationAngle;

		public float inertia;

		public CNDBLGGIABD targetMode;

		public float targetDistanceThreshold;

		public AnimationCurve throwCurveNormalizedAngleCurve;

		public float maxThrowCurveAngle;

		public ScreenPlayerCursorSettings dodgeballGameplayCursorSettings;

		public float fadeInDelay;

		public float fadeInDuration;

		public float fadeOutDelay;

		public float fadeOutDuration;
	}
}
