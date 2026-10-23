using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom;
using RecRoom.Core;
using UnityEngine;

[Serializable]
public sealed class GameSpawnManager : MonoBehaviourPun, KEAFLIHKNBO
{
	public delegate void JPNOAJIJPGA(SpawnableTool GJNAFANFDIH);

	private struct EJNLCNOMEBN
	{
		public GameSpawnPoint KPNIOFFMODI;

		public float PJHFHPNBPOF;
	}

	[Serializable]
	private struct SpawnPointTagMetadata
	{
		public OEKMAGELALF TagType;

		public string Name;
	}

	[NonSerialized]
	public bool SpawnToolRestrictedByTeam;

	[NonSerialized]
	public GIBEGHKMCIE SpawnToolSupportedTeam;

	[NonSerialized]
	public bool SpawnToolRestrictedByTeamPlayerIndex;

	[NonSerialized]
	public POEOMLLLCAI SpawnToolSupportedTeamPlayerIndex;

	private int currentVisTestGameplaySPIndex;

	private const int MAX_SPAWN_POINT_VISIBILITY_TESTS_PER_FRAME = 1;

	private static readonly string TAG_INSTANTIATION_ID;

	private static readonly string SUPPRESS_CLEANUP_TOOL_INSTANTIATION_ID;

	private static readonly string SUPPRESS_ANIMATE_IN_PARTICLES_TOOL_INSTANTIATION_ID;

	private static readonly string IGNORE_DYNAMIC_COLLISIONS_TOOL_INSTANTIATION_ID;

	private static readonly string SUPPRESS_SKINS_TOOL_INSTANTIATION_ID;

	[CompilerGenerated]
	private JPNOAJIJPGA SpawnedEquipmentInstantiatedEvent;

	[CompilerGenerated]
	private JPNOAJIJPGA SpawnedEquipmentDestroyedEvent;

	private List<GameSpawnPoint> prePostGameSceneSpawnPoints;

	private List<GameSpawnPoint> playingGameSceneSpawnPoints;

	private List<GameSpawnPoint> prePostGameSandboxSpawnPoints;

	private List<GameSpawnPoint> playingGameSandboxSpawnPoints;

	private List<GiftBoxSpawnPoint> giftBoxSpawnPoints;

	private List<EJNLCNOMEBN> teammateProximitySpawnPointScores;

	private List<GameSpawnPoint> spawnPointsRequirementFiltered;

	private List<GameSpawnPoint> spawnPointsOverlapFiltered;

	private List<GameSpawnPoint> spawnPointFilteringScratchSpace;

	private List<GiftBoxSpawnPoint> filteredGiftBoxSpawnPoints;

	private SpawnPoint localPlayerCheckpointSpawnPoint;

	private NDGANCIJLGB leftHandRequestedSpawnParameters;

	private NDGANCIJLGB rightHandRequestedSpawnParameters;

	private int[] requestedEquipSlotSpawnIds;

	private NDGANCIJLGB[] requestedEquipSlotSpawnParameters;

	private bool requestedSpawnEquipmentSuppressCleanup;

	public static global::HHOBPMOCKMJ<CHILKDJABBF> MasterOnlyPlayerRespawnEvent;

	public static EEANDDJEMJC RespawnPlayerFailed;

	private global::AFHOAHNAMGF<LNJAPFIKKCO> _spawnPointSelectionMethodMap;

	private global::AFHOAHNAMGF<ProximityScoreSettings> _teammateProximityScoreSettingsMap;

	private global::AFHOAHNAMGF<ProximityScoreSettings> _opponentProximityScoreSettingsMap;

	private global::AFHOAHNAMGF<JBGFOIKBKED> _mainHandSpawnEquipmentTypeMap;

	private global::AFHOAHNAMGF<JBGFOIKBKED> _offHandSpawnEquipmentTypeMap;

	private global::AFHOAHNAMGF<IReadOnlyList<JBGFOIKBKED>> _toolTypesToNotDestroyWhenReset;

