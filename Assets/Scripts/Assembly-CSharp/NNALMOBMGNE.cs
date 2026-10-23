using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;

public class NNALMOBMGNE : IDisposable
{
	public enum JNEOCDDOFAO
	{
		Invalid = 0,
		SpawnInvention = 1,
		SpawnObject = 2,
		Paste = 3,
		Clone = 4,
		DeleteAll = 5,
		BuiltInTooling = 6,
		BuiltInTooling_SkipCheck = 7
	}

	public delegate Task<NALLLFKFEFC> OEJCNHNDNOK(int PIHPHEMDPGD, byte[] PNOPBLNDCLO, CancellationToken NDKAKDJMDIF);

	public readonly struct NALLLFKFEFC
	{
		public readonly IONEOHGOAML MMEEFDICDDB;

		public readonly byte[] FJPONLLJKIH;

public bool CEFHNBAGACA
{
get 		{
			return false;
		}

}

		public NALLLFKFEFC(IONEOHGOAML PEJNHHBEBPH, byte[] CMOPDLJODCC = null)
		{
			MMEEFDICDDB = IONEOHGOAML.Success;
			FJPONLLJKIH = null;
		}

		public static NALLLFKFEFC NFPADFOMHPP(IONEOHGOAML CDNLFEOBNKB)
		{
			return default;
		}
	}

	public readonly struct NCFNGOFOIBA<T>
	{
		public readonly IONEOHGOAML MMEEFDICDDB;

		public readonly T BMMKHHAFPCC;

public bool CEFHNBAGACA
{
get 		{
			return false;
		}

}

		public NCFNGOFOIBA(IONEOHGOAML PEJNHHBEBPH, T KHKGGNHOCOE)
		{
			MMEEFDICDDB = IONEOHGOAML.Success;
			BMMKHHAFPCC = default;
		}
	}

	private class MFLKMOEPGGE
	{
		private readonly Dictionary<Guid, KHIEAIOACFF> MDLOLJNNODI;

		private readonly Dictionary<JNEOCDDOFAO, HashSet<Guid>> MHAKKDHGKMM;

		private readonly Dictionary<JNEOCDDOFAO, DateTime> AICBAGKHKMK;

		public void ALJGHHMGFOA(KHIEAIOACFF DNLAOJCAEED)
		{
		}

		public void OFCDMAFALBN(KHIEAIOACFF DNLAOJCAEED)
		{
		}

		public bool KIHDOPMPDMJ(Guid AMGNCPLIAAC, out KHIEAIOACFF DNLAOJCAEED)
		{
			DNLAOJCAEED = default;
			return false;
		}

		public int KDCDOADNPDP(JNEOCDDOFAO BNPHIMADFKK)
		{
			return 0;
		}

		public TimeSpan BCNKMFKHPMP(JNEOCDDOFAO BNPHIMADFKK, DateTime? CJCLLNNMCFL = null)
		{
			return default;
		}
	}

	private readonly struct KHIEAIOACFF
	{
		public readonly Guid LJLKNFEHJOF;

		public readonly JNEOCDDOFAO GHDEKEHMLEF;

		public readonly TaskCompletionSource<NALLLFKFEFC> GGBJNDEPDMA;

		public readonly DateTime AHAJONCEFEN;

		public KHIEAIOACFF(Guid AMGNCPLIAAC, JNEOCDDOFAO BNPHIMADFKK, TaskCompletionSource<NALLLFKFEFC> LCILDPHMBNI, DateTime HBPJNCOGKAE)
		{
			LJLKNFEHJOF = default;
			GHDEKEHMLEF = JNEOCDDOFAO.Invalid;
			GGBJNDEPDMA = null;
			AHAJONCEFEN = default;
		}
	}

	public struct CDIEMOJJKEC
	{
		public readonly bool PANDIDPAGCJ;

		public bool MHCDJGLMBKC;

		public readonly TimeSpan? IDPHOBHDNFI;

		public CDIEMOJJKEC(bool LDEOIINOJDP, bool ENNLECJGFAG, TimeSpan? EGNFMOCHKNO = null)
		{
			PANDIDPAGCJ = false;
			MHCDJGLMBKC = false;
			IDPHOBHDNFI = null;
		}
	}

	private sealed class FNNGLHGOPBK<TResponse>
	{
		public TaskCompletionSource<NALLLFKFEFC> tcs;

		public CancellationToken token;

