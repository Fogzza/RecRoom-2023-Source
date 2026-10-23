using System.Collections.Generic;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.StuntRunner
{
	public class CheckpointOverlapVolume : OverlapVolume
	{
		[SerializeField]
		private SpawnPoint respawnPoint;

		[SerializeField]
		private ParticleSystem[] checkpointReachedVFX;

		[SerializeField]
		private RecRoomAudioClip[] checkpointReachedSFX;

		protected static List<CheckpointOverlapVolume> GGBHALOFGIH;

		private bool MACLCBAOIFO;

		private SpawnPoint FKHOIGJBFIN;

public static IReadOnlyCollection<CheckpointOverlapVolume> AllCheckpoints
{
get 		{
			return null;
		}

}

public bool FeedbackPlayed
{
get 		{
			return false;
		}

set {
		}
}

public SpawnPoint RespawnPoint
{
get 		{
			return null;
		}

}

public SpawnPoint ClosestRespawnPoint
{
get 		{
			return null;
		}

set {
		}
}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void PlayCheckpointReachedFeedback()
		{
		}
	}
}
