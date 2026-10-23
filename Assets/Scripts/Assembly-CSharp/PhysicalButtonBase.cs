using System;
using System.Collections.Generic;
using Photon.Pun;
using RecRoom;
using RecRoom.Audio;
using UnityEngine;
using UnityEngine.Events;

public abstract class PhysicalButtonBase : MonoBehaviourPun, HOLOGEOFMOO
{
	public enum IHANOHBJBBJ
	{
		Pressed = 0,
		Transferred = 1,
		Released = 2
	}

	[Serializable]
	public class PhysicalButtonPressEvent : UnityEvent<PhysicalButtonBase, Player>
	{
	}

	[Serializable]
	public class PhysicalButtonStateEvent : UnityEvent<IHANOHBJBBJ, Player>
	{
	}

	[SerializeField]
	private MeshRenderer mainRenderer;

	[SerializeField]
	protected float instanceLimitDuration;

	[SerializeField]
	private RecRoomAudioClip onButtonPressAudio;

	private readonly Color JJINBINIHKA;

	[SerializeField]
	private bool enforceLaserMinDistance;

	[SerializeField]
	private bool enforceLaserFromFront;

	[SerializeField]
	private bool allowLaserInVR;

	[SerializeField]
	protected bool useCustomScreensAnimations;

	[SerializeField]
	protected PlayerAnimation customScreensTargetAnimation;

	[SerializeField]
	protected PlayerAnimation customScreensPushAnimation;

	private Color FBDFAABEOOM;

	private ColorButton POFJNJDJGLO;

	private bool BCOAIICNIAK;

	private bool AMNENPDPBCL;

	protected AOABBLJMPMD GJENAONGDBE;

	protected List<CHILKDJABBF> FIMHDCGMOMA;

	private List<CHILKDJABBF> INHKALNLBLM;

	[SerializeField]
	private PhysicalButtonPressEvent pressEvent;

	[SerializeField]
	private PhysicalButtonStateEvent onReleaseEvent;

	[SerializeField]
	private PhysicalButtonStateEvent onPressTransferEvent;

	protected float IOEGNIMCIJP;

public RecRoomAudioClip OnButtonPressAudio
{
get 	{
		return null;
	}

set {
	}
}

public bool UseCustomScreensAnimations
{
get 	{
		return false;
	}

}

public PlayerAnimation CustomScreensTargetAnimation
{
get 	{
		return null;
	}

}

public PlayerAnimation CustomScreensPushAnimation
{
get 	{
		return null;
	}

}

public bool EnforceLaserMinDistance
{
get 	{
		return false;
	}

}

public bool EnforceLaserFromFront
{
get 	{
		return false;
	}

}

public bool AllowLaserInVR
{
get 	{
		return false;
	}

}

public virtual bool ToolIsReady
{
get 	{
		return false;
	}

}

protected virtual bool EFEIJCNMOPI
{
get 	{
		return false;
	}

}

public virtual bool IsButtonEnabled
{
get 	{
		return false;
	}

set {
	}
}

protected virtual bool LPBFKCMAKKM
{
get 	{
		return false;
	}

set {
	}
}

public PhysicalButtonPressEvent PressEvent
{
get 	{
		return null;
	}

}

public PhysicalButtonStateEvent OnReleaseEvent
{
get 	{
		return null;
	}

}

public PhysicalButtonStateEvent OnPressTransferEvent
{
get 	{
		return null;
	}

}

protected bool MHPGFHFBEIO
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void FGEGFDAOMOE(float OKBAJEAPIHG)
	{
	}

	public void BroadcastLocalLaserPress(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void BroadcastLocalLaserRelease(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public void RenderOutline()
	{
	}

	[PBOMGCLBFHF]
	protected void RpcNonPhysicalPressButton(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	[PBOMGCLBFHF]
	protected void RpcNonPhysicalReleaseButton(CHILKDJABBF EKOFNPFCLMO)
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

	public virtual int GetPressingPlayersCount()
	{
		return 0;
	}

	private void HJGOEOHPCIC(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	private void KLFFKLNHCJM(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public bool IsButtonEnabledForLocalPlayer()
	{
		return false;
	}

	public virtual bool IsButtonEnabledForPlayer(CHILKDJABBF FBCDJHOIDJJ)
	{
		return false;
	}

	public virtual bool PlayerPushedButton(CHILKDJABBF LLAGNEBKMCA)
	{
		return false;
	}

	protected virtual void OnTriggerEnter(Collider ADMCDJKKCIA)
	{
	}

	protected virtual void OnTriggerExit(Collider HNPEBINPOBO)
	{
	}

	public virtual bool PlayerReleasedButton(CHILKDJABBF EKOFNPFCLMO)
	{
		return false;
	}

	private void NHPDJADMNEH(CHILKDJABBF FBCDJHOIDJJ)
	{
	}
}
