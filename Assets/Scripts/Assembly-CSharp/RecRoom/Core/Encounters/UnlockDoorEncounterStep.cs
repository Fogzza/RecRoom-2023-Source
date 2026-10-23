using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class UnlockDoorEncounterStep : GameEncounterStep
	{
		public enum HBFKCHAIGJG
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		[SerializeField]
		public LockableDoor door;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnEncounterActivate()
		{
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
