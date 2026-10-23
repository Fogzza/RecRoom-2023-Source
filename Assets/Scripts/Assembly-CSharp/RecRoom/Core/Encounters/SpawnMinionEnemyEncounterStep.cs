using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class SpawnMinionEnemyEncounterStep : SpawnEnemyEncounterStep
	{
		[SerializeField]
		private float minEnemySpawnRadius;

		[SerializeField]
		private float maxEnemySpawnRadius;

		[SerializeField]
		private Enemy targetEnemy;

		private int OBLENGJBLNJ;

		protected override bool NOPEMFOCEHF(EncounterEnemyDescriptor AMCFCAMIGKC, out Vector3 INKGHPCDMCG, out Quaternion OOFIIEKBKAE)
		{
			INKGHPCDMCG = default;
			OOFIIEKBKAE = default;
			return false;
		}

		protected override void NHPHCIKGECN(Vector3 INKGHPCDMCG, Quaternion OOFIIEKBKAE, out Vector3 PAGOHCBOIPE, out Quaternion MCMPEHACGHN)
		{
			PAGOHCBOIPE = default;
			MCMPEHACGHN = default;
		}
	}
}
