using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using RRUI.Dialogs;
using RRUI.Navigation;
using RecRoom.Utils.Image;
using UnityEngine;

namespace RRUI.Data
{
	public class RoomCurrencyModel : RRUIModel<DAKMOAKIKIC>
	{
		public class BMPLELNGEBC
		{
			public Guid BLEIJIALGBO;

			public string PALADLMJNAK;

			public string HDJKLNIGFHF;

			public string EDMNOAEBDNC;

			public int KPKILOKBMMH;

			private bool NHMDFOHKFJL;

public bool KBJOCCLGCEO
{
get 			{
				return false;
			}

set {
			}
}
		}

		private sealed class MFNHFPMDMJF
		{
			public GameObject loadingSpinner;

			public GameObject noPackagesText;

			public RoomCurrencyPackageModel[] packageModels;

			public RoomCurrencyModel _003C_003E4__this;

			internal void _003CLoadPackageModels_003Eb__0(List<KPMECOOBOKJ> data)
			{
			}

			internal void _003CLoadPackageModels_003Eb__1(string error)
			{
			}
		}

		private sealed class NINIGKAPALE
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CShowRoomCurrencyDebugDialog_003Eb__2_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public NINIGKAPALE _003C_003E4__this;

				private TaskAwaiter<NGHFNDNBCGL> _003C_003Eu__1;

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

			public MessageWithInputFieldDialogModel activeDialog;

			public RoomCurrencyModel _003C_003E4__this;

			public long newAmount;

			public HELFEDOLCOM errorMessage;

			public LAJCFKEJKIN saveButton;

			internal Task _003CShowRoomCurrencyDebugDialog_003Eb__2(CancellationToken cancellationToken)
			{
				return null;
			}

			internal string _003CShowRoomCurrencyDebugDialog_003Eb__3()
			{
				return null;
			}

			internal void _003CShowRoomCurrencyDebugDialog_003Eb__4(string s)
			{
			}

			internal void _003CShowRoomCurrencyDebugDialog_003Eb__0(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}
		}

		public const string ROOM_CURRENCY_ID_KEY = "ROOM_CURRENCY_ID_KEY";

		public const string ROOM_CURRENCY_ENTRYPOINT_NAME_KEY = "ROOM_CURRENCY_ENTRYPOINT_NAME_KEY";

		public const string DEFAULT_NAME_TEXT = "Create New Room Currency";

		private const string GMHOHABLIFN = "tokens";

		public const string ROOM_CURRENCY_SHOW_INFO_IN_DETAIL_VIEW = "RoomCurrency_ShowInfoInDetailView";

		[SerializeField]
		private bool redirectOnSuccessfulCreation;

		[SerializeField]
		private Route creationRedirectRoute;

		public static Guid INVALID_CURRENCY_ID;

		private bool JFEOALPNFIG;

		private int MEICCIJAFCP;

		private Guid PNKPEHFPJLM;

		private BKCIEBLAHHB EABCAONEPPN;

		private long CBEKDOCGEGE;

		private string OMHKGGPLBNK;

		private bool JMBBLLIFCGC;

		private bool LNNDJNAGIIH;

		private OneButtonMessageDialogModel PEHELDEPGIJ;

		private MessageDialogModel CCEJFNENJHO;

		private FBNJPEHPKJA MGJKGCBILFL;

		private FBNJPEHPKJA ADPJBJELAHB;

		private FBNJPEHPKJA MJBGNJACLIJ;

		private List<Func<LAHBDKNMNHN>> DHHKLOJKEFE;

		private readonly ManagedTexture PHDELAPLILN;

