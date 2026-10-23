using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class WheelSuspensionAudio : VehicleAudio
	{
		private enum LLEAGAAPHEL
		{
			NONE = 0,
			LIGHT = 1,
			HEAVY = 2
		}

		[SerializeField]
		private WheelSuspension[] wheelSuspensions;

		[SerializeField]
		private RecRoomAudioClip[] lightCompressionClips;

		[SerializeField]
		private RecRoomAudioClip[] heavyCompressionClips;

		[SerializeField]
		private float suspensionAudioCooldown;

		[SerializeField]
		private float lightCompressionSpeedThreshold;

		[SerializeField]
		private float maxLightCompressionVolume;

		[SerializeField]
		private AnimationCurve lightCompressionSpeedToVolumeCurve;

		[SerializeField]
		private float heavyCompressionSpeedThreshold;

		[SerializeField]
		private float maxHeavyCompressionVolume;

		[SerializeField]
		private AnimationCurve heavyCompressionSpeedToVolumeCurve;

		[SerializeField]
		private float compressionAmountThreshold;

		private float GDELPIACDBO;

		private float LIOPIBKCBBF;

		private float GBJAIJLIPGM;

private bool OELGEEKFCFC
{
get 		{
			return false;
		}

}

private bool GIGDBJEPCAI
{
get 		{
			return false;
		}

}

		private void Update()
		{
		}

		private LLEAGAAPHEL KCPLNFDFBNI()
		{
			return LLEAGAAPHEL.NONE;
		}

		private void OEICGCEFHAA(LLEAGAAPHEL NIFOGEBEDNG)
		{
		}
	}
}
