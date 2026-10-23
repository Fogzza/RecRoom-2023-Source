using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Tutorials.Helpers;
using UnityEngine;

namespace RecRoom.Tutorials
{
	[Serializable]
	public abstract class MakerPenIntroTransformStep : MakerPenIntroStep
	{
		private sealed class DIFAFHEJMDL
		{
			public MakerPenIntroTransformStep _003C_003E4__this;

			public bool actionPerformed;

			internal bool _003CProcessStep_003Eb__1()
			{
				return false;
			}

			internal void _003CProcessStep_003Eg__OnActionCompleted_007C2()
			{
			}

			internal bool _003CProcessStep_003Eb__3()
			{
				return false;
			}
		}

		private sealed class ONMEMBFOAKD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MakerPenIntroTransformStep _003C_003E4__this;

			private DIFAFHEJMDL _003C_003E8__1;

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
			public ONMEMBFOAKD(int _003C_003E1__state)
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

		[Space]
		[SerializeField]
		private ConditionalString selectObjectToContinueSubtitle;

		[SerializeField]
		[Space]
		private bool displayOpenMenuPrompt;

		[SerializeField]
		private ConditionalString openMenuSubtitle;

		[SerializeField]
		private MakerPenIntroOpenMenu openMenuPrompt;

		[Space]
		[HNDJNPOHFJK]
		[SerializeField]
		private string button;

		[SerializeField]
		private ConditionalString buttonLabel;

		[SerializeField]
		private ConditionalString subtitleBeforeAction;

		private LKGILLBEJEK processingPromise;

		private AJBAOOEKCBF buttonHighlight;

		private BFABKMNDMMP highlightSystem;

		private HashSet<string> pressedButtons;

		public override bool Ready => false;

		public override void Init()
		{
		}

		protected override void KMKMFENKIEM()
		{
		}

		protected override void JNIOJFAAGPE()
		{
		}

		protected override void DDNLOPKLINK()
		{
		}

		protected abstract void FNJFCABIFLG(Action ONAFALABHKI);

		protected abstract void DLCEKLEONME(Action ONAFALABHKI);

		private IEnumerator<EGGPGCCKPCO> LHALCDOMAMH()
		{
			return null;
		}

		private void JIACICIDKAM(string OFFJPOMOLDJ)
		{
		}

		private void JMCGOJBMFDL()
		{
		}
	}
}
