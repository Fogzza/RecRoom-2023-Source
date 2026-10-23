using System;
using UnityEngine;

public class HeadGestureDetect : MonoBehaviour
{
	public enum FBLFDOGGLGI
	{
		TiltUp = 0,
		TiltDown = 1,
		NodUp = 2,
		NodDown = 3,
		FullNod = 4,
		TurnLeft = 5,
		TurnRight = 6,
		ShakeLeft = 7,
		ShakeRight = 8,
		FullShake = 9,
		LeanLeft = 10,
		LeanRight = 11,
		NodLeft = 12,
		NodRight = 13,
		FullSideNod = 14
	}

	private Action<FBLFDOGGLGI> BLLKDADJGFL__BackingField;

	[SerializeField]
	private float nodSensitivity;

	[SerializeField]
	private float shakeSensitivity;

	[SerializeField]
	private float leanSensitivity;

	[SerializeField]
	private float nodNeutralZone;

	[SerializeField]
	private float shakeNeutralZone;

	[SerializeField]
	private float leanNeutralZone;

	[SerializeField]
	private float timeOut;

	[SerializeField]
	private Transform trackedHead;

	public bool DetailedDetection;

	private float KPHJLDNPHEE;

	private float ACNLCBIAJPK;

	private float KPLIMIJDJPI;

	private float GJBPPDHECOB;

	private float ONJEDBFDBNP;

	private float ICFCNKNGFKM;

	private float IEMCMPOHMEG;

	private float OKPMNDFALCA;

	private bool HDMHENLAACC;

	private bool PKDNPHLCPED;

	private bool MOLHPABBDJH;

	private bool ANFIIGLIMAB;

	private bool MBPOLPOJBHL;

	private bool HDEFMHOPDCK;

	private bool PMJMEMKGNJA;

	private bool COECFDJGLHG;

	private bool JNKJOAPDECO;

	private bool NIFAGJPJGPK;

	private bool EJANNJLILJB;

	private bool IDMODCHCPBN;

	private int FCIFGOHJKOF;

	private int MBIDPBKOIHE;

	private int EIMNGAGHLKI;

	private float EPJEOGHEGBC;

	private float HICDDDEABMC;

	private float ODHHMOBDNBA;

public event Action<FBLFDOGGLGI> GestureDetected {
add {
	}
remove {
	}
}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private float BHEHOHBPFEN(float NNMPJECKECI)
	{
		return 0f;
	}

	private float KCNCMCEGMHP(float NNMPJECKECI, float EFNJCAIBDLA)
	{
		return 0f;
	}
}
