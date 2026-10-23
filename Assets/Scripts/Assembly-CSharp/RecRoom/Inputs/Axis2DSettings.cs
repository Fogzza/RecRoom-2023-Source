using System;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public class Axis2DSettings
	{
		private enum GFOBAPNMMFK
		{
			NONE = -1,
			RADIAL = 0,
			AXIAL = 1
		}

		[SerializeField]
		private GFOBAPNMMFK deadzoneType;

		[SerializeField]
		private float innerDeadzone;

		[SerializeField]
		private float outerDeadzone;

		[SerializeField]
		private AnimationCurve inputCurve;

		public float FHPLNAMOEFB(float GMLDEHJHNGA)
		{
			return 0f;
		}

		public Vector2 FHPLNAMOEFB(Vector2 GMLDEHJHNGA)
		{
			return default;
		}
	}
}
