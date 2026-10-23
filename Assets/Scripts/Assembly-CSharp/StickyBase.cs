using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Persistence;
using UnityEngine;

public abstract class StickyBase : MonoBehaviourPun, DJLCHGFCFAD, AAGHAEPCFKP
{
	private sealed class HPLPPFNPKGA
	{
		public StickyBase element;

		public bool alreadyInTree;

		internal void _003CTreeContainsElement_003Eb__0(StickyBase sticky)
		{
		}
	}

	private sealed class EOJJNIBIECP
	{
		public int size;

		internal void _003CTreeSize_003Eb__0(StickyBase node)
		{
		}
	}

	private sealed class KKDDCGDHMHM
	{
		public List<Collider> colliders;

		internal void _003CGatherTreeColliders_003Eb__0(StickyBase node)
		{
		}
	}

	private sealed class EJFBPPMCJLM
	{
		public List<Collider> colliders;

		internal void _003CGatherTreeCollidersIgnoreSubtree_003Eb__0(StickyBase node)
		{
		}
	}

	private sealed class LONJCFBIOIM
	{
		public List<Collider> colliders;

		internal void _003CGatherTreeCollidersIgnoreNode_003Eb__0(StickyBase node)
		{
		}
	}

	private static readonly List<Collider> PCJLDJHKOKD;

	private static readonly List<Collider> DKMOJHMOGNN;

	[SerializeField]
	private Tool _tool;

	[SerializeField]
	private bool onlyMasterCanAttach;

	[SerializeField]
	private bool disableCollidersWhenAttached;

	[SerializeField]
	private bool persistAttachment;

	[SerializeField]
	private bool attachOnRelease;

	[SerializeField]
	private bool alwaysKeepOriginalScaleOnDetach;

	private StickyBase HHFDFFDPCGO;

	private readonly List<StickyBase> OKKDPEMOHMC;

	private Action<Tool> KBJMINHLDAA__BackingField;

	private float? DGPNOHIGJMO;

	private bool PMOJGKJBPPP;

	private bool IMIKNDIHGID;

	private bool HMFIELANDAJ;

	private PhotonView FHGKKGOFFEM;

	private Tool JONGOFCGKPM;

	private Player ICEKNPKANKE;

	private global::MOBDJNEDDKC<bool> JDGOKNMOAOO;

