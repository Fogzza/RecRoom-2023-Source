using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Localization;
using UnityEngine;

namespace RRUI.Data
{
	public class TitleScreenFlowModel : BaseRouteFlowModel, AIOCIBMFJEJ
	{
		private enum EDNJKIHJAGB
		{
			INITIAL_BOOT = 0,
			PLATFORM_LOGIN = 1,
			DISPLAY_MODE_SELECTION = 2,
			EULA = 3,
			LOADING_SCREEN = 4,
			CROSS_PLATFORM_WARNING = 5,
			VERSION_UPDATE = 6,
			LOGOUT_REASON_MESSAGE = 7,
			TITLE_SCREEN_NEW_ACCOUNT = 8,
			TITLE_SCREEN_CACHED_ACCOUNT = 9,
			TITLE_SCREEN_INTERRUPTED_ACCOUNT_CREATION = 10,
			TITLE_SCREEN_MOBILE_HOME = 11,
			SWITCH_ACCOUNT = 12,
			LOGIN = 13,
			LOGIN_SHORT_SECOND = 14,
			RESET_PASSWORD = 15,
			SWITCH_ACCOUNT_LOADING_SCREEN = 16,
			AVATAR_CUSTOMIZATION = 17,
			BIRTHDAY = 18,
			USERNAME_NON_JUNIOR = 19,
			USERNAME_JUNIOR = 20,
			PASSWORD = 21,
			ACCOUNT_CREATION_CONSOLIDATED_INFO = 22,
			ACCOUNT_CREATION_VERIFY_EMAIL = 23,
			ACCOUNT_CREATION_VERIFY_PHONE = 24,
			ACCOUNT_CREATION_MIC_PERMISSIONS = 25,
			ACCOUNT_CREATION_NOTIF_PERMISSIONS = 26,
			ACCOUNT_CREATION_CONTACTS_PERMISSIONS = 27,
			ACCOUNT_CREATION_FRIEND_IMPORT = 28,
			ACCOUNT_CREATION_VR_SEATED_MODE_SELECTION = 29,
			ACCOUNT_CREATION_MEASURE_PLAYER_HEIGHT = 30,
			ACCOUNT_CREATION_CODE_OF_CONDUCT = 31,
			ACCOUNT_CREATION_COMPLETE = 32,
			ACCOUNT_CREATION_INTERSTITIAL = 33,
			ACCOUNT_CREATION_LAUNCH_GAME = 34,
			LAUNCH_GAME_EMAIL = 35,
			LAUNCH_GAME_VERIFY_EMAIL = 36,
			LAUNCH_GAME_MIC_PERMISSIONS = 37,
			LAUNCH_GAME_NOTIF_PERMISSIONS = 38,
			LAUNCH_GAME_CONTACTS_PERMISSIONS = 39,
			LAUNCH_GAME_FRIEND_IMPORT = 40,
			LAUNCH_GAME_VR_SEATED_MODE_SELECTION = 41,
			LAUNCH_GAME_MEASURE_PLAYER_HEIGHT = 42,
			LAUNCH_GAME = 43,
			CONNECTION_ERROR = 44,
			VERSION_ERROR = 45,
			META_JUNIOR_LOGIN_NOT_SUPPORTED = 46,
			META_JUNIOR_ACCOUNT_CREATION_NOT_SUPPORTED = 47,
			AUTHORIZE_ANOTHER_DEVICE_CONFIRMATION_PAGE = 48,
			AUTHORIZE_ANOTHER_DEVICE_EMAIL_PAGE = 49,
			AUTHORIZE_ANOTHER_DEVICE_VERIFY_EMAIL_PAGE = 50,
			AUTHORIZE_ANOTHER_DEVICE_LOGIN = 51,
			TITLE_INTERSTITIAL = 52,
			REBOOT = 53,
			CHAT_NOTIF_PERMISSIONS = 54,
			CHAT = 55,
			FEED = 56,
			COUNT = 57
		}

		public enum PPGMCKPPHDK
		{
			LOGIN_ERROR_PASSWORD_REQUIRED = 0,
			LOGIN_ERROR_FAILED_TO_LOCATE_ACCOUNT = 1,
			LOADING_BAR_CONNECTING_TO_SERVER = 2,
			LOADING_BAR_CREATING_NEW_ACCOUNT = 3,
			LOADING_BAR_DOWNLOADING_PLAYER_DATA = 4,
			LOADING_BAR_LOGGING_INTO_ACCOUNT = 5,
			LOADING_BAR_DONE = 6,
			EMAIL_VERIFICATION_NON_JUNIOR = 7,
			EMAIL_VERIFICATION_JUNIOR = 8,
			EMAIL_DESCRIPTION_NON_JUNIOR = 9,
			EMAIL_DESCRIPTION_JUNIOR = 10,
			EMAIL_PLACEHOLDER_JUNIOR = 11,
			EMAIL_PLACEHOLDER_NON_JUNIOR = 12,
			EMAIL_PLACEHOLDER_OPTIONAL = 13,
			UPDATE_WARNING_CLICKABLE = 14,
			UPDATE_WARNING_RECOMMENDED = 15,
			PLAY = 16,
			SWAP_AND_PLAY = 17,
			CHAT_CALLOUT_HEADER = 18,
			CHAT_CALLOUT_MESSAGE = 19
		}

		[Serializable]
		public class TitleScreenPage
		{
			[SerializeField]
			private bool routeIsDifferentOnMobile;

			[SerializeField]
			private Route route;

			[SerializeField]
			private Route mobileRoute;

			public Route Route
			{
				get
				{
					if (!routeIsDifferentOnMobile || !SingletonMonoBehaviour<PlatformManager>.IsInitialized)
						return route;
					return MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<MCCKDPKLCIN>(null).SupportsPortraitMode
						? mobileRoute : route;
				}
			}
		}

		private abstract class EEPNGDEKJOG
		{
			public abstract NOFHIODEAHA.EAIKGIBOLBI GKHCHGIMALF(List<NOFHIODEAHA.EAIKGIBOLBI> ODPNMHGJLOG);
		}

		private class AGJIAKLHMNO : EEPNGDEKJOG
		{
			private readonly string GMCKCKBAHNO;

			public AGJIAKLHMNO(string EHOJHHMGNOD)
			{
			}

			public override NOFHIODEAHA.EAIKGIBOLBI GKHCHGIMALF(List<NOFHIODEAHA.EAIKGIBOLBI> ODPNMHGJLOG)
			{
				return null;
			}

			[CompilerGenerated]
			private bool ACJPOJKPLFG(NOFHIODEAHA.EAIKGIBOLBI JJMCOJPJLAL)
			{
				return false;
			}
		}

		private class JNAMGDDIKKM : EEPNGDEKJOG
		{
			private readonly string FEIJAADICAH;

			public JNAMGDDIKKM(string AMKNIICCPOJ)
			{
			}

			public override NOFHIODEAHA.EAIKGIBOLBI GKHCHGIMALF(List<NOFHIODEAHA.EAIKGIBOLBI> ODPNMHGJLOG)
			{
				return null;
			}

