using System;
using UnityEngine;

namespace RRUI.Data
{
	public class PhotoChatMessageModelController : ModelController<PhotoChatMessageModel>
	{
		[Serializable]
		private class PhotoChatMessageToImageImpl : ControllerImplementation<PhotoChatMessageModel>
		{
			[SerializeField]
			private ImageModel imageModel;

			protected override void NGFFCLPHKJN()
			{
			}
		}
	}
}
