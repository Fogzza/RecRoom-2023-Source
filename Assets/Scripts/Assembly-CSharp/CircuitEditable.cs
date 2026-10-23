using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CircuitEditable : MonoBehaviour
{
	[SerializeField]
	protected Image headerImage;

	[SerializeField]
	protected TextMeshProUGUI nameText;

	[SerializeField]
	protected Button3D configureButton;

	[SerializeField]
	protected Button3D deleteButton;

	public abstract void Button_Delete();

	public abstract void Button_Configure();
}
