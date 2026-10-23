using UnityEngine;

namespace RecRoom.Inputs
{
	public class ScreensCameraInputGamepadSettings : ScriptableObject
	{
		[SerializeField]
		private AnimationCurve sensitivityCurve;

		[SerializeField]
		private AnimationCurve sensitivityCurveNoAcceleration;

		[SerializeField]
		private float pitchScaler;

		[SerializeField]
		private float peggedMaxSpeedScaler;

		[SerializeField]
		private float peggedTimeToReachMaxSpeed;

		[SerializeField]
		private bool supportsVerticalPegging;

		[SerializeField]
		private float peggedMaxAngleFromHorizontal;

		[SerializeField]
		private float peggedMaxAngleFromVertical;

		public AnimationCurve SensitivityCurve => null;

		public AnimationCurve SensitivityCurveNoAcceleration => null;

		public float PitchScaler => 0f;

		public float PeggedMaxSpeedScaler => 0f;

		public float PeggedTimeToReachMaxSpeed => 0f;

		public bool SupportsVerticalPegging => false;

		public float PeggedMaxAngleFromHorizontal => 0f;

		public float PeggedMaxAngleFromVertical => 0f;
	}
}
