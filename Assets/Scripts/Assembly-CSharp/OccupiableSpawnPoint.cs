using System;
using UnityEngine;

public class OccupiableSpawnPoint : MonoBehaviour
{
	[SerializeField]
	private bool automaticallyRelease;

	[SerializeField]
	private float sphereCheckRadius;

	[SerializeField]
	private Vector3 sphereCheckCenter;

	private Action<OccupiableSpawnPoint> NBCLHKIEFAJ__BackingField;

	private bool PFGNHNCIKAI;

public bool Occupied
{
get 	{
		return false;
	}

private set {
	}
}

public event Action<OccupiableSpawnPoint> AutomaticallyReleasedEvent {
add {
	}
remove {
	}
}

	private void Update()
	{
	}

	public void Occupy()
	{
	}

	public void Release()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
