using System;

[Flags]
public enum JHEMPDCLIFL
{
	Uninitialized = int.MinValue,
	None = 0,
	Visible = 1,
	NormalRes = 2,
	PortsVisible = 4,
	PortTextVisible = 8,
	TitleTextVisible = 0x10,
	SpriteVisible = 0x20,
	All = int.MaxValue
}
