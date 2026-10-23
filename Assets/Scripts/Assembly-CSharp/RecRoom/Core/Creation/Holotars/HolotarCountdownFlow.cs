using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using RecRoom.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Core.Creation.Holotars
{
	public class HolotarCountdownFlow : RecordableUIFlow
	{
		private sealed class NOPBKGJMCML : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HolotarCountdownFlow _003C_003E4__this;

			private SFXAudioSource _003Csfx_003E5__2;

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
			public NOPBKGJMCML(int _003C_003E1__state)
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

		[SerializeField]
		private int countdownLength;

		[SerializeField]
		private Text timeLabel;

		[SerializeField]
		private Image countdownFillImage;

		[SerializeField]
		private RecRoomAudioClip beepSfx;

		[SerializeField]
		private RecRoomAudioClip recordingStartSfx;

		[SerializeField]
		private int audioLatencyWaitMs;

		private float IOFAEAHGBGJ;

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		private IEnumerator BLAIFOLKHLI()
		{
			return null;
		}

		private void OLDNMNIEIII()
		{
		}

		public void Button_CancelCountdown()
		{
		}
	}
}
