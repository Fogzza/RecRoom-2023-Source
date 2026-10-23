using System;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class ResizablePagedGrid : ResizableElementBase<ResizablePagedGrid.Settings>
	{
		[Serializable]
		public class Settings : SizeSettingsBase
		{
			public int pageSize;
		}

		[SerializeField]
		private VirtualPagedGrid pagedGrid;

		[SerializeField]
		private Settings[] settings;

protected override Settings[] LMACFJJCBOB
{
get 		{
			return null;
		}

}

public int MaxPageSize
{
get 		{
			return 0;
		}

}

		protected override void FFEJFIHJFJF(Settings CAOIPCMMNMJ)
		{
		}
	}
}