			[CompilerGenerated]
			private bool ACJPOJKPLFG(NOFHIODEAHA.EAIKGIBOLBI JJMCOJPJLAL)
			{
				return false;
			}
		}

		private class CHMJPLJFNHL : EEPNGDEKJOG
		{
			private readonly int MBAAIINANMC;

			public CHMJPLJFNHL(int EJIHLJJMOBD)
			{
			}

			public override NOFHIODEAHA.EAIKGIBOLBI GKHCHGIMALF(List<NOFHIODEAHA.EAIKGIBOLBI> ODPNMHGJLOG)
			{
				return null;
			}

			[CompilerGenerated]
			private bool ACJPOJKPLFG(NOFHIODEAHA.EAIKGIBOLBI JJMCOJPJLAL)
			{
				return false;
			}
		}

		public readonly struct EOOFAEEOGKM
		{
			public readonly string IEACNHGAIIE;

			public readonly float CLBGEKBMHJC;

			public readonly float HOGOLBJOFLE;

			public readonly float HNJLGFPIDMP;

			public EOOFAEEOGKM(string IEACNHGAIIE, float CLBGEKBMHJC, float HOGOLBJOFLE, float HNJLGFPIDMP)
			{
				this.IEACNHGAIIE = null;
				this.CLBGEKBMHJC = 0f;
				this.HOGOLBJOFLE = 0f;
				this.HNJLGFPIDMP = 0f;
			}
		}

		private readonly struct BHLOFKHLNMC
		{
			public readonly LBGGLBDJKBH MNCCGCPPDLA;

			public readonly bool NPFLKFHNOOO;

			public BHLOFKHLNMC(LBGGLBDJKBH MNCCGCPPDLA, bool NPFLKFHNOOO)
			{
				this.MNCCGCPPDLA = null;
				this.NPFLKFHNOOO = false;
			}
		}

		private sealed class LPCDGBLFIMM
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public Route currentRoute;

			internal void _003CRequestMicrophonePermissionsThenGoToNext_003Eb__0()
			{
			}
		}

		private sealed class FEGEIEDFAGE
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public Route currentRoute;

