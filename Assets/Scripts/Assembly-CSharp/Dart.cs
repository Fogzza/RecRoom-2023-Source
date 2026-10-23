using UnityEngine;

public sealed class Dart : StickyBase
{
	[SerializeField]
	private Transform centerOfMass;

	[SerializeField]
	private Transform tail;

	[SerializeField]
	private float tailDrag;

	[SerializeField]
	private AnimationCurve dragByAngle;

	[SerializeField]
	private float scaleVelocityAtRelease;

	[SerializeField]
	private float scaleAngularVelocityAtRelease;

	[SerializeField]
	private float minSpeedToStick;

	[SerializeField]
	private float maxAngleToVelocityToStick;

	[SerializeField]
	private float maxAngleToSurfaceToStick;

	protected override void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnCollisionEnter(Collision KDGCDLJEAMD)
	{
	}

	private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
	{
	}

	protected override void OFEEICKPJDA()
	{
	}
}
