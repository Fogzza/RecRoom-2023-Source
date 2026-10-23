using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RRUI.Data;

namespace RecRoom.Core.Creation
{
	public class TrialInventionManager : NetworkedSingletonMonoBehaviour<TrialInventionManager>
	{
		public class MKAMBKPCCOL
		{
			private int JGBLBKPGMFB;

			private long ALLDPFIHAJG;

			private OEBAEGDPBLA DBPLCLEDMLJ;

			private List<InventionManager.CLMIBMNNOCE> PCPFKMLNGPC;

public int GIJDJPDNJON
{
get 			{
				return 0;
			}

set {
			}
}

public long CIDLKBBCMNM
{
get 			{
				return 0L;
			}

set {
			}
}

public OEBAEGDPBLA BHADDFPINCO
{
get 			{
				return null;
			}

private set {
			}
}

public List<InventionManager.CLMIBMNNOCE> CLIMEBCCPPD
{
get 			{
				return null;
			}

set {
			}
}

			public MKAMBKPCCOL(int AIABLOJDPKA, long KBPFKPGOCFN, List<InventionManager.CLMIBMNNOCE> OCFIFLKHMMI)
			{
			}

			public string NDHIKMHMFMP()
			{
				return null;
			}

			public static string NDHIKMHMFMP(int PCKCPNGPNBJ, long KBPFKPGOCFN)
			{
				return null;
			}

			public static string NDHIKMHMFMP(InventionManager.CLMIBMNNOCE GPHGPADAPHE)
			{
				return null;
			}

			public global::NCOKFFGPIJM<OEBAEGDPBLA> NPAADFLHBJJ()
			{
				return null;
			}

			[CompilerGenerated]
			private void KGABLHBPFLK(OEBAEGDPBLA EGDOIKMDMJM)
			{
			}
		}

		public class AMIIGCHDJEK
		{
			public class OIPPHAKOBLB
			{
				public MKAMBKPCCOL CKDKHOFBJIP;

				public PLCJLIOLGCO PJKHNNKOAJN;
			}

			public List<OIPPHAKOBLB> DMHAJBMJGKO;

			public List<OEBAEGDPBLA> IBPILNLNPMF;
		}

		public class FALEPCILAMN
		{
			public List<string> MLKONJJBKBO;

			public List<string> BCCODLHLOKJ;
		}

		private sealed class LHEKOHFNAAB
		{
			public OEBAEGDPBLA invention;

			public TrialInventionManager _003C_003E4__this;

			internal void _003COnSpawnInstanceResultReceived_003Eb__0()
			{
			}
		}

		private sealed class BMPIKJLGPMN
		{
			public MKAMBKPCCOL record;

			public float approximateTrialPeriodInMinutes;

			internal void _003CDeleteAllTrialsObjectsOnCondition_003Eb__0(JLGDECHJNNO inventionDetails)
			{
			}
		}

		private sealed class FNAJLNGKFFL
		{
			public TrialInventionManager _003C_003E4__this;

			public CHILKDJABBF playerRemovedBy;

			internal void _003CRpcOnTrialRecordDeleted_003Eb__0(OEBAEGDPBLA invention)
			{
			}
		}

		private sealed class IJPPKPHGHCF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float seconds;

			public TrialInventionManager _003C_003E4__this;

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
			public IJPPKPHGHCF(int _003C_003E1__state)
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

		private sealed class CHALBBFIKND
		{
			public global::PHLHFLLLDLK<bool> promise;

			internal void _003CPreSaveTrialInventionProcess_003Eb__0(HGKINAOMNIF r)
			{
			}
		}

		private sealed class IHGGOOFCLBG
		{
			public Dictionary<string, MKAMBKPCCOL> trialInventionRegistry;

			internal global::NCOKFFGPIJM<AMIIGCHDJEK> _003CGetPurchaseDataFromRegistry_003Eb__1(List<OEBAEGDPBLA> trialInventions)
			{
				return null;
			}
		}

