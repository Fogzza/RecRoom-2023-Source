using UnityEngine;

public interface LMFLCFFHNOF
{

 GameObject GameObject
{
get ;
}

 Bounds Bounds
{
get ;
}

 KENMLGIKKPD Priority
{
get ;
}

 bool CanBeTargetedForInteraction
{
get ;
}

 bool CanBeTargetedWhileOccluded
{
get ;
}

 bool IgnoreTargetingDirection
{
get ;
set ;
}

 bool IsHoverHighlighted
{
get ;
}

 Collider HighlightedCollider
{
get ;
set ;
}

 bool CanBeInteracted
{
get ;
}

 bool CanVRInteractUsingHandPickupAxis
{
get ;
}

 bool ShouldPlayInteractAnimation
{
get ;
}

 bool MaintainInteractionAfterCompletionUntilInputReleased
{
get ;
}

 bool RequiresHoldToInteract
{
get ;
}

	bool OccludesTargetingForPlayer(Player EKOFNPFCLMO);

	void HoverStart(object IALNODEHBNN);

	void HoverEnd(object IALNODEHBNN);

	void RenderOutline(LMKFOACECEG? IEMMIFODLAI = null, bool CLHNEFFBGPD = true);

	bool CanBeTargetedByPlayer(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN);

	bool IsPreferredHandForInteraction(PlayerHand KOMMPCGEMAP);

	bool GetInteractionPromptString(PIHMPBGNBHB IFEOGBCJEBI, BCPOPPHNIMF HACBGNEIIIL, PlayerHand KOMMPCGEMAP, out string DKHEOGKHDKK);

	Vector3 GetInteractionPromptPosition();

	Sprite GetInteractionSprite(PIHMPBGNBHB IFEOGBCJEBI);

	PIHMPBGNBHB GetInteractionType(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, BCPOPPHNIMF HACBGNEIIIL);

	bool CanBeInteractedByTargetingHand(Player BBHMKAPPKOD, PlayerHand GHODAKHBECE);

	void Interact(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI, GNEENOANCIM.IMNMCGGINJG CDHOBCPKHPN, bool CAEGKCMDDNC);

	float GetHoldToInteractProgress();

	void StartHoldingForInteraction(Player JOHIHILPLPJ, PlayerHand KOMMPCGEMAP, PIHMPBGNBHB IFEOGBCJEBI);

	void CancelHoldingForInteraction();

	LMFLCFFHNOF GetForwardedInteractable();

	float SquareDistanceToTransform(Collider DHNNLHJMKIH, Vector3 JJFGOCBHLOH, Quaternion CADNEKFKMNC, out bool MPFJOMFHPCA);
}
