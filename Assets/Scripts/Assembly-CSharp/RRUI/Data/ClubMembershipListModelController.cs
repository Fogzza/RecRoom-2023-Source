using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubMembershipListModelController : ModelController<ClubMembershipListModel>
	{
		[Serializable]
		private class ClubMembershipListTypeTextImpl : TextControllerImpl<ClubMembershipListModel>
		{
			[SerializeField]
			private string textToAppend;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubMembershipListMembershipTypeFilterDropdownImpl : DropdownControllerImpl<ClubMembershipListModel>
		{
			[NonSerialized]
			private List<ClubsConfig.ClubMembershipTypeFriendlyNameMapping> membershipTypeList;

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
			private bool CPIGDEKABHN(ClubsConfig.ClubMembershipTypeFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class ClubMembershipListSortByDropdownImpl : DropdownControllerImpl<ClubMembershipListModel>
		{
			private List<ClubsConfig.ClubMembershipSortFriendlyNameMapping> sortCriteriaConfig;

			[SerializeField]
			private bool usePortfolioFriendlyNames;

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
			private TMP_Dropdown.OptionData MANNJEDHIEG(ClubsConfig.ClubMembershipSortFriendlyNameMapping IOOFIJENAKG)
			{
				return null;
			}

			[CompilerGenerated]
			private bool GLDMBJIMPBM(ClubsConfig.ClubMembershipSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class ClubIdFromClubMembershipListLinkImpl : LinkControllerImpl<ClubMembershipListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinRequestsLinkImpl : ClubIdFromClubMembershipListLinkImpl
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubMembershipListFromUriImpl : FromUriControllerImpl<ClubMembershipListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class ClubMembershipListCardSpawnerImpl : InfiniteListCardSpawnerControllerImpl<ClubMembershipListModel, ClubMembershipModel, ClubMembershipModelController, LCFAELDOGBB>
		{
			[SerializeField]
			private bool includeUnreadCreatorAnnouncements;

			protected override IReadOnlyList<LCFAELDOGBB> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubMembershipModel ADKLHHPKKBI, JLOCLGGLOPP GKNEJBFHODM)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB, ClubMembershipModel ADKLHHPKKBI, JLOCLGGLOPP GKNEJBFHODM)
			{
			}
		}

		[Serializable]
		private class ClubMembershipListSpawnerImpl : InfiniteScrollListControllerImpl<ClubMembershipListModel, ClubMembershipModel, LCFAELDOGBB>
		{
			[SerializeField]
			private bool includeUnreadCreatorAnnouncements;

			protected override IReadOnlyList<LCFAELDOGBB> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB)
			{
			}
		}
	}
}
