using System;
using UnityEngine;

namespace RecRoom.Tools.Groups
{
	[Serializable]
	public class PlayingCardVisualConfig : ScriptableObject
	{
		[Serializable]
		public struct SuitConfig
		{
			public PlayingCard.BMBNCFFNGPI Suit;

			public Sprite Sprite;

			public Color Color;
		}

		[Serializable]
		public struct ValueConfig
		{
			public PlayingCard.JCKHOIOKIEE Value;

			public string Label;
		}

		[SerializeField]
		public SuitConfig[] SuitConfigs;

		[SerializeField]
		public ValueConfig[] ValueConfigs;
	}
}
