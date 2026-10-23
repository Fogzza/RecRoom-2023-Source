using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.AI;
using UnityEngine;

namespace RecRoom.Activities.Quest
{
	public class QuestExplosiveEnemy : Enemy
	{
		private enum PLKOBOEENAF
		{
			FIND_TARGET = 0,
			FOLLOW_TARGET = 1,
			INVALID = 65535
		}

		private sealed class LIBLCLDBJOK : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float frequency;

			public QuestExplosiveEnemy _003C_003E4__this;

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
			public LIBLCLDBJOK(int _003C_003E1__state)
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
		private float warningFrequency;

		[SerializeField]
		private RecRoomAudioClip warningAudioBeep;

		[SerializeField]
		private float explosionRadius;

		private JOJOABLFOBA BEMANLOEDDE;

		private HONEDBECDOK ACMNKPDJAJE;

		private BlinkingRenderer DOKMDKCBJML;

		private Coroutine IHLPOHAKCMC;

		private float EPFJJICOJOB;

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

		private void NDPALLANICN()
		{
		}

		[PBOMGCLBFHF]
		private void RpcExplode()
		{
		}

		protected override void BHECKIKLDOK()
		{
		}

		private void BEIJIILKJNC()
		{
		}

		private void GNCFKCNALBG()
		{
		}

		private IEnumerator BIPCLDNHPIC(float DMOIMIACENF)
		{
			return null;
		}

		private void CCNAJJHHFCD()
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
