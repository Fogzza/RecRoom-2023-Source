using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Backtrace.Unity.Model;
using RecRoom.CircuitsV2;

namespace RecRoom.Debugging
{
	public sealed class UgcWatchdog : NetworkedSingletonMonoBehaviour<UgcWatchdog>
	{
		[Serializable]
		public sealed class UgcWatchdogConfig
		{
			public bool LogLoadComplete;

			public int[] LoadLogTimesSeconds;

			public int LoadBacktraceTimeoutSeconds;

			public float LoadingBacktraceProbability;

			public int LoadTimeoutSeconds;

			public int AdditionalLogTraceSizeForLoading;

			public HJDBOADFHMC AdditionalTraceFlagsForLoading;

			public int CorruptRoomDetectionTimeSeconds;

			public float CorruptRoomDetectionProbability;
		}

		public sealed class MFFAJLFDAME : KADCGADLAOC.MHELKIHLEEE
		{
			private readonly UgcWatchdog JNOECGNNGPM;

			public MFFAJLFDAME(UgcWatchdog DIJPFIMLAFB)
			{
			}

			private void EFPGJHKALLL(int JIMDMKNEJHJ, in Guid AMGNCPLIAAC)
			{
			}

			void KADCGADLAOC.MHELKIHLEEE.BDGFDGCFJIM(int JIMDMKNEJHJ, in Guid AMGNCPLIAAC)
			{
				//ILSpy generated this explicit interface implementation from .override directive in EFPGJHKALLL
				this.EFPGJHKALLL(JIMDMKNEJHJ, in AMGNCPLIAAC);
			}
		}

		public sealed class DEAOBLDNFGA
		{
			private struct AOAIBIMCCIN
			{
				private int KBNHDGFKJPE;

				private long EICCJMGPPKB;

				private bool IHOOEPGPDOA;

public int JJKEBPDDPIE
{
get 				{
					return 0;
				}

private set {
				}
}

				public bool HGGGFGGBNOC(int LJNLBOBOJFI)
				{
					return false;
				}

				public void PAKIMOKGMBI()
				{
				}

				public bool DMABLOOGMPG(long LFNENBOPIDO)
				{
					return false;
				}

				public static AOAIBIMCCIN ELCFDEFNBDD()
				{
					return default;
				}
			}

			public interface MGPPCKEIEKL
			{
				bool FPNIGFKJKKO();

				bool ELNJFFCEONK();

				long HNIHEEGGFMI();

				void FGCPKCGMNGL(int KLLJLLBGPKE, bool OOMBAEEPDDN, bool EFPDIMEFEFC);

				int[] ADNBPFPDMAM();

				int NOEFAPCADLB();

				int LDAMOGHHADH();

				void AJHOPMACHGH();

				void HOGOHEBMICE(double KLLJLLBGPKE);

				void CDJHKCNAIKI();
			}

			public class KAMHAPMMHJA : MGPPCKEIEKL
			{
				private sealed class CMBFLJOPEDL
				{
					[StructLayout((LayoutKind)3)]
					private struct _003C_003CRecRoom_002DDebugging_002DUgcWatchdog_002DInfiniteLoadDetection_002DIDebugDependencies_002DReportLongLoad_003Eb__0_003Ed : IAsyncStateMachine
					{
						public int _003C_003E1__state;

						public AsyncTaskMethodBuilder _003C_003Et__builder;

						public CMBFLJOPEDL _003C_003E4__this;

						private TaskAwaiter _003C_003Eu__1;

						private TaskAwaiter<BacktraceResult> _003C_003Eu__2;

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

					public Guid? customId;

					public Task origTask;

					internal Task _003CRecRoom_002EDebugging_002EUgcWatchdog_002EInfiniteLoadDetection_002EIDebugDependencies_002EReportLongLoad_003Eb__0()
					{
						return null;
					}
				}

				private sealed class LDCGEPEJCCD
				{
					[StructLayout((LayoutKind)3)]
					private struct _003C_003CRecRoom_002DDebugging_002DUgcWatchdog_002DInfiniteLoadDetection_002DIDebugDependencies_002DOnLoadFinish_003Eb__0_003Ed : IAsyncStateMachine
					{
						public int _003C_003E1__state;

