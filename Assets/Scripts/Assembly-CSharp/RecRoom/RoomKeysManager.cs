using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using CodeStage.AntiCheat.ObscuredTypes;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom
{
	public class RoomKeysManager : NetworkedSingletonMonoBehaviour<RoomKeysManager>
	{
		public enum GELCGJCLKEA
		{
			Running = 0,
			Completed = 1,
			Faulted = 2
		}

		private sealed class MMBMKBAMKFL
		{
			public long roomId;

			internal bool _003CDoesCurrentRoomContainAnyKeys_003Eb__0(EOHADGOEBOD k)
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct BONAAIOFKDK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AHDBIFJNDCH args;

			public CancellationToken cancellationToken;

			public RoomKeysManager _003C_003E4__this;

			private float _003CnextLogTime_003E5__2;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		private sealed class NJCEHPJMIPJ
		{
			public RoomKeysManager _003C_003E4__this;

			public long roomId;

			internal bool _003CRemoveRoomKeysFromCacheByRoomId_003Eb__0(long k)
			{
				return false;
			}
		}

		private sealed class IKFBNPKFGLD
		{
			public Guid replicationId;

			internal bool _003CGetCachedRoomKeyByReplicationId_003Eb__0(KeyValuePair<long, EOHADGOEBOD> kvp)
			{
				return false;
			}
		}

		private sealed class GLEOKCLEMKL
		{
			public ObscuredLong roomId;

			internal bool _003CGetCachedRoomKeysForCurrentRoom_003Eb__0(EOHADGOEBOD k)
			{
				return false;
			}
		}

		private sealed class KCMHBFGLDIO
		{
			public Guid replicationId;

			public ObscuredLong roomId;

			internal bool _003CGetCachedRoomKeyForCurrentRoomByReplicationId_003Eb__0(KeyValuePair<long, EOHADGOEBOD> kvp)
			{
				return false;
			}
		}

		private sealed class ODLDDINLPEH
		{
			public long roomKeyId;

			internal bool _003CDoesLocalPlayerOwnKey_003Eb__0(long id)
			{
				return false;
			}
		}

		private sealed class GPAIFGBMBFJ
		{
			public EOHADGOEBOD roomKey;

			public RoomKeysManager _003C_003E4__this;

			public int playerId;

			internal bool _003CDoesPlayerOwnKeyShared_003Eb__0(long id)
			{
				return false;
			}

			internal void _003CDoesPlayerOwnKeyShared_003Eb__1(bool ownsKey)
			{
			}
		}

		private sealed class LOKJBELMJOB
		{
			public RoomKeysManager _003C_003E4__this;

			public long? initialBalance;

			public string purchaseSource;

			public EOHADGOEBOD key;

			internal global::NCOKFFGPIJM<(bool, string)> _003CPurchaseRoomKey_003Eb__0(LKKOPNLCJBC.RoomKeyPurchaseResponseDTO response)
			{
				return null;
			}

			internal void _003CPurchaseRoomKey_003Eb__1(string error)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct MOKIENKCJAN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<global::FAIKNKAIPLB<IENGILMPFNE>> _003C_003Et__builder;

			public RoomKeysManager _003C_003E4__this;

			public CHILKDJABBF recipient;

			public long roomKeyId;

			public JEGAPHLGBJA e;

			public CancellationToken cancellationToken;

			public Action<string> logWarningAction;

			private TaskAwaiter<global::GEMGLHHAKOD<HCEPBACKNIL>> _003C_003Eu__1;

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

		private sealed class LAJDBDGKLBL
		{
			public RoomKeysManager _003C_003E4__this;

			public int accountId;

			public long roomKeyId;

			internal void _003CRpcOnNotifiedOfRoomKeyUnlockStatusChanged_003Eb__0(bool playerOwnsRoomKey)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct LIMMOMIJLHJ : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<FOKGKPOPJPF> _003C_003Et__builder;

			public int playerId;

			public long roomKeyId;

			public CancellationToken cancellationToken;

			public RoomKeysManager _003C_003E4__this;

			private TaskAwaiter<FOKGKPOPJPF> _003C_003Eu__1;

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

		private sealed class PCOPPMHIBOI
		{
			public Guid roomKeyId;

			internal void _003CRpcShowPurchasePrompt_003Eb__0()
			{
			}
		}

		private const string NMGGOFLJNAB = "Unknown error occured. If this persists, please contact us at recroom.zendesk.com";

		private const string MBEOGHDCDNL = "CV2_Purchase_Prompt_Chip";

		private const float KPJFAOPCLGC = 1f;

		[SerializeField]
		private RecRoomAudioClip successfulPurchaseSFX;

		private readonly Dictionary<long, EOHADGOEBOD> KMKFANKOILK;

		private readonly Dictionary<int, ISet<long>> ALKNEOLJKNE;

		public static readonly global::HHOBPMOCKMJ<EOHADGOEBOD> OnRoomKeyUpdated;

		public static readonly global::BPEPJJDICII<long, Guid> OnRoomKeyDeleted;

		public static readonly global::BPEPJJDICII<long, Guid> OnLocalPlayerPurchasedRoomKey;

		private Lazy<FEIKFKAICHC> JJJMDJMNEIL;

		private Lazy<IILDCCEMGBA> MOFCMOKAHHO;

		private IDisposable CNAGCKBFLOE;

		private GELCGJCLKEA ACJFEADMLBN;

		private LFHHMEALLBA FLIFJAGEPCH;

		private global::FEJPODIAHHP<OIMKCBGAAFN, global::GEMGLHHAKOD<HCEPBACKNIL>> MOPBKIOEJNK;

private FEIKFKAICHC JINHNPGMCMC
{
get 		{
			return null;
		}

}

private IILDCCEMGBA PFGCMJCEEMA
{
get 		{
			return null;
		}

}

public GELCGJCLKEA CurrentRoomKeyDownloadStatus
{
get 		{
			return GELCGJCLKEA.Running;
		}

private set {
		}
}

private static long HBODJBBGFJE
{
get 		{
			return 0L;
		}

}

private LFHHMEALLBA OGMLKPLEICD
{
get 		{
			return null;
		}

}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public LAHBDKNMNHN DownloadPurchasedKeys()
		{
			return null;
		}

		public bool DoesCurrentRoomContainAnyKeys()
		{
			return false;
		}

		public ILODPOPFPAH CreateDeserializationHandler()
		{
			return null;
		}

		private Task IEJAMDPGOPB(AHDBIFJNDCH ADCFFAJGNAM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private Task KGJJEBLMAFF(AHDBIFJNDCH ADCFFAJGNAM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private void KPFCCMIOGHH(EOHADGOEBOD NKEGLGHKOJC)
		{
		}

		private void JLAOHEGBBGL(long LLKNDIDFNDB)
		{
		}

		private void KLKNCMGIKKC(long EPOBIFCHLNM, bool EHHJDPMMIAK = false)
		{
		}

		private void JKHFJKIJEAF(IList<EOHADGOEBOD> IGHHPCGKHAM, bool EHHJDPMMIAK = false)
		{
		}

		private void KNMNABGPKLP(EOHADGOEBOD NKEGLGHKOJC, bool EHHJDPMMIAK = false)
		{
		}

		private void DCCCOCAFELN(long LLKNDIDFNDB, bool EHHJDPMMIAK = false)
		{
		}

		public void StorePlayerOwnedRoomKeyInCache(int PCKCPNGPNBJ, IEnumerable<long> GKFDALGIEIB)
		{
		}

		public void StorePlayerOwnedRoomKeyInCache(int PCKCPNGPNBJ, long LLKNDIDFNDB)
		{
		}

		private void MCEBLHKCHLI(int PCKCPNGPNBJ, long LLKNDIDFNDB)
		{
		}

		private void HPNBFHNMLGL(int EJIHLJJMOBD, long LLKNDIDFNDB, bool DLEMNBPMGBG)
		{
		}

		private bool PHJMONLAKCK(int EJIHLJJMOBD, long LLKNDIDFNDB)
		{
			return false;
		}

		public EOHADGOEBOD GetCachedRoomKeyById(long LLKNDIDFNDB)
		{
			return null;
		}

		public EOHADGOEBOD GetCachedRoomKeyByReplicationId(Guid IEMFHCFEHCA)
		{
			return null;
		}

		public IEnumerable<EOHADGOEBOD> GetCachedRoomKeysForCurrentRoom()
		{
			return null;
		}

		public EOHADGOEBOD GetCachedRoomKeyForCurrentRoomByReplicationId(Guid IEMFHCFEHCA)
		{
			return null;
		}

		public global::NCOKFFGPIJM<List<EOHADGOEBOD>> GetRoomKeysForRoom(long EPOBIFCHLNM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<List<EOHADGOEBOD>> GetRoomKeysForCurrentRoomForceReload()
		{
			return null;
		}

		public bool DoesLocalPlayerOwnKey(Guid IEMFHCFEHCA)
		{
			return false;
		}

		public bool DoesLocalPlayerOwnKey(long LLKNDIDFNDB)
		{
			return false;
		}

		public global::NCOKFFGPIJM<bool> CV2_DoesPlayerOwnKey(int PCKCPNGPNBJ, Guid IEMFHCFEHCA)
		{
			return null;
		}

		public global::NCOKFFGPIJM<bool> DoesPlayerOwnKey(int PCKCPNGPNBJ, Guid IEMFHCFEHCA)
		{
			return null;
		}

		public global::NCOKFFGPIJM<bool> DoesPlayerOwnKeyShared(int PCKCPNGPNBJ, Guid IEMFHCFEHCA, Func<int, EOHADGOEBOD, global::NCOKFFGPIJM<bool>> NMNMKPEEGNL)
		{
			return null;
		}

		public global::NCOKFFGPIJM<(bool, string)> PurchaseRoomKey(Guid IEMFHCFEHCA, long NDGJEBNJMAB, string NNECEELJHMM = null)
		{
			return null;
		}

		private global::NCOKFFGPIJM<(bool, string)> MHLHBLNIMOD(EOHADGOEBOD FDAIMOMOHIG, long NDGJEBNJMAB, long? NCFOPAPFAKL, string NNECEELJHMM = null)
		{
			return null;
		}

		public static void TrySendFunnelAnalytics(OILDLLGEMKP.CJLOPHACJOC GDGDAIAMBKP, EOHADGOEBOD NKEGLGHKOJC, string NNECEELJHMM = null, string NLJOHEKGNDH = null)
		{
		}

		public string HandleSuccessfulPurchase(EOHADGOEBOD NKEGLGHKOJC, long? NCFOPAPFAKL, FLOBEEJEPJO MLDANHIGANI, string NNECEELJHMM = null)
		{
			return null;
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestShowPurchasePrompt(JEGAPHLGBJA GCBHEJANCJK, CHILKDJABBF EKOFNPFCLMO, Guid LLKNDIDFNDB)
		{
			return default;
		}

		private void PCFDEEEBEFF(out float OMMPKPIKPEB, out int CNLKNFNEKPL)
		{
			OMMPKPIKPEB = default;
			CNLKNFNEKPL = default;
		}

		private string HEFCHKALIJC(EOHADGOEBOD NKEGLGHKOJC, string NLJOHEKGNDH, LKKOPNLCJBC.RoomKeyPurchaseResponseDTO MLDANHIGANI, string NNECEELJHMM = null)
		{
			return null;
		}

		public Task<global::FAIKNKAIPLB<IENGILMPFNE>> Cv2AwardRoomKeyAsync(JEGAPHLGBJA GCBHEJANCJK, long LLKNDIDFNDB, CHILKDJABBF EMPMIKKJDKE, Action<string> OGBLKKKOFKO, CancellationToken NDKAKDJMDIF = default(CancellationToken))
		{
			return null;
		}

		private void OGMOLLGKBHI(long LLKNDIDFNDB, CHILKDJABBF EKOFNPFCLMO, bool ACONMGEGBIJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnNotifiedOfRoomKeyUnlockStatusChanged(long LLKNDIDFNDB)
		{
		}

		private Task<global::GEMGLHHAKOD<HCEPBACKNIL>> FHAIFBPFNCN(long LLKNDIDFNDB, int EJIHLJJMOBD, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private Task<List<global::GEMGLHHAKOD<HCEPBACKNIL>>> NCFGEHALOBI(IEnumerable<OIMKCBGAAFN> GDKJDDCKGLO, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public Task<FOKGKPOPJPF> RevokeRoomKeyForPlayerAsync(long LLKNDIDFNDB, int PCKCPNGPNBJ, CancellationToken NDKAKDJMDIF = default(CancellationToken))
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcMasterUpdatePlayerOwnedRoomKey(int PCKCPNGPNBJ, long LLKNDIDFNDB)
		{
		}

		[PBOMGCLBFHF]
		private void RpcUpdateRoomKey(long LLKNDIDFNDB, Guid IEMFHCFEHCA, long EPOBIFCHLNM, string KNOPFGAGMCN, string GKHMKKBKEKC, int PJJFBBBIFOP, string NPOEAPJKNFN, long PJJACNOGHPF, Guid OAELEOGJFOL)
		{
		}

		[PBOMGCLBFHF]
		private void RpcDeleteRoomKey(long LLKNDIDFNDB)
		{
		}

		[PBOMGCLBFHF]
		private void RpcShowPurchasePrompt(Guid LLKNDIDFNDB)
		{
		}

		[CompilerGenerated]
		private void KFNHGHOOOOM(List<EOHADGOEBOD> BLIJEOBPEBK)
		{
		}

		[CompilerGenerated]
		private void PNBOJPCDDMI(List<EOHADGOEBOD> LLNNCEMACKC)
		{
		}

		[CompilerGenerated]
		private void CANHHPFBHGP(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void LKEPHLNEIMP(List<EOHADGOEBOD> LLNNCEMACKC)
		{
		}

		[CompilerGenerated]
		private void EMAMJLGFHOB(List<EOHADGOEBOD> LLNNCEMACKC)
		{
		}
	}
}
