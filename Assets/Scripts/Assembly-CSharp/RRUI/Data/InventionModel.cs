using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RRUI.Dialogs;
using RRUI.Navigation;
using UnityEngine;

namespace RRUI.Data
{
	public class InventionModel : RRUIModel
	{
		private sealed class PKLCGOICOOD
		{
			public InventionModel _003C_003E4__this;

			public global::PHLHFLLLDLK<string> promise;

			internal void _003CSetInventionSubtype_003Eb__0(JLGDECHJNNO inventionDetails)
			{
			}
		}

		private sealed class BAFJDBJNAIP
		{
			public InventionModel _003C_003E4__this;

			public PLCJLIOLGCO costInfo;

			internal void _003CGetInvention_003Eb__0(OEBAEGDPBLA ownedInvention)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct LPELPEPICKP : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public InventionModel _003C_003E4__this;

			public OILDLLGEMKP.NMJOBHIALCL buttonSource;

			private BAFJDBJNAIP _003C_003E8__1;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct KNBHJOBOBPC : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public InventionModel _003C_003E4__this;

			private TaskAwaiter<string> _003C_003Eu__1;

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

		private sealed class HOLCOFJAHAG
		{
			public bool isSelected;

			public PMEOGBJJKME Checkbox;

			public InventionModel _003C_003E4__this;

			internal bool _003CTryShowDespawnWarningDialogPopUp_003Eb__1()
			{
				return false;
			}

			internal void _003CTryShowDespawnWarningDialogPopUp_003Eb__2(bool isActive)
			{
			}

			internal void _003CTryShowDespawnWarningDialogPopUp_003Eb__3()
			{
			}
		}

		private sealed class BNFFIDICGNH
		{
			public InventionModel _003C_003E4__this;

			public bool cheer;

			internal void _003CToggleIsCheered_003Eb__0(JLLIAMENNLJ result)
			{
			}

			internal void _003CToggleIsCheered_003Eb__1(string error)
			{
			}

			internal void _003CToggleIsCheered_003Eb__2()
			{
			}
		}

		private sealed class IACOFKPFJCL
		{
			public PLCJLIOLGCO costInfo;

			public InventionModel _003C_003E4__this;

			public CheckoutDialogModel cachedCheckoutDialogModel;

			public LJJIHDDNLNB checkoutDialogData;

			public Action _003C_003E9__5;

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__0(int index, CardModel cardModel, InventionModel inventionModel, JLOCLGGLOPP accountToCardController)
			{
			}

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__1()
			{
			}

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__5()
			{
			}

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__2()
			{
			}

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__3()
			{
			}

			internal void _003CLaunchPurchaseConfirmationDialog_003Eb__4(BaseDialogModel<LJJIHDDNLNB> dialog)
			{
			}
		}

		private sealed class ADHEKBBPDPO
		{
			public InventionModel _003C_003E4__this;

			public PLCJLIOLGCO costInfo;

			internal void _003CTryPurchaseInvention_003Eb__0(LKKOPNLCJBC.InventionPurchaseResponseDTO response)
			{
			}

			internal void _003CTryPurchaseInvention_003Eb__1(string error)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct AGPIHEDJMBM : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public InventionModel _003C_003E4__this;

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

		public const string INVENTION_IS_DETAILS_PAGE_KEY = "INVENTION_IS_DETAILS_PAGE_KEY";

		public const string INVENTION_ENTRYPOINT_NAME_KEY = "INVENTION_ENTRYPOINT_NAME_KEY";

		public const string INVENTION_DORM_TAB_DESPAWN_QOL_EXP_PARAM_KEY = "INVENTION_DORM_TAB_DESPAWN_QOL_EXP_PARAM_KEY";

		public const string INVENTION_DETAILS_SHOW_BANNER_PREF = "InventionDetails_ShowDisclaimerBanner";

		public const string INVENTION_SHOW_DESPAWN_WARNING = "Inventions_ShowDespawnWarning";

		private const int GEBPMMAAODD = 250;

		private const long GDCGEKPPOAF = -1L;

		[SerializeField]
		private Route shareLinkRoute;

		[SerializeField]
		private string sharingMessage;

		[SerializeField]
		private string sharingWindowTitle;

		[SerializeField]
		private string sharingWindowDescription;

		private string OMHKGGPLBNK;

		private long KBPFKPGOCFN;

