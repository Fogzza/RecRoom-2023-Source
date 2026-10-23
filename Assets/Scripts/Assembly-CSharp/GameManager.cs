using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using RecNet;
using RecRoom.Audio;
using RecRoom.Core.GameManagement;
using UnityEngine;

public sealed class GameManager : NetworkedSingletonMonoBehaviour<GameManager>, OJIHDJHLFFI
{
	private sealed class ENMHLFMPODH
	{
		public GameManager _003C_003E4__this;

		public bool startOver;

		internal void _003CMasterStartGame_003Eb__0(bool isDev)
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct NFKEJJLKLDM : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<(bool, string, int, int)> _003C_003Et__builder;

		public CHILKDJABBF receiverPlayer;

		public string promptTitle;

		public string promptBody;

		public string[] answerChoices;

		public GameManager _003C_003E4__this;

		private TaskAwaiter<ICABNBCOLBH> _003C_003Eu__1;

		private TaskAwaiter<(bool, string, int, int)> _003C_003Eu__2;

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

	private sealed class COEDPDGOIBP
	{
		public GameManager _003C_003E4__this;

		public CHILKDJABBF sourcePlayer;

		public int actorId;

		public int requestId;

		internal void _003CRpcSendMultipleChoicePrompt_003Eb__0(ICABNBCOLBH response)
		{
		}
	}

	public const int MAX_SANDBOX_PLAYERS = 20;

	private const float JMILNDBNCOI = 3f;

	private const float MBKLLGNIMDG = 6f;

	private const float NBOFDIAMAHI = 3f;

	private const float NKMINBEGOEB = 35f;

	private const float JNMALCOGAMF = 15f;

	private const float FBFJDKBCIBI = 10f;

	private const float FKKKJADDLDE = 10f;

	private const float IPKECEINCDN = 5f;

	private const float BILLMELKOLL = 10f;

	public static EEANDDJEMJC OnGameStartEvent;

	public static EEANDDJEMJC OnGameEndEvent;

	public static EEANDDJEMJC OnExitGameOverEvent;

	public static EEANDDJEMJC InitializeSceneOnPreGameEvent;

	public static EEANDDJEMJC OnGameLoadingEvent;

	public static EEANDDJEMJC OnGameResultsEvent;

	public static global::BPEPJJDICII<bool, bool> InitializeLocalPlayerEvent;

	public static global::HHOBPMOCKMJ<bool> ResetLocalPlayerEvent;

	public static EEANDDJEMJC UpdateLocalPlayerPickupRestrictionsEvent;

	public static global::HHOBPMOCKMJ<CHILKDJABBF> OnPlayerTeamChangeEvent;

	private ILNJNAIHNJF.DGKBCFAHNKA KLBFNLDJBAP__BackingField;

	private Action HHDMDHMHPOC__BackingField;

	private Action KFKGPNMEENL__BackingField;

	private Action EGDOLLAFHLD__BackingField;

	private Action GMBINNKCNLO__BackingField;

	private Action GFIJHNANKMP__BackingField;

	[SerializeField]
	private GameCombatManager combatManager;

	[SerializeField]
	private GameTeamManager teamManager;

	[SerializeField]
	private GameScoreManager scoreManager;

	[SerializeField]
	private GameSpawnManager spawnManager;

	[SerializeField]
	private GameBoundsManager boundsManager;

	[SerializeField]
	private GamePowerUpManager powerupManager;

	[SerializeField]
	private GameVoteManager voteManager;

	[SerializeField]
	private GameConfigurationAsset[] supportedGameConfigTemplates;

	[SerializeField]
	private GameConfigurationTool[] legacySandboxGameConfigPrefabs;

	private FIHGBEHGLGB CHJDMGLMOCN;

	private FIHGBEHGLGB JDJGPCFJEMC;

	private global::AFHOAHNAMGF<RecRoomAudioClip> LMCENJEEGHP;

