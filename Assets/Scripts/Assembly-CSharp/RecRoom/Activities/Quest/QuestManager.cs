using System;
using System.Collections.Generic;
using RecRoom.Activities.SubScenes;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestManager : GameRuleManager
	{
		private struct FIPFMFHGJIA
		{
			public Tool IPJNOCPOPFF;

			public Tool LKOEMJLHLPA;

			public List<int> CBCHJMCEHOH;

			public List<Tool> BEMKJDLJPKB;

public static FIPFMFHGJIA DPPJPBMGLNA
{
get 			{
				return default;
			}

}

			public static FIPFMFHGJIA OKCHCMMIKGF()
			{
				return default;
			}
		}

		protected enum DLHPAABJDHC
		{
			INVALID = 0,
			INITIAL_LOAD = 1,
			RUNNING = 2,
			LOSE = 3,
			WIN = 4
		}

		private enum EDDPEOJFCDM
		{
			INITIAL_ROOM = 0
		}

		private enum ILMBPLCDKAL
		{
			RUNNING_ROOM_SUB_STATE = 0,
			UNLOADING_ROOM_SUB_STATE = 1,
			COUNT = 2
		}

		private enum LDDMBLGLCPE
		{
			LOSE_SUB_STATE = 0,
			UNLOADING_FINAL_ROOM_SUB_STATE = 1
		}

		public enum CGPECJJPDIH
		{
			POINTS_VALUE = 0
		}

		public enum JANNFCHDBAB
		{
			Revive = 0,
			Trap = 1,
			Enemy = 2,
			FriendlyFire = 3,
			Initialize = 4
		}

		public enum PCGJIMCMLHD
		{
			STATE_0 = 0,
			STATE_1 = 1,
			STATE_2 = 2,
			STATE_3 = 3,
			STATE_4 = 4,
			STATE_5 = 5,
			STATE_6 = 6,
			STATE_7 = 7,
			STATE_8 = 8,
			STATE_9 = 9,
			STATE_10 = 10,
			STATE_11 = 11,
			STATE_12 = 12,
			STATE_13 = 13,
			STATE_14 = 14,
			STATE_15 = 15,
			STATE_16 = 16,
			STATE_17 = 17,
			STATE_18 = 18,
			STATE_19 = 19,
			MAX_VALUE = STATE_19
		}

		[SerializeField]
		private bool hasInitialLobbyRoom;

		[SerializeField]
		private EnemyCombatUI enemyCombatUIPrefab;

		[SerializeField]
		private BFPALKJDPLP statTypeToDisplayAsScore;

		[SerializeField]
		private float winGameOverDuration;

		[SerializeField]
		private float loseGameOverDuration;

		[SerializeField]
		private string victoryNotificationString;

		[SerializeField]
		private string loseNotificationString;

		[SerializeField]
		private string gameProgressSubtitle;

		[SerializeField]
		private bool playPointsFXandNotifications;

		[SerializeField]
		private BFPALKJDPLP addPointsToLootStat;

		[SerializeField]
		private bool everyoneEarnsUndividedLoot;

		[SerializeField]
		public bool hasCustomPointDropColor;

		[SerializeField]
		public Color customPointDropColor;

		[SerializeField]
		private int deathPointsPenalty;

		[SerializeField]
		private int friendlyFirePointsPenalty;

		[SerializeField]
		private float deathPenaltyTrapMultiplier;

		[SerializeField]
		public bool usesCollectiblesForPoints;

		[SerializeField]
		private SpawnableCollectible collectiblePrefab;

		[SerializeField]
		private int spawnableCollectibleValue;

		[SerializeField]
		private PooledParticle playerDamagedVFXPrefab;

		[SerializeField]
		private PooledParticle smallPointsSpawnVFXPrefab;

		[SerializeField]
		private PooledParticle largePointsSpawnVFXPrefab;

		[SerializeField]
		private RecRoomAudioClip gameWinSFX;

		[SerializeField]
		private RecRoomAudioClip gameLoseSFX;

		[SerializeField]
		private RecRoomAudioClip localPlayerOutSFX;

		[SerializeField]
		private RecRoomAudioClip smallPointsSpawnSFX;

		[SerializeField]
		private RecRoomAudioClip largePointsSpawnSFX;

		[SerializeField]
		private PNLFAAAPEID objectiveGames;

		[SerializeField]
		private PNLFAAAPEID objectiveWins;

		[SerializeField]
		private PNLFAAAPEID objectivePlayerRevives;

		[SerializeField]
		private PNLFAAAPEID objectiveEnemyKills;

		[SerializeField]
		private KeyCode debugKillAllEnemiesKey;

		[SerializeField]
		private GameRoleSettings gameRoleSettings;

		protected JOJOABLFOBA LPECCOEIDLF;

		private HONEDBECDOK JANMEFICNOP;

		protected int DKIBDDMLFFC;

		private global::MOBDJNEDDKC<int> ONLEMAOFIDO;

		protected QuestPreGameRoom MMIHIFPMEOP;

		protected QuestGameplayRoom BGPNDNPCGBM;

		private int[] NLFFBBCMKJE;

		private BaseActivitySubScene DMFKFFMEELD;

		private global::MOBDJNEDDKC<int> DIEBCMLKEEJ;

		private global::MOBDJNEDDKC<int> CKFPLNGIBNM;

		private global::MOBDJNEDDKC<int> IBPPLHAOCCH;

		private bool PKOMGKOOPNE;

		private FIPFMFHGJIA PAHODFNPGPH;

		private IDisposable GODHCBAPJKN;

		private Action<QuestGameplayRoom> KGDCFLIDHPJ__BackingField;

		private Action<PCGJIMCMLHD> ALKEAMKCGJI__BackingField;

		public static EEANDDJEMJC CheckpointReachedEvent;

public new static QuestManager Instance
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

public PNLFAAAPEID ObjectiveGames
{
get 		{
			return (PNLFAAAPEID)0;
		}

}

public PNLFAAAPEID ObjectiveWins
{
get 		{
			return (PNLFAAAPEID)0;
		}

}

public PNLFAAAPEID ObjectivePlayerRevives
{
get 		{
			return (PNLFAAAPEID)0;
		}

}

public PNLFAAAPEID ObjectiveEnemyKills
{
get 		{
			return (PNLFAAAPEID)0;
		}

}

public GameRoleSettings GameRoleSettings
{
get 		{
			return null;
		}

}

public override string RuleTypeAutoTag
{
get 		{
			return null;
		}

}

public int DefaultRoomIndex
{
get 		{
			return 0;
		}

set {
		}
}

public PCGJIMCMLHD DefaultCampaignStoryState
{
get 		{
			return PCGJIMCMLHD.STATE_0;
		}

set {
		}
}

public override bool CanContinue
{
get 		{
			return false;
		}

set {
		}
}

public virtual bool IsQuestRunning
{
get 		{
			return false;
		}

}

public PCGJIMCMLHD CurrentCampaignStoryState
{
get 		{
			return PCGJIMCMLHD.STATE_0;
		}

set {
		}
}

public PCGJIMCMLHD CurrentRoomStoryState
{
get 		{
			return PCGJIMCMLHD.STATE_0;
		}

set {
		}
}

public override bool AutoRunTimer
{
get 		{
			return false;
		}

}

protected virtual bool KHMNCIMPGMG
{
get 		{
			return false;
		}

}

public event Action<QuestGameplayRoom> GameplayRoomLoaded {
add {
		}
remove {
		}
}

public event Action<PCGJIMCMLHD> StoryStateChanged {
add {
		}
remove {
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

		protected virtual void Update()
		{
		}

		protected override void HDJBEAFJEHD()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcOnMultipleHealthChanges()
		{
		}

		protected override void ENHEJEADGCH()
		{
		}

		private void NFKJFJMFLOI()
		{
		}

		private void BKMEIJJGAEC()
		{
		}

		private void BLKJINEPKDB(CHILKDJABBF EKOFNPFCLMO, JANNFCHDBAB GBMLHJHCLFD, Enemy KGKGANFIKBK = null, CHILKDJABBF ANGPIJDDCNJ = null)
		{
		}

		public void PenalizePlayer(CHILKDJABBF EKOFNPFCLMO, JANNFCHDBAB GBMLHJHCLFD, CHILKDJABBF ANGPIJDDCNJ = null)
		{
		}

		private void PBIPAGNDIBA(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 INLGLHIPOMC)
		{
		}

		private void FCIFJACGMBD(CHILKDJABBF NJDHAACHDKF, Weapon ONFCNCHNBGL, Enemy INIEKKNFPDP, Vector3 PDFEDMAOMNH)
		{
		}

		private void NIMAMFAOJFA(Enemy NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void LPEPOPBILMM(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC DHIJJLNLHNN, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcOnPlayerDown(CHILKDJABBF ADIIGAEKMMD, JANNFCHDBAB GBMLHJHCLFD, KDBKBBGOBIP OGPDFOMPNND)
		{
		}

		protected virtual void KOKBPINKLEI(CHILKDJABBF ADIIGAEKMMD, JANNFCHDBAB GBMLHJHCLFD, KDBKBBGOBIP OGPDFOMPNND)
		{
		}

		public void PlayDeathPenaltyNotification(JANNFCHDBAB GBMLHJHCLFD, string PFDGOJNEMCK, string MGOFJGOHNBA = null)
		{
		}

		public void PlayPlayerHitFx(CHILKDJABBF KJCCPIIFNGO, Vector3 OGEABPMOJJB)
		{
		}

		private void MLPDKFLLLCP(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void PKPLAJPMPAB(CHILKDJABBF EKOFNPFCLMO, int GGPGKGELBDI)
		{
		}

		private void ACGGANDMEBD(PointsDropper LOFJOGNFLPB, Vector3 OGCEJJFNMFN, CHILKDJABBF[] EKJPLODFNKO, int KOMPMCPODJM, int AFALOODLEEP, GCKJBJPBEIG JIEKNMMMHAA, bool CAJKLOGPEID = false)
		{
		}

		private void EOLHFALAJIH(Vector3 OGCEJJFNMFN, GCKJBJPBEIG JIEKNMMMHAA)
		{
		}

		private void PEOGMMGEBAH(Vector3 OBPLDFCKNOP, int[] PFEKALKPMBL, int IPMIIEAGJKC, bool FAAADCKNPEL, int NECPIOJLJIH = 0, bool CAJKLOGPEID = false)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcMasterAwardPoints(Vector3 OBPLDFCKNOP, int[] PFEKALKPMBL, int CCMJGDNHOND, bool FAAADCKNPEL, int NECPIOJLJIH, bool CAJKLOGPEID)
		{
		}

		private void IKAIJDBIMLD(Vector3 OBPLDFCKNOP, int[] PFEKALKPMBL, int CCMJGDNHOND, bool FAAADCKNPEL, int NECPIOJLJIH, bool CAJKLOGPEID)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcPlayPointsNotification(Vector3 OGCEJJFNMFN, int[] PFEKALKPMBL, int IPMIIEAGJKC, int NECPIOJLJIH)
		{
		}

		private int OKKDDCIPDKE(int KOMPMCPODJM, int AFALOODLEEP)
		{
			return 0;
		}

		private void MOFALNPFAIA()
		{
		}

		private void MKNKFMGOMHC()
		{
		}

		private bool KNGIKOGCBOF(Vector3 OGCEJJFNMFN, CHILKDJABBF[] EKJPLODFNKO, int IPMIIEAGJKC, GCKJBJPBEIG JIEKNMMMHAA)
		{
			return false;
		}

		private void MILHANOAIEO(SpawnableCollectible LJJMELANGBO)
		{
		}

		private void IBCBBJCCFGB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LJCGKBEAJOM()
		{
		}

		private void MCEHGFOHDIC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void JOPGJKMAMLF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void JCGBIJMNELF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void AAEEIEHADHJ()
		{
		}

		private void BLEBGBBCGMG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void HAOBDDOPDOD()
		{
		}

		private void DKEBLBFIBKE(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void NJMNFBIODOP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected void PIKPBACCKMG()
		{
		}

		protected virtual void OCCPGAKFHFH()
		{
		}

		protected virtual void BCDBHKOHBGD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual bool CDOBBMCNJKP()
		{
			return false;
		}

		private void EFKKBGINPCG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FHBDOKAOPHN()
		{
		}

		private void PMMMEPCHKOA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FIBGIPOPCJL()
		{
		}

		private void OOPMAGCOBCD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void NJMEMOBBHKF()
		{
		}

		protected virtual void FNMLANJLBOE(int OOMCLENBFPI)
		{
		}

		protected virtual void MOFHIOANKJD(int OOMCLENBFPI, GameObject[] LJLEGPDKBNB)
		{
		}

		protected virtual void GOGMHGACAFI()
		{
		}

		private void EOAOABHDHPE()
		{
		}

		private ushort NDIBFPHECIG(int OOMCLENBFPI)
		{
			return 0;
		}

		private ushort IEKEHLPIPMI(int OOMCLENBFPI)
		{
			return 0;
		}

		private int EGLECHNBAFH(int OOMCLENBFPI, ILMBPLCDKAL ACFPEJKNBDE)
		{
			return 0;
		}

		private int GFEMOEIDBHK(ushort BEOILOFKEIA)
		{
			return 0;
		}

		private int GNMIAGCCBLB()
		{
			return 0;
		}

		public int GetCurrentGameplayRoomIndex()
		{
			return 0;
		}

		private int MHOBCIMIOBO()
		{
			return 0;
		}

		private void DHHPMEJMMOG()
		{
		}

		private void IMOOGDHINMK()
		{
		}

		private void KCGOHLBCOJH()
		{
		}

		private void JCNFFJDDDLI(int JOPOKBJLGOE)
		{
		}
	}
}
