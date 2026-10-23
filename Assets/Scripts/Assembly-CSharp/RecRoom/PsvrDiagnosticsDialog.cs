using AGUI.StackedUI.Dialog;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class PsvrDiagnosticsDialog : ConfirmUIDialog
	{
		[SerializeField]
		private Text headsetDetails;

		[SerializeField]
		private Text leftControllerDetails;

		[SerializeField]
		private Image leftGlobeColorImage;

		[SerializeField]
		private Text rightControllerDetails;

		[SerializeField]
		private Image rightGlobeColorImage;

		[SerializeField]
		private Transform playareaBrightnessWarning;

		public const bool SupportedOnCurrentPlatform = false;

		public void Button_RecalibrateHMD()
		{
		}

		public void Button_RecalibrateMoveControllers()
		{
		}
	}
}
