using System;
using TMPro;
using UnityEngine;

namespace RecRoom.UI.Notifications
{
	[Serializable]
	public class ScreenModeNotificationText : GGPAKCCMKMG
	{
		[SerializeField]
		private TextMeshProUGUI textObject;

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
	}
}
