using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[ExecuteInEditMode]
public class TeleportTarget : MonoBehaviour
{
	private sealed class DCEOIEDIHKB : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TeleportTarget _003C_003E4__this;

		public Player player;

		private bool _003CplayerWalkedInside_003E5__2;

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
		public DCEOIEDIHKB(int _003C_003E1__state)
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
	private PulsingBeam beam;

	[SerializeField]
	private float targetRadius;

	private bool FJMIEBOKAEG;

	public Action<bool> PlayerTeleportedEvent;

	public Action PlayerWalkedToTargetEvent;

public bool AllowWalk
{
get 	{
		return false;
	}

set {
	}
}

	private void Awake()
	{
	}

	private void NLHDMJKKCML()
	{
	}

	public void OnPlayerTeleported(Player EKOFNPFCLMO, Vector3 CIGPKNNFNLE, Vector3 HEGDIHHKFGM)
	{
	}

	public IEnumerator RunCheckForPlayerWalkToTarget(Player EKOFNPFCLMO)
	{
		return null;
	}

	private void OnDrawGizmos()
	{
	}
}
