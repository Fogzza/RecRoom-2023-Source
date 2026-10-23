using System;
using System.Collections.Generic;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Core.Combat
{
	[Serializable]
	public class MeleeWeaponChunk
	{
		[Serializable]
		public struct DurabilityGameObject
		{
			public GameObject GameObject;

			public int MinimumVisibilityDamage;

			public int MaximumVisibilityDamage;

			public ProxyPhysicsCollisionTransform Collision;

			[NonSerialized]
			public BGBFNLNFOPD ProxyPhysicsPart;
		}

		[SerializeField]
		private int durability;

		[SerializeField]
		private float weaponAttackContribution;

		[SerializeField]
		private Transform origin;

		[SerializeField]
		private DurabilityGameObject[] durabilityGameObjects;

		[SerializeField]
		private RagdollPiece[] ragdollPieces;

		[SerializeField]
		private MeleeWeaponCollider[] meleeColliders;

		[SerializeField]
		private DynamicMeshTrail[] trails;

		private Weapon weapon;

		private bool isShattered;

		private bool _isEnabled;

		public Vector3 OriginPosition => default;

		public int Durability => 0;

		public IEnumerable<DurabilityGameObject> DurabilityGameObjects => null;

		public float WeaponAttackContribution => 0f;

		public int DurabilityDamageTaken
		{
			set
			{
			}
		}

		public bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void IHEKMEOIBOI(MeleeWeapon PLOGNHIJBNB)
		{
		}

		public void MLJJAOFJPML(ProxyPhysicsCollision CGEHELCDBAD)
		{
		}

		public void MBLFBJBODNA(Vector3 KGIOBJMPLKI, float EAPKGOMLMPI)
		{
		}

		public void CELKLDBCJGF()
		{
		}

		public void HGLDAOHPEBF()
		{
		}

		private void KAGLHHPFCDP()
		{
		}

		private void GEEEGOJAHOC()
		{
		}

		private void CLKKEFDJGPK()
		{
		}

		private void LCNJOIJBEIF(int ABBOOFCKGMO)
		{
		}
	}
}
