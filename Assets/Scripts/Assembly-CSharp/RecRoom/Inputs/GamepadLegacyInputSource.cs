using System;
using UnityEngine;

namespace RecRoom.Inputs
{
	public class GamepadLegacyInputSource : LegacyInputSourceConfig<NNFNDHCEPKO, GamepadLegacyInputSource>
	{
		public enum AOGHKCPODJP
		{
			PlayStationDualshock = 0,
			XboxAndMFi = 1
		}

		[Serializable]
		public class GamepadInputMap
		{
			public KCPKKLFAKBP inputType;

			[SerializeField]
			private LegacyInputConfiguration pcConfig;

			[SerializeField]
			private LegacyInputConfiguration ps4Config;

			[SerializeField]
			private LegacyInputConfiguration iOSConfig;

			public Sprite defaultSprite;

			public Sprite Sprite => null;

			public LegacyInputConfiguration PlatformAppropriateConfig => null;
		}

		public GamepadInputMap[] inputMap;

		public EEHLPCMAENF gamepadType;

		public bool supportsPC;

		public string[] pcDeviceNames;

		public bool supportsPS4;

		public bool supportsIOS;

		public AOGHKCPODJP iOSGamepadProfile;

		public bool supportsXbox;
	}
}
