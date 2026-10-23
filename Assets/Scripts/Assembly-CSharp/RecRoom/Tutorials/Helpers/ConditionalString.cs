using System;
using UnityEngine;

namespace RecRoom.Tutorials.Helpers
{
	[Serializable]
	public class ConditionalString
	{
		[SerializeField]
		[TextArea]
		private string defaultValue;

		[SerializeField]
		private ConditionalStringEntry[] entries;

		private string cachedValue;

		public string Value => null;
	}
}
