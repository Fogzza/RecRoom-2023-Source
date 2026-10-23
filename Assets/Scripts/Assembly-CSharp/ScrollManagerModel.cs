using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AGUI.StackedUI;
using RRUI;
using RRUI.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using frame8.Logic.Misc.Visual.UI.MonoBehaviours;

public class ScrollManagerModel : RRUIModel
{
	public class FMKGKAPHKDF
	{
		private sealed class HCGMKEDCOAO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public FMKGKAPHKDF _003C_003E4__this;

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
			public HCGMKEDCOAO(int _003C_003E1__state)
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

		public readonly ScrollbarFixer8 BHBFAAFBGBD;

		public readonly Hideable DELBEHFDOOC;

		public readonly BaseRaycaster PNIDNMMGGBJ;

		private float ENNODFGDAML;

		private float FEFCBMBOCJM;

		private float FBEABMBCECH;

		private LKGILLBEJEK ACCJIFBCOIA;

		public FMKGKAPHKDF(ScrollbarFixer8 BHBFAAFBGBD, Hideable DELBEHFDOOC)
		{
		}

		public void IBKHPFLLAEA(float PCJGAMJMPIB)
		{
		}

		private IEnumerator<EGGPGCCKPCO> BPDBAPJFBKN()
		{
			return null;
		}
	}

	private const float HCGCNNFDJOG = 5.1f;

	private const float KPNHANPPEIG = 1f;

	private const float CAFFCANMFAK = 0.1f;

	private const float KDLOKDOCEDJ = 0.9f;

	public const bool DEFAULT_ADAPTIVE_PREFER_RIGHT_HAND = true;

	[SerializeField]
	private RectTransform canvasRect;

	private bool AMCPEGMPJIK;

	private JNKNMMDAHCF JPKKAMIKFJO;

	private BFABKMNDMMP LFBKPABHEJO;

	private Tool IECBBOAJOPP;

	private RRUIRootScreen DANJGEKEMAI;

	private ScrollManagerModel IMDPMFJOKGF;

	private bool OEAONLGBBPN;

	private FMKGKAPHKDF DOBDMEAEPFM;

	private FMKGKAPHKDF NNIILLJHJDO;

	private bool LFKBCNNFAPB;

	private List<FMKGKAPHKDF> DFGOLKOKEEE;

	private List<OverlayEntryListModel> KNDCAIGCPOP;

public bool UseExteriorScrollbars
{
get 	{
		return false;
	}

}

public bool VRThumbstickScrollingEnabled
{
get 	{
		return false;
	}

}

public bool IsAdaptive
{
get 	{
		return false;
	}

}

public bool AdaptiveCurrentlyPreferredRightSide
{
get 	{
		return false;
	}

set {
	}
}

private PlayerHand.ICBKGDOJNDN HNKFAMNDFBN
{
get 	{
		return PlayerHand.ICBKGDOJNDN.Left;
	}

}

private JNKNMMDAHCF DHCLACKALOF
{
get 	{
		return null;
	}

}

private BFABKMNDMMP HLPODFILCCO
{
get 	{
		return null;
	}

}

public bool PreferRightScrollbar
{
get 	{
		return false;
	}

set {
	}
}

public bool CanSwapSides
{
get 	{
		return false;
	}

}

public IReadOnlyList<FMKGKAPHKDF> ActiveScrollbars
{
get 	{
		return null;
	}

}

protected override bool GIHBNOOCJDD
{
get 	{
		return false;
	}

}

	private void HKOJAPMDEJH()
	{
	}

	public FMKGKAPHKDF GetSideScrollbar(bool GCFNDMNODND)
	{
		return null;
	}

	private void JFPPFJJACEJ(ScrollbarFixer8 BHBFAAFBGBD, out bool LBAGGBJJBEO, out bool LJKDMBPBONI)
	{
		LBAGGBJJBEO = default;
		LJKDMBPBONI = default;
	}

	public bool GetPageButtonInteractable(bool DDMACDKCIGI, bool JDPMOCLEIEI)
	{
		return false;
	}

	public bool GetCorrespondingScrollbarActive(bool DDMACDKCIGI)
	{
		return false;
	}

	public void PageScrollbar(bool DDMACDKCIGI, bool OPDMKINEDBF)
	{
	}

	public void RegisterScrollbar(FMKGKAPHKDF PCPEJHIMHJJ)
	{
	}

	public void UnregisterScrollbar(FMKGKAPHKDF PCPEJHIMHJJ)
	{
	}

	private bool NMABLEPBPKH(FMKGKAPHKDF HPHJGCEOHJK)
	{
		return false;
	}

	public void OnScrollbarSizeChanged()
	{
	}

	public void OnScrollbarVisibilityChanged()
	{
	}

	public void OnScrollbarValueChanged()
	{
	}

	private void BEKFIMLGKMB(Tool IEGMBEPJMGC)
	{
	}

	private void EHCAPMPKGFF()
	{
	}

	private void PEOGJMMGFLE(bool MDBIFMEJIME)
	{
	}

	private void AHMJIKBNBHO()
	{
	}

	private void PHCBKODNHKH()
	{
	}

	private void GMAPINHCACM()
	{
	}

	private void EHOCBEKJBPJ()
	{
	}

	protected override void IILPBDLFFKG()
	{
	}

	protected override void BJPPPBGBLAO()
	{
	}

	protected override void LPBNNNGFPIF()
	{
	}

	protected override LAHBDKNMNHN KANNLKCLIOF()
	{
		return null;
	}

	protected override void DHHOMFCCFKP()
	{
	}
}
