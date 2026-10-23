using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Photon.Pun;
using RecRoom.Core.Combat;
using UnityEngine;

namespace RecRoom.Core.Locomotion
{
	public class PlayerMovement : MonoBehaviourPun, KFLNCOLKJEM
	{
		private class JIJPJEFBIFK
		{
			private bool BEDJGEJKGBJ;

			private bool AACMDEKGGIG;

			private RigidbodyEx HHFDFFDPCGO;

			private LAOELDLIJOM PCBJBILNFMI;

			public void LGCLINNGHPG(LAOELDLIJOM LNHIJKEHHPO, RigidbodyEx HHFDFFDPCGO)
			{
			}

			public bool BDOPEOADEHC(out LAOELDLIJOM LNHIJKEHHPO)
			{
				LNHIJKEHHPO = default;
				return false;
			}

			public void GLBPPAIACJF()
			{
			}

			private void FEAJALKKEHP(LAOELDLIJOM LNHIJKEHHPO, RigidbodyEx HHFDFFDPCGO, Transform HNECJLNIOCG)
			{
			}

			private bool LCDMGJKLPNK(Transform HNECJLNIOCG, out LAOELDLIJOM LNHIJKEHHPO)
			{
				LNHIJKEHHPO = default;
				return false;
			}
		}

		public class LGMBHCIHGDM
		{
			public PlayerMovement DLFKMDFDAFO;

			public bool OACCDFNKLKJ;

			public bool LIGCCCKJDMP;

			public bool BLLIGAJEIKF;

			public bool AHMMEGGHHKD;

			public bool AMOEALPNLBL;

			public bool GOLDDPHOKNN;

			public bool KIFJDLELDMC;

			public bool MOOAFHPOFME;

			public Vector3 AKCHNDFOLAN;

			public bool LBMMBEGINPC;

			public bool MHDADPDAIDO;

			public Vector3 DBLCFIJDLPE;

			public bool PFFLDHBJKMG;

			public Vector3 NKHHBFAKDBH;

			public bool MMPLPKGADAB;

			public bool PBJDBFIEGEN;

			public Vector3 GBAMBKIIHDC;

			public bool LBNPPAJMFNN;

			public int OFBLEIFIHPB;

			public KCIBJJDCPBO OPKAOFNCHFF;

			public Vector3 IFHMMPLCAJM;

			public float GPIFOOCPDFD;

			private const float DJGGBILKFEF = 0f;

			private const float LKBGCFACEFI = 1f;

			private const int IOFBPGJCJID = 10;

			private static readonly ELFDKCLHAMN DGJEOFHPNDP;

			public static short IIADKJHBOIN(StreamBuffer HLHADAOGCMN, object PJGPNPBFMFD)
			{
				return 0;
			}

			public static object BBCFAILGGHN(StreamBuffer FAMJGEFEDDM, short MNKGPEKFPKK)
			{
				return null;
			}
		}

		private struct LLLKBNMFGKO
		{
			public bool JJAIKMEPEGJ;

			public bool CCHKDDLFHNA;

			public Vector3 LLOLHOKFBIC;

			public Vector3 MNPAGIJPEBB;

			public float HDGFHFCPNPD;

			public float FJKIDPPLMMJ;
		}

		private sealed class DDEHNEMBIKK
		{
			private sealed class _003C_003CLocallySimulateImpulseToRemotePlayer_003Eg__LocallySimulateRemoteImpulseCoroutine_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public DDEHNEMBIKK _003C_003E4__this;

				private float _003CmaxSimulationDuration_003E5__2;

				private HOOOFBIFNOE _003CcontactData_003E5__3;

				private float _003CelapsedTime_003E5__4;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CLocallySimulateImpulseToRemotePlayer_003Eg__LocallySimulateRemoteImpulseCoroutine_007C0_003Ed(int _003C_003E1__state)
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

			public PlayerMovement _003C_003E4__this;

			public NetworkTransform networkTransform;

			public RigidbodyEx trackingSpaceRigidbodyEx;

			public Vector3 velocity;

			public bool expectAck;

			internal IEnumerator<EGGPGCCKPCO> _003CLocallySimulateImpulseToRemotePlayer_003Eg__LocallySimulateRemoteImpulseCoroutine_007C0()
			{
				return null;
			}
		}

		private sealed class PIPLDIPEMMP
		{
			private sealed class _003C_003CRpcAckApplyRemoteImpulseToLocalPlayer_003Eg__StopLocalSimulationOfRemotePlayerImpulseCoroutine_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public PIPLDIPEMMP _003C_003E4__this;

				private float _003CackDispatchTime_003E5__2;

				private NetworkTransform _003CnetworkTransform_003E5__3;

				private float _003CelapsedTime_003E5__4;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CRpcAckApplyRemoteImpulseToLocalPlayer_003Eg__StopLocalSimulationOfRemotePlayerImpulseCoroutine_007C0_003Ed(int _003C_003E1__state)
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

			public GGGMJMEFFOC info;

			public Player impulsedPlayer;

			public PlayerMovement _003C_003E4__this;

			public int impulseID;

			internal IEnumerator<EGGPGCCKPCO> _003CRpcAckApplyRemoteImpulseToLocalPlayer_003Eg__StopLocalSimulationOfRemotePlayerImpulseCoroutine_007C0()
			{
				return null;
			}
		}

		private sealed class ACCODOFGLFL : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public PlayerMovement _003C_003E4__this;

			public Vector3 sourceSurfacePosition;

			public Vector3 destinationSurfacePosition;

			public float duration;

