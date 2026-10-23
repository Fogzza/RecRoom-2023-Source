using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomKeyModel : RRUIModel<DAKMOAKIKIC>, KFLOGBPDDDD, FDFHJNFMGOJ
	{
		public enum KFBCFCEHKDC
		{
			Default = 0,
			KeyDetails = 1,
			KeyStore = 2
		}

		public class APOHBKFADMJ
		{
			public long JGDCFJKJKPF;

			public string PALADLMJNAK;

			public string HDJKLNIGFHF;

			public int FEABDNCAABL;

			public string EDMNOAEBDNC;

			public Guid? GDFJODMHPGD;
		}

		private sealed class LDPPNGJIMPE
		{
			public BJCEIFIFEOK costInfo;

			public LJJIHDDNLNB checkoutDialogData;

			public RoomKeyModel _003C_003E4__this;

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__2()
			{
			}

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__3()
			{
			}
		}

		public const string ROOM_KEY_ID_KEY = "ROOM_KEY_ID_KEY";

		public const string ROOM_KEY_ENTRYPOINT_NAME_KEY = "ROOM_KEY_ENTRYPOINT_NAME_KEY";

		public const string ROOM_KEY_REPLICATION_KEY = "ROOM_KEY_REPLICATION_KEY";

		public const string DEFAULT_NAME_TEXT = "Create New Key";

		private const string FPMHLGBACNN = "Tokens";

		public const string ROOM_KEY_SHOW_INFO_IN_DETAIL_VIEW = "RoomKey_ShowInfoInDetailView";

		[SerializeField]
		private KFBCFCEHKDC source;

		[SerializeField]
		private bool redirectOnSuccessfulModification;

		[SerializeField]
		private Route modificationRedirectRoute;

		[SerializeField]
		private Route deletionRedirectRoute;

		[SerializeField]
		private bool redirectOnSuccessfulCreation;

		[SerializeField]
		private Route creationRedirectRoute;

		public static long INVALID_KEY_ID;

		private long DJOJMIDBABE;

		private EOHADGOEBOD BHECBAFNPEM;

		private string OMHKGGPLBNK;

		private const string GKOICHOFMEO = "This key has been disabled due to Code of Conduct violations.";

		private const string FCFNBCKDEMG = "Further violations may result in the room being closed.";

		private const string JFGBGFFCALH = "You are about to delete the key with the name \"{0}\". Once this key is deleted, this name cannot be used again. \n\nAre you sure you want to delete this key? \n\nThis action cannot be undone.";

		private MessageDialogModel PEHELDEPGIJ;

		private MessageDialogModel CCEJFNENJHO;

		private IPGOOJIFBAB AHFCLGJMEPC;

		private IPGOOJIFBAB EJOBBKPNJEL;

		private IPGOOJIFBAB GNDBCBFDKPC;

		private List<BKCIEBLAHHB> HIKHMJEIBED;

		private DynamicUIDialogModel EIBHMHKFAAH;

		private DHAPPKCJJCA IKNKNNIFKON;

		private readonly ManagedTexture PHDELAPLILN;

		private Guid IEMFHCFEHCA;

		private EEANDDJEMJC NMEALPOPCHL;

		private CheckoutDialogModel GEGLGIMBFOH;

		private MessageDialogModel HIBHINOKJLL;

		private IPGOOJIFBAB OCIPICLBINB;

		private List<DGMPBIPKJEB> ONDFGAOALKJ;

		private APOHBKFADMJ OFABMKEANJH;

		private string GMCEELDFIOP;

protected override BMBBHLIOIIF CHGIJCOGJED
{
get 		{
			return default;
		}

}

public bool IsGameRunning
{
get 		{
			return false;
		}

}

public long RoomKeyId
{
get 		{
			return 0L;
		}

private set {
		}
}

public EOHADGOEBOD RoomKey
{
get 		{
			return null;
		}

private set {
		}
}

public bool RoomKeyOwned
{
get 		{
			return false;
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

public static bool DisplayRoomKeyInfoSection
{
get 		{
			return false;
		}

set {
		}
}

protected override bool GIHBNOOCJDD
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

public APOHBKFADMJ ModificationBackingData
{
get 		{
			return null;
		}

private set {
		}
}

public string Name
{
get 		{
			return null;
		}

set {
		}
}

public string Description
{
get 		{
			return null;
		}

set {
		}
}

public int Price
{
get 		{
			return 0;
		}

set {
		}
}

public string ImageName
{
get 		{
			return null;
		}

set {
		}
}

public Guid? PurchaseCurrencyId
{
get 		{
			return null;
		}

set {
		}
}

public string PurchaseCurrencyName
{
get 		{
			return null;
		}

private set {
		}
}

public bool ShouldSubmitButtonBeInteractable
{
get 		{
			return false;
		}

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

		public void OnRRUIStackedUIEntered(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK)
		{
		}

		public void OnBeforeRRUIStackedUIExited(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public void OnRRUIStackedUIExited(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		public void Set(long LLKNDIDFNDB)
		{
		}

		public void Set(long LLKNDIDFNDB, Guid IEMFHCFEHCA, EEANDDJEMJC NMEALPOPCHL = null, string PGEIBONDJJP = null)
		{
		}

		private void LEMMPKPKJKO(EOHADGOEBOD NKEGLGHKOJC)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(DAKMOAKIKIC MIEKCPMBJHD)
		{
			return null;
		}

		public void TryChangeRoomKeyImage()
		{
		}

		private global::NCOKFFGPIJM<string> DLLPNBIEHKH()
		{
			return null;
		}

		public void ModifyRoomKey()
		{
		}

		public void ConfirmDeleteRoomKey()
		{
		}

		private void DBBJGDEJCIP()
		{
		}

		private void ELKCKKJLGMP()
		{
		}

		public void CreateRoomKey()
		{
		}

		public void TryShowPurchaseCurrencyListDialogPopUp()
		{
		}

		public string GetRoomKeyPriceText()
		{
			return null;
		}

		private string GPOPLDAICLP()
		{
			return null;
		}

		public void LaunchPurchaseConfirmationDialog()
		{
		}

		private void KOKIFNAHAKD()
		{
		}

		private void JNOCAJBHPPJ(long NDGJEBNJMAB)
		{
		}

		private void MMDFNFAMJPO(string OFMGPNLDCAB, string OFCFPGACNJB, Sprite IECDHEIBMJN = null, List<DGMPBIPKJEB> EFPCOJJCKFH = null, Action EMPPKJOOCAO = null)
		{
		}

		public void ShowDismissInfoDisclaimerDialog()
		{
		}

		[CompilerGenerated]
		private bool EDLCAINMLML(BKCIEBLAHHB FCCGDNMAHPA)
		{
			return false;
		}

		[CompilerGenerated]
		private void GDOPBFEJEEC(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<string> CJKGPLFALAF(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private void BNPCPCFNOOC(MOJJJCCHPLE MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void FEHEILOHEKI(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void BJDLMPJPFDB()
		{
		}

		[CompilerGenerated]
		private void DADPJOEKKDP(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void FHPBMGPNOJB()
		{
		}

		[CompilerGenerated]
		private void ENJPKNOKPPD(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void ONLNDEBOFHA(bool NIACONHLDKF)
		{
		}

		[CompilerGenerated]
		private void KOCHDAAMEFM()
		{
		}

		[CompilerGenerated]
		private void MKNJFKGKEJK(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void GAGPPIPGDNO(FLOBEEJEPJO MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void MHGLFIJPKIM(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void DEEEAFACKHA(MOJJJCCHPLE MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void GNADJFKFLDL(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private object KHBJPOFLOGB()
		{
			return null;
		}

		[CompilerGenerated]
		private void KCOHLENHKMJ(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private void PBKKEFMIIHE(string IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void HIEKDPPIPKE(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void LBDJNBNAMDN(int GMEHLIHLGEH, CardModel DBFJCBGMMPD, RoomKeyModel MDENKAMNHAJ, JLOCLGGLOPP PBDIPMFIDNG)
		{
		}

		[CompilerGenerated]
		private void MLPKFICNCFO()
		{
		}

		[CompilerGenerated]
		private void KDFPANKLCAI(BaseDialogModel<LJJIHDDNLNB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void FGHBOLEGAMN((bool, string) MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void JGIABMNDEPC(LKKOPNLCJBC.RoomKeyPurchaseWithCurrencyResponseDTO FCFLDGMANOJ)
		{
		}

		[CompilerGenerated]
		private void CHFJJBGBIDK()
		{
		}

		[CompilerGenerated]
		private void EFBOIFPJMBN(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void ANCODLDHKEG()
		{
		}

		[CompilerGenerated]
		private void FEIKBLLFNAB()
		{
		}

		[CompilerGenerated]
		private void FPBMFMHEBCC(MessageDialogModel LFKKJIFPEMA)
		{
		}
	}
}
