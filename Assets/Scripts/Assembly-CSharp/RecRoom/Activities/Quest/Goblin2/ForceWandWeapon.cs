using System.Collections.Generic;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Tools.Weapons;
using UnityEngine;

namespace RecRoom.Activities.Quest.Goblin2
{
	public class ForceWandWeapon : SpreadRangedWeapon
	{
		[SerializeField]
		private DelayedRangedWeaponTrigger trigger;

		[SerializeField]
		private Transform spreadOffsetRoot;

		[SerializeField]
		private WandProjectileParticles shootParticlesPrefab;

		[SerializeField]
		private float minBulletPercentageRequiredForParticles;

		[SerializeField]
		private bool useHeadAimBias;

		[SerializeField]
		private float maxHeadAimAngle;

		[SerializeField]
		private float centerShotInitialCharge;

		[SerializeField]
		private float spreadShotInitialCharge;

		[SerializeField]
		private AnimationCurve damageFalloffCurve;

		[SerializeField]
		private float minPhysicsDamageVelocity;

		[SerializeField]
		private float maxFloorAngleDegrees;

		[SerializeField]
		private float enemyCollisionDamageCharge;

		[SerializeField]
		private float otherEnemyCollisionDamageCharge;

		[SerializeField]
		private float environmentCollisionDamageCharge;

		private readonly List<Enemy> FDBMILJLBOH;

		private WandProjectileParticles BKBBMCALHJO;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void NEBIOPGDKEB(DelayedRangedWeaponTrigger OBNBBDPHGAD)
		{
		}

		public override void Fire(float DHKEJJCLBKC)
		{
		}

		protected override void BHCDKFBLBMG(Bullet HCLJODLNCNE, Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override bool BCHPHNNIPMK(Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		protected void FECKJIBEBHA(Enemy DPENEFKKNDN)
		{
		}

		protected void CEKPLKCMNAP(Enemy DPENEFKKNDN, Collision KDGCDLJEAMD)
		{
		}

		private void DJBLNNCNEEP(Enemy DPENEFKKNDN)
		{
		}

		private void ECBGHALGNEJ(Enemy DPENEFKKNDN)
		{
		}

		protected override void MPNCIDCFDNM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool GHCPLAPAGHB, byte CMBCNFBLLNI)
		{
		}
	}
}
