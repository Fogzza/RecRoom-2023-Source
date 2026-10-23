using UnityEngine;

namespace SA.Foundation.PropertyDrawers.Attributes
{
	public class SA_PD_SimpleSliderAttribute : PropertyAttribute
	{
		private float m_minLimit;

		private float m_maxLimit;

		private Color m_color;

		public float MinLimit => 0f;

		public float MaxLimit => 0f;

		public Color Color => default;

		public SA_PD_SimpleSliderAttribute(float minLimit, float maxLimit, float r, float g, float b)
		{
		}
	}
}
