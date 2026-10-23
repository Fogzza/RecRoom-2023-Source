using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RRUI;
using RRUI.Data;
using RecRoom;
using RecRoom.Audio;
using UnityEngine;

public class TitleScreenManager : SingletonMonoBehaviour<TitleScreenManager>
{
	[StructLayout((LayoutKind)3)]
	private struct AECFDDJIDAL
	{
		public TitleScreenManager _003C_003E4__this;

		public AudioClip currentMusic;
	}

	private sealed class BBOMFKCKKEP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TitleScreenManager _003C_003E4__this;

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
		public BBOMFKCKKEP(int _003C_003E1__state)
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

	private sealed class EPCGHFICLMA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TitleScreenManager _003C_003E4__this;

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
		public EPCGHFICLMA(int _003C_003E1__state)
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
	private Canvas mainCanvas;

	[SerializeField]
	private Canvas[] otherCanvases;

	[SerializeField]
	private RoundedCorners backgroundRoundedCorners;

	[SerializeField]
	private TitleScreenFlowModel flowModel;

	[SerializeField]
	private AGVirtualKeyboard keyboardPrefab;

	[SerializeField]
	private RecRoomAudioClip titleScreenMusic;

	[SerializeField]
	private RecRoomAudioClip accountCreationMusic;

	[SerializeField]
	private float musicFadeInTime;

	private Coroutine HEGLMMJABEN;

	private AGVirtualKeyboard KMNIAGFPHEN;

	private Vector3 AFFEJPNPKPM;

	private Vector3 AHAPJIODLLJ;

	private Quaternion BGMCKGNIMKN;

	public const string BIRTHDAY_ENTERED = "birthdayEntered";

	public const string EMAIL_STEP = "emailStep";

	public const string CREATING_ACCOUNT = "creatingAccount";

	public const string ACCOUNT_CREATED = "accountCreated";

	public const string ACCOUNT_FAILED = "failedAccountCreation";

	public const string RESET_PASSWORD = "passwordReset";

	public const string BDAY_ISJUNIOR = "isJunior";

	public const string CONFIRM_EMAIL_INPUT = "confirmEmailInput";

	public const string CONFIRM_EMAIL_SENT = "confirmEmailSent";

	public const string CONFIRM_EMAIL_ERROR = "confirmEmailError";

	public const string RESULT_LATER = "later";

	public const string RESULT_SUCCESS = "success";

	public const string SEND_LINK = "sendLink";

	public const string PRIVACY_POLICY = "privacyPolicy";

	public const string FAIL_TO_SEND = "failToSend";

	public const string EMAIL_SUBMITTED = "submitted";

	private const string HKFGDBKECJB = "registration_flow";

	private const string DMEOMNCICNG = "step";

	private const string DPIAFGBJFPK = "substep";

	private const string LCJBNNCGMKE = "privacyPolicy";

	private const string MOKDHGLKAFD = "codeOfConduct";

	private const string LKHBIIKKMJJ = "Birthday";

	private DCCDAPLPICN IBDKAJJPLGA;

	private CPBPJLLMKDB LIPCPJMCHDF;

public AIOCIBMFJEJ FlowModel
{
get 	{
		return flowModel;
	}

}

public bool CanUpdateOrGoToFeed
{
get 	{
		return false;
	}

}

public bool TitleScreenFeedEnabled
{
get 	{
		return false;
	}

}

	protected override void Awake()
	{
		base.Awake();
		LoadingScreen.Instance.IsVisibleChangeEvent += NBDKIBMNLCA;
		KMNIAGFPHEN = UnityEngine.Object.Instantiate<AGVirtualKeyboard>(keyboardPrefab, Vector3.zero, Quaternion.identity);
		KMNIAGFPHEN.ForceHideKeyboard(true);
		IBDKAJJPLGA = MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<DCCDAPLPICN>(null);
		LIPCPJMCHDF = MPAAIECKLGA.CFHDLGEGDFD.HHCPOGCCGNF<CPBPJLLMKDB>(null);
	}

