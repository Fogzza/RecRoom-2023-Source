using System;
using RRUI.Dialogs;
using UnityEngine;

namespace RRUI.Data
{
	public class MessageWithInputFieldDialogModelController : ModelController<MessageWithInputFieldDialogModel>
	{
		[Serializable]
		private class SpawnDialogImpl : ButtonControllerImpl<MessageWithInputFieldDialogModel>
		{
			private sealed class HONAEHNKECI
			{
				public MessageWithInputFieldDialogModel messageDialogModel;

				public string test;

				internal void _003COnButtonClicked_003Eb__3()
				{
				}

				internal string _003COnButtonClicked_003Eb__1()
				{
					return null;
				}

				internal void _003COnButtonClicked_003Eb__2(string value)
				{
				}

				internal void _003COnButtonClicked_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialogModel)
				{
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PlaceholderTextImpl : TextControllerImpl<MessageWithInputFieldDialogModel>
		{
			[SerializeField]
			private string defaultPlaceholder;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MainInputFieldImpl : InputFieldControllerImpl<MessageWithInputFieldDialogModel>
		{
			[NonSerialized]
			private uint lastRefreshVersion;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}
	}
}
