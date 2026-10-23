using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.Pools;
using UnityEngine;

namespace RecRoom.Core.AI
{
	public class RagdollPiece : MonoBehaviour, MMECCKDCDCE
	{
		private enum OPGKDOBCOII
		{
			NONE = -1,
			PLAY_EFFECT = 0
		}

		private sealed class PHLIAKIKHGJ : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public RagdollPiece _003C_003E4__this;

			private float _003CshrinkDelayEndTime_003E5__2;

			private float _003CshrinkEndTime_003E5__3;

			private JNDHCGAMLML _003CscheduleRate_003E5__4;

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
			public PHLIAKIKHGJ(int _003C_003E1__state)
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
		private bool disableColliderWhenNotRagdolling;

		[SerializeField]
		private bool disableInsteadOfRagdoll;

		[SerializeField]
		private ProxyPhysicsCollisionTransform proxyCollision;

		[SerializeField]
		private float criticalHitShatterSpeedMultiplier;

		[SerializeField]
		private OPGKDOBCOII criticalHitActionOverride;

		[SerializeField]
		private float criticalHitOverrideChance;

		[SerializeField]
		private bool disableWhenOverriding;

		[SerializeField]
		private PooledParticle criticalHitActionEffect;

		[SerializeField]
		private RecRoomAudioClip criticalHitActionAudioClip;

		private List<RecRoomCollider> FCDBCOOCIME;

		private List<Collider> GHKNKHCKPII;

		private Rigidbody PCCINHGFLHK;

		private Transform HHFDFFDPCGO;

		private Vector3 EGJKEDKNNAD;

		private Quaternion IBHAEICNMJI;

		private Vector3 KIJDIOHEBHG;

		private bool LDHAAGIIHGB;

		private float BIFJDNBPBPJ;

		private Vector3 DLGONELLDKK;

		private LKGILLBEJEK NCIKOAAIAAP;

		private const float GNJCCLEFDBD = 3.33f;

		private const float FCKCHFGOOKL = 0.66f;

		private static bool JBHCCOMLOEM;

		private static Vector3 POFOIFOPAFC;

		private Action<(MMECCKDCDCE, bool)> FHFEEBJKNBE__BackingField;

		private bool NDBNOMFGCED;

public GameObject ProxyCollision
{
get 		{
			return null;
		}

}

public bool IsProxyingEnabled
{
get 		{
			return false;
		}

private set {
		}
}

public event Action<(MMECCKDCDCE, bool)> IsProxyingEnabledChanged {
add {
		}
remove {
		}
}

		public static void UseCustomGravity(Vector3 POFOIFOPAFC)
		{
		}

		public static void UseDefaultGravity()
		{
		}

		protected void Awake()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		public void StartRagdoll(Vector3 HCAOLLKLKIM, Vector3 GCICHJMKKCP, float DCDLMEJGLIG, bool HIPNDKBFLGL = false)
		{
		}

		public void StopRagdoll()
		{
		}

		private IEnumerator<EGGPGCCKPCO> MNBPOCBKNJI()
		{
			return null;
		}

		private void IDMDNNGHABD()
		{
		}
	}
}
