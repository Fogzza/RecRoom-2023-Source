using RecRoom.Audio;
using RecRoom.Core.Locomotion;
using RecRoom.Utils.OverridableFields;
using UnityEngine;

namespace RecRoom.Activities.StuntRunner
{
	public class PlayerLauncher : MonoBehaviour
	{
		public enum FNPMGLDEIBK
		{
			ADDITIVE = 0,
			ADDITIVE_PLUS_REFLECT_INBOUND_VELOCITY = 1,
			OVERRIDE_INBOUND_VELOCITY = 2
		}

		private static string CNDFDGHHBGO;

		private static string AKKNLOEAILJ;

		private static string LBFMLELAJLF;

		private const float IGPJAMGFOHF = 0.6f;

		private const float MJDKHKANCDM = 0.05f;

		[SerializeField]
		private bool launchFromForwardFaceOnly;

		[SerializeField]
		private float impulseAirControlPercentageOverride;

		[SerializeField]
		private FNPMGLDEIBK impulseApplicationType;

		[SerializeField]
		private OverridableVector3 impulseDirectionOverride;

		[SerializeField]
		private float restitutionFactor;

		[SerializeField]
		private float impulseForce;

		[SerializeField]
		private float maxVelocity;

		[SerializeField]
		private RecRoomAudioClip impulseApplicationSfx;

		[SerializeField]
		private BoxCollider triggerCollider;

		[SerializeField]
		private LocomotionCollisionTrigger locomotionCollider;

		private FIHGBEHGLGB EJOPDBDJLOI;

		private float DMEPCIJKHDE;

private bool LHJBFCEHNKN
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetSandboxSettings(float COHBNIGJJKO, float GFPPHDDIFHP, float LIODLDNGDIO, int BLOOMLCFLLN, bool NPAFLNKLKNE, bool KNCOJDKGBFD)
		{
		}

		private void OnTriggerEnter(Collider ADMCDJKKCIA)
		{
		}

		private void OnTriggerExit(Collider ADMCDJKKCIA)
		{
		}

		private void BLNEFLKGPII(Player EKOFNPFCLMO, DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM)
		{
		}

		private void AHNPHHLFCIA(Player EKOFNPFCLMO, DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM)
		{
		}

		private bool NNGPGDJEODK(DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM)
		{
			return false;
		}

		private string BNBKNDHPCOL(DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM)
		{
			return null;
		}

		private bool PLNAAJMNECG(Player MHCOBIPKGNI)
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
