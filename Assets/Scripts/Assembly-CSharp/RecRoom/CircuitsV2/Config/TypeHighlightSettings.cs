using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public sealed class TypeHighlightSettings
	{
		[SerializeField]
		private Color wireHighlightColor1;

		[SerializeField]
		private Color wireHighlightColor2;

		[SerializeField]
		private Color portHighlightColor;

		[SerializeField]
		private Color portHighlightEmissiveColor;

		public Color WireColor1 => default;

		public Color WireColor2 => default;

		public Color PortHighlightColor => default;

		public Color PortHighlightEmissiveColor => default;
	}
}
