using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class WatchStoreItemsPagedGrid : RecyclerPagedGrid<EOKBGGOAFLF, WatchStoreItemButton>
	{
		[Serializable]
		public class ItemSelectedEvent : UnityEvent<EOKBGGOAFLF>
		{
		}

		private sealed class ELKKMFFDCKE
		{
			public WatchStoreItemsPagedGrid _003C_003E4__this;

			public WatchStoreItemButton button;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}

			internal void _003CSetupNewChild_003Eb__1()
			{
			}
		}

		[SerializeField]
		private StackedUIFlowBase uiFlowBase;

		public ItemSelectedEvent OnItemSelectedEvent;

		public ItemSelectedEvent OnItemSelectedToTryEvent;

		[SerializeField]
		private GridLayoutGroup gridLayoutGroup;

		[SerializeField]
		private bool showTryButton;

public int GridColumnCount
{
get 		{
			return 0;
		}

}

		public void SetItems(IEnumerable<EOKBGGOAFLF> JNAAHMPCPAB, bool OPKEFNEECKK)
		{
		}

		public void SetGridColumnnCount(int BFFJHKFEFPP)
		{
		}

		protected override void ANLHNIJPJEC(EOKBGGOAFLF OBIIENMBMLH, WatchStoreItemButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}

		protected override void LKIICDHGCMD(WatchStoreItemButton HHDMPJJAPJJ)
		{
		}
	}
}
