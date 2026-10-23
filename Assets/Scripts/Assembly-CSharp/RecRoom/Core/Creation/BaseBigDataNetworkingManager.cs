using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;

namespace RecRoom.Core.Creation
{
	public abstract class BaseBigDataNetworkingManager : MonoBehaviourPun
	{
		[StructLayout((LayoutKind)3)]
		private struct JCPHJIGMNBA : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public global::FKCKMADGELN<string>.PPKAMDIDPFK stackTimer;

			public CancellationToken cancellationToken;

			private global::FKCKMADGELN<string>.PPKAMDIDPFK _003C_003E7__wrap1;

			private TaskAwaiter _003C_003Eu__1;

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

		private sealed class PKADFEHPJMH
		{
			public CancellationToken cancellationToken;

			internal Task _003CRunAllDataRetrievalInternal_003Eb__1(BaseBigDataNetworkingManager bdnm)
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct KDNBIIGEHIC : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			private CancellationTokenSource _003C_003E7__wrap1;

			private TaskAwaiter _003C_003Eu__1;

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

		public static HashSet<BaseBigDataNetworkingManager> All;

		private JLJEJNFJIDP JONMNOCLCLL;

		private static CancellationTokenSource HAHJOOPCHOK;

		private static bool PPEAKOCOLBD;

		private static Task CJEHBDPPCDP;

		protected static readonly HashSet<int> JJLICNGKINP;

protected abstract IEnumerable<BigDataTrackedObject> CDDDMNGNMJJ
{
get ;
}

protected JLJEJNFJIDP LEPFKHILIEN
{
get 		{
			return null;
		}

private set {
		}
}

