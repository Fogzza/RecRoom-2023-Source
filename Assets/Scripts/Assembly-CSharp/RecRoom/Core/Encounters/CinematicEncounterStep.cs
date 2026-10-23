using RecRoom.Core.Cinematics;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class CinematicEncounterStep : GameEncounterStep
	{
		public enum CNJIJDJLPDA
		{
			CINEMATIC_FINISHED = 0,
			TIME_ELAPSED = 1,
			IMMEDIATELY = 2
		}

		[SerializeField]
		public Cinematic cinematic;

public override string Description
{
get 		{
			return null;
		}

}

		public override void OnEncounterDeactivate()
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
