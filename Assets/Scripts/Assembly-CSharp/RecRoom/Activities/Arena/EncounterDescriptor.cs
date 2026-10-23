using System;
using RecRoom.Core.Encounters;
using UnityEngine;

namespace RecRoom.Activities.Arena
{
	[Serializable]
	public struct EncounterDescriptor
	{
		public GameEncounter EncounterPrefab;

		public Transform EncounterSpawnPoint;

		public EnemyPatrol OverridePatrol;
	}
}
