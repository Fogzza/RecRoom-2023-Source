using System;
using UnityEngine;

namespace RRUI.Data.NUX
{
	public class FriendImportModelController : ModelController<FriendImportModel>
	{
		[Serializable]
		private class AddNFriendsTextImpl : TextControllerImpl<FriendImportModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FriendImportAccountListCardSpawnerImpl : RecyclingListCardSpawnerControllerImpl<FriendImportModel, AccountModel, AccountModelController>
		{
			private sealed class JPHBNDKDOCL
			{
				public FriendImportAccountListCardSpawnerImpl _003C_003E4__this;

				public int accountId;

				public AccountModel accountModel;

				internal string _003COnPopulateInstance_003Eb__0()
				{
					return null;
				}

				internal bool _003COnPopulateInstance_003Eb__1()
				{
					return false;
				}

				internal void _003COnPopulateInstance_003Eb__2()
				{
				}
			}

			private sealed class LAFMCJNCHCH
			{
				public string platformId;

				internal string _003COnPopulateInstance_003Eb__4()
				{
					return null;
				}
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH, AccountModel KCCEEALIFJE, JLOCLGGLOPP JCOELCOJBFM)
			{
			}
		}

		[Serializable]
		private class ImportSelectedFriends : ButtonControllerImpl<FriendImportModel>
		{
			[SerializeField]
			private FriendImportModel friendImportModel;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformFriendsExistImpl : HideableControllerImpl<FriendImportModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfPlatformFriendsEmptyImpl : HideableControllerImpl<FriendImportModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
