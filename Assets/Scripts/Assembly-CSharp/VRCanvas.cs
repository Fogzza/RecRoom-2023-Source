using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour
{
	public static readonly List<VRCanvas> AllActiveVRCanvases;

	[SerializeField]
	private bool tactile3DUIEnabled;

public bool Tactile3DUIEnabled
{
get 	{
		return false;
	}

set {
	}
}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}
}
