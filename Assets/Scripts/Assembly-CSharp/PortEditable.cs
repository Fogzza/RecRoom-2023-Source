using System;
using AGUI.StackedUI;
using Circuits.Shared.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortEditable : CreationObjectSettingPropertyUIControl<Tuple<IAFGPKMBMBF, DGNNDGAENKL, IOKind>, PortEditable>
{
	[SerializeField]
	protected Image headerImage;

	[SerializeField]
	protected TextMeshProUGUI nameText;

	[SerializeField]
	protected Button3D configureButton;

	[SerializeField]
	protected Button3D deleteButton;

	public IAFGPKMBMBF CurrentNodeGroup;

	public DGNNDGAENKL CurrentPort;

	public IOKind IOKind;

	public void Button_Delete()
	{
	}

	public void Button_Configure()
	{
	}

	public void SetPortInfo(IAFGPKMBMBF NNFMALALIFF, DGNNDGAENKL DIKHIPHOFLP, IOKind FNHCAJMGKEP)
	{
	}
}
