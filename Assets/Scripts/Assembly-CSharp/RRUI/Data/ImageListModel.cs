using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ImageListModel : ListModel, CHJOOBOCKOG
	{
		private enum POBFJDDAABF
		{
			Room = 0,
			LocalPlayerTakenPhotos = 1,
			LocalPlayerTaggedPhotos = 2,
			FriendsTakenPhotos = 3,
			CreatorAccount = 4
		}

		private sealed class PGMKCBKBOCC
		{
			public ImageListModel _003C_003E4__this;

			public int skip;

			internal (int, IEnumerable<long>, string) _003CRefreshPage_003Eb__0()
			{
				return default;
			}
		}

		private List<long> JGIKFKPNKKI;

		private GDHOAGNFOBD.MENCAIHDKKN CBAPDIDLNHM;

		private GDHOAGNFOBD.GHHJMNMEHFC ENOLPHNFBKA;

		private bool EOIKHGFMHII;

		private bool? ABPJAIMCOGB;

		private int EBPEOEONPMJ;

		[SerializeField]
		private POBFJDDAABF source;

		[SerializeField]
		private GDHOAGNFOBD.MENCAIHDKKN defaultSortCriteria;

		private long EPOBIFCHLNM;

		private const int DDGJNJIOMMK = 100;

		private const string BMIIFKBAGNM = "RoomDetails.PhotoRollEnabled";

		private Dictionary<GDHOAGNFOBD.MENCAIHDKKN, string> MFKDFIJMBOG;

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

public IReadOnlyList<long> Ids
{
get 		{
			return null;
		}

}

public bool IncludeTaggedPlayers
{
get 		{
			return false;
		}

}

public bool IncludeImageDetails
{
get 		{
			return false;
		}

}

public GDHOAGNFOBD.MENCAIHDKKN SortCriteria
{
get 		{
			return GDHOAGNFOBD.MENCAIHDKKN.CreatedAt_Desc;
		}

private set {
		}
}

public GDHOAGNFOBD.GHHJMNMEHFC FilterCriteria
{
get 		{
			return GDHOAGNFOBD.GHHJMNMEHFC.VisibleToPlayer;
		}

private set {
		}
}

public bool IsSearching
{
get 		{
			return false;
		}

private set {
		}
}

public bool PhotoRollServerEnabled
{
get 		{
			return false;
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

public bool ImagesAreOwnedByLocalAccount
{
get 		{
			return false;
		}

}

public bool ImagesAreOwnedByRemoteAccount
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

		public void Set(long EPOBIFCHLNM)
		{
		}

		protected override void EHOFAGJCHPA()
		{
		}

		public void RefreshCheers()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private LAHBDKNMNHN BEEAAKILJAB(int LOHCDOECAMB, int NEGMKDLGHMF)
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		public void ToggleFilteredSelf()
		{
		}

		public void SortByCheerCount()
		{
		}

		public void SortByRecent()
		{
		}

		public void TryShowSortDialogPopUp()
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<GDHOAGNFOBD.BAPBAPCBDIJ>> HPAOLMOKDID(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN ODEBJAKGCON(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<GDHOAGNFOBD.BAPBAPCBDIJ>> FHFFJIHFMEH(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private void KIDNHBKLOIB(string JDDIAEIMOBB)
		{
		}

		[CompilerGenerated]
		private void NPJOCOMLEBG()
		{
		}

		[CompilerGenerated]
		private void OHFEPPBFGFF(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private object LEPPKIFHOHB()
		{
			return null;
		}

		[CompilerGenerated]
		private void FIKEPMFLPFI(GDHOAGNFOBD.MENCAIHDKKN FDAIMOMOHIG)
		{
		}
	}
}
