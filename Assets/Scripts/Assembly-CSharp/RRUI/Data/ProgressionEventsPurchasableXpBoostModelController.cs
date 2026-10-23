using System;
using UnityEngine;

namespace RRUI.Data
{
	public class ProgressionEventsPurchasableXpBoostModelController : ModelController<ProgressionEventsPurchasableXpBoostModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class XpFromPurchasableBoostTextImpl : TextControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class XpMultiplierTextImpl : TextControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchasableBoostPayableCostTextImpl : TextControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PurchasableBoostOriginalCostTextImpl : TextControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TimeLeftTextImpl : CountdownTextImpl
		{
			[SerializeField]
			private string zeroTimerText;

			protected override void DDDHFOKNKKE(float GADDGJANIGG = 0f)
			{
			}
		}

		[Serializable]
		private class BuyXpBoostButtonImpl : ButtonControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PurchasableXpBoostToCardImpl : ToCardControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class HideIfNoPurchasableBoostImpl : HideableControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			private void FLPNBFLCDGM()
			{
			}
		}

		[Serializable]
		private class HideUnlessBoostAvailableImpl : HideableControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			private void FLPNBFLCDGM()
			{
			}
		}

		[Serializable]
		private class HideUnlessBoostCoolingDownImpl : HideableControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			private void FLPNBFLCDGM()
			{
			}
		}

		[Serializable]
		private class HideUnlessWaitingForBoostToArriveImpl : HideableControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			private void FLPNBFLCDGM()
			{
			}
		}

		private abstract class CountdownTextImpl : TextControllerImpl<ProgressionEventsPurchasableXpBoostModel>
		{
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

			protected abstract void DDDHFOKNKKE(float HOHFHDNPBAI = 0f);
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
