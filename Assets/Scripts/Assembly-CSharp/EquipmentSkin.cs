using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSkin : AvatarSelectionElement
{
	[Serializable]
	public class MeshAssetMapping
	{
		public string name;

		public Mesh mesh;

		public bool IsValid => false;

		public bool OFPEIHMPLIL(MeshAssetMapping HNPEBINPOBO)
		{
			return false;
		}
	}

	[Serializable]
	public class MaterialsMapping
	{
		public string name;

		public Material[] materials;

		public bool IsValid => false;

		public bool OFPEIHMPLIL(MaterialsMapping HNPEBINPOBO)
		{
			return false;
		}
	}

	[Serializable]
	public class GameObjectActionMapping
	{
		public enum FHJGDFJBOGD
		{
			None = 0,
			Enable = 1,
			Disable = 2,
			Instantiate = 3
		}

		public string name;

		public FHJGDFJBOGD action;

		public GameObject prefabToInstantiate;
	}

	public List<MeshAssetMapping> MeshMappings;

	public List<MaterialsMapping> MaterialMappings;

	public List<GameObjectActionMapping> GameObjectActionMappings;

	public bool LMFOMLJAGJN(List<MeshAssetMapping> MEHFHDLHDII, List<MaterialsMapping> PPCHAEMIJLK)
	{
		return false;
	}
}
