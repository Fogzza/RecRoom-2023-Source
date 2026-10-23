using UnityEngine;

public class ArenaMainframeSpawnPoint : MonoBehaviour
{
	[SerializeField]
	private GIBEGHKMCIE team;

	[SerializeField]
	private Transform mainframeSpawnTransform;

public GIBEGHKMCIE Team
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

}

public Vector3 SpawnPoint
{
get 	{
		return default;
	}

}

public Quaternion SpawnRotation
{
get 	{
		return default;
	}

}
}
