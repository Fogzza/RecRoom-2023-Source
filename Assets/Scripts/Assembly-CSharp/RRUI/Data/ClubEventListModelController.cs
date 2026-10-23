using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class ClubEventListModelController : ModelController<ClubEventListModel>
	{
		[Serializable]
		private class Shim_NavigateToOldWatchCreateEventButtonImpl : ButtonControllerImpl<ClubEventListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(bool FKMFOHHIPFM)
			{
			}
		}

		[Serializable]
		private class EventSearchLinkImpl : LinkControllerImpl<ClubEventListModel>
		{
			[SerializeField]
			private EventListModel.JLBPABBDEGL source;

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
		private class FromUriImpl : FromUriControllerImpl<ClubEventListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class ClubEventListItemSpawnerImpl : InfiniteListCardSpawnerControllerImpl<ClubEventListModel, ClubEventModel, ClubEventModelController, BHDEIJLAHBK>
		{
			protected override IReadOnlyList<BHDEIJLAHBK> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubEventModel LLBAEPMAMLA, JLOCLGGLOPP MIDNMHFGMJP)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB, ClubEventModel LLBAEPMAMLA, JLOCLGGLOPP MIDNMHFGMJP)
			{
			}
		}

		[Serializable]
		private class ClubEventListCardSpawnerImpl : InfiniteListCardSpawnerControllerImpl<ClubEventListModel, ClubEventModel, ClubEventModelController, BHDEIJLAHBK>
		{
			protected override IReadOnlyList<BHDEIJLAHBK> ModelItems => null;

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, ClubEventModel LLBAEPMAMLA, JLOCLGGLOPP MIDNMHFGMJP)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB, ClubEventModel LLBAEPMAMLA, JLOCLGGLOPP MIDNMHFGMJP)
			{
			}
		}

		[Serializable]
		private class ClubEventListSpawnerImpl : InfiniteScrollListControllerImpl<ClubEventListModel, ClubEventModel, BHDEIJLAHBK>
		{
			[NonSerialized]
			private Dictionary<GameObject, ClubEventModel> _instanceToModelMapping;

			protected override IReadOnlyList<BHDEIJLAHBK> ModelItems => null;

			protected override void IHEKMEOIBOI()
			{
			}

			private ClubEventModel BCGKIGAMPKO(GameObject CMDPMJBEBAB)
			{
				return null;
			}

			protected override void ODJCLCCENKA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void JDLOOGGCNKP(GameObject CMDPMJBEBAB)
			{
			}
		}
	}
}
