using RecRoom.Avatars.Data.Shared;
using RecRoom.Core.AI;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerEvents : MonoBehaviour
{
	public global::HHOBPMOCKMJ<bool> MicrophoneMuteEvent;

	public EEANDDJEMJC TeleportEvent;

	public global::HHOBPMOCKMJ<bool> SwipeRotateEvent;

	public global::HHOBPMOCKMJ<bool> MenuVisibleEvent;

	public global::BPEPJJDICII<bool, bool> GameOverEvent;

	public global::BPEPJJDICII<bool, float> RecRoyalePlayerFinishedEvent;

	public global::HHOBPMOCKMJ<Tool> ToolReleaseEvent;

	public global::HHOBPMOCKMJ<Tool> ToolPickupEvent;

	public global::BPEPJJDICII<Tool, bool> ToolLockedEvent;

	public global::BPEPJJDICII<Player.NBPIPAJOGLC, Tool> ToolHitEvent;

	public global::HHOBPMOCKMJ<Player.NBPIPAJOGLC> OutfitEquipEvent;

	public global::CBEFDECGNBJ<Player.NBPIPAJOGLC, Player, Player.NBPIPAJOGLC> PlayerHitEvent;

	public EEANDDJEMJC PartiedUpEvent;

	public EEANDDJEMJC PointedAtPlayerEvent;

	public EEANDDJEMJC CheeredPlayerEvent;

	public EEANDDJEMJC CheeredRoomEvent;

	public EEANDDJEMJC SubscribedToPlayerEvent;

	public global::HHOBPMOCKMJ<float> MadeBasketEvent;

	public global::BPEPJJDICII<bool, bool> UploadedPhotoEvent;

	public EEANDDJEMJC UpdatedPlayerBioEvent;

	public EEANDDJEMJC SavedOutfitSlotEvent;

	public EEANDDJEMJC SavedRoomEvent;

	public EEANDDJEMJC DailyChallengeCompletedEvent;

	public EEANDDJEMJC WeeklyChallengeCompletedEvent;

	public EEANDDJEMJC CreatedNewRoomEvent;

	public EEANDDJEMJC PurchasedClothingItemEvent;

	public EEANDDJEMJC PurchasedNonClothingItemEvent;

	public global::HHOBPMOCKMJ<bool> LocalPlayerAFKStatusChangedEvent;

	public EEANDDJEMJC DodgeballOutEvent;

	public EEANDDJEMJC PaintballHitEvent;

	public EEANDDJEMJC PaintballFlagCaptureEvent;

	public EEANDDJEMJC SoccerGoalEvent;

	public global::HHOBPMOCKMJ<int> DiscGolfCompletedHoleEvent;

	public EEANDDJEMJC PaddleballScoreEvent;

	public global::HHOBPMOCKMJ<Enemy> QuestEnemyKillEvent;

	public global::HHOBPMOCKMJ<CHILKDJABBF> QuestFriendReviveEvent;

	public global::HHOBPMOCKMJ<Enemy> ArenaBotTagEvent;

	public global::HHOBPMOCKMJ<CHILKDJABBF> ArenaHeroTagEvent;

	public global::HHOBPMOCKMJ<CHILKDJABBF> ArenaFriendReviveEvent;

	public EEANDDJEMJC BowlingStrikeEvent;

	public global::HHOBPMOCKMJ<CHILKDJABBF> RecRoyaleHeroTagEvent;

	public EEANDDJEMJC OpenedChestEvent;

	public global::BPEPJJDICII<float, float> PotionConsumedEvent;

	public EEANDDJEMJC ExitedGliderEvent;

	public EEANDDJEMJC DrankWaterEvent;

	public global::HHOBPMOCKMJ<Color> AddedToWhiteboardEvent;

	public global::HHOBPMOCKMJ<string> EquippedSkinEvent;

	public EEANDDJEMJC ThrewBasketballEvent;

	public EEANDDJEMJC ToggledOwnedClothesEvent;

	public global::HHOBPMOCKMJ<AvatarItemData> EquippedOutfitItemEvent;

	public EEANDDJEMJC LoadedOutfitEvent;

	public EEANDDJEMJC SpawnedCameraEvent;

	public global::CBEFDECGNBJ<bool, bool, bool> TookPhotoEvent;

	public global::BPEPJJDICII<bool, bool> PrintedPhotoEvent;

	public EEANDDJEMJC SpawnedFoodWithOtherPlayersEvent;

	public EEANDDJEMJC SentEmoteEvent;

	public global::HHOBPMOCKMJ<bool> SentRoomChatEvent;

	public EEANDDJEMJC SentCannedChatEvent;

	public EEANDDJEMJC UsedFrendotronEvent;

	public EEANDDJEMJC JoinedRecCenterEvent;

	public EEANDDJEMJC JoinedCustomRoomEvent;

	public EEANDDJEMJC JoinedOwnDormRoomEvent;

	public EEANDDJEMJC JoinedPublicRRORoomEvent;

	public EEANDDJEMJC ChangedProfilePictureEvent;

	public EEANDDJEMJC OpenedOwnProfileEvent;

	public EEANDDJEMJC OpenedOtherPlayersProfileEvent;

	public EEANDDJEMJC OpenedOnlineStatusModalEvent;

	public EEANDDJEMJC OpenedOtherPlayersPortfolioEvent;

	public EEANDDJEMJC FavoritedFriend;

	public EEANDDJEMJC OpenedPronounsModal;

	public EEANDDJEMJC ChangedDisplayName;

	public EEANDDJEMJC ChangedProfileDescription;

	public EEANDDJEMJC FavoriteRoomEvent;

	public void MicrophoneMuted(bool FPNALMLOHHH)
	{
	}

	public void Teleport()
	{
	}

	public void SwipeRotate(bool HGAJCDKAHHB)
	{
	}

	public void MenuVisible(bool BMGEHFPFCBJ)
	{
	}

	public void GameOver(bool KOEEMOIFPBE, bool BBNCKBDJMJP)
	{
	}

	public void RecRoyalePlayerFinished(bool KOEEMOIFPBE, float HIJDKOAMHHM)
	{
	}

	public void ToolRelease(Tool IEGMBEPJMGC)
	{
	}

	public void ToolPickup(Tool IEGMBEPJMGC)
	{
	}

	public void ToolLocked(Tool IEGMBEPJMGC, bool IMNGCLCHDDL)
	{
	}

	public void ToolHit(Player.NBPIPAJOGLC MKLOBAIKINA, Tool IEGMBEPJMGC)
	{
	}

	public void OutfitEquipped(Player.NBPIPAJOGLC MKLOBAIKINA)
	{
	}

	public void PlayerHit(Player.NBPIPAJOGLC MKLOBAIKINA, Player PLNGHFIMCDB, Player.NBPIPAJOGLC GFDCGAJJHML)
	{
	}

	public void PartiedUp()
	{
	}

	public void PointedAtPlayer()
	{
	}

	public void CheeredPlayer()
	{
	}

	public void CheeredRoom()
	{
	}

	public void SubscribedToPlayer()
	{
	}

	public void MadeBasket(float DAMOGGANOJL)
	{
	}

	public void UploadedPhoto(bool JJDIFNOOOKO, bool AEKCMELAJFD)
	{
	}

	public void UpdatedPlayerBio()
	{
	}

	public void SavedOutfitSlot()
	{
	}

	public void SavedRoom()
	{
	}

	public void DailyChallengeCompleted()
	{
	}

	public void WeeklyChallengeCompleted()
	{
	}

	public void CreatedNewRoom()
	{
	}

	public void PurchasedClothingItem()
	{
	}

	public void PurchasedNonClothingItem()
	{
	}

	public void LocalPlayerAFKStatusChanged(bool OENHKMEMABA)
	{
	}

	public void DodgeballOut()
	{
	}

	public void PaintballHit()
	{
	}

	public void PaintballFlagCapture()
	{
	}

	public void SoccerGoal()
	{
	}

	public void DiscGolfCompletedHole(int JOPOKBJLGOE)
	{
	}

	public void PaddleballScore()
	{
	}

	public void QuestEnemyKill(Enemy DPENEFKKNDN)
	{
	}

	public void QuestFriendRevive(CHILKDJABBF GDIGGLJFDPB)
	{
	}

	public void ArenaBotTag(Enemy DPENEFKKNDN)
	{
	}

	public void ArenaHeroTag(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	public void ArenaFriendRevive(CHILKDJABBF GDIGGLJFDPB)
	{
	}

	public void BowlingStrike()
	{
	}

	public void RecRoyaleHeroTag(CHILKDJABBF PLNGHFIMCDB)
	{
	}

	public void OpenedChest()
	{
	}

	public void PotionConsumed(float KBDNFBEFCAD, float COKLEIOCNGL)
	{
	}

	public void ExitedGlider()
	{
	}

	public void OnDrankWater()
	{
	}

	public void OnAddedToWhiteboard(Color HMCAFGCGFJF)
	{
	}

	public void OnEquippedSkin(string PEGANFDBJPA)
	{
	}

	public void OnThrewBasketball()
	{
	}

	public void OnToggledOwnedClothes()
	{
	}

	public void OnEquippedOutfitItem(AvatarItemData KHHGBBNODJN)
	{
	}

	public void OnLoadedOutfit()
	{
	}

	public void OnSpawnedCamera()
	{
	}

	public void OnTookPhoto(bool JJDIFNOOOKO, bool AEKCMELAJFD, bool DKGBPOLHPMF)
	{
	}

	public void OnPrintedPhoto(bool JJDIFNOOOKO, bool AEKCMELAJFD)
	{
	}

	public void OnSpawnedFoodWithOtherPlayers()
	{
	}

	public void OnSentEmote()
	{
	}

	public void OnSentRoomChat(bool NPGOHEHINJO)
	{
	}

	public void OnSentCannedChat()
	{
	}

	public void OnUsedFrendotron()
	{
	}

	public void OnJoinedRecCenter()
	{
	}

	public void OnJoinedCustomRoom()
	{
	}

	public void OnJoinedOwnDormRoom()
	{
	}

	public void OnJoinedPublicRRORoom()
	{
	}

	public void OnChangedProfilePicture()
	{
	}

	public void OnOpenedOwnProfile()
	{
	}

	public void OnOpenedOtherPlayersProfile()
	{
	}

	public void OnOpenedOnlineStatusModal()
	{
	}

	public void OnOpenedOtherPlayersPortfolio()
	{
	}

	public void OnFavoritedFriend()
	{
	}

	public void OnOpenedPronounsModal()
	{
	}

	public void OnChangedDisplayName()
	{
	}

	public void OnChangedProfileDescription()
	{
	}

	public void FavoritedRoom()
	{
	}
}
