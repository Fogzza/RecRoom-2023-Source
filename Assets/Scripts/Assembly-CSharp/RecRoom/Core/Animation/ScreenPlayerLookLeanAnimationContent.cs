using RecRoom.MathUtils.Springs;
using UnityEngine;

namespace RecRoom.Core.Animation
{
	public class ScreenPlayerLookLeanAnimationContent : ScriptableObject
	{
		public PlayerAnimationAsset DefaultAnimation;

		public PlayerAnimationAsset PositiveYawExtreme;

		public PlayerAnimationAsset NegativeYawExtreme;

		public PlayerAnimationAsset PositivePitchExtreme;

		public PlayerAnimationAsset NegativePitchExtreme;

		public float YawVelocityExtreme;

		public float PitchVelocityExtreme;

		public SimpleSpringConfig Spring;
	}
}
