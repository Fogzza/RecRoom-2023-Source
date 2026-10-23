using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Navigation;
using RecNet;
using UnityEngine;

namespace RRUI.Data
{
	public class ProgressionEventsModelController : ModelController<ProgressionEventsModel>
	{
		[Serializable]
		private class EventNameTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class BonusTaskTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private string formatString;

			private readonly Dictionary<string, object> formatParams;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TimeLeftTextImpl : CountdownTextImpl
		{
			[SerializeField]
			private string eventEndedText;

			protected override void DDDHFOKNKKE(float GADDGJANIGG = 0f)
			{
			}
		}

		[Serializable]
		private class RoomListsUnlockedTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(KeepsakeRoomListDTO JAAGBDPDCIE)
			{
				return false;
			}
		}

		[Serializable]
		private class KeepsakeNameTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private BLIIKHLKHJA keepsakeCategory;

			[SerializeField]
			private bool isPlural;

			[SerializeField]
			private bool isAllCaps;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AllKeepsakeNamesTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UpsellTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CollectionTimeLeftTextImpl : CountdownTextImpl
		{
			[SerializeField]
			private string collectionPeriodEndedText;

			protected override void DDDHFOKNKKE(float GADDGJANIGG = 0f)
			{
			}
		}

		[Serializable]
		private class NextStandardKeepsakeRoomUnlockCountdownTextImpl : CountdownTextImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void KONHEFEPCLL()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ConfigurableTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private IOEIFEGHMIF configurableTextType;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ConfigurableTextByIndexImpl : TextControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private IOEIFEGHMIF configurableTextType;

