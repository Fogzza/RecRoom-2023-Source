using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class FadeLocalPlayerCameraEncounterStep : GameEncounterStep
	{
		public enum FOLKLONLIOH
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1,
			AFTER_FADE_COMPLETES = 2
		}

		protected enum ONHKPEBLNCF
		{
			FADE_IN = 0,
			FADE_OUT = 1
		}

		protected enum EKHHNCJNIOM
		{
			DEFAULT = 0,
			SINGLE_FRAME = 1,
			CUSTOM = 2
		}

		[SerializeField]
		protected ONHKPEBLNCF fadeType;

		[SerializeField]
		protected EKHHNCJNIOM fadeDuration;

		[SerializeField]
		protected float customFadeDuration;

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
