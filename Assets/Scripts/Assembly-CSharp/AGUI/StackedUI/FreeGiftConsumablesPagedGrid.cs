using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AGUI.StackedUI
{
	public class FreeGiftConsumablesPagedGrid : RecyclerPagedGrid<IELGHJEOPKB, FreeGiftConsumableButton>
	{
		[Serializable]
		public class FreeGiftConsumableSelectedEvent : UnityEvent<IELGHJEOPKB>
		{
		}

		private sealed class KGHMHJJALNA
		{
			public FreeGiftConsumablesPagedGrid _003C_003E4__this;

			public FreeGiftConsumableButton button;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}
		}

		[SerializeField]
		private StackedUIFlowBase uiFlowBase;

		[SerializeField]
		private bool showAddNewFreeGiftButton;

		[SerializeField]
		private Button3D addNewFreeGiftButton;

		[SerializeField]
		private string buttonText;

		public FreeGiftConsumableSelectedEvent OnFreeGiftConsumableSelectedEvent;

		private int DBNBDDCNILJ;

		public int GetCurrentGifterPlayerID()
		{
			return 0;
		}

		protected override void Awake()
		{
		}

		protected override void LKIICDHGCMD(FreeGiftConsumableButton HHDMPJJAPJJ)
		{
		}

		public void EnableAllButtons(bool OBFHBDLKFPA)
		{
		}

		public void SetConsumables(IEnumerable<IELGHJEOPKB> BCBAHJMKOJN, int GDFNNNLBCGP)
		{
		}

		protected override void ANLHNIJPJEC(IELGHJEOPKB KIJHICGIKFM, FreeGiftConsumableButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
