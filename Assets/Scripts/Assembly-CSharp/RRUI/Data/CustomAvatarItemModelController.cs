using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class CustomAvatarItemModelController : ModelController<CustomAvatarItemModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class CustomAvatarItemToReportingModelImpl : ControllerImplementation<CustomAvatarItemModel>
		{
			[SerializeField]
			private CustomAvatarItemReportModel customAvatarItemReportModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EditCustomAvatarItemDetailsButtonImpl : ButtonControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CustomAvatarItemThumbnailRecNetRawImageImpl : RecNetRawImageControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCustomAvatarItemCreatorImpl : HideableControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotCustomAvatarItemCreatorImpl : HideableControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfExistingCustomAvatarItemImpl : HideableControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNewCustomAvatarItemImpl : HideableControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotPublicCustomAvatarItemImpl : HideableControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class NameTextImpl : TextControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PriceTextImpl : TextControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DescriptionTextImpl : TextControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PermissionTextImpl : TextControllerImpl<CustomAvatarItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CustomAvatarItemToCardImpl : ToCardControllerImpl<CustomAvatarItemModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}
		}

		[Serializable]
		private class CustomAvatarItemPreviewPuppetAnimationsImpl : ControllerImplementation<CustomAvatarItemModel>
		{
			[SerializeField]
			private AnimatedPlayerPuppetAvatarModel playerPuppetModel;

			[SerializeField]
			private bool resetToLocalAvatarOnHide;

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void CFDBMCBMALN()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