			public Vector3 destinationForward;

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
			public ACCODOFGLFL(int _003C_003E1__state)
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

		private sealed class KCOFNHBDFFH
		{
			private sealed class _003C_003CWaitUntilSeatedAndMoveToSeatAnchor_003Eg__WaitUntilSeated_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public KCOFNHBDFFH _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CWaitUntilSeatedAndMoveToSeatAnchor_003Eg__WaitUntilSeated_007C0_003Ed(int _003C_003E1__state)
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

			public PlayerMovement _003C_003E4__this;

			public RigidbodyEx seatRigidbody;

			public Vector3 seatOffsetPositionLocal;

			public Vector3 targetForwardLocal;

			internal IEnumerator<EGGPGCCKPCO> _003CWaitUntilSeatedAndMoveToSeatAnchor_003Eg__WaitUntilSeated_007C0()
			{
				return null;
			}

			internal bool _003CWaitUntilSeatedAndMoveToSeatAnchor_003Eb__2()
			{
				return false;
			}

			internal void _003CWaitUntilSeatedAndMoveToSeatAnchor_003Eb__1()
			{
			}
		}

		private const float NIMNPHCPPOP = 0.33f;

		private const float JCFGKEAINEM = 0.033f;

		private const float MOOBEHPCLBK = 0.001089f;

		private const float ONEAPKODFDI = 0.0001f;

		private const int KAMDAPMLOJF = 100;

		[SerializeField]
		protected Player thisPlayer;

		[SerializeField]
		protected CrossPlatformPlayerLocomotionContent content;

		[SerializeField]
		private float SimulateRemoteImpulseLocallyPingMultiplier;

		private NetworkTransform[] BACDEFNBCCP;

		private Bounds PDBGLBBALOG;

		private LGMBHCIHGDM KBKJADAEFED;

		private FIHGBEHGLGB FCGOABCHKLP;

		private FIHGBEHGLGB KHNJKMOGAHA;

		private EKBFMFCBNHO GIBFBHPAGIO;

		private JIJPJEFBIFK HMKJCNLLCKO;

		private MNKHLCPAPMI BNJJALINKKA;

		private AFNCKIAIPKL OGAGGLEJLLM;

		private HOOOFBIFNOE JDFIKLJMAND;

		private JHBPOJCJFBH DECLKOFDBPL;

		private float BEDPHOLGHND;

		private FIHGBEHGLGB DDMADOEHJML;

		private FIHGBEHGLGB HIJLDKLIJMP;

		private FIHGBEHGLGB ECEFCMODMCN;

		private FIHGBEHGLGB IJGPILFFGHJ;

		private global::AFHOAHNAMGF<ObscuredFloat> EMBNMDPDJJG;

		private global::AFHOAHNAMGF<ObscuredFloat> IHBHHLODBNG;

		private global::AFHOAHNAMGF<ObscuredFloat> MHNMDDIPFPA;

		private global::AFHOAHNAMGF<ObscuredFloat> KIPODEKGLCE;

		private global::AFHOAHNAMGF<ObscuredFloat> LJLHOPOAJJO;

		private global::AFHOAHNAMGF<ObscuredFloat> ANKJDFJKONF;

		private global::AFHOAHNAMGF<bool> MAOFJEHIMPN;

		private FIHGBEHGLGB FCJDEANIOLJ;

		private FIHGBEHGLGB IABJOPMIKNH;

		private global::AFHOAHNAMGF<ObscuredFloat> LFJOCPNNPKJ;

		private global::MKJNCDLHHNA<ObscuredFloat> CNNODIJCODE;

		private float IIJGDJFAECB;

		private global::AFHOAHNAMGF<ObscuredBool> KGBPABAECGG;

		private global::AFHOAHNAMGF<ObscuredBool> GPBGHPBHFPJ;

		private global::AFHOAHNAMGF<ObscuredFloat> BHIGKLMAPJA;

		private float EFPPCDDDBNL;

		private global::AFHOAHNAMGF<ObscuredFloat> EPIMONMAPAJ;

		private FIHGBEHGLGB PAGENKOBIMO;

		private FIHGBEHGLGB PJCOPHOALHJ;

		private global::AFHOAHNAMGF<ObscuredFloat> CDNPIABLMOH;

		private FIHGBEHGLGB BPOFLIJHNGC;

		private FIHGBEHGLGB NKLEOJJMKPG;

		private FIHGBEHGLGB KIEPBNFKAFN;

		private float BBDJDHADLDN;

		private float AOOKOOMMOMA;

		private FIHGBEHGLGB NCMJKEOGFNB;

		private FIHGBEHGLGB PAPBBJMBLDG;

		private global::AFHOAHNAMGF<ObscuredFloat> CJFNFJEJJIF;

		private global::AFHOAHNAMGF<ObscuredFloat> NJFBAJINMHK;

		private global::AFHOAHNAMGF<ObscuredFloat> GGGEFPNDPDG;

		private global::AFHOAHNAMGF<ObscuredFloat> IIPPGONDBMB;

		private global::AFHOAHNAMGF<ObscuredFloat> IKNKAFBCJDC;

		private readonly global::AFHOAHNAMGF<ObscuredBool> CFBNDDIBEOL;

		private readonly global::MKJNCDLHHNA<ObscuredFloat> PPEKMADAFDA;

		private bool ECHDHOANAJO;

		private Quaternion EFKHFCAILIJ;

		private bool ADPFNAGBGCL;

		private LKGILLBEJEK DOINHIOMOGA;

		private LLLKBNMFGKO MGOJDGGLBLL;

		private global::AFHOAHNAMGF<ObscuredFloat> MKKHPIPHELD;

