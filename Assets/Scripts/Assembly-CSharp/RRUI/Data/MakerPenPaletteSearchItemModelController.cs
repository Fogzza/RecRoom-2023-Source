using System;
using RecRoom.Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RRUI.Data
{
	internal class MakerPenPaletteSearchItemModelController : ModelController<MakerPenPaletteSearchItemModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class NoActionButtonImpl : ToggleControllerImpl<MakerPenPaletteSearchItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UIHandleDragController : UIHandleDecoratorControllerImpl<MakerPenPaletteSearchItemModel>
		{
			private bool canStartDrag;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void PJGBMFHBEIO(PointerEventData OEPDOIOJPHD)
			{
			}

			protected override void BLOEAHFNKGI(PointerEventData OEPDOIOJPHD)
			{
			}

			protected override void OFKPEIELNKN(UIHandleDecorator.UIHandleEventData OEPDOIOJPHD)
			{
			}
		}

		[Serializable]
		private class PaletteSearchCard_QuantityText : TextControllerImpl<MakerPenPaletteSearchItemModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PaletteSearchItemToCardImpl : ToCardControllerImpl<MakerPenPaletteSearchItemModel>
		{
			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class PaletteSearchCard_Icon : ImageControllerImpl<MakerPenPaletteSearchItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PaletteSearchCard_ShapeDynamicResolution : ImposterRawImageControllerImpl<MakerPenPaletteSearchItemModel>
		{
			[SerializeField]
			private int customSize;

			[SerializeField]
			private int antiAliasing;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PaletteSearchCard_HideIfNoIcon : HideableControllerImpl<MakerPenPaletteSearchItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PaletteSearchCard_HideIfNotBetaItem : HideableControllerImpl<MakerPenPaletteSearchItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PaletteSearchCard_HideIfNotLimitedQuantity : HideableControllerImpl<MakerPenPaletteSearchItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PaletteSearchCard_HideIfRemainingQuantity : HideableControllerImpl<MakerPenPaletteSearchItemModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
