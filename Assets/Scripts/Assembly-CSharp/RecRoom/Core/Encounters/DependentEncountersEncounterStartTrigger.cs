using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class DependentEncountersEncounterStartTrigger : GameEncounterStartTrigger
	{
		private enum ABLLEHAHEEA
		{
			FINISHED = 0,
			RUNNING = 1,
			WAITING_FOR_TRIGGER = 2,
			INACTIVE = 3
		}

		[SerializeField]
		public GameEncounter[] dependentEncounters;

		[SerializeField]
		private ABLLEHAHEEA encounterRequirement;

public override string Description
{
get 		{
			return null;
		}

}

		public override void StartListening()
		{
		}

		public override void StopListening()
		{
		}

		public override bool IsTriggered()
		{
			return false;
		}

		private bool AMHBGKEGMOA(GameEncounter CGBFJFNKJFN)
		{
			return false;
		}
	}
}
