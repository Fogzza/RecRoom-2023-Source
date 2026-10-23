using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using RRUI.Theme;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomListModelController : ModelController<RoomListModel>
	{
		[Serializable]
		private class SourceLabelTextImpl : TextControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PlaylistDescriptionTextImpl : TextControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClearSearchQueryButtonImpl : ButtonControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ClearFilterButtonImpl : ButtonControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchQueryButtonImpl : ButtonControllerImpl<RoomListModel>
		{
			private enum NMAHOODICOF
			{
				Set = 0,
				Append = 1
			}

			[SerializeField]
			private string value;

			[SerializeField]
			private NMAHOODICOF type;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowSearchSortDialogButtonImpl : ButtonControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GetMoreJackpotRoomsButtonImpl : ButtonControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CategoryTagToggleImpl : ToggleControllerImpl<RoomListModel>
		{
			[SerializeField]
			private TextMeshProUGUI chipText;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SearchQueryInputFieldImpl : InputFieldControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class FilterInputFieldImpl : InputFieldControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class SourceDropdownImpl : EnumDropdownControllerImpl<RoomListModel, RoomListModel.FFPAGDBKIPG>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void CGAOPDAMPMJ(RoomListModel.FFPAGDBKIPG IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class SortByDropdownImpl : DropdownControllerImpl<RoomListModel>
		{
			[NonSerialized]
			private List<RoomsConfig.RoomSortFriendlyNameMapping> sortCriteriaConfig;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OBNGIJHLCJE(int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private bool CPIGDEKABHN(RoomsConfig.RoomSortFriendlyNameMapping ONCGIPFNENB)
			{
				return false;
			}
		}

		[Serializable]
		private class RoomsBySourceLinkImpl : LinkControllerImpl<RoomListModel>
		{
			[SerializeField]
			private RoomListModel.FFPAGDBKIPG source;

			[SerializeField]
			private bool overrideLoadSceneSource;

			[SerializeField]
			private DBECJLAIPEL loadSceneSourceOverride;

			[SerializeField]
			private RoomsConfig.OKAFPNHPKND sortCriteria;

			[SerializeField]
			private bool sortByPlayerCount;

			[SerializeField]
			private bool showPlayerCountBadge;

			[SerializeField]
			private string tagName;

			[SerializeField]
			private ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private bool KFOIOFCMPKD()
			{
				return false;
			}
		}

		[Serializable]
		private class TrendingTagLinkImpl : LinkControllerImpl<RoomListModel>
		{
			[SerializeField]
			private TextMeshProUGUI chipText;

			[SerializeField]
			private ToggleTheme toggleTheme;

			private RRUI.Navigation.Uri UriWithData => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PlayerCreatedRoomsTabLinkImpl : LinkControllerImpl<RoomListModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			[SerializeField]
			private RoomListModel.DDFKFJLFOKF ownershipFilter;

			private RRUI.Navigation.Uri UriWithData => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class PlayerShowcaseRoomsLinkImpl : LinkControllerImpl<RoomListModel>
		{
			[SerializeField]
			private ToggleTheme toggleTheme;

			private RRUI.Navigation.Uri UriWithData => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowMeAllRoomsLinkImpl : LinkControllerImpl<RoomListModel>
		{
			private RRUI.Navigation.Uri UriWithData => null;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class FromUriImpl : FromUriControllerImpl<RoomListModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfNotSearchingImpl : HideableControllerImpl<RoomListModel>, global::NOPBJEAADPE<KDOHOBLOICP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfSearchingImpl : HideableControllerImpl<RoomListModel>, global::NOPBJEAADPE<KDOHOBLOICP>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		public abstract class SourceMatchImpl : HideableControllerImpl<RoomListModel>
		{
			[SerializeField]
			private RoomListModel.FFPAGDBKIPG source;

			[SerializeField]
			private string searchQuery;

			[SerializeField]
			private bool requireMatchSearchQuery;

			[SerializeField]
			private string hotTags;

			[SerializeField]
			private bool requireMatchHotTags;

			protected bool isMatch => false;

			private bool CONCMILKFON()
			{
				return false;
			}
		}

		[Serializable]
		private class HideIfNotSourceMatchImpl : SourceMatchImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfSourceMatchImpl : SourceMatchImpl
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShouldHideCarousel : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfChipBarShouldBeHiddenImpl : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShouldHideThisRoomCarouselSizeImpl : HideableControllerImpl<RoomListModel>
		{
			[SerializeField]
			private LNCCOPFMJAL size;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomCategorySelectChipShouldBeHiddenImpl : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfGoStraightToRandomRoomShouldBeHiddenImpl : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomJackpotChipShouldBeHiddenImpl : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRoomJackpotIsEmptyImpl : HideableControllerImpl<RoomListModel>
		{
			[SerializeField]
			private int index;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowMeAllRoomsShouldBeHiddenImpl : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingLocalAccountCreatedRoomsImpl : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfShowingRemoteAccountCreatedRoomsImpl : HideableControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomListSpawnerImpl : RecyclingListControllerImpl<RoomListModel, RoomModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class CategoryTagTogglesSpawnerImpl : PrefabSpawnerControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class TrendingTagSpawnerImpl : PrefabSpawnerControllerImpl<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class RoomListCardSpawnerNonScrollableImpl : PrefabCardSpawnerControllerImpl<RoomListModel, RoomModel, RoomModelController>
		{
			private enum NNGKFFHEFCF
			{
				RoomName = 0,
				RoomDescription = 1,
				CreatorUsername = 2,
				CreationDate = 3
			}

			private sealed class HFELKGABLEN
			{
				public RoomModel roomModel;

				public RoomListCardSpawnerNonScrollableImpl _003C_003E4__this;

				public long roomId;

				internal string _003COnPopulateInstance_003Eb__0()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__2()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__4()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__5()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__6()
				{
					return null;
				}

				internal bool _003COnPopulateInstance_003Eb__7(RoomListModel.OGMHBDGFCJN x)
				{
					return false;
				}
			}

			[SerializeField]
			private bool setSecondaryTextBasedOnSortingType;

			[SerializeField]
			private bool overridePrimaryText;

			[SerializeField]
			private NNGKFFHEFCF overridePrimaryTextType;

			[SerializeField]
			private bool overrideSecondayText;

			[SerializeField]
			private NNGKFFHEFCF overrideSecondaryTextType;

			[SerializeField]
			private bool overrideTertiaryText;

			[SerializeField]
			private NNGKFFHEFCF overrideTertiaryTextType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected sealed override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE)
			{
			}

			protected virtual void IDHNBLOOEJM(RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE, long EPOBIFCHLNM)
			{
			}

			private string MILAHFHMNJB(RoomModel KJJMPBMEDDC, NNGKFFHEFCF EJNIEHHBOPO)
			{
				return null;
			}
		}

		[Serializable]
		private class RoomListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<RoomListModel, RoomModel, RoomModelController>
		{
			private enum HICIBKBPMAB
			{
				RoomName = 0,
				RoomDescription = 1,
				CreatorUsername = 2,
				CreationDate = 3
			}

			private sealed class CGHKHAJCCEL
			{
				public RoomModel roomModel;

				public RoomListCardSpawnerImpl _003C_003E4__this;

				public long roomId;

				internal string _003COnPopulateInstance_003Eb__0()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__2()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__4()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__5()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__6()
				{
					return null;
				}

				internal bool _003COnPopulateInstance_003Eb__7(RoomListModel.OGMHBDGFCJN x)
				{
					return false;
				}
			}

			[SerializeField]
			private bool setSecondaryTextBasedOnSortingType;

			[SerializeField]
			private bool overridePrimaryText;

			[SerializeField]
			private HICIBKBPMAB overridePrimaryTextType;

			[SerializeField]
			private bool overrideSecondayText;

			[SerializeField]
			private HICIBKBPMAB overrideSecondaryTextType;

			[SerializeField]
			private bool overrideTertiaryText;

			[SerializeField]
			private HICIBKBPMAB overrideTertiaryTextType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected sealed override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE)
			{
			}

			protected virtual void IDHNBLOOEJM(RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE, long EPOBIFCHLNM)
			{
			}

			private string MILAHFHMNJB(RoomModel KJJMPBMEDDC, HICIBKBPMAB EJNIEHHBOPO)
			{
				return null;
			}
		}

		[Serializable]
		private class SelectableRoomListCardSpawnerImpl : SelectableRecyclingListCardSpawnerControllerImpl<RoomListModel, RoomModel, RoomModelController>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE)
			{
			}

			protected override void IGNBBEJIBJO(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, RoomModel KJJMPBMEDDC)
			{
			}

			private void GELMAMOLGOD(int GMEHLIHLGEH, RoomModel KJJMPBMEDDC)
			{
			}
		}

		[Serializable]
		private class RoomListClubhouseSelectionCardSpawnerImpl : RoomListCardSpawnerImpl
		{
			private sealed class FLFLNLDIEEJ
			{
				public RoomListClubhouseSelectionCardSpawnerImpl _003C_003E4__this;

				public RoomModel roomModel;

				internal Sprite _003CConfigureRoomToCardController_003Eb__0()
				{
					return null;
				}

				internal void _003CConfigureRoomToCardController_003Eb__1()
				{
				}
			}

			private ClubModel clubModel;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void IDHNBLOOEJM(RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE, long EPOBIFCHLNM)
			{
			}
		}

		[Serializable]
		private class RoomListClubhouseToClubCardSpawnerImpl : RoomListCardSpawnerImpl
		{
			private sealed class BIIBHDKHPMB
			{
				public long roomId;

				public RoomModel roomModel;

				public RoomListModel.OGMHBDGFCJN clubhouseData;

				public RoomListClubhouseToClubCardSpawnerImpl _003C_003E4__this;

				internal bool _003CConfigureRoomToCardController_003Eb__0(RoomListModel.OGMHBDGFCJN x)
				{
					return false;
				}

				internal string _003CConfigureRoomToCardController_003Eb__1()
				{
					return null;
				}

				internal string _003CConfigureRoomToCardController_003Eb__2()
				{
					return null;
				}

				internal string _003CConfigureRoomToCardController_003Eb__4()
				{
					return null;
				}

				internal Sprite _003CConfigureRoomToCardController_003Eb__5()
				{
					return null;
				}

				internal void _003CConfigureRoomToCardController_003Eb__6()
				{
				}

				internal string _003CConfigureRoomToCardController_003Eb__7()
				{
					return null;
				}
			}

			[SerializeField]
			private Route ClubDetailsRoute;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void IDHNBLOOEJM(RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE, long EPOBIFCHLNM)
			{
			}
		}

		[Serializable]
		private class CreationBaseRoomCardSpawnerImpl : RoomListCardSpawnerImpl
		{
			private sealed class PKJMKHCIFID
			{
				public RoomModel roomModel;

				internal string _003CConfigureRoomToCardController_003Eb__0()
				{
					return null;
				}

				internal string _003CConfigureRoomToCardController_003Eb__1()
				{
					return null;
				}

				internal void _003CConfigureRoomToCardController_003Eb__4()
				{
				}
			}

			protected override void IDHNBLOOEJM(RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE, long EPOBIFCHLNM)
			{
			}
		}

		[Serializable]
		private class CreationMyRoomCardSpawnerImpl : RoomListCardSpawnerImpl
		{
			private sealed class CDKILHMBFFL
			{
				public RoomModel roomModel;

				internal string _003CConfigureRoomToCardController_003Eb__0()
				{
					return null;
				}

				internal string _003CConfigureRoomToCardController_003Eb__1()
				{
					return null;
				}
			}

			protected override void IDHNBLOOEJM(RoomModel KJJMPBMEDDC, JLOCLGGLOPP GIJKOHHEMOE, long EPOBIFCHLNM)
			{
			}
		}

		[Serializable]
		private class RoomJackpotRoomToCardImpl : ToCardControllerImpl<RoomListModel>
		{
			private sealed class CLGGLNMBDKM
			{
				public RoomJackpotRoomToCardImpl _003C_003E4__this;

				public RoomListModel.PHOMKMAEIAF room;

				internal void _003Cget_CardData_003Eb__0()
				{
				}
			}

			[SerializeField]
			private int index;

			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class RoomCategoryToCardImpl : ToCardControllerImpl<RoomListModel>
		{
			private sealed class LICKHNEPOAB
			{
				public RoomCategoryToCardImpl _003C_003E4__this;

				public DDOAONHMPPP.RoomCategory roomCategory;

				internal void _003Cget_CardData_003Eb__0()
				{
				}
			}

			[SerializeField]
			private Route route;

			[SerializeField]
			private int index;

			protected override AEBHFHIINHM CardData => null;
		}

		[Serializable]
		private class TryShowFullPlayMenuDialogImpl : ControllerImplementation<RoomListModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		public const string ROOM_LIST_TAG_KEY = "ROOM_LIST_TAG_KEY";

		private const string KGJBNMHEABL = "SORT_BY_PLAYER_COUNT_KEY";

		private const string GGGOEEADCJI = "SHOW_PLAYER_COUNT_BADGE_KEY";

		private const string ILNPABFABDN = "KEEPSAKE_ROOM_LIST_ID_KEY";
	}
}
