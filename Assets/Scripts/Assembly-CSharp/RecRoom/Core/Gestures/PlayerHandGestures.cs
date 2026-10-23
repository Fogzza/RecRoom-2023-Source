using System;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Core.Gestures
{
	public class PlayerHandGestures : MonoBehaviourPun
	{
		public enum NAHIAFFDEIO
		{
			None = -1,
			Highfive = 0,
			Fistbump = 1,
			HandshakeStart = 2,
			HandshakeCancel = 3,
			HandshakeSuccess = 4,
			StopGestureCharging = 5,
			StopGestureCancel = 6,
			StopGestureSuccess = 7,
			CheerGestureCharging = 8,
			CheerGestureCancel = 9,
			CheerGestureSuccess = 10,
			GameReviveHandshakeStart = 11,
			GameReviveHandshakeCancel = 12,
			GameReviveHandshakeSuccess = 13
		}

		public delegate void BHEPPNNLIJP(PlayerHand KJCMNCDGCKA, PlayerHand MCGMBMMJMBM, NAHIAFFDEIO AEBIACPKIKH, Player EEOLEPDDCFN = null, Player ANDCAFFMODA = null);

		private const int HDKBPCBMGMK = 600;

		private const int HPELKMAPHCC = 128;

		private BHEPPNNLIJP BLLKDADJGFL__BackingField;

		private BHEPPNNLIJP EIABFIJIELP__BackingField;

		private Action<PlayerHand, PlayerHand> KMDIIKBAONA__BackingField;

		[SerializeField]
		private PlayerHand _hand;

		[SerializeField]
		private float handCollisionRadius;

		private float PAOHMOOHDDE;

		private PlayerHand AIHGAHFDKMM;

		private Vector3 DINAOFDAECE;

		private Collider[] DKIFDIMOLEN;

		private RaycastHit[] DAAJKMLOJNN;

		private FIHGBEHGLGB DPBJNBNPNFL;

		private HandGestureBase[] DDMPBIMNKPG;

		private int NEKPHIGBDOC;

		private NAHIAFFDEIO NMFOAOEDNLA;

		private int JIIJEIBELFP;

public PlayerHand Hand
{
get 		{
			return null;
		}

}

public int LastGestureServerTimestamp
{
get 		{
			return 0;
		}

private set {
		}
}

public NAHIAFFDEIO LastGestureType
{
get 		{
			return NAHIAFFDEIO.Highfive;
		}

private set {
		}
}

public bool ShouldSuppressHighFiveEffect
{
get 		{
			return false;
		}

}

public event BHEPPNNLIJP GestureDetected {
add {
		}
remove {
		}
}

public event BHEPPNNLIJP GestureDetectedCalledOnBothHands {
add {
		}
remove {
		}
}

public event Action<PlayerHand, PlayerHand> HandCollisionChanged {
add {
		}
remove {
		}
}

		public void SuppressHighFive()
		{
		}

		public void UnsuppressHighFive()
		{
		}

		protected override void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		public void AuthorityCancelOtherGestures(HandGestureBase KLKIMDIEOCE)
		{
		}

		public void AddRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveRestriction(object IALNODEHBNN)
		{
		}

		public bool IsGestureBlocked(HandGestureBase AEBIACPKIKH)
		{
			return false;
		}

		private void CKPFNBAKJED()
		{
		}

		private bool JFGNHJNHOEK(out PlayerHand CFJJAGEHNOJ, out NonPlayerGestureTarget KAJIFLBNNCK)
		{
			CFJJAGEHNOJ = null;
			KAJIFLBNNCK = null;
			return false;
		}

		private bool EMEHANDPKOA(out PlayerHand CFJJAGEHNOJ, out NonPlayerGestureTarget KAJIFLBNNCK)
		{
			CFJJAGEHNOJ = null;
			KAJIFLBNNCK = null;
			return false;
		}

		private void LCHNBOGMFPO(PlayerHand MCGMBMMJMBM)
		{
		}

		private void KEIPOBBOEPM(NonPlayerGestureTarget KAJIFLBNNCK)
		{
		}

		public void AuthorityTriggerGesture(NAHIAFFDEIO AEBIACPKIKH, PlayerHand MCGMBMMJMBM, bool MAOKBDCHHGG = true)
		{
		}

		[PBOMGCLBFHF]
		private void RpcHandGestureDetected(PlayerHand MCGMBMMJMBM, NAHIAFFDEIO AEBIACPKIKH, int ABJNIFABPMO, bool MAOKBDCHHGG)
		{
		}

		public void HandleLocalHandGestureDetected(PlayerHand MCGMBMMJMBM, NAHIAFFDEIO AEBIACPKIKH, int ABJNIFABPMO, Player PLNGHFIMCDB, bool MAOKBDCHHGG)
		{
		}
	}
}
