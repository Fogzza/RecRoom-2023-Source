using System;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public class TextInputUIDialog : BaseTextInputUIDialog<TextInputUIDialog.FGHGFIFENNB, TextInputUIDialog.FOBELBLMBDE>
	{
		public struct FGHGFIFENNB
		{
			public TMP_InputField.ContentType PANLMPDMCKG;

			public string BOGCJKAMALE;

			public string HGIIJBKEGMK;

			public string NMLDDBBKEBD;

			public DIKDHBKKFCM IJAFKBJIGBI;

			public string JINHPNDAHKP;

			public bool BCNOOIABPKG;

			public int MPPKBKCGBKL;

			public EIOGFODBKNI DPOBBOINDJO;

			public Func<string, bool> IECKGIBPFHD;

			public TMP_InputField.CharacterValidation LCFHBGGAHLO;

			public string AHJAJMMOJAL;

			public bool LLKBDECFCMO;

			public FGHGFIFENNB(TMP_InputField.ContentType PANLMPDMCKG, string BOGCJKAMALE, string HGIIJBKEGMK)
			{
				this.PANLMPDMCKG = TMP_InputField.ContentType.Standard;
				this.BOGCJKAMALE = null;
				this.HGIIJBKEGMK = null;
				NMLDDBBKEBD = null;
				IJAFKBJIGBI = DIKDHBKKFCM.SingleLine;
				JINHPNDAHKP = null;
				BCNOOIABPKG = false;
				MPPKBKCGBKL = 0;
				DPOBBOINDJO = null;
				IECKGIBPFHD = null;
				LCFHBGGAHLO = TMP_InputField.CharacterValidation.None;
				AHJAJMMOJAL = null;
				LLKBDECFCMO = false;
			}
		}

		public struct FOBELBLMBDE
		{
			public string GDIPPDDKKCL;

			public HGKINAOMNIF IAMHCABOCOA;
		}

		[SerializeField]
		private ValidatedButtonInputField singleLineTextInputField;

		[SerializeField]
		private ValidatedButtonInputField multiLineTextInputField;

		[SerializeField]
		private Transform singleLineTextInputGroupTransform;

		[SerializeField]
		private Transform multiLineTextInputGroupTransform;

		private DIKDHBKKFCM CPDFKNINONB;

		private static readonly FOBELBLMBDE LCDAMLOHFBL;

protected override FOBELBLMBDE KEJCDHMONAL
{
get 		{
			return default;
		}

}

protected override ValidatedButtonInputField GODJGJEIGPH
{
get 		{
			return null;
		}

}

		protected override void FFEAMMPGNLP(FGHGFIFENNB ADCFFAJGNAM)
		{
		}

		protected override FOBELBLMBDE DEBNCJMABEH(string LDGLHPBNCMH)
		{
			return default;
		}
	}
}
