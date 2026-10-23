using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class ResizableText : ResizableElementBase<ResizableText.Settings>
	{
		[Serializable]
		public class Settings : SizeSettingsBase
		{
			public int fontSize;

			public float lineSpacing;
		}

		[SerializeField]
		private Text text;

		[SerializeField]
		private TMP_Text tmp_text;

		[SerializeField]
		private Settings[] settings;

protected override Settings[] LMACFJJCBOB
{
get 		{
			return null;
		}

}

		protected override void FFEJFIHJFJF(Settings CAOIPCMMNMJ)
		{
		}
	}
}
