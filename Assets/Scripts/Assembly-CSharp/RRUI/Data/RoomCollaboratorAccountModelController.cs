using System;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomCollaboratorAccountModelController : ModelController<RoomCollaboratorAccountModel>
	{
		[Serializable]
		private class RoleTextImpl : TextControllerImpl<RoomCollaboratorAccountModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoleImageImpl : ImageControllerImpl<RoomCollaboratorAccountModel>
		{
			[SerializeField]
			private Sprite creatorSprite;

			[SerializeField]
			private Sprite coOwnerSprite;

			[SerializeField]
			private Sprite moderatorSprite;

			[SerializeField]
			private Sprite hostSprite;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RoomIdAndAccountIdLinkImpl : LinkControllerImpl<RoomCollaboratorAccountModel>
		{
			protected override void BNFEJGHHHLO()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPermissionsImpl : HideableControllerImpl<RoomCollaboratorAccountModel>, global::NOPBJEAADPE<RoomCollaboratorAccountModel.BAADNIEBNCC>
		{
			[SerializeField]
			private RoomCollaboratorAccountModel.BAADNIEBNCC minimumRole;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPermissionsNotEqualImpl : HideableControllerImpl<RoomCollaboratorAccountModel>, global::NOPBJEAADPE<RoomCollaboratorAccountModel.BAADNIEBNCC>
		{
			[SerializeField]
			private RoomCollaboratorAccountModel.BAADNIEBNCC role;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
