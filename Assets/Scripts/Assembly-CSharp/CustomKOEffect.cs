using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CustomKOEffect : MonoBehaviour
{
	private sealed class AHJCAIECJLE : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomKOEffect _003C_003E4__this;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public AHJCAIECJLE(int _003C_003E1__state)
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
	private float delayTimeBeforeThrob;

	private ThrobbingUIElement DIEHDEIEIGE;

	private ParticleSystem[] JHNNFNJDMGL;

	private Animator CBCFEAPCGEO;

	private Image GFLKOLMKJBC;

	private Coroutine GNDIDONDAEO;

public Image Sprite
{
get 	{
		return null;
	}

private set {
	}
}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private IEnumerator HOPPIPPPLND()
	{
		return null;
	}

	private void OnDisable()
	{
	}
}
