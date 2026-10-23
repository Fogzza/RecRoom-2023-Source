using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Pathfinding;
using Pathfinding.Util;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.AI
{
	public class UGCNavMeshManager : BaseBigDataNetworkingManager<CLJFINCAEHL>, OJIHDJHLFFI
	{
		private sealed class HIGPGKDNEGK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public DBIPHDIEBCM initializationPromise;

			public UGCNavMeshManager _003C_003E4__this;

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
			public HIGPGKDNEGK(int _003C_003E1__state)
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

		private sealed class KKHIPKJBNKG
		{
			public UGCNavMeshManager _003C_003E4__this;

			public float bakeStartTime;

			internal void _003CRunNavMeshGeneration_003Eb__0(RecastGraph navMeshGraph)
			{
			}

			internal void _003CRunNavMeshGeneration_003Eb__1(string error)
			{
			}
		}

		private sealed class PIFBCOGHGND : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public UGCNavMeshManager _003C_003E4__this;

			public global::INEAOPIKBME<RecastGraph> generationPromise;

			private RecastGraph _003CrecastGraph_003E5__2;

			private int _003ClastProgress_003E5__3;

			private IEnumerator<Progress> _003C_003E7__wrap3;

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
			public PIFBCOGHGND(int _003C_003E1__state)
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
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class MIFBNBMALNO
		{
			public RetainedGizmos.Hasher hasher;

			internal void _003CUpdateNavMeshHash_003Eb__0(GraphNode node)
			{
			}
		}

		private sealed class LCHGLFHLCLE : IEnumerable<BigDataTrackedObject>, IEnumerable, IEnumerator<BigDataTrackedObject>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private BigDataTrackedObject _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public UGCNavMeshManager _003C_003E4__this;

			BigDataTrackedObject IEnumerator<BigDataTrackedObject>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public LCHGLFHLCLE(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<BigDataTrackedObject> IEnumerable<BigDataTrackedObject>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private const int HODNJJOJDIO = 256;

		private const int CLBAOGJELIK = 32;

		private const float GFHIHODPFKB = 1.5f;

		private global::INEAOPIKBME<RecastGraph> INBDNMFAONH;

		private DBIPHDIEBCM DKOPPFKODEH;

		private DisableObjectWhenManuallyHiddenOrCircuitsHidden HPIPAEKBIHJ;

		private MeshRenderer BOIONKPILEH;

		private Mesh OAAOCPDDPDI;

		private ulong LFNJDPKMNMP;

		private JNKNMMDAHCF DHCLACKALOF;

		private NNBAJLCGAOK JGEGKOOCOEH;

		private Action IECFMKEHBBB__BackingField;

		private Action GEHEGEPOCMC__BackingField;

		private static UGCNavMeshManager EGAIHCNFOEN;

		private RecastGraph MKBDGGEADNO;

		private ulong HCFNIBMPGGA;

		private ulong FFLOAADIBMP;

		private float HNBHPJKANMM;

		private float GNJIJJHAJMK;

		private bool GCAKKFENOCJ;

		private BigDataTrackedObject JIONMNFLNCI;

public static UGCNavMeshManager Instance
{
get 		{
			return null;
		}

private set {
		}
}

public static bool IsInitialized
{
get 		{
			return false;
		}

}

public RecastGraph NavMeshGraph
{
get 		{
			return null;
		}

private set {
		}
}

public ulong NavMeshHash
{
get 		{
			return 0uL;
		}

private set {
		}
}

private ulong NPABPJIDGAF
{
get 		{
			return 0uL;
		}

set {
		}
}

public static bool NavMeshInitialized
{
get 		{
			return false;
		}

}

public float LastNavMeshBakeTime
{
get 		{
			return 0f;
		}

private set {
		}
}

public float LastNavMeshBakeDuration
{
get 		{
			return 0f;
		}

private set {
		}
}

public bool AllowNavMeshVisible
{
get 		{
			return false;
		}

set {
		}
}

private bool ICOIDGDKEIH
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ PersistableRunFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

protected override IEnumerable<BigDataTrackedObject> CDDDMNGNMJJ
{
get 		{
			return null;
		}

}

public event Action NavMeshUpdated {
add {
		}
remove {
		}
}

public event Action NavMeshInvalidated {
add {
		}
remove {
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

		public void LocalPlayerBakeNavMesh()
		{
		}

		public void ClearNavMesh()
		{
		}

		public void InitializeBakeVolume()
		{
		}

		private static void HGLDHEBBJEF(List<Vector3> EBMLPFHDHMP, List<int> EMBOJIFBMBL, float IOLADPJDFCK)
		{
		}

		private IEnumerator<EGGPGCCKPCO> JCFPHCMPDLM(DBIPHDIEBCM DKAAGKDFDIK)
		{
			return null;
		}

		[PBOMGCLBFHF]
		protected void RpcMasterInstantiateNavMeshBakeVolume()
		{
		}

		private void DKEIPPAKCKJ()
		{
		}

		private IEnumerator<EGGPGCCKPCO> OBNGAIDBOMG(global::INEAOPIKBME<RecastGraph> LCILKCGKGGA)
		{
			return null;
		}

		private int JDDIFFIDDGD(float EHDNENMEDEO, float CKOHOKHDKPA)
		{
			return 0;
		}

		private void BEKGLEAFEKL()
		{
		}

		private void DEEHJLIDHEE(GHCCKFEJDOA PKJIEOPNCHK)
		{
		}

		private void JHEJKOGOGAC()
		{
		}

		private void BLBDCDOMGCJ()
		{
		}

		private void PMIDBCMOAPC()
		{
		}

		private void NNFECNJIJDH()
		{
		}

		private void DEDAPJLIPHD()
		{
		}

		public Task DeserializeFrom(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public void SerializeTo(ref KHMOHFAFGBI KGMPBFBAMCF)
		{
		}

		private FMDKMFLEJJL AMEDEJDCOPB()
		{
			return null;
		}

		private bool NLKKPIDAJOC(FMDKMFLEJJL NMFPFHBNPAO, short AJMCKPPKOFJ)
		{
			return false;
		}

		[PBOMGCLBFHF]
		protected void RpcUpdateNavMeshData(CLJFINCAEHL NMFPFHBNPAO)
		{
		}

		protected override bool NFFNFEEDAMM(BigDataTrackedObject ICHBECDKHOJ)
		{
			return false;
		}

		protected override CLJFINCAEHL ABCAMCIBBPC()
		{
			return null;
		}

		protected override void NHEOLIFKNCK(CLJFINCAEHL GFFOJMCNLLE)
		{
		}

		protected override bool BOMBAGJKMAP(CLJFINCAEHL GFFOJMCNLLE)
		{
			return false;
		}

		protected override HashSet<int> JFPOJIIKPHK(CLJFINCAEHL HJHCHKNIJAF)
		{
			return null;
		}

		protected override void ODAOOOJGPBA(PJLAOHCINDI MDGDEIDGAFE)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcRequestPlayerDataNavMeshManager(System.Guid AMGNCPLIAAC, GGGMJMEFFOC PPLJGCMIKOB)
		{
		}

		protected override void BCCMCHMPFJJ(CHILKDJABBF OJMKLBPAANP, System.Guid AMGNCPLIAAC, CLJFINCAEHL HJHCHKNIJAF)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcDataResponseNavMesh(System.Guid GHENACKCILD, CLJFINCAEHL HJHCHKNIJAF)
		{
		}
	}
}
