using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class TransformChangeTracker5Hz : MonoBehaviour
	{
		private sealed class LPAFGLDHJAA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TransformChangeTracker5Hz _003C_003E4__this;

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
			public LPAFGLDHJAA(int _003C_003E1__state)
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

		private Matrix4x4 LNJOGIJLMHA;

		private Transform DGCPFANJPJN;

		private Action<Transform> AOOCBHFNDBL__BackingField;

public event Action<Transform> TransformChanged {
add {
		}
remove {
		}
}

		private IEnumerator Start()
		{
			return null;
		}

		private void PEOPJAFNOBD(float OKBAJEAPIHG)
		{
		}
	}
}
