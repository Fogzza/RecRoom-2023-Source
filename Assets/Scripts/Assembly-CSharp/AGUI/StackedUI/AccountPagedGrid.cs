using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AGUI.StackedUI
{
	public class AccountPagedGrid : RecyclerPagedGrid<DFDECAEJBIO, PlayerButton>
	{
		[Serializable]
		public class ShowPlayerDetailsEvent : UnityEvent<DFDECAEJBIO>
		{
		}

		private sealed class DOGFAHNKNBG
		{
			public AccountPagedGrid _003C_003E4__this;

			public PlayerButton button;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}
		}

		[SerializeField]
		private ShowPlayerDetailsEvent ShowDetailsEvent;

		private AccountSpecificUIBehaviour.PlayerDisplayMode AIDOCIKAKCJ;

		protected override void LKIICDHGCMD(PlayerButton HHDMPJJAPJJ)
		{
		}

		public void SetAccountsSimple(IEnumerable<DFDECAEJBIO> AGIGKKMBEKN)
		{
		}

		public void SetAccounts(IEnumerable<DFDECAEJBIO> AGIGKKMBEKN, AccountSpecificUIBehaviour.PlayerDisplayMode AIDOCIKAKCJ, bool OPKEFNEECKK)
		{
		}

		protected override void ANLHNIJPJEC(DFDECAEJBIO ACBGBAAHOIM, PlayerButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
