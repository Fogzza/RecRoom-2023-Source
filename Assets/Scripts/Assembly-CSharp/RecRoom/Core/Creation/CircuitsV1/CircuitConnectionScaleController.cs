using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class CircuitConnectionScaleController : MonoBehaviour
	{
		private enum KMBOGJLGIKN
		{
			X = 0,
			Y = 1,
			Z = 2,
			Num = 3
		}

		private enum JJLDIBABFCL
		{
			Vertical = 0,
			Horizontal = 1
		}

		private const float NPNCFFICIFO = 0.2f;

		private const float BMJJBAIPJLO = 3.5f;

		private const float BHCPAIOAAKI = 3.1f;

		private const float KFLOCLCLAAD = 0.4f;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private Collider connectedBounds;

		[SerializeField]
		private SimpleVolume connectedBoundsSimple;

		private CircuitConnectionPoint[] LJBPEMPDGME;

		private KMBOGJLGIKN PGPLIOFPEIA;

		private KMBOGJLGIKN FBPGMGEHCGB;

		private JJLDIBABFCL KDFFDNDOFHJ;

		private Vector3 PMEGFDMDFOI;

		private Transform GGJFJFGDHDO;

		private Vector3 KJFCFDOIOLC;

		private float BNEJPJBHIHC;

		private void OnEnable()
		{
		}

		private void Awake()
		{
		}

		private JJLDIBABFCL KBPPOENNICD()
		{
			return JJLDIBABFCL.Vertical;
		}

		private void GFOGNLJOKBB()
		{
		}

		private KMBOGJLGIKN APJNNGDLENI(Vector3 GDBPMENFPOA, Transform PDGICJHINGM)
		{
			return KMBOGJLGIKN.X;
		}

		private float IDFJDBCPNLD(Vector3 CAPKFCHDLFA, KMBOGJLGIKN OJBODCOIDJO)
		{
			return 0f;
		}

		private Vector3 EACDNBCDDDL(Transform FGOKLFNNANA, KMBOGJLGIKN OJBODCOIDJO)
		{
			return default;
		}

		private void ILCMMDNEBBH()
		{
		}

		private void PPIBIDGEBAI(Transform PEFALILIJJC, int IHDLEEBDPPI, float MEJGGLKOEMF, float LHEHHLPPJII, float NEMOICOLEKL, float KAPDJBAJNDE, JJLDIBABFCL OAIIAIGAFIL = JJLDIBABFCL.Horizontal)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
