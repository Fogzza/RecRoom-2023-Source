namespace Steamworks
{
	public static class SteamNetworking
	{
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0)
		{
			return false;
		}

		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0)
		{
			pcubMsgSize = default;
			return false;
		}

		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0)
		{
			pcubMsgSize = default;
			psteamIDRemote = default;
			return false;
		}

		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote)
		{
			return false;
		}

		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote)
		{
			return false;
		}

		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel)
		{
			return false;
		}

		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState)
		{
			pConnectionState = default;
			return false;
		}

		public static bool AllowP2PPacketRelay(bool bAllow)
		{
			return false;
		}

		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, SteamIPAddress_t nIP, ushort nPort, bool bAllowUseOfPacketRelay)
		{
			return default;
		}

		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay)
		{
			return default;
		}

		public static SNetSocket_t CreateConnectionSocket(SteamIPAddress_t nIP, ushort nPort, int nTimeoutSec)
		{
			return default;
		}

		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			return false;
		}

		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			return false;
		}

		public static bool SendDataOnSocket(SNetSocket_t hSocket, byte[] pubData, uint cubData, bool bReliable)
		{
			return false;
		}

		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize)
		{
			pcubMsgSize = default;
			return false;
		}

		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize)
		{
			pcubMsgSize = default;
			return false;
		}

		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			pcubMsgSize = default;
			phSocket = default;
			return false;
		}

		public static bool RetrieveData(SNetListenSocket_t hListenSocket, byte[] pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			pcubMsgSize = default;
			phSocket = default;
			return false;
		}

		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out SteamIPAddress_t punIPRemote, out ushort punPortRemote)
		{
			pSteamIDRemote = default;
			peSocketStatus = default;
			punIPRemote = default;
			punPortRemote = default;
			return false;
		}

		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out SteamIPAddress_t pnIP, out ushort pnPort)
		{
			pnIP = default;
			pnPort = default;
			return false;
		}

		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket)
		{
			return ESNetSocketConnectionType.k_ESNetSocketConnectionTypeNotConnected;
		}

		public static int GetMaxPacketSize(SNetSocket_t hSocket)
		{
			return 0;
		}
	}
}
