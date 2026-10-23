using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class BurstFireGun : RangedWeapon
	{
		private enum AMGHKCDKFKB
		{
			SPRAY = 0,
			SIMPLE = 1
		}

		private sealed class JNJMCGPKFAN : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BurstFireGun _003C_003E4__this;

			public int semiAutomaticShotCount;

			private float _003CinitialAngle_003E5__2;

			private float _003CinitialVelocity_003E5__3;

			private float _003Cacceleration_003E5__4;

			private float _003Ctimer_003E5__5;

			private float _003CreturnToRestTime_003E5__6;

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
			public JNJMCGPKFAN(int _003C_003E1__state)
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

		private const float KAANLPCDGHJ = -1f;

		private const float GODBLNBDFFC = 50f;

		[SerializeField]
		private AMGHKCDKFKB burstMode;

		[SerializeField]
		private Transform kickbackTransform;

		[SerializeField]
		private float totalBurstAngle;

		private float AGOHJDJBICI;

		[SerializeField]
		private float curveNextShotTimeNormalized;

		[SerializeField]
		private float simpleBurstModeBurstSize;

		[SerializeField]
		private bool hasMaxDistance;

		[SerializeField]
		private float maxDistance;

		[SerializeField]
		private Transform sprayTargetRoot;

		private Transform[] GFKENPOPAPJ;

		private int BGNPBNMLFNI;

		private IDisposable LEFGJBPJOON;

		private Coroutine LCIOPNHFGPI;

private float HPJMNAPIMGM
{
get 		{
			return 0f;
		}

set {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void JMNJJLBJLEK(Tool PMEFICGEDFK)
		{
		}

		private void GHJGJJNABIK(Tool PMEFICGEDFK)
		{
		}

		private void BHEDNHMJFIE(Tool PMEFICGEDFK)
		{
		}

		protected override void MPNCIDCFDNM(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 OIEPDFJCEHE, float BHEFDILBFOI, bool GHCPLAPAGHB, byte CMBCNFBLLNI)
		{
		}

		private void BENOONGCBKO()
		{
		}

		private void NHDINKLIIOC()
		{
		}

		private void PNDMDLHOALK(float OKBAJEAPIHG)
		{
		}

		private void BGNNBOGOHEO(float OKBAJEAPIHG)
		{
		}

		public override bool IsAutomaticFireRunning()
		{
			return false;
		}

		private void KBCHMEDGJAJ(int IGFOFDJPPCI)
		{
		}

		private void JCHINIIGKLD()
		{
		}

		private IEnumerator BPMMBEHKMMN(int IGFOFDJPPCI)
		{
			return null;
		}

		private void BBBCLEOIAOA(float OJCHBHFBBNH, float FKBPDMHJCGH, float KAJIBHGEHKG, float FNGFEOHNOKM, out float KGIOBJMPLKI, out float JNJHPFJPBAC)
		{
			KGIOBJMPLKI = default;
			JNJHPFJPBAC = default;
		}

		private float CFHONBJJMCB(float HKCAPENMPDI, float KGIOBJMPLKI, float JNJHPFJPBAC)
		{
			return 0f;
		}
	}
}
