using System;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public class UIConfirmationDialog : ConfirmUIDialog<UIConfirmationDialog.EPIGOMCICOG, string, string, string, string, string>
	{
		[Flags]
		public enum EPIGOMCICOG
		{
			YES_NO_CANCEL_HOME = 0xF,
			OK_CANCEL = 0xD,
			YES_NO = 3,
			LOCKED = 0,
			YES_ONLY = 1,
			YES_NO_CANCEL = 7,
			OK_CANCEL_TEXT = 0x1D,
			YES_NO_NOTNOW = 0x23
		}

		public const int YES = 1;

		public const int NO = 2;

		public const int BACK = 4;

		public const int HOME = 8;

		public const int TEXT = 16;

		public const int NOTNOW = 32;

		[SerializeField]
		private ScreenHeader screenHeader;

		[SerializeField]
		private TextMeshProUGUI titleText;

		[SerializeField]
		private TextMeshProUGUI bodyText;

		[SerializeField]
		private TextMeshProUGUI yesText;

		[SerializeField]
		private TextMeshProUGUI noText;

		[SerializeField]
		private TextMeshProUGUI notNowText;

		[SerializeField]
		private ValidatedButtonInputField textInputField;

		[SerializeField]
		private GameObject textInputGroup;

		[SerializeField]
		private RectTransform yesButton;

		[SerializeField]
		private RectTransform noButton;

		[SerializeField]
		private RectTransform notNowButton;

		[SerializeField]
		private PagedTextMeshPro3D pagedText;

		private bool FLJIGCLCGHL;

		private TextAlignmentOptions IKGDGEMNPGE;

public ValidatedButtonInputField TextInputField
{
get 		{
			return null;
		}

}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		public override global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(EPIGOMCICOG HNPFAOFHHII, string BOGCJKAMALE, string HGIIJBKEGMK, string JINHPNDAHKP = "Yes", string ABONDMLCNBK = "No", string ADMBJPIEGBI = "Later")
		{
			return null;
		}

		public void SetupBodyText(bool KNEBJHGJEOK = false, TextAlignmentOptions BIJKGDNCEEA = TextAlignmentOptions.Top)
		{
		}

		public void UpdateBodyText(string HGIIJBKEGMK)
		{
		}
	}
}
