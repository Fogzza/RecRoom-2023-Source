using System;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RecRoom.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReportWatchUIFlow : PlayerWatchUIFlow
{
	[SerializeField]
	private ToggleGroup3D toggleGroup;

	[SerializeField]
	private ToggleButton3D underageToggle;

	[SerializeField]
	private ToggleButton3D sexualBehaviorToggle;

	[SerializeField]
	private ToggleButton3D gameExploitToggle;

	[SerializeField]
	private ToggleButton3D discriminatoryBehaviorToggle;

	[SerializeField]
	private ToggleButton3D inapproriateNameToggle;

	[SerializeField]
	private InputField3D descriptionTextField;

	[SerializeField]
	private TextMeshProUGUI charCount;

	[SerializeField]
	private Button3D submitButton;

	[SerializeField]
	private DropdownWrapper descriptionDropDown;

	private WatchUI GBAAIDEGHBF;

	private string ONFJHOLIKPH;

	private string DLMKDNPFLMD;

	private IBPKDJLFBHM.OMLBCKDFMHL DEINDEBHFHF;

	public Action<ReportWatchUIFlow> CreateReportAction;

	public Func<ReportWatchUIFlow, bool> CanIssueReportAction;

	public Action OnReportedAction;

public IBPKDJLFBHM.OMLBCKDFMHL Category
{
get 	{
		return IBPKDJLFBHM.OMLBCKDFMHL.Unknown;
	}

private set {
	}
}

	private void Start()
	{
	}

	public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
	{
	}

	public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
	{
	}

	private void PJBMAENFMNM(bool BMGEHFPFCBJ)
	{
	}

	public void ClearForm()
	{
	}

	public override void SetAccount(DFDECAEJBIO ACBGBAAHOIM)
	{
	}

	public void SelectCategory(IBPKDJLFBHM.OMLBCKDFMHL JNKJFJLJKNJ, int NCFLAGPPHFI = 0)
	{
	}

	public void SetAdditionalDescriptionPrefix(string KHCNDENCFFO)
	{
	}

	public void SetAdditionalDescriptionPostfix(string PKMIPBHPANP)
	{
	}

	public string GetFullDescription()
	{
		return null;
	}

	private void BEMPABLLHMC(IBPKDJLFBHM.OMLBCKDFMHL JNKJFJLJKNJ, int NCFLAGPPHFI = 0)
	{
	}

	private ToggleButton3D JNELDEHICGD(IBPKDJLFBHM.OMLBCKDFMHL JNKJFJLJKNJ)
	{
		return null;
	}

	public void Toggle_DropdownSelected(Dropdown dropdown)
	{
	}

	public void Toggle_Underage(bool isOn)
	{
	}

	public void Toggle_SexualBehavior(bool isOn)
	{
	}

	public void Toggle_DiscriminatoryBehavior(bool isOn)
	{
	}

	public void Toggle_Trolling(bool isOn)
	{
	}

	public void Toggle_Inappropriate(bool isOn)
	{
	}

	public void Toggle_InappropriateClothing(bool isOn)
	{
	}

	public void Button_Submit()
	{
	}

	public void OnTextValueChanged(string newText)
	{
	}

	[CompilerGenerated]
	private void ANLOMIABNMH(HGKINAOMNIF GOJCEBCMFJK)
	{
	}
}
