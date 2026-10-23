using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public class UIDateSelectionDialog : UIDialog<DateTime?>
	{
		public delegate void IBNIJKFFLJH(ref int JOEPEOEMEDF, ref int CLDPOBMLBNK, ref int BAMAIEFDAEJ);

		public delegate string GBCHNNHIHAD(int JOEPEOEMEDF, int CLDPOBMLBNK, int BAMAIEFDAEJ);

		public IBNIJKFFLJH customDateConversion;

		public GBCHNNHIHAD customDateValidation;

		[SerializeField]
		protected ScreenHeader screenHeader;

		[SerializeField]
		private TextMeshProUGUI infoText;

		[SerializeField]
		private ValidatedButtonInputField monthField;

		[SerializeField]
		private ValidatedButtonInputField dayField;

		[SerializeField]
		protected ValidatedButtonInputField yearField;

		[SerializeField]
		private Button3D submitButton;

		[SerializeField]
		private bool displayYear;

		[SerializeField]
		protected GameObject yearContainer;

		private DateTime? DKAKEAGACJL;

		protected bool MACJINIKPMH;

		protected string LIIMEFFGBDH;

		private bool HELDPHCALDC;

		private int? KKEIBAKBCKD;

protected DateTime? ADADNBMCKKA
{
get 		{
			return null;
		}

private set {
		}
}

public bool DisplayYear
{
get 		{
			return false;
		}

set {
		}
}

public int? LockedAge
{
get 		{
			return null;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		public void SetTitleText(string BOGCJKAMALE)
		{
		}

		public void UpdateUIState(string AKOKILEPANJ, bool CEKBHBBHDCG)
		{
		}

		private void BJFJAMMLFAE(string AKOKILEPANJ)
		{
		}

		protected virtual void MMLEMGLNLKH(bool CEKBHBBHDCG)
		{
		}

		public void SetCurrentDate(DateTime DKPPPBFONDH)
		{
		}

		public global::NCOKFFGPIJM<DateTime?> ShowDialog(string LIIMEFFGBDH, DateTime? PMLJFBLGBMO)
		{
			return null;
		}

		public override global::NCOKFFGPIJM<DateTime?> ShowDialog()
		{
			return null;
		}

		protected virtual bool OLOCONNBNPH()
		{
			return false;
		}

		private void KJMBFGKOPNF()
		{
		}

		public override void ForceCancel(bool EDLFMMEDNGP)
		{
		}

		public void Button_Submit()
		{
		}

		public void Button_Cancel()
		{
		}

		[CompilerGenerated]
		private bool JCLCMPGBIDK(string JOEPEOEMEDF)
		{
			return false;
		}

		[CompilerGenerated]
		private bool DFELIKFGLMJ(string CLDPOBMLBNK)
		{
			return false;
		}

		[CompilerGenerated]
		private bool HFHLPOBOJOP(string BAMAIEFDAEJ)
		{
			return false;
		}
	}
}
