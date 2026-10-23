using System;
using UnityEngine;

public class PlungerRigidbodyPickup : RigidbodyPickup
{
	[NonSerialized]
	public RigidbodyPickup ConstraintPickup;

	[NonSerialized]
	public Vector3 ConstraintOffsetPosition;

	[NonSerialized]
	public Quaternion ConstraintOffsetRotation;

	[NonSerialized]
	public Vector3 ConstraintLocalAxis;

	[NonSerialized]
	public float MinimumConstraintDistance;

	[NonSerialized]
	public float MaximumConstraintDistance;

	[NonSerialized]
	public float CurrentDistance;

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

public Vector3 ConstraintPosition
{
get 	{
		return default;
	}

}

public Quaternion ConstraintRotation
{
get 	{
		return default;
	}

}

public Vector3 ConstraintAxis
{
get 	{
		return default;
	}

}
}
