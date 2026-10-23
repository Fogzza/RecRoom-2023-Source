using System;
using System.Runtime.CompilerServices;
using RecRoom.Inputs;
using UnityEngine;

namespace RecRoom.Systems
{
	public class InputManager : SingletonMonoBehaviour<InputManager>
	{
		public enum NHOLCEAFIFN
		{
			Not_Supported = 0,
			SteamVR_Vive = 1,
			SteamVR_Oculus = 2,
			SteamVR_WindowsMR = 3,
			Oculus_Rift = 4,
			PS4_Move = 5,
			Oculus_Quest = 7,
			SteamVR_Index = 8,
			Mock_Input = 9,
			PicoNeo3 = 10,
			PicoPhoenix = 11
		}

		public enum AAPGMMJNIMD
		{
			Not_Supported = 0,
			PC = 1,
			PS4_DualShock = 2,
			Mobile = 3
		}

		[Serializable]
		private class VRConfiguration
		{
			public NHOLCEAFIFN InputMode;

			public VRInputConfiguration InputConfiguration;
		}

		private sealed class EPFGKFPMDFP
		{
			public string controlSchemeKey;

			internal bool _003CGetActionInputMapForControlSchemeKey_003Eb__0(ScreenPlayerActionInputMap pairing)
			{
				return false;
			}
		}

		public const string DEFAULT_CONTROL_SCHEME_KEY = "DEFAULT";

		public Action VRInputHandlersChangedEvent;

		[SerializeField]
		private VRConfiguration[] vrConfigurations;

		[SerializeField]
		private ScreenControlsMap screenControlMap;

		[SerializeField]
		private ScreenPlayerActionInputMap[] screensControlSchemesArray;

		[SerializeField]
		private ScreenPlayerActionDefinitions screensActionDefinitions;

		[SerializeField]
		private InputSourceConfigBase[] screenInputSourceConfigs;

		[SerializeField]
		private MockGamepadInputSource mockGamepadInputSource;

		private NHOLCEAFIFN FAJKKOECGMB;

		private AAPGMMJNIMD OKBLFOAGJLK;

		private VRInputConfiguration MHPKHILJBLE;

		private VRInputHandler JDGMFDFDMNM;

		private VRInputHandler LBMJALKLPFD;

		private VRInputConfiguration FHKEGFBCBCL;

		private AECAHLPIFOC CMNBIDEHMFL;

		private bool FKEDPFLEJHB;

public ScreenPlayerActionInputMap[] ScreensControlSchemesArray
{
get 		{
			return null;
		}

}

public ScreenPlayerActionDefinitions ScreenPlayerActionDefinitions
{
get 		{
			return null;
		}

}

public NHOLCEAFIFN SupportedVRInputDeviceType
{
get 		{
			return NHOLCEAFIFN.Not_Supported;
		}

private set {
		}
}

public AAPGMMJNIMD SupportedScreenInputDeviceType
{
get 		{
			return AAPGMMJNIMD.Not_Supported;
		}

private set {
		}
}

public KLIMDPGKKGM ScreensInputMode
{
get 		{
			return KLIMDPGKKGM.GAMEPAD;
		}

}

public VRInputHandler LeftHandVRInputHandler
{
get 		{
			return null;
		}

}

public VRInputConfiguration LeftHandVRConfig
{
get 		{
			return null;
		}

}

public VRInputHandler RightHandVRInputHandler
{
get 		{
			return null;
		}

}

public VRInputConfiguration RightHandVRConfig
{
get 		{
			return null;
		}

}

public AECAHLPIFOC ScreenInputHandler
{
get 		{
			return null;
		}

private set {
		}
}

public bool CanChangeControlSchemes
{
get 		{
			return false;
		}

}

public bool HasAppliedSplitTestControlSettings
{
get 		{
			return this.FKEDPFLEJHB;
		}

private set {
			this.FKEDPFLEJHB = value;
		}
}

public bool VRNaturalGripSupported
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void OnUpdate()
		{
		}

		private ScreenPlayerActionInputMap EBHOAJBIGKN(string DEBCMGPAPBE)
		{
			return null;
		}

		public void UpdateScreenControlScheme()
		{
		}

		private bool BHCGCCCJNAH()
		{
			return false;
		}

		private void CLPGGGBIDGE()
		{
		}

		private void CLPGGGBIDGE(bool COPOILGLIAJ)
		{
		}

		private VRInputHandler NELKNJDEGNF(NHOLCEAFIFN IJAFKBJIGBI, VRTrackedController.EGONEFPMCNI BNNHCJJILFB, out VRInputConfiguration OKOEDFKLCGK)
		{
			OKOEDFKLCGK = null;
			return null;
		}

		private void JEDNHPOAOOK()
		{
		}

		private NHOLCEAFIFN GGELIFCFAJK()
		{
			return NHOLCEAFIFN.Not_Supported;
		}

		private bool DFCPHHJOAPA()
		{
			return false;
		}

		private AAPGMMJNIMD FDEINEMMIPO()
		{
			return AAPGMMJNIMD.Not_Supported;
		}

		private void DNONENAIGBA()
		{
		}

		public void ApplySplitTestControlSettings()
		{
		}

		[CompilerGenerated]
		private bool FAFNCPALHDJ(ScreenPlayerActionInputMap JABJBEKEGLK)
		{
			return false;
		}
	}
}