		private bool IHBAHBLPLJL;

		private MessageDialogModel CCEJFNENJHO;

		private IPGOOJIFBAB LHNOLDLKMGH;

		private string DENFGIBLKNA;

		private bool? MMCICCNGPKE;

		private List<string> DOLNIDINOBB;

		private bool CFJIGDAMJBC;

		private bool DLLKDKLJFGK;

		private bool OAIADFBKEKG;

		private bool GHEFEDHOBEC;

		private ALONAFPFMKD BEPMMEOJJAL;

		private OEBAEGDPBLA DBPLCLEDMLJ;

		private DFDECAEJBIO EOHCDFKAIPP;

		private bool FBOPLJIDEMG;

		private bool POJEFMLOEAE;

		private DynamicUIDialogModel DFGBNNHNAIJ;

		private DHAPPKCJJCA IDFNHNLJHKA;

		private EHEJPNFKNAL FOAEGOAOFLI;

		private CBBKADNEBGN ADHHMIKEEJA;

		private bool JMPFEBLFJPI;

		private string AFDJALOEEJA;

		private bool BEDAPJKMMAK;

		private bool KPJLDCCCMPO;

		[CanBeNull]
		private string PAFBGIENLNL;

		private MessageDialogModel CDDAILOEKKB;

		private IPGOOJIFBAB JHMKBGFJBPP;

		private BHNJIBDJFAL NJPJBDDAEFH;

		private FEIKFKAICHC JINHNPGMCMC;

		private global::CPEJHPJNIKM<long> OHJCMACAONC;

		private int? NLEICOLBFAN;

