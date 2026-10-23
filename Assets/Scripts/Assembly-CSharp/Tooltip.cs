using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DisallowMultipleComponent]
public class Tooltip : MonoBehaviour
{
	private sealed class MPPNHANMHJD : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tooltip _003C_003E4__this;

		private float _003ChoverStartTime_003E5__2;

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
		public MPPNHANMHJD(int _003C_003E1__state)
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

	private const float ACCCBCGILCG = 0.45f;

	public Action<Tooltip> RefreshEvent;

	public string Message;

	public bool IgnoreSelectable;

	private bool JDBAOCBIBEB;

	[SerializeField]
	private TooltipUI.FontConfig fontConfig;

	private TooltipUI LJPADBEJAHN;

	private Coroutine NIPLKKEGCBL;

	private float IHHLLDLBGOE;

	private float GOIDFGFOOBM;

	private bool JGLLBKBIBMI;

	private Transform EBIMENIICMG;

	private GameObject BPPKGEEIECE;

public bool Hovered
{
get 	{
		return false;
	}

set {
	}
}

	private void OnDisable()
	{
	}

	public void SetHoverPoint(Transform FCKCGINHMPG, float IHHLLDLBGOE = 0f, GameObject NFABBFPMPIO = null)
	{
	}

	private void KIPADCDFPAD()
	{
	}

	private void GKMIHEIILFB(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	private IEnumerator BLMCBGLEMDN()
	{
		return null;
	}

	internal void GODLBKDFPDG()
	{
	}
}
