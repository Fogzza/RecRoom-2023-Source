using System;

[Flags]
public enum OPKFOPKNLMG
{
	None = 0,
	DynamicUVProjection = 1,
	PreventInvertedCreation = 2,
	NewBendLogic = 4,
	ALL = DynamicUVProjection | PreventInvertedCreation | NewBendLogic,
	MAX_VALUE = ALL
}
