using System;
using RecRoom.Audio;

namespace RecRoom.Tools
{
	[Serializable]
	public struct DynamicAudioLoopContent
	{
		public RecRoomAudioClip LoopStartSfx;

		public RecRoomAudioClip LoopEndSfx;

		public DynamicAudioClip[] LoopingAudioClips;

		public float FadeInTime;

		public float FadeOutTime;

		public float DynamicVolumeValueRange;

		public float DynamicPitchValueRange;
	}
}