	private FIHGBEHGLGB AGPCBLHHKLM;

	private FIHGBEHGLGB POJOCPEJGGG;

	private FIHGBEHGLGB FPAKBBECKFG;

	private FIHGBEHGLGB AJPNFBJBMDB;

	private FIHGBEHGLGB ECHHBEOGAFK;

	private GameTimerManager OJJMELGNKFB;

	private GameMovementManager BPLIJPICFHP;

	private CPFPNFLPLME ECHBMKAMJLF;

	private GamePresenceManager AGAAMLHMCHK;

	[NonSerialized]
	public bool SuppressPregameVO;

	private global::MOBDJNEDDKC<bool> FOKEMEKBGKH;

	private JOJOABLFOBA JOMILDGFALA;

	private HONEDBECDOK LHGNDEGHHFD;

	private KBJKDKFNFIA DIHKDEMEJCK;

	private global::DAHHPCNLCBH<GameConfigurationTool> DHJNPGMBCGO;

	private global::DAHHPCNLCBH<GameRuleCircuitWrapperTool> CAKHAKCGNEK;

	private List<KEAFLIHKNBO> DCOJPCKDEOI;

	private List<SpawnableTool> KKCNMILEFAF;

	[NonSerialized]
	public bool supportsPlayingAgainInThisInstance;

	[NonSerialized]
	public bool gameCanStillBeWon;

	[NonSerialized]
	public bool supportsGameOverGiftDequeing;

	[NonSerialized]
	public bool SuppressGameOverChallengeEvent;

	[NonSerialized]
	public bool allowDevsAndCommunityTeamToStartWhileWaitingForPlayers;

	private bool NFLGKJFPEAE;

	private HLNFDOBEGJO CHABDOLEEMD;

	private INBDIKIJLGF GBIFNANKKKC;

	private CGOPOAFDIDN FIJHCMLFKJH;

	private IDisposable PLBEAMIACLE;

	private LKFJJHJMFIB ADGPGMPOPNJ;

	private FCAFJHGMACK EMBGONOIIBO;

	private global::MOBDJNEDDKC<bool> ACKEJLKMOCH;

	private global::MOBDJNEDDKC<string> EGLOAMOLOPB;

	private global::MOBDJNEDDKC<bool> KFHMGODJKAG;

	private global::MOBDJNEDDKC<GIBEGHKMCIE> LBMFALNADOG;

	private global::MOBDJNEDDKC<bool> FAAFGKOINGJ;

	private float? EIMFPMNCEOD;

	private GIBEGHKMCIE MGJFBGHMGEF;

	private global::AFHOAHNAMGF<string> LHCDMNJBCOH;

	private FIHGBEHGLGB BAFHKIHDMKK;

	private FIHGBEHGLGB HLIEOCOJNIN;

	private global::AFHOAHNAMGF<float> LIJKJFKIEAP;

	private global::AFHOAHNAMGF<float> FNDDEGAKNED;

	private FIHGBEHGLGB KBMPKHPOFCN;

	private global::AFHOAHNAMGF<bool> DIPCNFAJLBL;

	private global::AFHOAHNAMGF<bool> HGPGLNOPMBJ;

	private global::AFHOAHNAMGF<bool> GKCFAHJCNKC;

	private FIHGBEHGLGB BMFBLDPCNDF;

	private bool CMFEHIDPMNH;

