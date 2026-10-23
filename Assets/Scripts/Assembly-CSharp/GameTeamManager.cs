using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

[Serializable]
public class GameTeamManager : MonoBehaviourPun, KEAFLIHKNBO
{
	public delegate void GOONDLEPALO(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE);

	protected class AJLNMALHOIB
	{
		private GOONDLEPALO NAPGKPHBMFN__BackingField;

		private CHILKDJABBF BDJDBNPCCOK;

		private global::JPEBBAFCBEP<GIBEGHKMCIE, POEOMLLLCAI> NKEBJOHFPKJ;

public GIBEGHKMCIE DAOGEGBNKLC
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
		}

}

public POEOMLLLCAI GFFMJINLPGE
{
get 		{
			return POEOMLLLCAI.INDEX_0;
		}

}

public event GOONDLEPALO NAPGKPHBMFN {
add {
		}
remove {
		}
}

		public AJLNMALHOIB(MonoBehaviourPun DELCOFCGDFF, CHILKDJABBF EKOFNPFCLMO)
		{
		}

		public void LOOCPCHDKMI(GIBEGHKMCIE NEBNOBLPNEP, POEOMLLLCAI AFGPGEKAMJK)
		{
		}

		private void JODJNLJNEBC()
		{
		}
	}

	private sealed class ANPPNPJKIHL
	{
		public GIBEGHKMCIE team;

		internal bool _003CGetOtherTeams_003Eb__0(GIBEGHKMCIE t)
		{
			return false;
		}
	}

	private sealed class BIJOMAFJCGL
	{
		public GIBEGHKMCIE team;

		public GameTeamManager _003C_003E4__this;

		internal bool _003CGetOtherActiveTeams_003Eb__0(GIBEGHKMCIE t)
		{
			return false;
		}
	}

	private sealed class FHALNBGGAEP : IEnumerable<CHILKDJABBF>, IEnumerable, IEnumerator<CHILKDJABBF>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private CHILKDJABBF _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public GameTeamManager _003C_003E4__this;

		private IReadOnlyList<CHILKDJABBF> _003CplayerList_003E5__2;

		private int _003Ci_003E5__3;

 CHILKDJABBF global::System.Collections.Generic.IEnumerator<global::CHILKDJABBF>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CPhoton_002ERealtime_002EPlayer_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public FHALNBGGAEP(int _003C_003E1__state)
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
		private CHILKDJABBF System_002ECollections_002EGeneric_002EIEnumerator_003CPhoton_002ERealtime_002EPlayer_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<CHILKDJABBF> IEnumerable<CHILKDJABBF>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private sealed class IABHFOJNNFB : IEnumerable<CHILKDJABBF>, IEnumerable, IEnumerator<CHILKDJABBF>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private CHILKDJABBF _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public GameTeamManager _003C_003E4__this;

		private IReadOnlyList<CHILKDJABBF> _003CplayerList_003E5__2;

		private int _003Ci_003E5__3;

 CHILKDJABBF global::System.Collections.Generic.IEnumerator<global::CHILKDJABBF>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CPhoton_002ERealtime_002EPlayer_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public IABHFOJNNFB(int _003C_003E1__state)
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
		private CHILKDJABBF System_002ECollections_002EGeneric_002EIEnumerator_003CPhoton_002ERealtime_002EPlayer_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<CHILKDJABBF> IEnumerable<CHILKDJABBF>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private static readonly List<GIBEGHKMCIE> INSTANTANEOUS_TEAMS;

	private static readonly List<CHILKDJABBF> INSTANTANEOUS_PLAYERS;

	private static readonly List<POEOMLLLCAI> INSTANTANEOUS_PLAYER_INDICES;

	public static readonly int MAX_TEAM_COUNT;

	public static readonly int MAX_TEAM_SIZE;

	[SerializeField]
	private PlayerHighlightBeam beaconPrefab;

	private Transform beaconRoot;

	private List<PlayerHighlightBeam> beacons;

	private CHILKDJABBF[] squadmates;

	private bool hasCustomLevelColorSettings;

	private GameTeamColorSettings customLevelColorSettings;

	[CompilerGenerated]
	private GOONDLEPALO TeamChangeEvent;

	[CompilerGenerated]
	private Action LocalPlayerTeamChangeEvent;

	private global::AFHOAHNAMGF<GameStartRequirement> _manualGameStartRequirementMap;

	private FIHGBEHGLGB _automaticGameStartSupportFlag;

	private global::AFHOAHNAMGF<GameStartRequirement> _automaticGameStartRequirementMap;

	private FIHGBEHGLGB _joinInProgressSupportedFlag;

	private FIHGBEHGLGB _endGameIfStartRequirementsNotMetFlag;

	private List<int> _teamSizes;

	private global::AFHOAHNAMGF<KMNCAMFDLFN> _teamSelectionMethodMap;

	private FIHGBEHGLGB _explicitTeamSelectionSupportedFlag;

	private FIHGBEHGLGB _spectatingSupportFlag;

	private FIHGBEHGLGB _gameRunningTeamChangeSupportedFlag;

	private FIHGBEHGLGB _respawnOnGameRunningTeamChangeSupportedFlag;

	private FIHGBEHGLGB _clearTeamsAfterGameSupportedFlag;

	private FIHGBEHGLGB _teamRadioSupportedFlag;

	private FIHGBEHGLGB _teamRadioCrossteamSupportedFlag;

	private global::AFHOAHNAMGF<TeamRadioSettings> _teamRadioSettingsMap;

	private global::AFHOAHNAMGF<PlayerVisualSettings> _playerVisualSettingsMap;

	public static global::HHOBPMOCKMJ<PlayerVisualSettings> PlayerVisualSettingsUpdateEvent;

	private Dictionary<int, AJLNMALHOIB> allPlayerData;

	public GameStartRequirement ManualGameStartRequirement => default;

	public bool AutomaticGameStartSupported => false;

	public GameStartRequirement AutomaticGameStartRequirement => default;

	public bool JoinInProgressSupported => false;

	public bool EndGameIfStartRequirementsNotMetSupported => false;

	public int TeamCount => 0;

	public KMNCAMFDLFN TeamSelectionMethod => KMNCAMFDLFN.RANDOM;

	public bool ExplicitTeamSelectionSupported => false;

	public bool SpectatingSupported => false;

	public bool GameRunningTeamChangeSupported => false;

	public bool RespawnOnGameRunningTeamChangeSupported => false;

	public bool ClearTeamsAfterGameSupported => false;

	public bool TeamRadioSupported => false;

	private bool TeamRadioCrossteamSupported => false;

	public TeamRadioSettings TeamRadioSettings => default;

	public PlayerVisualSettings PlayerVisualSettings => default;

	public bool GameStartTeamRequirementsMet => false;

	public bool GameAutomaticStartTeamRequirementsMet => false;

