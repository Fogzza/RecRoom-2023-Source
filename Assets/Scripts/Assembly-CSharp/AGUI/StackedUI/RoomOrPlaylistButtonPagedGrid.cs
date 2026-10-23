using System.Collections.Generic;

namespace AGUI.StackedUI
{
	public class RoomOrPlaylistButtonPagedGrid : RecyclerPagedGrid<OAHIIBBLMCD, RoomOrPlaylistButton>
	{
		private sealed class JLOPFDMKPKE
		{
			public JCDPHCELKHI room;

			public COJJLLLOCNL playlist;

			internal bool _003CAddItemToCurrentListIfNotPresent_003Eb__0(JCDPHCELKHI r)
			{
				return false;
			}

			internal bool _003CAddItemToCurrentListIfNotPresent_003Eb__1(COJJLLLOCNL p)
			{
				return false;
			}
		}

		private DBECJLAIPEL CFBNOKOADFB;

		private string AHDJEHLAPED;

		protected override void Awake()
		{
		}

		protected override void ANLHNIJPJEC(OAHIIBBLMCD EJMOCIAPCPJ, RoomOrPlaylistButton JHAHOJKBMJD, int GMEHLIHLGEH)
		{
		}

		public void SetItems(IEnumerable<OAHIIBBLMCD> JNAAHMPCPAB, DBECJLAIPEL CFBNOKOADFB)
		{
		}

		public void AddItemToCurrentListIfNotPresent(OAHIIBBLMCD ONCGIPFNENB)
		{
		}

		public RoomOrPlaylistButton GetFirstEnabledButton()
		{
			return null;
		}

		public int FindPageIndexOfRoomOrPlaylist(string DKMGLGNLJCJ)
		{
			return 0;
		}
	}
}
