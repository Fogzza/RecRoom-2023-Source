using System;
using UnityEngine;

namespace RRUI.Data
{
	public class OnlineFriendsModelController : ModelController<OnlineFriendsModel>
	{
		[Serializable]
		private class OnlineFriendCountTextImpl : TextControllerImpl<OnlineFriendsModel>
		{
			[SerializeField]
			private int _maximum;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideIfNoFriendsOnlineImpl : HideableControllerImpl<OnlineFriendsModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
