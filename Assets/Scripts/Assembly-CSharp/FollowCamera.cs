using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public float DistanceFromPlayer;

	public bool FacePlayer;

	public Vector3 PositionOffset;

	public Vector3 RotationOffset;

	public bool StayAtHeadHeight;

	public float OuterFollowAngle;

	private Interpolator KNBEIANDHDL;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void ForceUpdate()
	{
	}
}
