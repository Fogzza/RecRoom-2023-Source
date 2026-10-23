using System;
using UnityEngine;

namespace RecRoom.Inputs
{
	public class ScreenControlsMap : ScriptableObject
	{
		public enum BDJEPCJEKDP
		{
			CONCRETE = 0,
			VIRTUAL = 1
		}

		[Serializable]
		public class Control
		{
			public string name;

			public BDJEPCJEKDP type;

			public string[] concreteControlNames;

			public ControlConfig config;
		}

		public ControlSettings globalControlSettings;

		public Control[] controls;
	}
}
