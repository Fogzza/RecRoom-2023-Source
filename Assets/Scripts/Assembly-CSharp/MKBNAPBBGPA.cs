using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Core.Comfort;
using RecRoom.Settings;
using RecRoom.Systems.StreamingCamera;
using UnityEngine;
using UnityEngine.Scripting;

internal class MKBNAPBBGPA : JNKNMMDAHCF, CEPCPLIDGFK, IDisposable
{
	private sealed class KCOJANCGLJG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public MKBNAPBBGPA _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public KCOJANCGLJG(int _003C_003E1__state)
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

	private readonly EEANDDJEMJC BPCKCCPDBDE = new EEANDDJEMJC(true, false);

	private readonly BHNJIBDJFAL NJPJBDDAEFH;

	private readonly global::BANDHPLOOPI<ONCCFHECNKK> DDMDANHPLOH;

	private SettingDefaults CPNIIEKHLGB = new SettingDefaults();

	private MPKEDKHLCLJ FLHHDLJKMNM;

	private Action ONHKHKMFCAP__BackingField;

	private const string PBFOMGFKIKD = "ShowNames";

	private const string EDLCCKAIOGI = "ShowOwnNames";

	private const string DIFAKMJEKME = "ShowVoiceLines";

	private const string KDHAFBOEJHG = "ShowRoomCenter";

	private readonly EEANDDJEMJC BMKLNOPCGJB = new EEANDDJEMJC(true, false);

	private const string BEKENLFMCKJ = "FPSMonitorEnabled";

	private const string DNIAAHCKKOM = "VoiceChat";

	private Action JOJPIEMAKKN__BackingField;

	private const string JONCJKLPAFN = "VoiceFilter2";

	private const string HHJMNIFNGAJ = "VoicesICanHear";

	private const string JMECIDLIBIG = "RoomChat";

	private const string PDMIOPCMEAH = "RoomChatMobile";

	private const string BBIKHALIFJL = "HandMute";

	private const string LNLDFCNFEMM = "TapToOpenWatch";

	private const string FBDNKADBNDJ = "ShowWatchNotifications";

	private const string JPKMPOPBNLI = "DisableGiftNotifications";

	private const string AEPEPBBJJGH = "TeleportBuffer";

	private Action IONLPIEHOKD__BackingField;

	private const string GBCNPGMOOOC = "ShowRRPlus";

	private Action PHNFDGLFGFK__BackingField;

	private const string CCCKGEJKCMB = "PlayerStatusVisibility";

	private Action<JFAAGFOLICM, JFAAGFOLICM> MNIAODDEILE__BackingField;

	private const string JGCNLKGIKII = "DisablePersonalBubbleForFriends";

	private const string HAFAJPDEMAC = "IncreaseComfortSettingsWhileInStopFlow";

	private const string DNFDMBMLEKB = "ROTATE_IN_PLACE_ENABLED";

	private const string CCCOPKJLFLE = "ROTATION_INCREMENT";

	private const string BMFMBPIBINB = "STRAFE_ENABLED";

	private const string JJECONFAIHD = "CONTINUOUS_ROTATION_MODE";

	private readonly EEANDDJEMJC CHEKDMCMIMP = new EEANDDJEMJC(true, false);

	private const string OGIKKOCEKLH = "VR_EXTERIOR_SCROLLBAR";

	private const string HPGLPJLKEHH = "VR_SCROLLBAR_SIDE";

	private const string JBLHLBPABIJ = "VR_TOOL_SCROLLBAR_SIDE";

	private readonly EEANDDJEMJC JBIBIIEHJHK = new EEANDDJEMJC(true, false);

	private const string FEOKPNPAPJF = "VR_WATCH_MENU_SIZE";

	private const string HMOPEOLIHGO = "THUMBSTICK_SCROLLING_ENABLED";

	private const string LMJFPJLICNI = "VR_MOVEMENT_MODE";

	private Action BNFMMAPCEBC__BackingField;

	private const string EDMENLNFLGF = "VR_LEGACY_FLYING_ENABLED";

	private const string AEMFELFBPKP = "VR_TOUCH_GRID";

	private const string AJBCJDJLICH = "VR_TOUCH_CURSOR";

	private const string JGBFNHFMCGO = "VR_TOUCH_CLICK_ON_CANCEL";

	private const string IJDBHDNMEAL = "WALKING_MODE";

