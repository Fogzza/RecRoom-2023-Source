using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class SkuModelController : ModelController<SkuModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class SkuNameImpl : TextControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SkuDescriptionImpl : TextControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SkuPriceTextImpl : TextControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchaseBundlePriceTextImpl : TextControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OriginalPurchaseBundlePriceTextImpl : TextControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchaseBundleRRDiscountTextImpl : TextControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RRPlusDiscountLabelTextImpl : TextControllerImpl<SkuModel>
		{
			public override bool RefreshWhileInactiveOrHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RRPMembershipInfoTextImpl : TextControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TimeLeftTextImpl : TextControllerImpl<SkuModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string postfix;

			private IDisposable countdownDisposable;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void ALHNNKKLGHC(float GADDGJANIGG = 0f)
			{
			}
		}

		[Serializable]
		private class TryOrRevertTextImpl : TextControllerImpl<SkuModel>
		{
			public enum IMMBBBKMIIN
			{
				Try = 0,
				Revert = 1
			}

			private readonly Lazy<CFHGAIBGHDH> bundleTrialTracker;

			private CFHGAIBGHDH BundleTrialTracker => null;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MainImageImpl : RecNetRawImageControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SeasonsImageImpl : RecNetRawImageControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BuyRRPlusMembershipButtonImpl : ButtonControllerImpl<SkuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BuySkuButtonImpl : ButtonControllerImpl<SkuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BuyPurchaseReminderButtonImpl : ButtonControllerImpl<SkuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowSearchPageFilterDialogPopUpButtonImpl : ButtonControllerImpl<SkuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ShowAlreadyOwnedPlayerOwnableBundleItemsButtonImpl : ButtonControllerImpl<SkuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PreviewBundleItemsButtonImpl : ButtonControllerImpl<SkuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RevertBundleItemsPreviewButtonImpl : ButtonControllerImpl<SkuModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LimitedTimeOfferBadgeColorImageImpl : ImageControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FromUriSkuDetailsImpl : FromUriControllerImpl<SkuModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfActiveSubscriptionTimeRemainingIsOverThreshold : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideRRPTokenValueBannerImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideBuyMembershipButtonSectionImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideBuyMembershipButtonImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideManageMembershipButtonImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideOpenRecNetWebsiteButtonImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideMembershipInfoTextImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HidePurchaseReminderTimeLeftImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoTokenPriceImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasTokenPriceImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfTokenPriceIsOriginalImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoPreviewableBundleItemsImpl : HideableControllerImpl<SkuModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfAllPlayerOwnableBundleItemsOwnedImpl : HideableControllerImpl<SkuModel>
		{
			private readonly Lazy<bool> canShowPartiallyOwnedBundles;

			private POPLPJGHHIA.OCDCJKGHBON lastKnownFullSku;

			private bool isPartiallyOwned;

			private bool CanShowPartiallyOwnedBundles => false;

			private bool PartiallyOwnedElementHidden => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SkuToCardImpl : ToCardControllerImpl<SkuModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
