using System;
using RRUI.Dialogs;
using RRUI.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class DialogListModelController : ModelController<DialogListModel>
	{
		[Serializable]
		private class TestButtonImpl : ButtonControllerImpl<DialogListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowInfoText : ButtonControllerImpl<DialogListModel>
		{
			[SerializeField]
			public Sprite infoTextDialogSpriteOverride;

			[SerializeField]
			private TextMeshProUGUI inheritTitleFromText;

			[SerializeField]
			private string infoTextTitle;

			[SerializeField]
			private LocalizedString infoTextTitleLocalized;

			[SerializeField]
			[Multiline]
			private string infoText;

			[SerializeField]
			private LocalizedString infoTextLocalized;

			[SerializeField]
			private ButtonTheme buttonTheme;

			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
