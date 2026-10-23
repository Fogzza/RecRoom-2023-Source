using UnityEngine;

namespace RecRoom
{
	public class RCCarWheel : MonoBehaviour
	{
		[SerializeField]
		private float suspensionLength;

		[SerializeField]
		private float suspensionDamping;

		[SerializeField]
		private Transform meshTransform;

		[SerializeField]
		private float wheelRadius;

		private float EAGDMGKLAGI;

		private float BPGIBJBKOOM;

		private RaycastHit GBAMJMAEAAA;

		private float KNCDPJFGODH;

public float MaxSuspensionForce
{
get 		{
			return 0f;
		}

set {
		}
}

public RaycastHit LatestRaycastHit
{
get 		{
			return default;
		}

}

public float Circumference
{
get 		{
			return 0f;
		}

}

public Vector3 CurrentDampingForce
{
get 		{
			return default;
		}

}

public Vector3 CurrentSuspensionForce
{
get 		{
			return default;
		}

}

public float CurrentSuspensionCompression
{
get 		{
			return 0f;
		}

}

public bool IsGrounded
{
get 		{
			return false;
		}

}

		private void Update()
		{
		}

		public bool UpdateSuspension()
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
