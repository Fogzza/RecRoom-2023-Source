using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Photon.Pun;
using RecRoom.Activities;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Gestures;
using RecRoom.Core.Pools;
using RecRoom.UI.HUD;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCombatManager : MonoBehaviourPun, KEAFLIHKNBO
{
	public enum NMJGAEHKCNH
	{
		NONE = 0,
		DAMAGED = 1,
		BROKE = 2
	}

	public enum INLLFPAMJHI
	{
		SUPPRESSED = 0,
		DAMAGED = 1,
		DOWNED = 2,
		KILLED = 3
	}

	public enum KIIMEBDDPIK
	{
		NONE = 0,
		HIGH_FIVE = 1,
		HANDSHAKE = 2
	}

	private enum LNHKNNLOBAJ
	{
		GAME_NOT_RUNNING = 0,
		ALIVE = 1,
		DEAD = 2,
		RESPAWNING = 3,
		DOWN_BUT_NOT_OUT = 4
	}

	private enum PJOGJJAKCKD
	{
		OUT_OF_COMBAT = 0,
		IN_COMBAT = 1
	}

	private enum MOOAAPBEOBL
	{
		IN_COMBAT = 0,
		LEAVING_COMBAT = 1
	}

	public delegate void GLGKOAAIHHH(CHILKDJABBF ANFAILCOAEI);

	public delegate void LNHPIFLFOHK(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, INLLFPAMJHI KIJFHDKILAL, NMJGAEHKCNH LPHKEIOOFIN);

	public delegate void PPGINDNGOGI(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, NMJGAEHKCNH LPHKEIOOFIN);

	public delegate void HLKNDEMJEAB(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 KEOBHKAKKKB);

	public delegate void HADDJPNLMNL(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN);

	public delegate void IOCEHABELDP(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN);

	public delegate void NLCEJEKMLHG(CHILKDJABBF NJDHAACHDKF, Weapon ONFCNCHNBGL, Enemy INIEKKNFPDP, Vector3 OGEABPMOJJB);

	public delegate void LGLMILIDPKB(Enemy NJDHAACHDKF, Enemy INIEKKNFPDP, Vector3 OGEABPMOJJB);

	public delegate bool PBCJBDENONK(CHILKDJABBF EKOFNPFCLMO);

	private class LEEDPLNLCAL
	{
		private Action<CHILKDJABBF> DHOGDIADOKM__BackingField;

		private Action<CHILKDJABBF> DDJFPJJFNEO__BackingField;

		private global::MOBDJNEDDKC<ObscuredInt> CMOCBCIONGB;

		private global::MOBDJNEDDKC<ObscuredInt> MJABNKECDOK;

		private global::KPBNLENPEPO<ObscuredBool, ObscuredFloat, ObscuredFloat, ObscuredInt> MBEOHAMOHMM;

		private global::KPBNLENPEPO<ObscuredBool, ObscuredFloat, ObscuredFloat, ObscuredInt> JNDKEGDNJKA;

		private global::HNIFCLKLIPF<bool, bool, float, float, float> BDJNEKJFNII;

		private global::MOBDJNEDDKC<int> KJLACAEHCDA;

		private global::MOBDJNEDDKC<float> BGKMNHLLPEJ;

		private global::MOBDJNEDDKC<float> FNOINIAENNL;

		private global::MOBDJNEDDKC<float> JPEFLCBCABP;

		private global::MOBDJNEDDKC<int> PHAEECCJAMF;

		private global::MOBDJNEDDKC<ObscuredFloat> DODKFELDIEK;

		private global::MOBDJNEDDKC<float> ICKCKPILNIA;

		private global::MOBDJNEDDKC<ObscuredFloat> LGAHBDFFJIL;

		private bool EPGHBLKPJIP;

		private CHILKDJABBF DCJFPELAJIH;

public int JCHNLIANGKA
{
get 		{
			return 0;
		}

set {
		}
}

public int AEAIFDOKJIF
{
get 		{
			return 0;
		}

set {
		}
}

public bool BPEMNMOMKKE
{
get 		{
			return false;
		}

}

public float EODBHJKAOHP
{
get 		{
			return 0f;
		}

}

public float CFIGBNMNPNO
{
get 		{
			return 0f;
		}

}

public int FHFHDBNCIHO
{
get 		{
			return 0;
		}

}

public bool NFFIAJMLDGN
{
get 		{
			return false;
		}

}

public float GFHCFDKJODG
{
get 		{
			return 0f;
		}

}

public float FHEAOPOCOFL
{
get 		{
			return 0f;
		}

}

public int JGNNGGDADFM
{
get 		{
			return 0;
		}

}

public bool AGGPGGHICNI
{
get 		{
			return false;
		}

}

public bool ALNNHGBDJLH
{
get 		{
			return false;
		}

}

public float LODGCCLFKAP
{
get 		{
			return 0f;
		}

}

public float PFICFALLMDD
{
get 		{
			return 0f;
		}

}

public float CPCMCJKDECO
{
get 		{
			return 0f;
		}

}

public int JJOEEDPDKHM
{
get 		{
			return 0;
		}

set {
		}
}

public float BNOGCOCLOCH
{
get 		{
			return 0f;
		}

set {
		}
}

public float KLKPAJIHMOH
{
get 		{
			return 0f;
		}

set {
		}
}

public float ADFFMBKHKIG
{
get 		{
			return 0f;
		}

set {
		}
}

public int JHOBOAMBIPM
{
get 		{
			return 0;
		}

set {
		}
}

public float NMPEFCFHJIA
{
get 		{
			return 0f;
		}

set {
		}
}

public float NGKMALMNJGI
{
get 		{
			return 0f;
		}

set {
		}
}

public float NCFCDMMOHGD
{
get 		{
			return 0f;
		}

set {
		}
}

public bool KIBHOJKLBPI
{
get 		{
			return false;
		}

private set {
		}
}

public event Action<CHILKDJABBF> DHOGDIADOKM {
add {
		}
remove {
		}
}

public event Action<CHILKDJABBF> DDJFPJJFNEO {
add {
		}
remove {
		}
}

		public void AEOPPIDPLJM()
		{
		}

		public void POBOPOIEGCF(float HDGFHFCPNPD, float FGBPJMKCMAO, int FGPNJDLOOOC)
		{
		}

		public void MNHDADHJJBL()
		{
		}

		public void IKHMAMGGAAF(float HDGFHFCPNPD, float FGBPJMKCMAO, int LMOFMNEHNMH)
		{
		}

		public void GCOJJCDKPLP()
		{
		}

		public void KADLFHOCMAB(float DPHMAEHENEP, float GGEPGCNHMDB, float DGHDIIOLLLD)
		{
		}

		public void DMHCLIOHHNG()
		{
		}

		public LEEDPLNLCAL(MonoBehaviourPun DELCOFCGDFF, CHILKDJABBF EKOFNPFCLMO, int MODNAPOAFFP)
		{
		}

		private void BJEPCPFIMMP()
		{
		}

		private void OCDJNBNDDIK()
		{
		}

		public void BOPNMIDOIOD()
		{
		}
	}

	private sealed class EBDPKOJPEDK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public EBDPKOJPEDK(int _003C_003E1__state)
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

	private sealed class BBMKCPMBDOJ : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Color color;

		public float intensity;

		public float duration;

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
		public BBMKCPMBDOJ(int _003C_003E1__state)
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

	private sealed class HCIMNLKBFMB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public GameCombatManager _003C_003E4__this;

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
		public HCIMNLKBFMB(int _003C_003E1__state)
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

	private const float CJGODACBKJD = 2f;

	private const int HJHLDBALKAP = 16;

	private const string CHDBDNGBABE = "CV2CombatHUD";

	private const string EEFENAEJDEB = "CameraFadedOut";

	private GLGKOAAIHHH JEJKMPDABKG__BackingField;

	private LNHPIFLFOHK AKGCGIPNNJC__BackingField;

	private PPGINDNGOGI IHGLHOMJNGL__BackingField;

	private PPGINDNGOGI PJILOOOALGG__BackingField;

	private Action<CHILKDJABBF> HCLGGBFNBDM__BackingField;

	private HLKNDEMJEAB DNEPLGBDPLG__BackingField;

	private HADDJPNLMNL MEGJCPAOAFK__BackingField;

	private HADDJPNLMNL KIEDCAAODGL__BackingField;

	private HADDJPNLMNL IIFMAJAGFPO__BackingField;

	private IOCEHABELDP FHPDPILJEPG__BackingField;

	private IOCEHABELDP EGMAAJLJDLO__BackingField;

	private IOCEHABELDP EBBLOPPENCM__BackingField;

	private NLCEJEKMLHG NNPEDNOEEFN__BackingField;

	private NLCEJEKMLHG ICLECOPIGLJ__BackingField;

	private LGLMILIDPKB EBMHIEDBGPP__BackingField;

	private LGLMILIDPKB HHNLBHOMHJO__BackingField;

	private Action<CHILKDJABBF> DBPAECOENDA__BackingField;

	private Action<CHILKDJABBF> NGGPOOHPBPK__BackingField;

	private Action MEAKGNBNAEH__BackingField;

	private Action KGCEGKCEHCL__BackingField;

	public static EEANDDJEMJC LocalPlayerChangedToAliveEvent;

	public static EEANDDJEMJC LocalPlayerChangedToDeadEvent;

	private const float LEINIPBJBNO = 1f;

	private const float MMLKLPODLOD = 0.5f;

	private static readonly string PLEMEHJPDPF;

	private static readonly string DABEOECGNDF;

	private static readonly string LJCFBGCHMIE;

	private static readonly string BPMHFKNDIIE;

	private static readonly string EMPCCEOLHML;

	private static readonly string IEOCALDHCEJ;

	private INBDIKIJLGF GBIFNANKKKC;

	private MDEJADHJOEJ CGNJBNCMGCF;

	private KBJKDKFNFIA LDMJGCOLGEF;

	private MDEJADHJOEJ JKMOOEGAIMC;

	private KBJKDKFNFIA AEHCOJNHPCP;

	private bool EIJDHPOGPHO;

	private bool JFMNLGCNDPH;

	private Transform PDHABBLCLGE;

	private List<EnemyCombatUI> PKCCJBIOBBB;

	private List<GameReviveHandshakeFeedback> KFOGKPFIFML;

	private List<GameReviveHandshakeFeedback> GIDKBNELJLO;

	private bool BMPEMBIDKCP;

	private Tool AGNEHOKOENP;

	private Tool OPBLOLBFPMI;

	private int[] CPEDKJDCEHE;

	private Tool[] MIBMLDPEFNF;

	private LocalPlayerCombatHUD LMIABAMAKHM;

	private Coroutine BNNIJBBGGPC;

	private Coroutine FIMLCHABNBO;

	private float NDOJKNFFOPH;

	private IDisposable CNAGCKBFLOE;

	private CGOPOAFDIDN AAKFKPKFDJJ;

	private bool FBOMDODBOIC;

	public PBCJBDENONK CustomDownButNotOutRespawnCondition;

	[SerializeField]
	private LocalPlayerCombatHUD vrHudPrefab;

	[SerializeField]
	private LocalPlayerCombatHUD screensHudPrefab;

	[SerializeField]
	private PlayerCombatUI playerCombatUIDefaultPrefab;

	[SerializeField]
	private EnemyCombatUI enemyCombatUIDefaultPrefab;

	[SerializeField]
	private CV2CombatHUD vrCv2CombatHudPrefab;

	[SerializeField]
	private CV2CombatHUD pcCv2CombatHudPrefab;

	[SerializeField]
	private CV2CombatHUD mobileCv2CombatHudPrefab;

	[SerializeField]
	private PooledDamageParticles playerDamagedParticles;

	[SerializeField]
	private RecRoomAudioClip playerDamagedSFX;

	[SerializeField]
	private PooledDamageParticles playerShieldDamagedParticles;

	[SerializeField]
	private RecRoomAudioClip playerShieldDamagedSFX;

	[SerializeField]
	private RecRoomAudioClip opponentDownedSFX;

	[SerializeField]
	private RecRoomAudioClip localPlayerDownedSFX;

	[SerializeField]
	private RecRoomAudioClip teammateDownedSFX;

	[SerializeField]
	private GameReviveHandshakeFeedback handshakeReviveFeedbackPrefab;

	[SerializeField]
	private PooledParticle playerReviveParticles;

	[SerializeField]
	private RecRoomAudioClip playerReviveSFX;

	private global::AFHOAHNAMGF<PlayerCombatUI> APCEELCGLPP;

	private global::AFHOAHNAMGF<EnemyCombatUI> PIFPGOOEDAF;

	private global::AFHOAHNAMGF<LocalPlayerCombatHUD> LJCHMMKIALJ;

	private FIHGBEHGLGB GJNIENLBHHJ;

	public static CV2CombatHUD CV2CombatHUD;

	private FIHGBEHGLGB APCDFENOIOL;

	private FIHGBEHGLGB FDHLJOFAKGK;

	private FIHGBEHGLGB BCMPJBIIEAB;

	private FIHGBEHGLGB DLLODIKIEBF;

	private FIHGBEHGLGB KPLHJPCBLJI;

	private global::AFHOAHNAMGF<int> CMCJIFNIPDA;

	private global::AFHOAHNAMGF<int> OLMJPLJFMKI;

	private FIHGBEHGLGB GGGHEDEPCEA;

	private FIHGBEHGLGB DLNJJBBNELK;

	private FIHGBEHGLGB KEJDHOIEMNC;

	private FIHGBEHGLGB DDKJFIBKJOL;

	private global::AFHOAHNAMGF<AutoHealSettings> FDAEJBOFDNG;

	private FIHGBEHGLGB LPLKOILJKMD;

	private global::AFHOAHNAMGF<DownButNotOutSettings> CJIGDBIMHGD;

	private FIHGBEHGLGB OFHNFCFEPMM;

	private global::AFHOAHNAMGF<RespawnSettings> FFOIJHEBHDB;

	private global::AFHOAHNAMGF<KIIMEBDDPIK> PBLNADEBNKH;

	private global::AFHOAHNAMGF<ReviveSettings> FKPOHGIMCKB;

	private global::AFHOAHNAMGF<FriendlyFireSettings> IHAEANACOJP;

	private global::AFHOAHNAMGF<PlayerCombatUISettings> NENMIFGGPIO;

	private global::AFHOAHNAMGF<EnemyCombatUISettings> DCMPKMDKNDG;

	private FIHGBEHGLGB IEENODJHGJF;

	private FIHGBEHGLGB OHPDLFIDFMI;

	private FIHGBEHGLGB OADMMKIBEPP;

	private FIHGBEHGLGB KDJKIIMHLDM;

	private FIHGBEHGLGB ADEDNMHEENC;

	private LKGILLBEJEK EHEDBFIBCDH;

	private Dictionary<int, LEEDPLNLCAL> JKDKPKBFNDE;

	public Action<Killzone> LocalPlayerKillzoneRespawnLogicOverride;

	public Action LocalPlayerKillzoneKillLogicOverride;

	private List<CHILKDJABBF> DCACACGIAKL;

	private Dictionary<CHILKDJABBF, PlayerCombatUI> JIBLLAGPOBJ;

public float RespawnDuration
{
get 	{
		return 0f;
	}

}

public bool AutoKilledEnemiesAddToScore
{
get 	{
		return false;
	}

set {
	}
}

public LocalPlayerCombatHUD LocalPlayerHUD
{
get 	{
		return null;
	}

}

private PlayerCombatUI GLLLDMIGAPG
{
get 	{
		return null;
	}

}

private EnemyCombatUI HKJPAIFOBKN
{
get 	{
		return null;
	}

}

private LocalPlayerCombatHUD OELFNHAHAHL
{
get 	{
		return null;
	}

}

private bool BDCBCDOADIH
{
get 	{
		return false;
	}

}

public bool UseDefaultHitFeedback
{
get 	{
		return false;
	}

}

public bool UseDefaultReviveFeedback
{
get 	{
		return false;
	}

}

public bool UseDefaultDownedOpponentFeedback
{
get 	{
		return false;
	}

}

public bool UseDefaultDownedLocalPlayerFeedback
{
get 	{
		return false;
	}

}

public bool UseDefaultDownedTeammateFeedback
{
get 	{
		return false;
	}

}

public int MaxHealth
{
get 	{
		return 0;
	}

}

public int MaxShield
{
get 	{
		return 0;
	}

}

public bool ShieldSupported
{
get 	{
		return false;
	}

}

public bool WeaponDamageSuppressed
{
get 	{
		return false;
	}

}

public bool EnemiesIgnoreSpectators
{
get 	{
		return false;
	}

}

public bool AllDamageToPlayerSuppressed
{
get 	{
		return false;
	}

}

public bool AutoHealSupported
{
get 	{
		return false;
	}

}

private AutoHealSettings DGEKNMKDLLI
{
get 	{
		return default;
	}

}

public bool DownButNotOutSupported
{
get 	{
		return false;
	}

}

private DownButNotOutSettings ICEBENEMBOJ
{
get 	{
		return default;
	}

}

public bool AutoRespawnSupported
{
get 	{
		return false;
	}

}

private RespawnSettings DNMAAFBNBGN
{
get 	{
		return default;
	}

}

public KIIMEBDDPIK ReviveMode
{
get 	{
		return KIIMEBDDPIK.NONE;
	}

}

private ReviveSettings LMKAOOHFGPP
{
get 	{
		return default;
	}

}

private FriendlyFireSettings GCLKHBOIFJP
{
get 	{
		return default;
	}

}

private PlayerCombatUISettings MPGIDBNCHMM
{
get 	{
		return default;
	}

}

private EnemyCombatUISettings KCLBDACFAFG
{
get 	{
		return default;
	}

}

private bool IJAHEGAACBF
{
get 	{
		return false;
	}

}

private bool OMCJCPDADLO
{
get 	{
		return false;
	}

}

private bool DENPLAOGLPC
{
get 	{
		return false;
	}

}

private bool AFINBIGPCHP
{
get 	{
		return false;
	}

}

public bool FriendlyFirePaused
{
get 	{
		return false;
	}

}

public bool IsGameRunning
{
get 	{
		return false;
	}

}

public static bool IsLocalPlayerEliminated
{
get 	{
		return false;
	}

}

public bool AllActivePlayersAreAlive
{
get 	{
		return false;
	}

}

public bool AllActivePlayersAreDead
{
get 	{
		return false;
	}

}

public bool AllActiveTeamsAreAlive
{
get 	{
		return false;
	}

}

public bool AllActiveTeamsAreDead
{
get 	{
		return false;
	}

}

public bool RequiresHandshakeRevive
{
get 	{
		return false;
	}

}

public float HandshakeReviveDuration
{
get 	{
		return 0f;
	}

}

private bool PLKLHBADIGM
{
get 	{
		return false;
	}

}

public event GLGKOAAIHHH MasterOnlyPlayerDeathEvent {
add {
	}
remove {
	}
}

public event LNHPIFLFOHK PlayerDamagedPlayerEvent {
add {
	}
remove {
	}
}

public event PPGINDNGOGI PlayerKilledPlayerEvent {
add {
	}
remove {
	}
}

public event PPGINDNGOGI PlayerDownedPlayerEvent {
add {
	}
remove {
	}
}

public event Action<CHILKDJABBF> DownButNotOutKilledPlayerEvent {
add {
	}
remove {
	}
}

public event HLKNDEMJEAB PlayerRevivePlayerEvent {
add {
	}
remove {
	}
}

public event HADDJPNLMNL EnemyDamagedPlayerEvent {
add {
	}
remove {
	}
}

public event HADDJPNLMNL EnemyKilledPlayerEvent {
add {
	}
remove {
	}
}

public event HADDJPNLMNL EnemyDownedPlayerEvent {
add {
	}
remove {
	}
}

public event IOCEHABELDP MiscDamagedPlayerEvent {
add {
	}
remove {
	}
}

public event IOCEHABELDP MiscKilledPlayerEvent {
add {
	}
remove {
	}
}

public event IOCEHABELDP MiscDownedPlayerEvent {
add {
	}
remove {
	}
}

public event NLCEJEKMLHG PlayerDamagedEnemyEvent {
add {
	}
remove {
	}
}

public event NLCEJEKMLHG PlayerKilledEnemyEvent {
add {
	}
remove {
	}
}

public event LGLMILIDPKB EnemyDamagedEnemyEvent {
add {
	}
remove {
	}
}

public event LGLMILIDPKB EnemyKilledEnemyEvent {
add {
	}
remove {
	}
}

public event Action<CHILKDJABBF> PlayerHealthChangeEvent {
add {
	}
remove {
	}
}

public event Action<CHILKDJABBF> PlayerDownButNotOutChangeEvent {
add {
	}
remove {
	}
}

public event Action EnteringCombatEvent {
add {
	}
remove {
	}
}

public event Action ExitingCombatEvent {
add {
	}
remove {
	}
}

	public void AddPlayerCombatUIPrefab(PlayerCombatUI PGCLGFEAIOD, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemovePlayerCombatUIPrefab(object IALNODEHBNN)
	{
	}

	public void AddEnemyCombatUIPrefab(EnemyCombatUI NLMJEIOHIBI, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveEnemyCombatUIPrefab(object IALNODEHBNN)
	{
	}

	public void AddHudPrefab(LocalPlayerCombatHUD JOGBBEAGAAN, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveHudPrefab(object IALNODEHBNN)
	{
	}

	public void AddHUDSupport(object IALNODEHBNN)
	{
	}

	public void RemoveHUDSupport(object IALNODEHBNN)
	{
	}

	public void AddDefaultHitFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDefaultHitFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void AddDefaultReviveFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDefaultReviveFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void AddDefaultDownedOpponentFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDefaultDownedOpponentFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void AddDefaultDownedLocalPlayerFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDefaultDownedLocalPlayerFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void AddDefaultDownedTeammateFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDefaultDownedTeammateFeedbackSupport(object IALNODEHBNN)
	{
	}

	public void AddMaxHealthSetting(int EMDIPCIPFBF, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveMaxHealthSetting(object IALNODEHBNN)
	{
	}

	public void AddMaxShieldSetting(int OEDCEJMGICB, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveMaxShieldSetting(object IALNODEHBNN)
	{
	}

	public void AddSuppressWeaponDamage(object IALNODEHBNN)
	{
	}

	public void RemoveSuppressWeaponDamage(object IALNODEHBNN)
	{
	}

	public void AddEnemiesIgnoreSpectators(object IALNODEHBNN)
	{
	}

	public void RemoveEnemiesIgnoreSpectators(object IALNODEHBNN)
	{
	}

	public void AddSuppressAllDamageToPlayer(object IALNODEHBNN)
	{
	}

	public void RemoveSuppressAllDamageToPlayer(object IALNODEHBNN)
	{
	}

	public void AddAutoHealSupport(object IALNODEHBNN)
	{
	}

	public void RemoveAutoHealSupport(object IALNODEHBNN)
	{
	}

	public void AddAutoHealSettings(AutoHealSettings CPHBAJOBPHA, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveAutoHealSettings(object IALNODEHBNN)
	{
	}

	public void AddDBNOSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDBNOSupport(object IALNODEHBNN)
	{
	}

	public void AddDBNOSettings(DownButNotOutSettings KFMFKDAMDIK, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveDBNOSettings(object IALNODEHBNN)
	{
	}

	public void AddAutoRespawnSupport(object IALNODEHBNN)
	{
	}

	public void RemoveAutoRespawnSupport(object IALNODEHBNN)
	{
	}

	public void AddRespawnSettings(RespawnSettings PAIHFDMNFLK, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveRespawnSettings(object IALNODEHBNN)
	{
	}

	public void AddReviveMode(KIIMEBDDPIK FNLILDAEJOF, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveReviveMode(object IALNODEHBNN)
	{
	}

	public void AddReviveSettings(ReviveSettings GFMKHBAAGCD, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveReviveSettings(object IALNODEHBNN)
	{
	}

	public void AddFriendlyFireSettings(FriendlyFireSettings GMMCMAFACNG, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveFriendlyFireSettings(object IALNODEHBNN)
	{
	}

	public void AddPlayerCombatUISettings(PlayerCombatUISettings FINHACFPOHM, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemovePlayerCombatUISettings(object IALNODEHBNN)
	{
	}

	public void AddEnemyCombatUISettings(EnemyCombatUISettings FINHACFPOHM, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveEnemyCombatUISettings(object IALNODEHBNN)
	{
	}

	public void AddDeadMonochromeEffectSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDeadMonochromeEffectSupport(object IALNODEHBNN)
	{
	}

	public void AddDamageRedFlashEffectSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDamageRedFlashEffectSupport(object IALNODEHBNN)
	{
	}

	public void AddDownButNotOutMonochromeEffectSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDownButNotOutMonochromeEffectSupport(object IALNODEHBNN)
	{
	}

	public void AddDeadPersistentNotificationSupport(object IALNODEHBNN)
	{
	}

	public void RemoveDeadPersistentNotificationSupport(object IALNODEHBNN)
	{
	}

	public void PauseFriendlyFire(object IALNODEHBNN)
	{
	}

	public void ResumeFriendlyFire(object IALNODEHBNN)
	{
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void InitializeOnAwake(GameManager KPCADKBOAFA)
	{
	}

	public void InitializeOnStart()
	{
	}

	public void CleanupOnDestroy()
	{
	}

	public void OnUpdate()
	{
	}

	public void OnPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void OnGameStart()
	{
	}

	public void OnGameEnd()
	{
	}

	public void InitializeLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void ResetLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void DisableLocalPlayerCombatHUD()
	{
	}

	private void PCJAMKNGHOK()
	{
	}

	private void EGBCOKELIOL()
	{
	}

	private void AMOBMOCPGDM(int EJIHLJJMOBD)
	{
	}

	private LEEDPLNLCAL ALANECENMJF(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	public int GetPlayerHealth(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0;
	}

	public int GetPlayerShield(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0;
	}

	public float GetLastDamageTime(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	public bool PlayerIsAlive(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public bool IsPlayerDownButNotOut(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public float GetPlayerDownButNotOutPercentage(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	public int TeamPlayersAliveCount(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	public bool TeamIsAlive(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return false;
	}

	public float GetPlayerLastDeathStartTime(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	public float GetPlayerLastDeathEndTime(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	public void MasterResetPlayerHealth(CHILKDJABBF EKOFNPFCLMO, float CLIAJMOAHGO = 1f)
	{
	}

	public void MasterDamagePlayer(CHILKDJABBF EKOFNPFCLMO, int FDDPFMJOHLO, bool GJDPKDEDBBI)
	{
	}

	public void MasterDamagePlayer(CHILKDJABBF EKOFNPFCLMO, int FDDPFMJOHLO, bool GJDPKDEDBBI, out INLLFPAMJHI KIJFHDKILAL, out NMJGAEHKCNH LPHKEIOOFIN)
	{
		KIJFHDKILAL = default;
		LPHKEIOOFIN = default;
	}

	public void MasterKillPlayer(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void MasterRestorePlayerHealth(CHILKDJABBF EKOFNPFCLMO, int HPGBKIIFBPC, float MKPALLBMAAJ)
	{
	}

	private void OACMMEOPJKB(LEEDPLNLCAL JKDKPKBFNDE, int HPGBKIIFBPC, float MKPALLBMAAJ)
	{
	}

	public void MasterRestorePlayerShield(CHILKDJABBF EKOFNPFCLMO, int LBOCNOFFMPE, float JJLNPAIHHNI)
	{
	}

	public void MasterSetPlayerHealth(CHILKDJABBF EKOFNPFCLMO, int LCLKHEDICPD)
	{
	}

	private void FCIKNHAADIF(LEEDPLNLCAL JKDKPKBFNDE, int LCLKHEDICPD)
	{
	}

	public void MasterSetPlayerShield(CHILKDJABBF EKOFNPFCLMO, int HGCNECNDABF)
	{
	}

	private void ILLIJJNKKDK(LEEDPLNLCAL JKDKPKBFNDE, int HGCNECNDABF)
	{
	}

	private void OFFAFIPMBJC(LEEDPLNLCAL JKDKPKBFNDE, float DPHMAEHENEP)
	{
	}

	private void EPJDGLAKANE(LEEDPLNLCAL JKDKPKBFNDE)
	{
	}

	private void LCCANLGPCII(LEEDPLNLCAL JKDKPKBFNDE)
	{
	}

	private void GFFHFCEAPCG()
	{
	}

	private void NBLJNFIGNLF()
	{
	}

	private void HEGGBKOGKCK(LEEDPLNLCAL JKDKPKBFNDE, float GGEPGCNHMDB)
	{
	}

	private void AIDMIDHDNGH(LEEDPLNLCAL JKDKPKBFNDE, float GGEPGCNHMDB, int MODNAPOAFFP, float JBBHNILHEGB, float JECAPADLLMH)
	{
	}

	private void NEILKEDFIHH(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void HMMEOEHCIMF()
	{
	}

	public float GetTimeUntilPlayerReviveAvailable(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	public bool PlayerIsInvincible(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private bool JKAFDJDFKFB(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private void JKJDGGDDBJF(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void EHPHAAAFJJE(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnDBNOKilledPlayer(CHILKDJABBF NLGCGEFCFNA)
	{
	}

	public int GetPlayerEnemyTargetCount(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0;
	}

	private void JDKLNNDGHLH(CHILKDJABBF EKOFNPFCLMO, int BFFJHKFEFPP)
	{
	}

	public void AddPlayerEnemyTargetCount(CHILKDJABBF EKOFNPFCLMO, int FKHDPLPGMAK)
	{
	}

	public void MasterAddPlayerEnemyTargetCount(CHILKDJABBF EKOFNPFCLMO, int FKHDPLPGMAK)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterAddPlayerEnemyTargetCount(CHILKDJABBF EKOFNPFCLMO, int FKHDPLPGMAK)
	{
	}

	private void OLJDPAGJDLD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GOMLBBHKIBH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HGONLNDDAAG()
	{
	}

	private void KCDLJABDHFF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void PLGKAHEHFFL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private bool DIDMFMKNPPD(Tool IEGMBEPJMGC)
	{
		return false;
	}

	private void IILKCPDIMAN()
	{
	}

	private void CJLHEBPBANM()
	{
	}

	private void HPGCJIACCFL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void IFDKFHFNBJH()
	{
	}

	private void NCBINLLAPBG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FBPLCECJOGA()
	{
	}

	public bool RequestWeaponOnPlayerDamage(Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, Player INIEKKNFPDP, Player.NBPIPAJOGLC ICBHFMMOPKA, NGLCDIDOEMK BNFNJFKJEOA)
	{
		return false;
	}

	public bool RequestWeaponOnToolDamage(Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, Player INIEKKNFPDP, Tool AFNHKNGKICM, NGLCDIDOEMK BNFNJFKJEOA)
	{
		return false;
	}

	public bool RequestWeaponOnToolDamage(Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Tool AFNHKNGKICM, NGLCDIDOEMK BNFNJFKJEOA)
	{
		return false;
	}

	private bool PDJEJPAANCC(Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP)
	{
		return false;
	}

	private bool ILPMLEEEFAI(Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC ICBHFMMOPKA, NGLCDIDOEMK BNFNJFKJEOA)
	{
		return false;
	}

	public void MasterRequestPlayerOnPlayerDamage(Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, float PGPHKLEGBBA, byte GIHGJIFCHMK)
	{
	}

	public void OnPlayerDamagedPlayer(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC ICBHFMMOPKA, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, INLLFPAMJHI KIJFHDKILAL, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void OnPlayerKilledPlayer(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC ICBHFMMOPKA, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void OnPlayerDownedPlayer(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC ICBHFMMOPKA, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	private bool DMOIMGLPMGJ(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon DELLMFIOAAK, DJBEHNDMJDL IKEDGLGPGEA)
	{
		return false;
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestPlayerOnPlayerDamage(Weapon PLOGNHIJBNB, DJBEHNDMJDL CAEAGJCJCGJ, CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, float PGPHKLEGBBA, byte GIHGJIFCHMK)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnPlayerDamagedPlayer(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, INLLFPAMJHI KIJFHDKILAL, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public bool RequestEnemyOnPlayerDamage(Enemy NJDHAACHDKF, Player INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB)
	{
		return false;
	}

	private bool PBDIJNANLEG(Enemy NJDHAACHDKF, Player INIEKKNFPDP)
	{
		return false;
	}

	public void MasterRequestEnemyOnPlayerDamage(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB)
	{
	}

	public void OnEnemyDamagedPlayer(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void OnEnemyKilledPlayer(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void OnEnemyDownedPlayer(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	private void IAMFMINDAPK()
	{
	}

	private void PEPCICBBBIH()
	{
	}

	private void JGIFHPKLBEP(Enemy DPENEFKKNDN)
	{
	}

	private bool DPKOFLEKKAI(Enemy DPENEFKKNDN)
	{
		return false;
	}

	private void JJBFPGGGFMO(DPMOPDDAJBJ NJDHAACHDKF, Enemy INIEKKNFPDP, Vector3 OGEABPMOJJB)
	{
	}

	private void KKALBOOJCFA(Enemy DPENEFKKNDN, DPMOPDDAJBJ NJDHAACHDKF)
	{
	}

	private bool HGLALIDKHNH(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP)
	{
		return false;
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestEnemyOnPlayerDamage(Enemy DPENEFKKNDN, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnEnemyDamagedPlayer(Enemy DPENEFKKNDN, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnEnemyKilledPlayer(Enemy DPENEFKKNDN, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnEnemyDownedPlayer(Enemy DPENEFKKNDN, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void LocalRequestMiscPlayerDamage(Player.NBPIPAJOGLC DIGGAPIGLAA, Vector3 JFCDKBOPNDG, int FDDPFMJOHLO, bool BMONJPIKHIM = false)
	{
	}

	public void MasterRequestMiscPlayerDamage(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, int FDDPFMJOHLO, bool GJDPKDEDBBI)
	{
	}

	public void OnMiscDamagedPlayer(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void OnMiscKilledPlayer(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void OnMiscDownedPlayer(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	private void MCIGGHCNOHA(Player INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, int FDDPFMJOHLO, bool BMONJPIKHIM)
	{
	}

	private bool HLOIDPMAGHC(CHILKDJABBF INIEKKNFPDP)
	{
		return false;
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestMiscPlayerDamage(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, int FDDPFMJOHLO, bool GJDPKDEDBBI)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnMiscDamagedPlayer(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnMiscKilledPlayer(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC JOHJFEPLBND, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnMiscDownedPlayer(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC JOHJFEPLBND, Vector3 OGEABPMOJJB, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	public void OnDBNOKilledPlayer(CHILKDJABBF NLGCGEFCFNA)
	{
	}

	private void GBMOACAHLNC()
	{
	}

	private void CFNDIMGHDNH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void BPCFAOIKCFG(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void APLALDHNEHB()
	{
	}

	private void AAAJCCGBPBE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void IIFCNCAAOBM()
	{
	}

	public void MasterRequestSelfRevive(CHILKDJABBF GDIGGLJFDPB)
	{
	}

	public void MasterRequestPlayerRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 NDKHGOKJALC, bool FPGCDCHKKPK)
	{
	}

	public void MasterRequestStartHandshakeRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, PlayerHand BNGFJPIEFGN, PlayerHand JICBLAODMPP)
	{
	}

	public void MasterRequestCancelHandshakeRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH)
	{
	}

	public void MasterResetTimesRevivedForPlayer(CHILKDJABBF LHBNHDPHBFJ)
	{
	}

	private void PBIPAGNDIBA(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 NDKHGOKJALC, bool FPGCDCHKKPK)
	{
	}

	private void NPFIDLOGJGO(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, PlayerHand BNGFJPIEFGN, PlayerHand JICBLAODMPP)
	{
	}

	private void PGMOFEBKMCH(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH)
	{
	}

	public void LocalPlayerRequestHighFiveRevive(CHILKDJABBF GDIGGLJFDPB, Vector3 NDKHGOKJALC)
	{
	}

	public void LocalPlayerRequestStartHandshakeRevive(CHILKDJABBF GDIGGLJFDPB, PlayerHand BNGFJPIEFGN, PlayerHand JICBLAODMPP)
	{
	}

	public void LocalPlayerRequestCancelHandshakeRevive(CHILKDJABBF GDIGGLJFDPB)
	{
	}

	public void LocalPlayerRequestHandshakeReviveSuccess(CHILKDJABBF GDIGGLJFDPB, Vector3 INLGLHIPOMC)
	{
	}

	public bool CanPlayerRevive(CHILKDJABBF OOJOIFKCDLH)
	{
		return false;
	}

	public bool CanPlayerBeRevived(CHILKDJABBF GDIGGLJFDPB)
	{
		return false;
	}

	public bool IsValidPlayerRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH)
	{
		return false;
	}

	private void LEONNGOCHJI()
	{
	}

	private void HHCADKAIIOF()
	{
	}

	private void HMGLDFLGMOM(PlayerHand AHELDLHMNFC, PlayerHand GIBEGOAHAFM)
	{
	}

	private void JEGMCFKJHIN(PlayerHand KJCMNCDGCKA, PlayerHand MCGMBMMJMBM, PlayerHandGestures.NAHIAFFDEIO AEBIACPKIKH, Player EEOLEPDDCFN = null, Player ANDCAFFMODA = null)
	{
	}

	private void MLHMBOHAGMK(PlayerHand AHELDLHMNFC, PlayerHand GIBEGOAHAFM, out CHILKDJABBF GDIGGLJFDPB, out CHILKDJABBF OOJOIFKCDLH, out PlayerHand BNGFJPIEFGN, out PlayerHand JICBLAODMPP)
	{
		GDIGGLJFDPB = null;
		OOJOIFKCDLH = null;
		BNGFJPIEFGN = null;
		JICBLAODMPP = null;
	}

	private bool JFBGMMMDIBA(CHILKDJABBF FBCDJHOIDJJ)
	{
		return false;
	}

	private float JEBCKDECPPL(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	private float CNLIKJAJKHE(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	private void HOLINPOMHEG(CHILKDJABBF OOJOIFKCDLH, PlayerHand BNGFJPIEFGN, PlayerHand JICBLAODMPP)
	{
	}

	private void PLLODAGEDOA(CHILKDJABBF OOJOIFKCDLH)
	{
	}

	private void PBOCGGGKJEK()
	{
	}

	public void RequestSelfRevive()
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestPlayerRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 NDKHGOKJALC, bool FPGCDCHKKPK)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestStartHandshakeRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, int HLNDPLBGJIJ, int KJPDKMBLLKM)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestCancelHandshakeRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestSelfRevive(GGGMJMEFFOC BOCBPOADLNM)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnPlayerRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 NDKHGOKJALC, bool FPGCDCHKKPK)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnStartHandshakeRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, int HLNDPLBGJIJ, int KJPDKMBLLKM)
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnCancelHandshakeRevive(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH)
	{
	}

	public void MasterRequestPlayerInvincibility(CHILKDJABBF EKOFNPFCLMO, float NDOEPOFJKBF)
	{
	}

	private bool EKJJPCLJDOI(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private float ANELJGEFBLG(CHILKDJABBF EKOFNPFCLMO)
	{
		return 0f;
	}

	private void EKJHLIIOOLP(CHILKDJABBF EKOFNPFCLMO, float NDOEPOFJKBF)
	{
	}

	public void LocalRequestToolDisarm(Tool AFNHKNGKICM, Vector3 OGEABPMOJJB)
	{
	}

	private bool AGDFFDGFNIF(Tool AFNHKNGKICM)
	{
		return false;
	}

	public void OnLocalPlayerEnterKillzone(Killzone FOOPALEAEGM)
	{
	}

	private void IFEJOPODCMI()
	{
	}

	private void EGBFMKFAKDL(Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	private void CMAPMAICGJJ(CHILKDJABBF INIEKKNFPDP)
	{
	}

	private void CMAPMAICGJJ(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP)
	{
	}

	private void PHAFALGHFOL()
	{
	}

	private IEnumerator EBLCMCOOLLE()
	{
		return null;
	}

	private void JKOMKGEJLPA()
	{
	}

	public void PlayCircuitFlashRequest(CHILKDJABBF EKOFNPFCLMO, float FGBPJMKCMAO, JLHLKDMLBPK HMCAFGCGFJF, float DOEJGDJILAD)
	{
	}

	[PBOMGCLBFHF]
	private void RpcPlayCircuitFlash(float FGBPJMKCMAO, JLHLKDMLBPK HMCAFGCGFJF, float DOEJGDJILAD)
	{
	}

	private void PDNGBOIEFBG(float FGBPJMKCMAO, JLHLKDMLBPK LNBGDJLPKJM, float DOEJGDJILAD)
	{
	}

	public void StopCircuitFlashRequest(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	[PBOMGCLBFHF]
	private void RpcStopCircuitFlash()
	{
	}

	private void BJJFODOEOFN()
	{
	}

	private IEnumerator JDACMHFDEOM(float FGBPJMKCMAO, Color HMCAFGCGFJF, float DOEJGDJILAD)
	{
		return null;
	}

	private void HINCLMHPLJC()
	{
	}

	private void CCBBNHINNGN(string PAKKJAPOGPN, LoadSceneMode OGCJOMHGAPD)
	{
	}

	public void RequestSetCameraShake(CHILKDJABBF EKOFNPFCLMO, float DOEJGDJILAD, float FGBPJMKCMAO)
	{
	}

	[PBOMGCLBFHF]
	private void RpcSetCameraShake(float DOEJGDJILAD, float FGBPJMKCMAO)
	{
	}

	public void RequestStopCameraShake(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	[PBOMGCLBFHF]
	private void RpcStopCameraShake()
	{
	}

	private void IDJLPGHNGDI(float LEFKDEHEKPF)
	{
	}

	private void NCPCLFHPCJE()
	{
	}

	private void MILKBPJIHID(string PBOPFHHBNPO)
	{
	}

	private void LGILCFEBJEF()
	{
	}

	private void HPMDJCEFOMK(string OFMGPNLDCAB)
	{
	}

	private void KGNNDMFDBHM(string OEEBIOPLOMG)
	{
	}

	private LocalPlayerCombatHUD BPDDAHENHAJ()
	{
		return null;
	}

	private CV2CombatHUD NBHLFAFINED()
	{
		return null;
	}

	private void BJKCCEMNLOE(bool AMMBCKDKBLE = false)
	{
	}

	public void SetPlayerCombatUIOverridden(CHILKDJABBF EKOFNPFCLMO, bool PBMDFEHKKIL)
	{
	}

	private void MHGBPFABJBI(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
	{
	}

	private void NBEMGMKLNGL(Enemy DPENEFKKNDN)
	{
	}

	private void OGHPMJJKLPJ(Enemy DPENEFKKNDN)
	{
	}

	private void NGPCEGHEKOC()
	{
	}

	private EnemyCombatUI IAFBPKAIKPC()
	{
		return null;
	}

	public void PlayReviveFeedback(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 INLGLHIPOMC, bool FPGCDCHKKPK, RecRoomAudioClip JJMOEAMPMJD = null)
	{
	}

	public void InitializeCV2CombatHUD()
	{
	}

	private void ODMNMHBGMEK()
	{
	}

	private void IEJAMDPGOPB()
	{
	}

	private void BMOFFBMKGJJ()
	{
	}

	private void OKGMAPGPPPJ()
	{
	}

	private void BOOKJAJMKLC(EGGMEJDMHKF GPKOELKKOBP)
	{
	}

	public ILODPOPFPAH CreateDeserializationHandler()
	{
		return null;
	}

	private void FMICAJHGFNA(CHILKDJABBF FCPNJBMMECM)
	{
	}

	[CompilerGenerated]
	private IEnumerator<EGGPGCCKPCO> BGKNAGIKLPI()
	{
		return null;
	}

	[CompilerGenerated]
	private void HKCGJOJKPNC(PlayerHand PMNLJGLDMJN)
	{
	}

	[CompilerGenerated]
	private void AIOBKBODFEL(PlayerHand PMNLJGLDMJN)
	{
	}
}
