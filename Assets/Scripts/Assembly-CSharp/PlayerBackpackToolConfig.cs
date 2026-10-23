using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class PlayerBackpackToolConfig : HashableScriptableObject
{
	public enum MOAGENHCFPN
	{
		Head = 0,
		Feet = 1
	}

	[Serializable]
	public class Config : JMIIPNGAANF
	{
		public BKMDFCCNPGE ToolType;

		public string FriendlyName;

		public Tool Prefab;

		public Vector3 SpawnRotation;

		public Vector3 ImposterRotation;

		public bool CanToolBeFavorited;

		[SerializeField]
		private Texture2D customBackpackToolImage;

		[HideInInspector]
		[SerializeField]
		private AssetReference customBackpackToolImageReference;

		public MOAGENHCFPN SpawnPositionAnchor;

		public Vector3 SpawnLocationOffset;

		public Texture2D CustomBackpackToolImage => null;

		public AssetReference CustomBackpackToolImageReference => null;

		public bool OLJJHBDFPGM(out global::EHOCIICLNGN<Texture> HJJMEECNOIN)
		{
			HJJMEECNOIN = null;
			return false;
		}

		public void AppendToHash(IncrementalHash NDFMMDHCKFC)
		{
		}
	}

	public Config[] Configs;

	public Sprite favoriteIconToggledOn;

	public Sprite favoriteIconToggledOff;

	public override void AppendToHash(IncrementalHash NDFMMDHCKFC)
	{
	}
}
