using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using RRUI.Data;
using RRUI.Theme;
using TMPro;
using UnityEngine;

public class WatchNotificationsModel : RRUIModel
{
	public enum CIOOJGBLOOL
	{
		Header = 0,
		Message = 1
	}

	public enum JHKLEMJCNGF
	{
		Date_Descending = 0,
		Date_Ascending = 1,
		Custom_String_Sort_Alphabetical_Ascending = 2,
		Custom_String_Sort_Alphabetical_Descending = 3,
		Custom_Number_Sort_Ascending = 4,
		Custom_Number_Sort_Descending = 5
	}

	private struct HINFNHJBBIJ
	{
		public JHKLEMJCNGF PEIAPCPFBNP;

		public string MGADCMMPNCE;

		public HINFNHJBBIJ(JHKLEMJCNGF CDOJNBEINAH, string AAJGLAGGOEE)
		{
			PEIAPCPFBNP = JHKLEMJCNGF.Date_Descending;
			MGADCMMPNCE = null;
		}
	}

	private class OCCMFDBDABA : IComparer<PKJPEMDJKKM>
	{
		public JHKLEMJCNGF FJDHHBMEEBA;

		public int Compare(PKJPEMDJKKM FDAGKPCBDJO, PKJPEMDJKKM EPNHHNJPIKB)
		{
			return 0;
		}

		private int JEGALCHAKNB(PKJPEMDJKKM FDAGKPCBDJO, PKJPEMDJKKM EPNHHNJPIKB, bool PPDPFEBBGFO)
		{
			return 0;
		}

		private int JPBJKBEGHJB(PKJPEMDJKKM FDAGKPCBDJO, PKJPEMDJKKM EPNHHNJPIKB, bool PPDPFEBBGFO)
		{
			return 0;
		}
	}

	public abstract class PKJPEMDJKKM
	{
		private MixedToggleTheme.NMIGMCMKNFH MCEMPKCAJKP;

		private int HLDMAGCCMKM;

		protected readonly WatchNotificationsModel LFKKJIFPEMA;

public abstract CIOOJGBLOOL MMMENNAAGAA
{
get ;
}

public abstract DateTime LLAJJAEJLKN
{
get ;
}

public virtual EJPPMJFCEGI BIJBFOHFNPG
{
get 		{
			return null;
		}

}

public MixedToggleTheme.NMIGMCMKNFH HPPADOMAGDH
{
get 		{
			return MixedToggleTheme.NMIGMCMKNFH.Inactive;
		}

set {
		}
}

public bool FFGNDKFLDMO
{
get 		{
			return false;
		}

set {
		}
}

public int DPHKAOHPFNK
{
get 		{
			return 0;
		}

private set {
		}
}

		public virtual void BMDNBDHHIDB(bool KPABDMMIEJP)
		{
		}

		public void BHAHIDENNAG()
		{
		}

		public void NCKFFICNPFC()
		{
		}

		public PKJPEMDJKKM(int LAGADKBKLAD, WatchNotificationsModel LFKKJIFPEMA)
		{
		}

		~PKJPEMDJKKM()
		{
		}
	}

	public class FDJCMEJKKGK : PKJPEMDJKKM
	{

public override CIOOJGBLOOL MMMENNAAGAA
{
get 		{
			return CIOOJGBLOOL.Header;
		}

}

public override DateTime LLAJJAEJLKN
{
get 		{
			return default;
		}

}

		public FDJCMEJKKGK(int LAGADKBKLAD, WatchNotificationsModel LFKKJIFPEMA)
			: base(0, null)
		{
		}
	}

	public class HKPANIPIGPO : PKJPEMDJKKM
	{
		public readonly EJPPMJFCEGI ILCFIEECOBH;

public override EJPPMJFCEGI BIJBFOHFNPG
{
get 		{
			return null;
		}

}

public override CIOOJGBLOOL MMMENNAAGAA
{
get 		{
			return CIOOJGBLOOL.Header;
		}

}

public override DateTime LLAJJAEJLKN
{
get 		{
			return default;
		}

}

		public override void BMDNBDHHIDB(bool KPABDMMIEJP)
		{
		}

		public HKPANIPIGPO(DMAIEODHOGA OFCFPGACNJB, int LAGADKBKLAD, WatchNotificationsModel LFKKJIFPEMA)
			: base(0, null)
		{
		}

		public HKPANIPIGPO(HEDHPBBBLKG OFCFPGACNJB, int LAGADKBKLAD, WatchNotificationsModel LFKKJIFPEMA)
			: base(0, null)
		{
		}
	}

	private sealed class MGMACFIALIJ : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WatchNotificationsModel _003C_003E4__this;

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
		public MGMACFIALIJ(int _003C_003E1__state)
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

