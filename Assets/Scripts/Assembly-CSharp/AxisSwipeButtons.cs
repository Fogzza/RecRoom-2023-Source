using System;
using UnityEngine;

[Serializable]
public class AxisSwipeButtons : AxisButtons
{
	public enum HPNNNBDBBDB
	{
		None = 0,
		Swiping = 1,
		SwipeComplete = 2,
		Touch = 3
	}

	[SerializeField]
	private float maxSwipeTime;

	[SerializeField]
	private float minSwipeDistance;

	private bool swipeIsValid;

	private Vector2 swipeDisplacement;

	private Vector2 latestPosition;

	private float swipeStartTime;

	public HPNNNBDBBDB SwipeState { get; private set; }

	public override void CDJHKCNAIKI(Vector2 OJBODCOIDJO, bool MKGANNDBJBC, bool FLPEAFHLCLG = true)
	{
	}
}
