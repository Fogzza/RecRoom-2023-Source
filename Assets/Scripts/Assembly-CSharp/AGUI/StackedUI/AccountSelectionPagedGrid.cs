using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AGUI.StackedUI
{
	public class AccountSelectionPagedGrid : RecyclerPagedGrid<DFDECAEJBIO, AccountSelectionButton3D>
	{
		[Serializable]
		public class ShowPlayerDetailsEvent : UnityEvent<DFDECAEJBIO>
		{
		}

		private sealed class ADBNJKLHBKG
		{
			public AccountSelectionPagedGrid _003C_003E4__this;

			public AccountSelectionButton3D button;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}
		}

		[SerializeField]
		private ShowPlayerDetailsEvent AccountSelectedEvent;

		protected override void LKIICDHGCMD(AccountSelectionButton3D HHDMPJJAPJJ)
		{
		}

		public void EnableAllButtons(bool OBFHBDLKFPA)
		{
		}

		public void SetAccounts(IEnumerable<DFDECAEJBIO> AGIGKKMBEKN)
		{
		}

		protected override void ANLHNIJPJEC(DFDECAEJBIO ACBGBAAHOIM, AccountSelectionButton3D HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
