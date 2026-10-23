using System;
using UnityEngine;

namespace RecRoom.Tools
{
	[Serializable]
	public struct DynamicAudioClip
	{
		public AudioClip AudioClip;

		public AnimationCurve IntensityOverDynamicRange;

		public bool HasDynamicPitch;

		[SerializeField]
		public AnimationCurve PitchOverDynamicRange;
	}
}
