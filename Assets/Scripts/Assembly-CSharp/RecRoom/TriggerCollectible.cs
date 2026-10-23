using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom
{
	public class TriggerCollectible : MonoBehaviourPun, HICMCNIDBOB, GAAKCFPLMHN
	{
		public delegate void ANLGEMLKANJ(TriggerCollectible BJFOGOHFGAM);

		private sealed class ICKPCEDGKBD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float respawnTime;

			public TriggerCollectible _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public ICKPCEDGKBD(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class LEOMCKBBBEF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public TriggerCollectible _003C_003E4__this;

			private float _003CanimationStartTime_003E5__2;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public LEOMCKBBBEF(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private OENDEJENMFH collectibleType;

		[SerializeField]
		private int defaultValue;

		[SerializeField]
		private bool respawn;

		[SerializeField]
		private float respawnTime;

		[SerializeField]
		private bool scaleUpOnRespawn;

		[SerializeField]
		private float respawnScaleAnimationTime;

		[SerializeField]
		private GameObject visualRoot;

		[SerializeField]
		private RecRoomAudioClip[] pickupSfx;

		[SerializeField]
		private PooledParticle pickupVfx;

		private bool NGCBKCCNBOP;

		private global::MOBDJNEDDKC<bool> HFPCFDKHLEG;

		private LKGILLBEJEK ONKFLJBBKJD;

		private float ACEPPAMDMBH;

		private int ABGNFCJCFOH;

		public static global::HHOBPMOCKMJ<TriggerCollectible> CollectedEvent;

public int Value
{
get 		{
			return 0;
		}

set {
		}
}

public bool Consumed
{
get 		{
			return false;
		}

private set {
		}
}

public OENDEJENMFH Type
{
get 		{
			return OENDEJENMFH.Default;
		}

}

public bool ShouldRespawn
{
get 		{
			return false;
		}

}

public bool ScaleUpOnRespawn
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private bool MOPNGHGOJDG(Collider HNPEBINPOBO)
		{
			return false;
		}

		private void OnTriggerEnter(Collider HNPEBINPOBO)
		{
		}

		public void OnCollect()
		{
		}

		private IEnumerator<EGGPGCCKPCO> IJDBOHHPBCB(float HCHGGLJEDFN)
		{
			return null;
		}

		private void BDLINPDMAOI()
		{
		}

		private IEnumerator<EGGPGCCKPCO> GCOECGMBFLB()
		{
			return null;
		}

		private void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		public void ResetObject()
		{
		}

		[CompilerGenerated]
		private void IOBPDMLFOKF()
		{
		}
	}
}
