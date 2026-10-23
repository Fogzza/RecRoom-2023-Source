using System;
using UnityEngine;

public class PlayerHandCollider : PlayerCollider
{
	private enum OHFIPBCCNKK : byte
	{
		Invalid = 0,
		Local = 1,
		Remote = 2
	}

	[SerializeField]
	private OHFIPBCCNKK activeForNetworkPlayerType;

	[SerializeField]
	private bool destroyGameObjectForWrongNetworkedPlayerType;

	private Action<PlayerHandCollider> NDPFMKBCJMH__BackingField;

public event Action<PlayerHandCollider> PlayerHandColliderOnDestroy {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	protected override void FJGPOGBCICA()
	{
	}

	protected override void OnDestroy()
	{
	}
}
