using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

namespace RecRoom.Activities.StuntRunner
{
	public class StuntRunnerScoreBoard : MonoBehaviour
	{
		[Serializable]
		private struct RowData
		{
			public GameObject root;

			public TextMeshProUGUI place;

			public TextMeshProUGUI name;

			public TextMeshProUGUI time;
		}

		private struct EMKJCDNPONF
		{
			public CHILKDJABBF EKOFNPFCLMO;

			public string KNOPFGAGMCN;

			public int BBGNJMKOHPL;
		}

		private class PCGEBPCGFKO
		{
			public struct CHECDOLIPGJ
			{
				public KLCPLGECDIH KLMCNEIFLMA;

				public DFDECAEJBIO ACBGBAAHOIM;
			}

			public string OFMGPNLDCAB;

			public List<CHECDOLIPGJ> DLOLJJNCMJE;
		}

		private sealed class ALMKPAIIBBN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public bool initalWait;

			public StuntRunnerScoreBoard _003C_003E4__this;

			public BFPALKJDPLP courseStat;

			public BFPALKJDPLP requiredStat;

			public BFPALKJDPLP combinedStat;

			private List<EMKJCDNPONF> _003CcourseList_003E5__2;

			private List<EMKJCDNPONF> _003CcombinedList_003E5__3;

			private List<EMKJCDNPONF> _003Clist_003E5__4;

			private CHILKDJABBF _003ClocalPhotonPlayer_003E5__5;

			private int _003CplayerRow_003E5__6;

			private int _003Ci_003E5__7;

			private RowData[] _003C_003E7__wrap7;

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
			public ALMKPAIIBBN(int _003C_003E1__state)
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

		private sealed class IJLCANIDOBH
		{
			public StuntRunnerScoreBoard _003C_003E4__this;

			public PCGEBPCGFKO board;

			internal void _003CCreateNearbyLeaderboard_003Eb__0(LCENNMIHEBO result)
			{
			}
		}

		private sealed class LMMNDDMDPJO
		{
			public StuntRunnerScoreBoard _003C_003E4__this;

			public PCGEBPCGFKO board;

			internal void _003CCreateRankedLeaderboard_003Eb__0(LCENNMIHEBO result)
			{
			}
		}

		private sealed class IKNPLJBMMOH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public StuntRunnerScoreBoard _003C_003E4__this;

			private PCGEBPCGFKO _003Cl_003E5__2;

			private int _003ClocalPlayerId_003E5__3;

			private int _003CplayerRow_003E5__4;

			private int _003Ci_003E5__5;

			private RowData[] _003C_003E7__wrap5;

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
			public IKNPLJBMMOH(int _003C_003E1__state)
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
		private TextMeshProUGUI titleText;

		[SerializeField]
		private Color playerRowTopColor;

		[SerializeField]
		private Color playerRowBottomColor;

		[SerializeField]
		private Color defaultRowTopColor;

		[SerializeField]
		private Color defaultRowBottomColor;

		private VertexGradient CLBKHLIODLA;

		private VertexGradient ELHGCNLMHPA;

		[SerializeField]
		private RowData[] rows;

		[SerializeField]
		private int defaultStatsChannel;

		private string HFPDHGIPIIH;

		private LKGILLBEJEK JIKACNNBJPC;

		private const int JLJMBHNHCAL = 3;

		private PCGEBPCGFKO[] FLJDJBPIEEB;

		private int HNMNHADNJDI;

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		private void FIFPLDCDAJI(int MIKJMIMGAKO, bool JEACEDJAFMO)
		{
		}

		private List<EMKJCDNPONF> JFONOPDEDBB(BFPALKJDPLP CHJCAECALGD, BFPALKJDPLP KOAJFDIANGB)
		{
			return null;
		}

		public void UpdateBoard(BFPALKJDPLP PHFIHHHCENB, BFPALKJDPLP OKEMHNGMCEH, BFPALKJDPLP KOAJFDIANGB, bool MNEODJJMNBH)
		{
		}

		private IEnumerator<EGGPGCCKPCO> FJGMNKKOJMJ(BFPALKJDPLP PHFIHHHCENB, BFPALKJDPLP OKEMHNGMCEH, BFPALKJDPLP KOAJFDIANGB, bool MNEODJJMNBH)
		{
			return null;
		}

		public void InitWorldLeaderboard(int AALAGJNLHJL)
		{
		}

		private PCGEBPCGFKO HKIOHOALAPB(int AALAGJNLHJL, POCFIEIKIDJ.LHJOAPKMPKC FNKFLNKAGDD, string OFMGPNLDCAB)
		{
			return null;
		}

		private PCGEBPCGFKO PFCLEPLHAPN(int AALAGJNLHJL, POCFIEIKIDJ.LHJOAPKMPKC FNKFLNKAGDD, string OFMGPNLDCAB)
		{
			return null;
		}

		private void LPGJOKAELPJ(PCGEBPCGFKO GAOIKCBCELE, LCENNMIHEBO PCPEJHIMHJJ)
		{
		}

		private IEnumerator<EGGPGCCKPCO> AMKBFFELKIO()
		{
			return null;
		}

		private void NGIJOLPOECJ(PCGEBPCGFKO.CHECDOLIPGJ LHMOACJOHDA, ref RowData IHCPKAJHPBL)
		{
		}

		private void KHBHDOPPNIC()
		{
		}

		private void KNIBCJCDCKG(int EJIHLJJMOBD)
		{
		}
	}
}
