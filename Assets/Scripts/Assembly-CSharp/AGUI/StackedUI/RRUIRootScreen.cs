using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Data;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Core.Storefronts;
using RecRoom.Core.UI;
using RecRoom.Sharing;
using RecRoom.Utils.Image;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class RRUIRootScreen : WatchUIFlow, GIDKJMNDAEO
	{
		private sealed class NLKDGLAKLPG
		{
			public RRUIRootScreen _003C_003E4__this;

			public DBIPHDIEBCM promise;

			internal List<DGMPBIPKJEB> _003CDisplaySkuPurchaseSuccessDialog_003Eg__createFooterLayout_007C0(bool includeStoreButton)
			{
				return null;
			}

			internal void _003CDisplaySkuPurchaseSuccessDialog_003Eb__3()
			{
			}

			internal void _003CDisplaySkuPurchaseSuccessDialog_003Eb__4()
			{
			}

			internal void _003CDisplaySkuPurchaseSuccessDialog_003Eb__1()
			{
			}

			internal void _003CDisplaySkuPurchaseSuccessDialog_003Eb__2(BaseDialogModel<IPGOOJIFBAB> dialog)
			{
			}
		}

		private sealed class MJJFMEEJHDC<TFromModel, TToCardControllerProvider> where TFromModel : ModelBase where TToCardControllerProvider : ControllerBase, AJFPIIJCIFO, DDIDMFFBNAE
		{
			public CheckoutDialogModel checkoutDialogModel;

			internal void _003CShowScreenAndDisplayCheckoutDialog_003Eb__0(BaseDialogModel<LJJIHDDNLNB> dialog)
			{
			}
		}

		private sealed class JJNEAPEOHPI
		{
			public string hubRoomConfigName;

			internal void _003CShowProgressionEventTutorialEndPrompt_003Eb__0()
			{
			}
		}

		private const string KCBLDGAELNL = "experience_2023q1_people_menu_iterations";

		private const string GLGBEPJIJKK = "friends_default_tab";

		private const int BGMKDALLACB = 32;

		[SerializeField]
		private FastGraphicRaycaster fastGraphicRaycaster;

		[SerializeField]
		private BrowserModel browserModel;

		[SerializeField]
		private CachedViewStateModel cachedViewStateModel;

		[SerializeField]
		private WatchModel watchModel;

		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private RRUI.Navigation.Uri homeUri;

		[SerializeField]
		private RRUI.Navigation.Uri playUri;

		[SerializeField]
		private Route newPlayerChallengesRoute;

		[SerializeField]
		private Route progressionEventsRoute;

		[SerializeField]
		private Route keepsakeEventsRoute;

		[SerializeField]
		private Route settingsRoute;

		[SerializeField]
		private Route settingsRouteMiscTab;

		[SerializeField]
		private Route minimalSettingsRoute;

		[SerializeField]
		private Route notificationSettingsRoute;

		[SerializeField]
		private RoutesConfig settingsRouteConfig;

		[SerializeField]
		private RoutesConfig backpackRouteConfig;

		[SerializeField]
		private RRUI.Navigation.Uri backpackUri;

		[SerializeField]
		private RRUI.Navigation.Uri backpackOtherUri;

		[SerializeField]
		private Route clubsRoute;

		[SerializeField]
		private Route clubDetailsRoute;

		[SerializeField]
		private Route eventsBrowserRoute;

		[SerializeField]
		private Route eventInstancesRoute;

		[SerializeField]
		private Route eventSetupRoute;

		[SerializeField]
		private Route eventDetailsRoute;

		[SerializeField]
		private RRUI.Navigation.Uri eventsUri;

		[SerializeField]
		private Route highlightRoomsRoute;

		[SerializeField]
		private Route roomJackpotRoute;

		[SerializeField]
		private Route searchRoomsRoute;

		[SerializeField]
		private Route roomCategorySelectRoute;

		[SerializeField]
		private Route roomSettingsEarningDistributionRoute;

		[SerializeField]
		private RRUI.Navigation.Uri thisRoomUri;

		[SerializeField]
		private Route subscriptionsRoute;

		[SerializeField]
		private Route portfolioRoute;

		[SerializeField]
		private Route profileRoute;

		[SerializeField]
		private RRUI.Navigation.Uri myProfileUri;

		[SerializeField]
		private Route savedOutfitsRoute;

		[SerializeField]
		private RRUI.Navigation.Uri peopleUri;

		[SerializeField]
		private RRUI.Navigation.Uri peopleFriendsTabDefaultUri;

		[SerializeField]
		private RRUI.Navigation.Uri partyUri;

		[SerializeField]
		private RRUI.Navigation.Uri friendUri;

		[SerializeField]
		private Route roomKeysBrowserRoute;

		[SerializeField]
		private Route roomKeysCreateRoute;

		[SerializeField]
		private Route roomKeyStoreRoute;

		[SerializeField]
		private Route roomCurrencyBrowserRoute;

		[SerializeField]
		private Route roomCurrencyCreateRoute;

		[SerializeField]
		private Route roomCurrencyStoreRoute;

		[SerializeField]
		private Route roomConsumableBrowserRoute;

		[SerializeField]
		private Route roomConsumableCreateRoute;

		[SerializeField]
		private Route roomConsumableStoreRoute;

		[SerializeField]
		private Route roomConsumableBackpackRoute;

		[SerializeField]
		private Route ugcStorefrontRoute;

		[SerializeField]
		private Route customAvatarItemDetailsRoute;

		[SerializeField]
		private Route customAvatarItemFeaturedRoute;

		[SerializeField]
		private Route customAvatarItemSearchRoute;

		[SerializeField]
		private Route customAvatarItemStoreRoute;

		[SerializeField]
		private Route storeFeaturedRoute;

		[SerializeField]
		private Route storeClothingRoute;

		[SerializeField]
		private Route storeInventionsRoute;

		[SerializeField]
		private Route inventionDetailsRoute;

		[SerializeField]
		private Route inventionSearchRoute;

		[SerializeField]
		private Route storeItemSearchRoute;

		[SerializeField]
		private Route itemDetailsRoute;

		[SerializeField]
		private Route tokenStoreRoute;

		[SerializeField]
		private Route rrPlusSignUpRoute;

		[SerializeField]
		private Route starterPackDetailsRoute;

		[SerializeField]
		private Route wishlistRoute;

		[SerializeField]
		private Route friendotronMainRoute;

		[SerializeField]
		private Route outfitRoute;

		[SerializeField]
		private RRUI.Navigation.Uri storeFeaturedUri;

		[SerializeField]
		private Route storeDormSkinsRoute;

		[SerializeField]
		private Route avatarCustomizationRoute;

		[SerializeField]
		private Route resolveBundleTrialsRoute;

		[SerializeField]
		private Route rewardSelectionRoute;

		[SerializeField]
		private Route emailPromptRoute;

		[SerializeField]
		private Route phonePromptRoute;

		[SerializeField]
		private Route actionCodeRoute;

		[SerializeField]
		private Route enterCodeRoute;

		[SerializeField]
		private Route inviteRoute;

		[SerializeField]
		private Route referralRewardsRoute;

		[SerializeField]
		private Route chatRoute;

		[SerializeField]
		private Route notificationsRoute;

		[SerializeField]
		private Route testCaseManagementRoute;

		[SerializeField]
		private RRUI.Navigation.Uri createUri;

		[SerializeField]
		private Route bugReportingRoute;

		[SerializeField]
		private Route debugRoute;

		[SerializeField]
		private RRUI.Navigation.Uri escMenuUri;

		[SerializeField]
		private Route bannedScreenRoute;

		[SerializeField]
		private Route warnedScreenRoute;

		[SerializeField]
		private Route reportPlayerRoute;

		private bool DIDONNOAFPG;

		private static readonly List<KFLOGBPDDDD> JGNCOHBKAMJ;

		private readonly Dictionary<Enum, Dictionary<int, BrowserModel.NHMLINFLOOA>> GPJOIFOALLB;

		private FBNJPEHPKJA IIOPDMFBICM;

		private FBNJPEHPKJA PONBEOFFCFD;

		private FastGraphicRaycaster GCHMKGHGAMG;

		private bool KGNCFHDIAOK;

		private Action<RRUIRootScreen, bool> EJEIMNDPEEP__BackingField;

		private IPGOOJIFBAB CJLNGCBNONI;

		private MessageDialogModel HIJCAJMHMOC;

		private DMGCKEOKIPC COMHFFIOHLF;

		private LMNOCCKEMKH IIOMBMAEKDF;

		private GNKIEJFAGCI MFJAOLJEAGL;

		private FEIKFKAICHC OJKHJDFLKAI;

		private const string EKFPNIEFFBA = "RRUI.UseRRUIBackpackScreen";

public RRUI.Navigation.Uri HomeUri
{
get 		{
			return null;
		}

}

public RoutesConfig SettingsRouteConfig
{
get 		{
			return null;
		}

}

public RoutesConfig BackpackRouteConfig
{
get 		{
			return null;
		}

}

public bool PoppingAllFlows
{
get 		{
			return false;
		}

set {
		}
}

public BrowserModel BrowserModel
{
get 		{
			return null;
		}

}

private RRUI.Navigation.Uri JEPGOHEKIDL
{
get 		{
			return null;
		}

}

public bool IsOnMinimalSettingsRoute
{
get 		{
			return false;
		}

}

public bool IsWatchAttachedToWrist
{
get 		{
			return false;
		}

}

public bool IsWatchMenuOpen
{
get 		{
			return false;
		}

}

public bool ShouldUseRRUINotificationsScreen
{
get 		{
			return false;
		}

}

public bool ShouldUseNewWatchArchitecture
{
get 		{
			return false;
		}

}

public bool CanPopModalViewOrGoBack
{
get 		{
			return false;
		}

}

public bool CanBypassLockedUI
{
get 		{
			return false;
		}

}

public event Action<RRUIRootScreen, bool> IsOnMinimalSettingsRouteChanged {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		private void LOOBLDEHOOJ(Enum FMDAEMIPHIC)
		{
		}

		private bool KAPCHDIBKGD()
		{
			return false;
		}

		public bool ClearHistoryForActiveTab()
		{
			return false;
		}

		public bool ApplyRRUITabHistoryOverOldUIScreen()
		{
			return false;
		}

		public bool PopFlow()
		{
			return false;
		}

		public void PopAllFlows()
		{
		}

		public void ToggleWatchSize()
		{
		}

		public void ShowPlayerReportScreen(DFDECAEJBIO FDCLMAGDCFJ, string LDPCFDMCJLH)
		{
		}

		public void AuthorityDetachWatchMenu()
		{
		}

		public void AuthorityOpenWatchMenuDetached(bool COPOILGLIAJ = false)
		{
		}

		public void AuthorityOpenWatchMenuDetached(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO, bool COPOILGLIAJ)
		{
		}

		public void AuthorityReattachWatchMenu()
		{
		}

		public bool TryPopFlow()
		{
			return false;
		}

		public void CloseScreenAndPopFlows()
		{
		}

		public void ShowScreenAndGoToRoute(Route NBCNOLJOIIM, bool CKMIGAPECHM, bool FAOBALNFCAD = true)
		{
		}

		public void ShowScreenAndGoToRoute(Route NBCNOLJOIIM, ELCPGOKLPLO GAHLHILPEDH, bool CKMIGAPECHM)
		{
		}

		public void ShowScreenAndGoToUri(RRUI.Navigation.Uri FKFKJOJNCLM, ELCPGOKLPLO GAHLHILPEDH, bool CKMIGAPECHM, RRUI.Navigation.Uri NNPODJNBDOK = null)
		{
		}

		public void ShowScreenAndGoToUri(RRUI.Navigation.Uri FKFKJOJNCLM, bool CKMIGAPECHM, bool FAOBALNFCAD = true)
		{
		}

		public void ShowScreenAndGoToSettings(bool KDLBPJOMMGP)
		{
		}

		public void ShowScreenAndGoToSettings_ARSettings(bool KDLBPJOMMGP)
		{
		}

		public void ShowScreenAndGoToMinimalSettings()
		{
		}

		public void ShowScreenAndGoToNotificationsPreferences(bool KDLBPJOMMGP)
		{
		}

		public void ShowScreenAndGoToBackpack(bool KDLBPJOMMGP)
		{
		}

		public void ShowScreenAndGoToBackpackOther(bool KDLBPJOMMGP)
		{
		}

		public void ShowScreenAndGoToClubs()
		{
		}

		public void ShowScreenAndGoToClubDetails(long AFPHABFLEBN, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToThisRoom(DBECJLAIPEL GLLFHCCFIGK = DBECJLAIPEL.NOT_SET, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToRoomDetails(long EPOBIFCHLNM, DBECJLAIPEL GLLFHCCFIGK, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToRoomEarningsDistribution(long EPOBIFCHLNM, DBECJLAIPEL GLLFHCCFIGK, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToEventDetails(long NJJFDENHGKK, bool KLEHGPMGPHM)
		{
		}

		public void GoToClubEventCreate(long AFPHABFLEBN)
		{
		}

		public void ShowScreenAndGoToEventSetup(long? NJJFDENHGKK)
		{
		}

		public bool IsNotEventDetailsOrSetup(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
			return false;
		}

		public void ShowScreenAndGoToEventInstances(long NJJFDENHGKK)
		{
		}

		public void ShowScreenAndGoToTestCaseManagement()
		{
		}

		public void ShowScreenAndGoToPlay(bool KLEHGPMGPHM = true)
		{
		}

		public void ShowScreenAndGoToPlayMenu()
		{
		}

		public void ShowScreenAndGoToCreateMenu(bool AMBLGCPNOEK = true)
		{
		}

		public void ShowScreenAndGoToEvents()
		{
		}

		public void ShowScreenAndGoToEventsBrowser()
		{
		}

		public void ShowScreenDetachedAndGoToPlayMenuSearch(string ADGIOFAMOGF, DBECJLAIPEL GLLFHCCFIGK, Vector3? INLGLHIPOMC = null)
		{
		}

		public void ShowScreenAndGoToPlayMenuSearch(string ADGIOFAMOGF, DBECJLAIPEL GLLFHCCFIGK, bool ICCDFIEAKDE, bool HCGNCNHEIBG = false)
		{
		}

		public void ShowScreenAndGoToMyProfile(bool ICCDFIEAKDE = true)
		{
		}

		public void ShowScreenAndGoToProfile(int EJIHLJJMOBD, bool ICCDFIEAKDE = true, bool IDLKDDEBFDP = false, bool FAOBALNFCAD = false)
		{
		}

		public void ShowScreenAndGoToPeople(bool AMBLGCPNOEK = true)
		{
		}

		public void ShowScreenAndGoToSavedOutfits(string PGEIBONDJJP)
		{
		}

		public void ShowScreenAndGoToParty(bool AMBLGCPNOEK = true)
		{
		}

		public void GoToChat(LFFKCMNFNAN GLLFHCCFIGK, bool ICCDFIEAKDE = true, bool AOLBMPLJLKL = true)
		{
		}

		public void GoToChat(long FFBALOOMPIB, LFFKCMNFNAN GLLFHCCFIGK, bool ICCDFIEAKDE = true, bool AOLBMPLJLKL = true)
		{
		}

		public bool IsOnChat()
		{
			return false;
		}

		public void ShowScreenAndGoToNotifications(bool CKMIGAPECHM)
		{
		}

		public void ShowScreenAndGoToCreateAnnouncement(long AFPHABFLEBN, ClubAnnouncementCreationModel.MIECNDJNDKA PBIOOLMNIAD)
		{
		}

		public void ShowScreenAndGotoSubscriptions()
		{
		}

		public void ShowScreenAndGotoPortfolio(int EJIHLJJMOBD, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGotoStandalone(RRUI.Navigation.Uri IHFCKHNEHFH, bool FAOBALNFCAD = false)
		{
		}

		public void ShowScreenAndGotoWishlist(int EJIHLJJMOBD)
		{
		}

		public void ShowScreenAndGotoOutfit(int EJIHLJJMOBD, bool ICCDFIEAKDE = true)
		{
		}

		public void ShowScreenAndGoToStoreTab(string PGEIBONDJJP)
		{
		}

		public void ShowScreenAndGoToStore(string PGEIBONDJJP, bool HHPJOMNOHPC = true)
		{
		}

		public void DisplayGoToStorePrompt(string ANJAOEPDJML, string FOKHCBODMCD)
		{
		}

		public LAHBDKNMNHN DisplaySkuPurchaseSuccessDialog(string ANJAOEPDJML, string FOKHCBODMCD, bool IGDMDHFNMPF)
		{
			return null;
		}

		public void ShowScreenAndGoToStoreClothing(int MBEMMAGIHIH, bool ICCDFIEAKDE = true)
		{
		}

		public global::NCOKFFGPIJM<CheckoutDialogModel> ShowScreenAndDisplayCheckoutDialog<TFromModel, TToCardControllerProvider>(LJJIHDDNLNB HKOEAGLLOOM) where TFromModel : ModelBase where TToCardControllerProvider : ControllerBase, AJFPIIJCIFO, DDIDMFFBNAE
		{
			return null;
		}

		public void ShowBundleTrialResolution(DELOHOCBIDM HNLEJKJFLGO, string PGEIBONDJJP, POPLPJGHHIA.EGCCHLKLIIL FONLDCNNLKG)
		{
		}

		public void ShowScreenAndGoToStoreInventions()
		{
		}

		public void ShowScreenAndGoToStoreDormSkins()
		{
		}

		public void ShowScreenAndGoToInventionDetails(long KBPFKPGOCFN, string PGEIBONDJJP, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToInventionSearch(List<string> GALCLCJNKMM, string PGEIBONDJJP, string NIOBDAGDJAE, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToStoreItemSearch(string NIOBDAGDJAE, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToItemDetails(int APKDLPDLNEE, bool HHPJOMNOHPC = true)
		{
		}

		public void ShowScreenAndGoToCustomAvatarItemDetails(Guid JGNABAMMKMP, bool AMBLGCPNOEK, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG)
		{
		}

		public void ShowScreenAndGoToCustomAvatarItemDetails(Guid JGNABAMMKMP, ManagedTexture MDNCPEOLOJF, Color HMCAFGCGFJF, bool AMBLGCPNOEK, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG)
		{
		}

		public void ShowScreenAndGoToCustomAvatarItemFeaturedPage()
		{
		}

		public void ShowScreenAndGoToCustomAvatarItemSearch(PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG, string NIOBDAGDJAE)
		{
		}

		public void ShowScreenAndGoToCustomAvatarItemStorePage(Guid JGNABAMMKMP, bool AMBLGCPNOEK, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG)
		{
		}

		public void ShowScreenAndGoToTokenStore(string PGEIBONDJJP, bool HGLNDEOCGNE)
		{
		}

		public void ShowScreenAndGoToRRPlusSignUp(string PGEIBONDJJP, bool KDLBPJOMMGP, EEANDDJEMJC AMFKAIJIABD = null, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD = POPLPJGHHIA.EGCCHLKLIIL.None)
		{
		}

		public void ShowScreenAndGoToStarterPackDetails(POPLPJGHHIA.OCDCJKGHBON EEFFOCCPECD, string PGEIBONDJJP, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD = POPLPJGHHIA.EGCCHLKLIIL.None)
		{
		}

		public void GoToStarterPackDetails(POPLPJGHHIA.OCDCJKGHBON EEFFOCCPECD, string PGEIBONDJJP, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD = POPLPJGHHIA.EGCCHLKLIIL.None)
		{
		}

		public void ShowScreenAndGoToFriendotronMain()
		{
		}

		public void ShowScreenAndGoToUri(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
		}

		public void ShowScreenAndGoToBugReporting()
		{
		}

		public void ShowScreenAndGoToDebug()
		{
		}

		public void TryShowEscMenu()
		{
		}

		public void ShowScreenAndGoToPlayerBanned()
		{
		}

		public void ShowScreenAndGoToPlayerWarned()
		{
		}

		public void ShowScreenAndGoToHighestPriorityChallengesPage()
		{
		}

		public void ShowScreenAndGoToAvatarCustomization()
		{
		}

		public global::NCOKFFGPIJM<MessageDialogModel> ShowMessageDialog(string OFMGPNLDCAB, string OFCFPGACNJB, Sprite DLADPCHJMME, OMGIPOLPCND CAPKFCHDLFA = OMGIPOLPCND.Small)
		{
			return null;
		}

		public global::NCOKFFGPIJM<MessageDialogModel> ShowMessageDialog(IPGOOJIFBAB PCPEJHIMHJJ)
		{
			return null;
		}

		public global::NCOKFFGPIJM<OneButtonMessageDialogModel> ShowOneButtonMessageDialog(string OFMGPNLDCAB, string OFCFPGACNJB, string AICBAMHEBBB)
		{
			return null;
		}

		public void ShowScreenAndGoToReferralRewards(bool FJJDHJNFMBG = true, bool KDLBPJOMMGP = true)
		{
		}

		public void ShowScreenAndGoToActionCode(HJIIMKJBOHI HDEEDHODCOE, ActionCode.NMLEIPDLABI ABPFMLKOJAM)
		{
		}

		public void ShowScreenAndGoToEnterActionCode()
		{
		}

		public void ShowScreenAndGoToRoomKeysBrowser(long EPOBIFCHLNM)
		{
		}

		public void ShowScreenAndGoToRoomKeysCreate(long EPOBIFCHLNM = -1L)
		{
		}

		public bool TryShowScreenAndGoToRoomKeyStore(Guid AOKOLHLKHFE, EEANDDJEMJC HPBHPGBHAOG = null, bool JPHFBJCBOIM = true, string NNECEELJHMM = null)
		{
			return false;
		}

		public void EnsureCurrentFlow()
		{
		}

		public void ShowScreenAndGoToRoomCurrenciesBrowser(long EPOBIFCHLNM)
		{
		}

		public void ShowScreenAndGoToRoomCurrenciesCreate(long EPOBIFCHLNM = -1L)
		{
		}

		public void ShowScreenAndGoToRoomCurrencyStore(Guid DJOFODHJEBF, bool JPHFBJCBOIM = true, string NNECEELJHMM = null)
		{
		}

		public void ShowScreenAndGoToRoomConsumablesBrowser(long EPOBIFCHLNM)
		{
		}

		public void ShowScreenAndGoToRoomConsumablesCreate(long EPOBIFCHLNM = -1L)
		{
		}

		public bool TryShowScreenAndGoToRoomConsumableStore(Guid JNHIIPBPEOB, bool JPHFBJCBOIM = true, string NNECEELJHMM = null)
		{
			return false;
		}

		public void ShowScreenAndGoToRoomConsumablesBackpack()
		{
		}

		public void ShowScreenAndGoToUGCStorefrontBrowser(UGCStorefront OCNGKLDCJKG)
		{
		}

		public void ShowScreenAndGoToRewardSelection(PEIGAAKDIDI HCIBGFPNHCJ)
		{
		}

		public void CloseRewardSelectScreen()
		{
		}

		public LAHBDKNMNHN ShowScreenAndGoToEmailPrompt(string GFFOMHMCDGE = null)
		{
			return null;
		}

		public LAHBDKNMNHN ShowScreenAndGoToPhonePrompt(string GFFOMHMCDGE = null)
		{
			return null;
		}

		public void ShowScreenAndDisplayScreenShareReportDialog(string NPOEAPJKNFN, int MKHHFAPLOPC)
		{
		}

		private void FDJJFJNDBAF()
		{
		}

		public void ResetWatchToHome()
		{
		}

		public override void Show()
		{
		}

		public override void Hide()
		{
		}

		public T GoTo<T>(string LDPCFDMCJLH = null) where T : StackedUIFlowBase
		{
			return null;
		}

		public void ShowProgressionEventTutorialEndPrompt()
		{
		}

		public void ShowScreenAndGotoNewPlayerChallenges(bool OGMGOJLHJEC = false, bool JHJEKDFMFMJ = false)
		{
		}

		public void ShowScreenAndGotoProgressionEvents(bool JHJEKDFMFMJ = false)
		{
		}

		public void ShowScreenAndGotoKeepsakeEvents(bool JHJEKDFMFMJ = false)
		{
		}

		private void NPKJJMKCCKD(BrowserModel.NHMLINFLOOA KNBPIEINLIG)
		{
		}

		private void BFIENGOGLBD()
		{
		}

		public void Button_Home()
		{
		}

		[CompilerGenerated]
		private void MKHKMMAFGFC()
		{
		}

		[CompilerGenerated]
		private void ALLOMMBOILO()
		{
		}

		[CompilerGenerated]
		private void EDJGICEILKE()
		{
		}

		[CompilerGenerated]
		private void PONMIKBCJOA()
		{
		}
	}
}
