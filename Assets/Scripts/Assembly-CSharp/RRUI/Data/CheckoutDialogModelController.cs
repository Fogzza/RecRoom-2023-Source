using System;
using UnityEngine;

namespace RRUI.Data
{
	public class CheckoutDialogModelController : ModelController<CheckoutDialogModel>
	{
		[Serializable]
		private class PurchaseItemCountTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchaseTotalCostTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchaseTotalOriginalCostTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchaseRoomCurrencyNameTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TitleTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class WarningMessageTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SecondaryWarningMessageTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SecondaryWarningDetailBubbleTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchaseButtonLabelTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ItemNameTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OriginalPurchaseBundlePriceTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RRPlusDiscountLabelTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RRPlusDiscountTextImpl : TextControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ConfirmPurchaseButtonImpl : ButtonControllerImpl<CheckoutDialogModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class WarningMessageDetailButtonImpl : ButtonControllerImpl<CheckoutDialogModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TokenStoreLinkImpl : LinkControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RRPSignUpPageLinkImpl : LinkControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CurrencyStoreLinkImpl : LinkControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideDiscountListImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideWarningBannerImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideSecondaryWarningBannerImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideWarningBannerDetailImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFooterElementsImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasFooterElementsImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfMissingRRPlusMembershipRequiredImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPriceUnitRoomCurrencyImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPriceUnitRecTokenImpl : HideableControllerImpl<CheckoutDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CheckoutItemSpawnerImpl : RecyclingListControllerImpl<CheckoutDialogModel, CardModel>
		{
			[NonSerialized]
			private uint lastRefreshVersion;

			protected override GameObject DefaultPrefabToSpawn => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class DiscountItemSpawnerImpl : RecyclingListControllerImpl<CheckoutDialogModel, CardModel>
		{
			[NonSerialized]
			private uint lastRefreshVersion;

			protected override GameObject DefaultPrefabToSpawn => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}
	}
}
