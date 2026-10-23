using System;
using TMPro;
using UnityEngine;

namespace RRUI.Data
{
	public class PartyInviteChatMessageModelController : ModelController<PartyInviteChatMessageModel>
	{
		[Serializable]
		private class PartyInviteTextImpl : TextControllerImpl<PartyInviteChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class AcceptPartyInviteButtonImpl : ButtonControllerImpl<PartyInviteChatMessageModel>
		{
			[SerializeField]
			private TextMeshProUGUI textMeshProUGUI;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfPartyInviteExpiredImpl : HideableControllerImpl<PartyInviteChatMessageModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
