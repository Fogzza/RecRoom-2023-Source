using System;
using System.Collections.Generic;
using RRUI.Dialogs;
using RecNet;

namespace RRUI.Data
{
	public class ProgressionEventsPurchasableXpBoostModel : RRUIModel
	{
		private sealed class BBNBHBFPOMF
		{
			public ProgressionEventsPurchasableXpBoostModel _003C_003E4__this;

			public Guid guid;

			public Predicate<ProgressionEventPurchasableXpBoostDTO> _003C_003E9__1;

			internal void _003CRefreshInternal_003Eb__0(Tuple<List<ProgressionEventPurchasableXpBoostDTO>, int> results)
			{
			}

			internal bool _003CRefreshInternal_003Eb__1(ProgressionEventPurchasableXpBoostDTO boost)
			{
				return false;
			}
		}

		private sealed class BHPLPEILFNK
		{
			public ProgressionEventsPurchasableXpBoostModel _003C_003E4__this;

			public BAOEIDACKHE costInfo;

			public Action<LKKOPNLCJBC.BalanceUpdateResponseDTO<LKKOPNLCJBC.PurchasedProgressionEventXpBoostDTO>> _003C_003E9__3;

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__0(int index, CardModel cardModel, ProgressionEventsPurchasableXpBoostModel xpBoostModel, JLOCLGGLOPP accountToCardController)
			{
			}

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__1()
			{
			}

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__3(LKKOPNLCJBC.BalanceUpdateResponseDTO<LKKOPNLCJBC.PurchasedProgressionEventXpBoostDTO> purchaseResults)
			{
			}

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__2(BaseDialogModel<LJJIHDDNLNB> dialog)
			{
			}
		}

		private BAOEIDACKHE BIGLONMDBCM;

		private ProgressionEventPurchasableXpBoostDTO JIKNOIKOPOI;

		private bool POMINDFAFFL;

		private int? BAHDGEOLBCB;

		private Guid? GNCOFLLECFI;

		private CheckoutDialogModel GEGLGIMBFOH;

		private EAOCHKEGDFJ BBHMAAACAIO;

		private HEIKEFEIKLD LACOFCFHKCA;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public BAOEIDACKHE CostInfo
{
get 		{
			return null;
		}

private set {
		}
}

public ProgressionEventPurchasableXpBoostDTO ProgressionEventPurchasableXpBoost
{
get 		{
			return null;
		}

private set {
		}
}

public bool ClientWaitingForXpBoostToArrive
{
get 		{
			return false;
		}

private set {
		}
}

public bool XpBoostIsWaitingToArrive
{
get 		{
			return false;
		}

}

public bool XpBoostIsCoolingDown
{
get 		{
			return false;
		}

}

public bool XPBoostIsAvailableForPurchase
{
get 		{
			return false;
		}

}

public int? XpEarnedFromBoost
{
get 		{
			return null;
		}

private set {
		}
}

public int XpMultiplierFromBoost
{
get 		{
			return 0;
		}

}

public int XpCapFromBoost
{
get 		{
			return 0;
		}

}

public long XpLookbackDurationTicks
{
get 		{
			return 0L;
		}

}

public long XpCooldownDurationTicks
{
get 		{
			return 0L;
		}

}

private ProgressionEventDTO AFNLJPCJDMP
{
get 		{
			return null;
		}

}

private ProgressionEventRecordDTO OAPHOGKKPHD
{
get 		{
			return null;
		}

}

public Guid? PurchasableXpBoostGuid
{
get 		{
			return null;
		}

private set {
		}
}

		public void Set(Guid? EGAGMOBCFGH)
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		private void HAAKMPNENBG()
		{
		}

		private void MPCOLNGLACE()
		{
		}

		public void BuyPurchasableXpBoost()
		{
		}

		private void OEGMAGOCCDB()
		{
		}

		public string GetDisplayName()
		{
			return null;
		}

		public bool GetXpBoostIsCoolingDown()
		{
			return false;
		}

		public TimeSpan XpBoostCooldownTimeRemaining()
		{
			return default;
		}
	}
}
