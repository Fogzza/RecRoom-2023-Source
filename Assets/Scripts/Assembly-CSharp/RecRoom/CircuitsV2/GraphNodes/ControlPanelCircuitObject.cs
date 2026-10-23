using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom.Core.Creation;
using RecRoom.Core.Studio;
using RecRoom.DataStructures;
using RecRoom.Persistence;
using UnityEngine;

namespace RecRoom.CircuitsV2.GraphNodes
{
	public class ControlPanelCircuitObject : ControlPanelCircuitObjectBase, BAKGKOJPGLO, DJLCHGFCFAD, GBIGGECGKHF, NKHKPBPHIEG
	{
		private sealed class COCHLKCIILK
		{
			public ControlPanelCircuitObject _003C_003E4__this;

			public bool controlPanelInstantiationDataIsNull;

			public Guid graphId;

			public Guid parentGraphId;

			public bool isDeserialized;

			internal object _003CSetupControlPanel_003Eb__0()
			{
				return null;
			}

			internal object _003CSetupControlPanel_003Eb__1()
			{
				return null;
			}
		}

		private sealed class EFJKELGJOGG
		{
			public ControlPanelCircuitObject _003C_003E4__this;

			public Guid nodeId;

			public global::MPNGGJINIEL<KGGKJGICJLE> objectDefinitionId;

			public EHPNEOOACFA serializedStateObj;

			internal Task<global::LAFJBBFBCGA<JHFMIMDLHNN, HODHNINHENI>> _003CCreateObjectBoard_003Eb__0()
			{
				return null;
			}

			internal Task<global::LAFJBBFBCGA<MJJFILPGPCH, HODHNINHENI>> _003CCreateObjectBoard_003Eb__1()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct DPMNCKPINBM : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ControlPanelCircuitObject _003C_003E4__this;

			public bool empty;

			private EFJKELGJOGG _003C_003E8__1;

			private DBJMAFIOFFK _003Cparent_003E5__2;

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

		private KGDFHOFBJJO LCEEIDPAOHE;

		[SerializeField]
		protected Tool tool;

		[SerializeField]
		private RecRoom.DataStructures.SerializedGuid serializedCircuitGraphId;

		[SerializeField]
		protected ControlPanelSerializedState serializedState;

		[SerializeField]
		[EFEFIKFHIDK]
		private long setTimestamp;

		[SerializeField]
		private PersistenceView persistenceView;

		[SerializeField]
		protected Transform controlPanelSpawnPoint;

		[SerializeField]
		private SandboxDeformableShape volume;

		public Guid ParentCircuitGraphId;

		private RecRoomStudioSpawnableObject IAPGMLEKNBA;

		private bool GMCBNPMELJJ;

		private bool JEENOMNOCJP;

		private bool OKPPHDNKIAB;

protected DBJMAFIOFFK EBCMHCLDAJL
{
get 		{
			return default;
		}

}

protected MGLKJGICKPJ BNFLPGDEKBP
{
get 		{
			return default;
		}

}

public CreationObject CreationObject
{
get 		{
			return null;
		}

}

private bool EAFBNDANLMJ
{
get 		{
			return false;
		}

}

protected override Transform NHHCIIKGFPE
{
get 		{
			return null;
		}

}

protected override bool PEDMHGEFFCL
{
get 		{
			return false;
		}

}

private bool PFOMPFCAMAB
{
get 		{
			return false;
		}

}

protected List<DGMPBIPKJEB> JDHNENKOGFC
{
get 		{
			return null;
		}

}

private JNODIIINKKJ.PPDDHHHCIBC OEBONIBOPKM
{
get 		{
			return JNODIIINKKJ.PPDDHHHCIBC.None;
		}

}

public override string Name
{
get 		{
			return null;
		}

}

public override bool AreCircuitsPersistable
{
get 		{
			return false;
		}

}

public override bool IsBeta
{
get 		{
			return false;
		}

}

public override bool IsDeveloperOnly
{
get 		{
			return false;
		}

}

public long PersistableDataTimestamp
{
get 		{
			return 0L;
		}

set {
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

public bool IsObjectSelected
{
get 		{
			return false;
		}

private set {
		}
}

		protected override void Awake()
		{
		}

		protected void AJFOIBEJKGJ()
		{
		}

		protected override void POCNJIOKNDL(LNDJBKINLAJ FJBLCAGJCDO)
		{
		}

		public void CreateObjectBoard()
		{
		}

		public virtual Task CreateObjectBoard(bool ABPCIMNFOFF)
		{
			return null;
		}

		protected virtual void MALPMPHEBMN()
		{
		}

		private void IOENHPGIELM(bool JJHLECIBCOD)
		{
		}

		private void IOENHPGIELM()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected virtual (Guid, Guid, bool)? ABAJGLDIPCH(MonoBehaviourPun NEOCAENIDLL)
		{
			return null;
		}

		private EHPNEOOACFA OPLEBFHDHOC()
		{
			return null;
		}

		private EHPNEOOACFA GMOKAKDBDMP()
		{
			return null;
		}

		private EHPNEOOACFA PFPCGBBBFEB(ControlPanelSerializedState DADHJJNJEFA)
		{
			return null;
		}

		private string AEFNMELOGAP(Tool IEGMBEPJMGC)
		{
			return null;
		}

		public override void Bind(OEJOPFEPHFI JLPKCGOJDJN)
		{
		}

		public override void Unbind()
		{
		}

		public override void OnVisualizationAcquired(object JJMNDCAFBDA)
		{
		}

		public override void OnVisualizationReleased(object JJMNDCAFBDA)
		{
		}

		public override void ConfigureAttachedObject()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void DDIIGEIOOEK()
		{
		}

		void GBIGGECGKHF.OnCreatedBySpawning()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DDIIGEIOOEK
			this.DDIIGEIOOEK();
		}

		private void POBIBPABPKK()
		{
		}

		void NKHKPBPHIEG.OnSelected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in POBIBPABPKK
			this.POBIBPABPKK();
		}

		private void DOGPKLNNNPA()
		{
		}

		void NKHKPBPHIEG.OnDeselected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DOGPKLNNNPA
			this.DOGPKLNNNPA();
		}

		[PBOMGCLBFHF]
		public override void RpcObjectReceiveRpc(NDMIIOKAAIK PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private void GFHCNDBGPPJ()
		{
		}

		[CompilerGenerated]
		private bool HODNPEAFBJG()
		{
			return false;
		}

		[CompilerGenerated]
		private bool EIJOPDNCBHN()
		{
			return false;
		}

		[CompilerGenerated]
		private void LOPGDLBEJAA()
		{
		}

		[CompilerGenerated]
		private bool FCCFOHLIMFB()
		{
			return false;
		}

		[CompilerGenerated]
		private Task<global::LAFJBBFBCGA<MFEHAEMCKCJ, HODHNINHENI>> GPIIOCBCANK()
		{
			return null;
		}

		[CompilerGenerated]
		private object EDNMNPACPLP()
		{
			return null;
		}
	}
}