						public AsyncTaskMethodBuilder _003C_003Et__builder;

						public LDCGEPEJCCD _003C_003E4__this;

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

					public Task uploadTask;

					public PDKMOBAFOAA? token;

					internal Task _003CRecRoom_002EDebugging_002EUgcWatchdog_002EInfiniteLoadDetection_002EIDebugDependencies_002EOnLoadFinish_003Eb__0()
					{
						return null;
					}
				}

				public static readonly KAMHAPMMHJA OFDKPDDLIJC;

				private CameraFade.BAIBOJEOOGB PADDGJCJGAN;

				private bool COMPHDOCCFO;

				private PDKMOBAFOAA? LMPLBCLFECE;

				private bool LHGJOEAFKKO()
				{
					return false;
				}

				bool MGPPCKEIEKL.FPNIGFKJKKO()
				{
					//ILSpy generated this explicit interface implementation from .override directive in LHGJOEAFKKO
					return this.LHGJOEAFKKO();
				}

				private bool AIMIGINNJBP()
				{
					return false;
				}

				bool MGPPCKEIEKL.ELNJFFCEONK()
				{
					//ILSpy generated this explicit interface implementation from .override directive in AIMIGINNJBP
					return this.AIMIGINNJBP();
				}

				private long PPAENNOLPHN()
				{
					return 0L;
				}

				long MGPPCKEIEKL.HNIHEEGGFMI()
				{
					//ILSpy generated this explicit interface implementation from .override directive in PPAENNOLPHN
					return this.PPAENNOLPHN();
				}

				private void FKDGCMJIEBA(int KLLJLLBGPKE, bool OOMBAEEPDDN, bool EFPDIMEFEFC)
				{
				}

				void MGPPCKEIEKL.FGCPKCGMNGL(int KLLJLLBGPKE, bool OOMBAEEPDDN, bool EFPDIMEFEFC)
				{
					//ILSpy generated this explicit interface implementation from .override directive in FKDGCMJIEBA
					this.FKDGCMJIEBA(KLLJLLBGPKE, OOMBAEEPDDN, EFPDIMEFEFC);
				}

				private int[] FFPNFMLCLIJ()
				{
					return null;
				}

				int[] MGPPCKEIEKL.ADNBPFPDMAM()
				{
					//ILSpy generated this explicit interface implementation from .override directive in FFPNFMLCLIJ
					return this.FFPNFMLCLIJ();
				}

				private int BNGLEEKPHFH()
				{
					return 0;
				}

				int MGPPCKEIEKL.NOEFAPCADLB()
				{
					//ILSpy generated this explicit interface implementation from .override directive in BNGLEEKPHFH
					return this.BNGLEEKPHFH();
				}

				private int KJMACKFBNNK()
				{
					return 0;
				}

				int MGPPCKEIEKL.LDAMOGHHADH()
				{
					//ILSpy generated this explicit interface implementation from .override directive in KJMACKFBNNK
					return this.KJMACKFBNNK();
				}

				private void IHEAOBKOFFI()
				{
				}

				void MGPPCKEIEKL.AJHOPMACHGH()
				{
					//ILSpy generated this explicit interface implementation from .override directive in IHEAOBKOFFI
					this.IHEAOBKOFFI();
				}

				private void GPCIAFFDDCF(double KLLJLLBGPKE)
				{
				}

				void MGPPCKEIEKL.HOGOHEBMICE(double KLLJLLBGPKE)
				{
					//ILSpy generated this explicit interface implementation from .override directive in GPCIAFFDDCF
					this.GPCIAFFDDCF(KLLJLLBGPKE);
				}

				private void JJGALEJKGGK()
				{
				}

				void MGPPCKEIEKL.CDJHKCNAIKI()
				{
					//ILSpy generated this explicit interface implementation from .override directive in JJGALEJKGGK
					this.JJGALEJKGGK();
				}

				private static UgcWatchdogConfig PFAFGEAKGKN()
				{
					return null;
				}

				private static bool BIGBENNANCN()
				{
					return false;
				}

				private static bool LFNHMELGIJE()
				{
					return false;
				}