	private Action JEKPKMCIHMB__BackingField;

	private const string OKBNEPHHNEK = "VRAUTOSPRINT";

	private const string HEHBGDLEGPK = "SCREENSAUTOSPRINT";

	private const string GIHGHJHHMCO = "AUTOSPRINT_GAMEPAD";

	private const string CKNLNPMNAHO = "AUTOSPRINT_KEYBOARD";

	private const string PPEBMEDONBG = "AUTOSPRINT_TOUCH";

	private const string JIEMHNJOAHO = "SPRINTMODE_GAMEPAD";

	private const string ONFHFJPBAFM = "SPRINTMODE_KEYBOARD";

	private const string BAAJPBJPBIK = "HoldToAimDownSights";

	private const string EJMMCJLJLIN = "ThumbstickWalk";

	private const string KHDOIKJCGJI = "MOTION_TURN_ENABLED";

	private const bool LBPOAJLOBOJ = true;

	private const string GBCEIGJNCLC = "DONT_LOCK_TOOLS_TO_HAND";

	private const bool NBONLDKDOMI = false;

	private const string JMOGGPOEIAK = "TOUCHPAD_TELEPORT_ENABLED";

	private const string NABNNNLPJLG = "STABILIZE_HANDS";

	private const string NBOHKIJBCIF = "SEATED_MODE";

	private const string LHGMLLAGNBK = "VR_INTERACT_LABELS_ENABLED";

	private const string IKOCMOANGID = "VR_VEHICLE_INPUT_METHOD";

	private const string DLOLJODCCGE = "EXPRESSO_MENU_HANDEDNESS";

	private string JPKHLNLFNCB = "COMFORT_ENABLED";

	private const string CHMFAHPCANG = "COMFORT_FLY";

	private const string FNEBPGAFIKA = "COMFORT_ROTATE";

	private const string HOBADGKDAOH = "COMFORT_CLIMB";

	private const string PKPFKIBNKMP = "COMFORT_WALK";

	private const string ECMPIFGFOBB = "COMFORT_SPRINT";

	private const string JBLGCGAOLKP = "COMFORT_VEHICLES";

	private const string GMEGNOIENHA = "COMFORT_FALL";

	private const string AIECPCAHHPN = "COMFORT_TELEPORT";

	private const string PMJOPIPINFO = "COMFORT_FORCES";

	private const string BLFLOJMBFGH = "TV_MODE_VEHICLES";

	private const string HNCIFPKBOMB = "COMFORT_SETTINGS";

	private const string OKHAMCHEBBE = "PlayerHeight";

	private const string GOOHOJBPJOD = "SCREENS_INVERT_LOOK";

	private const string JHINJHNBMFM = "SCREENS_INVERT_LOOK_X";

	private const float GPAPLMHANGC = 1f;

	private const float AGPCMKBJPLF = 10f;

	private const string IPCNKDGCCNL = "SCREENS_LOOK_SENSITIVITY";

	private const float CCLBIDKFNJE = 100f;

	private const string BMCJCMKNIBB = "SCREENS_GAMEPAD_SENSITIVITY_HORIZ";

	private const string KDKNNGDJJHC = "SCREENS_GAMEPAD_SENSITIVITY_VERT";

	private const string OCPPDOMAOAJ = "SCREENS_CAMERA_ACCELERATION_GAMEPAD";

	private const string ADCBKBAEGCM = "SCREENS_INVERT_MOUSE";

	private const string LBIBMLLOAHG = "SCREENS_INVERT_MOUSE_X";

	private const float JDCKMJNKGDH = 1f;

	private const float OCAPBLAHBOO = 100f;

	private const string GLIKOKMALLE = "SCREENS_MOUSE_SENSITIVITY";

	private const string CLFMBCGILAH = "SCREENS_MOUSE_SENSITIVITY_HORIZ";

	private const string GELHIGANFKN = "SCREENS_MOUSE_SENSITIVITY_VERT";

	private const string LHNGLCDDAIH = "SCREENS_INVERT_TOUCH";

	private const string GCCDGNKJHHO = "SCREENS_INVERT_TOUCH_X";

	private const string MPJMKHPIDMM = "SCREENS_MINIMAL_HUD";

	private const string NFCBHMLBGAN = "SCREENS_SEAT_RECENTERING_ENABLED";

