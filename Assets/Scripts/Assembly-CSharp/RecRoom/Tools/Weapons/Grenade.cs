using System;
using System.Collections.Generic;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class Grenade : Weapon
	{
		protected enum EAEBODIGJIF
		{
			DISARMED = 0,
			ARMED = 1,
			DETONATED = 2
		}

		private const float NNLELDNBAEI = 0.1f;

		private static readonly string POKECDIBLLG;

		[SerializeField]
		protected float explosionRadius;

		[SerializeField]
		protected float explosionForce;

		[SerializeField]
		protected AnimationCurve forceFalloff;

		[SerializeField]
		protected AnimationCurve damageFalloff;

		[SerializeField]
		protected float explosionTimeout;

		[SerializeField]
		private Transform visualRoot;

		[SerializeField]
		private PooledParticle explosionParticlesPrefab;

		[SerializeField]
		private PooledParticle armedParticlesPrefab;

		[SerializeField]
		private Transform armedParticlesTransform;

		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private RecRoomAudioClip explodeAudio;

		[SerializeField]
		private RecRoomAudioClip activeAudio;

		[SerializeField]
		private RecRoomAudioClip countdownAudio;

		[SerializeField]
		private AnimationCurve explosionTimeLeftToCountdownAudioCurve;

		protected readonly BCKPMPNCEOO GBNGMEEHPCB;

		private SFXAudioSource ODPHJCDIAJO;

		private PooledParticle IDBIJIKDACC;

		protected bool LLKMDKKOOLF;

		private float KDBOKHGNDAH;

		private float GPGMBFGHLLD;

		protected JOJOABLFOBA LFJDBDLHJEP;

		protected HONEDBECDOK PBGDDCKLHOH;

		private float EBDENNOLHJJ;

		private List<CHILKDJABBF> MPKKDGMNNDA;

		[NonSerialized]
		public bool AutomaticallyArmOnNextRelease;

		private global::MOBDJNEDDKC<int> GDJELDOGNIJ;

protected override Color EGOOKBNKAEM
{
get 		{
			return default;
		}

}

private Player EFGNNFPALGN
{
get 		{
			return null;
		}

set {
		}
}

public bool IsArmed
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void FMJNDHMBJEC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void CJOMFNGPHEE()
		{
		}

		protected virtual void IOKNENCFBCE(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		protected virtual void GPJPAEFLABD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		protected virtual void LINILPAANNL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void NNALCHFEBDC(Tool IEGMBEPJMGC)
		{
		}

		protected virtual void PJOJAJHOBPE(Tool IEGMBEPJMGC)
		{
		}

		protected override void PLLGKABPABI(Tool PMEFICGEDFK, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool DFAOAOMFDKE)
		{
		}

		protected override void AOMPLKNJDAI()
		{
		}

		protected override void BMFONHPBFAN(Player ACNLJOAAJMA, Weapon PANFKBPMCFI)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAuthorityHitExplosiveWithWeapon(CHILKDJABBF ACNLJOAAJMA, Weapon PANFKBPMCFI, bool PLCBPELAHBM, bool NCBKFMHNIFD, bool HDJAIKKBLDI)
		{
		}

		protected virtual void IFCFEJLCKCF(CHILKDJABBF ACNLJOAAJMA, Weapon PANFKBPMCFI, bool PLCBPELAHBM, bool NCBKFMHNIFD, bool HDJAIKKBLDI)
		{
		}

		public virtual void AuthorityArmGrenade()
		{
		}

		private void ALLBOHLMPNB(bool IFEELKEGNPO = false)
		{
		}

		protected void INMIHBOAPAM(bool BFDBCMGIOBG)
		{
		}

		protected virtual PooledParticle FFPFAECAFII()
		{
			return null;
		}

		private void PLJHPBNIMCA()
		{
		}

		private void OJCNHNFDPPN()
		{
		}

		private void IMGHDJEEKPJ()
		{
		}

		private void DIIIGEJFGCO()
		{
		}

		public override bool ImpactAlreadyRegistered(byte GIHGJIFCHMK, CHILKDJABBF INIEKKNFPDP)
		{
			return false;
		}

		private void LBCNCAJOOJJ(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void KBOFMAGIGAE(Enemy NJDDIIEPJDM, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BAPNMFLDAFL(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BGACPKCBJKB(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		public override int GetPlayerImpactDamage(Player.NBPIPAJOGLC AAEAKJPHADF, float ONDJPLPDHEC, bool ANGAIHPMEGF)
		{
			return 0;
		}

		protected virtual void OnDrawGizmosSelected()
		{
		}
	}
}