		private sealed class HMCMPCIDAAC
		{
			public TrialInventionManager _003C_003E4__this;

			public FHPHMBKPLCC entryPoint;

			public Action<int, CardModel, InventionModel, JLOCLGGLOPP> _003C_003E9__2;

			public Action _003C_003E9__12;

			public Action<string> _003C_003E9__13;

			public Action _003C_003E9__11;

			public Action<CheckoutDialogModel> _003C_003E9__5;

			internal global::NCOKFFGPIJM<HGKINAOMNIF> _003CTryShowTrialInventionsCheckoutDialog_003Eb__0(AMIIGCHDJEK purchaseData)
			{
				return null;
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__2(int index, CardModel cardModel, InventionModel inventionModel, JLOCLGGLOPP accountToCardController)
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__12()
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__13(string _)
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__11()
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__5(CheckoutDialogModel dialogModel)
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__1()
			{
			}
		}

		private sealed class CKDBEACNPPE
		{
			public bool isShowingPurchaseResults;

			public LJJIHDDNLNB checkoutDialogData;

			public HMCMPCIDAAC CS_0024_003C_003E8__locals1;

			public Action _003C_003E9__14;

			public Action<FALEPCILAMN> _003C_003E9__10;

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__3()
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__10(FALEPCILAMN purchaseResults)
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__14()
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__4()
			{
			}
		}

		private sealed class KFBELHFPCOC
		{
			public MKAMBKPCCOL trialInventionRecord;

			public HMCMPCIDAAC CS_0024_003C_003E8__locals2;

			public Action<OEBAEGDPBLA> _003C_003E9__9;

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__7()
			{
			}

			internal void _003CTryShowTrialInventionsCheckoutDialog_003Eb__9(OEBAEGDPBLA invention)
			{
			}
		}

		private sealed class BHKAFKLOFLH
		{
			public OILDLLGEMKP.NMJOBHIALCL inventionPurchaseFunnelStep;

			public OEBAEGDPBLA invention;

			public string entrypointName;

			public float? trialPeriodInMinutes;

			internal void _003CRemoveTrialInvention_003Eb__0(JLGDECHJNNO inventionDetails)
			{
			}
		}

		private const float DDAENHMKFHG = 30f;

		private const float DDCKJNCKABI = 1f / 30f;

		private int LCCGPNGFFJC;

		private const float KKKDFACFPKK = 5f;

		private const float PLLGFGCEEEM = 0.5f;

		public static EEANDDJEMJC OnTrialInventionsChanged;

		private HLNFDOBEGJO CHABDOLEEMD;

		private CheckoutDialogModel GEGLGIMBFOH;

		private AMIIGCHDJEK CLHCBLLAKKH;

		private global::PHLHFLLLDLK<HGKINAOMNIF> LKBDFDHKHKF;

		private bool KOODKEINOFJ;

		private string PGEIBONDJJP;

		protected override void Awake()
		{
		}

		protected void Start()
		{
		}

		private IEnumerable<InventionManager.CLMIBMNNOCE> HAJDIJCMFHK()
		{
			return null;
		}

		public Dictionary<string, MKAMBKPCCOL> GetTrialInventionsRegistry()
		{
			return null;
		}

		public bool DoTrialsExist()
		{
			return false;
		}

		private bool EFJDIHPJAAD()
		{
			return false;
		}

		private void EHBCAIDDLOI(float OKBAJEAPIHG)
		{
		}

		protected override void OnDestroy()
		{
		}

		public void MasterPollTrialDuration()
		{
		}

		public void OnSpawnInstanceResultReceived(OEBAEGDPBLA EGDOIKMDMJM, CreationManager.ALEFKNOEIAL PCPEJHIMHJJ)
		{
		}

		private global::NCOKFFGPIJM<int> FMIOFHJIJEB()
		{
			return null;
		}

