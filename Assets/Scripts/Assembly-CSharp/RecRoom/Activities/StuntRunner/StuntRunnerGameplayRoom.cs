using RecRoom.Activities.Quest;
using TMPro;
using UnityEngine;

namespace RecRoom.Activities.StuntRunner
{
	public class StuntRunnerGameplayRoom : QuestGameplayRoom
	{
		[SerializeField]
		private int statChannel;

		public StuntRunnerScoreBoard StuntRunnerScoreBoard;

		public StuntRunnerScoreBoard StuntRunnerLeaderBoard;

		public StuntRunnerScoreBoard GameStartTotalScoreBoard;

		public StuntRunnerScoreBoard[] GameEndScoreBoards;

		public StuntRunnerScoreBoard GameEndTotalScoreBoard;

		public StuntRunnerScoreBoard GameEndLeaderBoard;

		public TextMeshProUGUI[] courseTimers;

		[SerializeField]
		private GamePlayerSpawnPoint postRunSpawnPoint;

		private float DJIJBDDKECP;

public int StatChannelForLeaderboard
{
get 		{
			return 0;
		}

}

protected override bool CLPNMIMEFAL
{
get 		{
			return false;
		}

}

public GamePlayerSpawnPoint PostRunSpawnPoint
{
get 		{
			return null;
		}

}

		public void UpdateCourseTimers(int DEHFPCEDFCD)
		{
		}

		public void PauseCourseTimers(int GKIDNGHEEMO, float HPJFMBPKJBG)
		{
		}

		public void TeleportPlayerToPostRunSpawnPoint(Player EKOFNPFCLMO)
		{
		}
	}
}
