using System.Text;
using Photon.Pun;
using RecRoom.Persistence;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class WheelSuspension : MonoBehaviourPun, DJLCHGFCFAD
	{
		public struct FGJKPDFNOJO
		{
			public float CPLNIDKPKHM;

			public float MKPAOONKINH;

			public Wheel.EELOGGBOOBJ NONBNIEOADJ;

			public void KMDJNOCMKDB(ELFDKCLHAMN DGJEOFHPNDP)
			{
			}

			public static FGJKPDFNOJO JFDMJLPIIPF(ELFDKCLHAMN DGJEOFHPNDP)
			{
				return default;
			}
		}

		private static readonly RaycastHit[] IBFIMJOMNIJ;

		private const float CNDILCKHKGN = 0.05f;

		private const int EAFDAFAHJJJ = 5;

		private const int NGLKAAHGOJF = 6;

		private const float FHJCDBBEAPM = 0.2f;

		[SerializeField]
		private PersistenceView persistenceView;

		[SerializeField]
		private Wheel wheel;

		[SerializeField]
		private float maxContactNormalAngle;

		[SerializeField]
		private bool useWorldUpForContactAngle;

		[SerializeField]
		private float suspensionMaxExtension;

		[SerializeField]
		private float restCompressionPercentage;

		[SerializeField]
		private float dampingRatio;

		[SerializeField]
		private bool clampDampingForces;

		[SerializeField]
		private float maxDampingForce;

		[SerializeField]
		private bool reduceEfficiencyOnOscillationDetection;

		[SerializeField]
		private float oscillationDetectionAvgVsSumRatioThreshold;

		[SerializeField]
		private bool drawForceRays;

		[SerializeField]
		private float forceRayDuration;

		private FGJKPDFNOJO KBKJADAEFED;

		private float HNGHILFKNGE;

		private float CFLOHGIKLCN;

		private float JNDICLADAMB;

		private float MGFCIKOEFNH;

		private float CBFEHLGIBKI;

		private Vector3 EKPOMBLHBIO;

		private int ADJNLBCKIIL;

		private readonly float[] BDMEAEEFJBL;

		private int IHDFPMOAMKJ;

		private global::MOBDJNEDDKC<bool> PLEHHDEIKEP;

		private global::MOBDJNEDDKC<bool> LKNFEICCOCP;

		private global::MOBDJNEDDKC<bool> OCKHFPEIJPG;

		private global::MOBDJNEDDKC<bool> IMMOEDHMGML;

		private global::MOBDJNEDDKC<float> JIEJCFKLNOH;

		private global::MOBDJNEDDKC<float> ABGPGOMJAHG;

		private global::MOBDJNEDDKC<float> MIFDAADOEOF;

		private global::MOBDJNEDDKC<float> ANDNBCLLGMA;

		private global::JPEBBAFCBEP<float, float> NHJGMPBJGAE;

		private global::JPEBBAFCBEP<float, float> LJGEMODGJJK;

		private global::MOBDJNEDDKC<float> OIKFINCLHKN;

		private global::MOBDJNEDDKC<float> ACBMPEJFCPO;

		private global::MOBDJNEDDKC<float> GPDKDJAOLDF;

		private RigidbodyEx LOHAOHEFAGM;

		private float BIKOFDDLPOH;

		private Vector3 IKLKMCIFDIA;

		private Vector3 PCKAJKLMBCB;

		private Vector3 HHMMICIJDMD;

		private Vector3 HDHLFHIFJKD;

		private float AEBPIPBGGKJ;

public bool CanSteer
{
get 		{
			return false;
		}

set {
		}
}

public bool CanDrive
{
get 		{
			return false;
		}

set {
		}
}

public bool CanHandbrake
{
get 		{
			return false;
		}

set {
		}
}

public bool CanDriveOnWalls
{
get 		{
			return false;
		}

set {
		}
}

public float SuspensionMaxExtension
{
get 		{
			return 0f;
		}

set {
		}
}

public float SuspensionRestCompressionPercentage
{
get 		{
			return 0f;
		}

set {
		}
}

public float SuspensionDampingRatio
{
get 		{
			return 0f;
		}

set {
		}
}

public float WheelCorneringStiffness
{
get 		{
			return 0f;
		}

set {
		}
}

public float WheelLongitudinalFrictionCoefficient
{
get 		{
			return 0f;
		}

set {
		}
}

public float WheelLateralFrictionCoefficient
{
get 		{
			return 0f;
		}

set {
		}
}

public float WheelHandbrakeLongitudinalFrictionMultiplier
{
get 		{
			return 0f;
		}

set {
		}
}

public float WheelHandbrakeLateralFrictionMultiplier
{
get 		{
			return 0f;
		}

set {
		}
}

public float WheelMaxRollingFrictionTorque
{
get 		{
			return 0f;
		}

set {
		}
}

public float WheelMaxBrakingTorque
{
get 		{
			return 0f;
		}

set {
		}
}

public float SuspensionEfficiency
{
get 		{
			return 0f;
		}

private set {
		}
}

public RigidbodyEx SuspendedRigidbody
{
get 		{
			return null;
		}

set {
		}
}

public float SupportedMass
{
get 		{
			return 0f;
		}

private set {
		}
}

private float EOPCAGBAHFJ
{
get 		{
			return 0f;
		}

}

public Wheel Wheel
{
get 		{
			return null;
		}

}

public bool IsGrounded
{
get 		{
			return false;
		}

}

public Vector3 WheelHardPointVelocity
{
get 		{
			return default;
		}

private set {
		}
}

public Vector3 WheelContactPointVelocity
{
get 		{
			return default;
		}

private set {
		}
}

public Vector3 LatestContactPoint
{
get 		{
			return default;
		}

private set {
		}
}

public Vector3 LatestContactNormal
{
get 		{
			return default;
		}

private set {
		}
}

public float SuspensionSpringConstant
{
get 		{
			return 0f;
		}

private set {
		}
}

public float LastFrameSuspensionCompression
{
get 		{
			return 0f;
		}

private set {
		}
}

private float DAPCGICOAPA
{
get 		{
			return 0f;
		}

set {
		}
}

public float SignedLastFrameCompressionSpeed
{
get 		{
			return 0f;
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

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		public Vector3 UpdateSuspension(VehicleTerrainMarkup.GroundDrivingConfig DHHGHFOLHLI)
		{
			return default;
		}

		public void SetSupportedMass(float LEFBGBOFAEN)
		{
		}

		public Vector3 GetSuspensionLoadForce()
		{
			return default;
		}

		public void ResetSuspension()
		{
		}

		public void SetSyncData(FGJKPDFNOJO KBKJADAEFED)
		{
		}

		public FGJKPDFNOJO GetSyncData()
		{
			return default;
		}

		private Vector3 OKAHAHJGAFO(VehicleTerrainMarkup.GroundDrivingConfig DHHGHFOLHLI)
		{
			return default;
		}

		private float BDKGFHOJEJJ(float IPAAGHOBJIL)
		{
			return 0f;
		}

		private float IKBLOBGACEK(float EAPDNEAMFAI)
		{
			return 0f;
		}

		private bool DFKPMFLDNLE(float PILGIKEKPCL, out float OKFGKCFEAGO, out Vector3 IOGCIJMPJJE, out Vector3 KEMAFNKMJGH)
		{
			OKFGKCFEAGO = default;
			IOGCIJMPJJE = default;
			KEMAFNKMJGH = default;
			return false;
		}

		private void GNKIGMFCBJJ(float KAMAFGANFGD)
		{
		}

		private void NABJCNKOLHO(bool KELMOAADLCD = false)
		{
		}

		private float BDIDNMGEJCH()
		{
			return 0f;
		}

		private bool BPFHGKFOKJD()
		{
			return false;
		}

		private void EFJDOFENBMA()
		{
		}

		private void OAEDBENGOOA()
		{
		}

		private void FNGENCDBAGD()
		{
		}

		private void AJJKEFALOJG()
		{
		}

		private void JHJBGOAOGKK()
		{
		}

		private void JNFIPKFFFPG()
		{
		}

		private void MENGFOKLKPJ()
		{
		}

		private void GEOCABPPJIG()
		{
		}

		private void MIIOLIMOIOE()
		{
		}

		private void NACNOEKPLKP()
		{
		}

		private void GJJFPJAOODF()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
