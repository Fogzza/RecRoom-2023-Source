using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Pun;
using RecRoom.Players;

namespace RecRoom.Broadcasting
{
	public class BroadcastingManager : MonoBehaviourPunCallbacks, HDCOAHEBHMA
	{
		public enum DNGGEIPPHLG
		{
			NotRequested = 0,
			Requested = 1,
			Granted = 2,
			Denied = 3
		}

		private enum JGFBFKNFLIN
		{
			FailedToConnect = 0,
			Disconnected = 1,
			BroadcastRoomInstanceMismatch = 2
		}

		private enum CPOKLFCMOJJ : byte
		{
			RoomChat = 0,
			Movement = 1,
			Voice = 2,
			DesktopScreenShare = 3,
			CircuitManagerV2Event = 4
		}

		public enum CGOKGJPDIAF
		{
			Listener = 0,
			Broadcaster = 1
		}

		private sealed class OIIEEDOFJOK
		{
			public BroadcastingManager _003C_003E4__this;

			public DNGGEIPPHLG status;

			public int accountId;

			public long playerEventId;

			internal void _003CSetEventBroadcastingAuthorizationStatus_003Eb__0(IMIJPHJKLIM playerEvent)
			{
			}
		}

		private sealed class AIDBBBMKBJG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public BroadcastingManager _003C_003E4__this;

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
			public AIDBBBMKBJG(int _003C_003E1__state)
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

		private sealed class LKODIDMDKHD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public BroadcastingManager _003C_003E4__this;

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
			public LKODIDMDKHD(int _003C_003E1__state)
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

		private sealed class BDAIJGDHDKI
		{
			public int senderPlayerId;

			internal bool _003CParseRoomChatMessage_003Eb__0(CHILKDJABBF p)
			{
				return false;
			}

			internal bool _003CParseRoomChatMessage_003Eb__1(Player p)
			{
				return false;
			}
		}

		private sealed class ECGBPLHFCBM
		{
			public BroadcastPlayerData playerData;

			public object[] userDataProps;

			public BroadcastingManager _003C_003E4__this;

			internal void _003CRecRoom_002EBroadcasting_002EIBroadcastManager_002EInstantiateBroadcastedPlayers_003Eb__0(PJFDADLIKCD playerPresence)
			{
			}
		}

		private readonly global::HHOBPMOCKMJ<(long, int)> DFIPMGHKAKO;

		private readonly Dictionary<long, Dictionary<int, DNGGEIPPHLG>> OBGAKOONPCF;

		private const int GOLLHKGABJO = 10000;

		private const float JPNMNCIOOPJ = 8f;

		private const string NKMBGBLOBPH = "BroadcastingRoom";

		private const int BMBEHDNFHHL = 20000;

		private IILDCCEMGBA LCPOIILBNLD;

		private LKDMDLACMHN KLPJCNPJHEA;

		private FEEGDHIHCAJ EBBNKDFGAKL;

		private float NMHIDHFIEKC;

		private ExitGames.Client.Photon.Hashtable LOPPNBKCGMN;

		private readonly HashSet<int> MHLICMEIIHB;

		private LKGILLBEJEK PBJHLBNDJLE;

		private LKGILLBEJEK DDCMKGNMIBD;

		private readonly Dictionary<string, (int, long)> DNGAOJGLBMK;

		private readonly Dictionary<int, EventData> PLNBGGCHCAF;

		private int HADAKBKLBBM;

		private bool OLJAFEHCCDK;

		private bool IJKNNLEENEG;

		private string KLOHFPPLDEI;

		private bool HHPMFCMPFHI;

		private bool? BEPDBPIJDBI;

public global::HHOBPMOCKMJ<(long, int)> EventAuthorizationStatusChanged
{
get 		{
			return null;
		}

}

public bool IsInitialized
{
get 		{
			return false;
		}

}

public int TotalSubscribers
{
get 		{
			return 0;
		}

private set {
		}
}

public bool IsBroadcasting
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsInBroadcastingRoom
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsConnected
{
get 		{
			return false;
		}

}

public bool IsConnectedAndBroadcasting
{
get 		{
			return false;
		}

}

public string BroadcastChannel
{
get 		{
			return null;
		}

private set {
		}
}

private bool FLNHIMOKEIF
{
get 		{
			return false;
		}

}

		public void RequestEventBroadcastingAuthorization()
		{
		}

		public void SetEventBroadcastingAuthorizationStatus(int EJIHLJJMOBD, DNGGEIPPHLG AJLDNMPIGNP)
		{
		}

		private Dictionary<int, DNGGEIPPHLG> LBPCLDDGBBN(long JJLIIOCLCNA)
		{
			return null;
		}

		private void HLJEKOHLNJA(IDictionary<int, DNGGEIPPHLG> FJACKECBNOJ, int EJIHLJJMOBD, long NJJFDENHGKK, DNGGEIPPHLG AJLDNMPIGNP)
		{
		}

