using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom
{
	public class InventionFilterButtonIconMap : ScriptableObject
	{
		[Serializable]
		private struct FilterToIconMapping
		{
			public string FilterName;

			public Sprite Icon;

			public string Tooltip;
		}

		[SerializeField]
		private FilterToIconMapping[] Mappings;

		[NonSerialized]
		private readonly Dictionary<string, FilterToIconMapping> mappingsDict;

		[NonSerialized]
		private bool initialized;

		public Sprite IACJCKCDBIH(string IHKEKMIDCMF)
		{
			return null;
		}

		public string EKBNFAIHAIC(string IHKEKMIDCMF)
		{
			return null;
		}

		private void IHEKMEOIBOI()
		{
		}
	}
}
