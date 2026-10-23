using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Vehicles
{
	public class VehicleSteeringAssist : MonoBehaviour
	{
		private enum NHJIOLFFDJE
		{
			UNASSISTED = 0,
			ASSISTING_DRIFT = 1
		}

		private enum FJMNNJILOLN
		{
			INACTIVE = 0,
			HAND_BRAKING_NOT_DRIFTING = 1,
			HAND_BRAKING_DRIFTING = 2,
			BOOSTING = 3
		}

		private const int NLOLEBDEAPF = 128;

		[SerializeField]
		private GroundVehicle vehicle;

		[SerializeField]
		private bool driftAssistEnabled;

		[SerializeField]
		private float minSpeedForDriftAssist;

		[SerializeField]
		private AnimationCurve driftAssistFrictionMultiplierOverTime;

		[SerializeField]
		private float minThrottleInputForDriftAssist;

		[SerializeField]
		private float minSteeringInputForDriftAssist;

		[SerializeField]
		private float driftInputSmoothTime;

		[SerializeField]
		private bool driftBoostEnabled;

		[SerializeField]
		private float minSideslipAngleForDrift;

		[SerializeField]
		private float minSpeedForDrift;

		[SerializeField]
		private float driftBoostTorqueMultiplier;

		[SerializeField]
		private AnimationCurve driftTimeToBoostTime;

		[SerializeField]
		private float boostFadeoutTime;

		[SerializeField]
		private RecRoomAudioClip boostEngageSfx;

		[SerializeField]
		private bool verboseLogging;

		private NHJIOLFFDJE DLOIFJBHEAH;

		private float MENMADPDNFI;

		private readonly float[] CNENEBEMNLM;

		private readonly float[] EKKMGKAOBBJ;

		private int IHIOOCPIEED;

		private float LOMIDHFPLHM;

		private float IGMACBBMOPL;

		private FJMNNJILOLN GKCGNDFGGAA;

		private float KDIGBDGCCOI;

		private float LDNNFHKFOIH;

		private bool MBDOLAJAPEL;

		private float CILPGGGFIMF;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void FixedUpdate()
		{
		}

		private void PIOHKALAKAI()
		{
		}

		private void NPMHBLNEEKE()
		{
		}

		private void BDFANLNOHIE()
		{
		}

		private bool NMIKGNMHEJO(float BKOONMOKBOG)
		{
			return false;
		}

		private void ONFHPINLPDM()
		{
		}

		private void PGFHKAMKJBE()
		{
		}

		private void KJKAJBBHPNE()
		{
		}

		private void AGHHAHHIEGN()
		{
		}

		private void MBBLPEODILL()
		{
		}

		private float GJNOKLMHGJB(float FHMMCMOGNFE, float JFGDAEILDGE)
		{
			return 0f;
		}
	}
}
