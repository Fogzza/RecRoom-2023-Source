using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.UI;
using UnityEngine;

public class PhysicalTextLabel : MonoBehaviourPun, DJLCHGFCFAD, JICDMECOFLC
{
	private const float FOHKPBNOBAJ = 0.05f;

	private const float BJLHLJLEALJ = 50f;

	private const int LAKHBFFLBOC = 0;

	private const int MDDKCGDDKPP = 25;

	[SerializeField]
	private PlayerEditableTextBase editableText;

	[SerializeField]
	private PhysicalTextSource textSource;

	[SerializeField]
	private Tool tool;

	[SerializeField]
	private Transform backerTransform;

	[SerializeField]
	private Transform leftPivot;

	[SerializeField]
	private Transform rightPivot;

	[SerializeField]
	private Transform centerPivot;

	[SerializeField]
	private BoxCollider textBoundsCollider;

	[SerializeField]
	private Transform circuitConnectionsTransform;

	[SerializeField]
	private CircuitNodeDisplay circuitNodeDisplay;

	[SerializeField]
	private EDBMANFHGGO hiddenInputSlot;

	[SerializeField]
	private int settingsPriority;

	[SerializeField]
	private CreationObject creationObject;

	[SerializeField]
	private FaceCamera billboardBehaviour;

	private Vector3 BBBNCPIMFOC;

	private bool OFKAICCEMLP;

	private global::MOBDJNEDDKC<GCNPLJCMHED> KOCICHPEMED;

	private global::MOBDJNEDDKC<float> OEHIFGCPOPF;

	private global::MOBDJNEDDKC<int> AKJEBDMCAPO;

	private global::MOBDJNEDDKC<int> OENONCFOMMP;

	private global::MOBDJNEDDKC<bool> OBAOLJPGHAD;

	private global::MOBDJNEDDKC<bool> GPIOHLFBPJC;

public GCNPLJCMHED HorizontalAlignment
{
get 	{
		return GCNPLJCMHED.Left;
	}

set {
	}
}

public float TextThickness
{
get 	{
		return 0f;
	}

set {
	}
}

public int CharacterSpacing
{
get 	{
		return 0;
	}

set {
	}
}

public int LineSpacing
{
get 	{
		return 0;
	}

set {
	}
}

public bool Billboard
{
get 	{
		return false;
	}

set {
	}
}

public bool BillboardPitch
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

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void OnCircuitInputUpdated(Dictionary<EDBMANFHGGO, int> input)
	{
	}

	private void FOJBMPOBJAI(string HLIGBKANEEA)
	{
	}

	private void OIPJOHPAKEB()
	{
	}

	private void EDKKGIMAMBL()
	{
	}

	private void NFCJHDJANLA()
	{
	}

	private void MPKGANHDPBD()
	{
	}

	private void DAHOPEDKLKE()
	{
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	public IReadOnlyList<DGMPBIPKJEB> GetConfigurableDynamicUI(List<JICDMECOFLC> OKGFHDGAPBM = null)
	{
		return null;
	}

	[CompilerGenerated]
	private bool FIPKPOFNNDH()
	{
		return false;
	}

	[CompilerGenerated]
	private void BBDIDAEEBAG(bool IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private int ELEKHNGGJDP()
	{
		return 0;
	}

	[CompilerGenerated]
	private void AMGKMJGFCBO(object IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private bool BNEOKPFFDBI()
	{
		return false;
	}

	[CompilerGenerated]
	private void HPLEEDBAEGI(bool IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private float IILPIAOLBEK()
	{
		return 0f;
	}

	[CompilerGenerated]
	private void JPCGGFPJLAE(float IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private bool DAEEEOBKEFM()
	{
		return false;
	}

	[CompilerGenerated]
	private int OBJALOGBJEI()
	{
		return 0;
	}

	[CompilerGenerated]
	private void PNDCEOENMLG(int IPMIIEAGJKC)
	{
	}

	[CompilerGenerated]
	private int CKODEDCPEEK()
	{
		return 0;
	}

	[CompilerGenerated]
	private void MGKJMLCMAJC(int IPMIIEAGJKC)
	{
	}
}
