using System;
using System.Collections.Generic;
using AGUI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TierRewardPagedGrid : RecyclerPagedGrid<KGFLMPJOODP, TierRewardSpawner>
{
	[Serializable]
	public class BuyTierEvent : UnityEvent<int>
	{
	}

	private sealed class MNCPPHLCLIO
	{
		public TierRewardPagedGrid _003C_003E4__this;

		public TierRewardSpawner button;

		internal void _003CSetupNewChild_003Eb__0()
		{
		}
	}

	[SerializeField]
	private Image freeBackground;

	[SerializeField]
	private Image paidBackground;

	[SerializeField]
	private Color freeRewardsColor;

	[SerializeField]
	private Color paidRewardsBasicPlayerColor;

	[SerializeField]
	private Color paidRewardsElitePlayerColor;

	private HNJJEAFLMFO BFFCGPJEHGB;

	private WatchUIFlow DNGMGCOOONO;

	public BuyTierEvent OnBuyTierEvent;

	protected override void LKIICDHGCMD(TierRewardSpawner HHDMPJJAPJJ)
	{
	}

	public void SetTiers(IEnumerable<KGFLMPJOODP> EFFODNFDHEK, HNJJEAFLMFO JDBHABEFGKF, WatchUIFlow HCDENHFGFNP)
	{
	}

	public void UpdateBuyButton(int GMDMKEPHEBP, bool PCNPMPMHGHF, string HLIGBKANEEA)
	{
	}

	public Transform GetUnlockedTierTransform(int GMDMKEPHEBP)
	{
		return null;
	}

	public void PlayUnlockAnimation(int GMDMKEPHEBP, float FGBPJMKCMAO)
	{
	}

	protected override void ANLHNIJPJEC(KGFLMPJOODP JHHLNFDJCHE, TierRewardSpawner PGDBOCOHNBL, int GNGEFBBFBLF)
	{
	}
}
