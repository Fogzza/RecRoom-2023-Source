using System;
using System.Collections.Generic;
using RecRoom.Audio;
using UnityEngine;

public class WatchNotificationTypeConfig : ScriptableObject
{
	public enum CNOGBNLENGJ
	{
		None = 0,
		Online = 1,
		Plus = 2
	}

	[Serializable]
	public class WatchNotificationTypeSettings
	{
		public string Name;

		public NotificationManager.MAOKONFJDIM WatchNotificationType;

		public RecRoomAudioClip AudioClip;

		public bool UseRecNetAccountIcon;

		public CNOGBNLENGJ RecNetAccountIconOverlay;

		public Sprite Icon;
	}

	private Dictionary<NotificationManager.MAOKONFJDIM, WatchNotificationTypeSettings> parsedMap;

	private WatchNotificationTypeSettings defaultSettings;

	[SerializeField]
	private WatchNotificationTypeSettings[] map;

	public WatchNotificationTypeSettings KEPDNDJHEPP(NotificationManager.MAOKONFJDIM DLOEJOFANNP)
	{
		return null;
	}

	public RecRoomAudioClip GDMDLNGIEOA(NotificationManager.MAOKONFJDIM DLOEJOFANNP)
	{
		return null;
	}
}
