using UnityEngine;

namespace RecRoom.Activities.Arena
{
	public class ArenaEncounterSpawnPoint : MonoBehaviour
	{
		[SerializeField]
		private GIBEGHKMCIE team;

		[SerializeField]
		private bool isInitialSpawnPoint;

		[SerializeField]
		private EnemyPatrol patrol;

public GIBEGHKMCIE Team
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
		}

}

public bool IsInitialSpawnPoint
{
get 		{
			return false;
		}

}

public EnemyPatrol Patrol
{
get 		{
			return null;
		}

}
	}
}
