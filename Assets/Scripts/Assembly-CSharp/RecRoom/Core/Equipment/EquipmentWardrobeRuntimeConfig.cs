using System.Collections.Generic;
using System.Security.Cryptography;

namespace RecRoom.Core.Equipment
{
	public class EquipmentWardrobeRuntimeConfig : HashableScriptableObject
	{
		public List<EquipmentSkinMappingData> toolSkinMaps;

		public List<EquipmentSkinSelectionData> defaultUnlockedSelections;

		public override void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}
	}
}