			internal void _003CRequestNotificationPermissionsThenGoToNext_003Eb__0()
			{
			}
		}

		private sealed class INGFCFGHKHI
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public Route currentRoute;

			internal void _003CRequestContactsPermissionsThenGoToNext_003Eb__0()
			{
			}
		}

		private sealed class KLABHLBIFAO
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public Route currentRoute;

			internal void _003CSubmitEmail_003Eb__0()
			{
			}

			internal void _003CSubmitEmail_003Eb__1(string e)
			{
			}
		}

		private sealed class NFBMHAAJDDH
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public Route currentUsernameRoute;

			internal void _003CSubmitAccountCreationUsernameAndGoToNext_003Eb__0()
			{
			}

			internal void _003CSubmitAccountCreationUsernameAndGoToNext_003Eb__1(string e)
			{
			}
		}

		private sealed class JPMLCELAKDD
		{
			public int cachedAccountId;

			public TitleScreenFlowModel _003C_003E4__this;

			public NOFHIODEAHA.EAIKGIBOLBI cachedAccount;

			internal bool _003CLoginToCachedAccountById_003Eb__0(NOFHIODEAHA.EAIKGIBOLBI a)
			{
				return false;
			}

			internal void _003CLoginToCachedAccountById_003Eb__1()
			{
			}

			internal void _003CLoginToCachedAccountById_003Eb__2(string e)
			{
			}
		}

		private sealed class OAEDPDBHLAN
		{
			public global::PHLHFLLLDLK<MJLJBHNFNAP> promise;

			public MJLJBHNFNAP selectedDisplayMode;

			internal void _003CShowDisplayModeWarningDialog_003Eb__0()
			{
			}
		}

		private sealed class DOBCFHHEMMN
		{
			public BaseDialogModel<IPGOOJIFBAB> dialog;

			internal void _003CShowVRWarningDialog_003Eb__1()
			{
			}
		}

		private sealed class NLPFOILENNE
		{
			private sealed class _003C_003CSwitchDisplayMode_003Eg__RunDisplayModeTransition_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public NLPFOILENNE _003C_003E4__this;

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
				public _003C_003CSwitchDisplayMode_003Eg__RunDisplayModeTransition_007C0_003Ed(int _003C_003E1__state)
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

			public MJLJBHNFNAP selectedDisplayMode;

			internal IEnumerator<EGGPGCCKPCO> _003CSwitchDisplayMode_003Eg__RunDisplayModeTransition_007C0()
			{
				return null;
			}
		}

		private sealed class LDBJLNCDENI
		{
			public int cachedID;

			public bool hasCachedAccountID;

			public TitleScreenFlowModel _003C_003E4__this;

			internal LAHBDKNMNHN _003COnEnterLoadingScreenState_003Eg__LogIntoAccountByCachedLoginID_007C2()
			{
				return null;
			}

			internal LAHBDKNMNHN _003COnEnterLoadingScreenState_003Eg__LoginWithoutOverride_007C4()
			{
				return null;
			}

			internal LAHBDKNMNHN _003COnEnterLoadingScreenState_003Eg__LoginWithAccountOverride_007C5(EEPNGDEKJOG loginOverride)
			{
				return null;
			}
		}

		private sealed class FAHEKJJMCKE
		{
			public EEPNGDEKJOG loginOverride;

			public LDBJLNCDENI CS_0024_003C_003E8__locals1;

			internal LAHBDKNMNHN _003COnEnterLoadingScreenState_003Eb__8(List<NOFHIODEAHA.EAIKGIBOLBI> cachedAccounts)
			{
				return null;
			}
		}

		private sealed class BGKJCFFIKJL
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public NOFHIODEAHA.EAIKGIBOLBI autoLoginCachedAccount;

			internal void _003CAttemptAutoLoginForCachedAccount_003Eb__0(string e)
			{
			}
		}

		private sealed class BLAFNLOCMFB
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public Action goToTitleScreen;

			internal void _003CGoToTitleScreen_003Eb__0()
			{
			}

			internal void _003CGoToTitleScreen_003Eb__1(JBPMMJCDCHG.ODJCKKLLPME versionStatusResponse)
			{
			}
		}

		private sealed class AOFHHBGPIJM
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public string error;

			internal void _003COnConnectionError_003Eb__0()
			{
			}
		}

		private sealed class AOKEJPJIGOP
		{
			public NOFHIODEAHA.EAIKGIBOLBI autoLoginCachedAccount;

			public TitleScreenFlowModel _003C_003E4__this;

			public string error;

			internal void _003COnAutoLoginError_003Eb__0()
			{
			}
		}

		private sealed class GANENJJAEJD
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public string error;

			public string accountUsername;

			internal void _003COnManualLoginError_003Eb__0()
			{
			}
		}

		private sealed class FJPDFBDNAKN
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public string error;

			public string accountUsername;

			internal void _003COnExclusiveLoginError_003Eb__0()
			{
			}
		}

		private sealed class AHAEAEKBLDL
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public string error;

			internal void _003COnResetPasswordError_003Eb__0()
			{
			}
		}

		private sealed class KGEHCBPCFLI
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public string error;

			internal void _003COnAccountCreationError_003Eb__0()
			{
			}
		}

		private sealed class JIGAIHHNHOC
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public bool forceUpdate;

			internal void _003CDownloadCachedAccounts_003Eb__0(List<NOFHIODEAHA.EAIKGIBOLBI> cachedLogins)
			{
			}
		}

		private sealed class CPFEBPDECDL
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public bool isNewAccount;

			public bool gotoNextRoute;

			internal LAHBDKNMNHN _003CLoginToCachedAccountInternal_003Eb__0()
			{
				return null;
			}

			internal void _003CLoginToCachedAccountInternal_003Eb__1(string e)
			{
			}

			internal void _003CLoginToCachedAccountInternal_003Eb__2()
			{
			}
		}

		private sealed class NIHPCDFGJIM
		{
			public bool rememberPassword;

			public TitleScreenFlowModel _003C_003E4__this;

			public bool isNewAccount;

			internal LAHBDKNMNHN _003CManualLoginInternal_003Eb__0()
			{
				return null;
			}
		}

		private sealed class EKDBFCAFIJF
		{
			public LAHBDKNMNHN openNotificationChannelPromise;

			public LAHBDKNMNHN loginToMatchmakingPromise;

			public LAHBDKNMNHN downloadPrefsPromise;

			public LAHBDKNMNHN downloadAvatarPromise;

			public LAHBDKNMNHN downloadUnlockedAvatarItems;

			public LAHBDKNMNHN downloadStringsPromise;

			public TitleScreenFlowModel _003C_003E4__this;

			internal LAHBDKNMNHN _003CPostLogin_003Eb__0()
			{
				return null;
			}

			internal LAHBDKNMNHN _003CPostLogin_003Eb__1()
			{
				return null;
			}

			internal LAHBDKNMNHN _003CPostLogin_003Eb__2()
			{
				return null;
			}

			internal LAHBDKNMNHN _003CPostLogin_003Eb__3()
			{
				return null;
			}

			internal LAHBDKNMNHN _003CPostLogin_003Eb__4()
			{
				return null;
			}

			internal LAHBDKNMNHN _003CPostLogin_003Eb__5()
			{
				return null;
			}

			internal void _003CPostLogin_003Eb__6()
			{
			}
		}

		private sealed class DEGELAGGPIL
		{
			public TitleScreenFlowModel _003C_003E4__this;

			public bool mustGoToOrientation;

			public BootSequence.NJIJPADHPEC launchTarget;

			internal void _003CLaunchGame_003Eb__0()
			{
			}

			internal void _003CLaunchGame_003Eb__1(string error)
			{
			}
		}

		private sealed class JODFCKLBMGD
		{
			public Route route;

			public TitleScreenFlowModel _003C_003E4__this;

			internal bool _003CWaitForTransitionToFinish_003Eb__2()
			{
				return false;
			}
		}

		private sealed class APPHAJLDMFN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public APPHAJLDMFN(int _003C_003E1__state)
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

		private sealed class FMCJOAPBLHN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TitleScreenFlowModel _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public FMCJOAPBLHN(int _003C_003E1__state)
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

		private sealed class DMPHLENDPHK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public DMPHLENDPHK(int _003C_003E1__state)
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

		private sealed class GJNHDGAICFB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public GJNHDGAICFB(int _003C_003E1__state)
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

		private sealed class JCJIAEFKKOP : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TitleScreenFlowModel _003C_003E4__this;

			public Route route;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public JCJIAEFKKOP(int _003C_003E1__state)
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

		public const string TITLE_SCREEN_SESSION_KEY = "titlescreen";

		[SerializeField]
		private TitleScreenPage initialBootPage;

		[SerializeField]
		private TitleScreenPage platformLoginPage;

		[SerializeField]
		private TitleScreenPage loadingScreenPage;

		[SerializeField]
		private TitleScreenPage eulaPage;

		[SerializeField]
		private TitleScreenPage displayModeSelectionPage;

		[SerializeField]
		private TitleScreenPage crossPlatformWarningPage;

		[SerializeField]
		private TitleScreenPage titleScreenNewAccountPage;

		[SerializeField]
		private TitleScreenPage titleScreenCachedAccountPage;

		[SerializeField]
		private TitleScreenPage titleScreenInterruptedAccountCreationPage;

		[SerializeField]
		private TitleScreenPage titleScreenMobileHomePage;

		[SerializeField]
		private TitleScreenPage chatPage;

		[SerializeField]
		private TitleScreenPage chatThreadPage;

		[SerializeField]
		private TitleScreenPage chatNotifPermissionsPage;

		[SerializeField]
		private TitleScreenPage feedPage;

		[SerializeField]
		private TitleScreenPage avatarCustomizationPage;

		[SerializeField]
		private TitleScreenPage birthdayPage;

		[SerializeField]
		private TitleScreenPage usernamePage;

		[SerializeField]
		private TitleScreenPage usernameJuniorPage;

		[SerializeField]
		private TitleScreenPage passwordPage;

		[SerializeField]
		private TitleScreenPage consolidatedInfoPage;

		[SerializeField]
		private TitleScreenPage verifyEmailPage;

		[SerializeField]
		private TitleScreenPage verifyPhonePage;

		[SerializeField]
		private TitleScreenPage accountCreationMicPermissionsPage;

		[SerializeField]
		private TitleScreenPage accountCreationNotifPermissionsPage;

		[SerializeField]
		private TitleScreenPage accountCreationContactsPermissionsPage;

		[SerializeField]
		private TitleScreenPage accountCreationFriendImportPage;

		[SerializeField]
		private TitleScreenPage accountCreationVRSeatedModeSelectionPage;

		[SerializeField]
		private TitleScreenPage accountCreationMeasurePlayerHeightPage;

		[SerializeField]
		private TitleScreenPage accountCreationCompletePage;

		[SerializeField]
		private TitleScreenPage accountCreationCodeOfConductPage;

		[SerializeField]
		private TitleScreenPage accountCreationInterstitialPage;

		[SerializeField]
		private TitleScreenPage accountCreationLaunchGamePage;

		[SerializeField]
		private TitleScreenPage switchAccountPage;

		[SerializeField]
		private TitleScreenPage loginPage;

		[SerializeField]
		private TitleScreenPage loginPageShortSecond;

		[SerializeField]
		private TitleScreenPage resetPasswordPage;

		[SerializeField]
		private TitleScreenPage switchAccountLoadingScreenPage;

		[SerializeField]
		private TitleScreenPage loginWithAnotherDevicePage;

		[SerializeField]
		private TitleScreenPage authorizeAnotherDevicePage;

		[SerializeField]
		private TitleScreenPage authorizeAnotherDeviceConfirmationPage;

		[SerializeField]
		private TitleScreenPage authorizeAnotherDeviceEmailPage;

		[SerializeField]
		private TitleScreenPage authorizeAnotherDeviceVerifyEmailPage;

		[SerializeField]
		private TitleScreenPage launchGameEmailPage;

		[SerializeField]
		private TitleScreenPage launchGameVerifyEmailPage;

		[SerializeField]
		private TitleScreenPage launchGameMicPermissionsPage;

		[SerializeField]
		private TitleScreenPage launchGameNotifPermissionsPage;

		[SerializeField]
		private TitleScreenPage launchGameContactsPermissionsPage;

		[SerializeField]
		private TitleScreenPage launchGameFriendImportPage;

		[SerializeField]
		private TitleScreenPage launchGameVRSeatedModeSelectionPage;

		[SerializeField]
		private TitleScreenPage launchGameMeasurePlayerHeightPage;

		[SerializeField]
		private TitleScreenPage launchGamePage;

		[SerializeField]
		private TitleScreenPage connectionErrorPage;

		[SerializeField]
		private TitleScreenPage versionErrorPage;

		[SerializeField]
		private TitleScreenPage updatePromptPage;

		[SerializeField]
		private TitleScreenPage logoutReasonMessagePage;

		[SerializeField]
		private TitleScreenPage rebootPage;

		[SerializeField]
		private TitleScreenPage titleInterstitialPage;

		[SerializeField]
		private TitleScreenPage metaJuniorAccountLoginErrorPage;

		[SerializeField]
		private TitleScreenPage metaJuniorAccountCreationErrorPage;

		[SerializeField]
		private MeasurePlayerHeightModel measurePlayerHeightModel;

		[SerializeField]
		private VRSettingsModel vrSettingsModel;

		[SerializeField]
		private LanguageModel languageModel;

		private readonly List<NOFHIODEAHA.EAIKGIBOLBI> AEONMIHECKB;

		private readonly Route[] JPDNBFLBKJE;

		private readonly LBGGLBDJKBH[] MJILNAPJBPG;

		private readonly bool[] HLJKFEIBAMK;

		private readonly MDEJADHJOEJ BGBIFFLGANM;

		private LKGILLBEJEK PPJECJCFHNC;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private EFGIDDLNECL ALCHBCLKCII;

		private MCCKDPKLCIN GNEINIEOJLL;

		private IDisposable MACNHIABDFN;

		private DCCDAPLPICN IBDKAJJPLGA;

		private APGPNOKPLLL NKKHAEFBOLO;

		private FEIKFKAICHC HKNAHLAFLPC;

		private FLPGLADCKPI HDNFDFNJJOK;

		private GCLANALOAPO EBPBNGBNANG;

		private static bool BMEODGLIHLL;

		private bool GMGPDIILDJG;

		private OINCCICKEPE PDCFNNLFBFI;

		private bool BCPLMHDCEPP;

		private BMCGMLFFLBN ICDMMGNFMAF;

		private string AICDDJCAFMH;

		private DynamicUIDialogModel FHHOMMPODAI;

		private DHAPPKCJJCA ODCHDPEMAHN;

		private bool KKKCPFKAKAO;

		private bool JPOBLCHPAMB;

		private string KONOHKPGMLG;

		private bool PHELINKFEBI;

		private bool DKCKFDCPHLC;

		private BFKGIGGJKHD BKFMIFCJOHK;

		private bool? KACINMADAPP;

		private bool LBLMGAHAHEK;

		private EOOFAEEOGKM JHPBAPJEIKC;

		private bool EFNMBEEMNGH;

		private bool? PGJNHEMOLDP;

		private bool? DNODLMBOJJE;

		private string LHGBCEDJFCI;

		private string NEFGPHHAAHD;

		private string NGDNNNJJHJJ;

		private string CFJJJDCDCBK;

		private bool BJPPIALHEHP;

		private string NAOPEBCEBGK;

		private string LMJIIAEINHM;

		private bool MCMPLJFCICH;

		private bool CCLJEALGFMG;

		private bool KJALGJGGJLE;

		private string JMOKEOHPAHD;

		private string GJHGGOFGHML;

		private string CBMMHOJDOLC;

		private bool NHKMAPJGNGN;

		private bool MKLAALDHOMO;

		private DateTime OHKDGIAAKGK;

		private string KHEJNDPFBPI;

		private string EHKOCLIBOBK;

		private bool EBILGNBILBP;

		private string MIGOMPPBCHN;

		private string MEHOEMLNMMA;

		private string ONENENKIOHP;

		private static bool BCHJONKFFAK;

		private OILDLLGEMKP.BKOPGEEODIK.IPJLEMFLEBI AKIAHIDGLHN;

		private readonly OILDLLGEMKP.BKOPGEEODIK.GHIMENCKMEG EFNEMLNOJDG;

		private OILDLLGEMKP.BKOPGEEODIK.KGLHOCCCPAP KNHDGGEKNFE;

		private const string KLEMCNBPHLH = "growth_platform_notification_permissions_request";

		private const string GAEKJNMHALP = "Growth.NotificationPermissionSkipCount";

		private const string MHPFPHFFLAN = "Growth.NotificationPermissionLastSkipDate";

		private static bool OPKLKAPCFNE;

		public const string USERNAME_BYPASS_ARG_PREFIX = "+username:";

		public const string PASSWORD_BYPASS_ARG_PREFIX = "+password:";

		public const string QUIT_ON_LOGIN_FAILURE_ARG = "+quitonloginfailure";

		private const string NJCGFONHKBC = "+rrurl:";

		private const string DGFBAALNHAD = "Recroom.AccountCreation.HasStarted";

		private const string MIGIJBKHMEA = "Recroom.AccountCreation.HasFinished";

		private const string MPEMPIDHGGC = "Recroom.AccountCreation.HasChosenUsername";

		private const string AKCACLFMGEB = "Recroom.AccountCreation.HasCreatedPassword";

		private const string DADNEIMAMOL = "Recroom.AccountCreation.HasImportedFriends";

		private string FIPFNLEHONJ;

		private const string KOMJKAOGDPE = "social_q3_session_takeover";

		private const string KHPEJLEMKDN = "can_takeover";

		public bool ShouldAttemptSessionTakeover;

		private const string GGILONONFLK = "update_ps_only_matching_pref";

		private const string FGBBGDAIKMM = "update_xbox_only_matching_pref";

		private const string PEADMHBODNC = "psOnlyMatching";

		private const string EOCMCCGDAHN = "xboxOnlyMatching";

		public FallbackTableReference recNetLocTable;

