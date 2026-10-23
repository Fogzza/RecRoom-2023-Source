using System;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public class LogChannelColors : ScriptableObject
	{
		[Serializable]
		internal class ChannelColorDictionary : EditableSerializedDictionary<AIMNMBLLDFJ, Color, ChannelColorDictionary.Kvp>
		{
			[Serializable]
			public sealed class Kvp : SerializedKeyVal<AIMNMBLLDFJ, Color>
			{
			}
		}

		[SerializeField]
		private ChannelColorDictionary channelColors;

		public Color OBEIEBKKCGL(AIMNMBLLDFJ LAEAGAJDAFO)
		{
			return default;
		}
	}
}
