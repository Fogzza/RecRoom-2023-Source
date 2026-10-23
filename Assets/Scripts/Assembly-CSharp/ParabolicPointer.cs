using System.Collections.Generic;
using RecRoom.Core.Vehicles;
using UnityEngine;

public class ParabolicPointer : MonoBehaviour
{
	public enum BIIGOOLPJCD
	{
		Valid = 0,
		Invalid = 1,
		Shortened = 2,
		Disabled = 3,
		Invisible = 4,
		FadeOut = 5
	}

	private const int PNCFAGEJFPK = 20;

	private const float OLJKDEBODBD = 30f;

	private const float CDINOAFEJNA = 8f;

	private const float MJLDDFIKLFA = 50f;

	[SerializeField]
	private float minParabolaSegmentLength;

	[SerializeField]
	private float maxParabolaSegmentLegnth;

	[SerializeField]
	private float meshDistanceBetweenVertices;

	[SerializeField]
	private float meshWidth;

	[SerializeField]
	private Vector2 uvScale;

	[SerializeField]
	private float shortenedDistance;

	[SerializeField]
	private float reflectionOffset;

	[SerializeField]
	private int maxSampleCount;

	[SerializeField]
	private float maxPathLength;

	[SerializeField]
	private float startFadeBeginDistance;

	[SerializeField]
	private float startFadeEndDistance;

	[SerializeField]
	private float endFadeBeginDistance;

	[SerializeField]
	private float endFadeEndDistance;

	public float PersonalSpaceFromLaser;

	[SerializeField]
	private Material validTargetMaterial;

	[SerializeField]
	private Material invalidTargetMaterial;

	[SerializeField]
	private Material fadeOutMaterial;

	[SerializeField]
	private Material shortenedTargetMaterial;

	private Vector3 IDHPBIADFMF;

	private Vector3 BAIGDFDLOOM;

	private Vector3 PIBKIIDCGHO;

	private Vector3 NFEFGILKFDC;

	private bool PIIFOECJNDH;

	private Vector3 HFCJPDDIHAE;

	private Vector3 AKAKMJFKBOE;

	private float BNOPJLMFBFE;

	private BIIGOOLPJCD BMECLKABPAG;

	private LaserTeleporter PFLHFIDNDAD;

	private static readonly int OJGKDBBFDPB;

	private Mesh DJGDPDGELGI;

	private List<Vector3> PMBGMPIKLIP;

	private KKGCOBPPLHO PIJCLJJFHOE;

	private List<Vector3> LAPIMJGCFJK;

	private List<Color> ICLOECMPANC;

	private List<Vector2> GBFHFBNBEJH;

	private List<Vector2> OKPEEEJMPNC;

	private List<int> NLIOAFGKLJM;

	private TeleportationPortal CLHGCLMCAFA;

	public Tool HitTool;

	public Vector3 HitToolPosition;

	public Vector3 HitToolNormal;

	public FixedPathVehicle HitVehicle;

	public bool HitSomething;

	public bool HitColliderSupportsTeleport;

	private bool DCMCPJJPKHD;

	private Material IPPEFMDMHFB;

	private static Color? OAIBPJEPHEL;

	public float ArcSpeed;

	private RaycastHit FFNNKMFECFP;

public Vector3 InitialParabolaPoint
{
get 	{
		return default;
	}

private set {
	}
}

public Vector3 InitialParabolaTangent
{
get 	{
		return default;
	}

private set {
	}
}

public Vector3 FinalParabolaTangent
{
get 	{
		return default;
	}

private set {
	}
}

public Vector3 FinalParabolaPoint
{
get 	{
		return default;
	}

private set {
	}
}

public bool Reflected
{
get 	{
		return false;
	}

private set {
	}
}

public Vector3 ReflectionPoint
{
get 	{
		return default;
	}

private set {
	}
}

public Vector3 ReflectionTangent
{
get 	{
		return default;
	}

private set {
	}
}

public float CurrentParabolaAngle
{
get 	{
		return 0f;
	}

private set {
	}
}

public BIIGOOLPJCD Mode
{
get 	{
		return BIIGOOLPJCD.Valid;
	}

set {
	}
}

public LaserTeleporter LaserTeleporter
{
get 	{
		return null;
	}

set {
	}
}

public TeleportationPortal TeleportationPortal
{
get 	{
		return null;
	}

set {
	}
}

public bool PointOnNavMesh
{
get 	{
		return false;
	}

set {
	}
}

public Color LaserColor
{
get 	{
		return default;
	}

set {
	}
}

private Material NFOHHLJAHJK
{
get 	{
		return null;
	}

}

public static Color? DefaultLaserColor
{
get 	{
		return null;
	}

private set {
	}
}

private Material EFHBDFNHMBF
{
get 	{
		return null;
	}

}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void PerformParabolicRaycasts(Vector3 BKIKCBGLODC, Vector3 HJPAJNOCGPD, float DJOFHCKIOGH, float HEMEEHMNIIN, float HFEJOPAPMDJ)
	{
	}

