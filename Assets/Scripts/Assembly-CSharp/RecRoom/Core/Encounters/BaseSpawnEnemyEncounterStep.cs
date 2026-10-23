using System.Collections.Generic;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public abstract class BaseSpawnEnemyEncounterStep : GameEncounterStep
	{
		[SerializeField]
		public EnemySpawnerConfiguration spawnerConfiguration;

		[SerializeField]
		public bool spawnOnPatrol;

		[SerializeField]
		public EnemySpawnNavMeshRegion[] spawnRegions;

		[SerializeField]
		public bool suppressRewards;

		public static readonly string ENCOUNTER_ID_KEY;

		public static readonly string ENCOUNTER_STEP_ID_KEY;

		public static readonly string ENCOUNTER_SUPPRESS_REWARDS_KEY;

		private static List<Enemy> NEJCMDCDJOD;

		protected List<Enemy> PJDONKHAMDM;

		private Dictionary<string, object> ELCNOFLBCKI;

		public override void OnAwake(GameEncounter CGBFJFNKJFN, int GNNALAJAMKB, KBJKDKFNFIA KLIJMCAEKKB, KBJKDKFNFIA CIMGEOHGFJK)
		{
		}

		public override void OnCleanup()
		{
		}

		public override void OnEncounterStart()
		{
		}

		public override void OnEncounterStop()
		{
		}

		protected virtual Enemy CACOHKFCJIN(EncounterEnemyDescriptor AMCFCAMIGKC, bool EMIEDCJNPDE, out bool MFGOAHDEJPH)
		{
			MFGOAHDEJPH = default;
			return null;
		}

		protected virtual bool NOPEMFOCEHF(EncounterEnemyDescriptor AMCFCAMIGKC, out Vector3 INKGHPCDMCG, out Quaternion OOFIIEKBKAE)
		{
			INKGHPCDMCG = default;
			OOFIIEKBKAE = default;
			return false;
		}

		protected virtual void NHPHCIKGECN(Vector3 INKGHPCDMCG, Quaternion OOFIIEKBKAE, out Vector3 PAGOHCBOIPE, out Quaternion MCMPEHACGHN)
		{
			PAGOHCBOIPE = default;
			MCMPEHACGHN = default;
		}

		private void EJPNGJIPKFK(Enemy DPENEFKKNDN)
		{
		}

		private void KKALBOOJCFA(Enemy DPENEFKKNDN, DPMOPDDAJBJ NJDHAACHDKF)
		{
		}

		private bool HFAPAFLOKEA(Enemy DPENEFKKNDN)
		{
			return false;
		}

		public void MasterKillAllLivingEnemies()
		{
		}

		protected int JOFHNNJCNHL()
		{
			return 0;
		}
	}
}
