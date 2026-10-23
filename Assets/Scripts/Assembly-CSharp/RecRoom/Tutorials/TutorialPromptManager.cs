using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.VR.UI;
using RecRoom.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RecRoom.Tutorials
{
	public class TutorialPromptManager : SingletonMonoBehaviour<TutorialPromptManager>
	{
		public enum OEGOINFNJBC
		{
			NONE = -1,
			CANCEL = 0,
			COMPLETE = 1,
			HIDE = 2
		}

		private sealed class PIHCNEILFCP
		{
			public TutorialPromptManager _003C_003E4__this;

			public TutorialPromptContext promptContext;

			public LIKFFCKGMNN newActivePromptPromise;

			internal void _003CTutorialPromptCoroutine_003Eb__0()
			{
			}
		}

		private sealed class LOJJIHMNGIM
		{
			public float startTime;

			public PIHCNEILFCP CS_0024_003C_003E8__locals1;

			internal bool _003CTutorialPromptCoroutine_003Eb__1()
			{
				return false;
			}
		}

		private sealed class ENFABNGPNKM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TutorialPromptManager _003C_003E4__this;

			public TutorialPromptContext promptContext;

			public LIKFFCKGMNN newActivePromptPromise;

			private PIHCNEILFCP _003C_003E8__1;

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
			public ENFABNGPNKM(int _003C_003E1__state)
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

		private sealed class DJBBJACKGJN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TutorialPromptManager _003C_003E4__this;

			public TutorialPromptContext promptContext;

			private TutorialPromptConfig _003CpromptConfig_003E5__2;

			private bool _003CfirstUpdate_003E5__3;

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
			public DJBBJACKGJN(int _003C_003E1__state)
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
		private VRTutorialPromptDialog vrTutorialPromptDialog;

		[SerializeField]
		private TutorialPromptConfigs tutorialPromptConfigs;

		[SerializeField]
		private FallbackTableReference tableReference;

		private LIKFFCKGMNN MKMCPKGAOFA;

		private LKGILLBEJEK BPLEHNJIHJC;

		private List<JKHCJAJHGAO> AKHAGBANAHC;

public VRTutorialPromptDialog VRTutorialPromptDialog
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public JKHCJAJHGAO RunTutorialPrompt(TutorialPromptContext KAGPMIHBLMJ)
		{
			return null;
		}

		public void FinishTutorialPrompt(OEGOINFNJBC AAOFGKDFPMG)
		{
		}

		public void CancelTutorialPrompt()
		{
		}

		public void CompleteTutorialPrompt()
		{
		}

		public void HideTutorialPrompt()
		{
		}

		private IEnumerator<EGGPGCCKPCO> JMCELGIEJHF(TutorialPromptContext KAGPMIHBLMJ, LIKFFCKGMNN FBDKAIGCJKE)
		{
			return null;
		}

		private void KKJEGDFFILL(Scene FEGPGPHCDJD)
		{
		}

		private void PMCMOOGFFEI(TutorialPromptContext KAGPMIHBLMJ)
		{
		}

		private void LKBIPBMACIM(TutorialPromptContext KAGPMIHBLMJ)
		{
		}

		private IEnumerator<EGGPGCCKPCO> LILOOHLAKBH(TutorialPromptContext KAGPMIHBLMJ)
		{
			return null;
		}
	}
}
