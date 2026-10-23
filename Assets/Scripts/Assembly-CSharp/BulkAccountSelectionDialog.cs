using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using AGUI.StackedUI.Dialog;
using RecRoom.AGUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulkAccountSelectionDialog : UIDialog<BulkAccountSelectionDialog.AMDIPFKFHCC, BulkAccountSelectionDialog.GGLKDINOLHA>
{
	public class GGLKDINOLHA
	{
		public IReadOnlyList<DFDECAEJBIO> PGJCECJPJMD;

		public HGKINAOMNIF IAMHCABOCOA;
	}

	public enum CFGKBDNCNJK
	{
		Friends = 0,
		Nearby = 1
	}

	public class AMDIPFKFHCC
	{
		public HashSet<int> BENFPOJOHPI;

		public bool APNPEDDDMHO;

		public bool PPLGEDOKKAD;

		public string FDLAOOHDJAE;
	}

	private enum FGKJENBBNJM
	{
		SelectAll = 0,
		SelectNone = 1
	}

	private sealed class AOOBGOKBFIP
	{
		public IEnumerable<DFDECAEJBIO> accounts;

		internal void _003CGetAccountsForIds_003Eb__0(List<DFDECAEJBIO> result)
		{
		}

		internal void _003CGetAccountsForIds_003Eb__1(string error)
		{
		}
	}

	private static GGLKDINOLHA DOGEAFKMMMO;

	[SerializeField]
	private CFGKBDNCNJK defaultAccountSource;

	[SerializeField]
	private GameObject promptRow;

	[SerializeField]
	private Text promptText;

	[SerializeField]
	private RadioButton3D friendsRadioButton;

	[SerializeField]
	private RadioButton3D nearbyRadioButton;

	[SerializeField]
	private Button3D submitButton;

	[SerializeField]
	private Text accountNamesText;

	[SerializeField]
	private SelectAccountButtonsPagedGrid selectAccountsPagedGrid;

	[SerializeField]
	private TMP_InputField filterInputField;

	[SerializeField]
	private Subscreen selectAccountsSubscreen;

	[SerializeField]
	private GameObject selectedAccountsContextRow;

	[SerializeField]
	private GameObject searchAccountsRow;

	[SerializeField]
	[Multiline]
	private string noFriendsOnlineText;

	[SerializeField]
	[Multiline]
	private string noFriendsOnlineOrOfflineText;

	[SerializeField]
	[Multiline]
	private string noNearbyPlayersText;

	[SerializeField]
	private TMP_Text toggleBulkSelectButtonLabel;

	[SerializeField]
	private string selectAllLabelText;

	[SerializeField]
	private string selectNoneLabelText;

	private CFGKBDNCNJK MEOACAJBPBN;

	private IReadOnlyList<DFDECAEJBIO> ODOMLNOMADF;

	private IReadOnlyList<DFDECAEJBIO> CFIKKNDMAIK;

	private IReadOnlyList<DFDECAEJBIO> PNHILOECLKG;

	private HashSet<int> KLEDEGAIOAP;

	private HIGPLMIBJJI EKIGECAEAKE;

	private AMDIPFKFHCC MOOEPAAPNFK;

protected override string CIKPANGLFGP
{
get 	{
		return null;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public override global::NCOKFFGPIJM<GGLKDINOLHA> ShowDialog(AMDIPFKFHCC CAOIPCMMNMJ)
	{
		return null;
	}

	public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
	{
	}

	public override void ForceCancel(bool EDLFMMEDNGP)
	{
	}

	private bool HOPBACOBJAM(DFDECAEJBIO ACBGBAAHOIM)
	{
		return false;
	}

	private void BPECCLHFLEN(IReadOnlyList<DFDECAEJBIO> ILJGHKGMILC)
	{
	}

	private void IFIJCDBNPHC(string HNGJGPJCNBJ)
	{
	}

	private void FHEDBLODFHO(IReadOnlyList<DFDECAEJBIO> AGIGKKMBEKN, bool FAILMPKEEPK = false)
	{
	}

	private void KMMLEMOMBEL()
	{
	}

	private void NJAHEBCGBKD()
	{
	}

	private void KCELHKFOJAE()
	{
	}

	private FGKJENBBNJM AINAAMNONAE()
	{
		return FGKJENBBNJM.SelectAll;
	}

	private void DPEABINBGCB(CFGKBDNCNJK PAFIFJPOKMF)
	{
	}

	private IReadOnlyList<DFDECAEJBIO> BLIGEJMMNIL()
	{
		return null;
	}

	private IEnumerable<DFDECAEJBIO> HPPKIDAGKOK()
	{
		return null;
	}

	private IEnumerable<DFDECAEJBIO> KPPLJFCOGAJ()
	{
		return null;
	}

	private IEnumerable<DFDECAEJBIO> HALDPIJKBNJ(IReadOnlyList<int> AEBIAAMBKED)
	{
		return null;
	}

	public void SelectedAccountsUpdated(IReadOnlyList<DFDECAEJBIO> newAccounts)
	{
	}

	public void Button_ToggleBulkSelect()
	{
	}

	public void Button_SetAccountSourceToFriends()
	{
	}

	public void Button_SetAccountSourceToNearby()
	{
	}

	public void Button_Submit()
	{
	}

	[CompilerGenerated]
	private bool NANOOEFBJML(DFDECAEJBIO NNMPJECKECI)
	{
		return false;
	}

	[CompilerGenerated]
	private bool CFGBDFAKHNC(DFDECAEJBIO NNMPJECKECI)
	{
		return false;
	}
}
