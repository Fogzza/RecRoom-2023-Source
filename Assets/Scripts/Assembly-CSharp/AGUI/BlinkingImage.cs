using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI
{
	[DisallowMultipleComponent]
	public class BlinkingImage : MonoBehaviour
	{
		private sealed class OFBKMGLPPKC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BlinkingImage _003C_003E4__this;

			private float _003Ct_003E5__2;

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
			public OFBKMGLPPKC(int _003C_003E1__state)
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
		private Image _image;

		[SerializeField]
		private float blinkDuration;

		[SerializeField]
		private Color blinkColor;

		private Color HHMGLMDHBPE;

		private Color OFDGLKDBIMM;

		private Coroutine CEGPLCGIGIG;

public Image Image
{
get 		{
			return null;
		}

}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private IEnumerator HAGKAEMBBCD()
		{
			return null;
		}
	}
}
