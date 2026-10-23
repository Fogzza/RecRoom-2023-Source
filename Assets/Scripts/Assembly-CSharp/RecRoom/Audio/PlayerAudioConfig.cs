using System;
using UnityEngine;

namespace RecRoom.Audio
{
	[Serializable]
	public class PlayerAudioConfig : ScriptableObject
	{
		public AudioRolloff defaultVoiceRolloff;

		public AnimationCurve defaultVoiceLowPassRolloff;

		public AnimationCurve directionalVoiceSourceAngleRolloff;

		public AnimationCurve directionalVoiceListenerAngleRolloff;
	}
}
