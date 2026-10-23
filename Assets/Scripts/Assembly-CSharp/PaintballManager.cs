using RecRoom;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.Combat;
using RecRoom.Tools;
using UnityEngine;

public class PaintballManager : GameRuleManager
{
	public enum HGOOCEJIEMN
	{
		CaptureTheFlag = 0,
		TeamBattle = 1,
		None = 2
	}

	private enum HBCGKHLCJIC
	{
		CTF_ROUND_RUNNING = 0,
		CTF_FLAG_CAPTURED = 1,
		TEAM_BATTLE_ROUND_RUNNING = 2,
		INVALID = 65535
	}

	private enum FAEFBEOGGLC
	{
		HITS = 0,
		OUTS = 1,
		FLAG_CAPTURES = 2
	}

	private sealed class PIFPBKKGFKA
	{
		public GIBEGHKMCIE team;

		internal bool _003CValidateRoomForModeCTF_003Eb__0(FlagTool x)
		{
			return false;
		}
	}

	private static readonly string PBNAJDDPJEH;

	[SerializeField]
	private GameRoleSettings ctfGameRoleSettings;

	[SerializeField]
	private PlayerCombatUI playerCombatUIPrefab;

	[SerializeField]
	private RecRoomAudioClip captureTheFlagTitleVO;

	[SerializeField]
	private RecRoomAudioClip teamBattleTitleVO;

	[SerializeField]
	private RecRoomAudioClip playerHitSFX;

	[SerializeField]
	private RecRoomAudioClip playerOutSFX;

	[SerializeField]
	private RecRoomAudioClip flagPickupSFX;

	[SerializeField]
	private RecRoomAudioClip blueTeamFlagPickupVO;

	[SerializeField]
	private RecRoomAudioClip redTeamFlagPickupVO;

	[SerializeField]
	private RecRoomAudioClip flagDroppedSFX;

	[SerializeField]
	private RecRoomAudioClip blueTeamFlagDroppedVO;

	[SerializeField]
	private RecRoomAudioClip redTeamFlagDroppedVO;

	[SerializeField]
	private RecRoomAudioClip flagReturnSFX;

	[SerializeField]
	private RecRoomAudioClip blueTeamFlagReturnVO;

	[SerializeField]
	private RecRoomAudioClip redTeamFlagReturnVO;

	[SerializeField]
	private RecRoomAudioClip flagCaptureSFX;

	[SerializeField]
	private RecRoomAudioClip blueTeamFlagCaptureVO;

	[SerializeField]
	private RecRoomAudioClip redTeamFlagCaptureVO;

	[SerializeField]
	private float audioFXMinInterval;

	[SerializeField]
	private RecRoomAudioClip loadingGameMusic;

	[SerializeField]
	private RecRoomAudioClip gameplayMusic;

	[SerializeField]
	private KLNOBKBCIEK flagCarrierGameRoleId;

	[SerializeField]
	private float flagHolderMovementCooldown;

	[SerializeField]
	private float flagHolderCustomWalkSpeed;

	private const float HABOHHDMBOK = 0.35f;

	private const float OLPFMBNLHGJ = 3f;

	private const float DOPHLKMNCLM = 3f;

	private const float IKGELHLEKHO = 8f;

	private float MOFIELACCMO;

	private int GGCOGEBAAEL;

	private bool FNJLLIIFGJP;

	private JOJOABLFOBA MGBNNJLMDMA;

	private HONEDBECDOK PBKPDDKOMOE;

	private float DBBCAKIFIMC;

	private float ECPKHDEIBMM;

	private float KLCJIBKJEAN;

	private float PNONIMLLDIE;

	private global::MOBDJNEDDKC<GIBEGHKMCIE> JPHPKBBJGNE;

	private global::MOBDJNEDDKC<int> FJCPJHEOBEL;

public new static PaintballManager Instance
{
get 	{
		return null;
	}

}

public new static bool IsInitialized
{
get 	{
		return false;
	}

}

public override GameRoleSettings CustomExtraGameRoleSettings
{
get 	{
		return null;
	}

}

public float GameDuration
{
get 	{
		return 0f;
	}

set {
	}
}

public int ScoreToWin
{
get 	{
		return 0;
	}

set {
	}
}

public bool MusicEnabled
{
get 	{
		return false;
	}

set {
	}
}

private GIBEGHKMCIE JJIIPOPNGKL
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

set {
	}
}

private int BCHKGCEEHMF
{
get 	{
		return 0;
	}

set {
	}
}

