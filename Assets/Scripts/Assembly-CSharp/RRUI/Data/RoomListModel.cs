using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecNet;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomListModel : FilterableListModel<long, JCDPHCELKHI, string>, EMGACNJDBGN
	{
		public enum FFPAGDBKIPG
		{
			ServerSearch = 0,
			Hot = 1,
			Featured = 2,
			Recent = 3,
			MyCreatedRooms = 4,
			PlayerCreatedRooms = 5,
			None = 6,
			PlayerShowcaseRooms = 7,
			PlaylistById = 8,
			Recommended = 9,
			MyFavorites = 10,
			FriendPresence = 11,
			MyClubhouses = 12,
			MySubscriptions = 13,
			TopCreators = 14,
			MoreFromContestWinners = 15,
			ForYou = 16,
			PlaylistByName = 17,
			RoomSimilarity = 18,
			RoomJackpot = 19,
			CreationBaseRooms = 20,
			RecentForOtherUser = 21,
			RoomCategory = 22,
			ClubhouseOptions = 23,
			AllKeepsakeRooms = 24,
			StandardKeepsakeRooms = 25,
			PremiumKeepsakeRooms = 26,
			RRCALearnToCreate = 27,
			RRCACreationTutorials = 28,
			RRCABuildingTutorials = 29,
			RRCACircuitsTutorials = 30,
			Rising = 31
		}

		public enum DDFKFJLFOKF
		{
			OwnedAndCoOwnedRooms = 0,
			OwnedRoomsOnly = 1,
			CoOwnedRoomsOnly = 2
		}

		public struct PHOMKMAEIAF
		{
			public LCEKCFEIEGJ GGHABHJJMNF;

			public DFDECAEJBIO KCLGBDLKKKD;
		}

		public struct OGMHBDGFCJN
		{
			public long PMIMBJLKMLB;

			public long IFILEBPBLBG;

			public int INIKLNPDCJK;
		}

		public struct BILLCOMEGOO
		{
			public List<EPILDIJELPG> ADFBMHDEGMN;

			public Dictionary<long, EAKEEKOJOAO> GEPCINMPKLH;
		}

		private sealed class EDEJLGELAOK
		{
			public JCDPHCELKHI recCenterDTO;

			public List<JCDPHCELKHI> results;

			public RoomListModel _003C_003E4__this;

			internal void _003CRefreshCacheInternal_003Eb__14(JCDPHCELKHI room)
			{
			}

			internal void _003CRefreshCacheInternal_003Eb__15(IReadOnlyList<JCDPHCELKHI> recentRooms)
			{
			}

			internal void _003CRefreshCacheInternal_003Eb__17(IReadOnlyList<JCDPHCELKHI> creatorsImSubscribedToRooms)
			{
			}

			internal global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> _003CRefreshCacheInternal_003Eb__18()
			{
				return null;
			}
		}

		private sealed class CBOMPAKKICI
		{
			public IReadOnlyList<JCDPHCELKHI> rooms;

			internal global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> _003CRefreshCacheInternal_003Eb__25(JCDPHCELKHI arRoom)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> _003CRefreshCacheInternal_003Eb__26(string error)
			{
				return null;
			}
		}

		private sealed class COOGAGCEJBK
		{
			public IEnumerable<EPILDIJELPG> clubsWithClubhouse;

			public RoomListModel _003C_003E4__this;

			internal BILLCOMEGOO _003CRefreshCacheInternal_003Eb__35(IReadOnlyList<EAKEEKOJOAO> summaries)
			{
				return default;
			}
		}

		private sealed class CFJMDJKAGAL
		{
			public Dictionary<long, EAKEEKOJOAO> summaryLookup;

			internal int _003CRefreshCacheInternal_003Eb__38(EPILDIJELPG c)
			{
				return 0;
			}
		}

		private sealed class DNNFJALIINF
		{
			public bool isUpcoming;

			public RoomListModel _003C_003E4__this;

			public long roomId;

			public RoomModel roomModel;

			public long keepsakeRoomListId;

			internal string _003CApplyKeepsakeOverrides_003Eb__4()
			{
				return null;
			}

			internal bool _003CApplyKeepsakeOverrides_003Eb__5()
			{
				return false;
			}

			internal bool _003CApplyKeepsakeOverrides_003Eb__6()
			{
				return false;
			}

			internal Color? _003CApplyKeepsakeOverrides_003Eb__10()
			{
				return null;
			}

			internal void _003CApplyKeepsakeOverrides_003Eb__11()
			{
			}

			internal Sprite _003CApplyKeepsakeOverrides_003Eb__12()
			{
				return null;
			}

			internal bool _003CApplyKeepsakeOverrides_003Eb__13()
			{
				return false;
			}
		}

		private sealed class HDLAGNEJBFB
		{
			public long roomId;

			public HHCLMHEOLDA? loadSceneSourceData;

			public RoomListModel _003C_003E4__this;

			internal void _003CShowLockedByItemWarningDialogPopUp_003Eb__3()
			{
			}

			internal void _003CShowLockedByItemWarningDialogPopUp_003Eb__0()
			{
			}

			internal void _003CShowLockedByItemWarningDialogPopUp_003Eb__1(BaseDialogModel<IPGOOJIFBAB> dialog)
			{
			}
		}

		private sealed class DKLLIBBMJEC
		{
			public EOKBGGOAFLF upsellItem;

			public HDLAGNEJBFB CS_0024_003C_003E8__locals1;

			internal void _003CShowLockedByItemWarningDialogPopUp_003Eb__4()
			{
			}
		}

		private sealed class DGFAJONPJIH
		{
			public string tag;

			internal bool _003CIsPinnedTagActive_003Eb__0(string t)
			{
				return false;
			}
		}

		private sealed class MCNDMHLCFAO
		{
			public MessageDialogModel messageDialogModel;

			internal void _003CTryShowFullPlayMenuDialog_003Eb__1()
			{
			}

			internal void _003CTryShowFullPlayMenuDialog_003Eb__0(BaseDialogModel<IPGOOJIFBAB> dialogModel)
			{
			}
		}

		public const string SEARCH_QUERY_KEY = "SEARCH_QUERY_KEY";

		public const string RRCA_LEARN_TO_CREATE_KEY = "CCT.RRCA.TutorialRooms.LearnToCreate";

		public const string RRCA_CREATION_TUTORIALS_KEY = "CCT.RRCA.TutorialRooms.Creation";

		public const string RRCA_BUILDING_TUTORIALS_KEY = "CCT.RRCA.TutorialRooms.Building";

		public const string RRCA_CIRCUITS_TUTORIALS_KEY = "CCT.RRCA.TutorialRooms.Circuits";

		public const string PROGRESSION_EVENTS_UPSELL_DIALOG_TEXT = "ProgressionEvents.UpsellDialogText";

		[SerializeField]
		private FFPAGDBKIPG source;

		private string HNACLKAJAJK;

		[SerializeField]
		private bool sortByPlayerCount;

		[SerializeField]
		private bool showPlayerCountBadge;

		[SerializeField]
		private RoomsConfig.OKAFPNHPKND sortCriteria;

		[SerializeField]
		private float spaceBetweenRoomSortOptions;

		[SerializeField]
		private string hotTags;

		[SerializeField]
		private bool overrideLoadSceneSource;

		[SerializeField]
		private bool trackImpressions;

		[SerializeField]
		private DBECJLAIPEL loadSceneSourceOverride;

		[SerializeField]
		private bool refreshPageOnShow;

		[SerializeField]
		public bool includeKeepsakeRoomOverlays;

		[SerializeField]
		private BMBBHLIOIIF autoRefreshBehavior;

		private static readonly Lazy<BHNJIBDJFAL> MMDHAILKDOO;

		private IReadOnlyList<string> JIBKLFFNAPF;

		private IReadOnlyList<string> KHJJNOBHPML;

		private HashSet<string> OFAGKLNCOHA;

		private global::CPEJHPJNIKM<long> JODACEENALN;

		[SerializeField]
		private string playlistName;

		[SerializeField]
		private long playlistId;

		private BODDLBAAJDK HOPMKILHMJF;

		private RoomsConfig.OKAFPNHPKND JBHDHHODMIC;

		private int EBPEOEONPMJ;

		private int PHBCLPIGGHN;

		private long NOAKKIMDBKG;

		private IReadOnlyList<PHOMKMAEIAF> MBKNGDPCPOA;

		private DDFKFJLFOKF EHGHKNKCODB;

		private IReadOnlyList<DDOAONHMPPP.RoomCategory> CAEKLPNPGGP;

		private readonly List<OGMHBDGFCJN> GLPNFEACEMB;

		private DBECJLAIPEL FKHIIFMMEJD;

		private long EMGCGOJDNND;

		private DBECJLAIPEL? DJPNOMILDPO;

		private IOLBEFEOEMA NKLEDEGAPEM;

		private EAOCHKEGDFJ BBHMAAACAIO;

		private PNPHOOBLIIO KKGOHIDNJOL;

		private MessageDialogModel ONJMEHJHBKG;

		private IPGOOJIFBAB EBJBKDEHMFE;

		private EHEJPNFKNAL KDGIDEALDGD;

		private LNCCOPFMJAL ABNHEKDJGHP;

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

private set {
		}
}

