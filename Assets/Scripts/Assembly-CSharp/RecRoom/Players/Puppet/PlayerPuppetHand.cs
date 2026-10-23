using System;
using UnityEngine;

namespace RecRoom.Players.Puppet
{
	public class PlayerPuppetHand : MonoBehaviour
	{
		[NonSerialized]
		public bool IsPointingMeshVisible;

		[NonSerialized]
		public bool IsThumbsUpActive;

		[NonSerialized]
		public float OpenCloseAxis;

		[NonSerialized]
		public bool IsHoldingTool;
	}
}
