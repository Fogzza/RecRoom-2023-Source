using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Activities.Vehicles;
using RecRoom.Audio;
using UnityEngine;

public class BrakeHandleAudio : MonoBehaviour
{
	private sealed class NIFOPMNHAHG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public BrakeHandleAudio _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NIFOPMNHAHG(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private GroundVehicle vehicle;

	[SerializeField]
	private RecRoomAudioClip engagedSfx;

	[SerializeField]
	private RecRoomAudioClip disengagedSfx;

	[SerializeField]
	private RecRoomAudioClip tireSquealSfx;

	[SerializeField]
	private float tireSquealSFXDelay;

	[SerializeField]
	private float tireSquealSFXTriggerSpeedThreshold;

	private bool DNOGNPNEMFL;

	private bool OGGBJBEINKA;

	private SFXAudioSource JGMDHNCKNHI;

	public void PlayStateChangeSfx(bool IJFCKLELEDJ)
	{
	}

	private void PMHEEHALFBL(bool IJFCKLELEDJ)
	{
	}

	private IEnumerator<EGGPGCCKPCO> DDCHOFCPEBF()
	{
		return null;
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void KPCLLNALCCD()
	{
	}
}
