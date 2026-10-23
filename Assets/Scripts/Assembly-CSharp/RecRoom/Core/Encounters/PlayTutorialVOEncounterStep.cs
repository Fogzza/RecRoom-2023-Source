using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class PlayTutorialVOEncounterStep : GameEncounterStep
	{
		public enum CKMMJGIJMCK
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1,
			VO_DURATION = 2
		}

		public enum DMEPHBPMHLE
		{
			AUDIO_CLIP = 0,
			TUTORIAL_AUDIO_CONFIG = 1
		}

		[SerializeField]
		protected DMEPHBPMHLE sourceType;

		[SerializeField]
		protected RecRoomAudioClip audioClip;

		[SerializeField]
		protected TutorialManager.ACLOGGPNLDF tutorialAudioType;

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
