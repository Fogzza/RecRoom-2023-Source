using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class RoomCurrencyManager : NetworkedSingletonMonoBehaviour<RoomCurrencyManager>
{
	private struct CELJBJPLFFP : IEquatable<CELJBJPLFFP>
	{
		public int JDONLFOPABP;

		public Guid HJDAOGBNGLB;

		public CELJBJPLFFP(int EJIHLJJMOBD, Guid LFNGEFEDKJM)
		{
			JDONLFOPABP = 0;
			HJDAOGBNGLB = default;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object HNPEBINPOBO)
		{
			return false;
		}

		public bool Equals(CELJBJPLFFP HNPEBINPOBO)
		{
			return false;
		}
	}

	private class CNDNDPDMNNA
	{
		public int BIFGPGBIDJC;

		public Guid HJDAOGBNGLB;

		public long NDEECBPDNJC;

		public global::PHLHFLLLDLK<BKLADIAHHFO> KLNJLJEOINM;
	}

	private sealed class LOPFEKIKPJJ
	{
		public long roomId;

		public RoomCurrencyManager _003C_003E4__this;

		internal void _003CGetCurrenciesForRoomAsync_003Eb__0(List<BKCIEBLAHHB> currencies)
		{
		}
	}

	private sealed class CEOBGHGMFPL
	{
		public Guid? currencyId;

		internal bool _003CDoesCurrencyIdExistInCurrentRoom_003Eb__0(BKCIEBLAHHB x)
		{
			return false;
		}
	}

	private sealed class LGNJOKGMMFN
	{
		public List<OJFKBBBMDEF> responses;

		public string serverRequestError;

		internal void _003CProcessBatchedAwards_003Eb__2(List<OJFKBBBMDEF> r)
		{
		}

		internal void _003CProcessBatchedAwards_003Eb__3(string e)
		{
		}
	}

	private sealed class NNLPBEONMDB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public RoomCurrencyManager _003C_003E4__this;

		private LGNJOKGMMFN _003C_003E8__1;

		private float _003CtimeAtRequest_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NNLPBEONMDB(int _003C_003E1__state)
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
		private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class JJNKOJNGGLC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public string error;

		public RoomCurrencyManager _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public JJNKOJNGGLC(int _003C_003E1__state)
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
		private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class PCHCMHKCNLG
	{
		public int accountId;

		public RoomCurrencyManager _003C_003E4__this;

		internal void _003CGetBalanceForPlayerAsync_003Eb__0(NGHFNDNBCGL balance)
		{
		}
	}

	private sealed class MFJPKPAJOFG
	{
		public long roomId;

		public RoomCurrencyManager _003C_003E4__this;

		internal void _003CGetBalancesForRoomAsync_003Eb__0(List<NGHFNDNBCGL> balances)
		{
		}
	}

	private sealed class KPEBNPKPKMH
	{
		public Guid purchaseOfferid;

		internal void _003CDeletePurchaseOfferAsync_003Eb__0()
		{
		}
	}

	private sealed class MKNDMJHMAEI
	{
		public bool forceRefreshPurchaseOffers;

		public Func<BKCIEBLAHHB, global::NCOKFFGPIJM<List<KPMECOOBOKJ>>> _003C_003E9__1;

		internal global::NCOKFFGPIJM<List<KPMECOOBOKJ>> _003CGetPurchaseOffersForRoomAsync_003Eb__0(List<BKCIEBLAHHB> currencies)
		{
			return null;
		}

		internal global::NCOKFFGPIJM<List<KPMECOOBOKJ>> _003CGetPurchaseOffersForRoomAsync_003Eb__1(BKCIEBLAHHB currency)
		{
			return null;
		}
	}

	private sealed class EJEABDILGFH
	{
		public RoomCurrencyManager _003C_003E4__this;

		public long roomId;

		internal void _003CUpdateLocalRoomCaches_003Eb__0(List<BKCIEBLAHHB> _)
		{
		}

		internal global::NCOKFFGPIJM<List<NGHFNDNBCGL>> _003CUpdateLocalRoomCaches_003Eb__1(List<BKCIEBLAHHB> currencies)
		{
			return null;
		}

		internal void _003CUpdateLocalRoomCaches_003Eb__2(List<NGHFNDNBCGL> balances)
		{
		}
	}

	public const int MAX_CURRENCIES_PER_ROOM = 20;

	public const int MAX_PACKAGES_PER_CURRENCY = 4;

	public static readonly global::HHOBPMOCKMJ<BKCIEBLAHHB> CachedCurrenciesUpdatedEvent;

	public static readonly global::HHOBPMOCKMJ<Guid> CachedCurrencyDeletedEvent;

	public static readonly global::HHOBPMOCKMJ<KPMECOOBOKJ> CurrencyPurchaseOfferUpdatedEvent;

	public static readonly global::HHOBPMOCKMJ<Guid> CurrencyPurchaseOfferDeletedEvent;

	private Dictionary<Guid, NGHFNDNBCGL> DAEKMABHIAF;

	private int? GIFAFODGPAB;

	private readonly Dictionary<Guid, BKCIEBLAHHB> DJKKNLOFMCN;

	private long? OICDNAKBBEO;

	private List<CNDNDPDMNNA> MGBDIEJJCLL;

	private List<CNDNDPDMNNA> EACCKFHLKGA;

	private LAHBDKNMNHN FHLGOMBKDHL;

	private bool ANDEOBBBIML;

	private bool BMJMDALDHGD;

	private static readonly List<OJFKBBBMDEF> CDKFMNBLPLE;

public bool IsBalanceCacheInitialized
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsCurrencyCacheInitialized
{
get 	{
		return false;
	}

private set {
	}
}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public global::NCOKFFGPIJM<BKCIEBLAHHB> CreateCurrencyAsync(long EPOBIFCHLNM, string KNOPFGAGMCN, string GKHMKKBKEKC, long CKKJBLGGKKM, string NPOEAPJKNFN = null)
	{
		return null;
	}

	public global::NCOKFFGPIJM<BKCIEBLAHHB> UpdateCurrencyAsync(Guid LFNGEFEDKJM, string KNOPFGAGMCN = null, string GKHMKKBKEKC = null, long? CKKJBLGGKKM = null, string NPOEAPJKNFN = null)
	{
		return null;
	}

	public global::NCOKFFGPIJM<BKLADIAHHFO> AwardCurrencyAsync(Guid LFNGEFEDKJM, int PMHHBIILMFH, long BECMELKBGCA, Action<string> HAOLPJEFKCD = null)
	{
		return null;
	}

	public global::NCOKFFGPIJM<List<BKCIEBLAHHB>> GetCurrenciesForRoomAsync(long EPOBIFCHLNM, bool KAGIMFAPGOG = false)
	{
		return null;
	}

	public bool TryGetCachedCurrencyById(Guid LFNGEFEDKJM, out BKCIEBLAHHB DLAOMGCBOAI)
	{
		DLAOMGCBOAI = null;
		return false;
	}

	public bool TryGetCachedCurrenciesForCurrentRoom(out List<BKCIEBLAHHB> MBNBCHIJENO)
	{
		MBNBCHIJENO = null;
		return false;
	}

	public bool DoesCurrencyIdExistInCurrentRoom(Guid? LFNGEFEDKJM)
	{
		return false;
	}

	private IEnumerator<EGGPGCCKPCO> GHLKGLDDJDK()
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> BAAMLPCIEKI(string NLJOHEKGNDH)
	{
		return null;
	}

	public long? GetBalanceForLocalPlayer(Guid LFNGEFEDKJM)
	{
		return null;
	}

	public global::NCOKFFGPIJM<NGHFNDNBCGL> GetBalanceForPlayerAsync(Guid LFNGEFEDKJM, int EJIHLJJMOBD, bool KAGIMFAPGOG = false)
	{
		return null;
	}

	public global::NCOKFFGPIJM<NGHFNDNBCGL> SetBalanceForLocalPlayer(Guid LFNGEFEDKJM, long PBKJGHFJEPL)
	{
		return null;
	}

	public global::NCOKFFGPIJM<List<NGHFNDNBCGL>> GetBalancesForRoomAsync(long EPOBIFCHLNM, bool KAGIMFAPGOG = false)
	{
		return null;
	}

	public global::NCOKFFGPIJM<KPMECOOBOKJ> CreatePurchaseOfferAsync(Guid LFNGEFEDKJM, string KNOPFGAGMCN, long BECMELKBGCA, long PJJFBBBIFOP, int MHAKGFHBBPF)
	{
		return null;
	}

	public global::NCOKFFGPIJM<KPMECOOBOKJ> UpdatePurchaseOfferAsync(Guid FJBOFHHJDBF, long? BECMELKBGCA = null, long? PJJFBBBIFOP = null, int? MHAKGFHBBPF = null)
	{
		return null;
	}

	public LAHBDKNMNHN DeletePurchaseOfferAsync(Guid OOIMPNIMKON)
	{
		return null;
	}

	public global::NCOKFFGPIJM<List<KPMECOOBOKJ>> GetPurchaseOffersForCurrencyAsync(Guid LFNGEFEDKJM, bool KAGIMFAPGOG = false)
	{
		return null;
	}

	public global::NCOKFFGPIJM<List<KPMECOOBOKJ>> GetPurchaseOffersForRoomAsync(long EPOBIFCHLNM, bool JCHOKBKHIHM = false)
	{
		return null;
	}

	private void BOOKJAJMKLC(EGGMEJDMHKF GPKOELKKOBP)
	{
	}

	private LAHBDKNMNHN FDMOPCJGBLJ(long EPOBIFCHLNM)
	{
		return null;
	}

	private void MBAFDBAIOJK(List<BKCIEBLAHHB> MBNBCHIJENO)
	{
	}

	private void MNPNMKAKHLG(BKCIEBLAHHB DLAOMGCBOAI)
	{
	}

	private void KGJECJABGHF(Guid LFNGEFEDKJM)
	{
	}

	private void KEJEMCDEMIF(NGHFNDNBCGL HBGBOLHPFEF)
	{
	}

	private void CAMCIBMFGJJ(List<NGHFNDNBCGL> EIIMJFDEPJH)
	{
	}

	private void ELKBPKDJLMH(NGHFNDNBCGL JKPJELBKKGN)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnNotifiedOfBalanceChanged(int EJIHLJJMOBD, Guid LFNGEFEDKJM, long BAOJPELMDEI, long PLKBNOEPPLB)
	{
	}

	private void OLEMDFNDGEM(int EJIHLJJMOBD, NGHFNDNBCGL HBGBOLHPFEF)
	{
	}

	public static bool CanLocalPlayerCreateCurrency()
	{
		return false;
	}

	[CompilerGenerated]
	private void EAAPDDLDELK(string GCBHEJANCJK)
	{
	}

	[CompilerGenerated]
	private void DJNHIBHEDDA(NGHFNDNBCGL BAOJPELMDEI)
	{
	}
}
