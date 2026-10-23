using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class ExplosiveWeaponAddon : MonoBehaviourPun
	{
		[SerializeField]
		private Weapon weapon;

		[SerializeField]
		private BreakableObject breakableObject;

		[SerializeField]
		private float radius;

		[SerializeField]
		private float force;

		[SerializeField]
		private int damage;

		[SerializeField]
		private bool canDamageHolderPlayer;

		[SerializeField]
		private bool canExplodeWhenHeld;

		[SerializeField]
		private PooledParticle explosionParticles;

		[SerializeField]
		private RecRoomAudioClip explosionAudio;

		private BCKPMPNCEOO GBNGMEEHPCB;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void HDAEEODMPCO(Weapon PLOGNHIJBNB, NGLCDIDOEMK BNFNJFKJEOA, bool DIAJCDMIFCD)
		{
		}

		private void EDLADMOJKIL(Vector3 PDFEDMAOMNH)
		{
		}

		private void LBCNCAJOOJJ(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BAPNMFLDAFL(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void KBOFMAGIGAE(Enemy NJDDIIEPJDM, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BGACPKCBJKB(Trap MBLENDJGFCI, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		[PBOMGCLBFHF]
		private void RpcExplode(Vector3 PDFEDMAOMNH)
		{
		}
	}
}
