using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RRUI.Dialogs;

namespace RRUI.Data
{
	public class TranscriptionTargetModel : RRUIModel
	{
		public struct GKAFEIAPEBI
		{
			public string DKNLAANLGAK;

			public string HDJKLNIGFHF;
		}

		private sealed class INOKLOBCPCO
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CShowNeedMicrophonePermissionDialog_003Eb__0_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncVoidMethodBuilder _003C_003Et__builder;

				public INOKLOBCPCO _003C_003E4__this;

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

			public TaskCompletionSource<bool> dialogClosed;

			internal void _003CShowNeedMicrophonePermissionDialog_003Eb__0()
			{
			}

			internal void _003CShowNeedMicrophonePermissionDialog_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct CBJKIMNHPDI : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public TranscriptionTargetModel _003C_003E4__this;

			private INOKLOBCPCO _003C_003E8__1;

			private TaskAwaiter<TwoButtonMessageDialogModel> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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

		private string IFGEHPNOAHE;

		private GKAFEIAPEBI? FJCNFKMAPEP;

		private ONPBFNKNEKJ PEKJMFLHHHB;

		private readonly object GNLIGIDOJKC;

public bool Transcribing
{
get 		{
			return false;
		}

}

public bool IsServiceEnabled
{
get 		{
			return false;
		}

}

public string TranscribedText
{
get 		{
			return null;
		}

private set {
		}
}

public GKAFEIAPEBI? LastError
{
get 		{
			return null;
		}

private set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

		public void BeginTranscription()
		{
		}

		public void EndTranscription()
		{
		}

		public Task<bool> ShowNeedMicrophonePermissionDialog()
		{
			return null;
		}

		public void ClearLastError()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		protected override void PLLBMDOLLBP()
		{
		}

		private void MHFPPCFGBAL(string MAFKLMLIAOD)
		{
		}

		private void MGAACENHMOH()
		{
		}

		private void JCOCAAKGOPO()
		{
		}

		private void INPLPKIJPMO(string CKHHGBNHHCK)
		{
		}

		private void BGLLJDPCKJB()
		{
		}

		private void CHBAKNDEABJ()
		{
		}

		private void AGGEBCBPKLK()
		{
		}
	}
}
