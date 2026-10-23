using System;
using System.Collections.Generic;
using RRUI.Dialogs;
using UnityEngine;

namespace RRUI.Data
{
	public class ChatThreadListModel : FilterableListModel<long, FMEDMCFGHFM, string>
	{
		private sealed class NMPONJOIOCD
		{
			public HashSet<int> indicesToCreateChatWith;

			public ChatThreadListModel _003C_003E4__this;

			public IReadOnlyList<DFDECAEJBIO> accountsPlayerCanMessage;

			public PickerDialogModel createChatDialog;

			public EHEJPNFKNAL confirmButton;

			public Action _003C_003E9__8;

			internal bool _003CShowCreateChatDialog_003Eb__4()
			{
				return false;
			}

			internal void _003CShowCreateChatDialog_003Eb__5()
			{
			}

			internal void _003CShowCreateChatDialog_003Eb__8()
			{
			}

			internal void _003CShowCreateChatDialog_003Eb__0(GameObject instance, int index, CardModel cardModel, AccountModel accountModel, JLOCLGGLOPP toCardController)
			{
			}

			internal bool _003CShowCreateChatDialog_003Eb__1(string filter, int i)
			{
				return false;
			}

			internal void _003CShowCreateChatDialog_003Eb__2()
			{
			}

			internal void _003CShowCreateChatDialog_003Eb__3(BaseDialogModel<KCOKPCOFDIM> dialog)
			{
			}
		}

		private sealed class PBFFGCPIAEH
		{
			public KCIMFOOCLPN createChatFlow;

			public NMPONJOIOCD CS_0024_003C_003E8__locals1;

			internal void _003CShowCreateChatDialog_003Eb__6(FMEDMCFGHFM chatThread)
			{
			}

			internal void _003CShowCreateChatDialog_003Eb__7(string err)
			{
			}
		}

		private const int MCEHDAMNEMJ = -1;

		private readonly EEANDDJEMJC BGAKPJJGKEJ;

		private readonly EEANDDJEMJC ODINKPMHBAP;

		private List<long> MOFFEEIMIGC;

		private ChatThreadModel MJOAINOGKFO;

		private int FNNONOEONMK;

		private MFGJOELPIIL MIOEIFPEOLB;

		private DCCDAPLPICN LKPLMCAEDAD;

		private CDLILHDKGGD GDPDKMDOBMH;

		[SerializeField]
		private ChatThreadModel selectedChatThreadModel;

		[SerializeField]
		private LFFKCMNFNAN chatTelemetrySource;

public EEANDDJEMJC OnSelectedGridIndexChange
{
get 		{
			return null;
		}

}

public EEANDDJEMJC OnSelectedChatThreadChanged
{
get 		{
			return null;
		}

}

protected override bool GIHBNOOCJDD
{
get 		{
			return false;
		}

}

public List<long> ChatThreadIds
{
get 		{
			return null;
		}

private set {
		}
}

public ChatThreadModel SelectedChatThreadModel
{
get 		{
			return null;
		}

set {
		}
}

public long SelectedChatThreadId
{
get 		{
			return 0L;
		}

}

public bool PlayerHasClubChats
{
get 		{
			return false;
		}

}

public int SelectedGridIndex
{
get 		{
			return 0;
		}

set {
		}
}

public MFGJOELPIIL Source
{
get 		{
			return MFGJOELPIIL.PlayerChats;
		}

set {
		}
}

private DCCDAPLPICN PAAHLKLHMOL
{
get 		{
			return null;
		}

}

private CDLILHDKGGD FGFFCFFCEPN
{
get 		{
			return null;
		}

}

		protected override void DHHOMFCCFKP()
		{
		}

		protected override void LPBNNNGFPIF()
		{
		}

		protected override void IILPBDLFFKG()
		{
		}

		protected override void DCEBFEOEHGG()
		{
		}

		protected override void KPOHBHPPGBM()
		{
		}

		public void SetChatFilter(string HNGJGPJCNBJ)
		{
		}

		protected override global::NCOKFFGPIJM<IReadOnlyList<FMEDMCFGHFM>> LFFEHHGOFFN()
		{
			return null;
		}

		private void DNIAFHEPKHI(IReadOnlyList<FMEDMCFGHFM> DILBLKKEDCG)
		{
		}

		protected override long EIDFFKOOKDK(FMEDMCFGHFM AAMFKNLLGDC)
		{
			return 0L;
		}

		private global::NCOKFFGPIJM<IEnumerable<FMEDMCFGHFM>> NKDABAEKEFN(IEnumerable<FMEDMCFGHFM> JNAAHMPCPAB)
		{
			return null;
		}

		private bool DIFKOCKKJFO(string HNGJGPJCNBJ, FMEDMCFGHFM AAMFKNLLGDC)
		{
			return false;
		}

		private void HCMKLHAIPPB(FMEDMCFGHFM AAMFKNLLGDC)
		{
		}

		private void GCJJHAOAPHJ(long FFBALOOMPIB, int EJIHLJJMOBD, string LBCPKCMJIKK)
		{
		}

		private void BLKJJBIOCEC()
		{
		}

		private void OHLLCDEMGIF(long AFPHABFLEBN, KEJOIDAKHLL IIDIPBJDGKB)
		{
		}

		private void PGCFMKNDNAK(long AFPHABFLEBN)
		{
		}

		public void SelectChatThread(long FFBALOOMPIB)
		{
		}

		public void ShowCreateChatDialog()
		{
		}

		public void ToggleFiltering(MFGJOELPIIL LFDHCCFNEMP)
		{
		}
	}
}
