using RecRoom.Core.AI;
using RecRoom.Core.Pools;
using UnityEngine;

public class LaserTrap : Trap
{
	private enum JDEKLPDGGBN
	{
		PING_PONG = 0,
		PING_PONG_STOP_AT_EACH_NODE = 1,
		LOOP = 2,
		LOOP_STOP_AT_EACH_NODE = 3
	}

	private enum EACKKIDDBOA
	{
		PARALLEL = 0,
		PERPENDICULAR = 1
	}

	[SerializeField]
	private Transform[] lasers;

	[SerializeField]
	private float maxLaserLength;

	[SerializeField]
	private float rotationSpeed;

	[SerializeField]
	private float slowdownAngle;

	[SerializeField]
	private Transform[] targetPath;

	[SerializeField]
	private int initialNodeIndex;

	[SerializeField]
	private JDEKLPDGGBN pathingMode;

	[SerializeField]
	private EACKKIDDBOA laserRotationMode;

	[SerializeField]
	private PooledParticle impactParticlePrefab;

	private static readonly RaycastHit[] OAIOLCCDNFH;

	private global::JPEBBAFCBEP<int, int> JCBEPAEKDCA;

	private Steering OHPLGHHAECG;

	private Quaternion BLNMCJILHIJ;

	private JPMBLKCPNAG NDNPDBJKCIA;

	private PooledParticle[] BCFIDLEJLMG;

	private static Vector3 HLHJEKKCPAH;

private int OMIJJCDNKFF
{
get 	{
		return 0;
	}

}

private int EENKHJPIJOK
{
get 	{
		return 0;
	}

}

private int LDODPBJLLGL
{
get 	{
		return 0;
	}

}

	protected override void Awake()
	{
	}

	protected override void Start()
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

	private void MGKIHJHMPPK(int CDDPLNMEOPL)
	{
	}

	private bool LEOBNGPKCGM(RaycastHit KHFHAAMKDHD)
	{
		return false;
	}

	private void OBBELMIGFDC()
	{
	}

	private Vector3 PGPLANDIFOM(int BPNJACICPLM)
	{
		return default;
	}

	private void OFEPEAHDIOB()
	{
	}

	private void JDDBIAAPLNE()
	{
	}

	private int GIGNJOEALKF(int OPBKNDBJHEL, int FKMCGMMGKJL)
	{
		return 0;
	}

	private int MFMEAANOALA(int OPBKNDBJHEL)
	{
		return 0;
	}

	private int PJJLIECKLLG(int OPBKNDBJHEL, int FKMCGMMGKJL)
	{
		return 0;
	}

	private void AOPDFDCOLFL()
	{
	}

	private void PGEFKAINPCM()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
