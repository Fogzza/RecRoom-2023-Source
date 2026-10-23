using System;
using UnityEngine;

namespace RRUI.Data
{
	public class ExternalRoomProgressionModelController : ModelController<ExternalRoomProgressionModel>
	{
		[Serializable]
		private class MainScoreTextImpl : TextControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class MainRankTextImpl : TextControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ScoreDescriptionTextImpl : TextControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class RankDescriptionTextImpl : TextControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ScoreColumnTextImpl : TextControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfTimeCardImpl : HideableControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfIntCardImpl : HideableControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfFriendsImpl : HideableControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFriendsImpl : HideableControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfInLeaderboardImpl : HideableControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNotInLeaderboardImpl : HideableControllerImpl<ExternalRoomProgressionModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class FriendLeaderboardEntrySpawnerImpl : PrefabSpawnerControllerImpl<ExternalRoomProgressionModel>
		{
			[SerializeField]
			private int numberOfFriendsToShow;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void MAGCPNIBJPL(GameObject CMDPMJBEBAB, int GMEHLIHLGEH)
			{
			}
		}

		[Serializable]
		private class TopFriendToFriendEntryImpl : ControllerImplementation<ExternalRoomProgressionModel>
		{
			[SerializeField]
			private ExternalRoomProgressionFriendEntryModel friendEntryModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
