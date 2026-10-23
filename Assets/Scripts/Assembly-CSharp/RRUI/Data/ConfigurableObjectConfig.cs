using UnityEngine;

namespace RRUI.Data
{
	public class ConfigurableObjectConfig : ScriptableObject
	{
		private static ConfigurableObjectConfig _instance;

		public GameObject defaultPrefabForPickerDialog;

		public GameObject radioButtonPrefabForPickerDialog;

		public GameObject defaultCardForGridPickerDialog;

		public GameObject defaultItemCardForPaletteSearch;

		public GameObject defaultItemCardForPickerDialog;

		public GameObject defaultItemCardForConsumable;

		public GameObject materialPickerCard;

		public GameObject colorPickerCard;

		public GameObject defaultItemCardForChooseFreeGiftConsumable;

		public GameObject saveHistoryCard;

		public Sprite colorPickerButtonSprite;

		public static ConfigurableObjectConfig Instance => null;
	}
}
