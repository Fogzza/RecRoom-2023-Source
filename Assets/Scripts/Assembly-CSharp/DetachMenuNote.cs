using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using RecRoom.Core;
using UnityEngine;
using UnityEngine.UI;

public class DetachMenuNote : MonoBehaviour
{
	private sealed class OCHBBHLFNPN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DetachMenuNote _003C_003E4__this;

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
		public OCHBBHLFNPN(int _003C_003E1__state)
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

	public Transform TextButtonNameTransform;

	public Transform PS4ButtonNameTransform;

	public Text ButtonNameText;

	public Text ActionText;

	[SerializeField]
	private string attachedText;

	[SerializeField]
	private string notAttachedText;

	[SerializeField]
	private bool usedForOldUI;

	private void Awake()
	{
	}

	private IEnumerator Start()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	private void JAELOFHPIBJ(WatchUI NJCCDKGIAPI, bool DJBKLLMMJNJ)
	{
	}

	private void GJIOFMBJKNA(StackedUIFlowBase FLEEGFGCKFC)
	{
	}

	public void Refresh(bool MNPLAEIIIDI)
	{
	}
}
