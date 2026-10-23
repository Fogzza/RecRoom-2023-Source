using UnityEngine;

public class AdjustablePodiumPickup : RigidbodyPickup
{
	[SerializeField]
	private float localMinYOffset;

	[SerializeField]
	private float localMaxYOffset;

	private float NHDMPOEIGGI;

	[SerializeField]
	private Transform podiumRoot;

public float YOffset
{
get 	{
		return 0f;
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

	protected override void Awake()
	{
	}
}
