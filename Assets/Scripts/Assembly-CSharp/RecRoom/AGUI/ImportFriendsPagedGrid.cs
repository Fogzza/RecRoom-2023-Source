using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine;
using UnityEngine.Events;

namespace RecRoom.AGUI
{
	public class ImportFriendsPagedGrid : RecyclerPagedGrid<JJGPKBPPDHH, ImportFriendButton>
	{
		[Serializable]
		public class FriendEvent : UnityEvent<int>
		{
		}

		private sealed class JLMPOLAFGLA
		{
			public ImportFriendButton button;

			public ImportFriendsPagedGrid _003C_003E4__this;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}

			internal void _003CSetupNewChild_003Eb__1()
			{
			}
		}

		[SerializeField]
		private FriendEvent DismissEvent;

		[SerializeField]
		private FriendEvent AddEvent;

		protected override void LKIICDHGCMD(ImportFriendButton HHDMPJJAPJJ)
		{
		}

		public void SetAccounts(IEnumerable<JJGPKBPPDHH> MKACDMNEGNA)
		{
		}

		protected override void ANLHNIJPJEC(JJGPKBPPDHH NFBLEIFBPBP, ImportFriendButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
