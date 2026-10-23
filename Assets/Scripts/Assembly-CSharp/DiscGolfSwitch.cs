using Photon.Pun;
using UnityEngine;

public abstract class DiscGolfSwitch : MonoBehaviourPun
{
	public enum CHNHGDDOBIK
	{
		INVALID = -1,
		OFF = 0,
		ON = 1,
		STATE_0 = 2,
		STATE_1 = 3,
		STATE_2 = 4,
		STATE_3 = 5,
		STATE_4 = 6
	}

	[SerializeField]
	private CHNHGDDOBIK initialState;

	private global::MOBDJNEDDKC<CHNHGDDOBIK> LMMEGEIPPLM;

public CHNHGDDOBIK CurrentState
{
get 	{
		return CHNHGDDOBIK.OFF;
	}

set {
	}
}

	protected override void Awake()
	{
	}

	protected virtual void DJDGPEDKHHK()
	{
	}
}
