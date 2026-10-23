using System;

[Serializable]
public struct ReviveSettings
{
	public float RequiredDelay;

	public float MaxReviveHealthNormalized;

	public float MinReviveHealthNormalized;

	public float MultiplierPerReviveHealthNormalized;

	public bool PickupToolsOnRevive;

	public float ReviverInvincibilityDuration;

	public float ReviveeInvincibilityDuration;

	public float HandshakeHoldDuration;
}
