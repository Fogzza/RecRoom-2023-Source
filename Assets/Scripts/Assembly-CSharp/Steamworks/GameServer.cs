namespace Steamworks
{
	public static class GameServer
	{
		public static bool Init(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString)
		{
			return false;
		}

		public static void Shutdown()
		{
		}

		public static void RunCallbacks()
		{
		}

		public static void ReleaseCurrentThreadMemory()
		{
		}

		public static bool BSecure()
		{
			return false;
		}

		public static CSteamID GetSteamID()
		{
			return default;
		}

		public static HSteamPipe GetHSteamPipe()
		{
			return default;
		}

		public static HSteamUser GetHSteamUser()
		{
			return default;
		}
	}
}
