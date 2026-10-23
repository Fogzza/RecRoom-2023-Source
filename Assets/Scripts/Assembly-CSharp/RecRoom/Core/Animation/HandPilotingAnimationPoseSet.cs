using RecRoom.Core.Screens.PlayerController;
using UnityEngine;

namespace RecRoom.Core.Animation
{
	public class HandPilotingAnimationPoseSet : ScriptableObject
	{
		public enum KINGKHJMOHK
		{
			Center = 0,
			Left = 1,
			UpLeft = 2,
			Up = 3,
			UpRight = 4,
			Right = 5,
			DownRight = 6,
			Down = 7,
			DownLeft = 8,
			Center_Far = 9,
			Left_Far = 10,
			UpLeft_Far = 11,
			Up_Far = 12,
			UpRight_Far = 13,
			Right_Far = 14,
			DownRight_Far = 15,
			Down_Far = 16,
			DownLeft_Far = 17,
			COUNT = 18
		}

		[SerializeField]
		private PlayerAnimationAsset center;

		[SerializeField]
		private PlayerAnimationAsset left;

		[SerializeField]
		private PlayerAnimationAsset right;

		[SerializeField]
		private PlayerAnimationAsset down;

		[SerializeField]
		private PlayerAnimationAsset up;

		[SerializeField]
		private PlayerAnimationAsset upLeft;

		[SerializeField]
		private PlayerAnimationAsset upRight;

		[SerializeField]
		private PlayerAnimationAsset downRight;

		[SerializeField]
		private PlayerAnimationAsset downLeft;

		[SerializeField]
		private PlayerAnimationAsset centerFar;

		[SerializeField]
		private PlayerAnimationAsset leftFar;

		[SerializeField]
		private PlayerAnimationAsset rightFar;

		[SerializeField]
		private PlayerAnimationAsset downFar;

		[SerializeField]
		private PlayerAnimationAsset upFar;

		[SerializeField]
		private PlayerAnimationAsset upLeftFar;

		[SerializeField]
		private PlayerAnimationAsset upRightFar;

		[SerializeField]
		private PlayerAnimationAsset downRightFar;

		[SerializeField]
		private PlayerAnimationAsset downLeftFar;

		public PlayerAnimation3DBlendedPoseSet poseSet;

		public static PlayerAnimationAsset MHOEJCECBPL(HandPilotingAnimationPoseSet LPKMEBJKNCG, KINGKHJMOHK EPKIAECHKFB)
		{
			return null;
		}
	}
}
