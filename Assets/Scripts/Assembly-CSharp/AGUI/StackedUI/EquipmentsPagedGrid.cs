using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AGUI.StackedUI
{
	public class EquipmentsPagedGrid : RecyclerPagedGrid<FFNCPFGBPND, EquipmentButton>
	{
		[Serializable]
		public class EquipmentSelectedEvent : UnityEvent<FFNCPFGBPND>
		{
		}

		private sealed class FJGKHAADOLA
		{
			public EquipmentsPagedGrid _003C_003E4__this;

			public EquipmentButton button;

			internal void _003CSetupNewChild_003Eb__0(bool isOn)
			{
			}
		}

		[SerializeField]
		private StackedUIFlowBase uiFlowBase;

		public EquipmentSelectedEvent OnEquipmentSelectedEvent;

		protected override void LKIICDHGCMD(EquipmentButton HHDMPJJAPJJ)
		{
		}

		public void SetEquipments(IEnumerable<FFNCPFGBPND> HPNPFCJHLHM)
		{
		}

		protected override void ANLHNIJPJEC(FFNCPFGBPND CKAPBBGHJEC, EquipmentButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
