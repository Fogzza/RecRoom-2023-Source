using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleBoostAudio : VehicleAudio
	{
		public enum POBCFCJCNMB
		{
			RAMP_UP = 0,
			BOOST = 1,
			RAMP_DOWN = 2,
			MISFIRE = 3
		}

		[SerializeField]
		protected Transform boostAudioTargetTransform;

		[SerializeField]
		protected Transform boostButtonAudioTargetTransform;

		[SerializeField]
		protected RecRoomAudioClip rampUpSound;

		[SerializeField]
		protected RecRoomAudioClip rampDownSound;

		[SerializeField]
		protected RecRoomAudioClip boostingSound;

		[SerializeField]
		protected RecRoomAudioClip boostMisfireSound;

		[SerializeField]
		protected RecRoomAudioClip boostReadySound;

		[SerializeField]
		protected float stackingPitchShiftModifierAdditive;

		[SerializeField]
		protected float stackingPitchShiftModifierMultiplier;

		[SerializeField]
		protected float stackingVolumeModifier;

		private int ONEJBLDGEEL;

		private SFXAudioSource GDLCCPKKNOH;

		public void OnBoostMisfire()
		{
		}

		public void OnBoostStart()
		{
		}

		public void OnBoostEnd()
		{
		}

		public void OnBoostReady()
		{
		}

		public void ResetBoostAudio(bool BFNJILCAGGA)
		{
		}

		public void SetActiveBoosts(int FNEHEACLKOK)
		{
		}
	}
}
