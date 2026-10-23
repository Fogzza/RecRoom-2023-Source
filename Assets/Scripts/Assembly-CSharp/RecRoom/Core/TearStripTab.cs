using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Core
{
	public class TearStripTab : MonoBehaviour
	{
		private sealed class IOAOAMPNDEJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TearStripTab _003C_003E4__this;

			private float _003CpopTimePerLink_003E5__2;

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
			public IOAOAMPNDEJ(int _003C_003E1__state)
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
		private Tool tool;

		[SerializeField]
		private TearStripChest chest;

		[SerializeField]
		private RecRoomAudioClip poppingSound;

		[SerializeField]
		private SkinnedMeshRenderer meshRenderer;

		[SerializeField]
		private Transform transformWhenTearing;

		[SerializeField]
		private float autoTearStartPercentage;

		[SerializeField]
		private float autoTearDuration;

		[SerializeField]
		private bool forceDropWhenTorn;

		public bool TearingEnabled;

		private bool DHEKOCGIHNL;

		private AxisConstrainedRigidbodyPickup BINEFHINMGP;

		private bool GIBOFCALMJB;

		private bool NNMMIBEMKLO;

		private int MMKFJEDPBLG;

		private Transform[] PFHJBLKGJML;

		private KKGCOBPPLHO KBOIHKDCGKF;

		private Vector3 DHPDDGIACKJ;

		private float LKOHMMGBFHI;

		private float JIHADKLALBK;

		private Vector3 BLKBDOLHMAH;

		private float DHBCIJFDGIC;

public Tool Tool
{
get 		{
			return null;
		}

}

public AxisConstrainedRigidbodyPickup ConstrainedRigidbodyPickup
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsTorn
{
get 		{
			return false;
		}

}

public TearStripChest Chest
{
get 		{
			return null;
		}

}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void FixedUpdate()
		{
		}

		private void ILJPCIFFFFJ(Vector3 ENAIMPGAJLC, float CAIOIMLMJBB)
		{
		}

		private IEnumerator JFLBDNALNEE()
		{
			return null;
		}

		private void APLCMMAJAOP(Vector3 ENAIMPGAJLC, float CAIOIMLMJBB)
		{
		}

		private bool DMPAGFFJLOO(Tool PMEFICGEDFK, Killzone FOOPALEAEGM)
		{
			return false;
		}

		private void KNALNPOIOPN(Tool IEGMBEPJMGC)
		{
		}

		private void NNALCHFEBDC(Tool IEGMBEPJMGC)
		{
		}

		private void MCPPOGMDJPH()
		{
		}

		private void PLLGKABPABI(Tool IEGMBEPJMGC, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
		{
		}

		private bool PJCFBMINANN(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		public void TearOff()
		{
		}

		private void GLDBEODCKDA()
		{
		}
	}
}
