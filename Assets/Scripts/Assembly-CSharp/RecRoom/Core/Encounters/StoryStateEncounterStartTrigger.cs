using RecRoom.Activities.Quest;
using UnityEngine;

namespace RecRoom.Core.Encounters
{
	public class StoryStateEncounterStartTrigger : GameEncounterStartTrigger
	{
		public enum OFPJLBICPJI
		{
			STORY_STATE = 0,
			ROOM_STORY_STATE = 1,
			STORY_AND_ROOM_STORY_STATE = 2,
			STORY_OR_ROOM_STORY_STATE = 3
		}

		[SerializeField]
		private OFPJLBICPJI triggerOn;

		[SerializeField]
		private QuestManager.PCGJIMCMLHD storyState;

		[SerializeField]
		private QuestManager.PCGJIMCMLHD roomStoryState;

public override string Description
{
get 		{
			return null;
		}

}

		public override void StartListening()
		{
		}

		public override void StopListening()
		{
		}

		public override bool IsTriggered()
		{
			return false;
		}
	}
}
