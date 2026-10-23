using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Circuits.All.RecRoom.Integration.Adapter;
using RRUI.Data;
using RecRoom.CircuitsV2.Experience;
using RecRoom.DataStructures;
using RecRoom.Tools;
using UnityEngine;

namespace RecRoom.CircuitsV2.Adapter
{
	[Serializable]
	public sealed class MockChipAdapter : CCFFIDBNKOF, AGBJGJLLJFN, ISerializationCallbackReceiver
	{
		[SerializeField]
		[EFEFIKFHIDK]
		private SerializedGuid _graphId;

		[EFEFIKFHIDK]
		[SerializeField]
		private SerializedGuid _nodeId;

		[SerializeField]
		private bool _canSetName;

		[Multiline]
		[SerializeField]
		private string _name;

		[SerializeField]
		private bool _showName;

		[SerializeField]
		private BHOIHOJGIOJ memoryType;

		[SerializeField]
		private int _color;

		[SerializeField]
		private KEMGPCPONLA _emissionColor;

		[SerializeField]
		private string _staticName;

		[SerializeField]
		private NodeVisualizationKey _key;

		[SerializeField]
		private List<MockNodeGroupAdapter> _nodeGroups;

		[SerializeField]
		private bool _hasInnerContext;

		[EFEFIKFHIDK]
		[SerializeField]
		private SerializedGuid _innerGraphId;

		[SerializeField]
		private bool _isRegisteredToEvent;

		[SerializeField]
		private bool _isObjectBoard;

		[SerializeField]
		private bool _isSyncVariable;

		[SerializeField]
		private bool _canClone;

		[SerializeField]
		private bool _canDestroy;

		[SerializeField]
		private bool _canAddRemoveNodeGroups;

		[SerializeField]
		private bool _canModifyWithMakerPen;

		[SerializeField]
		private int _makerPenInteractionFilter;

		[SerializeField]
		private bool _isRoomOwnerLocked;

		[SerializeField]
		private bool _isParentPreviewContext;

		[SerializeField]
		private string _inventionId;

		[SerializeField]
		private bool _hasSelfGroup;

		private bool _canSaveIntoInventions;

		[SerializeField]
		private bool _isDeprecating;

		[SerializeField]
		private bool _supportsCustomEditControls;

		[SerializeField]
		private bool _canPlaceInCircuitBoard;

		[SerializeField]
		private bool _isBeingEdited;

		[SerializeField]
		private MPDEOEGEEIC _localPosition;

		[SerializeField]
		private HIAGCLNJBPN _localRotation;

		[CompilerGenerated]
		private Action OnChanged;

		[CompilerGenerated]
		private GMOGOHKCKFP OnPositionChanged;

		[CompilerGenerated]
		private GPEJDKGBOCL OnRotationChanged;

		[CompilerGenerated]
		private Action OnNodeWillDestroy;

		[CompilerGenerated]
		private Action<int> OnNodeGroupWillAdd;

		[CompilerGenerated]
		private Action<int, IAFGPKMBMBF> OnNodeGroupDidAdd;

		[CompilerGenerated]
		private Action<int, IAFGPKMBMBF> OnNodeGroupWillRemove;

		[CompilerGenerated]
		private Action<int> OnNodeGroupDidRemove;

		[CompilerGenerated]
		private Action OnRegistrationChanged;

		[CompilerGenerated]
		private Action<int, IAFGPKMBMBF> OnNodeGroupWillRename;

		[CompilerGenerated]
		private Action<int, IAFGPKMBMBF> OnNodeGroupDidRename;

		public object Object => null;

		public ref readonly Guid GraphId
		{
			get
			{
				throw null;
			}
		}

		public ref readonly Guid NodeId
		{
			get
			{
				throw null;
			}
		}

		public bool CanSetName => false;

		public string Name => null;

		public bool ShowName => false;

