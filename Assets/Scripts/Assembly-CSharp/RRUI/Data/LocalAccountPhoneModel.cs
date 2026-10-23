using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using RRUI.Dialogs;

namespace RRUI.Data
{
	public class LocalAccountPhoneModel : RRUIModel, KFLOGBPDDDD
	{
		private sealed class JCHJLICGJNI
		{
			public LocalAccountPhoneModel _003C_003E4__this;

			public string fullPhoneNumber;

			public Action _003C_003E9__4;

			public Action<BaseDialogModel<EJBAHPMBHMO>> _003C_003E9__1;

			internal void _003CSetPhone_003Eb__0()
			{
			}

			internal void _003CSetPhone_003Eb__4()
			{
			}

			internal void _003CSetPhone_003Eb__1(BaseDialogModel<EJBAHPMBHMO> dialog)
			{
			}
		}

		private sealed class EOAPJMIPNFH
		{
			public string code;

			public JCHJLICGJNI CS_0024_003C_003E8__locals1;

			internal string _003CSetPhone_003Eb__2()
			{
				return null;
			}

			internal void _003CSetPhone_003Eb__3(string s)
			{
			}

			internal void _003CSetPhone_003Eb__5()
			{
			}
		}

		private sealed class DHACEAEBBBI : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public StackedUIFlowBase newFlow;

			public LocalAccountPhoneModel _003C_003E4__this;

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
			public DHACEAEBBBI(int _003C_003E1__state)
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

		public const string TITLE_OVERRIDE_KEY = "PhoneTitleText";

		private string JJPKBDBABAG;

		private DBIPHDIEBCM FKANPJLFEEA;

		private string HAIIHNOIHOA;

		private string AOFFNBMJCAB;

		private long IDDLLNPENBK;

		private string DIBOFMHLGNG;

		private string BDKDIMABNBH;

		private DynamicUIDialogModel PKGABFDINKJ;

		private DHAPPKCJJCA JLGGIKPDHAJ;

		private MessageWithInputFieldDialogModel GJKLIOAJDMP;

		private EJBAHPMBHMO PMCCFDPIOHD;

		private bool AMFACKIMFHM;

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public string TitleText
{
get 		{
			return null;
		}

private set {
		}
}

public string NewPhoneNumber
{
get 		{
			return null;
		}

set {
		}
}

public string FormattedCountryAndDialCode
{
get 		{
			return null;
		}

set {
		}
}

public bool PhoneIsValid
{
get 		{
			return false;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override LAHBDKNMNHN KANNLKCLIOF()
		{
			return null;
		}

		public void OverrideTitle(string GFFOMHMCDGE)
		{
		}

		public void SetPhoneFlowCompletedPromise(DBIPHDIEBCM BOJDPAGLBLI)
		{
		}

		public void OpenCountryCodeSelectionDialog()
		{
		}

		public void SetPhone()
		{
		}

		private void HHBEGNAOJGK(string MCGEFCJLEOM, string FKKHPIMPJBP)
		{
		}

		private IEnumerator<EGGPGCCKPCO> BLGNNFGNNLN(StackedUIFlowBase GGBPGKFCHDK)
		{
			return null;
		}

		public void OnRRUIStackedUIEntered(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK)
		{
		}

		public void OnBeforeRRUIStackedUIExited(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public void OnRRUIStackedUIExited(StackedUIFlowBase OHINCEKNIJF, StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		[CompilerGenerated]
		private object KFDDALHBOGN()
		{
			return null;
		}

		[CompilerGenerated]
		private void MKJLBNKIMDA(object FDAIMOMOHIG)
		{
		}

		[CompilerGenerated]
		private void ILDJMNFNEKB(string IPMIIEAGJKC)
		{
		}

		[CompilerGenerated]
		private void HDBOJGFAANL(BaseDialogModel<DHAPPKCJJCA> GDMKJGAKCND)
		{
		}

		[CompilerGenerated]
		private void CJHHOGLPFBF()
		{
		}
	}
}
