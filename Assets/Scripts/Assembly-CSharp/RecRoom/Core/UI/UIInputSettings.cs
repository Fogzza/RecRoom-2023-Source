using UnityEngine;

namespace RecRoom.Core.UI
{
	public class UIInputSettings : MonoBehaviour
	{
		[SerializeField]
		private bool isInteractableWhileHoldingTool;

		[SerializeField]
		private string buttonPromptOverride;

		[SerializeField]
		private bool suppressButtonPrompt;

		[SerializeField]
		private bool suppressPointAnimation;

public bool IsInteractableWhileHoldingTool
{
get 		{
			return false;
		}

}

public string ButtonPromptOverride
{
get 		{
			return null;
		}

}

public bool SuppressButtonPrompt
{
get 		{
			return false;
		}

set {
		}
}

public bool SuppressPointAnimation
{
get 		{
			return false;
		}

set {
		}
}
	}
}
