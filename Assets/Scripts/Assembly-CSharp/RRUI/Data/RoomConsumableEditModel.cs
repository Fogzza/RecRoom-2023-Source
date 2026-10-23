using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomConsumableEditModel : RoomConsumableModelBase, FDFHJNFMGOJ
	{
		public enum AOJFKDINIEI
		{
			Default = 0,
			ConsumableDetails = 1,
			RoomConsumableStore = 2
		}

		private sealed class IFPLGCLCNKE
		{
			public BHBBBFDCJAH costInfo;

			public LJJIHDDNLNB checkoutDialogData;

			public RoomConsumableEditModel _003C_003E4__this;

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__2()
			{
			}

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__3()
			{
			}
		}

		private const string HANJAOBCLFA = "This consumable has been disabled due to Code of Conduct violations.";

		private const string LKDBGPDFCAH = "Further violations may result in the room being closed.";

		private const int MHMNGFCMMEN = 18;

		[SerializeField]
		private AOJFKDINIEI source;

		private DynamicUIDialogModel EIBHMHKFAAH;

		private DHAPPKCJJCA IKNKNNIFKON;

		private readonly ManagedTexture PHDELAPLILN;

		private MessageDialogModel PEHELDEPGIJ;

		private IPGOOJIFBAB AHFCLGJMEPC;

		private IPGOOJIFBAB EJOBBKPNJEL;

		private IPGOOJIFBAB GNDBCBFDKPC;

		private CheckoutDialogModel GEGLGIMBFOH;

		private MessageDialogModel HIBHINOKJLL;

		private IPGOOJIFBAB OCIPICLBINB;

		private List<DGMPBIPKJEB> ONDFGAOALKJ;

		private List<DGMPBIPKJEB> CIEKAEPJOIO;

public bool ShouldSubmitButtonBeInteractible
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

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void BJPPPBGBLAO()
		{
		}

		public void CreateRoomConsumable()
		{
		}

		public void TryChangeRoomConsuambleImage()
		{
		}

		private global::NCOKFFGPIJM<string> DLLPNBIEHKH()
		{
			return null;
		}

		public void ModifyRoomConsumable()
		{
		}

		public void ConfirmDeleteRoomConsumable()
		{
		}

		private void PAGAHMCDCHA()
		{
		}

		public void DeleteRoomConsumable()
		{
		}

		private void CEJIKFDGOKB(BKCIEBLAHHB GADDGJANIGG)
		{
		}

		private void KGJECJABGHF(Guid GADDGJANIGG)
		{
		}

		private void JIHEKHPJKEK()
		{
		}

		public void TryShowPurchaseCurrencyListDialogPopUp()
		{
		}

		public void GetRoomConsumable()
		{
		}

		private void NFFOHNNIHIL()
		{
		}

		private void MBICHBEBCGC(long NDGJEBNJMAB, Guid? CDOPKKFCMLA = null)
		{
		}

		private void BBELGOOIONH(string OFCFPGACNJB)
		{
		}

		private void MMDFNFAMJPO(string OFMGPNLDCAB, string OFCFPGACNJB, Sprite IECDHEIBMJN = null, List<DGMPBIPKJEB> EFPCOJJCKFH = null)
		{
		}

		private IPGOOJIFBAB HHGNBHOFBFK()
		{
			return null;
		}

		private IPGOOJIFBAB NHFPKCMJEFA()
		{
			return null;
		}

		private IPGOOJIFBAB FGGMKPDEMKI()
		{
			return null;
		}

		private void PPGCPHGMMGM()
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

		[CompilerGenerated]
		private void CNJJGNBINJJ(EKACNGGFGNM MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void OPFHMGHKKJN(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void FENGIEMOKKF(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<string> MDLIKLGEJNK(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private void DEBCFPMPIEC(EKACNGGFGNM MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void DOMEDMCCBMJ(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void BICOIIHLHOI(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void BAFDDMMIACE(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void BNBHCHHPFJI(bool NIACONHLDKF)
		{
		}

		[CompilerGenerated]
		private void AOCBJEGPHAG(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void AIDJLNCNBHI(PLPKONMJAFM MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void LKDJEHMBPHD(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private object OFEBLGAOCHF()
		{
			return null;
		}

		[CompilerGenerated]
		private void KLBKGCADLDC(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private void OLLPLPFJCEC(string IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void ADGHNFKIAAO(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void JEONKINNIAN(int GMEHLIHLGEH, CardModel DBFJCBGMMPD, RoomConsumableEditModel BPEEHGJPHJG, JLOCLGGLOPP PBDIPMFIDNG)
		{
		}

		[CompilerGenerated]
		private string EJOFHPAJAPO()
		{
			return null;
		}

		[CompilerGenerated]
		private string CLBAPFOCIHK()
		{
			return null;
		}

		[CompilerGenerated]
		private string PBMLJGAMFPO()
		{
			return null;
		}

		[CompilerGenerated]
		private void NGAKAPMILAE()
		{
		}

		[CompilerGenerated]
		private void AIDOKOLPNME(BaseDialogModel<LJJIHDDNLNB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void GODJMDDNKBK((bool, string) MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private void LIJEJOIONPD()
		{
		}

		[CompilerGenerated]
		private void NKPNEADAAHH()
		{
		}

		[CompilerGenerated]
		private void JBCINMEKBIH(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void CCLKNCMNHFD()
		{
		}

		[CompilerGenerated]
		private void AJLPJNKMNHB()
		{
		}

		[CompilerGenerated]
		private void COINJOKIBHO()
		{
		}
	}
}
