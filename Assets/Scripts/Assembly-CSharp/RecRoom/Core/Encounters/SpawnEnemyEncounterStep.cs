using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class SpawnEnemyEncounterStep : BaseSpawnEnemyEncounterStep
	{
		public enum GHDFJIHOBBA
		{
			IMMEDIATELY = 0,
			ENEMIES_ALIVE = 1,
			ENEMIES_KILLED = 2,
			TIME_ELAPSED = 3,
			ENEMIES_AGGROD = 4
		}

		[SerializeField]
		public EncounterEnemyDescriptor[] enemies;

		[SerializeField]
		public float timeBeforeFirstSpawn;

		[SerializeField]
		public float timeBetweenSpawns;

		private const float DNIHOCKJKMO = 0.1f;

		private const float KGMNFBNIFMO = 0.5f;

		private const int KIAJFPKCDMK = 10;

		private global::KPBNLENPEPO<int, int, float, int> GEACAFBODDJ;

public override string Description
{
get 		{
			return null;
		}

}

private float HJNOCDPGCDL
{
get 		{
			return 0f;
		}

}

private int JEODHBDOINA
{
get 		{
			return 0;
		}

set {
		}
}

private int OCALBPHDMMK
{
get 		{
			return 0;
		}

set {
		}
}

private float HECFICPIIMC
{
get 		{
			return 0f;
		}

set {
		}
}

private int HFFCIFFKHGK
{
get 		{
			return 0;
		}

set {
		}
}

		public override void OnAwake(GameEncounter CGBFJFNKJFN, int GNNALAJAMKB, KBJKDKFNFIA KLIJMCAEKKB, KBJKDKFNFIA CIMGEOHGFJK)
		{
		}

		public override void OnStartRunning()
		{
		}

		public override void OnUpdateRunning()
		{
		}

		public override void OnStopRunning()
		{
		}

		public override void OnSkipRunning()
		{
		}

		public override bool IsBlockingEncounterEnd()
		{
			return false;
		}

		public override bool IsCompleted()
		{
			return false;
		}
	}
}
