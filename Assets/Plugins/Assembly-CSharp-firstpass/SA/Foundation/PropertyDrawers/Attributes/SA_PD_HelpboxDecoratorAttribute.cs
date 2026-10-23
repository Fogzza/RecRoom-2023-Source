using UnityEngine;

namespace SA.Foundation.PropertyDrawers.Attributes
{
	public class SA_PD_HelpboxDecoratorAttribute : PropertyAttribute
	{
		private string m_message;

		private SA_PD_MessageType m_type;

		public string Message => null;

		public SA_PD_MessageType Type => SA_PD_MessageType.None;

		public SA_PD_HelpboxDecoratorAttribute(SA_PD_MessageType type, string message = "")
		{
		}
	}
}
