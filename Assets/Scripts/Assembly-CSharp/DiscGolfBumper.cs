using UnityEngine;

public class DiscGolfBumper : DiscGolfTriggerable
{
	[SerializeField]
	private float bumpForce;

	[SerializeField]
	private float bumpCooldown;

	[SerializeField]
	private bool aimAssisted;

	public Transform AimAssistTarget;

	private float GEMEGJJJOAA;

	private CollisionForwarder LFDHELHDBPE;

	protected override void Awake()
	{
	}

	private void OnTriggerEnter(Collider HNPEBINPOBO)
	{
	}
}
