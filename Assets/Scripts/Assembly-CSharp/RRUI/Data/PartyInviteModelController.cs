using System;
using UnityEngine;
using UnityEngine.Localization;

namespace RRUI.Data
{
	public class PartyInviteModelController : ModelController<PartyInviteModel>
	{
		[Serializable]
		private class AddAccountToInviteImpl : ButtonControllerImpl<PartyInviteModel>
		{
			[SerializeField]
			private AccountModel accountModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class RemoveAccountFromInviteImpl : ButtonControllerImpl<PartyInviteModel>
		{
			[SerializeField]
			private AccountModel accountModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InviteAccountsToPartyImpl : ButtonControllerImpl<PartyInviteModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class InviteAccountsChatDialogImpl : ToggleControllerImpl<PartyInviteModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			private void ONKOEKPOFDI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class InviteAccountsTextImpl : TextControllerImpl<PartyInviteModel>
		{
			[SerializeField]
			private string noAccountsText;

			[SerializeField]
			private LocalizedString noAccountLocText;

			[SerializeField]
			private LocalizedString inviteNToPartyLocText;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
