using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class MessagesScreenItem : MonoBehaviour
	{
		[Serializable]
		private class MessageColorConfig
		{
			public enum LBEOBMEKILG
			{
				Moderation = 0,
				RequestFailed = 1,
				Urgent = 2,
				UrgentViewed = 3,
				NonUrgent = 4,
				NonUrgentViewed = 5
			}

			public Color ModerationColor;

			public Color ModerationFailedColor;

			public Color UrgentColor;

			public Color UrgentViewedColor;

			public Color NonUrgentColor;

			public Color NonUrgentViewedColor;

			public LBEOBMEKILG GameInviteColorType;

			public LBEOBMEKILG GameInviteDeclinedColorType;

			public LBEOBMEKILG GameJoinFailedColorType;

			public LBEOBMEKILG PartyActivitySwitchColorType;

			public LBEOBMEKILG FriendInviteColorType;

			public LBEOBMEKILG VoteToKickColorType;

			public LBEOBMEKILG RequestGameInviteColorType;

			public LBEOBMEKILG RequestGameInviteDeclinedColorType;

			public LBEOBMEKILG FriendStatusOnlineColorType;

			public LBEOBMEKILG TextMessageColorType;

			public LBEOBMEKILG CoachMessageColorType;

			public LBEOBMEKILG RoomCoOwnerAddedMessageColorType;

			public LBEOBMEKILG RoomCoOwnerRemovedMessageColorType;

			public LBEOBMEKILG RoomTranslationCompletedColorType;

			public LBEOBMEKILG ClubMemberInviteMessageColorType;

			public LBEOBMEKILG CheerMessageColorType;

			public LBEOBMEKILG FriendRequestAcceptedColorType;

			public LBEOBMEKILG FriendCodeUsedColorType;

			public LBEOBMEKILG CreatorPublishedNewRoomColorType;

			public LBEOBMEKILG PlayerEventInvitationColorType;

			public LBEOBMEKILG NewRoomCommentsColorType;

			public LBEOBMEKILG CreatorPublishedNewInventionColorType;

			public LBEOBMEKILG CreatorAnnouncementColorType;

			public LBEOBMEKILG PartyUpRequestColorType;

			public LBEOBMEKILG CreatorPublishedNewPlayerEventColorType;

			public LBEOBMEKILG RoomNotificationColorType;

			public LBEOBMEKILG BroadcastingRequestColorType;

			public LBEOBMEKILG RoomEarningsDistributionCoOwnerChangedColorType;

			public LBEOBMEKILG RoomEarningsDistributionPercentageUpdatedColorType;
		}

		private enum DILMJJGDJPD
		{
			NOTIFICATION_GAME_INVITE = 0,
			NOTIFICATION_GAME_INVITE_DECLINED = 1,
			NOTIFICATION_FAILED_TO_JOIN_YOUR_GAME = 2,
			NOTIFICATION_FAILED_TO_JOIN_YOUR_GAME_WITH_SIZE = 3,
			NOTIFICATION_FRIEND_REQUEST_ACCEPTED = 4,
			NOTIFICATION_FRIEND_CODE_USED = 5,
			NOTIFICATION_PLAYER_WANTS_YOU_TO_MEET_FRIEND = 6,
			NOTIFICATION_FRIEND_IS_ONLINE = 7,
			NOTIFICATION_REQUEST_INVITE = 8,
			NOTIFICATION_REQUEST_INVITE_DECLINED = 9,
			NOTIFICATION_PARTY_UP_REQUEST = 10,
			NOTIFICATION_VIRTUAL_ROOM_NOTIFICATION = 11,
			NOTIFICATION_PLAYER_EVENT_INVITATION_DETAILED = 12,
			NOTIFICATION_PLAYER_EVENT_INVITATION_OBSCURED = 13,
			NOTIFICATION_FRIEND_REQUEST_LOADING_MUTUAL_FRIENDS = 14,
			NOTIFICATION_FRIEND_REQUEST = 15,
			NOTIFICATION_FRIEND_REQUEST_WITH_MUTUAL_FRIENDS = 16,
			PLAYER_NAME_LOADING = 17
		}

		private enum BKIDIOLHNMH
		{
			NOTIF_ROOM_TRANSLATION_HEADER_SHORT = 0
		}

		private sealed class CLJFEPHHPLM
		{
			public DFDECAEJBIO account;

			internal void _003CTryLoadPlayerName_003Eb__0(DFDECAEJBIO a)
			{
			}
		}

		private sealed class CJGJCCPECOB
		{
			public string friendInviteMessage;

			internal void _003CTryLoadFriendInviteMessage_003Eb__0(string mutualFriendsText)
			{
			}
		}

		private sealed class KKMJFOJCDFB
		{
			public JCDPHCELKHI room;

			internal void _003CTryLoadRoomName_003Eb__0(JCDPHCELKHI r)
			{
			}
		}

		private sealed class IAFOMMBNDJF
		{
			public IMIJPHJKLIM playerEvent;

			internal void _003CTryLoadEventName_003Eb__0(IMIJPHJKLIM e)
			{
			}
		}

		private sealed class LCFJBJBNAFG
		{
			public OEBAEGDPBLA invention;

			internal void _003CTryLoadAnnouncementInventionName_003Eb__0(OEBAEGDPBLA i)
			{
			}
		}

		private sealed class JGFIKOEHKEL
		{
			public EPILDIJELPG club;

			internal void _003CTryLoadAnnouncementClubName_003Eb__0(EPILDIJELPG c)
			{
			}
		}

		private sealed class DNNOFDBPOEM
		{
			public DFDECAEJBIO account;

			internal void _003CTryLoadAnnouncementPlayerName_003Eb__0(DFDECAEJBIO a)
			{
			}
		}

		[SerializeField]
		private TextMeshProUGUI contentText;

		[SerializeField]
		private TextMeshProUGUI headerText;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private GameObject profileButton;

		[SerializeField]
		private GameObject roomDetailsButton;

		[SerializeField]
		private GameObject clubAnnouncementDetailsButton;

		[SerializeField]
		private GameObject eventDetailsButton;

		[SerializeField]
		private GameObject openMessageButton;

		[SerializeField]
		private Image openMessageButtonImage;

		[SerializeField]
		private GameObject unreadBadge;

		private DMAIEODHOGA LFKKJIFPEMA;

		[SerializeField]
		private MessageColorConfig colorConfig;

public DMAIEODHOGA Model
{
get 		{
			return null;
		}

set {
		}
}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void IOJADIDCAOE(DMAIEODHOGA PBOPFHHBNPO)
		{
		}

		private void GODLBKDFPDG()
		{
		}

		private void LBNPIBGINPI(DMAIEODHOGA OFCFPGACNJB)
		{
		}

		private string GCCCOGBLJEC(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string FLEMFHPHDBN(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string HBKAOJGADDC(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string MHHKHBEOKEF(int EJIHLJJMOBD, bool JGBKCCDCCBM = false)
		{
			return null;
		}

		private string OCKHICKPMDL(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string HIOCOKGPLNH(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string AHPAFOMGBNH(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string IPHFOPDDBIH(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string BLMMDKEAEKC(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private string EGMOPCAFBIM(DMAIEODHOGA OFCFPGACNJB)
		{
			return null;
		}

		private void BDOBFMBFBOO()
		{
		}

		private Color BFGHLMOIPGJ(BJCIKFCDBFN.ELPJJPDDKCD MCGAJGCMAAK, bool GHNKKPJFPNE)
		{
			return default;
		}

		public void Button_Delete()
		{
		}

		public void Button_ShowDetails()
		{
		}
	}
}
