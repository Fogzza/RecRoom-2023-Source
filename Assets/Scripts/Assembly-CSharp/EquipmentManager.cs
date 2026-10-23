using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class EquipmentManager : NetworkedSingletonMonoBehaviour<EquipmentManager>, CNLHIEAHCBL
{
	private sealed class MDKILJIOKIF
	{
		public string equipmentPrefabName;

		public string equipmentModificationGuid;

		public EquipmentManager _003C_003E4__this;

		internal global::NCOKFFGPIJM<FFNCPFGBPND> _003CUpdateUnlockedEquipmentsFor_003Eb__0(List<FFNCPFGBPND> unlockedEquipments)
		{
			return null;
		}

		internal void _003CUpdateUnlockedEquipmentsFor_003Eb__1(FFNCPFGBPND equipment)
		{
		}

		internal void _003CUpdateUnlockedEquipmentsFor_003Eb__2(string error)
		{
		}
	}

	public const string PLAYER_SPAWNED_EQUIPMENT_PURPOSE_PARAM_NAME = "Purpose";

	private Action<FFNCPFGBPND> ENEDOHEKHEG__BackingField;

	private Action<CHILKDJABBF, string> MCKAEKHPNKO__BackingField;

	private List<FFNCPFGBPND> PJIEFNPGAOB;

	private Dictionary<string, FFNCPFGBPND> CPEIDOMCPHO;

	private Dictionary<string, (FFNCPFGBPND, bool)> BGGNCMGINCG;

	private List<FFNCPFGBPND> DONGLALIHFL;

	private IDisposable CNAGCKBFLOE;

public List<FFNCPFGBPND> UnlockedEquipments
{
get 	{
		return null;
	}

private set {
	}
}

public Dictionary<string, FFNCPFGBPND> FavoriteEquipments
{
get 	{
		return null;
	}

private set {
	}
}

public event Action<FFNCPFGBPND> NewEquipmentUnlocked {
add {
	}
remove {
	}
}

public event Action<CHILKDJABBF, string> FavoriteEquipmentChanged {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public bool IsAssetHashValid()
	{
		return false;
	}

	[CanBeNull]
	public Tool SpawnEquipmentForLocalPlayer([NotNull] FFNCPFGBPND MPLIANHHNHG, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO, PlayerSpawnedEquipment.NHMNGDFJFCC LODOMOIPMIL)
	{
		return null;
	}

	[CanBeNull]
	private Tool BFEKOPIGJAN(string PEGANFDBJPA, string GGOEPDCFDOE, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO, PlayerSpawnedEquipment.NHMNGDFJFCC LODOMOIPMIL)
	{
		return null;
	}

	public Tool LocalFind(FFNCPFGBPND CKAPBBGHJEC, PlayerSpawnedEquipment.NHMNGDFJFCC LODOMOIPMIL)
	{
		return null;
	}

	public LAHBDKNMNHN DownloadUnlockedEquipments()
	{
		return null;
	}

	public FFNCPFGBPND LocalGetEquipmentFromTool(Tool IEGMBEPJMGC)
	{
		return null;
	}

	public FFNCPFGBPND GetEquipment(ToolSkinMapper DEPNGCPJEJJ)
	{
		return null;
	}

	public string GetFavoriteEquipmentSkin(ToolSkinMapper DEPNGCPJEJJ)
	{
		return null;
	}

	public string GetFavoriteEquipmentSkin(string PEGANFDBJPA)
	{
		return null;
	}

	public FFNCPFGBPND GetFavoriteEquipment(string PEGANFDBJPA)
	{
		return null;
	}

	public FFNCPFGBPND GetFavoriteEquipment(ToolSkinMapper DEPNGCPJEJJ)
	{
		return null;
	}

	public void ToggleFavoriteEquipment(ToolSkinMapper DEPNGCPJEJJ)
	{
	}

	public void ToggleFavoriteEquipment(FFNCPFGBPND CKAPBBGHJEC, string PEGANFDBJPA, bool DJDKMNIHNJF = true)
	{
	}

	public void PreviewFavorite(FFNCPFGBPND CKAPBBGHJEC, bool DJDKMNIHNJF = true)
	{
	}

	public void RevertPreviewedFavorite(string PEGANFDBJPA, bool DJDKMNIHNJF = true)
	{
	}

	private void PEDCIAGAKPE()
	{
	}

	public bool IsAlreadyPurchased(string JMIFIJDBMNM, bool ENOBONIDIEH = true)
	{
		return false;
	}

	public void UpdateUnlockedEquipmentsFor(string GAEDFELDFJC, string GNMCKHPODDF)
	{
	}

	public void RevokeUnlockedEquipmentsFor(string GAEDFELDFJC, string GNMCKHPODDF)
	{
	}

	private bool FJPPDPHNCPG(string GAEDFELDFJC, string GNMCKHPODDF)
	{
		return false;
	}

	private bool EDOBKBJAFOA(string GAEDFELDFJC, string GNMCKHPODDF)
	{
		return false;
	}

	private void DPNPCEFCGJL(Tool IEGMBEPJMGC)
	{
	}

	[CompilerGenerated]
	private void DALBCJPKJLF(List<FFNCPFGBPND> DOKKHPBAEKE)
	{
	}
}
