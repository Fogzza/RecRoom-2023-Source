using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.AI;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class ExplosiveTrap : Trap
	{
		private enum AONPJNJNGNA
		{
			DISARMED = 0,
			ARMED = 1,
			DETONATED = 2,
			INVALID = 65535
		}

		private sealed class CDGLCJHPOJP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExplosiveTrap _003C_003E4__this;

			public float frequency;

			private float _003Cperiod_003E5__2;

			private float _003Ctimer_003E5__3;

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
			public CDGLCJHPOJP(int _003C_003E1__state)
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
		private BlinkingRenderer blinkingRenderer;

		[SerializeField]
		private bool canBeProximityArmed;

		[SerializeField]
		private float proximityArmRadius;

		[SerializeField]
		private float armedDuration;

		[SerializeField]
		private float armedWarningFrequency;

		[SerializeField]
		private RecRoomAudioClip armedWarningBeepAudio;

		[SerializeField]
		private float explosionRadius;

		[SerializeField]
		private float explosiveForce;

		[SerializeField]
		private PooledParticle explosionParticlePrefab;

		[SerializeField]
		private RecRoomAudioClip explosionAudio;

		[SerializeField]
		private Renderer[] renderers;

		[SerializeField]
		private Light[] lights;

		private static CHILKDJABBF[] HKLIMFCLJLF;

		private HONEDBECDOK IFCDBBCODHP;

		private JOJOABLFOBA BGBIFFLGANM;

		private bool HOCFFNMCCJJ;

		private PointsDropper JHHDJDGINPI;

		private BCKPMPNCEOO GBNGMEEHPCB;

		private Coroutine JOPAFJADHCP;

private bool FIFCELPAKGA
{
set {
		}
}

private bool NNGNALANPIO
{
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

		protected override void IDIEHBILCLL()
		{
		}

		private void Update()
		{
		}

		private void BEEPGDAFPGH()
		{
		}

		private void FMJNDHMBJEC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void CJOMFNGPHEE()
		{
		}

		private void IOKNENCFBCE(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		private void GPJPAEFLABD(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LINILPAANNL(ushort ANAKIMJNHMH, ushort EDNNIIPAKCK)
		{
		}

		public override void AuthorityApplyDamage(DJBEHNDMJDL IKEDGLGPGEA, int FDDPFMJOHLO, Vector3 PDFEDMAOMNH, Vector3 CHEKLLFMKBP)
		{
		}

		private void MGKPHCBKLEN(Player KJCCPIIFNGO, Player.NBPIPAJOGLC AAEAKJPHADF, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void BCHPHNNIPMK(Enemy NJDDIIEPJDM, BHHAHFFCKJO GFHNJGJNNCK, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void AJEBBOBCEED(Trap AOCKEAPKNDE, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void HIMBHEKNECN(Tool LMEKFBDFCDN, NGLCDIDOEMK BNFNJFKJEOA)
		{
		}

		private void KAONGFGOMNK()
		{
		}

		private void HFIDMPHPDMD()
		{
		}

		private void KAMDIGFKJOF()
		{
		}

		private void MMOMPIILDPC()
		{
		}

		private IEnumerator GGMDKIHIMGB(float DMOIMIACENF)
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
