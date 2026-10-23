using RecRoom.Audio;
using UnityEngine;

public class LockableDoor : TeleportationPortal
{
	[SerializeField]
	private RecRoomAudioClip unlockAudio;

	[SerializeField]
	private GameObject lockVisual;

	[SerializeField]
	private GameObject teleportBlockingColliders;

	private static readonly int IGDPIMLJDEM;

public GameObject TeleportBlockingColliders
{
get 	{
		return null;
	}

}

public override bool IsLocked
{
get 	{
		return false;
	}

set {
	}
}

	private void Reset()
	{
	}
}
