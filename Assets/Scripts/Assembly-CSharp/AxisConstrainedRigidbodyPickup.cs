using UnityEngine;

public class AxisConstrainedRigidbodyPickup : RigidbodyPickup
{
	public enum LIHHPEMDKHA
	{
		All = 2,
		None = 0,
		Positive = 1,
		Negative = -1
	}

	public LIHHPEMDKHA allowMovementOnX;

	public LIHHPEMDKHA allowMovementOnY;

	public LIHHPEMDKHA allowMovementOnZ;

	public bool allowRotationOnX;

	public bool allowRotationOnY;

	public bool allowRotationOnZ;

	public bool constrainToSphere;

	public Vector3 sphericalRestrictionCenter;

	public float sphericalRestrictionRadius;

public override bool IsVisuallyHeld
{
get 	{
		return false;
	}

}

public override Vector3 TargetPosition
{
get 	{
		return default;
	}

}

public override Quaternion TargetRotation
{
get 	{
		return default;
	}

}

	public void SetAllConstraints(bool LGOHPJLCEDP)
	{
	}
}
