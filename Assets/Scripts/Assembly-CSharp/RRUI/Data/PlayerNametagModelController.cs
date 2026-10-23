using System;
using UnityEngine;

namespace RRUI.Data
{
	public class PlayerNametagModelController : ModelController<PlayerNametagModel>
	{
		[Serializable]
		private class HideIfPlayerNametagHiddenController : HideableControllerImpl<PlayerNametagModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerHiddenController : HideableControllerImpl<PlayerNametagModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerHasRecRoomPlusController : HideableControllerImpl<PlayerNametagModel>, global::NOPBJEAADPE<HBEMJBHCCHB>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlayerDoesNotHaveRecRoomPlusController : HideableControllerImpl<PlayerNametagModel>, global::NOPBJEAADPE<HBEMJBHCCHB>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInAnyPartyImpl : HideableControllerImpl<PlayerNametagModel>, global::NOPBJEAADPE<OBCCGDPMMFD>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInAnyPartyImpl : HideableControllerImpl<PlayerNametagModel>, global::NOPBJEAADPE<OBCCGDPMMFD>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class SetModelsPlayerController : ControllerImplementation<PlayerNametagModel>
		{
			[SerializeField]
			private AccountModel AccountModel;

			[SerializeField]
			private RoomCollaboratorAccountModel RoomCollaboratorAccountModel;

			[SerializeField]
			private PlayerColorModel playerColorModel;

			[SerializeField]
			private PlayerRoleModel playerRoleModel;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
