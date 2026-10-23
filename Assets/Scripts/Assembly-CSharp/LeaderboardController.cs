using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom.Core.Creation;
using UnityEngine;

public class LeaderboardController : MonoBehaviourPun, DJLCHGFCFAD, DKKOHMDPPEO
{
	public enum GAEICMJOEII
	{
		NearbyScoresGlobal = 0,
		NearbyScoresFriends = 1,
		Champions = 2,
		NUM_VALUES = 3
	}

	[Serializable]
	private struct LeaderboardParams
	{
		public string FullTitle;

		public string ShortTitle;

		public string ScoreLabel;

		public int StatChannel;

		public bool SortAscending;

		public bool UseStatOnLeaderboard;

		public LNJJFAPMBNM FormattingMode;
	}

	public class HACIELOOEKC
	{
		public List<KLCPLGECDIH> HAGKPHDBEAD;

		public List<KLCPLGECDIH> KHNOMINOCHA;

		public List<KLCPLGECDIH> LPAFCBOCAEN;
	}

	private sealed class GLHLKPBFNIH
	{
		public LeaderboardController _003C_003E4__this;

		public int statIdx;

		public string name;

		internal void _003CSetFullName_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
		{
		}
	}

	private sealed class HCIMDNLMMKD
	{
		public LeaderboardController _003C_003E4__this;

		public int statIdx;

		public string name;

		internal void _003CSetShortName_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
		{
		}
	}

	private sealed class BIMBEOIJANJ
	{
		public int capturedStatIdx;

		public LeaderboardController _003C_003E4__this;

		internal void _003CInitializeSynchronizedConfigurationSettings_003Eb__0()
		{
		}
	}

	private sealed class MCEBBKAABHJ
	{
		public int currentIdx;

		public LeaderboardController _003C_003E4__this;

		internal bool _003CSetupConfigurationMenu_003Eb__0()
		{
			return false;
		}

		internal void _003CSetupConfigurationMenu_003Eb__1(bool value)
		{
		}

		internal string _003CSetupConfigurationMenu_003Eb__2()
		{
			return null;
		}

		internal void _003CSetupConfigurationMenu_003Eb__3(string newName)
		{
		}

		internal string _003CSetupConfigurationMenu_003Eb__4()
		{
			return null;
		}

		internal void _003CSetupConfigurationMenu_003Eb__5(string newName)
		{
		}

		internal bool _003CSetupConfigurationMenu_003Eb__6()
		{
			return false;
		}

		internal void _003CSetupConfigurationMenu_003Eb__7(bool value)
		{
		}

		internal int _003CSetupConfigurationMenu_003Eb__8()
		{
			return 0;
		}

		internal void _003CSetupConfigurationMenu_003Eb__9(int value)
		{
		}
	}

	private sealed class GCBEKGBAJMH
	{
		public int accountId;

		internal bool _003COnAccountUpdated_003Eb__0(HKAGAMNGAAD entry)
		{
			return false;
		}
	}

	private sealed class KCFJHMBHNPD
	{
		public LeaderboardController _003C_003E4__this;

		public int idx;

		internal void _003CHandleChampionsScoresRequest_003Eb__0(LCENNMIHEBO result)
		{
		}
	}

	private sealed class IHOFNBMGFFF
	{
		public LeaderboardController _003C_003E4__this;

		public int idx;

		public bool requestGlobal;

		internal void _003CHandleNearbyScoresRequest_003Eb__0(LCENNMIHEBO result)
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct PLAHBCHHCOJ : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public APFHIIGOAJG serializeType;

		public LeaderboardController _003C_003E4__this;

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

	private const int MNKGDJEHGBL = 32;

	private const int CAAGHGGIGOH = 16;

	[SerializeField]
	private LeaderboardView view;

	[SerializeField]
	private int numRows;

	[SerializeField]
	private LeaderboardParams[] leaderboardParams;

	[SerializeField]
	private CreationObject creationObject;

	private GameManager KPCADKBOAFA;

	private GAEICMJOEII OLDAODLJLGC;

	private int KDJBCCPJKPG;

	private HACIELOOEKC[] FLJDJBPIEEB;

	private KHGHNOPJDAI MKMPLLMGJON;

	private bool PNAAKHDLDEB;

	private bool OEAONLGBBPN;

	private List<global::HNIFCLKLIPF<string, string, bool, bool, int>> FGGOBBNEBFC;

public bool BlockObjectPersistance
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

	private void OPJGALJPOOD(int NGMNGMIEKDK, string KNOPFGAGMCN)
	{
	}

	private string ODMHLAENBAK(int NGMNGMIEKDK)
	{
		return null;
	}

	private void NMDDGCOJBGG(int NGMNGMIEKDK, string KNOPFGAGMCN)
	{
	}

	private string LNEIKGKAEJA(int NGMNGMIEKDK)
	{
		return null;
	}

	private void EEPFBJGOCLE(int NGMNGMIEKDK, bool BHDHPPBFIHD)
	{
	}

	private bool NJPDPMEIDKE(int NGMNGMIEKDK)
	{
		return false;
	}

	private void KFCHEBPGIAF(int NGMNGMIEKDK, bool NEIAPGNIJBD)
	{
	}

	private bool GFADJFHFAON(int NGMNGMIEKDK)
	{
		return false;
	}

	private void GICDIEPCLFI(int NGMNGMIEKDK, int JOALLMOAENA)
	{
	}

	private LNJJFAPMBNM LNCHCHGLMAC(int NGMNGMIEKDK)
	{
		return LNJJFAPMBNM.INT;
	}

	private void OGHFEIFLAND(int NGMNGMIEKDK)
	{
	}

	private string OLPLNFFJALG(int GMEHLIHLGEH)
	{
		return null;
	}

	protected override void Awake()
	{
	}

	private void FMNKBFPLPKB()
	{
	}

	private void Start()
	{
	}

	private void DKPEJJJMFND()
	{
	}

	private void NOLKHCNOFPF()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void HBNNFPICEDL()
	{
	}

	private void JJAMMOHCJKA(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
	{
	}

	private void AMOBMOCPGDM(int EJIHLJJMOBD)
	{
	}

	private void OHOFFKBDAJC()
	{
	}

	private void MELDCGOKAKF()
	{
	}

	private void FBDHACDICKI()
	{
	}

	private void FMFJGAPCJKE()
	{
	}

	private bool PBDIMEDNHCJ(int MKLOHLFHFKF, GAEICMJOEII OLDAODLJLGC)
	{
		return false;
	}

	private void FFHCDJDANPO()
	{
	}

	private void AMKBFFELKIO(int ODCMHGAKLKH)
	{
	}

	private List<KLCPLGECDIH> NPLOHKKJGOE(LCENNMIHEBO CDNLFEOBNKB)
	{
		return null;
	}

	private void EKOKCHGPAMD(int ODCMHGAKLKH)
	{
	}

	private void GNLJBEAGMDK(int ODCMHGAKLKH)
	{
	}

	private void DJONBHPEHHO(int ODCMHGAKLKH)
	{
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	public Task PreSerializeAsync(StringBuilder AAMCGPPJPFM, APFHIIGOAJG LJBOPGAFHIA, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	private void NBLDPCDAGJD(DHJLEHBOGBG ICHBECDKHOJ)
	{
	}
}
