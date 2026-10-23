using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using RecRoom.Core;
using RecRoom.Tools;
using TMPro;
using UnityEngine;

public class TeleportationPortal : InteractablePortal
{
	public enum CKHJBIKHEKH
	{
		Teleport = 0,
		Respawn = 1,
		DEPRECATED_1 = 2,
		DEPRECATED_5 = 3,
		Nothing = 4,
		Room = 5,
		DEPRECATED_2 = 6,
		DEPRECATED_3 = 7,
		DEPRECATED_4 = 8,
		TeleportToRandomPoint = 9,
		Disabled = 10,
		ReloadCurrentActivityLevel = 11,
		DEPRECATED_7 = 12,
		Ladder = 13,
		MultiSelect = 14,
		RoomScene = 15,
		DEPRECATED_6 = 16,
		OfflineRoom = 17,
		MagicDoor = 18,
		RoomEvent = 19
	}

	private RoomDoorV2 GAKHLIEDABL;

	[SerializeField]
	public CKHJBIKHEKH mode;

	public Transform Target;

	[SerializeField]
	private Transform randomPointCenter;

	[SerializeField]
	private float randomPointRadius;

	[SerializeField]
	private int randomPointMaxRetryCount;

	[SerializeField]
	private bool randomizeRotation;

	public string TargetName;

	public SessionManager.PFPFLMJDKIB JoinRoomSceneInviteMode;

	public bool ForceNewInstance;

	[SerializeField]
	private string DoorID;

	[SerializeField]
	private TextMeshPro DoorNameText;

	private string EMLOBBJDFOE;

	private Regex PFEBHLABIFO;

	[SerializeField]
	private bool CanCarryTools;

	[SerializeField]
	private bool supportsInGameLocking;

	[SerializeField]
	private bool showLockedScreenSpaceMessage;

	[SerializeField]
	private string lockedScreenSpaceMessage;

	[SerializeField]
	private float lockedScreenSpaceMessageDuration;

	[SerializeField]
	private Transform activityMenuRoot;

	[HideInInspector]
	public Vector3? TargetPositionOverride;

	[HideInInspector]
	public Quaternion? TargetRotationOverride;

	private IILDCCEMGBA PFGCMJCEEMA;

	private bool KGIACECAEKA;

	private float FPHCLFBGNBJ;

	private const float HAAMIBBPICG = 20f;

	private const int KOKAFAFCJCC = 3;

	private static int GPBCEJGIECH;

	private Action<TeleportationPortal> LAFPPILCCPN__BackingField;

public RoomDoorV2 DoorV2
{
get 	{
		return null;
	}

set {
	}
}

public bool SupportsInGameLocking
{
get 	{
		return false;
	}

}

public bool IsLadder
{
get 	{
		return false;
	}

}

public override bool CanBeTargetedForInteraction
{
get 	{
		return false;
	}

}

public override bool CanBeTargetedWhileOccluded
{
get 	{
		return false;
	}

}

public bool IsCustomEventOnly
{
get 	{
		return false;
	}

}

protected override bool BLIGOAKBHLK
{
get 	{
		return false;
	}

}

public override bool CanBeInteracted
{
get 	{
		return false;
	}

}

public override Vector3 DestinationPosition
{
get 	{
		return default;
	}

}

public override Vector3 DestinationForward
{
get 	{
		return default;
	}

}

public bool SupportsLaserTeleportPreview
{
get 	{
		return false;
	}

}

public string LockedScreenSpaceMessage
{
get 	{
		return null;
	}

set {
	}
}

public override string DefaultInteractionLabel
{
get 	{
		return null;
	}

}

public event Action<TeleportationPortal> LocalPlayerUseEvent {
add {
	}
remove {
	}
}

	public override bool OccludesTargetingForPlayer(Player EKOFNPFCLMO)
	{
		return false;
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	private void PNKMIGBGBEB()
	{
	}

	public void ChangeMode(CKHJBIKHEKH KEJGPMMMJIK)
	{
	}

	public override void Use(Player EKOFNPFCLMO, bool CANNMAJLOHD = false)
	{
	}

	private void ADLPBKDCHDB(bool LNBOCMEBNEB)
	{
	}

	private void NPKPPGONGCB(Player EKOFNPFCLMO)
	{
	}

	public override Sprite GetInteractionSprite(PIHMPBGNBHB IFEOGBCJEBI)
	{
		return null;
	}

	private void OnDrawGizmosSelected()
	{
	}

	[CompilerGenerated]
	private void DFBKJEEEHMF(string NLJOHEKGNDH)
	{
	}
}
