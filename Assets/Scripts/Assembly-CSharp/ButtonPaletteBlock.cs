using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonPaletteBlock : ScriptableObject
{
	[Serializable]
	public class ButtonPalette
	{
		public string name;

		public Color BaseColor;

		public Color ToggleColor;
	}

	public ColorBlock SelectionColorModifiers;

	public ButtonPalette[] paletteBlock;
}
