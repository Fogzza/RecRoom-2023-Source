using System;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleCollisionsAudio : VehicleAudio
	{
		[Serializable]
		private class ImpactAudioConfig
		{
			public RecRoomAudioClip[] impactClips;

			public AnimationCurve impactSpeedToVolumeCurve;

			public float impactSFXMinimalInterval;

			[HideInInspector]
			public float lastTimeImpactSFXPlayed;
		}

		private enum NCPACGJGBJJ
		{
			STATIC = 0,
			STATIC_HEAVY = 1,
			LANDING = 2,
			DYNAMIC = 3,
			PLAYER = 4
		}

		[SerializeField]
		private ImpactAudioConfig staticImpactAudioConfig;

		[SerializeField]
		private ImpactAudioConfig staticHeavyImpactAudioConfig;

		[SerializeField]
		private ImpactAudioConfig landingImpactAudioConfig;

		[SerializeField]
		private ImpactAudioConfig dynamicImpactAudioConfig;

		[SerializeField]
		private ImpactAudioConfig playerImpactAudioConfig;

		[SerializeField]
		private GameObject skidPlate;

		[SerializeField]
		private float staticHeavyCollisionSFXTriggerSpeedThreshold;

		[SerializeField]
		private float playerCollisionSFXTriggerSpeedThreshold;

		public void PlayVehicleEnvironmentCollisionSFX(float MJPKOMEINCJ, Vector3 HPCMNGNFNBF, Vector3 MCKFCCNKIND, Collider HMANBCOGNNK, Vector3 HEELFJDJPGM)
		{
		}

		public void PlayVehicleObjectCollisionSFX(float MJPKOMEINCJ, Vector3 HPCMNGNFNBF)
		{
		}

		public void PlayVehiclePlayerCollisionSFX(float MJPKOMEINCJ, Vector3 HPCMNGNFNBF)
		{
		}

		private void LGHCIDECMIN(NCPACGJGBJJ OEBDOJJPDMN, float MJPKOMEINCJ, Vector3 HPCMNGNFNBF)
		{
		}

		private ImpactAudioConfig PFNOKILBJKD(NCPACGJGBJJ OEBDOJJPDMN)
		{
			return null;
		}
	}
}
