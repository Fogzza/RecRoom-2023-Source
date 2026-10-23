using RecRoom.Tools;
using TMPro;
using UnityEngine;

namespace AGUI.StackedUI
{
	public abstract class BaseCreationObjectSettingPropertyUIControl : MonoBehaviour
	{
		public TextMeshProUGUI PropertyDescription;

		public TextMeshProUGUI PropertyValueText;

		private MakerPen GBBHEKOPNIM;

public MakerPen MakerPen
{
get 		{
			return null;
		}

set {
		}
}

		public abstract void UpdateControl();
	}
}
