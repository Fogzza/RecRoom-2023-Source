using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Data;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Utils.Image;
using UnityEngine;

public class UGCRewardModel : RRUIModel, FDFHJNFMGOJ
{
	public enum CDEOFJHILAC
	{
		Default = 0,
		RewardDetails = 1
	}

	public class ODCFNKGGMPL
	{
		public Guid GHIEHEOOCPN;

		public string PALADLMJNAK;

		public string HDJKLNIGFHF;

		public int PIMFGCCCIDN;

		public string EDMNOAEBDNC;

		public IGHPMNDHNII.FABOPIHCMOO EMOOLCHPHPD;

		public Guid GGOBJDJGLOF;
	}

	public const string REWARD_ID_KEY = "REWARD_ID_KEY";

	public const string DEFAULT_NAME_TEXT = "Create New Reward";

	public const int MIN_NAME_LENGTH = 3;

	public const int MAX_NAME_LENGTH = 40;

	public const int MIN_DESCRIPTION_LENGTH = 10;

	public const int MAX_DESCRIPTION_LENGTH = 174;

	public const int MIN_CURRENCY_REWARD = 1;

	public const int MAX_CURRENCY_REWARD = 10000;

	public const int MIN_CONSUMABLE_REWARD = 1;

	public const int MAX_CONSUMABLE_REWARD = 100;

	public static Guid INVALID_REWARD_ID;

	[SerializeField]
	private CDEOFJHILAC source;

	private IGHPMNDHNII NEEHICNEIKI;

	private Guid OAKOBIANOAL;

	private List<BKCIEBLAHHB> HIKHMJEIBED;

	private IEnumerable<EOHADGOEBOD> OHPEPOEKOKM;

	private IEnumerable<KFGPIBFKOAK> GAMIHLMKCMN;

	private ODCFNKGGMPL OFABMKEANJH;

	private string LCIMIBIJPNO;

	private readonly ManagedTexture PHDELAPLILN;

	private MessageDialogModel PEHELDEPGIJ;

	private IPGOOJIFBAB OFGCLLGGIBC;

	private const string NDJEMLKCFHE = "You are about to delete the reward with the name \"{0}\".\n\nAre you sure you want to delete this reward? \n\nThis action cannot be undone.";

	private DynamicUIDialogModel AHELLHDBKPK;

	private DHAPPKCJJCA CCBFNILNOGF;

	private DynamicUIDialogModel DFGBNNHNAIJ;

	private DHAPPKCJJCA JFACADKMJOC;

	private DHAPPKCJJCA GPBMODPLJLA;

	private DHAPPKCJJCA GKAAGKADGLG;

protected override bool GIHBNOOCJDD
{
get 	{
		return false;
	}

}

public IGHPMNDHNII RewardData
{
get 	{
		return null;
	}

private set {
	}
}

public Guid RewardId
{
get 	{
		return default;
	}

private set {
	}
}

public ODCFNKGGMPL ModificationBackingData
{
get 	{
		return null;
	}

private set {
	}
}

public string Name
{
get 	{
		return null;
	}

set {
	}
}

public string Description
{
get 	{
		return null;
	}

set {
	}
}

public int Quantity
{
get 	{
		return 0;
	}

set {
	}
}

public string ImageName
{
get 	{
		return null;
	}

set {
	}
}

public IGHPMNDHNII.FABOPIHCMOO RewardType
{
get 	{
		return IGHPMNDHNII.FABOPIHCMOO.None;
	}

set {
	}
}

public Guid TargetId
{
get 	{
		return default;
	}

set {
	}
}

public string TargetName
{
get 	{
		return null;
	}

private set {
	}
}

public bool ShouldSubmitButtonBeInteractable
{
get 	{
		return false;
	}

}

public int MinQuantity
{
get 	{
		return 0;
	}

}

public int MaxQuantity
{
get 	{
		return 0;
	}

}

public GameObject GameObject
{
get 	{
		return null;
	}

}

