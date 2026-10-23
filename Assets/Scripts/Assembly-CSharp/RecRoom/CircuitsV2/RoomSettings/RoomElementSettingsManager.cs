using System;
using System.Collections.Generic;

namespace RecRoom.CircuitsV2.RoomSettings
{
	public class RoomElementSettingsManager : NetworkedSingletonMonoBehaviour<RoomElementSettingsManager>
	{
		public static Action OnIsInitialized;

public new static bool IsInitialized
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		public T GetRoomElement<T>()
		{
			return default;
		}

		public IEnumerable<OJIHDJHLFFI> IPersistableRoomElements()
		{
			return null;
		}
	}
}