	private bool PBKFEJDJKJF;

public Tool Tool
{
get 	{
		return null;
	}

}

public bool PauseCleanupOfAttachedTool
{
get 	{
		return false;
	}

set {
	}
}

public StickyBase TreeRoot
{
get 	{
		return null;
	}

}

public IReadOnlyList<StickyBase> Children
{
get 	{
		return null;
	}

}

public bool IsTreeRoot
{
get 	{
		return false;
	}

}

public Tool RootNonStickyTool
{
get 	{
		return null;
	}

}

public bool IsAttached
{
get 	{
		return false;
	}

private set {
	}
}

public bool IsAttachedToPhotonView
{
get 	{
		return false;
	}

private set {
	}
}

public PhotonView AttachedPhotonView
{
get 	{
		return null;
	}

private set {
	}
}

public Tool AttachedTool
{
get 	{
		return null;
	}

private set {
	}
}

public Player AttachedPlayer
{
get 	{
		return null;
	}

private set {
	}
}

public Vector3 AttachedRelativePosition
{
get 	{
		return default;
	}

}

public Quaternion AttachedRelativeRotation
{
get 	{
		return default;
	}

}

public bool ShouldAttachOnRelease
{
get 	{
		return false;
	}

}

private bool GKDIALNBJGA
{
get 	{
		return false;
	}

set {
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

public event Action<Tool> AttachedToolReset {
add {
	}
remove {
	}
}

	protected override void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void DBIFDAMOJEO(CHILKDJABBF HIGOLKPFBPL)
	{
	}

	private void HDPAMCBGIDB(Tool PMEFICGEDFK)
	{
	}

	protected abstract void OFEEICKPJDA();

	private void KOGFCNGAMLC(Tool PMEFICGEDFK)
	{
	}

	private void JNMPECPHFIJ()
	{
	}

	private void GGBKANLJGCH()
	{
	}

	protected virtual void PJJJHOBABJO()
	{
	}

	public virtual bool AuthorityTryAttach(PhotonView EILMGGLFNAK)
	{
		return false;
	}

	private void JNKHGCFIGFD(PhotonView EILMGGLFNAK, bool FPIHHFAAMFO, Vector3 GJGMLLFCOAD, Quaternion FLINFHACPCC)
	{
	}

	private void PMMMPDKPKHI(PhotonView EILMGGLFNAK, bool FPIHHFAAMFO, Vector3 GJGMLLFCOAD, Quaternion FLINFHACPCC)
	{
	}

	[PBOMGCLBFHF]
	protected void RpcMasterRequestChangeAttachmentToObject(PhotonView EILMGGLFNAK, bool FPIHHFAAMFO, Vector3 GJGMLLFCOAD, Quaternion FLINFHACPCC)
	{
	}

	private bool JLAEDJACBBO(CHILKDJABBF LJPJGJHNOGM, PhotonView EILMGGLFNAK)
	{
		return false;
	}

	public void AuthorityTryDetach()
	{
	}

	private void MDMDJPKMAHG(Tool IPLOENKLJMA, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
	{
	}

	protected static bool GBPNAKPOLPF(StickyBase BEBKGFJNPEG, StickyBase OFFJPOMOLDJ)
	{
		return false;
	}

	public static int TreeSize(StickyBase KPDGHDGLMHO)
	{
		return 0;
	}

	public static int TreeDepth(StickyBase BEBKGFJNPEG)
	{
		return 0;
	}

	public static void GatherTreeColliders(StickyBase KPDGHDGLMHO, List<Collider> GHKNKHCKPII)
	{
	}

	public static void GatherTreeCollidersIgnoreSubtree(StickyBase KPDGHDGLMHO, StickyBase DOJOEGAONAG, List<Collider> GHKNKHCKPII)
	{
	}

	public static void GatherTreeCollidersIgnoreNode(StickyBase KPDGHDGLMHO, StickyBase GELHJKCFLOO, List<Collider> GHKNKHCKPII)
	{
	}

	public static void GatherNodeColliders(StickyBase KNBPIEINLIG, List<Collider> GHKNKHCKPII)
	{
	}

	protected void JHBMCJBCCGO(StickyBase HHDCDGBODJA)
	{
	}

	protected void GNJNIECKPAP()
	{
	}

	public void RefreshIgnoredColliders()
	{
	}

	public static void IgnoreTreeColliders(StickyBase DLMFEPNOGID, StickyBase MCJACKGOJNG, bool CHEHHIMIPCJ)
	{
	}

	public static void IgnoreNodeColliders(StickyBase BEBKGFJNPEG, StickyBase KNBPIEINLIG, bool CHEHHIMIPCJ)
	{
	}

	public static void ToolIgnoreTreeColliders(Tool IEGMBEPJMGC, StickyBase NHHFDECALOD, bool CHEHHIMIPCJ)
	{
	}

	public static void ToolIgnoreNodeColliders(Tool IEGMBEPJMGC, StickyBase KNBPIEINLIG, bool CHEHHIMIPCJ)
	{
	}

	private static void PAHDGOMJDIN(Tool IEGMBEPJMGC, List<Collider> GHKNKHCKPII, bool CHEHHIMIPCJ)
	{
	}

	public static void TraverseTree(StickyBase KPDGHDGLMHO, Action<StickyBase> MCDNLHIFOLF)
	{
	}

	public static void TraverseTree(StickyBase KPDGHDGLMHO, StickyBase GELHJKCFLOO, bool BFNENOLGCNC, Action<StickyBase> MCDNLHIFOLF)
	{
	}

	public static string StickyTreeToString(StickyBase KPDGHDGLMHO, int PMPELHFMKFF = 0, int GADEOBMPDPB = 0)
	{
		return null;
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	public void PreDeserialize(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
	{
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	protected bool KNPGDKCKBGM(Guid JMIFIJDBMNM, out PersistenceView BPKCPPJDGIJ)
	{
		BPKCPPJDGIJ = null;
		return false;
	}

	[CompilerGenerated]
	private void KCIHFDDIEJF()
	{
	}
}
