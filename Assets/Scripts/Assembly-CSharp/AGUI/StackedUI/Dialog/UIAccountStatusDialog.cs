using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI.Dialog
{
	public class UIAccountStatusDialog : ConfirmUIDialog<UIAccountStatusDialog.MJHKNFPENIC>
	{
		public enum MJHKNFPENIC
		{
			Creating = 0,
			CreateSuccess = 1,
			CreateFail = 2,
			PendingJunior = 3,
			Banned = 4,
			PendingEmailVerification = 5
		}

		public const string SIZE_CONFIG_KEY = "WATCH";

		[SerializeField]
		private Text titleText;

		[SerializeField]
		private Text subTitleText;

		[SerializeField]
		private Text bodyText;

		[SerializeField]
		private Button3D helpPageButton;

		[SerializeField]
		private Button3D okButton;

		[SerializeField]
		private Text okButtonText;

		private const string ICLNGOEBPNK = "Please ensure everyone active at your location knows:\n\n1. One player per account\n2. Players 12 and younger may ONLY be active on a junior account";

		private const string FEKGHFBDOIM = "A moderator has activated junior status on this account. Junior accounts support players 12 or younger. Please enter a parent / guardian’s email or contact us at recroom.zendesk.com to appea";

		private const string GHPFIBCIHIL = "Please finish registration using the email you received.";

protected override string NPNGNBNICFF
{
get 		{
			return null;
		}

}

		public override global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(MJHKNFPENIC AJLDNMPIGNP)
		{
			return null;
		}

		public void UpdateUIState(MJHKNFPENIC AJLDNMPIGNP, string HLIGBKANEEA = null)
		{
		}

		public void Button_HelpPage()
		{
		}

		public override void Button_Affirmative()
		{
		}
	}
}
