using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Core.Encounters;
using UnityEngine;

namespace RecRoom.Activities.Arena
{
	public class ArenaEncounterSpawner : MonoBehaviourPun
	{
		[SerializeField]
		private int maxTeamEncountersRunning;

		[SerializeField]
		private float encounterSpawnPeriod;

		[SerializeField]
		private GameEncounter initialEncounterPrefab;

		[SerializeField]
		private GameEncounter[] encounterPrefabs;

		private List<GameEncounter> HLJOODHMKGC;

		private List<GameEncounter> GKBJAIDKICI;

public int MaxTeamEncountersRunning
{
get 		{
			return 0;
		}

}

public float EncounterSpawnPeriod
{
get 		{
			return 0f;
		}

}

public GameEncounter InitialEncounterPrefab
{
get 		{
			return null;
		}

}

public GameEncounter[] EncounterPrefabs
{
get 		{
			return null;
		}

}

public int RunningEncounterCount
{
get 		{
			return 0;
		}

}

		public int GetRunningEncounterCountByTeam(GIBEGHKMCIE PBDNEPMBBOI)
		{
			return 0;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public GameEncounter MasterSpawnEncounter(GameEncounter GBGDGAKLGAJ, Transform GFAKOIEKNEM, GIBEGHKMCIE NEBNOBLPNEP, EnemyPatrol MKMEEOCJIBJ = null)
		{
			return null;
		}

		public GameEncounter MasterSpawnEncounter(EncounterDescriptor GAIDFOFCDHJ, GIBEGHKMCIE NEBNOBLPNEP)
		{
			return null;
		}

		public void MasterDestroyAllActiveEncounters()
		{
		}

		private void GBOPBMENLEO(GameEncounter PBPDPOHAINJ)
		{
		}

		private void PIBEDNNNOCE(GameEncounter CGBFJFNKJFN)
		{
		}

		private bool GOBDFMOPPKH(GameEncounter CGBFJFNKJFN)
		{
			return false;
		}
	}
}
