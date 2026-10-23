using System;
using UnityEngine;

public class ShaderVariantCollectionWarmup : SingletonMonoBehaviour<ShaderVariantCollectionWarmup>
{
	[Serializable]
	public class HardwareSpecificVariantCollection
	{
		public CILEIOOHEOB HardwareType;

		public ShaderVariantCollection VRModeShaderVariantCollection;

		public ShaderVariantCollection ScreensModeShaderVariantCollection;
	}

	[SerializeField]
	private HardwareSpecificVariantCollection[] hardwareSpecificVariantCollections;

	public void WarmUpHardwareSpecificShaders(bool FFFFMGPJDOC)
	{
	}
}
