using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecNet;
using RecRoom.Async;

public class BootSequence : SingletonMonoBehaviour<BootSequence>, NEPJJLMCFPM
{
	public class NJIJPADHPEC
	{
		public struct BPEAHMIJHBF
		{
			public DMAIEODHOGA KDOMBDJJJCI;
		}

		public bool CPKDCKMLKCL;

		public string HHHMANOIGJN;

		public int? JPDFDKBECLP;

		public string HHPEHMCHMGA;

		public DBECJLAIPEL? IENALKJJBJC;

		public bool MHKLIEKNHLA;

		public BPEAHMIJHBF? OEHHLLJJPPF;

		public long? DGHAPALLIEM;
	}

	private enum BCNGINLINPH
	{
		INVALID = -1,
		DOWNLOAD_SETTINGS = 0,
		SEND_INITIALIZE = 1,
		DOWNLOAD_DATA = 2,
		COMPLETE = 3
	}

	private enum INFFBPOJOIJ
	{
		INVALID = -1,
		APP_SETUP = 0,
		PRE_INITIALIZATION = 1,
		LOGIN = 2,
		POST_LOGIN_RECNET_OPERATIONS = 3,
		CALIBRATION = 4,
		POST_LOGIN_INITIALIZATION = 5,
		LOAD_INITIAL_SCENE = 100,
		POST_LOAD_INITIAL_SCENE = 101,
		ERROR = 1000
	}

	private sealed class ALCCEBFBPGP
	{
		public BootSequence _003C_003E4__this;

		public string timerName;

		internal void _003CTimePromise_003Eb__0()
		{
		}
	}

	private sealed class DACFJPOFNGG<T>
	{
		public BootSequence _003C_003E4__this;

		public string timerName;

		internal void _003CTimePromise_003Eb__0()
		{
		}
	}

