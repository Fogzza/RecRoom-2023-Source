using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class VoiceLineControl : MonoBehaviour
{
	[Serializable]
	public class VoiceLineControlConfig
	{
		public float zTranslationWrapLimit;

		public float zTranslationRate;

		public float jitterFPS;

		public float TTL;
	}

	private sealed class IBIFIKPPGHC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VoiceLineControl _003C_003E4__this;

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
		public IBIFIKPPGHC(int _003C_003E1__state)
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

	private Vector3 LIGOHLDLHDO;

	private Vector3 ACEPPAMDMBH;

	private float BLCPBIIKOMD;

	private Vector3 GNKNLDILNDJ;

	private Vector3 ABNNBJELIAN;

	private Vector3 HBCGBOMNBMN;

	private float DDAMFAFHGBF;

	[HideInInspector]
	public VoiceLineControlConfig Config;

	private Coroutine OJFDCBGLJHP;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void IGHJAPGIBJE()
	{
	}

	private IEnumerator MAKNEPCFLNG()
	{
		return null;
	}

	private void Update()
	{
	}

	public void SetLifespan(float BLCPBIIKOMD)
	{
	}
}
