using System;

namespace RecRoom.Core.Encounters
{
	[Serializable]
	public struct RandomlyEnabledGameEncounterDesc
	{
		public GameEncounter Encounter;

		public float EnabledChance;
	}
}