public bool ShowUpdateWarning
{
get 		{
			return false;
		}

}

public bool IsInAccountCreationState
{
get 		{
			ushort state = BGBIFFLGANM.CPDFJCCALIA;
			return state >= 17 && state <= 34;
		}

}

public bool IsInChatState
{
get 		{
			ushort state = BGBIFFLGANM.CPDFJCCALIA;
			return state >= 54 && state <= 55;
		}

}

public bool IsInFeedState
{
get 		{
			return BGBIFFLGANM.CPDFJCCALIA == 56;
		}

}

public bool IsInCachedAccountState
{
get 		{
			return false;
		}

}

public bool IsInInterstitialState
{
get 		{
			ushort state = BGBIFFLGANM.CPDFJCCALIA;
			return state == 33 || state == 52;
		}

}

public bool IsInHomeState
{
get 		{
			return false;
		}

}

public bool IsInLoadingState
{
get 		{
			return false;
		}

}

public bool IsInStateThatSupportsGoingBack
{
get 		{
			return false;
		}

}

public bool HasReadEULA
{
get 		{
			return false;
		}

set {
		}
}

public string EULAString
{
get 		{
			return null;
		}

private set {
		}
}

public bool MustDisplayCrossPlatformWarning
{
get 		{
			return false;
		}

private set {
		}
}

