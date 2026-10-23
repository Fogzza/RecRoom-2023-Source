using System.Security.Cryptography;
using UnityEngine;

namespace RecRoom.Consumable
{
	public class ConsumableCollectionRuntimeConfig : HashableScriptableObject
	{
		[SerializeField]
		public GenericConsumableInfo[] GenericConsumables;

		[SerializeField]
		public HairDyeConsumableInfo[] HairDyeConsumables;

		[SerializeField]
		public CouponConsumableInfo[] CouponConsumables;

		[SerializeField]
		public HeadPotionConsumableInfo[] HeadPotionConsumables;

		public ConsumableInfo[] HOEGIGJPEJL()
		{
			return null;
		}

		public override void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}
	}
}
