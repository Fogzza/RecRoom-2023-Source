using System;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class PenModeDependentScreen : MonoBehaviour
	{
		[Serializable]
		public struct PenModeMenuScreen
		{
			public HHNPLBOFAGE penMode;

			public GameObject toolSubScreen;

			public MakerPenToolRadioGroup screenRadioGroup;
		}

		[SerializeField]
		private PenModeMenuScreen[] modeSubScreens;

public PenModeMenuScreen CurrentMenuScreen
{
get 		{
			return default;
		}

}

		public void ShowModeScreen(HHNPLBOFAGE DNLPIHIBJDP)
		{
		}
	}
}
