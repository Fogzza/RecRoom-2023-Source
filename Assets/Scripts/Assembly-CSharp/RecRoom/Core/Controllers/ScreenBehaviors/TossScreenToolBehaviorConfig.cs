namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class TossScreenToolBehaviorConfig : ScreenToolBehaviorConfig<EKPODIKOACI, TossScreenToolBehaviorConfig>
	{
		public float SnapPoseDistanceFromCamera;

		public float MaxAnticipationDuration;

		public float AnticipationPoseDistanceFromCamera;

		public float TossSpeed;

		public PlayerAnimation TossPoseAnimation;

		public PlayerAnimation TossFollowThroughAnimation;
	}
}
