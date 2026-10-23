using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine.Events;

namespace RecRoom.AGUI
{
	public class InviteClubButtonsPagedGrid : RecyclerPagedGrid<EPILDIJELPG, InviteClubButton>
	{
		[Serializable]
		public class SelectedClubUpdated : UnityEvent<EPILDIJELPG>
		{
		}

		private sealed class KCJJILKHEHE
		{
			public InviteClubButton button;

			public InviteClubButtonsPagedGrid _003C_003E4__this;

			internal void _003CSetupNewChild_003Eb__0(bool isOn)
			{
			}
		}

		private sealed class BODKJOOFOAE
		{
			public long? selectedClubId;

			internal bool _003CSetClubs_003Eb__0(EPILDIJELPG c)
			{
				return false;
			}
		}

		public SelectedClubUpdated OnSelectedClubUpdatedEvent;

		private IEnumerable<EPILDIJELPG> ICPCBDADNDP;

		private EPILDIJELPG BCFELHFFCHE;

		private bool ANKMAHBMAKI;

		protected override void LKIICDHGCMD(InviteClubButton HHDMPJJAPJJ)
		{
		}

		public void SetClubs(IEnumerable<EPILDIJELPG> NDAEMCFLEJP, long? PFBMOKIGJLK, bool CPLAKCGBMEK)
		{
		}

		public void SetSelectedClub(long? AFPHABFLEBN)
		{
		}

		protected override void ANLHNIJPJEC(EPILDIJELPG APMHMCKALGG, InviteClubButton HHDMPJJAPJJ, int GNGEFBBFBLF)
		{
		}
	}
}
