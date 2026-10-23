using System;
using RecRoom.Core.Vehicles;
using UnityEngine;

public class LaserTeleporter : MonoBehaviour
{
	public enum KCHMBMJKKLA
	{
		ValidTeleportPosition = 0,
		MissedTeleportSurface = 1,
		InvalidTeleportDirection = 2,
		RestrictedTeleportPosition = 3,
		ValidPortalPosition = 4,
		Cooldown = 5,
		Disabled = 6,
		InvalidPortalPosition = 7,
		ValidLevelLoadPortal = 8
	}

	private struct FNMDHCHLIPK
	{
		public bool LKMDAIOLOOC;

		public bool MJAGCEDONCI;

		public Vector3 BAODHIOEBPC;

		public Vector3 NCCIIAOGOIG;

		public bool LPEAGAFNCMG;

		public Vector3 IOPLKBGDDFN;

		public Vector3 LPOEAIFMLHB;

		public TeleportationPortal LIFMPLNBHCI;

		public FixedPathVehicle GAFCBCBDCKA;

		public Tool KPBIMLKIIJG;

		public Vector3 DEKMGILJFMH;

		public Vector3 BDCLDPGIGDH;
	}

	private struct LNCMMBBPKDJ
	{
		public Vector3 JPBOBPIHNBD;

		public Tool KPBIMLKIIJG;

		public Vector3 DEKMGILJFMH;

		public Vector3 BDCLDPGIGDH;

		public Vector3 GOPICGNCPKH;
	}

	private delegate FNMDHCHLIPK KCADKPINDLB(Vector3 PEJEOHJJKBA, Vector3 CNIIOLEKCNA, Vector3 ACEDGHHIEAH, float DJOFHCKIOGH, float OOGEHJDIIKE);

	[SerializeField]
	private Transform laserStartPosition;

	[SerializeField]
	private Transform visualRoot;

	[SerializeField]
	private ParabolicPointer parabolicPointer;

	[SerializeField]
	private PlayerTeleportDecal playerTeleportDecalPrefab;

	public static readonly float HEAD_COLLISION_RADIUS;

	[SerializeField]
	private float toolHitWindow;

	[SerializeField]
	private float maxPitchDegrees;

	[SerializeField]
	private BoxCollider worldOverlapCollider;

	[SerializeField]
	private FloatValueCurve toolHitForceCurve;

	private PlayerTeleportDecal FPFDKKKNGEC;

	private GameObject IJBDFCIAOKG;

	private float KOJHKKPOIGI;

	private LNCMMBBPKDJ KBLPNHDKABK;

	private TeleportationPortal CADJEKFCELM;

	private Vector3 HFBFLDIFIDI;

	private FixedPathVehicle JBMMLKOGFLA;

	private Player JCPLJCIFGFK;

	private PlayerHand JHDKMHPLHAH;

	[NonSerialized]
	public bool DecalCylinderVisible;

	private Color? IDDIECGAFKJ;

	public Action<Color?> LaserColorChanged;

	private Vector3 LMEGMGCNAAD;

	private KCHMBMJKKLA FBIBPBIHDNK;

	[HideInInspector]

public Player Player
{
get 	{
		return null;
	}

set {
	}
}

public PlayerHand Hand
{
get 	{
		return null;
	}

set {
	}
}

public Color? LaserColor
{
get 	{
		return null;
	}

set {
	}
}

public bool Visible
{
get 	{
		return false;
	}

}

private bool LLEFKOAFCBI
{
get 	{
		return false;
	}

}

private KCHMBMJKKLA FEPANAEOPID
{
get 	{
		return KCHMBMJKKLA.ValidTeleportPosition;
	}

set {
	}
}

private float KOFGGFFIAGJ
{
get 	{
		return 0f;
	}

}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	public void UpdateTeleportTargetParabolic(bool PHGILJMHKFI, bool OOELPAOHGIE, Vector3 MJLDFDINHIN, Vector3 DBGOHBPFIJD, Vector3 GJAOGLEMLEP)
	{
	}

	public void TryToTeleport()
	{
	}

	public void ResetTarget()
	{
	}

	private KCHMBMJKKLA BNJJCNGEEIM(bool PHGILJMHKFI, bool OOELPAOHGIE, KCADKPINDLB OADHHHFAILA, Vector3 PEJEOHJJKBA, Vector3 CNIIOLEKCNA, Vector3 ACEDGHHIEAH, bool KGNIEPLHLDF, float DJOFHCKIOGH, float OOGEHJDIIKE, ref FNMDHCHLIPK CDNLFEOBNKB)
	{
		return KCHMBMJKKLA.ValidTeleportPosition;
	}

	private FNMDHCHLIPK PCJEJOMKOND(Vector3 PEJEOHJJKBA, Vector3 CNIIOLEKCNA, Vector3 ACEDGHHIEAH, float DJOFHCKIOGH, float OOGEHJDIIKE)
	{
		return default;
	}

	private void LKOICLHFFCI()
	{
	}

	public void RequestTeleport(Vector3 INLGLHIPOMC)
	{
	}

	private void JPAKIAGHMGL()
	{
	}

	private bool LIPEMCEAGMK(float EJCIDELHJEK)
	{
		return false;
	}

	public void HandlePhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
	{
	}
}
