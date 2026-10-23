using System;
using RRUI.Navigation;
using RRUI.Theme;
using UnityEngine;

namespace RRUI.Data
{
	public class StoreItemListModelController : ModelController<StoreItemListModel>
	{
		[Serializable]
		private class NameTextImpl : TextControllerImpl<StoreItemListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowSearchPageFilterDialogPopUpButtonImpl : ButtonControllerImpl<StoreItemListModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowStoreTabFilterDialogPopUpButtonImpl : ButtonControllerImpl<StoreItemListModel>
		{
			[SerializeField]
			private Route route;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowSearchPageSortDialogPopUpButtonImpl : ButtonControllerImpl<StoreItemListModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowStoreTabSortDialogPopUpButtonImpl : ButtonControllerImpl<StoreItemListModel>
		{
			[SerializeField]
			private Route route;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SearchStoreItemListLinkImpl : LinkControllerImpl<StoreItemListModel>
		{
			[SerializeField]
			private StoreItemsConfig.KMKGPPLDGEL sortCriteria;

			[SerializeField]
			private StoreItemsConfig.HJJMICEOAOM activeFilters;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchTabLinkImpl : LinkControllerImpl<StoreItemListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GiftStoreTabLinkImpl : LinkControllerImpl<StoreItemListModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromSearchUriImpl : FromUriControllerImpl<StoreItemListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class FromAdCarouselItemUriImpl : FromUriControllerImpl<StoreItemListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class FromGiftingToPlayerIdUriImpl : FromUriControllerImpl<StoreItemListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class StoreItemListSpawnerImpl : RecyclingListControllerImpl<StoreItemListModel, StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int PBPKPPCAJBO)
			{
			}
		}

		[Serializable]
		private class StoreItemListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<StoreItemListModel, StoreItemModel, StoreItemModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, StoreItemModel BALAABJFCAI, JLOCLGGLOPP BKJABHIFFCA)
			{
			}
		}
	}
}
