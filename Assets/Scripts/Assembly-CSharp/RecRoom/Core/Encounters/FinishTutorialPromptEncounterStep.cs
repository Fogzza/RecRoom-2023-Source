using RecRoom.Tutorials;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class FinishTutorialPromptEncounterStep : GameEncounterStep
	{
		public enum BGPALMEKLAC
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		[SerializeField]
		protected TutorialPromptManager.OEGOINFNJBC promptFinishType;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnEncounterStart()
		{
		}

		public override void OnEncounterStop()
		{
		}

		public override void OnStartRunning()
		{
		}

		public override void OnUpdateRunning()
		{
		}

		public override void OnStopRunning()
		{
		}

		public override void OnSkipRunning()
		{
		}

		public override bool IsBlockingEncounterEnd()
		{
			return false;
		}

		public override bool IsCompleted()
		{
			return false;
		}
	}
}
