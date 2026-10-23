using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class TrapEncounterStartTrigger : GameEncounterStartTrigger
	{
		private enum HJLOIODAMPM
		{
			TRAP_IS_ENABLED = 0,
			TRAP_IS_DISABLED = 1
		}

		[SerializeField]
		private Trap trap;

		[SerializeField]
		private HJLOIODAMPM requirement;

public override string Description
{
get 		{
			return null;
		}

}

		public override bool IsTriggered()
		{
			return false;
		}

		public override void StartListening()
		{
		}

		public override void StopListening()
		{
		}
	}
}
