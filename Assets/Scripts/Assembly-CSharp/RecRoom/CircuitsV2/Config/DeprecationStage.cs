using System;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public enum DeprecationStage
	{
		Active = 0,
		Deprecating = 1,
		Deprecated = 2
	}
}
