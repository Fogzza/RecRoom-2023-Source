using System;
using System.Collections.Generic;
using AGUI;
using RecRoom.Core.Creation;
using UnityEngine.Events;

namespace RecRoom.AGUI.ToolUIs
{
	public class TrialInventionPagedGrid : RecyclerPagedGrid<TrialInventionManager.MKAMBKPCCOL, TrialInventionButton>
	{
		[Serializable]
		public class InventionTrialSelectedEvent : UnityEvent<TrialInventionManager.MKAMBKPCCOL>
		{
		}

		private sealed class CJLNHIFAHOG
		{
			public TrialInventionPagedGrid _003C_003E4__this;

			public TrialInventionButton button;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}

			internal void _003CSetupNewChild_003Eb__1()
			{
			}
		}

		public InventionTrialSelectedEvent OnInventionBuyEvent;

		public InventionTrialSelectedEvent OnInventionRemoveEvent;

		protected override void LKIICDHGCMD(TrialInventionButton HHDMPJJAPJJ)
		{
		}

		public void SetTrials(IEnumerable<TrialInventionManager.MKAMBKPCCOL> AMIAEMLONAO)
		{
		}

		protected override void ANLHNIJPJEC(TrialInventionManager.MKAMBKPCCOL MNNKINGOIKL, TrialInventionButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