	private sealed class LCDNHACPKGE : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WatchNotificationsModel _003C_003E4__this;

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
		public LCDNHACPKGE(int _003C_003E1__state)
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

	private sealed class MFHNBFFBKPL
	{
		public KCOKPCOFDIM pickerDialogData;

		public WatchNotificationsModel _003C_003E4__this;

		public JHKLEMJCNGF sortType;

		public Predicate<HINFNHJBBIJ> _003C_003E9__4;

		internal void _003CShowSortingDialog_003Eb__3()
		{
		}

		internal void _003CShowSortingDialog_003Eb__0(GameObject instance, int index, TextMeshProUGUI textMeshProUGUI)
		{
		}

		internal int _003CShowSortingDialog_003Eb__1()
		{
			return 0;
		}

		internal bool _003CShowSortingDialog_003Eb__4(HINFNHJBBIJ sortTypeAtIndex)
		{
			return false;
		}

		internal void _003CShowSortingDialog_003Eb__2(int index)
		{
		}

		internal void _003CShowSortingDialog_003Eb__5()
		{
		}
	}

	public const string NOTIF_SORT_MODE_KEY = "NOTIF_SORT_MODE_KEY";

	private const float AEHKIOBGBDK = 1f;

	private BHNJIBDJFAL NJPJBDDAEFH;

	private List<PKJPEMDJKKM> KCAFECEHLLK;

	private List<PKJPEMDJKKM> HICCMPNNCEM;

	private Action<int, MixedToggleTheme.NMIGMCMKNFH> ADDFKLGMIBB__BackingField;

	private Action CJIFCMAFINH__BackingField;

	private Action KDKKAPEFGPC__BackingField;

	private EOOFCNPHMKG.KLOEDHJLIFF GGBALAJGJLN;

	private int HMAGOBLFJJO;

	private bool LIIGIHGLPBP;

	private Coroutine CCLFOIDMIDA;

	private bool HLPFACFCMEN;

	private JHKLEMJCNGF CDOJNBEINAH;

	private HINFNHJBBIJ[] ADPOPIICJHC;

	private bool LKMEJPNNHBP;

	private OCCMFDBDABA COGCHIFFIHI;

	private Coroutine NKJGMKEMEHA;

public bool HasOpenedGiftsOnPage
{
get 	{
		return false;
	}

private set {
	}
}

public IReadOnlyList<PKJPEMDJKKM> Notifications
{
get 	{
		return null;
	}

}

public bool IsEmpty
{
get 	{
		return false;
	}

}

public EOOFCNPHMKG.KLOEDHJLIFF MainNotificationCategory
{
get 	{
		return EOOFCNPHMKG.KLOEDHJLIFF.Transient;
	}

}

public int MainNotificationSubCategory
{
get 	{
		return 0;
	}

set {
	}
}

public bool HasSubcategories
{
get 	{
		return false;
	}

}

public bool DontGenerateHeaders
{
set {
	}
}

public float SortDataLoadingProgress
{
get 	{
		return 0f;
	}

}

public JHKLEMJCNGF NotifSortType
{
get 	{
		return JHKLEMJCNGF.Date_Descending;
	}

set {
	}
}

private bool DHLBJFPDFOG
{
get 	{
		return false;
	}

}

protected override bool GIHBNOOCJDD
{
get 	{
		return false;
	}

}

protected override BMBBHLIOIIF CHGIJCOGJED
{
get 	{
		return default;
	}

}

public event Action<int, MixedToggleTheme.NMIGMCMKNFH> OnHeaderSelectedUpdatedAutomaticallyByChildren {
add {
	}
remove {
	}
}

public event Action OnHeaderSelectedUpdatedManually {
add {
	}
remove {
	}
}

public event Action OnMessagesReadPotentiallyUpdated {
add {
	}
remove {
	}
}

	public void SortMessages()
	{
	}

	public void QueueResort()
	{
	}

	private IEnumerator CLHFAMJHCPP()
	{
		return null;
	}

	private void LEKFFMHHALN()
	{
	}

	private void HDKCIGIIOIM()
	{
	}

	private void FKBDDNICMAO(BJCIKFCDBFN OFCFPGACNJB)
	{
	}

	private void CAJFPECFDEB(BJCIKFCDBFN OFCFPGACNJB)
	{
	}

	private void HLIHAODLMFF(HashSet<long> PPILEOGMMFD)
	{
	}

	private void DCPGKDLCMNM(PIMDBGKAIBE.MMANGNBCADN EIKNIKMJMOP)
	{
	}