	public void ClearParabolicRaycasts()
	{
	}

	public void SetParabolaPoints(Vector3 BKIKCBGLODC, Vector3 BHJBBKPJJPC, Vector3 CMFOGNPMNEJ, Vector3 GLENOHNHMGF)
	{
	}

	public void SetParabolaPointsWithReflection(Vector3 BKIKCBGLODC, Vector3 BHJBBKPJJPC, Vector3 CKEGMKJDCKB, Vector3 AJHDADNEDJB, Vector3 CMFOGNPMNEJ, Vector3 GLENOHNHMGF)
	{
	}

	private bool DAMCKPOHADN(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, out RaycastHit KHFHAAMKDHD, bool NFCGMANKFFK = true)
	{
		KHFHAAMKDHD = default;
		return false;
	}

	public static bool ParabolicPointerCollisionFilter(Collider ADMCDJKKCIA)
	{
		return false;
	}

	private static void BCANKEKIBAD(Collider ADMCDJKKCIA, ref bool MLNOEBPBEOK, ref TeleportationPortal IADDDNCGGGC, ref FixedPathVehicle FKLJAAAAAND, ref Tool LMEKFBDFCDN)
	{
	}

	private void NFONNOEHENG()
	{
	}

	private static float GAOGMADDDGH(float DBJCEIOACJO, float JMLGEONLBNM, float NNMPJECKECI, float IHPJCBCPLCM)
	{
		return 0f;
	}

	private static float DIBLGDDAEKN(float JMLGEONLBNM, float NNMPJECKECI, float IHPJCBCPLCM)
	{
		return 0f;
	}

	private static Vector3 GAOGMADDDGH(Vector3 DBJCEIOACJO, Vector3 JMLGEONLBNM, Vector3 NNMPJECKECI, float IHPJCBCPLCM)
	{
		return default;
	}

	private static Vector3 DIBLGDDAEKN(Vector3 JMLGEONLBNM, Vector3 NNMPJECKECI, float IHPJCBCPLCM)
	{
		return default;
	}

	private bool PIEIAHOBCPH(Vector3 BKIKCBGLODC, Vector3 HJPAJNOCGPD, Vector3 NNMPJECKECI, float CMFOCBINFKC, float HEMEEHMNIIN)
	{
		return false;
	}

	private static bool MHFDIIFANIP(Vector3 PDFEDMAOMNH)
	{
		return false;
	}

	private bool CHCCKJFLGEB(Vector3 PCGFKGLHLFP, Vector3 ICIKOCELOLI, Vector3 PLKCNIBDCDC, float NNLEGJGIGHA, out Vector3 BBOLIJMGKDH)
	{
		BBOLIJMGKDH = default;
		return false;
	}

	private bool GBOLLNLALFD(Vector3 MEJLOHFJJGD, float CMFOCBINFKC, float NBFAPFCKNHO, float HEMEEHMNIIN, float EGMJGPLIJJF, out Vector3 CKEGMKJDCKB, out Vector3 JGBFELBEKKD, out bool FJBJFJIEDHD)
	{
		CKEGMKJDCKB = default;
		JGBFELBEKKD = default;
		FJBJFJIEDHD = default;
		return false;
	}

	private KKGCOBPPLHO HAGLNFDBKAH(Vector3 CFNMFALFFHL)
	{
		return null;
	}

	private void CJOPCJGALNK(Vector3 BKIKCBGLODC, Vector3 BHJBBKPJJPC, Vector3 CMFOGNPMNEJ, Vector3 PFJPMEMOJKD)
	{
	}

	private void DMPDDNLLNAH(ref Mesh AAKOJGEOGGC, KKGCOBPPLHO KDENKOIEIEI, float MHGGMDKJNLA, Vector3 BPKEANIGKON, float BFHNBDIDMCI)
	{
	}

	private void LJIJPJEMHAM(Vector3 BKIKCBGLODC, Vector3 BHJBBKPJJPC, Vector3 CMFOGNPMNEJ, Vector3 PFJPMEMOJKD, out Vector3 OOJLHFJMKNL, out Vector3 CFNFGJOBMHH)
	{
		OOJLHFJMKNL = default;
		CFNFGJOBMHH = default;
	}

	private float LDBNNGFDNNN(float DJOFHCKIOGH)
	{
		return 0f;
	}

	private Vector3 NGKLCOOHMAJ(float DJOFHCKIOGH)
	{
		return default;
	}

	private void OnDrawGizmos()
	{
	}
}
