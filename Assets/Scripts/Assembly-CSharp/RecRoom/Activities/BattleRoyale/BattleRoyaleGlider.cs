using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RecRoom.Audio;
using RecRoom.Core.Vehicles;
using UnityEngine;

namespace RecRoom.Activities.BattleRoyale
{
	public class BattleRoyaleGlider : BaseVehicle
	{
		private sealed class PNPMLLEBHDJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BattleRoyaleGlider _003C_003E4__this;

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
			public PNPMLLEBHDJ(int _003C_003E1__state)
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

		private sealed class AMKDCOLLIGO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BattleRoyaleGlider _003C_003E4__this;

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
			public AMKDCOLLIGO(int _003C_003E1__state)
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
		private AnimateInOut animateInOut;

		[SerializeField]
		private TeleportationPortal portal;

		[SerializeField]
		private BattleRoyaleGliderHandlebar handlebar;

		[SerializeField]
		private float postDisembarkSlowdownDuration;

		[SerializeField]
		private Transform canopyVisual;

		[SerializeField]
		private ParticleSystem firstPersonParticles;

		[SerializeField]
		private Vector3 collisionSphereOriginLocalposition;

		[SerializeField]
		private float collisionSphereRadius;

		[SerializeField]
		private float collisionSkinThickness;

		[SerializeField]
		private int collisionMaxIterations;

		[SerializeField]
		private AnimationCurve throttleCurve;

		[SerializeField]
		private float negativeThrottleForwardSpeed;

		[SerializeField]
		private float minThrottleForwardSpeed;

		[SerializeField]
		private float maxThrottleForwardSpeed;

		[SerializeField]
		private float negativeThrottleFallingSpeed;

		[SerializeField]
		private float minThrottleFallingSpeed;

		[SerializeField]
		private float maxThrottleFallingSpeed;

		[SerializeField]
		private float negativeThrottleCanopyPitch;

		[SerializeField]
		private float minThrottleCanopyPitch;

		[SerializeField]
		private float maxThrottleCanopyPitch;

		[SerializeField]
		private AnimationCurve steeringCurve;

		[SerializeField]
		private float maxYawSpeed;

		[SerializeField]
		private float maxTurnCanopyRoll;

		[SerializeField]
		private AnimationCurve steeringVignetteCurve;

		[SerializeField]
		private RecRoomAudioClip deploySFX;

		[SerializeField]
		private RecRoomAudioClip canopyFlapSFX;

		[SerializeField]
		private RecRoomAudioClip steerSFX;

		[SerializeField]
		private Transform steerLeftAudioOrigin;

		[SerializeField]
		private Transform steerRightAudioOrigin;

		[SerializeField]
		private AnimationCurve steerSFXCurve;

		[SerializeField]
		private RecRoomAudioClip windSFX;

		[SerializeField]
		private AnimationCurve windSFXThrottleCurve;

		[SerializeField]
		private float throttleAudioDecelerateTime;

		[SerializeField]
		private RecRoomAudioClip[] handlebarCreakSFXChoices;

		[SerializeField]
		private float minCreakPeriod;

		[SerializeField]
		private float steerCreakThreshold;

		[SerializeField]
		private float throttleCreakThreshold;

		private bool NOJBPCNNLND;

		private Coroutine NEIGAEKNPON;

		private SFXAudioSource IEBGOPPAHMB;

		private SFXAudioSource KCENDHPPKFP;

		private SFXAudioSource BOJIFDMOHFH;

		private float AIIOFFAJFPN;

		private float MLBEDJFOIIB;

		private Vector2 OCGAGMGFCMA;

		private float AEIMLBABHEH;

		private const float LJDMIDBGIHM = 1f;

		private const float FKGIPAMAOGB = 1f;

		[NonSerialized]
		public bool InDirectSteerMode;

		private bool HPCIHJNDCJK;

public float MaxSteerSpeed
{
get 		{
			return 0f;
		}

}

public BattleRoyaleGliderHandlebar Handlebar
{
get 		{
			return null;
		}

}

public bool BoardingEnabled
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

		private void Update()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void SteerDirectly(float DKINOEEHLBE, float IBCNHMMABBN, float CLHLCLNPAKO, float KJJGBEIGNAN)
		{
		}

		private void NANGADAALBA(float DKINOEEHLBE, float IBCNHMMABBN, float CLHLCLNPAKO, float KJJGBEIGNAN)
		{
		}

		private void PCOHCCLLOMI(float FPJGAJJKGMN, float OHPLGHHAECG)
		{
		}

		private void NAHNJFFECJJ(float OHPLGHHAECG)
		{
		}

		private void OJNIANGNONL(float FPJGAJJKGMN, float OHPLGHHAECG)
		{
		}

		private void JDAPMPFPAJG()
		{
		}

		private void DGCAKEKALGH(float FPJGAJJKGMN, float OHPLGHHAECG)
		{
		}

		private bool JANOAKEGODC(Vector3 OIEPDFJCEHE)
		{
			return false;
		}

		private bool CGEHMOFLDHI(out Vector3 KEHKGALKGFP)
		{
			KEHKGALKGFP = default;
			return false;
		}

		private void EKPGDPEMHMF()
		{
		}

		protected override void LPLOJFCFBCH()
		{
		}

		private void HJOOPJKBJHE()
		{
		}

		protected override void GHDLHBBBDEL(Player EKOFNPFCLMO, out Vector3 CLCKEILHMCE, out Quaternion KIPJBLDNNOP)
		{
			CLCKEILHMCE = default;
			KIPJBLDNNOP = default;
		}

		protected override void CBEHAHCFNIH(CHILKDJABBF PAAEPEPFNHE)
		{
		}

		private void BPOHGCMEAHI(TeleportationPortal KNAPEFNAOGE)
		{
		}

		private void PFCPFMLGONA()
		{
		}

		private IEnumerator BGCFHDLEKCG()
		{
			return null;
		}

		private IEnumerator JKLGIBNCCHP()
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcOnGliderDeploy(Vector3 EGLFIDAPMIO)
		{
		}

		public static BattleRoyaleGlider InstantiateForLocalPlayer(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool EDEMCAFCPIO, bool NOJBPCNNLND)
		{
			return null;
		}
	}
}
