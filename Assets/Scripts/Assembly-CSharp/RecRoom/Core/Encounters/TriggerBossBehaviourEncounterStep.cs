using RecRoom.Core.AI;

namespace RecRoom.Core.Encounters
{
	public class TriggerBossBehaviourEncounterStep : TriggerEnemyBehaviourEncounterStep
	{
		public enum IFDEFIMPIAG
		{
			IMMEDIATELY = 0,
			BOSS_HEALTH_LESS_THAN = 1,
			TIME_ELAPSED = 2,
			CUSTOM_BOSS_VALUE_LESS_THAN = 3,
			CUSTOM_BOSS_VALUE_EQUALS = 4
		}

		private SpawnBossEnemyEncounterStep JGDBEGBAMID;

public override string Description
{
get 		{
			return null;
		}

}

public override Enemy TargetEnemy
{
get 		{
			return null;
		}

}

		public override void OnAwake(GameEncounter CGBFJFNKJFN, int GNNALAJAMKB, KBJKDKFNFIA KLIJMCAEKKB, KBJKDKFNFIA CIMGEOHGFJK)
		{
		}

		public override bool IsBlockingEncounterEnd()
		{
			return false;
		}
	}
}
