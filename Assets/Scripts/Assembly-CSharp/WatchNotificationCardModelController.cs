using System;
using RRUI;
using RRUI.Data;
using RRUI.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WatchNotificationCardModelController : ModelController<WatchNotificationCardModel>
{
	[Serializable]
	private class HideIfNoRecNetImageImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoSpriteImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfReadImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoPrimaryActionImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoSecondaryActionImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoBodyTextImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoPrimarySubtextImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class HideIfNoSecondarySubtextImpl : HideableControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class PrimaryActionButtonImpl : ButtonControllerImpl<WatchNotificationCardModel>
	{
		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class SecondaryActionButtonImpl : ButtonControllerImpl<WatchNotificationCardModel>
	{
		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class DismissButtonImpl : ButtonControllerImpl<WatchNotificationCardModel>
	{
		[SerializeField]
		private Hideable buttonHideable;

		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class ImageButtonImpl : ButtonControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class BackgroundButtonImpl : ToggleControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class CheckboxToggleImpl : ToggleControllerImpl<WatchNotificationCardModel>
	{
		[SerializeField]
		private Hideable hideable;

		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}

		protected override void BNFEJGHHHLO()
		{
		}
	}

	[Serializable]
	private class PrimaryTextImpl : TextControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class TimestampTextImpl : TextControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SecondaryTextImpl : TextControllerImpl<WatchNotificationCardModel>
	{
		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class PrimaryActionButtonTextImpl : TextControllerImpl<WatchNotificationCardModel>
	{
		[SerializeField]
		private TextMeshProUGUI buttonText;

		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class PrimaryActionButtonSubtextImpl : TextControllerImpl<WatchNotificationCardModel>
	{
		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SecondaryActionButtonTextImpl : TextControllerImpl<WatchNotificationCardModel>
	{
		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class SecondaryActionButtonSubtextImpl : TextControllerImpl<WatchNotificationCardModel>
	{
		public override bool RefreshWhileInactiveOrHidden => false;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class NotifImageImpl : RecNetRawImageControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class NotifSpriteImpl : ImageControllerImpl<WatchNotificationCardModel>
	{
		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class ResizeImageImpl : ControllerImplementation<WatchNotificationCardModel>
	{
		[SerializeField]
		private RoundedCorners roundedCorners;

		[SerializeField]
		private LayoutElement layoutElement;

		[SerializeField]
		private RectTransform rectTransform;

		[SerializeField]
		private int normalRoundedCornersRadius;

		[SerializeField]
		private int compactRoundedCornersRadius;

		protected override void NGFFCLPHKJN()
		{
		}

		private void ANGHLMACHLE()
		{
		}

		private void FNDFKDKHEKM()
		{
		}
	}

	[Serializable]
	private class ToggleThemeSwitcherImpl : ControllerImplementation<WatchNotificationCardModel>
	{
		[SerializeField]
		private ToggleTheme theme;

		[SerializeField]
		private ANEKOPOIEJE readPalette;

		[SerializeField]
		private ANEKOPOIEJE unreadPalette;

		protected override void NGFFCLPHKJN()
		{
		}
	}

	[Serializable]
	private class LabelThemeSwitcherImpl : ControllerImplementation<WatchNotificationCardModel>
	{
		[SerializeField]
		private LabelTheme theme;

		[SerializeField]
		private EKICPBBABHC readFontPalette;

		[SerializeField]
		private IOMPAPAHEJP readSizePalette;

		[SerializeField]
		private JDOLBJAOGPC readColorPalette;

		[SerializeField]
		private EKICPBBABHC unreadFontPalette;

		[SerializeField]
		private IOMPAPAHEJP unreadSizePalette;

		[SerializeField]
		private JDOLBJAOGPC unreadColorPalette;

		protected override void NGFFCLPHKJN()
		{
		}
	}
}
