using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class TriggerEnemyBehaviourEncounterStep : GameEncounterStep
	{
		public enum PPLKGHCOOAP
		{
			IMMEDIATELY = 0,
			ENEMY_HEALTH_LESS_THAN = 1,
			TIME_ELAPSED = 2,
			CUSTOM_ENEMY_VALUE_LESS_THAN = 3,
			CUSTOM_ENEMY_VALUE_EQUALS = 4
		}

		public enum AJDKCFMBEHJ
		{
			NOTHING = 0,
			DISENGAGE = 1,
			REENGAGE = 2,
			CUSTOM_ENEMY_EVENT = 3
		}

		[SerializeField]
		public AJDKCFMBEHJ triggerBehaviour;

		[SerializeField]
		protected Enemy _targetEnemy;

public override string Description
{
get 		{
			return null;
		}

}

public virtual Enemy TargetEnemy
{
get 		{
			return null;
		}

}

		public override void OnEncounterStart()
		{
		}

		public override void OnEncounterStop()
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

		protected bool MLNHALDJLNN()
		{
			return false;
		}
	}
}
