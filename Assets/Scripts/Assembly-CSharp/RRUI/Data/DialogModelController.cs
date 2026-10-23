using System;
using RRUI.Dialogs;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class DialogModelController : ModelController<BaseDialogModel>
	{
		[Serializable]
		private class TitleTextImpl : TextControllerImpl<BaseDialogModel>
		{
			private string _defaultText;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MessageTextImpl : TextControllerImpl<FBJENEJAKPP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PrimaryButtonImpl : ButtonControllerImpl<FBJENEJAKPP>
		{
			[SerializeField]
			protected TextMeshProUGUI label;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SecondaryButtonImpl : ButtonControllerImpl<ODDIIIPFHGP>
		{
			[SerializeField]
			protected TextMeshProUGUI label;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TertiaryButtonImpl : ButtonControllerImpl<LBDLMHNOBEL>
		{
			[SerializeField]
			protected TextMeshProUGUI label;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class QuaternaryButtonImpl : ButtonControllerImpl<CNMDPKGECHP>
		{
			[SerializeField]
			protected TextMeshProUGUI label;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfCanNotGoToDefaultRoomImpl : HideableControllerImpl<BaseDialogModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
