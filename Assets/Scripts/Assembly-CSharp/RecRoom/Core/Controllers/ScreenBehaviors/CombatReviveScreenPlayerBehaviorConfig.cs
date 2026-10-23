namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class CombatReviveScreenPlayerBehaviorConfig : PerHandScreenPlayerBehaviorConfig<JNILGNINBLO, CombatReviveScreenPlayerBehaviorConfig>
	{
		public float MaxTeammateSearchDistance;

		public float MaxTeammateReviveDistance;

		public float PlayerSearchFrequency;

		public float MaxReviveMoveDistance;

		public PlayerAnimation HoverRemotePlayerHighFiveAnimation;

		public PlayerAnimation HoverRemotePlayerHandshakeAnimation;

		public PlayerAnimation HighFiveReviveAnimation;

		public PlayerAnimation HandshakeReviveAnimation;
	}
}
