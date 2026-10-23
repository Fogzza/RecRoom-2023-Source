namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class InteractWithInteractablesPerHandScreenPlayerBehaviorConfig : PerHandScreenPlayerBehaviorConfig<LADJGOGDCKM, InteractWithInteractablesPerHandScreenPlayerBehaviorConfig>
	{
		public PlayerAnimation PickupAnimation;

		public float InteractionDuration;

		public float TapToInteractMaxViewportDistanceFromInteractable;

		public float StationaryPressForInteractionTimeThreshold;
	}
}
