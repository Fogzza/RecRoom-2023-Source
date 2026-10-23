using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	[DisallowMultipleComponent]
	public class ChargeButton3D : Button3D
	{
		public delegate void MOKENBEFDAD(ChargeButton3D HHDMPJJAPJJ);

		private sealed class BPLGIJDLAMF : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ChargeButton3D _003C_003E4__this;

			private float _003CtimeElapsed_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public BPLGIJDLAMF(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}
		}

		private MOKENBEFDAD DKJDFBEOCHJ__BackingField;

		[SerializeField]
		private Image fillImage;

		[SerializeField]
		private float chargeDuration;

		[SerializeField]
		private float vibrationIntensity;

		[SerializeField]
		private RecRoomAudioClip chargeAudio;

		private SFXAudioSource JLHBHKCNIIP;

		private Coroutine COHCOBNOMME;

public event MOKENBEFDAD ChargedEvent {
add {
		}
remove {
		}
}

		protected override void OnDisable()
		{
		}

		protected override void JGHFDPCHPJJ(bool JGBEGFNGCKM = false)
		{
		}

		protected override void BCFAHLGGFLJ(bool JGBEGFNGCKM = false)
		{
		}

		protected override void KDPJHOOPHAL()
		{
		}

		private IEnumerator AILHLNOCONA()
		{
			return null;
		}

		private void PDJPGFFCLHC()
		{
		}
	}
}
