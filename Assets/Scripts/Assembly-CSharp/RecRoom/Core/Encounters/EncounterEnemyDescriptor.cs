using System;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	[Serializable]
	public class EncounterEnemyDescriptor
	{
		public KDBKBBGOBIP EnemyType;

		public Transform ExplicitSpawnPoint;

		public EnemyPatrol Patrol;

		public string ErrorString;
	}
}
