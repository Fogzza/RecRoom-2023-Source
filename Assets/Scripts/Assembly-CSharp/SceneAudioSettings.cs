using System;
using RecRoom.Audio;
using UnityEngine;

[Serializable]
public class SceneAudioSettings : NMIKADGOIOE
{
	[SerializeField]
	private bool hasCustom3DSFXRolloff;

	[SerializeField]
	private AudioRolloff custom3DSFXRolloff;

	[SerializeField]
	private RecRoomAudioClip[] customTeleportSounds;

	[SerializeField]
	private bool hasCustomWalkSounds;

	[SerializeField]
	private RecRoomAudioClipPoolConfig customWalkSoundPreset;

	[SerializeField]
	private RecRoomAudioClip[] customWalkSoundsIfNoCustomWalkSoundsPreset;

	[SerializeField]
	private RecRoomAudioClip ambientAudio;

	[SerializeField]
	private RecRoomAudioClip loadingGameMusic;

	[SerializeField]
	private RecRoomAudioClip gameplayMusic;

	[SerializeField]
	private ExtendedRecRoomAudioClips actionMusic;

	[SerializeField]
	private RecRoomAudioClip fanfareMusic;

	public static EEANDDJEMJC UseDirectionalVoiceChatChangedEvent;

	private global::MOBDJNEDDKC<bool> _useDirectionalVoiceChat;

	public bool UseDirectionalVoiceChat
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void JGHENDHCBHF(RecRoomSceneManager MACMCOFLIIO)
	{
	}

	public void LJODMHLJPAD()
	{
	}

	public void BJDNGFKFKPK()
	{
	}

	public void CDJHKCNAIKI()
	{
	}

	public void KPFOBOPDHJM()
	{
	}

	private void BGGAELJBGDF()
	{
	}
}
