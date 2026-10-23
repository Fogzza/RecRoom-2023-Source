using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class InputControllerSpecificSprite : MonoBehaviour
{
	public enum EFGBNJHBEGG
	{
		Basic = 1,
		All = 2
	}

	[Serializable]
	public class InputControllerSpriteMapping
	{
		public GHOAEFHGEDM InputControllerType;

		public AssetReference AssetReference;
	}

	private static bool OEAONLGBBPN;

	private static GHOAEFHGEDM CGKJPGPGJDN;

	[SerializeField]
	private Image Image;

	[SerializeField]
	private AssetReference DefaultSprite;

	[SerializeField]
	private List<InputControllerSpriteMapping> InputControllerSpriteMappings;

	private global::EHOCIICLNGN<Sprite> NJNKONAMKLJ;

private static GHOAEFHGEDM CPJCBLHHOIK
{
get 	{
		return GHOAEFHGEDM.Unknown;
	}

}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetSprite(GHOAEFHGEDM IIBNLGNOFHN)
	{
	}

	public void Cleanup()
	{
	}

	[CompilerGenerated]
	private void MPOFMJHFLCB(Sprite DLADPCHJMME)
	{
	}
}
