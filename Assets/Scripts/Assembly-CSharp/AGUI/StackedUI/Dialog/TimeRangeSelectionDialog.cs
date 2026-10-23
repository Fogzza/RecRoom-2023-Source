using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public class TimeRangeSelectionDialog : UIDialog<TimeRangeSelectionDialog.GLEGFFOOPGA>
	{
		public delegate bool JOPKBIPOKBA(int NILDODIFKPH, int GLDFHJCHIFH, int KBFLFDKGJBD, int HAONOIGHDFH, out string PEOLHGGDCPN);

		public class GLEGFFOOPGA
		{
			public int IOOOCNEPBGB;

			public int BOJBPBMLCED;

			public int DODFIECGMAA;

			public int OJKBDGDMACD;
		}

		[SerializeField]
		private TextMeshProUGUI currentTimeText;

		[SerializeField]
		private ValidatedButtonInputField startTimeHoursField;

		[SerializeField]
		private ValidatedButtonInputField startTimeMinutesField;

		[SerializeField]
		private ValidatedButtonInputField endTimeHoursField;

		[SerializeField]
		private ValidatedButtonInputField endTimeMinutesField;

		[SerializeField]
		private Slider3D startTimeAMPM;

		[SerializeField]
		private Slider3D endTimeAMPM;

		[SerializeField]
		private TextMeshProUGUI infoText;

		[SerializeField]
		private Button3D submitButton;

		private string MPHBINKGOJE;

		private string NAOANPHIMLD;

		private string NNOCBDBJPMG;

		private string PAKKPNAIIFI;

		private GLEGFFOOPGA BMHHMBOMICL;

		private JOPKBIPOKBA OFLAOBBEILF;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public override void ForceCancel(bool EDLFMMEDNGP)
		{
		}

		public override global::NCOKFFGPIJM<GLEGFFOOPGA> ShowDialog()
		{
			return null;
		}

		public void SetCustomValidation(JOPKBIPOKBA OAODAIEPOHA)
		{
		}

		public void SetInfoText(string OFCFPGACNJB)
		{
		}

		public void SetTimeRange(GLEGFFOOPGA DAPALPMGILG)
		{
		}

		private void LBAPOGELIEE(float GADDGJANIGG)
		{
		}

		private bool MIEIOOKAGGJ()
		{
			return false;
		}

		public void Button_Submit()
		{
		}

		public void Button_Cancel()
		{
		}

		private static int JNJJPKBLFDN(int GCMKFEKHBNC)
		{
			return 0;
		}

		private static int MBPBKBHABNL(int GCMKFEKHBNC, bool DKHOBIIJMON)
		{
			return 0;
		}

		[CompilerGenerated]
		private bool PIJKDPCFAJA(string DAACPAJMOAP)
		{
			return false;
		}

		[CompilerGenerated]
		private bool MDCCJNEBCFB(string NDKGIDFHDLK)
		{
			return false;
		}

		[CompilerGenerated]
		private bool NDCHGOMODGD(string DAACPAJMOAP)
		{
			return false;
		}

		[CompilerGenerated]
		private bool KJDLHFAEEDA(string NDKGIDFHDLK)
		{
			return false;
		}
	}
}
