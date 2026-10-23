using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubBannedAccountListModelController : ModelController<ClubBannedAccountListModel>
	{
		[Serializable]
		private class UnbanAccountButtonImpl : ButtonControllerImpl<ClubBannedAccountListModel>
		{
			[SerializeField]
			private ClubBannedAccountModel ClubBannedAccountModel;

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
		private class SortByDropdownImpl : DropdownControllerImpl<ClubBannedAccountListModel>
		{
			[NonSerialized]
			private List<ClubsConfig.ClubMembershipSortFriendlyNameMapping> sortCriteriaConfig;

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
			private bool CPIGDEKABHN(ClubsConfig.ClubMembershipSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class ClubIdFromClubBannedAccountListLinkImpl : LinkControllerImpl<ClubBannedAccountListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<ClubBannedAccountListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfAccountBannedImpl : HideableControllerImpl<ClubBannedAccountListModel>
		{
			[SerializeField]
			private ClubBannedAccountModel ClubBannedAccountModel;

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
		private class ClubBannedAccountListSpawnerImpl : RecyclingListControllerImpl<ClubBannedAccountListModel, ClubBannedAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject GDEKLMNKJBC, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class ClubBannedAccountListBanAndUnbanListItemSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ClubBannedAccountListModel, ClubBannedAccountModel, AccountModelController>
		{
			private sealed class PGOMJFGMMCN
			{
				public ClubBannedAccountListBanAndUnbanListItemSpawnerImpl _003C_003E4__this;

				public ClubBannedAccountModel clubBannedAccountModel;

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

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubBannedAccountModel NPLJIEOICPC, JLOCLGGLOPP JCOELCOJBFM)
			{
			}
		}
	}
}
