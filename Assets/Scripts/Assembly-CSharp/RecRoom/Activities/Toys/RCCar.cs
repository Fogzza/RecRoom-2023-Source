using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Toys
{
	public class RCCar : RemoteControllable, KFLNCOLKJEM
	{
		private enum ALFILPJFDLH
		{
			None = -1,
			Normal = 0,
			FrontFlip = 1,
			BackFlip = 2,
			LeftFlip = 3,
			RightFlip = 4
		}

		private enum KAHFOCEGMOK
		{
			Idle = 0,
			Accelerating = 1,
			Decelerating = 2,
			Cruising = 3
		}

		private sealed class EDHKOPHNHDG : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RCCar _003C_003E4__this;

			public ALFILPJFDLH flipType;

			private float _003CflipTime_003E5__2;

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
			public EDHKOPHNHDG(int _003C_003E1__state)
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
		private Transform frontAxleTransform;

		[SerializeField]
		private Transform rearAxleTransform;

		[SerializeField]
		private RCCarWheel[] wheels;

		[SerializeField]
		private float maxSpeed;

		[SerializeField]
		private float maxBoostedSpeed;

		[SerializeField]
		private float groundThrottleAcceleration;

		[SerializeField]
		private float groundFrictionDeceleration;

		[SerializeField]
		private FloatValueCurve groundFrictionSideDecelerationOverSpeed;

		[SerializeField]
		private float boostAcceleration;

		[SerializeField]
		private FloatValueCurve angularVelocityCompensationOverTurnAmount;

		[SerializeField]
		private FloatValueCurve steeringTorqueOverSpeed;

		[SerializeField]
		private float gravity;

		[SerializeField]
		private float jumpVelocity;

		[SerializeField]
		private float flipVelocityBoost;

		[SerializeField]
		private FloatValueCurve flipAngularSpeedOverTime;

		[SerializeField]
		private float jumpCooldown;

		[SerializeField]
		private float turnOverSpeed;

		[SerializeField]
		private Vector3 maxAirborneAngularVelocities;

		[SerializeField]
		private Vector3 airborneAngularAccelerations;

		[SerializeField]
		private Vector3 accelerationForceOffset;

		[SerializeField]
		private Vector3 chasisCenter;

		[SerializeField]
		private float flickGestureSpeed;

		[SerializeField]
		private float flippedOnSideCheckDistance;

		[SerializeField]
		private float flippedOnRoofCheckDistance;

		[SerializeField]
		private ParticleSystem boostParticleSystem;

		[SerializeField]
		private float maxTurnAnimationAngle;

		[SerializeField]
		private TrailRenderer[] trails;

		[SerializeField]
		private AudioSource engineAudioSource;

		[SerializeField]
		private RecRoomAudioClip acceleratingAudioClip;

		[SerializeField]
		private RecRoomAudioClip deceleratingAudioClip;

		[SerializeField]
		private RecRoomAudioClip engineLoopAudioClip;

		private const float GLLNCEJAFNF = 0.01f;

		private const float AKHLELBMBFA = 0.01f;

		private float DIIKANKDGEO;

		private float JOKALAOMADO;

		private float COBJHGBMFOI;

		private ALFILPJFDLH OIGDICKCNMH;

		private global::MOBDJNEDDKC<bool> NGLMKNFGGPA;

		private float BCNAFBMIKMO;

		private float EABIBGKAHFA;

		private const int DPLPGJOJOLM = 2;

		private int OHHMDIOCJNJ;

		private bool BFMPENLPOPK;

		[SerializeField]
		private Animator animator;

		private float IOGKNBPLDEJ;

		private float ELEPCPLFPAB;

		private KAHFOCEGMOK AEBOFFMBJBJ;

		private static readonly int NOIJDHOEJAD;

		private static readonly int EKABGKAIKCN;

private bool HIMIIFABDCD
{
get 		{
			return false;
		}

set {
		}
}

private bool LBNPPAJMFNN
{
get 		{
			return false;
		}

}

private bool PMNOMGDMEJF
{
get 		{
			return false;
		}

}

private bool HLGOGGBFEHO
{
get 		{
			return false;
		}

set {
		}
}

private float DIELELLHCOC
{
get 		{
			return 0f;
		}

set {
		}
}

private float OIINBNPBJEC
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

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void IHLNPHDKJOO()
		{
		}

		private void IFMCGDHACGO()
		{
		}

		private IEnumerator BEKEAHKEHND(ALFILPJFDLH CILNBOCPHHG)
		{
			return null;
		}

		private void AFDLFEFEPLN()
		{
		}

		private void OJNIANGNONL()
		{
		}

		private void FNCGFCEMPJG()
		{
		}

		private void PKCCLLNKKOC(Color HMCAFGCGFJF)
		{
		}

		public override void LocalUpdateRemoteControlInput(PlayerHand LIEHAPOPALF, Vector3 FDPINLJAOOP, float FJNAAEFPLBO, bool CDEDFFHMNCD)
		{
		}

		public void OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