		public static Task RunAllDataRetrieval(global::FKCKMADGELN<string>.PPKAMDIDPFK GLOICACPAOF, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private static Task BJKJLBIODHK(CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public static void Cancel()
		{
		}

		protected abstract Task LEJODEOGONM(CancellationToken NDKAKDJMDIF);

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
	public abstract class BaseBigDataNetworkingManager<T> : BaseBigDataNetworkingManager
	{
		protected class PJLAOHCINDI
		{
			public readonly CHILKDJABBF ODILGOLGKOO;

			private readonly List<BigDataTrackedObject> BANEHJLNKEM;

			private readonly TaskCompletionSource<T> HFJGIEEOHCA;

			public readonly Guid LJLKNFEHJOF;

public Task<T> BJIEBEBDOOF
{
get 			{
				return null;
			}

}

			public PJLAOHCINDI(CHILKDJABBF CBDPEOAABOH, List<BigDataTrackedObject> BANEHJLNKEM, CancellationToken NDKAKDJMDIF)
			{
			}

			public void FGJGBDJKHBC(T GFFOJMCNLLE)
			{
			}

			[CompilerGenerated]
			private void MEPNDBENGOA()
			{
			}

			[CompilerGenerated]
			private string ACCPDGKADKD()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct BLMOFNIDMIN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public int numFrames;

			private int _003Ci_003E5__2;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		private struct BHKEEHFONNG : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public BaseBigDataNetworkingManager<T> _003C_003E4__this;

			public CancellationToken cancellationToken;

			private Dictionary<CHILKDJABBF, List<BigDataTrackedObject>> _003CdirtyObjects_003E5__2;

			private float _003CtimeoutTime_003E5__3;

			private TaskAwaiter _003C_003Eu__1;

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

		private sealed class DMAHGPCCMHB
		{
			public BaseBigDataNetworkingManager<T> _003C_003E4__this;

			public CancellationToken cancellationToken;

			internal Task _003CRequestUpdatedDataFromAll_003Eb__0(KeyValuePair<CHILKDJABBF, List<BigDataTrackedObject>> kvp)
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct KKKMMPCNBAE : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public BaseBigDataNetworkingManager<T> _003C_003E4__this;

			public CancellationToken cancellationToken;

			public Dictionary<CHILKDJABBF, List<BigDataTrackedObject>> dirtyObjects;

			private TaskAwaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		private struct PCIIHPDEPPM : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public List<Task> tasks;

			private List<Exception> _003Cexceptions_003E5__2;

			private Task _003CcompletedTask_003E5__3;

			private TaskAwaiter<Task> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		private struct FOFPJJILKDF : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public BaseBigDataNetworkingManager<T> _003C_003E4__this;

			public CHILKDJABBF player;

			public List<BigDataTrackedObject> dirtyObjects;

			public CancellationToken cancellationToken;

			private TaskAwaiter<T> _003C_003Eu__1;

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

		private sealed class LFFIICJOKLN
		{
			public BaseBigDataNetworkingManager<T> _003C_003E4__this;

			public CHILKDJABBF targetPlayer;

			public List<BigDataTrackedObject> dirtyObjects;

			public HashSet<int> requestViewIds;

			internal object _003CRequestDataFromPlayer_003Eb__1(List<BigDataTrackedObject> dObjs)
			{
				return null;
			}
		}

		private sealed class AJFDAGFPJIM
		{
			public HashSet<int> responseViewIds;

			public LFFIICJOKLN CS_0024_003C_003E8__locals1;

			internal object _003CRequestDataFromPlayer_003Eb__2(List<BigDataTrackedObject> dObjs)
			{
				return null;
			}

			internal object _003CRequestDataFromPlayer_003Eb__3(List<BigDataTrackedObject> dObjs)
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct JFHDONONBMP : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public BaseBigDataNetworkingManager<T> _003C_003E4__this;

			public CHILKDJABBF targetPlayer;

			public List<BigDataTrackedObject> dirtyObjects;

			public CancellationToken cancellationToken;

			private AJFDAGFPJIM _003C_003E8__1;

			private PJLAOHCINDI _003CdataRequest_003E5__2;

			private TaskAwaiter<T> _003C_003Eu__1;

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

		private const int JONDPCIBNHA = 3;

		private CancellationTokenSource FMAEEMLNDMH;

		private bool MADLOKPDBDD;

		private readonly Dictionary<Guid, PJLAOHCINDI> FNLBCJHJOOH;

protected bool BFFCNLEDKMK
{
get 		{
			return false;
		}

private set {
		}
}

		protected abstract T ABCAMCIBBPC();

		protected abstract bool BOMBAGJKMAP(T GFFOJMCNLLE);

		protected abstract HashSet<int> JFPOJIIKPHK(T HJHCHKNIJAF);

		protected override void OnDestroy()
		{
		}

		protected virtual bool NFFNFEEDAMM(BigDataTrackedObject JIONMNFLNCI)
		{
			return false;
		}

		private Task JMOLKHBIBIN(int EIANJMMFFMN, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		protected override Task LEJODEOGONM(CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private bool NKFKALHFMFM(ref Dictionary<CHILKDJABBF, List<BigDataTrackedObject>> GHJIBJGEMNP, out int HLMJODFJPDE)
		{
			HLMJODFJPDE = default;
			return false;
		}

		protected Task KAAIOIPOBIF(Dictionary<CHILKDJABBF, List<BigDataTrackedObject>> BANEHJLNKEM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		protected Task FGAMHNBEOPP(List<Task> EBKDEDGILHF, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private Task CHGIAFLLKHL(CHILKDJABBF EKOFNPFCLMO, List<BigDataTrackedObject> BANEHJLNKEM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		protected abstract void NHEOLIFKNCK(T GFFOJMCNLLE);

		private Task<T> JJLEOJDMJDE(CHILKDJABBF CBDPEOAABOH, List<BigDataTrackedObject> BANEHJLNKEM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private static string JECOHOHCPCE(HashSet<int> LCPAKHJBEOA)
		{
			return null;
		}

		protected abstract void ODAOOOJGPBA(PJLAOHCINDI BEODCPFFPCC);

		protected abstract void BCCMCHMPFJJ(CHILKDJABBF NBNFKAECMKO, Guid AMGNCPLIAAC, T HJHCHKNIJAF);

		protected void CKLBKIGNENG(Guid GHENACKCILD, GGGMJMEFFOC PPLJGCMIKOB)
		{
		}

		protected void AEGECIODIPE(Guid GHENACKCILD, T HJHCHKNIJAF)
		{
		}

		protected void HMCJKAONHOP(bool AEINBIKHGME)
		{
		}

		[CompilerGenerated]
		private object LLBMAAJJGNM((Dictionary<CHILKDJABBF, List<BigDataTrackedObject>>, int) JLGJEKAAPOC)
		{
			return null;
		}
	}
}
