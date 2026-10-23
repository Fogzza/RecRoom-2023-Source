using System;
using UnityEngine;

namespace RRUI.Data
{
	public class PasswordlessLoginModelController : ModelController<PasswordlessLoginModel>
	{
		[Serializable]
		private class AuthorizeAnotherDeviceButtonImpl : ButtonControllerImpl<PasswordlessLoginModel>
		{
			[SerializeField]
			private string buttonLocation;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AuthorizeAnotherDeviceBackButtonImpl : ButtonControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AuthorizeAnotherDeviceDialogButtonImpl : ButtonControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PlayOnNewDeviceDialogButtonImpl : ButtonControllerImpl<PasswordlessLoginModel>
		{
			[SerializeField]
			private bool isResendEmailButton;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AuthorizeDeviceLogoutButtonImpl : ButtonControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitLaunchGameEmailButtonImpl : ButtonControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetAuthorizationCodeButtonImpl : ButtonControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AuthorizationCodeTextImpl : TextControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AuthorizationCodeExpirationTimeTextImpl : TextControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EmailTextImpl : TextControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotPasswordlessLoginVariant : HideableControllerImpl<PasswordlessLoginModel>
		{
			[SerializeField]
			private string variant;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPasswordlessLoginVariant : HideableControllerImpl<PasswordlessLoginModel>
		{
			[SerializeField]
			private string variant;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotPasswordlessLogin : HideableControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AuthorizationCodeInputFieldImpl : InputFieldControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class EmailInputFieldImpl : InputFieldControllerImpl<PasswordlessLoginModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class NavigationImpl : ControllerImplementation<PasswordlessLoginModel>
		{
			[NonSerialized]
			private BrowserModel browserModel;

			protected BrowserModel BrowserModel => null;

			public override bool SubscribeToDefaultModelEvents => false;

			public override bool OnModelChangedCanBeQueued => false;

			public override bool RefreshOnShow => false;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void JMFMPFFAMHN(PageWrapper NEEHPFOPEML)
			{
			}
		}
	}
}
