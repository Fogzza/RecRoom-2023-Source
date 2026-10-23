using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine.Events;

namespace RecRoom.AGUI
{
	public class RoomInstancePagedGrid : RecyclerPagedGrid<BHDAFFMJAIN, RoomInstanceRow>
	{
		[Serializable]
		public class JoinButtonClickEvent : UnityEvent<BHDAFFMJAIN>
		{
		}

		private sealed class EBOFNGNHEIF
		{
			public RoomInstancePagedGrid _003C_003E4__this;

			public RoomInstanceRow row;

			internal void _003CSetupNewChild_003Eb__0()
			{
			}
		}

		private sealed class BPNDHNJGODL
		{
			public long currentRoomInstanceId;

			internal int _003CSetRoomInstances_003Eb__0(BHDAFFMJAIN x, BHDAFFMJAIN y)
			{
				return 0;
			}
		}

		public JoinButtonClickEvent OnJoinButtonClicked;

		protected override void LKIICDHGCMD(RoomInstanceRow IHCPKAJHPBL)
		{
		}

		public void EnableButtons(bool OBFHBDLKFPA)
		{
		}

		public void SetRoomInstances(List<BHDAFFMJAIN> JGOHKEBHOBP, long KBBOEJKCAFI)
		{
		}

		protected override void ANLHNIJPJEC(BHDAFFMJAIN CMDPMJBEBAB, RoomInstanceRow HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
