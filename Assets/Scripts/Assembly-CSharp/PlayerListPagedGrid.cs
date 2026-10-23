using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine;
using UnityEngine.Events;

public class PlayerListPagedGrid : RecyclerPagedGrid<int, PlayerListButton>
{
	[Serializable]
	public class ShowPlayerDetailsEvent : UnityEvent<DFDECAEJBIO>
	{
	}

	private sealed class BJAAHLGCEGI
	{
		public PlayerListPagedGrid _003C_003E4__this;

		public PlayerListButton button;

		internal void _003CSetupNewChild_003Eb__0()
		{
		}
	}

	[SerializeField]
	private ShowPlayerDetailsEvent ShowDetailsEvent;

	protected override void LKIICDHGCMD(PlayerListButton HHDMPJJAPJJ)
	{
	}

	public void SetAccountIds(IEnumerable<int> DCCNDPPOHOG)
	{
	}

	protected override void ANLHNIJPJEC(int PCKCPNGPNBJ, PlayerListButton HHDMPJJAPJJ, int GNGEFBBFBLF)
	{
	}
}
