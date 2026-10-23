using System;
using UnityEngine;

public class Interpolator : MonoBehaviour
{
	public bool UseMovementEaseIn;

	public float MovementEaseInDistance;

	public float MovementEaseInPercent;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private float rotationSpeed;

	[SerializeField]
	private float scaleSpeed;

	private Transform OANBHFPMEPB;

	private bool BCBGADIJDAE;

	private Vector3 MEMAAAMDCOE;

	private bool NKKIDIBDPLE;

	private Quaternion PJDJKFPFGFO;

	private bool BDJGAOCMNFP;

	private Vector3 HILIKFCNGHC;

	private Action<Vector3> PLLCPFIKIIM__BackingField;

	private Action<Quaternion> GDNLBBGAMHC__BackingField;

	private Action<Vector3> DBKNMLHDBOI__BackingField;

public bool IsRunning
{
get 	{
		return false;
	}

}

public Transform TargetTransform
{
set {
	}
}

public Vector3 TargetPosition
{
get 	{
		return default;
	}

set {
	}
}

private Vector3 BCAMOEMLBIE
{
get 	{
		return default;
	}

}

public Quaternion TargetRotation
{
get 	{
		return default;
	}

set {
	}
}

public Vector3 TargetScale
{
get 	{
		return default;
	}

set {
	}
}

public event Action<Vector3> PositionUpdated {
add {
	}
remove {
	}
}

public event Action<Quaternion> RotationUpdated {
add {
	}
remove {
	}
}

public event Action<Vector3> ScaleUpdated {
add {
	}
remove {
	}
}

	private void Update()
	{
	}

	private void CGECJMHNCND()
	{
	}

	private void HPNMBJKLHII()
	{
	}

	private void NDHBLMEPDNE()
	{
	}

	public void StopInterpolation()
	{
	}

	public void SnapToTarget()
	{
	}
}
