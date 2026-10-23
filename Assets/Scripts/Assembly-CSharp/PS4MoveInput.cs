using System;
using UnityEngine;

public class PS4MoveInput : MonoBehaviour
{
	[SerializeField]
	private int controllerIndex;

	public const int RightHandControllerIndex = 0;

	public const int LeftHandControllerIndex = 1;

	private int IPEJEODDALK;

	private bool KFGGHFDGMLO;

	private int EGAGPKDGMDH;

	private int CPHJBDIDOON;

	private float KBAFPLALHIA;

	private float PANKGAFJOFD;

	private Vector3 KODFKCAMPML;

	private Quaternion MECLFMCAOPN;

	private Vector3 PBMHDMPLEMH;

	private Vector3 INCDHHNFNFB;

	private Action GGJPPPBAKFP__BackingField;

	private bool GEPCFPBBALL;

	private bool LDNGNGNPOFF;

public int ControllerIndex
{
get 	{
		return 0;
	}

set {
	}
}

public Vector3 LastPosition
{
get 	{
		return default;
	}

private set {
	}
}

public Quaternion LastRotation
{
get 	{
		return default;
	}

private set {
	}
}

public Vector3 LastLinearVelocity
{
get 	{
		return default;
	}

private set {
	}
}

public Vector3 LastAngularVelocity
{
get 	{
		return default;
	}

private set {
	}
}

public bool IsConnected
{
get 	{
		return false;
	}

}

public bool IsTrackingPosition
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsTrackingRotation
{
get 	{
		return false;
	}

private set {
	}
}

public event Action PosesChanged {
add {
	}
remove {
	}
}

	public bool GetButton(IILNGCKFGBN HHDMPJJAPJJ)
	{
		return false;
	}

	public bool GetButtonDown(IILNGCKFGBN HHDMPJJAPJJ)
	{
		return false;
	}

	public bool GetButtonUp(IILNGCKFGBN HHDMPJJAPJJ)
	{
		return false;
	}

	public float GetTriggerAxis()
	{
		return 0f;
	}

	public void SetVibration(float DOEJGDJILAD)
	{
	}
}
