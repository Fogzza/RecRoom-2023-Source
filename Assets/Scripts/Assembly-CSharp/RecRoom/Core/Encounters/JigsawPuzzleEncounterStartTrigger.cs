using RecRoom.Activities.Quest;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class JigsawPuzzleEncounterStartTrigger : GameEncounterStartTrigger
	{
		[SerializeField]
		private JigsawPuzzle puzzle;

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
