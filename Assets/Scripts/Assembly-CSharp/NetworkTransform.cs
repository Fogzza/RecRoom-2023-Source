using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using RecRoom;
using UnityEngine;

[DisallowMultipleComponent]
public class NetworkTransform : MonoBehaviourPun, KFLNCOLKJEM
{
	public enum NGCFJLCBKBN
	{
		Default = 0,
		SimpleKinematicExtrapolate = 1,
		Extrapolate = 2,
		Interpolate = 3,
		Ignore = 4
	}

	public delegate bool JJNIJDCNDJI(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float JDFDFBKKBPO, out Vector3 MCBCBMFBKCA, out Vector3 MEBJBANMPLK);

	public enum AEOHDPGMGAH
	{
		SetVelocity = 0,
		AddForceVelocityChange = 1
	}

	public class CJGKEHNIBMF
	{
		public NetworkTransform DLFKMDFDAFO;

		public int JLLCCGELHIA;

		public int MEJGJDGBFOK;

		public bool JIPELJMHGEE;

		public bool OGJEFCJPGHJ;

		public bool HDLMPNFDGCI;

		public Vector3 JPBOBPIHNBD;

		public Quaternion BFFEBCMOFHH;

		public bool PHBPGMPJPNI;

		public Vector3 EAFCCNDHBHA;

		public Vector3 NIOCADENHED;

		public Vector3 EEAJIEJHCCI;

		private static readonly ELFDKCLHAMN DGJEOFHPNDP;

		public static short IIADKJHBOIN(StreamBuffer HLHADAOGCMN, object PJGPNPBFMFD)
		{
			return 0;
		}

		public static object BBCFAILGGHN(StreamBuffer FAMJGEFEDDM, short MNKGPEKFPKK)
		{
			return null;
		}
	}

	private static readonly HDHIMOFHFJL AHADDDAMGKE;

	[SerializeField]
	public NGCFJLCBKBN LowFrequencyBehavior;

	[SerializeField]
	public bool extrapolatesDrag;

	[SerializeField]
	public bool ignoreVisibilityOptimizations;

	[SerializeField]
	public bool forceSyncOnPlayerJoin;

	[SerializeField]
	private RigidbodyEx rigidbodyEx;

	[SerializeField]
	private Tool tool;

	[SerializeField]
	private VisibleInCamera visibleInCamera;

	private const float DCKAFJKFLHK = 0.001f;

	private const float IJFKPNKBCNH = 0.5f;

	private const float BAKHGJBMEIK = 0.0001f;

	private const float AEJOHOOGEFO = 0.05f;

	private const float LDJBICKJOBL = 0.05f;

	private const float IBKLNFLFDIA = 0.2f;

	private const float AAOOOJOCFEI = 0.25f;

	private const int KPCNCKJNJAL = 5;

	private const float JGAKAOKGMFL = 0.5f;

	private const float FKEEPGGKLHN = 3f;

	private const float OICKGFENJIJ = 5f;

	private const float FDEACGINBEO = 1000f;

	private const int EJPEEPGBPED = 63;

	public const float UncompressedRotationThreshold = 32.489998f;

	[NonSerialized]
	public JJNIJDCNDJI StreamWriteTransformProvider;

	[NonSerialized]
	public bool RunCollisionDetectionWhileExtrapolating;

	[NonSerialized]
	public List<CHILKDJABBF> PotentialOwners;

	private bool NMFAFIBDCEA;

	private bool AHNFPJMHOLA;

	private bool AEIFKPDJIEE;

	private FIHGBEHGLGB NPDAIIIABKJ;

	private Collider CHPKFDDJMPD;

	private float CPCFNPBAIGP;

	private int KDAEIMPLHIC;

	private bool CEJFJCJIKBC;

	private float BGAJMIKGCBH;

	protected Vector3 HCKIACBCBDM;

	protected Vector3 DNKEILBJEBL;

	private float BIHOMOCJJNK;

	private int AONMLCAJEEC;

	private int CJMJJEDLPAB;

	private bool JMIGFEOGBJP;

	private bool APMFHOBCPJP;

	private Vector3 GDJDJENNEOL;

	private Quaternion EIGBNPIMNII;

	private Vector3 PJCHNBMHHCK;

	private Vector3 GJMMEIFACIB;

	private Vector3 JBFIJNFPJLA;

	private Vector3 KAMCONMDPMA;

	private Vector3 ALBCHFMLOEO;

	private Vector3 FPFFINOFKPA;

	private int MJPIEPNALIG;

	private bool DADONFHFJKA;

	private bool LECJCJFAFPI;

	private bool AOEBEGFNLAA;

	private bool KNFLHHMKAEF;

	private bool BNBCJBNGKEI;

	private CJGKEHNIBMF KBKJADAEFED;

	private float OLOJLDCNDFJ;

	private float IPPCLAEDLEN;

	private bool KLLJAAMJIIP;

	private bool NNNBPNGEKAK;

	private bool LOKBNHOLIDN;

	private bool IELPHHLCFJA;

	private bool IONHGCKNNPC;

	private AEOHDPGMGAH HNIHNPEDPKK;

	private float MJEJANMFGAH;

	public Action ValidPositionBoundsExceeded;

	public Action OnDiscontinuousMovement;

