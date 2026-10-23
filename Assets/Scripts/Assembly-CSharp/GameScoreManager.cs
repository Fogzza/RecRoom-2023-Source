using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;

[Serializable]
public class GameScoreManager : MonoBehaviourPun, KEAFLIHKNBO
{
	public enum ELDAKJLJBKB
	{
		Invalid = -1,
		S = 0,
		A = 1,
		B = 2,
		C = 3,
		SS = 4,
		D = 5
	}

	public enum GMGDNPOHAPK
	{
		ANY = -1,
		FIRST_PLACE = 0,
		SECOND_PLACE = 1,
		THIRD_PLACE = 2,
		FOURTH_PLACE = 3,
		FIFTH_PLACE = 4,
		SIXTH_PLACE = 5,
		SEVENTH_PLACE = 6,
		EIGHTH_PLACE = 7,
		NINTH_PLACE = 8,
		TENTH_PLACE = 9,
		ELEVENTH_PLACE = 10,
		TWELFTH_PLACE = 11
	}

	private const string DEFAULT_STAT_NAME = "Invalid Stat";

	[CompilerGenerated]
	private Action<bool> StatsChangeEvent;

	private global::AFHOAHNAMGF<string> _scoreNameMap;

	private global::AFHOAHNAMGF<BFPALKJDPLP> _visibleScoreStatTypeMap;

	private global::AFHOAHNAMGF<int> _maxScoreDisplayMap;

	private List<StatConfiguration> _statDefinitions;

	private global::AFHOAHNAMGF<string> _customRankNameMap;

	private global::AFHOAHNAMGF<IIGLDDDANPN> _alternateGiftContextMap;

	private List<RankBucket> _rankBucketDefinitions;

	private List<RankGiftContext> _rankGiftContextDefinitions;

	protected global::JPEBBAFCBEP<int[], int[]> _teamScores;

	private Dictionary<int, global::JPEBBAFCBEP<int[], float[]>> playerStats;

	public bool ShowScore => false;

	public string ScoreName => null;

	public BFPALKJDPLP VisibleScoreStatType => BFPALKJDPLP.STAT_1;

	public int MaxScoreToDisplay => 0;

	public int StatCount => 0;

	public int RankBucketCount => 0;

	public int RankGiftContextCount => 0;

	public IIGLDDDANPN AlternateGiftContext => IIGLDDDANPN.Default;

	protected int[] TeamScores
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected int[] PreviousTeamScores => null;

public event Action<bool> IBDOILMFOKK {
add {
	}
remove {
	}
}

	protected void ILMDBCKBJOK()
	{
	}

	protected void MIHGBABJKMN()
	{
	}

