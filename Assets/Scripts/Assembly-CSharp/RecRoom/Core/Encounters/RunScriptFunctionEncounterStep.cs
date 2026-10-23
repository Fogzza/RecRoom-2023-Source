using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.Core.Encounters
{
	public class RunScriptFunctionEncounterStep : GameEncounterStep
	{
		public enum OHKFMFJHJBA
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		[SerializeField]
		private UnityEvent functionsToRun;

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
