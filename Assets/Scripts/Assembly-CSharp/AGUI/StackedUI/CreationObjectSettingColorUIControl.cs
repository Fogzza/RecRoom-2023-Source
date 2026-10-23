using System;
using AGUI.StackedUI.Dialog;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class CreationObjectSettingColorUIControl : CreationObjectSettingPropertyUIControl<int, CreationObjectSettingColorUIControl>
	{
		private sealed class LEABNPBFOLO
		{
			public CreationObjectSettingColorUIControl _003C_003E4__this;

			public int prevColor;

			internal global::NCOKFFGPIJM<ColorInputUIDialog.KKIDIEKNOPK> _003CButton_Input_003Eb__0(ColorInputUIDialog dialog)
			{
				return null;
			}

			internal void _003CButton_Input_003Eb__1(ColorInputUIDialog.KKIDIEKNOPK r)
			{
			}
		}

		private string NBGMPHLGMAL;

		private string HDJGLOGPCHF;

		[SerializeField]
		private Button3D inputButton;

		public Action<int> PropertyPreview;

		public Action<int> OnCancel;

		[SerializeField]
		private ColorInputUIDialog colorInputDialogPrefab;

public Color ButtonColor
{
get 		{
			return default;
		}

set {
		}
}

		protected override void NGPGENCCLNA()
		{
		}

		public void Button_Input()
		{
		}
	}
}