		internal void _003CSendCreationOp_003Eb__0()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct BCFOBDJJIEL<TResponse> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<NCFNGOFOIBA<TResponse>> _003C_003Et__builder;

		public JNEOCDDOFAO op;

		public NNALMOBMGNE _003C_003E4__this;

		public TimeSpan? requestTimeout;

		public string requesterToken;

		public byte[] payload;

		public Func<byte[], TResponse> responseParser;

		private KHIEAIOACFF _003CpendingRequest_003E5__2;

		private TaskAwaiter<NALLLFKFEFC> _003C_003Eu__1;

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
	private struct FPJOIIJLKHM : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NNALMOBMGNE _003C_003E4__this;

		public IDictionary<object, object> eventData;

		public int senderId;

		public CancellationToken cancellationToken;

		private JNEOCDDOFAO _003Cop_003E5__2;

		private Guid _003CrequestId_003E5__3;

		private TaskAwaiter<NALLLFKFEFC> _003C_003Eu__1;

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

	private const byte EGABLEKKKFA = 1;

	private const byte AJMLCFFLPML = 2;

	private const byte DNHGDFMHJNA = 3;

	private const byte KDMMHCONBGO = 4;

	private const byte IJOGHMNNKLB = 5;

	private static readonly IDJBOINDOMB KPANIIJEKGN;

	private readonly Dictionary<JNEOCDDOFAO, OEJCNHNDNOK> IFHOCOKFMKB;

	private readonly Dictionary<JNEOCDDOFAO, CDIEMOJJKEC> NNGOIMGJDKN;

	private readonly MFLKMOEPGGE BJHINFJFGOD;

	private static readonly TimeSpan MOEPJDBDKLE;

	private static readonly TimeSpan CJGODJABIFO;

	private readonly JLJEJNFJIDP GCOGGHDIHNM;

	private readonly CancellationTokenSource LLMNLPDBKJN;

	public NNALMOBMGNE(JLJEJNFJIDP GCOGGHDIHNM)
	{
	}

	public void MCCNCEDAAMO(JNEOCDDOFAO GOCHJIMGLKB, OEJCNHNDNOK ODEFKCPHGJD, CDIEMOJJKEC LFNKCOLKBGM = default(CDIEMOJJKEC))
	{
	}

	public Task<NCFNGOFOIBA<TResponse>> PCGGFIGLKOH<TRequest, TResponse>(JNEOCDDOFAO GOCHJIMGLKB, string CFLEGEKMAJK, TRequest PCPEJHIMHJJ, Func<byte[], TResponse> ICMLFBANANO, TimeSpan? AHKDPABHMII = null) where TRequest : IMessage<TRequest>
	{
		return null;
	}

	public bool ILAEMNFDLJK(JNEOCDDOFAO BNPHIMADFKK, out IONEOHGOAML KEHFEFMDBHI)
	{
		KEHFEFMDBHI = default;
		return false;
	}

	private bool ILAEMNFDLJK(JNEOCDDOFAO BNPHIMADFKK, DateTime MFLLDOBLENI, out IONEOHGOAML KEHFEFMDBHI)
	{
		KEHFEFMDBHI = default;
		return false;
	}

	private bool GOLBIJKFOAI(JNEOCDDOFAO BNPHIMADFKK, DateTime MFLLDOBLENI, CDIEMOJJKEC IAFCNCPFJFC)
	{
		return false;
	}

	public Task<NCFNGOFOIBA<TResponse>> PCGGFIGLKOH<TResponse>(JNEOCDDOFAO GOCHJIMGLKB, string CFLEGEKMAJK, byte[] KHKGGNHOCOE, Func<byte[], TResponse> ICMLFBANANO, TimeSpan? AHKDPABHMII = null)
	{
		return null;
	}

	private void BMAIOBNEEHB(byte DFCHABKNANO, int PIHPHEMDPGD, object LBLGPPHFEFK)
	{
	}

	private Task NODLNKPKPBO(int PIHPHEMDPGD, IDictionary<object, object> OEPDOIOJPHD, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	private void HAPIECNKEEF(int DCENKPCEODI, JNEOCDDOFAO BNPHIMADFKK, Guid AMGNCPLIAAC, NALLLFKFEFC CDNLFEOBNKB)
	{
	}

	private void IDPEOADBFAB(IDictionary<object, object> OEPDOIOJPHD)
	{
	}

	public void Dispose()
	{
	}
}
