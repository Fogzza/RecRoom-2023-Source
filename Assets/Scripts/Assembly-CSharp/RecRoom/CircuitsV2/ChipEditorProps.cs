using System;
using RecRoom.CircuitsV2.Adapter;

namespace RecRoom.CircuitsV2
{
	[Serializable]
	public class ChipEditorProps
	{
		public CircuitsV2Mock circuitsV2Mock;

		public int activeMockChip;

		public bool rebindWhenMockChanges;

		public bool rebindWhenConfigChanges;

		public string newChipName;

		public string portName;

		public int port;

		public MockChipAdapter ActiveMockChip => null;
	}
}
