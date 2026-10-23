using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RecRoom.Core.Storefronts;
using RecRoom.Systems;
using RecRoom.Systems.PlayerRoles;

namespace RRUI.Data
{
	public class UGCStorefrontModel : FilterableListModel<UGCStorefrontModel.MJCAAAJKFED, UGCStorefrontModel.MJCAAAJKFED, BBEGCPACHAD>
	{
		public class MJCAAAJKFED : IEquatable<MJCAAAJKFED>
		{
			private IEGDEBEMAPJ CEDMEBEJLPH;

			private EGLJLFNLOGJ JJPAPANGBLL;

public IEGDEBEMAPJ EBKGALHBBKG
{
get 			{
				return null;
			}

private set {
			}
}

public EGLJLFNLOGJ OPECFMHMHIO
{
get 			{
				return null;
			}

private set {
			}
}

public CCMLCGONCIE DJCHMIBLOEI
{
get 			{
				return null;
			}

}

			public MJCAAAJKFED(IEGDEBEMAPJ HMNGGCICHOM, EGLJLFNLOGJ GEAGKLNBNHD)
			{
			}

			public bool Equals(MJCAAAJKFED HNPEBINPOBO)
			{
				return false;
			}

			public override bool Equals(object ICHBECDKHOJ)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public class GNPEBNOFCFI
		{
			private List<IEGDEBEMAPJ> FDOKCBILELP;

			private UGCStorefront ABLKIEJAICA;

public List<IEGDEBEMAPJ> JGKPMFIEPJL
{
get 			{
				return null;
			}

set {
			}
}

public UGCStorefront BFIHDLMNJMB
{
get 			{
				return null;
			}

set {
			}
}

public EOMIAFKMMOH FKGDLCBGLCJ
{
get 			{
				return null;
			}

set {
			}
}

			public GNPEBNOFCFI(UGCStorefront OCNGKLDCJKG)
			{
			}

			public bool KMODKLOODKN(IEGDEBEMAPJ BPBBBCMGPOG)
			{
				return false;
			}

			public bool JCJFCNDCFIE(int GMEHLIHLGEH)
			{
				return false;
			}

			public bool CKPNEIGMABF(int GMEHLIHLGEH)
			{
				return false;
			}

			public bool DIMIOEGEGNL(int GMEHLIHLGEH, IEGDEBEMAPJ BPBBBCMGPOG)
			{
				return false;
			}

			public void MLEEKBGGFOF()
			{
			}
		}

		public class IEGDEBEMAPJ
		{
			private string DOCNGOPPMFJ;

			private AFKNPCNMFMC IAEIIGDMGKK;

			private GNPEBNOFCFI FGGFOBHCJFP;

			private List<MJCAAAJKFED> JDFKGLAGFDE;

public string IMGKBGDGBMN
{
get 			{
				return null;
			}

set {
			}
}

public AFKNPCNMFMC BOODPKHMEKE
{
get 			{
				return null;
			}

private set {
			}
}

public GNPEBNOFCFI OMIDLABGGFB
{
get 			{
				return null;
			}

private set {
			}
}

public List<MJCAAAJKFED> NNFAPLLJADE
{
get 			{
				return null;
			}

private set {
			}
}

public UGCStorefront BFIHDLMNJMB
{
get 			{
				return null;
			}

}

			public IEGDEBEMAPJ(string BKLDPNCEDGE, GNPEBNOFCFI DGHOEPGOKBH)
			{
			}

			public IEGDEBEMAPJ(AFKNPCNMFMC IEPCHKDKLAO, GNPEBNOFCFI DGHOEPGOKBH)
			{
			}

			public void MLEEKBGGFOF()
			{
			}

			public bool AALMCPKNHJL(MJCAAAJKFED KNFCCFOFDOL)
			{
				return false;
			}

			public bool JMBCKNFPLBF(MJCAAAJKFED KNFCCFOFDOL)
			{
				return false;
			}

			public bool FCEMKJKCJAF(int GMEHLIHLGEH, MJCAAAJKFED KNFCCFOFDOL)
			{
				return false;
			}
		}

		private sealed class MLDGCKEBOLG
		{
			public UGCStorefrontModel _003C_003E4__this;

			public Action onConfirmDelete;

			internal void _003CShowConfirmDeleteDialog_003Eb__1()
			{
			}

			internal void _003CShowConfirmDeleteDialog_003Eb__2()
			{
			}

			internal void _003CShowConfirmDeleteDialog_003Eb__0(BaseDialogModel<IPGOOJIFBAB> dialog)
			{
			}
		}

		private sealed class KELAKBHLMLA
		{
			public string currentNameText;

			public UGCStorefrontModel _003C_003E4__this;

			public MessageWithInputFieldDialogModel activeDialog;

			public Action _003C_003E9__3;

			public Action<GMBCDOMHMFF.HLMOCMHMIEN> _003C_003E9__2;

			internal void _003CShowEditNameDialog_003Eb__1()
			{
			}

			internal void _003CShowEditNameDialog_003Eb__2(GMBCDOMHMFF.HLMOCMHMIEN result)
			{
			}

			internal void _003CShowEditNameDialog_003Eb__3()
			{
			}

			internal void _003CShowEditNameDialog_003Eb__4()
			{
			}

			internal string _003CShowEditNameDialog_003Eb__5()
			{
				return null;
			}

			internal void _003CShowEditNameDialog_003Eb__6(string s)
			{
			}

			internal void _003CShowEditNameDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}
		}

		public const string UGC_STOREFRONT_KEY = "UGCStorefront";

