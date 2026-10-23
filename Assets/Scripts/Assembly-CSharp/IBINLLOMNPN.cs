using RecRoom.Audio;
using RecRoom.Networking;
using UnityEngine;

public interface IBINLLOMNPN : HNGAMKHHDOD, GFLPAFBGELM
{

 EEANDDJEMJC BoardedVehicleChanged
{
get ;
}

 EEANDDJEMJC CurrentSocialModeDancePoseSetSelectedEvent
{
get ;
}

 EEANDDJEMJC DisablePersonalBubbleForFriendsChangedEvent
{
get ;
}

 EEANDDJEMJC BroadcastingStateChanged
{
get ;
}

 int PlayerIndex
{
get ;
}

 Vector3 CurrentFloorPosition
{
get ;
}

 float CurrentFloorHeightFromHead
{
get ;
}

 Vector3 CurrentHeadPosition
{
get ;
}

 Quaternion CurrentTrackingSpaceRotation
{
get ;
}

 PlayerHand.ICBKGDOJNDN FixedDominantHandType
{
get ;
set ;
}

 IOMDCIACIMF BoardedVehicle
{
get ;
set ;
}

 bool IsInVehicle
{
get ;
}

 NetworkCullingArea.NJEIMFKBBEG EditorInterestRegion
{
get ;
set ;
}

 bool IsInHighInterestRegion
{
get ;
set ;
}

 Vector3 LastLocalPlayerValidGroundPosition
{
get ;
set ;
}

 IILJLGFHLGK CurrentSocialModeDancePoseSet
{
get ;
set ;
}

 bool IsMuted
{
get ;
}

 bool IsTalking
{
get ;
}

 float AudioMaxForFrame
{
get ;
}

 ONCCFHECNKK IgnoreBuffer
{
get ;
set ;
}

 bool IsFriend
{
get ;
}

 bool DisablePersonalBubbleForFriends
{
get ;
set ;
}

 bool IsSelfScaling
{
get ;
set ;
}

 string PlayerName
{
get ;
}

 JDCIJIEOFOL NetworkedPlayer
{
get ;
}

 int PlayerAccountId
{
get ;
}

 bool IsBroadcasting
{
get ;
set ;
}

 bool HasVisibleRecRoomPlus
{
get ;
set ;
}

 HBEFBLGGFMC RecNetDeviceClass
{
get ;
}

 MJLJBHNFNAP ControllerDisplayMode
{
get ;
set ;
}

 MPKEDKHLCLJ DeveloperDisplayMode
{
get ;
set ;
}

 bool IsJunior
{
get ;
set ;
}

 bool IsInitialized
{
get ;
}

 NOMDJBMGHMJ VOIPFilter
{
get ;
set ;
}

 string RichPresence
{
get ;
}

 string LocalPlayerStatus
{
get ;
}

 bool IsVoiceChatRestricted
{
get ;
}

 bool UserIsPresent
{
get ;
set ;
}

 bool CanInteractWithTools
{
get ;
}

 bool CanInteractWithNonOwnedTools
{
get ;
}

 Vector3 LastSpawnPosition
{
get ;
}

 Quaternion LastSpawnRotation
{
get ;
}

 bool IsSpawning
{
get ;
}

 bool IsVisible
{
get ;
}

 bool DisplayAsBlocked
{
get ;
}

 bool AvatarSkeletonIsEnabled
{
get ;
set ;
}

 Vector3 TorsoForwardOverride
{
get ;
}

 float TorsoForwardOverrideWeight
{
get ;
}

 bool IsTorsoForwardOverridden
{
get ;
}

 Vector3 PelvisAnchorPosition
{
get ;
}

 float CostumeScale
{
get ;
set ;
}

 float DesiredAvatarSkeletonTrackingSpaceScale
{
get ;
}

 PlayerEvents PlayerEvents
{
get ;
}

 PlayerParty PlayerParty
{
get ;
}

 PlayerUI PlayerUI
{
get ;
}

	void ActivatePushToTalk(object IALNODEHBNN);

	void AddLocalPlayerStatus(string JJGDPHEIOJB, object IALNODEHBNN, int LAGADKBKLAD);

	void AddNonOwnedToolInteractionRestriction(object IALNODEHBNN);

