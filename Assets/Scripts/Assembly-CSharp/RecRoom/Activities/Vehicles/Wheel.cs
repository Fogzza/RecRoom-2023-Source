using RecRoom.Persistence;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class Wheel : MonoBehaviour
	{
		private enum EAHHLKNLMOJ
		{
			XAxis = 0,
			YAxis = 1,
			ZAxis = 2
		}

		public struct EELOGGBOOBJ
		{
			public bool OMJOJCLAPIL;

			public bool MAAKKGFNLFF;

			public bool ADOLMCJPPBE;

			public bool LBNPPAJMFNN;

			public bool PCLKAKMJPNM;

			public bool ENADHMDBKJH;

			public float FOJMPIJKGMC;

			public float LIOIDPJEHCF;

			public float EPBCDLEHILN;

			public float GPMKBFDIMNE;

			public void KMDJNOCMKDB(ELFDKCLHAMN DGJEOFHPNDP)
			{
			}

			public static EELOGGBOOBJ JFDMJLPIIPF(ELFDKCLHAMN DGJEOFHPNDP)
			{
				return default;
			}
		}

		private const float AAABEIEHJHI = 210f;

		private const float MOMMMBCJBLK = 1f / 90f;

		private const float NKDHOIMKPKG = 13f / 45f;

		private const float EKHJJOIKHOK = 1.07f;

		[SerializeField]
		private float radius;

		[SerializeField]
		private Transform hardPointTransform;

		[SerializeField]
		private Vector3 visualOffsetFromHardPoint;

		[SerializeField]
		private EAHHLKNLMOJ spinAxis;

		[SerializeField]
		public bool canSteer;

		[SerializeField]
		public bool canDrive;

		[SerializeField]
		public bool canHandbrake;

		[SerializeField]
		private float tireFrictionCoefficient;

		[SerializeField]
		public float corneringStiffness;

		[SerializeField]
		private AnimationCurve tractionForceOverSlipRatio;

		[SerializeField]
		private float minSlipSpeedForWheelSpin;

		[SerializeField]
		private bool clampLongitudinalAndLateralTractionSeparately;

		[SerializeField]
		public float longitudinalTireFrictionCoefficient;

		[SerializeField]
		public float lateralTireFrictionCoefficient;

		[SerializeField]
		public float handbrakeLongitudinalFrictionMultiplier;

		[SerializeField]
		public float handbrakeLateralFrictionMultiplier;

		[SerializeField]
		private bool useRealisticSlipTraction;

		[SerializeField]
		public float frictionMaxTorque;

		[SerializeField]
		public float brakingMaxTorque;

		[SerializeField]
		private WheelVFX vfx;

		[SerializeField]
		public bool verboseLogging;

		[SerializeField]
		private bool drawForces;

		[SerializeField]
		private float forceRayDuration;

		private EELOGGBOOBJ KBKJADAEFED;

		private float HNGHILFKNGE;

		private Vector3 KOCAFPHLBCM;

		private Vector3 OACAEGDPKCN;

		private VehicleTerrainMarkup.GroundDrivingConfig BALKHBMOMKF;

		private Quaternion LADFMDLIHHP;

		private Quaternion MOPEJIJLPHN;

		private PersistenceView ECBIDGPMMHI;

		private Vector3 LHHEKGELNNE;

		private WheelDifferential.MCFHKNPDHEI CKLKJENGOKN;

		private readonly NCIMIGIHJDN JKDEHGGNJJN;

		private float PJJPIIFNHFH;

		private float BIKOFDDLPOH;

		private float HMLEGMIABPF;

public PersistenceView PersistenceView
{
get 		{
			return null;
		}

set {
		}
}

public Vector3 AngularVelocity
{
get 		{
			return default;
		}

private set {
		}
}

public float AngularSpeed
{
get 		{
			return 0f;
		}

private set {
		}
}

public float RPM
{
get 		{
			return 0f;
		}

}

public bool IsGrounded
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsBraking
{
get 		{
			return false;
		}

set {
		}
}

public bool IsHandbraking
{
get 		{
			return false;
		}

private set {
		}
}

public WheelDifferential.MCFHKNPDHEI DriveDirection
{
get 		{
			return WheelDifferential.MCFHKNPDHEI.STOPPED;
		}

private set {
		}
}

public NCIMIGIHJDN ExternalTireFrictionMultiplier
{
get 		{
			return null;
		}

}

public WheelVFX VFX
{
get 		{
			return null;
		}

}

public bool IsRollingWithoutSlipping
{
get 		{
			return false;
		}

}

public float RollingSpeed
{
get 		{
			return 0f;
		}

private set {
		}
}

public bool IsSlipping
{
get 		{
			return false;
		}

}

private bool OMJOJCLAPIL
{
get 		{
			return false;
		}

set {
		}
}

private bool MAAKKGFNLFF
{
get 		{
			return false;
		}

set {
		}
}

private float EPBCDLEHILN
{
get 		{
			return 0f;
		}

set {
		}
}

private float GPMKBFDIMNE
{
get 		{
			return 0f;
		}

set {
		}
}

public float SlippingSpeed
{
get 		{
			return 0f;
		}

}

public bool IsSpinning
{
get 		{
			return false;
		}

private set {
		}
}

public float SpinningVelocity
{
get 		{
			return 0f;
		}

}

public float Radius
{
get 		{
			return 0f;
		}

}

public float Mass
{
get 		{
			return 0f;
		}

set {
		}
}

public float SupportedMass
{
get 		{
			return 0f;
		}

set {
		}
}

public Vector3 Position
{
get 		{
			return default;
		}

}

public float HardPointForwardDirectionSign
{
get 		{
			return 0f;
		}

set {
		}
}

private float HNAIKHFANNC
{
get 		{
			return 0f;
		}

}

private Vector3 OGNDLDJFJND
{
get 		{
			return default;
		}

}

private Vector3 NODJFIANEEP
{
get 		{
			return default;
		}

}

public Transform HardPointTransform
{
get 		{
			return null;
		}

}

public Vector3 HardPointAxleDirection
{
get 		{
			return default;
		}

}

private Vector3 OAPPPAAENAB
{
get 		{
			return default;
		}

}

private float MDIEELHMJOF
{
get 		{
			return 0f;
		}

}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void SetContact(bool KLOMKIBMLAP, Vector3 HLCIHKBLHEE, Vector3 IOGCIJMPJJE, Vector3 KEMAFNKMJGH, VehicleTerrainMarkup.GroundDrivingConfig PFDHKHLKLIJ)
		{
		}

		public void SetSteeringAngle(float NEJBFKANFPL)
		{
		}

		public void SetDriveDirection(WheelDifferential.MCFHKNPDHEI CLNOBEEBDKP)
		{
		}

		public void SetHandbraking(bool PDPCDDPBFJK)
		{
		}

		public Vector3 UpdateWheelPhysics(Vector3 DFOMFAOBFJJ, Vector3 JMADAHILNPK, float FHMMCMOGNFE, float BHNEHKOGMCN)
		{
			return default;
		}

		public void SetSyncData(EELOGGBOOBJ KBKJADAEFED)
		{
		}

		public EELOGGBOOBJ GetSyncData()
		{
			return default;
		}

		private Vector3 PMNOPBJIGBF(Vector3 DFOMFAOBFJJ, Vector3 JMADAHILNPK, Vector3 FHMMCMOGNFE, float BHNEHKOGMCN)
		{
			return default;
		}

		private void KCELMJOIMII(Vector3 NIHOPLMNKLF, Vector3 IJJKPFFCPGI, Vector3 PDDBNEAEMAP, Vector3 EIAKBFNFEIE, float BHNEHKOGMCN, float LNOCPIKPGDC, float EENCAOLOBDP, float IJDDHCNHDEA, out Vector3 DGBNGOLAIOP, out Vector3 BOECECPHCMN)
		{
			DGBNGOLAIOP = default;
			BOECECPHCMN = default;
		}

		private Vector3 NDMHMBACKJP(Vector3 PDDBNEAEMAP, Vector3 EIAKBFNFEIE, Vector3 IJJKPFFCPGI, float MDFLIIFKHBG, float BHNEHKOGMCN)
		{
			return default;
		}

		private Vector3 KFKEMPDGPOL(float EHDFIKCEMFG, Vector3 IJJKPFFCPGI, float BHNEHKOGMCN, Vector3 FBHPLMFGDDN)
		{
			return default;
		}

		private Vector3 ADFOONLHFJA(Vector3 IJJKPFFCPGI, float MDFLIIFKHBG, Vector3 KEMAFNKMJGH, Vector3 GNELDEOFNCJ, out Vector3 GPPEBCNLFIG, out float IJDDHCNHDEA)
		{
			GPPEBCNLFIG = default;
			IJDDHCNHDEA = default;
			return default;
		}

		private void CJABNLKOOLJ()
		{
		}

		private void INMDNJLNOOC()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
