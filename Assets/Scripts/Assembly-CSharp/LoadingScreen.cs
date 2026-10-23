using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeStage.AntiCheat.ObscuredTypes;
using RRUI;
using RecRoom.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : SingletonMonoBehaviour<LoadingScreen>
{
	private class LMEPIPMMOCO
	{
		private sealed class JBEAFCMPFAO
		{
			public GEECONMKCOH context;

			internal bool _003CHasContext_003Eb__0(HNEMJLDMEDF tip)
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct PAMFPCOIBBC
		{
			public List<IGrouping<GEECONMKCOH, HNEMJLDMEDF>> contextGroups;

			public LMEPIPMMOCO _003C_003E4__this;
		}

		private sealed class HLLCJBDDOKA
		{
			public GEECONMKCOH context;

			internal bool _003CRefillTips_003Eb__3(IGrouping<GEECONMKCOH, HNEMJLDMEDF> g)
			{
				return false;
			}
		}

		private static readonly List<GEECONMKCOH> JMEGAOJEHIH;

		private List<int> OKJMEEFJKBD;

		private List<HNEMJLDMEDF> JMPCHDJELLO;

		private int PNJDEDFCJDH;

public int LGEKOOLJFGJ
{
get 		{
			return 0;
		}

}

		private static int LPOKEIGEGPM(GEECONMKCOH DELCOFCGDFF)
		{
			return 0;
		}

		public bool CDMALKDLGHL(GEECONMKCOH DELCOFCGDFF)
		{
			return false;
		}

		public void LIGAFCEGIDO(string LBGBFPDNKOL, IReadOnlyList<GEECONMKCOH> DILLEHPPMLM = null)
		{
		}

		public void LDGCFIPODHD(out HNEMJLDMEDF EADNFGPCIDB)
		{
			EADNFGPCIDB = null;
		}

		private void IIFGEBMBBOF(IEnumerable<HNEMJLDMEDF> IIGHOHLJPIF, ref List<int> EODBFLJDGJM, ref List<HNEMJLDMEDF> DIFNIOLNFDO)
		{
		}

		[CompilerGenerated]
		private void JJMJFCCGOAE(GEECONMKCOH DELCOFCGDFF, ref PAMFPCOIBBC P_1)
		{
		}
	}

	private enum IALADGPEINF
	{
		FullyFadedOut = 0,
		FadingIn = 1,
		FullyFadedIn = 2,
		FadingOut = 3
	}

	private sealed class HLLBGCDBAII : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		private IEnumerator<EGGPGCCKPCO> _003CfadeToBlackRoutine_003E5__2;

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
		public HLLBGCDBAII(int _003C_003E1__state)
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

	private sealed class GGBNILCICKK
	{
		public LoadingScreen _003C_003E4__this;

		public global::NCOKFFGPIJM<LCEKCFEIEGJ> roomDetailsPromise;

		internal void _003CShowLoadingScreenRoutine_003Eb__1(LCEKCFEIEGJ fetchedRoomDetails)
		{
		}

		internal void _003CShowLoadingScreenRoutine_003Eb__2(string err)
		{
		}

		internal bool _003CShowLoadingScreenRoutine_003Eb__3()
		{
			return false;
		}
	}

	private sealed class KOPGCCAOBDJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		private GGBNILCICKK _003C_003E8__1;

		private IEnumerator<EGGPGCCKPCO> _003CcycleIter_003E5__2;

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
		public KOPGCCAOBDJ(int _003C_003E1__state)
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

	private sealed class AIOKJMMJCIE
	{
		public AFHDGIILOPN loadingScreenData;

		public LoadingScreen _003C_003E4__this;

		internal LAHBDKNMNHN _003CCycleLoadingScreens_003Eb__2()
		{
			return null;
		}
	}

	private sealed class GCLENEABELO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		public int customScreenCount;

		public int recRoomTipCount;

		private bool _003CfirstScreen_003E5__2;

		private bool _003CallowCyclingTips_003E5__3;

		private HNEMJLDMEDF _003CloadingScreenTip_003E5__4;

		private IEnumerator<EGGPGCCKPCO> _003CfadeIn_003E5__5;

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
		public GCLENEABELO(int _003C_003E1__state)
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

	private sealed class MMNENJNAJEI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		public bool fadeToBlack;

		public float duration;

		private float _003CstartTime_003E5__2;

		private float _003CendTime_003E5__3;

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
		public MMNENJNAJEI(int _003C_003E1__state)
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

	private sealed class KPPFOCHAFAC
	{
		public LoadingScreen _003C_003E4__this;

		public ObscuredLong roomIdToJoin;

		public AFHDGIILOPN data;

		internal void _003CFetchCustomLoadingScreenData_003Eb__0(DFDECAEJBIO roomOwner)
		{
		}
	}

	private sealed class GMAOAFHBPKH
	{
		public LoadingScreen _003C_003E4__this;

		public AFHDGIILOPN data;

		internal void _003CShowCustomLoadingScreen_003Eb__0(Texture2D texture)
		{
		}
	}

	private sealed class IBAGHKENDIH
	{
		public LoadingScreen _003C_003E4__this;

		public HNEMJLDMEDF tip;

		internal void _003CShowRecRoomLoadingTip_003Eb__0(Texture2D texture)
		{
		}
	}

	private sealed class EANBCEECOAJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

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
		public EANBCEECOAJ(int _003C_003E1__state)
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

	private sealed class CLLODBGHEGC
	{
		public LoadingScreen _003C_003E4__this;

		public GDHOAGNFOBD.KEIAPDLHGPG imageHandle;

		internal void _003CQueueCachedImageHandle_003Eb__0()
		{
		}

		internal void _003CQueueCachedImageHandle_003Eb__1(string e)
		{
		}
	}

	private sealed class NCNBLDEPFAO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public NCNBLDEPFAO(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class LDFCPOGFGBP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoadingScreen _003C_003E4__this;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public LDFCPOGFGBP(int _003C_003E1__state)
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
		void IEnumerator.Reset()
		{
		}
	}

	private const int LMMOBABIJAI = 5;

	private static readonly string[] OLLNLCENOKN;

	private IALADGPEINF FAMOBIGDNOI;

	private float GIMBBAEEBCN;

	private Action<bool> AOPEEGHJLHA__BackingField;

	[SerializeField]
	private WaitCursor recFaceWaitCursor;

	[SerializeField]
	private Transform recFaceBackground;

	[SerializeField]
	private Shader textureArrayBlitShader;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private Image imageFade;

	[SerializeField]
	private LoadingScreenTemplate imageTemplate;

	[SerializeField]
	private LoadingScreenTemplate textTemplate;

	[SerializeField]
	private float fadeInDuration;

	[SerializeField]
	private float fadeOutDuration;

	[SerializeField]
	private float minTotalDisplayDuration;

	[SerializeField]
	private float minDisplayDurationPerTip;

	[SerializeField]
	private float maxDisplayDurationPerTip;

	[SerializeField]
	private float displayDurationPerElipse;

	[SerializeField]
	private RawImage avatarImage;

	[SerializeField]
	private RawImage avatarShadow;

	[SerializeField]
	private Image recroomLogo;

	[SerializeField]
	private string customRoomScreenTitle;

	[SerializeField]
	private string customRoomScreenSubtitle;

	[SerializeField]
	private Texture2D customLoadScreenDefaultPicture;

	[SerializeField]
	private ProgressBar progressBar;

	[SerializeField]
	private TextMeshProUGUI percentProgressText;

	private LCEKCFEIEGJ IMOKJNNOLHF;

	private string BDGFDMKJNKC;

	private float DFBAEGPAPPG;

	private float PFKMDNJDKNO;

	private int DPIDDDHECCO;

	private LoadingScreenTemplate PBAPHHKDIDA;

	private bool BLNELCGNMIJ;

	private LMEPIPMMOCO PGCHFJENLJO;

	private readonly List<GEECONMKCOH> EIAFDJLBCKN;

	private RenderTexture OICEFOECMLI;

	private RenderTexture IOMNEGANOOA;

	private GDHOAGNFOBD.KEIAPDLHGPG DIFHLKCENFF;

	private GDHOAGNFOBD.KEIAPDLHGPG PJNOBCFBHJB;

	private Camera DDFBKNMBINF;

	private Camera NMEBHKCNOLK;

	private RenderTexture MCIPPFBHOPI;

	private Texture2DArray PFPNLHNAMHE;

	private Material AKHLKLOKFIE;

	private int EGCEALNMPMM;

	public string IsVisibleDebugString;

	private bool FPFINNJICGO;

	private bool MALLECOCOEF;

	private PNAABCMOHGM.PINBHDOHJGH? OMJILHGJOKB;

	private LKGILLBEJEK HKAIEAJHMEK;

	private LKGILLBEJEK PAEBIIHHMFN;

	private float DGKMPFAEOBB;

	private const float ONNPHAKFPOI = 0.05f;

	public FallbackTableReference loadingScreenTable;

private IALADGPEINF MBHNCCMHIPK
{
get 	{
		return IALADGPEINF.FullyFadedOut;
	}

set {
	}
}

private float NLAGACHFIPO
{
get 	{
		return 0f;
	}

set {
	}
}

private bool GDDLNLKDEFD
{
get 	{
		return false;
	}

}

public bool IsVisible
{
get 	{
		return false;
	}

set {
	}
}

public bool IsFullyFadedOut
{
get 	{
		return false;
	}

}

public bool IsFullyFadedIn
{
get 	{
		return false;
	}

}

public bool IsFadingIn
{
get 	{
		return false;
	}

}

public bool IsFadingOut
{
get 	{
		return false;
	}

}

public bool IsFading
{
get 	{
		return false;
	}

}

private LKGILLBEJEK PKDFHLDOBCC
{
set {
	}
}

private LKGILLBEJEK DAAMIILMOLL
{
set {
	}
}

public event Action<bool> IsVisibleChangeEvent {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void LGNKPIMELLJ()
	{
	}

	private void HGEHNEHLABK(LCEKCFEIEGJ KPFNANKNKLE)
	{
	}

	private void Update()
	{
	}

	private void OGOFENIPIDL()
	{
	}

	private void IIAGEINBCMM()
	{
	}

	private void BEPEJCPLIFB()
	{
	}

	private void PLPLLDCEENA()
	{
	}

	private IEnumerator<EGGPGCCKPCO> MBHBBFMMKBJ()
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> CIMDJNFCDCH()
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> EADDCMLGFOA(int AJOBCIDDMDA, int ILCKNLIHJNE)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> IGCEJHBHCKI(bool JOCIDHDBPIF, float FGBPJMKCMAO)
	{
		return null;
	}

	private int APPKFLLJHKB()
	{
		return 0;
	}

	private LAHBDKNMNHN ICIMJPECBNJ(out AFHDGIILOPN OIFMNACPAPN)
	{
		OIFMNACPAPN = null;
		return null;
	}

	private LAHBDKNMNHN GDDEEOBNDLN(AFHDGIILOPN PCPEJHIMHJJ)
	{
		return null;
	}

	public void QueueTipContext(GEECONMKCOH DELCOFCGDFF)
	{
	}

	private LAHBDKNMNHN FDKJLKCGHAD(HNEMJLDMEDF EADNFGPCIDB)
	{
		return null;
	}

	private IEnumerator<EGGPGCCKPCO> HAOOKGPELOB()
	{
		return null;
	}

	private void MNGIPEIIDKB()
	{
	}

	private void JBHDKDBLGKJ(string LBGBFPDNKOL)
	{
	}

	private void FIEAEMAEJJP()
	{
	}

	private global::NCOKFFGPIJM<Texture2D> KGONHECNBCD(GDHOAGNFOBD.KEIAPDLHGPG JFBFDAHGLDO)
	{
		return null;
	}

	private bool FCCJMIHCCGI(Texture2D CIONKGJFLOB)
	{
		return false;
	}

	private void AJCPGICGPHI()
	{
	}

	private IEnumerator IHOKNHONAKM()
	{
		return null;
	}

	private IEnumerator EHFGMKBLJOH()
	{
		return null;
	}

	private void IAKHOJAEEJA()
	{
	}

	private int CDMHNOBPMEF()
	{
		return 0;
	}

	private void EDCNCJMJDDF()
	{
	}

	private void LMIDKJOEHBD()
	{
	}

	private void BOPMCNGKEFG(bool BOEEKOIFPPC = true)
	{
	}

	public void SetLabel(string IEACNHGAIIE)
	{
	}

	public void SetProgress(float OKAABELDPNP)
	{
	}

	private void AOCOIBBPHCF()
	{
	}

	[CompilerGenerated]
	private bool ILLGJPDJPDJ(GEECONMKCOH DHNNLHJMKIH)
	{
		return false;
	}

	[CompilerGenerated]
	private bool HJEGJCIGNDI()
	{
		return false;
	}

	[CompilerGenerated]
	private LAHBDKNMNHN FMCIBIOEGNN()
	{
		return null;
	}

	[CompilerGenerated]
	private void CEEIINJOLBP(string MANKFIKGIGJ)
	{
	}

	[CompilerGenerated]
	private void CDFBNMLKIOD()
	{
	}
}
