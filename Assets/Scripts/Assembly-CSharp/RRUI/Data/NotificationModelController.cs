using System;
using UnityEngine;

namespace RRUI.Data
{
	public class NotificationModelController : ModelController<NotificationModel>
	{
		[Serializable]
		private class UnreadNotificationsTextImpl : TextControllerImpl<NotificationModel>
		{
			[SerializeField]
			private int _maximum;

			[SerializeField]
			private bool ignoreFriendRequestsIfUsingRRUIPeopleScreen;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UnreadMessagesTextImpl : TextControllerImpl<NotificationModel>
		{
			[SerializeField]
			private int _maximum;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class UnreadFriendRequestsTextImpl : TextControllerImpl<NotificationModel>
		{
			[SerializeField]
			private int _maximum;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoUnreadNotificationsImpl : HideableControllerImpl<NotificationModel>
		{
			[SerializeField]
			private bool ignoreFriendRequestsIfUsingRRUIPeopleScreen;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoUnreadMessagesImpl : HideableControllerImpl<NotificationModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoUnreadFriendRequestsImpl : HideableControllerImpl<NotificationModel>
		{
			[SerializeField]
			private bool alwaysHideIfNotUsingRRUIPeopleScreen;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DisableAllChatThreadNotificationsImpl : ControllerImplementation<NotificationModel>
		{
			private NotificationModel.IFKGMHMDDIO token;

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class DisableChatThreadNotificationsImpl : ControllerImplementation<NotificationModel>
		{
			[SerializeField]
			protected ChatThreadModel chatThreadModel;

			private NotificationModel.IFKGMHMDDIO token;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void AFELIDKEEFL()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
