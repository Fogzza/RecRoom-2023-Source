using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public abstract class EditTagsDialog<T> : ConfirmUIDialog<T>
	{
		private sealed class OGOAPICAGAN
		{
			public int toggleIndex;

			public EditTagsDialog<T> _003C_003E4__this;

			internal void _003CAwake_003Eb__0(bool isOn)
			{
			}
		}

		private sealed class KKIMMBKCPBP
		{
			public EditTagsDialog<T> _003C_003E4__this;

			public int i;

			public Func<string, bool> _003C_003E9__0;

			internal bool _003CRefreshHotTagToggles_003Eb__0(string t)
			{
				return false;
			}
		}

		private sealed class NLGFEKAJFOL
		{
			public EditTagsDialog<T> _003C_003E4__this;

			public int index;

			internal bool _003CToggle_Tag_003Eb__0(string sp)
			{
				return false;
			}
		}

		[SerializeField]
		protected TextMeshProUGUI autoTagsText;

		[SerializeField]
		protected InputField3D playerTagsField;

		[SerializeField]
		protected GameObject tagTogglesParent;

		[SerializeField]
		protected TextMeshProUGUI infoText;

		[SerializeField]
		protected Button3D cancelButton;

		[SerializeField]
		protected Button3D saveButton;

		[SerializeField]
		private TextMeshProUGUI cancelButtonText;

		[SerializeField]
		private TextMeshProUGUI saveButtonText;

		protected ToggleButton3D[] OBPJJFLHEBC;

		protected List<string> MFKJLAHPBPK;

		protected List<string> OMKMDPNNHGD;

		protected IReadOnlyList<string> MHFGKODCMCE;

protected abstract int FJLNLFADOBD
{
get ;
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void BJFJAMMLFAE(string AKOKILEPANJ, bool CEKBHBBHDCG)
		{
		}

		protected void HDFBDGGLCNO()
		{
		}

		protected void KFNILNNDBDL(string NLJOHEKGNDH, HPMDKMBJDDE MLDANHIGANI)
		{
		}

		protected bool GIOJBIKJJAN()
		{
			return false;
		}

		protected void IEJOENKKOCO()
		{
		}

		public void SetButtonText(string JINHPNDAHKP, string ABONDMLCNBK)
		{
		}

		public void Toggle_Tag(int GMEHLIHLGEH, bool NCPDDNBABLF)
		{
		}
	}
}
