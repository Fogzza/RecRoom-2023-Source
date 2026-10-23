using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Tools
{
	public class RoomDoor : MonoBehaviourPun, DJLCHGFCFAD
	{
		private sealed class KPMHCGLPHBB
		{
			public RoomDoor _003C_003E4__this;

			public string name;

			public KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB type;

			internal void _003CTrySetTargetRoom_003Eb__0()
			{
			}
		}

		private sealed class OJIMLFENKAN
		{
			public string name;

			internal string _003CValidateTargetData_003Eb__0(string error)
			{
				return null;
			}
		}

		private sealed class ANMGEOHKMAJ
		{
			public RoomDoor _003C_003E4__this;

			public string targetName;

			public Action _003C_003E9__1;

			public Action<string> _003C_003E9__2;

			internal void _003CTargetRoomName_Set_003Eb__0(GMBCDOMHMFF.HLMOCMHMIEN response)
			{
			}

			internal void _003CTargetRoomName_Set_003Eb__1()
			{
			}

			internal void _003CTargetRoomName_Set_003Eb__2(string e)
			{
			}
		}

		[SerializeField]
		private TextMesh roomNameText;

		[SerializeField]
		private Tool _tool;

		[SerializeField]
		private TeleportationPortal teleportationPortal;

		[SerializeField]
		private DisableObjectWhenCircuitsHidden signRoot;

		[SerializeField]
		private DisableObjectWhenCircuitsHidden doorRoot;

		private bool MFMEGEIKNJB;

		private readonly Dictionary<string, MIBJNNKFLND> DLPCHKCKBCD;

		private CreationObject BPEGJLIMPPJ;

		private global::JPEBBAFCBEP<string, KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB> DONEJEMANMN;

		private global::JPEBBAFCBEP<KKAPOPJBDOA.PKCADEJAJPO.CLMOBELOGEP, bool> GLKIELELPGE;

		private global::MOBDJNEDDKC<bool> AOOAPEEKLBH;

		private global::MOBDJNEDDKC<bool> IPBGACFCGMA;

public string TargetName
{
get 		{
			return null;
		}

}

public KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB TargetType
{
get 		{
			return KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB.UnknownType;
		}

}

public KKAPOPJBDOA.PKCADEJAJPO.CLMOBELOGEP InviteMode
{
get 		{
			return KKAPOPJBDOA.PKCADEJAJPO.CLMOBELOGEP.UnknownMode;
		}

}

public bool ForceNewInstance
{
get 		{
			return false;
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

		public void ProcessCircuitInput(int signal)
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

		private void JBCDLKKJDMD()
		{
		}

		private LAHBDKNMNHN JFABKHAOILC(string KNOPFGAGMCN, KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB NIFOGEBEDNG)
		{
			return null;
		}

		private LAHBDKNMNHN PAEGFMGILPC(string KNOPFGAGMCN, KKAPOPJBDOA.PKCADEJAJPO.OAPIMBPPIIB NIFOGEBEDNG)
		{
			return null;
		}

		private void DDNDDHCAFKG(object ICHBECDKHOJ)
		{
		}

		private string OGMHMNGAHMK()
		{
			return null;
		}

		private void OJLLNEBLHJH(int GKAPDGEAPAN)
		{
		}

		private int KMJGJMMEAPF()
		{
			return 0;
		}

		private void IPHPECJLFFF(int DLEMNBPMGBG)
		{
		}

		private int IIHIMNGLLLO()
		{
			return 0;
		}

		private void IHBKDDEEHLM(bool DLEMNBPMGBG)
		{
		}

		private bool FCNEFBNDINO()
		{
			return false;
		}

		private void FHGBGIOLFCE()
		{
		}

		private void BGNDFJFEBFJ(string OFMGPNLDCAB, string OFCFPGACNJB)
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		[CompilerGenerated]
		private void JEBPNADMMEG()
		{
		}

		[CompilerGenerated]
		private bool AHCLIEPPLCA()
		{
			return false;
		}

		[CompilerGenerated]
		private void DBODGMKEEGC(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private bool BHBHGKAPNCG()
		{
			return false;
		}

		[CompilerGenerated]
		private void ACJPNHMFGJD(bool DGAGNFOEEIJ)
		{
		}

		[CompilerGenerated]
		private void LEHPHDAOPPD()
		{
		}

		[CompilerGenerated]
		private void PEKEIMIJCBD(string GCBHEJANCJK)
		{
		}

		[CompilerGenerated]
		private bool NLLGKMDOHJF(OPKEAIOICLJ IBALDFBGBGL)
		{
			return false;
		}

		[CompilerGenerated]
		private void HCAPNFADIMH(JCDPHCELKHI KPFNANKNKLE)
		{
		}
	}
}
