using UnityEngine;

namespace RecRoom.Consumable
{
	public class HeadPotionConsumableItem : ConsumableItem
	{
		public enum FHFOPNDCLCB
		{
			INVALID = 0,
			DKMode = 1
		}

		[SerializeField]
		protected FHFOPNDCLCB potionType;

public FHFOPNDCLCB PotionType
{
get 		{
			return FHFOPNDCLCB.INVALID;
		}

}

		public override ConsumableInfo ToConsumableInfo()
		{
			return null;
		}
	}
}
