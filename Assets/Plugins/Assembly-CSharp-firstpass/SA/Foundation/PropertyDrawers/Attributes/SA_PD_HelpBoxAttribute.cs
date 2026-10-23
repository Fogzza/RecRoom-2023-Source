using UnityEngine;

namespace SA.Foundation.PropertyDrawers.Attributes
{
	public class SA_PD_HelpBoxAttribute : PropertyAttribute
	{
		private SA_PD_MessageType m_type;

		public SA_PD_MessageType Type => SA_PD_MessageType.None;

		public SA_PD_HelpBoxAttribute(SA_PD_MessageType type)
		{
		}
	}
}