	public Action OnAuthorityAcquired;

public bool UseCompressedRotation
{
get 	{
		return false;
	}

set {
	}
}

public bool UseCompressedPosition
{
get 	{
		return false;
	}

set {
	}
}

public bool SyncDeformationScale
{
get 	{
		return false;
	}

set {
	}
}

public bool AllowCompression
{
get 	{
		return false;
	}

}

private Vector3 NLAMDEGFNOM
{
get 	{
		return default;
	}

}

private Quaternion EHBMBHMJCHK
{
get 	{
		return default;
	}

}

private Vector3 AICKBHPEOBL
{
get 	{
		return default;
	}

}

private Vector3 IDNCFNCNMOI
{
get 	{
		return default;
	}

}

private Vector3 NDOEIGPOEEE
{
get 	{
		return default;
	}

}

public bool IgnoreVisibilityOptimizations
{
get 	{
		return false;
	}

}

public float MaxDistanceDiscrepancyBeforeSnap
{
get 	{
		return 0f;
	}

set {
	}
}

public bool UseDynamicDistanceExtrapolation
{
get 	{
		return false;
	}

set {
	}
}

public bool SynchronizationReadingEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool SynchronizationWritingEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool SynchronizationSmoothMovementEnabled
{
get 	{
		return false;
	}

set {
	}
}

public bool ReceivingLowFrequencyUpdates
{
get 	{
		return false;
	}

set {
	}
}

private bool GJIHCFFIFKJ
{
get 	{
		return false;
	}

}

public AEOHDPGMGAH PhysicsMode
{
get 	{
		return AEOHDPGMGAH.SetVelocity;
	}

set {
	}
}

public float LastSyncSentTime
{
get 	{
		return 0f;
	}

private set {
	}
}

public Vector3 LastSyncPosition
{
get 	{
		return default;
	}

}

	public static bool CanCompressRotationForSize(float IJAMHPOPFHB)
	{
		return false;
	}

	public void AddCompressionRestriction(object IALNODEHBNN)
	{
	}

	public void RemoveCompressionRestriction(object IALNODEHBNN)
	{
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	public void RecordInitialSpawnData()
	{
	}

	protected override void OnDestroy()
	{
	}

	private bool JEPPDHHAANF(Vector3 OGDMECABMNI)
	{
		return false;
	}

	private bool GDIEPDFPDGC(Vector3 BAGMHHCMNNF, Quaternion DNEFKBEHEEC, Vector3 MDNBDKOFNIK)
	{
		return false;
	}

	private bool HIHLFLPIJLB()
	{
		return false;
	}

	public void OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
	{
	}

	private void LHOJKHNDINB(string AHNIMJDLOPB)
	{
	}

	private float CNPCNCLAOBA()
	{
		return 0f;
	}

	private void CBMIMPPKIIJ()
	{
	}

	private void HNIHGGHCNDN()
	{
	}

	public void InsertPositionDiscontinuity(bool LDFNPCBGCKP = false)
	{
	}

	private void HGAPIOJLHFO()
	{
	}

	private void PKCMCILINPD(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JDFDFBKKBPO, int AONMLCAJEEC)
	{
	}

	private void ADCDHCKDAOB()
	{
	}

	private void AOFFJNFAKHA()
	{
	}

	private void LBGAEALHOFJ()
	{
	}

	private void ELILLGGIFIG()
	{
	}

	private Vector3 JFGALIEAKKC(float BFJGENAHBKJ)
	{
		return default;
	}

	private Quaternion FFOMBLIPMJG(float BFJGENAHBKJ)
	{
		return default;
	}

	protected virtual void LCEKOIAFDFO(float BFJGENAHBKJ, out Vector3 BHDDGLNLJIF, bool ADBGPHJAPMI = false)
	{
		BHDDGLNLJIF = default;
	}

	private void OBLDMAHDBCK()
	{
	}

	private float OGBPLCPGFJL()
	{
		return 0f;
	}

	private void NBJOKPLKCNH()
	{
	}

	public void FixedUpdate()
	{
	}

	private void JEJJPLBFILL()
	{
	}

	private bool OLLJIPNIGEA()
	{
		return false;
	}

	private Vector3 DFPCFHKBIFE(Vector3 CDCEFBJHIAN)
	{
		return default;
	}

	private void IHLNPHDKJOO(Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK, Vector3 JDFDFBKKBPO)
	{
	}

	private void NBECOODGFHA(Vector3 JDFDFBKKBPO)
	{
	}

	private void OBDKHJLBLOL(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH)
	{
	}

	private void AFEMPAEIAHA(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JDFDFBKKBPO)
	{
	}

	private void JOGNNCNINMM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JDFDFBKKBPO)
	{
	}

	private void HKBNAFFJHCA(Vector3 FJEIPCCFKEB, Vector3 FLBMFCPCPEF)
	{
	}

	private bool KMOIFMOKNKE()
	{
		return false;
	}

	private void NHJOPMPGEFM(RigidbodyEx FNBMGBEMKPE)
	{
	}

	private void DAFKBHGEFHJ(CHILKDJABBF HIGOLKPFBPL)
	{
	}

	private void OnPhotonPlayerConnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	[PBOMGCLBFHF]
	protected void RpcForceDiscontinuitySync(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JDFDFBKKBPO, int AONMLCAJEEC)
	{
	}
}
