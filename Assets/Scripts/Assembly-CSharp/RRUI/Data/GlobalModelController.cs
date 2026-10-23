using System;
using System.Collections.Generic;
using RRUI.Navigation;
using RecRoom.Core;
using UnityEngine;

namespace RRUI.Data
{
	public class GlobalModelController : ModelController<GlobalModel>
	{
		[Serializable]
		private class LocalAccountImpl : ControllerImplementation<GlobalModel>
		{
			[SerializeField]
			private AccountModel accountModel;

			[SerializeField]
			private bool includeBio;

			[SerializeField]
			private bool includeReputation;

			[SerializeField]
			private bool includeProgression;

			[SerializeField]
			private bool includeSubscriberCount;

			[SerializeField]
			private bool includeUnreadCreatorAnnouncements;

			[SerializeField]
			private bool includePortfolio;

			[SerializeField]
			private bool includeMobileNotifications;

			[SerializeField]
			private bool includeInfluencerInfo;

			[SerializeField]
			private bool includePlatformInfo;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LocalRoomImpl : ControllerImplementation<GlobalModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			[SerializeField]
			private DBECJLAIPEL source;

			[SerializeField]
			private bool includeDetails;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LocalEventImpl : ControllerImplementation<GlobalModel>
		{
			[SerializeField]
			private EventModel eventModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OpenExternalWebpageButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			private enum AKMMIOKFGII
			{
				PrivacyPolicy = 0,
				TermsOfService = 1,
				HelpPage = 2,
				ComfortAndSafety = 3,
				CodeOfConduct = 4,
				InfluencerProgram = 5,
				RecNetTokenStorePage = 6,
				RecNetRRPlusMembershipPage = 7,
				Other = 99
			}

			[SerializeField]
			private AKMMIOKFGII webpage;

			[SerializeField]
			private string externalUrl;

			[SerializeField]
			private string externalPageName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavigateToRouteInWatchMenuButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			[SerializeField]
			private Route route;

			[SerializeField]
			private bool openDetached;

			[SerializeField]
			private bool resetBrowser;

			[SerializeField]
			private float detachedDistance;

			[SerializeField]
			private float detachedVerticalOffsetFromHead;

			[SerializeField]
			private float detachedScale;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CloseWatchMenuButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavigateToInventionSearchButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			[SerializeField]
			private List<string> tagList;

			[SerializeField]
			private string entrypointName;

			[SerializeField]
			private string inventionSubtype;

			[SerializeField]
			private bool sendInventionPurchaseFunnelEvent;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavigateToDormSkinsStoreButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			[SerializeField]
			private string entrypointName;

			[SerializeField]
			private string inventionSubtype;

			[SerializeField]
			private bool sendInventionPurchaseFunnelEvent;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavigateToCustomAvatarItemFeaturedPageButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavigateToCustomAvatarItemSearchPageButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TakeOutCameraButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NavigateToSavedOutfitsButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			private bool? isSavedOutfitRRUI;

			[SerializeField]
			private string entrypointName;

			private bool IsSavedOutfitRRUI => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchGetMoreTokensButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			[SerializeField]
			private string entrypointName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchEventsButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchRecRoomPlusButtonImpl : ButtonControllerImpl<GlobalModel>
		{
			[SerializeField]
			private string entrypointName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfJuniorImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<IIPELALCKPL>
		{
			[SerializeField]
			private bool limitedUGCForJuniorAccount;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotJuniorImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<IIPELALCKPL>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoLocalAccountImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLocalRoomHasNoEventImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLocalRoomHasEventImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowIfModeratorImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotDeveloperImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotDeveloperAndNotDebugBuildImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotDebugBuildImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideDuringNUXImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotCommunicateImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLocalRoomIsOfflineDormImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUserIsUGCRestrictedImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUserIsNotOnPlatformImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<EAFLPCNDJNK>
		{
			[SerializeField]
			private OJCAJBAODPP showForThesePlatforms;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUserIsOnPlatformImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<EAFLPCNDJNK>
		{
			[SerializeField]
			private OJCAJBAODPP hideForThesePlatforms;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUserIsOnHardwareImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<CILEIOOHEOB>
		{
			[SerializeField]
			private BGCMEPFEBCK hideForThisHardware;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUserIsNotOnHardwareImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<CILEIOOHEOB>
		{
			[SerializeField]
			private BGCMEPFEBCK showForThisHardware;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfScreensInputModeImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<GHOAEFHGEDM>
		{
			[SerializeField]
			private KLIMDPGKKGM inputType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotScreensInputModeImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<GHOAEFHGEDM>
		{
			[SerializeField]
			private KLIMDPGKKGM inputType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfVRImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<MJLJBHNFNAP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfScreensImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<MJLJBHNFNAP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLeagueNotMatchImpl : HideableControllerImpl<GlobalModel>
		{
			[SerializeField]
			private JKHJHBHHJMI.HEIFDMDAKJF league;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLeaguesDisabledImpl : HideableControllerImpl<GlobalModel>, global::NOPBJEAADPE<GGACGIDFPOI>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNewPlayerChallengesInactiveImpl : HideableControllerImpl<GlobalModel>
		{
			private LMNOCCKEMKH newPlayerChallengesManager;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformCantShareImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformCantCopyImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformCantShareOrCopyImpl : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideExitOrBackDependingOnStandalone : ControllerImplementation<GlobalModel>
		{
			[SerializeField]
			private Hideable exitButton;

			[SerializeField]
			private Hideable backButton;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformDoesNotSupportOpeningWebBrowser : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformSupportsOpeningWebBrowser : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfWeeklyChallengeInactive : HideableControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideScreensCursorControllerImpl : ControllerImplementation<GlobalModel>
		{
			private ScreenHUD ScreenHud => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			private void INJLJKBHOEO()
			{
			}

			private void BGLCHJGABIG()
			{
			}
		}

		[Serializable]
		private class LocalPlayerLinkImpl : LinkControllerImpl<GlobalModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MakerPenVRHandednessReparentingController : ControllerImplementation<GlobalModel>
		{
			[SerializeField]
			private Transform content;

			[SerializeField]
			private Transform rightyParent;

			[SerializeField]
			private Transform leftyParent;

			private static bool CheckForLeftHand => false;

			private static bool IsLeftHanded => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ResizeScreensContentImpl : ControllerImplementation<GlobalModel>
		{
			[SerializeField]
			private RectTransform _rectTransform;

			[SerializeField]
			private Vector2 _screensSize;

			[SerializeField]
			private Vector2 _vrSize;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
