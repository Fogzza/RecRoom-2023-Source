using System;
using System.Security.Cryptography;

namespace RecRoom.Consumable
{
	[Serializable]
	public abstract class ConsumableInfo : JMIIPNGAANF
	{
		public string FileName;

		public string ConsumableItemDesc;

		public string FriendlyName;

		public HMJFJMPLFEO Category;

		public ConsumableManager.ALNBFPPACFD LimitType;

		public int LimitCount;

		public bool AutoActivateNextItem;

		public string ConsumableToolName;

		public bool HasConsumableTool => false;

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}
	}
}