	private global::AFHOAHNAMGF<OEKMAGELALF> _localPlayerSpawnPointTagMap;

	private bool IsGameRunning => false;

	public List<GiftBoxSpawnPoint> GiftBoxSpawnPoints => null;

	public List<GameSpawnPoint> GameSandboxSpawnPoints => null;

	public LNJAPFIKKCO SpawnPointSelectionMethod => LNJAPFIKKCO.LEAST_RECENTLY_USED;

	public ProximityScoreSettings TeammateProximityScoreSettings => default;

	public ProximityScoreSettings OpponentProximityScoreSettings => default;

	public JBGFOIKBKED MainHandSpawnEquipmentType => JBGFOIKBKED.AC_UNIT;

	public JBGFOIKBKED OffHandSpawnEquipmentType => JBGFOIKBKED.AC_UNIT;

	public IReadOnlyList<JBGFOIKBKED> ToolTypesToNotDestroyWhenReset => null;

	public OEKMAGELALF LocalPlayerSpawnPointTag => OEKMAGELALF.TAG_1;

public event JPNOAJIJPGA BBDFAKIIEIP {
add {
	}
remove {
	}
}

public event JPNOAJIJPGA NJNCIMAAAAD {
add {
	}
remove {
	}
}

	public void AddSpawnPointSelectionMethod(LNJAPFIKKCO PNMOPCJFNHG, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveSpawnPointSelectionMethod(object IALNODEHBNN)
	{
	}

	public void AddTeammateProximityScoreSettings(ProximityScoreSettings CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveTeammateProximityScoreSettings(object IALNODEHBNN)
	{
	}

	public void AddOpponentProximityScoreSettings(ProximityScoreSettings CAOIPCMMNMJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveOpponentProximityScoreSettings(object IALNODEHBNN)
	{
	}

	public void AddMainHandSpawnEquipmentType(JBGFOIKBKED CKEPLIBLBFJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveMainHandSpawnEquipmentType(object IALNODEHBNN)
	{
	}

	public void AddOffHandSpawnEquipmentType(JBGFOIKBKED CKEPLIBLBFJ, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveOffHandSpawnEquipmentType(object IALNODEHBNN)
	{
	}

	public void AddToolTypesToNotDestroyWhenReset(IReadOnlyList<JBGFOIKBKED> BFAKBIJCJAF, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveToolTypesToNotDestroyWhenReset(object IALNODEHBNN)
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

	private void OBIPPONHEPI()
	{
	}

	public void InitializeLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void ResetLocalPlayer(bool BIJHPJHGOEF)
	{
	}

	public void AddLocalPlayerSpawnPointTag(OEKMAGELALF AHNIMJDLOPB, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void RemoveLocalPlayerSpawnPointTag(object IALNODEHBNN)
	{
	}

	public bool HasSpawnPointForTeam(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return false;
	}

	public void SetLocalPlayerCheckpointSpawnPoint(SpawnPoint ELGLOEDDKAJ)
	{
	}

	public SpawnPoint GetLocalPlayerCheckpointSpawnPoint()
	{
		return null;
	}

	private void LMDHILPFCND(OverlapVolume KBAMDKNOBOG)
	{
	}

	public void LocalPlayerRequestInstantiateToolsOnRespawn(Tool LKOEMJLHLPA, Tool IPJNOCPOPFF, int[] CBCHJMCEHOH, Tool[] FHAENFIMKBB, bool ODOJIMNCNGK)
	{
	}

	private void MECMMFJMDLG(Tool IEGMBEPJMGC, ref NDGANCIJLGB EKMNHHPJPHC)
	{
	}

	private void AODHNKLEJAA(Tool IEGMBEPJMGC, ref NDGANCIJLGB EKMNHHPJPHC)
	{
	}

	public void LocalPlayerRequestRespawnAtPoint(SandboxCircuitSpawnPoint PNOHMODPNCF, bool CDEPAJILBJA = true, bool MIHGKCBLLFJ = false)
	{
	}

	private Tool FKHBFHBMEEA(CHILKDJABBF EKOFNPFCLMO, string AHNIMJDLOPB, bool IHOMPANMPCH)
	{
		return null;
	}

	public void LocalPlayerRequestRespawn(bool CDEPAJILBJA = true, bool MIHGKCBLLFJ = false)
	{
	}

	public void MasterRespawnPlayerAtPoint(CHILKDJABBF EKOFNPFCLMO, SpawnPoint ELGLOEDDKAJ, bool CDEPAJILBJA, bool IKNMCCFKADN, NDGANCIJLGB EBKOENHFJIN, NDGANCIJLGB ENEFBFFMJHF, int[] MFPDBILNCAO, NDGANCIJLGB[] JPCHPAOOJAH, bool LDEDLOJMIPC, bool MIHGKCBLLFJ)
	{
	}

	public void MasterRespawnPlayer(CHILKDJABBF EKOFNPFCLMO, OEKMAGELALF AHNIMJDLOPB, bool HNIDKEJNEKJ, bool CDEPAJILBJA, bool IKNMCCFKADN, NDGANCIJLGB EBKOENHFJIN, NDGANCIJLGB ENEFBFFMJHF, int[] MFPDBILNCAO, NDGANCIJLGB[] JPCHPAOOJAH, bool LDEDLOJMIPC, bool MIHGKCBLLFJ)
	{
	}

	private Tool AOKPEMHEMOB(CHILKDJABBF EKOFNPFCLMO, bool LPHAJEBKFGI, SandboxCircuitSpawnPoint CCFNIPIGNAD, JBGFOIKBKED LOPDLILFCHK, int GLBHBIFDGKG, int MIJAOJLPGMF, bool LDEDLOJMIPC, Transform HJGAOBEOAGE)
	{
		return null;
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestPlayerRespawnAtPoint(int PCKCPNGPNBJ, PhotonView CNELOJFALGF, bool CDEPAJILBJA, bool IKNMCCFKADN, NDGANCIJLGB EBKOENHFJIN, NDGANCIJLGB ENEFBFFMJHF, int[] MFPDBILNCAO, NDGANCIJLGB[] JPCHPAOOJAH, bool CLGHLDEIPGA, bool MIHGKCBLLFJ)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestPlayerRespawn(int PCKCPNGPNBJ, int LDLKBLAHGMN, bool HNIDKEJNEKJ, bool CDEPAJILBJA, bool IKNMCCFKADN, NDGANCIJLGB EBKOENHFJIN, NDGANCIJLGB ENEFBFFMJHF, int[] MFPDBILNCAO, NDGANCIJLGB[] JPCHPAOOJAH, bool CLGHLDEIPGA, bool MIHGKCBLLFJ)
	{
	}

	[PBOMGCLBFHF]
	public void RpcRespawnPlayer(Vector3 FCNGMPHKHAE, Quaternion EIKMPMAOMIA, PhotonView IGDDAMGFGCC, SeatManagement MNHPICBOKAC, bool CDEPAJILBJA, Tool LKOEMJLHLPA, string JDKGLCNMDIB, Tool IPJNOCPOPFF, string EMAILLAEEAB, int[] CBCHJMCEHOH, Tool[] FHAENFIMKBB, string[] IOIHLNGMHEN, bool MIHGKCBLLFJ)
	{
	}

	[PBOMGCLBFHF]
	public void RpcRespawnPlayerFailed()
	{
	}

	public GiftBoxSpawnPoint GetGiftBoxSpawnPoint(CHILKDJABBF EKOFNPFCLMO)
	{
		return null;
	}

	private void HNHKBAKBDGK(List<GiftBoxSpawnPoint> KBNDKHJAECM, GIBEGHKMCIE NKKPJJNHMGK, POEOMLLLCAI KJKBHBGBFGK, GameScoreManager.GMGDNPOHAPK BCLMOLMFNFP, List<GiftBoxSpawnPoint> ACHFIOANLOG)
	{
	}

	public JBGFOIKBKED GetSpawnEquipmentTypeForHand(bool CKPKEOCIJPE)
	{
		return JBGFOIKBKED.AC_UNIT;
	}

	public Tool MasterSpawnEquipment(JBGFOIKBKED CKAPBBGHJEC, Vector3 FCNGMPHKHAE, Quaternion EIKMPMAOMIA, float LGPIDIPODLD, int AHNIMJDLOPB = -1, bool GKFEOGOHEHC = false, bool OHLGGMNKCDP = false, bool CAJKBGJAIJN = false, bool CBMHBLIDCPM = false, Dictionary<string, object> KBEDDPHHODO = null)
	{
		return null;
	}

	public Tool MasterSpawnTool(string IDAIMHJIGBA, Vector3 FCNGMPHKHAE, Quaternion EIKMPMAOMIA, float LGPIDIPODLD, int AHNIMJDLOPB = -1, bool GKFEOGOHEHC = false, bool OHLGGMNKCDP = false, bool CAJKBGJAIJN = false, bool CBMHBLIDCPM = false, Dictionary<string, object> KBEDDPHHODO = null)
	{
		return null;
	}

	public Tool AuthoritySpawnEquipment(JBGFOIKBKED CKAPBBGHJEC, Vector3 FCNGMPHKHAE, Quaternion EIKMPMAOMIA, float LGPIDIPODLD, int AHNIMJDLOPB = -1, bool GKFEOGOHEHC = false, bool OHLGGMNKCDP = false, bool CAJKBGJAIJN = false, bool CBMHBLIDCPM = false)
	{
		return null;
	}

	private Dictionary<string, object> JDFEOKMOCJO(int AHNIMJDLOPB, bool GKFEOGOHEHC, bool OHLGGMNKCDP, bool CAJKBGJAIJN, bool CBMHBLIDCPM, bool IBOIFMEPHOC = false)
	{
		return null;
	}

	private Tool ODICABBFNMA(CHILKDJABBF EKOFNPFCLMO, JBGFOIKBKED JMHDLPKKPHC, Vector3 FCNGMPHKHAE, Quaternion EIKMPMAOMIA, float LGPIDIPODLD, bool CAJKBGJAIJN)
	{
		return null;
	}

	private void DPNPCEFCGJL(Tool IEGMBEPJMGC)
	{
	}

	private void BNFOLHIIKFM(Tool IEGMBEPJMGC)
	{
	}

	public void OnSpawnedToolReset(Tool IEGMBEPJMGC, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}

	private void NILADDIDPNI(Tool IEGMBEPJMGC)
	{
	}

	private void GFDONLAJKDJ(RigidbodyEx FNBMGBEMKPE)
	{
	}

	private void CEBGBOFPOPL(Tool IEGMBEPJMGC)
	{
	}

	private void BKMFLEOIPPC(Tool IEGMBEPJMGC)
	{
	}

	public void AddGiftSpawnPoints(GiftBoxSpawnPoint[] GFJLCINKHEE)
	{
	}

	public void RemoveGiftSpawnPoints(GiftBoxSpawnPoint[] GFJLCINKHEE)
	{
	}

	public void AddSceneSpawnPoint(GameSpawnPoint ELGLOEDDKAJ)
	{
	}

	public void RemoveSceneSpawnPoint(GameSpawnPoint ELGLOEDDKAJ)
	{
	}

	public void AddSceneSpawnPoints(GameSpawnPoint[] BEKAAFMPMNI)
	{
	}

	public void RemoveSceneSpawnPoints(GameSpawnPoint[] BEKAAFMPMNI)
	{
	}

	public void AddSandboxSpawnPoints(params SandboxCircuitSpawnPoint[] DIKEHOGKHGD)
	{
	}

	public void RemoveSandboxSpawnPoints(params SandboxCircuitSpawnPoint[] DIKEHOGKHGD)
	{
	}

	private void KFEIKMFPICE(CHILKDJABBF EKOFNPFCLMO, out NJOGGCOMCJG EPKBGOLBHIO, out GIBEGHKMCIE KKALGIAOAEI, out POEOMLLLCAI HFAGEINIALG, out bool LJDBDNBHHAF)
	{
		EPKBGOLBHIO = default;
		KKALGIAOAEI = default;
		HFAGEINIALG = default;
		LJDBDNBHHAF = default;
	}

	private SpawnPoint NODCEFJKALN(CHILKDJABBF EKOFNPFCLMO, OEKMAGELALF LNDJJLGGNDM, bool HNIDKEJNEKJ)
	{
		return null;
	}

	private void JPHMMPIIEIO(IReadOnlyList<GameSpawnPoint> KBNDKHJAECM, GIBEGHKMCIE JIJFKEHEPGK, POEOMLLLCAI KJKBHBGBFGK, OEKMAGELALF OHKDBFONPNF, bool HNIDKEJNEKJ, bool LJDBDNBHHAF, NJOGGCOMCJG IDAHDMLGHJO, List<GameSpawnPoint> ACHFIOANLOG)
	{
	}

	private void BIGCFPJCIBL(List<GameSpawnPoint> KBNDKHJAECM, List<GameSpawnPoint> ACHFIOANLOG)
	{
	}

	private IReadOnlyList<GameSpawnPoint> EIFODPMFBOA()
	{
		return null;
	}

	private IReadOnlyList<GameSpawnPoint> HPANNKFHCHI()
	{
		return null;
	}

	private IReadOnlyList<GameSpawnPoint> LJLDMPENGGN()
	{
		return null;
	}

	private SpawnPoint GOBCNKFCEJC(List<GameSpawnPoint> BEKAAFMPMNI)
	{
		return null;
	}

	private SpawnPoint PPPHBELHFHD(List<GameSpawnPoint> BEKAAFMPMNI)
	{
		return null;
	}

	private CHILKDJABBF[] JLGGEPBCFJB(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private CHILKDJABBF[] BKGPDNCELBF(GIBEGHKMCIE NEBNOBLPNEP)
	{
		return null;
	}

	private SpawnPoint ODLPLINLDNF(GIBEGHKMCIE ENJKFCDELPE, List<GameSpawnPoint> BEKAAFMPMNI)
	{
		return null;
	}

	private float KEFEBDPFKOJ(List<Vector3> PEIKADHFBKL, List<Vector3> AOMBGJOMCKD, GameSpawnPoint ELGLOEDDKAJ)
	{
		return 0f;
	}

	private List<GIBEGHKMCIE> IPOAONFGOGO(IEnumerable<CHILKDJABBF> KNGJDELLJHD, bool KBLDGABCIMD = true)
	{
		return null;
	}

	private List<Vector3> DOKCADOOKML(IEnumerable<CHILKDJABBF> KNGJDELLJHD)
	{
		return null;
	}

	public float GetSpawnPointProximityScoreHelper(GameSpawnPoint ELGLOEDDKAJ, List<Vector3> IMEJEOKPGKL, ProximityScoreSettings BDPCABNIGOO)
	{
		return 0f;
	}

	public float GetSpawnPointProximityScoreForPosition(GameSpawnPoint ELGLOEDDKAJ, Vector3 KDPAIIJHIJF, ProximityScoreSettings BDPCABNIGOO)
	{
		return 0f;
	}

	private SpawnPoint LNDLCFGGIPC(GIBEGHKMCIE ENJKFCDELPE, List<GameSpawnPoint> BEKAAFMPMNI)
	{
		return null;
	}

	private void CJCFFFDJAFN()
	{
	}

	private void APLMCACFMMB()
	{
	}
}