	private global::JEKNBGHMBJN<(bool, string, int, int)> AKNAJNONIEJ;

public GameConfigurationAsset[] SupportedGameConfigTemplates
{
get 	{
		return null;
	}

}

public bool HasGameConfigurationApplied
{
get 	{
		return false;
	}

}

public bool ResetToolsOnGameStartSupported
{
get 	{
		return false;
	}

}

private RecRoomAudioClip KLBBDHDJJHK
{
get 	{
		return null;
	}

}

private bool JHNPNEKKGNJ
{
get 	{
		return false;
	}

}

private bool LIDPKEBFCHA
{
get 	{
		return false;
	}

}

private bool DDADBEIHCJE
{
get 	{
		return false;
	}

}

private bool IJEPGJCNLJC
{
get 	{
		return false;
	}

}

private bool AHANMMKMCGA
{
get 	{
		return false;
	}

}

public GameCombatManager CombatManager
{
get 	{
		return null;
	}

}

public GameTeamManager TeamManager
{
get 	{
		return null;
	}

}

public GameSpawnManager SpawnManager
{
get 	{
		return null;
	}

}

public GameScoreManager ScoreManager
{
get 	{
		return null;
	}

}

public GameBoundsManager BoundsManager
{
get 	{
		return null;
	}

}

public GamePowerUpManager PowerupManager
{
get 	{
		return null;
	}

}

public GameVoteManager VoteManager
{
get 	{
		return null;
	}

}

public GameTimerManager TimerManager
{
get 	{
		return null;
	}

private set {
	}
}

public GameMovementManager MovementManager
{
get 	{
		return null;
	}

private set {
	}
}

public CPFPNFLPLME UIManager
{
get 	{
		return null;
	}

private set {
	}
}

public GamePresenceManager PresenceManager
{
get 	{
		return null;
	}

private set {
	}
}

public bool GameHasSaveState
{
get 	{
		return false;
	}

set {
	}
}

public bool GameConfigurationCorrupted
{
get 	{
		return false;
	}

private set {
	}
}

public bool AllowRewards
{
get 	{
		return false;
	}

}

private float DFANCNBJFEG
{
get 	{
		return 0f;
	}

}

public bool IsInitializing
{
get 	{
		return false;
	}

}

public bool SupportsSpectating
{
get 	{
		return false;
	}

}

public bool CanLocalPlayerStartGame
{
get 	{
		return false;
	}

}

public bool CanLocalPlayerStopGame
{
get 	{
		return false;
	}

}

public bool CanContinue
{
get 	{
		return false;
	}

set {
	}
}

public bool GameRuleManagerStarted
{
get 	{
		return false;
	}

}

public string GameID
{
get 	{
		return null;
	}

private set {
	}
}

public bool HasWinner
{
get 	{
		return false;
	}

private set {
	}
}

public GIBEGHKMCIE WinningTeam
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

private set {
	}
}

public bool GameEndedPrematurely
{
get 	{
		return false;
	}

private set {
	}
}

private float? GKGCDGJCEAB
{
get 	{
		return null;
	}

set {
	}
}

public NJOGGCOMCJG CurrentModeType
{
get 	{
		return NJOGGCOMCJG.MODE_1;
	}

}

private GameConfigurationTool KPJFBBJNPII
{
get 	{
		return null;
	}

set {
	}
}

private GameRuleCircuitWrapperTool JPBDPPFDKLB
{
get 	{
		return null;
	}

set {
	}
}

public bool MoreThanOneAvailableGame
{
get 	{
		return false;
	}

}

public string GameName
{
get 	{
		return null;
	}

}

public bool GameWinRestricted
{
get 	{
		return false;
	}

}

public bool PreGameVoiceOverSupported
{
get 	{
		return false;
	}

}

public float GameStartDelay
{
get 	{
		return 0f;
	}

}

public float ResultsSubStateDuration
{
get 	{
		return 0f;
	}

}

public bool GameOverFeedbackRestricted
{
get 	{
		return false;
	}

}

public bool RespawnPlayersOnGameStartSupported
{
get 	{
		return false;
	}

}

public bool RespawnPlayersOnGameOverSupported
{
get 	{
		return false;
	}

}

public bool PersistPlayerStatsOnGameStart
{
get 	{
		return false;
	}

}

public bool GameOverGiftGenerationRestricted
{
get 	{
		return false;
	}

}

public bool StartRequirementsMet
{
get 	{
		return false;
	}

}

public bool ReadyToJoinInProgress
{
get 	{
		return false;
	}

}

public bool CanToggleGameConfiguration
{
get 	{
		return false;
	}

}

public float LoadingGameTimeRemaining
{
get 	{
		return 0f;
	}

}

public float PostGameTimeRemaining
{
get 	{
		return 0f;
	}

}

public HAALBELHGID CurrentState
{
get 	{
		return HAALBELHGID.INITIALIZE_CONFIG;
	}

}

public bool IsPreGameOrInitializing
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

public bool IsGameRunningOrLoading
{
get 	{
		return false;
	}

}

public bool CanSpawnGiftPackageInCurrentState
{
get 	{
		return false;
	}

}

public bool GameCanStillBeWon
{
get 	{
		return false;
	}

}

public EOGNBABPLBF CurrentPreGameState
{
get 	{
		return EOGNBABPLBF.WAITING_FOR_PLAYERS;
	}

}

public ADNNPEHMGND CurrentPostGameState
{
get 	{
		return ADNNPEHMGND.GAME_OVER;
	}

}

private bool JHHABHLPKDC
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ PersistableRunFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

public event ILNJNAIHNJF.DGKBCFAHNKA StateChangeEvent {
add {
	}
remove {
	}
}

public event Action ActiveGameConfigChangeEvent {
add {
	}
remove {
	}
}

public event Action GameStartedEvent {
add {
	}
remove {
	}
}

public event Action GameEndedEvent {
add {
	}
remove {
	}
}

public event Action GameWinEvent {
add {
	}
remove {
	}
}

public event Action GameLoseEvent {
add {
	}
remove {
	}
}

