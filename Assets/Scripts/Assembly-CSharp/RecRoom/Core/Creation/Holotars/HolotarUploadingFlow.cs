using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Core.Creation.Holotars
{
	public class HolotarUploadingFlow : RecordableUIFlow
	{
		private sealed class CPMFPDEOCGJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HolotarUploadingFlow _003C_003E4__this;

			private string _003CbaseMessage_003E5__2;

			private string _003Cmessage_003E5__3;

			private int _003Cdots_003E5__4;

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
			public CPMFPDEOCGJ(int _003C_003E1__state)
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

		private sealed class JNNDDLFGPOP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HolotarUploadingFlow _003C_003E4__this;

			public string message;

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
			public JNNDDLFGPOP(int _003C_003E1__state)
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

		private const int KHEHFAMMMOG = 1;

		private const int OFECNFKHIDB = 3;

		[SerializeField]
		private Text label;

		private Coroutine EHDDHEKNPJA;

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public void MarkSuccess()
		{
		}

		public void MarkFailure()
		{
		}

		private IEnumerator NFBPPLEIHGC()
		{
			return null;
		}

		private IEnumerator ADHMILAADOC(string OFCFPGACNJB)
		{
			return null;
		}
	}
}
