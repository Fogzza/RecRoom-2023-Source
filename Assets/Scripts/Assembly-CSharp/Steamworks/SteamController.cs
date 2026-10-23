namespace Steamworks
{
	public static class SteamController
	{
		public static bool Init()
		{
			return false;
		}

		public static bool Shutdown()
		{
			return false;
		}

		public static void RunFrame()
		{
		}

		public static int GetConnectedControllers(ControllerHandle_t[] handlesOut)
		{
			return 0;
		}

		public static ControllerActionSetHandle_t GetActionSetHandle(string pszActionSetName)
		{
			return default;
		}

		public static void ActivateActionSet(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle)
		{
		}

		public static ControllerActionSetHandle_t GetCurrentActionSet(ControllerHandle_t controllerHandle)
		{
			return default;
		}

		public static void ActivateActionSetLayer(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle)
		{
		}

		public static void DeactivateActionSetLayer(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetLayerHandle)
		{
		}

		public static void DeactivateAllActionSetLayers(ControllerHandle_t controllerHandle)
		{
		}

		public static int GetActiveActionSetLayers(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t[] handlesOut)
		{
			return 0;
		}

		public static ControllerDigitalActionHandle_t GetDigitalActionHandle(string pszActionName)
		{
			return default;
		}

		public static InputDigitalActionData_t GetDigitalActionData(ControllerHandle_t controllerHandle, ControllerDigitalActionHandle_t digitalActionHandle)
		{
			return default;
		}

		public static int GetDigitalActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerDigitalActionHandle_t digitalActionHandle, EControllerActionOrigin[] originsOut)
		{
			return 0;
		}

		public static ControllerAnalogActionHandle_t GetAnalogActionHandle(string pszActionName)
		{
			return default;
		}

		public static InputAnalogActionData_t GetAnalogActionData(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t analogActionHandle)
		{
			return default;
		}

		public static int GetAnalogActionOrigins(ControllerHandle_t controllerHandle, ControllerActionSetHandle_t actionSetHandle, ControllerAnalogActionHandle_t analogActionHandle, EControllerActionOrigin[] originsOut)
		{
			return 0;
		}

		public static string GetGlyphForActionOrigin(EControllerActionOrigin eOrigin)
		{
			return null;
		}

		public static string GetStringForActionOrigin(EControllerActionOrigin eOrigin)
		{
			return null;
		}

		public static void StopAnalogActionMomentum(ControllerHandle_t controllerHandle, ControllerAnalogActionHandle_t eAction)
		{
		}

		public static InputMotionData_t GetMotionData(ControllerHandle_t controllerHandle)
		{
			return default;
		}

		public static void TriggerHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec)
		{
		}

		public static void TriggerRepeatedHapticPulse(ControllerHandle_t controllerHandle, ESteamControllerPad eTargetPad, ushort usDurationMicroSec, ushort usOffMicroSec, ushort unRepeat, uint nFlags)
		{
		}

		public static void TriggerVibration(ControllerHandle_t controllerHandle, ushort usLeftSpeed, ushort usRightSpeed)
		{
		}

		public static void SetLEDColor(ControllerHandle_t controllerHandle, byte nColorR, byte nColorG, byte nColorB, uint nFlags)
		{
		}

		public static bool ShowBindingPanel(ControllerHandle_t controllerHandle)
		{
			return false;
		}

		public static ESteamInputType GetInputTypeForHandle(ControllerHandle_t controllerHandle)
		{
			return ESteamInputType.k_ESteamInputType_Unknown;
		}

		public static ControllerHandle_t GetControllerForGamepadIndex(int nIndex)
		{
			return default;
		}

		public static int GetGamepadIndexForController(ControllerHandle_t ulControllerHandle)
		{
			return 0;
		}

		public static string GetStringForXboxOrigin(EXboxOrigin eOrigin)
		{
			return null;
		}

		public static string GetGlyphForXboxOrigin(EXboxOrigin eOrigin)
		{
			return null;
		}

		public static EControllerActionOrigin GetActionOriginFromXboxOrigin(ControllerHandle_t controllerHandle, EXboxOrigin eOrigin)
		{
			return EControllerActionOrigin.k_EControllerActionOrigin_None;
		}

		public static EControllerActionOrigin TranslateActionOrigin(ESteamInputType eDestinationInputType, EControllerActionOrigin eSourceOrigin)
		{
			return EControllerActionOrigin.k_EControllerActionOrigin_None;
		}

		public static bool GetControllerBindingRevision(ControllerHandle_t controllerHandle, out int pMajor, out int pMinor)
		{
			pMajor = default;
			pMinor = default;
			return false;
		}
	}
}
