using System;

[Flags]
public enum AMBAFLLOFEA
{
	Empty = 0,
	Press = 1,
	LongPress = 2,
	DoublePress = 4,
	ShortPress = 8,
	None = 0x10,
	All = Press | LongPress | DoublePress | ShortPress | None,
	LongPressConsumer = 3,
	ShortPressConsumer = 0xD
}
