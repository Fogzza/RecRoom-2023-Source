using System;
using System.Collections.Generic;
using RecRoom;
using RecRoom.Audio;
using RecRoom.Tools;
using UnityEngine;

public class CharadesManager : GameRuleManager
{
	public enum JLKBGHOCDKN
	{
		COOP_GAME_START = 0,
		COOP_SELECT_PERFORMER = 1,
		COOP_PERFORMER_ROUND_START = 2,
		COOP_PERFORMER_ROUND_RUNNING = 3,
		COOP_POST_PERFORMER_ROUND = 4,
		COOP_GAME_END = 5,
		TEAM_GAME_START = 6,
		TEAM_SELECT_PERFORMER = 7,
		TEAM_PERFORMER_ROUND_START = 8,
		TEAM_PERFORMER_ROUND_RUNNING = 9,
		SWITCH_PERFORMING_TEAM = 10,
		TEAM_GAME_END = 11,
		INVALID = 65535
	}

	public enum FMBJBJOIIDH
	{
		COOP = 0,
		TEAM = 1
	}

	public enum EEHLCAFCBDM
	{
		AUDIENCE = -1,
		GUESSER = 0,
		PERFORMER = 1
	}

	public enum FNPAPPFEHOB
	{
		AUDIENCE = -1,
		GUESSER = 0,
		PERFORMER = 1
	}

	private const float KBBGEJJADGD = 0f;

	private const float MADJHEHMOBF = 4f;

	private const float MLABHBEMNFB = 5f;

	private const float ECAEFLMKGNF = 2f;

	private const float KPGPONNHAAJ = 2f;

	private const float FJLGCBFHJKA = 2f;

	private const float HJIFFHMFHAE = 0.5f;

	private const float PNEMOOHOJMP = 2f;

	private const float IMLGGOABDCP = 0f;

	private const float PDGICDLPGOJ = 5f;

	private const float JPLHLMDLDEC = 3f;

	private const float HMGMDFODGNA = 1f;

	private static readonly JLHLKDMLBPK[] ONJFPCPBPAG;

	private float EGAGOANNMAG;

	private float IFKPNPHKOBF;

	[NonSerialized]
	public float CoopMaxPerformerRoundDuration;

	[NonSerialized]
	public float TeamLightningMaxPerformerDuration;

	[NonSerialized]
	public int TeamLightningGameRounds;

	[SerializeField]
	private RecRoomAudioClip successClip;

	[SerializeField]
	private RecRoomAudioClip blueTeamJoinVO;

	[SerializeField]
	private RecRoomAudioClip redTeamJoinVO;

	[SerializeField]
	private RecRoomAudioClip timerExpiredClip;

	[SerializeField]
	private RecRoomAudioClip timerTickLoopClip;

	[SerializeField]
	private CharadesPhysicalButton guessButton;

	private List<CharadesPen> BJIJNEJJLCE;

	private CharadesPen PCNHOMDDLBM;

	private ColorButton DGKNHFCGGOO;

	private Color OPMOMMMIFBE;

	private CardBox NPHLCPIBKNL;

	private List<CharadesPodium> BEBMCMGIBEB;

	private CharadesRoundTimer ONCEKIECKDG;

	private JOJOABLFOBA AIOHBGHBGBA;

	private HONEDBECDOK FAGOPFNPHFC;

	private global::MOBDJNEDDKC<POEOMLLLCAI> GOABMLFMLKL;

	private global::MOBDJNEDDKC<GIBEGHKMCIE> CDKBGGIDDAL;

	private global::MOBDJNEDDKC<int> BMBFPNOAFOL;

	private global::MOBDJNEDDKC<POEOMLLLCAI> GKJNIGLKGOP;

	private global::MOBDJNEDDKC<POEOMLLLCAI> KOJHMIIPIEA;

	private SFXAudioSource OICKFGADPOL;

