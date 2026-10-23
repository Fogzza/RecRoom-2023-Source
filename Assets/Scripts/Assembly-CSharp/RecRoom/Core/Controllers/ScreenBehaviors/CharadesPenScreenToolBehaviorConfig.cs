using RecRoom.Core.Screens.PlayerController;
using RecRoom.MathUtils.Springs;
using UnityEngine;

namespace RecRoom.Core.Controllers.ScreenBehaviors
{
	public class CharadesPenScreenToolBehaviorConfig : ScreenToolBehaviorConfig<MKELDBHLOEF, CharadesPenScreenToolBehaviorConfig>
	{
		public PlayerAnimation ExtrudingAnimation;

		public WeightedPlayerAnimationData FingerpaintingAnimation;

		public PlayerAnimation3DBlendedPoseSet FingerpaintingPoseSet;

		[Space]
		public SimpleSpring6DConfig FingerpaintAnimationSpring;

		public ScreenPlayerCursorSettings FingerpaintingCursorSettings;

		[Space]
		public EIIIOKMILNL FingerpaintingCameraController;

		[Space]
		public AnimationCurve DigitalToAnalogExtrusionAmountByCursorViewportSpeed;

		public AnimationCurve ApplePencilExtrusionCurve;
	}
}
