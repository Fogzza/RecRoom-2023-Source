using System;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	[Serializable]
	public class QuestGearConfig : ScriptableObject
	{
		public JMGADHIDPHD campaign;

		public int minNumberOfItemsSpawnedPerDrop;

		public int maxNumberOfItemsSpawnedPerDrop;

		public QuestGearEntry[] gearTypes;

		public SpawnableTool[] toolsToNotDestroyOnReset;

		public QuestGear customGearBehavior;
	}
}
