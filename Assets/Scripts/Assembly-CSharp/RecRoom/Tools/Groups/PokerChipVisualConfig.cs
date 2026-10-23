using System;
using UnityEngine;

namespace RecRoom.Tools.Groups
{
	[Serializable]
	public class PokerChipVisualConfig : ScriptableObject
	{
		[Serializable]
		public struct ValueConfig
		{
			public PokerChip.LCOPHALNODP Value;

			public string Label;

			public Color ChipColor;

			public Color LabelColor;
		}

		[SerializeField]
		public ValueConfig[] ValueConfigs;
	}
}
