using UnityEngine;

public class OffsetRotationRigidbodyPickup : RigidbodyPickup
{
	public bool usingOffsetRotation;

	public Transform rotationHandleTransform;

	public Vector3 rotationUpVector;

public override Quaternion TargetRotation
{
get 	{
		return default;
	}

}
}
