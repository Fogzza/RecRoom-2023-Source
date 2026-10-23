using System.Collections.Generic;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

public class SteamTrap : Trap
{
	private enum JFFCNLBLBOE
	{
		INVALID = 0,
		DELAY = 1,
		OFF = 2,
		WARNING = 3,
		ON = 4
	}

	[SerializeField]
	private Transform[] steamEmissionTransforms;

	[SerializeField]
	private OverlapVolume collisionVolume;

	[SerializeField]
	private float initialDelay;

	[SerializeField]
	private float offDuration;

	[SerializeField]
	private float warningDuration;

	[SerializeField]
	private float onDuration;

	[SerializeField]
	private PooledParticle warningParticlesPrefab;

	[SerializeField]
	private PooledParticle steamParticlesPrefab;

	[SerializeField]
	private RecRoomAudioClip warningLoopingAudio;

	[SerializeField]
	private RecRoomAudioClip steamLoopingAudio;

	private const float BFNHFINOGGP = 5f;

	private const float FENCOOENNDL = 25f;

	private SFXAudioSource MMOELAACAEH;

	private List<PooledParticle> DGPNEBABJBP;

	private JOJOABLFOBA BGBIFFLGANM;

	private HONEDBECDOK IFCDBBCODHP;

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Update()
	{
	}

	protected override void IDIEHBILCLL()
	{
	}

	private void OJDBDBMJOHF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void CIKKBJICGDL()
	{
	}

	private void DLFAKPCMELN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void LJPBCIFJCIB()
	{
	}

	private void KHIGGCOHMOI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void JFCMMDBHBOM()
	{
	}

	private void FCKEBGNPMJH(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void GEACJENMDDI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
	{
	}

	private void KMBBFOIPNJL()
	{
	}

	private void GOJPMNGLIOD(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
	{
	}

	private void DDDBIDAAHJJ(Transform HOFBFBKNDPC, PooledParticle GLEIJHOELIP, float FGBPJMKCMAO)
	{
	}

	private void LNDFIHPKJGC()
	{
	}

	private void ODPGIIFEBJI(RecRoomAudioClip PHJDMMIAGCB)
	{
	}

	private void JDAPMPFPAJG()
	{
	}

	private void AODPMEGEMIE()
	{
	}
}
