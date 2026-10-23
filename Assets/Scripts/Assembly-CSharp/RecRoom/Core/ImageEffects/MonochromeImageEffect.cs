using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RecRoom.Core.ImageEffects
{
	[DisallowMultipleComponent]
	public class MonochromeImageEffect : MonoBehaviour
	{
		private sealed class DACLHGACOGJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MonochromeImageEffect _003C_003E4__this;

			public float target;

			public float time;

			private float _003Cvelocity_003E5__2;

			private float _003Ct_003E5__3;

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
			public DACLHGACOGJ(int _003C_003E1__state)
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

		private sealed class PEPIPFBMLIN : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MonochromeImageEffect _003C_003E4__this;

			public float target;

			public float time;

			private float _003Cvelocity_003E5__2;

			private ComfortEffects _003CcomfortEffects_003E5__3;

			private float _003Ct_003E5__4;

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
			public PEPIPFBMLIN(int _003C_003E1__state)
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

		private Coroutine BKFGEKADLAF;

		private VolumeProfile HDIBHMLMKIM;

		private float NKMJFOEILPC;

public bool IsMonochrome
{
get 		{
			return false;
		}

}

public float MonochromeAmount
{
get 		{
			return 0f;
		}

private set {
		}
}

		public void Initialize(VolumeProfile HDIBHMLMKIM)
		{
		}

		public void LerpToMonochromeAmount(float CFLPHICBCLC, float DOJCHFLNMEE = 0.2f)
		{
		}

		private IEnumerator JKDGBDKAHLH(float GFCPAMJILIO, float BBGNJMKOHPL)
		{
			return null;
		}

		private IEnumerator LOPNNBGLNFM(float GFCPAMJILIO, float BBGNJMKOHPL)
		{
			return null;
		}
	}
}
