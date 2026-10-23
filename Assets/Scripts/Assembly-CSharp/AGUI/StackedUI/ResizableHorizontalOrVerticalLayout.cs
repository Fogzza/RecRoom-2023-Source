using System;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class ResizableHorizontalOrVerticalLayout : ResizableElementBase<ResizableHorizontalOrVerticalLayout.Settings>
	{
		[Serializable]
		public class Settings : SizeSettingsBase
		{
			public RectOffset padding;

			public float spacing;
		}

		[SerializeField]
		private HorizontalOrVerticalLayoutGroup layout;

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
