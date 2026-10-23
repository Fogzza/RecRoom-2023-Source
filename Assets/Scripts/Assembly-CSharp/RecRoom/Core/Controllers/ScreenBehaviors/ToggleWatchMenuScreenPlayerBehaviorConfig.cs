using RecRoom.Audio;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class ToggleWatchMenuScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<KHANACIPINL, ToggleWatchMenuScreenPlayerBehaviorConfig>
	{
		public PlayerAnimation WatchAnimation;

		public PlayerAnimation IdleAnimation;

		public float OpenMenuAnimationDelay;

		public float CloseMenuAnimationDelay;

		public RecRoomAudioClipPoolConfig openMenuArmSwingClipPool;

		public RecRoomAudioClipPoolConfig closeMenuPreArmSwingClipPool;

		public RecRoomAudioClipPoolConfig closeMenuArmSwingClipPool;
	}
}
