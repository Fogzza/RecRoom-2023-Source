using Photon.Pun;
using RecRoom.Core.Pools;
using UnityEngine;

public class PlayerProgression : MonoBehaviourPun
{
	public enum OKADFLLOJIE
	{
		LevelUp = 0,
		Cheer = 1,
		BlowOutCandles = 2
	}

	[SerializeField]
	private PooledParticle levelUpParticlesPrefab;

	[SerializeField]
	private PooledParticle cheerParticlesPrefab;

	[SerializeField]
	private PooledParticle blowingOutCandlesParticlesPrefab;

	private Player PGKEHBCKJKI;

	public static readonly global::HHOBPMOCKMJ<PooledParticle> LocalPlayerAcquiredLevelUpParticleEvent;

	protected override void Awake()
	{
	}

	public void PlayLevelUpFeedback()
	{
	}

	public void PlayCheerFeedback()
	{
	}

	public void PlayCandlesFeedback()
	{
	}

	[PBOMGCLBFHF]
	private void RpcPlayLevelUpFeedback(OKADFLLOJIE EJHOFMJNGEO)
	{
	}
}
