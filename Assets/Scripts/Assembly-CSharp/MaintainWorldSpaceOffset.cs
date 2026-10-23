using System;
using UnityEngine;

public class MaintainWorldSpaceOffset : MonoBehaviour
{
	[NonSerialized]
	public Transform Origin;

	[NonSerialized]
	public Vector3 WorldSpaceOffset;

	private void Update()
	{
	}
}
