using UnityEngine;

namespace RecRoom.Core.Screens.PlayerController
{
	public class AvatarCustomizationAnimationContent : ScriptableObject
	{
		public PlayerAnimationAsset[] UndoAnimations;

		public PlayerAnimationAsset[] RedoAnimations;

		public PlayerAnimationAsset[] RandomizeAnimations;
	}
}
