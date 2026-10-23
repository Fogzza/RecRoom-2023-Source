using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AGUI.StackedUI;
using Photon.Pun;
using RRUI.Data;
using UnityEngine;

namespace RecRoom
{
	public class CreatorFreeGiftButton : MonoBehaviourPun, DJLCHGFCFAD
	{
		public enum HEIFLCIGHFA : byte
		{
			MINUTES_5 = 0,
			HOURS_1 = 1,
			HOURS_24 = 2,
			DAYS_7 = 3,
			MONTHS_1 = 4,
			LIFETIME = 5
		}

		private sealed class FGIKKCNILML
		{
			public int index;

			public CreatorFreeGiftButton _003C_003E4__this;

			internal void _003CEditFreeGiftsRRUI_003Eb__2()
			{
			}
		}

		private sealed class APFJBDFDKGM
		{
			public CreatorFreeGiftButton _003C_003E4__this;

			public IELGHJEOPKB consumable;

			internal void _003CAddFreeGift_003Eb__0()
			{
			}
		}

		private sealed class EDOFBJDPEIG
		{
			public CreatorFreeGiftButton _003C_003E4__this;

			public IELGHJEOPKB consumable;

			public Func<EOKBGGOAFLF, bool> _003C_003E9__1;

			internal void _003CChooseFreeGiftToBuyScreen_003Eb__0()
			{
			}

			internal bool _003CChooseFreeGiftToBuyScreen_003Eb__1(EOKBGGOAFLF item)
			{
				return false;
			}
		}

		private sealed class DBEJDFEKGNI
		{
			public int index;

			public CreatorFreeGiftButton _003C_003E4__this;

			internal void _003CChooseFreeGiftToBuyScreenDialog_003Eb__2()
			{
			}
		}

		private sealed class LCPOHBKAJIH
		{
			public CreatorFreeGiftButton _003C_003E4__this;

			public DBFJJLIGAFA giftDrop;

			public DFDLIBCDHDN loadingData;

			internal void _003CPurchaseItems_003Eb__0()
			{
			}

			internal void _003CPurchaseItems_003Eb__1(string error)
			{
			}
		}

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private RoomOrPlaylistSpecificUIBehaviour roomDetailsProvider;

		[SerializeField]
		private AccountSpecificUIBehaviour accountDetailsProvider;

		private static List<CreatorFreeGiftButton> NJMAOKDOECN;

		private global::MOBDJNEDDKC<int> LMDIGHGEBPN;

		private const int PCLEEBFKKCF = 0;

		private const string GOEJPINFAJO = "{0}'s Free Gifts";

		private const string MBOBMBMEEIH = "Add to {0}'s Free Gifts";

		private const string NDCMCBGLHKN = "Any free gifts you buy will go into {0}'s free gift button pool and be available in all their rooms.";

		private const string KGFEECHGDGB = "Error deserializing FreeGiftButton {0}: No data found!";

		private const string GBOIFMBAMPC = "Error serializing FreeGiftButton {0}: Data already specified.";

		private const string LHIPEGFMGJE = "How many {0} would you like to buy?";

		private const string BOJKNDGHFAD = "Current balance: {0:n0} tokens";

		private const string DLLBDBHLOEO = "Original price: {0} tokens\nPrice with {1}: {2} tokens\nYou save: {3} tokens";

		private const string MJCAGGEKGEB = "Total Cost: {0} tokens";

		private const string JOBJGHJGDCM = "Unable to purchase {0} at a time. Please try a smaller amount.";

		private const string NGJCKIGPEHI = "Confirm purchase of {0}x {1} for {2} tokens?";

		private const string HMOPNLJNFIK = "It looks like you need {0} more tokens to buy {1}x {2}s.\n\nWould you like to buy more tokens now?";

		private const string POHHHNELNMK = "Purchasing {0}s...";

		private int FCOCOJOBHIE;

		private string AGEMFKGJMPN;

		private string FBDADPIOCIO;

		private string GHKIAFIODDM;

		private string HEFKHGKLELH;

		private bool? MHDAMDKKEEE;

		private KCOKPCOFDIM FJLKPEIKKMO;

		private List<IELGHJEOPKB> IBMCKIFNOEI;

		private IPGOOJIFBAB MBKNEEPPNMC;

		private List<EOKBGGOAFLF> GAIEMFHOMGI;

		private KCOKPCOFDIM DDDGGAEFMJO;

		private LAHBDKNMNHN IILPBOEBEBB;

		private int FIIACJOFGKM;

		private long DFPNHCJKCFM;

		private string DPKPLFDFCBO;

		private string ACJMFHKCIEM;

		private string PJCMMNEEGCA;

		private EOKBGGOAFLF BMCOAIPAEMJ;

