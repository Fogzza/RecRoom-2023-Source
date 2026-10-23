using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace RRUI.Data
{
	public class TranscriptionTargetModelController : ModelController<TranscriptionTargetModel>
	{
		[Serializable]
		private class EndTranscriptionIfActiveImpl : ButtonControllerImpl<TranscriptionTargetModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfS2TNotAvailableImpl : HideableControllerImpl<TranscriptionTargetModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TranscribeTextImpl : InputFieldControllerImpl<TranscriptionTargetModel>
		{
			[SerializeField]
			private ChatThreadModel chatThreadModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class ToggleTranscriptionButtonImpl : ToggleControllerImpl<TranscriptionTargetModel>
		{
			[StructLayout((LayoutKind)3)]
			private struct IPDMKOCGOID : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncVoidMethodBuilder _003C_003Et__builder;

				public ToggleTranscriptionButtonImpl _003C_003E4__this;

				private TaskAwaiter<bool> _003C_003Eu__1;

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

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DisplayTutorialImpl : ControllerImplementation<TranscriptionTargetModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LastErrorToCalloutDialogImpl : ControllerImplementation<TranscriptionTargetModel>
		{
			[SerializeField]
			private CalloutDialogTarget target;

			private const string calloutKey = "TRANSCRIPTION_ERROR";

			[SerializeField]
			private Button[] buttonsWhichDismissError;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void MLKFMGGDFGN()
			{
			}
		}

		[Serializable]
		private class ChatThreadListEventResponderImpl : ControllerImplementation<TranscriptionTargetModel>
		{
			[SerializeField]
			private ChatThreadListModel chatThreadListModel;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void BKKOAEKNLMH()
			{
			}
		}
	}
}
