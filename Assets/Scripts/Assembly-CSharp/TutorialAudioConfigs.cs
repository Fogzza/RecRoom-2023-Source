using System;
using RecRoom.Audio;
using UnityEngine;

public class TutorialAudioConfigs : ScriptableObject
{
	[Serializable]
	public class TutorialAudioConfig : HardwareTypeConfig<RecRoomAudioClip, AudioSet, HardwareTutorialAudio>
	{
		public TutorialManager.ACLOGGPNLDF AudioType;
	}

	[Serializable]
	public class HardwareTutorialAudio : HardwareSpecificConfig<RecRoomAudioClip>
	{
	}

	[Serializable]
	public class AudioSet : HardwareSpecificConfigSet<HardwareTutorialAudio, RecRoomAudioClip>
	{
		public override RecRoomAudioClip FBJHBFFDBDJ()
		{
			return null;
		}
	}

	[SerializeField]
	public TutorialAudioConfig[] Configs;

	public RecRoomAudioClip FGPEGONCJOO(TutorialManager.ACLOGGPNLDF PLCOIGCJCEF)
	{
		return null;
	}
}
