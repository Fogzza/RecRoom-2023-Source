using System;
using TMPro;
using UnityEngine;

namespace AGUI
{
	public class FriendlyIntButton : MonoBehaviour
	{
		public delegate void GBMEMNOBHPL(int IPMIIEAGJKC);

		[Serializable]
		public struct FriendlyIntConfig
		{
			public string FriendlyString;

			public string Tooltip;

			public int Value;

			public GBMEMNOBHPL OnSelected;
		}

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private Tooltip tooltip;

		private int ABGNFCJCFOH;

		private GBMEMNOBHPL IOHDPOJCMAH;

public int Value
{
get 		{
			return 0;
		}

private set {
		}
}

		public void SetConfig(FriendlyIntConfig FPJKGKBOAOA)
		{
		}

		public void Button_OnClick()
		{
		}
	}
}