		public const string UGC_STOREFRONT_SOURCE_KEY = "UGCStorefrontSource";

		private const string BHFPDBJJCJP = "Carousel Name Goes Here";

		public static readonly int INVALID_CAROUSEL_INDEX;

		public const byte UGC_STOREFRONT_CAROUSEL_CHAR_LIMIT = 80;

		private const int KBKBMNKPLGN = 10;

		private const int PDBFEELNIMG = 50;

		public BBEGCPACHAD TypeFilter;

		private UGCStorefront EOKKJCFCPND;

		public int CarouselIndex;

		public UGCPurchasableItemsManager.GFGOGCKNPFH StorefrontSource;

		private CGOPOAFDIDN AAKFKPKFDJJ;

		private IPGOOJIFBAB JAGBBAKEIHB;

		private MessageDialogModel KMKOKJHLMDH;

		private GNPEBNOFCFI MICPFPKLLJI;

public UGCStorefront UGCStorefront
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsConfigured
{
get 		{
			return false;
		}

}

public bool IsConfigurableByCurrentPlayer
{
get 		{
			return false;
		}

}

public int CarouselCount
{
get 		{
			return 0;
		}

}

public IEGDEBEMAPJ FeaturedModificationDataStoreCarousel
{
get 		{
			return null;
		}

}

public IEGDEBEMAPJ CurrentModificationDataStoreCarousel
{
get 		{
			return null;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public List<IEGDEBEMAPJ> Carousels
{
get 		{
			return null;
		}

}

public IEGDEBEMAPJ ModificationDataCurrentCarousel
{
get 		{
			return null;
		}

}

		protected override MJCAAAJKFED EIDFFKOOKDK(MJCAAAJKFED GPPHKHEOOON)
		{
			return null;
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<MJCAAAJKFED>> LFFEHHGOFFN()
		{
			return null;
		}

		private bool PFAHAKPENDO(BBEGCPACHAD HNGJGPJCNBJ, MJCAAAJKFED ONCGIPFNENB)
		{
			return false;
		}

		public void SetTypeFilter(BBEGCPACHAD HNGJGPJCNBJ)
		{
		}

		public void Set(UGCStorefront GOCAALDGNKB, UGCPurchasableItemsManager.GFGOGCKNPFH GLLFHCCFIGK)
		{
		}

		public void Set(UGCStorefront GOCAALDGNKB, UGCPurchasableItemsManager.GFGOGCKNPFH GLLFHCCFIGK, int JMGGCIHEJNN)
		{
		}

		public void SetupModel(UGCStorefront GOCAALDGNKB)
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		public bool CarouselCanMoveUp()
		{
			return false;
		}

		public bool CarouselCanMoveDown()
		{
			return false;
		}

		private bool MDGJKIOOPHL(int DGPALBLAIFC)
		{
			return false;
		}

		public void MoveCarouselUp()
		{
		}

		public void MoveCarouselDown()
		{
		}

		private void GLFPGGMPILN(int JMGGCIHEJNN, int DGPALBLAIFC)
		{
		}

		public bool ItemCanMoveUpInCarousel(MJCAAAJKFED KNFCCFOFDOL)
		{
			return false;
		}

		public bool ItemCanMoveDownInCarousel(MJCAAAJKFED KNFCCFOFDOL)
		{
			return false;
		}

		public bool ItemCanMoveInCarousel(MJCAAAJKFED KNFCCFOFDOL, int DGPALBLAIFC)
		{
			return false;
		}

		public void MoveItemUpInCarousel(MJCAAAJKFED KNFCCFOFDOL)
		{
		}

		public void MoveItemDownInCarousel(MJCAAAJKFED KNFCCFOFDOL)
		{
		}

		private void FHHGOAKCAFG(MJCAAAJKFED KNFCCFOFDOL, int DGPALBLAIFC)
		{
		}

		public void RemoveCarousel()
		{
		}

		public int AddCarousel()
		{
			return 0;
		}

		public bool CanAddCarousel()
		{
			return false;
		}

		public void AddCarouselAndGoToAddItems()
		{
		}

		public bool CanAddPurchasableItem()
		{
			return false;
		}

		public bool PurchasableItemIsInCarousel(MJCAAAJKFED KNFCCFOFDOL)
		{
			return false;
		}

		public void AddOrRemoveFromCarousel(MJCAAAJKFED KNFCCFOFDOL)
		{
		}

		public void SetCarouselName(string INIOBIJJMJP)
		{
		}

		public void InitializeModificationData()
		{
		}

		public void DebugPrint()
		{
		}

		public void DebugPrintCarousel(IEGDEBEMAPJ BPBBBCMGPOG)
		{
		}

		public void ShowAddItemsDialog()
		{
		}

		public void ShowConfirmDeleteDialog(Action CIMJPOEPGNG)
		{
		}

		public void ShowEditNameDialog()
		{
		}

		public void UpdateStorefrontModel()
		{
		}

		private void MMGPNPCHCPP(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		private void NPEEOEMNBCI(CHILKDJABBF EKOFNPFCLMO, GameRole DGNFCCOMMEL)
		{
		}

		private void LOGCDMFMOCI(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		public bool CarouselIsValid()
		{
			return false;
		}

		public bool CarouselIndexIsValid(int JMGGCIHEJNN)
		{
			return false;
		}

		public string GetCarouselName()
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<ReadOnlyCollection<MJCAAAJKFED>> PKAFGKMAGJK()
		{
			return null;
		}

		[CompilerGenerated]
		private void LIPKGPLOMNI()
		{
		}
	}
}
