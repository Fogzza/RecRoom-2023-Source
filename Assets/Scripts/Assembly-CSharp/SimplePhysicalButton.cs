using UnityEngine;

public class SimplePhysicalButton : PhysicalButtonBase
{
	[SerializeField]
	private bool canPushWithTools;

	[SerializeField]
	private bool pushingToolsMustBeHeld;

	[SerializeField]
	private bool canOnlyPushLocally;

	[SerializeField]
	private bool canOnlyPushWhenPlayerExists;

	[SerializeField]
	private bool allowPressesFromMultiplePlayers;

protected override bool EFEIJCNMOPI
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
	}

	protected override void OnTriggerEnter(Collider ADMCDJKKCIA)
	{
	}
}