	private const string CCEMBOAMPON = "SCREENS_AUTO_FIRE";

	private const float HMEKCPMFDOJ = 1f;

	private const float MLKKPICLCJL = 100f;

	private const string IOFKCFKECOD = "SCREENS_TOUCH_SENSITIVITY";

	private const string FGCGIOCKACE = "SCREENS_TOUCH_SENSITIVITY_HORIZ";

	private const string MILNFJNHFCM = "SCREENS_TOUCH_SENSITIVITY_VERT";

	private const string CMKFKCKHIFB = "SCREENS_MOTION_CONTROLS_ENABLED";

	private const string LBABJIDBBDP = "MOBILE_AR_CONTROLS_ENABLED";

	private const string DCOFOGPPGAO = "AR_ROOM_SCALE_LOCOMOTION_ENABLED";

	private const string BEKCEOCCBEF = "FULL_AR_MODE_ENABLED";

	private const string JCCFBAMJLFI = "SCREENS_HEAD_BOB";

	private const string GEIOLMABOEJ = "SCREEN_MKB_CONTROL_SCHEME_PREF";

	private const string NGDCBPLGGAP = "SCREEN_GAMEPAD_CONTROL_SCHEME_PREF";

	private Action OBOFOKJFFDE__BackingField;

	private const string NMCPGCEBCMM = "PER_HAND_INTERACT_CONTROLS_TOUCH";

	private const string OIKKDODHBHO = "THIRD_PERSON_OPT_IN";

	private const string IFLIABMLAJB = "QualitySettings_";

	private const string HKINIMGJKAD = "QualitySettings";

	private const string IDMDOFMBFDJ = "QualitySettingsMobile";

	private Action<GHCCKFEJDOA> LDPBDHKKDCC__BackingField;

	public const string GKCCPGNPCNH = "ScreensVsyncEnabled";

	private readonly string IAPMOFMAILO = "PlayerSessionCount";

	private readonly string JGBDONFHNOO = "PlayerHasExitedDorm";

	public const string AHOJHLIPEJE = "CrossPlatformWarningDisplayed";

	public const string HLNEFHMNAGD = "PSOnlyMatching";

	private Action<float> CMFEKKOEAOG__BackingField;

	public const string KOIGDPEOABL = "AutosaveInterval";

	private const string HMLPJFPJEMD = "ShareCamGesture";

	private const string KNEEHFLEDJP = "ShareCamAutoSmile";

	private const string OLMFKPPKDNH = "ShareCamMirrorPreview";

	private const string DKGBGMOBIEM = "SCREENS_SHARE_CAM_SELFIE_RELATIVE_MOVEMENT";

	private const string KPOOHNMDPIN = "SCREENS_SHARE_CAM_SELFIE_INVERT_X";

	private const string CPFOPOLHFAJ = "SCREENS_SHARE_CAM_SELFIE_INVERT_Y";

	private const string MIJJAIPNABF = "VR_SHARE_CAM_MENU_SIZE";

	private StreamingCameraController HKAHIKJJMMH;

	private StreamingCameraController.PEBNLHNMBGI EPIONMJKBPJ;