		[PBOMGCLBFHF]
		private void RPCSetEventBroadcastingAuthorization(long JJLIIOCLCNA, int EJIHLJJMOBD, DNGGEIPPHLG AJLDNMPIGNP)
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void GBEILGJPHID()
		{
		}

		private void FNFLINCHDCF(int EJIHLJJMOBD)
		{
		}

		private static bool MNGCMMHEEJH(PJFDADLIKCD KACGABCPLLE, long IBLBJPGGJME)
		{
			return false;
		}

		private IEnumerator<EGGPGCCKPCO> CAEDMNCDFFK()
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> NNIOLABMEDD()
		{
			return null;
		}

		private void OJGPLMMLJML(IMIJPHJKLIM IGGPIMCKMBP)
		{
		}

		public void Connect(IBINLLOMNPN EKOFNPFCLMO, CGOKGJPDIAF LMCAEKEFKCH, string LEGPGAPNFKC = null)
		{
		}

		public void Connect(CGOKGJPDIAF LMCAEKEFKCH, string LEGPGAPNFKC = null)
		{
		}

		private void PKPPBPPGMNI()
		{
		}

		private void BNKFCABEKME(Player EKOFNPFCLMO)
		{
		}

		private void DIJGOIHPCEM(PlayerEmotes.PDHFIKBMGOD ABDDCLHIIHG, string OFCFPGACNJB)
		{
		}

		private bool LMJHOPOAGJB(object PCPEJHIMHJJ)
		{
			return false;
		}

		public void StopBroadcasting(IBINLLOMNPN EKOFNPFCLMO)
		{
		}

		public void StopBroadcasting()
		{
		}

		public DNGGEIPPHLG? GetEventBroadcastingAuthorization(int EJIHLJJMOBD)
		{
			return null;
		}

		private void EPLEHJDMLAM()
		{
		}

		private void KLAGNHACFHO()
		{
		}

		private void CGCNKFOJMOG()
		{
		}

		private void KKKHNOCGJPF(object OFCFPGACNJB)
		{
		}

		void HDCOAHEBHMA.BHHMNJIIEFK(object OFCFPGACNJB)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KKKHNOCGJPF
			this.KKKHNOCGJPF(OFCFPGACNJB);
		}

		private void ACNCKBHPMEC(object[] PCPEJHIMHJJ)
		{
		}

		private void GPEEFKANIAI(int IPMIIEAGJKC)
		{
		}

		void HDCOAHEBHMA.KCLJJKHIBKK(int IPMIIEAGJKC)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GPEEFKANIAI
			this.GPEEFKANIAI(IPMIIEAGJKC);
		}

		private void HBCAIIMCPFO(object[] LPHIPOLKJOK)
		{
		}

		void HDCOAHEBHMA.IOLDLNIMKAH(object[] LPHIPOLKJOK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in HBCAIIMCPFO
			this.HBCAIIMCPFO(LPHIPOLKJOK);
		}

		private void ICCOFIBOFGC(BroadcastPlayerData JKDKPKBFNDE, ExitGames.Client.Photon.Hashtable LDIMFFPCKHP, EventData IJCJINCPEPA, EventData EPLDNJDHJIL, EventData PFBDMPLLHDN)
		{
		}

		private void CFLNNCPCBOA(string GOFMFBECJBN)
		{
		}

		private static void EBNOCDODIHH(object JDMBAKALLAE, int NPBNMKOMFOL)
		{
		}

		private static void BDDDOCFMMNN(bool AIKAIPNMIIH, JGFBFKNFLIN NAHFMOPKECC)
		{
		}

		private static string AHGODHPOOKP(bool AIKAIPNMIIH, JGFBFKNFLIN NAHFMOPKECC)
		{
			return null;
		}

		public override void OnDisconnected(ABKEPLHLDAN OAHKKMPJPPO)
		{
		}

		public override void OnCreateRoomFailed(short CBNAHBMFGMP, string OFCFPGACNJB)
		{
		}

		public override void OnLeftRoom()
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable ECEFLJDFNBM)
		{
		}

		private void DEIACKBFDKD(ExitGames.Client.Photon.Hashtable ECEFLJDFNBM)
		{
		}

		public override void OnEventSend(EventData ODLMFNNDEEF)
		{
		}

		private void GFACJBPFIIA(EventData ODLMFNNDEEF)
		{
		}

		[PBOMGCLBFHF]
		private void RPCClearBroadcastingRoomInstance()
		{
		}

		[PBOMGCLBFHF]
		private void RPCConnectPlayer(CGOKGJPDIAF LMCAEKEFKCH, string LCABDAFJKNN)
		{
		}

		[PBOMGCLBFHF]
		private void RPCStopBroadcastingPlayer()
		{
		}

		[CompilerGenerated]
		private void MOKGCGIPALF(IMIJPHJKLIM GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private void NOKBNEODBBL()
		{
		}

		[CompilerGenerated]
		private void MOHHCFPABCL(IMIJPHJKLIM GCBHEJANCJK)
		{
		}
	}
}