	private List<Tool> DGHNEGGEGBN;

public new static CharadesManager Instance
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

public float TeamLightningTeamRoundDuration
{
get 	{
		return 0f;
	}

set {
	}
}

public float CoOpGameDuration
{
get 	{
		return 0f;
	}

set {
	}
}

public POEOMLLLCAI TeamOneLastPerformerIndex
{
get 	{
		return POEOMLLLCAI.INDEX_0;
	}

set {
	}
}

public POEOMLLLCAI TeamTwoLastPerformerIndex
{
get 	{
		return POEOMLLLCAI.INDEX_0;
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

public bool IsCoopPerformerRoundRunning
{
get 	{
		return false;
	}

}

public bool IsTeamPerformerRoundRunning
{
get 	{
		return false;
	}

}

public POEOMLLLCAI PerformerPlayerIndex
{
get 	{
		return POEOMLLLCAI.INDEX_0;
	}

set {
	}
}

public GIBEGHKMCIE CurrentPerformingTeam
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

set {
	}
}

public int CurrentTeamRoundNumber
{
get 	{
		return 0;
	}

set {
	}
}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void KNBFMECMMEL()
	{
	}

	private void EAKLEKEJNHP()
	{
	}

	protected void Update()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected override void HDJBEAFJEHD()
	{
	}

	protected override void ENHEJEADGCH()
	{
	}

	protected void JHECFGDENEP(bool BIJHPJHGOEF, bool AEDEGBAOLDD)
	{
	}

	protected void LHOABNCJFAK(bool BIJHPJHGOEF)
	{
	}

	protected void NFKJFJMFLOI()
	{
	}

	private void IFICONBMKAI()
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestGameplayExtruder(GGGMJMEFFOC BOCBPOADLNM)
	{
	}

	[PBOMGCLBFHF]
	private void RpcPickupGameplayExtruder()
	{
	}

	protected void MHGBPFABJBI(CHILKDJABBF FFDEPLCDBNA)
	{
	}

	private void FMFNFGINLAF()
	{
	}

	private void FFPONPAPLIE()
	{
	}

	private void DEACECBMEBG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void OPPFPIGMFPG()
	{
	}

	private void AGPDJHCDMNH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void EOHLIFDFIBI()
	{
	}

	private void KEDIHLCGDHI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FMGDBFMLBMK()
	{
	}

	private void PIKKLNBKCHL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void DBAKJDPPNNG()
	{
	}

	private void HKMEIDJGPJJ()
	{
	}

	private void KOFBFLGJDGJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FHNLCGDAFKG()
	{
	}

	private void IMAODAHELFO()
	{
	}

	private void KIHDFPBGGKJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HBDBIPIBJPN()
	{
	}

	private void LEBAINNGMBA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void GCAFJJDLJLK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GDFCGOCNFGL()
	{
	}

	private void AICNEPMOABH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void OCBLKPPIHAI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void JEHADPCNNNF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void MDCAPLONHPM()
	{
	}

	private void NLHBOCMCNOJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void NDBFOEBPCFL()
	{
	}

	private void CPAHBGCJHKN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void NPFIDNCJEHP()
	{
	}

	private void DKIJNFMMKFH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void KILGPBKBJGI()
	{
	}

	private void JFHJLBKGDFF()
	{
	}

	private void PDAPBEMDFHC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void OBMFGIMLKEG()
	{
	}

	public bool IsPlayerPerforming(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private void GBCBADLMHAA()
	{
	}

	private void MEEHGIEBACE()
	{
	}

	private void JIIGLKEKMJP()
	{
	}

	private void DKDIDNPBGKM(bool DBJDMJKOBBP = false)
	{
	}

	private void KBBOFBAFIFK(bool BNMCDCPDKIL = false)
	{
	}

	private void MNIAINIENOB(PhysicalButtonBase HHDMPJJAPJJ, Player HDJDDJPEFCG)
	{
	}

	private void BDNCBFBDKBA()
	{
	}

	[PBOMGCLBFHF]
	private void RpcMasterRequestGuess(GGGMJMEFFOC BOCBPOADLNM)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnGuess(CHILKDJABBF MILBGJCMLOD)
	{
	}

	[PBOMGCLBFHF]
	private void RpcOnTimerExpired()
	{
	}

	private bool MFAABCCAKEB(CHILKDJABBF CIJOKONENND)
	{
		return false;
	}

	private bool OCPGJAICOEP()
	{
		return false;
	}

	private bool JGJLHDKJFAO()
	{
		return false;
	}

	private void CAHFFAODFNC()
	{
	}

	public void UpdatePodiums()
	{
	}

	public void ClearPodiums()
	{
	}

	private void BAPANPJIGAA()
	{
	}

	private bool OLDEOJEMPCE(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
	{
		return false;
	}

	private void KEAKCFKKHJL(bool DBJDMJKOBBP = false)
	{
	}

	protected void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void DGFBKFMBILK()
	{
	}
}
