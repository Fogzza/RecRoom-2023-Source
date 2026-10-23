using System;
using RecRoom.DataStructures;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public class KeyboardMouseInputConfig : BaseInputConfig
	{
		[SerializeField]
		private MLMLNGCFECK keyboardDialogType;

		public SerializedGuid actionTypeId;

		public MLMLNGCFECK DefaultDialogType => MLMLNGCFECK.INVALID;
	}
}
