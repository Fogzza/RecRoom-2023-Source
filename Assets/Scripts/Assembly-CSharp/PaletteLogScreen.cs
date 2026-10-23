using AGUI.StackedUI;
using RecRoom.Core.Creation.SandboxGizmos;
using UnityEngine;

public class PaletteLogScreen : MonoBehaviour
{
	[SerializeField]
	private ToggleButton3D showTimestampsButton;

	[SerializeField]
	private ToggleButton3D[] channelButtons;

	[SerializeField]
	private LogScreenModel _logScreenModel;

	private void Start()
	{
	}

	public void ToggleTimestamps(bool enable)
	{
	}

	public void ToggleChannel(int channel)
	{
	}

	public void ClearLogs()
	{
	}
}
