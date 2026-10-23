using System;

namespace RecRoom.Avatars
{
	[Serializable]
	public class AvatarBodyShapeData
	{
		public enum CEEGMOEPIAJ
		{
			Pear = 1,
			Apple = 2,
			Triangle = 3,
			Hourglass = 4,
			Square = 5
		}

		public CEEGMOEPIAJ blendShape;

		public float value;
	}
}
