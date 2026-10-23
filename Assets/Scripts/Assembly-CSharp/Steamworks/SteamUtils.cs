using System;

namespace Steamworks
{
	public static class SteamUtils
	{
		public static uint GetSecondsSinceAppActive()
		{
			return 0u;
		}

		public static uint GetSecondsSinceComputerActive()
		{
			return 0u;
		}

		public static EUniverse GetConnectedUniverse()
		{
			return EUniverse.k_EUniverseInvalid;
		}

		public static uint GetServerRealTime()
		{
			return 0u;
		}

		public static string GetIPCountry()
		{
			return null;
		}

		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight)
		{
			pnWidth = default;
			pnHeight = default;
			return false;
		}

		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize)
		{
			return false;
		}

		public static bool GetCSERIPPort(out uint unIP, out ushort usPort)
		{
			unIP = default;
			usPort = default;
			return false;
		}

		public static byte GetCurrentBatteryPower()
		{
			return 0;
		}

		public static AppId_t GetAppID()
		{
			return default;
		}

		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
		{
		}

		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed)
		{
			pbFailed = default;
			return false;
		}

		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall)
		{
			return ESteamAPICallFailure.k_ESteamAPICallFailureSteamGone;
		}

		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed)
		{
			pbFailed = default;
			return false;
		}

		public static uint GetIPCCallCount()
		{
			return 0u;
		}

		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
		}

		public static bool IsOverlayEnabled()
		{
			return false;
		}

		public static bool BOverlayNeedsPresent()
		{
			return false;
		}

		public static SteamAPICall_t CheckFileSignature(string szFileName)
		{
			return default;
		}

		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText)
		{
			return false;
		}

		public static uint GetEnteredGamepadTextLength()
		{
			return 0u;
		}

		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText)
		{
			pchText = null;
			return false;
		}

		public static string GetSteamUILanguage()
		{
			return null;
		}

		public static bool IsSteamRunningInVR()
		{
			return false;
		}

		public static void SetOverlayNotificationInset(int nHorizontalInset, int nVerticalInset)
		{
		}

		public static bool IsSteamInBigPictureMode()
		{
			return false;
		}

		public static void StartVRDashboard()
		{
		}

		public static bool IsVRHeadsetStreamingEnabled()
		{
			return false;
		}

		public static void SetVRHeadsetStreamingEnabled(bool bEnabled)
		{
		}

		public static bool IsSteamChinaLauncher()
		{
			return false;
		}

		public static bool InitFilterText()
		{
			return false;
		}

		public static int FilterText(out string pchOutFilteredText, uint nByteSizeOutFilteredText, string pchInputMessage, bool bLegalOnly)
		{
			pchOutFilteredText = null;
			return 0;
		}

		public static ESteamIPv6ConnectivityState GetIPv6ConnectivityState(ESteamIPv6ConnectivityProtocol eProtocol)
		{
			return ESteamIPv6ConnectivityState.k_ESteamIPv6ConnectivityState_Unknown;
		}
	}
}
