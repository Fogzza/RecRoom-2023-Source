using System.Collections.Generic;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class ChargeGunProjectile : Bullet
	{
		[SerializeField]
		private float minRadius;

		[SerializeField]
		private float maxRadius;

		[SerializeField]
		private float minTrailLifetime;

		[SerializeField]
		private float maxTrailLifetime;

		[SerializeField]
		private float minTrailWidthExpansion;

		[SerializeField]
		private float maxTrailWidthExpansion;

		private PersistentBulletTrail AMEFABKDDOO;

		protected override void Awake()
		{
		}

		public override void Fire(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 KGIOBJMPLKI, float IKIAOEADGLL, float BHEFDILBFOI, List<Collider> GEEGNLOGPDI, DJIBCHKKBDJ.MKEPPPJPDMB JHLEJMONOGI, float PDGCNICBLGN, byte CMBCNFBLLNI, bool FGFPPJJKHMN = false, float LNCMDEJJJOM = 1f, Player EKMGJPMBLCP = null)
		{
		}
	}
}