		private global::AFHOAHNAMGF<ObscuredFloat> LEKLGKDAKAN;

		private global::AFHOAHNAMGF<ObscuredFloat> JJLOLCLPCKK;

		private global::AFHOAHNAMGF<ObscuredFloat> PEMCBNEIGMD;

		private global::AFHOAHNAMGF<ObscuredFloat> BEOLIIBLEKD;

		private FIHGBEHGLGB JPOIMJDCFIM;

		private FIHGBEHGLGB OBOCDPDCJAM;

		private FIHGBEHGLGB IDJKIBLNIEP;

		private bool LDLELLNEAME;

		private static Collider[] CBDEMLABHCN;

		private static Collider[] GFFFLMLBBNN;

		private static Collider[] LOHHMLJDIAG;

		private FIHGBEHGLGB JHPKHEOHBAC;

		private bool AEAMLJMGAID;

		public const float MAX_PLAYER_CAPSULE_HEIGHT = 1.7f;

		public const float PLAYER_CAPSULE_RADIUS = 0.25f;

		private const float NOKDFILBMOH = 0.1f;

		private const float DDLBHNMAOKA = 3f;

		private const string HHCPLJGKJMO = "avatars_2023q1_screen_player_height_adjust";

		private const string GMACBHBHOFJ = "height_adjustment";

		private FEIKFKAICHC HKNAHLAFLPC;

		private const float GOEAHMMNFFK = 1f;

		public EEANDDJEMJC MovementUpdated;

		private const string LBNIBHBGNCG = "REMOTE_IMPULSE_INSTIGATOR";

		private const string EIBEPJBHNCH = "REMOTE_IMPULSE_RECIPIENT";

		private const float KGMAAIGBCGH = 5f;

		private const float EDHEJAHEBPP = 5f;

		private int KBPOBOLMOBP;

		private LKGILLBEJEK KDGFDNMPCOD;

		private FIHGBEHGLGB MOFKCHFJDJD;

		private const float GFIPKNNALBE = 1f;

		private const float HFNACDIALHN = 1.5f;

		private const float OKFHMJFPIBK = 0.4f;

		private const float MKLPMKFNGHA = 4f;

		private static float BNFMDLMDKAK;

