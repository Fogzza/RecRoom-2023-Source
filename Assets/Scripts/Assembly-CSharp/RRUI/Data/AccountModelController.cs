using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Theme;
using RecNet;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class AccountModelController : ModelController<BaseAccountModel>, DDIDMFFBNAE
	{
		public enum ENMKDLCFKJI
		{
			IsFriend = 0,
			IsNotFriend = 1
		}

		[Serializable]
		private class BioTextImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string localAccountDefaultText;

			[SerializeField]
			private string remoteAccountDefaultText;

			[SerializeField]
			private LocalizedString localAccountDefaultLocText;

			[SerializeField]
			private LocalizedString remoteAccountDefaultLocText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DisplayNameTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EmojiTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UsernameTextImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PlatformDisplayNameTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LevelTextImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PresenceTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SubscriberCountTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SubscriberCountSmartTextImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private LocalizedString subscriberLocTextSmart;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RelationshipTextImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string relationshipNoneText;

			[SerializeField]
			private string relationshipRequestReceivedText;

			[SerializeField]
			private string relationshipRequestSentText;

			[SerializeField]
			private string relationshipFriendsText;

			[SerializeField]
			private LocalizedString relationshipNoneLocText;

			[SerializeField]
			private LocalizedString relationshipRequestReceivedLocText;

			[SerializeField]
			private LocalizedString relationshipRequestSentLocText;

			[SerializeField]
			private LocalizedString relationshipFriendsLocText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FavoriteTextImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string favoriteText;

			[SerializeField]
			private string unfavoriteText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SubscribeTextImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string subscribeText;

			[SerializeField]
			private string unsubscribeText;

			[SerializeField]
			private LocalizedString subscribeLocText;

			[SerializeField]
			private LocalizedString unsubscribeLocText;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ProfileNavbarTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OnlineStatusVisibilityTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PronounTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class IdentityTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FriendCountTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InventionCountTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomCountTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PhotoCountTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CustomAvatarItemCountTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class VersionMismatchTextImpl : TextControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OnlineTextImpl : TextControllerImpl<BaseAccountModel>
		{
			private MNIEBEJFEHJ _playerStatusFormatter;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TextColorOnlineIndicationImpl : TextControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Color onlineColor;

			[SerializeField]
			private Color offlineColor;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DisplayNameInputFieldImpl : InputFieldControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			private bool havePopulatedSinceShow;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class BioInputFieldImpl : InputFieldControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			private bool havePopulatedSinceShow;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class UsernameInputFieldImpl : InputFieldControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class AccountImageImpl : RecNetRawImageControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountSilhouettedImageImpl : RawImageControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(bool JKJHGGNCEEA)
			{
			}
		}

		[Serializable]
		private class ProfileBannerImageImpl : RecNetRawImageControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ExperienceBarImpl : ImageControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OnlineIndicatorImpl : ImageControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Color onlineColor;

			[SerializeField]
			private Color offlineColor;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CheerBadgeOpacityImpl : ImageControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private DINMFHPHBEG.MMCGOCLBAEG category;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FavoriteIconImpl : ImageControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Sprite favoriteImage;

			[SerializeField]
			private Sprite unfavoriteImage;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SubscribeIconImpl : ImageControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Sprite subscribeImage;

			[SerializeField]
			private Sprite unsubscribeImage;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class IdentityFlagImageImpl : ImageControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private int flagIndex;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool NOPJPIEKDHD(GADDFKOBCNK NCJCLJGCIMF)
			{
				return false;
			}
		}

		[Serializable]
		private class CheerBadgeImageImpl : ImageControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LeagueIconImpl : ImageControllerImpl<BaseAccountModel>, global::MFKLLBLDGMH<JKHJHBHHJMI.HEIFDMDAKJF>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LeagueBackgroundImpl : RecNetRawImageControllerImpl<BaseAccountModel>, global::MFKLLBLDGMH<JKHJHBHHJMI.HEIFDMDAKJF>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TryChangePortfolioBannerImageButtonImpl : ButtonControllerImpl<AccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FavoriteToggleImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RelationshipToggleImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubscribeButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LeagueButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RoomBanButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Sprite banImage;

			[SerializeField]
			private Sprite unbanImage;

			[SerializeField]
			private Image image;

			[SerializeField]
			private string banText;

			[SerializeField]
			private string unbanText;

			[SerializeField]
			private LocalizedString banLocText;

			[SerializeField]
			private LocalizedString unbanLocText;

			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PlatformAccountImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenPlayersFullBioDialogImpl : ButtonControllerImpl<AccountModel>
		{
			[SerializeField]
			protected TextMeshProUGUI bioText;

			[SerializeField]
			protected TextMeshProUGUI readMoreText;

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void ADBILIJEGGC(TMP_TextInfo IOKKLHMKGAH)
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DeleteAccountButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchCheerPlayerButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchReportPlayerScreenButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private void OCPEODBABOB(ReportWatchUIFlow JHCMPHLGEED)
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchVotekickScreenButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchBlockListScreenButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchIntroduceScreenButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GiftStorefrontButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OutfitButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenReportPlayerDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenFriendSettingsDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenCheerBadgeDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenOnlineStatusDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PartyUpButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LeavePartyButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InviteButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Hoverable hoverable;

			[SerializeField]
			private CalloutDialogTarget disabledInfoTarget;

			private const string DISABLED_INFO_CALLOUT_KEY = "inviteButton_disabledInfo";

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private void BHODPBAMMID(PointerEventData HLMEKEJJPIN)
			{
			}

			private void JLEGHDNJPBG(PointerEventData HLMEKEJJPIN)
			{
			}
		}

		[Serializable]
		private class GoToButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Hoverable hoverable;

			[SerializeField]
			private CalloutDialogTarget disabledInfoTarget;

			private const string DISABLED_INFO_CALLOUT_KEY = "goToButton_disabledInfo";

			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private bool hideTextIfNotInteractable;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private void BHODPBAMMID(PointerEventData HLMEKEJJPIN)
			{
			}

			private void JLEGHDNJPBG(PointerEventData HLMEKEJJPIN)
			{
			}
		}

		[Serializable]
		private class CheerBadgeToggleImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private DINMFHPHBEG.MMCGOCLBAEG category;

			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BlockPlayerButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Sprite blockImage;

			[SerializeField]
			private Sprite unblockImage;

			[SerializeField]
			private Image image;

			[SerializeField]
			private string blockText;

			[SerializeField]
			private string unblockText;

			[SerializeField]
			private LocalizedString blockLocText;

			[SerializeField]
			private LocalizedString unblockLocText;

			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MutePlayerButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private Sprite muteImage;

			[SerializeField]
			private Sprite unmuteImage;

			[SerializeField]
			private Image image;

			[SerializeField]
			private string muteText;

			[SerializeField]
			private string unmuteText;

			[SerializeField]
			private LocalizedString muteLocText;

			[SerializeField]
			private LocalizedString unmuteLocText;

			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ChatThreadLinkImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveUsernameButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveDisplayNameButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveDisplayEmojiButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveBioButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OnlineStatusVisibilityDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private GameObject buttonPrefab;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PronounSelectionDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class IdentityFlagSelectionDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ChangePasswordDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddEmailDialogButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToggleSupportButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private string supportText;

			[SerializeField]
			private string unsupportText;

			[SerializeField]
			private LocalizedString supportLocText;

			[SerializeField]
			private LocalizedString unsupportLocText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenAdjectiveMenuSelectionButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenNounMenuSelectionButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenEmojiMenuSelectionButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private string defaultEmojiForNonRRPlusSurfacing;

			private string _defaultEmojiForNonRRPlusSurfacingParsedValue;

			[SerializeField]
			private CanvasPositioner.CanvasPositionerPlacement emojiPickerPlacement;

			[SerializeField]
			private string emojiPickerAnalyticsContext;

			[SerializeField]
			private EmojiPickerRootModel emojiPickerRootModel;

			private MIHKELGJLFO emojiPickerData;

			private int cachedAccountId;

			private string defaultEmojiForNonRRPlusSurfacingParsedValue => null;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			private void HFFNNMBLMOL(POPLPJGHHIA.IBLMGFBJMDI HGAEJEHIHKC)
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void HKAOMFAEPMC(string IODMDDBIFEI)
			{
			}

			[CompilerGenerated]
			private void GHAKEMGDPDA()
			{
			}
		}

		[Serializable]
		private class SaveJuniorDisplayNameButtonImpl : ButtonControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NotifyFriendsWhenOnlineToggleImpl : ToggleControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NotifyMeWhenFriendsOnlineToggleImpl : ToggleControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AllWatchNotificationsToggleImpl : ToggleControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class WatchNotificationToggleImpl : ToggleControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private BJCIKFCDBFN.JGBHDFADCMI notificationType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RecentHistoryVisibilityToggleImpl : ToggleControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}
		}

		[Serializable]
		private class RecentCarouselTypeToggleImpl : ToggleControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private BaseAccountModel.GOECMMIPHNN carouselType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AccountIdLinkImpl : LinkControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private bool forceOpenInWatch;

			[SerializeField]
			private bool setAccountDisplayName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		public class FriendsPageSourceLinkImpl : LinkControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private CJIHECEJAHH source;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class StatsigConditionalAccountIdLinkImpl : StatsigLinkControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private bool setAccountDisplayName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InventionListLinkImpl : LinkControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RoomsCreatedByLinkImpl : LinkControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private RoomListModel.DDFKFJLFOKF ownershipFilter;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RoomsShowcaseLinkImpl : LinkControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubsCreatedByLinkImpl : LinkControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowIfJuniorForMetaEmptyImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBioEmptyImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfEmojiEmptyImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotFriendImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<ENMKDLCFKJI>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfFriendImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<ENMKDLCFKJI>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPendingFriendsImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotPendingFriendsImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfMutedImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotMutedImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBlockedImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfOfflineImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfOnlineImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfActuallyOfflineImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInPartyImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<OBCCGDPMMFD>
		{
			[SerializeField]
			private bool includeSelf;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInPartyImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<OBCCGDPMMFD>
		{
			[SerializeField]
			private bool includeSelf;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideLeavePartyButtonImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInSameRoomImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInSameRoomImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideRoomBanButtonImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UnreadCreatorAnnouncementIconImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotLocalAccountImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLocalAccountImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInfluencerImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<AGOJAELPMOC>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInfluencerImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<AGOJAELPMOC>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLocalAccountIsInfluencerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotSupportingInfluencerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotSupportedByLocalPlayerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideMutualFriendsImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(List<EOKKPHLOBBD> FDFLLMDJJLO)
			{
			}
		}

		[Serializable]
		private class HideDeveloperBadgeImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoPortfolioImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideRoomPortfolioCardImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideInventionPortfolioCardImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideCustomAvatarItemPortfolioCardImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HidePortfolioDefaultTextImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoPronounsImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRecentHistoryNotVisible : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLessThanTwoIdentityFlagImpl : HideableControllerImpl<BaseAccountModel>
		{
			private sealed class PJGEEKCDADG
			{
				public HideIfLessThanTwoIdentityFlagImpl _003C_003E4__this;

				public int flagCount;

				internal void _003COnModelChanged_003Eb__0(GADDFKOBCNK flag)
				{
				}
			}

			[SerializeField]
			private int minNumber;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotActiveCarouselImpl : HideableControllerImpl<BaseAccountModel>
		{
			[SerializeField]
			private BaseAccountModel.GOECMMIPHNN carouselType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoCheerBadgeImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideSetBadgesButtonImpl : HideableControllerImpl<BaseAccountModel>
		{
			private sealed class LAMICDMBOAN
			{
				public HideSetBadgesButtonImpl _003C_003E4__this;

				public bool hasAnyCheer;

				internal void _003COnModelChanged_003Eb__0(DINMFHPHBEG.MMCGOCLBAEG category)
				{
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideReportButtonImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNonDevNonModeratorAccountImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HidePlatformDisplayPanelImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HidePlatformLogoButtonImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBlockedByLocalPlayerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotBlockedByLocalPlayerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBlockingLocalPlayerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotBlockingLocalPlayerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfFavoritedByLocalPlayerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotFavoritedByLocalPlayerImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfJuniorAccountImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowIfJuniorAccountImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCoachImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCheerNotEqualImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<DINMFHPHBEG.MMCGOCLBAEG>
		{
			[SerializeField]
			private DINMFHPHBEG.MMCGOCLBAEG cheer;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerBlockedImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerNotMutedImpl : HideableControllerImpl<BaseAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInMyLeagueImpl : HideableControllerImpl<BaseAccountModel>, global::NOPBJEAADPE<GGACGIDFPOI>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountFromUriImpl : FromUriControllerImpl<AccountModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class FullAccountFromUriImpl : FromUriControllerImpl<AccountModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class AccountToCardImpl : ToCardControllerImpl<BaseAccountModel>
		{
			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class AccountToInventionListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private InventionListModel inventionListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccoutToCreatedRoomListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private RoomListModel roomListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToVisitedRoomListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private RoomListModel roomListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToCreatorClubImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private ClubModel clubModel;

			[SerializeField]
			private bool includeDetails;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void CPIGDEKABHN(long? AFPHABFLEBN)
			{
			}
		}

		[Serializable]
		private class AccountToClubListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private ClubListModel clubListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MemberAccountToClubListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private ClubListModel clubListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToCurrentRoomImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToCreatedRoomImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToCreatedInventionImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private InventionModel inventionModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToCreatedCustomAvatarItemImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private CustomAvatarItemModel customAvatarItemModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToAccountListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private AccountListModel accountListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToWishlistImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private WishlistModel wishlistModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToCustomAvatarItemListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private CustomAvatarItemListModel customAvatarItemListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToEventListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private EventListModel eventListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToImageListImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private ImageListModel imageListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToRemoteAvatarImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private AvatarModel avatarModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToSupportedAccountImpl : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private AccountModel accountModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MobileNotificationSpawnerImpl : PrefabSpawnerControllerImpl<BaseAccountModel>
		{
			private sealed class GHECEHNDLGG
			{
				public MobileNotificationSpawnerImpl _003C_003E4__this;

				public PlatformNotificationCategoryConfigDTO categoryConfig;

				internal void _003COnPopulateInstance_003Eg__ToggleNotificationCategory_007C0()
				{
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}
		}

		[Serializable]
		private class PlayerAudioVolumeUpdater : ControllerImplementation<BaseAccountModel>
		{
			[SerializeField]
			private AudioVolumeView audioVolumeView;

			[SerializeField]
			private float playerAudioUpdateFrequency;

			[SerializeField]
			private float playerAudioVolumeMax;

			private IDisposable updateAccountPlayerAudioToken;

			private bool AudioUpdateRunning => false;

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private bool JNNKLKFIABP()
			{
				return false;
			}

			private bool KPDHMDINLAF()
			{
				return false;
			}

			[CompilerGenerated]
			private void HHGCDBMNBCF(float BBGNJMKOHPL)
			{
			}
		}

		[Serializable]
		private class OpenedProfileImpl : ControllerImplementation<AccountModel>
		{
			private enum OMNFCBJEMND
			{
				OpenedOwnProfile = 0,
				OpenedOtherPlayersProfile = 1,
				OpenedOnlineStatusModal = 2,
				OpenedOtherPlayersPortfolio = 3
			}

			[SerializeField]
			private OMNFCBJEMND eventToFire;

			[SerializeField]
			private bool onlyFireIfAccountIsLocalPlayerAccount;

			[SerializeField]
			private bool onlyFireIfAccountIsNotLocalPlayerAccount;

			private bool hasFired;

			private LHMPPJKHCJG playerProvider;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private void MJCIMBOHNDB()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
