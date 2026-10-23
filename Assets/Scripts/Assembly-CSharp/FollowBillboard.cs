using UnityEngine;

public class FollowBillboard : MonoBehaviour
{
	[SerializeField]
	private Vector3 viewSpaceTargetOffset;

	public Transform Target;

	public Camera Camera;

	private void Update()
	{
	}
}
