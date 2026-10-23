using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class ActivateDeactivateGameObjectEncounterStep : GameEncounterStep
	{
		public enum KCIMHJJHAEH
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		public enum AAODKCOMPJF
		{
			NONE = -1,
			ACTIVATE = 0,
			DEACTIVATE = 1
		}

		[SerializeField]
		private GameObject targetObject;

		[SerializeField]
		private AAODKCOMPJF onEnableAction;

		[SerializeField]
		private AAODKCOMPJF onStepAction;

public override string Description
{
get 		{
			return null;
		}

}

		public void OnEnable()
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

		private void MIPMGLBKODB(AAODKCOMPJF IBKGKDECOEG)
		{
		}
	}
}
