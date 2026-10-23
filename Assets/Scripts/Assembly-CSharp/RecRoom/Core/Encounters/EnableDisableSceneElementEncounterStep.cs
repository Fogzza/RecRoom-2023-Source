using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class EnableDisableSceneElementEncounterStep : GameEncounterStep
	{
		public enum GKGKIPEDGGE
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		public enum DLBAIGNIBDE
		{
			ENABLE = 0,
			DISABLE = 1
		}

		[SerializeField]
		private DLBAIGNIBDE action;

		[SerializeField]
		private GameObject[] affectedObjects;

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

		private void FENOBKDKKGM(bool OBFHBDLKFPA)
		{
		}
	}
}