	private sealed class NEKGMMPKEPF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BootSequence _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this._003C_003E2__current;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return this._003C_003E2__current;
			}

}

		[DebuggerHidden]
		public NEKGMMPKEPF(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int state = _003C_003E1__state;
			BootSequence boot = _003C_003E4__this;
			if (state == 0)
			{
				_003C_003E1__state = -1;
				if (boot.CGCGDEEJADP == 0)
				{
					float processTime = PlatformManager.Instance.GetCurrentProcessTimeSinceBoot();
					boot.KEEBMEBDMMH = processTime;
					if (processTime > 0f)
					{
						var processTimers = boot.AIDHPHJKAMP;
						boot.LIPOFDEAMPE = true;
						processTimers.OJFIFFKKFLH(KFLCEJHCAII, processTime);
					}
				}
				boot.AIDHPHJKAMP.OJFIFFKKFLH(MDGBEFOBMLG, 0f);
				boot.AIDHPHJKAMP.OJFIFFKKFLH(KFKHDPIOGDF, 0f);
				boot.AIDHPHJKAMP.OJFIFFKKFLH(JIGCOAAHHCO, 0f);
				boot.AIDHPHJKAMP.OJFIFFKKFLH(DPOPFLBCAKF, 0f);
				PNAABCMOHGM.FPNMONCCAAE(string.Concat("Build version: ", IDDIAODMAPP.OLGKJALIAAI), new HJDBOADFHMC?(HJDBOADFHMC.NLODGHMOFNO));
				boot.HLLLBLNAABH = null;
				boot.PHFHOMMGCGJ = false;
				NDFLHBFOIGB.IHEKMEOIBOI();
				if (MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<MCCKDPKLCIN>(null).CurrentUnityLauncher == (KDHPMLNMNNO)1)
				{
					MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<GCLANALOAPO>(null).IHEKMEOIBOI();
				}
				if (!PlatformManager.Instance.RequiresLoginBeforeInternet)
				{
					boot.DKODHBLBHDC();
				}
				_003C_003E2__current = new UnityEngine.WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			}
			if (state == 1)
			{
				_003C_003E1__state = -1;
				boot.HOMDODONEKI.IHEKMEOIBOI(0);
				boot.CBFAAHKFJCI = JHIKKDDFDGA.FJNOABDJGMO(boot, boot.HKBJKPPPCPM, true);
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class HMPHEGFPPFD
	{
		public OINCCICKEPE cachedAccountId;

		internal global::NCOKFFGPIJM<JBPMMJCDCHG.ODJCKKLLPME> _003COnEnterPreInitializationState_003Eb__4()
		{
			return null;
		}
	}

	private sealed class PMFCJGKNBDE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public BootSequence _003C_003E4__this;

		public DBIPHDIEBCM completePromise;

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
		public PMFCJGKNBDE(int _003C_003E1__state)
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

	private sealed class BCGPAOEDFOP
	{
		public DBIPHDIEBCM promise;

		public string roomNameArg;

		public string roomSceneNameArg;

		public string roomCodeArg;

		public bool createPrivateRoomInstance;

		public OILDLLGEMKP.IPEKDADBAIA joinMethod;

		public BootSequence _003C_003E4__this;

		public int? playerToJoin;

		public Action _003C_003E9__12;

		public Action<string> _003C_003E9__15;

		public Action<Matchmaking.DABKEMNEPLM> _003C_003E9__16;

		internal void _003CLoadInitialScene_003Eb__0(string error)
		{
		}

		internal void _003CLoadInitialScene_003Eb__1(string error)
		{
		}

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CLoadInitialScene_003Eb__2(JCDPHCELKHI room)
		{
			return null;
		}

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CLoadInitialScene_003Eb__3(JCDPHCELKHI room)
		{
			return null;
		}

		internal void _003CLoadInitialScene_003Eb__4(Matchmaking.DABKEMNEPLM response)
		{
		}

		internal void _003CLoadInitialScene_003Eb__12()
		{
		}

		internal void _003CLoadInitialScene_003Eb__5(string error)
		{
		}

		internal void _003CLoadInitialScene_003Eb__7(string error)
		{
		}

		internal void _003CLoadInitialScene_003Eb__8(EPILDIJELPG homeClub)
		{
		}

		internal void _003CLoadInitialScene_003Eb__15(string error)
		{
		}

		internal void _003CLoadInitialScene_003Eb__16(Matchmaking.DABKEMNEPLM response)
		{
		}

		internal void _003CLoadInitialScene_003Eb__9(string error)
		{
		}
	}

	private sealed class BDKGJHDJDHK
	{
		public Matchmaking.KOGKIEBALBG roomJoinMode;

		public BCGPAOEDFOP CS_0024_003C_003E8__locals1;

		internal global::NCOKFFGPIJM<Matchmaking.DABKEMNEPLM> _003CLoadInitialScene_003Eb__10(LCEKCFEIEGJ room)
		{
			return null;
		}
	}

	private sealed class KLAHFKOFHOH
	{
		public OILDLLGEMKP.IPEKDADBAIA method;

		public DBIPHDIEBCM completePromise;

		internal void _003CLoadDormRoom_003Eb__0(string error)
		{
		}

		internal void _003CLoadDormRoom_003Eb__1(Matchmaking.DABKEMNEPLM response)
		{
		}
	}

	private sealed class JMCKNIOANNE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

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
		public JMCKNIOANNE(int _003C_003E1__state)
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

	private const string NHHDANDOAFC = "TitleScreen";

	private const string OFIAODLAHEB = "room_calibration";

	private const string KJEGHJJINNO = "BootSequence_PreloadSceneReplicationId";

	private const string JIGCOAAHHCO = "(Before Login)";

	private const string KFKHDPIOGDF = "(Waiting for Rec Room)";

	private const string MDGBEFOBMLG = "(Total)";

	private const string DPOPFLBCAKF = "(Boot Start To User Interaction)";

	private const string KFLCEJHCAII = "(Process Start To User Interaction)";

	private const string EPPEGCPMDND = "(Play Pressed To Initial Room Visible)";

	private const string DEEGEOMKKKJ = "FinishLoadSceneAsync(ACCOUNT_SELECTION_SCENE)";

	private const string IDHNIEKCOCM = "(Login)";

	private const string IBBENPOANDP = "(After Login)";

	private const string ABLFHGLGCMG = "WaitForCalibration";

	private const string ADHNEILCKMB = "Wait for AsyncBatch";

	private const string NHLEBGDFEAD = "InitializeCoreSystems";

	private const string CJCAAMHJDBC = "LoadInitialScene";

	private const string MIDPFEPGAEB = "PostLoadInitialScene";

	private const float KFGNALHAJCD = 10f;

	private JNKNMMDAHCF DHCLACKALOF;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private DCCDAPLPICN IBDKAJJPLGA;

	private FEIKFKAICHC HKNAHLAFLPC;

	private IPBHBFJGDME FANDMLPFELA;

	private APGPNOKPLLL NKKHAEFBOLO;

	private MCCKDPKLCIN GNEINIEOJLL;

	private GCLANALOAPO EBPBNGBNANG;

	private LAHBDKNMNHN FPADPPPNOOM;

	private global::NCOKFFGPIJM<JBPMMJCDCHG.ODJCKKLLPME> DNHGCHILBKA;

	private LAHBDKNMNHN GAIINAIAKJM;

	private bool PHFHOMMGCGJ;

	private string HLLLBLNAABH;

	private NJIJPADHPEC OHDIFKONNPP;

	private MDEJADHJOEJ DFECAIFGNCA;

	private MDEJADHJOEJ HOMDODONEKI;

	private IDisposable CBFAAHKFJCI;

	private IDisposable OMHADFCPKJJ;

	private OFDHBOEDNCN AIDHPHJKAMP;

	private bool LIPOFDEAMPE;

	private static int JKGHHHKBONP;

	private int CGCGDEEJADP;

	private float KEEBMEBDMMH;

	private bool HNLBNHFAEIF;

	private bool KBIFGLJCCEI;

	private StackTrace ENIJBELFGIG;

	private static Action KMHAJLFDEJA__BackingField;

	private static bool NJLKPOAHJOG;

	private string ABPPEFLFCGO;

	private bool IHCDBPMANNH;

	private LAHBDKNMNHN LDLKHPEPGGG;

	private LAHBDKNMNHN AFEFPGHMNGI;

	private LAHBDKNMNHN PEGPAICEFIM;

	private AsyncBatch LAKEDJPPACD;

	private bool JEMJEBDBGEO;

	private global::NCOKFFGPIJM<IReadOnlyDictionary<string, int>> NKBHGBEDHDA;

	private bool MPPKEIGBAFL;

	private AsyncBatch HOJNHEDAFBJ;

	private bool BONOPEJBIHF;

	private AsyncBatch PHBBJJLKPKG;

	private const string HLOEINOGHLL = "+roomname:";

	public const string TEST_PLATFORM_ID_PREFIX = "+platformid:";

public global::NCOKFFGPIJM<JBPMMJCDCHG.ODJCKKLLPME> CheckRecNetVersionPromise
{
get 	{
		return null;
	}

}

public LAHBDKNMNHN InitializePlatformPromise
{
get 	{
		return null;
	}

}

public bool HasError
{
get 	{
		return false;
	}

}

public string ErrorString
{
get 	{
		return null;
	}

}

private bool FEKJHNBPFEO
{
get 	{
		return false;
	}

}

private INFFBPOJOIJ GAKFIBCGHNA
{
get 	{
		return INFFBPOJOIJ.APP_SETUP;
	}

set {
	}
}

public static bool IsBootSequenceReadyForSceneChanges
{
get 	{
		return false;
	}

set {
	}
}

public OFDHBOEDNCN Clock
{
get 	{
		return null;
	}

}

public float InitialBootTimeInSeconds
{
get 	{
		return 0f;
	}

}

public bool ExperiencedFocusChangeDuringBoot
{
get 	{
		return false;
	}

}

private bool KCIPJPJECGF
{
get 	{
		return false;
	}

}

private string MGJAMCJDCKA
{
get 	{
		return null;
	}

set {
	}
}

public static event Action OnReadyForPresenceChanged {
add {
	}
remove {
	}
}

	private void IFBHEMGGLOB(string NLJOHEKGNDH)
	{
	}

	private LAHBDKNMNHN ELAFAAHOIJK(string OMDKBMJBMOO, Func<LAHBDKNMNHN> AGLNNHPIMMA)
	{
		return null;
	}

	private global::NCOKFFGPIJM<T> ELAFAAHOIJK<T>(string OMDKBMJBMOO, Func<global::NCOKFFGPIJM<T>> AGLNNHPIMMA)
	{
		return null;
	}

	private void DKODHBLBHDC()
	{
	}

	private static void HIMGBACNCPJ()
	{
	}

	protected override void Awake()
	{
	}

	private IEnumerator Start()
	{
		return null;
	}

	protected override void OnDestroy()
	{
	}

	public void BeginPlatformLogin()
	{
	}

	public void EndPlatformLogin()
	{
	}

	private void OnApplicationFocus(bool BADJIEDMGHC)
	{
	}

	private void NMNIIDFEANK()
	{
	}

	private void FDNJAPINKCB()
	{
	}

	private void NAGEFDOMGJF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void KBICJJOMLCH()
	{
	}

	private void BKMKEEENNEC()
	{
	}

	private void NMJHFJGKLPK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FOAGHDPFDEK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void KHFJEKANHKK()
	{
	}

	private void BHMKPMJCLLO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private LAHBDKNMNHN DKBECGKHEKO()
	{
		return null;
	}

	private void OGGHGLCGMKC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FAPDJLLMBFI()
	{
	}

	private void DPKHEPKPGDD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AEHHFAKCOMG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	public void StartPhotonPing()
	{
	}

	public void OnLaunchingGameStarted()
	{
	}

	public void LaunchGame(NJIJPADHPEC GFCPAMJILIO)
	{
	}

	public void SetLaunchTarget(NJIJPADHPEC GFCPAMJILIO)
	{
	}

	private void BIIKBFDHAHL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void MNCPFJLNGOP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void AMLPOGGOFMO()
	{
	}

	private void BKMCHPEBLIP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void BFNHDLAFFIN()
	{
	}

	private void LILGJFBHLBC()
	{
	}

	private void NGMNELNLNLB()
	{
	}

	private void LOMLBLLNIGE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private NJIJPADHPEC PAGOIHDMGIM()
	{
		return null;
	}

	private void BKDKLOMJKBG()
	{
	}

	public static void ClearPreloadRoomSceneLocation()
	{
	}

	public static void SetPreloadRoomSceneLocation(string MENIKDNFNIM)
	{
	}

	private void KNNEHBCLOKE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void OGOAHMIEAPO(IReadOnlyList<JCDPHCELKHI> CECGEDKICOA)
	{
	}

	private void LPJNFIBIKGD()
	{
	}

	private void EJKPIIAGILL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GGNMOINIFLF()
	{
	}

	private void OHBHEDKAIEN()
	{
	}

	public void MarkBootTimeForAnalytics()
	{
	}

	private void DOGBOOLBKHJ()
	{
	}

	private IEnumerator<EGGPGCCKPCO> JELBFBBOAHH(DBIPHDIEBCM JFIHJEIMDHP)
	{
		return null;
	}

	private LAHBDKNMNHN GNPIIBNKILJ()
	{
		return null;
	}

	private void NAMKEFMHNFC(DBIPHDIEBCM JFIHJEIMDHP, bool IFAACINIADP)
	{
	}

	[CompilerGenerated]
	private void HKBJKPPPCPM(float FBFLLMKFMDL)
	{
	}

	[CompilerGenerated]
	private LAHBDKNMNHN BBEHKDBHAAO()
	{
		return null;
	}

	[CompilerGenerated]
	private void MONOEOOHOJF(string NLJOHEKGNDH)
	{
	}

	[CompilerGenerated]
	private void FGGEPMADKHI()
	{
	}

	[CompilerGenerated]
	private void LIGBBGELDNK()
	{
	}

	[CompilerGenerated]
	private LAHBDKNMNHN CBBFPMDMNGP()
	{
		return null;
	}

	[CompilerGenerated]
	private void ICBMGMAMENI()
	{
	}

	[CompilerGenerated]
	private void APGCKMFDOHA()
	{
	}

	[CompilerGenerated]
	private LAHBDKNMNHN MHFKMOLKHII()
	{
		return null;
	}

	[CompilerGenerated]
	private void ODAPNIIGAEC()
	{
	}

	[CompilerGenerated]
	private LAHBDKNMNHN FAHEBIJEPGP()
	{
		return null;
	}

	[CompilerGenerated]
	private void EBDMIICCAMM()
	{
	}

	[CompilerGenerated]
	private void JDFBJDHEOHM()
	{
	}

	[CompilerGenerated]
	private void DNIJJJBEMFB()
	{
	}

	[CompilerGenerated]
	private void JLDOOILPBJO()
	{
	}

	[CompilerGenerated]
	private global::NCOKFFGPIJM<IReadOnlyDictionary<string, int>> GMMOODIHFOG()
	{
		return null;
	}

	[CompilerGenerated]
	private LAHBDKNMNHN OFHEFBICKDJ()
	{
		return null;
	}

	[CompilerGenerated]
	private void POMCOGIJBGC(JCDPHCELKHI KPFNANKNKLE)
	{
	}

	[CompilerGenerated]
	private void JDIIDFMMGBH()
	{
	}

	[CompilerGenerated]
	private void AJMBFAIOFEM()
	{
	}

	[CompilerGenerated]
	private void ELAHNFFEBBP()
	{
	}

	[CompilerGenerated]
	private void MMIIAHNOGGL()
	{
	}

	[CompilerGenerated]
	private void GDHMDBIPNJB()
	{
	}

	[CompilerGenerated]
	private global::NCOKFFGPIJM<IReadOnlyDictionary<string, int>> LBBGKGNKNLG()
	{
		return null;
	}

	[CompilerGenerated]
	private void MGPIOJILDDP()
	{
	}

	[CompilerGenerated]
	private void NEELOJNFEDL(string JIPKHDPODHF)
	{
	}

	[CompilerGenerated]
	internal static IEnumerator<EGGPGCCKPCO> MGJHECNIJLC()
	{
		return null;
	}
}
