using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Activities.Vehicles;
using RecRoom.Audio;
using RecRoom.Core;
using UnityEngine;

namespace RecRoom.Activities.RecRally
{
	public class RecRallyManager : GameRuleManager
	{
		private struct EEAAELCAPFO
		{
			public GIBEGHKMCIE BFEKAAHGNLH;

			public POEOMLLLCAI AIDOLKNMHIA;

			public EEAAELCAPFO(GIBEGHKMCIE NEBNOBLPNEP, POEOMLLLCAI AFGPGEKAMJK)
			{
				BFEKAAHGNLH = GIBEGHKMCIE.TEAM_1;
				AIDOLKNMHIA = POEOMLLLCAI.INDEX_0;
			}
		}

		public enum KAAOACAGBJD
		{
			INVALID = 65535,
			WAIT_FOR_PLAYERS = 0,
			RACE_SPAWN = 1,
			RACE_PREP = 2,
			COUNTDOWN = 3,
			RACE_RUNNING = 4,
			RACE_WRAPUP = 5,
			RACE_WRAPUPOUTRO = 6,
			RACE_FINISHED = 7,
			RACE_TRANSITION = 8
		}

		public enum FBEJMHGHFLK
		{
			RACE_FINISHED = 1,
			CURRENT_LAP = 2
		}

		public enum KNHGFDMNPCE
		{
			RACE_PREP = 0,
			RACE_RUNNING = 1,
			RACE_FINISHED = 2,
			LOCAL_PLAYER_FINISHED = 3,
			FIRST_PLACE_FINISHED = 4
		}

		private enum HOHILAGFJFB
		{
			DEFAULT = -1,
			POST_RACE_1ST = 0,
			POST_RACE_2ND = 1,
			POST_RACE_3RD = 2,
			POST_RACE_DEFAULT = 3
		}

		private enum CNBOIILELOL
		{
			TEAM_FINISHED = 0
		}

		private class PEENBEGICGM
		{
			private global::MOBDJNEDDKC<int> PHMJOLEDEDH;

			private global::MOBDJNEDDKC<int> DAJKAIGAJIP;

			private global::MOBDJNEDDKC<int> CIPLOEGFDOD;

			private global::MOBDJNEDDKC<bool> MOCDBGMAPOP;

			private global::MOBDJNEDDKC<bool> FEABBCKLDNP;

public int MNFEBAJBFOO
{
get 			{
				return 0;
			}

set {
			}
}

public int IGDFFLNBHAD
{
get 			{
				return 0;
			}

set {
			}
}

public int GHFGJJHAJGL
{
get 			{
				return 0;
			}

set {
			}
}

public bool DFNFFNGOBIP
{
get 			{
				return false;
			}

set {
			}
}

public bool NFLHABIJKOE
{
get 			{
				return false;
			}

set {
			}
}

			public PEENBEGICGM(GIBEGHKMCIE NEBNOBLPNEP, RecRallyManager ACDHNMANGFE)
			{
			}

			private static string MJFAGAKLKCE(GIBEGHKMCIE NEBNOBLPNEP, string OIFCDJKHBEC)
			{
				return null;
			}
		}

		private sealed class BCNAIOOPFBD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RecRallyManager _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public BCNAIOOPFBD(int _003C_003E1__state)
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

		private sealed class HJCLKJBHIIO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RecRallyManager _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public HJCLKJBHIIO(int _003C_003E1__state)
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

		private sealed class BDBPHGFFEID : IEnumerable<GroundVehicle>, IEnumerable, IEnumerator<GroundVehicle>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private GroundVehicle _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public RecRallyManager _003C_003E4__this;

			private bool includeDisabled;

			public bool _003C_003E3__includeDisabled;

			private List<SpawnPoint>.Enumerator _003C_003E7__wrap1;

