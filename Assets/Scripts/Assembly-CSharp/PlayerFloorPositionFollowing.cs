using System;
using UnityEngine;

public class PlayerFloorPositionFollowing : MonoBehaviour
{
	[NonSerialized]
	public Player TrackedPlayer;

	[SerializeField]
	private Vector3 eulerAngleParentRotation;

	private void Update()
	{
	}
}
