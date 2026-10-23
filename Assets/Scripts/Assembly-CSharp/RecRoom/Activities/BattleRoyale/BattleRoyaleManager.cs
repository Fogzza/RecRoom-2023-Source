using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	public class BattleRoyaleManager : GameRuleManager
	{
		public enum BKAGJCBMHNO
		{
			SOLOS = 0,
			SQUADS = 1,
			NONE = 2
		}

		private enum POBJFGAJDCC
		{
			CABLE_CAR = 0,
			GAME_RUNNING = 1,
			VICTORY = 2,
			INVALID = 65535
		}

		private enum GOELHJJINNO
		{
			SPAWN_IN_CABLE_CAR = 0,
			CABLE_CAR_FANFARE = 1
		}

		private enum HGLALIKPCLN
		{
			WAIT_FOR_PLAYERS_TO_EXIT_CABLE_CAR = 0,
			WARN_PLAYERS_KICK_OUT_OF_CABLE_CAR = 1,
			KICK_PLAYERS_OUT_OF_CABLE_CAR = 2,
			WAIT_FOR_REST_OF_GAME = 3
		}

		private enum KHAHONDOPOK
		{
			INITIAL_FEEDBACK = 0,
			SECONDARY_FEEDBACK = 1
		}

		private enum OCCMNHHNGFE
		{
			PLAYER_IS_ELIMINATED = 0,
			ELIMINATION_RANK = 1,
			LAST_KILL = 2,
			DEFERRED_KILLER_PLAYER_ID = 3
		}

		private enum AKLIJMBKFHK
		{
			INITIALIZE = 0,
			GAME_OVER = 1,
			VICTORY = 2
		}

		private sealed class MLMIMJEPGLM : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BattleRoyaleManager _003C_003E4__this;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public MLMIMJEPGLM(int _003C_003E1__state)
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

		[SerializeField]
		private PlayerCombatUI playerCombatUIPrefab;

		[SerializeField]
		private float spawnInCableCarStateDuration;

		[SerializeField]
		private float cableCarFanfareDuration;

		[SerializeField]
		private float victoryStateDuration;

		[SerializeField]
		private float waitForPlayersToExitCableCarStateDuration;

		[SerializeField]
		private float warnKickPlayersOutOfCableCarStateDuration;

		[SerializeField]
		private float kickPlayerOutOfCableCarStateDuration;

		[SerializeField]
		private RecRoomAudioClip playerReviveSFX;

		[SerializeField]
		private RecRoomAudioClip localPlayerOutMusic;

		[SerializeField]
		private RecRoomAudioClip localPlayerWinMusic;

		[SerializeField]
		private RecRoomAudioClip localPlayerLoseMusic;

		[SerializeField]
		private RecRoomAudioClip localPlayerExitGondolaMusic;

		[SerializeField]
		private BattleRoyaleWinnerDoor winnerDoor;

		private const float NOABHGDICLC = 5f;

		private const float EBMBIOHJEGE = 3f;

		private const float OOEKONCAOGM = 4f;

		private const float BGNCIDECEOJ = 3f;

		private const float IHOFBLDAAFP = 4f;

		private const float LOLHGEHABGA = 3f;

		private HONEDBECDOK DIOBKCDDDEP;

		private JOJOABLFOBA JOMILDGFALA;

		private bool JAIABBMFFEA;

		private int GADKKELJBLH;

		private float? OIAFGPJFNAG;

		private int OEAODMJGGPP;

		private int KGBCMKGBLAA;

		private int LKHLMLCLDAP;

		private float? FGMAGGGKHDP;

		private int MEHANFFBAJE;

		private bool LAGLEPONBAJ;

public new static BattleRoyaleManager Instance
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

public override bool AutoRunTimer
{
get 		{
			return false;
		}

}

public bool IsGameEnding
{
get 		{
			return false;
		}

}

public int NumPlayersRemaining
{
get 		{
			return 0;
		}

}

public override string RuleTypeAutoTag
{
get 		{
			return null;
		}

}

		private void JHECFGDENEP(bool BIJHPJHGOEF, bool AEDEGBAOLDD)
		{
		}

		private void LAELCNBNDND()
		{
		}

		private void CGOOFIBLGDE(BattleRoyaleCableCar LNCLCFIBFBC)
		{
		}

		private IEnumerator ONHMOAOOFEI()
		{
			return null;
		}

		private void OMIDNEEKOFD(bool CIIBNODPBKD)
		{
		}

		private void ANHJGKGKBHI(CHILKDJABBF NLGCGEFCFNA)
		{
		}

		private void JCHMDHPIIHL()
		{
		}

		private void PMOHMEJOBHC(float KBDNFBEFCAD, float COKLEIOCNGL)
		{
		}

		private void GBHGFAEKCOM()
		{
		}

		private void DFLILAGGGDM()
		{
		}

		private void JLNLLIDMIEE()
		{
		}

		protected override void HDJBEAFJEHD()
		{
		}

		protected override void ENHEJEADGCH()
		{
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

		private void Update()
		{
		}

		public bool IsPlayerEliminated(CHILKDJABBF EKOFNPFCLMO, out float CPMMAINHEHO)
		{
			CPMMAINHEHO = default;
			return false;
		}

		public bool IsPlayerEliminated(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public bool IsTeamEliminated(GIBEGHKMCIE NEBNOBLPNEP, out float CPMMAINHEHO)
		{
			CPMMAINHEHO = default;
			return false;
		}

		public bool CustomDownButNotOutRespawnCondition(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		private int DCGNMPJIEGH()
		{
			return 0;
		}

		private string NJNNJDCNMFC(CHILKDJABBF EKOFNPFCLMO)
		{
			return null;
		}

		public bool TryGetPlayerEliminationRank(CHILKDJABBF EKOFNPFCLMO, out int JLJKPNCDEIN)
		{
			JLJKPNCDEIN = default;
			return false;
		}

		public bool TryGetLastTeamStanding(out GIBEGHKMCIE ICCEMEPBDID)
		{
			ICCEMEPBDID = default;
			return false;
		}

		private int DFMLJIEGIOI(CHILKDJABBF PGKEHBCKJKI)
		{
			return 0;
		}

		private void BCAIHNCKEMJ()
		{
		}

		private void OCNLJGBEFOB(bool LIKOBOFKNKJ)
		{
		}

		private void EEEKIDEPKIP(CHILKDJABBF FFDEPLCDBNA, bool OHDEKMCDIPE)
		{
		}

		private void KEAKCFKKHJL()
		{
		}

		private void HGMKIOCAKGN(CHILKDJABBF ANFAILCOAEI)
		{
		}

		private void DJDJBDIHIFO(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void MLPDKFLLLCP(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void LPEPOPBILMM(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void CCAFKLECDDO(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void AJBLMKPKMGL(CHILKDJABBF NJDHAACHDKF, CHILKDJABBF INIEKKNFPDP, Weapon PLOGNHIJBNB, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, Vector3 LIHLELBIDLB, int FDDPFMJOHLO, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void EIGEJFCDIIJ(CHILKDJABBF INIEKKNFPDP, Player.NBPIPAJOGLC EODAGGFEIEO, Vector3 OGEABPMOJJB, GameCombatManager.NMJGAEHKCNH LPHKEIOOFIN)
		{
		}

		private void PBIPAGNDIBA(CHILKDJABBF GDIGGLJFDPB, CHILKDJABBF OOJOIFKCDLH, Vector3 INLGLHIPOMC)
		{
		}

		private void OHOAEJOKELL(CHILKDJABBF ANFAILCOAEI, bool FMFBPKPHJMG)
		{
		}

		private void PFCDIGNAFGL(string NANGCKCJMMA)
		{
		}

		private void EKMPKHMDJPP(CHILKDJABBF ANFAILCOAEI, string NANGCKCJMMA)
		{
		}

		private void DNDOAMDDODE(CHILKDJABBF ADIIGAEKMMD)
		{
		}

		private void OPMAJNJGMMB(string NANGCKCJMMA)
		{
		}

		private void AFPADEOHAPI(CHILKDJABBF ANFAILCOAEI)
		{
		}

		private void HGLIEJFAFNK()
		{
		}

		private void INCGBHCMCJE(CHILKDJABBF ANFAILCOAEI)
		{
		}

		private void DMIHCOPPDPA()
		{
		}

		[PBOMGCLBFHF]
		private void RpcRequestMasterKillzoneKillLocalPlayer(GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		private void ELAPEBCGIMJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FJHDEKBBDBB(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void OBDJEPNFDFL()
		{
		}

		private void BKDIFMCHDDC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BGBFPDFJFGC()
		{
		}

		private void AMCCENKIECF(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void FGDAPNKIKJF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BDEGFCIJCAP()
		{
		}

		private void HOMKCMBGLPO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KFKBEBAPCPI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void IJFDBIMJHEL()
		{
		}

		private void DJBCBJDMOOL(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void IPNIHMIHCPJ()
		{
		}

		private void IJGHGGLBPED(ushort EHLPLCEJPDD, ushort HCGJGBJCAOB)
		{
		}

		private void CKCBFLFJJLD()
		{
		}

		private void OELFIBBIMOA(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private bool DFHKDKNFDKB()
		{
			return false;
		}

		private void CIJKINPFAIC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void LFOFBDOEDMP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EHHJMMFHFAJ()
		{
		}

		private void NDEMMGJNKGM()
		{
		}

		private void LPJDHOLGGJA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DHFNHOIPCDI()
		{
		}

		private void ECBDLLGPPBK()
		{
		}

		protected void LAJGBEKOMJI()
		{
		}
	}
}