	void AddRichPresence(string JDMKLBCHDHJ, object IALNODEHBNN, int LAGADKBKLAD);

	void AddToolInteractionRestriction(object IALNODEHBNN);

	void AddVoiceChatRestriction(object IALNODEHBNN);

	void AddVoiceHighPassFilterEnabled(object IALNODEHBNN);

	void AddVoiceReverbFilterEnabled(object IALNODEHBNN);

	void AddVoiceSpatialBlendMultiplier(float GDBGAEFICHD, object IALNODEHBNN);

	void AddVoiceVolumeMultiplier(float COEPFINFOAM, object IALNODEHBNN);

	void BroadcastFacialExpression(int MAFEEIEHLEI);

	global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2AddImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float JCOIPNJNGNL, float MJJDNDIGKOE);

	global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2ReflectImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 HLFIBIDOLEF, float DPIEOJGBCAN, float DMIPMFMPLAP, float MJJDNDIGKOE);

	global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2Respawn(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC, in Quaternion HEGBBJCMANH, in bool KBDPBKJKFGJ, in bool LPKBKDOMDNB);

	global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetImpulse(JEGAPHLGBJA GCBHEJANCJK, in Vector3 GDBGENEPKJJ, float BGDNNHOLJIH);

	global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2SetPosition(JEGAPHLGBJA GCBHEJANCJK, in Vector3 INLGLHIPOMC);

	global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2GoToRoom(JEGAPHLGBJA GCBHEJANCJK, in GPLMEJAFFFO FMECHJDDNAF);

	void DeactivatePushToTalk(object IALNODEHBNN);

	LKGILLBEJEK DespawnLocal(bool CDEPAJILBJA, bool LPKBKDOMDNB, CameraFade.BAIBOJEOOGB CKHHGBNHHCK = CameraFade.BAIBOJEOOGB.Misc);

	bool IsInVehicleOfType<T>() where T : class, IOMDCIACIMF;

	bool MutedBy(Player.BMHJDGKCMBJ NCJCLJGCIMF);

	bool MutedOnlyBy(Player.BMHJDGKCMBJ NCJCLJGCIMF);

	void OnFriendAdded(int OBCFBKKCBFH, ODCEOIGDCAH.AIFBEBFNDOK GLLFHCCFIGK);

	void OnMicSpamStateChange(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL);

	void OnRecRoomSceneManagerDestroyed();

	void ProcessPlayerEventNotifications();

	void RefreshRelationship();

	void ReleaseToolsFromAllEquipSlots();

	void ReleaseToolsFromBothHands();

	void RemoveLocalPlayerStatus(object IALNODEHBNN);

	void RemoveNonOwnedToolInteractionRestriction(object IALNODEHBNN);

	void RemoveRichPresence(object IALNODEHBNN);

	void RemoveToolInteractionRestriction(object IALNODEHBNN);

	void RemoveVoiceChatRestriction(object IALNODEHBNN);

	void RemoveVoiceHighPassFilterEnabled(object IALNODEHBNN);

	void RemoveVoiceReverbFilterEnabled(object IALNODEHBNN);

	void RemoveVoiceSpatialBlendMultiplier(object IALNODEHBNN);

	void RemoveVoiceVolumeMultiplier(object IALNODEHBNN);

	void SetDisplayAsBlocked(object IALNODEHBNN, bool CHEHHIMIPCJ);

	void SetHeadScale(float KBFGDHBNMLA);

	void SetLocalVoiceChatMode(DPDBLMENBLF KJIJAABOEKI);

	bool SetMuteFlag(Player.BMHJDGKCMBJ NCJCLJGCIMF, bool BFDBCMGIOBG = true);

	void SetPushToTalkActive(bool GNGKKJPOAPJ, object IALNODEHBNN);

	void SetVoiceAudioRolloff(AudioRolloff GIKIKBPOJNI);

	void SetVoiceFilter(NOMDJBMGHMJ HNGJGPJCNBJ);

	LKGILLBEJEK SpawnLocal(float HJOLODPNIPI, bool MJGDPADJBEG, Vector3 FCNGMPHKHAE, bool LPKBKDOMDNB);

	void UpdateAFKStatus(bool JMKGIJLHBKI);

	void UpdateBody();

	void UpdateVoicesICanHear();

	AMBBOEBJPNH GetUpdateLOD();
}
