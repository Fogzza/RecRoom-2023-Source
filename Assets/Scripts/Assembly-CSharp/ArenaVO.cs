using System;
using RecRoom.Audio;
using UnityEngine;

public class ArenaVO : MonoBehaviour
{
	[Serializable]
	public class TeamVO
	{
		public GIBEGHKMCIE team;

		public string TeamName;

		public RecRoomAudioClip JoinVO;

		public RecRoomAudioClip CloseToVictoryVO;

		public RecRoomAudioClip TookTheLeadVO;
	}

	public RecRoomAudioClip gameTitleAnnouncementVO;

	public RecRoomAudioClip gameInstructionsVO;

	public RecRoomAudioClip teamNearingVictoryMusic;

	public TeamVO[] teams;

	public TeamVO GetTeam(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}
}