			GroundVehicle IEnumerator<GroundVehicle>.Current
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
			public BDBPHGFFEID(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<GroundVehicle> IEnumerable<GroundVehicle>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public const int NULL_SCORE = -1;

		private static string[] NCKIKHPDGJA;

		private const int EAKPHGAGMOL = 5;

		[SerializeField]
		private RecRoomAudioClip preRaceStartStinger;

		[SerializeField]
		private RecRoomAudioClip startYourEngines;

		[SerializeField]
		private RecRoomAudioClip[] countdownTickAudioClips;

		[SerializeField]
		private RecRoomAudioClip raceStartAudioClip;

		[SerializeField]
		private float timeBetweenRaceStartAndGameplayMusic;

		[SerializeField]
		private RecRoomAudioClip[] newLapAudioClips;

		[SerializeField]
		private RecRoomAudioClip[] gainedPlaceAudioClips;

		[SerializeField]
		private RecRoomAudioClip[] lostPlaceAudioClips;

		[SerializeField]
		private float placeAudioCooldownTime;

		[SerializeField]
		private RecRoomAudioClip finalLapStinger;

		[SerializeField]
		private float raceWrapupTime;

		[SerializeField]
		private float minRaceWrapupTime;

		[SerializeField]
		private string[] finishPositionStrings;

		[SerializeField]
		private RecRoomAudioClip[] finishPositionAudioClips;

		[SerializeField]
		private RecRoomAudioClip wrapupAudioClip;

		[SerializeField]
		private float raceWrapupOutroTime;

		private JOJOABLFOBA COKFLOBALKK;

		private HONEDBECDOK OCNFLCIFIBF;

		private LapManager CPFHCBEEEAK;

		private List<SpawnPoint> DGHBCCBBLKE;

		private float KMBOBOHIJAB;

		private float KMGFLIIGHGN;

		private bool BKCBGCIMIIJ;

		private Dictionary<GroundVehicle, EEAAELCAPFO> NEHINAPIOEK;

		private bool EDNAMONJKIG;

		private static readonly string IMMBDMHPGCL;

		public static global::HHOBPMOCKMJ<KNHGFDMNPCE> RaceEvent;

		private bool FJNCFJBPFPK;

		private bool FNJLLIIFGJP;

		private Dictionary<GIBEGHKMCIE, PEENBEGICGM> LLGCFCIIDBB;

public new static RecRallyManager Instance
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

private KAAOACAGBJD MBHNCCMHIPK
{
get 		{
			return KAAOACAGBJD.WAIT_FOR_PLAYERS;
		}

set {
		}
}

private GIBEGHKMCIE AIMEHAKGMLI
{
get 		{
			return GIBEGHKMCIE.TEAM_1;
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

public bool AmbienceEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool MusicEnabled
{
get 		{
			return false;
		}

set {
		}
}

private bool IPPLPJDIDDA
{
get 		{
			return false;
		}

}

private bool MJJMPPDBKLI
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

		protected override void OnDestroy()
		{
		}

		protected void Update()
		{
		}

		private bool ENJICGNAEIM()
		{
			return false;
		}

		private void JDEMLOHJLPJ()
		{
		}

		private void INGOFACGHIJ()
		{
		}

		private void GHEICPLOPMF(bool OBFHBDLKFPA)
		{
		}

		protected override void HDJBEAFJEHD()
		{
		}

		protected override void ENHEJEADGCH()
		{
		}

		private void JHGANAIEINE()
		{
		}

		private void MOALPCNOJHE(GIBEGHKMCIE NEBNOBLPNEP, int DLEDLFJIMGE)
		{
		}

		private void DEODNANFBPC(GIBEGHKMCIE NEBNOBLPNEP, int ANKBOHGLPCE)
		{
		}

		private void NBOGLFELFGA(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void KICCEPJGKPG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FGHBFGCDCBE()
		{
		}

		private void KDPMFIOFHGM(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void FGAFCPFMDAJ()
		{
		}

		private void MEJOKDMLKCP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void AHEJMEOPBFC()
		{
		}

		private void AHFOKBMGHIO(bool CCFFKJLGAKD = true)
		{
		}

		private void AJIOJCIDJLC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void JHLICGBAJJB()
		{
		}

		private void GNFIHMOANJC(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void LLBCEHEDNOL(bool GALIGHIENDI)
		{
		}

		private void KFLOEKAPAHJ()
		{
		}

		private void OMDJDIILBCC()
		{
		}

		private void JAMCEOJGPKF()
		{
		}

		private void FJPIKGJOFON()
		{
		}

		private void HOOLBBBDCHO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EHLPLFHEMCP()
		{
		}

		private void OOCDGEJAGEO(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private IEnumerator<EGGPGCCKPCO> EAFLKLPHOKE()
		{
			return null;
		}

		private void BLHODCJOHOM(float HCNHLFPCLIO)
		{
		}

		private void HOHPNIDCFEA(ushort EHLPLCEJPDD, ushort EDNNIIPAKCK)
		{
		}

		private void BONJLJMPNAP()
		{
		}

		private IEnumerator<EGGPGCCKPCO> BGAIJLBLJEC()
		{
			return null;
		}

		private bool DGPAMKIFEOA()
		{
			return false;
		}

		private bool IKIBNDFFING()
		{
			return false;
		}

		private bool JLHOFGLAING()
		{
			return false;
		}

		private void GFLHKHPKNNJ()
		{
		}

		private void PAJGPMOEFEH()
		{
		}

		[PBOMGCLBFHF]
		private void RpcRallyNotifyTeamPlaceChanged(GIBEGHKMCIE NEBNOBLPNEP, int EKFMCELLIJK, int GJKBAPACKMF)
		{
		}

		private void HJLFPDBLKIE(int GJKBAPACKMF)
		{
		}

		private void FOFOBCAOCNC(int GJKBAPACKMF)
		{
		}

		private void BDLMJPECPME(RecRoomAudioClip HFMBEKEICOC)
		{
		}

		private void EPLEIKKOFHG()
		{
		}

		private int EGCAFPBGNIE(GIBEGHKMCIE NNMPJECKECI, GIBEGHKMCIE EFNJCAIBDLA)
		{
			return 0;
		}

		private Vector3 DFBONKIEACH(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return default;
		}

		private void GGILGNOGFPD(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterRallyRequestRaceFinish(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void AJGHOPCENMB(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private void DCJKMNNPBHK(ushort EHLPLCEJPDD, ushort EDNNIIPAKCK)
		{
		}

		private void MPBBFCCCADF()
		{
		}

		private void ACANJNJGOCG(ushort EHLPLCEJPDD, ushort EDNNIIPAKCK)
		{
		}

		private void LBMCKCKOHKK()
		{
		}

		private void NBLPFPINJBG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void AHDIFFKKBOP()
		{
		}

		private void BADJMKGLHIN()
		{
		}

		private void DMGOGOJOBBP()
		{
		}

		private void AKGFLKBCKPK(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void KIBGIAPLIDB()
		{
		}

		private void OAPINGCMHKE()
		{
		}

		private bool IOCEDGLLGKK(CHILKDJABBF EKOFNPFCLMO, SeatManagement PLGGGAJMBCN)
		{
			return false;
		}

		private bool GDBDPFHACCP(CHILKDJABBF EKOFNPFCLMO, VehicleControl BADKNFDLLEG)
		{
			return false;
		}

		private bool GBLLCAEIDDI(CHILKDJABBF EKOFNPFCLMO, GroundVehicle GFNJONFMHFK)
		{
			return false;
		}

		private PEENBEGICGM AOJCLCDIMBO(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return null;
		}

		private int HFHEJHBNDOI(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return 0;
		}

		private void BEEIPCBHCDM(GIBEGHKMCIE NEBNOBLPNEP, int DBGMMMFKLKG)
		{
		}

		private void CCKFEBENPFO(GIBEGHKMCIE NEBNOBLPNEP)
		{
		}

		private int LGOCHIBKOLJ(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return 0;
		}

		private void DGIPKFMMOND(GIBEGHKMCIE NEBNOBLPNEP, int JFJADDEAHGM)
		{
		}

		private int CBCFPCGNNMD(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return 0;
		}

		private void EEBHGGGBLAL(GIBEGHKMCIE NEBNOBLPNEP, int OBCNCMAIGNK)
		{
		}

		private bool PJOIHHFBNBK(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return false;
		}

		private void CDFJKBNECIO(GIBEGHKMCIE NEBNOBLPNEP, bool IGPKEAEFGPF)
		{
		}

		private bool CEFCCDDPIBC(GIBEGHKMCIE NEBNOBLPNEP)
		{
			return false;
		}

		private void HHCBIOOMLBL(GIBEGHKMCIE NEBNOBLPNEP, bool DDHBAILDOFG)
		{
		}

		private GIBEGHKMCIE EFMPIDEALJH()
		{
			return GIBEGHKMCIE.TEAM_1;
		}

		private void BGBBGNMLEBA()
		{
		}

		private bool CBEGIAABCJA(out int JFBHLKBFDJI, out bool EDINMKJNNMK, out int KDENGJAAAAA, out int KFFDGGIMLOJ, out bool AMCPEAKKBKO, out int LIJGJGIGLOD)
		{
			JFBHLKBFDJI = default;
			EDINMKJNNMK = default;
			KDENGJAAAAA = default;
			KFFDGGIMLOJ = default;
			AMCPEAKKBKO = default;
			LIJGJGIGLOD = default;
			return false;
		}

		public int CurrentRaceTime()
		{
			return 0;
		}

		private void NAOAHFANMLO()
		{
		}

		private void LFPDFJJIMEN(GIBEGHKMCIE NEBNOBLPNEP, int JFBHLKBFDJI)
		{
		}

		private void BJOLIFDHJOI(CNBOIILELOL MBJJKJNAOPF, int AOLGDKOOCIE, int CGIPLHMBODI)
		{
		}

		[PBOMGCLBFHF]
		private void RpcRallyNotifyAllFeedback(CNBOIILELOL MBJJKJNAOPF, int AOLGDKOOCIE, int CGIPLHMBODI)
		{
		}

		private IEnumerable<GroundVehicle> FFGOHMJMEBB(bool PKEEBDPFKLJ)
		{
			return null;
		}

		public void RaceStartedAnalyticsEvent()
		{
		}

		public void RaceFinishedAnalyticsEvent()
		{
		}
	}
}
