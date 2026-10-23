using RecRoom.Activities.Quest;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class ChangeStoryStateEncounterStep : GameEncounterStep
	{
		[SerializeField]
		private bool changeStoryState;

		[SerializeField]
		private QuestManager.PCGJIMCMLHD newStoryState;

		[SerializeField]
		private bool changeRoomStoryState;

		[SerializeField]
		private QuestManager.PCGJIMCMLHD newRoomStoryState;

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
