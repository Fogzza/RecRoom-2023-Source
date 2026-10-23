using System;
using UnityEngine;

namespace RecRoom.Tutorials.Helpers
{
	[Serializable]
	public class ConditionalStringEntry
	{
		[SerializeField]
		private StringCondition condition;

		[TextArea]
		[SerializeField]
		private string value;

		public bool Valid => false;

		public string Value => null;
	}
}
