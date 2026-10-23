namespace RecRoom.Core.Encounters
{
	public class DoNothingEncounterStep : GameEncounterStep
	{
		public enum BPIEJHEDMHD
		{
			TIME_ELAPSED = 0,
			IMMEDIATELY = 1,
			STORY_STATE = 2,
			ROOM_STORY_STATE = 3,
			ROOM_STORY_STATE_GREATER_THAN = 4,
			ROOM_STORY_STATE_LESS_THAN = 5
		}

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
