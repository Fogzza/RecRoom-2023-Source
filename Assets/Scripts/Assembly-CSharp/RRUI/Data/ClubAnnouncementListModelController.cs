using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubAnnouncementListModelController : ModelController<ClubAnnouncementListModel>
	{
		[Serializable]
		private class SortByDropdownImpl : DropdownControllerImpl<ClubAnnouncementListModel>
		{
			[NonSerialized]
			private List<ClubAnnouncementsConfig.ClubAnnouncementSortFriendlyNameMapping> sortCriteriaConfig;

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
			private bool CPIGDEKABHN(ClubAnnouncementsConfig.ClubAnnouncementSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class ClubAnnouncementCreateLinkImpl : LinkControllerImpl<ClubAnnouncementListModel>
		{
			private sealed class EGOJGHCAEFN
			{
				public ClubAnnouncementCreateLinkImpl _003C_003E4__this;

				public long? currentClubId;

				internal void _003COnModelChanged_003Eb__0(bool canBeCreated)
				{
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementListFromUriImpl : FromUriControllerImpl<ClubAnnouncementListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfShowingLocalAccountAnnouncementsImpl : HideableControllerImpl<ClubAnnouncementListModel>
		{
			protected long? clubId;

			protected virtual bool FIBCEIBHDOB()
			{
				return false;
			}

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void CPIGDEKABHN(long? IKHNIJKGJFD)
			{
			}
		}

		[Serializable]
		private class HideIfNotShowingLocalAccountAnnouncementsImpl : HideIfShowingLocalAccountAnnouncementsImpl
		{
			protected override bool FIBCEIBHDOB()
			{
				return false;
			}
		}

		[Serializable]
		private class ClubAnnouncementListCardSpawnerImpl : InfiniteListCardSpawnerControllerImpl<ClubAnnouncementListModel, ClubAnnouncementModel, ClubAnnouncementModelController, ClubAnnouncementModel.GFDDIOFHFHI>
		{
			protected override IReadOnlyList<ClubAnnouncementModel.GFDDIOFHFHI> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubAnnouncementModel NBGCMIFAIAF, JLOCLGGLOPP JDMGHBGLHLK)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB, ClubAnnouncementModel NBGCMIFAIAF, JLOCLGGLOPP JDMGHBGLHLK)
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementListItemSpawnerImpl : InfiniteListCardSpawnerControllerImpl<ClubAnnouncementListModel, ClubAnnouncementModel, ClubAnnouncementModelController, ClubAnnouncementModel.GFDDIOFHFHI>
		{
			protected override IReadOnlyList<ClubAnnouncementModel.GFDDIOFHFHI> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubAnnouncementModel NBGCMIFAIAF, JLOCLGGLOPP JDMGHBGLHLK)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB, ClubAnnouncementModel NBGCMIFAIAF, JLOCLGGLOPP JDMGHBGLHLK)
			{
			}
		}

		[Serializable]
		private class ClubAnnouncementListSpawnerImpl : InfiniteScrollListControllerImpl<ClubAnnouncementListModel, ClubAnnouncementModel, ClubAnnouncementModel.GFDDIOFHFHI>
		{
			protected override IReadOnlyList<ClubAnnouncementModel.GFDDIOFHFHI> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB)
			{
			}
		}
	}
}
