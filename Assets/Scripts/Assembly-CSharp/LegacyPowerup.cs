using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LegacyPowerup : MonoBehaviourPun
{
	public static readonly List<LegacyPowerup> AllPowerups;

	[SerializeField]
	protected Transform visualRoot;

	[SerializeField]
	protected Collider triggerToDisableWhenNotAlive;

	[SerializeField]
	private float value;

	[SerializeField]
	protected bool automaticallyResets;

	[SerializeField]
	protected float resetDuration;

	private global::MOBDJNEDDKC<bool> NMNMONHBBFB;

	private global::MOBDJNEDDKC<bool> OJBLGDIBIBH;

	protected HONEDBECDOK KHHJMMADLKH;

public float PowerupValue
{
get 	{
		return 0f;
	}

}

public bool IsEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool IsAlive
{
get 	{
		return false;
	}

set {
	}
}

	protected override void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected virtual void Update()
	{
	}

	private void IDIEHBILCLL()
	{
	}

	protected virtual void BLLFFGLEOOI()
	{
	}

	public void MasterDisable()
	{
	}

	public void MasterEnable()
	{
	}

	public void MasterOnPickup()
	{
	}
}