	private const string PNPNGGBHHLH = "PLAYER_USES_FULL_BODY_AVATAR";

public EEANDDJEMJC AFEAPJBOCDP
{
get 	{
		return null;
	}

}

public MPKEDKHLCLJ EFIINEBBKOD
{
get 	{
		return MPKEDKHLCLJ.None;
	}

set {
	}
}

public bool HBGGKIJGKDE
{
get 	{
		return false;
	}

set {
	}
}

public bool KLNIDEBLEGO
{
get 	{
		return false;
	}

set {
	}
}

public bool OKMECBJMFDC
{
get 	{
		return false;
	}

set {
	}
}

public bool IINJNPMDBGG
{
get 	{
		return false;
	}

set {
	}
}

public EEANDDJEMJC IDEFCHEHOOK
{
get 	{
		return null;
	}

}

public bool LGOBOGKJFBB
{
get 	{
		return false;
	}

set {
	}
}

public DPDBLMENBLF PLDNPALHPLH
{
get 	{
		return DPDBLMENBLF.Mute;
	}

set {
	}
}

private EAPMPDFMAMI BDMAMNIKKPM
{
get 	{
		return EAPMPDFMAMI.CLOUD;
	}

}

public NOMDJBMGHMJ HKCDJPBHGJK
{
get 	{
		return NOMDJBMGHMJ.LowPitch;
	}

set {
	}
}

public FOFOHMMFILG LKNHNLEIDDF
{
get 	{
		return FOFOHMMFILG.None;
	}

set {
	}
}

public AJKNNOFCDCJ KNKCHCNDEOH
{
get 	{
		return AJKNNOFCDCJ.On;
	}

set {
	}
}

private string BMENHHGOGJO
{
get 	{
		return null;
	}

}

private AJKNNOFCDCJ CNIFCNLLMPP
{
get 	{
		return AJKNNOFCDCJ.On;
	}

}

public bool JMCPEDBKDKP
{
get 	{
		return false;
	}

set {
	}
}

public bool OHEIHACBECF
{
get 	{
		return false;
	}

set {
	}
}

public bool FLLCHEHALCA
{
get 	{
		return false;
	}

set {
	}
}

public bool JADNNCEPOAL
{
get 	{
		return false;
	}

set {
	}
}

public float KHHMENPLMDJ
{
get 	{
		return 0f;
	}

}

public PINLDPIKLLE JMLGPOJOGNB
{
get 	{
		return PINLDPIKLLE.Small;
	}

set {
	}
}

private string PANEEBOJLFJ
{
get 	{
		return null;
	}

}

private ONCCFHECNKK EHNOKDIJOPG
{
get 	{
		return ONCCFHECNKK.Disabled;
	}

}

public ONCCFHECNKK IPCLFLPFKEB
{
get 	{
		return ONCCFHECNKK.Disabled;
	}

}

public bool IDGJHCBNDOP
{
get 	{
		return false;
	}

set {
	}
}

public JFAAGFOLICM KKONFMHGPHO
{
get 	{
		return JFAAGFOLICM.Public;
	}

set {
	}
}

public bool GKMLCHDLBPE
{
get 	{
		return false;
	}

set {
	}
}

public bool POIEGEKKPII
{
get 	{
		return false;
	}

}

public bool OBJAFLDOGHI
{
get 	{
		return false;
	}

set {
	}
}

public bool HEOALALEFKM
{
get 	{
		return false;
	}

set {
	}
}

public OLEMPONHGJB EJOJLNJLBPG
{
get 	{
		return OLEMPONHGJB.SNAP_FORTY_FIVE_DEGREES;
	}

set {
	}
}

public bool ECDMDPAKDJN
{
get 	{
		return false;
	}

set {
	}
}

public bool MBHGOBCEIHA
{
get 	{
		return false;
	}

}

public JIFNNGHEDND BJEFPNFOCFG
{
get 	{
		return JIFNNGHEDND.DISABLED;
	}

set {
	}
}

public EEANDDJEMJC DOIDDJJHGBK
{
get 	{
		return null;
	}

}

public bool NMJBNMNBAFJ
{
get 	{
		return false;
	}

set {
	}
}

public MFEHGEJOLDL CMBAJDBAIJE
{
get 	{
		return MFEHGEJOLDL.Left;
	}

set {
	}
}

public MFEHGEJOLDL DNPOCCLNEEN
{
get 	{
		return MFEHGEJOLDL.Left;
	}

set {
	}
}

public EEANDDJEMJC FBILHKICOGJ
{
get 	{
		return null;
	}

}

public MAKDBNOCAAD FCFPMKLDNIA
{
get 	{
		return MAKDBNOCAAD.Small;
	}

set {
	}
}

public bool BLANIEANLMO
{
get 	{
		return false;
	}

set {
	}
}

public NLOBDKDEACH BAALCNAMGID
{
get 	{
		return NLOBDKDEACH.TELEPORT;
	}

set {
	}
}

public bool DGJPBHCLKPF
{
get 	{
		return false;
	}

set {
	}
}

public bool KKNOLAJHOFB
{
get 	{
		return false;
	}

set {
	}
}

public bool FKDPAGFNFGK
{
get 	{
		return false;
	}

set {
	}
}

public bool DNPDDDBOIDH
{
get 	{
		return false;
	}

set {
	}
}

public GOIFPBJAGOG BFBLALAJOFE
{
get 	{
		return (GOIFPBJAGOG)0;
	}

set {
	}
}

public bool GDOBMHOPFGG
{
get 	{
		return false;
	}

set {
	}
}

public KFIAEIHFGII ILHOEHDDABD
{
get 	{
		return KFIAEIHFGII.Hold;
	}

set {
	}
}

public bool PCMDGLHCOFJ
{
get 	{
		return false;
	}

set {
	}
}

public NAODPIKMKHK NHDIBGIMJEJ
{
get 	{
		return NAODPIKMKHK.OFF;
	}

set {
	}
}

public bool FADMHBFDFAP
{
get 	{
		return false;
	}

set {
	}
}

public bool FBGAEPECEIH
{
get 	{
		return false;
	}

set {
	}
}

public bool JFGFCLGHHEB
{
get 	{
		return false;
	}

set {
	}
}

public bool JGOFFKBKDII
{
get 	{
		return false;
	}

set {
	}
}

public bool? IDLNDLIEOMN
{
get 	{
		return null;
	}

set {
	}
}

public bool JCOJHGLNAGP
{
get 	{
		return false;
	}

set {
	}
}

public BMKCHGCBDCO DMGNGJBIKMB
{
get 	{
		return BMKCHGCBDCO.MOTION_INPUT;
	}

set {
	}
}

public BOLFHKKILPB IIBLPJNNHMI
{
get 	{
		return BOLFHKKILPB.LEFT;
	}

set {
	}
}

public bool PDPGMGINHBC
{
get 	{
		return false;
	}

set {
	}
}

public bool DCIPFLGJLFM
{
get 	{
		return false;
	}

set {
	}
}

public bool JLKLACKHCDC
{
get 	{
		return false;
	}

set {
	}
}

public bool KMMADCLBHGK
{
get 	{
		return false;
	}

set {
	}
}

public bool HBEIPAJKJID
{
get 	{
		return false;
	}

set {
	}
}

public bool PBKGJDGBNIA
{
get 	{
		return false;
	}

set {
	}
}

public bool LPAJEJEEMPN
{
get 	{
		return false;
	}

set {
	}
}

public DPIDGEICOAI JECIIGDDAKG
{
get 	{
		return DPIDGEICOAI.OFF;
	}

set {
	}
}

public DPIDGEICOAI ONJEPAFGCLG
{
get 	{
		return DPIDGEICOAI.OFF;
	}

set {
	}
}

public DPIDGEICOAI IGNJAPAFFJJ
{
get 	{
		return DPIDGEICOAI.OFF;
	}

set {
	}
}

public VRLocomotionComfortMode.SerializedSettings ECOPKEGJFNP
{
get 	{
		return default;
	}

set {
	}
}

public float? CLJOOMIDNOP
{
get 	{
		return null;
	}

set {
	}
}

public bool FMNCPDPONOH
{
get 	{
		return false;
	}

set {
	}
}

public bool LDGHBAIDBFB
{
get 	{
		return false;
	}

set {
	}
}

public Vector2 GPGJHNEPPCM
{
get 	{
		return default;
	}

set {
	}
}

public float EHCEFPANFIH
{
get 	{
		return 0f;
	}

}

public Vector2 JLLMPKMNNPF
{
get 	{
		return default;
	}

}

public bool IKGJKNIEBNL
{
get 	{
		return false;
	}

set {
	}
}

public bool EOAENPDMNON
{
get 	{
		return false;
	}

set {
	}
}

public bool LHHCDIAGLBP
{
get 	{
		return false;
	}

set {
	}
}

public Vector2 AGFAJIEOLKB
{
get 	{
		return default;
	}

set {
	}
}

public float PHBPHEAKAKK
{
get 	{
		return 0f;
	}

}

public bool CNDBEJBAFNK
{
get 	{
		return false;
	}

set {
	}
}

public bool MBMNEEOGGOB
{
get 	{
		return false;
	}

set {
	}
}

public bool IBODBGNBABP
{
get 	{
		return false;
	}

set {
	}
}

public bool HBGDNNMKFBK
{
get 	{
		return false;
	}

set {
	}
}

public bool OKHBCDHPOHM
{
get 	{
		return false;
	}

set {
	}
}

public Vector2 HBPPCMDMNIP
{
get 	{
		return default;
	}

set {
	}
}

public float EICLILJILLH
{
get 	{
		return 0f;
	}

}

public bool BMCLKLKOKAL
{
get 	{
		return false;
	}

set {
	}
}

public bool KJBPJIAJPMN
{
get 	{
		return false;
	}

set {
	}
}

public bool BOAIFINNONB
{
get 	{
		return false;
	}

set {
	}
}

public bool GCOMKHCJAEO
{
get 	{
		return false;
	}

set {
	}
}

public float AKNLMDPGMNE
{
get 	{
		return 0f;
	}

set {
	}
}

public string ENDPNLELBLG
{
get 	{
		return null;
	}

set {
	}
}

public bool DPBBELBANMM
{
get 	{
		return false;
	}

}

public string GGGFONCNOEG
{
get 	{
		return null;
	}

set {
	}
}

public bool AEFCFOOBKPH
{
get 	{
		return false;
	}

}

public bool PJCDHBBEMOC
{
get 	{
		return false;
	}

set {
	}
}

public bool EOEAMLMBHDE
{
get 	{
		return false;
	}

set {
	}
}

public GHCCKFEJDOA KMBOABNPCPE
{
get 	{
		return GHCCKFEJDOA.Fastest;
	}

set {
	}
}

private GHCCKFEJDOA OKIJDKFEIHN
{
get 	{
		return GHCCKFEJDOA.Fastest;
	}

}

private string NKBLCEGHFHE
{
get 	{
		return null;
	}

}

public bool BBDFBEFDEFD
{
get 	{
		return false;
	}

set {
	}
}

public int BOIOMLNDCCF
{
get 	{
		return 0;
	}

private set {
	}
}

public bool ICMFLKFCCLI
{
get 	{
		return false;
	}

set {
	}
}

public bool NDHICIBEJKP
{
get 	{
		return false;
	}

set {
	}
}

public bool IGNKEGDFBPP
{
get 	{
		return false;
	}

set {
	}
}

public float ALFNDKAGBNI
{
get 	{
		return 0f;
	}

set {
	}
}

public bool IHEPIFIKBPI
{
get 	{
		return false;
	}

set {
	}
}

public bool MDFGANEIMLA
{
get 	{
		return false;
	}

set {
	}
}

public bool CBFPLBGONCB
{
get 	{
		return false;
	}

set {
	}
}

public bool PCKNKOPKEMA
{
get 	{
		return false;
	}

set {
	}
}

public bool EDNBFAEFAJH
{
get 	{
		return false;
	}

set {
	}
}

public bool MFBFBAGGJIG
{
get 	{
		return false;
	}

set {
	}
}

public FOFAFNONMCH MKOGHJPNAPF
{
get 	{
		return FOFAFNONMCH.Small;
	}

set {
	}
}

public StreamingCameraController.PEBNLHNMBGI OOHALPNLFFL
{
get 	{
		return StreamingCameraController.PEBNLHNMBGI.OFF;
	}

set {
	}
}

public StreamingCameraController PPODMHJDHLB
{
get 	{
		return null;
	}

}

public bool EOAJEINAHPB
{
get 	{
		return false;
	}

}

public bool LDBILBJKMEC
{
get 	{
		return false;
	}

}

public bool LLICHIACMAM
{
get 	{
		return false;
	}

set {
	}
}

private bool JNGGNLFGFOO
{
get 	{
		return false;
	}

}

private bool DNKMPHENBNP
{
get 	{
		return false;
	}

}

private bool MEPGFCCNEPM
{
get 	{
		return false;
	}

}

private bool EMKGINCGELC
{
get 	{
		return false;
	}

}

private bool ECJFAKIDENF
{
get 	{
		return false;
	}

}

private bool DMAFEJHMCOA
{
get 	{
		return false;
	}

}

