using System;
using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI
{
	public class SubroomButtonPagedGrid : RecyclerPagedGrid<PMIKMHFIDLO, SubroomButton>
	{
		[Serializable]
		public class SubroomChosen : UnityEvent<OPKEAIOICLJ>
		{
		}

		private sealed class HKFFFMHIIFB
		{
			public SubroomButtonPagedGrid _003C_003E4__this;

			public SubroomButton button;

			internal void _003CSetupNewChild_003Eb__0(RadioButton3D isOn)
			{
			}
		}

		[SerializeField]
		private RadioGroup3D radioGroup;

		public SubroomChosen OnSubroomChosenEvent;

		protected override void LKIICDHGCMD(SubroomButton HHDMPJJAPJJ)
		{
		}

		public void SetButtonModels(IEnumerable<PMIKMHFIDLO> KBBJJENAIDN)
		{
		}

		protected override void ANLHNIJPJEC(PMIKMHFIDLO IFCMFMBKMNJ, SubroomButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