public override string RuleTypeAutoTag
{
get 	{
		return null;
	}

}

public override bool AutoRunTimer
{
get 	{
		return false;
	}

}

public bool IsRoundRunning
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected void Update()
	{
	}

	protected void NFKJFJMFLOI()
	{
	}

	protected override void HDJBEAFJEHD()
	{
	}

	protected override void ENHEJEADGCH()
	{
	}

	public override void RecordMatchAnalytics(bool DNKBEOHALFL)
	{
	}

	public override bool LocalPlayerHasGameActivity()
	{
		return false;
	}

	private void MMJKLAEEMHB(CHILKDJABBF CCMOOAAAOGC, CHILKDJABBF KJCCPIIFNGO, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC AAEAKJPHADF, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	private void LPEPOPBILMM(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
	{
	}

	private void ADIKNDCBDOO(CHILKDJABBF NJDHAACHDKF, string FFHJFEKLOPC)
	{
	}

	private void IELKNJJIHOE(CHILKDJABBF KJCCPIIFNGO, string POMDNILKKCG)
	{
	}

	private void HIIALGDFABN(FlagTool NCJCLJGCIMF, GIBEGHKMCIE FMOKAADPMDE, Player NGHIMLOOILF)
	{
	}

	private void OPHINCPGHAO(FlagTool NCJCLJGCIMF, Player CLAAKJAFDLA)
	{
	}

	private void EHJBBLCHIFG(FlagTool NCJCLJGCIMF, Player EFIJKONHFCN)
	{
	}

	private void NPGOPGJDFBI(FlagTool NCJCLJGCIMF)
	{
	}

	private void LKPOEDIGHMO(FlagTool NCJCLJGCIMF, Player EJCJDCBJCLP)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestFlagCapture(FlagTool NCJCLJGCIMF, GIBEGHKMCIE FMOKAADPMDE, CHILKDJABBF ADLMEFEICIC)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestFlagReturn(FlagTool NCJCLJGCIMF, CHILKDJABBF EMBBMGFFOIN)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestFlagTaken(FlagTool NCJCLJGCIMF, CHILKDJABBF CLAAKJAFDLA)
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestFlagDrop(FlagTool NCJCLJGCIMF, CHILKDJABBF LOFJOGNFLPB)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnFlagCaptured(FlagTool NCJCLJGCIMF, CHILKDJABBF LCNFJFIKILP)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnFlagTaken(FlagTool NCJCLJGCIMF, CHILKDJABBF HNFKCOCGFOJ)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnFlagReturn(FlagTool NCJCLJGCIMF, CHILKDJABBF EJCJDCBJCLP)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnFlagDrop(FlagTool NCJCLJGCIMF, CHILKDJABBF LOFJOGNFLPB)
	{
	}

	private bool LONNMLANGMK(FlagTool NCJCLJGCIMF, GIBEGHKMCIE FMOKAADPMDE, CHILKDJABBF ADLMEFEICIC)
	{
		return false;
	}

	private bool OEBMLIFMOEE(FlagTool NCJCLJGCIMF, CHILKDJABBF EFIJKONHFCN)
	{
		return false;
	}

	private bool MKJJPOEIHNC(FlagTool NCJCLJGCIMF, CHILKDJABBF CLAAKJAFDLA)
	{
		return false;
	}

	private bool FLAJPIBHIDK(FlagTool NCJCLJGCIMF, CHILKDJABBF EMBBMGFFOIN)
	{
		return false;
	}

	private FlagTool KOPKMKBDNAC(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private void KBIMPHKOFPL(bool IPPIIFIEMDK)
	{
	}

	private void LAAGPGGIOLI(bool PDFMNDAMDOE)
	{
	}

	private static Vector3 GHLEGCNONCK(FlagTool NCJCLJGCIMF)
	{
		return default;
	}

	private void PKCHAIOFJBL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void DFMKPODNMAO()
	{
	}

	private void DFKNPKANGAC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EGEPCHBKCNG()
	{
	}

	private void NLHKPFCGOLM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void DGEGINAOPEL()
	{
	}

	public override bool ValidateRoom()
	{
		return false;
	}

	private bool MLIGMHFGHLP()
	{
		return false;
	}

	private bool PCMKCNBBPAB()
	{
		return false;
	}

	private void NAOAHFANMLO()
	{
	}

	private bool IECGPIOGJPI(Tool IEGMBEPJMGC, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}

	private bool BKBIGCEOKPP(GenericPortal KNAPEFNAOGE, Player FOCKAEINGKG)
	{
		return false;
	}
}
