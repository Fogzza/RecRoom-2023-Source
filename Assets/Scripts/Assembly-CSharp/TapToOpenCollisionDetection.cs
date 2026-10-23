using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TapToOpenCollisionDetection : MonoBehaviour
{
	public enum LINLLPFDDEI
	{
		NONE = 0,
		WATCH = 1,
		TOOL = 2
	}

	private sealed class CGOLECGNMEH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TapToOpenCollisionDetection _003C_003E4__this;

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
		public CGOLECGNMEH(int _003C_003E1__state)
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
	private Collider defaultCollider;

	[SerializeField]
	private Collider largeCollider;

	[SerializeField]
	private LINLLPFDDEI _type;

	[SerializeField]
	private Tool tool;

	private float BDEPEKPKDPA;

	private float PMFHHILJJKD;

	private float NEBDJHBHCHD;

	private bool MIIFOKLHEBN;

public bool IsTapped
{
get 	{
		return false;
	}

set {
	}
}

public LINLLPFDDEI Type
{
get 	{
		return LINLLPFDDEI.NONE;
	}

}

	private void Awake()
	{
	}

	private IEnumerator HGIFFNGEPEH()
	{
		return null;
	}

	private void OnTriggerEnter(Collider HNPEBINPOBO)
	{
	}
}
