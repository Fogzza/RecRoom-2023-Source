using System;
using UnityEngine;

namespace RRUI.Data
{
	public class AvatarColorModelController : ModelController<AvatarColorModel>, DDIDMFFBNAE
	{
		[Serializable]
		private class AvatarColorToCardImpl : ToCardControllerImpl<AvatarColorModel>
		{
			protected override AEBHFHIINHM CardData => null;

			private void OnClick()
			{
			}
		}

		[Serializable]
		private class BackgroundColorImageImpl : ImageControllerImpl<AvatarColorModel>
		{
			[SerializeField]
			private AvatarColorModel.AvatarColorType avatarColorType;

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
