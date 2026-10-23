using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AGUI.StackedUI
{
	public class ConsumablesPagedGrid : RecyclerPagedGrid<IELGHJEOPKB, ConsumableButton>
	{
		[Serializable]
		public class ConsumableSelectedEvent : UnityEvent<IELGHJEOPKB>
		{
		}

		private sealed class LAMFKBEEBPJ
		{
			public ConsumablesPagedGrid _003C_003E4__this;

			public ConsumableButton button;

			internal void _003CSetupNewChild_003Eb__0(bool isOn)
			{
			}
		}

		[SerializeField]
		private StackedUIFlowBase uiFlowBase;

		public ConsumableSelectedEvent OnConsumableSelectedEvent;

		protected override void LKIICDHGCMD(ConsumableButton HHDMPJJAPJJ)
		{
		}

		public void SetConsumables(IEnumerable<IELGHJEOPKB> BCBAHJMKOJN, BackpackScreen.DFNLMMONNOI AIDOCIKAKCJ)
		{
		}

		protected override void ANLHNIJPJEC(IELGHJEOPKB KIJHICGIKFM, ConsumableButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
