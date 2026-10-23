using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	public class PoolCue : MonoBehaviourPun
	{
		public enum GEMEHAMDHFG
		{
			Default = 0,
			Aiming = 1,
			Shooting = 2
		}

		public enum ADBLADAPBCD
		{
			AllBalls = 0,
			CueBall = 1
		}

		public delegate void JJLNPGPGMNH(PoolBall PMFMNEJCNDJ, ref Vector3 COPOILGLIAJ, ref Vector3 PDFEDMAOMNH);

		public const float LENGTH = 1.4875f;

		private const float LJJFGFPLEMJ = 0.01f;

		private const float OFOMJLENEIM = 1.25f;

		[SerializeField]
		private Transform tipTransform;

		[SerializeField]
		private PoolCueAimGrip aimGrip;

		[SerializeField]
		private RecRoomAudioClip ballHitAudio;

		[SerializeField]
		private Tool tool;

		private bool IMHFHIOIPND;

		private RaycastHit[] AMOGAFEFLFF;

		private Vector3 NODIEHMKGFE;

		private PlayerHand ANLONKDHLDJ;

		private global::MOBDJNEDDKC<GEMEHAMDHFG> LMMEGEIPPLM;

		private ADBLADAPBCD HOJDKINCLNL;

		public EEANDDJEMJC StateChanged;

		public global::HHOBPMOCKMJ<float> BallHit;

		private global::MOBDJNEDDKC<Vector3> JOPHJBHCCBI;

		private global::MOBDJNEDDKC<Vector3> BHMBDOCGCNC;

		private global::MOBDJNEDDKC<Vector3> KIHLBHKHIMJ;

		private global::MOBDJNEDDKC<Vector3> FKEEIMPKEMP;

		private global::MOBDJNEDDKC<Vector3> CCFBCNKBBLC;

		private global::MOBDJNEDDKC<Quaternion> JEKIAPFKNJC;

		private JJLNPGPGMNH IALAKPEMBCM;

public Transform TipTransform
{
get 		{
			return null;
		}

}

public PoolCueAimGrip AimGrip
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

public GEMEHAMDHFG CurrentState
{
get 		{
			return GEMEHAMDHFG.Default;
		}

set {
		}
}

public ADBLADAPBCD CurrentShootingMode
{
get 		{
			return ADBLADAPBCD.AllBalls;
		}

set {
		}
}

public Vector3 HoldingHandLocalPosition
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 AimingHandLocalPosition
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 AimingHandOffsetToCue
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 ShootingHandStartPosition
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 ShootingLockedPosition
{
get 		{
			return default;
		}

set {
		}
}

public Quaternion ShootingLockedRotation
{
get 		{
			return default;
		}

set {
		}
}

public JJLNPGPGMNH AdjustCalculatedHit
{
get 		{
			return null;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void FixedUpdate()
		{
		}

		private void OBJKAKFINMO()
		{
		}

		private void JDLFPKKNOFM()
		{
		}

		public static void CalculateCueTransformForTip(Vector3 CEILKPPOJKL, Quaternion GHDHAOEEKEE, out Vector3 OEOHDILDOLI, out Quaternion FFLJIDKKNHF)
		{
			OEOHDILDOLI = default;
			FFLJIDKKNHF = default;
		}
	}
}
