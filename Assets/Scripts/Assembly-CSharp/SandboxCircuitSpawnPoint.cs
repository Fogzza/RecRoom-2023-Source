using System.Collections.Generic;
using System.Text;
using RecRoom.Core.Creation;
using UnityEngine;

public class SandboxCircuitSpawnPoint : GameSpawnPoint, DJLCHGFCFAD
{
	public enum MPJMCNPEMDD
	{
		Point = 0,
		Area = 1
	}

	public enum CFHMHCLFEHF
	{
		DURING_GAME = 0,
		PRE_POST_GAME = 1,
		MANUAL = 2
	}

	private const EDBMANFHGGO COFICGDHFMI = EDBMANFHGGO.R;

	private const EDBMANFHGGO NGPHCJOPGDD = EDBMANFHGGO.G;

	private Dictionary<MPJMCNPEMDD, float> GKPCEKHNDFI;

	private MaterialPropertyBlock HOOJEGOGAPE;

	[SerializeField]
	private MeshRenderer baseMesh;

	[SerializeField]
	private MeshRenderer beamMesh;

	private CreationObject BPEGJLIMPPJ;

	[SerializeField]
	private Color unwiredMeshColor;

	private bool MEODPKPHAHD;

	private global::MOBDJNEDDKC<int> EEINBJGENJE;

	private global::MOBDJNEDDKC<float> ABOJHEAEDOL;

	private global::MOBDJNEDDKC<string> NJHOPABKPKG;

	private global::MOBDJNEDDKC<bool> GNANMKKCABJ;

	private global::MOBDJNEDDKC<int> DOAHPEDOCFN;

	private global::MOBDJNEDDKC<string> AKEPPHMDBLC;

	private global::MOBDJNEDDKC<bool> FMJALLEECOM;

	private global::MOBDJNEDDKC<bool> IMNBLKDLNHJ;

public GIBEGHKMCIE SettingsConfiguredGameTeam
{
get 	{
		return GIBEGHKMCIE.TEAM_1;
	}

set {
	}
}

public float SpawnPrecisionRadius
{
get 	{
		return 0f;
	}

set {
	}
}

public string PrimaryHandHeldTag
{
get 	{
		return null;
	}

set {
	}
}

public bool PrimaryHandTakeFromHolder
{
get 	{
		return false;
	}

set {
	}
}

public CFHMHCLFEHF SpawnPointPurpose
{
get 	{
		return CFHMHCLFEHF.DURING_GAME;
	}

set {
	}
}

public string SecondaryHandHeldTag
{
get 	{
		return null;
	}

set {
	}
}

public bool SecondaryHandTakeFromHolder
{
get 	{
		return false;
	}

set {
	}
}

public bool KeepHeldTools
{
get 	{
		return false;
	}

set {
	}
}

protected override Color BAFJOOPEPHO
{
get 	{
		return default;
	}

}

public bool BlockObjectPersistance
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

	public override bool IsBlockedAtPosition(Vector3 INLGLHIPOMC)
	{
		return false;
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void SandboxCircuitSpawnPointTeam_Set(int DLEMNBPMGBG)
	{
	}

	public int SandboxCircuitSpawnPointTeam_Get()
	{
		return 0;
	}

	public void SpawnPointPrecision_Set(int DLEMNBPMGBG)
	{
	}

	public int SpawnPointPrecision_Get()
	{
		return 0;
	}

	public void PrimaryHandToolHeld_Set(string DLEMNBPMGBG)
	{
	}

	public string PrimaryHandToolHeld_Get()
	{
		return null;
	}

	public void SpawnPointPurpose_Set(int DLEMNBPMGBG)
	{
	}

	public int SpawnPointPurpose_Get()
	{
		return 0;
	}

	public void PrimaryHandPoliteRespawn_Set(bool DLEMNBPMGBG)
	{
	}

	public bool PrimaryHandPoliteRespawn_Get()
	{
		return false;
	}

	public void SecondaryHandToolHeld_Set(string DLEMNBPMGBG)
	{
	}

	public string SecondaryHandToolHeld_Get()
	{
		return null;
	}

	public void SecondaryHandPoliteRespawn_Set(bool DLEMNBPMGBG)
	{
	}

	public bool SecondaryHandPoliteRespawn_Get()
	{
		return false;
	}

	public void KeepHeldTools_Set(bool DLEMNBPMGBG)
	{
	}

	public bool KeepHeldTools_Get()
	{
		return false;
	}

	private void CBABLKKHPKH(bool GNGKKJPOAPJ)
	{
	}

	private void AODIDOBMEPD()
	{
	}

	private void IAGIJENAOFA()
	{
	}

	private void LFJDGCFLMNN()
	{
	}

	public void UpdateRespawnConfiguration(Dictionary<EDBMANFHGGO, int> updates)
	{
	}

	private void FMCJBBLEPPK()
	{
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}
}
