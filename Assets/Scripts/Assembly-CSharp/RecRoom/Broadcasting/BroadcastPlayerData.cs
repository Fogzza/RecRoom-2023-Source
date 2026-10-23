using System;

namespace RecRoom.Broadcasting
{
	[Serializable]
	internal class BroadcastPlayerData
	{
		public int ActorNumber;

		public string Nickname;

		public int RecNetAccountId;

		public long RoomInstanceId;
	}
}