 event Action global::JNKNMMDAHCF.ONHKHKMFCAP {
add {
	}
remove {
	}
}

 event Action global::JNKNMMDAHCF.JOJPIEMAKKN {
add {
	}
remove {
	}
}

 event Action global::JNKNMMDAHCF.IONLPIEHOKD {
add {
	}
remove {
	}
}

 event Action global::JNKNMMDAHCF.PHNFDGLFGFK {
add {
	}
remove {
	}
}

 event Action<JFAAGFOLICM, JFAAGFOLICM> global::JNKNMMDAHCF.MNIAODDEILE {
add {
	}
remove {
	}
}

 event Action global::JNKNMMDAHCF.BNFMMAPCEBC {
add {
	}
remove {
	}
}

 event Action global::JNKNMMDAHCF.JEKPKMCIHMB {
add {
	}
remove {
	}
}

 event Action global::JNKNMMDAHCF.OBOFOKJFFDE {
add {
	}
remove {
	}
}

 event Action<GHCCKFEJDOA> global::CEPCPLIDGFK.LDPBDHKKDCC {
add {
	}
remove {
	}
}

 event Action<float> global::JNKNMMDAHCF.CMFEKKOEAOG {
add {
	}
remove {
	}
}

	[IOFOCEAPGPD(NPBJMIOJGOK.None)]
	private static void EDLMAOJJALF(MNALHHOLFGL FMPHDMAKDKP)
	{
		FMPHDMAKDKP.IFIGMJHIABP<JNKNMMDAHCF>().CLBIACAHFKJ<MKBNAPBBGPA>();
	}

