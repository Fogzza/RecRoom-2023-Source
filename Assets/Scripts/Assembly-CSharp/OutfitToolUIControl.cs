using System;
using UnityEngine;
using UnityEngine.UI;

public class OutfitToolUIControl : MonoBehaviour
{
	[Flags]
	public enum CNAEOEHHMIH
	{
		None = 0,
		LevelLocked = 1,
		New = 2,
		Favorite = 4,
		Wearing = 8,
		PlatformLocked = 0x10
	}

	[SerializeField]
	private Text lockLevelText;

	[SerializeField]
	private GameObject lockPlatformText;

	[SerializeField]
	private Image lockIcon;

	[SerializeField]
	private GameObject newItemIcon;

	[SerializeField]
	private GameObject favoriteItemIcon;

	[SerializeField]
	private GameObject wearingItemIcon;

	private Vector3 MOHMCFDNHKH;

	[SerializeField]
	private CNAEOEHHMIH _state;

public CNAEOEHHMIH State
{
get 	{
		return CNAEOEHHMIH.None;
	}

set {
	}
}

	public void SetLockLevel(int OFMKJBIBDCL)
	{
	}

	public void UpdatePlacement(Tool IEGMBEPJMGC)
	{
	}
}
