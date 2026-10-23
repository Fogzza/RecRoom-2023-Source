using UnityEngine;

namespace RecRoom.Core.Screens
{
	public class ScreenInteractableTargetingSystemConfig : InteractableTargetingSystemConfig
	{
		public float PrecisePhaseCheckMaxDistance;

		public float PrecisePhaseMinOcclusionDistance;

		public float BroadPhaseCheckHorizontalCameraFrustumPercentage;

		public float BroadPhaseCheckVerticalCameraFrustumPercentage;

		public float BroadPhaseCheckMaxDistance;

		public float BroadPhaseMinOcclusionDistance;

		public AnimationCurve BroadPhaseRaycastDistanceMultiplierOverAngleFromUp;

		public bool ShowBroadPhaseDebugging;

		public Material DebugFrustumMaterial;

		public Mesh debugSphereMesh;

		public Material debugSphereMaterial;

		public float debugSphereSize;
	}
}
