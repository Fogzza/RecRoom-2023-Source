using System;
using RRUI.Navigation;
using RRUI.Theme;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class EventListModelController : ModelController<EventListModel>
	{
		[Serializable]
		private class SourceButtonImpl : ButtonControllerImpl<EventListModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private EventListModel.JLBPABBDEGL source;

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
		private class ClearFilterButtonImpl : ButtonControllerImpl<EventListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PinnnedTagToggleImpl : ToggleControllerImpl<EventListModel>
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
		private class IncludeFarFutureEventsToggleImpl : ToggleControllerImpl<EventListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TrendingTagLinkImpl : LinkControllerImpl<EventListModel>
		{
			[SerializeField]
			private TextMeshProUGUI chipText;

			[SerializeField]
			private ToggleTheme toggleTheme;

			private RRUI.Navigation.Uri UriWithData => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class EventSearchLinkImpl : LinkControllerImpl<EventListModel>
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
		private class FromUriImpl : FromUriControllerImpl<EventListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfShouldHideCarousel : HideableControllerImpl<EventListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EventListSpawnerImpl : RecyclingListCardSpawnerControllerImpl<EventListModel, EventModel, EventModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, EventModel HIFPCCLNLGB, JLOCLGGLOPP AJGBPAKJPKH)
			{
			}
		}

		[Serializable]
		private class EventListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<EventListModel, EventModel, EventModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected sealed override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, EventModel HIFPCCLNLGB, JLOCLGGLOPP AJGBPAKJPKH)
			{
			}

			protected virtual void IJDPECHBHII(EventModel HIFPCCLNLGB, JLOCLGGLOPP AJGBPAKJPKH, long JJLIIOCLCNA)
			{
			}
		}

		[Serializable]
		private class TrendingTagSpawnerImpl : PrefabSpawnerControllerImpl<EventListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class PinnedTagSpawnerImpl : PrefabSpawnerControllerImpl<EventListModel>
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
