using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class SpotlightEncounterStep : GameEncounterStep
	{
		public enum EEAFFOPNGPO
		{
			IMMEDIATELY = 0,
			TIME_ELAPSED = 1
		}

		public enum HBNPGPMFFLC
		{
			ENABLE_SPOTLIGHTS = 0,
			DISABLE_SPOTLIGHTS = 1
		}

		[SerializeField]
		public Light[] spotlights;

		[SerializeField]
		public EncounterSpotlightModel[] models;

		[SerializeField]
		public HBNPGPMFFLC mode;

		[SerializeField]
		public bool disableAfterEncounter;

public override string Description
{
get 		{
			return null;
		}

}

		private void KNMEKPBMFGM(bool BFDBCMGIOBG)
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
	}
}
