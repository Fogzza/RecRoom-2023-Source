using UnityEngine;

namespace SA.Foundation.PropertyDrawers.Attributes
{
	public class SA_PD_IndentLevelAttribute : PropertyAttribute
	{
		private int m_indentLevel;

		public int IndentLevel => 0;

		public SA_PD_IndentLevelAttribute(int indentLevel)
		{
		}
	}
}
