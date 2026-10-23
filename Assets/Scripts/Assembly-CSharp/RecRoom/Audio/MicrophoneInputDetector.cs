using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Voice.Unity;
using UnityEngine;

namespace RecRoom.Audio
{
	public class MicrophoneInputDetector : MonoBehaviour
	{
		private sealed class JNECPGBPBJL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public Recorder recorder;

			public MicrophoneInputDetector _003C_003E4__this;

			private PBHHMLHHACM _003Cwait_003E5__2;

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
			public JNECPGBPBJL(int _003C_003E1__state)
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

		private const float HADLOMNFBON = 1E-05f;

		private LKGILLBEJEK HKJPIKLMFFE;

		private static bool GEMMAGOMFLN;

public static bool HasEverDetectedInput
{
get 		{
			return false;
		}

set {
		}
}

		public JKHCJAJHGAO StartListening(Recorder GGLNKPFPBCB)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> AIOONMNBGJF(Recorder KIMNMHOFCGD)
		{
			return null;
		}
	}
}
