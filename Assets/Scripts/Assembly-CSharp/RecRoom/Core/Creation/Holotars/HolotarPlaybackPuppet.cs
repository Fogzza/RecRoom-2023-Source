using System;
using RecRoom.Audio;
using RecRoom.Players.Puppet;
using UnityEngine;
using UnityEngine.Audio;

namespace RecRoom.Core.Creation.Holotars
{
	public class HolotarPlaybackPuppet : PlayerPuppet
	{
		private const float FKJPBNFHAOA = 0.01f;

		[SerializeField]
		private AudioSource audioSource;

		[SerializeField]
		private DirectionalAudioSource directionalAudioSource;

		[SerializeField]
		private AudioSourceSimpleLevelMeter levelMeter;

		public bool Loop;

		public bool PlayHolographicOverlayEffect;

		public Action OnPlaybackComplete;

		private AudioClip HFMBEKEICOC;

		private OIBICOBOMHD GPPFBDGJCLD;

		protected LHFOEGBJHLN GLLFHCCFIGK;

		private bool DHMILHOAGJP;

protected override HDPAHKBCHKD DFFGLFMJPMI
{
get 		{
			return null;
		}

}

public bool IsPlaying
{
get 		{
			return false;
		}

}

public float Volume
{
get 		{
			return 0f;
		}

set {
		}
}

public bool Uses2DAudio
{
get 		{
			return false;
		}

set {
		}
}

public AudioMixerGroup AudioChannel
{
get 		{
			return null;
		}

set {
		}
}

public float Timestamp
{
get 		{
			return 0f;
		}

}

public float NormalizedTimestamp
{
get 		{
			return 0f;
		}

}

private bool JLJKANCHNOL
{
get 		{
			return false;
		}

}

		protected void Awake()
		{
		}

		protected override void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		public void Initialize(FPDMEIABFON PCPEJHIMHJJ)
		{
		}

		public void RefreshFromData()
		{
		}

		public void Play()
		{
		}

		public void Pause()
		{
		}

		public void Stop(bool BMKMGIJJBKM = true)
		{
		}

		protected override void DDMNBCGHGGD()
		{
		}

		private void EFIHKDDAOEJ()
		{
		}

		private void BJPCMPKGEOL(AudioClip DLLECDOAMDE)
		{
		}

		public void SetTime(float BBGNJMKOHPL)
		{
		}

		private void ANJFMJJHOJB(NOMDJBMGHMJ HNGJGPJCNBJ)
		{
		}

		private void KCDFLOOODED()
		{
		}
	}
}
