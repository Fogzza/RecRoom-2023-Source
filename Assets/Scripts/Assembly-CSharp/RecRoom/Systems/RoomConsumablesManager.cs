using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using RecRoom.Audio;
using UnityEngine;

namespace RecRoom.Systems
{
	public class RoomConsumablesManager : NetworkedSingletonMonoBehaviour<RoomConsumablesManager>
	{
		private class DABAKEBPEFJ
		{
			private readonly Dictionary<Guid, KFGPIBFKOAK> MDILGDOIFED;

			private readonly Dictionary<Guid, CGCLKJLGBAM> JLHMJFBCIJF;

			private long? JAAMCAFAAFL;

public long? CBCCEPHPKGN
{
get 			{
				return null;
			}

private set {
			}
}

public bool KKKHNMGIFMF
{
get 			{
				return false;
			}

}

			public bool KJDMLLBNCMG(KFGPIBFKOAK KIJHICGIKFM)
			{
				return false;
			}

			public bool IOLHLFMFHML(Guid GFGAKKMOHON, out bool AGGECIGLMIK, out bool PFONDBDJJLI)
			{
				AGGECIGLMIK = default;
				PFONDBDJJLI = default;
				return false;
			}

			public bool JONJCFKKIKC(PAOMHJBMEIN EIGKHNLLFHG, out CGCLKJLGBAM IEBPGMLAAGI)
			{
				IEBPGMLAAGI = null;
				return false;
			}

			public bool PKBOKMEALBF(Guid GFGAKKMOHON)
			{
				return false;
			}

			public IEnumerable<KFGPIBFKOAK> LOFCCLPMLIM()
			{
				return null;
			}

			public bool DBDNIMMDJDB(Guid GFGAKKMOHON, out KFGPIBFKOAK KIJHICGIKFM)
			{
				KIJHICGIKFM = null;
				return false;
			}

			public IEnumerable<CGCLKJLGBAM> KBKHEPFNMPN()
			{
				return null;
			}

			public bool EKIPOFDFJNC(Guid GFGAKKMOHON, out CGCLKJLGBAM EIGKHNLLFHG)
			{
				EIGKHNLLFHG = null;
				return false;
			}

			public CGCLKJLGBAM IBLMFCAJDNF(Guid GFGAKKMOHON)
			{
				return null;
			}

			public void PAKIMOKGMBI()
			{
			}

			public void JJAHECGFAOL(long EPOBIFCHLNM)
			{
			}
		}

		private sealed class GNEMCGJKEOD
		{
			public RoomConsumablesManager _003C_003E4__this;

			public Guid roomConsumableId;

			internal void _003CDeleteRoomConsumableAsync_003Eb__0(PLPKONMJAFM result)
			{
			}
		}

		private sealed class FFDCICGIHOB
		{
			public RoomConsumablesManager _003C_003E4__this;

			public CGCLKJLGBAM inventoryItem;

			internal void _003CActivateConsumableAsync_003Eb__0()
			{
			}
		}

		private sealed class DGFEMIGIHNN
		{
			private sealed class _003C_003CTryStartNewActivationTimer_003Eg__Timer_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public DGFEMIGIHNN _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CTryStartNewActivationTimer_003Eg__Timer_007C0_003Ed(int _003C_003E1__state)
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

			public RoomConsumablesManager _003C_003E4__this;

			public Guid roomConsumableId;

			internal IEnumerator<EGGPGCCKPCO> _003CTryStartNewActivationTimer_003Eg__Timer_007C0()
			{
				return null;
			}

			internal void _003CTryStartNewActivationTimer_003Eb__1()
			{
			}
		}

		private sealed class DMMFBDOHIDO
		{
			public RoomConsumablesManager _003C_003E4__this;

			public KFGPIBFKOAK roomConsumable;

			public long? initialBalance;

			public string purchaseSource;

