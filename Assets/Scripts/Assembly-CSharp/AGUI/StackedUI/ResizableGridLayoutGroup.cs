using System;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class ResizableGridLayoutGroup : ResizableElementBase<ResizableGridLayoutGroup.Settings>
	{
		[Serializable]
		public class Settings : SizeSettingsBase
		{
			public Vector2 cellSize;

			public Vector2 spacing;
		}

		[SerializeField]
		protected GridLayoutGroup gridLayout;

		[SerializeField]
		protected Settings[] settings;

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
