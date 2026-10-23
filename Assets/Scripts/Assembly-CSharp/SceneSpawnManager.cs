using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom;
using UnityEngine;

[Serializable]
public class SceneSpawnManager : NMIKADGOIOE
{
	private struct CIHJNMPNNLB
	{
		public class JKCFEOPPIOI : IComparer<CIHJNMPNNLB>
		{
			public int Compare(CIHJNMPNNLB NNMPJECKECI, CIHJNMPNNLB EFNJCAIBDLA)
			{
				return 0;
			}
		}

		public static JKCFEOPPIOI AODEGPHMMPD;

		public SceneSpawnPoint ELGLOEDDKAJ;

		public bool DFHPFPDADGE;
	}

	public enum LGLCODILPIH
	{
		Uninitialized = 0,
		NotRunning = 1,
		WaitingForClusterLod = 2,
		WaitingForRoomKeys = 3,
		WaitingForBigData = 4,
		Instantiating = 5,
		WaitingForCameraFade = 6,
		WaitingForDelay = 7,
		SpawnedWaitingForFade = 8,
		SpawnedAndFadedIn = 9
	}

	private enum EBKIKKLFOPD : byte
	{
		Success = 0,
		CancelledByAnotherRequest = 1
	}

	public class MBELAEHDFMG : TimeoutException
	{
		public MBELAEHDFMG()
		{
		}

		public MBELAEHDFMG(Exception OAFPGAMPFDL)
		{
		}

		public MBELAEHDFMG(string OFCFPGACNJB, Exception OAFPGAMPFDL = null)
		{
		}
	}

	private sealed class NGAOOGGMFML
	{
		public CancellationToken token;
	}

	private sealed class JPJDGFHMCLE
	{
		public TaskCompletionSource<(EBKIKKLFOPD, Player)> localPlayerSpawnRequestCompletionSource;

		public NGAOOGGMFML CS_0024_003C_003E8__locals1;

		internal void _003CRequestSpawnFromMasterClient_003Eb__1()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct BMNALNMJLEM : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Player> _003C_003Et__builder;

		public global::FKCKMADGELN<string>.PPKAMDIDPFK stackTimer;

		public JLJEJNFJIDP networking;

		public CancellationToken externalToken;

		private NGAOOGGMFML _003C_003E8__1;

		public SceneSpawnManager _003C_003E4__this;

		private float _003CtotalPlayerSpawnForSameMasterTimeout_003E5__2;

		private float _003CperMessageTimeout_003E5__3;

		private float _003CspawnPlayerStart_003E5__4;

		private global::FKCKMADGELN<string>.PPKAMDIDPFK _003CspawnTimer_003E5__5;

		private int _003Ci_003E5__6;

		private BENALPDHOED _003CmasterCancellationScope_003E5__7;

		private int _003Cattempts_003E5__8;

		private global::FKCKMADGELN<string>.PPKAMDIDPFK _003C_003E7__wrap8;

		private byte _003CrequestId_003E5__10;

		private TaskAwaiter<(EBKIKKLFOPD, Player)> _003C_003Eu__1;

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
	private struct BGNLBONKOPJ : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Player> _003C_003Et__builder;

		public global::FKCKMADGELN<string>.PPKAMDIDPFK stackTimer;

		public CancellationToken cancellationToken;

		public SceneSpawnManager _003C_003E4__this;

		public JLJEJNFJIDP networking;

		private global::FKCKMADGELN<string>.PPKAMDIDPFK _003CspawnRoutineTimer_003E5__2;

		private global::FKCKMADGELN<string>.PPKAMDIDPFK _003C_003E7__wrap2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Player> _003C_003Eu__2;

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
	private struct DNFGPLMGAPG : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CancellationToken cancellationToken;

		public SceneSpawnManager _003C_003E4__this;

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
	private struct JOAHPLHFJAD
	{
		public RigidbodyEx parentRigidbodyEx;

		public Vector3 localPosition;

		public Quaternion localRotation;
	}

	private sealed class FNNBKGPNNPH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public string title;

		public Func<bool> untilFunc;

		private float _003CstartTime_003E5__2;

		private float _003CnextLogTime_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public FNNBKGPNNPH(int _003C_003E1__state)
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
	}

	private sealed class KJNACBNEBNC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Func<string> title;

		public Func<bool> untilFunc;

		private float _003CstartTime_003E5__2;

