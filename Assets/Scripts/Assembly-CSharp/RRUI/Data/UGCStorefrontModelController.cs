using System;
using UnityEngine;

namespace RRUI.Data
{
	public class UGCStorefrontModelController : ModelController<UGCStorefrontModel>
	{
		[Serializable]
		private class CarouselNameTextImpl : TextControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NoCarouselsTextImpl : TextControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoCarouselsImpl : HideableControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCarouselsImpl : HideableControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfStorefrontConfiguredImpl : HideableControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfStorefrontNotConfiguredImpl : HideableControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotAbleToConfigureImpl : HideableControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ConfigureStorefrontButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SeeAllPurchasablesButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MoveCarouselUpButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MoveCarouselDownButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RemoveCarouselButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EditCarouselItemsButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RenameCarouselButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AddCarouselButtonImpl : ButtonControllerImpl<UGCStorefrontModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UGCStorefrontFeaturedPurchasablesSpawnableImpl : PrefabCardSpawnerControllerImpl<UGCStorefrontModel, UGCPurchasableItemModel, UGCPurchasableItemModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, UGCPurchasableItemModel PBEBBPFLILL, JLOCLGGLOPP PCHEGLLBMEK)
			{
			}
		}

		[Serializable]
		private class UGCPurchasableCarouselSpawnerImpl : PrefabSpawnerControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class UGCPurchasableCarouselRecyclingListSpawnerImpl : RecyclingListControllerImpl<UGCStorefrontModel, UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class UGCPurchasableEditItemsListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<UGCStorefrontModel, UGCPurchasableEditItemModel, UGCPurchasableEditItemModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, UGCPurchasableEditItemModel PBEBBPFLILL, JLOCLGGLOPP PCHEGLLBMEK)
			{
			}
		}

		[Serializable]
		private class UGCPurchasableAddRoomItemsListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<UGCStorefrontModel, UGCPurchasableEditItemModel, UGCPurchasableEditItemModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, UGCPurchasableEditItemModel PBEBBPFLILL, JLOCLGGLOPP PCHEGLLBMEK)
			{
			}
		}

		[Serializable]
		private class UGCPurchasableItemListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<UGCStorefrontModel, UGCPurchasableItemModel, UGCPurchasableItemModelController>
		{
			[SerializeField]
			private bool resetBrowserHistory;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, UGCPurchasableItemModel PBEBBPFLILL, JLOCLGGLOPP PCHEGLLBMEK)
			{
			}
		}

		[Serializable]
		private class UGCPurchasableRearrangeItemsListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<UGCStorefrontModel, UGCPurchasableRearrangeItemModel, UGCPurchasableRearrangeItemModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, UGCPurchasableRearrangeItemModel PBEBBPFLILL, JLOCLGGLOPP PCHEGLLBMEK)
			{
			}
		}

		[Serializable]
		private class UGCPurchasableCarouselFromStorefront : FromUriControllerImpl<UGCStorefrontModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class UGCPurchasableItemForRoomListSetTypeFilterImpl : ToggleControllerImpl<UGCStorefrontModel>
		{
			[SerializeField]
			private BBEGCPACHAD typeFilter;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NoCarouselsImageImpl : ImageControllerImpl<UGCStorefrontModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
