using System;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubListModelController : ModelController<ClubListModel>
	{
		[Serializable]
		private class ClubListNoResultTextImpl : TextControllerImpl<ClubListModel>
		{
			[SerializeField]
			private string noResultsBaseMessage;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubListClearSearchQueryButtonImpl : ButtonControllerImpl<ClubListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClearFilterButtonImpl : ButtonControllerImpl<ClubListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowSearchSortDialogButtonImpl : ButtonControllerImpl<ClubListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PinnnedTagToggleImpl : ToggleControllerImpl<ClubListModel>
		{
			[SerializeField]
			private TextMeshProUGUI chipText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubListSearchQueryInputFieldImpl : InputFieldControllerImpl<ClubListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ClubSearchLinkImpl : LinkControllerImpl<ClubListModel>
		{
			[SerializeField]
			private ClubListModel.PFLLCNFJLGB source;

			[SerializeField]
			private string primaryTag;

			[SerializeField]
			private string searchQuery;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClubListFromUriImpl : FromUriControllerImpl<ClubListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class ClubListHideIfNotSearchingImpl : HideableControllerImpl<ClubListModel>, global::NOPBJEAADPE<KDOHOBLOICP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubListHideIfSearchingImpl : HideableControllerImpl<ClubListModel>, global::NOPBJEAADPE<KDOHOBLOICP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubListHideIfSearchingAndNotEmptyImpl : HideableControllerImpl<ClubListModel>, global::NOPBJEAADPE<KDOHOBLOICP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingLocalAccountCreatedClubsImpl : HideableControllerImpl<ClubListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingRemoteAccountCreatedClubsImpl : HideableControllerImpl<ClubListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ClubListModel, ClubModel, ClubModelController>
		{
			private sealed class DOCMMLBEMKH
			{
				public ClubListCardSpawnerImpl _003C_003E4__this;

				public ClubModel clubModel;

				public int index;

				internal void _003COnPopulateInstance_003Eb__0()
				{
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubModel IOEDGIHBJMP, JLOCLGGLOPP HICPOMDFJJE)
			{
			}
		}

		[Serializable]
		private class ClubListSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ClubListModel, ClubModel, ClubModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubModel IOEDGIHBJMP, JLOCLGGLOPP HICPOMDFJJE)
			{
			}
		}

		[Serializable]
		private class PrimaryTagSpawnerImpl : PrefabSpawnerControllerImpl<ClubListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