public event GOONDLEPALO NAPGKPHBMFN {
add {
	}
remove {
	}
}

public event Action IMAPINFEFHL {
add {
	}
remove {
	}
}

	public void AddManualGameStartRequirement(GameStartRequirement CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveManualGameStartRequirement(object IALNODEHBNN)
	{
	}

	public void AddAutomaticGameStartRequirement(GameStartRequirement CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveAutomaticGameStartRequirement(object IALNODEHBNN)
	{
	}

	public void AddAutomaticGameStartSupport(object IALNODEHBNN)
	{
	}

	public void RemoveAutomaticGameStartSupport(object IALNODEHBNN)
	{
	}

	public void AddJoinInProgressSupport(object IALNODEHBNN)
	{
	}

	public void RemoveJoinInProgressSupport(object IALNODEHBNN)
	{
	}

	public void AddEndGameIfStartRequirementsNotMetSupport(object IALNODEHBNN)
	{
	}

	public void RemoveEndGameIfStartRequirementsNotMetSupport(object IALNODEHBNN)
	{
	}

	public int GetTeamSize(int GKMCHPDKBDG)
	{
		return 0;
	}

	public int GetTeamSize(GIBEGHKMCIE EHJCKKNLLEE)
	{
		return 0;
	}

	public void AddTeam(int CAPKFCHDLFA)
	{
	}

	public void ClearTeams()
	{
	}

	private int BFJLFLFJGPF(GIBEGHKMCIE IKHNIJKGJFD)
	{
		return 0;
	}

	private GIBEGHKMCIE BMFGFEDAKAE(int GMEHLIHLGEH)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	public void AddTeamSelectionMethod(KMNCAMFDLFN CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveTeamSelectionMethod(object IALNODEHBNN)
	{
	}

	public void AddExplicitTeamSelectionSupport(object IALNODEHBNN)
	{
	}

	public void RemoveExplicitTeamSelectionSupport(object IALNODEHBNN)
	{
	}

	public void AddSpectatingSupport(object IALNODEHBNN)
	{
	}

	public void RemoveSpectatingSupport(object IALNODEHBNN)
	{
	}

	public void AddGameRunningTeamChangeSupport(object IALNODEHBNN)
	{
	}

	public void RemoveGameRunningTeamChangeSupport(object IALNODEHBNN)
	{
	}

	public void AddRespawnOnGameRunningTeamChangeSupport(object IALNODEHBNN)
	{
	}

	public void RemoveRespawnOnGameRunningTeamChangeSupport(object IALNODEHBNN)
	{
	}

	public void AddClearTeamsAfterGameSupport(object IALNODEHBNN)
	{
	}

	public void RemoveClearTeamsAfterGameSupport(object IALNODEHBNN)
	{
	}

	public void AddTeamRadioSupport(object IALNODEHBNN)
	{
	}

	public void RemoveTeamRadioSupport(object IALNODEHBNN)
	{
	}

	public void AddTeamRadioSettings(TeamRadioSettings CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveTeamRadioSettings(object IALNODEHBNN)
	{
	}

	public void AddTeamRadioCrossteamSupported(object IALNODEHBNN)
	{
	}

	public void RemoveTeamRadioCrossteamSupported(object IALNODEHBNN)
	{
	}

	private void DIJCOPGGBJD()
	{
	}

	public void AddPlayerVisualSettings(PlayerVisualSettings CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemovePlayerVisualSettings(object IALNODEHBNN)
	{
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Update()
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

	public void OnPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void OnGameStart()
	{
	}

	public void OnGameEnd()
	{
	}

	public void OnUpdate()
	{
	}

	public void LeaveTeam(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void MasterClearTeams()
	{
	}

	protected AJLNMALHOIB ALANECENMJF(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	protected void MHGBPFABJBI(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
	{
	}

	protected void AGOFEKOJJNC(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
	{
	}

	public bool IsPlayerSpectator(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public GIBEGHKMCIE GetPlayerTeam(CHILKDJABBF EKOFNPFCLMO)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	public POEOMLLLCAI GetTeamPlayerIndex(CHILKDJABBF EKOFNPFCLMO)
	{
		return POEOMLLLCAI.INDEX_0;
	}

	public bool TryGetPlayerTeamAndIndex(CHILKDJABBF EKOFNPFCLMO, out GIBEGHKMCIE BFEKAAHGNLH, out POEOMLLLCAI AIDOLKNMHIA)
	{
		BFEKAAHGNLH = default;
		AIDOLKNMHIA = default;
		return false;
	}

	public CHILKDJABBF GetPlayerAtTeamPlayerIndex(GIBEGHKMCIE NEBNOBLPNEP, POEOMLLLCAI BCCPBAOFCBD)
	{
		return null;
	}

	public int GetTeamPlayerCount(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	public GIBEGHKMCIE GetAnotherTeam(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	public IEnumerable<GIBEGHKMCIE> GetOtherTeams(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	public IEnumerable<GIBEGHKMCIE> GetOtherActiveTeams(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	public IEnumerable<GIBEGHKMCIE> GetActiveTeams()
	{
		return null;
	}

	public int GetTeamVacancy(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	public int GetGameVacancy()
	{
		return 0;
	}

	public CHILKDJABBF GetAnyPlayerOnTeam(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	public CHILKDJABBF[] GetTeamPlayers(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	public CHILKDJABBF[] GetTeammatesOfPlayer(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	public CHILKDJABBF[] GetOpponentsOfPlayer(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	public CHILKDJABBF[] GetTeamPlayersSortedByIndex(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	public CHILKDJABBF[] GetOtherPlayers(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	public GIBEGHKMCIE GetFirstActiveTeam()
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	public int GetActiveTeamCount()
	{
		return 0;
	}

	public IEnumerable<CHILKDJABBF> GetSpectatingPlayers()
	{
		return null;
	}

	public int GetSpectatingPlayerCount()
	{
		return 0;
	}

	public IEnumerable<CHILKDJABBF> GetActivePlayers()
	{
		return null;
	}

	public int GetActivePlayerCount()
	{
		return 0;
	}

	public int GetActivePlayerVacancy()
	{
		return 0;
	}

	public bool PlayersAreTeammates(CHILKDJABBF BMFDMADJDLP, CHILKDJABBF MABCGNKHNAC)
	{
		return false;
	}

	public bool PlayerOnTeam(CHILKDJABBF BMFDMADJDLP, GIBEGHKMCIE NEBNOBLPNEP)
	{
		return false;
	}

	protected int ALLCNIHJKEM(GIBEGHKMCIE[] ODCIHIKEFOM)
	{
		return 0;
	}

	protected int ALLCNIHJKEM(GIBEGHKMCIE[] ODCIHIKEFOM, out GIBEGHKMCIE CJGFPICDPIK)
	{
		CJGFPICDPIK = default;
		return 0;
	}

	protected GIBEGHKMCIE NDEAHHLJHLF(CHILKDJABBF DCJFPELAJIH, string BLLFELOHJMF)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	protected void EPKEOBPBMDC(CHILKDJABBF EKOFNPFCLMO, GIBEGHKMCIE NEBNOBLPNEP)
	{
	}

	protected POEOMLLLCAI EDLOGEGHAJB(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return POEOMLLLCAI.INDEX_0;
	}

	private bool AOHDKDCGBHG(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private bool EDPJJNAIAAJ(GameStartRequirement IIEMLHPOFMM, int AGFBPCGAGDK, int MEPHBMCBPFP, int HOJHOBNIEOK)
	{
		return false;
	}

	public void InitializeLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void ResetLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public Color GetTeamColor(GIBEGHKMCIE NEBNOBLPNEP, bool HHBGHCNNHOF = false)
	{
		return default;
	}

	public void RequestNextTeam(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void RequestTeamChange(CHILKDJABBF EKOFNPFCLMO, GIBEGHKMCIE ICEDHPCLPDM)
	{
	}

	private void BMCGDKGFNCN(CHILKDJABBF EKOFNPFCLMO, GIBEGHKMCIE ICEDHPCLPDM, GIBEGHKMCIE DJPCFFBGIAP, bool KLIALECKONN)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestTeam(CHILKDJABBF EKOFNPFCLMO, GIBEGHKMCIE ICEDHPCLPDM, GIBEGHKMCIE DJPCFFBGIAP, bool KLIALECKONN)
	{
	}

	public int GetTeamMaxPlayerCount(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	public IEnumerable<GIBEGHKMCIE> GetAllTeams()
	{
		return null;
	}

	public int GetActivePlayersMaxCount()
	{
		return 0;
	}

	public bool PlayerCanSwitchTeam(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public bool PlayerCanLeaveGame(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	public bool TryGetActivePlayerCentroid(out Vector3 KCHAIAINPHG)
	{
		KCHAIAINPHG = default;
		return false;
	}

	public string GetTeamName(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private void JJAMMOHCJKA(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
	{
	}

	private void GHMOLJADOOP()
	{
	}

	public void MasterAssignTeam(CHILKDJABBF EKOFNPFCLMO, GIBEGHKMCIE ICEDHPCLPDM, GIBEGHKMCIE DJPCFFBGIAP, bool KLIALECKONN, bool HOPFMHOHGGD = true)
	{
	}

	private GIBEGHKMCIE KCNHDCHPEHP(CHILKDJABBF EKOFNPFCLMO, GIBEGHKMCIE DJPCFFBGIAP, bool KLIALECKONN)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	private GIBEGHKMCIE CJHLKFFNLCE(GIBEGHKMCIE DJPCFFBGIAP = GIBEGHKMCIE.ANY)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	private GIBEGHKMCIE MGIIONJLCEG(GIBEGHKMCIE DJPCFFBGIAP = GIBEGHKMCIE.ANY)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	private GIBEGHKMCIE MPLFHGLODAF(bool CNBODADLJML, GIBEGHKMCIE DJPCFFBGIAP)
	{
		return GIBEGHKMCIE.TEAM_1;
	}

	private void EHPHAAAFJJE(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void DMDHDGOKHEN()
	{
	}

	private PlayerHighlightBeam LFOCDFBGCAA()
	{
		return null;
	}

	private void GONKIFEKKLC(CHILKDJABBF FFDEPLCDBNA = null, bool OHDEKMCDIPE = false)
	{
	}

	private void FGKDDBIDLOF()
	{
	}

	private void CKPAECOEOLK()
	{
	}

	private void PHDBFCEEHJI(Player ANDCAFFMODA)
	{
	}

	protected void GEIAKCIBMDO(Player EKOFNPFCLMO)
	{
	}

	private void LNGHJHHGPNI()
	{
	}

	private void KKEJPKICMPO()
	{
	}

	private void BJPFOECEABP(Player KFGIFIOCHEP, GIBEGHKMCIE KKALGIAOAEI, Color BNLLLOGKPGN)
	{
	}

	private void MBNMFGAJOHI(Player KFGIFIOCHEP, GIBEGHKMCIE KKALGIAOAEI, Color BNLLLOGKPGN)
	{
	}

	[CompilerGenerated]
	private bool EJMFNBLKLBC(GIBEGHKMCIE IHPJCBCPLCM)
	{
		return false;
	}

	[CompilerGenerated]
	private int FHOGNMLNLCP(CHILKDJABBF NNMPJECKECI, CHILKDJABBF EFNJCAIBDLA)
	{
		return 0;
	}
}
