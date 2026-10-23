using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine.Events;

namespace RecRoom.AGUI
{
	public class ChooseFriendPagedGrid : RecyclerPagedGrid<DFDECAEJBIO, ChooseFriendButton>
	{
		[Serializable]
		public class SelectedFriendsUpdated : UnityEvent<List<DFDECAEJBIO>>
		{
		}

		private sealed class GKGFDJLADHA
		{
			public ChooseFriendPagedGrid _003C_003E4__this;

			public ChooseFriendButton button;

			internal void _003CSetupNewChild_003Eb__0(bool isOn)
			{
			}
		}

		public SelectedFriendsUpdated OnSelectedFriendsUpdatedEvent;

		private List<DFDECAEJBIO> PNHILOECLKG;

		private bool CGHPOOBJEMN;

		protected override void LKIICDHGCMD(ChooseFriendButton HHDMPJJAPJJ)
		{
		}

		public void SetAccounts(IEnumerable<DFDECAEJBIO> AGIGKKMBEKN, bool NLBHBBJGNEP)
		{
		}

		protected override void ANLHNIJPJEC(DFDECAEJBIO ACBGBAAHOIM, ChooseFriendButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
