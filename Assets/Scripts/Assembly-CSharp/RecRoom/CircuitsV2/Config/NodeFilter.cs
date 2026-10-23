using System;
using UnityEngine;

namespace RecRoom.CircuitsV2.Config
{
	[Serializable]
	public struct NodeFilter : ISerializationCallbackReceiver
	{
		[HideInInspector]
		[SerializeField]
		private string name;

		[SerializeField]
		public string[] FilterPath;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
