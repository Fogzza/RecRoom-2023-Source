using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Activities.Bowling
{
	public class BowlingLane : MonoBehaviourPun
	{
		public delegate void IGAAAEPJMPE(int GDMBHPLDBAP, int DIFMOMFKPOF);

		public delegate void HJDOMACBJNC();

		public delegate void DMFHDEGCHBN();

		public delegate bool GOHJCGKHNCH(BowlingBall LMHBMCCBGOI);

		private enum EECCACKIFJP
		{
			INVALID = 0,
			PREPARING_ROUND = 1,
			BOWLING_FRAME = 2,
			LIFT_PINS = 3
		}

		private sealed class CKDJMNKIJGC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public BowlingLane _003C_003E4__this;

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
			public CKDJMNKIJGC(int _003C_003E1__state)
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

		private const int HGKIMMPEAPL = 10;

		private const int FLONMAANGKD = 10;

		private const float KLHHMNJCJJK = 0.2f;

		private const float DCCHHCFPKID = 1f;

		private const float BNBNNBCLLJN = 2f;

		private const float NMCEEIJHMCK = 7f;

		[SerializeField]
		private BowlingPin pinPrefab;

		[SerializeField]
		private Transform firstPinLocation;

		[SerializeField]
		private Transform fowlLine;

		[SerializeField]
		private RecRoomAudioClip fowlBuzzer;

		[SerializeField]
		private Transform[] ballReturnSpawnLocations;

		[SerializeField]
		private Renderer bowlLight1;

		[SerializeField]
		private Renderer bowlLight2;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RecRoomAudioClip pinSetterSound;

		[SerializeField]
		private Collider triggerVolume;

		[SerializeField]
		private RecRoomAudioClip strikeSFX;

		private int HJEEPFFCAGP;

		private int LEMCGMHMALL;

		private float IDNCGOPEHGC;

		private float OHIGPAHGFOO;

		private float ENIBACHMOAN;

		private IGAAAEPJMPE ENCHPMBDPIB__BackingField;

		private HJDOMACBJNC NBHLELLIJBP__BackingField;

		private DMFHDEGCHBN LMPBEKPJBIL__BackingField;

		public GOHJCGKHNCH CustomValidateBall;

		private List<BowlingPin> PFIKAALNIHF;

		private HONEDBECDOK LPDINEGBLDK;

		private JOJOABLFOBA BGBIFFLGANM;

		private BowlingBall NONPECFNHON;

		private BowlingBall NPAPDGOFEFK;

		private global::MOBDJNEDDKC<int> IMJELONBHMO;

		private global::MOBDJNEDDKC<bool> GCNLLMDMFDK;

		private global::MOBDJNEDDKC<bool> DOCNLHFLKLP;

		private global::MDAHOKBAGPC<int, int, int> EJCKEMGFEFL;

private BowlingBall FDINEDMGKCB
{
get 		{
			return null;
		}

set {
		}
}

public bool TenthFrame
{
get 		{
			return false;
		}

set {
		}
}

public bool Bumpers
{
get 		{
			return false;
		}

set {
		}
}

public int FirstBowlPoints
{
get 		{
			return 0;
		}

set {
		}
}

public int SecondBowlPoints
{
get 		{
			return 0;
		}

set {
		}
}

public int ThirdBowlPoints
{
get 		{
			return 0;
		}

set {
		}
}

private int IKHPAODFLPH
{
get 		{
			return 0;
		}

}

private bool ADLIENKHDGN
{
get 		{
			return false;
		}

}

public event IGAAAEPJMPE BallBowledEvent {
add {
		}
remove {
		}
}

public event HJDOMACBJNC TurnFinishedEvent {
add {
		}
remove {
		}
}

public event DMFHDEGCHBN FramePointsChangedEvent {
add {
		}
remove {
		}
}

		protected override void Awake()
		{
		}

		protected void Start()
		{
		}

		protected void Update()
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		public void ResetPoints()
		{
		}

		private void HBDIDMNJFCP()
		{
		}

		private void FNLKOAPKHKE()
		{
		}

		private void DEDKCPFDLIG()
		{
		}

		public void PlayPinSetterSound()
		{
		}

		public void MasterStartNewGame()
		{
		}

		public IEnumerator<EGGPGCCKPCO> StartNewGameRoutine()
		{
			return null;
		}

		private void OnTriggerEnter(Collider HNPEBINPOBO)
		{
		}

		private void EGPOFAOIOBP(Collider HNPEBINPOBO)
		{
		}

		[PBOMGCLBFHF]
		private void RpcPlayFowlBuzzer()
		{
		}

		public void ForcePrepareNewRound()
		{
		}

		private void KKDLFOHPMHI(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void LMKDJCGPAHB()
		{
		}

		private void JPAABJGJBBK(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void DIIBGHBOIFL()
		{
		}

		private void FCLNBCBPNLB(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void HGGNBECGCPM(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		private void PFJMPNJOPBL()
		{
		}

		private void DAMHJKLACHJ(ushort PLPOPJIKGFK, ushort BMOCIFECECK)
		{
		}

		[PBOMGCLBFHF]
		private void RpcPlayStrikeSound()
		{
		}

		[PBOMGCLBFHF]
		private void RpcResetPins()
		{
		}

		public void OnPinCollision(Collision KDGCDLJEAMD, BowlingPin JPDKNCJPJHL, BowlingPin JMKMJEBIJEK)
		{
		}

		public void SetStandingPinsKinematic(int KEBFOCNPJLL)
		{
		}

		private int MELDBDAIPNA()
		{
			return 0;
		}

		public void DisableDownedPins()
		{
		}

		private void HGDLEPGIKLK()
		{
		}

		private void PGLHBOBDBEM()
		{
		}

		private void BHJJAKDKIDL(CHILKDJABBF CMNODMLEKGJ)
		{
		}
	}
}
