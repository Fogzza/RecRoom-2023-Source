using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Photon.Pun;
using UnityEngine;

public class UGCProgression : MonoBehaviourPun
{
	[StructLayout((LayoutKind)3)]
	private struct JBKANBIDLHG : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public UGCProgression _003C_003E4__this;

		private int _003Cbalance_003E5__2;

		private TaskAwaiter<NGHFNDNBCGL> _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[SerializeField]
	private Player player;

	private global::MOBDJNEDDKC<int> NKFDMKMCHGC;

	private global::MOBDJNEDDKC<int> MENLAGCHCGD;

	private const int OAFOBKKGNEC = 1;

	private CancellationTokenSource NDKAKDJMDIF;

	private int PGPHBIFCPHP;

private static IDPBEMNMNJH FLKGOHBGNEJ
{
get 	{
		return null;
	}

}

public static bool RoomLevelsEnabled
{
get 	{
		return false;
	}

}

public static bool InTestMode
{
get 	{
		return false;
	}

set {
	}
}

public int RoomXp
{
get 	{
		return 0;
	}

set {
	}
}

public static Guid PlaceholderXpCurrency
{
get 	{
		return default;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public static void UpdateTestModeEnabled()
	{
	}

	private void MOBFCAMFPKG()
	{
	}

	public int GetRoomLevel()
	{
		return 0;
	}

	private int PILOIFKFDIL(int CCJAAOHFPDP)
	{
		return 0;
	}

	private void GKDMPDBOMPL()
	{
	}

	private void EHDJOABGJFD()
	{
	}

	[CompilerGenerated]
	private void EIFGLFANODJ()
	{
	}
}
