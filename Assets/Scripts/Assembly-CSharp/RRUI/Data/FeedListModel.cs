using System.Collections.Generic;

namespace RRUI.Data
{
	public class FeedListModel : ListModel, CHJOOBOCKOG, AIMBDKPHOGK
	{
		private sealed class DMPPGFKCGDO
		{
			public FeedListModel _003C_003E4__this;

			public bool loadingFirstPage;

			internal (int, IEnumerable<LMPPEEMILFC>, string) _003CRefreshPage_003Eb__0(NMGMOPOJFAL feed)
			{
				return default;
			}

			internal void _003CRefreshPage_003Eb__1(string err)
			{
			}

			internal void _003CRefreshPage_003Eb__2()
			{
			}
		}

		private bool LKMOMJPDAKA;

		private List<LMPPEEMILFC> JKIGONBCCJJ;

		private List<KDEEJHLLLCH> EEGENMPGPEL;

		private bool DOBAANAIEKB;

		private bool MAKMLKOOCDK;

		private int NIKNNMHOCIJ;

		private string MJHINBGGDEO;

		private short ILBOFCPMPEF;

		private KIDPMAMHDFB.EFBDDEOKIEC PIBFODJEDDC;

		private DBECJLAIPEL LCANAOCDGLF;

		private const string HJJEIGIEPII = "app_exit";

		private const string LOFDMPMPDKH = "application_pause";

		private const string LMKIJFIDIDD = "go_to_mobile_home";

		private const string GNHMABBJPPB = "go_to_room";

		private const string FHFAMLPJFMP = "update_feed";

		public const string EXIT_REASON_REFRESH_FEED = "refresh_feed";

		private const string DAPAPKPKOOI = "feed_refresh_failure";

		private const string FAFDADIJDOL = "mobile_home_feed_stats";

		private const string HKLMEHMMPAJ = "mobile_home_feed";

public override bool IsEmpty
{
get 		{
			return false;
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

public override bool CanRefresh
{
get 		{
			return false;
		}

}

public override bool HasRefreshed
{
get 		{
			return false;
		}

}

public IReadOnlyList<LMPPEEMILFC> Data
{
get 		{
			return null;
		}

}

public bool IsLoading
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsFailed
{
get 		{
			return false;
		}

private set {
		}
}

public bool DataCollectionActive
{
get 		{
			return false;
		}

}

public bool HasItemImpressionsPopulated
{
get 		{
			return false;
		}

}

 HBPLHHMKAFA global::CHJOOBOCKOG.InfiniteScrollListState
{
get 		{
			return null;
		}

}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		public void Set(List<KDEEJHLLLCH> DIMLIEFIABI, DBECJLAIPEL KKCMJNHAKPD = DBECJLAIPEL.NOT_SET)
		{
		}

		protected override HBPLHHMKAFA KGFJLMLFOGN()
		{
			return null;
		}

		public void DiscardInMemoryItems(int JDHIICINABH, int BFFJHKFEFPP)
		{
		}

		public LAHBDKNMNHN RefreshPage(string ACKFNIOKBKJ, BJNEFKKMJEG MLCFEEOIEOE)
		{
			return null;
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private static global::NCOKFFGPIJM<NMGMOPOJFAL> CCOHGDOILID(int NEGMKDLGHMF, bool NOJGKCBALDI, string ACKFNIOKBKJ, List<KDEEJHLLLCH> DIMLIEFIABI)
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		public void ItemEnteredScreen(int GMEHLIHLGEH)
		{
		}

		public void ItemLeftScreen(int GMEHLIHLGEH)
		{
		}

		private void LMNKDDKFJLG(string EAAJBDFKOGK, short CFCCCNNLINM, bool NECEKDIHHEK = false)
		{
		}

		public void FlushImpressions(string OLNCBENNALL, bool ALHAGIHBCPP, long? EPOBIFCHLNM = null, short? CFCCCNNLINM = null)
		{
		}

		public KIDPMAMHDFB.OAJGLJAELMG GetOrCreateDataHelperForItem(int GMEHLIHLGEH)
		{
			return null;
		}

		protected override void EHOFAGJCHPA()
		{
		}

		private void OLEKPBFGEBJ(ModelBase GADDGJANIGG)
		{
		}

		private void OnApplicationPause(bool PBAEEBGJNPN)
		{
		}

		public void OnCheerTelemetry(short CFCCCNNLINM, bool OHJCCMNFEIL)
		{
		}

		public void OnShareTelemetry()
		{
		}

		public void OnGoToRoomTelemetry(short CFCCCNNLINM, long EPOBIFCHLNM)
		{
		}
	}
}
