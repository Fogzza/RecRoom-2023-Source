using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Backtrace.Unity;
using Backtrace.Unity.Model;
using Backtrace.Unity.Types;
using UnityEngine;

namespace RecRoom.Core
{
	public class BacktraceManager : IDisposable
	{
		internal class OMNANNGOPOC
		{
			public string GKLDOBMJHII;

			public string KABKJMFHPLN;

			public int COJFPKDNEOL;

			public ReportFilterType DKICICBOOGM;

			public DeduplicationStrategy DOMHBHPOPPP;

			public float HKMIFDJHAEO;

			public int BPCLPECNJMF;

			public bool BOLBLJAHPCI;

			public int KBKCJIBKMBN;

			public int MBEMNKAEHHF;

			public string JCGHAOMIKGC;

			public string LBNDACBHPHM;

			public OMNANNGOPOC(string AIOEOEOANMF)
			{
			}

			public OMNANNGOPOC(string AIOEOEOANMF, KNHHGOIIJHG FPJKGKBOAOA)
			{
			}
		}

		private sealed class NALLCFDFJDJ
		{
			public BHNJIBDJFAL preferences;

			public IILDCCEMGBA gameConfigs;

			internal bool _003CClientInitialize_003Eb__0()
			{
				return false;
			}
		}

		private sealed class ADIAEIOONMJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public BacktraceManager _003C_003E4__this;

			private NALLCFDFJDJ _003C_003E8__1;

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
			public ADIAEIOONMJ(int _003C_003E1__state)
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

		private const string GOHDKKNLMKN = "https://submit.backtrace.io/recroom/68bd650c1b4d66b82d0af51d5feb00632872fa8c186871ae4323dfa198daded5/json";

		private const string IOOLCLHHMAN = "https://submit.backtrace.io/recroom/18b756148971d753d211cf55fd8f37e6d10be4c0434ff9463f7e599765c53462/json";

		private const string HGNGKFLPAPJ = "https://submit.backtrace.io/recroom/7dc4ad0837d3c3e7074f4f8452de3439fa24254f97ef135aad5464cad1618df2/json";

		private const string KCNOKGBHMKI = "https://recroom-dataplane.rudderstack.com/v1/webhook?writeKey=2KCOY7nTwRbB2DWa0Z3BVUiS4v4";

		private const string FPDMNAJKKCC = "backtrace/database";

		private const int IELGOPPMPGA = 50;

		private bool OEAONLGBBPN;

		private BacktraceClient EBILMCDPJEG;

		private Dictionary<string, string> PAONDKMPBFH;

		private Regex LJOGJAODPCB;

		private int EFDMEGIMDOC;

		private int HLHNHKMIOMH;

		private bool DCKNEBBONEO;

		private FJCOIIPMCLL PCMOJHJCDLA;

		private static BacktraceManager CMDPMJBEBAB;

internal FJCOIIPMCLL ACLHLOLBEJB
{
get 		{
			return null;
		}

}

public bool BFDBCMGIOBG
{
get 		{
			return false;
		}

set {
		}
}

public static BacktraceManager OFDKPDDLIJC
{
get 		{
			return null;
		}

}

		public void Dispose()
		{
		}

		public void IDBNELDIPOP(string OFCFPGACNJB, Dictionary<string, string> PJBNCGFJODJ = null, List<string> KMHAIOEEHBD = null, Action<BacktraceResult> ONAFALABHKI = null)
		{
		}

		public void IDBNELDIPOP(Exception GCBHEJANCJK, Dictionary<string, string> PJBNCGFJODJ = null, List<string> KMHAIOEEHBD = null, Action<BacktraceResult> ONAFALABHKI = null)
		{
		}

		public void OFJMBIIDEKD(string FDAIMOMOHIG, string IPMIIEAGJKC)
		{
		}

		private bool IOIOLOLCGKI(OMNANNGOPOC FPJKGKBOAOA)
		{
			return false;
		}

		private bool POPIHNKMDMI(ReportFilterType NIFOGEBEDNG, Exception GCBHEJANCJK, string OFCFPGACNJB)
		{
			return false;
		}

		private IEnumerator<EGGPGCCKPCO> LKKHPFNDOHA()
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod]
		public static void OnApplicationInitialize()
		{
		}
	}
}