	public void AddScoreName(string KNOPFGAGMCN, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveScoreName(object IALNODEHBNN)
	{
	}

	public void AddVisibleScoreStatType(BFPALKJDPLP IPCGHAJNGNK, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveVisibleScoreStatType(object IALNODEHBNN)
	{
	}

	public void AddMaxScoreToDisplay(int HLCCIFEKLLB, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveMaxScoreToDisplay(object IALNODEHBNN)
	{
	}

	public BFPALKJDPLP GetStatTypeFromIndex(int GMEHLIHLGEH)
	{
		return BFPALKJDPLP.STAT_1;
	}

	public string GetStatNameByIndex(int GMEHLIHLGEH)
	{
		return null;
	}

	public void SetStatNameByIndex(int GMEHLIHLGEH, string KNOPFGAGMCN)
	{
	}

	public bool GetStatVisibleInUIByIndex(int GMEHLIHLGEH)
	{
		return false;
	}

	public bool GetStatVisibleInHUDByIndex(int GMEHLIHLGEH)
	{
		return false;
	}

	public LNJJFAPMBNM GetStatFormatByIndex(int GMEHLIHLGEH)
	{
		return LNJJFAPMBNM.INT;
	}

	public void ClearStatDefinitions()
	{
	}

	public void AddStatDefinition(StatConfiguration JJENEBICNGD)
	{
	}

	public bool TryGetRankBucketByIndex(int GMEHLIHLGEH, out RankBucket BDFOOBKCCEF)
	{
		BDFOOBKCCEF = default;
		return false;
	}

	public bool TryGetRankGiftContextByIndex(int GMEHLIHLGEH, out RankGiftContext NLDFHOPLCAL)
	{
		NLDFHOPLCAL = default;
		return false;
	}

	public bool TryGetCustomRankName(out string KHFFGDMJLMP)
	{
		KHFFGDMJLMP = null;
		return false;
	}

	public void ClearRankBucketDefinitions()
	{
	}

	public void AddRankBucketDefinition(RankBucket BDFOOBKCCEF)
	{
	}

	public void ClearRankGiftContextDefinitions()
	{
	}

	public void AddRankGiftContextDefinition(RankGiftContext NLDFHOPLCAL)
	{
	}

	public void AddCustomRankName(string KHFFGDMJLMP, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveCustomRankName(object IALNODEHBNN)
	{
	}

	public void AddAlternateGiftContext(IIGLDDDANPN PEHPBOANIIP, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveAlternateGiftContext(object IALNODEHBNN)
	{
	}

	protected override void Awake()
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

	public int GetScore(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	public int GetPreviousScore(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	public int GetVisibleScore(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return 0;
	}

	public void MasterAddScore(GIBEGHKMCIE NEBNOBLPNEP, int JMKKOEIAEGH, int HLCCIFEKLLB)
	{
	}

	public void MasterAddScore(GIBEGHKMCIE NEBNOBLPNEP, int JMKKOEIAEGH)
	{
	}

	public void MasterSetScore(GIBEGHKMCIE NEBNOBLPNEP, int JOPOKBJLGOE)
	{
	}

	public void GetHighestScore(out GIBEGHKMCIE AIFPIAAEFMJ, out int ANPGPKECMML, bool NBLMAPAIFJP = false)
	{
		AIFPIAAEFMJ = default;
		ANPGPKECMML = default;
	}

	public void GetLowestScore(out GIBEGHKMCIE AIFPIAAEFMJ, out int ANPGPKECMML, bool NBLMAPAIFJP = false)
	{
		AIFPIAAEFMJ = default;
		ANPGPKECMML = default;
	}

	public void AddScore(GIBEGHKMCIE NEBNOBLPNEP, int JMKKOEIAEGH)
	{
	}

	public void MasterResetAllScores()
	{
	}

	public bool HasRanks()
	{
		return false;
	}

	public ELDAKJLJBKB GetTeamRank(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return ELDAKJLJBKB.S;
	}

	public IIGLDDDANPN GetRankGiftContext(ELDAKJLJBKB JLJKPNCDEIN)
	{
		return IIGLDDDANPN.Default;
	}

	public IIGLDDDANPN GetAlternateGiftContext()
	{
		return IIGLDDDANPN.Default;
	}

	public IIGLDDDANPN GetRankGiftContext(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return IIGLDDDANPN.Default;
	}

	public GMGDNPOHAPK GetTeamPlace(GIBEGHKMCIE NEBNOBLPNEP, bool NBLMAPAIFJP = false)
	{
		return GMGDNPOHAPK.FIRST_PLACE;
	}

	private global::JPEBBAFCBEP<int[], float[]> DIFGBKKGEMP(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	public bool TryGetPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, out int IPMIIEAGJKC, out float DBADKICDKCN)
	{
		IPMIIEAGJKC = default;
		DBADKICDKCN = default;
		return false;
	}

	public bool TryGetPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, out int IPMIIEAGJKC)
	{
		IPMIIEAGJKC = default;
		return false;
	}

	public bool TryGetPlayerStatLastChangeTime(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, out float CMDCIKCGIDN)
	{
		CMDCIKCGIDN = default;
		return false;
	}

	public void MasterAddPlayerStatForAllActivePlayers(BFPALKJDPLP CHJCAECALGD, int EKKPHELNKNJ)
	{
	}

	public void AddPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, int EKKPHELNKNJ)
	{
	}

	public void SetPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, int IPMIIEAGJKC)
	{
	}

	public void ClearPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD)
	{
	}

	public void MasterAddPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, int EKKPHELNKNJ, bool NEHEEBNPMDA = true)
	{
	}

	public void MasterSetPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, int IPMIIEAGJKC)
	{
	}

	public void ResetAllLocalPlayerStats()
	{
	}

	private int CEPKBBIEKCK(BFPALKJDPLP IPCGHAJNGNK)
	{
		return 0;
	}

	[PBOMGCLBFHF]
	public void RpcMasterAddScore(GIBEGHKMCIE BFEKAAHGNLH, int JMKKOEIAEGH)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterAddPlayerStat(CHILKDJABBF EKOFNPFCLMO, BFPALKJDPLP CHJCAECALGD, int EKKPHELNKNJ)
	{
	}
}
