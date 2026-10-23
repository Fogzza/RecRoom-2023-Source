using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class EnableDisableToolEncounterStep : GameEncounterStep
	{
		public enum OCFFNJIEBCG
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		public enum KANFKEGFPBJ
		{
			ENABLE = 0,
			DISABLE = 1
		}

		[SerializeField]
		private KANFKEGFPBJ action;

		[SerializeField]
		private bool inverseActionDuringActivation;

		[SerializeField]
		private GameObject toolRoot;

		private Tool[] FJPKJJJFOCB;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnAwake(GameEncounter CGBFJFNKJFN, int GNNALAJAMKB, KBJKDKFNFIA KLIJMCAEKKB, KBJKDKFNFIA CIMGEOHGFJK)
		{
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

		private void JKKFJHNEKPP()
		{
		}

		private void OFMLKMIBHIN()
		{
		}

		private void JGGNNNOBCDO(bool OBFHBDLKFPA)
		{
		}
	}
}
