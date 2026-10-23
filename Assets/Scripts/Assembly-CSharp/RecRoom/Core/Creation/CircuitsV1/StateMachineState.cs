using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public class StateMachineState : MonoBehaviourPun, DJLCHGFCFAD, LEJOPAFDMEE
	{
		private sealed class MJOHICLCFAO
		{
			public StateMachineState _003C_003E4__this;

			public string newStateName;

			internal void _003CSetUserDefinedStateName_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}
		}

		private sealed class OCIBGCGMPFN
		{
			public StateMachineState state;

			internal bool _003CRemoveTransitionToState_003Eb__0(StateMachineTransition t)
			{
				return false;
			}
		}

		private sealed class BGEOCNBDBHF
		{
			public StateMachineState to;

			internal bool _003CConnectToState_003Eb__0(StateMachineTransition t)
			{
				return false;
			}
		}

		private sealed class LHJDPCCMOCG
		{
			public StateMachineState toState;

			public EDBMANFHGGO inputSlot;

			internal bool _003CAddTransition_003Eb__0(StateMachineTransition t)
			{
				return false;
			}
		}

		private sealed class LHLEAHJIFLF
		{
			public StateMachineState _003C_003E4__this;

			public int valIndex;

			internal int _003CCreateDynamicValueEditEvent_003Eb__0()
			{
				return 0;
			}

			internal void _003CCreateDynamicValueEditEvent_003Eb__1(int newVal)
			{
			}
		}

		private static readonly List<MGDPGGECAAB> ECCIBELMFCM;

		public const int CIRCUIT_GROUP_DISCOUNT = -5;

		private const int OIMONCOJFOB = 3;

		private const int MDHDALLHFHB = 0;

		[SerializeField]
		private StateMachineTransition stateMachineTransitionPrefab;

		[SerializeField]
		private ConnectionPoint mainConnectionPoint;

		[SerializeField]
		private TMP_Text stateNameText;

		public List<StateMachineTransition> outboundTransitions;

		private global::MOBDJNEDDKC<byte> PHGIKGHBKIC;

		public int val1;

		public int val2;

		public int val3;

		public int minTimeInStateMS;

		private global::MOBDJNEDDKC<string> OGDFFHBJCBI;

		private global::DAHHPCNLCBH<StateMachineCircuitNodeDisplay> LFKONLJOMIA;

		private FIHGBEHGLGB JMAKHFLKBNB;

		public CircuitOutputConnectionPoint onEnterConnection;

		public CircuitOutputConnectionPoint inStateConnection;

		public CircuitOutputConnectionPoint onExitConnection;

		public Renderer mainRenderer;

		[SerializeField]
		protected Sprite defaultCircuitLabelSprite;

		[SerializeField]
		protected Sprite activeCircuitLabelSprite;

		private Sprite DLPNHFBNNLC;

		private MaterialPropertyBlock ODJIKPKGDPB;

		private bool PHBIHODBCCG;

		private Guid HNJEIEMGIPE;

public byte StateIndex
{
get 		{
			return 0;
		}

private set {
		}
}

public string StateName
{
get 		{
			return null;
		}

private set {
		}
}

public StateMachineCircuitNodeDisplay StateMachineOwner
{
get 		{
			return null;
		}

set {
		}
}

public bool AreTransitionVisualsHidden
{
get 		{
			return false;
		}

}

public bool IsInitialized
{
get 		{
			return false;
		}

private set {
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

		private void DJAMCGCEIOE(string LKMPOIKDGMM)
		{
		}

		public void SetTransitionVisualsHidden(bool IPMIIEAGJKC, object IALNODEHBNN)
		{
		}

		private void KKMDHGDMHOF(bool DJJEBCPCDHO)
		{
		}

		protected override void Awake()
		{
		}

		private void GOBBLDJLJAN()
		{
		}

		protected void Start()
		{
		}

		public void OnNameChanged()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void ENHLACNHNKH()
		{
		}

		private void PJIIKOJFKGG()
		{
		}

		public bool RemoveTransitionToState(StateMachineState DADHJJNJEFA)
		{
			return false;
		}

		public void SetupOwner(StateMachineCircuitNodeDisplay CMNODMLEKGJ, bool LIFPCIBBECN = true)
		{
		}

		private void PLKPPBNKLGN(ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, ConnectionPoint.ININJKAJDDN LOHCFFGPEAA = null)
		{
		}

		public void RequestMasterInitState(StateMachineCircuitNodeDisplay GCILADHGICM, StateMachineState MNPBIJEMHGK = null)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestInitState(StateMachineCircuitNodeDisplay GCILADHGICM, StateMachineState MNPBIJEMHGK)
		{
		}

		public void RequestMasterConnectToState(StateMachineState FKGDJKOLCNN)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcMasterRequestConnectToState(StateMachineState FKGDJKOLCNN)
		{
		}

		private void KBFIFFEEBDK(StateMachineState FKGDJKOLCNN)
		{
		}

		public void RemoveTransition(StateMachineTransition IIPJBKNHCJK)
		{
		}

		public bool TryAddTransition(StateMachineState GMBCPDOKEDK)
		{
			return false;
		}

		public void AddTransition(StateMachineState GMBCPDOKEDK, EDBMANFHGGO OBONMNBJMLD)
		{
		}

		public void UpdateSprite()
		{
		}

		private void GAHHBGJBCCA(float OKBAJEAPIHG)
		{
		}

		private void LDCFMIIJMMC(CircuitOutputConnectionPoint HOFDCJAAGMA)
		{
		}

		private void FHEJOGGEGDE(CircuitOutputConnectionPoint HOFDCJAAGMA, BHEOAPLBNIE HHOGFBCFGAB)
		{
		}

		private FDGDCNLMACK BNLJPPHHMGD(int EMCONDIGOOH)
		{
			return null;
		}

		private void EBJODDAKCDF()
		{
		}

		private int IIEIMKIPEKF(int GMEHLIHLGEH)
		{
			return 0;
		}

		private void FIDBGNANPBO(int GMEHLIHLGEH, int KBMIOMICALD)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
		{
		}

		public void UpdateDataFromNode()
		{
		}

		public Vector3 GetConnectionLinePosition(Vector3 BKEIKIMNNOO)
		{
			return default;
		}

		protected void OHMFLMPNHCH(Sprite NDDEMFPJPIP)
		{
		}

		private void LHGFGJBMKNF()
		{
		}

		private CostInfo OBDEPBLIELC()
		{
			return default;
		}

		[CompilerGenerated]
		private float OMKJINDAKAB()
		{
			return 0f;
		}

		[CompilerGenerated]
		private void HJBPBFCLEIC(float CMHHHACAPAI)
		{
		}

		[CompilerGenerated]
		private string IOBNAHMEFOB()
		{
			return null;
		}
	}
}
