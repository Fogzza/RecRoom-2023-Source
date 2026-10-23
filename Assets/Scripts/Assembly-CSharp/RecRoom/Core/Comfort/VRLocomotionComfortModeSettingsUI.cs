using System;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;

namespace RecRoom.Core.Comfort
{
	public class VRLocomotionComfortModeSettingsUI : MonoBehaviour
	{
		[Serializable]
		public class ModeSetting
		{
			public VRLocomotionComfortMode.HIBCGAAJJPA Mode;

			public string DisplayText;

			public bool AllowSettings;
		}

		[Serializable]
		public class TechniqueSetting
		{
			public VRLocomotionComfortMode.OACKHDNDIMI Technique;

			public string DisplayText;
		}

		private sealed class DNIOEPJBGHC
		{
			public VRLocomotionComfortMode.HIBCGAAJJPA mode;

			internal bool _003CShowMode_003Eb__0(ModeSetting ms)
			{
				return false;
			}
		}

		private sealed class BDNMCIFMHHG
		{
			public VRLocomotionComfortMode.OACKHDNDIMI technique;

			internal bool _003CShowTechnique_003Eb__0(TechniqueSetting ms)
			{
				return false;
			}
		}

		[SerializeField]
		private TextMeshProUGUI currentModeLabel;

		[SerializeField]
		private TextMeshProUGUI currentTechniqueLabel;

		[SerializeField]
		private Button3D settingsButton;

		[SerializeField]
		private Slider3D sizeSlider;

		[SerializeField]
		private ModeSetting[] modeSettings;

		[SerializeField]
		private TechniqueSetting[] techniqueSettings;

		public void OnEnable()
		{
		}

		public void Button_CycleModes()
		{
		}

		private void NKGIKFOJMHI(VRLocomotionComfortMode.HIBCGAAJJPA DNLPIHIBJDP)
		{
		}

		private void CIHELNLMJKO(VRLocomotionComfortMode.OACKHDNDIMI FKJKFPOPDCH)
		{
		}

		public void Button_CycleTechniques()
		{
		}

		public void SetSize(float size)
		{
		}
	}
}
