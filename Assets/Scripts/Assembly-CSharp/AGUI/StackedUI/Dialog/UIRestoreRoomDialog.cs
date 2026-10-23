using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI.Dialog
{
	public class UIRestoreRoomDialog : ConfirmUIDialog
	{
		[StructLayout((LayoutKind)3)]
		private struct EFAFOEBOAHI
		{
			public List<string> scratchParts;
		}

		private sealed class JFCFNIFLPJA
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CButton_Restore_003Eg__RestoreAsync_007C0_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public JFCFNIFLPJA _003C_003E4__this;

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

			public UIRestoreRoomDialog _003C_003E4__this;

			public ACDMEBDFJKM selectedRestoreOption;

			internal Task _003CButton_Restore_003Eg__RestoreAsync_007C0()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct LKHFHOBBOLN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public UIRestoreRoomDialog _003C_003E4__this;

			public Func<CancellationToken, Task<BCDAPDDMMEO>> buildRequest;

			private CancellationTokenSource _003C_003E7__wrap1;

			private CancellationToken _003Ctoken_003E5__3;

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

		[SerializeField]
		private Text infoText;

		[SerializeField]
		private Text statusHeaderText;

		[SerializeField]
		private Dropdown historyDropDown;

		private readonly List<ACDMEBDFJKM> GJKBODJDBNG;

		[SerializeField]
		private Button3D cancelButton;

		[SerializeField]
		private Button3D restoreButton;

		[SerializeField]
		private string latestSaveDifferentiator;

		[SerializeField]
		private string backupSaveDifferentiator;

		private HLNFDOBEGJO CHABDOLEEMD;

		private NCNIBHELJLF ACKEALENFIN;

		private MMCFCPOLMGM ABFMGHNAKGD;

		private CancellationTokenSource CLAKBBCNILK;

		private bool IKINBHPIAIH;

		private readonly StringBuilder NKGMMLAEEHK;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog()
		{
			return null;
		}

		private void GICEPLPOLNP(IList<ACDMEBDFJKM> GMDANADMFGG)
		{
		}

		public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		private void GKPMJKLDGAH(FDDHILGHJBB ICHBECDKHOJ)
		{
		}

		private void FMONCDMCEOI(bool AHALBLDMGJC = false)
		{
		}

		private void GDMMBAPLAJH(bool CEKBHBBHDCG, string HMEFOHBPPNE, bool LHDKOFKHKFO = false)
		{
		}

		private Dropdown.OptionData JAGBIIADDLC(int PDBJOFPFHDA, ACDMEBDFJKM CAIBHDAIACF, bool EFGOPBHJFBM)
		{
			return null;
		}

		private static string GODLJOHMNKK(ACDMEBDFJKM CAIBHDAIACF)
		{
			return null;
		}

		private string GDKLMLBHFAH(int? EJIHLJJMOBD, EAFLPCNDJNK? PKEFBHINBDE, HBEFBLGGFMC? NGBLANOILDA)
		{
			return null;
		}

		public void Button_Restore()
		{
		}

		private Task AILLPFGHEAK(Func<CancellationToken, Task<BCDAPDDMMEO>> DKIHEIGLJJC)
		{
			return null;
		}

		[CompilerGenerated]
		private static void FOCGHHONAPF(string BKDCPFHKDLB, ref EFAFOEBOAHI P_1)
		{
		}
	}
}
