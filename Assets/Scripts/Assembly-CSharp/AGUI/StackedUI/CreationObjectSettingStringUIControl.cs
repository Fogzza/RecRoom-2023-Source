using System;
using System.Runtime.CompilerServices;
using AGUI.StackedUI.Dialog;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class CreationObjectSettingStringUIControl : CreationObjectSettingPropertyUIControl<string, CreationObjectSettingStringUIControl>
	{
		public delegate bool LJDGJBEFEED(TextMeshProUGUI HADMIMJGCHD, string KAEDAICECGN);

		public struct IMAKNLDBPIC
		{
			public string HDJGLOGPCHF;

			public string GDMLACOILJE;

			public DIKDHBKKFCM IJAFKBJIGBI;

			public TMP_InputField.ContentType PANLMPDMCKG;

			public TMP_InputField.CharacterValidation LCFHBGGAHLO;

			public Func<string, bool> IECKGIBPFHD;

			public LJDGJBEFEED DPOBBOINDJO;

			public string AHJAJMMOJAL;

			public bool PHIOCAIMHKK;

			public int MPPKBKCGBKL;

			public IMAKNLDBPIC(string HDJGLOGPCHF, string GDMLACOILJE, DIKDHBKKFCM IJAFKBJIGBI)
			{
				this.HDJGLOGPCHF = null;
				this.GDMLACOILJE = null;
				this.IJAFKBJIGBI = DIKDHBKKFCM.SingleLine;
				PANLMPDMCKG = TMP_InputField.ContentType.Standard;
				LCFHBGGAHLO = TMP_InputField.CharacterValidation.None;
				IECKGIBPFHD = null;
				DPOBBOINDJO = null;
				AHJAJMMOJAL = null;
				PHIOCAIMHKK = false;
				MPPKBKCGBKL = 0;
			}
		}

		[SerializeField]
		private Button3D modifyButton;

		[SerializeField]
		private Tooltip buttonTooltip;

		private IMAKNLDBPIC DMMDPMFCBHN;

		[SerializeField]
		private TextInputUIDialog textInputDialogPrefab;

		public void SetTooltip(string JKMNMOJDOKB)
		{
		}

		public void SetDialogOptions(IMAKNLDBPIC DMMDPMFCBHN)
		{
		}

		private void Start()
		{
		}

		private void GGILCOJIFKK()
		{
		}

		protected override void NGPGENCCLNA()
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<TextInputUIDialog.FOBELBLMBDE> JMBJLLNNCLO(TextInputUIDialog GDMKJGAKCND)
		{
			return null;
		}

		[CompilerGenerated]
		private bool MEMBLPHILCA(TextMeshProUGUI HADMIMJGCHD, string HLIGBKANEEA)
		{
			return false;
		}

		[CompilerGenerated]
		private void EHKKEJBHEHK(TextInputUIDialog.FOBELBLMBDE GOJCEBCMFJK)
		{
		}
	}
}
