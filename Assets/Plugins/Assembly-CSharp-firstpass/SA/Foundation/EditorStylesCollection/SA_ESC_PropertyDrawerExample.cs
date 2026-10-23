using SA.Foundation.PropertyDrawers.Attributes;
using UnityEngine;

namespace SA.Foundation.EditorStylesCollection
{
	public class SA_ESC_PropertyDrawerExample : MonoBehaviour
	{
		[Space]
		[Multiline]
		[SerializeField]
		private string m_multilineString;

		[TextArea]
		public string m_textAreaString;

		[SerializeField]
		private int m_intRange;

		[SerializeField]
		private float m_floatRange;

		[SerializeField]
		private float m_hoverMouseToSeeTooltip;

		[Space]
		public float m_simpleSlider;

		public Vector2 m_MinMaxSlider;

		public string myHelpBox;

		public string myString;

		[SA_PD_StandartInsertionDecorator]
		[Space]
		[SA_PD_PRInsertionDecorator]
		[SA_PD_ThingInsertionDecorator]
		[Space]
		[Space]
		[Space]
		public string indentLevel;

		public string indentLevel1;

		public string indentLevel2;

		[Space]
		public bool showBelowSettings;

		public float range;

		public bool isExists;

		public AnimationCurve curve;

		[Space]
		public bool enableBelowSettings;

		public bool firstSettings;

		public float secondSettigs;

		[Space]
		public string myLabel;

		public string favoriteLabel;
	}
}
