using System;
using AGUI.StackedUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeGroupEditable : CreationObjectSettingPropertyUIControl<Tuple<CCFFIDBNKOF, IAFGPKMBMBF>, NodeGroupEditable>
{
	[SerializeField]
	protected Image headerImage;

	[SerializeField]
	protected TextMeshProUGUI nameText;

	[SerializeField]
	protected Button3D configureButton;

	[SerializeField]
	protected Button3D deleteButton;

	[SerializeField]
	private Sprite sprite;

	public CCFFIDBNKOF CurrentChip;

	public IAFGPKMBMBF CurrentNodeGroup;

	public void Button_Delete()
	{
	}

	public void Button_Configure()
	{
	}

	public void SetNodeGroupInfo(CCFFIDBNKOF DKIOAGBBKDI, IAFGPKMBMBF NNFMALALIFF)
	{
	}
}
