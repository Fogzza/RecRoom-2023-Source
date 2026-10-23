using System;
using TMPro;
using UnityEngine;

namespace AGUI
{
	public class FriendlyGuidButton : MonoBehaviour
	{
		public delegate void NMCAGJKOAAD(Guid IPMIIEAGJKC);

		public interface LJECGMLHJAB
		{

 string BINIHGKGLJD
{
get ;
}

 string FMBEEICPGAN
{
get ;
}

 Guid HHDPKELHGKE
{
get ;
}
		}

		[Serializable]
		public struct FriendlyGuidConfig
		{
			public string FriendlyString;

			public string Tooltip;

			public Guid Value;

			public NMCAGJKOAAD OnSelected;
		}

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private Tooltip tooltip;

		private Guid ABGNFCJCFOH;

		private NMCAGJKOAAD LNNKKCMIDBL;

public Guid Value
{
get 		{
			return default;
		}

private set {
		}
}

		public void SetConfig(FriendlyGuidConfig FPJKGKBOAOA)
		{
		}

		public void Button_OnClick()
		{
		}
	}
}
