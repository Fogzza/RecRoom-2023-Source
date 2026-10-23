using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AGUI.StackedUI;
using Photon.Pun;
using RecRoom.Core.Creation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom
{
	public class ShowcasePosterController : MonoBehaviourPun, DJLCHGFCFAD, JCPJHDPNDKB
	{
		private enum OHMPEHNJOGM
		{
			TypeIcon = 0,
			TargetImage = 1
		}

		private enum BMMOGAKFCBD
		{
			NotConfigured = 0,
			ConfigureContent = 1,
			TargetMissing = 2,
			Active = 3
		}

		[SerializeField]
		private SandboxColorable colorable;

		[SerializeField]
		private RigidbodyEx rigidBodyEx;

		[SerializeField]
		private TMP_Text imposterText;

		[SerializeField]
		private TMP_Text posterName;

		[SerializeField]
		private TMP_Text labelText;

		[SerializeField]
		private Image typeIcon;

		[SerializeField]
		private RawImage targetImage;

		[SerializeField]
		private Transform targetImageRoot;

		[SerializeField]
		private Renderer[] renderers;

		[SerializeField]
		private Sprite notConfiguredTypeIcon;

		[SerializeField]
		private OHMPEHNJOGM displayMode;

		[SerializeField]
		private Color deactivatedColor;

		[SerializeField]
		private Transform posterFrame;

		[SerializeField]
		private Transform[] posterCorners;

		[SerializeField]
		private Transform[] posterEdges;

		[SerializeField]
		private Transform posterCase;

		[SerializeField]
		private int settingsPriority;

		[SerializeField]
		private GameObject[] canvasElementsP1;

		[SerializeField]
		private GameObject[] canvasElementsP2;

		[SerializeField]
		private GameObject[] canvasElementsP0;

		[SerializeField]
		private float LODSize0;

		[SerializeField]
		private float LODSize1;

		[SerializeField]
		private float LODSize2;

		private global::MOBDJNEDDKC<NHGKMDCGGIM> PANLMPDMCKG;

		private global::MOBDJNEDDKC<long> PACFOLBJLAK;

		private global::MOBDJNEDDKC<int> LMCPAOHFDNH;

		private IDisposable NDJNOLAABAH;

		private bool KLMIBAMJMPO;

		private bool IAPIDBHJDJO;

		private bool JPNFOPPJPJC;

		private AKCHPHOMHLH GPKIMMMPFMA;

		private CreationObject BPEGJLIMPPJ;

		private MaterialPropertyBlock HOOJEGOGAPE;

		private static Material OAHNIDOOLHG;

		private static Material NNKILCFHPGP;

		private Camera KNGJEGJDCMC;

		private Renderer AJOIEOAIBAP;

		private AMBBOEBJPNH GIJHKBGMDBM;

		private float FGPJHKCLEEG;

		private ALCGFACOHOF PNKPONLLDFA;

		private readonly Dictionary<NHGKMDCGGIM, ALCGFACOHOF> INJEKDLJGCN;

		private static readonly int KOHONNBKAEA;

		private static CreationObjectSettingFriendlyFlagsControl HKAJONNFNFC;

		private const int HFMKFDOPPJP = 15;

public NHGKMDCGGIM ContentType
{
get 		{
			return NHGKMDCGGIM.Uninitialized;
		}

set {
		}
}

public long ContentTargetId
{
get 		{
			return 0L;
		}

set {
		}
}

public NFMBFHFPDOA DisplayFlag
{
get 		{
			return NFMBFHFPDOA.None;
		}

set {
		}
}

private IDisposable NOIBNEGIPPL
{
get 		{
			return null;
		}

set {
		}
}

private bool CAEFCEKEJHP
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		protected override void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void EJKFBNIADFG()
		{
		}

		public DGMPBIPKJEB GetDynamicDisplayFlagConfiguration()
		{
			return null;
		}

		private void DCNLKDCLEIA()
		{
		}

		private void EKAPDAEHAOF(long IKHNIJKGJFD)
		{
		}

		private void NKMGIPBKOEF()
		{
		}

		private void KNCPEEEHOBI()
		{
		}

		private void BJCALJMDDPJ(bool HHBGEDKOPFA)
		{
		}

		private void GPDKBMACAFH()
		{
		}

		private void KDKMAIOGPCA(BMMOGAKFCBD IKGPIJDJGPL)
		{
		}

		private void HPKHJNPKMCJ()
		{
		}

		private void ANCKEIICMID()
		{
		}

		private void PHAHNKPBGFB()
		{
		}

		public void PrepareImposter(MNENEENPCFE HMJOKPKOPCN)
		{
		}

		public void SetFrameElements(GameObject CECLGJEOAPE, float MAPNJIMLAMD)
		{
		}

		private void KBEJKHOGPOD(AMBBOEBJPNH IJOJMGHMFHL, AMBBOEBJPNH HHJDHBDPCNN)
		{
		}

		private void NBLAKMJLBPP(float OKBAJEAPIHG)
		{
		}

		private void KKAHLBFJEIN()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private int CDFLBFDLIHP()
		{
			return 0;
		}

		[CompilerGenerated]
		private void BHIIIOIGDIE(int IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private int DNKMMHGHHLK()
		{
			return 0;
		}

		[CompilerGenerated]
		private void JEDEGGGDKPN(int IPMIIEAGJKC)
		{
		}
	}
}
