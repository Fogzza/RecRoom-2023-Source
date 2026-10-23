using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CodeStage.AntiCheat.ObscuredTypes;
using RRUI.Dialogs;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class InventionListModel : FilterableListModel<long, OEBAEGDPBLA, string>
	{
		public enum JKLMNNJDJEC
		{
			ServerSearch = 0,
			PlayerCreatedInventions = 1,
			None = 2,
			Room = 3,
			MySubscriptions = 4,
			TopToday = 5,
			FeaturedInventions = 6,
			FeaturedDormSkins = 7,
			MySubscriptionsDormSkins = 8,
			MyDormSkins = 9,
			TrendingInventions = 10
		}

		private sealed class GNOGPNAEHAE
		{
			public string defaultSearchQuery;

			public InventionListModel _003C_003E4__this;

			public List<string> tagList;

			internal void _003CSet_003Eb__0()
			{
			}
		}

		private sealed class BPACBAJDEFB
		{
			public ObscuredInt localAccountId;

			public Func<OEBAEGDPBLA, bool> _003C_003E9__7;

			internal List<OEBAEGDPBLA> _003CRefreshCacheInternal_003Eb__0(List<OEBAEGDPBLA> results)
			{
				return null;
			}

			internal bool _003CRefreshCacheInternal_003Eb__7(OEBAEGDPBLA x)
			{
				return false;
			}
		}

		private sealed class DDEKDDKOPLI
		{
			public int localAccountId;

			internal bool _003CFilterUnlistedUnownedInventionsTransform_003Eb__1(OEBAEGDPBLA r)
			{
				return false;
			}
		}

		private sealed class JDAMPOHLGMN
		{
			public InventionListModel _003C_003E4__this;

			public RRUI.Navigation.Uri uri;

			internal void _003CTryShowFilterDialogPopUp_003Eb__0()
			{
			}
		}

		private sealed class ELPFLBACFJO
		{
			public InventionListModel _003C_003E4__this;

			public DBIPHDIEBCM promise;

			internal void _003CSetUpPinnedInventionTags_003Eb__0(List<string> result)
			{
			}
		}

		private sealed class OBPHDILELFH
		{
			public InventionListModel _003C_003E4__this;

			public RRUI.Navigation.Uri uri;

			public Dictionary<string, bool> initialTags;

			internal void _003CSetUpFilterDialogPopUp_003Eb__5()
			{
			}

			internal void _003CSetUpFilterDialogPopUp_003Eb__6()
			{
			}

			internal void _003CSetUpFilterDialogPopUp_003Eb__0()
			{
			}

			internal void _003CSetUpFilterDialogPopUp_003Eb__1()
			{
			}

			internal void _003CSetUpFilterDialogPopUp_003Eb__2(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class DMKPCHJMCID
		{
			public KeyValuePair<string, bool> element;

			public OBPHDILELFH CS_0024_003C_003E8__locals1;

			internal bool _003CSetUpFilterDialogPopUp_003Eb__3()
			{
				return false;
			}

			internal void _003CSetUpFilterDialogPopUp_003Eb__4(bool isActive)
			{
			}
		}

		private const int PFBBLJJDKPJ = 1000;

		public const string INVENTION_LIST_TAGS_LIST_KEY = "INVENTION_LIST_TAGS_LIST_KEY";

		public const string INVENTION_LIST_ENTRYPOINT_NAME = "INVENTION_LIST_ENTRYPOINT_NAME";

		public const string DORM_SKINS_QOL_STATSIG_TAB_EXPERIMENT = "econ_q3_dorm_tab_spawn_qol";

		public const string DORM_SKINS_QOL_STATSIG_QOL_PARAM_NAME = "has_qol";

		private const string ANPAMCNOLPO = "Storefront_Watch";

		private const char CDKPFOIMDNM = '#';

		private const int CBDBBGFDHJF = -1;

		private const long BNGGINLFPNA = -1L;

		private HLNFDOBEGJO CHABDOLEEMD;

		private DynamicUIDialogModel DFGBNNHNAIJ;

		private DHAPPKCJJCA IDFNHNLJHKA;

		private EHEJPNFKNAL EBMLCMGLHAK;

		private EHEJPNFKNAL EBDFEDOBAFO;

		private List<string> PJIBDIKNGDG;

		private Dictionary<string, bool> DKFHLBOKLHE;

		private static readonly List<string> MGJCONIODMO;

		private static readonly List<string> PECIMECGNIG;

		private static readonly StringBuilder DNEPLIGHCDA;

		private FEIKFKAICHC JINHNPGMCMC;

		[SerializeField]
		private InventionsConfig.JKAMIDHHBCK sortCriteria;

		[SerializeField]
		private JKLMNNJDJEC source;

		private string HNACLKAJAJK;

		[SerializeField]
		private string entrypointName;

		private global::CPEJHPJNIKM<long> JODACEENALN;

		[SerializeField]
		private bool isUsingStoreItemCard;

		private int EBPEOEONPMJ;

		private long EPOBIFCHLNM;

		private bool? KEHJGJEFNPC;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public string SourceMeta
{
get 		{
			return null;
		}

set {
		}
}

public string EntrypointName
{
get 		{
			return null;
		}

}

public global::CPEJHPJNIKM<long> ImpressionDataCollectionWrapper
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsUsingStoreItemCard
{
get 		{
			return false;
		}

}

public JKLMNNJDJEC Source
{
get 		{
			return JKLMNNJDJEC.ServerSearch;
		}

set {
		}
}

public InventionsConfig.JKAMIDHHBCK SortCriteria
{
get 		{
			return InventionsConfig.JKAMIDHHBCK.CreationDate_Desc;
		}

set {
		}
}

public int CreatorAccountId
{
get 		{
			return 0;
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

public bool IsSpawnQolParamActive
{
get 		{
			return false;
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

		public override void Search(string ADGIOFAMOGF)
		{
		}

		private void LDFPDIEICBB(GBAJDOHJDHJ HFEKGOLNKOL)
		{
		}

		public void Set(JKLMNNJDJEC? GLLFHCCFIGK, int? EBPEOEONPMJ, InventionsConfig.JKAMIDHHBCK? KPJCOANICLH)
		{
		}

		public void Set(JKLMNNJDJEC? GLLFHCCFIGK, List<string> GALCLCJNKMM, string MHIPHONJEPB, string PGEIBONDJJP)
		{
		}

		private IReadOnlyList<OEBAEGDPBLA> OFIDJCBCOKB(IReadOnlyList<OEBAEGDPBLA> AMIAEMLONAO)
		{
			return null;
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<OEBAEGDPBLA>> LFFEHHGOFFN()
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<OEBAEGDPBLA>> HOMJDGMBANO(global::NCOKFFGPIJM<IReadOnlyList<OEBAEGDPBLA>> MILKCHAFMBN)
		{
			return null;
		}

		protected override long EIDFFKOOKDK(OEBAEGDPBLA EGDOIKMDMJM)
		{
			return 0L;
		}

		public void ToggleInventionTag(string FDAIMOMOHIG, bool GNGKKJPOAPJ)
		{
		}

		public void TryShowFilterDialogPopUp(RRUI.Navigation.Uri FKFKJOJNCLM = null)
		{
		}

		private LAHBDKNMNHN FNLCHIDLBND()
		{
			return null;
		}

		private static bool DIFKOCKKJFO(string HNGJGPJCNBJ, OEBAEGDPBLA EGDOIKMDMJM)
		{
			return false;
		}

		private void IFMBGJFOLCI()
		{
		}

		private static string[] MNOBLALOAJD(OEBAEGDPBLA EGDOIKMDMJM)
		{
			return null;
		}

		private global::NCOKFFGPIJM<IEnumerable<OEBAEGDPBLA>> NKDABAEKEFN(IEnumerable<OEBAEGDPBLA> JNAAHMPCPAB)
		{
			return null;
		}

		private string ECKNOECHENK(List<string> CMCEGGHLGPN)
		{
			return null;
		}

		private void CBCFFDNMHBH(string MHIPHONJEPB)
		{
		}

		private void JOJLKNBPMJI(RRUI.Navigation.Uri FKFKJOJNCLM = null)
		{
		}

		private void OCMOJMLIFKE()
		{
		}

		private void GHLFPJCIINC()
		{
		}

		private void CJLPGGOAJMO(Dictionary<string, bool> LFOJJACFMOE)
		{
		}

		private void NBPKAONNIEM(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
		}

		private List<string> LPLHBBCGGEG()
		{
			return null;
		}

		private void DMPLILGJAEC(bool FAJJGPDBNCA = true)
		{
		}

		private string CCIECNMIEGB()
		{
			return null;
		}

		private bool PKOHGHGLIJP(string BJJDBMNFODL, string JLAOKGCHIKF)
		{
			return false;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<OEBAEGDPBLA>> ONDDKJGBFFA(DFDECAEJBIO ACBGBAAHOIM)
		{
			return null;
		}
	}
}
