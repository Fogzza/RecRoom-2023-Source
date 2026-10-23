using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class PlayAudioEncounterStep : GameEncounterStep
	{
		public enum JFBFFNJLEAG
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1
		}

		private enum ANDAPMKOIMP
		{
			TWO_DIMENSIONAL = 0,
			THREE_DIMENSIONAL = 1
		}

		[SerializeField]
		private RecRoomAudioClip audioClip;

		[SerializeField]
		private ANDAPMKOIMP audioType;

		[SerializeField]
		private Transform threeDimensionalTransform;

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