		private float _003CnextLogTime_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public KJNACBNEBNC(int _003C_003E1__state)
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
	}

	private PNPHOOBLIIO keepsakeManager;

	private RecRoomSceneManager sceneManager;

	private List<SceneSpawnPoint> dynamicSpawnPoints;

	private List<CIHJNMPNNLB> filteredSpawnPoints;

	private FIHGBEHGLGB spawnNotificationRestrictionFlag;

	private Coroutine spawnNewPlayerCoroutine;

	public static Regex RegexClientJoinData;

	private SceneSpawnPoint[] _sceneSpawnPoints;

	private static LGLCODILPIH _localPlayerSpawnState;

	public const string PREVIOUSACTIVITY_PROPERTY = "prev_activity";

	public const string PREVIOUSROOM_PROPERTY = "prev_room";

	public const string PREVIOUSSUBROOM_PROPERTY = "prev_subroom";

	public const string PREVIOUSROOM_TAGS_PROPERTY = "prev_room_tags";

	private byte currentRequestId;

	private readonly Dictionary<byte, TaskCompletionSource<(EBKIKKLFOPD, Player)>> pendingSpawnRequests;

	private SceneSpawnPoint[] SceneSpawnPoints => null;

	public static LGLCODILPIH LocalPlayerSpawnState
	{
		get
		{
			return LGLCODILPIH.Uninitialized;
		}
		set
		{
		}
	}

	public void JGHENDHCBHF(RecRoomSceneManager MACMCOFLIIO)
	{
	}

	public void BJDNGFKFKPK()
	{
	}

	public void LJODMHLJPAD()
	{
	}

	public void CDJHKCNAIKI()
	{
	}

	public void KPFOBOPDHJM()
	{
	}

	public void LKADLOPIECG(byte AMGNCPLIAAC, CHILKDJABBF DEODPCHAFKO)
	{
	}

	private static string KPCKFOBNNGO(string JHMBNMIOGBF)
	{
		return null;
	}

	private byte IMOIDGAJDDD()
	{
		return 0;
	}

	private Task<Player> BABEMFMKCAP(JLJEJNFJIDP GCOGGHDIHNM, global::FKCKMADGELN<string>.PPKAMDIDPFK GLOICACPAOF, CancellationToken MFMBGLNBFDO)
	{
		return null;
	}

	public Task<Player> JGOEINDPDLF(JLJEJNFJIDP GCOGGHDIHNM, CancellationToken NDKAKDJMDIF, global::FKCKMADGELN<string>.PPKAMDIDPFK GLOICACPAOF)
	{
		return null;
	}

	public Task ODEADHAAFDB(CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	public void HKPCMKMMOHH(byte AMGNCPLIAAC, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, PhotonView IGDDAMGFGCC)
	{
	}

	public void NPAHOHINHAP(bool CDEPAJILBJA)
	{
	}

	public void HOKPEAPMNDJ(CHILKDJABBF EKOFNPFCLMO, bool CDEPAJILBJA)
	{
	}

	private IEnumerator PEHMGAFOJNM(string OFMGPNLDCAB, Func<bool> LFELKIGOALP)
	{
		return null;
	}

	private IEnumerator PEHMGAFOJNM(Func<string> OFMGPNLDCAB, Func<bool> LFELKIGOALP)
	{
		return null;
	}

	private void JKIIDNPLKLD()
	{
	}

	private void NMPHGHCEDJE()
	{
	}

	public void KGCEIGIJPNB(SceneSpawnPoint ELGLOEDDKAJ)
	{
	}

	public void BMKBAAOMCAJ(SceneSpawnPoint[] BEKAAFMPMNI)
	{
	}

	public void DLLJAMOCKAL(SceneSpawnPoint ELGLOEDDKAJ)
	{
	}

	public void PKKEFKPMNNA(SceneSpawnPoint[] BEKAAFMPMNI)
	{
	}

	public void NGHHBMAPIML(object IALNODEHBNN)
	{
	}

	public void OJHKLNPLFPJ(object IALNODEHBNN)
	{
	}

	public SceneSpawnPoint FGODIIFHGOO(string LDKCCPNJIGC = "", long GNNKEGEPPNL = 0L, long DIALDJBBFFL = 0L, string FECFCCPIFPK = null)
	{
		return null;
	}

	private SceneSpawnPoint KJIGJJGBHCF(IList<SceneSpawnPoint> BEKAAFMPMNI, string LDKCCPNJIGC, long GNNKEGEPPNL, long DIALDJBBFFL, string FECFCCPIFPK)
	{
		return null;
	}

	private static SceneSpawnPoint ELKIKPDCFOO(IList<SceneSpawnPoint> BEKAAFMPMNI, string LDKCCPNJIGC)
	{
		return null;
	}

	private SceneSpawnPoint PLKHOHGCJDH(IList<SceneSpawnPoint> BEKAAFMPMNI, long DPGFOHLBLPF = 0L, long JAAHKAHCILF = 0L, string FECFCCPIFPK = null)
	{
		return null;
	}

	private void LPFKKKFKFJA(IList<SceneSpawnPoint> BEKAAFMPMNI, long DPGFOHLBLPF, long JAAHKAHCILF, string FECFCCPIFPK, List<CIHJNMPNNLB> ACHFIOANLOG)
	{
	}

	[CompilerGenerated]
	private static Vector3 NEKPLGIMDAJ(ref JOAHPLHFJAD P_0)
	{
		return default;
	}

	[CompilerGenerated]
	private static Quaternion NJFBCAIEFBG(ref JOAHPLHFJAD P_0)
	{
		return default;
	}
}
