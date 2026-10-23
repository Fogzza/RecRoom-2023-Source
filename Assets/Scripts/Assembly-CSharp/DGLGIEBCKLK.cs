using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using RecRoom.Core;
using RecRoom.Core.Controllers.ScreenBehaviors;
using RecRoom.Core.Imposters;
using UnityEngine;

public class DGLGIEBCKLK : global::NJHDFCIBDLG<DGLGIEBCKLK, InventoryPerHandScreenPlayerBehaviorConfig>
{
	private class EPAICFNLNNG : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		private struct GAKGHDHANPK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public EPAICFNLNNG _003C_003E4__this;

			public Tool tool;

			public ImposterRenderConfig imposterConfig;

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

		public readonly HHPGMLNAJBO EEKFCFEADCB;

		public Tool CGAAICDMLAG;

		private bool KBDIBPJIHNN;

		private readonly RenderTexture AEFDOLILMOP;

		private CancellationTokenSource IDHBMGIMBCD;

public RenderTexture NBDINAGDGME
{
get 		{
			return null;
		}

}

		public EPAICFNLNNG(HHPGMLNAJBO DFFEOHFKPDE)
		{
		}

		public void Dispose()
		{
		}

		public void LIPNFADPCON(Tool IEGMBEPJMGC, ImposterRenderConfig HHMCKFOAFIL)
		{
		}
	}

	private enum FIFLGNAKNKP
	{
		DISABLED = 0,
		ENABLED = 1,
		RESTRICTED = 2
	}

	private sealed class AHPBGONEHIP
	{
		public HHPGMLNAJBO[] entries;

		public DGLGIEBCKLK _003C_003E4__this;

		internal void _003CGetInitialShortcutEntries_003Eg__InitializeRadialHolsterSlot_007C0(PlayerToolEquipSlot equipSlot, string name, KHJHENDFNGH entryPosition)
		{
		}

		internal void _003CGetInitialShortcutEntries_003Eb__3()
		{
		}

		internal bool _003CGetInitialShortcutEntries_003Eb__4()
		{
			return false;
		}

		internal void _003CGetInitialShortcutEntries_003Eb__5()
		{
		}

		internal bool _003CGetInitialShortcutEntries_003Eb__6()
		{
			return false;
		}
	}

	private sealed class HOAPEJEPPJN
	{
		public PlayerToolEquipSlot equipSlot;

		public string name;

		public AHPBGONEHIP CS_0024_003C_003E8__locals1;

		internal void _003CGetInitialShortcutEntries_003Eb__1()
		{
		}

		internal bool _003CGetInitialShortcutEntries_003Eb__2()
		{
			return false;
		}
	}

	private sealed class GJJEEJJGPMA
	{
		public Tool toolToStow;

		internal void _003CRunHolsterSwapCoroutine_003Eb__0()
		{
		}
	}

	private sealed class BKPFBKJDHIL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public PlayerToolEquipSlot equipSlot;

		public DGLGIEBCKLK _003C_003E4__this;

		public string label;

		private GJJEEJJGPMA _003C_003E8__1;

		private Tool _003CtoolToGrab_003E5__2;

		private PlayerHand _003CdesiredHand_003E5__3;

		private KBEDPKIBCNN _003Chandedness_003E5__4;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public BKPFBKJDHIL(int _003C_003E1__state)
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

	private sealed class EOMCLHHLONB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public BKMDFCCNPGE requestedToolType;

		public DGLGIEBCKLK _003C_003E4__this;

		private KBEDPKIBCNN _003Chandedness_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public EOMCLHHLONB(int _003C_003E1__state)
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

	private const int FCODNJFMHOE = 256;

	private static int ONIPANKICBO;

	private static bool GICAIKOCPIM;

	private static FIHGBEHGLGB IIAPFJKMIGF;

	private bool IFAKFCLAKON;

	private LKGILLBEJEK EECGDNAIOFG;

	private int CEHDGFPMIPN;

	private MDEJADHJOEJ BGBIFFLGANM;

	private KKHFFLBNJPD OEDGOHNFFKI;

	private readonly Dictionary<PlayerToolEquipSlot, EPAICFNLNNG> HGFKHLHOMKN;

	private readonly EPAICFNLNNG FODBDILECGK;

	private static readonly Sprite NFDPPLAFEBA;

	private static readonly Sprite IJFDBMKMPJG;

	private string PAILDFDOGBB;