			internal global::NCOKFFGPIJM<(bool, string)> _003CPurchaseRoomConsumableInternal_003Eb__0(CAPIKAHMPLA result)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<(bool, string)> _003CPurchaseRoomConsumableInternal_003Eb__1(string error)
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct AAFOPFBGAOA : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<global::FAIKNKAIPLB<IENGILMPFNE>> _003C_003Et__builder;

			public CHILKDJABBF recipient;

			public RoomConsumablesManager _003C_003E4__this;

			public Guid roomConsumableId;

			public int quantity;

			public Action<string> logWarning;

			public JEGAPHLGBJA e;

			private TaskAwaiter<PHIBIAGLCBG> _003C_003Eu__1;

			private TaskAwaiter<PLPKONMJAFM> _003C_003Eu__2;

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
		private struct PJOKOGJLFKJ : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<PHIBIAGLCBG> _003C_003Et__builder;

			public RoomConsumablesManager _003C_003E4__this;

			public Guid roomConsumableId;

			public int quantity;

			public CHILKDJABBF awardingPlayer;

			public Guid operationId;

			private PLPKONMJAFM _003CoperationResult_003E5__2;

			private TaskAwaiter<PHIBIAGLCBG> _003C_003Eu__1;

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
		private struct LAJNCKKEPKN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Dictionary<Guid, PHIBIAGLCBG>> _003C_003Et__builder;

			public Dictionary<Guid, int> requests;

			public RoomConsumablesManager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private TaskAwaiter<Dictionary<Guid, PHIBIAGLCBG>> _003C_003Eu__1;

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

		private sealed class OOBOCAJNJMO
		{
			public RoomConsumablesManager _003C_003E4__this;

			public EGGMEJDMHKF roomInstance;

			internal LAHBDKNMNHN _003COnRoomInstanceChanged_003Eb__0()
			{
				return null;
			}

			internal void _003COnRoomInstanceChanged_003Eb__1()
			{
			}
		}

		private sealed class GNAIDBFPBDC
		{
			public IEnumerable<KFGPIBFKOAK> consumables;

			internal bool _003CSyncConsumableCache_003Eb__0(KFGPIBFKOAK consumable)
			{
				return false;
			}
		}

		private sealed class FAHIHEJNNGH
		{
			public KFGPIBFKOAK consumable;

			internal bool _003CSyncConsumableCache_003Eb__1(KFGPIBFKOAK c)
			{
				return false;
			}
		}

		private sealed class ICAKCOBJNPE
		{
			public IEnumerable<PAOMHJBMEIN> inventory;

			internal bool _003CSyncConsumableInventoryCache_003Eb__0(CGCLKJLGBAM i)
			{
				return false;
			}
		}

		private sealed class HAFLFOJFHFC
		{
			public CGCLKJLGBAM i;

			internal bool _003CSyncConsumableInventoryCache_003Eb__1(PAOMHJBMEIN x)
			{
				return false;
			}
		}

		private sealed class NIEAPCKKEPJ
		{
			public Guid roomConsumableId;

			internal void _003CRpcShowPurchasePrompt_003Eb__0()
			{
			}
		}

		private const int GOLPFBEJAMK = 3;

		private static readonly TimeSpan DHJBKAOJADL;

		private const string NMGGOFLJNAB = "Unknown error occured. If this persists, please contact us at recroom.zendesk.com";

		private const string MBEOGHDCDNL = "CV2_Purchase_Prompt_Chip";

		private static readonly IEnumerable<KFGPIBFKOAK> JMFBMIMBHDI;

		private static readonly IEnumerable<CGCLKJLGBAM> FNJFOBAFHNG;

		[SerializeField]
		private RecRoomAudioClip successfulPurchaseSFX;

		public static readonly global::HHOBPMOCKMJ<Guid> ConsumableAddedOrUpdated;

		public static readonly global::HHOBPMOCKMJ<Guid> ConsumableDeleted;

