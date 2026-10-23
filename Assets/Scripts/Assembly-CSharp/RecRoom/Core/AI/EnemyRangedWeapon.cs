using RecRoom.Core.Combat;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Core.AI
{
	public abstract class EnemyRangedWeapon : EnemyRangedWeaponBase
	{
		protected enum JKALIGCOHIB
		{
			BULLET = 0,
			EQUIPMENT = 1
		}

		[SerializeField]
		protected JKALIGCOHIB projectileType;

		[SerializeField]
		protected Bullet bulletProjectilePrefab;

		[SerializeField]
		protected Color projectileColor;

		[SerializeField]
		public SerializedGuid equipmentProjectileTypeId;

		[SerializeField]
		protected float projectileSpeed;

		[SerializeField]
		protected float projectileImpactForce;

		private const float JMLNGGEHPDE = 720f;

		public const string PROJECTILE_SPEED_OVERRIDE = "PSO";

protected JBGFOIKBKED NHGJCMEAINN
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

}

private Color OHPPOFOLCOA
{
get 		{
			return default;
		}

}

		protected void Start()
		{
		}

		protected override float JNGEHFIOODP(float JEFDIJMDBOF)
		{
			return 0f;
		}

		protected GameObject DPLCGDIJMMC(Vector3 INLGLHIPOMC, Vector3 HLFIBIDOLEF, float DMIPMFMPLAP)
		{
			return null;
		}

		private GameObject LABNNPPFGHF(Vector3 INLGLHIPOMC, Vector3 HLFIBIDOLEF, float DMIPMFMPLAP)
		{
			return null;
		}

		private GameObject PNNCDINDNNC(Vector3 INLGLHIPOMC, Vector3 HLFIBIDOLEF, float DMIPMFMPLAP)
		{
			return null;
		}

		private Bullet LIPKDHINPGF()
		{
			return null;
		}

		protected virtual void COCACFLPOMO(Bullet HKEPPKCNEPN)
		{
		}

		private bool FNPBIECFLDN(Collider GJKLNFFOHPF, Vector3 EPGAOLNDLII)
		{
			return false;
		}

		protected virtual void JCHOIPAFDFK(Bullet HCLJODLNCNE, Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void BHCDKFBLBMG(Bullet HCLJODLNCNE, Enemy DPENEFKKNDN, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void LABCLALOAEL(Bullet NAIPJKGDKML, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void LMCLMIPHONB(Bullet NAIPJKGDKML, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected void IIGKEBCJEMF(NGLCDIDOEMK BNFNJFKJEOA)
		{
		}
	}
}
