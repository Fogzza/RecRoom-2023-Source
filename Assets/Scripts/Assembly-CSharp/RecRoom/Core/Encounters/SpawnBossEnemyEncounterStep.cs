using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class SpawnBossEnemyEncounterStep : BaseSpawnEnemyEncounterStep
	{
		public enum MBFEMJINOCO
		{
			IMMEDIATELY = 0,
			BOSS_HEALTH_LESS_THAN = 1,
			BOSS_KILLED = 2,
			TIME_ELAPSED = 3,
			BOSS_AGGROD = 4
		}

		private const float KEDBGJMFEPE = 0.1f;

		[SerializeField]
		public EncounterEnemyDescriptor bossEnemyDescriptor;

		[SerializeField]
		public bool spawnDisenaged;

		private global::MDAHOKBAGPC<bool, float, int> LOKKKEMONKJ;

public Enemy BossEnemy
{
get 		{
			return null;
		}

}

public float BossSpawnTime
{
get 		{
			return 0f;
		}

}

public bool BossHasBeenSpawned
{
get 		{
			return false;
		}

}

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnAwake(GameEncounter CGBFJFNKJFN, int GNNALAJAMKB, KBJKDKFNFIA KLIJMCAEKKB, KBJKDKFNFIA CIMGEOHGFJK)
		{
		}

		public override void OnEncounterStart()
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

		private void NKPKPLNJKKB(bool JFCGLIEANAD, Enemy JOILEIFAFGD)
		{
		}
	}
}
