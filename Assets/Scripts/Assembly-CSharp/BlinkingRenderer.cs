using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BlinkingRenderer : MonoBehaviour
{
	private sealed class KPAAHEAHOCN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float frequency;

		public BlinkingRenderer _003C_003E4__this;

		private float _003Ctimer_003E5__2;

		private float _003Cperiod_003E5__3;

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
		public KPAAHEAHOCN(int _003C_003E1__state)
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
	private RendererMaterialPair[] renderers;

	[SerializeField]
	private FloatValueCurve blinkIntensityCurve;

	[SerializeField]
	private string colorShaderPropertyName;

	[SerializeField]
	private bool playOnAwake;

	[SerializeField]
	private float playOnAwakeFrequency;

	private int IDBMLDFHBBJ;

	private Color[] DJEAEPOONOM;

	private Coroutine CEEDAIBOPLJ;

	private float EBECFLBGBIE;

private float DBLMMLDCEHK
{
get 	{
		return 0f;
	}

set {
	}
}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void StartBlinking(float DMOIMIACENF)
	{
	}

	public void StopBlinking()
	{
	}

	private IEnumerator HMHOFHEDDLB(float DMOIMIACENF)
	{
		return null;
	}

	private void OIMKEHDFAGF()
	{
	}
}