		private LKGILLBEJEK MKNKPOAMBCK;

private bool MMAMFEOFHDH
{
get 		{
			return false;
		}

}

private float DCHODLEGNJD
{
get 		{
			return 0f;
		}

}

public FCANHOEFNGD OnStateTransition
{
get 		{
			return FCANHOEFNGD.None;
		}

}

public bool IsCollisionParentingEnabled
{
get 		{
			return false;
		}

}

public bool OnRotationDiscontinuity
{
get 		{
			return this.ECHDHOANAJO;
		}

}

public Quaternion RotationDiscontinuityOffset
{
get 		{
			return default;
		}

}

public bool SupportsRoomScaleMovement
{
get 		{
			return false;
		}

}

public bool SupportsRoomScaleGroundClamp
{
get 		{
			return false;
		}

}

public Vector3 SteeringVelocity
{
get 		{
			return default;
		}

}

public float NormalizedSteeringSpeed
{
get 		{
			return 0f;
		}

}

public bool MovementActionRestricted
{
get 		{
			return false;
		}

}

public bool MovementFrozen
{
get 		{
			return false;
		}

}

public bool IsSeated
{
get 		{
			return false;
		}

}

public bool IsSeatedInSittingPosture
{
get 		{
			return false;
		}

}

public bool IsWaitingToBeSeated
{
get 		{
			return false;
		}

}

public bool IsSitEnabled
{
get 		{
			return false;
		}

}

public Vector3 PlayerReferenceFrameUp
{
get 		{
			return default;
		}

}

public Vector3 PlayerReferenceFrameForward
{
get 		{
			return default;
		}

}

public Quaternion PlayerReferenceFrameRotation
{
get 		{
			return default;
		}

}

public Vector3 PlayerReferenceFramePosition
{
get 		{
			return default;
		}

}

public Vector3 SeatAnchorWorldPosition
{
get 		{
			return default;
		}

}

public Vector3 SeatWorldForward
{
get 		{
			return default;
		}

}

public Vector3 SeatWorldUp
{
get 		{
			return default;
		}

}

public RigidbodyEx SeatRigidbody
{
get 		{
			return null;
		}

}

public Quaternion SeatOffsetRotation
{
get 		{
			return default;
		}

}

public float MaxWalkSpeed
{
get 		{
			return 0f;
		}

}

public bool IsIdle
{
get 		{
			return false;
		}

}

public bool SprintEnabled
{
get 		{
			return false;
		}

}

public bool IsSprinting
{
get 		{
			return false;
		}

}

public bool OnSprintCancel
{
get 		{
			return false;
		}

}

public float LastSprintStartTime
{
get 		{
			return 0f;
		}

}

public float LastSprintEndTime
{
get 		{
			return 0f;
		}

}

public bool IsAlwaysSprintRoleEnabled
{
get 		{
			return false;
		}

}

public bool IsSprintOnCooldown
{
get 		{
			float now = Time.time;
			return EFPPCDDDBNL > now;
		}

}

public bool IsWallRunEnabled
{
get 		{
			return false;
		}

}

public bool IsWallRunning
{
get 		{
			return false;
		}

}

public bool OnWallRunStart
{
get 		{
			return false;
		}

}

public bool OnWallRunStop
{
get 		{
			return false;
		}

}

public Vector3 WallRunWallNormal
{
get 		{
			return default;
		}

}

public Vector3 WallRunWallTangent
{
get 		{
			return default;
		}

}

public bool WallRunOnRightSide
{
get 		{
			return false;
		}

}

public bool CanGetPushed
{
get 		{
			return false;
		}

}

public bool CanRam
{
get 		{
			return false;
		}

}

public bool IsWallClimbing
{
get 		{
			return false;
		}

}

public Vector3 WallClimbNormal
{
get 		{
			return default;
		}

}

public bool IsWallClimbEnabled
{
get 		{
			return false;
		}

}

public float WallClimbMaxClimbableWallDistance
{
get 		{
			return 0f;
		}

}

public bool OnManualWallClimbJump
{
get 		{
			return false;
		}

}

public bool IsAutomaticWallClimbing
{
get 		{
			return false;
		}

}

public PELFKPIGEBK AutomaticWallClimbLookingAwayFromWallDirection
{
get 		{
			return PELFKPIGEBK.NONE;
		}

}

public Vector3 AutomaticWallClimbJumpDirection
{
get 		{
			return default;
		}

}

public Vector3 AutomaticWallClimbWallNormal
{
get 		{
			return default;
		}

}

public bool OnAutomaticWallClimbJump
{
get 		{
			return false;
		}

}

public bool IsSlideEnabled
{
get 		{
			return false;
		}

}

public bool IsSliding
{
get 		{
			return false;
		}

}

public bool OnSlideStart
{
get 		{
			return false;
		}

}

public bool OnSlideJump
{
get 		{
			return false;
		}

}

public float SlideNormalizedSpeed
{
get 		{
			return 0f;
		}

}

public bool OnLand
{
get 		{
			return false;
		}

}

public bool IsJumpEnabled
{
get 		{
			return false;
		}

}

public bool IsJumpCutoffEnabled
{
get 		{
			return false;
		}

}

public bool OnJump
{
get 		{
			return false;
		}

}

public bool OnPush
{
get 		{
			return false;
		}

}

public Player PushedPlayer
{
get 		{
			return null;
		}

}

public Vector3 PushVelocity
{
get 		{
			return default;
		}

}

public bool OnGetUpFailed
{
get 		{
			return false;
		}

}

public float CrouchNormalizedHeight
{
get 		{
			return 0f;
		}

}

public float SlideNormalizedHeight
{
get 		{
			return 0f;
		}

}

public float ProneNormalizedHeight
{
get 		{
			return 0f;
		}

}

public bool IsShortenEnabled
{
get 		{
			return false;
		}

}

public bool IsAutoShortenEnabled
{
get 		{
			return false;
		}

}

public bool IsShortenSpeedMultiplierEnabled
{
get 		{
			return false;
		}

}

public bool IsCrouching
{
get 		{
			return false;
		}

}

public bool IsProne
{
get 		{
			return false;
		}

}

public Vector3 ProneNormal
{
get 		{
			return default;
		}

}

public bool IsFalling
{
get 		{
			return false;
		}

}

public bool IsLanding
{
get 		{
			return false;
		}

}

public bool IsGrounded
{
get 		{
			return false;
		}

}

public Vector3 PhysicsVelocity
{
get 		{
			return default;
		}

}

public bool OnImpulse
{
get 		{
			return false;
		}

}

public bool IsClamberEnabled
{
get 		{
			return false;
		}

}

public bool IsClambering
{
get 		{
			return false;
		}

}

public bool OnClamberStart
{
get 		{
			return false;
		}

}

public float ClamberTimeRemaining
{
get 		{
			return 0f;
		}

}

public JHIKPIHAJLC ClamberLedgeType
{
get 		{
			return JHIKPIHAJLC.NONE;
		}

}

public CIILFFLGMCL ClamberLedgeHeightType
{
get 		{
			return CIILFFLGMCL.VERY_SHORT;
		}

}

public Vector3 ClamberWallNormal
{
get 		{
			return default;
		}

}

public bool IsFlyingEnabled
{
get 		{
			return false;
		}

}

public bool IsFlying
{
get 		{
			return false;
		}

}

public bool CanStartSelfScaleFlying
{
get 		{
			return false;
		}

}

public bool IsTeleporting
{
get 		{
			return false;
		}

}

public bool OnTeleportStart
{
get 		{
			return false;
		}

}

public bool OnTeleportEnd
{
get 		{
			return false;
		}

}

public Vector3 TeleportStartPosition
{
get 		{
			return default;
		}

}

public Vector3 TeleportEndPosition
{
get 		{
			return default;
		}

}

public float TeleportStartTime
{
get 		{
			return 0f;
		}

}

public float TeleportEndTime
{
get 		{
			return 0f;
		}

}

public float TeleportCooldownValue
{
get 		{
			return 0f;
		}

}

public float MaxTeleportHorizontalDistance
{
get 		{
			return 0f;
		}

}

public float MaxTeleportDropDistance
{
get 		{
			return 0f;
		}

}

public float MaxTeleportHorizontalSurfaceAngle
{
get 		{
			return 0f;
		}

}

public bool IsRoomScaleCollisionDisplacementBeingApplied
{
get 		{
			return this.LDLELLNEAME;
		}

}

public bool RoomScaleCollisionDisplacementEnabled
{
get 		{
			return false;
		}

}

public bool IsRoomScaleConfinementDisplacementBeingApplied
{
get 		{
			return this.AEAMLJMGAID;
		}

}

public bool RoomScaleConfinementEnabled
{
get 		{
			return false;
		}

}

private bool HGDLJKGLIKB
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void OnDrawGizmos()
		{
		}