public bool ShowPlayerCountBadge
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

private static BHNJIBDJFAL GMMEACABABI
{
get 		{
			return null;
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

public bool HasAnyActivePinnedTags
{
get 		{
			return false;
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

public bool IsKeepsakeRoomSource
{
get 		{
			return false;
		}

}

public FFPAGDBKIPG Source
{
get 		{
			return FFPAGDBKIPG.ServerSearch;
		}

set {
		}
}

public string HotTags
{
get 		{
			return null;
		}

set {
		}
}

public bool HasActiveSearchCriteria
{
get 		{
			return false;
		}

}

public string PlaylistName
{
get 		{
			return null;
		}

set {
		}
}

public long PlaylistId
{
get 		{
			return 0L;
		}

set {
		}
}

public BODDLBAAJDK Playlist
{
get 		{
			return null;
		}

private set {
		}
}

public RoomsConfig.OKAFPNHPKND SortCriteria
{
get 		{
			return RoomsConfig.OKAFPNHPKND.CreationDate_Desc;
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

public int VisitorAccountId
{
get 		{
			return 0;
		}

set {
		}
}

public long SimilarSeedRoomId
{
get 		{
			return 0L;
		}

set {
		}
}

public IReadOnlyList<PHOMKMAEIAF> RoomJackpots
{
get 		{
			return null;
		}

private set {
		}
}

public DDFKFJLFOKF PlayerCreatedRoomsFilter
{
get 		{
			return DDFKFJLFOKF.OwnedAndCoOwnedRooms;
		}

set {
		}
}

public bool ShouldHideCarousel
{
get 		{
			return false;
		}

}

public bool ShouldHideChipBar
{
get 		{
			return false;
		}

}

public bool ShouldShowRoomJackpotChip
{
get 		{
			return false;
		}

}

public IReadOnlyList<DDOAONHMPPP.RoomCategory> RoomCategories
{
get 		{
			return null;
		}

private set {
		}
}

public bool ShouldShowRoomCategorySelectChip
{
get 		{
			return false;
		}

}

public bool ShouldHideShowMeAllRooms
{
get 		{
			return false;
		}

}

public IReadOnlyList<OGMHBDGFCJN> ClubhouseAndClubIds
{
get 		{
			return null;
		}

}

public DBECJLAIPEL LoadSceneSource
{
get 		{
			return DBECJLAIPEL.NOT_SET;
		}

private set {
		}
}

public long KeepsakeRoomListId
{
get 		{
			return 0L;
		}

private set {
		}
}

public bool HasValidKeepsakeRoomListId
{
get 		{
			return false;
		}

}

public ProgressionEventDTO ActiveProgressionEvent
{
get 		{
			return null;
		}

}

		private DBECJLAIPEL AJDNJIODOCB()
		{
			return DBECJLAIPEL.NOT_SET;
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		private IReadOnlyList<JCDPHCELKHI> GANDGJKEKKP(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
		{
			return null;
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> LFFEHHGOFFN()
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> NDOOOGJEFMA(string HNKCHJFCELM)
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> HNBPPKMEHLO()
		{
			return null;
		}

		public void ApplyKeepsakeOverrides(ref JLOCLGGLOPP GIJKOHHEMOE, RoomModel KJJMPBMEDDC, long EPOBIFCHLNM, int GMEHLIHLGEH, long HJPNFJHJPBE)
		{
		}

		public void ShowLockedByItemWarningDialogPopUp(long EPOBIFCHLNM, HHCLMHEOLDA? APFMLJLPMJD)
		{
		}

		private EOKBGGOAFLF EEIEFDFONAG()
		{
			return null;
		}

		private void FGNOCNGNJII()
		{
		}

		public global::NCOKFFGPIJM<IEnumerable<Guid>> GetAllKeepsakeInstanceIdsForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<IEnumerable<Guid>> GetUncollectedKeepsakeInstanceIdsForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<int> GetTotalKeepsakeCountForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<int> GetUncollectedKeepsakeCountForRoom(long EPOBIFCHLNM, long LEBNGAGIGPK, BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public string GetKeepsakeCategoryOutlineImageName(BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public string GetKeepsakeCategoryFilledImageName(BLIIKHLKHJA OHMIKIIHJHM)
		{
			return null;
		}

		public IComparer<BLIIKHLKHJA> GetKeepsakeCategoryComparer()
		{
			return null;
		}

		public void Set(FFPAGDBKIPG? GLLFHCCFIGK, DBECJLAIPEL? BJOLDMAKJDG, int? EBPEOEONPMJ, string AHNIMJDLOPB, long? OPIBMMJHECF, long? NOAKKIMDBKG, bool? KHHLPMNIHHF, bool? PGMEJNHMJCO, RoomsConfig.OKAFPNHPKND? JIOAADGLBHG, string NIOBDAGDJAE, DDFKFJLFOKF? EHGHKNKCODB, long HJPNFJHJPBE = -1L)
		{
		}

		public override void Search(string ADGIOFAMOGF)
		{
		}

		public void TryShowSortDialogPopUp()
		{
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

		public void GetHotRoomsByTags(string CMBMOBEBGIN)
		{
		}

		public void GetMoreJackpotRooms()
		{
		}

		public void TryShowFullPlayMenuDialog()
		{
		}

		public void SetHasSeenFullPlayMenuPrompt()
		{
		}

		public void LoadIntoRoom(LCEKCFEIEGJ KPFNANKNKLE)
		{
		}

		public void SelectRoomCategory(string JNKJFJLJKNJ, Route NBCNOLJOIIM)
		{
		}

		public bool ShouldHideRoomCarouselOfSize(LNCCOPFMJAL CAPKFCHDLFA)
		{
			return false;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> MDDJBFJPJAK(global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> DDLIBIHPMNF)
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> JMINNGJNPIN(global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> DDLIBIHPMNF)
		{
			return null;
		}

		protected override long EIDFFKOOKDK(JCDPHCELKHI KPFNANKNKLE)
		{
			return 0L;
		}

		private LAHBDKNMNHN OOODEDOACBH()
		{
			return null;
		}

		private static bool DIFKOCKKJFO(string HNGJGPJCNBJ, JCDPHCELKHI KPFNANKNKLE)
		{
			return false;
		}

		private void IFMBGJFOLCI()
		{
		}

		private static string[] MPLAHJOGAMC(JCDPHCELKHI KPFNANKNKLE)
		{
			return null;
		}

		private global::NCOKFFGPIJM<IEnumerable<JCDPHCELKHI>> NKDABAEKEFN(IEnumerable<JCDPHCELKHI> JNAAHMPCPAB)
		{
			return null;
		}

		public Dictionary<string, string> GetLoadSceneSourceRRUIData()
		{
			return null;
		}

		[CompilerGenerated]
		private IReadOnlyList<JCDPHCELKHI> JCIDDIPIIEH(BODDLBAAJDK ECDDGINAGLA)
		{
			return null;
		}

		[CompilerGenerated]
		private IReadOnlyList<JCDPHCELKHI> BMKOINMCBEJ(BODDLBAAJDK ECDDGINAGLA)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<BILLCOMEGOO> KHILGOFBJJP(List<EPILDIJELPG> NDAEMCFLEJP)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> IMPAFAHPEMN(BILLCOMEGOO LJFGOFMFGPA)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> JANIKCCNFHF(List<int> FICONBLBKOM)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<IReadOnlyList<JCDPHCELKHI>> BJNEEAEDMDM(List<int> FICONBLBKOM)
		{
			return null;
		}

		[CompilerGenerated]
		private List<JCDPHCELKHI> HPHEHFFIPBI(IReadOnlyList<PHOMKMAEIAF> CECGEDKICOA)
		{
			return null;
		}

		[CompilerGenerated]
		private void DCHOKHCOCCP(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void DMEEMCCJPML(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private object HGOFHGEDIBM()
		{
			return null;
		}

		[CompilerGenerated]
		private void MPNAPGOHCGE(RoomsConfig.OKAFPNHPKND FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private void JLLLECNPAAE(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
		{
		}

		[CompilerGenerated]
		private List<JCDPHCELKHI> ENKPKLODIKC(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
		{
			return null;
		}

		[CompilerGenerated]
		private bool AGIHKKEOCCB(JCDPHCELKHI KPFNANKNKLE)
		{
			return false;
		}

		[CompilerGenerated]
		private List<JCDPHCELKHI> HECHAFELAMO(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
		{
			return null;
		}

		[CompilerGenerated]
		private bool HHJBMNMFBEE(JCDPHCELKHI KPFNANKNKLE)
		{
			return false;
		}

		[CompilerGenerated]
		private void GALFHOBKHNP(MKEJIKOPGJP MJPGCONAKLC)
		{
		}
	}
}
