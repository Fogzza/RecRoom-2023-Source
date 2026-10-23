using System.Collections.Generic;
using RecRoom.Core.AI;
using RecRoom.Tools;
using RecRoom.Tools.Weapons;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestCannon : ExplosiveRangedWeapon
	{
		public delegate void FAGNOCNJHBP(QuestCannon BDKHMFPGCKD);

		[SerializeField]
		private SwivelTool swivel;

		[SerializeField]
		private DelayedRangedWeaponTrigger trigger;

		[SerializeField]
		private QuestCannonLighter lighter;

		[SerializeField]
		private float minEnemyWieldYawAngle;

		[SerializeField]
		private float maxEnemyWieldYawAngle;

		[SerializeField]
		private float minEnemyWieldPitchAngle;

		[SerializeField]
		private float maxEnemyWieldPitchAngle;

		[SerializeField]
		private Transform lighterHolsterTransform;

		[SerializeField]
		private Transform wickTransform;

		private static List<QuestCannon> FNBKHHFJGOF;

		public FAGNOCNJHBP WielderChangeEvent;

public QuestCannonLighter Lighter
{
get 		{
			return null;
		}

}

public Transform LighterHolsterTransform
{
get 		{
			return null;
		}

}

public Transform WickTransform
{
get 		{
			return null;
		}

}

public static IEnumerable<QuestCannon> ActiveCannons
{
get 		{
			return null;
		}

}

public float MinEnemyWieldYawAngleNormalized
{
get 		{
			return 0f;
		}

}

public float MaxEnemyWieldYawAngleNormalized
{
get 		{
			return 0f;
		}

}

public float MinEnemyWieldPitchAngleNormalized
{
get 		{
			return 0f;
		}

}

public float MaxEnemyWieldPitchAngleNormalized
{
get 		{
			return 0f;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void RequestFire(CHILKDJABBF EKMGJPMBLCP = null)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcRequestFire(CHILKDJABBF EKMGJPMBLCP)
		{
		}

		protected override void AOMPLKNJDAI()
		{
		}

		private bool ALNMEICHKEG(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private void GDEOGCJNBKA(DelayedRangedWeaponTrigger OBNBBDPHGAD)
		{
		}

		protected override void MPNCIDCFDNM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool GHCPLAPAGHB, byte CMBCNFBLLNI)
		{
		}

		public void EnemyStartWielding(Enemy DPENEFKKNDN)
		{
		}

		public bool EnemyCanWield(Enemy DPENEFKKNDN)
		{
			return false;
		}

		public void EnemyStopWielding()
		{
		}

		public Vector3 GetEnemyWieldPosition()
		{
			return default;
		}

		public Vector3 GetEnemyWieldForwardVector()
		{
			return default;
		}

		public void GetNormalizedAimPitchYaw(out float ONJEDBFDBNP, out float ICFCNKNGFKM)
		{
			ONJEDBFDBNP = default;
			ICFCNKNGFKM = default;
		}

		public void AuthoritySetNormalizedAimPitchYaw(float CEOLIPCIJGN, float AMPLPMGFIFH)
		{
		}
	}
}
