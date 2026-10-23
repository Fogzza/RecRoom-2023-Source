using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class HelpPopupConfigs : ScriptableObject
{
	[Serializable]
	public class HelpPopupConfig : RestrictedTypeConfig<CILEIOOHEOB, AssetReference, HardwareSpecificTextureSet, HardwareSpecicTexture>
	{
		public TutorialManager.DCOLLEIEDOJ HelpType;
	}

	[Serializable]
	public class HardwareSpecificTextureSet : SpecificRestrictionConfigSet<CILEIOOHEOB, HardwareSpecicTexture, AssetReference>
	{
	}

	[Serializable]
	public class HardwareSpecicTexture : SpecificRestrictionConfig<CILEIOOHEOB, AssetReference>
	{
	}

	[SerializeField]
	private HelpPopupConfig[] helpPopupConfigs;

	public global::EHOCIICLNGN<Texture2D> OAPFCCHMOEN(TutorialManager.DCOLLEIEDOJ NOKBGHMMPMF, CILEIOOHEOB? HJJCLNMFBMC = null)
	{
		return null;
	}
}