public bool MustRequestMicPermissions
{
get 		{
			return false;
		}

private set {
		}
}

public bool MustRequestNotifPermissions
{
get 		{
			return false;
		}

private set {
		}
}

private int MIPJEHJHAPK
{
get 		{
			return 0;
		}

set {
		}
}

public bool MustRequestContactsPermissions
{
get 		{
			return false;
		}

private set {
		}
}

public EOOFAEEOGKM LoadingProgressStatus
{
get 		{
			return default;
		}

private set {
		}
}

public IReadOnlyList<NOFHIODEAHA.EAIKGIBOLBI> AllAvailableCachedAccounts
{
get 		{
			return null;
		}

}

public IKCIDEMLEIA LocalAccount
{
get 		{
			return null;
		}

}

public bool UnlinkThisAccountFromThisDeviceOnSwitchAccount
{
get 		{
			return false;
		}

private set {
		}
}

private bool COGILJMCACA
{
get 		{
			return false;
		}

}

public bool TitleScreenChatEnabled
{
get 		{
			return false;
		}

}

public bool TitleScreenFeedEnabled
{
get 		{
			return false;
		}

}

public bool HasConnectionError
{
get 		{
			return false;
		}

}

public string ConnectionError
{
get 		{
			return null;
		}

private set {
		}
}

public bool HasManualLoginError
{
get 		{
			return false;
		}

}

public string ManualLoginError
{
get 		{
			return null;
		}

private set {
		}
}

public bool HasAutoLoginError
{
get 		{
			return false;
		}

}

public string AutoLoginError
{
get 		{
			return null;
		}

private set {
		}
}

public bool HasAccountCreationError
{
get 		{
			return false;
		}

}

public string AccountCreationError
{
get 		{
			return null;
		}

private set {
		}
}

public bool SupportsLinkToDownloadUpdate
{
get 		{
			return false;
		}

private set {
		}
}

public bool HasManualLoginInformation
{
get 		{
			return false;
		}

}

public bool HasManualLoginUsername
{
get 		{
			return false;
		}

}

public string ManualLoginUsername
{
get 		{
			return null;
		}

set {
		}
}

public string ManualLoginPassword
{
get 		{
			return null;
		}

set {
		}
}

public bool ManualLoginShowPassword
{
get 		{
			return false;
		}

set {
		}
}

public bool ManualLoginRequirePassword
{
get 		{
			return false;
		}

set {
		}
}

public bool HasValidResetPasswordEmail
{
get 		{
			return false;
		}

private set {
		}
}

public string ResetPasswordEmail
{
get 		{
			return null;
		}

set {
		}
}

public bool HasResetPasswordError
{
get 		{
			return false;
		}

}

public string ResetPasswordError
{
get 		{
			return null;
		}

private set {
		}
}

public string Email
{
get 		{
			return null;
		}

set {
		}
}

public bool EmailIsValid
{
get 		{
			return false;
		}

}

public string EmailDescriptionText
{
get 		{
			return null;
		}

}

public string EmailPlaceholderText
{
get 		{
			return null;
		}

}

public string EmailVerificationText
{
get 		{
			return null;
		}

}

public bool ReceiveEmailNewsletter
{
get 		{
			return false;
		}

set {
		}
}

public bool OpenedPrivacyPolicy
{
get 		{
			return false;
		}

set {
		}
}

public string DeferredActionText
{
get 		{
			return null;
		}

}

public bool HasDeferredActionPending
{
get 		{
			return false;
		}

}

public bool AccountCreationBirthdayIsValid
{
get 		{
			return false;
		}

}

public DateTime AccountCreationBirthday
{
get 		{
			return default;
		}

set {
		}
}

public OPIHCLAIHML.COIGEFDLPKJ AccountCreationUsernameValidity
{
get 		{
			return OPIHCLAIHML.COIGEFDLPKJ.INCOMPLETE_LENGTH;
		}

}

public string AccountCreationUsername
{
get 		{
			return null;
		}

set {
		}
}

public OPIHCLAIHML.COIGEFDLPKJ AccountCreationPasswordValidity
{
get 		{
			return OPIHCLAIHML.COIGEFDLPKJ.INCOMPLETE_LENGTH;
		}

}

public string AccountCreationPassword
{
get 		{
			return null;
		}

set {
		}
}

public bool AccountCreationShowPassword
{
get 		{
			return false;
		}

set {
		}
}

public bool ShouldHideAccountCreationEmail
{
get 		{
			return false;
		}

}

public string AccountCreationFormattedCountryAndDialCode
{
get 		{
			return null;
		}

set {
		}
}

public string AccountCreationPhone
{
get 		{
			return null;
		}

set {
		}
}

public string PhonePlaceholderText
{
get 		{
			return null;
		}

}

public bool ShouldHideAccountCreationPhone
{
get 		{
			return false;
		}

}

public bool AccountCreationConsolidatedInfoIsValid
{
get 		{
			return false;
		}

}

public string AccountCreationPhoneVerificationCode
{
get 		{
			return null;
		}

set {
		}
}

public bool AccountCreationPhoneVerificationCodeIsValid
{
get 		{
			return false;
		}

}

public string LogoutReasonText
{
get 		{
			return null;
		}

}

public bool ShouldShowLogoutReasonMessage
{
get 		{
			return false;
		}

}

public bool CanUpdateOrGoToFeed
{
get 		{
			return false;
		}

}

private EDNJKIHJAGB MBHNCCMHIPK
{
get 		{
			return EDNJKIHJAGB.INITIAL_BOOT;
		}

}

private bool LAFFJJPCFJK
{
get 		{
			return false;
		}

}