	public void AddHasGameConfigurationApplied(object IALNODEHBNN)
	{
	}

	public void RemoveHasGameConfigurationApplied(object IALNODEHBNN)
	{
	}

	public void AddResetToolsOnGameStartSupport(object IALNODEHBNN)
	{
	}

	public void RemoveResetToolsOnGameStartSupport(object IALNODEHBNN)
	{
	}

	public void AddGameNameVO(RecRoomAudioClip DLLECDOAMDE, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveGameNameVO(object IALNODEHBNN)
	{
	}

	public void AddResultsVoiceOverSupport(object IALNODEHBNN)
	{
	}

	public void RemoveResultsVoiceOverSupport(object IALNODEHBNN)
	{
	}

	public void AddGameModeNotificationsSupport(object IALNODEHBNN)
	{
	}

	public void RemoveGameModeNotificationsSupport(object IALNODEHBNN)
	{
	}

	public void AddInGamePlayerNotificationSupport(object IALNODEHBNN)
	{
	}

	public void RemoveInGamePlayerNotificationSupport(object IALNODEHBNN)
	{
	}

	public void AddEndGameWhenAllDead(object IALNODEHBNN)
	{
	}

	public void RemoveEndGameWhenAllDead(object IALNODEHBNN)
	{
	}

	public void AddReloadInstanceAfterPostgameResults(object IALNODEHBNN)
	{
	}

	public void RemoveReloadInstanceAfterPostgameResults(object IALNODEHBNN)
	{
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void GEIAKCIBMDO(Player EKOFNPFCLMO)
	{
	}

	private void GANCIPGAOBN()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private void LECGBANNHOP()
	{
	}

	private void HDJBEAFJEHD()
	{
	}

	private void NJAHOFKKJLB()
	{
	}

	private void ENHEJEADGCH()
	{
	}

	private DFKPMLLJJLO FGAKMBMHEIM(bool LJDBDNBHHAF, bool KOEEMOIFPBE, bool IPNGGBKDLCG = true)
	{
		return null;
	}

	private void JHECFGDENEP(bool BIJHPJHGOEF, bool AEDEGBAOLDD)
	{
	}

	private void LHOABNCJFAK(bool BIJHPJHGOEF)
	{
	}

	private void MHGBPFABJBI(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
	{
	}

	private void AMPIBPGICIM(GameConfigurationTool JGMICIDIILO)
	{
	}

	private void EIDJEMAEKDK(GameConfigurationTool JGMICIDIILO)
	{
	}

	private void ABOGHDCCBNG()
	{
	}

	private void AOFGHGDFAGP()
	{
	}

	private int EJIADAMJNCJ()
	{
		return 0;
	}

	public void AddGameName(string KNOPFGAGMCN, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveGameName(object IALNODEHBNN)
	{
	}

	public void AddGameWinRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveGameWinRestriction(object IALNODEHBNN)
	{
	}

	public void AddPreGameVoiceOverSupport(object IALNODEHBNN)
	{
	}

	public void RemovePreGameVoiceOverSupport(object IALNODEHBNN)
	{
	}

	public void AddGameStartDelay(float FGBPJMKCMAO, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveGameStartDelay(object IALNODEHBNN)
	{
	}

	public void AddResultsSubStateDuration(float FGBPJMKCMAO, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveResultsSubStateDuration(object IALNODEHBNN)
	{
	}

	public void AddGameOverFeedbackRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveGameOverFeedbackRestriction(object IALNODEHBNN)
	{
	}

	public void AddRespawnPlayersOnGameStartSupport(bool BFDBCMGIOBG, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveRespawnPlayersOnGameStartSupport(object IALNODEHBNN)
	{
	}

	public void AddRespawnPlayersOnGameOverSupport(bool BFDBCMGIOBG, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveRespawnPlayersOnGameOverSupport(object IALNODEHBNN)
	{
	}

	public void AddPersistPlayerStatsOnGameStart(bool BFDBCMGIOBG, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemovePersistPlayerStatsOnGameStart(object IALNODEHBNN)
	{
	}

	public void AddGameOverGiftGenerationRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveGameOverGiftGenerationRestriction(object IALNODEHBNN)
	{
	}

	public void LocalPlayerTryOpenStartOverMenu()
	{
	}

	private void OFHOMKEGGGI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HDKOLMIGBFM()
	{
	}

	public void LocalPlayerRequestStartGame(bool NNBEAJCKAAN = false)
	{
	}

	public void LocalPlayerRequestStartGameEarly()
	{
	}

	public bool LocalPlayerRequestStopGame()
	{
		return false;
	}

	public void LocalPlayerJoinLeaveGame()
	{
	}

	private void AGOFEKOJJNC()
	{
	}

	private bool EFEKAGFBCIB(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public bool CanLocalPlayerSwitchTeam(GIBEGHKMCIE ICEDHPCLPDM)
	{
		return false;
	}

	public void LocalPlayerSwitchTeam(GIBEGHKMCIE ICEDHPCLPDM)
	{
	}

	public void LocalPlayerToggleGameConfiguration()
	{
	}

	public void MasterSetWinningTeam(GIBEGHKMCIE NEBNOBLPNEP)
	{
	}

	public bool IsPlayerOnWinningTeam(CHILKDJABBF FBCDJHOIDJJ)
	{
		return false;
	}

	public void MasterStopGame(bool FHEOHMKICKM = false)
	{
	}

	public void MasterHandleFailedRoomChangeAfterVote(string LOKKJFCDNHB)
	{
	}

	public void RoomAuthorityMoveToNextInstance()
	{
	}

	private void DIFMGLOBIGL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FFGJCGLDNCC()
	{
	}

	private void OOAGMANLLPA()
	{
	}

	private void JGALENCHPMJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void PCDGMFIKPGC()
	{
	}

	private void BGMFIIDHHOF()
	{
	}

	private void FKABAKBDMJK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void FAMMOIJPGHP()
	{
	}

	private void PCCNPFLKCBH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void DEPNKOLOEIE()
	{
	}

	private void BGBHNMLMPJE()
	{
	}

	private void KCCFIIBPLGO()
	{
	}

	private void AAGPKJHGAOJ()
	{
	}

	private void JMPLMLMDBPM()
	{
	}

	private void FJIDFDHMGGA()
	{
	}

	private bool MPIBGOPBJBC()
	{
		return false;
	}

	private void FJEDPBMHNIB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void GCOGLGHHHJD()
	{
	}

	private void GDCOBAADFGK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void OENNJCHOHCB()
	{
	}

	private void DPGDHMOKHEB()
	{
	}

	private void DAKBHOFHPLO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void CICFOEPFCNF()
	{
	}

	private void ECGPHKOLKJK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void BALEGKBJJLA()
	{
	}

	private void CABDABDFEMK(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void DNECBPFMKKP()
	{
	}

	private void EIAGCECNEAA()
	{
	}

	private void FGDAPNKIKJF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void HOMKCMBGLPO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void BDEGFCIJCAP()
	{
	}

	private void JGJPFGIEGHA()
	{
	}

	private void LNLDPCOIDCE()
	{
	}

	private void HAKPCBNBEGM()
	{
	}

	public void RaiseGameWinEvent()
	{
	}

	public void RaiseGameLoseEvent()
	{
	}

	private void HANCDGABGGI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void MBKGPCKEPOB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	public void SendGameOverChallengeEvent(bool LJDBDNBHHAF, bool KOEEMOIFPBE, bool IPNGGBKDLCG = true)
	{
	}

	private void HKIHICJPHGD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void BGBLIBEIHCG()
	{
	}

	private void IAGKBIJKJBK()
	{
	}

	private void OLAHHHCOBFN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void MJMMANMICME()
	{
	}

	private void NJNDALKMEAI(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void IOGKGFNJIBN()
	{
	}

	private string OEIMMDCAPCM(int LMLDKMMPDFD)
	{
		return null;
	}

	private string HKEANBNALPJ(int LMLDKMMPDFD, int BEOILOFKEIA)
	{
		return null;
	}

	private void JABPBBEJLCD(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
	{
	}

	public void MasterCleanupAllSpawnedEquipment(bool BCCGHNCNCMO = false, bool BALOHAGCKMG = false)
	{
	}

	private void ENBHIOJBOEC(bool JAPOLIMILIM)
	{
	}

	private void NBCAFDHOMDA(bool HFGCAAHFFOA, bool HBANNKFNDNI)
	{
	}

	private void PDBHNALNHJF(SpawnableTool IEGMBEPJMGC)
	{
	}

	private void INAGDEBBDPP(SpawnableTool IEGMBEPJMGC)
	{
	}

	private void HMBIOGFGNJJ()
	{
	}

	private void OBHCMMGCOAJ()
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterStartGame(CHILKDJABBF EKOFNPFCLMO, bool NNBEAJCKAAN = false)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterStartGameEarly(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void MasterStartGame(bool NNBEAJCKAAN = false)
	{
	}

	private void FDINBKNBNEA(CHILKDJABBF EKOFNPFCLMO, bool NNBEAJCKAAN = false)
	{
	}

	private void FDINBKNBNEA(int BOFDONCCJKI, bool NNBEAJCKAAN = false)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterStopGame()
	{
	}

	[PBOMGCLBFHF]
	public void RpcOnChangeSceneWithAutoFollowRequest(string KEKEFNPGBFN, SessionManager.PFPFLMJDKIB KHIJCFMFKHI, bool JDMCCJPEFCK, string OCLDAGFLIEO)
	{
	}

	public void SendPlayerChangeSceneWithAutoFollowRequestV2(CHILKDJABBF EKOFNPFCLMO, string BPFFKFHNHFA, DBECJLAIPEL CFBNOKOADFB, SessionManager.PFPFLMJDKIB KHIJCFMFKHI, bool JDMCCJPEFCK, string OCLDAGFLIEO = "")
	{
	}

	public void SendPlayerChangeSceneWithAutoFollowRequest(CHILKDJABBF EKOFNPFCLMO, string KEKEFNPGBFN, DBECJLAIPEL CFBNOKOADFB, SessionManager.PFPFLMJDKIB KHIJCFMFKHI, bool JDMCCJPEFCK)
	{
	}

	private bool OMEOGFPLKOJ(DBECJLAIPEL GLLFHCCFIGK)
	{
		return false;
	}

	[PBOMGCLBFHF]
	public void RpcMasterSetMode(int ECDCMDHEGCC)
	{
	}

	private void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void FDIGEENFFHL()
	{
	}

	private void APFMDIKEAML()
	{
	}

	private void DDHGFGMABHG()
	{
	}

	private void OnMasterClientSwitched(CHILKDJABBF GKNDJIKLPKK)
	{
	}

	private void BHIGJFDFGNF()
	{
	}

	private void POGOFGFCLBG()
	{
	}

	private void OIPGPJFHGCI(CHILKDJABBF LBJMGPLGCEB)
	{
	}

	private Task CDDPDMKAEJF(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	Task OJIHDJHLFFI.DeserializeFrom(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CDDPDMKAEJF
		return this.CDDPDMKAEJF(KGMPBFBAMCF, NDKAKDJMDIF);
	}

	private void OGPCDHDIGCI(AHDBIFJNDCH ADCFFAJGNAM)
	{
	}

	private bool FGAMJHLKIPK(AHDBIFJNDCH PCPEJHIMHJJ)
	{
		return false;
	}

	private bool OGCIILNJOJE(IPLNKMKGEFN KJAPODOABPN, FBLAHKFEHNM KGBADLHAHBP, OPKEAIOICLJ BEPGNCCJABH, KHMOHFAFGBI DJKFANFAIFI)
	{
		return false;
	}

	private void PEMFPEGCDBN(ref KHMOHFAFGBI KGMPBFBAMCF)
	{
	}

	void OJIHDJHLFFI.SerializeTo(ref KHMOHFAFGBI KGMPBFBAMCF)
	{
		//ILSpy generated this explicit interface implementation from .override directive in PEMFPEGCDBN
		this.PEMFPEGCDBN(ref KGMPBFBAMCF);
	}

	private void GNFDFLBKDPM()
	{
	}

	private BCDAPDDMMEO MCBPGMGBHKI(JDCIJIEOFOL FBCDJHOIDJJ)
	{
		return null;
	}

	public Task<(bool, string, int, int)> SendMultipleChoicePrompt(CHILKDJABBF FIKKFDJOIGD, string JLJJONAKDLL, string OACGBBKDLLM, string[] LLHKNIGMDOL)
	{
		return null;
	}

	[PBOMGCLBFHF]
	public void RpcSendMultipleChoicePrompt(int AMMLAHNGBBA, int AMGNCPLIAAC, string JLJJONAKDLL, string OACGBBKDLLM, string[] LLHKNIGMDOL)
	{
	}

	[PBOMGCLBFHF]
	private void RpcSendMultipleChoicePromptEvent(int AMMLAHNGBBA, int AMGNCPLIAAC, bool EGJEBAFNALL, string MLDANHIGANI, int BAPBHGEKECJ, int ACJOLLEBOJP)
	{
	}

	public void DestroyMultipleChoicePrompt(Player EKOFNPFCLMO)
	{
	}

	[PBOMGCLBFHF]
	private void RpcDestroyMultipleChoicePrompt(Player EKOFNPFCLMO)
	{
	}

	[CompilerGenerated]
	private void FHPBPPOIJIP(HGKINAOMNIF GOJCEBCMFJK)
	{
	}

	[CompilerGenerated]
	private void EJPGHAOEEJB()
	{
	}

	[CompilerGenerated]
	private void GFIGPBMDHMM(Matchmaking.DABKEMNEPLM CDNLFEOBNKB)
	{
	}

	[CompilerGenerated]
	private bool AFLDBOCFMMG()
	{
		return false;
	}
}
