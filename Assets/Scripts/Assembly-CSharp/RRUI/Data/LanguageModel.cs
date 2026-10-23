using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class LanguageModel : RRUIModel
	{
		public enum CAEJNKDEACB
		{
			None = -1,
			TitleScreen = 0,
			Settings = 1
		}

		private enum KOLLKPAGKOK
		{
			LANGUAGE_SWITCH = 0,
			SWITCH_ON_NEXT_LOGIN = 1,
			SWITCH_NOW = 2,
			CANCEL = 3,
			LANGUAGE_SWITCH_MESSAGE = 4,
			DIFFERENT_LANGUAGE_DETECTED_TITLE = 5,
			DIFFERENT_LANGUAGE_DETECTED_BODY = 6,
			SWITCH_TO_LANGUAGE = 7,
			STAY_ON_LANGUAGE = 8
		}

		private sealed class LKDHEMOIIBI
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CShowDifferentLanguageDetected_003Eb__0_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncVoidMethodBuilder _003C_003Et__builder;

				public LKDHEMOIIBI _003C_003E4__this;

				private TaskAwaiter _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			public LanguageModel _003C_003E4__this;

			public Locale previousDeviceLocale;

			public global::PHLHFLLLDLK<bool> promise;

			public string currentDeviceLocaleCode;

			internal void _003CShowDifferentLanguageDetected_003Eb__0()
			{
			}

			internal void _003CShowDifferentLanguageDetected_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct NMMCOHFBCKB : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Locale locale;

			public LanguageModel _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private sealed class CGMMMEFAIHA
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CShowLocaleConfirmationPopup_003Eb__1_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncVoidMethodBuilder _003C_003Et__builder;

				public CGMMMEFAIHA _003C_003E4__this;

				private TaskAwaiter _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			public DHAPPKCJJCA localeChangeConfirmationDialog;

			public LanguageModel _003C_003E4__this;

			public Locale locale;

			internal void _003CShowLocaleConfirmationPopup_003Eb__0()
			{
			}

			internal void _003CShowLocaleConfirmationPopup_003Eb__1()
			{
			}

			internal void _003CShowLocaleConfirmationPopup_003Eb__2()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct HFCABHPEMAG : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object locale;

			public LanguageModel _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public CAEJNKDEACB languagePickerSource;

		private DHAPPKCJJCA EIHLKKGIIEO;

		private DHAPPKCJJCA OCEKLDIECKI;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private Locale CCIAOFFJAGL;

		private Locale LPGLLILMHLG;

		public LocalizedString localePickerTitle;

public bool ShouldSeeLanguageSelector
{
get 		{
			return false;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public Locale CurrentLocale
{
get 		{
			return null;
		}

set {
		}
}

public Locale QueuedLocale
{
get 		{
			return null;
		}

set {
		}
}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override void DHHOMFCCFKP()
		{
		}

		public void ShowLanguageSelection()
		{
		}

		public global::NCOKFFGPIJM<bool> ShowDifferentLanguageDetected(string EPGNNNJMLGA, string AKOJIIICPOJ)
		{
			return null;
		}

		private Task GKKENPLLCNE(Locale OFFMDFLKJAN)
		{
			return null;
		}

		private void HLKPPDFJJOL(Locale OFFMDFLKJAN)
		{
		}

		[CompilerGenerated]
		private object PFJNGJOMJNI()
		{
			return null;
		}

		[CompilerGenerated]
		private void JPCEMCHKHOC(object OFFMDFLKJAN)
		{
		}
	}
}