		private bool FGKFAKJBEAA;

public string EntrypointName
{
get 		{
			return null;
		}

private set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public long InventionId
{
get 		{
			return 0L;
		}

set {
		}
}

public bool IncludeCreatorAccount
{
get 		{
			return false;
		}

set {
		}
}

public bool UserAllowsInventionDisclaimerBanner
{
get 		{
			return false;
		}

set {
		}
}

public bool UserAllowsDespawnWarning
{
get 		{
			return false;
		}

set {
		}
}

public string InkCostText
{
get 		{
			return null;
		}

set {
		}
}

public bool IsSpawnQolActive
{
get 		{
			return false;
		}

set {
		}
}

public IReadOnlyList<string> InventionTags
{
get 		{
			return null;
		}

}

public bool CanBeShared
{
get 		{
			return false;
		}

}

public bool IsInventionOwnedAndDownloaded
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanBuyInvention
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanGetInvention
{
get 		{
			return false;
		}

private set {
		}
}

public bool CanTryInvention
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsTryingInvention
{
get 		{
			return false;
		}

}

public bool IsInventionSpawned
{
get 		{
			return false;
		}

}

public ALONAFPFMKD InventionPersonalDetails
{
get 		{
			return null;
		}

private set {
		}
}

public OEBAEGDPBLA Invention
{
get 		{
			return null;
		}

set {
		}
}

public DFDECAEJBIO CreatorAccount
{
get 		{
			return null;
		}

set {
		}
}

public bool SubscribingToCreator
{
get 		{
			return false;
		}

set {
		}
}

public bool SubscribedToCreator
{
get 		{
			return false;
		}

set {
		}
}

public bool IsDormSkin
{
get 		{
			return false;
		}

}

public bool IsCheerPending
{
get 		{
			return false;
		}

private set {
		}
}

		public void Set(long KBPFKPGOCFN, bool ODLPEFCHOAB = false, bool CEGEIPKJGJD = false, string PGEIBONDJJP = null, global::CPEJHPJNIKM<long> OHJCMACAONC = null, int? NLEICOLBFAN = null, bool MMCICCNGPKE = false)
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		private void HKNKFJDKIGL(long KBPFKPGOCFN)
		{
		}

		private void AMOBMOCPGDM(int EJIHLJJMOBD)
		{
		}

		private void EKEKIDEMOGJ()
		{
		}

		private void NJPGIAPHMON(int? PCKCPNGPNBJ)
		{
		}

		private global::NCOKFFGPIJM<string> HIMFAGCMEJF()
		{
			return null;
		}

		private void HINHECNEHDD()
		{
		}

		private void CALFICIKPOB()
		{
		}

		private void KFNCEDCPOGD()
		{
		}

		public Task GetInvention(OILDLLGEMKP.NMJOBHIALCL FLBMMEKNMJC)
		{
			return null;
		}

		public void TryInvention()
		{
		}

		public void TryDespawnTrialInvention()
		{
		}

		public void SpawnDespawnInvention()
		{
		}

		public Task SpawnInvention()
		{
			return null;
		}

		private void OBGIFJIJELJ()
		{
		}

		public void TryDespawnInvention()
		{
		}

		public void ToggleIsCheered()
		{
		}

		public void TryShowReportInventionDialogPopUp()
		{
		}

		public string GetInventionCardPriceFieldText()
		{
			return null;
		}

		public string GetInventionCardButtonStatusText()
		{
			return null;
		}

		public string GetInventionCardButtonPriceText()
		{
			return null;
		}

		public string GetInventionCardButtonSpawnText()
		{
			return null;
		}

		public Sprite GetInventionCardPriceFieldIcon()
		{
			return null;
		}

		private bool CCHAKIEBLCC()
		{
			return false;
		}

		private void MMDFNFAMJPO(string OFMGPNLDCAB, string OFCFPGACNJB, Sprite IECDHEIBMJN = null, List<DGMPBIPKJEB> EFPCOJJCKFH = null)
		{
		}

		private void LAADOPJPPLI()
		{
		}

		private void DNGMMAAILIA(CBBKADNEBGN FGCIGFNJFNA)
		{
		}

		private void DNKMGMCIHPM(string AJIJDOEHMFL)
		{
		}

		private void EKPGGCOPKCH()
		{
		}

		private void ICIABDAGHII()
		{
		}

		public void LaunchPurchaseConfirmationDialog(PLCJLIOLGCO FDGMOJDLMCC)
		{
		}

		private LAHBDKNMNHN GMNPLHPMOJP(PLCJLIOLGCO FDGMOJDLMCC)
		{
			return null;
		}

		private Task ECHNOEEACHI()
		{
			return null;
		}

		public void ShowDisclaimerDismissDialog()
		{
		}

		public void ShareLink()
		{
		}

		public void NavigateToInventionPageAndRecordImpression()
		{
		}

		public void ToggleIsSubscribed(string LDPCFDMCJLH)
		{
		}

		[CompilerGenerated]
		private void OIBIPOJHCDI(OEBAEGDPBLA EGDOIKMDMJM)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<DFDECAEJBIO> OLLDABJACCP()
		{
			return null;
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<bool> CNIIBHIEGIK(DFDECAEJBIO ACBGBAAHOIM)
		{
			return null;
		}

		[CompilerGenerated]
		private void MLNNALEOGHN(bool HCCPLOHLPCJ)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<string> IJKIBHCKIMN(OEBAEGDPBLA EGDOIKMDMJM)
		{
			return null;
		}

		[CompilerGenerated]
		private void LPNIBPAFBHD(string PAFBGIENLNL)
		{
		}

		[CompilerGenerated]
		private void KBJIMOLHJCB(JLGDECHJNNO ANAJIMNLFLD)
		{
		}

		[CompilerGenerated]
		private void NAINPCECCHH(PJGPNHMNHPH JGPDCPDKBGJ)
		{
		}

		[CompilerGenerated]
		private void MALGKOGABMA(BaseDialogModel<IPGOOJIFBAB> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private object FMFHLCDBDEL()
		{
			return null;
		}

		[CompilerGenerated]
		private void LNJLAHOMDNG(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private string JAFFGPILMDF()
		{
			return null;
		}

		[CompilerGenerated]
		private void JDPIAMEHJHD(string KAEDAICECGN)
		{
		}

		[CompilerGenerated]
		private void MCGALGNBHBJ(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void IPCIJNIHLAH(BJMGAOAAKMM CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void ADDPHPHIIKK(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void KJOGKCLINDK(OEBAEGDPBLA CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void HKDHPEKEBBP(ALONAFPFMKD CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void APFKLGMAKLG()
		{
		}

		[CompilerGenerated]
		private void AHJCPIJLAIG()
		{
		}

		[CompilerGenerated]
		private void IOBHNMJFCII(BaseDialogModel<IPGOOJIFBAB> DKIIJDODEMG)
		{
		}

		[CompilerGenerated]
		private void ILAIJGOPJDC()
		{
		}

		[CompilerGenerated]
		private void BCPJJDPOGFF()
		{
		}
	}
}
