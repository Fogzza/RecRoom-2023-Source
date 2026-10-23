using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core
{
	public class ProxyPhysicsCollision : MonoBehaviour
	{
		public struct EDPCAOHKCDA
		{
			public MMECCKDCDCE HALEHDNDOOH;

			public Transform CDEONIICADA;

			public Vector3 DDCOIEGJHIE;

			public Quaternion ICHHCGIMAEK;
		}

		private sealed class CMPMLNFIAPG
		{
			public (MMECCKDCDCE, bool) args;

			internal bool _003COnAdditionalPartIsProxyingEnabledChanged_003Eb__0(EDPCAOHKCDA record)
			{
				return false;
			}
		}

		[SerializeField]
		protected ProxyPhysicsCollisionTransform collisionTransform;

		[SerializeField]
		protected Transform targetTransform;

		private readonly List<EDPCAOHKCDA> LCLLNLDNKBF;

		private Vector3 IDBDPILBHKK;

		private Quaternion CICIBNJOBEJ;

		private Action<Collider> AJBMCEHBEEG__BackingField;

		private Action<Collider> MNLNBDDHAOK__BackingField;

		private Action<Collider> AOILMOADANJ__BackingField;

		private Action<Collision> IFADGOLAKKF__BackingField;

		private Action<Collision> MOHDPMJIENI__BackingField;

		private Action<Collision> MBKNOOEMHAN__BackingField;

public Vector3 LastPositionOffset
{
get 		{
			return default;
		}

}

public Quaternion LastRotationOffset
{
get 		{
			return default;
		}

}

public event Action<Collider> OnTriggerEnterEvent {
add {
		}
remove {
		}
}

public event Action<Collider> OnTriggerStayEvent {
add {
		}
remove {
		}
}

public event Action<Collider> OnTriggerExitEvent {
add {
		}
remove {
		}
}

public event Action<Collision> OnCollisionEnterEvent {
add {
		}
remove {
		}
}

public event Action<Collision> OnCollisionStayEvent {
add {
		}
remove {
		}
}

public event Action<Collision> OnCollisionExitEvent {
add {
		}
remove {
		}
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

		protected void FixedUpdate()
		{
		}

		protected void OnCollisionEnter(Collision KDGCDLJEAMD)
		{
		}

		protected void OnCollisionStay(Collision KDGCDLJEAMD)
		{
		}

		protected void OnCollisionExit(Collision KDGCDLJEAMD)
		{
		}

		protected void OnTriggerEnter(Collider HNPEBINPOBO)
		{
		}

		protected void OnTriggerStay(Collider HNPEBINPOBO)
		{
		}

		protected void OnTriggerExit(Collider HNPEBINPOBO)
		{
		}

		public void RegisterAdditionalPart(MMECCKDCDCE BKDCPFHKDLB)
		{
		}

		private void GAINJOBKHDJ(EDPCAOHKCDA OBMHEBIAKGO)
		{
		}

		private void DGJCDJHPALJ(EDPCAOHKCDA OBMHEBIAKGO)
		{
		}

		private void AKKLJPGAANB((MMECCKDCDCE, bool) ADCFFAJGNAM)
		{
		}

		private void FAMOINBDAHP(Transform HFPHBCLGAMC)
		{
		}
	}
}
