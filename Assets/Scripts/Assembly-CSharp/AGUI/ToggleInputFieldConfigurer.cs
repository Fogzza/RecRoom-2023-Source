using System;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI
{
	public class ToggleInputFieldConfigurer : MonoBehaviour
	{
		[Serializable]
		private struct InputFieldConfig
		{
			public TMP_InputField.LineType LineType;

			public TMP_InputField.InputType InputType;

			public TouchScreenKeyboardType KeyboardType;

			public TMP_InputField.CharacterValidation CharacterValidation;
		}

		[SerializeField]
		private Toggle toggle2D;

		[SerializeField]
		private ToggleButton3D toggle3D;

		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private InputFieldConfig ToggledInputFieldState;

		[SerializeField]
		private InputFieldConfig UntoggledInputFieldState;

		private bool LLHPNFMKNAK;

private bool MCNLBMBLHLA
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void NDLGFBAMNMJ(bool IJIFOOANCNL = false)
		{
		}

		public void Toggle_ToggleChanged()
		{
		}
	}
}