				private static bool HGKLNDGAMJD(CameraFade.BAIBOJEOOGB? CKHHGBNHHCK)
				{
					return false;
				}
			}

			private readonly MGPPCKEIEKL IDHBAPKDAEK;

			private int[] EGCPGKHAEJK;

			private long[] EEFLKMECABB;

			private AOAIBIMCCIN BFAJDDGGLAD;

			private AOAIBIMCCIN CMMIEKIBELJ;

			private int LINOEFPHBEN;

			private long CEJPBBDAGMP;

			public DEAOBLDNFGA(MGPPCKEIEKL OEEJOADDENI = null)
			{
			}

			public void CDJHKCNAIKI()
			{
			}
		}

		public sealed class AMIJJHKDNIP : IDisposable
		{
			private readonly struct CBEIMAKNMCG
			{
				public readonly int BODCMDDMBDM;

				public readonly int EMIEGEPGIGI;

				public readonly int LMMMMFNCNCN;

				public readonly EAFLPCNDJNK KAAIIIEPCIA;

				public readonly CILEIOOHEOB LKMCFNPPHIL;

				public readonly CircuitsV2Manager.HFLMJPOEMCL.CLOMDPAMNIM GEDCDLICEOK;

				public readonly bool PCPHAHIICOK;

				public readonly bool LKIODEGLCAB;

				public readonly bool GKBONACFAMA;

				public CBEIMAKNMCG(int PGBACBNDDLB, int GEFPAOHLCFO, int JEIEMENLKNM, EAFLPCNDJNK PKEFBHINBDE, CILEIOOHEOB ACFOBOCFNAH, CircuitsV2Manager.HFLMJPOEMCL.CLOMDPAMNIM GKBMNBPJCJO, bool MGGAJNENFEO, bool ONKKJINLBMD, bool LDNPKCGBJPA)
				{
					BODCMDDMBDM = 0;
					EMIEGEPGIGI = 0;
					LMMMMFNCNCN = 0;
					KAAIIIEPCIA = EAFLPCNDJNK.Steam;
					LKMCFNPPHIL = CILEIOOHEOB.Desktop_Valve;
					GEDCDLICEOK = CircuitsV2Manager.HFLMJPOEMCL.CLOMDPAMNIM.Invalid;
					PCPHAHIICOK = false;
					LKIODEGLCAB = false;
					GKBONACFAMA = false;
				}
			}

			public interface IDIDMPILBOA : KADCGADLAOC.DEBCJFOOPOG
			{
				long HNIHEEGGFMI();

				void KBIKIIADEFH(int MALJIJKBHLE, int PMPBEOKAGLD, int HCJDDPHFMHM, string PKEFBHINBDE, string ACFOBOCFNAH, bool OANPJOIJCMD, string DKFNNANFNHP, bool HBKBGMDGBOP, int NPBDOCHOOJG, int FNLKBGBDIII, string GMGOGOCIKMB, string HNCPFLINHNO, int LFCJODMOLPF, int POPODLIBPBK, string COCBKKFLFLD, string OLFKGGEIPFJ, int NNIMKKEEHNC, int FLBBDOGOEOE, string PDCKDJIADHM, string NNDKFJLPIPL, int CLABGOHJGNO, string BILDHFIOOFD, string BEFCPHGJJFA, int HOCNDCMBAMM, string ADIPNOGHCDL, string OPHHLAKIDAN, int BDPBADGLHBA, string HPHIECHPABL, string MBLAKLFGCHD, int IHEDPGGLMLF, string IMGGEFJBCMJ, string AAEJFHFIMEH);

				int MCOHNJDKCKF();
			}

			public class BKBKNDHGAHA : KADCGADLAOC.LDAFKPDGKCE, IDIDMPILBOA, KADCGADLAOC.DEBCJFOOPOG
			{
				public new static IDIDMPILBOA OFDKPDDLIJC;

				private long CMCMBPFEENF()
				{
					return 0L;
				}

				long IDIDMPILBOA.HNIHEEGGFMI()
				{
					//ILSpy generated this explicit interface implementation from .override directive in CMCMBPFEENF
					return this.CMCMBPFEENF();
				}

