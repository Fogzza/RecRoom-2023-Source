using RecRoom.Activities.Quest;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class ActivateCheckpointEncounterStep : GameEncounterStep
	{
		public enum BIHAICHAOAN
		{
			CURRENT_STATE = 0,
			SPECIFY_STATE = 1
		}

		[SerializeField]
		public BIHAICHAOAN checkpointType;

		[SerializeField]
		public int checkpointRoomIndex;

		[SerializeField]
		public QuestManager.PCGJIMCMLHD checkpointStoryState;

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
