using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RRUI
{
	public class AccountsConfig : ScriptableObject
	{
		public enum CGEPIENCFOK
		{
			Username_Asc = 0,
			Username_Desc = 1,
			UnreadAnnouncements = 2,
			SubscriberCount_Asc = 3,
			SubscriberCount_Desc = 4,
			AppearsOnline = 5,
			Level_Asc = 6,
			Level_Desc = 7,
			DisplayName_Asc = 8,
			DisplayName_Desc = 9,
			Friends = 10
		}

		[Serializable]
		public struct AccountSortFriendlyNameMapping
		{
			public CGEPIENCFOK EnumValue;

			public string FriendlyName;
		}

		[Serializable]
		public struct LeagueOfHeroesConfig
		{
			public string Name;

			public JKHJHBHHJMI.HEIFDMDAKJF League;

			public Sprite Icon;

			public string ChosenText;

			public string Description;

			public string Traits;

			public Sprite LogoWithLeagueColor;

			public Texture Background;
		}

		private static AccountsConfig _instance;

		[SerializeField]
		private GameObject playerCard;

		[SerializeField]
		private Sprite unfriendConfirmationDialogSprite;

		[SerializeField]
		private Sprite juniorAccountAgeVerifyDialogSprite;

		[SerializeField]
		private List<AccountSortFriendlyNameMapping> SubscriptionAccountSortCriteriaMetadata;

		[SerializeField]
		public List<LeagueOfHeroesConfig> LeagueOfHeroesConfigs;

		public static AccountsConfig Instance => null;

		public GameObject PlayerCard => null;

		public Sprite UnfriendConfirmationDialogSprite => null;

		public Sprite JuniorAccountAgeVerifyDialogSprite => null;

		public void PNKEEENDNFE(out List<AccountSortFriendlyNameMapping> CAKDMLJEJPP, out List<TMP_Dropdown.OptionData> BAACJOELLBJ)
		{
			CAKDMLJEJPP = null;
			BAACJOELLBJ = null;
		}

		public LeagueOfHeroesConfig ECPKHFOGDAN()
		{
			return default;
		}
	}
}
