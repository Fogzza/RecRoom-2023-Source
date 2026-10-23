using System;
using UnityEngine;

namespace RecRoom.Consumable
{
	public abstract class ConsumableItem : MonoBehaviour, IComparable<ConsumableItem>
	{
		[SerializeField]
		protected string friendlyName;

		[SerializeField]
		protected HMJFJMPLFEO category;

		[SerializeField]
		protected string guidString;

		[SerializeField]
		protected int limitCount;

		[SerializeField]
		protected ConsumableManager.ALNBFPPACFD limitType;

		[SerializeField]
		protected bool autoActivateNextItem;

		[SerializeField]
		protected Transform visualRoot;

		[SerializeField]
		protected ConsumableTool consumableTool;

		[SerializeField]
		protected GameObject effectPrefab;

public string FriendlyName
{
get 		{
			return null;
		}

}

public HMJFJMPLFEO Category
{
get 		{
			return HMJFJMPLFEO.CameraFilter;
		}

}

public string ConsumableItemDesc
{
get 		{
			return null;
		}

}

public int LimitCount
{
get 		{
			return 0;
		}

}

public ConsumableManager.ALNBFPPACFD LimitType
{
get 		{
			return ConsumableManager.ALNBFPPACFD.Usage;
		}

}

public bool AutoActivateNextItem
{
get 		{
			return false;
		}

}

public Transform VisualRoot
{
get 		{
			return null;
		}

}

public ConsumableTool ConsumableTool
{
get 		{
			return null;
		}

}

public GameObject EffectPrefab
{
get 		{
			return null;
		}

}

		public int CompareTo(ConsumableItem HNPEBINPOBO)
		{
			return 0;
		}

		public virtual ConsumableInfo ToConsumableInfo()
		{
			return null;
		}

		protected void ELDMPJMJHMD<T>(ref T AKOKILEPANJ) where T : ConsumableInfo
		{
		}
	}
}
