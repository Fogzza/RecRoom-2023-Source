using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class PushToTalkScreenPlayerBehaviorConfig : ScreenPlayerBehaviorConfig<EBAPDAGEGHI, PushToTalkScreenPlayerBehaviorConfig>
	{
		public float Volume0Threshold;

		public float Volume1Threshold;

		public float Volume2Threshold;

		public float Volume3Threshold;

		[Space]
		public float DynamicPTTDelay;

		public float DynamicToggleDelay;
	}
}
