using System;
using System.Runtime.CompilerServices;

namespace RRUI.Data
{
	public class UGCPurchasableItemModelController : ModelController<UGCPurchasableItemModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class ImageNameImpl : RecNetRawImageControllerImpl<UGCPurchasableItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ImageSpriteImpl : ImageControllerImpl<UGCPurchasableItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UGCPurchasableItemToCardImpl : ToCardControllerImpl<UGCPurchasableItemModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