		public BHOIHOJGIOJ VariableMemoryType => BHOIHOJGIOJ.Instance;

		public int Color => 0;

		public ref readonly KEMGPCPONLA CircuitsEmissionColor
		{
			get
			{
				throw null;
			}
		}

		public string StaticName => null;

		public NodeVisualizationKey Key => NodeVisualizationKey.Execution;

		public global::MPNGGJINIEL<MDALFJIODBI> IconId => default;

		public IReadOnlyList<IAFGPKMBMBF> NodeGroups => null;

		public bool HasInnerGraph => false;

		public ref readonly Guid InnerGraphId
		{
			get
			{
				throw null;
			}
		}

		public bool IsRegisteredToEvent => false;

		public bool IsObjectBoard => false;

		public bool IsSyncVariable => false;

		public bool CanClone => false;

		public bool CanDestroy => false;

		public bool CanAddRemoveNodeGroups => false;

		public bool CanModifyWithMakerPen => false;

		public int MakerPenInteractionFilter => 0;

		public bool IsRoomOwnerLocked => false;

		public bool IsParentPreviewGraph => false;

		public string InventionId => null;

		public bool HasSelfGroup => false;

		public bool CanSaveIntoInventions => false;

		public bool IsDeprecating => false;

		public bool SupportsCustomEditControls => false;

		public bool CanPlaceInCircuitBoard => false;

		public bool IsBeingEdited => false;

		public GKGPHHHJLML SynchedLock => null;

		public ref readonly MPDEOEGEEIC LocalPosition
		{
			get
			{
				throw null;
			}
		}

		public ref readonly HIAGCLNJBPN LocalRotation
		{
			get
			{
				throw null;
			}
		}

		public bool HasBoardButton => false;

		public Guid? GraphParentId => null;

		public bool HasFloatingText => false;

		public NJJLGHIHLHD FloatingText => null;

		public ADDCDIBDJKJ ControlPanelDependencies => null;

		public IEnumerable<EKIIIJIOBCC> InnerGraphNodes => null;

public event Action KOOJPBMMOAK {
add {
		}
remove {
		}
}

public event GMOGOHKCKFP AOLHICIAKBG {
add {
		}
remove {
		}
}

public event GPEJDKGBOCL LHCDKFMGNDC {
add {
		}
remove {
		}
}

public event Action HPBMPMINKJD {
add {
		}
remove {
		}
}

public event Action<int> PHGIDDHEMFK {
add {
		}
remove {
		}
}

public event Action<int, IAFGPKMBMBF> DLEGCEILCOB {
add {
		}
remove {
		}
}

public event Action<int, IAFGPKMBMBF> EIGOKMABNBP {
add {
		}
remove {
		}
}

public event Action<int> AGMDAFJAOBF {
add {
		}
remove {
		}
}

public event Action ONOIBCEPBFK {
add {
		}
remove {
		}
}

public event Action<int, IAFGPKMBMBF> FGNDGAPNCME {
add {
		}
remove {
		}
}

public event Action<int, IAFGPKMBMBF> EGFNPLKDFMP {
add {
		}
remove {
		}
}

		public void DLMJBPBJDDN(string INIOBIJJMJP)
		{
		}

		public void KOAAHJPPJOE(int FMHCCJDJFBA)
		{
		}

		public void DAHMNDIEKOJ(in MPDEOEGEEIC IPMIIEAGJKC)
		{
		}

		public void CCIMDIMBMEJ(in HIAGCLNJBPN IPMIIEAGJKC)
		{
		}

		public void CIMGDPABKGC(Collider LPGAJGPGKFM)
		{
		}

		public void MHBBGGMNHNJ(Collider LPGAJGPGKFM)
		{
		}

		public void HPAKKDPPCHI()
		{
		}

		public void PFMMOFGMBHH(in Vector3? EGJKEDKNNAD, in Quaternion? IBHAEICNMJI)
		{
		}

