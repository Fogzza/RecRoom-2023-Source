using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core
{
	public class ProxyPhysicsCollisionTransform : MonoBehaviour
	{
		protected enum BCDKKIBFIEO
		{
			Identity = 0,
			CaptureTranslationOnAwake = 1
		}

		[SerializeField]
		protected Transform visuals;

		[SerializeField]
		protected BCDKKIBFIEO CollisionToVisualTranslationMode;

		private Matrix4x4 FNDINHOPODP;

public Transform Visuals
{
get 		{
			return null;
		}

}

		protected void Awake()
		{
		}

		public static bool TryTranslateCollisionPointToVisuals(Transform CHGHLCBKPDN, Vector3 NPAODAODGDN, Quaternion KGMHCOCIHOM, out Transform BNCIFDNNBAP, out Vector3 CHNPEMEKCPL, out Quaternion IIDKGJNADGB)
		{
			BNCIFDNNBAP = null;
			CHNPEMEKCPL = default;
			IIDKGJNADGB = default;
			return false;
		}

		public static PhotonView TryGetPhotonViewPreferringVisualTree(Transform CHGHLCBKPDN)
		{
			return null;
		}

		private static bool JBEFJJOHNGF(Transform CHGHLCBKPDN, out ProxyPhysicsCollisionTransform LMKDOFEGKFB, out Transform BNCIFDNNBAP)
		{
			LMKDOFEGKFB = null;
			BNCIFDNNBAP = null;
			return false;
		}
	}
}
