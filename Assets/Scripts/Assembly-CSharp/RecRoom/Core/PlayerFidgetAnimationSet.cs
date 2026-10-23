using UnityEngine;

namespace RecRoom.Core
{
	public class PlayerFidgetAnimationSet : ScriptableObject
	{
		public PlayerAnimationAsset[] LowEnergyFidgetAnimations;

		public PlayerAnimationAsset[] MediumEnergyFidgetAnimations;

		public PlayerAnimationAsset[] HighEnergyFidgetAnimations;
	}
}
