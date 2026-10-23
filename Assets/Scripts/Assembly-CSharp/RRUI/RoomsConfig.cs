using System;
using System.Collections.Generic;
using RRUI.Data;
using RRUI.Navigation;
using TMPro;
using UnityEngine;

namespace RRUI
{
	public class RoomsConfig : ScriptableObject
	{
		public enum OKAFPNHPKND
		{
			CreationDate_Desc = 0,
			CreationDate_Asc = 1,
			Name_Asc = 2,
			Name_Desc = 3,
			None = 4,
			Random_Per_Session = 5,
			Random_Per_Day = 6,
			Clubhouse_Options = 7
		}

		[Serializable]
		public struct RoomSortFriendlyNameMapping
		{
			public OKAFPNHPKND EnumValue;

			public string FriendlyName;
		}

		[Serializable]
		public struct RoomSourceFriendlyNameMapping
		{
			public RoomListModel.FFPAGDBKIPG SourceEnum;

			public string FriendlyName;
		}

		public struct LKLHIDLGHDE
		{
			public Guid? HJDAOGBNGLB;

			public string HGHLBCLFGAE;
		}

		private sealed class BLJHABPCPAM
		{
			public OKAFPNHPKND criteria;

			internal bool _003CGetFriendlyNameFor_003Eb__0(RoomSortFriendlyNameMapping rs)
			{
				return false;
			}
		}

		private sealed class COOKNALELOM
		{
			public RoomListModel.FFPAGDBKIPG source;

			internal bool _003CGetFriendlyNameFor_003Eb__0(RoomSourceFriendlyNameMapping rs)
			{
				return false;
			}
		}

		private static RoomsConfig _instance;

		public List<OKAFPNHPKND> RoomListAvailableSortOptions;

		[SerializeField]
		private List<RoomSortFriendlyNameMapping> RoomSortCriteriaMetadata;

		[SerializeField]
		private List<RoomSourceFriendlyNameMapping> RoomSourceCriteriaMetadata;

		[SerializeField]
		public Route RedirectAfterDeleteRoom;

		[SerializeField]
		public GameObject AccountCardPickerDialog;

		[SerializeField]
		public GameObject ImageCardPickerDialog;

		[SerializeField]
		public Sprite DeleteWarningSprite;

		[SerializeField]
		public Sprite AddNewSubroomSprite;

		[SerializeField]
		public Sprite SaveRoomSprite;

		[SerializeField]
		public Route RoomCurrencyStoreRoute;

		private List<LKLHIDLGHDE> currencyFriendlyMapping;

		[SerializeField]
		public Route RoomConsumablesSettingsTabRoute;

		[SerializeField]
		public Route RoomConsumablesStoreRoute;

		[SerializeField]
		private RRUI.Navigation.Uri roomConsumablesBackpackUri;

		public static RoomsConfig Instance => null;

		public RRUI.Navigation.Uri RoomConsumablesBackpackUri => null;

		public string KKHCEDADNIM(OKAFPNHPKND CMJKOMEBFMJ)
		{
			return null;
		}

		public string KKHCEDADNIM(RoomListModel.FFPAGDBKIPG GLLFHCCFIGK)
		{
			return null;
		}

		public void EKFPPMHEPIN(out List<RoomSortFriendlyNameMapping> CAKDMLJEJPP, out List<TMP_Dropdown.OptionData> BAACJOELLBJ)
		{
			CAKDMLJEJPP = null;
			BAACJOELLBJ = null;
		}

		public void PACFMCCKDAM(List<BKCIEBLAHHB> GHDNMNHAANI, out List<LKLHIDLGHDE> CAKDMLJEJPP)
		{
			CAKDMLJEJPP = null;
		}
	}
}
