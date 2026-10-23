using System;
using ExitGames.Client.Photon;
using RecRoom.Core;
using RecRoom.Core.Creation;
using RecRoom.Core.Locomotion;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class GroundVehicle : BaseRecRallyVehicle, KFLNCOLKJEM, HECDIPMDFHB
	{
		[Serializable]
		private struct DamageTypeForceModifier
		{
			public DJBEHNDMJDL damageType;

			public float forceMultiplier;
		}

		public delegate float MPGECKPBALN(float FPJGAJJKGMN);

		public class DNFGPNEJLHJ
		{
			private const int LEBDCHOLIPN = 4;

			private static readonly ELFDKCLHAMN DGJEOFHPNDP;

			public GroundVehicle DLFKMDFDAFO;

			public float LKLNLECJPMK;

			public VehicleEngine.KFLKAINDAAB NFMMFIEHGDO;

			public readonly WheelSuspension.FGJKPDFNOJO[] FCEHLGKDENM;

			public static short IIADKJHBOIN(StreamBuffer HLHADAOGCMN, object PJGPNPBFMFD)
			{
				return 0;
			}

			public static object BBCFAILGGHN(StreamBuffer FAMJGEFEDDM, short MNKGPEKFPKK)
			{
				return null;
			}
		}

		private const float NDAADBDIOKI = 2.23694f;

		private const float EIMBPJPNCKA = 3.6f;

		private const string FGBFJPJIOEL = "Vehicle";

		private const string HPPCPLGNGJE = "RESET";

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private NetworkTransform networkTransform;

		[SerializeField]
		private VehicleEngine engine;

		[SerializeField]
		private WheelSuspension[] wheelSuspensions;

		[SerializeField]
		private Wheel[] wheels;

		[SerializeField]
		private WheelDifferential differential;

		[SerializeField]
		private VehicleBoost boost;

		[SerializeField]
		private bool applyTractionForcesAtContactPoints;

		[SerializeField]
		private Transform dynamicTerrainTractionSampleStartTransform;

		[SerializeField]
		private float dynamicTerrainTractionSampleRate;

		[SerializeField]
		private float baseVehicleDrag;

		[SerializeField]
		private RigidbodyEx rigidbody;

		[SerializeField]
		private SimpleVolume inertiaRepresentativeBox;

		[SerializeField]
		private Transform floorDetectionStartTransform;

		[SerializeField]
		private float floorPositionSampleRate;

		[SerializeField]
		private float floorDetectionMaxDistance;

		[SerializeField]
		private UGCSeatManagement[] seats;

		[SerializeField]
		private DamageTypeForceModifier[] damageTypeForceMultipliers;

		[SerializeField]
		private float maxForceMultiplierOverMassRatio;

		[SerializeField]
		private bool useAirborneStabilization;

		[SerializeField]
		private float stabilizationTime;

		[SerializeField]
		private float maxStabilizationAngularSpeed;

		[SerializeField]
		private float airborneAngularDrag;

		[SerializeField]
		private float groundedAngularDrag;

		[SerializeField]
		private AnimationCurve angularDragMultiplierOverAngularVelocity;

		[SerializeField]
		private TextMesh speedometerText;

		[SerializeField]
		private GaugeNeedle speedometerGauge;

		[SerializeField]
		private CrossPlatformPlayerLocomotionFeedbackContent content;

		[SerializeField]
		private float minSideslipAngleForDriftWindLines;

		[SerializeField]
		private float minSpeedForDriftWindlines;

		[SerializeField]
		private GameObject driveGearIndicator;

		[SerializeField]
		private GameObject neutralGearIndicator;

		[SerializeField]
		private GameObject reverseGearIndicator;

		[SerializeField]
		private BoxCollider Bounds;

		[SerializeField]
		private bool verboseLogging;

		[SerializeField]
		private bool showSpeedMeterText;

		[SerializeField]
		private bool ignoreTractionForces;

		private DNFGPNEJLHJ KBKJADAEFED;

		private VehicleTerrainMarkup MONLDPDMAFH;

		private VehicleTerrainMarkup.GroundDrivingConfig KGJBAOKAJBG;

		private float PGKMDEDODBP;

		private bool KFKKMMGBMND;

		private Vector3 GDNAHGGOKGD;

		private float GOIDGLDMNPK;

		private EGMDNODKGIA AABDIODJPKI;

		private bool KMLCBCDHNEA;

		private bool NKGOEMDEPJD;

		private float OIHEFAIHEND;

		private float PCEFGBOAIDG;

		private bool DMOKMIEOGGH;

		private bool KPOGBNJEBFD;

		private PooledParticle FNDOADLFPOE;

		private float ANFKFLJPHGD;

		public EEANDDJEMJC OnLocalPlayerEnterVehicleAnySeat;

		public EEANDDJEMJC OnLocalPlayerExitVehicleAnySeat;

		private bool AJNGOIPMKBH;

		private bool GOKAGOHJPBD;

		private readonly global::AFHOAHNAMGF<MPGECKPBALN> KBALEAGNPMP;

		private readonly FIHGBEHGLGB BOHICCIMEHC;

		private readonly FIHGBEHGLGB FCGOABCHKLP;

public override bool HasDriver
{
get 		{
			return false;
		}

}

public override bool HasOccupant
{
get 		{
			return false;
		}

}

public override RigidbodyEx Rigidbody
{
get 		{
			return null;
		}

}

public VehicleEngine Engine
{
get 		{
			return null;
		}

}

public VehicleBoost Boost
{
get 		{
			return null;
		}

}

public WheelDifferential Differential
{
get 		{
			return null;
		}

}

public WheelSuspension[] WheelSuspensions
{
get 		{
			return null;
		}

}

public Wheel[] Wheels
{
get 		{
			return null;
		}

}

public UGCSeatManagement[] Seats
{
get 		{
			return null;
		}

}

public override bool AllowsBoosting
{
get 		{
			return false;
		}

}

public bool IsVehicleGrounded
{
get 		{
			return false;
		}

set {
		}
}

public float SteeringInput
{
get 		{
			return 0f;
		}

}

public bool IsHandbrakeApplied
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanHandbrake
{
get 		{
			return false;
		}

}

public bool IsReversing
{
get 		{
			return false;
		}

}

public float Speed
{
get 		{
			return 0f;
		}

}

public float SyncedVehicleSpeedOnForwardSigned
{
get 		{
			return 0f;
		}

}

public Vector3 Velocity
{
get 		{
			return default;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

private MPGECKPBALN LFLKDDIOPCK
{
get 		{
			return null;
		}

}

public bool SimulationIsDisabled
{
get 		{
			return false;
		}

}

public bool NetworkSynchronizationSmoothMovementEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool MovementActionRestricted
{
get 		{
			return false;
		}

}

 CHILKDJABBF global::HECDIPMDFHB.owner
{
get 		{
			return null;
		}

}

 bool global::HECDIPMDFHB.hasAuthority
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnCollisionExit(Collision KDGCDLJEAMD)
		{
		}

		public override void SetSteering(float OHPLGHHAECG)
		{
		}

		public override void AuthoritySetGas(float KNFJJMDFBNI)
		{
		}

		public override void AuthorityApplyBoost(bool GAJCFDCEOIJ)
		{
		}

		public override void AuthorityApplyHandbrake()
		{
		}

		public override void AuthorityApplyReset(EGMDNODKGIA EMCILMHMENA)
		{
		}

		public override void AuthoritySetDriving(bool ILLIAOKHBGE)
		{
		}

		public void SetDriftAssistTireFrictionMultiplier(float KAAPGOCANLN, object IALNODEHBNN)
		{
		}

		public void RemoveDriftAssistTireFrictionMultiplier(object IALNODEHBNN)
		{
		}

		public bool IsPlayerSeatedInVehicle(Player EKOFNPFCLMO)
		{
			return false;
		}

		public bool GetFloorPosition(out Vector3 KIPBJABANHE)
		{
			KIPBJABANHE = default;
			return false;
		}

		public override void AddRestrictionToSeats(SeatManagement.FDMADKNOFCI NAOILMPNIEO)
		{
		}

		public override void RemoveRestrictionToSeats(SeatManagement.FDMADKNOFCI NAOILMPNIEO)
		{
		}

		public void SetSeatActivelyRapidlyAcceleratingState(bool JOMIIJEPLLG)
		{
		}

		public void DisableSeatRapidlyAcceleratingState()
		{
		}

		public void AddWheelVFXAllowance(object IALNODEHBNN)
		{
		}

		public void RemoveWheelVFXAllowance(object IALNODEHBNN)
		{
		}

		public void AddThrottleModifier(MPGECKPBALN OONACCDEFKJ, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveThrottleModifier(object IALNODEHBNN)
		{
		}

		private float ANEHJGOHDMH(float FPJGAJJKGMN)
		{
			return 0f;
		}

		public float GetCurrentThrottle()
		{
			return 0f;
		}

		public void AddSimulationDisabledToken(object IALNODEHBNN)
		{
		}

		public void RemoveSimulationDisabledToken(object IALNODEHBNN)
		{
		}

		public override void AuthorityApplyLocalDriverFavoriteSkin(Player POAFANOMOJE)
		{
		}

		private bool NPNGDIFBCPA(CreationObject FHDPOGAOHBN, Collider ADMCDJKKCIA)
		{
			return false;
		}

		private void NONLCABFFEG()
		{
		}

		private void PGDGHNGMKJI()
		{
		}

		private void IJBNCLDFELO()
		{
		}

		private VehicleTerrainMarkup.GroundDrivingConfig HAEHNALENAM()
		{
			return default;
		}

		private void PKHAPGBCOBP()
		{
		}

		private void POBFGGGGFBI()
		{
		}

		private void LNNDOILHLGP()
		{
		}

		private void FHCHDKMCMNM()
		{
		}

		public void AuthoritySetVehicleTransform(Vector3 INKGHPCDMCG, Quaternion OOFIIEKBKAE, bool MJDHNIJIDKD = true, bool JHNPDDNMFOG = false)
		{
		}

		private bool FPONKIBHMKC(Collider ADMCDJKKCIA)
		{
			return false;
		}

		public Vector3 Depenetrate(Vector3 INKGHPCDMCG, Quaternion OOFIIEKBKAE)
		{
			return default;
		}

		public void InitializeSuspensionState()
		{
		}

		public override void AuthorityResetSuspension()
		{
		}

		public void SimplifyInertiaTensor()
		{
		}

		public Vector3 GetSimplifiedInertiaTensor()
		{
			return default;
		}

		public Player GetPlayerOwner()
		{
			return null;
		}

		private void NAFKPBPHDFP(ref Vector3 NFNPPFFOJMO, ref Vector3 EBJPIKPGHIB, Tool.ELEENIHEJOG NIFOGEBEDNG)
		{
		}

		private void PMKPPAFBLCJ(ref Vector3 COPOILGLIAJ, Vector3 PDFEDMAOMNH, ForceMode OJOAKAEAKAC, DJBEHNDMJDL IKEDGLGPGEA)
		{
		}

		private void MCPJHLBGBMM(Tool IEGMBEPJMGC)
		{
		}

		private void NALPLEJDDNI(SeatManagement HGHEJNOMIJN, Player DBJCMPCHBHK, Player HKLMCKOOLEG)
		{
		}

		private void FGOGLGMAEOC(Player EKOFNPFCLMO, bool AIBCEJLGOMG)
		{
		}

		private void LHCCGEAOMGA(Tool IEGMBEPJMGC, bool AIBCEJLGOMG)
		{
		}

		private void BIEIHOKEPAI(float OKBAJEAPIHG)
		{
		}

		private void LDCEHJDFAJJ()
		{
		}

		private void MELBKAELIPB()
		{
		}

		private void IGENODKFPIK()
		{
		}

		private void OHJINGEBGDJ(PooledParticle BLJHJFMKMJG, Vector3 NMEGIJFODAB)
		{
		}

		private void IEHKKOCNILD(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		void KFLNCOLKJEM.OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IEHKKOCNILD
			this.IEHKKOCNILD(EDIGAFOKGOJ, AKOKILEPANJ);
		}

		private void KJDNJGHGIBK(CHILKDJABBF HIGOLKPFBPL)
		{
		}

		public void AddMovementActionRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveMovementActionRestriction(object IALNODEHBNN)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