		public static readonly global::HHOBPMOCKMJ<Guid> InventoryItemAddedOrUpdated;

		public static readonly global::HHOBPMOCKMJ<Guid> InventoryItemRemoved;

		private readonly DABAKEBPEFJ OKOMALFNKGH;

		private DateTime ODMGCBJFOFB;

		private DateTime GDLEBOKNDCF;

		private JKHCJAJHGAO LLIBMKPLDJO;

		private JKHCJAJHGAO DEFKEIACGNF;

		private Dictionary<Guid, JKHCJAJHGAO> EACFDGIEDPK;

		private global::EBJFKEBKMPI<Guid, PHIBIAGLCBG> LJKLDBIFFJP;

		private global::IMINPMKCFDC<PLPKONMJAFM> GJCPEMJGJBH;

		private CancellationTokenSource JIADCOBNPEB;

		private IDisposable CNAGCKBFLOE;

		private Lazy<FEIKFKAICHC> JJJMDJMNEIL;

		private Lazy<IILDCCEMGBA> MOFCMOKAHHO;

		private LFHHMEALLBA FLIFJAGEPCH;

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

		public ILODPOPFPAH CreateDeserializationHandler()
		{
			return null;
		}

		public global::NCOKFFGPIJM<EKACNGGFGNM> CreateRoomConsumableAsync(string KNOPFGAGMCN, string GKHMKKBKEKC, string NPOEAPJKNFN, long PJJFBBBIFOP, Guid? LFNGEFEDKJM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<EKACNGGFGNM> EditRoomConsumableAsync(Guid JNHIIPBPEOB, string KNOPFGAGMCN, string GKHMKKBKEKC, string NPOEAPJKNFN, long PJJFBBBIFOP, Guid? LFNGEFEDKJM)
		{
			return null;
		}

		public global::NCOKFFGPIJM<PLPKONMJAFM> DeleteRoomConsumableAsync(Guid JNHIIPBPEOB)
		{
			return null;
		}

		public LAHBDKNMNHN RefreshRoomConsumablesForCurrentRoom(bool KAGIMFAPGOG = false)
		{
			return null;
		}

		private LAHBDKNMNHN KMHHAJEDBON(long EPOBIFCHLNM, bool KAGIMFAPGOG)
		{
			return null;
		}

		public bool TryGetCachedConsumableById(Guid JNHIIPBPEOB, out KFGPIBFKOAK EDEAENAAKCD)
		{
			EDEAENAAKCD = null;
			return false;
		}

		public IEnumerable<KFGPIBFKOAK> GetCachedConsumablesForCurrentRoom()
		{
			return null;
		}

		public LAHBDKNMNHN RefreshConsumableInventoryForCurrentRoom(bool KAGIMFAPGOG = false)
		{
			return null;
		}

		private LAHBDKNMNHN GPPOPBKBILJ(long EPOBIFCHLNM, bool KAGIMFAPGOG)
		{
			return null;
		}

		public bool TryGetCachedConsumableInventoryItem(Guid JNHIIPBPEOB, out CGCLKJLGBAM EIGKHNLLFHG)
		{
			EIGKHNLLFHG = null;
			return false;
		}

		public IEnumerable<CGCLKJLGBAM> GetCachedConsumableInventoryForCurrentRoom()
		{
			return null;
		}

		public LAHBDKNMNHN ActivateConsumableAsync(Guid GFGAKKMOHON)
		{
			return null;
		}

		public bool DeactivateConsumable(Guid GFGAKKMOHON)
		{
			return false;
		}

		public bool UseConsumable(Guid GFGAKKMOHON)
		{
			return false;
		}

		private LAHBDKNMNHN HBNMHJCJFCK(Guid GFGAKKMOHON)
		{
			return null;
		}

		private void LNICJPGHAIK(PHIBIAGLCBG CDNLFEOBNKB)
		{
		}

		private void FKANODKEOPO(PHIBIAGLCBG CDNLFEOBNKB)
		{
		}

		private void GJMLLJLCDLG(CGCLKJLGBAM ONCGIPFNENB, MPMFGEOFDEB? AJLDNMPIGNP = null, bool? GIFIHJGDMJC = null, bool? DKILLBGLENH = null, bool? ODJBFMLOKFP = null)
		{
		}

		private void MNKLPEJIMGP(Guid JNHIIPBPEOB)
		{
		}

		private void BFDDKIOGHGH(Guid JNHIIPBPEOB)
		{
		}

		private void LAIKPEDKBIO()
		{
		}

		public global::FAIKNKAIPLB<MFEHAEMCKCJ> CV2RequestShowPurchasePrompt(JEGAPHLGBJA GCBHEJANCJK, CHILKDJABBF EKOFNPFCLMO, Guid JNHIIPBPEOB)
		{
			return default;
		}

		private void PCFDEEEBEFF(out float OMMPKPIKPEB, out int CNLKNFNEKPL)
		{
			OMMPKPIKPEB = default;
			CNLKNFNEKPL = default;
		}

		public global::NCOKFFGPIJM<(bool, string)> PurchaseRoomConsumable(Guid GFGAKKMOHON, long NDGJEBNJMAB, Guid? CDOPKKFCMLA, string NNECEELJHMM = null)
		{
			return null;
		}

		private global::NCOKFFGPIJM<(bool, string)> KCJEGMKGKKB(KFGPIBFKOAK EDEAENAAKCD, long NDGJEBNJMAB, Guid? CDOPKKFCMLA, Guid? CHBOBCLCDFM, long? NCFOPAPFAKL, string NNECEELJHMM = null)
		{
			return null;
		}

		public static void TrySendFunnelAnalytics(OILDLLGEMKP.GIALFMHCLNE GDGDAIAMBKP, KFGPIBFKOAK EDEAENAAKCD, string NNECEELJHMM = null, string NLJOHEKGNDH = null)
		{
		}

		private string NLMKMKMKEHC(KFGPIBFKOAK EDEAENAAKCD, long? NCFOPAPFAKL, string NNECEELJHMM = null)
		{
			return null;
		}

		private string HEFCHKALIJC(KFGPIBFKOAK EDEAENAAKCD, PLPKONMJAFM? CDNLFEOBNKB = null, LKKOPNLCJBC.MJCNIFBNGHM? EGDCDOJAAFH = null, HMNANAGIKJF? LINAFMDPIBP = null, string FKGMPFJOHBO = null, string NNECEELJHMM = null)
		{
			return null;
		}

		private bool KMMDBDMJAIJ(KFGPIBFKOAK KIJHICGIKFM, out long? NCFOPAPFAKL)
		{
			NCFOPAPFAKL = null;
			return false;
		}

		public Task<global::FAIKNKAIPLB<IENGILMPFNE>> Cv2AwardRoomConsumable(JEGAPHLGBJA GCBHEJANCJK, CHILKDJABBF EMPMIKKJDKE, Guid JNHIIPBPEOB, int IFLOEKGCJON, Action<string> NJKNHNCMAPM)
		{
			return null;
		}

		private global::FAIKNKAIPLB<IENGILMPFNE> PIEKJOKKJKN(PLPKONMJAFM BGGOPNOGOCC, Action<string> NJKNHNCMAPM = null)
		{
			return default;
		}

		private Task<PHIBIAGLCBG> BGLHOHODHGN(Guid JNHIIPBPEOB, int IFLOEKGCJON, Guid FDNJCNKKGBE = default(Guid), CHILKDJABBF DEMLNIKDFBG = null)
		{
			return null;
		}

		private Task<Dictionary<Guid, PHIBIAGLCBG>> ONDIFEDFABF(Dictionary<Guid, int> GDKJDDCKGLO, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private void BOOKJAJMKLC(EGGMEJDMHKF GPKOELKKOBP)
		{
		}

		private Task IEJAMDPGOPB(AHDBIFJNDCH ADCFFAJGNAM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private Task BMOFFBMKGJJ(AHDBIFJNDCH ADCFFAJGNAM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private void OKGMAPGPPPJ()
		{
		}

		private void JLOEBPHCDOH()
		{
		}

		private void BBMJFPPPGFM()
		{
		}

		private void EGJBMNPICPI()
		{
		}

		private void EANCCEBHBCN(EKACNGGFGNM CDNLFEOBNKB)
		{
		}

		private void ABBLDHLEAKH(KFGPIBFKOAK KIJHICGIKFM)
		{
		}

		private void NDPOKBCMONJ(IEnumerable<KFGPIBFKOAK> BCBAHJMKOJN)
		{
		}

		private bool IEGAECHMJHP(Guid GFGAKKMOHON)
		{
			return false;
		}

		private CGCLKJLGBAM NJOOFDGPBHC(PHIBIAGLCBG CDNLFEOBNKB)
		{
			return null;
		}

		private void PEOHBCECNFG(IEnumerable<PAOMHJBMEIN> OIPMDNIPIJH)
		{
		}

		private void PKBOKMEALBF(Guid GFGAKKMOHON)
		{
		}

		private void FPFEAOBOJJE(EKACNGGFGNM BGGOPNOGOCC)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnNotifiedOfConsumableUpdate(string PEAHBHKBDHG)
		{
		}

		private void OANEOELACDP(Guid JNHIIPBPEOB)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnNotifiedOfConsumableRemoved(Guid JNHIIPBPEOB)
		{
		}

		private void FHBJKGPDJHH(CHILKDJABBF EMPMIKKJDKE, Guid FDNJCNKKGBE, Guid JNHIIPBPEOB, int IFLOEKGCJON)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnNotifiedOfAwardRequest(Guid FDNJCNKKGBE, Guid JNHIIPBPEOB, int IFLOEKGCJON, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		private void PEJFAPONGHJ(CHILKDJABBF EMPMIKKJDKE, Guid FDNJCNKKGBE, PLPKONMJAFM NALKLKPGPME)
		{
		}

		[PBOMGCLBFHF]
		private void RPCOnReceivedResponseWithAwardRequestResult(Guid FDNJCNKKGBE, int NALKLKPGPME, GGGMJMEFFOC AKOKILEPANJ)
		{
		}

		[PBOMGCLBFHF]
		private void RpcShowPurchasePrompt(Guid JNHIIPBPEOB)
		{
		}

		public static string GetResponseCodeFriendlyMessage(PLPKONMJAFM CDNLFEOBNKB, LKKOPNLCJBC.MJCNIFBNGHM? BEGDPKJLICP = null, HMNANAGIKJF? JMAPMGJLCDA = null)
		{
			return null;
		}

		private static string CBDNKDOMHAP(LKKOPNLCJBC.MJCNIFBNGHM BEGDPKJLICP)
		{
			return null;
		}

		private static string BOLKEJOJGEF(HMNANAGIKJF JMAPMGJLCDA)
		{
			return null;
		}

		[CompilerGenerated]
		private void EFBJFKHAFFI(EKACNGGFGNM CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void BDALLJBGENM(EKACNGGFGNM CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void PKEFFCLIFMJ(IReadOnlyList<KFGPIBFKOAK> BCBAHJMKOJN)
		{
		}

		[CompilerGenerated]
		private void LHIKKJLOLNJ(IReadOnlyList<PAOMHJBMEIN> OIPMDNIPIJH)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN JPIGENJCIBH(PHIBIAGLCBG CDNLFEOBNKB)
		{
			return null;
		}

		[CompilerGenerated]
		private BLBJMECFGJE ECPMDBPOFLE(KeyValuePair<Guid, int> GOJCEBCMFJK)
		{
			return null;
		}
	}
}