				private void OJFBBCKBDPJ(int MALJIJKBHLE, int PMPBEOKAGLD, int HCJDDPHFMHM, string PKEFBHINBDE, string ACFOBOCFNAH, bool OANPJOIJCMD, string DKFNNANFNHP, bool HBKBGMDGBOP, int NPBDOCHOOJG, int FNLKBGBDIII, string GMGOGOCIKMB, string HNCPFLINHNO, int LFCJODMOLPF, int POPODLIBPBK, string COCBKKFLFLD, string OLFKGGEIPFJ, int NNIMKKEEHNC, int FLBBDOGOEOE, string PDCKDJIADHM, string NNDKFJLPIPL, int CLABGOHJGNO, string BILDHFIOOFD, string BEFCPHGJJFA, int HOCNDCMBAMM, string ADIPNOGHCDL, string OPHHLAKIDAN, int BDPBADGLHBA, string HPHIECHPABL, string MBLAKLFGCHD, int IHEDPGGLMLF, string IMGGEFJBCMJ, string AAEJFHFIMEH)
				{
				}

				void IDIDMPILBOA.KBIKIIADEFH(int MALJIJKBHLE, int PMPBEOKAGLD, int HCJDDPHFMHM, string PKEFBHINBDE, string ACFOBOCFNAH, bool OANPJOIJCMD, string DKFNNANFNHP, bool HBKBGMDGBOP, int NPBDOCHOOJG, int FNLKBGBDIII, string GMGOGOCIKMB, string HNCPFLINHNO, int LFCJODMOLPF, int POPODLIBPBK, string COCBKKFLFLD, string OLFKGGEIPFJ, int NNIMKKEEHNC, int FLBBDOGOEOE, string PDCKDJIADHM, string NNDKFJLPIPL, int CLABGOHJGNO, string BILDHFIOOFD, string BEFCPHGJJFA, int HOCNDCMBAMM, string ADIPNOGHCDL, string OPHHLAKIDAN, int BDPBADGLHBA, string HPHIECHPABL, string MBLAKLFGCHD, int IHEDPGGLMLF, string IMGGEFJBCMJ, string AAEJFHFIMEH)
				{
					//ILSpy generated this explicit interface implementation from .override directive in OJFBBCKBDPJ
					this.OJFBBCKBDPJ(MALJIJKBHLE, PMPBEOKAGLD, HCJDDPHFMHM, PKEFBHINBDE, ACFOBOCFNAH, OANPJOIJCMD, DKFNNANFNHP, HBKBGMDGBOP, NPBDOCHOOJG, FNLKBGBDIII, GMGOGOCIKMB, HNCPFLINHNO, LFCJODMOLPF, POPODLIBPBK, COCBKKFLFLD, OLFKGGEIPFJ, NNIMKKEEHNC, FLBBDOGOEOE, PDCKDJIADHM, NNDKFJLPIPL, CLABGOHJGNO, BILDHFIOOFD, BEFCPHGJJFA, HOCNDCMBAMM, ADIPNOGHCDL, OPHHLAKIDAN, BDPBADGLHBA, HPHIECHPABL, MBLAKLFGCHD, IHEDPGGLMLF, IMGGEFJBCMJ, AAEJFHFIMEH);
				}

				private int NLEEDDMNOBH()
				{
					return 0;
				}