		private KJPMDALEEKI JMJNDNBPEDB;

		private DHAPPKCJJCA OGAJFBHEMBN;

		private HELFEDOLCOM MAJFFAPICEN;

		private EHEJPNFKNAL JJENLOOMBPL;

		private bool PMEELCNCCHN;

		private string CDDDLDGCOOP;

		private IPGOOJIFBAB HEOIIDDGIJP;

public HEIFLCIGHFA Cooldown
{
get 		{
			return HEIFLCIGHFA.MINUTES_5;
		}

set {
		}
}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		private LAHBDKNMNHN BFKAIFFKMEE(int AOKOKMGBMDM)
		{
			return null;
		}

		private void Start()
		{
		}

		private void MMMPAFILNOJ()
		{
		}

		private void ENGIMCOBPLG(RoomOrPlaylistSpecificUIBehaviour.EBIKMOHGHOJ JDBHABEFGKF, RoomOrPlaylistSpecificUIBehaviour.OPBALFHHAFF BFFCGPJEHGB, BNKIKFBACEL NIFOGEBEDNG)
		{
		}

		protected override void OnDestroy()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private LAHBDKNMNHN EMODHDFEJMJ()
		{
			return null;
		}

		private void DGOEPACEHFA()
		{
		}

		private void EFJGKEHNGDK()
		{
		}

		public void AddNewFreeGiftButton()
		{
		}

		public void RestockItemButton(IELGHJEOPKB KIJHICGIKFM)
		{
		}

		private LAHBDKNMNHN BOHIDALHEKC()
		{
			return null;
		}

		private void BNFEBFBAMKI(IELGHJEOPKB KIJHICGIKFM)
		{
		}

		private void IJDJMHLNNEA(IELGHJEOPKB KIJHICGIKFM)
		{
		}

		private void NLEOLFFMCIF()
		{
		}

		private LAHBDKNMNHN MAMMNINOBKO()
		{
			return null;
		}

		private bool MBPEKLCPGGO(DBFJJLIGAFA OPKDMEIFDHL)
		{
			return false;
		}

		private bool GCHJDEHAKCE(DBFJJLIGAFA OPKDMEIFDHL)
		{
			return false;
		}

		private HMJFJMPLFEO IFCPFBPKILG(DBFJJLIGAFA ONCGIPFNENB)
		{
			return HMJFJMPLFEO.CameraFilter;
		}

		private void MKECKANNKNH()
		{
		}

		private void OHEDJFEOPNC(EOKBGGOAFLF OBIIENMBMLH)
		{
		}

		private void AMBFFEANHAN(EOKBGGOAFLF OBIIENMBMLH)
		{
		}

		private void NDCEHOJJEAI(bool KAGIMFAPGOG = false)
		{
		}

		public string GetPurchaseCount()
		{
			return null;
		}

		public void SetPurchaseCount(string BFFJHKFEFPP)
		{
		}

		public bool CanContinueToConfirmFreeGiftPurchaseScreen()
		{
			return false;
		}

		private void PEIFEHIFJFP()
		{
		}

		private void IPAOIGHPLAP()
		{
		}

		private void ADHBHFIBBJM()
		{
		}

		private void IJDFFAMFBCP()
		{
		}

		public void PurchaseDialogConfirmResponse()
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN FCILKIDDBPB(bool GNGKKJPOAPJ)
		{
			return null;
		}

		[CompilerGenerated]
		private void LCAICPAAOCA(DFDECAEJBIO CMHKLCBLLCC)
		{
		}

		[CompilerGenerated]
		private int EEEANIEIIEF()
		{
			return 0;
		}

		[CompilerGenerated]
		private void JODDHPLEKND()
		{
		}

		[CompilerGenerated]
		private void LBNMLJAAPDC(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, CardModel DBFJCBGMMPD, FreeGiftConsumableModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
		{
		}

		[CompilerGenerated]
		private void JBMKNBKANBA(List<IELGHJEOPKB> BCBAHJMKOJN)
		{
		}

		[CompilerGenerated]
		private void BLJKBOAKDNP()
		{
		}

		[CompilerGenerated]
		private void DFHEFPFBJIA(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, CardModel DBFJCBGMMPD, StoreItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
		{
		}

		[CompilerGenerated]
		private void DDBHKHALPON(FFGPLFHAGKC ELPAJMFPHOL)
		{
		}

		[CompilerGenerated]
		private bool DOLAFEGOPLO(EOKBGGOAFLF ONCGIPFNENB)
		{
			return false;
		}

		[CompilerGenerated]
		private void NDMDMMHDINM()
		{
		}

		[CompilerGenerated]
		private void OEPPKJBBCEC()
		{
		}
	}
}
