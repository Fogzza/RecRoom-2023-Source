using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

[DisallowMultipleComponent]
public class ToolSkinMapper : MonoBehaviourPun, JCPJHDPNDKB
{
	[Serializable]
	public class MeshComponentMapping
	{
		public string name;

		public bool IsSkinned;

		public MeshFilter MeshFilter;

		public SkinnedMeshRenderer SkinnedMeshRenderer;

		public Mesh runtimeOriginalMesh;

		public Mesh SharedMesh
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}

	[Serializable]
	public class RendererMapping
	{
		public string name;

		public Renderer renderer;

		public Material[] runtimeOriginalMaterials;
	}

	[Serializable]
	public class GameObjectMapping
	{
		public string name;

		public GameObject gameObject;

		public GameObject runtimeInstantiatedPrefab;
	}

	private sealed class OMMBKMJBIDG
	{
		public GameObjectMapping currentMapping;

		internal bool _003CApplyGameObjectMappings_003Eb__0(EquipmentSkin.GameObjectActionMapping mapping)
		{
			return false;
		}

		internal bool _003CApplyGameObjectMappings_003Eb__1(EquipmentSkin.GameObjectActionMapping mapping)
		{
			return false;
		}
	}

	private sealed class FNMDPNIKFGK
	{
		public GameObjectMapping currentMapping;

		internal bool _003CRevertGameObjectMappings_003Eb__0(EquipmentSkin.GameObjectActionMapping mapping)
		{
			return false;
		}

		internal bool _003CRevertGameObjectMappings_003Eb__1(EquipmentSkin.GameObjectActionMapping mapping)
		{
			return false;
		}
	}

	private Action<EquipmentSkin> MKFDOLHHKLA__BackingField;

	public List<MeshComponentMapping> MeshMappings;

	public List<RendererMapping> RenderersMappings;

	public List<GameObjectMapping> GameObjectMappings;

	private TeamColorRenderer JLLPOLOKDHN;

	private Tool AEAKGNKFPDB;

	private global::MOBDJNEDDKC<string> CJODLHNFLEI;

	private EquipmentSkin LAJCDMIIJOH;

	private global::MOBDJNEDDKC<string> LJANNFICGID;

	private string GGHBMHPFCOJ;

	private EquipmentSkin JDMKOGIJAKC;

	[HideInInspector]
	public string PrefabName;

	[NonSerialized]
	public bool SuppressSkins;

	[SerializeField]
	private bool automaticallyApplySkinChangesWhenAttached;

	[SerializeField]
	private bool allowSkinResetOnToolReset;

	[SerializeField]
	private bool preventSkinResetOnToolResetWhenGameRunning;

public TeamColorRenderer TeamColorRenderer
{
get 	{
		return null;
	}

}

public Tool ThisTool
{
get 	{
		return null;
	}

private set {
	}
}

private string ADHLBACHFML
{
get 	{
		return null;
	}

set {
	}
}

public bool HasDefaultSkinOverride
{
get 	{
		return false;
	}

}

public EquipmentSkin DefaultSkinOverride
{
get 	{
		return null;
	}

private set {
	}
}

public string ActiveSkinGuid
{
get 	{
		return null;
	}

set {
	}
}

public string OriginalSkinGuid
{
get 	{
		return null;
	}

private set {
	}
}

public bool HasActiveSkin
{
get 	{
		return false;
	}

}

public EquipmentSkin ActiveSkin
{
get 	{
		return null;
	}

private set {
	}
}

public event Action<EquipmentSkin> ActiveSkinChanged {
add {
	}
remove {
	}
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

	private void PMNBLLMMDJK(CHILKDJABBF FBCDJHOIDJJ, string OPMFJJDMEKF)
	{
	}

	private void LMCLIFGBADO(Tool PMEFICGEDFK)
	{
	}

	private void JHAHCLLNLDO(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}

	private void HONEMBJKHAC()
	{
	}

	private void DABILIMODHE()
	{
	}

	public void SetDefaultSkinOverride(EquipmentSkin LAEEGJCPADH)
	{
	}

	public void ApplySkin(string GDHFIFPBNJH, bool PNHNKHHGMBB = false)
	{
	}

	public void ApplyLocalPlayerFavoriteSkin(bool PNHNKHHGMBB = false)
	{
	}

	private void KCFGEEGNAFH(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private void JADKGIFOHDK(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private void CPCPDAFMOJD(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private void OADNKOHHOCP(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private void KGONGEBAPOG(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private void NNBFMGNLMGN(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private void LOHLGLPOLKA(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private void MDOJOGFDIHI(EquipmentSkin FJMDMFGMFBH)
	{
	}

	private bool GAIKOGJCAOD(string GGOEPDCFDOE)
	{
		return false;
	}

	private void GLKBCCNFINJ(MNENEENPCFE HMJOKPKOPCN)
	{
	}

	void JCPJHDPNDKB.PrepareImposter(MNENEENPCFE HMJOKPKOPCN)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GLKBCCNFINJ
		this.GLKBCCNFINJ(HMJOKPKOPCN);
	}

	[CompilerGenerated]
	private void LIHAEAHLGCN()
	{
	}
}
