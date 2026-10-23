using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RecRoom.Avatars;
using RecRoom.Avatars.Data.Runtime;
using RecRoom.Avatars.Data.Shared;

namespace RRUI.Data
{
	public class OutfitItemModel : AvatarCustomizationDependentModel
	{
		private sealed class NDKHAJGJIJJ
		{
			public OutfitItemModel _003C_003E4__this;

			public DIGIMEFFGDC browsableAvatarItem;

			internal void _003CLoadItemDataAsync_003Eb__0(JHHDMDHLNGF data)
			{
			}
		}

		public const string NONE_DESC = "NONE_EQUIPPED_IN_THIS_SLOT";

		public const string VIEW_FEATURED_CUSTOM_CLOTHING_STORE_DESC = "VIEW_FEATURED_CUSTOM_CLOTHING_STORE";

		public const string SPAWN_CLOTHING_CUSTOMIZER_TOOL_DESC = "SPAWN_CLOTHING_CUSTOMIZER_TOOL";

		private string PEFBPEEMFGG;

		private OutfitType CKFGOEMNNKD;

		private AvatarItemSidednessEquipType PFGFAOPNLIN;

		private AvatarItemSidednessEquipType OBOIFFOAPCE;

		private FHPHMBKPLCC ABLKIEJAICA;

		private bool AJALFEHHFHN;

		private readonly List<string> NBLGIOPEDCP;

		private AnchorParams LBKKAHCCGCG;

		private CLMEHHLKBJG PNMIBHIAIKN;

		private bool MCABCPCDGEL;

		private bool HBEBBPBJEKJ;

		private global::EHOCIICLNGN<JHHDMDHLNGF> FFLHBOPABGK;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

private string CDOMKEBEMOA
{
get 		{
			return null;
		}

set {
		}
}

public OutfitType OutfitType
{
get 		{
			return OutfitType.Hat;
		}

private set {
		}
}

private AvatarItemSidednessEquipType BBOPIACCLFC
{
get 		{
			return AvatarItemSidednessEquipType.Left;
		}

set {
		}
}

private AvatarItemSidednessEquipType MIPAABIEGPG
{
get 		{
			return AvatarItemSidednessEquipType.Left;
		}

set {
		}
}

private FHPHMBKPLCC BFIHDLMNJMB
{
get 		{
			return FHPHMBKPLCC.None;
		}

set {
		}
}

public bool IsEquipped
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsNoneItem
{
get 		{
			return false;
		}

}

public bool IsStoreLink
{
get 		{
			return false;
		}

}

public bool IsCustomClothingStoreLink
{
get 		{
			return false;
		}

}

public bool IsClothingCustomizerToolLink
{
get 		{
			return false;
		}

}

public bool IsBrowsableAvatarItem
{
get 		{
			return false;
		}

}

public bool IsEmpty
{
get 		{
			return false;
		}

}

public DIGIMEFFGDC BrowsableAvatarItem
{
get 		{
			return null;
		}

}

public bool IsCustomShirt
{
get 		{
			return false;
		}

}

private bool MOKGAKIHNNG
{
get 		{
			return false;
		}

}

public bool IsFeet
{
get 		{
			return false;
		}

}

public bool IsHair
{
get 		{
			return false;
		}

}

public bool IsBeard
{
get 		{
			return false;
		}

}

public bool IsHat
{
get 		{
			return false;
		}

}

public bool IsAdjustableHat
{
get 		{
			return false;
		}

}

private AnchorParams NMOONADGDFD
{
get 		{
			return default;
		}

set {
		}
}

private CLMEHHLKBJG AKJOANAAGNJ
{
get 		{
			return null;
		}

set {
		}
}

		public string GetItemShortName()
		{
			return null;
		}

		public void Set(string ELDKAMCLDON, OutfitType EHGPLLEIIBB, AvatarItemSidednessEquipType FFAINMOOEOO, FHPHMBKPLCC OCNGKLDCJKG)
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

		private LAHBDKNMNHN KEKEJBPJFBC()
		{
			return null;
		}

		private void HGMCEGKLEIG()
		{
		}

		public void EquipItem()
		{
		}

		public void UnequipItem()
		{
		}

		public void GoToAdjustPage()
		{
		}

		public void GoToConfigureHairPage()
		{
		}

		public void GoToConfigureBeardPage()
		{
		}

		public void GoToCustomAvatarItemFeaturedPage()
		{
		}

		public string GetCustomizerCardText()
		{
			return null;
		}

		public void SpawnOrRecallClothingCustomizerTool()
		{
		}

		[CompilerGenerated]
		private bool LAGAGIECGJO(AvatarItemSelection MPLIANHHNHG)
		{
			return false;
		}

		[CompilerGenerated]
		private bool MIPJKBGJECB(AvatarItemSelection MPLIANHHNHG)
		{
			return false;
		}

		[CompilerGenerated]
		private bool JLFCDIMJCFE(AvatarItemSelection MPLIANHHNHG)
		{
			return false;
		}
	}
}