		public void OKODBEKMEGB()
		{
		}

		public void KEPKNHCKBNL()
		{
		}

		public void GCMMNEBCEKJ()
		{
		}

		public bool CHELOJCOPHN(int GADDGJANIGG)
		{
			return false;
		}

		public void GPECMILCNKA(string KNOPFGAGMCN)
		{
		}

		public void NGOKEHHAJGO(int GMEHLIHLGEH)
		{
		}

		public IEnumerable<CAFMMAJMNLD> PMEEFOMNLEE()
		{
			return null;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> KKPLFNNKJOH(string INIOBIJJMJP)
		{
			return default;
		}

		public void IFIGMJHIABP(Chip JJMNDCAFBDA)
		{
		}

		public void MCGNKKNLFBL(Chip JJMNDCAFBDA)
		{
		}

		public bool OCAOJCEJMLM(out Guid PFEBBONNCEI)
		{
			PFEBBONNCEI = default;
			return false;
		}

		public bool OEMGHLECMFH(out Chip OMKGDKEKEBP)
		{
			OMKGDKEKEBP = null;
			return false;
		}

		public bool MMKLBJLCBGP(in Guid NOFHFINGBPG)
		{
			return false;
		}

		public void JICFECBLODD(ChipConfigMenu NDLEFDOGJAN, ref int LAGADKBKLAD)
		{
		}

		public void BEKHGHADBKM(ChipConfigMenu NDLEFDOGJAN)
		{
		}

		public void PAKIMOKGMBI()
		{
		}

		public void IHJCKPCCEDA(MakerPen BHCCDMJFHEO, FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public EAGGEJMPGHG NPIINPMOHJK(in CircuitsCustomEditUIModel.OHDNGMNHIFC LFKKJIFPEMA)
		{
			return null;
		}

		public void HEGENLMAODF(bool FPMKKJKAHFN)
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void KALLKIBPMJO()
		{
		}

		private void CIACEOBHPJJ(in Vector3? EGJKEDKNNAD, in Quaternion? IBHAEICNMJI)
		{
		}

		void CCFFIDBNKOF.PFMMOFGMBHH(in Vector3? EGJKEDKNNAD, in Quaternion? IBHAEICNMJI)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CIACEOBHPJJ
			this.CIACEOBHPJJ(in EGJKEDKNNAD, in IBHAEICNMJI);
		}

		private EAGGEJMPGHG IKDAMIMIAIM(in CircuitsCustomEditUIModel.OHDNGMNHIFC LFKKJIFPEMA)
		{
			return null;
		}

		EAGGEJMPGHG CCFFIDBNKOF.NPIINPMOHJK(in CircuitsCustomEditUIModel.OHDNGMNHIFC LFKKJIFPEMA)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IKDAMIMIAIM
			return this.IKDAMIMIAIM(in LFKKJIFPEMA);
		}

		private void KGOJNFNEJBA(in MPDEOEGEEIC IPMIIEAGJKC)
		{
		}

		void AGBJGJLLJFN.DAHMNDIEKOJ(in MPDEOEGEEIC IPMIIEAGJKC)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KGOJNFNEJBA
			this.KGOJNFNEJBA(in IPMIIEAGJKC);
		}

		private void BJBFOAAIGCO(in HIAGCLNJBPN IPMIIEAGJKC)
		{
		}

		void AGBJGJLLJFN.CCIMDIMBMEJ(in HIAGCLNJBPN IPMIIEAGJKC)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BJBFOAAIGCO
			this.BJBFOAAIGCO(in IPMIIEAGJKC);
		}

		private bool NLCIBIANGKI(in Guid GLLFFIFLOAG)
		{
			return false;
		}

		bool AGBJGJLLJFN.MMKLBJLCBGP(in Guid GLLFFIFLOAG)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NLCIBIANGKI
			return this.NLCIBIANGKI(in GLLFFIFLOAG);
		}
	}
}