	private bool FFLEDDAGJKC(int IFLOEKGCJON, IGHPMNDHNII.FABOPIHCMOO OFBKHHAOBNO)
	{
		return false;
	}

	protected override void DHHOMFCCFKP()
	{
	}

	protected override void KPOHBHPPGBM()
	{
	}

	public void Set(Guid IGBONJIMGNI, bool IDNNLLKEEHB = true)
	{
	}

	protected override LAHBDKNMNHN KANNLKCLIOF()
	{
		return null;
	}

	protected override void LPBNNNGFPIF()
	{
	}

	public void TryChangeRewardImage()
	{
	}

	private global::NCOKFFGPIJM<string> DLLPNBIEHKH()
	{
		return null;
	}

	public void CreateOrModifyReward()
	{
	}

	public void ConfirmDeleteReward()
	{
	}

	private void KGPCKCLKDIB()
	{
	}

	public void TryShowRewardTypeDialogPopUp()
	{
	}

	public void TryShowRewardPickerDialogPopup()
	{
	}

	private DHAPPKCJJCA CMPOKMCGPOO(List<DGMPBIPKJEB> ILCKLFBBIDJ, string OFMGPNLDCAB)
	{
		return null;
	}

	private void PDPPDOBHOFP()
	{
	}

	private void PDLOFFHMEOD()
	{
	}

	private void IOIBHNMLIAG()
	{
	}

	public LAHBDKNMNHN OnBeforePageSwapFrom(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL IJBCMNDEFKG)
	{
		return null;
	}

	public LAHBDKNMNHN OnBeforePageSwapTo(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL NNNNCKGCFDC)
	{
		return null;
	}

	public LAHBDKNMNHN OnAfterPageSwapTo(RRUI.Navigation.Uri FKFKJOJNCLM, JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL CPPLLDJOLBG)
	{
		return null;
	}

	public LAHBDKNMNHN OnShow(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
	{
		return null;
	}

	public LAHBDKNMNHN OnHide(JAKKOEKBEDG AKOKILEPANJ, MCMEHFCNDOL JJBAOLFOIMI, MCMEHFCNDOL IMLLIIBAJMB)
	{
		return null;
	}

	[CompilerGenerated]
	private bool EPFKCPNEKLO(EOHADGOEBOD FCCGDNMAHPA)
	{
		return false;
	}

	[CompilerGenerated]
	private bool PCDJPHLFFDK(BKCIEBLAHHB FCCGDNMAHPA)
	{
		return false;
	}

	[CompilerGenerated]
	private bool AMLGHLIHIGD(KFGPIBFKOAK FCCGDNMAHPA)
	{
		return false;
	}

	[CompilerGenerated]
	private void BJLKFPEPGNI(string NPOEAPJKNFN)
	{
	}

	[CompilerGenerated]
	private global::NCOKFFGPIJM<string> BEGIMHNGBJG(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
	{
		return null;
	}

	[CompilerGenerated]
	private void EOPLCNBDKKK()
	{
	}

	[CompilerGenerated]
	private void BIMKMLPFNOO(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
	{
	}

	[CompilerGenerated]
	private object CBEFAMFOCOH()
	{
		return null;
	}

	[CompilerGenerated]
	private void DAOMHKJGJDD(object FDAIMOMOHIG)
	{
	}

	[CompilerGenerated]
	private void JBJLGLMAKIN(string IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private void OIFHNGNIDBA(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
	{
	}

	[CompilerGenerated]
	private object ILFIAMCNONP()
	{
		return null;
	}

	[CompilerGenerated]
	private void MMCAFLKAEMF(object FDAIMOMOHIG)
	{
	}

	[CompilerGenerated]
	private void IKEBCMAPDGG(string IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private void MCJKCGAKLEO(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
	{
	}

	[CompilerGenerated]
	private void BLNIPHFBDKH(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
	{
	}

	[CompilerGenerated]
	private void AJGHCFJPBKI(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
	{
	}
}
