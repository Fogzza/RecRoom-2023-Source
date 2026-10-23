using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Combat
{
	public class LiquidBullet : Bullet
	{
		[SerializeField]
		private float stretchAtMaxSpeed;

		[SerializeField]
		private float minStretch;

		[SerializeField]
		private AnimationCurve sqrSpeedToMaxStretch;

		[SerializeField]
		private AnimationCurve sqrSpeedToWidth;

		[SerializeField]
		private AnimationCurve lifetimeToBulletSize;

		private float MDPGFBPLINO;

		private float GKGOPHIDKNE;

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		public override void Fire(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 KGIOBJMPLKI, float IKIAOEADGLL, float BHEFDILBFOI, List<Collider> GEEGNLOGPDI, DJIBCHKKBDJ.MKEPPPJPDMB JHLEJMONOGI, float PDGCNICBLGN, byte JNHGFONGOCO, bool FGFPPJJKHMN = false, float LNCMDEJJJOM = 1f, Player EKMGJPMBLCP = null)
		{
		}
	}
}
