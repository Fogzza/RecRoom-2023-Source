using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Combat;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestMeleeAttackEnemy : Enemy
	{
		private enum NCFAFPAGAMD
		{
			FIND_TARGET = 0,
			FOLLOW_TARGET = 1,
			SCRAMBLE_CHARGE = 2,
			REPOSITION = 3,
			ATTACK = 4,
			BLOCK = 5,
			INVALID = 65535
		}

		private enum HLEFDBNLNCD
		{
			PREPARE = 0,
			REPOSITION = 1,
			POST = 2
		}

		private enum OABJDEKMGHE
		{
			CHARGE = 0,
			CHARGE_FAST = 1,
			ATTACK = 2,
			RECOVERY = 3,
			INTERRUPTED = 4
		}

		private sealed class PPMEICAAFJC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestMeleeAttackEnemy _003C_003E4__this;

			public Enemy enemy;

			public Player hitPlayer;

			public Player.NBPIPAJOGLC hitBodyPart;

			public NGLCDIDOEMK impact;

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
			public PPMEICAAFJC(int _003C_003E1__state)
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
		private float desiredTargetDistance;

		[SerializeField]
		private float minRandomTargetOffsetAngle;

		[SerializeField]
		private float maxRandomTargetOffsetAngle;

		[SerializeField]
		private float scrambleToTargetDistance;

		[SerializeField]
		private float scrambleToTargetSpeed;

		[SerializeField]
		private bool scrambleHasRequiredAttackVariant;

		[SerializeField]
		private int scrambleRequiredAttackVariantIndex;

		[SerializeField]
		private bool repositionBeforeAttack;

		[SerializeField]
		private float repositionTargetDistanceMultiplier;

		[SerializeField]
		private float repositionAngle;

		[SerializeField]
		private float repositionPrepareDuration;

		[SerializeField]
		private float maximumRepositionDuration;

		[SerializeField]
		private float postRepositionDuration;

		[SerializeField]
		private float repositionSpeed;

		[SerializeField]
		private float repositionAcceleration;

		[SerializeField]
		private float repositionAngularSpeed;

		[SerializeField]
		private bool chargesAttack;

		[SerializeField]
		private float chargeAttackDuration;

		[SerializeField]
		private float chargeAttackFastDuration;

		[SerializeField]
		private bool supportsChargingWhileMoving;

		[SerializeField]
		private float attackDuration;

		[SerializeField]
		private float attackRecoveryDuration;

		[SerializeField]
		private bool supportsBlocking;

		[SerializeField]
		private float blockDuration;

		[SerializeField]
		private float blockLinearVelocityMultiplier;

		[SerializeField]
		private float blockAngularVelocityMultiplier;

		[SerializeField]
		private RecRoomAudioClip blockAudio;

		[SerializeField]
		private PooledParticle blockParticles;

		[SerializeField]
		private bool supportsAttackInterruption;

		[SerializeField]
		private float attackInterruptionDuration;

		[SerializeField]
		private RecRoomAudioClip attackInterruptAudio;

		[SerializeField]
		private PooledParticle attackInterruptParticle;

		[SerializeField]
		private Collider swingCollider;

		private JOJOABLFOBA PBLPENFJJBG;

		private HONEDBECDOK NCFAAOFJHCF;

		private global::MOBDJNEDDKC<int> ONKMNBDKGNF;

		private AnimationAttackTrigger JKCAPFODGNL;

		protected const RigidbodyConstraints JCGGHHKPOJN = RigidbodyConstraints.FreezeRotation;

		private Vector3 FBOFMGKDDJH;

private int IJJFHMGBEEH
{
get 		{
			return 0;
		}

set {
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

		protected override void NEJEMAPNLKG()
		{
		}

		protected override void OFHFJBCEGKG()
		{
		}

		protected override void Update()
		{
		}

		private void CFDGMGOFIFG(bool FBHDABEFLKL)
		{
		}

		private void OLCKPNCBCCH()
		{
		}

		protected override void MGKPHCBKLEN(Enemy DPENEFKKNDN, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private IEnumerator IBHEAHHKONN(Enemy DPENEFKKNDN, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return null;
		}

		private void GAEFMPOPCCC(Enemy DPENEFKKNDN, Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override void EKCPKDDGHED(Enemy DPENEFKKNDN, Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		protected override bool DGLIDHCLFDE(DPMOPDDAJBJ NJDHAACHDKF, Weapon PLOGNHIJBNB, DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, int FDDPFMJOHLO, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		private bool MFFICFHPEGH(Weapon PLOGNHIJBNB, CHILKDJABBF HIMDEKCJKAD, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		private bool BGEFPMIHBNO(CHILKDJABBF FDOGMDABIGJ, MeleeWeapon PLOGNHIJBNB, Vector3 MIFJCKFLKDI, Vector3 JHCIAOFAHFD)
		{
			return false;
		}

		private bool LLKDKFPLKEM(Player EKOFNPFCLMO, out MeleeWeapon OHDFIGLMMFC)
		{
			OHDFIGLMMFC = null;
			return false;
		}

		private bool LBINGFEPINI(Tool IEGMBEPJMGC, out MeleeWeapon OHDFIGLMMFC)
		{
			OHDFIGLMMFC = null;
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcOnBlock(CHILKDJABBF HIMDEKCJKAD, Vector3 MIFJCKFLKDI)
		{
		}

		private bool BKJEABNOEAA(CHILKDJABBF DOMFIFFLOLM, MeleeWeapon PLOGNHIJBNB, Vector3 MIFJCKFLKDI)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcOnAttackInterrupt(CHILKDJABBF DMLHIILMIHM, int EBPAGLCOLCM, Vector3 PDFEDMAOMNH)
		{
		}

		private bool FIMFIHCMONF(MeleeWeapon PLOGNHIJBNB, NGLCDIDOEMK BNFNJFKJEOA)
		{
			return false;
		}

		private void FFDCLBCHKBJ(bool BFDBCMGIOBG)
		{
		}

		private void BEJICGGDLFJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void GJDHFPLLBKK()
		{
		}

		private void DKDPHKDOEGP(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ALENMAAPGIB()
		{
		}

		private void PAHAOJDJFJL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private bool AAANIHOJBMI(Vector3 INKGHPCDMCG, Vector3 CDCEFBJHIAN, float IOFLOODGLNO)
		{
			return false;
		}

		private void CAIADKEFOKG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void JOKANLJAOOI(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void KDIKEFAMCKN(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ILDCHLGBFFE()
		{
		}

		private void DFDIMOEDFIO(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DOKEADCKGHG()
		{
		}

		private void DGAFPDBFEHF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void ENKPJDCGOLN()
		{
		}

		private Vector3 DNCFFGMLKBH(Vector3 INKGHPCDMCG, Vector3 CDCEFBJHIAN, float BKFGJDFMNKI, float NPJFFMNGJAI)
		{
			return default;
		}

		private Vector3 OOKADHAGOMM(Vector3 INKGHPCDMCG, Vector3 CDCEFBJHIAN, float BKFGJDFMNKI, Vector3 JNNAPEHCCOF, Vector3 EHJMIHGFHGI)
		{
			return default;
		}

		private void MMENAMGOGLC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DLMPBLIGHKN()
		{
		}

		private void JFJJELDALAB(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void IPLNGHPGCBG(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DHGKECPOPKB()
		{
		}

		private void ECAJKHOCHOB(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void MHNCFCAACEF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void BNFAEPPHBFP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void LPMCMKEDAIF(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CJCOFDFHGGB()
		{
		}

		private void MJGPFFIOLLE(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DPIAEECOONB()
		{
		}

		private void IHCMHBJDHEJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void EAAPKNNBEDI()
		{
		}

		private void NLBIEPLMNJP(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void BJCHLCMDCPA(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void DHCFJCPAODK()
		{
		}

		private void ALFJKGDJJGH(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CIILOGDBNIB()
		{
		}

		public override void AuthorityOnDamageChangeVelocity(DJBEHNDMJDL IKEDGLGPGEA, BHHAHFFCKJO GFHNJGJNNCK, Vector3 OIEPDFJCEHE, Vector3 MEBJBANMPLK)
		{
		}

		protected override void GGKGCGAEDOI()
		{
		}

		protected override void HDGAJEPCDAJ()
		{
		}
	}
}
