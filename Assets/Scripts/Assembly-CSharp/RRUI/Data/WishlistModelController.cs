using System;
using UnityEngine;

namespace RRUI.Data
{
	public class WishlistModelController : ModelController<WishlistModel>
	{
		[Serializable]
		private class WishlistNameTextImpl : TextControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class WishlistNoItemsTextImpl : TextControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class StoreLinkImpl : LinkControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class WishlistFromUriImpl : FromUriControllerImpl<WishlistModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideBuyButtonImpl : HideableControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUnloadedImpl : HideableControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLoadedImpl : HideableControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasItemsImpl : HideableControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasNoItemsImpl : HideableControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideWishlistCardImpl : HideableControllerImpl<WishlistModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToStoreItemListImpl : ControllerImplementation<WishlistModel>
		{
			[SerializeField]
			private StoreItemListModel storeItemListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToStoreItemImpl : ControllerImplementation<WishlistModel>
		{
			[SerializeField]
			private StoreItemModel storeItemModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