		public void AddCollisionParentingRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveCollisionParentingRestriction(object IALNODEHBNN)
		{
		}

		public void AddStationaryRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveStationaryRestriction(object IALNODEHBNN)
		{
		}

		public void RotateTo(Quaternion HEGBBJCMANH)
		{
		}

		public Vector3 RotateToAroundPivot(Quaternion HEGBBJCMANH, Vector3 FLAMDDLFAMD)
		{
			return default;
		}

		public void AddRoomScaleMovementRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveRoomScaleMovementRestriction(object IALNODEHBNN)
		{
		}

		public void AddRoomScaleGroundClampRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveRoomScaleGroundClampRestriction(object IALNODEHBNN)
		{
		}

		private Vector3 GDBFANKLAPN(Vector3 BBBMGHNBAEH)
		{
			return default;
		}

		private Vector3 AMPPFAAHLHH(LAOELDLIJOM DELKEOLPGPB, Vector3 ABFMHNNILAA, float OKBAJEAPIHG)
		{
			return default;
		}

		public void AuthorityUpdateMovement(float GGEPGCNHMDB, float OKBAJEAPIHG)
		{
		}

		public void ImpulseRemotePlayer(Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE, bool EEEPJCJGLHI)
		{
		}

		private void CEJDJAHGHAG(Vector3 OIEPDFJCEHE, bool HLCDKPAFMNE)
		{
		}

