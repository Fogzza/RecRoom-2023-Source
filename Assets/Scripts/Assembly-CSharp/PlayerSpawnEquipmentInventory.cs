using System;

[Serializable]
public struct PlayerSpawnEquipmentInventory
{
	public Tool LeftHandTool;

	public string LeftHandToolSkinId;

	public Tool RightHandTool;

	public string RightHandToolSkinId;

	public Tool LeftHipSlotTool;

	public string LeftHipSlotSkinId;

	public Tool RightHipSlotTool;

	public string RightHipSlotSkinId;

	public Tool ShoulderSlotTool;

	public string ShoulderSlotSkinId;

	public static PlayerSpawnEquipmentInventory Default => default;
}
