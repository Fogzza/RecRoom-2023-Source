using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubListModel : FilterableListModel<long, EPILDIJELPG, string>
	{
		public enum PFLLCNFJLGB
		{
			ServerSearch = 0,
			ClubsIBelongTo = 1,
			MyCreatedClubs = 2,
			PrimaryTag = 3,
			PlayerCreatedClubs = 4,
			None = 5,
			MostActiveToday = 6,
			ClubsAccountBelongsTo = 7
		}

		private sealed class ALACEGCGDKA
		{
			public Tuple<EPILDIJELPG, List<EPILDIJELPG>> results;

			internal bool _003CRefreshClubsIBelongToResults_003Eb__1(EPILDIJELPG club)
			{
				return false;
			}
		}

		private static readonly IReadOnlyList<EPILDIJELPG> DBCEFJJKCOO;

		public const string PRIMARY_TAG_KEY = "PRIMARY_TAG_KEY";

		public const string SEARCH_QUERY_KEY = "SEARCH_QUERY_KEY";

		private DHAPPKCJJCA COGJFICBMCP;

		private int EBPEOEONPMJ;

		private int OOJHKNMJDFE;

		private List<string> CIPKCLHIMHK;

		private OJEIBHFICEN ONKPBFKKDEI;

		private global::KIDPMAMHDFB.CFKKDNBBKKM<long> NJCEGIFAIBM;

		private string HNACLKAJAJK;

		[SerializeField]
		private PFLLCNFJLGB source;

		[SerializeField]
		private bool excludeIfNoClubhouse;

		[SerializeField]
		private string _primaryTagFilter;

		[SerializeField]
		private float spaceBetweenClubSortOptions;

public int CreatorAccountId
{
get 		{
			return 0;
		}

set {
		}
}

public int MemberAccountId
{
get 		{
			return 0;
		}

set {
		}
}

public List<string> PrimaryTags
{
get 		{
			return null;
		}

private set {
		}
}

public OJEIBHFICEN SortCriteria
{
get 		{
			return OJEIBHFICEN.MemberCount_Desc;
		}

set {
		}
}

public bool HasActivePrimaryTag
{
get 		{
			return false;
		}

}

public bool HasActiveSearchCriteria
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

private set {
		}
}

protected override bool JFAJLIBNKCK
{
get 		{
			return false;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

protected override BMBBHLIOIIF CHGIJCOGJED
{
get 		{
			return default;
		}

}

public PFLLCNFJLGB Source
{
get 		{
			return PFLLCNFJLGB.ServerSearch;
		}

set {
		}
}

public string PrimaryTagFilter
{
get 		{
			return null;
		}

set {
		}
}

		protected override global::NCOKFFGPIJM<IReadOnlyList<EPILDIJELPG>> LFFEHHGOFFN()
		{
			return null;
		}

		protected override long EIDFFKOOKDK(EPILDIJELPG ONCGIPFNENB)
		{
			return 0L;
		}

		public override void Search(string ADGIOFAMOGF)
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		private global::NCOKFFGPIJM<IReadOnlyList<EPILDIJELPG>> ILCIACCGCCN()
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<EPILDIJELPG>> HBIEKEFNPEL()
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<EPILDIJELPG>> JNPJDMHPAFH()
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<EPILDIJELPG>> FOKFGKJKOMP()
		{
			return null;
		}

		private LAHBDKNMNHN EDGEOGJKDOD()
		{
			return null;
		}

		public bool IsPrimaryTagActive(string AHNIMJDLOPB)
		{
			return false;
		}

		public void RemoveActivePrimaryTag(string AHNIMJDLOPB)
		{
		}

		public void SetActivePrimaryTag(string AHNIMJDLOPB)
		{
		}

		public void ClearPrimaryTags()
		{
		}

		public void Initialize(PFLLCNFJLGB GLLFHCCFIGK, string OFHBFJPNIKD, string NIOBDAGDJAE)
		{
		}

		private void IFMBGJFOLCI()
		{
		}

		private static string[] FKNCHLJKDHO(EPILDIJELPG APMHMCKALGG)
		{
			return null;
		}

		public void TryShowSortDialogPopUp()
		{
		}

		private void GBADDEAHEAJ()
		{
		}

		private bool BGEPBPKEKIB(EPILDIJELPG APMHMCKALGG)
		{
			return false;
		}

		private static bool DIFKOCKKJFO(string HNGJGPJCNBJ, EPILDIJELPG APMHMCKALGG)
		{
			return false;
		}

		private IReadOnlyList<EPILDIJELPG> NKDABAEKEFN(IEnumerable<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		private void OLEKPBFGEBJ(ModelBase GADDGJANIGG)
		{
		}

		private void DENMMOCCEBF()
		{
		}

		public void AddImpression(long JJLIIOCLCNA)
		{
		}

		[CompilerGenerated]
		private IReadOnlyList<EPILDIJELPG> MHGNCMJNGIP(List<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		[CompilerGenerated]
		private IReadOnlyList<EPILDIJELPG> JGCBNIFCBGL(IReadOnlyList<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		[CompilerGenerated]
		private IReadOnlyList<EPILDIJELPG> GIJGMMCKPEC(List<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		[CompilerGenerated]
		private IReadOnlyList<EPILDIJELPG> DKAEJOEDMJC(IKHILDIPMEJ KBCMFMOBLFG)
		{
			return null;
		}

		[CompilerGenerated]
		private void NCFFEKCPJON(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private IReadOnlyList<EPILDIJELPG> JNCEBOOHJFM(IKHILDIPMEJ KBCMFMOBLFG)
		{
			return null;
		}

		[CompilerGenerated]
		private void MACNJNDAEFB(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private IReadOnlyList<EPILDIJELPG> PFBBOPDJNLM(IReadOnlyList<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		[CompilerGenerated]
		private void JABHKJCCLOM(List<string> CMBMOBEBGIN)
		{
		}

		[CompilerGenerated]
		private void KCPJFIEANGG(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private object HGDDAOFHHKB()
		{
			return null;
		}

		[CompilerGenerated]
		private void FLLOPOMEEOG(OJEIBHFICEN FDAIMOMOHIG)
		{
		}
	}
}
