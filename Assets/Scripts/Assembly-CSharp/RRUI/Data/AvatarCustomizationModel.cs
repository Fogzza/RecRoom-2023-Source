using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Avatars;
using RecRoom.Avatars.Data.Runtime;
using RecRoom.Avatars.Data.Shared;
using RecRoom.Avatars.Face;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class AvatarCustomizationModel : AvatarModel
	{
		public enum BFHCKNOGMBF
		{
			Style = 0,
			Color = 1
		}

		public enum BALDMALDHPO
		{
			FaceShape = 0,
			Eyes = 1,
			Mouth = 2,
			Ears = 3,
			BodyShape = 4,
			SkinColor = 5
		}

		public enum MIGLCBFOEKE
		{
			BothHands = 0,
			LeftHand = 1,
			RightHand = 2
		}

		public enum FHLHONNBJHH
		{
			Hats = 0,
			Glasses = 1,
			Earrings = 2
		}

		public enum FPOGPHAHDPA
		{
			Clothes = 0,
			Shoulders = 1,
			Necklaces = 2,
			Belts = 3,
			CustomShirts = 4
		}

		public enum OCAGFNOGIBG
		{
			Shirts = 0
		}

		public enum JLEFPDEHLAI
		{
			MyItems = 0,
			ShowOnlyItemsIOwn = 1,
			Filters = 2,
			Featured = 3,
			Name_AToZ = 4,
			Name_ZToA = 5,
			Stars_5To1 = 6,
			Stars_1To5 = 7,
			Price_LowToHigh = 8,
			Price_HighToLow = 9,
			Sorting = 10,
			Reset = 11,
			OK = 12,
			Owned = 13
		}

		private sealed class PHEMILJPFLK
		{
			public List<EOKBGGOAFLF> giftDrops;

			public global::PHLHFLLLDLK<HGKINAOMNIF> promise;

			public FHPHMBKPLCC storefrontEntryPoint;

			public bool showWarning;

			public Func<EOKBGGOAFLF, bool> _003C_003E9__5;

			public Action _003C_003E9__15;

			public Action<string> _003C_003E9__16;

			internal void _003CHandleTrialItems_003Eb__2(FFGPLFHAGKC sf)
			{
			}

			internal bool _003CHandleTrialItems_003Eb__5(EOKBGGOAFLF storeGiftDrop)
			{
				return false;
			}

			internal void _003CHandleTrialItems_003Eb__15()
			{
			}

			internal void _003CHandleTrialItems_003Eb__16(string _)
			{
			}
		}

		private sealed class CLLBEIAOMMD
		{
			public EDDPDJCKOBH.GMBCAMAAPMN package;

			internal LAHBDKNMNHN _003CHandleTrialItems_003Eb__3()
			{
				return null;
			}
		}

		private sealed class JCPEFNCMDPO
		{
			public List<EOKBGGOAFLF> allItems;

			public CheckoutDialogModel checkoutDialogModel;

			public HCLDBKDHKLE costInfo;

			public bool isLocalPlayerRRPlusMember;

			public bool isShowingPurchaseResults;

			public LJJIHDDNLNB checkoutDialogData;

			public PHEMILJPFLK CS_0024_003C_003E8__locals1;

			public Action _003C_003E9__17;

			internal void _003CHandleTrialItems_003Eb__7(int index, CardModel cardModel, StoreItemModel storeItemModel, JLOCLGGLOPP storeItemToCardController)
			{
			}

			internal void _003CHandleTrialItems_003Eb__8()
			{
			}

			internal void _003CHandleTrialItems_003Eb__17()
			{
			}

			internal void _003CHandleTrialItems_003Eb__9()
			{
			}

			internal void _003CHandleTrialItems_003Eb__10(CheckoutDialogModel dialogModel)
			{
			}
		}

		private sealed class KIIGJOHAAFC
		{
			public int index;

			public JCPEFNCMDPO CS_0024_003C_003E8__locals2;

			internal void _003CHandleTrialItems_003Eb__12()
			{
			}
		}

		private sealed class JMLOIELFJLK
		{
			public DialogListModel dialogListModel;

			public JCPEFNCMDPO CS_0024_003C_003E8__locals3;

			internal void _003CHandleTrialItems_003Eb__14(HMFCKFAKBID.LKOMOOHBHBJ purchaseResults)
			{
			}
		}

		private const int DDONGHHDHCI = 10;

		[SerializeField]
		private DIGIMEFFGDC.DBCAKOOBLMA defaultOwnershipFilter;

		[SerializeField]
		private DIGIMEFFGDC.DBKMGOBDOOH defaultSorting;

		[SerializeField]
		private BrowserModel customizationBrowser;

		[SerializeField]
		private Route customizeMainRoute;

		[SerializeField]
		private Route customizeEyeRoute;

		[SerializeField]
		private Route customizeMouthRoute;

		[SerializeField]
		private Route customizeHatRoute;

		[SerializeField]
		private Route customizeCompleteRoute;

		[SerializeField]
		private Route customizeHairRoute;

		[SerializeField]
		private Route customizeBeardRoute;

		[SerializeField]
		private Route customAvatarItemFeaturedRoute;

		[SerializeField]
		private Route customAvatarItemStoreRoute;

		private readonly global::ADIBECMODCM<DCLIAIDLPOI> CMCOGOFJIDF;

		public static readonly EEANDDJEMJC AvatarFaceChangedEvent;

		public static readonly EEANDDJEMJC AvatarBodyChangedEvent;

		public static readonly EEANDDJEMJC AvatarHairOrBeardColorChangedEvent;

		public static readonly EEANDDJEMJC AvatarRandomizedEvent;

		public static readonly EEANDDJEMJC AvatarUndoEvent;

		public static readonly EEANDDJEMJC AvatarRedoEvent;

		public static readonly global::HHOBPMOCKMJ<OutfitType> AvatarItemChangedEvent;

		public static readonly global::HHOBPMOCKMJ<OutfitType> AvatarItemUnequippedEvent;

		private readonly Lazy<CFHGAIBGHDH> EDBLLLCFNOE;

		private BALDMALDHPO ELBECFOCAFH;

		private BFHCKNOGMBF AOAFLMBICGP;

		private BFHCKNOGMBF ICCAFANLIOK;

		private MIGLCBFOEKE LNMLOMCJJHM;

		private FHLHONNBJHH GOFMCMHPMOK;

		private FPOGPHAHDPA GLLIBOMDEMJ;

		private OCAGFNOGIBG CIOEHIBGBHJ;

		private DIGIMEFFGDC.DBKMGOBDOOH LLBPJMMFLAD;

		private DIGIMEFFGDC.DBCAKOOBLMA MABEOOBEJNN;

		private string DNAINFMPINO;

		private bool FOCKCIIHBMA;

		private CLMEHHLKBJG OKDDELBEIEL;

		private AnchorParams EJBJLIAHDPM;

		private bool BLCHNHNCFDB;

		private bool HNACMKBINDD;

		private DynamicUIDialogModel NIDILDIDKBE;

		private DHAPPKCJJCA HNBBOFOCBKP;

		private DynamicUIDialogModel BLIFCDAAMKM;

		private DHAPPKCJJCA LOIJDCDAOIN;

private CFHGAIBGHDH PFHPBLLNOKG
{
get 		{
			return null;
		}

}

public bool HasActiveBundleTrialWithOutfitOrDye
{
get 		{
			return false;
		}

}

public BALDMALDHPO FaceCategory
{
get 		{
			return BALDMALDHPO.FaceShape;
		}

set {
		}
}

public BFHCKNOGMBF HairCategory
{
get 		{
			return BFHCKNOGMBF.Style;
		}

set {
		}
}

public BFHCKNOGMBF FacialHairCategory
{
get 		{
			return BFHCKNOGMBF.Style;
		}

set {
		}
}

public MIGLCBFOEKE HandCategory
{
get 		{
			return MIGLCBFOEKE.BothHands;
		}

set {
		}
}

public FHLHONNBJHH HeadCategory
{
get 		{
			return FHLHONNBJHH.Hats;
		}

set {
		}
}

public FPOGPHAHDPA TorsoCategory
{
get 		{
			return FPOGPHAHDPA.Clothes;
		}

set {
		}
}

public OCAGFNOGIBG CustomCategory
{
get 		{
			return OCAGFNOGIBG.Shirts;
		}

set {
		}
}

public DIGIMEFFGDC.DBKMGOBDOOH Sorting
{
get 		{
			return (DIGIMEFFGDC.DBKMGOBDOOH)0;
		}

set {
		}
}

public DIGIMEFFGDC.DBCAKOOBLMA OwnershipFilter
{
get 		{
			return DIGIMEFFGDC.DBCAKOOBLMA.None;
		}

set {
		}
}

public string SearchQuery
{
get 		{
			return null;
		}

set {
		}
}

public bool IsSearchActive
{
get 		{
			return false;
		}

set {
		}
}

public bool ShowLockedItems
{
get 		{
			return false;
		}

}

public CLMEHHLKBJG CurrentHatAnchorRestrictions
{
get 		{
			return null;
		}

private set {
		}
}

public AnchorParams CurrentHatAnchorParams
{
get 		{
			return default;
		}

private set {
		}
}

public bool IsHatAdjustable
{
get 		{
			return false;
		}

private set {
		}
}

public bool InTitleScreenFlow
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsCustomizationComplete
{
get 		{
			return false;
		}

}

public bool CanUndo
{
get 		{
			return false;
		}

}

public bool CanRedo
{
get 		{
			return false;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		public void BuyAll()
		{
		}

		public void Undo()
		{
		}

		public void Redo()
		{
		}

		public void AddUndoStack()
		{
		}

		public void Randomize()
		{
		}

		public void RandomizeHair()
		{
		}

		public void RandomizeBeard()
		{
		}

		public void UnequipOutfitItems(IEnumerable<AvatarItemSelection> JNAAHMPCPAB)
		{
		}

		public void EquipOutfitItem(AvatarItem ONCGIPFNENB, AvatarItemSidednessEquipType FFAINMOOEOO, CLMEHHLKBJG NHCODCCFGBB, AnchorParams NMOONADGDFD)
		{
		}

		public void SetSkinColor(ColorVault.DAKHANMKKFJ HMCAFGCGFJF)
		{
		}

		public void SetHairPrimaryColor(ColorVault.DAKHANMKKFJ HMCAFGCGFJF)
		{
		}

		public void SetHairSecondaryColor(ColorVault.DAKHANMKKFJ HMCAFGCGFJF)
		{
		}

		public void SetHairPattern(AvatarHairPattern CDAJMFEANMG)
		{
		}

		public void SetBeardPrimaryColor(ColorVault.DAKHANMKKFJ HMCAFGCGFJF)
		{
		}

		public void SetBeardSecondaryColor(ColorVault.DAKHANMKKFJ HMCAFGCGFJF)
		{
		}

		public void SetBeardPattern(AvatarHairPattern CDAJMFEANMG)
		{
		}

		public void SetBodyShape(string JMIFIJDBMNM)
		{
		}

		public void SetFaceShape(string JMIFIJDBMNM)
		{
		}

		public void SetFaceFeatureStyle(FaceFeatureType NIFOGEBEDNG, string JMIFIJDBMNM)
		{
		}

		public void GoToCustomizeEyesPage()
		{
		}

		public void GoToCustomizeMouthPage()
		{
		}

		public void GoToCustomizeHatPage(CLMEHHLKBJG KBHCLLHCCCA, AnchorParams NMOONADGDFD, bool MCABCPCDGEL)
		{
		}

		public void GoToCustomizeHairPage()
		{
		}

		public void GoToCustomAvatarItemFeaturedPage()
		{
		}

		public void GoToCustomAvatarItemStorePage(Guid JGNABAMMKMP, PJGPBJDBNEK.BDOPNLLKBPB DMIKNHOOEIG)
		{
		}

		public void GoToCustomizeBeardPage()
		{
		}

		public void CompleteCustomization()
		{
		}

		public void GoBackToCustomizeMainPage()
		{
		}

		private void BGKPJHFGAOE()
		{
		}

		private void ADNIFJGDMCF()
		{
		}

		private void KCBNOKFNIOJ(Locale ICHBECDKHOJ)
		{
		}

		public void TryShowFilterDialogPopUp()
		{
		}

		public void TryShowSortingDialogPopUp()
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private void LDAHJGNJJLO(HHNIABKALDA JOJGDHBJCGL)
		{
		}

		public void TryResolveBundleTrials()
		{
		}

		public static global::NCOKFFGPIJM<HGKINAOMNIF> HandleTrialItems(FHPHMBKPLCC PLCIFNOBJLO, bool DPPBECLBEDP = false)
		{
			return null;
		}

		[CompilerGenerated]
		private void LONFOJGMJHF(HGKINAOMNIF MLDANHIGANI)
		{
		}

		[CompilerGenerated]
		private bool FNDFMDJODHB(RRUI.Navigation.Uri FKFKJOJNCLM)
		{
			return false;
		}

		[CompilerGenerated]
		private bool LCKCIKHMPIG()
		{
			return false;
		}

		[CompilerGenerated]
		private void DNHDCELFAIA(bool IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void FPNOBOJIBCM(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private object JDDNJMOIKGN()
		{
			return null;
		}

		[CompilerGenerated]
		private void JOMIIKPMJNB(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private void AKGMKMNMAHD(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void PEDFFNLLGPD(IINOCBCBDGN NDECALNLBGD)
		{
		}
	}
}
