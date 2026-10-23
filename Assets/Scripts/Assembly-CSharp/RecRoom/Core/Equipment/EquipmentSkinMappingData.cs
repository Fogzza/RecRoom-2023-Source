using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace RecRoom.Core.Equipment
{
	[Serializable]
	public class EquipmentSkinMappingData : JMIIPNGAANF
	{
		public EquipmentData equipment;

		public List<SkinData> skins;

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}
	}
}