				int IDIDMPILBOA.MCOHNJDKCKF()
				{
					//ILSpy generated this explicit interface implementation from .override directive in NLEEDDMNOBH
					return this.NLEEDDMNOBH();
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct BKADGNPCFAC : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public AMIJJHKDNIP _003C_003E4__this;

				public CancellationToken cancellationToken;

				private TaskAwaiter<global::JIAHAEBODHG<CBEIMAKNMCG>.CPHKOLJGGMO[]> _003C_003Eu__1;

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

			private int NGKJJNANCNC;

			private long KBILDOGHICI;

			private readonly IDIDMPILBOA IDHBAPKDAEK;

			private readonly global::JIAHAEBODHG<CBEIMAKNMCG> KGEGGOECDPO;

			private long? HFOGDKMIBBL;

			private CancellationTokenSource OAAFINDBBOB;

			private bool BBMNKLMDJFB;

			private Task<TaskStatus> FBKDLAFLKPC;

public Task<TaskStatus> IPDHCKLEIGF
{
get 			{
				return null;
			}

private set {
			}
}

			public AMIJJHKDNIP(KADCGADLAOC.MHELKIHLEEE HJOOFGLHNBG, IDIDMPILBOA OEEJOADDENI = null)
			{
			}

			public void CIFKLFCAACP()
			{
			}

			public void CDJHKCNAIKI()
			{
			}

			private Task OJOAENCEJBO(CancellationToken NDKAKDJMDIF)
			{
				return null;
			}

			public void EKKMIGMGOIA(in Guid AMGNCPLIAAC, int OOCPEFJONBB, int PGBACBNDDLB, int GEFPAOHLCFO, int JEIEMENLKNM, EAFLPCNDJNK PKEFBHINBDE, CILEIOOHEOB ACFOBOCFNAH, CircuitsV2Manager.HFLMJPOEMCL.CLOMDPAMNIM GKBMNBPJCJO, bool MGGAJNENFEO, bool ONKKJINLBMD, bool LDNPKCGBJPA)
			{
			}

			public void Dispose()
			{
			}

			[CompilerGenerated]
			private Task FHNAJACDLCO()
			{
				return null;
			}

			[CompilerGenerated]
			internal static string DNJJNPJPELP(IList<int> DIJPFIMLAFB)
			{
				return null;
			}

			[CompilerGenerated]
			internal static string OCABOMGIPEK(IList<int> DIJPFIMLAFB)
			{
				return null;
			}
		}

		private sealed class KJNNDCOLDFD
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CRpcCorruptDataRequest_003Eb__0_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public KJNNDCOLDFD _003C_003E4__this;

				private CHILKDJABBF _003CrequestingPlayer_003E5__2;

				private int? _003ClocalPlayerActorNumber_003E5__3;

				private CircuitsV2Manager _003CstateValidCV2Manager_003E5__4;

				private TaskAwaiter<int> _003C_003Eu__1;

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

			public UgcWatchdog _003C_003E4__this;

			public int requestingPlayerActorNumber;

			public Guid requestId;

			public Func<CHILKDJABBF, bool> _003C_003E9__1;

			internal Task _003CRpcCorruptDataRequest_003Eb__0()
			{
				return null;
			}

			internal bool _003CRpcCorruptDataRequest_003Eb__1(CHILKDJABBF i)
			{
				return false;
			}
		}

		private UgcWatchdogConfig HKGBPHDIKOI;

		private string EBAFNLEOINL;

		private bool IKCHEJKHEEM;

		private bool GCIAPFGPPOO;

		private Task IGJBLJAFAGL;

		private DEAOBLDNFGA AAKHGNEDOBD;

		private AMIJJHKDNIP IAAHPGGFJNF;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void LFPKJOHNOIE()
		{
		}

		private void Update()
		{
		}

		public void SendCorruptDataRequest(int DMGLNDEGALK, in Guid AMGNCPLIAAC)
		{
		}

		[PBOMGCLBFHF]
		public void RpcCorruptDataRequest(int DMGLNDEGALK, Guid AMGNCPLIAAC)
		{
		}

		[PBOMGCLBFHF]
		public void RpcCorruptDataResponse(Guid AMGNCPLIAAC, int OOCPEFJONBB, int PGBACBNDDLB, int GEFPAOHLCFO, int JEIEMENLKNM, EAFLPCNDJNK PKEFBHINBDE, CILEIOOHEOB ACFOBOCFNAH, CircuitsV2Manager.HFLMJPOEMCL.CLOMDPAMNIM GKBMNBPJCJO, bool MGGAJNENFEO, bool ONKKJINLBMD, bool LDNPKCGBJPA)
		{
		}

		public void LogWasMakerPenEverOut()
		{
		}

		public void ForceRoomCorruptionDetection()
		{
		}

		[CompilerGenerated]
		internal static CircuitsV2Manager JJOGAMCLMCF()
		{
			return null;
		}
	}
}
