using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine.Events;

namespace RecRoom.AGUI
{
	public class SelectAccountButtonsPagedGrid : RecyclerPagedGrid<DFDECAEJBIO, SelectAccountButton>
	{
		[Serializable]
		public class SelectedAccountsUpdated : UnityEvent<List<DFDECAEJBIO>>
		{
		}

		private sealed class DJGICLDEPKH
		{
			public SelectAccountButton button;

			public SelectAccountButtonsPagedGrid _003C_003E4__this;

			internal void _003CSetupNewChild_003Eb__0(bool isOn)
			{
			}
		}

		public SelectedAccountsUpdated OnSelectedAccountsUpdatedEvent;

		private List<DFDECAEJBIO> PNHILOECLKG;

		private Dictionary<int, string> IPNLIGLPEPL;

		protected override void LKIICDHGCMD(SelectAccountButton HHDMPJJAPJJ)
		{
		}

		public void SetAccounts(IEnumerable<DFDECAEJBIO> AGIGKKMBEKN, Dictionary<int, string> FJACKECBNOJ, bool FAILMPKEEPK)
		{
		}

		public IEnumerable<SelectAccountButton> GetAllButtons()
		{
			return null;
		}

		protected override void ANLHNIJPJEC(DFDECAEJBIO ACBGBAAHOIM, SelectAccountButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
