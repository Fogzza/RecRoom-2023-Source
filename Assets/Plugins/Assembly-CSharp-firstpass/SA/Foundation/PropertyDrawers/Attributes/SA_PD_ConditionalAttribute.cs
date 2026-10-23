using UnityEngine;

namespace SA.Foundation.PropertyDrawers.Attributes
{
	public class SA_PD_ConditionalAttribute : PropertyAttribute
	{
		private string m_conditionalSourceField;

		private bool m_hideInInspector;

		public string ConditionalSourceField => null;

		public bool HideInInspector => false;

		public SA_PD_ConditionalAttribute(string conditionalSourceField)
		{
		}

		public SA_PD_ConditionalAttribute(string conditionalSourceField, bool hideInInspector)
		{
		}
	}
}
