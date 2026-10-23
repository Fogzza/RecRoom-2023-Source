using System;
using UnityEngine;

namespace RRUI.Data
{
	public class FriendotronModelController : ModelController<FriendotronModel>
	{
		[Serializable]
		private class CallToActionTextImpl : TextControllerImpl<FriendotronModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class GiftBoxImposterRenderImpl : ImposterRawImageControllerImpl<FriendotronModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ChooseFriendImpl : ButtonControllerImpl<FriendotronModel>
		{
			[SerializeField]
			private GameObject playerAccountPrefab;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class HideChooseFriendButtonImpl : HideableControllerImpl<FriendotronModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class HideSoldOutButtonImpl : HideableControllerImpl<FriendotronModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