	[Preserve]
	public MKBNAPBBGPA([CDOANEBODFP(null)] BHNJIBDJFAL FMMEGIJPELJ)
	{
		NJPJBDDAEFH = FMMEGIJPELJ;
		NJPJBDDAEFH.NEDNGDBICFI<VRLocomotionComfortMode.SerializedSettings>(new global::ABGPJBLKOMM<VRLocomotionComfortMode.SerializedSettings>(), null);
		NJPJBDDAEFH.LNOFPOFGLEK += new Action(BPCKCCPDBDE.LMIEJCDPBOC);
		DDMDANHPLOH = new global::BANDHPLOOPI<ONCCFHECNKK>(NJPJBDDAEFH,
			new global::BANDHPLOOPI<ONCCFHECNKK>.PGGKMJIMMIC(HBHOHODCLMD),
			new global::BANDHPLOOPI<ONCCFHECNKK>.KMJHHHKMGDN(KIAODONJOMC),
			new Action<ONCCFHECNKK>(NKENJINLDDD), null);
	}

	public void IHEKMEOIBOI(SettingDefaults GBJCAFLHNPP)
	{
	}

	public void Dispose()
	{
	}

	private void NKENJINLDDD(ONCCFHECNKK GADDGJANIGG)
	{
	}

	public void LLNCEPFBOCM(ONCCFHECNKK LPOPCKFPPLM)
	{
	}

