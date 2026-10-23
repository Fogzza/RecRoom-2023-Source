using System;
using System.Security.Cryptography;
using RecRoom;
using RecRoom.Core.Creation;
using RecRoom.DataStructures;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public abstract class SpawnableToolConfig : JMIIPNGAANF
{
	public SerializedGuid UniqueId;

	public string UniqueName;

	public string FriendlyName;

	public string Description;

	public string[] DefaultTagNames;

	public Vector3 SpawnPositionOffset;

	public Vector3 SpawnRotation;

	public float SpawnUniformScale;

	public Vector3 UIRotation;

	public Color ColorOverride;

	public GIBEGHKMCIE TeamOverride;

	public bool AvailableInSpawner;

	public bool AvailableInMakerPen;

	public bool UseCustomPaletteImage;

	public ANOEOICCMDH Category;

	public bool AvailableToDevsOnly;

	public bool CanSaveIntoInventions;

	public bool LimitInventionSaveForJuniors;

	public bool FirstInstanceIsFree;

	[EFEFIKFHIDK]
	public CostInfo SandboxResourceCost;

	public CircuitNodeType CircuitNodeType;

	public PNDAHJMHLMI ToolConnectability;

	public bool IsGadget;

	public bool IsBetaItem;

	public bool IsMakerPenIntroItem;

	[HNDJNPOHFJK]
	public string MakerPenIntroItemId;

	[SerializeField]
	public int LegacyPriority;

	public bool ExcludeFromTriggerVolume;

	public bool RangedWeaponsMisfireOnOverlap;

	[SerializeField]
	[HideInInspector]
	protected AssetReference paletteImageReference;

	public abstract global::NCOKFFGPIJM<Tool> PrefabPromise { get; }

	public AssetReference PaletteImageReference => null;

	public global::EHOCIICLNGN<Texture> DFMNPJJNFCD()
	{
		return null;
	}

	public virtual void AppendToHash(IncrementalHash NDFMMDHCKFC)
	{
	}
}
