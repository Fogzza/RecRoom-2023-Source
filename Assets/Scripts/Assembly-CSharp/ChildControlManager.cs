using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChildControlManager : SingletonMonoBehaviour<ChildControlManager>
{
	private sealed class AMJBBNDELFO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChildControlManager _003C_003E4__this;

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
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public AMJBBNDELFO(int _003C_003E1__state)
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
	private float timeBeforeFadeIn;

	[SerializeField]
	private float fadeInDuration;

	[SerializeField]
	private float visibleDuration;

	[SerializeField]
	private float fadeOutDuration;

	[SerializeField]
	private Canvas warningCanvas;

	[SerializeField]
	private CanvasRenderer warningElement;

	public void StartShowSecondScreenWarning()
	{
	}

	private IEnumerator IOHCKMMCGLH()
	{
		return null;
	}
}
