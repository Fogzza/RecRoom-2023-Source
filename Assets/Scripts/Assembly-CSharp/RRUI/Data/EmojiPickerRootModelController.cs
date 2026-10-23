using System;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class EmojiPickerRootModelController : ModelController<EmojiPickerRootModel>
	{
		[Serializable]
		private class ShowEmojiPickerImpl : ButtonControllerImpl<EmojiPickerRootModel>
		{
			[SerializeField]
			private TMP_InputField inputField;

			[SerializeField]
			private CanvasPositioner.CanvasPositionerPlacement emojiPickerPlacement;

			[SerializeField]
			private string analyticsContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private void OHKLJILDNPJ(string IODMDDBIFEI)
			{
			}
		}

		[Serializable]
		private class HideIfEmojisNotAllowedImpl : HideableControllerImpl<EmojiPickerRootModel>
		{
			[SerializeField]
			private TMP_Text textField;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void IJJCHPBGKFE()
			{
			}

			private void MPKGANHDPBD()
			{
			}
		}
	}
}