		private Dictionary<string, MKAMBKPCCOL> HEBDDPCMGNC()
		{
			return null;
		}

		private void DBALAGPCLNC(InventionManager.CLMIBMNNOCE GPHGPADAPHE, Dictionary<string, MKAMBKPCCOL> MMIHGABIFMM)
		{
		}

		private void JKNKOOCBEEK()
		{
		}

		private void NHOPFCFOPKO()
		{
		}

		private void NDDPMBOOHMK(Func<InventionManager.CLMIBMNNOCE, bool> NHJPBHJLFOD)
		{
		}

		public void RequestDeleteTrialRecord(string FDAIMOMOHIG)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterRequestDeleteTrialRecord(string FDAIMOMOHIG, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		private void DAAOEGMDHJC(MKAMBKPCCOL OBMHEBIAKGO)
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnTrialRecordDeleted(long KBPFKPGOCFN, CHILKDJABBF KOMIOMLAHKJ)
		{
		}

		private string BODDEGJFPLN(CHILKDJABBF KOMIOMLAHKJ)
		{
			return null;
		}

		private void EGBAPODGHGI()
		{
		}

		[PBOMGCLBFHF]
		private void RpcOnTrialsChanged()
		{
		}

		private IEnumerator<EGGPGCCKPCO> DNJDICGEIJF(float BGGBEMDBOHE)
		{
			return null;
		}

		private void MHLJADEFDMA()
		{
		}

		public void MasterDeleteAllTrialInventionsByPlayerID(int PCKCPNGPNBJ)
		{
		}

		private void NMDKGINGCGO(CreationManager.ALEFKNOEIAL NHMNHNNAAGA, bool CIDMHILFDLF)
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterOnInventionPurchased(string FDAIMOMOHIG, GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		private void CLGFLLCMFKA(string FDAIMOMOHIG)
		{
		}

		public void OnInventionPurchased(int AIABLOJDPKA, long KBPFKPGOCFN)
		{
		}

		protected void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void OnMasterClientSwitched(CHILKDJABBF GKNDJIKLPKK)
		{
		}

		private void NBPEOPANJMK(GBAJDOHJDHJ HFEKGOLNKOL)
		{
		}

		public global::NCOKFFGPIJM<bool> PreSaveTrialInventionProcess()
		{
			return null;
		}

		private global::NCOKFFGPIJM<AMIIGCHDJEK> DFLEKBIHOKN(Dictionary<string, MKAMBKPCCOL> PJPIHLPPCMA)
		{
			return null;
		}

		public global::NCOKFFGPIJM<HGKINAOMNIF> TryShowTrialInventionsCheckoutDialog(Dictionary<string, MKAMBKPCCOL> PJPIHLPPCMA, FHPHMBKPLCC HGMDAOHNPAP)
		{
			return null;
		}

		public float? GetTrialPeriodInMinutes(OEBAEGDPBLA EGDOIKMDMJM, string POCDPMEGOCN = null)
		{
			return null;
		}

		public void RemoveTrialInvention(OEBAEGDPBLA EGDOIKMDMJM, OILDLLGEMKP.NMJOBHIALCL LIENCCCDLFH, string PGEIBONDJJP, string POCDPMEGOCN = null)
		{
		}

		public bool IsLocalPlayerTryingInvention(long KBPFKPGOCFN)
		{
			return false;
		}

		private float KELLPKKEBKH(int HDGFHFCPNPD)
		{
			return 0f;
		}

		[CompilerGenerated]
		private void LHNFBGHMMOO(int CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private bool EBMKGONPFIA(InventionManager.CLMIBMNNOCE BPEGJLIMPPJ)
		{
			return false;
		}

		[CompilerGenerated]
		private void FDGNGPBIDMC(AMIIGCHDJEK PHFKBGNJJIP)
		{
		}
	}
}
