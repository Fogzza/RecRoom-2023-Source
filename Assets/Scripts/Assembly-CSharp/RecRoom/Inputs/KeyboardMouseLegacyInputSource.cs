using System;
using UnityEngine;

namespace RecRoom.Inputs
{
	public class KeyboardMouseLegacyInputSource : LegacyInputSourceConfig<JHNBFEOJCEE, KeyboardMouseLegacyInputSource>
	{
		[Serializable]
		public class KeyboardMouseInputMap
		{
			public NBBJGMFGNIL inputType;

			public LegacyInputConfiguration config;

			public Sprite sprite;
		}

		public KeyboardMouseInputMap[] inputMap;
	}
}
