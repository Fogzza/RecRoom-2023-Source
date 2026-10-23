using System;
using UnityEngine;

namespace RRUI.Data
{
	public class EmojiPickerModelController : ModelController<EmojiPickerModel>
	{
		[Serializable]
		private class ClearEmojiButton : ButtonControllerImpl<EmojiPickerModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideClearEmojiIfUnsupportedImpl : HideableControllerImpl<EmojiPickerModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InitializeEmojiPickerImpl : ControllerImplementation<EmojiPickerModel>
		{
			[SerializeField]
			private EmojiPicker emojiPicker;

			public override bool OnModelChangedCanBeQueued => false;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
