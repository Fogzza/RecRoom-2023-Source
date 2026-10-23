using System;

namespace RecRoom.Avatars.Data.Shared
{
	[Flags]
	public enum OutfitSlotFlags
	{
		None = 0,
		Hat = 1,
		Hair = 2,
		Ear = 4,
		Eye = 8,
		Beard = 0x10,
		Shoulder = 0x20,
		Shirt = 0x40,
		Waist = 0x80,
		Neck = 0x100,
		Wrist = 0x400,
		All = int.MaxValue
	}
}
