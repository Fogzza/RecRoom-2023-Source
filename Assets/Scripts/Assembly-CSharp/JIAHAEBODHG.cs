using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

public sealed class JIAHAEBODHG<T>
{
	public readonly struct CPHKOLJGGMO
	{
		public readonly int FFENGAAGPMF;

		public readonly Task<T> BJIEBEBDOOF;

public KADCGADLAOC.MNAPJIEDNNL NJAMNFMEENK
{
get 		{
			return KADCGADLAOC.MNAPJIEDNNL.Completed;
		}

}

public T OOJPBADIODK
{
get 		{
			return default;
		}

}

		public CPHKOLJGGMO(int LFKIHFDBJNI, Task<T> BEONMNODOMN)
		{
			FFENGAAGPMF = 0;
			BJIEBEBDOOF = null;
		}
	}

	private sealed class PIMHGEIFCDB
	{
		public Dictionary<int, TaskCompletionSource<T>> taskCompletionSources;

		public CancellationToken token;

		internal void _003CGatherData_003Eb__2()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct JFLKBJADDAE : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<CPHKOLJGGMO[]> _003C_003Et__builder;

		public global::JIAHAEBODHG<T> _003C_003E4__this;

		public CancellationToken cancellationToken;

		public int timeoutMs;

		private PIMHGEIFCDB _003C_003E8__1;

		private Guid _003CrequestId_003E5__2;

		private CancellationTokenRegistration _003C_003E7__wrap2;

		private TaskAwaiter<IEnumerable<Task<T>>> _003C_003Eu__1;

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

	private readonly KADCGADLAOC.DEBCJFOOPOG IDHBAPKDAEK;

	private readonly KADCGADLAOC.MHELKIHLEEE KIMIIJKIMKG;

	private readonly Dictionary<Guid, Dictionary<int, TaskCompletionSource<T>>> ANJKEEDFHAL;

	public JIAHAEBODHG(KADCGADLAOC.MHELKIHLEEE HJOOFGLHNBG, KADCGADLAOC.DEBCJFOOPOG OEEJOADDENI = null)
	{
	}

	public Task<CPHKOLJGGMO[]> AJPAFKLAIOD(int INGLDOOPDLO = 10000, CancellationToken NDKAKDJMDIF = default(CancellationToken))
	{
		return null;
	}

	public void ECHAABBNPHO(in Guid AMGNCPLIAAC, int OOCPEFJONBB, in T PCPEJHIMHJJ)
	{
	}
}
