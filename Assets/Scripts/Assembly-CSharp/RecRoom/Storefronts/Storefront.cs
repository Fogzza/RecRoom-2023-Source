using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RecRoom.Audio;
using RecRoom.Core;
using RecRoom.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RecRoom.Storefronts
{
	public class Storefront : MonoBehaviour
	{
		private sealed class OJCIDDOHHOH : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Storefront _003C_003E4__this;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public OJCIDDOHHOH(int _003C_003E1__state)
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

		private sealed class EJLPDOHBCGE
		{
			public EOKBGGOAFLF item;

			internal bool _003CPopulateSeasonsSlots_003Eb__0(IIJLKAPNFHH m)
			{
				return false;
			}
		}

		private sealed class LLLPPMIJGGE
		{
			public Storefront _003C_003E4__this;

			public HCLDBKDHKLE costInfo;

			public EOKBGGOAFLF firstPurchasableGiftDrop;

			public DBFJJLIGAFA firstGiftDrop;

			public int slotIndex;

			public bool playerUsedBuyAllButton;

			public Action _003C_003E9__5;

			internal void _003CPurchaseItems_003Eb__2(int dialogResponse)
			{
			}

			internal void _003CPurchaseItems_003Eb__5()
			{
			}
		}

		private sealed class JMOMGGPELEE
		{
			public long initialBalance;

			public long responseBalance;

			public LLLPPMIJGGE CS_0024_003C_003E8__locals1;
		}

		private sealed class CFENGILGPPM
		{
			public DBFJJLIGAFA slotItem;

			public long localPlayersCost;

			public EOKBGGOAFLF purchasableGiftDrop;

			public JMOMGGPELEE CS_0024_003C_003E8__locals2;

			internal void _003CPurchaseItems_003Eb__3(LKKOPNLCJBC.PurchaseBalanceUpdateResponseDTO<EDDPDJCKOBH.GMBCAMAAPMN> response)
			{
			}

			internal void _003CPurchaseItems_003Eb__4(string error)
			{
			}
		}

		private sealed class GMBOPAIBECI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Storefront _003C_003E4__this;

			public long newBalance;

			public long itemCost;

			public Vector3 giftPosition;

			public Quaternion giftRotation;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public GMBOPAIBECI(int _003C_003E1__state)
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

		private sealed class DMOKKHIIJKN
		{
			public bool giftPackageConsumed;

			internal void _003CWaitAndDequeueAll_003Eb__1(GiftBox giftBox)
			{
			}
		}

		private sealed class ECJBPMLOMKM : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Storefront _003C_003E4__this;

			public long newBalance;

			public long itemCost;

			private DMOKKHIIJKN _003C_003E8__1;

			public Vector3 giftPosition;

			public Quaternion giftRotation;

			private int _003CnumDequeuedGifts_003E5__2;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public ECJBPMLOMKM(int _003C_003E1__state)
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

		private sealed class POJDGBDCMJJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Storefront _003C_003E4__this;

			public long newBalance;

			public long itemCost;

			public Vector3 position;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public POJDGBDCMJJ(int _003C_003E1__state)
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

		private sealed class DNJNJLMMHOC
		{
			public bool setMerchBoothActive;

			internal void _003CSwapMerchBoothAndSeasonCanvases_003Eb__0(PurchasableItemSlot slot)
			{
			}

			internal void _003CSwapMerchBoothAndSeasonCanvases_003Eb__1(SubscriptionSeasonItemSlot seasonSlot)
			{
			}
		}

		private sealed class AABCEOPMNLI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public AABCEOPMNLI(int _003C_003E1__state)
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

		[SerializeField]
		private GameObject merchBoothCanvas;

		[SerializeField]
		private PurchasableItemSlot[] slots;

		[SerializeField]
		private Transform[] boxSpawnPoints;

		[SerializeField]
		private BoxCollider[] storefrontActivationVolumes;

		[SerializeField]
		private BoxCollider interactionVolume;

		[SerializeField]
		private TextMeshProUGUI primaryBalanceText;

		[SerializeField]
		private StorefrontTokensBalanceRow tokensBalanceRow;

		[SerializeField]
		private Button buyAllButton;

		[SerializeField]
		private Button backButton;

		[SerializeField]
		private Text endDateText;

		[SerializeField]
		private TextMeshProUGUI playerNameText;

		[SerializeField]
		private Transform coinSlot;

		[SerializeField]
		private FHPHMBKPLCC storefrontType;

		[SerializeField]
		private GKPEKOLBBJL currencyType;

		[SerializeField]
		private EAFLPCNDJNK? currencyPlatformType;

		[SerializeField]
		private IIGLDDDANPN boxGiftContextOverride;

		[SerializeField]
		private float creditChangeAnimationDelay;

		[SerializeField]
		private float creditChangeRate;

		[SerializeField]
		private GameObject seasonCanvas;

		[SerializeField]
		private SubscriptionSeasonItemSlot seasonPreviewSlot;

		[SerializeField]
		private SubscriptionSeasonItemSlot[] seasonSlots;

		[SerializeField]
		private TextMeshProUGUI seasonPreviewEndDateText;

		[SerializeField]
		private Text seasonEndDateText;

		[SerializeField]
		private GameObject seasonPreviewTimerBadge;

		[SerializeField]
		private string endDateTemplate;

		[SerializeField]
		private string seasonEndsInTemplate;

		[SerializeField]
		private string seasonAvailableUntilTemplate;

		[SerializeField]
		private RecRoomAudioClip purchasedItemAudioClip;

		[SerializeField]
		private RecRoomAudioClip dispensingTicketsAudioClip;

		[SerializeField]
		private StorefrontConfirmationDialog confirmationDialog;

		[SerializeField]
		private StorefrontStatusPopup statusPopup;

		[SerializeField]
		private StorefrontConfirmationDialog activeSlotsDialog;

		[SerializeField]
		private Transform[] popupRoots;

		[NonSerialized]
		public bool TestForPlayerRange;

		private OBNLIHDIEIE MFMGAHKGNGD;

		private List<EOKBGGOAFLF> CIHCCALCCBE;

		private bool AOFGGHOKHHP;

		private IDisposable DJJIINNDGNB;

		private FFGPLFHAGKC ACODBONBCFO;

		private SpawnableCollectible LBIJMBHFBKA;

		private int CMFOKONDJEL;

		private int FFKLPIFAONH;

		private bool CFKBLDBAGOA;

		private const int BHINCHLMHEF = 14;

		private const int KJNPGGHFHID = 0;

		private const float LECBGGAFGMK = 0.6f;

		private const string HEMGLEMOBHE = "Error purchasing items. Please contact us at recroom.zendesk.com if this persists.";

		private const string MMCPPBDECKH = "OK";

		private FastGraphicRaycaster[] NGKECABDNOE;

		private List<EOKBGGOAFLF> EHHJOLMNABF;

		private int FFKNCEPOPOE;

		private long EOOEHDBBHMM;

		private long NECKOBKPPML;

		private int OOEPGEMJKPN;

		private float IDKDAFDNIIE;

		private float MJOIAOBGGCB;

		private bool LKIJLPIEMNN;

		private bool MNBLHFJKHHO;

		private SendGiftScreen BDOJOMLBPGD;

		private int IEBHNKAMPBA;

		private Queue<EDDPDJCKOBH.GMBCAMAAPMN> DJPKICLJNBF;

		private List<string> MLKONJJBKBO;

		private List<(string, LKKOPNLCJBC.MJCNIFBNGHM)> BCCODLHLOKJ;

		private List<EOKBGGOAFLF> FCCJLFICFDM;

		private global::LPOCMKDAPMN<BecomeMemberToPurchaseItemScreen> IEELHFAIGOL;

		private const float MFMFNHDOCJO = 30f;

		private const float EEECCOOCEPH = 1f / 30f;

		private IDisposable DPNIJBHKOEK;

		private bool EEMGEGGAIOH;

		private bool? LLCFPEDDCCB;

		private Coroutine FBKPMEIPHHI;

		private Coroutine LHKHDJJHIPL;

public FHPHMBKPLCC StorefrontType
{
get 		{
			return FHPHMBKPLCC.None;
		}

}

public GKPEKOLBBJL CurrencyType
{
get 		{
			return GKPEKOLBBJL.Invalid;
		}

}

public EAFLPCNDJNK? CurrencyPlatformType
{
get 		{
			return null;
		}

}

public bool GiftingEnabled
{
get 		{
			return false;
		}

private set {
		}
}

private SendGiftScreen JCFFDCAHMHI
{
get 		{
			return null;
		}

}

private bool HFGCMDNCFBG
{
get 		{
			return false;
		}

}

		private void Awake()
		{
		}

		private IEnumerator Start()
		{
			return null;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void HDJBEAFJEHD()
		{
		}

		private void NNAKELHEGML(Scene FEGPGPHCDJD, LoadSceneMode DNLPIHIBJDP)
		{
		}

		private void ENHEJEADGCH()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void FHMBNBOJADM(OBNLIHDIEIE JHAGLGAMPLN)
		{
		}

		private void FODNODLDAPF()
		{
		}

		private void PEKFFAJEGFG(float OKBAJEAPIHG)
		{
		}

		private void KHCPLCJBJNC(float OKBAJEAPIHG)
		{
		}

		public void PopulatePurchasableItemSlots(List<EOKBGGOAFLF> NALGLEMPGDF, bool HHHOCBJLEOI = false, bool HCFPOIPBJEK = false)
		{
		}

		public void PopulateSeasonsSlots(List<EOKBGGOAFLF> NALGLEMPGDF, bool HHHOCBJLEOI = true)
		{
		}

		public void ClearSlots(StorefrontSlotDisplay[] BGIEJDJJHEM)
		{
		}

		public void SetItemSetActive(StorefrontSlotDisplay PCDJMAMOKAG, bool IDAMKLDJNEB = false)
		{
		}

		private void PGOMGKMFIPG(long? NCFOPAPFAKL, DBFJJLIGAFA ONCGIPFNENB, long PNNCCFDIMEP, string KMHELFNDCKE, LKKOPNLCJBC.MJCNIFBNGHM ODGBIPOHJOM = LKKOPNLCJBC.MJCNIFBNGHM.OK, bool CPDCFNJNEPA = false, int NCGMDOOCIDH = -1, string NLJOHEKGNDH = "Error purchasing items. Please contact us at recroom.zendesk.com if this persists.")
		{
		}

		public void PurchaseItems(List<EOKBGGOAFLF> JNAAHMPCPAB, bool MJLHDLAEBFN = false, int APFNAOPENNF = -1)
		{
		}

		private void EFGNFJEHPOM(out Vector3 OCGGGIIFAJD, out Quaternion ELOJPMEMIKL)
		{
			OCGGGIIFAJD = default;
			ELOJPMEMIKL = default;
		}

		private Vector3? LLDCNANFMCJ()
		{
			return null;
		}

		private void PFJIFCFFIKA()
		{
		}

		private void ADBKDMLHDFM()
		{
		}

		private void JJKGLOCIGIM()
		{
		}

		private void AHEKNHHMAOK(GKPEKOLBBJL NIFOGEBEDNG, long BAOJPELMDEI)
		{
		}

		private void OKKLBDMMJIC()
		{
		}

		public static string GetTokenStringFormatted(long BECMELKBGCA)
		{
			return null;
		}

		private void NKHEOKBFINE(long? BAOJPELMDEI, TextMeshProUGUI NEELKECDCMP)
		{
		}

		private void LBGJJMLGMKG(bool ICHBECDKHOJ)
		{
		}

		private HCLDBKDHKLE DBCCELGBCFN(List<EOKBGGOAFLF> LCPAKHJBEOA)
		{
			return null;
		}

		private bool DGCCFEHMHBI(DBFJJLIGAFA OPKDMEIFDHL)
		{
			return false;
		}

		private bool DHGCABEAHOB(List<EOKBGGOAFLF> JNAAHMPCPAB, out List<DBFJJLIGAFA> IFOIIGMIJIH)
		{
			IFOIIGMIJIH = null;
			return false;
		}

		private void PJBKDPECCBO(DBFJJLIGAFA AGKLCBDBLIO = null)
		{
		}

		private List<EOKBGGOAFLF> PICJINNMOAJ(List<EOKBGGOAFLF> JNAAHMPCPAB)
		{
			return null;
		}

		private IEnumerator EALNNAOFKIJ(long JKPJELBKKGN, long AJOGPANPPMN, Vector3 JKGJFALKBCA, Quaternion DICEJEPLBBA)
		{
			return null;
		}

		private IEnumerator HAAMFBEMDBO(long JKPJELBKKGN, long AJOGPANPPMN, Vector3 JKGJFALKBCA, Quaternion DICEJEPLBBA)
		{
			return null;
		}

		private IEnumerator NPBKNCLHDBJ(Vector3 INLGLHIPOMC, long JKPJELBKKGN, long AJOGPANPPMN)
		{
			return null;
		}

		private List<List<EOKBGGOAFLF>> ALOBKDPLNNH(List<EOKBGGOAFLF> NANKKFHMPFI, bool HCFPOIPBJEK)
		{
			return null;
		}

		public void Button_GetMoreTokens()
		{
		}

		public void Button_BuyItemSet()
		{
		}

		public void Button_SetItemSetInactive()
		{
		}

		public void Button_SetSeasonsActive()
		{
		}

		private void PGGHMFOFEII(bool HJJMNFPPPHO)
		{
		}

		private StorefrontConfirmationDialog.DELJNAJOKBB AEEOLHHMIKA(StorefrontConfirmationDialog GDMKJGAKCND, StorefrontConfirmationDialog.HLJDGHBNINP HNPFAOFHHII, string KEMAPPJCGEA, string JINHPNDAHKP = "Yes", string ABONDMLCNBK = "No")
		{
			return null;
		}

		private string FDHJEIBOEHD(DateTime PCDACHKHENP)
		{
			return null;
		}

		public void Refresh()
		{
		}

		public void AddCash()
		{
		}

		private IEnumerator GDPBOPDLCMN()
		{
			return null;
		}

		[CompilerGenerated]
		private void POHLCFIBFND()
		{
		}

		[CompilerGenerated]
		private void FCFKPKIGAJG(FFGPLFHAGKC FMPPCFELPGD)
		{
		}

		[CompilerGenerated]
		private void DAEDPNGFEDJ(OBNLIHDIEIE JHAGLGAMPLN)
		{
		}

		[CompilerGenerated]
		private void NAHCCGEFHLK(OBNLIHDIEIE JHAGLGAMPLN)
		{
		}

		[CompilerGenerated]
		private void FINOPMEJNGO()
		{
		}

		[CompilerGenerated]
		private bool IJJPIOKOLHI()
		{
			return false;
		}
	}
}
