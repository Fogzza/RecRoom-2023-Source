using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Core.UI.RoomChat;
using RecRoom.Inputs.Touch;
using RecRoom.UI;
using RecRoom.UI.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Core
{
	public class ScreenHUD : MonoBehaviour
	{
		private enum LFBLLHHKPEO
		{
			NONE = 0,
			WAITING_FOR_DELAY = 1,
			CURSOR_TO_CURSOR = 2,
			CURSOR_TO_CROSSHAIR = 3,
			CROSSHAIR_TO_CROSSHAIR = 4,
			CROSSHAIR_TO_CURSOR = 5
		}

		private sealed class FNBGCMPCMII : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float delay;

			public ScreenHUD _003C_003E4__this;

			public ScreenHUDCursor lhs;

			public float fadeDuration;

			public ScreenHUDCursor rhs;

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
			public FNBGCMPCMII(int _003C_003E1__state)
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

		[SerializeField]
		private ScreenWorldSpaceUIAnchor worldSpaceUIAnchor;

		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private CanvasScaler canvasScaler;

		[SerializeField]
		private RoomChatMenu roomChatMenu;

		[SerializeField]
		private PictureInPictureMenu pictureInPictureMenu;

		[SerializeField]
		private ScreenHUDElementGroup leftHandWavePoseGroup;

		[SerializeField]
		private ScreenHUDElementGroup rightHandWavePoseGroup;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private ScreenHUDBadgeManager badgeManager;

		[SerializeField]
		private ScreenHUDCursor cursorPrimary;

		[SerializeField]
		private ScreenHUDCursor cursorSecondary;

		private ScreenHUDCursor EBIMENIICMG;

		private ScreenHUDCursor EJEIBFBHAHI;

		[SerializeField]
		private ScreenHUDCrosshair crosshair;

		public ShortcutMenuManager shortcutMenu;

		[SerializeField]
		private WatchNotificationDialog screenWatchNotificationDialog;

		[SerializeField]
		private ScreenModeScreenSpaceNotificationConfig screenSpaceNotificationConfig;

		[SerializeField]
		private ScreenSubtitleDialog subtitleDialog;

		[SerializeField]
		private ScreenTutorialPromptDialog tutorialPromptDialog;

		[SerializeField]
		private ScreenHUDElement[] globalDialogRoots;

		[SerializeField]
		private ScreenHUDElement[] contextualDialogRoots;

		[SerializeField]
		private ScreenHUDElement leftContextualDialogListRoot;

		[SerializeField]
		private ScreenHUDElement rightContextualDialogListRoot;

		[SerializeField]
		private CanvasGroup[] hudCanvasGroups;

		[SerializeField]
		private ScreenHUDElement touchPseudoMenuCloseButton;

		[SerializeField]
		private float phoneScaleFactor;

		[SerializeField]
		private float tabletScaleFactor;

		[SerializeField]
		private float pcConsoleScaleFactor;

		[SerializeField]
		private RectTransform[] marginRectTransforms;

		[SerializeField]
		private Vector4 phoneMargins;

		[SerializeField]
		private Vector4 tabletMargins;

		[SerializeField]
		private Vector4 pcConsoleMargins;

		[SerializeField]
		private Vector2 touchInteractPromptMargin;

		[SerializeField]
		private GameObject[] toggleOffForProUX;

		private JNKNMMDAHCF DHCLACKALOF;

		private RectTransform HHCOHMMJGFO;

		private bool NPFNBBODGCP;

		private bool MLBGBPIBLKJ;

		private readonly FIHGBEHGLGB KAMDBDBMPMC;

		private readonly FIHGBEHGLGB MKBDPAKFGIB;

		private readonly FIHGBEHGLGB LACAJDMPKOC;

		private bool NGFPKLEAKPA;

		private readonly ScreenHUDControlDialog[] CPFJAFOPNMP;

		private readonly Dictionary<MIKAPGMDNAD, TouchRegion> OEEOGCHANNJ;

		private LFBLLHHKPEO NHLDDOBAFEJ;

		private readonly int JACAJOEBIDP;

		private readonly FIHGBEHGLGB DAFPGMDHMKD;

		private readonly FIHGBEHGLGB HCFJFKPJEAJ;

		private readonly FIHGBEHGLGB PCPDHIPOJGD;

		private readonly FIHGBEHGLGB BJLPPNFJHDL;

public RoomChatMenu RoomChatMenu
{
get 		{
			return null;
		}

}

public PictureInPictureMenu PictureInPictureMenu
{
get 		{
			return null;
		}

}

public ScreenWorldSpaceUIAnchor WorldSpaceUIAnchor
{
get 		{
			return this.worldSpaceUIAnchor;
		}

}

public WatchNotificationDialog WatchNotificationDialog
{
get 		{
			return null;
		}

}

public ScreenModeScreenSpaceNotificationConfig ScreenSpaceNotificationConfig
{
get 		{
			return null;
		}

}

public ScreenHUDElementGroup LeftHandWavePoseGroup
{
get 		{
			return null;
		}

}

public ScreenHUDElementGroup RightHandWavePoseGroup
{
get 		{
			return null;
		}

}

public CanvasScaler CanvasScaler
{
get 		{
			return null;
		}

}

public bool IsWatchNotificationBadgeVisible
{
get 		{
			return false;
		}

}

public bool IsContextualControlDialogRestricted
{
get 		{
			return false;
		}

}

public bool AreHUDMenusRestricted
{
get 		{
			return false;
		}

}

public bool IsRoomChatMenuRestricted
{
get 		{
			return false;
		}

}

public bool IsP2PChatMenuRestricted
{
get 		{
			return false;
		}

}

public bool IsCursorEnabled
{
get 		{
			return false;
		}

}

public Vector2 CursorViewportPosition
{
get 		{
			return default;
		}

}

public bool IsCrosshairEnabled
{
get 		{
			return false;
		}

}

		public void SetIsDriving(bool IPMIIEAGJKC)
		{
		}

		public bool GetIsDriving()
		{
			return false;
		}

		public void SetAlpha(float MEGHPOMLDMP)
		{
		}

		public void AddContextualControlDialogRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveControlDialogRestriction(object IALNODEHBNN)
		{
		}

		public void AddHUDMenusRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveHUDMenusRestriction(object IALNODEHBNN)
		{
		}

		public void AddRoomChatMenuRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveRoomChatMenuRestriction(object IALNODEHBNN)
		{
		}

		public void AddP2PChatMenuRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveP2PChatMenuRestriction(object IALNODEHBNN)
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void NMJKIJBBDKO(Player MHCOBIPKGNI)
		{
		}

		public void Enable(bool OBFHBDLKFPA, object IALNODEHBNN)
		{
		}

		public void StartProUX()
		{
		}

		public void StopProUX()
		{
		}

		public void FinalizeAtEndOfFrame(AECAHLPIFOC KAEDAICECGN)
		{
		}

		public void SetCursorSprite(Sprite DLADPCHJMME, Vector2 EHDGCEBICIF)
		{
		}

		public void SetCursorSize(float GABNCKGIEBH)
		{
		}

		public void SetCrosshairColor(Color HMCAFGCGFJF)
		{
		}

		public void EnableCursor(bool BFDBCMGIOBG, object IALNODEHBNN)
		{
		}

		private void OPKLGFNDLGC()
		{
		}

		public void CrossFadeCursorToCursor(float FHFDDKOBFLG, float DHGKDPBMONF)
		{
		}

		public void SetCursorViewportSpacePosition(Vector2 JNHGFAEPOJC)
		{
		}

		private IEnumerator<EGGPGCCKPCO> CMONJMPIAMC(ScreenHUDCursor BLFKABPCHLN, ScreenHUDCursor NPFMAENOPCH, float FHFDDKOBFLG, float DHGKDPBMONF)
		{
			return null;
		}

		public void EnableCrosshairForFrame(ScreenHUDCrosshair.IKNLFLEALLL PPMLMNLJAAE)
		{
		}

		public void DisableCrosshair()
		{
		}

		public void SetCrosshairTickDistance(float HNNAGDCDKKB)
		{
		}

		public void SetCrosshairViewportSpacePosition(Vector2 JNHGFAEPOJC)
		{
		}

		public void ShowPseudoTouchMenuCloseButtonForFrame()
		{
		}

		public void GloballyEnableControlDialogs()
		{
		}

		public void GloballyDisableControlDialogs()
		{
		}

		public void ShowControlDialogForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, string IEACNHGAIIE, float DDKCONDPEJF = -1f)
		{
		}

		public void ShowControlDialogForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, Sprite EIGOFECJNBJ, string IEACNHGAIIE, string OEEBIOPLOMG = null, Texture GGOHABAGCIF = null, float DDKCONDPEJF = -1f, bool LNGFIBHMPNE = false, MLMLNGCFECK? LCEOFCFGDIH = null, bool AIBNPIHCAEJ = false, bool BMPMFKNNHBL = false)
		{
		}

		private void ADMLPDENFKC(ScreenHUDControlDialog GDMKJGAKCND, ScreenHUDControlDialog.KPKPHHMBPDD LHIDPDIJJCI, Sprite EIGOFECJNBJ, Sprite LGHABMGGHLH, string HLIGBKANEEA, string OEEBIOPLOMG, Texture GGOHABAGCIF = null, float DDKCONDPEJF = -1f)
		{
		}

		public ScreenHUDControlDialog GetDialogForControlType(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, MLMLNGCFECK? LCEOFCFGDIH = null)
		{
			return null;
		}

		private ScreenHUDControlDialog.KPKPHHMBPDD FNJKJMMFGMC(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, bool LNGFIBHMPNE, bool BMPMFKNNHBL)
		{
			return default;
		}

		private void NNDAHLOLBBB(int CDICGKKBGMO)
		{
		}

		private void LGAECMGBMPN()
		{
		}

		public void GloballyEnableTouchButtons()
		{
		}

		public void GloballyDisableTouchButtons()
		{
		}

		private void MCOHMNFBLHO<T>(int CDICGKKBGMO, T[] DKIPBFCBBBG) where T : ScreenHUDElement
		{
		}

		private void ELAHPDBNKNP<T>(IEnumerable<T> DKIPBFCBBBG) where T : ScreenHUDElement
		{
		}

		private void EHELKGGLFAA<T>(bool FBHDABEFLKL, T[] DKIPBFCBBBG) where T : ScreenHUDElement
		{
		}

		public TouchRegion GetTouchRegionForControlType(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH)
		{
			return null;
		}

		public void PositionTouchInteractionPrompt(AECAHLPIFOC KAEDAICECGN, FMNJCGLEDJO POINFDHCNCM, Vector2 OADOFEDJPMP, PlayerHand.ICBKGDOJNDN BNNHCJJILFB)
		{
		}

		public void ShowTouchElementForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH)
		{
		}

		public void ShowTouchElementForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, Sprite DLADPCHJMME, float DDKCONDPEJF = -1f, bool LNGFIBHMPNE = false)
		{
		}

		public void ShowTouchElementForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, string IEACNHGAIIE, string OEEBIOPLOMG = null, float DDKCONDPEJF = -1f, bool LNGFIBHMPNE = false)
		{
		}

		public void ShowTouchElementForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, Sprite DLADPCHJMME, Texture CIONKGJFLOB, string IEACNHGAIIE, string OEEBIOPLOMG = null, float DDKCONDPEJF = -1f, bool LNGFIBHMPNE = false)
		{
		}

		public void ShowWalkJoystickForFrame(AECAHLPIFOC KAEDAICECGN)
		{
		}

		public void ShowLookJoystickForFrame(AECAHLPIFOC JLFMCCADIKH)
		{
		}

		public void ShowTouchElementWithRegionDelegateForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, IOCPDIHFMFC.JIHIHFJJFOI IFHIAGDJAJF)
		{
		}

		public void RemoveTouchElementWithRegionDelegateForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, IOCPDIHFMFC.JIHIHFJJFOI IFHIAGDJAJF)
		{
		}

		public void ShowControlElementForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, string IEACNHGAIIE = null, string OEEBIOPLOMG = null, float DDKCONDPEJF = -1f, bool LNGFIBHMPNE = false)
		{
		}

		public void ShowControlElementForFrame(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, Sprite DLADPCHJMME, string IEACNHGAIIE, string OEEBIOPLOMG = null, Texture CIONKGJFLOB = null, float DDKCONDPEJF = -1f, bool LNGFIBHMPNE = false, bool AIBNPIHCAEJ = false)
		{
		}

		public void ShowOrUpdateBadgeOnControlElement(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, ScreenHUDBadge.PKNIACPIPPO GJNKHFLDKHK)
		{
		}

		private void PCNAKKACEDD(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, ScreenHUDBadge.PKNIACPIPPO GJNKHFLDKHK)
		{
		}

		public bool ControlElementHasBadge(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH)
		{
			return false;
		}

		private void JGAKMLACAMA(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH, ScreenHUDBadge.PKNIACPIPPO GJNKHFLDKHK)
		{
		}

		public void HideBadgeOnControlElement(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH)
		{
		}

		private void BEDMIIIPAIA(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH)
		{
		}

		private void MDCHCPBLOFH(FMNJCGLEDJO POINFDHCNCM, AECAHLPIFOC JLFMCCADIKH)
		{
		}

		public void DisplayWatchNotification(NotificationManager.BMLNJJNEOAB PBOPFHHBNPO, AECAHLPIFOC JLFMCCADIKH)
		{
		}

		public void UpdateWatchNotificationBadge(DGFHKEBHIFF ALIOPIPDGDM, string HLIGBKANEEA)
		{
		}

		public void AddWatchNotificationBadgeRestriction(object IALNODEHBNN)
		{
		}

		public void RemoveWatchNotificationBadgeRestriction(object IALNODEHBNN)
		{
		}

		public void ShowSubtitleForFrame(string OEEBIOPLOMG, Sprite DDJJDDAMEFB = null)
		{
		}

		public void EnableTutorialPromptDialog(GLKEAIAEBFF GJNKHFLDKHK)
		{
		}

		public void DisableTutorialPromptDialog()
		{
		}

		private void LMKMIOODAPD(AECAHLPIFOC KAEDAICECGN)
		{
		}

		private void BFANIGMNCOB(ScreenHUDElement OFFJPOMOLDJ, Vector2 AELOJCNDNDH, Vector2 EMLDKFGPGFK)
		{
		}

		private Vector2 KBJHIPFFOFF(Vector2 AELOJCNDNDH, Vector2 EMLDKFGPGFK)
		{
			return default;
		}

		[CompilerGenerated]
		internal static void PIAEPKIFEEE(ScreenHUDElement HHFDFFDPCGO)
		{
		}
	}
}
