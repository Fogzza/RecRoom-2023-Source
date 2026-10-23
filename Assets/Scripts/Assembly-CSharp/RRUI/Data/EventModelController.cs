using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RRUI.Theme;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class EventModelController : ModelController<EventModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class NameImpl : TextControllerImpl<EventModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SettingsTitleImpl : TextControllerImpl<EventModel>
		{
			[SerializeField]
			private string prefix;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DescriptionImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CreatorAccountUsernameImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomNameImpl : TextControllerImpl<EventModel>
		{
			[SerializeField]
			private string appendInBroadcastInstance;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ClubNameImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class StartTimeImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class CountdownTextImpl : TextControllerImpl<EventModel>
		{
			[SerializeField]
			private string prefix;

			[SerializeField]
			private string finishedCountdownText;

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

			private void ALHNNKKLGHC(float GADDGJANIGG = 0f)
			{
			}
		}

		[Serializable]
		private class EndTimeImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AttendeeCountImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InterestCountImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(int BFFJHKFEFPP)
			{
			}
		}

		[Serializable]
		private class CurrentlyBroadcastingCountImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DefaultBroadcastPermissionsModeTextImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(EventsConfig.BroadcastPermissionsModeFriendlyNameMapping FCCGDNMAHPA)
			{
				return false;
			}
		}

		[Serializable]
		private class CanRequestBroadcastPermissionsModeTextImpl : TextControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			[CompilerGenerated]
			private bool JGDBHMOFKOH(EventsConfig.BroadcastPermissionsModeFriendlyNameMapping FCCGDNMAHPA)
			{
				return false;
			}
		}

		[Serializable]
		private class MainImageImpl : RecNetRawImageControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchEventDetailsButtonImpl : ButtonControllerImpl<EventModel>
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
		private class Shim_NavigateToOldWatchEventInvitesButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class Shim_NavigateToOldWatchReportEventButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class BroadcastButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class StopBroadcastButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShowBroadcastersButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ManageBroadcastersButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RequestToJoinBroadcastButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class JoinPrivateRoomButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class ShareButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DeleteButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveEventButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveEventNameButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveEventDescriptionButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryChangeEventImageButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TryChangeEventLocationImpl : ButtonControllerImpl<EventModel>
		{
			[SerializeField]
			private GameObject subRoomCardPrefab;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SaveEventTimeRangeButtonImpl : ButtonControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DefaultBroadcastPermissionButtonImpl : ButtonControllerImpl<EventModel>
		{
			[SerializeField]
			private GameObject buttonPrefab;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class CanRequestBroadcastPermissionButtonImpl : ButtonControllerImpl<EventModel>
		{
			[SerializeField]
			private GameObject buttonPrefab;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RSVPToggleImpl : ToggleControllerImpl<EventModel>
		{
			[SerializeField]
			private HHAPNEKGMEP responseType;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class AccessibilityToggleImpl : ToggleControllerImpl<EventModel>
		{
			[SerializeField]
			private AAOMIMIAKGO accessibility;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MultiInstanceToggleImpl : ToggleControllerImpl<EventModel>
		{
			[SerializeField]
			private bool isMultiInstance;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class MultiInstanceRoomChatToggleImpl : ToggleControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class TagToggleImpl : ToggleControllerImpl<EventModel>
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
		private class NameInputFieldImpl : InputFieldControllerImpl<EventModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class DescriptionInputFieldImpl : InputFieldControllerImpl<EventModel>
		{
			[SerializeField]
			private TextMeshProUGUI counter;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class TagCustomInputFieldImpl : TagInputFieldControllerImpl<EventModel>
		{
			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			private bool LJNDLANGCDN(string IPMIIEAGJKC)
			{
				return false;
			}

			protected override void LEKIJHCGCLH(IReadOnlyList<string> CMBMOBEBGIN)
			{
			}
		}

		[Serializable]
		private class StartDateTimeInputFieldImpl : DateTimePickerControllerImpl<EventModel>
		{
			protected override void NCMMJLLDGED(DateTime LEDKEEFMDDC)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class EndDateTimeInputFieldImpl : DateTimePickerControllerImpl<EventModel>
		{
			protected override void NCMMJLLDGED(DateTime LEDKEEFMDDC)
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class LocationInputFieldImpl : InputFieldControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void LMDNMDLBMGI(string IPMIIEAGJKC)
			{
			}

			protected override void OCBEIMLCCCH(string IPMIIEAGJKC)
			{
			}
		}

		[Serializable]
		private class EventIdLinkImpl : LinkControllerImpl<EventModel>
		{
			[SerializeField]
			protected ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class SwitchableEventIdLinkImpl : LinkControllerImpl<EventModel>
		{
			[SerializeField]
			protected ToggleTheme toggleTheme;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class EventFromUriImpl : FromUriControllerImpl<EventModel>
		{
			protected override void AGLPOPGOHMJ()
			{
			}
		}

		[Serializable]
		private class HideIfEventOrganizerImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotEventOrganizerImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanStartBroadcastingImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotStartBroadcastingImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanRequestBroadcastingAuthorizationImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotRequestBroadcastingAuthorizationImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanStopBroadcastingImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotStopBroadcastingImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInBroadcastingEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInBroadcastingEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHappeningNowImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotHappeningNowImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCannotJoinPrivateImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotClubEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfBroadcastingEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotBroadcastingEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfHasPendingInviteImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoPendingInviteImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfEventExistsImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNewEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCanEditTagsImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCantEditTagsImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfCantCreateMultiInstanceEventsImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotMultiInstanceEventImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfEveryoneCanBroadcastImpl : HideableControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class PopularTagTogglesSpawnerImpl : PrefabSpawnerControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}

			[CompilerGenerated]
			private void JGDBHMOFKOH(int ONEGMPJFKJP)
			{
			}
		}

		[Serializable]
		private class TagsListSpawnerImpl : PrefabSpawnerControllerImpl<EventModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class ToCardImpl : ToCardControllerImpl<EventModel>
		{
			protected override AEBHFHIINHM CardData => null;

			[CompilerGenerated]
			private void GIJNKPAALAP()
			{
			}
		}

		[Serializable]
		private class ToAccountListImpl : ControllerImplementation<EventModel>
		{
			[SerializeField]
			private AccountListModel accountListModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToRoomImpl : ControllerImplementation<EventModel>
		{
			[SerializeField]
			private RoomModel roomModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ToInviterAccountImpl : ControllerImplementation<EventModel>
		{
			[SerializeField]
			private AccountModel accountModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		public JLOCLGGLOPP GetToCardController()
		{
			return null;
		}
	}
}
