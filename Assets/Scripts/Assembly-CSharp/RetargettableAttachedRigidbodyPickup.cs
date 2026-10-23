using UnityEngine;

public class RetargettableAttachedRigidbodyPickup : RigidbodyPickup
{
	[SerializeField]
	private Transform targetTransform;

	[SerializeField]
	private bool smoothTransitions;

	[SerializeField]
	private AnimationCurve transitionCurve;

	private Transform IAIFJCKPJMN;

	private float GNBHHPCPJBA;

private float LGNACMHPDHE
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

protected override CAKFLICMCMA ECEJKNPMEHH
{
get 	{
		return CAKFLICMCMA.WHILE_HELD;
	}

}

	protected override void Awake()
	{
	}

	public void SetTargetTransform(Transform HDDMGJFKCGI)
	{
	}
}
