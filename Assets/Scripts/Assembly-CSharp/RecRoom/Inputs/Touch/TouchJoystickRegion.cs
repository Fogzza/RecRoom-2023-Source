using UnityEngine;

namespace RecRoom.Inputs.Touch
{
	public sealed class TouchJoystickRegion : TouchRegion
	{
		[SerializeField]
		private float inputRadiusMultiplier;

		[SerializeField]
		private RectTransform nub;

		[SerializeField]
		private float maxNubDistance;

		private void Update()
		{
		}
	}
}
