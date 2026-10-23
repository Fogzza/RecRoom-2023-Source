using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubMembershipRequestListModelController : ModelController<ClubMembershipRequestListModel>
	{
		[Serializable]
		private class AcceptButtonImpl : ButtonControllerImpl<ClubMembershipRequestListModel>
		{
			[SerializeField]
			private ClubMembershipRequestModel clubMembershipRequestModel;

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
		private class DenyButtonImpl : ButtonControllerImpl<ClubMembershipRequestListModel>
		{
			[SerializeField]
			private ClubMembershipRequestModel clubMembershipRequestModel;

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
		private class AcceptAllButtonImpl : ButtonControllerImpl<ClubMembershipRequestListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DenyAllButtonImpl : ButtonControllerImpl<ClubMembershipRequestListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SortByDropdownImpl : DropdownControllerImpl<ClubMembershipRequestListModel>
		{
			[NonSerialized]
			private List<ClubsConfig.PendingRequestSortFriendlyNameMapping> sortCriteriaConfig;

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
			private bool CPIGDEKABHN(ClubsConfig.PendingRequestSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<ClubMembershipRequestListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class ClubMembershipRequestListItemSpawnerImpl : InfiniteListCardSpawnerControllerImpl<ClubMembershipRequestListModel, ClubMembershipRequestModel, ClubMembershipRequestModelController, ELGOLFHDGDP>
		{
			private sealed class HDDIFJBMFNJ
			{
				public ClubMembershipRequestListItemSpawnerImpl _003C_003E4__this;

				public ClubMembershipRequestModel clubMembershipRequestModel;

				internal void _003COnPopulateInMemoryInstance_003Eb__1()
				{
				}

				internal void _003COnPopulateInMemoryInstance_003Eb__3()
				{
				}
			}

			protected override IReadOnlyList<ELGOLFHDGDP> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubMembershipRequestModel EPADIIBIBKC, JLOCLGGLOPP ONIEALEPGCP)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB, ClubMembershipRequestModel EPADIIBIBKC, JLOCLGGLOPP ONIEALEPGCP)
			{
			}
		}

		[Serializable]
		private class ClubMembershipRequestListSpawnerImpl : InfiniteScrollListControllerImpl<ClubMembershipRequestListModel, ClubMembershipRequestModel, ELGOLFHDGDP>
		{
			protected override IReadOnlyList<ELGOLFHDGDP> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB)
			{
			}
		}
	}
}
