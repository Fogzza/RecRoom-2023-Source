using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class EventListModel : FilterableListModel<long, IMIJPHJKLIM, string>
	{
		public enum JLBPABBDEGL
		{
			Soon = 0,
			MyEvents = 1,
			MyEventsAndClubEvents = 2,
			ClubEventsById = 3,
			Room = 4,
			Live = 5,
			Popular = 6,
			RemotePlayerEvents = 7,
			None = 8
		}

		private sealed class FIOFPGIOPCD
		{
			public string tag;

			internal bool _003CIsPinnedTagActive_003Eb__0(string t)
			{
				return false;
			}
		}

		private sealed class DEBDPHHCCNK
		{
			public EventListModel _003C_003E4__this;

			public DateTime twoWeeksFromNow;

			public bool includeEventsHappeningNow;

			public Func<IMIJPHJKLIM, bool> _003C_003E9__10;

			internal global::NCOKFFGPIJM<IEnumerable<IMIJPHJKLIM>> _003CRefreshCacheInternal_003Eb__3(FJHBMHDECLE details)
			{
				return null;
			}

			internal List<IMIJPHJKLIM> _003CRefreshCacheInternal_003Eb__0(IEnumerable<IMIJPHJKLIM> events)
			{
				return null;
			}

			internal bool _003CRefreshCacheInternal_003Eb__10(IMIJPHJKLIM x)
			{
				return false;
			}
		}

		private sealed class OEGGIBLJHMI
		{
			public List<IMIJPHJKLIM> clubEvents;

			internal IOrderedEnumerable<IMIJPHJKLIM> _003CRefreshCacheInternal_003Eb__7(List<IMIJPHJKLIM> playerEvents)
			{
				return null;
			}
		}

		public const string SEARCH_QUERY_KEY = "SEARCH_QUERY_KEY";

		public const string INCLUDED_ENDED_EVENTS_KEY = "INCLUDED_ENDED_EVENTS_KEY";

		private readonly HashSet<string> KLBEADHPFAM;

		private MDJIDMHPEKN OFIBMELJPMI;

		private global::KIDPMAMHDFB.CFKKDNBBKKM<long> NJCEGIFAIBM;

		[SerializeField]
		private JLBPABBDEGL source;

		private string HNACLKAJAJK;

		[SerializeField]
		private bool includeEventsThatHaveEnded;

		[SerializeField]
		private bool includeEventsOverTwoWeeksAway;

		private bool FMGPFAEEOPA;

		private IReadOnlyList<string> JIBKLFFNAPF;

		private IReadOnlyList<string> KHJJNOBHPML;

		private long AJGPCPPJOBD;

		private long MCMOLLCNPHO;

		private int CCMPDNMDLJG;

public string SourceMeta
{
get 		{
			return null;
		}

private set {
		}
}

public bool IncludeEventsOverTwoWeeksAway
{
get 		{
			return false;
		}

set {
		}
}

public bool HasAnyActivePinnedTags
{
get 		{
			return false;
		}

}

public IReadOnlyList<string> PinnedTags
{
get 		{
			return null;
		}

private set {
		}
}

public IReadOnlyList<string> TrendingTags
{
get 		{
			return null;
		}

private set {
		}
}

public long ClubId
{
get 		{
			return 0L;
		}

private set {
		}
}

public long RoomId
{
get 		{
			return 0L;
		}

private set {
		}
}

public JLBPABBDEGL Source
{
get 		{
			return JLBPABBDEGL.Soon;
		}

set {
		}
}

public int RemoteAccountId
{
get 		{
			return 0;
		}

set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public bool ShouldHideCarousel
{
get 		{
			return false;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		public void Set(JLBPABBDEGL GLLFHCCFIGK, long AFPHABFLEBN = 0L, long EPOBIFCHLNM = 0L, string NIOBDAGDJAE = null, MDJIDMHPEKN CDOJNBEINAH = MDJIDMHPEKN.StartTime)
		{
		}

		public override void Search(string ADGIOFAMOGF)
		{
		}

		private string IBHJOMPFEAJ()
		{
			return null;
		}

		public bool IsPinnedTagActive(string AHNIMJDLOPB)
		{
			return false;
		}

		public void RemoveActivePinnedTag(string AHNIMJDLOPB)
		{
		}

		public void AddActivePinnedTag(string AHNIMJDLOPB)
		{
		}

		public void ClearPinnedTags()
		{
		}

		private void IJEPBNLPEII(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		private void OJGPLMMLJML(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		private void OPJNNGNLMMD(long JJLIIOCLCNA)
		{
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<IMIJPHJKLIM>> LFFEHHGOFFN()
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override long EIDFFKOOKDK(IMIJPHJKLIM IGGPIMCKMBP)
		{
			return 0L;
		}

		private static bool DIFKOCKKJFO(string HNGJGPJCNBJ, IMIJPHJKLIM IGGPIMCKMBP)
		{
			return false;
		}

		protected override void KPOHBHPPGBM()
		{
		}

		private LAHBDKNMNHN OOODEDOACBH()
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
		private void OCDNNFLDBOE(MKEJIKOPGJP MJPGCONAKLC)
		{
		}
	}
}
