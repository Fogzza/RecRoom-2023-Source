using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Audio;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Tools.Weapons
{
	public class WeaponReloader : WeaponAccessory
	{
		private enum OMALHBAFCBJ
		{
			PUMP = 0,
			PULL = 1
		}

		private sealed class HCBDAEHHIPP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WeaponReloader _003C_003E4__this;

			private float _003CstartTime_003E5__2;

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
			public HCBDAEHHIPP(int _003C_003E1__state)
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

		private sealed class HLIFLFOPMEG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float returnDistance;

			public WeaponReloader _003C_003E4__this;

			private float _003CreturnVelocity_003E5__2;

			private float _003Cduration_003E5__3;

			private float _003Ctimer_003E5__4;

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
			public HLIFLFOPMEG(int _003C_003E1__state)
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

		private const float HIGEPGBNLLD = 0.99f;

		[SerializeField]
		private OMALHBAFCBJ reloaderType;

		[SerializeField]
		private Transform emptyClipTransform;

		[SerializeField]
		private Transform fullClipTransform;

		[SerializeField]
		private float extraPullDistance;

		[SerializeField]
		private RecRoomAudioClip pullTickAudio;

		[SerializeField]
		private int pullTickCount;

		[SerializeField]
		private float returnToConstraintSpeed;

		[SerializeField]
		private bool animateParentWeaponReloader;

		[SerializeField]
		private float reloaderAnimationBlendWhileFiring;

		private static readonly int HCLGOMBHOAJ;

		private const float DLCNFGLDJDD = 0.45f;

		[NonSerialized]
		public bool ReloadsAutomatically;

		[SerializeField]
		private DelayedRangedWeaponTrigger delayedWeaponTrigger;

		private PlungerRigidbodyPickup IOEODMMGOBK;

		private Vector3 ALIOBPDNIED;

		private float IMGDBKHBDGP;

		private float PPOLKOCHOIA;

		private bool KFHFEJPODOA;

		private float EDFGIOPONGA;

		private float? EOFIACELLKE;

		private IDisposable OBECBJCGHMB;

		private bool GDABAEEMGJB;

		private Coroutine EJNIIHPMNBI;

private int CEJNOCNOPNL
{
get 		{
			return 0;
		}

}

public bool AnimateParentWeaponReloader
{
get 		{
			return false;
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

		protected override void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void KMJPBECOCIC()
		{
		}

		private void HBFCDHKCCAF()
		{
		}

		private void OGBADKEKAFI()
		{
		}

		private void KNALNPOIOPN(Tool IEGMBEPJMGC)
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		private void GHPJGMOFEKE(Tool IEGMBEPJMGC)
		{
		}

		private void PLLGKABPABI(Tool IEGMBEPJMGC, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		protected override void DOKEBOEBJNK(Tool IEGMBEPJMGC)
		{
		}

		protected override void CNFFFPCNNJE(Tool IEGMBEPJMGC)
		{
		}

		protected override void LEHMEAMPKOL(RigidbodyEx OFNCMNJCFKJ)
		{
		}

		private void MEBNNOCJCOF()
		{
		}

		private void GOFNMJJIBGN()
		{
		}

		private void DLGPHFLCENO()
		{
		}

		private IEnumerator NKJIBAMKOIM()
		{
			return null;
		}

		private IEnumerator DHIJAGPLLAO(float EOFIACELLKE)
		{
			return null;
		}

		private void NHFMPGEPOED()
		{
		}

		private void LAFALFHCAJI()
		{
		}

		private void JIFOHGAFNMF(DelayedRangedWeaponTrigger OBNBBDPHGAD)
		{
		}

		private void FGPKKEHCONB(DelayedRangedWeaponTrigger OBNBBDPHGAD)
		{
		}

		private bool PJCFBMINANN(Tool PMEFICGEDFK, Player CLAAKJAFDLA, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		private void HLODDBFJIMP(float BDDFACNAHKF)
		{
		}

		[CompilerGenerated]
		private void FBILKJIGAJM()
		{
		}
	}
}
