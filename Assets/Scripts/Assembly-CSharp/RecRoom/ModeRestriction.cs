using UnityEngine;

namespace RecRoom
{
	public class ModeRestriction : VisibilityRestriction
	{
		public enum MHPMMBOOKCM
		{
			AG_CREATED = 0,
			PLAYER_CREATED = 1,
			ALL = 2
		}

		public enum GPKJAJMANGH
		{
			PUBLIC = 0,
			PRIVATE = 1,
			ALL = 2
		}

		[SerializeField]
		private MHPMMBOOKCM supportedRoomCreator;

		[SerializeField]
		private GPKJAJMANGH supportedVisibility;

		public RoomSceneLocationPicker[] DisableInLocations;

		public static bool IsSupported(MHPMMBOOKCM IAIIHGOLOBA)
		{
			return false;
		}

		public static bool IsSupported(GPKJAJMANGH HMIGNDLGKNL)
		{
			return false;
		}

		protected override void BGAOMEFNMME()
		{
		}

		private bool AOBMJAIMAFP(IPLNKMKGEFN KJAPODOABPN)
		{
			return false;
		}
	}
}
