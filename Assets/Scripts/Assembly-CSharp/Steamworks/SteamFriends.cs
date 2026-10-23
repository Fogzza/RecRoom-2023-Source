namespace Steamworks
{
	public static class SteamFriends
	{
		public static string GetPersonaName()
		{
			return null;
		}

		public static SteamAPICall_t SetPersonaName(string pchPersonaName)
		{
			return default;
		}

		public static EPersonaState GetPersonaState()
		{
			return EPersonaState.k_EPersonaStateOffline;
		}

		public static int GetFriendCount(EFriendFlags iFriendFlags)
		{
			return 0;
		}

		public static CSteamID GetFriendByIndex(int iFriend, EFriendFlags iFriendFlags)
		{
			return default;
		}

		public static EFriendRelationship GetFriendRelationship(CSteamID steamIDFriend)
		{
			return EFriendRelationship.k_EFriendRelationshipNone;
		}

		public static EPersonaState GetFriendPersonaState(CSteamID steamIDFriend)
		{
			return EPersonaState.k_EPersonaStateOffline;
		}

		public static string GetFriendPersonaName(CSteamID steamIDFriend)
		{
			return null;
		}

		public static bool GetFriendGamePlayed(CSteamID steamIDFriend, out FriendGameInfo_t pFriendGameInfo)
		{
			pFriendGameInfo = default;
			return false;
		}

		public static string GetFriendPersonaNameHistory(CSteamID steamIDFriend, int iPersonaName)
		{
			return null;
		}

		public static int GetFriendSteamLevel(CSteamID steamIDFriend)
		{
			return 0;
		}

		public static string GetPlayerNickname(CSteamID steamIDPlayer)
		{
			return null;
		}

		public static int GetFriendsGroupCount()
		{
			return 0;
		}

		public static FriendsGroupID_t GetFriendsGroupIDByIndex(int iFG)
		{
			return default;
		}

		public static string GetFriendsGroupName(FriendsGroupID_t friendsGroupID)
		{
			return null;
		}

		public static int GetFriendsGroupMembersCount(FriendsGroupID_t friendsGroupID)
		{
			return 0;
		}

		public static void GetFriendsGroupMembersList(FriendsGroupID_t friendsGroupID, CSteamID[] pOutSteamIDMembers, int nMembersCount)
		{
		}

		public static bool HasFriend(CSteamID steamIDFriend, EFriendFlags iFriendFlags)
		{
			return false;
		}

		public static int GetClanCount()
		{
			return 0;
		}

		public static CSteamID GetClanByIndex(int iClan)
		{
			return default;
		}

		public static string GetClanName(CSteamID steamIDClan)
		{
			return null;
		}

		public static string GetClanTag(CSteamID steamIDClan)
		{
			return null;
		}

		public static bool GetClanActivityCounts(CSteamID steamIDClan, out int pnOnline, out int pnInGame, out int pnChatting)
		{
			pnOnline = default;
			pnInGame = default;
			pnChatting = default;
			return false;
		}

		public static SteamAPICall_t DownloadClanActivityCounts(CSteamID[] psteamIDClans, int cClansToRequest)
		{
			return default;
		}

		public static int GetFriendCountFromSource(CSteamID steamIDSource)
		{
			return 0;
		}

		public static CSteamID GetFriendFromSourceByIndex(CSteamID steamIDSource, int iFriend)
		{
			return default;
		}

		public static bool IsUserInSource(CSteamID steamIDUser, CSteamID steamIDSource)
		{
			return false;
		}

		public static void SetInGameVoiceSpeaking(CSteamID steamIDUser, bool bSpeaking)
		{
		}

		public static void ActivateGameOverlay(string pchDialog)
		{
		}

		public static void ActivateGameOverlayToUser(string pchDialog, CSteamID steamID)
		{
		}

		public static void ActivateGameOverlayToWebPage(string pchURL, EActivateGameOverlayToWebPageMode eMode = EActivateGameOverlayToWebPageMode.k_EActivateGameOverlayToWebPageMode_Default)
		{
		}

		public static void ActivateGameOverlayToStore(AppId_t nAppID, EOverlayToStoreFlag eFlag)
		{
		}

		public static void SetPlayedWith(CSteamID steamIDUserPlayedWith)
		{
		}

		public static void ActivateGameOverlayInviteDialog(CSteamID steamIDLobby)
		{
		}

		public static int GetSmallFriendAvatar(CSteamID steamIDFriend)
		{
			return 0;
		}

		public static int GetMediumFriendAvatar(CSteamID steamIDFriend)
		{
			return 0;
		}

		public static int GetLargeFriendAvatar(CSteamID steamIDFriend)
		{
			return 0;
		}

		public static bool RequestUserInformation(CSteamID steamIDUser, bool bRequireNameOnly)
		{
			return false;
		}

		public static SteamAPICall_t RequestClanOfficerList(CSteamID steamIDClan)
		{
			return default;
		}

		public static CSteamID GetClanOwner(CSteamID steamIDClan)
		{
			return default;
		}

		public static int GetClanOfficerCount(CSteamID steamIDClan)
		{
			return 0;
		}

		public static CSteamID GetClanOfficerByIndex(CSteamID steamIDClan, int iOfficer)
		{
			return default;
		}

		public static uint GetUserRestrictions()
		{
			return 0u;
		}

		public static bool SetRichPresence(string pchKey, string pchValue)
		{
			return false;
		}

		public static void ClearRichPresence()
		{
		}

		public static string GetFriendRichPresence(CSteamID steamIDFriend, string pchKey)
		{
			return null;
		}

		public static int GetFriendRichPresenceKeyCount(CSteamID steamIDFriend)
		{
			return 0;
		}

		public static string GetFriendRichPresenceKeyByIndex(CSteamID steamIDFriend, int iKey)
		{
			return null;
		}

		public static void RequestFriendRichPresence(CSteamID steamIDFriend)
		{
		}

		public static bool InviteUserToGame(CSteamID steamIDFriend, string pchConnectString)
		{
			return false;
		}

		public static int GetCoplayFriendCount()
		{
			return 0;
		}

		public static CSteamID GetCoplayFriend(int iCoplayFriend)
		{
			return default;
		}

		public static int GetFriendCoplayTime(CSteamID steamIDFriend)
		{
			return 0;
		}

		public static AppId_t GetFriendCoplayGame(CSteamID steamIDFriend)
		{
			return default;
		}

		public static SteamAPICall_t JoinClanChatRoom(CSteamID steamIDClan)
		{
			return default;
		}

		public static bool LeaveClanChatRoom(CSteamID steamIDClan)
		{
			return false;
		}

		public static int GetClanChatMemberCount(CSteamID steamIDClan)
		{
			return 0;
		}

		public static CSteamID GetChatMemberByIndex(CSteamID steamIDClan, int iUser)
		{
			return default;
		}

		public static bool SendClanChatMessage(CSteamID steamIDClanChat, string pchText)
		{
			return false;
		}

		public static int GetClanChatMessage(CSteamID steamIDClanChat, int iMessage, out string prgchText, int cchTextMax, out EChatEntryType peChatEntryType, out CSteamID psteamidChatter)
		{
			prgchText = null;
			peChatEntryType = default;
			psteamidChatter = default;
			return 0;
		}

		public static bool IsClanChatAdmin(CSteamID steamIDClanChat, CSteamID steamIDUser)
		{
			return false;
		}

		public static bool IsClanChatWindowOpenInSteam(CSteamID steamIDClanChat)
		{
			return false;
		}

		public static bool OpenClanChatWindowInSteam(CSteamID steamIDClanChat)
		{
			return false;
		}

		public static bool CloseClanChatWindowInSteam(CSteamID steamIDClanChat)
		{
			return false;
		}

		public static bool SetListenForFriendsMessages(bool bInterceptEnabled)
		{
			return false;
		}

		public static bool ReplyToFriendMessage(CSteamID steamIDFriend, string pchMsgToSend)
		{
			return false;
		}

		public static int GetFriendMessage(CSteamID steamIDFriend, int iMessageID, out string pvData, int cubData, out EChatEntryType peChatEntryType)
		{
			pvData = null;
			peChatEntryType = default;
			return 0;
		}

		public static SteamAPICall_t GetFollowerCount(CSteamID steamID)
		{
			return default;
		}

		public static SteamAPICall_t IsFollowing(CSteamID steamID)
		{
			return default;
		}

		public static SteamAPICall_t EnumerateFollowingList(uint unStartIndex)
		{
			return default;
		}

		public static bool IsClanPublic(CSteamID steamIDClan)
		{
			return false;
		}

		public static bool IsClanOfficialGameGroup(CSteamID steamIDClan)
		{
			return false;
		}

		public static int GetNumChatsWithUnreadPriorityMessages()
		{
			return 0;
		}

		public static void ActivateGameOverlayRemotePlayTogetherInviteDialog(CSteamID steamIDLobby)
		{
		}
	}
}
