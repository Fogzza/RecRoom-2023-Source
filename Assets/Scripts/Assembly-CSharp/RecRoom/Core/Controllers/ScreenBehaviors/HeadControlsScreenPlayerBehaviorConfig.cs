using RecRoom.MathUtils.Springs;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class HeadControlsScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<AHGIDBJHKCJ, HeadControlsScreenPlayerBehaviorConfig>
	{
		public SimpleSpring6DConfig HeadDefaultControlSpring;

		public float HeadControlAccelerationScalar;

		public float HeadControlAngularAccelerationScalar;
	}
}
