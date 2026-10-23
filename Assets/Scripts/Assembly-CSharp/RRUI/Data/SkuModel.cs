using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RRUI.Dialogs;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class SkuModel : RRUIModel, KFLOGBPDDDD, FDFHJNFMGOJ
	{
		public class ICGCEDAHFGM
		{
			private bool MIAGHMLCBHJ;

			private bool BNGONKNOGAK;

			private bool HKGODBKPCNP;

			private Func<List<EDDPDJCKOBH.GMBCAMAAPMN>, List<EDDPDJCKOBH.GMBCAMAAPMN>> POJEMMECKOC;

			private static ICGCEDAHFGM FOCJOCEFFJD;

public bool GMMGLNIONKH
{
get 			{
				return false;
			}

set {
			}
}

public bool HLDKFKJAGAK
{
get 			{
				return false;
			}

set {
			}
}

public bool CJEMLHNDCIC
{
get 			{
				return false;
			}

set {
			}
}

public Func<List<EDDPDJCKOBH.GMBCAMAAPMN>, List<EDDPDJCKOBH.GMBCAMAAPMN>> EGDFBCMDMEH
{
get 			{
				return null;
			}

set {
			}
}

public static ICGCEDAHFGM OCEOCHBDNNO
{
get 			{
				return null;
			}

}
		}

		public enum JDNDNHKCPGL
		{
			Default = 0,
			RRPlusMembership = 1
		}

		private sealed class JHFJKJFPMEF
		{
			public SkuModel _003C_003E4__this;

			public LJJIHDDNLNB checkoutDialogData;

			public Action<JBKIHLCKCJM> _003C_003E9__4;

			internal void _003CTryShowPurchaseReminderConfirmationDialogPopUp_003Eb__0(int index, CardModel cardModel, SkuModel skuModel, JLOCLGGLOPP accountToCardController)
			{
			}

			internal void _003CTryShowPurchaseReminderConfirmationDialogPopUp_003Eb__1()
			{
			}

			internal void _003CTryShowPurchaseReminderConfirmationDialogPopUp_003Eb__4(JBKIHLCKCJM purchaseResults)
			{
			}

			internal void _003CTryShowPurchaseReminderConfirmationDialogPopUp_003Eb__2()
			{
			}

			internal void _003CTryShowPurchaseReminderConfirmationDialogPopUp_003Eb__3(BaseDialogModel<LJJIHDDNLNB> dialog)
			{
			}
		}

		private sealed class EOHPCEHBHJM
		{
			public string token;

			public SkuModel _003C_003E4__this;

			internal void _003CTryPurchaseItem_003Eb__6(long transactionId)
			{
			}
		}

		private sealed class BMEJJALNMHK
		{
			public long transactionId;

			public EOHPCEHBHJM CS_0024_003C_003E8__locals1;

			public Action<string> _003C_003E9__10;

			public Action<string> _003C_003E9__12;

			public Action<string> _003C_003E9__11;

			public Action<string> _003C_003E9__14;

			public Action<string> _003C_003E9__15;

			internal void _003CTryPurchaseItem_003Eb__8()
			{
			}

			internal void _003CTryPurchaseItem_003Eb__10(string newToken)
			{
			}

			internal void _003CTryPurchaseItem_003Eb__11(string error)
			{
			}

			internal void _003CTryPurchaseItem_003Eb__12(string cancelPurchaseError)
			{
			}

			internal void _003CTryPurchaseItem_003Eb__9(string error)
			{
			}

			internal void _003CTryPurchaseItem_003Eb__14(string newToken)
			{
			}

			internal void _003CTryPurchaseItem_003Eb__15(string tokenError)
			{
			}
		}

		private sealed class KLGKNINEDKC
		{
			public string error;

			public BMEJJALNMHK CS_0024_003C_003E8__locals2;

			internal void _003CTryPurchaseItem_003Eb__13()
			{
			}
		}

		private sealed class MONBELOMGIA
		{
			public SkuModel _003C_003E4__this;

			public long transactionId;

			internal void _003CTryCompletePurchaseInternal_003Eb__0()
			{
			}

			internal void _003CTryCompletePurchaseInternal_003Eb__1(string error)
			{
			}
		}

		private sealed class EPNDIEFMMHI
		{
			public long transactionId;

			public SkuModel _003C_003E4__this;

			internal void _003CTryCancelPurchaseInternal_003Eb__0(string cancelPurchaseError)
			{
			}

			internal void _003CTryCancelPurchaseInternal_003Eb__1()
			{
			}
		}

		public const int DAYS_REMAINING_IN_SUBSCRIPTION_THRESHOLD = 30;

		private const float JPJBJLFOBMP = 350f;

		private const float DKNDFKHEBAJ = 1850f;

		private const float IEEGDIBLNKL = 1650f;

		private const string EAPBCJLHNFP = "\\s*(\\d+)\\s*Tokens\\s*";

		private const string KDKHCDODKCF = "Econ.EnableTryingBundleItems";

		private const int JPKNJMLOLGH = 200;

		private const int JLHLBPMPNPK = 18;

		private const string BEBNLCHCGIH = "rrplus_upsells";

		private const string HHJPHFLNCHO = "slot_count_rrplus";

		private const string BOFLKPMJNIC = "slot_count_non_rrplus";

		[SerializeField]
		private JDNDNHKCPGL source;

		private POPLPJGHHIA.OCDCJKGHBON KPNKHECIGAH;

		private GLLAGLIOBOG FIOIPFLGIAM;

		private List<DBFJJLIGAFA> MEBNLDFHAGH;

		public Dictionary<GKPEKOLBBJL, int> BonusGiftDropCurrencies;

		private int CECHCGEFLAI;

		private POPLPJGHHIA.EGCCHLKLIIL CAIJIPHFNMH;

		private string LHJIEAOEPDJ;

		private MessageDialogModel HIBHINOKJLL;

		private IPGOOJIFBAB OCIPICLBINB;

		private LoadingDialogModel LEIMMDDCEHJ;

		private DFDLIBCDHDN PPPOFJAEBEP;

		private PS4SkuPurchaseConfirmationDialogModel FBBHKOGKCHN;

		private OKFNDADPNEA LBGHDDGLIKO;

		private CheckoutDialogModel GEGLGIMBFOH;

		private List<DGMPBIPKJEB> ONDFGAOALKJ;

		private List<DGMPBIPKJEB> OBDBCHCFGBM;

		private EEANDDJEMJC AMFKAIJIABD;

		private bool HFHHJAIBGJO;

		private Lazy<bool> DFIJMMDIJHI;

		private string JJHNBLCIBCO;

		private bool FNALHLBALFK;

		private bool KANBKMGDPPB;

		private bool LHLLDCBBGMP;

		private bool FDNNFAMNEBA;

		private string LIEIGPBNAAE;

		private DynamicUIDialogModel MENCGELDIFK;

		private DHAPPKCJJCA CDIDKBGGHAM;

		private string OMHKGGPLBNK;

		private ICGCEDAHFGM OCLPJAKMHHB;

public JDNDNHKCPGL Source
{
get 		{
			return JDNDNHKCPGL.Default;
		}

set {
		}
}

public POPLPJGHHIA.OCDCJKGHBON FullSku
{
get 		{
			return null;
		}

private set {
		}
}

public POPLPJGHHIA.KAEKKCCLKLH Sku
{
get 		{
			return null;
		}

}

public POPLPJGHHIA.LOBKJCHKJAA PurchaseCampaign
{
get 		{
			return null;
		}

}

public POPLPJGHHIA.KGDMKAOCGMG PurchaseReminder
{
get 		{
			return null;
		}

}

public GLLAGLIOBOG PurchaseReminderCostInfo
{
get 		{
			return null;
		}

set {
		}
}

public List<DBFJJLIGAFA> BonusGiftDropsToDisplay
{
get 		{
			return null;
		}

set {
		}
}

public int SkuIndexInList
{
get 		{
			return 0;
		}

private set {
		}
}

public POPLPJGHHIA.EGCCHLKLIIL TriggerFlags
{
get 		{
			return POPLPJGHHIA.EGCCHLKLIIL.None;
		}

private set {
		}
}

public string DisplayName
{
get 		{
			return null;
		}

}

public string DisplayDescription
{
get 		{
			return null;
		}

}

public string DisplayImageName
{
get 		{
			return null;
		}

}

public string SeasonsImageName
{
get 		{
			return null;
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

private bool EDHGJPNLJCC
{
get 		{
			return false;
		}

}

public bool CanShowPreviewableGiftDrops
{
get 		{
			return false;
		}

}

public GameObject GameObject
{
get 		{
			return null;
		}

}

public string RRPMembershipSignUpPageAmplitudeSource
{
get 		{
			return null;
		}

private set {
		}
}

public bool CanShowRRPlusMembershipWarningInfo
{
get 		{
			return false;
		}

}

public bool CanBuyRRPlusMembership
{
get 		{
			return false;
		}

}

public bool CanManageRRPlusMembership
{
get 		{
			return false;
		}

}

public bool CanOpenRecNetWebsite
{
get 		{
			return false;
		}

}

public string RRPlusMembershipWarningInfoText
{
get 		{
			return null;
		}

}

public string EntrypointName
{
get 		{
			return null;
		}

private set {
		}
}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		public void OnRRUIStackedUIEntered(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK)
		{
		}

		public void OnBeforeRRUIStackedUIExited(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public void OnRRUIStackedUIExited(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public LAHBDKNMNHN OnBeforePageSwapFrom(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL IJBCMNDEFKG)
		{
			return null;
		}

		public LAHBDKNMNHN OnBeforePageSwapTo(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL NNNNCKGCFDC)
		{
			return null;
		}

		public LAHBDKNMNHN OnAfterPageSwapTo(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL CPPLLDJOLBG)
		{
			return null;
		}

		public LAHBDKNMNHN OnShow(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
		{
			return null;
		}

		public LAHBDKNMNHN OnHide(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
		{
			return null;
		}

		public void Set(POPLPJGHHIA.OCDCJKGHBON EEFFOCCPECD, string PGEIBONDJJP, POPLPJGHHIA.EGCCHLKLIIL OBNBBDPHGAD = POPLPJGHHIA.EGCCHLKLIIL.None, int BMHCLIOCOOA = -1, ICGCEDAHFGM MHCKMFCFLON = null)
		{
		}

		public void Set(string PGEIBONDJJP, EEANDDJEMJC AMFKAIJIABD = null)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void BuySku()
		{
		}

		public void BuyPurchaseReminder()
		{
		}

		public void InitializePurchaseReminderCostInfo()
		{
		}

		private void NNKBGBDGHPF()
		{
		}

		private string EGNLKPCKBIP()
		{
			return null;
		}

		private void IAEOFFHFIFA()
		{
		}

		public void TryShowRRPMembershipDetailsDialogPopUp()
		{
		}

		public void BuyRRPlusMembership()
		{
		}

		public void ShowAlreadyOwnedBundleItemsDialog()
		{
		}

		private void DBDDLEENGJM()
		{
		}

		private void NKDLPDGNJMN()
		{
		}

		private void DKIJICHELBO()
		{
		}

		private void LNCICOJLIAM(PlayerCommerceConfig.BDHFDPGHALB AIDOCIKAKCJ, string FDIIMMKOKDJ = "")
		{
		}

		private global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> BCNOHDBGCGB()
		{
			return null;
		}

		private void PPJFANKHMKK(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
		{
		}

		private void FDKPFODFBNF(EAFLPCNDJNK EJLJFIBFPCA)
		{
		}

		private void KBHGMPFCJBL(int KJDBNCIGEGF)
		{
		}

		private void KBHGMPFCJBL(string DCGGHDHOHLO)
		{
		}

		private void FBDBJBFLPAI()
		{
		}

		private void BELDMHALNPI()
		{
		}

		public void InitiatePurchaseSku()
		{
		}

		private void DLANFADKAMC()
		{
		}

		private void OFFHEBDMOGN()
		{
		}

		private void OMJBPNAPJEB()
		{
		}

		private void PGPGJALNEOD()
		{
		}

		private void MMDFNFAMJPO(string OFMGPNLDCAB, string OFCFPGACNJB, Sprite IECDHEIBMJN = null, List<DGMPBIPKJEB> EFPCOJJCKFH = null)
		{
		}

		private void JHKCIEIEPKJ(long APMEBBJFJIJ, string LBNADNCOMBC)
		{
		}

		private void KCOLDJPINHI(long APMEBBJFJIJ, string LBNADNCOMBC)
		{
		}

		public string GetDisplayPrice()
		{
			return null;
		}

		private void PNNJABPLDMP(string HLIGBKANEEA)
		{
		}

		private void DGLBPFGEJKK(string IBKGKDECOEG, string GPDGCFACMII)
		{
		}

		private void GHPHIALGPCB()
		{
		}

		private void BCFBPGAACIN()
		{
		}

		public ImposterRawImage.EPAKCHBMMDO TryGetBonusGiftDropImposterImageByIndex(int GMEHLIHLGEH)
		{
			return null;
		}

		public string TryGetBonusGiftDropNameByIndex(int GMEHLIHLGEH)
		{
			return null;
		}

		public string GetSkuDisplayName()
		{
			return null;
		}

		public bool HasCurrencyToDisplay()
		{
			return false;
		}

		public int GetCurrencyAmountToDisplay()
		{
			return 0;
		}

		public string GetCurrencyTypeToDisplay()
		{
			return null;
		}

		public string GetCurrencyDisplay()
		{
			return null;
		}

		public int GetTotalProgressionEventCurrencyAmount()
		{
			return 0;
		}

		public int GetTotalRecCenterTokenAmount()
		{
			return 0;
		}

		public string GetBackgroundImageName()
		{
			return null;
		}

		public string GetFourthItemLabel()
		{
			return null;
		}

		public ImposterRawImage.EPAKCHBMMDO GetFourthItemImposterImage()
		{
			return null;
		}

		public string GetPurchaseSuccessTitleString()
		{
			return null;
		}

		public string GetPurchaseSuccessDescriptionString()
		{
			return null;
		}

		public string GetCountdownString(string KHCNDENCFFO, string PKMIPBHPANP)
		{
			return null;
		}

		private void BDJJGJJKHEE(GKPEKOLBBJL NIFOGEBEDNG, long JKPJELBKKGN)
		{
		}

		private void PHBLFOLAEDI(POPLPJGHHIA.IBLMGFBJMDI AGBGHKCBCDL)
		{
		}

		private void ELGIJAJNDEP(Action IBKGKDECOEG)
		{
		}

		public void ToggleBundleItemsPreview()
		{
		}

		public void UnequipTrackedBundleItemsPreview()
		{
		}

		[CompilerGenerated]
		private void GLEDDJPIDJJ(OBNLIHDIEIE JHAGLGAMPLN)
		{
		}

		[CompilerGenerated]
		private void OCAINBBHEJN()
		{
		}

		[CompilerGenerated]
		private void EOAIBGIDJKE(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void EONOGDMIIGK(bool EPDJDCDHLMP)
		{
		}

		[CompilerGenerated]
		private void KMMJOEMGJHM(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void CDPIKPGAGDH(bool LPBPNNLKPLK)
		{
		}

		[CompilerGenerated]
		private void OOOBLICFMPA(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void BOBAFFCIFDP()
		{
		}

		[CompilerGenerated]
		private void BMINJDKMBPG(bool LPBPNNLKPLK)
		{
		}

		[CompilerGenerated]
		private void PFIJOFJGGGN(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
		{
		}

		[CompilerGenerated]
		private void NLJJNOCJFCP(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void DPPHAKJFNKH(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void HODLOONOMDA(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void PMDBLMKILJD(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<POPLPJGHHIA.KAEKKCCLKLH>> COEGMKGBHKJ(List<POPLPJGHHIA.KAEKKCCLKLH> HPELBOFIPLN)
		{
			return null;
		}

		[CompilerGenerated]
		private void MIOPDCMOGFG(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void LCDOHBJJPCB(POPLPJGHHIA.IMHHMEHCDMP HMNMOFBEHOD)
		{
		}

		[CompilerGenerated]
		private void EPGJIPMGFDI(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void FPNBIELAGDB(DFDECAEJBIO ACBGBAAHOIM)
		{
		}

		[CompilerGenerated]
		private void GKKFLMEAIBP(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void KCHMBHKMENI()
		{
		}

		[CompilerGenerated]
		private void CHBJJKDIPOH(bool LPBPNNLKPLK)
		{
		}

		[CompilerGenerated]
		private void DMIMGKPDBNP(PlatformManager.CLOICBFMBND JONAPMBPHCO)
		{
		}

		[CompilerGenerated]
		private void PJFNLPMCICD(PlatformManager.CLOICBFMBND JONAPMBPHCO)
		{
		}

		[CompilerGenerated]
		private void AKCAMECFPPH(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void BKGLDHEBIOC(string IALNODEHBNN)
		{
		}

		[CompilerGenerated]
		private void IHBIGFKFEBP(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void LOLCKGFDPCM(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void GMMAIBDAMGG(BaseDialogModel<DFDLIBCDHDN> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void KAANGGBDLHI()
		{
		}

		[CompilerGenerated]
		private void KKCPOJHMACC(BaseDialogModel<OKFNDADPNEA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void GNIHPLHLKFB()
		{
		}

		[CompilerGenerated]
		private void ELGOCOOLOCO(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void BFMJFHDNLEN()
		{
		}

		[CompilerGenerated]
		private void FBBOFEDPJGO()
		{
		}

		[CompilerGenerated]
		private void CACFHPICHLE()
		{
		}
	}
}
