using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class ClubModelController : ModelController<ClubModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class CreatorAccountUsernameTextImpl : TextControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DescriptionTextImpl : TextControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubNameCharacterCountTextImpl : CharacterCountControllerImpl<ClubModel>
		{
			protected override string Text => null;
		}

		[Serializable]
		private class DescriptionCharacterCountTextImpl : CharacterCountControllerImpl<ClubModel>
		{
			protected override string Text => null;
		}

		[Serializable]
		private class ClubhouseNameTextImpl : TextControllerImpl<ClubModel>
		{
			[SerializeField]
			private bool showNoClubhousePrompt;

			[SerializeField]
			private string noClubhousePrompt;

			[SerializeField]
			private string clubhouseNamePrefix;

			[SerializeField]
			private string clubhouseNameSuffix;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MemberCountTextImpl : TextControllerImpl<ClubModel>
		{
			[SerializeField]
			private bool useKForThousand;

			[SerializeField]
			private string prefix;

			[SerializeField]
			private string postfix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NameTextImpl : TextControllerImpl<ClubModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string postfix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CreatorClubNameTextImpl : TextControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InviteSentTextImpl : TextControllerImpl<ClubModel>
		{
			[SerializeField]
			private AccountModel AccountModel;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MainImageImpl : RecNetRawImageControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AdditionalImageImpl : RecNetRawImageControllerImpl<ClubModel>
		{
			[SerializeField]
			private int index;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool NOPJPIEKDHD(PHABEMABILA HBEKDJPJIAD)
			{
				return false;
			}
		}

		[Serializable]
		private class DeleteButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BanAccountButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private AccountModel AccountModel;

			public override bool RefreshWhileInactiveOrHidden => false;

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
		}

		[Serializable]
		private class ClearAdditionalImageButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private int imageIndex;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private bool GLDMBJIMPBM(PHABEMABILA NNMPJECKECI)
			{
				return false;
			}
		}

		[Serializable]
		private class ClearMainImageButtonImpl : ButtonControllerImpl<ClubModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CreateCodeButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToClubhouseButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

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
		private class ClearClubhouseButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowClubhouseInfoButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ImageCycleForwardButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ImageCycleBackwardButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private string amplitudeCommandContext;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LeaveButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ModifyMainImageButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ModifyAdditionalImageButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private int index;

			[SerializeField]
			private RecNetRawImage additionalImage;

			[SerializeField]
			private Image addIcon;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private bool GLDMBJIMPBM(PHABEMABILA HBEKDJPJIAD)
			{
				return false;
			}
		}

		[Serializable]
		private class SaveAllModifiedSettingsButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private bool interactableIfDetailsHaveNoChange;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ModifyDetailsButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private bool interactableEvenIfDetailsHaveNoChange;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ModifyMainInfoButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ReportSubmitButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SelectClubhouseButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InviteAllFriendsButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InviteAllNearbyButtonImpl : ButtonControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InviteAccountButtonImpl : ButtonControllerImpl<ClubModel>
		{
			[SerializeField]
			private AccountModel AccountModel;

			public override bool RefreshWhileInactiveOrHidden => false;

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
		}

		[Serializable]
		private class PrimaryTagButtonImpl : ButtonControllerImpl<ClubModel>
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
		private class VisibilityButtonImpl : ButtonControllerImpl<ClubModel>
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
		private class JoinabilityButtonImpl : ButtonControllerImpl<ClubModel>
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
		private class SetHomeClubToggleImpl : ToggleControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AllowJuniorsToggleImpl : ToggleControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class VisiblityToggleImpl : ToggleControllerImpl<ClubModel>
		{
			[SerializeField]
			private HKKNCOIOGPO visibility;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinabilityToggleImpl : ToggleControllerImpl<ClubModel>
		{
			[SerializeField]
			private JFFJOJHMNAM joinability;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ActivateClubChatToggleImpl : ToggleControllerImpl<ClubModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			[SerializeField]
			private string overMemberLimitText;

			[SerializeField]
			private string underMemberLimitText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class NameInputFieldImpl : InputFieldControllerImpl<ClubModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class MinLevelInputFieldImpl : InputFieldControllerImpl<ClubModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class DescriptionInputFieldImpl : InputFieldControllerImpl<ClubModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ConfirmNameForDeletionInputFieldImpl : InputFieldControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ReportDescriptionInputFieldImpl : InputFieldControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class CustomTagsInputFieldImpl : InputFieldControllerImpl<ClubModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class VisibilityDropdownImpl : EnumDropdownControllerImpl<ClubModel, HKKNCOIOGPO>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void CGAOPDAMPMJ(HKKNCOIOGPO IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class PrimaryTagDropdownImpl : DropdownControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class JoinabilityDropdownImpl : EnumDropdownControllerImpl<ClubModel, JFFJOJHMNAM>
		{
			protected override Func<JFFJOJHMNAM, string> customEnumToLabelCallback => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void CGAOPDAMPMJ(JFFJOJHMNAM IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ReportCategoryDropdownImpl : DropdownControllerImpl<ClubModel>
		{
			private static readonly List<(IBPKDJLFBHM.OMLBCKDFMHL, string)> CategoryMappings;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class ClubIdFromClubLinkImpl : LinkControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FinalizeClubCreationLinkImpl : ClubIdFromClubLinkImpl
		{
			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private bool GAPFBOGKOON(RRUI.Navigation.Uri FKFKJOJNCLM)
			{
				return false;
			}
		}

		[Serializable]
		private class ActionLinkImpl : ClubIdFromClubLinkImpl
		{
			[SerializeField]
			private TextMeshProUGUI buttonLabel;

			[SerializeField]
			private Image buttonIcon;

			public void JHDLILNGLBC(string AICBAMHEBBB, Route NBCNOLJOIIM, Sprite MDECPMJIFKB)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CreatorLinkImpl : ClubIdFromClubLinkImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubIdFromClubLinkPublicOrMemberImpl : ClubIdFromClubLinkImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<ClubModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class FromUriForCreationImpl : FromUriImpl
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfNotJoinabilityMatchImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private JFFJOJHMNAM visibleFor;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfVisibilityMatchImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private bool hideIfPrivate;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotMembershipTypeMatchImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private KCAECILAJLI visibleFor;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfMembershipTypeMatchImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private KCAECILAJLI visibleFor;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ActionListHideIfEmptyImpl : HideableControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBannedImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private AccountModel AccountModel;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowIfBannedImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private AccountModel AccountModel;

			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCreatorOrHomeClubImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private bool hideIfIsHomeclub;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotHomeClubImpl : HideableControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideRROIconImpl : HideableControllerImpl<ClubModel>
		{
			[SerializeField]
			private bool hideIfIsHomeclub;

			[SerializeField]
			private bool hideIfIAmCreator;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoUnreadAnnouncementImpl : HideableControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoClubhouseImpl : HideableControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoEditDetailsPermissionImpl : HideableControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEligibleForClubChatImpl : HideableControllerImpl<ClubModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ActionListSpawnerImpl : RecyclingListControllerImpl<ClubModel, ClubModelController>
		{
			[NonSerialized]
			private List<ClubAction> myActions;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class LeaderListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ClubModel, AccountModel, AccountModelController>
		{
			[NonSerialized]
			private List<int> collaboratorAccountIds;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel KCCEEALIFJE, JLOCLGGLOPP JCOELCOJBFM)
			{
			}
		}

		[Serializable]
		private class LeaderListSpawnerImpl : RecyclingListControllerImpl<ClubModel, BaseAccountModel>
		{
			[NonSerialized]
			private List<int> collaboratorAccountIds;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class TagsListSpawnerImpl : RecyclingListControllerImpl<ClubModel, TextMeshProUGUI>
		{
			[NonSerialized]
			private List<string> allTags;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class ClubMembershipTypeToPermissionsSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ClubModel, ClubPermissionsModel, ClubPermissionsModelController>
		{
			private static readonly List<KEJOIDAKHLL> DefaultMembershipTypes;

			[NonSerialized]
			private List<(KEJOIDAKHLL, long)> thisClubMembershipTypesAndId;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubPermissionsModel ABBCDNPBBOD, JLOCLGGLOPP MDEHIFMGBFL)
			{
			}

			[CompilerGenerated]
			private bool GLDMBJIMPBM(KEJOIDAKHLL CJHEDPFOCKO)
			{
				return false;
			}

			[CompilerGenerated]
			private (KEJOIDAKHLL, long) OJPDLKOHMBA(KEJOIDAKHLL IIDIPBJDGKB)
			{
				return default;
			}
		}

		[Serializable]
		private class ToCardImpl : ToCardControllerImpl<ClubModel>
		{
			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class ToClubAnnouncementListImpl : ControllerImplementation<ClubModel>
		{
			[SerializeField]
			private ClubAnnouncementListModel clubAnnouncementListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToClubMembershipListImpl : ControllerImplementation<ClubModel>
		{
			[SerializeField]
			private ClubMembershipListModel ClubMembershipListModel;

			[SerializeField]
			private KEJOIDAKHLL membershipTypeFilter;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClearDeleteDataOnPageChangeImpl : ControllerImplementation<ClubModel>
		{
			[SerializeField]
			private BrowserModel browserModel;

			public override bool SubscribeToDefaultModelEvents => false;

			public override bool RefreshOnShow => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClearReportDataOnPageChangeImpl : ControllerImplementation<ClubModel>
		{
			[SerializeField]
			private BrowserModel browserModel;

			public override bool SubscribeToDefaultModelEvents => false;

			public override bool RefreshOnShow => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
