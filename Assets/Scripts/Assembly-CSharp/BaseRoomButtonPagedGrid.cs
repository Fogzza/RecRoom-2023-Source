using System;
using System.Collections.Generic;
using AGUI;
using AGUI.StackedUI;
using UnityEngine.Events;

public class BaseRoomButtonPagedGrid : RecyclerPagedGrid<JCDPHCELKHI, BaseRoomButton>
{
	[Serializable]
	public class BaseRoomButtonClicked : UnityEvent<JCDPHCELKHI>
	{
	}

	private sealed class CPJHJEEIHEC
	{
		public BaseRoomButtonPagedGrid _003C_003E4__this;

		public BaseRoomButton button;

		internal void _003CSetupNewChild_003Eb__0()
		{
		}
	}

	public BaseRoomButtonClicked OnBaseRoomButtonClicked;

public IEnumerable<BaseRoomButton> BaseRoomButtons
{
get 	{
		return null;
	}

}

	protected override void LKIICDHGCMD(BaseRoomButton HHDMPJJAPJJ)
	{
	}

	public void SetRooms(IEnumerable<JCDPHCELKHI> CECGEDKICOA)
	{
	}

	protected override void ANLHNIJPJEC(JCDPHCELKHI KPFNANKNKLE, BaseRoomButton HHDMPJJAPJJ, int GNGEFBBFBLF)
	{
	}

	public int FindPageIndexOfRoom(string LBGBFPDNKOL)
	{
		return 0;
	}
}
