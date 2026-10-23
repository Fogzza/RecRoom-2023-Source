using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class ExplosiveRangedWeapon : RangedWeapon
	{
		private sealed class DOCIIMCLLPE : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public ExplosiveRangedWeapon _003C_003E4__this;

			public Vector3 position;

			public float radius;

			public float chargeAmount;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public DOCIIMCLLPE(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private bool applyDirectDamage;

		[SerializeField]
		private PooledParticle directDamageParticles;

		[SerializeField]
		private RecRoomAudioClip directDamageImpactAudio;

		[SerializeField]
		private float explosionDelay;

		[SerializeField]
		protected float explosionRadius;

		[SerializeField]
		protected float explosionForce;

		[SerializeField]
		protected PooledParticle explosionParticles;

		[SerializeField]
		protected RecRoomAudioClip explosionAudio;

		[SerializeField]
		protected AnimationCurve forceFalloff;

		[SerializeField]
		protected AnimationCurve damageFalloff;

		[SerializeField]
		protected float maxPlayerDamageFalloff;

		protected BCKPMPNCEOO GBNGMEEHPCB;

		private Bullet OOPACLCBAON;

		private GameObject IGHLMKBFIMI;

		private float DMBLGKDKLCE;

		private List<CHILKDJABBF> MPKKDGMNNDA;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override bool HPCBPBCFNPM()
		{
			return false;
		}

		protected override Bullet LIPKDHINPGF(Bullet GDEKLMNKJBC = null)
		{
			return null;
		}

		protected override void FCIODKAEJGF(Bullet HCLJODLNCNE, Vector3 INLGLHIPOMC)
		{
		}

		protected void GNCNLGEOHHI(float FHFDDKOBFLG, Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float BHEFDILBFOI = 1f)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcManualExplode(float FHFDDKOBFLG, Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float BHEFDILBFOI)
		{
		}

		protected virtual void KAONGFGOMNK(float FHFDDKOBFLG, Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float BHEFDILBFOI = 1f)
		{
		}

		private IEnumerator IEDLLCFCAAN(float FHFDDKOBFLG, Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float BHEFDILBFOI = 1f)
		{
			return null;
		}

		protected void MIDGCBMIIPN(Vector3 INLGLHIPOMC, float NNLEGJGIGHA, float BHEFDILBFOI = 1f, float KBHFGBBCDMI = 1f)
		{
		}

		public override bool ImpactAlreadyRegistered(byte GIHGJIFCHMK, CHILKDJABBF INIEKKNFPDP)
		{
			return false;
		}

		protected override void JCHOIPAFDFK(Bullet HCLJODLNCNE, Player EKOFNPFCLMO, Player.NBPIPAJOGLC MKLOBAIKINA, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void BHCDKFBLBMG(Bullet HCLJODLNCNE, Enemy DPENEFKKNDN, BHHAHFFCKJO MBKGKPOBHBB, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void LABCLALOAEL(Bullet HCLJODLNCNE, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void EOJKDNNLMMB(Bullet HCLJODLNCNE, Trap MBLENDJGFCI, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void LBCNCAJOOJJ(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void KBOFMAGIGAE(Enemy NJDDIIEPJDM, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void BAPNMFLDAFL(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected virtual void BGACPKCBJKB(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		public override int GetPlayerImpactDamage(Player.NBPIPAJOGLC AAEAKJPHADF, float ONDJPLPDHEC, bool ANGAIHPMEGF)
		{
			return 0;
		}
	}
}
