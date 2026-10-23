using System;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using TMPro;
using UnityEngine;

public class SendGiftScreen : WatchUIFlow
{
	private sealed class OGJNGFOKONP
	{
		public SendGiftScreen _003C_003E4__this;

		public long? initialBalance;

		internal void _003CButton_SendGift_003Eb__0(LKKOPNLCJBC.PurchaseBalanceUpdateResponseDTO<EDDPDJCKOBH.GMBCAMAAPMN> response)
		{
		}

		internal void _003CButton_SendGift_003Eb__1(string error)
		{
		}
	}

	private const int MJHFDMLEKFF = 100;

	[SerializeField]
	private ChoosePlayerDialog choosePlayerDialog;

	[SerializeField]
	private InputField3D inputField;

	[SerializeField]
	private TextMeshProUGUI charLeftText;

	[SerializeField]
	private ToggleButton3D sendAnonymousToggle;

	[SerializeField]
	private TextMeshProUGUI infoText;

	[SerializeField]
	private Button3D sendGiftButton;

	[SerializeField]
	private Button3D okBtton;

	private int DDHPDLENNIC;

	private int BIKOKEEEKLA;

	private long? PIMIBCHPEJJ;

	private bool NMDBPPBNLIB;

	private UIDialog<int> GLCBPBKDENI;

	private int PABFOCHOHPN;

	private FHPHMBKPLCC OCNGKLDCJKG;

	private long AJOGPANPPMN;

	private DBFJJLIGAFA OOOJNBODGPI;

	private Action<bool> KKNOMFJKNNH__BackingField;

public event Action<bool> OnSendGiftScreenExit {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	public override void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
	{
	}

	public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
	{
	}

	public void SetUpScreen(int IKHNIJKGJFD, FHPHMBKPLCC NJCNIFJHLNK, long PNNCCFDIMEP, DBFJJLIGAFA OPKDMEIFDHL, long? CLOMODJINAK, int APFNAOPENNF = -1)
	{
	}

	public void PopScreenIfCurrent()
	{
	}

	private void EBHOFFNMCAE(bool BMGEHFPFCBJ)
	{
	}

	private void PGOMGKMFIPG(long? NCFOPAPFAKL, int DDHPDLENNIC, string NLJOHEKGNDH = null)
	{
	}

	public void InputField_OnValueChange(string text)
	{
	}

	public void Button_Ok()
	{
	}

	public void Button_SendGift()
	{
	}

	[CompilerGenerated]
	private void HIOCKCKPBKJ(int IKHNIJKGJFD)
	{
	}
}
