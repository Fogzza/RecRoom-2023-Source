using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WhiteboardPenPalette : ScriptableObject
{
	[Serializable]
	public struct PenColors
	{
		public string name;

		public Color penColor;
	}

	public List<PenColors> colors;
}
