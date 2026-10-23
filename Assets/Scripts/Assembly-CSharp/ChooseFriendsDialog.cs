using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using RecRoom.AGUI;
using TMPro;
using UnityEngine;

public class ChooseFriendsDialog : UIDialog<ChooseFriendsDialog.GBPODKEPHEM, FMEDMCFGHFM, List<DFDECAEJBIO>>
{
	public enum GBPODKEPHEM
	{
		Invalid = 0,
		StartChat = 1,
		AddPlayer = 2,
		ListMembers = 3
	}

	[SerializeField]
	private ScreenHeader screenHeader;

	[SerializeField]
	private ChooseFriendPagedGrid pagedGrid;

	[SerializeField]
	private GameObject contextRow;

	[SerializeField]
	private GameObject toTextContainer;

	[SerializeField]
	private TextMeshProUGUI playerNames;

	[SerializeField]
	private Button3D startChatButton;

	[SerializeField]
	private Button3D addPlayerButton;

	[SerializeField]
	private TextMeshProUGUI infoText;

	private List<DFDECAEJBIO> PNHILOECLKG;

	private FMEDMCFGHFM OKLCJNODHPF;

	private GBPODKEPHEM CIECFEBDHMM;

private GBPODKEPHEM HJFFDKOMMCN
{
get 	{
		return GBPODKEPHEM.Invalid;
	}

set {
	}
}

	public override global::NCOKFFGPIJM<List<DFDECAEJBIO>> ShowDialog(GBPODKEPHEM DNLPIHIBJDP, FMEDMCFGHFM AAMFKNLLGDC)
	{
		return null;
	}

	public override void ForceCancel(bool OANFJFDMNOM)
	{
	}

	private void OHLDNFLHCIJ()
	{
	}

	private void POIGHLNLMBL(DFDECAEJBIO ACBGBAAHOIM)
	{
	}

	public void SelectedAccountsUpdated(List<DFDECAEJBIO> newAccounts)
	{
	}

	public void Button_StartChat()
	{
	}

	public void Button_AddPlayer()
	{
	}

	[CompilerGenerated]
	private bool FBEJHMNLELJ(DFDECAEJBIO NNMPJECKECI)
	{
		return false;
	}

	[CompilerGenerated]
	private bool DOBAPHPPADM(DFDECAEJBIO NNMPJECKECI)
	{
		return false;
	}

	[CompilerGenerated]
	private void HCIJGJCJOFN(HEIHKKOLIID CDNLFEOBNKB)
	{
	}
}
