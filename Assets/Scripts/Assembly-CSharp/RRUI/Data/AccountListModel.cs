using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class AccountListModel : FilterableListModel<int, DFDECAEJBIO, string>
	{
		private sealed class DIGHGHEBFAD
		{
			public HashSet<int> localPlayerPartyMembers;

			internal bool _003CRefreshCacheInternal_003Eb__30(DFDECAEJBIO a)
			{
				return false;
			}
		}

		private sealed class AHJKCGDGKAA
		{
			public DFDECAEJBIO account;

			internal global::HBBHKKBNKHE<DFDECAEJBIO, long?> _003COrderItems_003Eb__10(long? clubId)
			{
				return null;
			}
		}

		private sealed class BBOIJKKNEJJ
		{
			public bool descending;

			public Func<global::HBBHKKBNKHE<DFDECAEJBIO, KPPGJKNBIJK>, int> _003C_003E9__3;

			internal global::NCOKFFGPIJM<IEnumerable<DFDECAEJBIO>> _003COrderAccountsByLevel_003Eb__1(List<global::HBBHKKBNKHE<DFDECAEJBIO, KPPGJKNBIJK>> results)
			{
				return null;
			}

			internal int _003COrderAccountsByLevel_003Eb__3(global::HBBHKKBNKHE<DFDECAEJBIO, KPPGJKNBIJK> pair)
			{
				return 0;
			}
		}

		private sealed class GAOGOEGPEJB
		{
			public DFDECAEJBIO account;

			internal global::HBBHKKBNKHE<DFDECAEJBIO, KPPGJKNBIJK> _003COrderAccountsByLevel_003Eb__2(KPPGJKNBIJK progression)
			{
				return null;
			}
		}

		private sealed class BDPGNJJNMHB
		{
			public bool descending;

			public Func<global::HBBHKKBNKHE<DFDECAEJBIO, int>, int> _003C_003E9__3;

			internal global::NCOKFFGPIJM<IEnumerable<DFDECAEJBIO>> _003COrderAccountsBySubscriberCount_003Eb__1(List<global::HBBHKKBNKHE<DFDECAEJBIO, int>> results)
			{
				return null;
			}

			internal int _003COrderAccountsBySubscriberCount_003Eb__3(global::HBBHKKBNKHE<DFDECAEJBIO, int> x)
			{
				return 0;
			}
		}

		private sealed class OHMLNEGIMJO
		{
			public DFDECAEJBIO account;

			internal global::HBBHKKBNKHE<DFDECAEJBIO, int> _003COrderAccountsBySubscriberCount_003Eb__2(int count)
			{
				return null;
			}
		}

		private sealed class ALDMLJLHCDD
		{
			public AccountListModel _003C_003E4__this;

			public string amplitudeCommandContext;

			internal void _003CShowAccountListDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, AccountModel accountModel, JLOCLGGLOPP toCardController)
			{
			}
		}

		private sealed class DEBELBFFAAC
		{
			public CardModel cardModel;

			public ALDMLJLHCDD CS_0024_003C_003E8__locals1;

			internal void _003CShowAccountListDialog_003Eb__1(DFDECAEJBIO account)
			{
			}
		}

		private sealed class NIMPDHHEBDI
		{
			public DFDECAEJBIO account;

			public DEBELBFFAAC CS_0024_003C_003E8__locals2;

			internal void _003CShowAccountListDialog_003Eb__2()
			{
			}
		}

		private sealed class IKGCNCAMDNG
		{
			public PickerDialogModel activeDialog;

			public global::HBBHKKBNKHE<AccountsConfig.CGEPIENCFOK, string>[] sortOptions;

			public AccountListModel _003C_003E4__this;

			public Predicate<global::HBBHKKBNKHE<AccountsConfig.CGEPIENCFOK, string>> _003C_003E9__5;

			internal void _003CShowAccountListSortDialog_003Eb__4()
			{
			}

			internal void _003CShowAccountListSortDialog_003Eb__0(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
			{
			}

			internal int _003CShowAccountListSortDialog_003Eb__1()
			{
				return 0;
			}

			internal bool _003CShowAccountListSortDialog_003Eb__5(global::HBBHKKBNKHE<AccountsConfig.CGEPIENCFOK, string> sortOption)
			{
				return false;
			}

			internal void _003CShowAccountListSortDialog_003Eb__2(int index)
			{
			}

			internal void _003CShowAccountListSortDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private const int MCEHDAMNEMJ = -1;

		private static readonly List<int> ECMFEOGBBBG;

		[SerializeField]
		protected bool includeLocalPlayer;

		[SerializeField]
		protected bool includeJuniors;

		[SerializeField]
		private bool includeOffline;

		[SerializeField]
		private bool includeLocalPlayerPartyMembers;

		[SerializeField]
		private CJIHECEJAHH defaultSource;

		[SerializeField]
		private AccountsConfig.CGEPIENCFOK sortCriteria;

		[SerializeField]
		private bool includeNearbyBroadcastingPlayers;

		[SerializeField]
		private bool refreshOnPresenceUpdates;

		[SerializeField]
		private bool refreshOnShow;

		private LHMPPJKHCJG KOCMHELAMME;

		private CDLILHDKGGD HEKDJDKMAPC;

		private readonly EEANDDJEMJC BGAKPJJGKEJ;

		private CJIHECEJAHH? GLLFHCCFIGK;

		private AccountsConfig.CGEPIENCFOK JBHDHHODMIC;

		private long EPOBIFCHLNM;

		private long NJJFDENHGKK;

		private long FFBALOOMPIB;

		private int EJIHLJJMOBD;

		private int FNNONOEONMK;

		private AccountModel MOFGLBKGJFL;

		[SerializeField]
		private CustomAccountListSource customSource;

		private bool BMBDKKINFLN;

protected override BMBBHLIOIIF CHGIJCOGJED
{
get 		{
			return default;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public EEANDDJEMJC OnSelectedGridIndexChange
{
get 		{
			return null;
		}

}

public CJIHECEJAHH Source
{
get 		{
			return CJIHECEJAHH.ServerSearch;
		}

set {
		}
}

public AccountsConfig.CGEPIENCFOK SortCriteria
{
get 		{
			return AccountsConfig.CGEPIENCFOK.Username_Asc;
		}

set {
		}
}

public long RoomId
{
get 		{
			return 0L;
		}

set {
		}
}

public long PlayerEventId
{
get 		{
			return 0L;
		}

set {
		}
}

public long ChatThreadId
{
get 		{
			return 0L;
		}

set {
		}
}

public int AccountId
{
get 		{
			return 0;
		}

set {
		}
}

public int SelectedGridIndex
{
get 		{
			return 0;
		}

set {
		}
}

public AccountModel SelectedAccountModel
{
get 		{
			return null;
		}

set {
		}
}

public CustomAccountListSource CustomSource
{
get 		{
			return null;
		}

set {
		}
}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		private void BLKJJBIOCEC()
		{
		}

		private void CDBBOHBGNNP(int? EJIHLJJMOBD)
		{
		}

		private void IOJEJAMEKNG()
		{
		}

		private void FNFLINCHDCF(int EJIHLJJMOBD)
		{
		}

		private void HCMKLHAIPPB(FMEDMCFGHFM AAMFKNLLGDC)
		{
		}

		private void BMHDGBBDAFE()
		{
		}

		private void HELHHKBOBBJ()
		{
		}

		private void FBLLEJKJKPO()
		{
		}

		public void Set()
		{
		}

		public void Refresh()
		{
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<DFDECAEJBIO>> LFFEHHGOFFN()
		{
			return null;
		}

		public IReadOnlyList<DFDECAEJBIO> GetAccounts()
		{
			return null;
		}

		protected override int EIDFFKOOKDK(DFDECAEJBIO ACBGBAAHOIM)
		{
			return 0;
		}

		private static bool LLBDCAEFDCJ(int EJIHLJJMOBD)
		{
			return false;
		}

		private void IFMBGJFOLCI()
		{
		}

		private static string[] HDNHCLDJIIM(DFDECAEJBIO ACBGBAAHOIM)
		{
			return null;
		}

		private global::NCOKFFGPIJM<IEnumerable<DFDECAEJBIO>> NKDABAEKEFN(IEnumerable<DFDECAEJBIO> JNAAHMPCPAB)
		{
			return null;
		}

		private static global::NCOKFFGPIJM<IEnumerable<DFDECAEJBIO>> ONNCFHLECED(IEnumerable<DFDECAEJBIO> JNAAHMPCPAB, bool PPDPFEBBGFO)
		{
			return null;
		}

		private static global::NCOKFFGPIJM<IEnumerable<DFDECAEJBIO>> BALGOCMCODE(IEnumerable<DFDECAEJBIO> JNAAHMPCPAB, bool PPDPFEBBGFO)
		{
			return null;
		}

		public void ShowAccountListDialog(string OFMGPNLDCAB, string LDPCFDMCJLH)
		{
		}

		public void ShowAccountListSortDialog(global::HBBHKKBNKHE<AccountsConfig.CGEPIENCFOK, string>[] IEHJABBHLKM, GameObject MPNJFGHHINN)
		{
		}

		private void HBCBJGDLEKH(DFDECAEJBIO ACBGBAAHOIM, string LDPCFDMCJLH)
		{
		}

		[CompilerGenerated]
		private List<DFDECAEJBIO> ACKCBGOKDOL(List<DFDECAEJBIO> AGIGKKMBEKN)
		{
			return null;
		}
	}
}