public override int LDHIBGALEDK
{
get 	{
		return 0;
	}

}

public override bool HFDBOJHHDHK
{
get 	{
		return false;
	}

}

private FMNJCGLEDJO JGEBDGKBLPN
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private FMNJCGLEDJO GNDNEDAJGNL
{
get 	{
		return FMNJCGLEDJO.SmartInteractButton;
	}

}

private IPDNABNIAEH BFKELFCAOFI
{
get 	{
		return IPDNABNIAEH.Emotes;
	}

}

private bool BBDHKKCGPLK
{
get 	{
		return false;
	}

}

	public override void IHEKMEOIBOI(InventoryPerHandScreenPlayerBehaviorConfig FPJKGKBOAOA, AJBBKCCIBGF HJOOFGLHNBG)
	{
	}

	public override void Dispose()
	{
	}

	protected override void LDBOEGKIPKO()
	{
	}

	protected override void LIKPEPFGGFO()
	{
	}

	public override void EHMICKMBCPH()
	{
	}

	private void FKANAICFGPE(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void CPDHLMCLGOJ()
	{
	}

	private void EBCKDELNKOL(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
	{
	}

	private void HECDABOMKHP()
	{
	}

	private bool ONEDDAOCLCE(out bool NCNJBBIMFKI)
	{
		NCNJBBIMFKI = default;
		return false;
	}

	private void HFDHDCKHKAH(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
	{
	}

	private void JHDDPDNGNJA(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
	{
	}

	private void HEBGJGMCHEK(PlayerHand PMNLJGLDMJN, Tool IEGMBEPJMGC)
	{
	}

	private void MEMBPBALAKE(PlayerHand PMNLJGLDMJN, Tool IEGMBEPJMGC)
	{
	}

	private void BIPNGGDKEEA()
	{
	}

	private HHPGMLNAJBO[] NLKCEGGCLOE()
	{
		return null;
	}

	private void MDLFDPFJDMB()
	{
	}

	private void LLEOOMOHHID(Tool IEGMBEPJMGC, PlayerToolEquipSlot HHOGFBCFGAB)
	{
	}

	private void MICLLOPPBCM(Tool DMEHNKDLHAC)
	{
	}

	private void JGMAOCPFPKC(bool NCNJBBIMFKI = false)
	{
	}

	private bool BCNDIFOEFDB(PlayerToolEquipSlot JMEEAMAPEDC)
	{
		return false;
	}

	private void BJJOFHFEEOE(PlayerToolEquipSlot JMEEAMAPEDC, string IEACNHGAIIE)
	{
	}

	private IEnumerator<EGGPGCCKPCO> BFCNNHMHDOL(PlayerToolEquipSlot JMEEAMAPEDC, string IEACNHGAIIE)
	{
		return null;
	}

	private void ANHFBLPMHBF(BKMDFCCNPGE HDNBCHPPDLN)
	{
	}

	private IEnumerator<EGGPGCCKPCO> PBDCEFLCDDC(BKMDFCCNPGE HDNBCHPPDLN)
	{
		return null;
	}

	private bool BGEFNCMPFMP(BKMDFCCNPGE FODPLAHKCFE)
	{
		return false;
	}

	private void HPBBJLMFAOH(PlayerToolEquipSlot HHOGFBCFGAB, FMNJCGLEDJO POINFDHCNCM)
	{
	}

	private bool NBEOFMGLGAD(BKMDFCCNPGE CKEPLIBLBFJ)
	{
		return false;
	}

	private void EMFIPMHIFKK()
	{
	}

	private void NHEDJPOICFB()
	{
	}

	[CompilerGenerated]
	private void NODMPAMFEKN()
	{
	}

	[CompilerGenerated]
	private void FFHNEHKIANC()
	{
	}
}
