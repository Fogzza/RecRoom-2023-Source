using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RecRoom.Core;
using UnityEngine;

public class DormroomSceneManager : RecRoomSceneManager
{
	private sealed class IFCIDKIOGBB : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DormroomSceneManager _003C_003E4__this;

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
		public IFCIDKIOGBB(int _003C_003E1__state)
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

	private sealed class JIBLAPKCBKD : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DormroomSceneManager _003C_003E4__this;

		public int blockDuration;

		private BulletinBoardController _003CbulletinBoardController_003E5__2;

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
		public JIBLAPKCBKD(int _003C_003E1__state)
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

	private sealed class BBLFBDHBPCP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DormroomSceneManager _003C_003E4__this;

		public float blockDuration;

		private float _003CblockStartTime_003E5__2;

		private WatchUI _003Cmenu_003E5__3;

		private RRUIRootScreen _003Cflow_003E5__4;

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
		public BBLFBDHBPCP(int _003C_003E1__state)
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

	private const string OJJACLBOJJL = "{0}.\nYou can rejoin in {1}";

	[SerializeField]
	private TeleportationPortal[] exitTeleportationPortals;

	private bool BKPEDBEELED;

	private FIHGBEHGLGB AMNDLCAJPIG;

	protected override IEnumerator Start()
	{
		return null;
	}

	private void FCFFGKECIFJ(int PCANKIBCPBJ)
	{
	}

	protected override void OnDestroy()
	{
	}

	private IEnumerator HNMFHMFOJEF(int PCANKIBCPBJ)
	{
		return null;
	}

	private void ENNCDKAMBHI()
	{
	}

	private void DDDJCPNOBJP(BulletinBoardController GOGGFHDAKJJ)
	{
	}

	private void HNAFHBIMJME(bool FBHDABEFLKL)
	{
	}

	public void AddLockAllDoors(object IALNODEHBNN)
	{
	}

	public void RemoveLockAllDoors(object IALNODEHBNN)
	{
	}

	private IEnumerator GHCCCOIHNGA(float PCANKIBCPBJ)
	{
		return null;
	}

	private void ACAGFJHHCAB()
	{
	}

	public void LockRoom(string OFMGPNLDCAB, string JAHKDPCLNPG)
	{
	}

	public void Button_PrivacyPolicy()
	{
	}

	public void Button_ToS()
	{
	}

	public void Button_FAQ()
	{
	}

	[CompilerGenerated]
	private void AGENJBPPALI(float GADDGJANIGG)
	{
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerator NBECFFIAJMM()
	{
		return null;
	}
}
