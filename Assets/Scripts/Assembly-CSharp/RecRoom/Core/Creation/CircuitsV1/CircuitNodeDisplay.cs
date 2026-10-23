using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using RecRoom.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class CircuitNodeDisplay : MonoBehaviourPun, DJLCHGFCFAD, JCPJHDPNDKB
	{
		[Serializable]
		public class InputSlotDisplayConfig
		{
			public EDBMANFHGGO InputSlot;

			public CircuitInputConnectionPoint IOSlot;
		}

		[Serializable]
		public class OutputSlotDisplayConfig
		{
			public BHEOAPLBNIE OutputSlot;

			public CircuitOutputConnectionPoint IOSlot;
		}

		public static readonly List<CircuitNodeDisplay> AllDisplays;

		private NNBAJLCGAOK JGEGKOOCOEH;

		public static readonly int IconTexScaleOffsetPropertyId;

		public static readonly int PinMaskPropertyId;

		protected readonly List<DGMPBIPKJEB> JHPGGBJELFG;

		private BNOPDNILAFA GHJILCDKCEF;

		private Action OLMFBMMOPPI__BackingField;

		public EEANDDJEMJC OnConnectionVisibilityChanged;

		private FIHGBEHGLGB BEEGLJGBNJK;

		public Dictionary<EDBMANFHGGO, CircuitInputConnectionPoint> InputSlotDisplays;

		public Dictionary<BHEOAPLBNIE, CircuitOutputConnectionPoint> OutputSlotDisplays;

		private Dictionary<EDBMANFHGGO, CircuitDefaultPinDisplay> BJOONKMGKFO;

		[SerializeField]
		private bool _isSimpleNode;

		[SerializeField]
		private bool _disallowedFromCircuitBoards;

		private bool DAPBCNJNILL;

		[SerializeField]
		private bool _useCustomCircuitRendering;

		[SerializeField]
		private bool KeepOrientationOnPickup;

		[SerializeField]
		public InputSlotDisplayConfig[] inputSlotConfigs;

		[SerializeField]
		public OutputSlotDisplayConfig[] outputSlotConfigs;

		[SerializeField]
		[HideInInspector]
		private int nodeId;

		public Tool Tool;

		[SerializeField]
		[HideInInspector]
		private MeshRenderer circuitMeshRenderer;

		[SerializeField]
		protected Sprite defaultCircuitLabelSprite;

		private MaterialPropertyBlock ODJIKPKGDPB;

		private bool OEAONLGBBPN;

		private bool LBGHDOPDCAP;

public BNOPDNILAFA MyCircuitNode
{
get 		{
			return null;
		}

private set {
		}
}

public HIMMMEOIPHM NodeGraph
{
get 		{
			return null;
		}

}

public NodeMetadata NodeMetadata
{
get 		{
			return default;
		}

}

public bool IsConnected
{
get 		{
			return false;
		}

}

public bool AreConnectionVisualsHidden
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

public bool IsSimpleNode
{
get 		{
			return false;
		}

}

public bool DisallowedFromCircuitBoards
{
get 		{
			return false;
		}

}

public bool CanBeGrouped
{
get 		{
			return false;
		}

set {
		}
}

public bool UseCustomCircuitRendering
{
get 		{
			return false;
		}

}

public int NodeId
{
get 		{
			return 0;
		}

}

public bool CanPersistNode
{
get 		{
			return false;
		}

}

public virtual Sprite CircuitNodeSprite
{
get 		{
			return null;
		}

}

public event Action OnConnectionChanged {
add {
		}
remove {
		}
}

		public virtual void PopulateDynamicEditables()
		{
		}

		public void SetConnectionVisualsHidden(bool IPMIIEAGJKC, object IALNODEHBNN)
		{
		}

		public bool TryGetInputConnection(EDBMANFHGGO HHOGFBCFGAB, out MGDPGGECAAB FFBADJKEOPF)
		{
			FFBADJKEOPF = null;
			return false;
		}

		public bool IsInputConnected(EDBMANFHGGO HHOGFBCFGAB)
		{
			return false;
		}

		public bool IsOutputConnected(BHEOAPLBNIE HHOGFBCFGAB)
		{
			return false;
		}

		protected virtual void LGIICAFAHCP(BNOPDNILAFA HNPEBINPOBO, EDBMANFHGGO OBONMNBJMLD, BHEOAPLBNIE IHOMJCBGMCM)
		{
		}

		protected virtual void OnValidate()
		{
		}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		private void PCMPJIPCKFK()
		{
		}

		protected void OHMFLMPNHCH()
		{
		}

		private void DCFKNJOLPFJ(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		protected sealed override void OnDestroy()
		{
		}

		protected virtual void FLBLLLBEIHC(PhotonView CIPJGOKLPNK)
		{
		}

		public virtual void OnCircuitNodeInitialized(BNOPDNILAFA KNBPIEINLIG)
		{
		}

		public virtual void OnCircuitNodeDeserialized()
		{
		}

		protected virtual void OIONBPJBJPK()
		{
		}

		protected virtual void HANLKIIDCNC()
		{
		}

		private void AILOMAMCHBO()
		{
		}

		private CostInfo OBDEPBLIELC()
		{
			return default;
		}

		protected void CMEDACEFNFI(bool COPOILGLIAJ = false)
		{
		}

		protected virtual void CPFLDCNPNHB(NodeMetadata DLGOHBFFFJO)
		{
		}

		public void RefreshDefaultPinDisplays()
		{
		}

		public CircuitDefaultPinDisplay GetDefaultPinForInput(EDBMANFHGGO KAEDAICECGN)
		{
			return null;
		}

		private Tooltip FEDALJEOHJF(CircuitConnectionPoint HHOGFBCFGAB, string GKHMKKBKEKC)
		{
			return null;
		}

		public virtual void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public virtual void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void EDGALOKCGJP(bool IMJJNFLLCLJ)
		{
		}

		public Guid GetCircuitNodeType()
		{
			return default;
		}

		private void GLKBCCNFINJ(MNENEENPCFE HMJOKPKOPCN)
		{
		}

		void JCPJHDPNDKB.PrepareImposter(MNENEENPCFE HMJOKPKOPCN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GLKBCCNFINJ
			this.GLKBCCNFINJ(HMJOKPKOPCN);
		}

		public bool IsInputVisualSuppressed(EDBMANFHGGO HHOGFBCFGAB)
		{
			return false;
		}

		public bool IsOutputVisualSuppressed(BHEOAPLBNIE IHOMJCBGMCM, CircuitNodeDisplay FLCDMFAKEKE, EDBMANFHGGO OBONMNBJMLD)
		{
			return false;
		}

		public static bool IsGameObjectSimpleNode(Component KLEOIMLJIAC)
		{
			return false;
		}
	}
}
