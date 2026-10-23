using System;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public abstract class VRInputConfiguration : MonoBehaviour
	{
		[SerializeField]
		protected ControllerVelocitySettings VelocitySettings;

		[SerializeField]
		public ControllerWingspanSettings WingspanSettings;

		public abstract VRInputHandler GetHandler(VRTrackedController.EGONEFPMCNI BNNHCJJILFB);
	}
	public class VRInputConfiguration<T> : VRInputConfiguration where T : VRInputHandler
	{
		[SerializeField]
		protected T Left;

		[SerializeField]
		protected T Right;

		public override VRInputHandler GetHandler(VRTrackedController.EGONEFPMCNI BNNHCJJILFB)
		{
			return null;
		}
	}
}
