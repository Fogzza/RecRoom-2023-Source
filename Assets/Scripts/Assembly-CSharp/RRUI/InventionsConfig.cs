using System;
using System.Collections.Generic;
using RRUI.Data;
using TMPro;
using UnityEngine;

namespace RRUI
{
	public class InventionsConfig : ScriptableObject
	{
		public enum JKAMIDHHBCK
		{
			CreationDate_Desc = 0,
			CreationDate_Asc = 1,
			Name_Asc = 2,
			Name_Desc = 3,
			Downloads_Asc = 4,
			Downloads_Desc = 5,
			Cheers_Asc = 6,
			Cheers_Desc = 7,
			Price_Asc = 8,
			Price_Desc = 9,
			Default = 10,
			PublishedAt_Desc = 11,
			PublishedAt_Asc = 12
		}

		[Serializable]
		public struct InventionReportCategoryFriendlyNameMapping
		{
			public CBBKADNEBGN EnumValue;

			public string FriendlyName;
		}

		[Serializable]
		public struct InventionSortFriendlyNameMapping
		{
			public JKAMIDHHBCK EnumValue;

			public string FriendlyName;
		}

		[Serializable]
		public struct InventionSourceFriendlyNameMapping
		{
			public InventionListModel.JKLMNNJDJEC SourceEnum;

			public string FriendlyName;
		}

		private static InventionsConfig _instance;

		private Dictionary<DNCOGHGDMAF, string> InventionPermissionTypeFriendlyNameMapping;

		[SerializeField]
		private List<InventionReportCategoryFriendlyNameMapping> inventionReportCategoryList;

		[SerializeField]
		private List<InventionSortFriendlyNameMapping> InventionSortCriteriaMetadata;

		[SerializeField]
		private string sourcePlayerCreatedInventions;

		[SerializeField]
		private string sourceFoundInRoom;

		[SerializeField]
		private string sourceMySubscriptions;

		[SerializeField]
		private string sourceFeaturedInventions;

		[SerializeField]
		private string sourceTrendingInventions;

		[SerializeField]
		private string sourceTopToday;

		[SerializeField]
		private string sourceFeaturedDormSkins;

		[SerializeField]
		private string sourceMyDormsSkins;

		[SerializeField]
		private string sourceMySubscriptionsDormSkins;

		private Dictionary<string, string> InventionTagFriendlyNameMapping;

		public static InventionsConfig Instance => null;

		public List<InventionReportCategoryFriendlyNameMapping> InventionReportCategoryList => null;

		public string CIHPCBHOEPF(DNCOGHGDMAF OAHMEFCIJFN)
		{
			return null;
		}

		public void OLHCGBKKHFH(out List<InventionSortFriendlyNameMapping> CAKDMLJEJPP, out List<TMP_Dropdown.OptionData> BAACJOELLBJ)
		{
			CAKDMLJEJPP = null;
			BAACJOELLBJ = null;
		}

		public string KKHCEDADNIM(InventionListModel.JKLMNNJDJEC GLLFHCCFIGK)
		{
			return null;
		}

		public string CPHPCAKKMIN(string AHNIMJDLOPB)
		{
			return null;
		}
	}
}
