using System;
using System.Collections.Generic;
using RRUI.Data;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI
{
	public class ClubsConfig : ScriptableObject
	{
		[Serializable]
		public struct ClubSortFriendlyNameMapping
		{
			public OJEIBHFICEN EnumValue;

			public string FriendlyName;
		}

		[Serializable]
		public struct ClubMembershipSortFriendlyNameMapping
		{
			public MFMJEGLCHHP EnumValue;

			public string ClubFriendlyName;

			public string PortfolioFriendlyName;
		}

		[Serializable]
		public struct ClubMembershipTypeFriendlyNameMapping
		{
			public KEJOIDAKHLL EnumValue;

			public string FriendlyName;
		}

		[Serializable]
		public struct AccountListSourceTypeFriendlyNameMapping
		{
			public CJIHECEJAHH EnumValue;

			public string FriendlyName;
		}

		[Serializable]
		public struct PendingRequestSortFriendlyNameMapping
		{
			public COJPIOAGDFP EnumValue;

			public string FriendlyName;
		}

		private sealed class NDKLKCIBEIE
		{
			public KEJOIDAKHLL membershipType;

			internal bool _003CGetFriendlyNameFor_003Eb__0(ClubMembershipTypeFriendlyNameMapping mt)
			{
				return false;
			}
		}

		private static ClubsConfig _instance;

		[SerializeField]
		public List<ClubSortFriendlyNameMapping> ClubSortCriteria;

		[SerializeField]
		public List<ClubMembershipSortFriendlyNameMapping> MemberSortCriteria;

		public List<ClubMembershipSortFriendlyNameMapping> BannedSortCriteria;

		[SerializeField]
		public List<ClubMembershipTypeFriendlyNameMapping> MembershipTypes;

		public List<ClubAction> ClubActions;

		public GameObject AnnouncementPickerDialogPrefab;

		public GameObject AnnouncementPhotoPickerDialogPrefab;

		public Sprite CodeAnnouncementDialogSprite;

		public Route ClubDetailsRoute;

		public Route PlayerAnnouncementActionRoute;

		public Route RoomAnnouncementActionRoute;

		public Route InventionAnnouncementActionRoute;

		public Route ChooseAnnouncementTypeRoute;

		public Route CreateAnnouncementRoute;

		public int DescriptionMaxLength;

		[SerializeField]
		public List<AccountListSourceTypeFriendlyNameMapping> InviteClubMembersDropdownSources;

		[SerializeField]
		public List<AccountListSourceTypeFriendlyNameMapping> BanClubMembersDropdownSources;

		[SerializeField]
		public List<PendingRequestSortFriendlyNameMapping> PendingRequestSortCriteria;

		public static ClubsConfig Instance => null;

		public string KKHCEDADNIM(KEJOIDAKHLL IIDIPBJDGKB)
		{
			return null;
		}
	}
}
