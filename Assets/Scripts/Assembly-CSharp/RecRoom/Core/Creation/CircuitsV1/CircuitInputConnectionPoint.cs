using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class CircuitInputConnectionPoint : CircuitConnectionPoint
	{
		public EDBMANFHGGO inputSlot;

		[SerializeField]
		private bool allowDefaultValuePin;

		[SerializeField]
		private Transform overrideDefaultValuePinTransform;

public override EDBMANFHGGO? MyInputSlot
{
get 		{
			return null;
		}

}

public bool IsDefaultValuePinAllowed
{
get 		{
			return false;
		}

}

public Transform DefaultValuePinTransform
{
get 		{
			return null;
		}

}

public Vector3 DefaultValuePinScale
{
get 		{
			return default;
		}

}
	}
}