private Route BDKFKIAJIHK
{
get 		{
			return null;
		}

}

		public void AcceptEULAAndGoToNext()
		{
		}

		public void AcceptCrossPlatformWarningAndGoToNext()
		{
		}

		public void RequestMicrophonePermissionsThenGoToNext()
		{
		}

		public void RequestNotificationPermissionsThenGoToNext()
		{
		}

		public void NotifyNotificationPermissionsRequestSkippedThenGoToNext()
		{
		}

		public void RequestContactsPermissionsThenGoToNext()
		{
		}

		public void MarkFriendsImportedThenGoToNext()
		{
		}

		public void ToggleUnlinkThisAccountFromThisDeviceOnSwitchAccount(bool IPMIIEAGJKC)
		{
		}

		private bool LCKIHDACPDK(string DNFIOLEHDGI, ref bool? KHNNFAJIILA, Func<bool> DIICHMBDFEB)
		{
			return false;
		}

		private void NMNIIDFEANK()
		{
		}

		public void LinkToUpdate()
		{
		}

		public void GoToNextPage()
		{
		}

		public void GoToResetPassword()
		{
		}

		public void SubmitPasswordResetAndGoBack()
		{
		}

		public void SubmitEmail()
		{
		}

		public void AcknowledgeLogoutReasonMessageAndGoToNext()
		{
		}

		public void AuthorizedWithAnotherDevice()
		{
		}

		public void AuthorizedAnotherDevice()
		{
		}

		private bool AINECHDKLGJ()
		{
			return false;
		}

		public void LaunchGameCachedAccount()
		{
		}

		public void LaunchGameAccountCreation()
		{
		}

		public void ManuallyLogin()
		{
		}

		public void GoToSwitchAccount()
		{
		}

		public void GoToChat()
		{
		}

		public void GoToChatThread(long FFBALOOMPIB)
		{
		}

		public void UpdateOrGoToFeed(List<KDEEJHLLLCH> DIMLIEFIABI, DBECJLAIPEL PKGLLJBECJM, bool CKDDPKOJGGJ = false)
		{
		}

		public void GoToFeed(List<KDEEJHLLLCH> DIMLIEFIABI = null, bool CKDDPKOJGGJ = false, DBECJLAIPEL PKGLLJBECJM = DBECJLAIPEL.NOT_SET)
		{
		}

		public void GoToLogin()
		{
			var browser = BrowserModel;
			if (System.Object.ReferenceEquals(browser, null))
				return;
			browser.GoTo(loginPage.Route, false);
		}

		public void GoToLoginWithAnotherDevice()
		{
		}

		public void GoToAuthorizeAnotherDevice()
		{
		}

		public void GoToEmailPage()
		{
		}

		public void GoToCachedAccountStartAccountCreationFlow()
		{
		}

		public void CreateNewAccountThenGoToStartAccountCreationFlow()
		{
		}

		public void SubmitAvatarCustomizationAndGoToNext()
		{
		}

		public void SubmitAccountCreationBirthdayAndGoToNext()
		{
		}

		public void SubmitAccountCreationUsernameAndGoToNext()
		{
		}

		public void SubmitAccountCreationPasswordAndGoToNext()
		{
		}

		public void RandomizeAccountCreationUsername()
		{
		}

		public void AcceptCodeOfConductAndGoToNext()
		{
		}

		public void Reboot()
		{
		}

		public void LoginToCachedAccountById(int BFGKJCGBOJP)
		{
		}

		public void OpenCountryCodeSelectionDialog()
		{
		}

		public void SubmitAccountCreationConsolidatedInfoAndGoToNext()
		{
		}

		public void SubmitAccountCreationPhoneVerificationCodeAndGoToNext()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		private void MKPOCGPIGEK()
		{
		}

		private void IAIPHHLGIBF()
		{
		}

		private static void HIMGBACNCPJ()
		{
		}

		private void OnApplicationPause(bool NFHCNHMLNJG)
		{
		}

		private void DIPHAJAGIIL()
		{
		}

		private void KAOKIJJHCHJ(EDNJKIHJAGB DADHJJNJEFA, TitleScreenPage MLCFEEOIEOE, bool PBGPPECCNLJ, LBGGLBDJKBH MPFPPBACFCN, ILNJNAIHNJF.ABDCCOJEOCH CFMFCGDAFFO, ILNJNAIHNJF.ABDCCOJEOCH CMIDPLEONAL = null)
		{
		}

		private void PNGMCLLKPBL(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void KDABBKNMIEF(EDNJKIHJAGB MEHPPOKJBGM)
		{
		}

		private void MMKKFKANJJK()
		{
		}

		private void NJJPGLELPHB(ModelBase LFKKJIFPEMA)
		{
		}

		private bool EJOEPHAHGKC(Route NBCNOLJOIIM, out EDNJKIHJAGB DADHJJNJEFA)
		{
			DADHJJNJEFA = default;
			return false;
		}

		private void PGFJEFLAJBA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool DCEJOLCKPAK()
		{
			return false;
		}

		private void PONAPDPKCDC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool MLEJMBLLLOO()
		{
			return false;
		}

		private void ANCBNKIEMGH(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private global::NCOKFFGPIJM<MJLJBHNFNAP> FGDHNBCCMHD(MJLJBHNFNAP IBILBGDHIDA)
		{
			return null;
		}

		private LAHBDKNMNHN KGOCGDCKKNH()
		{
			return null;
		}

		private LAHBDKNMNHN OFNCAFPCFBH(MJLJBHNFNAP IBILBGDHIDA)
		{
			return null;
		}

		private bool FJJEGCCBJDC()
		{
			return false;
		}

		private void BICKFBDOFNP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void CIDDHHDDPJL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private LAHBDKNMNHN JLAFJGBPHNL(NOFHIODEAHA.EAIKGIBOLBI JPOBNHEKPPF)
		{
			return null;
		}

		private LAHBDKNMNHN GIJNEBNAKGF()
		{
			return null;
		}

		private void PEPKPFPMCBC(bool OMPKDGKEFLJ = false)
		{
		}

		private bool CANODFKAPPA()
		{
			return false;
		}

		private bool PJLJPMINOME()
		{
			return false;
		}

		private void BCJNGGPJFKA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool GHKNJFLGEIN()
		{
			return false;
		}

		private void OOEEIJAPOFE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool EEBOICIFKLD()
		{
			return false;
		}

		private void AJHAHMFMBBD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool PGHMGJMIFHI()
		{
			return false;
		}

		private void KBIPDJEDCHO(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool JDELIJMCDLE()
		{
			return false;
		}

		private void MGCDMFEJBDI(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void EGIGINGLDDM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void CBEGKIJNGED(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool FADONPABGDI()
		{
			return false;
		}

		private void FPIADAGKFOD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void OGJHEJEHEJD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void FANEGENFDPD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KAMNMGOAMIN()
		{
		}

		private bool HIAGFFGNOHO()
		{
			return false;
		}

		private void MPNPEDOIMJM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JEFEFFPDGFN(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool BHHNLLOADMD()
		{
			return false;
		}

		private bool LCCCJNFDMHM()
		{
			return false;
		}

		private void CCILEKILGKL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void EONPELOHIBP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool OPLJPMGCAGP()
		{
			return false;
		}

		private void MKFLFDDOOHA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GOANAPHJEJK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool NFCFGJIMPJH()
		{
			return false;
		}

		private void OMNLJGBNPHD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void EJBPNJOEHMJ(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool BGPJEMNPDPP()
		{
			return false;
		}

		private void HBCDLCDOEML(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GBMNECMCALE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool JEKKHOGEDHG()
		{
			return false;
		}

		private void GOPMAAIFLLC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GNLDBIAFAND(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool FOEFKOHFHAF()
		{
			return false;
		}

		private void HIBODAGBJDE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ICFLFIPFKDB(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ONMKIADPMAA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool GILEFCHEIDI()
		{
			return false;
		}

		private void HDOLAFGFNPK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DMAMFJLGPIC(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool FPAKHLDOCKJ()
		{
			return false;
		}

		private void KCCJOEMAFFL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ACKOAHMKHHF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool MHLNODMIHMK()
		{
			return false;
		}

		private void DCHFPBMBDNI(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void ANKHPDGFEAM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GPDOHMDLBDG(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool ODODDPFMDFK()
		{
			return false;
		}

		private bool DNPONIDJFPO()
		{
			return false;
		}

		private void KMAGFKCLOCH(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void HAENOIKCMEF(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool EJPHPFJBIAK()
		{
			return false;
		}

		private bool FIGEOEDPACJ()
		{
			return false;
		}

		private void AHFDKJEOBPP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GCIBCJCHMDP(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool GFBAEMGOIKE()
		{
			return false;
		}

		private bool JKLCONMDCLK()
		{
			return false;
		}

		private void EJHFMCEPCPO(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MONMKCJILAA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JHKICBILOHM()
		{
		}

		private bool PMKEOKHGICI()
		{
			return false;
		}

		private void IIEABCNAEGD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void BOEFDGMONBI(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MOFJDNDICKA()
		{
		}

		private bool NFIKALEEBJP()
		{
			return false;
		}

		private void FGBDEKPBFHA(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void KPBHNBGKADD(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void IEBDPADJFBG(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void PMIJOHNCENB(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void JJDCDLHAEFG(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void GFJBLMCCOEB(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void LMEIEAHHAOE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void MDCGMJJDHLK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private bool ICLGPPCJNDP()
		{
			return false;
		}

		private void GKHAECECCLP(ushort DCGPBGGMGDN, ushort GPNAPJCPCDK)
		{
		}

		private bool AFOHLEIGNLP()
		{
			return false;
		}

		private void BDIBJKAGLHO()
		{
		}

		private bool GHCDEKIBIJN(string NLJOHEKGNDH)
		{
			return false;
		}

		private void DBIOHJBHNCA(string NLJOHEKGNDH)
		{
		}

		private bool GOPPAHGOONP(string NLJOHEKGNDH)
		{
			return false;
		}

		private void JOMELJKKFCE()
		{
		}

		private bool HMPFLECPOHN()
		{
			return false;
		}

		private bool EMDOGPGCLOI()
		{
			return false;
		}

		private void IAKAGMNFKAO()
		{
		}

		private void EGCLENJHOPG()
		{
		}

		private LAHBDKNMNHN IHEDBEMBBAP()
		{
			return null;
		}

		private void DHKHKGMBPAL(string NLJOHEKGNDH, NOFHIODEAHA.EAIKGIBOLBI JPOBNHEKPPF)
		{
		}

		private void PCAIJFNIEAG(string NLJOHEKGNDH, NOFHIODEAHA.EAIKGIBOLBI KHLGOGBHGOE)
		{
		}

		private void PCAIJFNIEAG(string NLJOHEKGNDH, string ANLHCJCGBFA)
		{
		}

		private void DPBJPDBFGOH(string NLJOHEKGNDH, string ANLHCJCGBFA)
		{
		}

		private void CDKCODKGMCH(string NLJOHEKGNDH)
		{
		}

		private static string KDJNNCDACAO(string NLJOHEKGNDH, string DPDHNAGGMCO)
		{
			return null;
		}

		private void BKLHPAKAEOF(Route BPMKGDACEFL, string NLJOHEKGNDH)
		{
		}

		private LAHBDKNMNHN PAINDEDKIDA()
		{
			return null;
		}

		private global::NCOKFFGPIJM<JBPMMJCDCHG.ODJCKKLLPME> DKBECGKHEKO()
		{
			return null;
		}

		private LAHBDKNMNHN JLMAAGNKFGM()
		{
			return null;
		}

		private global::NCOKFFGPIJM<List<NOFHIODEAHA.EAIKGIBOLBI>> LGCNIMHODJC(bool JCKJPDHHFPO = false)
		{
			return null;
		}

		private void BCEDBCAOGGE(List<NOFHIODEAHA.EAIKGIBOLBI> ODPNMHGJLOG)
		{
		}

		private void FNPFEHEGKHE(string IEACNHGAIIE, float CLBGEKBMHJC, float HOGOLBJOFLE, float HNJLGFPIDMP)
		{
		}

		private bool JBIPFDDFJKN()
		{
			return false;
		}

		private void GMOOEFABDME()
		{
		}

		private bool DNALNFBCIPB()
		{
			return false;
		}

		private void PKJIDJGMHHJ()
		{
		}

		public bool HasLocalAccountChosenUsername()
		{
			return false;
		}

		private void OALHKOGFEAM()
		{
		}

		private bool INNMNOLPPFF()
		{
			return false;
		}

		private void EJMAHLGCKCL()
		{
		}

		private bool CIEDJHIOJKJ()
		{
			return false;
		}

		private void OLOPMKNCBOD()
		{
		}

		private bool FDNMGGAOOJN(string FDAIMOMOHIG)
		{
			return false;
		}

		private void GBKFMCOFIAN(string FDAIMOMOHIG)
		{
		}

		private void DHAPKABHEMB()
		{
		}

		private EEPNGDEKJOG IFHDOOKJAAG()
		{
			return null;
		}

		private static NOFHIODEAHA.EAIKGIBOLBI HJEFAIDNPIF(List<NOFHIODEAHA.EAIKGIBOLBI> ODPNMHGJLOG)
		{
			return null;
		}

		private LAHBDKNMNHN MFKHDFPJOFL(NOFHIODEAHA.EAIKGIBOLBI ONHNJPDFNJN, bool CIKEMDLGKIN = true)
		{
			return null;
		}

		private LAHBDKNMNHN FMLMIOAKDCH(int PGANFJDAJMC, bool IOJOALLDODH, bool CIKEMDLGKIN = true)
		{
			return null;
		}

		private bool KGNPIJNHEBJ(out string DPDHNAGGMCO, out string AFGGJHIEOKG)
		{
			DPDHNAGGMCO = null;
			AFGGJHIEOKG = null;
			return false;
		}

		private bool JBJBKKJFJOH(out LAHBDKNMNHN BDALIEPJCKH)
		{
			BDALIEPJCKH = null;
			return false;
		}

		private LAHBDKNMNHN KKNCCDEDEDO(string DPDHNAGGMCO, string AFGGJHIEOKG, bool LAGPPJGBLKM)
		{
			return null;
		}

		public LAHBDKNMNHN BypassLoginToAccountInternal(BMCGMLFFLBN ICDMMGNFMAF)
		{
			return null;
		}

		private void OJACKMPPBPP()
		{
		}

		private static void BFBBALLCONC(string NLJOHEKGNDH)
		{
		}

		private LAHBDKNMNHN JDFNPHGOMMJ()
		{
			return null;
		}

		private LAHBDKNMNHN IPFGEEGKPDH(string DPDHNAGGMCO, string AFGGJHIEOKG, bool KGGGHOGPDOO, bool IOJOALLDODH)
		{
			return null;
		}

		private LAHBDKNMNHN DLGBHBNEKHD(bool IOJOALLDODH)
		{
			return null;
		}

		private LAHBDKNMNHN JFBAGGNFGPF()
		{
			return null;
		}

		private LAHBDKNMNHN NOKJENBGLDB()
		{
			return null;
		}

		private void EFPIHIPJLAO(bool LNBDKDKMDPG)
		{
		}

		private bool CBJCFIDCEHG()
		{
			return false;
		}

		private bool LAHDANENFKP()
		{
			return false;
		}

		private bool ELBEILHOKGA()
		{
			return false;
		}

		private bool BLGLIIEBCGN()
		{
			return false;
		}

		private string DODLCEFHABJ()
		{
			return null;
		}

		private LAHBDKNMNHN HFEKIBLEOOP()
		{
			return null;
		}

		private global::NCOKFFGPIJM<MJLJBHNFNAP> NHCIKBFNDEI()
		{
			return null;
		}

		private LAHBDKNMNHN LCIHCBJDCLM()
		{
			return null;
		}

		private LAHBDKNMNHN KAHPCFLLDCE()
		{
			return null;
		}

		private void PDECAIKDGJN()
		{
		}

		private LAHBDKNMNHN CJKOLPIFKPA()
		{
			return null;
		}

		private LAHBDKNMNHN IECDICNNKLD()
		{
			return null;
		}

		private void ADJIJEGJKAD()
		{
		}

		private void JEJPLPHLOPP()
		{
		}

		private void MNFPPLPHFIJ()
		{
		}

		private LAHBDKNMNHN BBLIECNHJPO()
		{
			return null;
		}

		private void PMCFCBBOEBF()
		{
		}

		private bool CPMKKOJJOPE()
		{
			return false;
		}

		private bool HMKPBICKENP()
		{
			return false;
		}

		private void CLJGLFKFOMG()
		{
		}

		private void BKOANLDINEB()
		{
		}

		private void HKNJJPJEDPE(string JNEDHKEAGEH)
		{
		}

		private void PNIHDBGLGEA()
		{
		}

		private void JPPKLFFDBGF()
		{
		}

		private void HHAIJALHIGN()
		{
		}

		private LAHBDKNMNHN CMFFBDDBNID(Route MLFKECNDCPF)
		{
			return null;
		}

		private void LDMMFPNODNI()
		{
		}

		private void MNADCBMHAAK()
		{
		}

		private void FAEJFJGABHI()
		{
		}

		public string LocalizeRecNetError(string NLJOHEKGNDH)
		{
			return null;
		}

		[CompilerGenerated]
		private void EOPFHHGNKMJ()
		{
		}

		[CompilerGenerated]
		private void DIHNNEMFMHM(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void MDJPPIIOMPD()
		{
		}

		[CompilerGenerated]
		private void JOIHLLMGAFK(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<NOFHIODEAHA.EAIKGIBOLBI>> HJKOHIKPGCM()
		{
			return null;
		}

		[CompilerGenerated]
		private void NBGEMMOFFAE()
		{
		}

		[CompilerGenerated]
		private void JNMJBHAJBLJ()
		{
		}

		[CompilerGenerated]
		private void LPCMGNDAMHA(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void PDOMGANBODI()
		{
		}

		[CompilerGenerated]
		private void BAMFHDGHJCN(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void MIKPCLIIPLB()
		{
		}

		[CompilerGenerated]
		private void EMBNJGPAKGG(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void HFBHGDCAFDO(MKKJLGPDDKJ.HDFOAMJMPJD NGDGIECBNKM)
		{
		}

		[CompilerGenerated]
		private object LKINFMPCGNI()
		{
			return null;
		}

		[CompilerGenerated]
		private void PLNDCDKELDL(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private void PFOFMFPBCLJ(string IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void FLPANLOOBNB(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN ECFLCCJCMBD()
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN MJMDENGFJBN()
		{
			return null;
		}

		[CompilerGenerated]
		private void GOBEDPMFLJM()
		{
		}

		[CompilerGenerated]
		private void LBKKBIJFLDD(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void IMGMPDBJOIF()
		{
		}

		[CompilerGenerated]
		private void OINHFDKOCPI(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void MPHCGGIGKPE(DateTime? IGGCAMBDKCF)
		{
		}

		[CompilerGenerated]
		internal static IEnumerator<EGGPGCCKPCO> OIMNJHKBEPD()
		{
			return null;
		}

		[CompilerGenerated]
		private void HANICDMKDMI()
		{
		}

		[CompilerGenerated]
		private IEnumerator<EGGPGCCKPCO> ICHHCKPJKJG()
		{
			return null;
		}

		[CompilerGenerated]
		private void CHJNHADFDIM(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void HOGEDPEFKCH()
		{
		}

		[CompilerGenerated]
		private void LJANFBKBNKO()
		{
		}

		[CompilerGenerated]
		private void HPGOBCHLPCM()
		{
		}

		[CompilerGenerated]
		private void GAFLBFLDJAK(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN JLPFGKFFCJC(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
			return null;
		}

		[CompilerGenerated]
		private void LAGEFMGPJKD(JBPMMJCDCHG.ODJCKKLLPME CDJFBGIGEFG)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN DOINAMKEBMI()
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<NOFHIODEAHA.EAIKGIBOLBI>> CHCOJKKIJOA()
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN IAHOKMBGMFG()
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN CDPOKKINLKP(List<NOFHIODEAHA.EAIKGIBOLBI> OMNKEPMNGPI)
		{
			return null;
		}

		[CompilerGenerated]
		private void IDBGIEHDKFE()
		{
		}

		[CompilerGenerated]
		private void LDMOIICDNIJ()
		{
		}

		[CompilerGenerated]
		private void JNMBLEPLAEF(bool AOGPFOEINLH)
		{
		}

		[CompilerGenerated]
		private void IKNMMHBHAFO()
		{
		}

		[CompilerGenerated]
		private void LMCLKFGENCD()
		{
		}

		[CompilerGenerated]
		private bool CLDGHLCGBLD(NOFHIODEAHA.EAIKGIBOLBI DHNNLHJMKIH)
		{
			return false;
		}

		[CompilerGenerated]
		internal static IEnumerator<EGGPGCCKPCO> LFOAIENHMAE()
		{
			return null;
		}

		[CompilerGenerated]
		internal static IEnumerator<EGGPGCCKPCO> GBLIDMECPIA()
		{
			return null;
		}

		[CompilerGenerated]
		private LAHBDKNMNHN GDDBBCJDDEH()
		{
			return null;
		}

		[CompilerGenerated]
		private void JHEMEFHIDKC()
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN HLKGHPNGBLJ()
		{
			return null;
		}

		[CompilerGenerated]
		private void IJBICGBFAEE(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN KHGBDEHDMNH()
		{
			return null;
		}

		[CompilerGenerated]
		private void LJPNHHIGOLN()
		{
		}

		[CompilerGenerated]
		private void DOJPMHKDDCF(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		internal static void ALFCIKFOHBN()
		{
		}

		[CompilerGenerated]
		private void PMJHGFGHNPI()
		{
		}

		[CompilerGenerated]
		private bool GFJIEMCIJDO(Route NBCNOLJOIIM)
		{
			return false;
		}

		[CompilerGenerated]
		private IEnumerator<EGGPGCCKPCO> GCIJNLAIBML(Route NBCNOLJOIIM)
		{
			return null;
		}

		[CompilerGenerated]
		private string ACMGHFDCKAM((JCIDEAANBIG, string) GCBHEJANCJK)
		{
			return null;
		}
	}
}
