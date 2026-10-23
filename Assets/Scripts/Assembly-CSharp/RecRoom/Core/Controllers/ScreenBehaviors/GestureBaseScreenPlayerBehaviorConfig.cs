using UnityEngine.Localization;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public abstract class GestureBaseScreenPlayerBehaviorConfig<Runtime, Config> : PerHandScreenPlayerBehaviorConfig<Runtime, Config> where Runtime : global::ADCLBHGPPKE<Runtime, Config>, new() where Config : GestureBaseScreenPlayerBehaviorConfig<Runtime, Config>
	{
		public float cameraBlendTimeAcceptor;

		public float cameraBlendTimeOfferer;

		public PlayerAnimation OfferingIntro;

		public PlayerAnimation OfferingLoop;

		public LocalizedString Subtitle;
	}
}
