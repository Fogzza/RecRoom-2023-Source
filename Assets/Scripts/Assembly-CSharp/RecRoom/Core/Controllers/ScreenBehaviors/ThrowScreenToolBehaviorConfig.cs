using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class ThrowScreenToolBehaviorConfig : ScreenToolBehaviorConfig<JLIHHIBDBBG, ThrowScreenToolBehaviorConfig>
	{
		public PlayerAnimation throwChargeAnimation;

		public bool throwOnAnimationEvent;

		public PlayerAnimation throwAnimation;

		public float throwSpeed;

		public float throwAngularSpeed;

		public bool throwTowardsGazeTarget;

		public bool throwTowardsGazeTargetCompensatingForGravity;

		public bool transformGazePitchWithCurves;

		public AnimationCurve normalizedVelocityByGazePitch;

		public AnimationCurve pitchByGazePitch;
	}
}
