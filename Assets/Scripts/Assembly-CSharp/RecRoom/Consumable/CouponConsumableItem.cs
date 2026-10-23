using UnityEngine;

namespace RecRoom.Consumable
{
	public class CouponConsumableItem : ConsumableItem
	{
		[SerializeField]
		protected DHIHBEBKCKK discountType;

		[SerializeField]
		protected int value;

		[SerializeField]
		protected FHPHMBKPLCC storefrontType;

		[SerializeField]
		protected GKPEKOLBBJL currencyType;

public DHIHBEBKCKK DiscountType
{
get 		{
			return (DHIHBEBKCKK)0;
		}

}

public int Value
{
get 		{
			return 0;
		}

}

public FHPHMBKPLCC StorefrontType
{
get 		{
			return FHPHMBKPLCC.None;
		}

}

public GKPEKOLBBJL CurrencyType
{
get 		{
			return GKPEKOLBBJL.Invalid;
		}

}

		public static long GetDiscountedPrice(DHIHBEBKCKK HPNGKLOMNHD, long OMBEFPMIAGD, long CFOPFMGNHOL)
		{
			return 0L;
		}

		public override ConsumableInfo ToConsumableInfo()
		{
			return null;
		}
	}
}