	private void BLKGPLLEJFE(PIMDBGKAIBE.MMANGNBCADN EIKNIKMJMOP, DMAIEODHOGA OFCFPGACNJB)
	{
	}

	private void BLKGPLLEJFE(PIMDBGKAIBE.MMANGNBCADN EIKNIKMJMOP, IReadOnlyList<DMAIEODHOGA> OBDPGGPGHBB)
	{
	}

	private void KDDKAANOHOH(HEDHPBBBLKG NONLILMOAPN)
	{
	}

	private void BGJKHJICIHA(long PNCKHFDCOIG)
	{
	}

	private void FDJCLBJBIEP(int GMEHLIHLGEH)
	{
	}

	private void NIENBBGIOLM(long IKHNIJKGJFD, EJPPMJFCEGI.EHIHBHLKNMO MCGAJGCMAAK)
	{
	}

	private void NDKEKNDHMBN(HashSet<long> PPILEOGMMFD, EJPPMJFCEGI.EHIHBHLKNMO MCGAJGCMAAK)
	{
	}

	private void OAIFGEJHODD(DMAIEODHOGA OFCFPGACNJB)
	{
	}

	private void HAGKNDJOMNJ(IReadOnlyList<DMAIEODHOGA> OBDPGGPGHBB)
	{
	}

	private void OAAEKGBMFKA(DMAIEODHOGA OFCFPGACNJB)
	{
	}

	private void KIAHJIENBOC(IReadOnlyList<DMAIEODHOGA> OBDPGGPGHBB)
	{
	}

	private bool LFOEHMDPCHC()
	{
		return false;
	}

	private void CLDBLKLELAL()
	{
	}

	private bool HBJJOPHKHDM(out int LAGADKBKLAD)
	{
		LAGADKBKLAD = default;
		return false;
	}

	private IEnumerator EMBKOJMGKKN()
	{
		return null;
	}

	private bool KOJLHFBJMPI(DMAIEODHOGA OFCFPGACNJB, bool FJCKLJLMLAN, out int LAGADKBKLAD)
	{
		LAGADKBKLAD = default;
		return false;
	}

	private void NBCAHKMAGON<T>(IReadOnlyList<T> OBDPGGPGHBB, bool FJCKLJLMLAN) where T : DMAIEODHOGA
	{
	}

	private void GEJCCHMINLC(IReadOnlyList<HEDHPBBBLKG> EDAIMHEABEO)
	{
	}

	private IReadOnlyList<PKJPEMDJKKM> MCCCDKEFEBG()
	{
		return null;
	}

	private void BKJEDPEGHPK()
	{
	}

	private void CILHJIAOBBD(List<PKJPEMDJKKM> MIOCBKNEJKL)
	{
	}

	public void OnRefreshButtonPressed()
	{
	}

	public bool AreAnyNotificationsDismissable(int LNNOHHADILP, bool IFBODNCIGDB)
	{
		return false;
	}

	public void SetCurrentCategory(EOOFCNPHMKG.KLOEDHJLIFF JNKJFJLJKNJ, int DNENAPMBGDO, bool KFDKIAEGPJK = false)
	{
	}

	public bool HasUnreadWatchNotificationsInCategory(EOOFCNPHMKG.KLOEDHJLIFF JNKJFJLJKNJ)
	{
		return false;
	}

	public bool HasUnreadWatchNotificationsInSubCategory(int MKNOBDHGMAH)
	{
		return false;
	}

	public void ReevaluateSelected(int LNNOHHADILP)
	{
	}

	public void SetSelected(int GMEHLIHLGEH, bool KCAPLJEHMMI)
	{
	}

	public void DeleteNotification(EJPPMJFCEGI IMAJKJBCIMJ)
	{
	}

	public void DismissSelected(int LNNOHHADILP)
	{
	}

	private void IFFPFKNFIHA(int LNNOHHADILP, bool DBCFOCLDOLH)
	{
	}

	public void BatchPrimaryAction(int LNNOHHADILP)
	{
	}

	public void BatchSecondaryAction(int LNNOHHADILP)
	{
	}

	public bool GetSelected(int GMEHLIHLGEH)
	{
		return false;
	}

	public void SetSelected(int GMEHLIHLGEH, MixedToggleTheme.NMIGMCMKNFH MCEMPKCAJKP)
	{
	}

	public void ShowSortingDialog()
	{
	}

	protected override void DHHOMFCCFKP()
	{
	}

	protected override void IILPBDLFFKG()
	{
	}

	protected override void BJPPPBGBLAO()
	{
	}

	protected override void KPOHBHPPGBM()
	{
	}

	protected override void LPBNNNGFPIF()
	{
	}

	protected override LAHBDKNMNHN KANNLKCLIOF()
	{
		return null;
	}
}
