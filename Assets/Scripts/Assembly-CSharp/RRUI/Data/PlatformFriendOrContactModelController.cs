using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RRUI.Data
{
	public class PlatformFriendOrContactModelController : ModelController<PlatformFriendOrContactModel>
	{
		[Serializable]
		private class PlatformNameTextImpl : TextControllerImpl<PlatformFriendOrContactModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PlatformDescriptiveTextImpl : TextControllerImpl<PlatformFriendOrContactModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InviteButtonTextImpl : TextControllerImpl<PlatformFriendOrContactModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MainImageImpl : RawImageControllerImpl<PlatformFriendOrContactModel>
		{
			[SerializeField]
			private Texture defaultTexture;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void NOPJPIEKDHD(Texture2D CIONKGJFLOB)
			{
			}

			[CompilerGenerated]
			private void BOLGPDCIPKO(string GADDGJANIGG)
			{
			}
		}

		[Serializable]
		private class InviteButtonImpl : ButtonControllerImpl<PlatformFriendOrContactModel>
		{
			[SerializeField]
			private PlatformFriendOrContactListModel listModel;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CodeTypeCodeAndUrlFromUriImpl : FromUriControllerImpl<PlatformFriendOrContactModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfNoDescriptiveTextImpl : HideableControllerImpl<PlatformFriendOrContactModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfImageNotSupportedImpl : HideableControllerImpl<PlatformFriendOrContactModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
