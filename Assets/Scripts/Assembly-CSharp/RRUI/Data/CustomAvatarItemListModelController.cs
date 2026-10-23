using System;
using UnityEngine;

namespace RRUI.Data
{
	public class CustomAvatarItemListModelController : ModelController<CustomAvatarItemListModel>
	{
		[Serializable]
		private class FromStoreFeaturedListImpl : FromUriControllerImpl<CustomAvatarItemListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class FromCreatorIdUriImpl : FromUriControllerImpl<CustomAvatarItemListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfShowingLocalAccountAvatarItemsImpl : HideableControllerImpl<CustomAvatarItemListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingRemoteAccountAvatarItemsImpl : HideableControllerImpl<CustomAvatarItemListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CustomAvatarItemListLinkImpl : LinkControllerImpl<CustomAvatarItemListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchTabLinkImpl : LinkControllerImpl<CustomAvatarItemListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfEmptyImpl : HideableControllerImpl<CustomAvatarItemListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CustomAvatarItemListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<CustomAvatarItemListModel, CustomAvatarItemModel, CustomAvatarItemModelController>
		{
			[SerializeField]
			private PJGPBJDBNEK.BDOPNLLKBPB entrypointName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, CustomAvatarItemModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}

		[Serializable]
		private class CustomAvatarItemMirrorStoreCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<CustomAvatarItemListModel, CustomAvatarItemStoreModel, CustomAvatarItemStoreModelController>
		{
			[SerializeField]
			private PJGPBJDBNEK.BDOPNLLKBPB entrypointName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, CustomAvatarItemStoreModel EPNCEKGIABC, JLOCLGGLOPP PBDIPMFIDNG)
			{
			}
		}
	}
}
