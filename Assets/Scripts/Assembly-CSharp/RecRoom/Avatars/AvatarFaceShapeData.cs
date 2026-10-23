using System;

namespace RecRoom.Avatars
{
	[Serializable]
	public class AvatarFaceShapeData
	{
		public enum PLOKPGJFBLL
		{
			Heart = 1,
			Oval = 2,
			Pointy = 3,
			Round = 4,
			Square = 5
		}

		public PLOKPGJFBLL blendShape;

		public float value;
	}
}
