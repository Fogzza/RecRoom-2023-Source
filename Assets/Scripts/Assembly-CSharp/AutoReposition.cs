using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AutoReposition : MonoBehaviour
{
	public delegate bool JEAAAPHGBJA();

	private sealed class MCJNGAJENDL : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AutoReposition _003C_003E4__this;

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
		public MCJNGAJENDL(int _003C_003E1__state)
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

	public float acceptableDistance_meters;

	public float acceptableLookAwayAngle_degrees;

	public float timeBeforeResetForDistance;

	public float timeBeforeResetForAngle;

	public Transform transformToMonitor;

	[SerializeField]
	private bool useDefaultPositioning;

	[SerializeField]
	private float defaultDistFromVRCamera;

	[SerializeField]
	private float defaultDistFromScreenCamera;

	[SerializeField]
	private float defaultHeightOffset;

	public IEnumerator OnResetRequired;

	public JEAAAPHGBJA CustomShouldRunLogic;

	private float CPMIJNFIFHP;

	private float GMACCDCHIMJ;

	private bool BNOPMOFLFAE;

	private void Update()
	{
	}

	public void ResetMenu()
	{
	}

	private IEnumerator PMKMPOPELEE()
	{
		return null;
	}

	private bool ONCGPHAKDJI()
	{
		return false;
	}

	private bool MMBNBLHFBGO()
	{
		return false;
	}
}
