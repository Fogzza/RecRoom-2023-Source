using UnityEngine;

namespace RecRoom.Core.VR.PlayerController
{
	public class VRPlayerRotationContent : ScriptableObject
	{
		public float SmoothRotateMaxSpeed;

		public float SnapRotateMaxSpeed;

		public float GripRotateInputStepSize;

		public float GripRotateOutputStepSize;

		public float GripRotateInputScaler;
	}
}
