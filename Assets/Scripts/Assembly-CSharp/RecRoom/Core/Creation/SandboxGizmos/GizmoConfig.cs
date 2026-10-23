using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class GizmoConfig : ScriptableObject
	{
		[Serializable]
		public class AnimationCurveData
		{
			public string name;

			public AnimationCurve curve;
		}

		public List<AnimationCurveData> AnimationCurves;

		public AnimationGizmoSplineStepVisualizer SplineStepVisualizerPrefab;
	}
}
