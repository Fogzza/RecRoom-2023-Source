using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Models.Statsig;
using RRUI.Navigation;
using RRUI.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class AccountListModelController : ModelController<AccountListModel>
	{
		[Serializable]
		private class SourceLabelImpl : TextControllerImpl<AccountListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NoResultsTextImpl : TextControllerImpl<AccountListModel>
		{
			[SerializeField]
			private string noResultsBaseMessage;

			[SerializeField]
			private LocalizedString noResultsBaseMessageLocalized;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SourceButtonImpl : ButtonControllerImpl<AccountListModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private CJIHECEJAHH source;

			[SerializeField]
			private string searchQuery;

			[SerializeField]
			private bool requireMatchSearchQuery;

			[SerializeField]
			private CustomAccountListSource customSource;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private bool CONCMILKFON()
			{
				return false;
			}
		}

		[Serializable]
		private class ClearSearchQueryImpl : ButtonControllerImpl<AccountListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowAccountListDialog : ButtonControllerImpl<AccountListModel>
		{
			[SerializeField]
			private string dialogTitle;

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
		private class ShowAccountListSortDialog : ButtonControllerImpl<AccountListModel>
		{
			[Serializable]
			private class SortOption
			{
				public AccountsConfig.CGEPIENCFOK sortCriteria;

				public string friendlyName;
			}

			[SerializeField]
			private SortOption[] sortOptions;

			[SerializeField]
			private GameObject radioButtonPrefab;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RefreshAccountList : ButtonControllerImpl<AccountListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AddAllAccountsToPartyInviteModelImpl : ButtonControllerImpl<AccountListModel>
		{
			[SerializeField]
			private PartyInviteModel partyInviteModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchQueryInputFieldImpl : InputFieldControllerImpl<AccountListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class FilterInputFieldImpl : InputFieldControllerImpl<AccountListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ClubBanDropdownImpl : DropdownControllerImpl<AccountListModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private bool NOPJPIEKDHD(ClubsConfig.AccountListSourceTypeFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class ClubInviteDropdownImpl : DropdownControllerImpl<AccountListModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private bool NOPJPIEKDHD(ClubsConfig.AccountListSourceTypeFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class SortBySubscriptionsDropdownImpl : DropdownControllerImpl<AccountListModel>
		{
			[SerializeField]
			private AccountsConfig.CGEPIENCFOK defaultSortCriteria;

			private List<AccountsConfig.AccountSortFriendlyNameMapping> sortCriteriaConfig;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private bool LMOGBDDHNKA(AccountsConfig.AccountSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}

			[CompilerGenerated]
			private bool GLDMBJIMPBM(AccountsConfig.AccountSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		public class FriendsPageSourceLinkImpl : LinkControllerImpl<AccountListModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

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
		private class FromUriImpl : FromUriControllerImpl<AccountListModel>
		{
			[SerializeField]
			private bool clearOnPopulate;

			protected override void AGLPOPGOHMJ()
			{
			}

			protected virtual bool OMDFKLAEDNO(RRUI.Navigation.Uri FKFKJOJNCLM, out bool CCDPDDAMHOJ)
			{
				CCDPDDAMHOJ = default;
				return false;
			}
		}

		[Serializable]
		private class FriendsPageFromUriImpl : FromUriImpl
		{
			protected override bool OMDFKLAEDNO(RRUI.Navigation.Uri FKFKJOJNCLM, out bool CCDPDDAMHOJ)
			{
				CCDPDDAMHOJ = default;
				return false;
			}
		}

		[Serializable]
		public abstract class SourceMatchImpl : HideableControllerImpl<AccountListModel>
		{
			[SerializeField]
			private CJIHECEJAHH source;

			[SerializeField]
			private string searchQuery;

			[SerializeField]
			private bool requireMatchSearchQuery;

			protected bool isMatch => false;

			private bool CONCMILKFON()
			{
				return false;
			}
		}

		[Serializable]
		private class HideIfNotSourceMatchImpl : SourceMatchImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfSourceMatchImpl : SourceMatchImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountListSpawnerImpl : RecyclingListControllerImpl<AccountListModel, AccountModel>
		{
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
			private bool includePrivatizedPlayerPresenceRoomName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class AccountListSpawnerDifferentCardsForSelectSources : AccountListSpawnerImpl
		{
			[SerializeField]
			private GameObject prefabToUseForSource;

			[SerializeField]
			private CJIHECEJAHH[] sources;

			protected override GameObject DefaultPrefabToSpawn => null;
		}

		[Serializable]
		private class AccountListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<AccountListModel, AccountModel, AccountModelController>
		{
			private sealed class LEMGNCIOEAC
			{
				public AccountModel accountModel;

				internal string _003COnPopulateInstance_003Eb__0()
				{
					return null;
				}
			}

			[SerializeField]
			private bool includePrivatizedPlayerPresenceRoomName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel KCCEEALIFJE, JLOCLGGLOPP JCOELCOJBFM)
			{
			}

			protected virtual void PDNLEHEBEJE(AccountModel KCCEEALIFJE, int EJIHLJJMOBD)
			{
			}
		}

		[Serializable]
		private class AccountListClubBanAndUnbanListItemSpawnerImpl : AccountListCardSpawnerImpl
		{
			private sealed class OJKILEKBDMD
			{
				public AccountListClubBanAndUnbanListItemSpawnerImpl _003C_003E4__this;

				public AccountModel accountModel;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}

				internal string _003COnPopulateInstance_003Eb__1()
				{
					return null;
				}

				internal void _003COnPopulateInstance_003Eb__2()
				{
				}
			}

			private ClubModel clubModel;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel KCCEEALIFJE, JLOCLGGLOPP JCOELCOJBFM)
			{
			}
		}

		[Serializable]
		private class AccountListSendClubInviteListItemSpawnerImpl : AccountListCardSpawnerImpl
		{
			private sealed class JBDFLLNLBKO
			{
				public AccountListSendClubInviteListItemSpawnerImpl _003C_003E4__this;

				public AccountModel accountModel;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}

				internal string _003COnPopulateInstance_003Eb__1()
				{
					return null;
				}

				internal void _003COnPopulateInstance_003Eb__2()
				{
				}
			}

			private ClubModel clubModel;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN(NJIIBNCBBMK LFKKJIFPEMA)
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel KCCEEALIFJE, JLOCLGGLOPP JCOELCOJBFM)
			{
			}
		}

		[Serializable]
		private class SubscriptionAccountListCardSpawnerImpl : AccountListCardSpawnerImpl
		{
			private sealed class ALPOIIICOCO
			{
				public AccountModel accountModel;

				internal string _003COnPopulateInstance_003Eb__0()
				{
					return null;
				}
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel KCCEEALIFJE, JLOCLGGLOPP JCOELCOJBFM)
			{
			}

			protected override void PDNLEHEBEJE(AccountModel KCCEEALIFJE, int EJIHLJJMOBD)
			{
			}
		}

		[Serializable]
		private class AccountListSingleCardSpawnerImpl : AccountListCardSpawnerImpl
		{
			private sealed class HGDLMBBDBID
			{
				public AccountListSingleCardSpawnerImpl _003C_003E4__this;

				public int index;

				public AccountModel fromModel;

				internal bool _003COnPopulateInstance_003Eb__0()
				{
					return false;
				}

				internal void _003COnPopulateInstance_003Eb__1()
				{
				}
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class TextTruncatedAccountModelListImpl : ControllerImplementation<AccountListModel>
		{
			[SerializeField]
			private AccountModel[] accountModels;

			[SerializeField]
			private TextMeshProUGUI text;

			[SerializeField]
			private string textWhenNoAccounts;

			[SerializeField]
			private string textWhenSingleAccount;

			[SerializeField]
			private string textWhenMultipleAccountsButNoneTruncated;

			[SerializeField]
			private string prefixWhenAccountsTruncated;

			[SerializeField]
			private string suffixWhenAccountsTruncated;

			[SerializeField]
			private string suffixWhenSingleAccountTruncated;

			[SerializeField]
			private LocalizedString textWhenNoAccountsLoc;

			[SerializeField]
			private LocalizedString textWhenSingleAccountsLoc;

			[SerializeField]
			private LocalizedString textWhenMultipleAccountsButNoneTruncatedLoc;

			[SerializeField]
			private LocalizedString prefixWhenAccountsTruncatedLoc;

			[SerializeField]
			private LocalizedString suffixWhenAccountsTruncatedLoc;

			[SerializeField]
			private LocalizedString suffixWhenSingleAccountTruncatedLoc;

			[SerializeField]
			private LocalizedString multipleTruncatedAccountsLocSmart;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SetDefaultSourceIfStatsigExperimentParamTrueImpl : ControllerImplementation<AccountListModel>
		{
			[SerializeField]
			private string experimentName;

			[SerializeField]
			private string parameterName;

			[SerializeField]
			private CJIHECEJAHH source;

			[SerializeField]
			private StatsigModel statsigModel;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
