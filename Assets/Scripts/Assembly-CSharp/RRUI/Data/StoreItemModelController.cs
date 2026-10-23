using System;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class StoreItemModelController : ModelController<StoreItemModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class NameTextImpl : TextControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DescriptionTextImpl : TextControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class StarRarityTextImpl : TextControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PriceTextImpl : TextControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OriginalPriceTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BadgeTextImpl : TextControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BadgeDescriptionTextImpl : TextControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RRPlusDiscountLabelTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SaleDiscountLabelTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CouponDiscountLabelTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RRPlusDiscountRateTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SaleDiscountRateTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CouponDiscountRateTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RRPlusDiscountAmountTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SaleDiscountAmountTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CouponDiscountAmountTextImpl : TextControllerImpl<StoreItemModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OwnedButtonTextImpl : TextControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LimitedTimeCountdownTextImpl : CountdownTextImpl<StoreItemModel>
		{
			protected override void KONHEFEPCLL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class StoreItemImposterRenderImpl : ImposterRawImageControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BadgeIconImpl : ImageControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BadgeColorImageImpl : ImageControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BuyButtonImpl : ButtonControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OwnButtonImpl : ButtonControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryButtonImpl : ButtonControllerImpl<StoreItemModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GiftButtonImpl : ButtonControllerImpl<StoreItemModel>
		{
			[SerializeField]
			private GameObject playerAccountPrefab;

			[SerializeField]
			private Route playerRoute;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			private void OPAEDGAGKII()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			[CompilerGenerated]
			private bool DOACJECODHC(RRUI.Navigation.Uri FKFKJOJNCLM)
			{
				return false;
			}
		}

		[Serializable]
		private class ShareItemLinkButtonImpl : ButtonControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class WishlistToggleImpl : ToggleControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class StoreItemDetailLinkImpl : LinkControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<StoreItemModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideBuyButtonImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfOwnedImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotOwnedImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotLimitedTimeImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLimitedTimeImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfLimitedTimeExpiredImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotLimitedTimeExpiredImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideTryButtonImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideOwnedButtonImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideGiftButtonImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideRRPlusSignButtonImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideSaleBadgeImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideRRPlusDiscountImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideSaleDiscountImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideCouponDiscountImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideOriginalPriceDiscountImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCurrentlyPurchasingGiftImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanBuyAsGiftImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanCantBeSharedImpl : HideableControllerImpl<StoreItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class StoreItemToCardImpl : ToCardControllerImpl<StoreItemModel>
		{
			private sealed class DKKFKKNJBBD
			{
				public StoreItemToCardImpl _003C_003E4__this;

				public OILDLLGEMKP.ELJFLLCIOKO purchaseEntryItemPositionData;

				internal void _003Cget_CardData_003Eb__0()
				{
				}
			}

			protected override AEBHFHIINHM CardData => null;
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
