using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RRUI.Data;
using RRUI.Dialogs;

namespace AGUI.StackedUI.Dialog
{
	public class LoadRoomSaveModel : RRUIModel
	{
		[StructLayout((LayoutKind)3)]
		private struct KGNEIAKEOKJ : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LoadRoomSaveModel _003C_003E4__this;

			public LoadingDialogModel model;

			private TaskAwaiter<BCDAPDDMMEO> _003C_003Eu__1;

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

		private string FJJFKJCLDFA;

		private long MCMOLLCNPHO;

		private long LCHGEIAIFFO;

		private OPKEAIOICLJ CIPHEPDBIEL;

		private LCEKCFEIEGJ OCNJNKAJIKN;

		private List<IPKJBIFKDKF> CACPGOBANBC;

		private List<bool> EEJMNKAJEOI;

		private FDDHILGHJBB JPPLGLINNNA;

		private int FKHEODNLBLN;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public string RoomName
{
get 		{
			return null;
		}

private set {
		}
}

public long RoomId
{
get 		{
			return 0L;
		}

private set {
		}
}

public long SubroomId
{
get 		{
			return 0L;
		}

private set {
		}
}

public OPKEAIOICLJ Subroom
{
get 		{
			return null;
		}

private set {
		}
}

public LCEKCFEIEGJ RoomDetails
{
get 		{
			return null;
		}

private set {
		}
}

public List<IPKJBIFKDKF> RoomSaves
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsRoomPublished
{
get 		{
			return false;
		}

}

public FDDHILGHJBB AutoSaveRecord
{
get 		{
			return null;
		}

private set {
		}
}

public int SelectedSaveIndex
{
get 		{
			return 0;
		}

set {
		}
}

		public bool IsValidRoomSave(int GMEHLIHLGEH)
		{
			return false;
		}

		public void LoadSelectedRoom()
		{
		}

		public void LoadAutoSave()
		{
		}

		private void FIEJIGPFAJI(LoadingDialogModel LFKKJIFPEMA)
		{
		}

		private void CDJAEBDDBOI()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		public void Set(long EPOBIFCHLNM, long FPPOCBBEOPL)
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		[CompilerGenerated]
		private void HDJNFEKPFAL(LoadingDialogModel GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void IABHEKCBDOB(LCEKCFEIEGJ BBHINKGKDBL)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<global::KBKOPBBHCHK<IPKJBIFKDKF>> AKJBFJNBDGK()
		{
			return null;
		}

		[CompilerGenerated]
		private void EHNEMODMHGL(global::KBKOPBBHCHK<IPKJBIFKDKF> HMOLPGPDBNM)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<List<bool>> BDMFNEKJMND()
		{
			return null;
		}

		[CompilerGenerated]
		private void ADEDGKAAJMA(List<bool> OPOLCOKPLLP)
		{
		}
	}
}