			[SerializeField]
			private int carouselIndex;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ConfigurableTextByRoomIdImpl : TextControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private IOEIFEGHMIF configurableTextType;

			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private void JLCLGOJBHNP()
			{
			}
		}

		[Serializable]
		private class InfoDialogButtonImpl : ButtonControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class GoToChallengesScreenButtonController : ButtonControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private string amplitudeCommandContext;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ProgressionEventsButtonClickedImpl : ButtonControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private string buttonLocation;

			[SerializeField]
			private string buttonName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class EventInfoImageImpl : RecNetRawImageControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChallengesIconImpl : RecNetRawImageControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RewardsPipImageImpl : RecNetRawImageControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ProgressionEventRewardListSpawnerImpl : RecyclingListControllerImpl<ProgressionEventsModel, ProgressionEventRewardModel>
		{
			private readonly List<int> ids;

			private float scrollOffsetFromActiveReward;

			private bool hasScrolledToActiveRewardIndex;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			[CompilerGenerated]
			private void OJPDLKOHMBA()
			{
			}
		}

		[Serializable]
		private class ProgressionEventUpsellItemListSpawnerImpl : RecyclingListCardSpawnerControllerImpl<ProgressionEventsModel, StoreItemModel, StoreItemModelController>
		{
			private sealed class AMNCFEOCBLB
			{
				public JLOCLGGLOPP storeItemToCardController;

				public ProgressionEventUpsellItemListSpawnerImpl _003C_003E4__this;

				public EOKBGGOAFLF purchasableGiftDrop;

				public StoreItemModel storeItemModel;

				public Func<LLEFPCFFPNH> _003C_003E9__3;

				public Func<string> _003C_003E9__4;

				internal void _003COnPopulateInstance_003Eb__0(JCDPHCELKHI room)
				{
				}

				internal LLEFPCFFPNH _003COnPopulateInstance_003Eb__3()
				{
					return null;
				}

				internal string _003COnPopulateInstance_003Eb__4()
				{
					return null;
				}
			}

			private sealed class AINADMLDKFA
			{
				public JCDPHCELKHI room;

				public AMNCFEOCBLB CS_0024_003C_003E8__locals1;

				internal void _003COnPopulateInstance_003Eb__1()
				{
				}

				internal string _003COnPopulateInstance_003Eb__2()
				{
					return null;
				}
			}

			protected readonly List<EOKBGGOAFLF> giftDrops;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, StoreItemModel HNGMOHCJOPD, JLOCLGGLOPP BKJABHIFFCA)
			{
			}
		}

		[Serializable]
		private class ProgressionEventUpsellItemRoomListSpawnerImpl : ProgressionEventUpsellItemListSpawnerImpl
		{
			[SerializeField]
			private RoomListModel roomListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ProgressionEventBonusRoomListSpawnerImpl : MultiPrefabRecyclingListControllerImpl<ProgressionEventsModel, RoomModel>
		{
			[SerializeField]
			private NAPPJGJJIFF keepsakeRoomListDisplayType;

			[SerializeField]
			private bool hideRoomsWithUnownedUpsell;

			[SerializeField]
			private GameObject regularRoomCard;

			[SerializeField]
			private GameObject premiumRoomCard;

			private readonly List<long> ids;

			private readonly Dictionary<long, KPEEPMGPOIB> keepsakeRoomTypes;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			protected override GameObject CDEDHHMKKNP(int GMEHLIHLGEH)
			{
				return null;
			}
		}

		[Serializable]
		private class HideIfActiveProgressionEventImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoActiveProgressionEventImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfActiveProgressionEventAndIntroTutorialNotStartedImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoActiveProgressionEventOrIntroTutorialStartedImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfActiveKeepsakeEventImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfActiveNonKeepsakeEventImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoBoostProgressionEventImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotStatusImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private IENHNBAOAMH status;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfStatusImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			private sealed class MIMGJKDCEJH
			{
				public IENHNBAOAMH currentStatus;

				internal bool _003COnModelChanged_003Eb__0(IENHNBAOAMH status)
				{
					return false;
				}
			}

			[SerializeField]
			private IENHNBAOAMH[] statuses;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfUpsellItemOwnedImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private RoomListModel roomListModel;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void HAOAGENIEIM(ModelBase GADDGJANIGG)
			{
			}
		}

		[Serializable]
		private class HideIfAllUpsellItemsOwnedImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(KeepsakeRoomListDTO NGFEBJIIMBM)
			{
				return false;
			}
		}

		[Serializable]
		private class HideIfNoUpsellItemsOwnedImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(KeepsakeRoomListDTO NGFEBJIIMBM)
			{
				return false;
			}
		}

		[Serializable]
		private class HideIfUpsellItemNotOwnedImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private RoomListModel roomListModel;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private void HAOAGENIEIM(ModelBase GADDGJANIGG)
			{
			}
		}

		[Serializable]
		private class HideIfNextStandardKeepsakeRoomUnlockTimeImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}

			private void HAOAGENIEIM()
			{
			}
		}

		[Serializable]
		private class HideIfNoNextStandardKeepsakeRoomUnlockTimeImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}

			private void HAOAGENIEIM()
			{
			}
		}

		[Serializable]
		private class HideIfActiveEventIsInCollectionGracePeriodImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfActiveEventIsNotInCollectionGracePeriodImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfChallengesIconImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoChallengesIconImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfRewardsPipImageImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoRewardsPipImageImpl : HideableControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AccountToMainRewardImpl : ControllerImplementation<ProgressionEventsModel>
		{
			[SerializeField]
			private ProgressionEventRewardModel progressionEventRewardModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EventToHighlightRoomImpl : ControllerImplementation<ProgressionEventsModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			[SerializeField]
			private RoomListModel roomListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EventToRoomListsImpl : ControllerImplementation<ProgressionEventsModel>
		{
			[SerializeField]
			private List<RoomListModel> standardRoomLists;

			[SerializeField]
			private List<RoomListModel> premiumRoomLists;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EventToFirstPurchasableBoostImpl : ControllerImplementation<ProgressionEventsModel>
		{
			[SerializeField]
			private ProgressionEventsPurchasableXpBoostModel purchasableXpBoostModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomNameToRoomImpl : ControllerImplementation<ProgressionEventsModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			[SerializeField]
			private string roomName;

			[SerializeField]
			private IOEIFEGHMIF roomNameGameConfigOverride;

			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void GLDMBJIMPBM(JCDPHCELKHI KPFNANKNKLE)
			{
			}
		}

		[Serializable]
		private class EventToBonusRewardImpl : ControllerImplementation<ProgressionEventsModel>
		{
			[SerializeField]
			private ProgressionEventRewardModel progressionEventRewardModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class TimeLeftProgressBarImpl : ProgressBarControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CollectionTimeRemainingProgressBarImpl : ProgressBarControllerImpl<ProgressionEventsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomIdLinkToProgressionEventMainHubImpl : LinkControllerImpl<ProgressionEventsModel>
		{
			private sealed class JLPDGDBOJFN
			{
				public RRUI.Navigation.Uri activeUri;

				public RoomIdLinkToProgressionEventMainHubImpl _003C_003E4__this;

				internal void _003COnButtonClicked_003Eb__0(JCDPHCELKHI room)
				{
				}
			}

			[SerializeField]
			private string progressionEventHubRoomName;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		private abstract class CountdownTextImpl : TextControllerImpl<ProgressionEventsModel>
		{
			private IDisposable countdownDisposable;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected abstract void DDDHFOKNKKE(float HOHFHDNPBAI = 0f);
		}
	}
}
