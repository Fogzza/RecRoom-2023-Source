using UnityEngine;

namespace RecRoom.Tools
{
	public class DrawingToolRigidbodyPickup : RigidbodyPickup
	{
		[SerializeField]
		private bool forceRotationNearSurface;

		[SerializeField]
		private AnimationCurve nearSurfaceRotationCurve;

		private DrawingToolBase BCBCKHADACE;

public override Quaternion TargetRotation
{
get 		{
			return default;
		}

}

public override Vector3 TargetPosition
{
get 		{
			return default;
		}

}

		protected override void Awake()
		{
		}
	}
}
