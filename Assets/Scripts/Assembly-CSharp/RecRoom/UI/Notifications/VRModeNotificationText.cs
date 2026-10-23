using System;
using TMPro;
using UnityEngine;

namespace RecRoom.UI.Notifications
{
	[Serializable]
	public class VRModeNotificationText : GGPAKCCMKMG
	{
		[SerializeField]
		private TextMeshPro textObject;

		public EEANDDJEMJC LayoutChanged;

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color Color
		{
			get
			{
				return default;
			}
			set
			{
			}
		}

		public float Alpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int LineCount => 0;

		public float RenderedHeight => 0f;

		public TextMeshPro TextObject => null;
	}
}
