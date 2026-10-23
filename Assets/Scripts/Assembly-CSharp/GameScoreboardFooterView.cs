using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreboardFooterView : ProjectorUIElementView
{
	[Serializable]
	private struct ButtonColumnView
	{
		public GameObject ButtonColumn;

		public Button Button;

		public Text ButtonText;
	}

	[SerializeField]
	private GameObject configRow;

	[SerializeField]
	private Text configText;

	[SerializeField]
	private GameObject buttonRow;

	[SerializeField]
	private ButtonColumnView joinGameButtonColumn;

	[SerializeField]
	private ButtonColumnView startGameButtonColumn;

	[SerializeField]
	private ButtonColumnView startOverGameButtonColumn;

	[SerializeField]
	private Button startGameEarlyButton;

	[SerializeField]
	private ButtonColumnView switchTeamButtonColumn;

	[SerializeField]
	private ButtonColumnView switchNextMapButtonColumn;

	[SerializeField]
	private GameObject nextMapLabelColumn;

	[SerializeField]
	private Text nextMapLabelText;

	[SerializeField]
	private ButtonColumnView viewResultsButtonColumn;

	[SerializeField]
	private Tooltip startGameButtonTooltip;

	private const string BJAEGCAANFH = "JOINING...";

	private const string KLBJHLAMEKL = "JOIN";

	private const string MKKLJHLGMCL = "SPECTATE";

	private const string MHEDDKFGIHG = "NEXT";

	private const string GGBDBOLFCPK = "RESULTS";

	private const string AJLFEHONKFO = "START";

	private const string NLPAOGDLHCM = "CONTINUE";

	private const string BBOJBJHAFOD = " required to start";

public bool CanStartGameEarly
{
get 	{
		return false;
	}

}

	public void SetGameModel(FFEFOIBOLLC DADHJJNJEFA, DDGAHBEDBCL LFKKJIFPEMA)
	{
	}
}
