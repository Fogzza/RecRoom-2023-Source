namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class DropToolPerHandScreenPlayerBehaviorConfig : PerHandScreenPlayerBehaviorConfig<IKJMENNEMDF, DropToolPerHandScreenPlayerBehaviorConfig>
	{
		public float dropSpeed;

		public float LongPressPercentageToShowIcon;

		public float underHandTossAngularSpeed;

		public bool underhandTossBypassToolSpeedMultiplier;

		public float TossTargetMinDistance;

		public float TossTargetMaxDistance;

		public float TossTargetFlyingTime;

		public PlayerAnimation initialTossAnimation;

		public PlayerAnimation tossAnimationFollowthrough;
	}
}
