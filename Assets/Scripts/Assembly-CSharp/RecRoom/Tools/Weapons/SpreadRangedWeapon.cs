using System;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class SpreadRangedWeapon : RangedWeapon
	{
		[Serializable]
		protected class SpreadTarget
		{
			public Transform Start;

			public Transform End;

			public Bullet bulletOverride;

			public float minCharge;
		}

		[SerializeField]
		protected float maxDistance;

		[SerializeField]
		protected Transform spreadTargetEndRoot;

		[SerializeField]
		protected SpreadTarget[] spreadTargets;

		[SerializeField]
		protected bool trackBulletGroups;

		[SerializeField]
		protected bool limitOneImpactPerTarget;

		protected BCOIAPIHCML CKMACPPGAIP;

		protected override void Awake()
		{
		}

		protected override void MPNCIDCFDNM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool GHCPLAPAGHB, byte CMBCNFBLLNI)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
