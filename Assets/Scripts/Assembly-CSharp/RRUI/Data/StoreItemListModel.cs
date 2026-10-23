using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Avatars;
using UnityEngine;

namespace RRUI.Data
{
	public class StoreItemListModel : FilterableListModel<EOKBGGOAFLF, EOKBGGOAFLF, StoreItemsConfig.HJJMICEOAOM>
	{
		public enum LJMMFEDJLNJ
		{
			Store = 0,
			AdCarousel = 1,
			Wishlist = 2,
			TopToday = 3
		}

		private sealed class GOMFHJBJPLM
		{
			public StoreItemListModel _003C_003E4__this;

			public Uri uri;

			internal object _003CTryShowSortDialogPopUp_003Eb__1()
			{
				return null;
			}

			internal void _003CTryShowSortDialogPopUp_003Eb__2(object key)
			{
			}

			internal void _003CTryShowSortDialogPopUp_003Eb__0(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class JCIGPBLCIIH
		{
			public StoreItemListModel _003C_003E4__this;

			public StoreItemsConfig.HJJMICEOAOM initialFilters;

			public Uri uri;

			internal void _003CTryShowFilterDialogPopUp_003Eb__3()
			{
			}

			internal void _003CTryShowFilterDialogPopUp_003Eb__4()
			{
			}

			internal void _003CTryShowFilterDialogPopUp_003Eb__0()
			{
			}

			internal void _003CTryShowFilterDialogPopUp_003Eb__1()
			{
			}

			internal void _003CTryShowFilterDialogPopUp_003Eb__2(BaseDialogModel<DHAPPKCJJCA> dialog)
			{
			}
		}

		private sealed class ELDGLJJHINF
		{
			public List<(StoreItemsConfig.HJJMICEOAOM, bool)> list;

			public StoreItemListModel _003C_003E4__this;
		}

		private sealed class KNAOKIHJKOC
		{
			public int index;

			public ELDGLJJHINF CS_0024_003C_003E8__locals1;

			internal bool _003CGetChecklistListSectionPanelData_003Eb__0()
			{
				return false;
			}

			internal void _003CGetChecklistListSectionPanelData_003Eb__1(bool isActive)
			{
			}
		}

		private DynamicUIDialogModel DFGBNNHNAIJ;

		private DHAPPKCJJCA HNBBOFOCBKP;

		private DHAPPKCJJCA COGJFICBMCP;

		private EHEJPNFKNAL EBMLCMGLHAK;

		private EHEJPNFKNAL EBDFEDOBAFO;

		private List<EOKBGGOAFLF> DMNNCLHPPJO;

		private List<int> IJEOKKCCDHD;

		private string NHLAJBNJDOF;

		private int MEINMHJOFNH;

		private int MAKJNNAJODJ;

		private List<(StoreItemsConfig.HJJMICEOAOM, bool)> HEDIPDKPJCD;

		private List<(StoreItemsConfig.HJJMICEOAOM, bool)> DGPHALIIBCM;

		private List<(StoreItemsConfig.HJJMICEOAOM, bool)> ECPBGGIAOCP;

		private List<(StoreItemsConfig.HJJMICEOAOM, bool)> DIONBHKMMNJ;

		private List<(StoreItemsConfig.HJJMICEOAOM, bool)> PJOBCLEIEJB;

		[SerializeField]
		private StoreItemsConfig.KMKGPPLDGEL sortCriteria;

		[SerializeField]
		private StoreItemsConfig.HJJMICEOAOM activeFilters;

		[SerializeField]
		private LJMMFEDJLNJ source;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public string AdCarouselTitle
{
get 		{
			return null;
		}

}

public int WishlistAccountId
{
get 		{
			return 0;
		}

}

public int GiftingToPlayerId
{
get 		{
			return 0;
		}

private set {
		}
}

public IReadOnlyList<(StoreItemsConfig.HJJMICEOAOM, bool)> ActiveOwnershipTypeFiltersList
{
get 		{
			return null;
		}

}

public IReadOnlyList<(StoreItemsConfig.HJJMICEOAOM, bool)> ActiveSpecialTypeFiltersList
{
get 		{
			return null;
		}

}

public IReadOnlyList<(StoreItemsConfig.HJJMICEOAOM, bool)> ActiveRarityFiltersList
{
get 		{
			return null;
		}

}

public IReadOnlyList<(StoreItemsConfig.HJJMICEOAOM, bool)> ActiveConsumablesFiltersList
{
get 		{
			return null;
		}

}

public IReadOnlyList<(StoreItemsConfig.HJJMICEOAOM, bool)> ActiveClothingFiltersList
{
get 		{
			return null;
		}

}

public LJMMFEDJLNJ Source
{
get 		{
			return LJMMFEDJLNJ.Store;
		}

set {
		}
}

		public void Set(StoreItemsConfig.HJJMICEOAOM PNEPPNKHMIM, StoreItemsConfig.KMKGPPLDGEL JIOAADGLBHG, string NIOBDAGDJAE, int IKMDGLICGMK = -1)
		{
		}

		public void Set(int JCGBFDJAIMJ)
		{
		}

		public void Set(List<int> IJEOKKCCDHD, int MEINMHJOFNH)
		{
		}

		public void SetGiftingToPlayerId(int IKMDGLICGMK)
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		public override void Search(string ADGIOFAMOGF)
		{
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<EOKBGGOAFLF>> LFFEHHGOFFN()
		{
			return null;
		}

		protected override EOKBGGOAFLF EIDFFKOOKDK(EOKBGGOAFLF ONCGIPFNENB)
		{
			return null;
		}

		private global::NCOKFFGPIJM<IEnumerable<EOKBGGOAFLF>> NKDABAEKEFN(IEnumerable<EOKBGGOAFLF> JNAAHMPCPAB)
		{
			return null;
		}

		private void ABLAKCNGDAM(StoreItemsConfig.HJJMICEOAOM HNGJGPJCNBJ, bool FBHDABEFLKL)
		{
		}

		private bool DIFKOCKKJFO(StoreItemsConfig.HJJMICEOAOM HMJEJMHJGMP, EOKBGGOAFLF OBIIENMBMLH)
		{
			return false;
		}

		public void TryShowSortDialogPopUp(Uri FKFKJOJNCLM = null)
		{
		}

		public void TryShowFilterDialogPopUp(Uri FKFKJOJNCLM = null)
		{
		}

		private void IFMBGJFOLCI()
		{
		}

		private static string[] EDNFAENDIEN(EOKBGGOAFLF ONCGIPFNENB)
		{
			return null;
		}

		private KLKCFJOABIM JGMKAODEOBP(List<(StoreItemsConfig.HJJMICEOAOM, bool)> JAAGBDPDCIE, string OEPJBAJNCNJ)
		{
			return null;
		}

		private void EFDJCLBPPDI()
		{
		}

		private void BAFECCFFHKA()
		{
		}

		private void HAACCPMHJKF(StoreItemsConfig.HJJMICEOAOM EBMCMOGMGNJ)
		{
		}

		private void NBPKAONNIEM(Uri FKFKJOJNCLM)
		{
		}

		private void JBMEOPKLDPH(StoreItemsConfig.KMKGPPLDGEL CMJKOMEBFMJ, Uri FKFKJOJNCLM)
		{
		}

		private OutfitType LJGHCJGNPIO(DBFJJLIGAFA ONCGIPFNENB)
		{
			return OutfitType.Hat;
		}

		private HMJFJMPLFEO IFCPFBPKILG(DBFJJLIGAFA ONCGIPFNENB)
		{
			return HMJFJMPLFEO.CameraFilter;
		}

		private int HDNENMCBODG(EOKBGGOAFLF OPKDMEIFDHL)
		{
			return 0;
		}

		public void ToggleStoreItemFilter(bool GNGKKJPOAPJ, List<(StoreItemsConfig.HJJMICEOAOM, bool)> MEADEDFNOMJ, int GMEHLIHLGEH)
		{
		}

		private void FMJGIDMJEHM()
		{
		}

		private void HGKABFFIKJO()
		{
		}

		private bool IMNOOBOEMND(EOKBGGOAFLF ONCGIPFNENB)
		{
			return false;
		}

		private bool MMPFIOLHFJJ(EOKBGGOAFLF ONCGIPFNENB)
		{
			return false;
		}

		private bool GFHAFABHGOI(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool GFEIGHEFGGF(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool FDLDFCCHFDA(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool PMFLJEPHLKM(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool IBMCDCHPKJA(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool BNNJPLEHEDL(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool GDPIPDDJFKE(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool EAJEKILDHND(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool JMODOJDCGCM(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool GGNAIBBAOEC(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool IOKGKCBPAEK(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool HMLAMJCOCDE(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool JFAHFKMBGKC(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool LPPAKCLJNHN(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool OEDAIADCIEM(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool MNNIPPMGIEO(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool MHBLBCGDCDC(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool JLIDDPLFLBN(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool IFHFNAPBKJH(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool MHFCPIMDILB(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private bool MDPHJADEIGB(DBFJJLIGAFA ONCGIPFNENB)
		{
			return false;
		}

		private void AMMCHFLPMJD()
		{
		}

		[CompilerGenerated]
		private int AMDHCOJLMGF(EOKBGGOAFLF ONCGIPFNENB)
		{
			return 0;
		}
	}
}
