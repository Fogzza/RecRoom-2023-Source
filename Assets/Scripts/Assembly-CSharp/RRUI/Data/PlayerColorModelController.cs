using System;
using RRUI.Theme;
using UnityEngine;

namespace RRUI.Data
{
	public class PlayerColorModelController : ModelController<PlayerColorModel>
	{
		[Serializable]
		private class PlayerColorTextColorController : TextControllerImpl<PlayerColorModel>, global::MIGMIFNKAII<HBEMJBHCCHB, Color>
		{
			[SerializeField]
			private PlayerColorModel.IIPICLIGPBA _colorType;

			[SerializeField]
			private Color customTextColor;

			[SerializeField]
			private GraphicTheme theme;

			[SerializeField]
			private bool useThemeColor;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RecRoomPlusFontController : ControllerImplementation<PlayerColorModel>, global::MFKLLBLDGMH<HBEMJBHCCHB>
		{
			[SerializeField]
			private LabelTheme labelTheme;

			[SerializeField]
			private EKICPBBABHC normalFont;

			[SerializeField]
			private EKICPBBABHC recRoomPlusFont;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PlayerColorImageColorController : ImageControllerImpl<PlayerColorModel>, global::MIGMIFNKAII<HBEMJBHCCHB, Color>
		{
			[SerializeField]
			private PlayerColorModel.IIPICLIGPBA _colorType;

			[SerializeField]
			private Color customColor;

			[SerializeField]
			private UIGradient customImageGradient;

			[SerializeField]
			private GraphicTheme theme;

			[SerializeField]
			private bool useThemeColor;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
