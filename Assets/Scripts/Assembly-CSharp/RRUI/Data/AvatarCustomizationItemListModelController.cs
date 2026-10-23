using System;
using UnityEngine;

namespace RRUI.Data
{
	public class AvatarCustomizationItemListModelController : ModelController<AvatarCustomizationItemListModel>
	{
		[Serializable]
		private class CustomAvatarItemsHideableImpl : HideableControllerImpl<AvatarCustomizationItemListModel>
		{
			private DCFGCHBJPOO recnetCustomAvatarItems;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class OutfitItemCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<AvatarCustomizationItemListModel, OutfitItemModel, OutfitItemModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, OutfitItemModel AICINKBCNFA, JLOCLGGLOPP BNFHIAFFDIM)
			{
			}
		}
	}
}
