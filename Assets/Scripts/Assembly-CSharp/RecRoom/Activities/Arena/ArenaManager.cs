using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Activities.Arena
{
	public class ArenaManager : GameRuleManager
	{
		private enum ALHDPCGCJCA
		{
			ATTRITION_ROUND_RUNNING = 0,
			INVALID = 65535
		}

		private enum JLDJFHDJDJM
		{
			LOW_SCORE = 0,
			HIGH_SCORE = 1
		}

		private enum JCOMIECGABE
		{
			NONE = 0,
			EXPLORE = 1,
			COMBAT = 2,
			LAST_LAP = 3
		}

		private enum LNHMHEAIJJL
		{
			PLAYER_KILLS = 0,
			ENEMY_KILLS = 1,
			DEATHS = 2,
			REVIVES = 3,
			TOTAL_POINTS = 4
		}

		private class MOMHMHADDCG
		{
			private global::MOBDJNEDDKC<int> JHHEKIDHNGM;

			private Action HOEGECIMEJG__BackingField;

public int JLHLOJOEGOG
{
get 			{
				return 0;
			}

set {
			}
}

public event Action HOEGECIMEJG {
add {
			}
remove {
			}
}

			public MOMHMHADDCG(MonoBehaviourPun HBHGCCNPOIL, GIBEGHKMCIE NEBNOBLPNEP)
			{
			}

			private void DCACHIBDLGL()
			{
			}

			private static string FGPOMONIMHL(GIBEGHKMCIE NEBNOBLPNEP, string OIFCDJKHBEC)
			{
				return null;
			}
		}

		private class NPFHLOCAHPF
		{
			private global::MOBDJNEDDKC<int> JHHEKIDHNGM;

			private Action HOEGECIMEJG__BackingField;

public int JLHLOJOEGOG
{
get 			{
				return 0;
			}

set {
			}
}

public event Action HOEGECIMEJG {
add {
			}
remove {
			}
}

			public NPFHLOCAHPF(MonoBehaviourPun DELCOFCGDFF, CHILKDJABBF EKOFNPFCLMO)
			{
			}

			private void LJIINEECAPH()
			{
			}
		}

		[Serializable]
		private class AwardConfig
		{
			public int BaseCredits;

			public int BonusRangeStart;

			public int BonusRangeEnd;

			public int TotalPossible => 0;

			public int BHHIGKAKFKC(out int DCHNBMAPHLD, out int NHENLAFAINL, float HIGGNOICILA = 1f)
			{
				DCHNBMAPHLD = default;
				NHENLAFAINL = default;
				return 0;
			}
		}

		private ArenaEncounterSpawner HDOHENLLJEH;

		private ArenaVO KPFFILLHNNN;

		[SerializeField]
		private PlayerCombatUI playerCombatUIPrefab;

		[SerializeField]
		private EnemyCombatUI enemyCombatUIPrefab;

		[SerializeField]
		private SpawnableCollectible collectiblePrefab;

		[SerializeField]
		private int individualCollectibleCreditValue;

		[SerializeField]
		private float combatMusicMinPlayTime;

		[SerializeField]
		private float combatMusicFadeOutTime;

		[SerializeField]
		private RecRoomAudioClip playerDamagedSFX;

		[SerializeField]
		private RecRoomAudioClip playerDamagedCriticalHitSFX;

		[SerializeField]
		private RecRoomAudioClip playerKilledPlayerSFX;

		[SerializeField]
		private RecRoomAudioClip playerKilledPlayerCriticalHitSFX;

		[SerializeField]
		private RecRoomAudioClip lootSpentSFX;

		[SerializeField]
		private PooledParticle playerDamagedParticles;

		[SerializeField]
		private PooledParticle playerDamagedCriticalHitParticles;

		[SerializeField]
		private WorldSpaceNotification team1WorldSpaceNotificationPrefab;

		[SerializeField]
		private WorldSpaceNotification team2WorldSpaceNotificationPrefab;

		[SerializeField]
		private SerializedGuid[] dualWieldAllowedWeaponTypeIds;

		[NonSerialized]
		private JBGFOIKBKED[] ACPFMHGMEDH;

		[SerializeField]
		private int playerKillPoints;

		[SerializeField]
		private int playerFriendlyFireKillPoints;

		[SerializeField]
		private int normalEnemyKillPoints;

		[SerializeField]
		private int eliteEnemyKillPoints;

		[SerializeField]
		private int enemyFriendlyFirePoints;

		[SerializeField]
		private int lootChestPoints;

		[SerializeField]
		private int minLeadFeedbackPoints;

		[SerializeField]
		private int gameEndingSoonPointsRemaining;

		[SerializeField]
		private float gameEndingSoonTimeRemaining;

		private float MOFIELACCMO;

		private int GGCOGEBAAEL;

		private const float HABOHHDMBOK = 1.35f;

		private const float LPICDBJPLHO = 3f;

		private const float PHJAADOHKCH = 1.5f;

		private JOJOABLFOBA JOMILDGFALA;

		private HONEDBECDOK OCNFLCIFIBF;

		private KBJKDKFNFIA MODNIMBPCKM;

		private MDEJADHJOEJ MHPDDKBKEOJ;

		private List<ArenaEncounterSpawnPoint> HBGKPPCBGKN;

		private List<ArenaEncounterSpawnPoint> NHPPHAIPCHL;

		private List<ArenaVendingMachine> MDGCMODDMGC;

		private List<ArenaDoor> KOAEIKFFBGH;

		private List<ArenaEquipmentSpawner> CFJJKAHECAD;

		private float LIJPDOPLGGA;

		private bool IILOOCJGIOD;

		private GIBEGHKMCIE JBMNGECJMJL;

		private int MNHFAIFOBND;

		private int IBHHNMAMNDN;

		private List<int> MIHPJMIGNLH;

		private Dictionary<GIBEGHKMCIE, MOMHMHADDCG> AGKCKACOCIH;

		private Dictionary<int, NPFHLOCAHPF> INFAOKBLPCB;

public new static ArenaManager Instance
{
get 		{
			return null;
		}

}

public new static bool IsInitialized
{
get 		{
			return false;
		}

}

private JBGFOIKBKED[] PBLBHKKDNNI
{
get 		{
			return null;
		}

}

public float GameDuration
{
get 		{
			return 0f;
		}

set {
		}
}

public int ScoreToWin
{
get 		{
			return 0;
		}

set {
		}
}

public override string RuleTypeAutoTag
{
get 		{
			return null;
		}

}

public override bool AutoRunTimer
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected void JHECFGDENEP(bool BIJHPJHGOEF, bool CLOJHJPNBPD)
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void Update()
		{
		}

		protected override void HDJBEAFJEHD()
		{
		}

		protected override void ENHEJEADGCH()
		{
		}

		protected int DEHHHELEEJC(CHILKDJABBF FBCDJHOIDJJ)
		{
			return 0;
		}

		public override void RecordMatchAnalytics(bool DNKBEOHALFL)
		{
		}

		public override bool LocalPlayerHasGameActivity()
		{
			return false;
		}

		private void FEJEKDDPHPD(SpawnableTool CKAPBBGHJEC)
		{
		}

		private void OGIJDKEDADI()
		{
		}

		private void PHJLGFLICPA(RangedWeapon KBPKGKEMHED)
		{
		}

		private void PKHKHNLMJCF(Tool IEGMBEPJMGC)
		{
		}

		private void GDOHHAIEMJH(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void NIMAMFAOJFA(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void IDNKCHBLILP(Enemy NJDHAACHDKF, Enemy INIEKKNFPDP, Vector3 PDFEDMAOMNH)
		{
		}

		private void FCIFJACGMBD(CHILKDJABBF NJDHAACHDKF, Weapon ONFCNCHNBGL, Enemy INIEKKNFPDP, Vector3 PDFEDMAOMNH)
		{
		}

		private void CHCDCHFGLMM(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, GameCombatManager.INLLFPAMJHI KIJFHDKILAL, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void MLPDKFLLLCP(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void LAKANMNMIEE(CHILKDJABBF ANFAILCOAEI, bool IIBMFHGIANL, bool ICMKPBEHGCE, Vector3 OGEABPMOJJB, string IOHHCLKDJGL)
		{
		}

		private void NBDKCGOKFDC(CHILKDJABBF INIEKKNFPDP, CHILKDJABBF NJDHAACHDKF, bool ICMKPBEHGCE)
		{
		}

		private void KLDFJCCKNIA(CHILKDJABBF FAINKAJCOKC, bool ICMKPBEHGCE, string KGAMLFCPPDH)
		{
		}

		private void NKCCFCFBFBC()
		{
		}

		private void PHFNKHMBGAN(Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB)
		{
		}

		private void PBOPPGFOKCE(int DIFMOMFKPOF, string OEEBIOPLOMG, Vector3 ADJINPMOILO)
		{
		}

		private void IIKMLPCKOPP(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 INLGLHIPOMC)
		{
		}

		private void IHGLNDIFFNA()
		{
		}

		private void DKIMEJFGBNJ(int ELMBNOBHPEM)
		{
		}

		private void EEIJBACPEKP(int EGJKDPKELEG)
		{
		}

		private int OFNCGACBENP(CHILKDJABBF EKOFNPFCLMO)
		{
			return 0;
		}

		private void LLHMDOHCBGH(CHILKDJABBF EKOFNPFCLMO, int NANLOFGHCIM)
		{
		}

		private void ACHNHBCEIJH(CHILKDJABBF EKOFNPFCLMO, int DIFMOMFKPOF)
		{
		}

		private void ACHNHBCEIJH(Enemy DPENEFKKNDN, int DIFMOMFKPOF)
		{
		}

		private string PAONJKLHHMD(int LAEEMOKJPOK, bool IJKJKBOLJMM = true)
		{
			return null;
		}

		private void DKLNHGLBPDL(int DIFMOMFKPOF)
		{
		}

		private void EPGJLNFJNAJ(PointsDropper CAMENOAPLLO, Vector3 INLGLHIPOMC, CHILKDJABBF[] EKJPLODFNKO, int KOMPMCPODJM, int AFALOODLEEP, GCKJBJPBEIG IMKGLLIBCCJ, bool CAJKLOGPEID)
		{
		}

		private void FMKCNJMKGBL(CHILKDJABBF CLAAKJAFDLA, int IPMIIEAGJKC, Vector3 FCNGMPHKHAE)
		{
		}

		private void DAJOKNGDPIG(CHILKDJABBF LNHANHBBKDO, int LAEEMOKJPOK, Vector3 FEGJDCODKGG)
		{
		}

		private void DAJOKNGDPIG(CHILKDJABBF LNHANHBBKDO, int LAEEMOKJPOK)
		{
		}

		private void DEJFIIEEPBI(int LAEEMOKJPOK, Vector3 FCNGMPHKHAE, Vector3 GFIGODPPIKP)
		{
		}

		private bool CLPHBAKIGHF(CHILKDJABBF EKOFNPFCLMO, int EEHIDEKCNKP)
		{
			return false;
		}

		private void GLEGFGPGEII()
		{
		}

		private void GOEOFLAFCME()
		{
		}

		private void HINCMAHDCHI(ArenaVendingMachine KLNODHDDMJD, ArenaVendingMachineSlot MBMGJLOHAKB, CHILKDJABBF EKOFNPFCLMO, int EEHIDEKCNKP)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnPurchaseSuccess(CHILKDJABBF EKOFNPFCLMO, ArenaVendingMachine KLNODHDDMJD, ArenaVendingMachineSlot MBMGJLOHAKB, int EEHIDEKCNKP)
		{
		}

		private void GBJPOCIOPMO(int EOOEHDBBHMM)
		{
		}

		private void DCACHIBDLGL()
		{
		}

		private void NJDGCMFPKNE()
		{
		}

		private void JMIHKONDPNH()
		{
		}

		private void MOCMADEJHOB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void IFKHLMAPLPN()
		{
		}

		private void JGMFENCNFIP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KDBKIMHFMLB(out GIBEGHKMCIE JBMNGECJMJL, out int IBHHNMAMNDN, out int MNHFAIFOBND)
		{
			JBMNGECJMJL = default;
			IBHHNMAMNDN = default;
			MNHFAIFOBND = default;
		}

		private void OEKICDOGPNO(ref GIBEGHKMCIE JBMNGECJMJL, ref int IBHHNMAMNDN, ref int MNHFAIFOBND)
		{
		}

		private void PCEFOFDIFDK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FJCONMKPGIA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void FIEALIOEIDD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DNFOIDCDKML()
		{
		}

		private void LAFBBLJPANO()
		{
		}

		private void EJLGDNKPGOO()
		{
		}

		private void CMPLBIOHCAG()
		{
		}

		private void PCLEOCPJDNI()
		{
		}

		private void FPODMOCNFKF(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void BKECFKGGJML(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void DJHNJHEGNPG()
		{
		}

		private void ILHOEAJINBA()
		{
		}

		private void DODOKHAJIDN()
		{
		}

		private void EOGOAHACGOA()
		{
		}

		public void LockAllDoors()
		{
		}

		public void UnlockAllDoors()
		{
		}

		public void SetDoorUnlockTime(float DIIPICLFCAN)
		{
		}

		private void EOGHBNMIGNL()
		{
		}

		private void MFJLKNFKGHN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void OPENPNKMEMI()
		{
		}

		private void IAEEFBJEAAP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void KALLENEHHGB()
		{
		}

		private void HHCHKKBMNCN(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KJAKABOJPGF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LOGMJMPHLBM(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KPAGKFMIGHP(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private bool KNIIFCEBEIO()
		{
			return false;
		}

		private bool NDMMGKCLCJM()
		{
			return false;
		}

		public void MasterSpawnEncounter(EncounterDescriptor GAIDFOFCDHJ, GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void IDEAIBOFHLM()
		{
		}

		private void GOLJAMPIOMK(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void DMOIDMIFCIL(GIBEGHKMCIE NEBNOBLPNEP, int BFFJHKFEFPP)
		{
		}

		private int IGAEOCJFHND(List<int> FDLGFAJCLAF, List<ArenaEncounterSpawnPoint> BEKAAFMPMNI)
		{
			return 0;
		}

		public void GrantLaserTagTickets(float HIJDKOAMHHM)
		{
		}

		private MOMHMHADDCG AOJCLCDIMBO(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return null;
		}

		private NPFHLOCAHPF ALANECENMJF(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		protected void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
		{
		}
	}
}
