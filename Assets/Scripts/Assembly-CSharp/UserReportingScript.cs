using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserReportingScript : MonoBehaviour
{
	private sealed class OMDDFOFBHFA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UserReportingScript _003C_003E4__this;

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
		public OMDDFOFBHFA(int _003C_003E1__state)
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

	public Dropdown CategoryDropdown;

	public InputField DescriptionInput;

	public Canvas ErrorPopup;

	private bool CJOFKOLMGAF;

	public bool IsHotkeyEnabled;

	public bool IsInSilentMode;

	public bool IsSelfReporting;

	private bool BACGPDMFJDI;

	private bool CNCNMMIEILG;

	public Text ProgressText;

	public bool SendEventsToAnalytics;

	public Canvas SubmittingPopup;

	public InputField SummaryInput;

	public Image ThumbnailViewer;

	private BKCOOHKCFAC KOGFJFAPGNM;

	public Button UserReportButton;

	public Canvas UserReportForm;

	public UserReportingPlatformType UserReportingPlatform;

	public UnityEvent UserReportSubmitting;

	private IHHLAAILAIF PDOEGIOPCOK;

public IHHLAAILAIF CurrentUserReport
{
get 	{
		return null;
	}

private set {
	}
}

public JDCAJECAIEF State
{
get 	{
		return JDCAJECAIEF.Idle;
	}

}

	public void CancelUserReport()
	{
	}

	private IEnumerator EBGHPKBINNO()
	{
		return null;
	}

	private void GGFFMFLHICC()
	{
	}

	public void CreateUserReport()
	{
	}

	private CGGCEJMAEEC NFNFPGGMLDB()
	{
		return null;
	}

	public bool IsSubmitting()
	{
		return false;
	}

	private void CCMNJHILGOD(IHHLAAILAIF BDKEBECPKEA)
	{
	}

	private void Start()
	{
	}

	public void SubmitUserReport()
	{
	}

	private void Update()
	{
	}

	protected virtual void FNJMAODNFEI()
	{
	}

	[CompilerGenerated]
	private void BMOLAFCMBHL(IHHLAAILAIF CJEJGOIKJAN)
	{
	}

	[CompilerGenerated]
	private void LOOOMEJHOHK(float HHKFNGINMFF, float PCPABLIGDPM)
	{
	}

	[CompilerGenerated]
	private void KFKHINEMGHK(bool EGJEBAFNALL, IHHLAAILAIF FIEOJOANDOM)
	{
	}
}
