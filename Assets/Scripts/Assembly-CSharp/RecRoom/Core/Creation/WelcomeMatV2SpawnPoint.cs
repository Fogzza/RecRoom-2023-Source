using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class WelcomeMatV2SpawnPoint : SceneSpawnPoint, GFLPAFBGELM, NEKJJEGPHFG, DJLCHGFCFAD
	{
		private enum HNIHFOMFCCE
		{
			Moving = 0,
			Resizing = 1,
			Available = 2,
			NotAvailable = 3,
			NotEnabled = 4
		}

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private GameObject spawnRegion;

		[SerializeField]
		[HideInInspector]
		private MeshRenderer spawnRegionMeshRenderer;

		[SerializeField]
		[HideInInspector]
		private Transform spawnRegionTransform;

		[SerializeField]
		private float defaultSpawnRadius;

		[SerializeField]
		private float spawnRegionVisualHeight;

		private const float ELBALKNEGJB = 0f;

		private const float COKHNMHIHLN = 5f;

		private const float IBPMGKIBAMB = 0.1f;

		private const float JMAOJDEBFME = 5f;

		private const int EFHIGJAFPJL = 200;

		private const float OGKAINNGICM = 0.3f;

		private static readonly Quaternion OJNHDFPJKBD;

		private const float DCIJLPAHLMC = 1.6f;

		private const float CIOBHMOFCFE = 1f;

		private static Dictionary<HNIHFOMFCCE, Color> EHHALBJKLEF;

		private Vector3 GAJNAIBHLOC;

		private Quaternion LAOAEMPMMLN;

		private float ALBPEBOOLLA;

		private float FNFAJPBKNNP;

		private const float OKFLEOPCBAA = 0.5f;

		private HNIHFOMFCCE HJJNKAPBKPJ;

		private float EBHIOHHICGF;

		private float DECPELNEHAC;

		private float PKDOAAKPLJN;

		private const float KHAPCCBOAJK = 0.5f;

		private global::MOBDJNEDDKC<int> CGKOILMPGFG;

		private global::MOBDJNEDDKC<string> EABPPHBBJEN;

		private global::MOBDJNEDDKC<float> OMLKFOGGFAE;

		private global::MOBDJNEDDKC<bool> AMDPLLOLMBL;

		private global::MOBDJNEDDKC<bool> CGAPAJMHFKC;

		private bool FEAICBMKMNF;

		private Vector3 CBOJKAGEMGI;

		private int NOPDDLGFJCF;

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

public int WelcomeMatId
{
get 		{
			return 0;
		}

private set {
		}
}

public string WelcomeMatName
{
get 		{
			return null;
		}

private set {
		}
}

private float IBMLHOPHKAP
{
get 		{
			return 0f;
		}

set {
		}
}

public override bool IsDefaultSpawnPoint
{
get 		{
			return false;
		}

set {
		}
}

public override bool SpawnPointEnabled
{
get 		{
			return false;
		}

set {
		}
}

private bool JPMMGKADNKO
{
get 		{
			return false;
		}

}

public override bool SupportsPreviousRoomCheck
{
get 		{
			return false;
		}

}

protected override Color BAFJOOPEPHO
{
get 		{
			return default;
		}

}

public override bool IsBlockedByOverlaps
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
		}

		private static bool JHDLBLPFJEL(Vector3 POHJDJLPCDG, out Vector3 FCNGMPHKHAE)
		{
			FCNGMPHKHAE = default;
			return false;
		}

		public override bool IsBlockedAtPosition(Vector3 INLGLHIPOMC)
		{
			return false;
		}

		private static bool KDLGEBGBLEO(Vector3 INLGLHIPOMC, bool GCIIKHAKABM)
		{
			return false;
		}

		private static Vector2 GBJPGIAIPGN()
		{
			return default;
		}

		private bool JOJDEDCGMDB()
		{
			return false;
		}

		private void GJOCIBLLHLJ()
		{
		}

		private bool KOKOANGPCAN()
		{
			return false;
		}

		private bool IHIPLLEACKE(bool INLOMDDIMCG, out Vector3 NMLADJGOEHM)
		{
			NMLADJGOEHM = default;
			return false;
		}

		public override Transform GetFirstAvailableSpawnTransform(out Vector3 ADJINPMOILO, out Quaternion LLJPMBHCKEE)
		{
			ADJINPMOILO = default;
			LLJPMBHCKEE = default;
			return null;
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnValidate()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private static HNIHFOMFCCE JIOENIIMANL(bool LPAJDMBEPBO, bool PCFLHCKCNOH, bool BFDBCMGIOBG, bool IJOKHAGGOEP)
		{
			return HNIHFOMFCCE.Moving;
		}

		private void JLLDGBJPJIO()
		{
		}

		private void DHPJIECKKEN(bool LPAJDMBEPBO, bool PCFLHCKCNOH)
		{
		}

		private bool CHBFLLHMILF()
		{
			return false;
		}

		private bool FDGDOLCNPDL()
		{
			return false;
		}

		private void MHIHLKLLGMA()
		{
		}

		private void HIBCCCDAMDG()
		{
		}
	}
}