		private BMPLELNGEBC OILJONIKABP;

public bool CanCreateNewRoomCurrency
{
get 		{
			return false;
		}

}

public bool HasValidCurrencyId
{
get 		{
			return false;
		}

}

public bool IsSaveInProgress
{
get 		{
			return false;
		}

private set {
		}
}

public int NumberOfCurrenciesInCurrentRoom
{
get 		{
			return 0;
		}

private set {
		}
}

public Guid CurrencyId
{
get 		{
			return default;
		}

private set {
		}
}

public BKCIEBLAHHB RoomCurrency
{
get 		{
			return null;
		}

private set {
		}
}

public long RoomCurrencyBalance
{
get 		{
			return 0L;
		}

private set {
		}
}

public string EntrypointName
{
get 		{
			return null;
		}

private set {
		}
}

public static bool DisplayRoomCurrencyInfoSection
{
get 		{
			return false;
		}

set {
		}
}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public BMPLELNGEBC BackingData
{
get 		{
			return null;
		}

private set {
		}
}

public Guid RoomCurrencyId
{
get 		{
			return default;
		}

private set {
		}
}

public string Name
{
get 		{
			return null;
		}

set {
		}
}

public string Description
{
get 		{
			return null;
		}

set {
		}
}

public int DailyLimit
{
get 		{
			return 0;
		}

set {
		}
}

public string ImageName
{
get 		{
			return null;
		}

set {
		}
}

public bool ShouldSubmitButtonBeInteractable
{
get 		{
			return false;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		public void Set(Guid DJOFODHJEBF, bool IDNNLLKEEHB = true, string NNECEELJHMM = null)
		{
		}

		public void AddSaveOperation(Func<LAHBDKNMNHN> JKGJMBNBPEL)
		{
		}

		public void RemoveSaveOperation(Func<LAHBDKNMNHN> JKGJMBNBPEL)
		{
		}

		public void PackageModelDeleted()
		{
		}

		public void LoadPackageModels(RoomCurrencyPackageModel[] ANLFFEHCOJH, GameObject BHAAHCIAEPI, GameObject FIKMLCOKCAM, bool NNGBIIMBFCL = false)
		{
		}

		public void DespawnPackageModels(RoomCurrencyPackageModel[] ANLFFEHCOJH, GameObject BHAAHCIAEPI, GameObject FIKMLCOKCAM)
		{
		}

		private bool NCPIPODGHAJ()
		{
			return false;
		}

		public void Save()
		{
		}

		private LAHBDKNMNHN FPHMFLPJDCA()
		{
			return null;
		}

		private void PAHCHEECJLB(Guid LFNGEFEDKJM)
		{
		}

		private void HCJHIDHLHNC(BKCIEBLAHHB AAEEGNFPOOH)
		{
		}

		private void NIENBMDBHIM(NGHFNDNBCGL HBGBOLHPFEF)
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF(DAKMOAKIKIC MIEKCPMBJHD)
		{
			return null;
		}

		public void TryChangeRoomCurrencyImage()
		{
		}

		private global::NCOKFFGPIJM<string> DLLPNBIEHKH()
		{
			return null;
		}

		public LAHBDKNMNHN ModifyRoomCurrency()
		{
			return null;
		}

		public bool IsCurrencyNameValid()
		{
			return false;
		}

		private global::NCOKFFGPIJM<BKCIEBLAHHB> EFJIEGADNCL()
		{
			return null;
		}

		private void CEELGOFNJOA()
		{
		}

		private void KNCCNDCDPOE()
		{
		}

		private void JIIHIMGLKLO()
		{
		}

		private void BDJPDPKFAPE()
		{
		}

		public void ShowDismissInfoDisclaimerDialog()
		{
		}

		public void ShowRoomCurrencyDebugDialog()
		{
		}

		[CompilerGenerated]
		private void BNEEAKEECJF(OneButtonMessageDialogModel GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void OEPFJOFJBFF(OneButtonMessageDialogModel GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN NGBGDCCBICL(BKCIEBLAHHB DLAOMGCBOAI)
		{
			return null;
		}

		[CompilerGenerated]
		private void OFCFOBFNMMH()
		{
		}

		[CompilerGenerated]
		private LAHBDKNMNHN PCIOBFJNFBJ()
		{
			return null;
		}

		[CompilerGenerated]
		private void MBLIBEFCLIF()
		{
		}

		[CompilerGenerated]
		private bool OINKLGIJGAL(BKCIEBLAHHB FCCGDNMAHPA)
		{
			return false;
		}

		[CompilerGenerated]
		private void HNIOJPPKOFN(string NPOEAPJKNFN)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<string> OKEFKJIMKMG(List<GDHOAGNFOBD.FPPNEFOBPMC> CBLOLEAFFPC)
		{
			return null;
		}

		[CompilerGenerated]
		private void LJJCANAJDAI(NGHFNDNBCGL CDNLFEOBNKB)
		{
		}

		[CompilerGenerated]
		private void EDGOOMFHEJJ()
		{
		}

		[CompilerGenerated]
		private void KDLAECNHHCD()
		{
		}

		[CompilerGenerated]
		private void NHKIPHNPJJH(MessageDialogModel LFKKJIFPEMA)
		{
		}
	}
}
