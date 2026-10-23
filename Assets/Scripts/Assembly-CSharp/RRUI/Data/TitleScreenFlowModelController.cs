using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RRUI.Theme;
using RRUI.Views;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class TitleScreenFlowModelController : ModelController<TitleScreenFlowModel>
	{
		[Serializable]
		private class LaunchGameCachedAccountButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenChatButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class LaunchGameAccountCreationButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ManualLoginButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ManualLoginFirstButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetPasswordButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToSwitchAccountPageButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UnlinkThisAccountFromThisDeviceOnSwitchAccountToggleImpl : ToggleControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToLoginPageButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToLoginWithAnotherDevicePageButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToAuthorizeAnotherDevicePageButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToAddEmailPageButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetEmailSentButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ResetEmailAndEmailSentButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AcceptEULAAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AcceptCrossPlatformWarningAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AcknowledgeLogoutReasonMessageAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RequestMicPermissionsAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RequestNotifPermissionsAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RequestContactsPermissionsAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SkipFriendImportAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SkipNotificationPermissionsRequestImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ImportSelectedFriendsAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private FriendImportModel friendImportModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToAccountCreationFlowButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CreateNewAccountThenGoToAccountCreationFlowButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToResetPasswordButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitAccountCreationAvatarAndGoToNextImpl : ControllerImplementation<TitleScreenFlowModel>
		{
			private sealed class NGIHFAMPKPB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public SubmitAccountCreationAvatarAndGoToNextImpl _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public NGIHFAMPKPB(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			[SerializeField]
			private AvatarCustomizationModel avatarCustomizationModel;

			private LKGILLBEJEK promise;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private IEnumerator<EGGPGCCKPCO> GJOCHGMDNMO()
			{
				return null;
			}

			[CompilerGenerated]
			private bool LEOOJICIHHJ()
			{
				return false;
			}

			[CompilerGenerated]
			private void KIFECMBNFPH()
			{
			}
		}

		[Serializable]
		private class SubmitAccountCreationBirthdayAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitAccountCreationUsernameAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitAccountCreationPasswordAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitAccountCreationConsolidatedInfoAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitAccountCreationPhoneVerificationCodeAndGoToNextButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RetryConnectionButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UpdateLinkButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class UpdateLaterLinkButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToggleManualLoginPasswordFieldVisibilityButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToggleManualLoginRememberPasswordButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToggleAccountCreationPasswordFieldVisibilityButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RandomizeAccountCreationUsernameButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SubmitLaunchGameEmailButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ToggleEmailNewsletterButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SelectCountryCodeButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AcceptCodeOfConductButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class OpenFeedButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowPrivacyPolicyButtonImpl : ButtonControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CachedAccountUsernameTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LoadingProgressStatusTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EULABigTextImpl : ControllerImplementation<TitleScreenFlowModel>
		{
			[SerializeField]
			protected BigTextGroup textGroup;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LoginErrorTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CachedLoginErrorTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ResetPasswordErrorTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ConnectionErrorTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountCreationErrorTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UsernameHintTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private LabelTheme labelTheme;

			[SerializeField]
			private LocalizedString ContainsInvalidCharacters;

			[SerializeField]
			private LocalizedString AlreadyChosenUsername;

			[SerializeField]
			private LocalizedString GreatUsername;

			[SerializeField]
			private LocalizedString MinimumCharacterLength;

			protected override void NGFFCLPHKJN()
			{
			}

			private string JONELOKOJND()
			{
				return null;
			}

			private JDOLBJAOGPC KIGCJGBNKPH()
			{
				return JDOLBJAOGPC.MainPrimary;
			}
		}

		[Serializable]
		private class PasswordHintTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private LabelTheme labelTheme;

			[SerializeField]
			private LocalizedString MaximumCharacterLength;

			[SerializeField]
			private LocalizedString LooksGood;

			[SerializeField]
			private LocalizedString DefaultMessage;

			protected override void NGFFCLPHKJN()
			{
			}

			private string JONELOKOJND()
			{
				return null;
			}

			private JDOLBJAOGPC KIGCJGBNKPH()
			{
				return JDOLBJAOGPC.MainPrimary;
			}
		}

		[Serializable]
		private class EmailVerificationTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EmailDescriptionTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EmailInputFieldPlaceholderTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PhoneInputFieldPlaceholderTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountCreationCountryCodeTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DeferredActionTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LogoutReasonTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UpdateWarningTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PlayButtonTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EmailTextImpl : TextControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClickableContentTextImpl : ClickableTextControllerImpl<TitleScreenFlowModel>
		{
			[SerializeField]
			private string buttonLocation;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void AJKKKHIDPHF(TMP_LinkInfo DJLDBHOPNND)
			{
			}
		}

		[Serializable]
		private class ManualLoginUsernameInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ManualLoginPasswordInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ResetPasswordEmailInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class AccountCreationUsernameInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class AccountCreationPasswordInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class EmailInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class AccountCreationPhoneInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class AccountCreationPhoneVerificationCodeInputFieldImpl : InputFieldControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class LoadingProgressBarImpl : ProgressBarControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideDownloadUpdateLinkImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideDownloadWarningImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideLoginErrorImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideCachedLoginErrorImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideResetPasswordErrorImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideAccountCreationErrorImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoAccountCreationEmailImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoAccountCreationPhoneImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfChatOrFeedEnabledImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfChatAndFeedDisabledImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfChatDisabledImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfDeferredActionIsPending : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoDeferredActionIsPending : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoDeferredActionTextIsPending : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfFeedDisabledImpl : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPromptingForSessionTakeover : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotPromptingForSessionTakeover : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotOpenedPrivacyPolicy : HideableControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CachedAccountCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<TitleScreenFlowModel, AccountModel, AccountModelController>
		{
			private sealed class FJPLMIHJFOG
			{
				public CachedAccountCardSpawnerImpl _003C_003E4__this;

				public int accountId;

				public AccountModel accountModel;

				internal void _003COnPopulateInstance_003Eb__0()
				{
				}

				internal string _003COnPopulateInstance_003Eb__1()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__2()
				{
					return null;
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel KCCEEALIFJE, JLOCLGGLOPP EALCJHOOFKH)
			{
			}
		}

		[Serializable]
		private class AccountCreationBirthdayDatePickerImpl : DatePickerControllerImpl<TitleScreenFlowModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void JFAMMFMCBKF(DateTime LEDKEEFMDDC)
			{
			}
		}

		[Serializable]
		private class ShowChatCalloutImpl : ControllerImplementation<TitleScreenFlowModel>
		{
			[SerializeField]
			private CalloutDialogTarget target;

			private const string calloutKey = "HOME_CHAT_BUTTON";

			private bool haveShownCallout;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
