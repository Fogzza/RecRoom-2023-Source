using AGUI.StackedUI;
using UnityEngine;

namespace RecRoom.AGUI.ToolUIs
{
	public class SpawnableToolButton : MonoBehaviour
	{
		[SerializeField]
		private ToolImposterUI toolImposterUI;

		[SerializeField]
		private RadioButton3D _radioButton;

		[SerializeField]
		private Tooltip tooltip;

public JBGFOIKBKED CurrentSpawnableTool
{
get 		{
			return JBGFOIKBKED.AC_UNIT;
		}

}

public RadioButton3D RadioButton
{
get 		{
			return null;
		}

}

public RadioButton3D.OnRadioButton3DClick ButtonAction
{
get 		{
			return null;
		}

}

		public void SetSpawnableTool(JBGFOIKBKED GPGEOGFOCMP, StackedUIBase HMDIBMJHHLN, float FHFDDKOBFLG = 0f)
		{
		}
	}
}
