using System;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public class GamepadInputConfig : BaseInputConfig
	{
		[SerializeField]
		private MLMLNGCFECK gamepadDialogType;

		public SerializedGuid actionTypeId;

		public MLMLNGCFECK DefaultDialogType => MLMLNGCFECK.INVALID;
	}
}
