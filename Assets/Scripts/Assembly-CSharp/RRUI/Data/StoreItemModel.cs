using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class StoreItemModel : RRUIModel
	{
		private sealed class OONFAIDAMLP
		{
			public int index;

			public StoreItemModel _003C_003E4__this;

			internal string _003CTryShowChoosePlayerToGiftDialogPopUp_003Eb__6()
			{
				return null;
			}

			internal string _003CTryShowChoosePlayerToGiftDialogPopUp_003Eb__7()
			{
				return null;
			}
		}

		private sealed class JJJOOPJEOPE
		{
			public StoreItemModel _003C_003E4__this;

			public bool isJunior;

			internal string _003CTryShowWriteGiftMessageDialogPopUp_003Eb__1()
			{
				return null;
			}

			internal void _003CTryShowWriteGiftMessageDialogPopUp_003Eb__2(string input)
			{
			}

			internal bool _003CTryShowWriteGiftMessageDialogPopUp_003Eb__3()
			{
				return false;
			}

			internal void _003CTryShowWriteGiftMessageDialogPopUp_003Eb__4()
			{
			}

			internal void _003CTryShowWriteGiftMessageDialogPopUp_003Eb__0(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class IOLCLHPFEFG
		{
			public LoadingDialogModel cachedLoadingDialog;

			public StoreItemModel _003C_003E4__this;

			internal void _003CConfirmSendGift_003Eb__0(LoadingDialogModel dialog)
			{
			}

			internal void _003CConfirmSendGift_003Eb__1(LKKOPNLCJBC.PurchaseBalanceUpdateResponseDTO<EDDPDJCKOBH.GMBCAMAAPMN> response)
			{
			}

			internal void _003CConfirmSendGift_003Eb__2(string error)
			{
			}
		}

		private sealed class FOHJJGKFHON
		{
			public MessageDialogModel messageDialog;

			internal void _003CHandleSendGiftSuccess_003Eb__1()
			{
			}

			internal void _003CHandleSendGiftSuccess_003Eb__0(MessageDialogModel dialog)
			{
			}
		}

		private sealed class ADBLFBGPNKO
		{
			public MessageDialogModel messageDialog;

			public StoreItemModel _003C_003E4__this;

			internal void _003CHandleSendGiftAlreadyOwned_003Eb__1()
			{
			}

			internal void _003CHandleSendGiftAlreadyOwned_003Eb__0(MessageDialogModel dialog)
			{
			}
		}

		private sealed class CKAGDKIOINF
		{
			public List<EOKBGGOAFLF> purchasableGiftDrops;

			public StoreItemModel _003C_003E4__this;

			public HCLDBKDHKLE costInfo;

			public LJJIHDDNLNB checkoutDialogData;

			public Action<HMFCKFAKBID.LKOMOOHBHBJ> _003C_003E9__4;

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__0(int index, CardModel cardModel, StoreItemModel storeItemModel, JLOCLGGLOPP accountToCardController)
			{
			}

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__1()
			{
			}

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__4(HMFCKFAKBID.LKOMOOHBHBJ purchaseResults)
			{
			}

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__2()
			{
			}

			internal void _003CTryShowPurchaseConfirmationDialogPopUp_003Eb__3(BaseDialogModel<LJJIHDDNLNB> dialog)
			{
			}
		}

		private sealed class KIFAHKHIOLP
		{
			public bool isAddingToWishlist;

			public StoreItemModel _003C_003E4__this;

			internal void _003CToggleIsWishlisted_003Eb__0()
			{
			}

			internal void _003CToggleIsWishlisted_003Eb__1(string error)
			{
			}

			internal void _003CToggleIsWishlisted_003Eb__2()
			{
			}
		}

		private int LIAHDGBIEPB;

		private int DDHPDLENNIC;

		private string EDBHPCACIAH;

		private List<DFDECAEJBIO> AMEHANJFDBF;

		private PickerDialogModel BPNMBEEJPDC;

		private KCOKPCOFDIM LHFDPPANKNJ;

		private DynamicUIDialogModel BPAMJGAFMBJ;

		private DHAPPKCJJCA NNOKMCJAPJE;

		private EHEJPNFKNAL BJKKJCBLHEC;

		private EHEJPNFKNAL BCBNJBGJLOM;

		private string FBMCPFCLALE;

		private GameObject MAABHFEJGFG;

		private Dictionary<long, (bool, bool, bool)> HGEIMPIACBP;

		private const string HGNBELHDCDL = "Failed to Send Gift";

		private const string NMGGOFLJNAB = "Sorry, there was an error while processing your purchase. Please contact us at recroom.zendesk.com if this persists.";

		private const string HLJGOMKNKBB = "Write your message to {0}";

		private const string JLJMGMMNHHG = "Send this gift to {0}?";

		public EEANDDJEMJC OnNavigateBackToProfilePageWhenGifting;

		private const int IBIADOKBLEI = 150;

		[SerializeField]
		private Route shareLinkRoute;

		[SerializeField]
		private string sharingMessage;

		[SerializeField]
		private string sharingWindowTitle;

		[SerializeField]
		private string sharingWindowDescription;

		private EOKBGGOAFLF AIBBKGGHCIJ;

		private KJPMDALEEKI BIGLONMDBCM;

		private FHPHMBKPLCC PLCIFNOBJLO;

		private string CIBAHFMFJDH;

		private CheckoutDialogModel GEGLGIMBFOH;

		private MessageDialogModel HIBHINOKJLL;

		private List<DGMPBIPKJEB> COMFFGHCJAE;

		private bool HNKHHNBCFCB;

		private bool CFCABBLKMFH;

		private bool GLOIGLHNCGM;

		public int WishlistAccountId;

		private Action PCJOPKJNFIM;

		private OILDLLGEMKP.ELJFLLCIOKO EAHHOONPAAI;

public int CurrentlyPurchasingGiftForPlayerId
{
get 		{
			return 0;
		}

private set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public DBFJJLIGAFA GiftDrop
{
get 		{
			return null;
		}

}

public EOKBGGOAFLF PurchasableGiftDrop
{
get 		{
			return null;
		}

private set {
		}
}

public KJPMDALEEKI CostInfo
{
get 		{
			return null;
		}

private set {
		}
}

public FHPHMBKPLCC StorefrontEntryPoint
{
get 		{
			return FHPHMBKPLCC.None;
		}

}

public bool IsBuyButtonInteractable
{
get 		{
			return false;
		}

}

public bool IsOwnedButtonVisible
{
get 		{
			return false;
		}

}

public bool IsOwnedTextVisible
{
get 		{
			return false;
		}

}

public bool CanBeShared
{
get 		{
			return false;
		}

}

public bool IsTryButtonInteractable
{
get 		{
			return false;
		}

}

public bool IsGiftingPossible
{
get 		{
			return false;
		}

}

public bool IsWishlistButtonVisible
{
get 		{
			return false;
		}

}

public bool IsCurrentlyGifting
{
get 		{
			return false;
		}

}

public string StarRarity
{
get 		{
			return null;
		}

private set {
		}
}

public bool HasRRPlusDiscount
{
get 		{
			return false;
		}

}

public string RRPlusDiscountRate
{
get 		{
			return null;
		}

}

public string RRPlusDiscountAmount
{
get 		{
			return null;
		}

}

public bool HasSaleDiscount
{
get 		{
			return false;
		}

}

public string SaleDiscountRate
{
get 		{
			return null;
		}

}

public string SaleDiscountAmount
{
get 		{
			return null;
		}

}

public TimeSpan LimitedTimeRemaining
{
get 		{
			return default;
		}

}

public bool LimitedTimeExpired
{
get 		{
			return false;
		}

}

public bool HasCouponDiscount
{
get 		{
			return false;
		}

}

public string CouponDiscountRate
{
get 		{
			return null;
		}

}

public string CouponDiscountAmount
{
get 		{
			return null;
		}

}

public bool ItemIsInWishlist
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsOtherPlayersWishlist
{
get 		{
			return false;
		}

}

public Action ToCardFreeGiftButtonPrimaryClickEvent
{
get 		{
			return null;
		}

private set {
		}
}

public OILDLLGEMKP.ELJFLLCIOKO StoreItemPositionData
{
get 		{
			return null;
		}

private set {
		}
}

		public void GiveAsGift(GameObject ABFDFCLEDNL)
		{
		}

		private void OCGFACLKECK(GameObject ABFDFCLEDNL)
		{
		}

		private void IHIGCFIHOEN()
		{
		}

		private void ADKDNLIFKDO()
		{
		}

		private void POKCAIMNMII()
		{
		}

		private void ILAMCGEMFBG()
		{
		}

		private void JADBOMFPEOL()
		{
		}

		private bool HIKOPGMJGCO(int GMEHLIHLGEH)
		{
			return false;
		}

		private bool KKAJMENIHLD(int GMEHLIHLGEH)
		{
			return false;
		}

		private bool FKGJNICELHM(int GMEHLIHLGEH)
		{
			return false;
		}

		private bool OGJKAABBGIP(string PIELIOOGIGG, int GMEHLIHLGEH)
		{
			return false;
		}

		private void NMMKFJLFJEL(int GMEHLIHLGEH)
		{
		}

		private string CBDKGOBOMGD()
		{
			return null;
		}

		private void EEEALDCMHLM()
		{
		}

		private bool DHJMMCNCLNI()
		{
			return false;
		}

		private bool CAALBHIKCGF()
		{
			return false;
		}

		private bool CEIDMFLBIDI()
		{
			return false;
		}

		private DBFJJLIGAFA DKNPLIDNCIK()
		{
			return null;
		}

		public void Set(EOKBGGOAFLF OPKDMEIFDHL)
		{
		}

		public void SetFreeGift(EOKBGGOAFLF OPKDMEIFDHL, Action CMBOGODMDHL)
		{
		}

		private void HMLMNPBCEBL(EOKBGGOAFLF OPKDMEIFDHL)
		{
		}

		public void Set(EOKBGGOAFLF OPKDMEIFDHL, int MEINMHJOFNH, int EJJMBGGIBMB = -1, OILDLLGEMKP.ELJFLLCIOKO HKABFOKMOLM = null)
		{
		}

		private void HMLMNPBCEBL(EOKBGGOAFLF OPKDMEIFDHL, int MEINMHJOFNH, int EJJMBGGIBMB)
		{
		}

		public void Set(int IEGHJNDINMO, int MEINMHJOFNH)
		{
		}

		public void Set(int IEGHJNDINMO)
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void BuyStoreItem()
		{
		}

		private void OEGMAGOCCDB(List<EOKBGGOAFLF> GAIEMFHOMGI)
		{
		}

		private global::NCOKFFGPIJM<LoadingDialogModel> OFFHEBDMOGN(string OFCFPGACNJB)
		{
			return null;
		}

		public void TryStoreItem()
		{
		}

		public void ShareLink()
		{
		}

		private void AMBAIJGALLL()
		{
		}

		private void EBKKAKJEDLK()
		{
		}

		private void BDJJGJJKHEE(GKPEKOLBBJL NIFOGEBEDNG, long JKPJELBKKGN)
		{
		}

		private void PHBLFOLAEDI(POPLPJGHHIA.IBLMGFBJMDI AGBGHKCBCDL)
		{
		}

		public bool CanWishlist()
		{
			return false;
		}

		public void ToggleIsWishlisted()
		{
		}

		public static bool ValidateGiftPackageToSpawn(EDDPDJCKOBH.GMBCAMAAPMN FONCKAGCGLJ, out string PEOLHGGDCPN)
		{
			PEOLHGGDCPN = null;
			return false;
		}

		public static void SpawnGiftPackage(EDDPDJCKOBH.GMBCAMAAPMN FONCKAGCGLJ)
		{
		}

		private bool JCBDEMODGIL()
		{
			return false;
		}

		public bool HasActiveSale()
		{
			return false;
		}

		public int GetActiveSalePercent()
		{
			return 0;
		}

		public bool IsLimitedTimeItem()
		{
			return false;
		}

		public DateTime LimitedTimeAvailableUntil()
		{
			return default;
		}

		public void OnLimitedTimeItemExpired()
		{
		}

		public string GetPriceText()
		{
			return null;
		}

		public bool TryGetGiftingToPlayerIdFromUri(out int IKMDGLICGMK)
		{
			IKMDGLICGMK = default;
			return false;
		}

		private bool FFIGIMCGMOE(FHDMILPJGDJ NJKILOEBDPD)
		{
			return false;
		}

		private string GLNMDLIADNI(FHDMILPJGDJ NJKILOEBDPD)
		{
			return null;
		}

		private string KNIJEBFGAFN(FHDMILPJGDJ NJKILOEBDPD)
		{
			return null;
		}

		private global::NCOKFFGPIJM<MessageDialogModel> MMDFNFAMJPO(string OFMGPNLDCAB, string OFCFPGACNJB, Sprite IECDHEIBMJN = null, List<DGMPBIPKJEB> EFPCOJJCKFH = null, Action NGEJLMKFAHM = null)
		{
			return null;
		}

		[CompilerGenerated]
		private void PHOKLAEKKKP()
		{
		}

		[CompilerGenerated]
		private bool JFBJPADMPMH()
		{
			return false;
		}

		[CompilerGenerated]
		private void FPDBHEMGLCN(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, CardModel DBFJCBGMMPD, AccountModel KCCEEALIFJE, JLOCLGGLOPP JCOELCOJBFM)
		{
		}

		[CompilerGenerated]
		private void OFJHDKJOCBP(int GMEHLIHLGEH)
		{
		}

		[CompilerGenerated]
		private void AKLMBPKMCOF(BaseDialogModel<KCOKPCOFDIM> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private DFDECAEJBIO MHMMOEMPHLB(EOKKPHLOBBD GOJCEBCMFJK)
		{
			return null;
		}

		[CompilerGenerated]
		private DFDECAEJBIO DPGDMNEAICK(Player COLMAMKJPJE)
		{
			return null;
		}

		[CompilerGenerated]
		private void OEMKFPKLJOM(List<OHBMDKFALBG> JMKDPAGJMGI)
		{
		}

		[CompilerGenerated]
		private bool ELBFDDDEDMF(OHBMDKFALBG NCJDOLEIFCO)
		{
			return false;
		}

		[CompilerGenerated]
		private void JNMLMKBDKKG()
		{
		}

		[CompilerGenerated]
		private void IICALHFPPOD()
		{
		}

		[CompilerGenerated]
		private void PMGEEKIAPAH(MessageDialogModel GDMKJGAKCND)
		{
		}
	}
}
