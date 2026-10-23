using System;
using RecRoom.Audio;

namespace RecRoom.Core.GameManagement
{
	[Serializable]
	public class EditorGameRuleConfiguration
	{
		public Ranking Rankings;

		public string CustomRankName;

		public IIGLDDDANPN AlternateGiftContext;

		public ProximityScoreSettings TeammateSpawnPointProximityScoreSettings;

		public ProximityScoreSettings OpponentSpawnPointProximityScoreSettings;

		public bool MovementModeSwitchDuringGameSupported;

		public float MovementModeSwitchDuringGameGracePeriod;

		public RecRoomAudioClip GameNameVO;

		public bool HasNotificationSFX;

		public RecRoomAudioClip NotificationSFX;

		public bool HasRichPresenceString;

		public string RichPresenceString;

		public bool HasLocalPlayerStatusString;

		public string LocalPlayerStatusString;
	}
}
