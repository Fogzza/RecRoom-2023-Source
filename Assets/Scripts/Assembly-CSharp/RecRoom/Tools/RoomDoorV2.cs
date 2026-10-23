using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Tools
{
	public class RoomDoorV2 : MonoBehaviourPun, GFLPAFBGELM, DJLCHGFCFAD, NEKJJEGPHFG
	{
		private sealed class KOMEJJHLDID
		{
			public string roomName;

			public RoomDoorV2 _003C_003E4__this;

			public Func<string, string> _003C_003E9__1;

			public Action<JCDPHCELKHI> _003C_003E9__2;

			public Action<string> _003C_003E9__3;

			internal void _003CMenu_RoomName_Set_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}

			internal string _003CMenu_RoomName_Set_003Eb__1(string error)
			{
				return null;
			}

			internal void _003CMenu_RoomName_Set_003Eb__2(JCDPHCELKHI room)
			{
			}

			internal void _003CMenu_RoomName_Set_003Eb__3(string e)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct NEPBJNEBLEL : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomDoorV2 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct BPANDHLKJHK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public RoomDoorV2 _003C_003E4__this;

			private List<KeyValuePair<string, MIBJNNKFLND>> _003CwelcomeMatMenuOptions_003E5__2;

			private int _003CwelcomeMatSelectionIndex_003E5__3;

			private List<MHKCAHMEGEF> _003CwelcomeMatsOfSelectedSubroom_003E5__4;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct KIPKPGCOFMK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RoomDoorV2 _003C_003E4__this;

			private string _003CtargetRoomName_003E5__2;

			private OPKEAIOICLJ _003Csubroom_003E5__3;

			private int _003CsubroomSelectionIndex_003E5__4;

			private List<OPKEAIOICLJ> _003CvisibleSubroomsOfSelectedRoom_003E5__5;

			private Dictionary<string, MIBJNNKFLND> _003CsubroomMenuOptions_003E5__6;

			private TaskAwaiter<JCDPHCELKHI> _003C_003Eu__1;

			private TaskAwaiter<LCEKCFEIEGJ> _003C_003Eu__2;

			private TaskAwaiter _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private ControlPanelCircuitObject controlPanelCircuitObject;

		[SerializeField]
		private TextMesh roomNameText;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		private TeleportationPortal teleportationPortal;

		[SerializeField]
		private DisableObjectWhenCircuitsHidden signRoot;

		[SerializeField]
		private DisableObjectWhenCircuitsHidden doorRoot;

		private int OEHHHADCKAD;

		private string LCHDNFEKIPA;

		private string FFLJMCEHDBE;

		private string LECEKJOHDBB;

		private int HPKCGOCCBLK;

		private int BMGBCJNJILD;

		private Dictionary<string, MIBJNNKFLND> DKGCMNOEKFC;

		private List<KeyValuePair<string, MIBJNNKFLND>> AKHNEKNEAFE;

		private List<OPKEAIOICLJ> AFPPCOBHHKB;

		private List<MHKCAHMEGEF> KDMNPIEGAGM;

		private bool AALAJCBIIIL;

		private bool NIALMLGMGEO;

		private const int OCKNKELJCFM = -1;

		private const int DFNNOCBDCND = -2;

		private const int KDDAGECBMON = -3;

		private const string LBMCDCBKNEE = "(INVALID DATA)";

		private readonly Dictionary<string, MIBJNNKFLND> DLPCHKCKBCD;

		private global::MOBDJNEDDKC<bool> AOOAPEEKLBH;

		private global::MOBDJNEDDKC<bool> IPBGACFCGMA;

		private global::MOBDJNEDDKC<bool> MFMEGEIKNJB;

		private global::CDLJMENCODC<string> FOEPAEODKDK;

		private global::CDLJMENCODC<string> OJFLPBJLINP;

		private global::CDLJMENCODC<string> LAICFJKJGPA;

		private global::CDLJMENCODC<int> BGLHGNCAJJJ;

		private global::CDLJMENCODC<bool> GBJACCNHJBJ;

		private LCEKCFEIEGJ FKADOKKGEBB;

		private static readonly Dictionary<int, string> LILGMGLMIJE;

public GPLMEJAFFFO Destination
{
get 		{
			return null;
		}

set {
		}
}

public bool DestinationForceNewInstanceRuntime
{
get 		{
			return false;
		}

set {
		}
}

protected bool JHBDNNGGPMM
{
get 		{
			return false;
		}

set {
		}
}

public string DestinationRoomNameRuntime
{
get 		{
			return null;
		}

set {
		}
}

protected string PPHLOAFIIKH
{
get 		{
			return null;
		}

set {
		}
}

public string DestinationSubroomNameRuntime
{
get 		{
			return null;
		}

set {
		}
}

protected string PIKGGODKKPK
{
get 		{
			return null;
		}

set {
		}
}

public string DestinationWelcomeMatNameRuntime
{
get 		{
			return null;
		}

set {
		}
}

protected string BMEHLCFKAAN
{
get 		{
			return null;
		}

set {
		}
}

public int DestinationRoomDoorInviteModeRuntime
{
get 		{
			return 0;
		}

set {
		}
}

protected int NHBBEKBLLNO
{
get 		{
			return 0;
		}

set {
		}
}

public bool HideSign
{
get 		{
			return false;
		}

set {
		}
}

public bool HideDoor
{
get 		{
			return false;
		}

set {
		}
}

public Tool Tool
{
get 		{
			return null;
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

public bool IsLocked
{
get 		{
			return false;
		}

set {
		}
}

public GMHHJCFIMML CV2CreationObject
{
get 		{
			return null;
		}

}

public global::MPNGGJINIEL<KGGKJGICJLE> ObjectDefinitionId
{
get 		{
			return default;
		}

}

		public void UseDoor(CHILKDJABBF FBCDJHOIDJJ)
		{
		}

		private global::FAIKNKAIPLB<OHAJOLBEFND> DCBNIOPDHIN(JEGAPHLGBJA GCBHEJANCJK)
		{
			return default;
		}

		global::FAIKNKAIPLB<OHAJOLBEFND> GFLPAFBGELM.Self(JEGAPHLGBJA GCBHEJANCJK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DCBNIOPDHIN
			return this.DCBNIOPDHIN(GCBHEJANCJK);
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

		private void EEKIJKJBBCE()
		{
		}

		private void NCHPPKIKFJM()
		{
		}

		public void CircuitSignalUpdated(Dictionary<EDBMANFHGGO, int> signals)
		{
		}

		[PBOMGCLBFHF]
		private void RpcLocalPlayerUseDoor()
		{
		}

		private void EPKBPODNJKJ()
		{
		}

		private void FNMEAEHAOHJ()
		{
		}

		private void DGKGKNCBACO()
		{
		}

		private void MNECEOLGCKC()
		{
		}

		private bool CJIKBLAEOEA()
		{
			return false;
		}

		private void JBCDLKKJDMD()
		{
		}

		private LAHBDKNMNHN IININCFDFCD()
		{
			return null;
		}

		private string DCAAIHKJKLP()
		{
			return null;
		}

		private void ACHHMPPCKLH()
		{
		}

		private void FOEGGNLCDPB(string OCLDAGFLIEO)
		{
		}

		private void PEKNIPNNFDF()
		{
		}

		private void GNGLJMOHEEJ(string GOLAFNFADNL)
		{
		}

		private void NIANLDAGJPO(int BCCBIGKNKIA)
		{
		}

		private int GKJCMCDKLHL()
		{
			return 0;
		}

		private void MCNMFEFMPGA(int FAJCCIHOLHG)
		{
		}

		private void NPCENABHGAK()
		{
		}

		private void DNHOMDEOJPH()
		{
		}

		private void NADFJKFMMGF()
		{
		}

		private void FLHHFHJMHLI(string LBGBFPDNKOL)
		{
		}

		private void POAAPAFNOJH()
		{
		}

		private Task FAMHMELJNOM()
		{
			return null;
		}

		private void IPBPIHANIPF()
		{
		}

		private void MOBLLBIBABF(int DLEMNBPMGBG)
		{
		}

		private int AJGALGFKPMJ()
		{
			return 0;
		}

		private void PAFJCNDNPKF(bool DLEMNBPMGBG)
		{
		}

		private bool AOGGEHOFACE()
		{
			return false;
		}

		private string AIEGCEBDFIG()
		{
			return null;
		}

		private string OBLPBOMPPPO()
		{
			return null;
		}

		private void FHGBGIOLFCE()
		{
		}

		private void BGNDFJFEBFJ(string OFMGPNLDCAB, string OFCFPGACNJB)
		{
		}

		public void ResetDestination()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private void CMMEJDEOFMN()
		{
		}

		[CompilerGenerated]
		private bool ECMHFHAGGLF()
		{
			return false;
		}

		[CompilerGenerated]
		private bool AADCKJIHCCN()
		{
			return false;
		}

		[CompilerGenerated]
		private bool ABPILJIHGIO()
		{
			return false;
		}

		[CompilerGenerated]
		private Dictionary<string, MIBJNNKFLND> EKBIDLCNPEN()
		{
			return null;
		}

		[CompilerGenerated]
		private int MJGHCGJPLAF()
		{
			return 0;
		}

		[CompilerGenerated]
		private void MGKDOIFFDDE(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool LHAIOAICHPJ()
		{
			return false;
		}

		[CompilerGenerated]
		private List<KeyValuePair<string, MIBJNNKFLND>> FPNDJDIHOCN()
		{
			return null;
		}

		[CompilerGenerated]
		private int NJFOOFLFENF()
		{
			return 0;
		}

		[CompilerGenerated]
		private void PIHFHPJPNLK(int MLIPDLAHDHI)
		{
		}

		[CompilerGenerated]
		private bool BPKCOGDLACI()
		{
			return false;
		}

		[CompilerGenerated]
		private bool GGCOBHNBNBP()
		{
			return false;
		}

		[CompilerGenerated]
		private bool AIJDLEMIJFH()
		{
			return false;
		}

		[CompilerGenerated]
		private void CEMBLALCJAP(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool EHINDGNGLCI()
		{
			return false;
		}

		[CompilerGenerated]
		private void OHFMKAPEGGO(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private string HFHFOLKJDIL(string NLJOHEKGNDH)
		{
			return null;
		}
	}
}