		[PBOMGCLBFHF]
		private void RpcApplyRemoteImpulseToLocalPlayer(Player CKFPIJFIGEP, Vector3 PMIAPGFMGKP, Vector3 OIEPDFJCEHE, int KBOMPFMMNNE, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAckApplyRemoteImpulseToLocalPlayer(Player BPJAHCGNPKP, int KBOMPFMMNNE, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		private void PEBIHKHDFMB(Vector3 PMIAPGFMGKP, ref Vector3 OIEPDFJCEHE, ref HOOOFBIFNOE CPLDCIPPHON, float HOHFHDNPBAI, out Vector3 HHADIFKGFOA)
		{
			HHADIFKGFOA = default;
		}

		public bool TryGetLatestCapsuleFootPosition(out Vector3 DALBMBNJFAB)
		{
			DALBMBNJFAB = default;
			return false;
		}

		public bool TryGetGroundContactNormal(out Vector3 LLOBNBEGGND)
		{
			LLOBNBEGGND = default;
			return false;
		}

		public void RequestSteering(Vector3 OBGGGCBLPEO, float GJBOMMFFMAJ, Vector3 OMMJFMECNJJ, bool JDJNIBJJNJC = false)
		{
			BNJJALINKKA.JOGHPHAOFAI = OBGGGCBLPEO;
			BNJJALINKKA.JMGPBJJDOGP = GJBOMMFFMAJ;
			BNJJALINKKA.JKLIPLNFCJM = OMMJFMECNJJ;
			BNJJALINKKA.LMJNAEILMPN = JDJNIBJJNJC;
		}

		public void RequestAdditionalArbitraryVelocity(Vector3 JBFIOKLDODK)
		{
			Vector3 velocity = BNJJALINKKA.IMELCMKKJNO;
			velocity.x = JBFIOKLDODK.x + velocity.x;
			velocity.y = velocity.y + JBFIOKLDODK.y;
			velocity.z = velocity.z + JBFIOKLDODK.z;
			BNJJALINKKA.IMELCMKKJNO = velocity;
		}

		public void RequestMoveTo(Vector3 KPBODMPJLCH, Vector3 BPKEANIGKON, bool AFBPPDHHDMI = false)
		{
			BNJJALINKKA.OMPDMGDFCAN = true;
			BNJJALINKKA.AFBPPDHHDMI = AFBPPDHHDMI;
			BNJJALINKKA.OLBMMBNKOIK = KPBODMPJLCH;
			BNJJALINKKA.LGBJMCGOOOG = BPKEANIGKON;
		}

		public void RequestMoveTrackingSpaceTo(Vector3 INLGLHIPOMC, Vector3 BPKEANIGKON)
		{
		}

		public void AddMovementActionRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveMovementActionRestriction(object IALNODEHBNN)
		{
		}

		public void AddFreezeMovement(object IALNODEHBNN)
		{
		}

		public void RemoveFreezeMovement(object IALNODEHBNN)
		{
		}

		public void AddSitRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveSitRestriction(object IALNODEHBNN)
		{
		}

		private static KCIBJJDCPBO PHMIKIAEHHJ(SeatManagement HGHEJNOMIJN)
		{
			return default;
		}

		public void RequestSitStart(SeatManagement HGHEJNOMIJN)
		{
		}

		public void RequestSitStop(Vector3 AMFIGFLDJNJ)
		{
		}

		public void RequestSitStopInPlace()
		{
		}

		public void AddMaxWalkSpeed(float MJJDNDIGKOE, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveMaxWalkSpeed(object IALNODEHBNN)
		{
		}

		public void AddWalkMaxSpeedMultiplier(float KFLDOGAMHCK, object IALNODEHBNN)
		{
		}

		public void RemoveWalkMaxSpeedMultiplier(object IALNODEHBNN)
		{
		}

		public void AddSprintEnabled(bool BFDBCMGIOBG, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveSprintEnabled(object IALNODEHBNN)
		{
		}

		public void AddAlwaysSprintRoleEnabled(bool BFDBCMGIOBG, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveAlwaysSprintRoleEnabled(object IALNODEHBNN)
		{
		}

		public void AddSprintMaxSpeedWalkSpeedMultiplier(float FOAOHJAPMHG, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveSprintMaxSpeedWalkSpeedMultiplier(object IALNODEHBNN)
		{
		}

		public void RequestSprintStart()
		{
		}

		public void RequestSprintStop()
		{
			BNJJALINKKA.NCHLFFPEDIA = true;
		}

		public void RequestSprintStop(float KGGEABLICDO)
		{
			BNJJALINKKA.NCHLFFPEDIA = true;
			float cooldownUntil = Time.time + KGGEABLICDO;
			EFPPCDDDBNL = Mathf.Max(EFPPCDDDBNL, cooldownUntil);
		}

		public void AddWallRunRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveWallRunRestriction(object IALNODEHBNN)
		{
		}

		public void RequestWallRunStart(bool BPCLMFNFNCN, Vector3 DBGAPCBPBFA)
		{
		}

		public void AddWallRunDuration(float FGBPJMKCMAO, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveWallRunDuration(object IALNODEHBNN)
		{
		}

		public void AddWallRunDropRateParameter(float EFGFDNGALLN, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveWallRunDropRateParameter(object IALNODEHBNN)
		{
		}

		public void AddWallRunStartSpeedBoost(float FNBCPOOPOJO, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveWallRunStartSpeedBoost(object IALNODEHBNN)
		{
		}

		public void AddWallRunMaxJumpHeight(float JGAACOEKKCJ, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveWallRunMaxJumpHeight(object IALNODEHBNN)
		{
		}

		public void AddWallRunJumpDirectionParameter(float GKBMPIFPPMI, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveWallRunJumpDirectionParameter(object IALNODEHBNN)
		{
		}

		public void AddWallRunJumpAirControlMultiplier(float PDLIFJBEDPD, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveWallRunJumpAirControlMultiplier(object IALNODEHBNN)
		{
		}

		public bool IsWallMarkedUpAsClimbable(Collider MACBOMEMMFB)
		{
			return false;
		}

		public void AddWallClimbRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveWallClimbRestriction(object IALNODEHBNN)
		{
		}

		public bool OnManualWallClimbHandAttach(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return false;
		}

		public bool IsManualWallClimbing(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return false;
		}

		public Vector3 GetManualWallClimbCombinedWallNormal()
		{
			return default;
		}

		public Vector3 ManualWallClimbContactPosition(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return default;
		}

		public Vector3 ManualWallClimbContactWallNormal(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return default;
		}

		public bool TryGetManualWallClimbSlideDirection(out Vector3 EMIBKEEBOAE)
		{
			EMIBKEEBOAE = default;
			return false;
		}

		public void RequestManualWallClimbStart(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
		}

		public void RequestManualWallClimbStop(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, Vector3 LGJCOFNEBOA)
		{
		}

		public void RequestManualWallClimbVelocity(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, Vector3 OIEPDFJCEHE)
		{
		}

		public void RequestManualWallClimbNearCliff(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
		}

		public void RequestManualWallClimbSurface(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, Vector3 OLLJOPPFGKK, Vector3 KNANFPGMDPO, Collider MACBOMEMMFB)
		{
		}

		public void RequestManualWallClimbLedgeDetectDirection(Vector3 HLFIBIDOLEF)
		{
		}

		public bool OnAutomaticWallClimbHandAttach(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return false;
		}

		public void RequestAutomaticWallClimbStart(Vector3 DBGAPCBPBFA, Vector3 OLLJOPPFGKK, Collider MACBOMEMMFB)
		{
		}

		public void RequestAutomaticWallClimbGazeDirection(Vector3 DBGAPCBPBFA)
		{
		}

		public void RequestAutomaticWallClimbStop()
		{
		}

		public void RequestAutomaticWallClimbHandAttachPosition(PlayerHand.ICBKGDOJNDN BNNHCJJILFB, Vector3 KLCDCMHPFFF)
		{
		}

		public Vector3 GetAutomaticWallClimbHandAttachPosition(PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
			return default;
		}

		public void AddSlideRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveSlideRestriction(object IALNODEHBNN)
		{
		}

		public void AddSlideGravityAccelerationRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveSlideGravityAccelerationRestriction(object IALNODEHBNN)
		{
		}

		public void AddSlideMaxSpeedSprintSpeedMultiplier(float DIKPKNOFNFM, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveSlideMaxSpeedSprintSpeedMultiplier(object IALNODEHBNN)
		{
		}

		public void AddSlideMinimumDuration(float FHBHGDHDGEF, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveSlideMinimumDuration(object IALNODEHBNN)
		{
		}

		public void AddSlideSteeringParameter(float LCNNJAPPIIM, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveSlideSteeringParameter(object IALNODEHBNN)
		{
		}

		public void AddSlideStartSpeedBoost(float CGNNHPNEKLF, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveSlideStartSpeedBoost(object IALNODEHBNN)
		{
		}

		public void AddSlideAirControlMultiplier(float GADOCOOKIID, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveSlideAirControlMultiplier(object IALNODEHBNN)
		{
		}

		public void RequestSlideStart()
		{
		}

		public void RequestSlideStop()
		{
		}

		public void AddJumpRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveJumpRestriction(object IALNODEHBNN)
		{
		}

		public void AddJumpCutoffRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveJumpCutoffRestriction(object IALNODEHBNN)
		{
		}

		public void AddMaxJumpHeight(float HMKBMBOECPO, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveMaxJumpHeight(object IALNODEHBNN)
		{
		}

		public void RequestJump()
		{
			if (!this.PAGENKOBIMO.OGFHDNBGHMH)
			{
				this.BNJJALINKKA.MOKKHMFJIEJ = true;
			}
		}

		public void RequestJumpCutoff()
		{
		}

		public void RequestPush(Player PPGBJFMEBME, Vector3 EGNKMIFIIDN)
		{
		}

		public void AddCanGetPushed(bool MDPBNDAEFHH, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveCanGetPushed(object IALNODEHBNN)
		{
		}

		public void SetCanRam(bool MDPBNDAEFHH, object IALNODEHBNN)
		{
		}

		public void SetPlayerNormalizedHeight(float BKKPAOOFKDC)
		{
			this.BBDJDHADLDN = BKKPAOOFKDC;
		}

		public float GetNormalizedHeight()
		{
			return this.BBDJDHADLDN;
		}

		public float GetCurrentHeight()
		{
			return 0f;
		}

		public float GetHeightOffset()
		{
			return 0f;
		}

		public void AddShortenRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveShortenRestriction(object IALNODEHBNN)
		{
		}

		public void AddAutoShortenRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveAutoShortenRestriction(object IALNODEHBNN)
		{
		}

		public void AddShortenSpeedMultiplierRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveShortenSpeedMultiplierRestriction(object IALNODEHBNN)
		{
		}

		public void RequestCrouchStart()
		{
		}

		public void RequestCrouchStop()
		{
		}

		public void RequestProneStart()
		{
		}

		public void RequestProneStop()
		{
		}

		public void AddAirControlPercentage(float LEPKNICDCGA, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveAirControlPercentage(object IALNODEHBNN)
		{
		}

		public void RequestImpulseReflective(Vector3 GDBGENEPKJJ, float DPIEOJGBCAN, float AENFJKDNHDN, float MJJDNDIGKOE, float OLPIHDEILNJ, bool DDLDEAEEDEH = false)
		{
		}

		public void RequestImpulseReflective(Vector3 GDBGENEPKJJ, float DPIEOJGBCAN, float AENFJKDNHDN, float MJJDNDIGKOE, bool DDLDEAEEDEH = false)
		{
		}

		public void RequestImpulseReflective(Vector3 GDBGENEPKJJ, float DPIEOJGBCAN, float AENFJKDNHDN, bool DDLDEAEEDEH = false)
		{
		}

		public void RequestImpulseOverride(Vector3 GDBGENEPKJJ, float BGDNNHOLJIH, float OLPIHDEILNJ, bool DDLDEAEEDEH = false)
		{
		}

		public void RequestImpulseOverride(Vector3 GDBGENEPKJJ, float BGDNNHOLJIH, bool DDLDEAEEDEH = false)
		{
		}

		public void RequestImpulseAdditive(Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE, float OLPIHDEILNJ, bool DDLDEAEEDEH = false)
		{
		}

		public void RequestImpulseAdditive(Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE, bool DDLDEAEEDEH = false)
		{
		}

		public void RequestImpulseAdditive(Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, bool DDLDEAEEDEH = false)
		{
		}

		public void AddClamberRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveClamberRestriction(object IALNODEHBNN)
		{
		}

		public void RequestClamber(Vector3 DBGAPCBPBFA)
		{
		}

		public void AddFlyEnabled(bool BFDBCMGIOBG, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveFlyEnabled(object IALNODEHBNN)
		{
		}

		public void AddSelfScaleLocomotionScale(float COHBNIGJJKO, object IALNODEHBNN)
		{
		}

		public void RemoveSelfScaleLocomotionScale(object IALNODEHBNN)
		{
		}

		public void RequestFlyStart()
		{
		}

		public void RequestFlyStop()
		{
		}

		public void AddTeleportCooldown(float LMDIGHGEBPN, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveTeleportCooldown(object IALNODEHBNN)
		{
		}

		public void AddTeleportMaxHorizontalDistance(float DJOFHCKIOGH, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveTeleportMaxHorizontalDistance(object IALNODEHBNN)
		{
		}

		public void AddTeleportMaxHorizontalDistanceScalar(float MHBMLFDAMGB, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveTeleportMaxHorizontalDistanceScalar(object IALNODEHBNN)
		{
		}

		public void AddTeleportMaxDropHeight(float BCOLJLKONFL, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveTeleportMaxDropHeight(object IALNODEHBNN)
		{
		}

		public void AddTeleportMaxHorizontalSurfaceAngle(float BGILNHOFCGL, object IALNODEHBNN, int LAGADKBKLAD)
		{
		}

		public void RemoveTeleportMaxHorizontalSurfaceAngle(object IALNODEHBNN)
		{
		}

		public void RequestTeleport(Vector3 LOCBBMCCODM, RigidbodyEx CIDCLPKMDLK = null)
		{
		}

		public void RequestTeleport(Vector3 LOCBBMCCODM, float FGBPJMKCMAO, RigidbodyEx CIDCLPKMDLK = null)
		{
		}

		public void TeleportTo(Vector3 LOCBBMCCODM, Vector3 IFDOEDPCCPM, RigidbodyEx CIDCLPKMDLK = null)
		{
		}

		public void AddRoomScaleCollisionDisplacementRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveRoomScaleCollisionDisplacementRestriction(object IALNODEHBNN)
		{
		}

		public void AddRoomScaleConfinementEnabled(object IALNODEHBNN)
		{
		}

		public void RemoveRoomScaleConfinementEnabled(object IALNODEHBNN)
		{
		}

		private void JKPCPNPBMIJ(in FMMHKNJODAC CJNFDKOBOKG, ref MNKHLCPAPMI GDKJDDCKGLO)
		{
		}

		private HKJLAFBFCKJ LDMCLBCHLGC(in HOOOFBIFNOE CPLDCIPPHON)
		{
			return default;
		}

		private bool KOEBBAHPFNL(in FMMHKNJODAC CJNFDKOBOKG, in HOOOFBIFNOE CPLDCIPPHON, JIJPJEFBIFK DHCNABPKCJI, bool OJDIAHJFJMG, bool ABPFBKHPICN, out LAOELDLIJOM DELKEOLPGPB, out Vector3 FNPDMHOAJJF)
		{
			DELKEOLPGPB = default;
			FNPDMHOAJJF = default;
			return false;
		}

		public static LAOELDLIJOM GetCapsule(in FMMHKNJODAC CJNFDKOBOKG, Vector3 IPKGKMFPIDL, float BKKPAOOFKDC, Vector3 FHKGPLLJFNJ)
		{
			return default;
		}

		public static float GetCapsuleNormalizedHeight(in FMMHKNJODAC CJNFDKOBOKG, LAOELDLIJOM JMABNFLOAPM)
		{
			return 0f;
		}

		public static float GetCapsuleNormalizedHeightForGap(in FMMHKNJODAC CJNFDKOBOKG, float GJCKBBAPFEH)
		{
			return 0f;
		}

		private FMMHKNJODAC JIJDOHNGAJK()
		{
			return default;
		}

		private void MEEIFICEHCF(bool EMCKHIEDFHK, in AFNCKIAIPKL MHNFECJOOHH, ref FMMHKNJODAC CJNFDKOBOKG)
		{
		}

		private void OGODJCECNHM(float OKBAJEAPIHG, ref RigidbodyEx HHFDFFDPCGO, ref AFNCKIAIPKL MHNFECJOOHH, out Vector3 MEEGGAFLDPD, out Vector3 NOCKBAFLIIN, out Vector3 HODCALPEEAE)
		{
			MEEGGAFLDPD = default;
			NOCKBAFLIIN = default;
			HODCALPEEAE = default;
		}

		private void NBBPBMALKHC(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, Vector3 MCBCBMFBKCA, Vector3 MEBJBANMPLK, bool FDAABPHBBHJ)
		{
		}

		private void DLOFIICHDKI(Transform HNECJLNIOCG, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, Vector3 LGOGCCAJHAG, Vector3 NMCANIJEPAA, bool FDAABPHBBHJ)
		{
		}

		private Vector3 AIEEDAKNLHC(Vector3 GHBLBGFLEBE, in HOOOFBIFNOE CPLDCIPPHON)
		{
			return default;
		}

		private Vector3 JDCJJGPFEGI(Vector3 GHBLBGFLEBE, Vector3 GJOCEGMFHMC)
		{
			return default;
		}

		private float AGAKMDODENP(JHIKPIHAJLC HBBIMKHGCOK, CIILFFLGMCL AEJOLGDBIHA)
		{
			return 0f;
		}

		private void JLPHIFOAFDJ()
		{
		}

		private void KPJOPHMCHOL(HOOOFBIFNOE CPLDCIPPHON)
		{
		}

		private void DODGKEBHHDD(Collider ADMCDJKKCIA, DCACHBJGDMC.ENAKFGOOAHI JEMNNNEKOJM)
		{
		}

		private float IBGNAGAHEGO(float FFILBAPANLL)
		{
			return 0f;
		}

		private void HEFOMFONPCP(bool HPKJOJHBEBB, bool AFBPPDHHDMI, Vector3 DKEDGCLEJLA, Vector3 LNMOOCBAAIM)
		{
		}

		private IEnumerator<EGGPGCCKPCO> OLJKENPBPIO(Vector3 DBKJILAFGCE, Vector3 LOCBBMCCODM, Vector3 IFDOEDPCCPM, float FGBPJMKCMAO)
		{
			return null;
		}

		private void NABADJGJPGB()
		{
		}

		private Vector3 LLJNADGIPOC(in FMMHKNJODAC CJNFDKOBOKG, Vector3 ONCLMGDKJDF)
		{
			return default;
		}

		private bool IOCEFHLKKLF()
		{
			return false;
		}

		private void FCLPEGAIJAP()
		{
		}

		private bool DFCNGNIPAGM()
		{
			return false;
		}

		private void LNGIFHPAKHN()
		{
		}

		private bool LHOKFCOACEO(float OAGLPEPEGLJ, out Vector3 INCDEMGNJFD)
		{
			INCDEMGNJFD = default;
			return false;
		}

		private bool GMCMIJDJMEO()
		{
			return false;
		}

		private void CGKJHHIBJBH()
		{
		}

		private bool CECHNIMGMIA(Vector3 OEJHFKFAEGM, float NIKFNLHAIHC, out Vector3 INCDEMGNJFD)
		{
			INCDEMGNJFD = default;
			return false;
		}

		private void NFCLGKFEKHD(Tool LMEKFBDFCDN, Collision KDGCDLJEAMD)
		{
		}

		private void PHJLGFLICPA(RangedWeapon PLOGNHIJBNB)
		{
		}

		private void KJPPIBLGGGO(RigidbodyEx DOMBPOBHONF, Vector3 IPKFEJMMACE, Vector3 GDIHFOBEBBB)
		{
		}

		private Quaternion JBDCGNCEJCA()
		{
			return default;
		}

		private void IEHKKOCNILD(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		void KFLNCOLKJEM.OnPhotonSerializeView(ANEIIIEOCMN EDIGAFOKGOJ, GGGMJMEFFOC AKOKILEPANJ)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IEHKKOCNILD
			this.IEHKKOCNILD(EDIGAFOKGOJ, AKOKILEPANJ);
		}
	}
}