	private void Start()
	{
		mainCanvas.renderMode = RenderMode.WorldSpace;
		mainCanvas.worldCamera = RecRoom.Core.UI.UIInputModule.Instance.ControllerCamera;
		AFFEJPNPKPM = mainCanvas.transform.position;
		AHAPJIODLLJ = mainCanvas.transform.localScale;
		BGMCKGNIMKN = mainCanvas.transform.rotation;
		if (otherCanvases != null)
		{
			for (int i = 0; i < otherCanvases.Length; i++)
			{
				otherCanvases[i].renderMode = RenderMode.WorldSpace;
				otherCanvases[i].worldCamera = RecRoom.Core.UI.UIInputModule.Instance.ControllerCamera;
			}
		}
		LIPCPJMCHDF.DisplayModeChange += PMNJIOHDABB;
		PMNJIOHDABB();
		IBDKAJJPLGA.LEODHBOENKA(PlatformManager.Instance.DefaultLayout, true);
		JHIKKDDFDGA.PEOPJAFNOBD(this, NMJIFHLPFNP, true);
	}

	private void Update()
	{
	}

	protected override void OnDestroy()
	{
	}

	public bool IsOnTitleScreen()
	{
		return false;
	}

	private void NBDKIBMNLCA(bool ICHBECDKHOJ)
	{
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}

	private void PMNJIOHDABB()
	{
		bool inScreenDisplayMode = LIPCPJMCHDF.InScreenDisplayMode;
		if (backgroundRoundedCorners != null)
			backgroundRoundedCorners.enabled = !inScreenDisplayMode;
		var anchor = RecRoom.Core.CameraRig.Instance.ScreenModeHUD.WorldSpaceUIAnchor;
		if (!inScreenDisplayMode)
		{
			if (anchor.AttachedGameObject == mainCanvas.gameObject)
				anchor.Detach();
			mainCanvas.transform.position = AFFEJPNPKPM;
			mainCanvas.transform.localScale = AHAPJIODLLJ;
			mainCanvas.transform.rotation = BGMCKGNIMKN;
			RecRoom.Core.UI.UIInputModule.Instance.ControllerCamera.farClipPlane = 20f;
		}
		else
		{
			var screenCamera = RecRoom.Core.CameraRig.Instance.ScreenModeCamera;
			anchor.Attach(mainCanvas.gameObject, EKJBJGDALKG, screenCamera.transform.rotation, 1f, 0f, false);
			RecRoom.Core.UI.UIInputModule.Instance.ControllerCamera.farClipPlane =
				Vector3.Distance(mainCanvas.transform.position, screenCamera.transform.position) * 2f;
		}
	}

	public void QueueBirthdayEventForPostLogIn(DateTime DPAIFPOLPOC)
	{
	}

	public void LogRegistrationEvent(string GDGDAIAMBKP, string ICGAPNOBCBF = null)
	{
	}

	public void LogRegistrationEventWithDetail(string GDGDAIAMBKP, string PJECDPAJCJE, string BNDLEDFKJKL)
	{
	}

	public void OnPrivacyPolicySelected()
	{
	}

	public void OnComfortAndSafetySelected()
	{
	}

	private void NDENAIFEGGC(IEnumerator KNMNCHEEHEI)
	{
	}

	private void MLOEPDOPGJD()
	{
	}

	private void NMJIFHLPFNP(float OKBAJEAPIHG)
	{
	}

	private IEnumerator KJNOGCGEIHD()
	{
		return null;
	}

	private IEnumerator MDLLPIFKLJO()
	{
		return null;
	}

	public void UpdateOrGoToFeed(List<KDEEJHLLLCH> MJFMBHKBJID, DBECJLAIPEL PKGLLJBECJM, bool CKDDPKOJGGJ = false)
	{
	}

	[CompilerGenerated]
	private Vector2 EKJBJGDALKG()
	{
		RectTransform rectTransform = (RectTransform)mainCanvas.transform;
		Vector2 sizeDelta = rectTransform.sizeDelta;
		Vector3 lossyScale = rectTransform.lossyScale;
		return new Vector2
		{
			x = lossyScale.x * sizeDelta.x,
			y = lossyScale.y * sizeDelta.y
		};
	}

	[CompilerGenerated]
	private bool INAANGFKADI(RecRoomAudioClip MHNDMEJNOLH, ref AECFDDJIDAL P_1)
	{
		return false;
	}
}
