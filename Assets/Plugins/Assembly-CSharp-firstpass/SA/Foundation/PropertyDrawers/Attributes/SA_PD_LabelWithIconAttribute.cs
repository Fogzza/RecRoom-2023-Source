using UnityEngine;

namespace SA.Foundation.PropertyDrawers.Attributes
{
	public class SA_PD_LabelWithIconAttribute : PropertyAttribute
	{
		private string m_iconPath;

		private string m_internalIconPath;

		private SA_PD_EditorIcons.IconType m_iconType;

		public string IconPath => null;

		public string InternalIconPath => null;

		public SA_PD_LabelWithIconAttribute(string iconPath)
		{
		}

		public SA_PD_LabelWithIconAttribute(SA_PD_EditorIcons.IconType icon)
		{
		}
	}
}
