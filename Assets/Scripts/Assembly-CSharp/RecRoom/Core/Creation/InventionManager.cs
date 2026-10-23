using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RRUI.Dialogs;

namespace RecRoom.Core.Creation
{
	public class InventionManager : NetworkedSingletonMonoBehaviour<InventionManager>
	{
		public interface CLMIBMNNOCE : JGLPGIIHGIM
		{

 bool FFEOJACGMNP
{
get ;
}

 NLOGLNAFFOA JICIJOOLJMP
{
get ;
}

			void LHHPDAPNPLJ();
		}

		public class JAFEFOEFMDB : CLMIBMNNOCE, JGLPGIIHGIM
		{
			private readonly CreationObject BPEGJLIMPPJ;

public bool FFEOJACGMNP
{
get 			{
				return false;
			}

}

public NLOGLNAFFOA JICIJOOLJMP
{
get 			{
				return null;
			}

}

public Type BulkDeleteHandlerType
{
get 			{
				return null;
			}

}

public object BulkDeleteObject
{
get 			{
				return null;
			}

}

public Guid BulkDeletableId
{
get 			{
				return default;
			}

}

			public void LHHPDAPNPLJ()
			{
			}

			public JAFEFOEFMDB(CreationObject BPEGJLIMPPJ)
			{
			}
		}

		public class DJNPKOPAMOI : CLMIBMNNOCE, JGLPGIIHGIM
		{
			private readonly EKIIIJIOBCC KNBPIEINLIG;

			private readonly NLOGLNAFFOA IGBCMCMLIDG;

public bool FFEOJACGMNP
{
get 			{
				return false;
			}

}

public NLOGLNAFFOA JICIJOOLJMP
{
get 			{
				return null;
			}

}

public Type BulkDeleteHandlerType
{
get 			{
				return null;
			}

}

public object BulkDeleteObject
{
get 			{
				return null;
			}

}

public Guid BulkDeletableId
{
get 			{
				return default;
			}

}

			public void LHHPDAPNPLJ()
			{
			}

			public DJNPKOPAMOI(EKIIIJIOBCC KNBPIEINLIG)
			{
			}
		}

		private sealed class PMGGHEOONHO
		{
			public InventionManager _003C_003E4__this;

			public bool isTrial;

			public OEBAEGDPBLA invention;

			public string inventionSubtype;

			public string entrypointName;

			public DialogListModel dialogListModel;

			internal void _003CCheckIfNeedDormSkinReplacement_003Eb__0(IReadOnlyList<long> spawnedDormSkins)
			{
			}
		}

		private sealed class JEEBBLNEDBG
		{
			public OEBAEGDPBLA invention;

			public string inventionSubtype;

			internal void _003CHandleInventionTrialOrSpawning_003Eb__1(bool isSuccess)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct MKOKELNLOAO : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public InventionManager _003C_003E4__this;

			public long inventionId;

			public int actorNumber;

			private TaskAwaiter<CreationManager.LJGEDIDFFCO> _003C_003Eu__1;

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

		private sealed class NOAIJONPGNL
		{
			public long inventionToSpawnId;

			public InventionManager _003C_003E4__this;

			public bool isTrial;

			public string inventionToSpawnSubType;

			public string entrypoint;

			public List<CLMIBMNNOCE> bulkDeleteObjects;

			public Action<OEBAEGDPBLA> _003C_003E9__2;

			public Action<OEBAEGDPBLA> _003C_003E9__4;

			public Action<CreationManager.LJGEDIDFFCO> _003C_003E9__3;

			internal void _003CRpcMasterRequestBulkDeleteAndReplaceWithInvention_003Eb__0(CreationManager.LJGEDIDFFCO bulkDeleteResult)
			{
			}

			internal void _003CRpcMasterRequestBulkDeleteAndReplaceWithInvention_003Eb__2(OEBAEGDPBLA invention)
			{
			}

			internal void _003CRpcMasterRequestBulkDeleteAndReplaceWithInvention_003Eb__3(CreationManager.LJGEDIDFFCO result)
			{
			}

			internal void _003CRpcMasterRequestBulkDeleteAndReplaceWithInvention_003Eb__4(OEBAEGDPBLA invention)
			{
			}
		}

		private sealed class AOFHCJJLBJI
		{
			public long inventionId;

			internal bool _003CGetInventionObjectsWithId_003Eb__2(CLMIBMNNOCE i)
			{
				return false;
			}
		}

		private const float NGFIEJKOEHF = 3f;

		private TaskCompletionSource<MFEHAEMCKCJ> AMNEAEAFLKK;

		private LHMPPJKHCJG LDFABJFFKHN;

		protected override void Awake()
		{
		}

		public bool IsInventionSpawned(long KBPFKPGOCFN)
		{
			return false;
		}

		public void CheckIfNeedDormSkinReplacement(DialogListModel DJDIJKOIFCC, bool CIDMHILFDLF, bool MAJIEPBPDFL, OEBAEGDPBLA EGDOIKMDMJM, string PAFBGIENLNL, string PGEIBONDJJP)
		{
		}

		public void HandleInventionTrialOrSpawning(bool CIDMHILFDLF, OEBAEGDPBLA EGDOIKMDMJM, string PAFBGIENLNL, string PGEIBONDJJP)
		{
		}

		public Task DespawnInvention(long KBPFKPGOCFN)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestDeleteInvention(long KBPFKPGOCFN, int LFKIHFDBJNI, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		private Task DCEJMEHIONA(long KBPFKPGOCFN, int LFKIHFDBJNI)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcActorDeleteInventionComplete()
		{
		}

		public void ReplaceInventionList(IEnumerable<long> NNCOCKMLOME, bool CIDMHILFDLF, long PMGBNJCAAON, string KGINHLCOIII, string DMIKNHOOEIG)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestBulkDeleteAndReplaceWithInvention(object NNCOCKMLOME, bool CIDMHILFDLF, long PMGBNJCAAON, string KGINHLCOIII, string DMIKNHOOEIG, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		private void CBHAMKHNDFK()
		{
		}

		private IEnumerable<CLMIBMNNOCE> JNACCBOHLCH(long KBPFKPGOCFN)
		{
			return null;
		}

		private global::NCOKFFGPIJM<IReadOnlyList<long>> KOCNHCKBBHI()
		{
			return null;
		}
	}
}
