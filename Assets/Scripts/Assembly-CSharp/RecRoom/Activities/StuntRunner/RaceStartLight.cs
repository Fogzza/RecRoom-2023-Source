using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Activities.StuntRunner
{
	public class RaceStartLight : MonoBehaviour
	{
		[Serializable]
		private class LightingAnimationStop
		{
			public float Position;

			public float DelayTime;

			public float AnimateInTime;

			public AudioClip Sound;
		}

		private sealed class JPEGAOELFGJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RaceStartLight _003C_003E4__this;

			private float _003CpreviousStopPosition_003E5__2;

			private LightingAnimationStop[] _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			private LightingAnimationStop _003Cstop_003E5__5;

			private float _003CrecipTime_003E5__6;

			private float _003Ctime_003E5__7;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public JPEGAOELFGJ(int _003C_003E1__state)
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
		private Renderer _lightRenderer;

		private IDisposable GCLILDHCOOH;

		private int DPNAHHNNDKB;

		private MaterialPropertyBlock DEGOCMBBFDJ;

		[SerializeField]
		private LightingAnimationStop[] _stops;

		[SerializeField]
		private AudioSource _audioSource;

public float CurrentPosition
{
get 		{
			return 0f;
		}

set {
		}
}

public float PlayTime
{
get 		{
			return 0f;
		}

}

		public void Play()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private IEnumerator<EGGPGCCKPCO> BGJCBNEINCN()
		{
			return null;
		}
	}
}
