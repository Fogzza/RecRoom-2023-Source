using RRUI.Data;
using RecRoom.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WatchNotificationDialog : MonoBehaviour
{
	private const string PEGJBNGNFBP = "New Watch Notification!";

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private float notificationDisplayTime;

	[SerializeField]
	private float notificationFadeOutTime;

	[SerializeField]
	private float notificationDisplayTimeWithQuickAccept;

	[SerializeField]
	private TMP_Text title;

	[SerializeField]
	private TMP_Text subtitle;

	[SerializeField]
	private GameObject watchActionPanel;

	[SerializeField]
	private GameObject[] inputButtonIconContainers;

	[SerializeField]
	private Image[] inputButtonIcons;

	[SerializeField]
	private Image notificationContextIcon;

	[SerializeField]
	private GameObject recNetIconPanel;

	[SerializeField]
	private AccountModel recNetIconAccountModel;

	[SerializeField]
	private GameObject recNetIconOnlineOverlay;

	[SerializeField]
	private GameObject recNetIconPlusOverlay;

	[SerializeField]
	private GameObject quickAcceptContainer;

	[SerializeField]
	private TMP_Text quickAcceptText;

	[SerializeField]
	private CircularProgressBar circularProgressBar;

	private bool MIFPMCPIGCD;

	private readonly int ECLBIMCJCOK;

	private readonly int ANKFPFLBKCE;

	private readonly int EHDOKBGIJJJ;

public float NotificationDisplayTime
{
get 	{
		return 0f;
	}

}

public float NotificationFadeOutTime
{
get 	{
		return 0f;
	}

}

public float NotificationDisplayTimeWithQuickAccept
{
get 	{
		return 0f;
	}

}

	public void SetActive(bool FBHDABEFLKL)
	{
	}

	public void AnimateOut()
	{
	}

	public void SetContent(NotificationManager.BMLNJJNEOAB PBOPFHHBNPO, Sprite CKGFAEHILNB)
	{
	}

	private void BHGCLLKHGPJ(Sprite CKGFAEHILNB)
	{
	}

	private void JGEDNNLPDKM(string GDOHHMMEKNO, string BDDPCJOHDGM)
	{
	}

	private bool IIMNCNPPDMN(TMP_Text KLEOIMLJIAC, string EHHMGBANFNH)
	{
		return false;
	}

	private void FKBHNMGIEBM(WatchNotificationTypeConfig.WatchNotificationTypeSettings CAOIPCMMNMJ)
	{
	}

	private void IJKJGFGABEF(WatchNotificationTypeConfig.WatchNotificationTypeSettings CAOIPCMMNMJ)
	{
	}

	public void SetProgress(float DDKCONDPEJF)
	{
	}

	public void QuickAccpetConfirmed()
	{
	}

	public void Dismissed()
	{
	}
}
