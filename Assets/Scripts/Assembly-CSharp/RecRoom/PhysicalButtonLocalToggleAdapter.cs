using System;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	public class PhysicalButtonLocalToggleAdapter : MonoBehaviour, IINFEBLEDEE, HOLOGEOFMOO, PMIKDMHLHIL
	{
		[SerializeField]
		private PhysicalButtonBase button;

		[SerializeField]
		private RecRoomAudioClip toggledOnAudio;

		[SerializeField]
		private RecRoomAudioClip toggledOffAudio;

		private ChargePhysicalButton FIKNJFFODJC;

		private Action OOIOBPPCCDL__BackingField;

		private bool BMGLAGINFOL;

public bool ToggleState
{
get 		{
			return false;
		}

set {
		}
}

public PhysicalButtonBase.PhysicalButtonPressEvent PressEvent
{
get 		{
			return null;
		}

}

public PhysicalButtonBase.PhysicalButtonStateEvent OnReleaseEvent
{
get 		{
			return null;
		}

}

public PhysicalButtonBase.PhysicalButtonStateEvent OnPressTransferEvent
{
get 		{
			return null;
		}

}

public event Action ToggleStateChanged {
add {
		}
remove {
		}
}

		private void Awake()
		{
		}

		private void IBBKLPADCCC()
		{
		}

		public CHILKDJABBF GetSomePressingPlayer()
		{
			return null;
		}

		public CHILKDJABBF GetSomePressingPlayer(out Collider ADMCDJKKCIA)
		{
			ADMCDJKKCIA = null;
			return null;
		}

		public bool PlayerPushedButton(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}

		public bool PlayerReleasedButton(CHILKDJABBF EKOFNPFCLMO)
		{
			return false;
		}
	}
}
