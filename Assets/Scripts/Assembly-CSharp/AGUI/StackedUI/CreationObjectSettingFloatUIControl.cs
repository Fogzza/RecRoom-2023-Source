using System.Runtime.CompilerServices;
using AGUI.StackedUI.Dialog;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class CreationObjectSettingFloatUIControl : CreationObjectSettingPropertyUIControl<float, CreationObjectSettingFloatUIControl>
	{
		[SerializeField]
		private int floatingPointPrecision;

		[SerializeField]
		private Button3D inputButton;

		[SerializeField]
		private Button3D incrementButton;

		[SerializeField]
		private Button3D decrementButton;

		[SerializeField]
		private bool clampRange;

		private float EJELOPCHGGJ;

		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue;

		private string GDMLACOILJE;

		private string HDJGLOGPCHF;

		private TMP_InputField.ContentType PANLMPDMCKG;

		[SerializeField]
		private TextInputUIDialog textInputDialogPrefab;

public bool ClampRange
{
get 		{
			return false;
		}

set {
		}
}

public float IncrementScalar
{
get 		{
			return 0f;
		}

set {
		}
}

public float MinValue
{
get 		{
			return 0f;
		}

set {
		}
}

public float MaxValue
{
get 		{
			return 0f;
		}

set {
		}
}

		public void SetDialogOptions(string HDJGLOGPCHF, string GDMLACOILJE, TMP_InputField.ContentType PANLMPDMCKG = TMP_InputField.ContentType.Alphanumeric)
		{
		}

		protected override void NGPGENCCLNA()
		{
		}

		protected override void JDJFOLOFJGL(float IPMIIEAGJKC)
		{
		}

		public void Button_Increment(float increment)
		{
		}

		public void Button_Input()
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<TextInputUIDialog.FOBELBLMBDE> DNNKFBKMMAH(TextInputUIDialog GDMKJGAKCND)
		{
			return null;
		}

		[CompilerGenerated]
		private void MOMCLJNJICJ(TextInputUIDialog.FOBELBLMBDE GOJCEBCMFJK)
		{
		}
	}
}
