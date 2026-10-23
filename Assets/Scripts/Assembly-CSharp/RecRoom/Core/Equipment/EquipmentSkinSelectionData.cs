using System;
using System.Security.Cryptography;

namespace RecRoom.Core.Equipment
{
	[Serializable]
	public class EquipmentSkinSelectionData : JMIIPNGAANF
	{
		public EquipmentData equipment;

		public SkinData skin;

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}
	}
}
