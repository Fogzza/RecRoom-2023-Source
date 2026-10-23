using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RecNet;
using RecRoom.Utils.Image;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public abstract class BaseAccountModel : RRUIModel<DAKMOAKIKIC>
	{
		public enum GOECMMIPHNN
		{
			Rooms = 0,
			Clubs = 1,
			Events = 2
		}

		private enum AOKABNFFNHH
		{
			Adjective = 0,
			Noun = 1
		}

		public enum MMGECJBGHMF
		{
			ONLINE_VISIBILITY_TEXT_ALL = 0,
			ONLINE_VISIBILITY_TEXT_FRIENDS = 1,
			ONLINE_VISIBILITY_TEXT_FAVORITES = 2,
			ONLINE_VISIBILITY_TEXT_NO_ONE = 3,
			PROFILE_TITLE_LOCAL = 4,
			PROFILE_TITLE_REMOTE = 5,
			GO_TO = 6,
			JOIN_THEM = 7,
			ROOM_FULL = 8,
			PRESENCE_STATUS_ROOM_FULL = 9
		}

		private sealed class OIAIHFGGBDP
		{
			public BaseAccountModel _003C_003E4__this;

			public bool success;

			internal void _003CTryRoomUnbanPlayer_003Eb__0()
			{
			}

			internal void _003CTryRoomUnbanPlayer_003Eb__1(string err)
			{
			}

			internal void _003CTryRoomUnbanPlayer_003Eb__2()
			{
			}
		}

		private sealed class NFFOHBLPPIJ
		{
			public BaseAccountModel _003C_003E4__this;

			public BaseDialogModel<DHAPPKCJJCA> activeDialog;

			internal DGMPBIPKJEB _003CShowPronounSelectionDialog_003Eb__0(NIOMAOPFJBI pronoun)
			{
				return null;
			}

			internal void _003CShowPronounSelectionDialog_003Eb__5()
			{
			}

			internal void _003CShowPronounSelectionDialog_003Eb__1(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class FDIMINNKFJE
		{
			public NIOMAOPFJBI pronoun;

			public NFFOHBLPPIJ CS_0024_003C_003E8__locals1;

			internal bool _003CShowPronounSelectionDialog_003Eb__2()
			{
				return false;
			}

			internal void _003CShowPronounSelectionDialog_003Eb__3(bool b)
			{
			}
		}

		private sealed class GDOBOOOKCOF
		{
			public NIOMAOPFJBI pronouns;

			public List<string> activeSingleSuffixes;

			public BaseAccountModel _003C_003E4__this;

			internal void _003CGetPronounText_003Eb__0(NIOMAOPFJBI pronoun)
			{
			}
		}

		private sealed class EIMHDEIKGOF
		{
			public GADDFKOBCNK identityFlags;

			public List<string> activeFlagNames;

			internal void _003CGetIdentityFlagText_003Eb__0(GADDFKOBCNK flag)
			{
			}
		}

		private sealed class HBMHBLALBNJ
		{
			public BaseAccountModel _003C_003E4__this;

			public BaseDialogModel<DHAPPKCJJCA> activeDialog;

			internal DGMPBIPKJEB _003CShowIdentityFlagSelectionDialog_003Eb__0(GADDFKOBCNK identityFlag)
			{
				return null;
			}

			internal void _003CShowIdentityFlagSelectionDialog_003Eb__5()
			{
			}

			internal void _003CShowIdentityFlagSelectionDialog_003Eb__1(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class ODLBMGICPMC
		{
			public GADDFKOBCNK identityFlag;

			public HBMHBLALBNJ CS_0024_003C_003E8__locals1;

			internal bool _003CShowIdentityFlagSelectionDialog_003Eb__2()
			{
				return false;
			}

			internal void _003CShowIdentityFlagSelectionDialog_003Eb__3(bool b)
			{
			}
		}

		private sealed class PMAIOKLNAHD
		{
			public string oldPasswordValue;

			public string newPasswordValue;

			public bool waitingForResponse;

			public BaseAccountModel _003C_003E4__this;

			public BaseDialogModel<DHAPPKCJJCA> activeDialog;

			public Action _003C_003E9__6;

			public Action<string> _003C_003E9__7;

			public Action _003C_003E9__8;

			internal string _003CShowChangePasswordDialog_003Eb__1()
			{
				return null;
			}

			internal void _003CShowChangePasswordDialog_003Eb__2(string s)
			{
			}

			internal string _003CShowChangePasswordDialog_003Eb__3()
			{
				return null;
			}

			internal void _003CShowChangePasswordDialog_003Eb__4(string s)
			{
			}

			internal void _003CShowChangePasswordDialog_003Eb__5()
			{
			}

			internal void _003CShowChangePasswordDialog_003Eb__6()
			{
			}

			internal void _003CShowChangePasswordDialog_003Eb__7(string error)
			{
			}

			internal void _003CShowChangePasswordDialog_003Eb__8()
			{
			}

			internal void _003CShowChangePasswordDialog_003Eb__9()
			{
			}

			internal void _003CShowChangePasswordDialog_003Eb__0(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class MMLOPOBHMOA
		{
			public BaseAccountModel _003C_003E4__this;

			public bool isSupportChange;

			internal void _003CSupportInfluencer_003Eb__0()
			{
			}

			internal void _003CSupportInfluencer_003Eb__1(string e)
			{
			}
		}

		private sealed class EMBJPPOKKPA
		{
			public AOKABNFFNHH part;

			public BaseAccountModel _003C_003E4__this;

			public BaseDialogModel<DHAPPKCJJCA> activeDialog;

			internal object _003CShowDisplayNameMenu_003Eb__3()
			{
				return null;
			}

			internal void _003CShowDisplayNameMenu_003Eb__4(object key)
			{
			}

			internal void _003CShowDisplayNameMenu_003Eb__5()
			{
			}

			internal void _003CShowDisplayNameMenu_003Eb__2(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class DPEOAPKCINE
		{
			public GDHOAGNFOBD.FPPNEFOBPMC emptySelection;

			public BaseAccountModel _003C_003E4__this;

			public Func<bool> _003C_003E9__2;

			internal List<GDHOAGNFOBD.FPPNEFOBPMC> _003CShowPortfolioBannerImageSelectionDialog_003Eb__0(List<GDHOAGNFOBD.FPPNEFOBPMC> images)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<long> _003CShowPortfolioBannerImageSelectionDialog_003Eb__1(List<GDHOAGNFOBD.FPPNEFOBPMC> savedImageDTOs)
			{
				return null;
			}

			internal bool _003CShowPortfolioBannerImageSelectionDialog_003Eb__2()
			{
				return false;
			}
		}

		private sealed class EPIEBHLMBNH
		{
			public string currentConfirmText;

			public BaseAccountModel _003C_003E4__this;

			public MessageWithInputFieldDialogModel activeDialog;

			public EHEJPNFKNAL applyButton;

			internal bool _003CShowDeleteAccountConfirmationDialog_003Eb__2()
			{
				return false;
			}

			internal void _003CShowDeleteAccountConfirmationDialog_003Eb__3()
			{
			}

			internal string _003CShowDeleteAccountConfirmationDialog_003Eb__4()
			{
				return null;
			}

			internal void _003CShowDeleteAccountConfirmationDialog_003Eb__5(string s)
			{
			}

			internal void _003CShowDeleteAccountConfirmationDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}

			internal void _003CShowDeleteAccountConfirmationDialog_003Eg__ConfirmDelete_007C1()
			{
			}
		}

		private sealed class LILJNBNAPLE
		{
			public PickerDialogModel activeDialog;

			public BaseAccountModel _003C_003E4__this;

			public JNKNMMDAHCF settingsManager;

			internal void _003CShowChangeOnlineStatusVisibilityDialog_003Eb__4()
			{
			}

			internal void _003CShowChangeOnlineStatusVisibilityDialog_003Eb__0(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
			{
			}

			internal int _003CShowChangeOnlineStatusVisibilityDialog_003Eb__1()
			{
				return 0;
			}

			internal void _003CShowChangeOnlineStatusVisibilityDialog_003Eb__2(int index)
			{
			}

			internal void _003CShowChangeOnlineStatusVisibilityDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private OHCCDNIDCMM JOMDADCFHIG;

		private DFDECAEJBIO ECINDJLCDOK;

		protected string OHOKPDNHJAO;

		private EOKKPHLOBBD PCPPICDOGBP;

		private PJFDADLIKCD JGEEJEAAOCO;

		private string APHDEOPCGDC;

		private IBINLLOMNPN NLMGCJEFCEO;

		protected IGBPGJHGFFP MADEEKOIJKH;

		protected int KHIJBGMHDDN;

		protected KPPGJKNBIJK BJABAOIEEFA;

		public bool hasUnreadCreatorAnnouncements;

		protected IReadOnlyList<JCDPHCELKHI> JBCKFEELPPD;

		protected IReadOnlyList<OEBAEGDPBLA> KFCMGEEIPDI;

		protected IReadOnlyList<GDHOAGNFOBD.FPPNEFOBPMC> GIJMHIHEHOI;

		protected IReadOnlyList<LINLOKECLME> IGGAHNKMPLG;

		protected IReadOnlyList<LINLOKECLME> KJMGFGFCAKL;

		protected IReadOnlyList<PlatformNotificationCategoryConfigDTO> LCHOLGHGIPD;

		public bool hasMobileNotificationSettingsChanges;

		protected PlatformNotificationPreferencesDTO JFKDAGACHGC;

		private NIOMAOPFJBI HNJMEDIAEHP;

		private bool HBPLCMANAAK;

		private string GHNMKMIHKHD;

		private GADDFKOBCNK CELHBGIEEFC;

		private bool CCOHJOCPBDJ;

		private string OPLALPJAHAK;

		private bool GACDPPMPJOP;

		private string FJKAMMIAHBP;

		private string BCJLNCPAEOG;

		private bool DAIELIPMNGG;

		private string BNFMDNKIELN;

		private bool BILCIHIIOKH;

		private string KFMEHDOPBEI;

		private bool? KEEDCLLEHLA;

		private bool OMFOCJMGNEC;

		private GOECMMIPHNN JBJBHPNMGLB;

		private bool GAGELBBMOFM;

		private int? FEDHCLCAPJN;

		private int? GLKCPMFDEKK;

		private bool GGCHMCJMHMI;

		private ILEPIGEGDOM JAENHKKODHC;

		private LHMPPJKHCJG KOCMHELAMME;

		private bool DPHAKKCFOHB;

		private CDLILHDKGGD GDPDKMDOBMH;

		private DCFGCHBJPOO DELMILNBBIJ;

		private readonly ManagedTexture MJJGDNFAGDN;

		private const long BPMHFGIPAEF = 0L;

		private DEEMBIEOJJH IOMOGJIIHEP;

		private MNIEBEJFEHJ FOMIOEDECEP;

		private IILDCCEMGBA PBGJGLECDCA;

		private const string LJGEKDADDEP = "Growth.SupportInfluencerConfirmMessage";

		private const string BPHKLPCAFLB = "new_portfolio_page_enabled";

		private const string HGCEOJEBAPM = "watch_layer";

		private JCHCNCODBEK DBFBMFDJCPJ;

		protected int EJIHLJJMOBD;

		protected bool MIFIPDDBAON;

		public MKKJLGPDDKJ.HDFOAMJMPJD JuniorDisplayNameGenerationOptions;

		public string JuniorDisplayNameAdjectiveBackingField;

		public string JuniorDisplayNameNounBackingField;

		protected bool JKLMFGLAOJH;

		protected bool IGGFNPBFNJC;

		protected bool FALCAMIJFPA;

		protected bool BFNPOCBNJFB;

		protected bool ONAMICCOJAA;

		protected bool KKKAEEJPIDP;

		protected bool EFDKDJHMNBA;

		protected bool KFEJJADAALD;

		protected bool PHNIPHJEDCH;

		protected bool KHCDKIDBECA;

		protected bool CPDFFENAGIJ;

		protected bool CELNCDILGCM;

		private string MGHDEEDHMGG;

		private string LKBJJNDELIJ;

		private bool JMAGFMCILHH;

		private IPGOOJIFBAB HJIECHMPOJG;

		private readonly List<string> AGDIGGAOCAF;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public bool HasAccount
{
get 		{
			return false;
		}

}

public bool IsLocalAccount
{
get 		{
			return false;
		}

}

public DFDECAEJBIO Account
{
get 		{
			return null;
		}

set {
		}
}

public string Bio
{
get 		{
			return null;
		}

set {
		}
}

public EOKKPHLOBBD Relationship
{
get 		{
			return null;
		}

private set {
		}
}

public PJFDADLIKCD PlayerPresence
{
get 		{
			return null;
		}

private set {
		}
}

public string PlayerPresencePrivatizedRoomName
{
get 		{
			return null;
		}

private set {
		}
}

public IBINLLOMNPN AccountPlayer
{
get 		{
			return null;
		}

private set {
		}
}

public bool AccountPlayerExists
{
get 		{
			return false;
		}

}

public bool IsInPartyWithLocalPlayer
{
get 		{
			return false;
		}

}

public bool IsJoinableFromChatPartyInvite
{
get 		{
			return false;
		}

}

public bool CanDeleteAccount
{
get 		{
			return false;
		}

}

public string VersionStatus
{
get 		{
			return null;
		}

}

public IGBPGJHGFFP Reputation
{
get 		{
			return null;
		}

set {
		}
}

public int? SubscriberCount
{
get 		{
			return null;
		}

set {
		}
}

public KPPGJKNBIJK Progression
{
get 		{
			return null;
		}

set {
		}
}

public bool? HasUnreadCreatorAnnouncements
{
get 		{
			return null;
		}

set {
		}
}

public IReadOnlyList<JCDPHCELKHI> OwnedRooms
{
get 		{
			return null;
		}

set {
		}
}

public JCDPHCELKHI MostRecentPublicOwnedRoom
{
get 		{
			return null;
		}

}

public IReadOnlyList<OEBAEGDPBLA> OwnedInventions
{
get 		{
			return null;
		}

set {
		}
}

public OEBAEGDPBLA MostRecentPublicOwnedInvention
{
get 		{
			return null;
		}

}

public IReadOnlyList<GDHOAGNFOBD.FPPNEFOBPMC> OwnedPhotos
{
get 		{
			return null;
		}

set {
		}
}

public IReadOnlyList<LINLOKECLME> OwnedCustomAvatarItems
{
get 		{
			return null;
		}

set {
		}
}

public IReadOnlyList<LINLOKECLME> CreatedCustomAvatarItems
{
get 		{
			return null;
		}

set {
		}
}

public LINLOKECLME MostRecentPublicCustomAvatarItem
{
get 		{
			return null;
		}

}

public IReadOnlyList<PlatformNotificationCategoryConfigDTO> MobileNotificationCategories
{
get 		{
			return null;
		}

set {
		}
}

public PlatformNotificationPreferencesDTO MobileNotificationSettings
{
get 		{
			return null;
		}

set {
		}
}

public NIOMAOPFJBI PersonalPronounsBackingField
{
get 		{
			return NIOMAOPFJBI.None;
		}

private set {
		}
}

public bool HasPronounChanges
{
get 		{
			return false;
		}

private set {
		}
}

public string PronounText
{
get 		{
			return null;
		}

private set {
		}
}

public GADDFKOBCNK IdentityFlagsBackingField
{
get 		{
			return GADDFKOBCNK.None;
		}

private set {
		}
}

public bool HasIdentityChanges
{
get 		{
			return false;
		}

private set {
		}
}

public string IdentityFlagText
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsLocalSubscribedTo
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsMutedByLocalPlayer
{
get 		{
			return false;
		}

}

public bool IsBlockedByLocalPlayer
{
get 		{
			return false;
		}

}

public bool IsBlockingLocalPlayer
{
get 		{
			return false;
		}

}

public bool IsFavoritedByLocalPlayer
{
get 		{
			return false;
		}

}

public string UsernameBackingField
{
get 		{
			return null;
		}

set {
		}
}

public bool HasUnsavedUsernameChanges
{
get 		{
			return false;
		}

}

public string PendingDisplayName
{
get 		{
			return null;
		}

set {
		}
}

public bool AwaitingDisplayNameChangeResult
{
get 		{
			return false;
		}

private set {
		}
}

public string EmojiBackingField
{
get 		{
			return null;
		}

set {
		}
}

public bool HasUnsavedDisplayNameChanges
{
get 		{
			return false;
		}

}

public bool HasUnsavedEmojiChanges
{
get 		{
			return false;
		}

}

public bool AwaitingBioChangeResult
{
get 		{
			return false;
		}

set {
		}
}

public string PendingBio
{
get 		{
			return null;
		}

set {
		}
}

public bool HasUnsavedBioChanges
{
get 		{
			return false;
		}

}

public bool? IsRecentHistoryVisible
{
get 		{
			return null;
		}

private set {
		}
}

public GOECMMIPHNN ActiveRecentCarousel
{
get 		{
			return GOECMMIPHNN.Rooms;
		}

set {
		}
}

public bool IsInfluencer
{
get 		{
			return false;
		}

private set {
		}
}

public int? SupportedInfluencerId
{
get 		{
			return null;
		}

private set {
		}
}

public int? LocalSupportedInfluencerId
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsSupportedByLocalAccount
{
get 		{
			return false;
		}

}

public bool CanReceiveOfflineInvitePlatformNotifications
{
get 		{
			return false;
		}

private set {
		}
}

public bool RoomBannedByLocalPlayer
{
get 		{
			return false;
		}

set {
		}
}

private CDLILHDKGGD FGFFCFFCEPN
{
get 		{
			return null;
		}

}

public DCFGCHBJPOO CustomAvatarItemManager
{
get 		{
			return null;
		}

}

private IILDCCEMGBA DAFPCOCAEOE
{
get 		{
			return null;
		}

}

private bool IOGLINAOPMI
{
get 		{
			return false;
		}

}

public int AccountId
{
get 		{
			return 0;
		}

}

public string JuniorDisplayNameBackingField
{
get 		{
			return null;
		}

}

public bool HasUnsavedJuniorDisplayNameChanges
{
get 		{
			return false;
		}

}

public virtual bool IncludeBio
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeReputation
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeSubscriberCount
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeUnreadCreatorAnnouncements
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeProgression
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludePortfolio
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeMobileNotifications
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeIsInfluencerInfo
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeSupportedInfluencerInfo
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludePlatformInfo
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludeCanReceiveInvitation
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IncludePrivatizedPlayerPresenceRoomName
{
get 		{
			return false;
		}

set {
		}
}

public string PlatformDisplayName
{
get 		{
			return null;
		}

private set {
		}
}

public string PlatformNetworkName
{
get 		{
			return null;
		}

}

public string PlatformNetworkIdType
{
get 		{
			return null;
		}

}

public bool CanReceiveInvitationFromLocalPlayer
{
get 		{
			return false;
		}

private set {
		}
}

public bool ShouldDisplayPlatformDisplayName
{
get 		{
			return false;
		}

}

public bool ShouldShowPlatformLogoButton
{
get 		{
			return false;
		}

}

public bool ShouldSendFriendOnlineStatusNotification
{
get 		{
			return false;
		}

}

public bool ShouldReceiveFriendOnlineStatusNotification
{
get 		{
			return false;
		}

}

public bool AnyWatchNotificationsActive
{
get 		{
			return false;
		}

}

public string FriendlyPresence
{
get 		{
			return null;
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

		private void OADFECJJNII(IBINLLOMNPN EKOFNPFCLMO)
		{
		}

		private void AMOBMOCPGDM(int EJIHLJJMOBD)
		{
		}

		private void FNFLINCHDCF(int EJIHLJJMOBD)
		{
		}

		private void CDBBOHBGNNP(int? EJIHLJJMOBD)
		{
		}

		private void PKDHAJJPLAI(int EJIHLJJMOBD)
		{
		}

		private void ELLGNDJPFBO(int EJIHLJJMOBD)
		{
		}

		private void KOPEFKGGOKA()
		{
		}

		private void OHLLCDEMGIF(long AFPHABFLEBN, KEJOIDAKHLL DBPOMJOHPIN)
		{
		}

		private void LLJOEMPOOKC(long EPOBIFCHLNM, IReadOnlyList<int> AEBIAAMBKED, GDIFHKCAAED MOMCCIEMHIM)
		{
		}

		private void FPMIIHPOCCM(int? NDFNACMDLBI)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(DAKMOAKIKIC KMDKPCPJKJH)
		{
			return null;
		}

		public void ToggleIsSubscribed(string LDPCFDMCJLH)
		{
		}

		public void ToggleRelationship()
		{
		}

		private void HHLLALFJPCN()
		{
		}

		public void ToggleIsFavorited()
		{
		}

		private global::NCOKFFGPIJM<string> PIAIBEFOECC()
		{
			return null;
		}

		public bool HasEarnedCheer(DINMFHPHBEG.MMCGOCLBAEG JNKJFJLJKNJ)
		{
			return false;
		}

		public bool IsSelectedCheer(DINMFHPHBEG.MMCGOCLBAEG JNKJFJLJKNJ)
		{
			return false;
		}

		public void UpdateSelectedCheer(DINMFHPHBEG.MMCGOCLBAEG JNKJFJLJKNJ)
		{
		}

		public void SendPartyRequest(PNBPIGNHJFA GLLFHCCFIGK)
		{
		}

		public void LeaveParty()
		{
		}

		public bool CanLocalJoinPlayer()
		{
			return false;
		}

		public void TryJoinPlayer()
		{
		}

		public void InvitePlayer()
		{
		}

		public void GoToChatWithPlayer()
		{
		}

		public void ToggleMute()
		{
		}

		public void ToggleBlock()
		{
		}

		public void TryRoomUnbanPlayer()
		{
		}

		public void ShowReportPlayerDialog()
		{
		}

		public void ShowFriendSettingsDialog()
		{
		}

		public void ShowCheerBadgeDialog()
		{
		}

		public void ShowOnlineStatusDialog()
		{
		}

		public void ShowAddEmailDialog()
		{
		}

		public void ShowPronounSelectionDialog()
		{
		}

		private void EPDBLCEFEPN(NIOMAOPFJBI CPEGLOCIJPO, bool IPMIIEAGJKC)
		{
		}

		public string FormatSinglePronoun(NIOMAOPFJBI KIBBCGEJDAF)
		{
			return null;
		}

		public string GetPronounText(NIOMAOPFJBI KIBBCGEJDAF)
		{
			return null;
		}

		public string GetIdentityFlagText(GADDFKOBCNK HPFFIJOINFN)
		{
			return null;
		}

		public string GetCannotGoToOrInviteReason()
		{
			return null;
		}

		public void ShowIdentityFlagSelectionDialog()
		{
		}

		private void PAGPEBPCMPN(GADDFKOBCNK IDODDPPKPFJ, bool IPMIIEAGJKC)
		{
		}

		public void ShowChangePasswordDialog()
		{
		}

		public void ShowSupporterDialog()
		{
		}

		private void CCPLKNHEKKG(bool CKMMIJMLPBD)
		{
		}

		public void UnsupportInfluencer()
		{
		}

		private void CGICFBBMPFA(AOKABNFFNHH BKDCPFHKDLB)
		{
		}

		public void ShowDisplayNameAdjectiveMenu()
		{
		}

		public void ShowDisplayNameNounMenu()
		{
		}

		public void ShowFullBioDialog()
		{
		}

		public void TryChangePortfolioBannerImage()
		{
		}

		private global::NCOKFFGPIJM<long> MGKPOJOPPOD()
		{
			return null;
		}

		private void CJPMGHCFKPH(long NGGLNJGEEPA)
		{
		}

		public virtual AEBHFHIINHM GetCardDataForAccount()
		{
			return null;
		}

		public void TryChangeUsername()
		{
		}

		public static char OnNameInputValidate(string HLIGBKANEEA, int MLPMIFMIOKK, char EAAIEEDJAHD)
		{
			return '\0';
		}

		public void TryChangeDisplayName()
		{
		}

		public void TryChangeEmoji()
		{
		}

		public void TryChangeJuniorDisplayName()
		{
		}

		public void GetJuniorDisplayNameOptions()
		{
		}

		public void TryChangeBio()
		{
		}

		public void ShowDeleteAccountConfirmationDialog()
		{
		}

		public void ToggleSendFriendOnlineStatusNotification(bool IPMIIEAGJKC)
		{
		}

		public void ToggleReceiveFriendOnlineStatusNotification(bool IPMIIEAGJKC)
		{
		}

		public void ShowChangeOnlineStatusVisibilityDialog(GameObject MPNJFGHHINN)
		{
		}

		public string FormatOnlineStatusVisibility(JFAAGFOLICM HMIGNDLGKNL)
		{
			return null;
		}

		public void SetNotificationOption(BJCIKFCDBFN.JGBHDFADCMI CIFHMNKCLNG, bool IPMIIEAGJKC)
		{
		}

		public void ToggleMobileNotification(FFAEIJPHMAG JNKJFJLJKNJ)
		{
		}

		public void UpdateMobileNotificationSettings()
		{
		}

		public bool IsWatchNotificationCategoryActive(BJCIKFCDBFN.JGBHDFADCMI OFOMIMPGNJN)
		{
			return false;
		}

		public void ToggleRecentHistoryVisibility()
		{
		}

		public void UpdateRecentHistoryVisibility()
		{
		}

		public bool TryParseJuniorDisplayName()
		{
			return false;
		}

		public global::NCOKFFGPIJM<string> GetPlatformName()
		{
			return null;
		}

		public void OpenPlatformAccountUI()
		{
		}

		public bool IsInMyLeague()
		{
			return false;
		}

		public Sprite GetLeagueIcon()
		{
			return null;
		}

		public Texture GetLeagueBackgroundTexture()
		{
			return null;
		}

		public void TryShowLeagueInfoDialog()
		{
		}

		[CompilerGenerated]
		private void AEJNIOHJLJI(bool MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void PDFIIKCDGHM(bool HCCPLOHLPCJ)
		{
		}

		[CompilerGenerated]
		private void HKKIDIJNHBJ(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		[CompilerGenerated]
		private void CEILAEECIPM(KPHMJELKCOA EFNJCAIBDLA)
		{
		}

		[CompilerGenerated]
		private void IKHGIHMPKMO(MKKJLGPDDKJ.HDFOAMJMPJD DMMDPMFCBHN)
		{
		}

		[CompilerGenerated]
		private void DAEGMFFAABJ(IGBPGJHGFFP GOJCEBCMFJK)
		{
		}

		[CompilerGenerated]
		private void GNJMFGEOHCP(int IBALDFBGBGL)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN DHNLNBJCIBN(long? AFPHABFLEBN)
		{
			return null;
		}

		[CompilerGenerated]
		private void LILCPJIOLLG(KPPGJKNBIJK COLMAMKJPJE)
		{
		}

		[CompilerGenerated]
		private void DCANNDAJNOD(List<JCDPHCELKHI> CECGEDKICOA)
		{
		}

		[CompilerGenerated]
		private List<OEBAEGDPBLA> AMHDKAKGBFF(List<OEBAEGDPBLA> AMIAEMLONAO)
		{
			return null;
		}

		[CompilerGenerated]
		private bool KOMNHHFJNPM(OEBAEGDPBLA FCCGDNMAHPA)
		{
			return false;
		}

		[CompilerGenerated]
		private void MJLIJFAFBPA(List<OEBAEGDPBLA> AMIAEMLONAO)
		{
		}

		[CompilerGenerated]
		private void NECNFCLOCLJ(List<OEBAEGDPBLA> AMIAEMLONAO)
		{
		}

		[CompilerGenerated]
		private void ALCOCKBJBAI(List<LINLOKECLME> JNAAHMPCPAB)
		{
		}

		[CompilerGenerated]
		private void MGCBAOHAPBI(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
		}

		[CompilerGenerated]
		private void LBOCAEJPBNH(IReadOnlyList<LINLOKECLME> NEOKALHDEAH)
		{
		}

		[CompilerGenerated]
		private void NAIEBPJNPCB(IReadOnlyList<LINLOKECLME> NEOKALHDEAH)
		{
		}

		[CompilerGenerated]
		private void LIGFFPNOOEE(List<PlatformNotificationCategoryConfigDTO> HKHKOJGCMIN)
		{
		}

		[CompilerGenerated]
		private void LDKBENMJKLI(PlatformNotificationPreferencesDTO CAOIPCMMNMJ)
		{
		}

		[CompilerGenerated]
		private void FFCCCMIACCG(bool MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void ONIJAPOFALB(int? MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void JDFIANGNFBC(int? MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void BFKMIGOLOHE(string JFDBGAACHBJ)
		{
		}

		[CompilerGenerated]
		private void DPDEJNNCKNF(bool ADBPGEPJOLE)
		{
		}

		[CompilerGenerated]
		private void AGEDGNFKAIC(string OKINGCJNPKJ)
		{
		}

		[CompilerGenerated]
		private void LEFCCPCNBGG()
		{
		}

		[CompilerGenerated]
		private void FHDCAMLLKDO()
		{
		}

		[CompilerGenerated]
		private void ACLKDHKAPKE()
		{
		}

		[CompilerGenerated]
		private void HHHBMFMENKF()
		{
		}

		[CompilerGenerated]
		private void IAPHFEMKIBB()
		{
		}

		[CompilerGenerated]
		private void JCFPOCFMCOF()
		{
		}

		[CompilerGenerated]
		private void MKDLCIKIJFJ()
		{
		}

		[CompilerGenerated]
		private void KIPKFLOKCIH()
		{
		}

		[CompilerGenerated]
		private string GPIMADCMKNI(LCEKCFEIEGJ JDBHABEFGKF)
		{
			return null;
		}

		[CompilerGenerated]
		private bool FAGMBMHELMH(Player COLMAMKJPJE)
		{
			return false;
		}

		[CompilerGenerated]
		private void ENGNAAHLFMB(JCDPHCELKHI NABGBJNBHDH)
		{
		}

		[CompilerGenerated]
		private bool HINKPENIHGG(BJCIKFCDBFN CJHEDPFOCKO)
		{
			return false;
		}

		[CompilerGenerated]
		private void JABEIPJLNCJ(FMEDMCFGHFM EBBNKDFGAKL)
		{
		}

		[CompilerGenerated]
		private void EMFPGHPBMPH(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void CPGNLGBGIBN(BaseDialogModel<AMFPEDOFIGE> DKIIJDODEMG)
		{
		}

		[CompilerGenerated]
		private void FDBJCEBOIMB()
		{
		}

		[CompilerGenerated]
		private void MLEBCOGGJFN(DFDECAEJBIO KAIBCOEOKMI)
		{
		}

		[CompilerGenerated]
		private void OEBFDEEDFJN()
		{
		}

		[CompilerGenerated]
		private void PAFMJELLMKG()
		{
		}

		[CompilerGenerated]
		private void GONDNPNIBII(long NGGLNJGEEPA)
		{
		}

		[CompilerGenerated]
		private void PEPECLNCCOI(GDHOAGNFOBD.FPPNEFOBPMC IECDHEIBMJN)
		{
		}

		[CompilerGenerated]
		private void EBBGMIEPLLF()
		{
		}

		[CompilerGenerated]
		private void EGJIOAMNGKC(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void BEAACFKKFLA()
		{
		}

		[CompilerGenerated]
		private void EIJJIJIMKPL()
		{
		}

		[CompilerGenerated]
		private void BCNMBACDLEF(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void BBMOLGDDOKO()
		{
		}

		[CompilerGenerated]
		private void DNGBALAHAEF(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void AGFLLLBBIJG()
		{
		}

		[CompilerGenerated]
		private void OBMGHKGLNFE()
		{
		}

		[CompilerGenerated]
		private void KDANAJLNGNJ(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void PDMPAGENEFJ()
		{
		}

		[CompilerGenerated]
		private void EHMDKAFMIAL(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void EHBNLIMCMPE()
		{
		}

		[CompilerGenerated]
		private void EHLMIOMIBCM()
		{
		}

		[CompilerGenerated]
		private void NJDONMNHHKC(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void DPFGIDNNCPK()
		{
		}

		[CompilerGenerated]
		private string HONIELPEIAC(string NLJOHEKGNDH)
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<string> KDFGDCJNGHP(string OBOBJIEALAL)
		{
			return null;
		}

		[CompilerGenerated]
		private bool LODMCGDAMNG(AccountsConfig.LeagueOfHeroesConfig EAPCACPHCCO)
		{
			return false;
		}

		[CompilerGenerated]
		private bool NAFPBILGFKE(AccountsConfig.LeagueOfHeroesConfig EAPCACPHCCO)
		{
			return false;
		}

		[CompilerGenerated]
		private bool CDBNPDCJAEP(AccountsConfig.LeagueOfHeroesConfig EAPCACPHCCO)
		{
			return false;
		}
	}
}
