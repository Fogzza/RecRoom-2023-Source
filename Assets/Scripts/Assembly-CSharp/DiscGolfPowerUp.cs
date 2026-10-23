using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;
using UnityEngine.UI;

public class DiscGolfPowerUp : LegacyPowerup
{
	public delegate void HGAKHJFGJNA(DiscGolfPowerUp JAPGGJKJGEO, DiscGolfDisc ENECPPAOOCM, Player GBEPPMIOPGE);

	[SerializeField]
	private MFCPKKGGLNF hole;

	[SerializeField]
	private int scoreAdjust;

	[SerializeField]
	private Text scoreAdjustText;

	[SerializeField]
	private PooledParticle hitParticles;

	[SerializeField]
	private RecRoomAudioClip onHit;

	private CollisionForwarder PKJEKGALNNI;

	private Vector3 GAKGLCAJMDK;

	public HGAKHJFGJNA PickupEvent;

public MFCPKKGGLNF Hole
{
get 	{
		return MFCPKKGGLNF.HOLE_1;
	}

}

public int ScoreAdjust
{
get 	{
		return 0;
	}

}

public bool LocalEnabled
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

	protected override void OnDestroy()
	{
	}

	private void OnTriggerEnter(Collider ADMCDJKKCIA)
	{
	}

	public void OnPickup()
	{
	}

	protected override void BLLFFGLEOOI()
	{
	}
}
