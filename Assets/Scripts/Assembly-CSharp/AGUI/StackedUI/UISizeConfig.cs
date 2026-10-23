using System;
using UnityEngine;

namespace AGUI.StackedUI
{
	public class UISizeConfig : ScriptableObject
	{
		[Serializable]
		public class SizeDefinition
		{
			public OMNLIPPAPDI size;

			public Vector2 dimensions;
		}

		[Serializable]
		public class UISizeDefinitions
		{
			public string key;

			public SizeDefinition[] sizes;

			public OMNLIPPAPDI defaultVrSize;

			public OMNLIPPAPDI smallScreensSize;

			public OMNLIPPAPDI largeScreensSize;
		}

		public UISizeDefinitions[] sizeDefinitions;
	}
}