	public void KBKIBCKOHDP(ONCCFHECNKK LPOPCKFPPLM, object IALNODEHBNN, int LAGADKBKLAD)
	{
	}

	public void BJLMOHHDDMP(object IALNODEHBNN)
	{
	}

	public float NOMFNLFHDFM(PINLDPIKLLE ACMMHKGMFIC)
	{
		return 0f;
	}

	public IgnoreBufferSize HNKPIJAKCEK(ONCCFHECNKK ACMMHKGMFIC)
	{
		return default;
	}

	public void JDMCAONOELM(object JGOELJPNBLN)
	{
	}

	public void JOPBGGHEJMB(object JGOELJPNBLN)
	{
	}

	private bool PPODEDGIAPH(out string FDAIMOMOHIG)
	{
		FDAIMOMOHIG = null;
		return false;
	}

	private bool FBDLAGEKADJ(out string FDAIMOMOHIG)
	{
		FDAIMOMOHIG = null;
		return false;
	}

	private VRLocomotionComfortMode.SerializedSettings MDGPNCOHKCB()
	{
		return default;
	}

	public string HGKFPJFHIHN()
	{
		return null;
	}

	public void GMFODDHKMID()
	{
	}

	private IEnumerator<EGGPGCCKPCO> ILMLLOLNNGB()
	{
		return null;
	}

	public void NHJBCBAIAAI()
	{
	}

	private bool HOPJHAOPNIM(string ACBOKBOIFAA, bool GFLAEOLMKMC)
	{
		return false;
	}

	private bool AFBNFLMIFKB(string FDAIMOMOHIG, bool GFLAEOLMKMC)
	{
		return false;
	}

	[CompilerGenerated]
	private ONCCFHECNKK HBHOHODCLMD(BHNJIBDJFAL ECEFLJDFNBM)
	{
		return ONCCFHECNKK.Disabled;
	}

	[CompilerGenerated]
	private void KIAODONJOMC(BHNJIBDJFAL ECEFLJDFNBM, ONCCFHECNKK DLEMNBPMGBG)
	{
	}
}
