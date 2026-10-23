using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPlatformSpecificSprite : MonoBehaviour
{
	public enum MOACLKCKPIC
	{
		UNKNOWN = -1,
		STEAM_VR = 0,
		OCULUS = 1,
		PS_VR = 2,
		MKB = 100,
		XBOX = 101,
		DUAL_SHOCK = 102,
		TOUCH_SCREEN = 103,
		DUAL_SENSE = 104
	}

	[Serializable]
	public class InputPlatformSpriteMapping
	{
		public MOACLKCKPIC InputPlatformType;

		public Sprite sprite;
	}

	private static bool OEAONLGBBPN;

	private static MOACLKCKPIC NBBMNANFJDJ;

	[SerializeField]
	private Image Image;

	[SerializeField]
	private Sprite defaultSprite;

	[SerializeField]
	private List<InputPlatformSpriteMapping> InputPlatformSpriteMappings;

private static MOACLKCKPIC FPIOFOJOCDI
{
get 	{
		return MOACLKCKPIC.STEAM_VR;
	}

}

	private void OnEnable()
	{
	}

	public void SetSprite(MOACLKCKPIC LLBFFBODDID)
	{
	}
}
