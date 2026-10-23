using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class CircuitGroup : ObjectGroup
	{
		private struct JHBKAKHJCHE
		{
			public CircuitGroupInterfaceNode.MJEEMHOJNLI AADCGLKMAIA;

			public CircuitGroupInterfaceNode.MJEEMHOJNLI CJDGADBLHJP;

			public bool JIJEGLKAABH;
		}

		private sealed class PNKOKLFHDPP
		{
			public CircuitGroup _003C_003E4__this;

			public string newDisplayName;

			internal void _003CSetNewUserDefinedDisplayName_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}
		}

		private sealed class OPDDFDJKPNK
		{
			public CircuitGroup _003C_003E4__this;

			public bool shouldPropagate;

			internal void _003CCleanupNodesWithNoInternalConnections_003Eb__0()
			{
			}
		}

		private sealed class GJAECAOKNND
		{
			public CircuitGroup _003C_003E4__this;

			public CircuitGroupInterfaceNode node;

			public bool isInput;

			public string name;

			internal void _003CSetNodeName_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}
		}

		private sealed class JPAFMILHOHJ : IEnumerable<JHBKAKHJCHE>, IEnumerable, IEnumerator<JHBKAKHJCHE>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private JHBKAKHJCHE _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private CircuitNodeDisplay nodeDisplay;

			public CircuitNodeDisplay _003C_003E3__nodeDisplay;

			public CircuitGroup _003C_003E4__this;

			private BNOPDNILAFA _003Cnode_003E5__2;

			private bool _003CnodeIsInGroup_003E5__3;

			private DHJLEHBOGBG _003CthisGroupCreationObj_003E5__4;

			private Dictionary<EDBMANFHGGO, CircuitInputConnectionPoint>.Enumerator _003C_003E7__wrap4;

			private Dictionary<BHEOAPLBNIE, CircuitOutputConnectionPoint>.Enumerator _003C_003E7__wrap5;

			private CircuitOutputConnectionPoint _003CcircuitConnectionPoint_003E5__7;

			private CircuitGroupInterfaceNode[] _003C_003E7__wrap7;

			private int _003C_003E7__wrap8;

			private HashSet<MGDPGGECAAB>.Enumerator _003C_003E7__wrap9;

			private MGDPGGECAAB _003Clink_003E5__11;

			private IEnumerator<BNOPDNILAFA> _003C_003E7__wrap11;

			JHBKAKHJCHE IEnumerator<JHBKAKHJCHE>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002ECircuitsV1_002ECircuitGroup_002EExternalConnectionData_003E_002Eget_Current();
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public JPAFMILHOHJ(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			private void _003C_003Em__Finally3()
			{
			}

			private void _003C_003Em__Finally4()
			{
			}

			[DebuggerHidden]
			private JHBKAKHJCHE System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002ECircuitsV1_002ECircuitGroup_002EExternalConnectionData_003E_002Eget_Current()
			{
				return default;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<JHBKAKHJCHE> IEnumerable<JHBKAKHJCHE>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class ONCBAFBHLOO : IEnumerable<JHBKAKHJCHE>, IEnumerable, IEnumerator<JHBKAKHJCHE>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private JHBKAKHJCHE _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private StateMachineState state;

			public StateMachineState _003C_003E3__state;

			public CircuitGroup _003C_003E4__this;

			private StateMachineCircuitNodeDisplay _003CnodeDisplay_003E5__2;

			private bool _003CstateIsInGroup_003E5__3;

			private DHJLEHBOGBG _003CthisGroupCreationObj_003E5__4;

			private Dictionary<EDBMANFHGGO, CircuitConnectionPoint>.Enumerator _003C_003E7__wrap4;

			JHBKAKHJCHE IEnumerator<JHBKAKHJCHE>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002ECircuitsV1_002ECircuitGroup_002EExternalConnectionData_003E_002Eget_Current();
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public ONCBAFBHLOO(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			private JHBKAKHJCHE System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002ECircuitsV1_002ECircuitGroup_002EExternalConnectionData_003E_002Eget_Current()
			{
				return default;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<JHBKAKHJCHE> IEnumerable<JHBKAKHJCHE>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class KADFKKOCIJO : IEnumerable<JHBKAKHJCHE>, IEnumerable, IEnumerator<JHBKAKHJCHE>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private JHBKAKHJCHE _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private CircuitGroup group;

			public CircuitGroup _003C_003E3__group;

			public CircuitGroup _003C_003E4__this;

			private bool _003CnodeIsInGroup_003E5__2;

			private List<CircuitGroupInterfaceNode>.Enumerator _003C_003E7__wrap2;

			JHBKAKHJCHE IEnumerator<JHBKAKHJCHE>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002ECircuitsV1_002ECircuitGroup_002EExternalConnectionData_003E_002Eget_Current();
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public KADFKKOCIJO(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			private JHBKAKHJCHE System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002ECircuitsV1_002ECircuitGroup_002EExternalConnectionData_003E_002Eget_Current()
			{
				return default;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<JHBKAKHJCHE> IEnumerable<JHBKAKHJCHE>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class HEMANHFOBBG
		{
			public CircuitGroup _003C_003E4__this;

			public short revision;

			internal void _003CLocalPostLoadCircuitGroupData_003Eb__0()
			{
			}
		}

		private sealed class GBOMJAIHLJA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public CircuitGroup _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public GBOMJAIHLJA(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class MCGMJKHBHCL
		{
			public CircuitGroupInterfaceNode node;

			public CircuitGroup _003C_003E4__this;

			internal string _003CRefreshEditables_003Eb__1()
			{
				return null;
			}

			internal void _003CRefreshEditables_003Eb__2(string newName)
			{
			}
		}

		private sealed class FABKJMJFILM
		{
			public CircuitGroupInterfaceNode node;

			public CircuitGroup _003C_003E4__this;

			internal string _003CRefreshEditables_003Eb__3()
			{
				return null;
			}

			internal void _003CRefreshEditables_003Eb__4(string newName)
			{
			}
		}

		public const int MAX_EXTERNAL_CONNECTIONS = 7;

		public const int MAX_CIRCUIT_GROUP_DEPTH = 5;

		private const int AAIIFMBGGKA = 16;

		private const int MJFHLLINGDJ = 8;

		private Dictionary<DHJLEHBOGBG, Matrix4x4> MAHKKCNDAAA;

		private Dictionary<CircuitGroupInterfaceNode, BBMJAJNMODG> MLKILCEADAH;

		private List<NOKBACLGMHI> FPKIACCHIPP;

		private short PHDCPAGEGLE;

		private List<StateMachineState> JBOMPFHPOHA;

		private MaterialPropertyBlock ODJIKPKGDPB;

		private CircuitGroupInputInterfaceNode[] MADMFNPNHPG;

		private CircuitGroupOutputInterfaceNode[] HCNKKBOGNHN;

		private List<CircuitGroup> EOEGEBOIGBE;

		private static readonly List<string> ADLHLOAIIAN;

		private FIHGBEHGLGB PFGGEAMNFHG;

		private FIHGBEHGLGB AAIHNKOCNHM;

		private object JIJPLACHNIH;

		private object KNFHDCENIHH;

		[SerializeField]
		private GameObject addInputInterfaceNodeContainer;

		[SerializeField]
		private GameObject addOutputInterfaceNodeContainer;

		[SerializeField]
		private MeshRenderer circuitMeshRenderer;

		[SerializeField]
		protected Sprite circuitLabelSprite;

		[SerializeField]
		private TMP_Text circuitGroupNameText;

		private global::MOBDJNEDDKC<string> GMCKCKBAHNO;

		private global::MOBDJNEDDKC<string[]> CCLONGKEJHG;

		private global::MOBDJNEDDKC<string[]> DNNFGJOPDDA;

		private bool AGKPIBDHKBH;

		public EEANDDJEMJC OnVisibilityChanged;

		[SerializeField]
		private BigDataTrackedObject bigDataTrackedObject;

		private int IJFFADDAGFE;

		private FIHGBEHGLGB BEEGLJGBNJK;

		public readonly List<CircuitGroupInterfaceNode> ActiveInputInterfaceNodes;

		public readonly List<CircuitGroupInterfaceNode> ActiveOutputInterfaceNodes;

		public readonly List<DHJLEHBOGBG> ObjectsPendingRemoval;

		public static readonly List<CircuitGroup> AllCircuitGroups;

		public static readonly int IconTexScaleOffsetPropertyId;

		public static readonly int PinMaskPropertyId;

		private AKCHPHOMHLH PPLLHFPPIPO;

public string DisplayName
{
get 		{
			return null;
		}

private set {
		}
}

public string[] InputNodeDisplayNames
{
get 		{
			return null;
		}

private set {
		}
}

public string[] OutputNodeDisplayNames
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsExpanded
{
get 		{
			return false;
		}

}

public BigDataTrackedObject BigDataTrackedObject
{
get 		{
			return null;
		}

}

public int CircuitGroupDepth
{
get 		{
			return 0;
		}

private set {
		}
}

public bool AreConnectionVisualsHidden
{
get 		{
			return false;
		}

}

public override GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		private void NMKILCDLBBL(string HFNELHNFMNA)
		{
		}

		public void SetConnectionVisualsHidden(bool IPMIIEAGJKC, object IALNODEHBNN)
		{
		}

		protected override void MGJAHJFDEDJ()
		{
		}

		public static bool IsObjectAllowedInCircuitGroup(DHJLEHBOGBG BPEGJLIMPPJ)
		{
			return false;
		}

		private void PCMPJIPCKFK()
		{
		}

		private void OHMFLMPNHCH()
		{
		}

		private void JIEDIGFFOHB()
		{
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

		public override bool AddCreationObjectToGroup(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB)
		{
			return false;
		}

		public override bool AddCreationObjectsToGroup(IEnumerable<DHJLEHBOGBG> DGCKCDACDNM, bool LAEPMFGPFIC)
		{
			return false;
		}

		[PBOMGCLBFHF]
		private void RpcAddToCircuitGroup(CreationObject BPEGJLIMPPJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAddListToCircuitGroup(List<CreationObject> DGCKCDACDNM)
		{
		}

		private void MCHFLLOOILL(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		protected override void HHPNCBDPCMC(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB)
		{
		}

		public override bool ExtractCreationObjectToParentGroupOrRoot(DHJLEHBOGBG BPEGJLIMPPJ)
		{
			return false;
		}

		public override bool ExtractCreationObjectsToParentGroupOrRoot(IEnumerable<DHJLEHBOGBG> DGCKCDACDNM)
		{
			return false;
		}

		[PBOMGCLBFHF]
		private void RpcExtractFromCircuitGroupToParentGroupOrRoot(CreationObject BPEGJLIMPPJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcExtractListFromCircuitGroupToParentGroupOrRoot(List<CreationObject> DGCKCDACDNM)
		{
		}

		private void AFJCPHEKHPB(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		public override void OnGroupPopped()
		{
		}

		public void ExpandGroup()
		{
		}

		public void CollapseGroup()
		{
		}

		[PBOMGCLBFHF]
		private void RpcUpdateLocalTransforms()
		{
		}

		public override void PrepForSerialization()
		{
		}

		public void CleanupNodesWithNoInternalConnections(bool DJJAHJMAGFB)
		{
		}

		[PBOMGCLBFHF]
		private void RpcCleanupNodesWithNoInternalConnections()
		{
		}

		public void OnAddTemporaryNodeConnection(ConnectionPoint otherNode)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAddNewInterfaceNodeForCircuitConnection(CircuitNodeDisplay FACDBINPLGK, int HHOGFBCFGAB, bool ENILFJEEOFP)
		{
		}

		private CircuitConnectionPoint AMEFPBFEHIL(CircuitNodeDisplay FACDBINPLGK, int HHOGFBCFGAB, bool ENILFJEEOFP)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcAddNewInterfaceNodeForInterfaceConnection(CircuitGroup JHACDMGADED, int DDBHHEMDDLC, bool ENILFJEEOFP)
		{
		}

		public void BroadcastAssignInterfaceNode(CircuitGroupInterfaceNode MNHPCFFLIPH, CircuitGroupInterfaceNode.MJEEMHOJNLI HOFDCJAAGMA, bool KAIFMPEGEGH)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAssignNodeToCircuitConnection(int IFDGMAIKPLJ, bool IFLNKMAFKAE, CircuitNodeDisplay FACDBINPLGK, int MHNHBGNCDAL, bool BFHJIFINMJF, bool KAIFMPEGEGH)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAssignNodeToInterfaceConnection(int OCOIJDMIMEI, bool NGGBBBHILMK, CircuitGroup FNJBEGFPCGO, int GPOCCGNFOCP, bool OGPGKKCPKBG, bool KAIFMPEGEGH)
		{
		}

		[PBOMGCLBFHF]
		private void RpcAssignNodeToEmpty(int PMPELHFMKFF, bool ENILFJEEOFP, bool KAIFMPEGEGH)
		{
		}

		protected override void JEIABLCFFHE(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		protected override void OMFACCPMLAJ(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		public int GetActiveInterfaceNodeIndex(CircuitGroupInterfaceNode KNBPIEINLIG)
		{
			return 0;
		}

		public CircuitGroupInterfaceNode GetActiveInterfaceNode(int GMEHLIHLGEH, bool ENILFJEEOFP)
		{
			return null;
		}

		protected override bool DDGKJEBOBNJ(DHJLEHBOGBG BPEGJLIMPPJ, bool HNPCPEMIKNB, out string LOKKJFCDNHB)
		{
			LOKKJFCDNHB = null;
			return false;
		}

		private void PEBDGJPEBLN()
		{
		}

		private void KBECNBAFGLK()
		{
		}

		private void DGOOAPGJFKE()
		{
		}

		private void FPLPHPMDGFE(bool ENILFJEEOFP)
		{
		}

		private void HJCBGIBOFAB()
		{
		}

		private string HLCDICJCBLL(CircuitGroupInterfaceNode KNBPIEINLIG, bool ENILFJEEOFP)
		{
			return null;
		}

		private string HLCDICJCBLL(int GMEHLIHLGEH, bool ENILFJEEOFP)
		{
			return null;
		}

		private void LDEDGIJHLDK(CircuitGroupInterfaceNode KNBPIEINLIG, bool ENILFJEEOFP, string KNOPFGAGMCN)
		{
		}

		private void LDEDGIJHLDK(int GMEHLIHLGEH, bool ENILFJEEOFP, string KNOPFGAGMCN)
		{
		}

		private void HNGHKOCJJFI(DHJLEHBOGBG BPEGJLIMPPJ, bool JOJCJADJHKF = true)
		{
		}

		private void CAABCCNMOIL(DHJLEHBOGBG BPEGJLIMPPJ)
		{
		}

		private void AJOPPGPGDAJ(DHJLEHBOGBG BPEGJLIMPPJ, bool DJJEBCPCDHO)
		{
		}

		private Matrix4x4 CBEJLPOAKDM(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return default;
		}

		private void NHMJMBDDEEK(DHJLEHBOGBG ICHBECDKHOJ, Matrix4x4 IBDBMMCBPJO)
		{
		}

		private void GEGALINMLFJ()
		{
		}

		private void MJJPGBIAFPD(IEnumerable<JHBKAKHJCHE> OALBNDOJPPE)
		{
		}

		private IEnumerable<JHBKAKHJCHE> FAEBOJFOKDA(CircuitNodeDisplay FACDBINPLGK)
		{
			return null;
		}

		private IEnumerable<JHBKAKHJCHE> FAEBOJFOKDA(StateMachineState DADHJJNJEFA)
		{
			return null;
		}

		private JHBKAKHJCHE? LAONMIMJINP(EDBMANFHGGO HHOGFBCFGAB, CircuitConnectionPoint DLMKIJMLNAE, CircuitNodeDisplay FACDBINPLGK, DHJLEHBOGBG KCNHFLPICNK, bool GKEJFJEMLOC)
		{
			return null;
		}

		private IEnumerable<JHBKAKHJCHE> FAEBOJFOKDA(CircuitGroup CIFHMNKCLNG)
		{
			return null;
		}

		private void HPHDHOIDCBL(DHJLEHBOGBG BPEGJLIMPPJ, bool PCBCEMBDJCN)
		{
		}

		private DHJLEHBOGBG LMLJICKBKAF(DHJLEHBOGBG BPEGJLIMPPJ)
		{
			return null;
		}

		private CircuitGroupInterfaceNode FAJPIAMINGB(JHBKAKHJCHE BOMIDJJOJCN, bool HNPCPEMIKNB)
		{
			return null;
		}

		private void JLIGDGHPFMM(CircuitGroupInterfaceNode MNHPCFFLIPH, List<CircuitGroupInterfaceNode> LBDAMOODJIK)
		{
		}

		private void DCAAOOBJDLG(CircuitGroupInterfaceNode MNHPCFFLIPH, bool IJPDMJNLHJP = true)
		{
		}

		private bool GGBKGNMKEOF(bool ENILFJEEOFP)
		{
			return false;
		}

		private void KLMJKEMJLHI(bool ENILFJEEOFP)
		{
		}

		private BBMJAJNMODG NNCDAAHMOAH(CircuitGroupInterfaceNode KNBPIEINLIG, bool ENILFJEEOFP)
		{
			return null;
		}

		private EHLKOHLONNA GGEFBAKNPAN(CircuitConnectionPoint KMFPKDIJNBB)
		{
			return null;
		}

		private AFNCACNBHBL HACOEFDHBCJ(CircuitGroupInterfaceNode MNHPCFFLIPH)
		{
			return null;
		}

		private NOKBACLGMHI OEGNNFNFHKL(Matrix4x4 FGNGGLFNLIP)
		{
			return null;
		}

		public void LocalLoadCircuitGroupData(IMFIBJPNBHM IJPJHBPHBJO, short AJMCKPPKOFJ)
		{
		}

		private void PODNEMLGANF(IMFIBJPNBHM IJPJHBPHBJO)
		{
		}

		[PBOMGCLBFHF]
		private void RpcLoadCircuitGroupData(IMFIBJPNBHM IJPJHBPHBJO, short KJNDJFCLPGF)
		{
		}

		public void LocalPostLoadCircuitGroupData(short AJMCKPPKOFJ)
		{
		}

		private IEnumerator<EGGPGCCKPCO> DPFGODPDNPG()
		{
			return null;
		}

		private bool DDOMNJDHDNB()
		{
			return false;
		}

		private void DCBKNHGGGFN(short AJMCKPPKOFJ)
		{
		}

		private void IOCFNIICCPN(short AJMCKPPKOFJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcPostLoadCircuitGroupData(short AJMCKPPKOFJ)
		{
		}

		private void GHBGJOJJFFI(BBMJAJNMODG KFECLMFEPBA, bool ENILFJEEOFP)
		{
		}

		private void PEJHFMNKDKP(CCIODADJJMP JANFGAFIAAE)
		{
		}

		public override void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public override void PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
		{
		}

		public override void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public IMFIBJPNBHM Serialize()
		{
			return null;
		}

		protected CCIODADJJMP PEENNGJCEPI()
		{
			return null;
		}

		private void LMMOBBMLKLK()
		{
		}

		private void MDOJDCADIDJ(bool IPMIIEAGJKC, object IALNODEHBNN)
		{
		}

		private void OBCFLEPNJKJ(bool IPMIIEAGJKC, object IALNODEHBNN)
		{
		}

		private void MLDLGNBALPI(bool IPMIIEAGJKC, object IALNODEHBNN, FIHGBEHGLGB HCIJEDJGMFM, GameObject IGKAPEFEJPJ)
		{
		}

		[CompilerGenerated]
		private bool OEDGAHDDNHJ()
		{
			return false;
		}

		[CompilerGenerated]
		private string JBGNELPILML()
		{
			return null;
		}
	}
}
