using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Realtime;
using RecRoom.Broadcasting;
using UnityEngine;

public class PUNNetworkManager : NetworkedSingletonMonoBehaviour<PUNNetworkManager>
{
	private sealed class LFEDHEPBHMH
	{
		public DFDECAEJBIO account;

		internal void _003CRpcPlayerSwitchedActivity_003Eb__0(string sanitizedDestination)
		{
		}
	}

	private sealed class AKAFGIPJGHC
	{
		public Player currentMaster;

		internal bool _003CCalculateBestCandidatePlayer_003Eb__1(Player p)
		{
			return false;
		}
	}

	private const string IJGKDBJBBOF = "+join:";

	private const string CGHBGEKCDMC = "9372aa8d-d3f4-44a0-986d-419e145a2b83";

	private const string FMKKBNCNKOE = "e93ae440-f238-4b6c-848f-1df89faf14f5";

	private const string CIBDHFNDBDD = "db7300fd-ac24-4e14-9dca-2bd685a7924f";

	private const int GLFIPPEIIFM = 30;

	private const int DCNJJGNILBP = 15;

	public static readonly Hashtable PhotonRoomPropertiesBugWorkaround;

	private const float MJPENJEAINB = 600f;

	private readonly Func<float> MIHGDAHPPKM;

	public AnimationCurve DynamicNetworkExtrapolationCurve;

	[SerializeField]
	private BroadcastingManager broadcastingManager;

	[SerializeField]
	private string disconnectAlertTitle;

	[SerializeField]
	private string timeoutCouldntConnectMessage;

	[SerializeField]
	private string timeoutDisconnectMessage;

	[SerializeField]
	private string genericDisconnectMessage;

	[SerializeField]
	private string playerJoinFailTitle;

	[SerializeField]
	private string playerJoinFailFullGameMessage;

	[SerializeField]
	private string playerJoinFailGenericMessage;

	[SerializeField]
	private string activitySwitchFailTitle;

	[SerializeField]
	private string activitySwitchFailFullGameMessage;

	[SerializeField]
	private string activitySwitchFailGenericMessage;

	[SerializeField]
	private string activitySwitchFailEventNotFoundMessage;

	[SerializeField]
	private string activitySwitchFailEventNotReadyMessage;

	private readonly GNHNKKFOPNJ GKDLOJLBHAJ;

	private IILDCCEMGBA LCPOIILBNLD;

	private JLJEJNFJIDP GCOGGHDIHNM;

	private AAAGDGIALHB EDOPJPEHLKI;

	private Action<CHILKDJABBF> LKIMFPLKDJD__BackingField;

	public global::HHOBPMOCKMJ<LCEKCFEIEGJ> OnJoiningRoom;

	private static AGCDMBNLFFM DBIKGOGJDCC;

	private int AJCCPAIBBAM;

	private bool NJMCICKMJGG;

	private ELICKFMHLPI FBPEBGGDPPL;

	private global::JEKNBGHMBJN<MFEHAEMCKCJ> PKJAFPALCKI;

public BroadcastingManager BroadcastingManager
{
get 	{
		return null;
	}

}

public string CurrentPhotonRegion
{
get 	{
		return null;
	}

}

public bool IsJoiningRoom
{
get 	{
		return false;
	}

}

public static AGCDMBNLFFM SynchronizedFieldNetworkBacking
{
get 	{
		return null;
	}

}

public int LastRoomPlayerCount
{
get 	{
		return 0;
	}

private set {
	}
}

public bool LastRoomWasLocalPlayerMaster
{
get 	{
		return false;
	}

private set {
	}
}

public string RichJoinCommand
{
get 	{
		return null;
	}

}

public static JLJEJNFJIDP PhotonNetworkedObjectBacking
{
get 	{
		return null;
	}

}

public event Action<CHILKDJABBF> PhotonPlayerDisconnected {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	private void LMONKDEFMDP()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void SetPhotonPauseState(object IALNODEHBNN, bool AEINBIKHGME)
	{
	}

	public global::NCOKFFGPIJM<IReadOnlyDictionary<string, int>> PingPhotonRegions()
	{
		return null;
	}

	public void Initialize()
	{
	}

	private void OGEOOOLPEJD()
	{
	}

	private void KDELGLNBFAF(GHCCKFEJDOA ICHBECDKHOJ)
	{
	}

	private void BLKJJBIOCEC()
	{
	}

	public void PrefetchInitialRoomDetails()
	{
	}

	public void SetPhotonRegionPreconnectionPings(IReadOnlyDictionary<string, int> ILKKDBDLPPE)
	{
	}

	private global::NCOKFFGPIJM<LCEKCFEIEGJ> PECDNNDGOJJ(long EPOBIFCHLNM)
	{
		return null;
	}

	[PBOMGCLBFHF]
	public void RpcPlayerSwitchedActivity(int EJIHLJJMOBD, string FMECHJDDNAF, long EPOBIFCHLNM)
	{
	}

	private static void LPIFEKJKKBP(string KKMCHAOLGFB, string LBGBFPDNKOL)
	{
	}

	[PBOMGCLBFHF]
	private void RpcPhotonRoundTrip(int AMMLAHNGBBA, int AMGNCPLIAAC)
	{
	}

	public Task PhotonRoundTrip(CancellationToken NDKAKDJMDIF = default(CancellationToken))
	{
		return null;
	}

	private void OnLeftRoom()
	{
	}

	private static AppSettings AALEDKJKEPO(string GEFPFIHEHPJ, bool BKOEPKFCAPC = false)
	{
		return null;
	}

	public static ChatAppSettings ConstructPhotonChatAppSettings()
	{
		return null;
	}

	private static string FIMOFGMNCFL()
	{
		return null;
	}

	private void OnConnectedToMaster()
	{
	}

	private void ELCFKDPEMLJ()
	{
	}

	private void OnJoinedRoom()
	{
	}

	public void SendPendingPlayerUpdates()
	{
	}

	public void SendPendingRoomUpdates()
	{
	}

	private void OnPhotonJoinRoomFailed(short DLBDGNBGNAC, string DCKDEBKEBNL)
	{
	}

	private void OnConnectionFail(ABKEPLHLDAN OAHKKMPJPPO)
	{
	}

	private void OnCustomAuthenticationFailed(string CKHHGBNHHCK)
	{
	}

	private void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void OnPhotonPlayerConnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void OnMasterClientSwitched(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void MasterSendRemotePlayerRecNetDisconnect(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public bool MasterSwitchToBestCandidatePlayer()
	{
		return false;
	}

	public bool CalculateBestCandidatePlayer(out Player PJCFBFGLLMI)
	{
		PJCFBFGLLMI = null;
		return false;
	}

	public bool TryTakeMasterFromBackgroundedExistingMaster()
	{
		return false;
	}

	private void NBFEKLLGPJO(HNGAMKHHDOD PIPCMEFGJAI)
	{
	}

	public void ProcessRichJoinCommand(string DBLFEEHBMEF)
	{
	}

	public static int? GetCommandLineArgsRichPresenceJoinPlayerId()
	{
		return null;
	}

	public CHILKDJABBF DebugChangeMasterClient()
	{
		return null;
	}

	public static void ConditionalDebugLog(string OFCFPGACNJB)
	{
	}

	public static void ConditionalDebugLogWarning(string OFCFPGACNJB)
	{
	}
}
