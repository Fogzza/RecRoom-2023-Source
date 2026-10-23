using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Tools;
using UnityEngine;

public class GestureTarget : MonoBehaviour
{
	private sealed class PFBICPHAMJG : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GestureTarget _003C_003E4__this;

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
		public PFBICPHAMJG(int _003C_003E1__state)
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

	private sealed class FHABIGBBNMC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool openWatchAutomatically;

		public GestureTarget _003C_003E4__this;

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
		public FHABIGBBNMC(int _003C_003E1__state)
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

	private const string PNBJDAPDBGK = "Gesture";

	[SerializeField]
	private bool supportsStop;

	[SerializeField]
	private bool supportsCheer;

	private Player ICEKNPKANKE;

	private RoomDoor ACFHGEAMACF;

	public Action<bool> IgnoreEvent;

	private float EGFDDJCGNPL;

	private float JKCAMLAHIPC;

	private float JALIABEPIFH;

	private float DOJOKHDIJLM;

public Player AttachedPlayer
{
get 	{
		return null;
	}

private set {
	}
}

public RoomDoor AttachedRoomDoor
{
get 	{
		return null;
	}

private set {
	}
}

public bool IsIgnored
{
get 	{
		return false;
	}

}

public bool CanBeIgnored
{
get 	{
		return false;
	}

}

public bool CanBeCheered
{
get 	{
		return false;
	}

}

public string Name
{
get 	{
		return null;
	}

}

	private void Awake()
	{
	}

	public void StopGestureRunning(bool OPGAEMFCFBM)
	{
	}

	public void SetIgnore(bool CHEHHIMIPCJ)
	{
	}

	private IEnumerator MCFICPCMEJO()
	{
		return null;
	}

	public void ShowCheerConfirmation(bool PLBJFEPIDKJ)
	{
	}

	private IEnumerator EDHMBNMGHII(bool PLBJFEPIDKJ)
	{
		return null;
	}

	public void ShowPointConfirmation()
	{
	}
}
