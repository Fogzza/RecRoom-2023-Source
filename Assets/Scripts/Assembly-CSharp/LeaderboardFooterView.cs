using System;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardFooterView : ProjectorUIElementView
{
	[Serializable]
	private struct ButtonColumnView
	{
		public GameObject ButtonColumn;

		public Button Button;

		public Text ButtonText;
	}

	[SerializeField]
	private ButtonColumnView statTypeButtonColumn;

	[SerializeField]
	private ButtonColumnView timeSpanButtonColumn;

	[SerializeField]
	private ButtonColumnView userSetButtonColumn;

	private const string LHJCDLGPCEF = "ALL TIME";

	private const string FHCKGBEIMBF = "GLOBAL";

	private const string IMGLFFBMHLG = "FRIENDS";

	private const string JMBPDEGMGBO = "CHAMPIONS";

	public void SetDataModel(KHGHNOPJDAI LFKKJIFPEMA)
	{
	}
}
