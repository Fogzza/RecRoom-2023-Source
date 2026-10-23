using System;
using RecRoom.DataStructures;
using UnityEngine;

namespace RRUI
{
	public class SerializableIdentifier : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		private SerializedGuid guid;

public Guid Guid
{
get 		{
			return default;
		}

}

		protected void Reset()
		{
		}
	}
}
