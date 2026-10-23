using System.Collections.Generic;

public static class SA_PD_EditorIcons
{
	public enum IconType
	{
		GameObject = 0,
		Favorite = 1,
		Prefab = 2,
		GameManager = 3,
		Dragdot = 4,
		DragdotActive = 5,
		DragdotDimmed = 6,
		Dropdown = 7,
		d_winbtn_mac_close = 8,
		d_winbtn_mac_close_a = 9,
		d_winbtn_mac_close_h = 10,
		d_winbtn_mac_inact = 11,
		d_winbtn_mac_max = 12,
		d_winbtn_mac_max_h = 13,
		d_winbtn_mac_min = 14,
		d_winbtn_mac_min_h = 15,
		d_winbtn_win_close = 16,
		DefaultAsset = 17,
		DllScript = 18,
		DistanceJoint2D = 19,
		FilterByLabel = 20,
		FilterByType = 21,
		Fixedjoint = 22,
		FlareLayer = 23,
		FrictionJoint2D = 24,
		GUIText = 25,
		HingeJoint2D = 26,
		Image = 27,
		LightProbeProxyVolume = 28,
		LightProbeGroup = 29,
		LineRenderer = 30,
		LayoutElement = 31,
		Light = 32,
		LensFlare = 33
	}

	private static Dictionary<IconType, string> m_internalIcons;

	public static string GetInternalStringPathOfEnumValue(IconType type)
	{
		return null;
	}
}
