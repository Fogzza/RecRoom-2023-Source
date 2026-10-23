using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Photon.Pun;
using RRUI.Data;
using RecRoom.Audio;
using RecRoom.Consumable;
using RecRoom.Utils.Image;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RecRoom
{
	public class ShareCamera : MonoBehaviourPun, LDHIPCJOMAD
	{
		[Serializable]
		private struct ToolMenuScaleConfigs
		{
			public Vector2 sizeRangeForTripodModeScaling;

			public float sizeWhenHeld;

			public float frustumSize;

			public float scaleSmoothTime;
		}

		public struct FJFBKHCABAC
		{
			public string AFBGIILLOMG;

			public bool GPGGCFBCJJI;

			public bool GCHNNEDNADK;

			public DABLDDPEMFJ EGLKNPFFLAM;

			public JKEOBGDJBMI DEMAGFFFPHC;

			public FAJCEKGPCFF IJLKCFCJGPB;

			public int BNPBEMGLBBL;

			public string JFPKBAKENPC;

			public bool DCOHOCOGHPF;
		}

		public enum MGENDJACDJK
		{
			DEFAULT = 0,
			REQUESTED_IMAGE = 1
		}

		public enum CNMMNMOIPHG
		{
			ACTIVE = 0,
			REVIEW = 1,
			ASYNC_RENDER = 2,
			CONFIRM_REQUESTED_IMAGE = 3,
			CONFIRM_PROFILE_IMAGE = 4,
			DISABLED = 5
		}

		[Flags]
		public enum EGBCDMMOCEH
		{
			None = 0,
			ACTIVE = 1,
			REVIEW = 2,
			ASYNC_RENDER = 4,
			CONFIRM_SINGLE_PICTURE = 8,
			CONFIRM_PROFILE_IMAGE = 0x10,
			DISABLED = 0x20,
			All = -1
		}

		public enum HGPINBOLACO
		{
			SHARE = 0,
			PRINT = 1,
			CHANGE_PROFILE = 2,
			NATIVE_SHARE = 3
		}

		public enum DABLDDPEMFJ
		{
			OFF = 0,
			THREE_SECONDS = 1,
			FIVE_SECONDS = 2,
			TEN_SECONDS = 3
		}

		public enum FAJCEKGPCFF
		{
			OFF = 0,
			GRID = 1,
			SQUARE = 2,
			CIRCLE = 3
		}

		public enum JKEOBGDJBMI
		{
			THIRTEEN = 0,
			TWENTY = 1,
			TWENTY_SIX = 2,
			FIFTY_TWO = 3
		}

		public enum JDCHIIKKEJC
		{
			FIFTEEN = 0,
			THIRTY = 1,
			SIXTY = 2,
			UNLIMITED = 3
		}

		private class PPEFOBIHEGJ : global::INEAOPIKBME<RenderTexture>
		{
			private readonly ShareCamera ANNCNMIDEEI;

			private readonly Tool IEGMBEPJMGC;

			public PPEFOBIHEGJ(ShareCamera ANNCNMIDEEI)
			{
			}

			private void MEMBPBALAKE(Tool IHPJCBCPLCM)
			{
			}

			private void OAJNLICMJIN(Tool PJCGCANLEBN, BKMDFCCNPGE CKEPLIBLBFJ, bool BFDBCMGIOBG, bool OENLCMEDCNI)
			{
			}

			private void JFABBDIHHBN()
			{
			}

			private void MBIOLEBFOOM(Tool PMEFICGEDFK, Vector3 JEJBBKIEANB, Quaternion NPGDACHLJKJ, Vector3 JJOPIKLAKMM, bool EOMPBNCBADP)
			{
			}

			private void NHKAEEIGGNO(Tool IHPJCBCPLCM)
			{
			}

			private void FADINDBDBGA(Tool OCAGBEKHKKH)
			{
			}

			[CompilerGenerated]
			private void NMDCJDGBMFH(string JDDIAEIMOBB)
			{
			}

			[CompilerGenerated]
			private void DGMHGEKJLNN()
			{
			}
		}

		private class HODACOHPHAG
		{
			public Camera GAPPCJHIBEK;

			public ShareCamera ANNCNMIDEEI;

			public RenderTexture KAACGMLIKHK;

			public Action<Camera> CDHICOIFLGB;

			public Action<Camera> OPLGOMBHKIN;

			public DBIPHDIEBCM BOJDPAGLBLI;

			private RenderTexture DBBAEAHBANN;

			public bool DIAKLPMPEAD;

			public bool JNGNMNOJDLP;

			private bool EIDJHDPOAGH;

			private List<DisabledAltRenderedObject.PEJNIGGGFOE> HDIDNKJMAKK;

			public void GPGIPAMLJOA(ScriptableRenderContext DELCOFCGDFF, Camera DNIJGDPNEFB)
			{
			}

			public void ODAIBEAOFKK(ScriptableRenderContext DELCOFCGDFF, Camera DNIJGDPNEFB)
			{
			}

			public void LHFLDILBGPN()
			{
			}

			public void PCLHIJDDMOB()
			{
			}
		}

		private sealed class BJPMJGHKOBM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ShareCamera _003C_003E4__this;

			public bool enabled;

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
			public BJPMJGHKOBM(int _003C_003E1__state)
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

		private sealed class IDPINHKCOEA
		{
			public ShareCamera _003C_003E4__this;

			public Vector3 position;

			public Quaternion rotation;

			public bool isBackCameraActive;

			public DABLDDPEMFJ timerOption;

			public bool takePicture;

			internal void _003CSpawnAndTakePictureAt_003Eb__0()
			{
			}
		}

		private sealed class HFDOFKPBLIB
		{
			public ShareCamera localPlayerShareCamera;

			internal void _003CLocalRequestTakeOutShareCamera_003Eb__1()
			{
			}
		}

		private sealed class OAECFDIJKBC
		{
			public ShareCamera localPlayerShareCam;

			public FAJCEKGPCFF cachedGuide;

			internal void _003CLocalRequestSingleImage_003Eb__0()
			{
			}
		}

		private sealed class BBIGIDPENBK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ShareCamera _003C_003E4__this;

			public Vector3 position;

			public Quaternion rotation;

			public DABLDDPEMFJ timerOption;

			public bool isbackCameraActive;

			public bool takePicture;

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
			public BBIGIDPENBK(int _003C_003E1__state)
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

		private sealed class OHLANPCGHOO
		{
			public LAHBDKNMNHN promise;

			public ShareCamera _003C_003E4__this;

			internal void _003CButton_TakePicture_003Eb__0()
			{
			}
		}

		private sealed class LLLDCDMAOKN
		{
			public DBIPHDIEBCM promise;

			public ShareCamera _003C_003E4__this;

			internal void _003CTakePicture_003Eb__0(string error)
			{
			}

			internal void _003CTakePicture_003Eb__1()
			{
			}

			internal void _003CTakePicture_003Eb__2()
			{
			}
		}

		private sealed class PDPPKMJECJD : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ShareCamera _003C_003E4__this;

			public bool useFlash;

			private LAHBDKNMNHN _003CrenderPromise_003E5__2;

			private CNMMNMOIPHG _003CnextState_003E5__3;

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
			public PDPPKMJECJD(int _003C_003E1__state)
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

		private sealed class MFLOGAGBCCN : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ShareCamera _003C_003E4__this;

			public bool useFlash;

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
			public MFLOGAGBCCN(int _003C_003E1__state)
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

		private sealed class FMMDADIEDFA
		{
			public bool showUploadedFeedback;

			public ShareCamera _003C_003E4__this;

			public bool isPrivate;

			internal void _003CUploadToRecNet_003Eb__0()
			{
			}
		}

		private sealed class CIAMHBOAECG
		{
			public bool showUploadedFeedback;

			public ShareCamera _003C_003E4__this;

			internal void _003CUploadToRecNetInternal_003Eb__0(string error)
			{
			}

			internal void _003CUploadToRecNetInternal_003Eb__1(string imageName)
			{
			}
		}

		private sealed class JGHKAGPOOKD
		{
			public ShareCamera _003C_003E4__this;

			public float requestTimeoutTime;

			internal bool _003CRunPrintPolaroid_003Eb__0()
			{
				return false;
			}
		}

		private sealed class KCGOIGLFAAE : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public ShareCamera _003C_003E4__this;

			public Texture2D imageTexture;

			private global::NCOKFFGPIJM<string> _003CuploadPromise_003E5__2;

			private Polaroid _003Cpolaroid_003E5__3;

			private float _003CprePrintStartTime_003E5__4;

			private Vector3 _003ColdLocalPosition_003E5__5;

			private Vector3 _003ClocalEndPosition_003E5__6;

			private float _003CprintStartTime_003E5__7;

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
			public KCGOIGLFAAE(int _003C_003E1__state)
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

		private sealed class FNOGJLPACLJ
		{
			public RenderTexture tempTexture;

			public ManagedTexture newSharableImage;

			internal void _003CCreatePolaroidJpeg_003Eb__0()
			{
			}
		}

		private sealed class DPMGFJKCNGG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public bool playFeedbackAudio;

			public ShareCamera _003C_003E4__this;

			public string text;

			public string followUpText;

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
			public DPMGFJKCNGG(int _003C_003E1__state)
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

		private static readonly LALFNFGHKHL.HIPPLPKINHO FOKHAKHOOPH;

		private const int OMEIGBEFNCM = 320;

		private const float KDDAEEDIHME = 1.7777778f;

		private readonly int BIIFOLFLKPD;

		private readonly int NBIEDHGAGEE;

		private readonly int AHCLPMHPKON;

		private readonly int IPPOGDGBLGM;

		private const float MKLCANONBHG = 0.1f;

		private const float JKLAFDJBDHP = 0.88f;

		private const float APKDNOHOJBL = 0.1f;

		private const float IJBCCEFBMOJ = 0.5f;

		private readonly Vector2 BKBLGLHIFDF;

		private static readonly int BPKKECIAGCN;

		private static readonly int ONACGKPPFMH;

		private const float BMKLFGFOAMM = 5f;

		private const float DMPPJBCKBIC = 100f;

		public static readonly List<ShareCamera> AllActiveShareCameras;

		public readonly global::HHOBPMOCKMJ<Texture> UpdateUITextureEvent;

		public readonly global::HHOBPMOCKMJ<string> UpdateFeedbackTextEvent;

		public readonly EEANDDJEMJC RefreshUIEvent;

		public readonly EEANDDJEMJC PostPictureTakenWithUIButtonEvent;

		public static readonly EEANDDJEMJC OnPictureTaken;

		public readonly EEANDDJEMJC EnterActiveStateEvent;

		public readonly EEANDDJEMJC EnterReviewStateEvent;

		public readonly EEANDDJEMJC SelfieToggleChangedEvent;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private Camera mainCamera;

		[SerializeField]
		private Camera selfieCamera;

		[SerializeField]
		private Transform polaroidStartTransform;

		[SerializeField]
		private Transform polaroidEndTransform;

		[SerializeField]
		private float polaroidPrintSpeed;

		[SerializeField]
		private float screenRefreshCutoffDistance;

		[SerializeField]
		private TextMeshPro playerName;

		[SerializeField]
		private TextMeshPro grabMeText;

		[SerializeField]
		private Material ldrBlitMaterial;

		[SerializeField]
		private Transform integratedMenuAnchor;

		[SerializeField]
		private ShareCameraToolMenuModel integratedMenuModel;

		[SerializeField]
		private Transform previewScreenSideMenuTarget;

		[SerializeField]
		private Transform lensSideMenuTarget;

		[SerializeField]
		private ToolMenuScaleConfigs toolMenuScaleConfigScreen;

		[SerializeField]
		private ToolMenuScaleConfigs toolMenuScaleConfigVRSmall;

		[SerializeField]
		private ToolMenuScaleConfigs toolMenuScaleConfigVRBig;

		[SerializeField]
		private bool useSteppedScaling;

		[SerializeField]
		private RecRoomAudioClip buttonPressAudio;

		[SerializeField]
		private RecRoomAudioClip countDownTickAudio;

		[SerializeField]
		private RecRoomAudioClip shutterAudio;

		[SerializeField]
		private RecRoomAudioClip successAudio;

		[SerializeField]
		private RecRoomAudioClip printAudio;

		[SerializeField]
		private GameObject gesturePreviewHudPrefab;

		[SerializeField]
		private RecRoomAudioClip gestureDetectedAudio;

		[SerializeField]
		private Material photoMaterial;

		[SerializeField]
		private Material opaqueBlitMaterial;

		[SerializeField]
		private Renderer fadePlane;

		[SerializeField]
		private SimpleVolume lensOverlapVolume;

		private static ShareCamera CNDPCJPHLEI;

		private MGENDJACDJK IHFGHIBCJFL;

		private bool IGBIGFKAIIB;

		private bool GMKNBHFKFBA;

		private bool JHOFMBIHIPO;

		private bool BJEFOBEMMPK;

		private int BJIAODLPGNI;

		private float CEPIMPGANAG;

		private static bool LNPOPDNNAKP;

		private static DABLDDPEMFJ MAEDNAPALBD;

		private float MHKKCKIKCIM;

		private static JKEOBGDJBMI BPCHMNKGGJF;

		private static FAJCEKGPCFF JMNCCMIMKDK;

		public static bool AutomaticallyDetermineFramerateByPlatform;

		private static JDCHIIKKEJC LBCFFJIDDKB;

		private static bool LOHFBDDFJFF;

		private static ShareCameraPreviewResolution LKEFICJBBAN;

		private static bool IEPBFDJBFLA;

		private JNKNMMDAHCF DHCLACKALOF;

		private CGOPOAFDIDN AAKFKPKFDJJ;

		private LHMPPJKHCJG KOCMHELAMME;

		private GameObject IOKDHOHLJBE;

		private RenderTexture MLNCAMJBCAA;

		private RenderTexture FDLFNEAKMEF;

		private RenderTexture NHDCPPPNPBK;

		private RenderTexture NHPDLGPKKPG;

		private RenderTexture MHDGKPJAACE;

		private readonly ManagedTexture CLDHIMMHEGO;

		private Material GNBCLLFDLLE;

		private static readonly int MINGIHIJAPB;

		private IDisposable CEMCGAOEELA;

		private global::NCOKFFGPIJM<string> BKPHGEMGFOH;

		private LKGILLBEJEK NLBGDKEANEJ;

		private LKGILLBEJEK HPHGLGPDCBF;

		private LKGILLBEJEK EJFGCGDNLOF;

		private LKGILLBEJEK HICGKBILBGA;

		private LKGILLBEJEK KJHCICEDPFJ;

		private global::NCOKFFGPIJM<string> MBJJNOGNLBB;

		private LAHBDKNMNHN LFKOECOGPDL;

		private PPEFOBIHEGJ INMIJPCGNMJ;

		private HODACOHPHAG HKMPEJCEGMD;

		private readonly List<ObscuredInt> LACAJHGIMHL;

		private readonly List<Mirror> OEMFBPGEJKI;

		private float MAKGDCCAMNO;

		private int MHOPHCIDDPH;

		[SerializeField]
		private DisabledAltRenderedObject disabledAltRenderedObject;

		private bool CKEBGEHKILA;

		private Polaroid FLLCIOOGIFE;

		private CameraFilterConsumableItem LHDGPBMNEKJ;

		private int LMHLPECFHBA;

		private ShareCameraPreviewResolution GDBMHFEJDBP;

		private ShareCameraPreviewResolution EPDCCKMBGOB;

		private bool JJDIFNOOOKO;

		private bool AEKCMELAJFD;

		private float? ELEOMDEDHFL;

		private FJFBKHCABAC BKCCCPCKMFN;

		private bool EPCODLAECMP;

		private bool IDEPHJJIHHB;

		private bool IMILJIEOIOH;

		private Vector3 BIEIEKOJHOA;

		private MDEJADHJOEJ BKEGAANMMHP;

		private global::MOBDJNEDDKC<bool> AECPGHCFLBG;

		private global::MOBDJNEDDKC<bool> CAGNJPIMMAA;

		private global::MOBDJNEDDKC<int> FOJFOGAAKLC;

		public const string STATUS_UPLOADING = "Uploading...";

		public const string STATUS_ERROR = "Error uploading";

		private const string KAEDJHJJIAD = "Saved to Photo Roll";

public Tool Tool
{
get 		{
			return null;
		}

}

public Transform PolaroidEndTransform
{
get 		{
			return null;
		}

}

public static ShareCamera Local
{
get 		{
			return null;
		}

private set {
		}
}

public static bool LocalPlayerCanUse
{
get 		{
			return false;
		}

}

public bool ShouldRunCollisionDetection
{
get 		{
			return false;
		}

}

private bool BCPFBEMFOGG
{
get 		{
			return false;
		}

}

private static bool LHFJFPBIGMH
{
get 		{
			return false;
		}

}

private MGENDJACDJK AKAJEKEALNE
{
get 		{
			return MGENDJACDJK.DEFAULT;
		}

set {
		}
}

public bool IsInActiveState
{
get 		{
			return false;
		}

}

public bool IsInAnyReviewingState
{
get 		{
			return false;
		}

}

public Camera CurrentCamera
{
get 		{
			return null;
		}

}

public ShareCameraToolMenuModel MenuModel
{
get 		{
			return null;
		}

}

private bool KGMJKKNLMHI
{
get 		{
			return false;
		}

}

private bool FNHKJHDJDGC
{
get 		{
			return false;
		}

}

private string EPKLPIOBNBH
{
get 		{
			return null;
		}

}

private bool NGGIEMKPOPM
{
get 		{
			return false;
		}

}

public bool HasSharedOnRecNet
{
get 		{
			return false;
		}

private set {
		}
}

public bool HasChangedProfilePic
{
get 		{
			return false;
		}

private set {
		}
}

public bool HasPrintedPolaroid
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsSettingProfileInProgress
{
get 		{
			return false;
		}

}

public CNMMNMOIPHG CurrentState
{
get 		{
			return CNMMNMOIPHG.ACTIVE;
		}

}

public bool GrabMeActive
{
get 		{
			return false;
		}

set {
		}
}

public int FrameLastPictureTaken
{
get 		{
			return 0;
		}

private set {
		}
}

public BKMDFCCNPGE PlayerBackpackToolType
{
get 		{
			return BKMDFCCNPGE.SHARE_CAM;
		}

}

public float CurrentAspectRatio
{
get 		{
			return 0f;
		}

set {
		}
}

private ToolMenuScaleConfigs LBCPEBLBAHA
{
get 		{
			return default;
		}

}

public bool IsSelfieCameraActive
{
get 		{
			return false;
		}

set {
		}
}

public DABLDDPEMFJ LocalPlayerTimerOption
{
get 		{
			return DABLDDPEMFJ.OFF;
		}

set {
		}
}

public bool IsTimerActive
{
get 		{
			return false;
		}

}

public float TimerTimeRemaining
{
get 		{
			return 0f;
		}

private set {
		}
}

public bool IsTimerCountingDown
{
get 		{
			return false;
		}

}

public float TimerTimeRemainingNormalized
{
get 		{
			return 0f;
		}

}

public float TimerDurationSeconds
{
get 		{
			return 0f;
		}

}

public JKEOBGDJBMI CurrentFocalLengthOption
{
get 		{
			return JKEOBGDJBMI.THIRTEEN;
		}

set {
		}
}

private float CPMGOGKBLBN
{
get 		{
			return 0f;
		}

}

public FAJCEKGPCFF CurrentGuideOption
{
get 		{
			return FAJCEKGPCFF.OFF;
		}

set {
		}
}

public JDCHIIKKEJC CurrentPreviewFramerateOption
{
get 		{
			return JDCHIIKKEJC.FIFTEEN;
		}

set {
		}
}

public bool AutomaticallyDetermineResolutionByPlatform
{
get 		{
			return false;
		}

set {
		}
}

public ShareCameraPreviewResolution CurrentPreviewResolutionOption
{
get 		{
			return ShareCameraPreviewResolution.Res_288P;
		}

set {
		}
}

public bool TripodEnabledPreference
{
get 		{
			return false;
		}

set {
		}
}

public bool IsTripodActiveAndInUse
{
get 		{
			return false;
		}

}

public Polaroid AttachedPolaroid
{
get 		{
			return null;
		}

}

public bool IsTripodActive
{
get 		{
			return false;
		}

private set {
		}
}

public bool IsFlashActive
{
get 		{
			return false;
		}

private set {
		}
}

public DABLDDPEMFJ CurrentTimerOption
{
get 		{
			return DABLDDPEMFJ.OFF;
		}

private set {
		}
}

public bool IntegratedMenuActive
{
get 		{
			return false;
		}

set {
		}
}

private bool KGBBCKCLIHB
{
get 		{
			return false;
		}

}

public bool IsPrintingPolaroid
{
get 		{
			return false;
		}

}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void PJNHPNBPODN()
		{
		}

		private static void JLDAFLJEHKM(Camera GAPPCJHIBEK)
		{
		}

		private void BFLFAGODGOC()
		{
		}

		private void JGHJFOIBJAE()
		{
		}

		private void JPJLFMIDNKE()
		{
		}

		private void FNKFAKFMGJN()
		{
		}

		private void HMPFOMMEPLH()
		{
		}

		private void BAGIMJMBGMI()
		{
		}

		private void PDLIBHKAPMK(bool GMJGLPNAENI)
		{
		}

		private void KGDCNAPIHIO(ushort BKADDDMLDPN, ushort EHLPLCEJPDD, ushort HEGCOPGLOHO, ushort HKDHPIPECPL)
		{
		}

		private void AAGKCNIGEAG(Tool PMEFICGEDFK)
		{
		}

		private void HPPGKOEBMNI(Tool PMEFICGEDFK)
		{
		}

		private void KPNMINBIINN(bool GMEKKCPLMOB)
		{
		}

		private void FPEKDBCJLCB(Tool PMEFICGEDFK)
		{
		}

		private IEnumerator<EGGPGCCKPCO> FDNGHNIBDDB(bool BFDBCMGIOBG)
		{
			return null;
		}

		private void JNFIMGIPILO()
		{
		}

		private void LOGCDMFMOCI(JDCIJIEOFOL EKOFNPFCLMO)
		{
		}

		private void JMNJJLBJLEK(Tool PMEFICGEDFK)
		{
		}

		private void KDELGLNBFAF(GHCCKFEJDOA PKJIEOPNCHK)
		{
		}

		public void EnterActiveState()
		{
		}

		private void DHKNKKFJNMC(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void LAMPMJCBMMI(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		private void MBOHKHALMAJ(ushort EHLPLCEJPDD, ushort HKDHPIPECPL)
		{
		}

		public void UpdateFilter(CameraFilterConsumableItem KIJHICGIKFM)
		{
		}

		public void UpdateShareCameraGesture(bool BPOAENJBPJF, bool KPHNGKHFKHH)
		{
		}

		private bool ADCBANIHIJJ(bool KPHNGKHFKHH, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
			return false;
		}

		public void SpawnAndTakePictureAt(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool LNDCMNDJJBK, DABLDDPEMFJ EGLKNPFFLAM, bool BCBFMFAAHLF)
		{
		}

		private void BLACDGPDGCE()
		{
		}

		public static bool LocalRequestTakeOutShareCamera(bool IFCIIMGAHCD, bool OBIBDGIGOJH, out ShareCamera ANNCNMIDEEI)
		{
			ANNCNMIDEEI = null;
			return false;
		}

		public static global::CMMFENAKLIN<RenderTexture> LocalRequestSingleImage(bool ELMMHOBKEOL, bool NCHJNPJOIDP, bool OBIBDGIGOJH, string FPEMGPAPHAO = null, bool PGNBOPAENHE = false)
		{
			return null;
		}

		private global::CMMFENAKLIN<RenderTexture> ONGIBMNMABJ(string FPEMGPAPHAO)
		{
			return null;
		}

		private static void OFOOLHEGEAH()
		{
		}

		private IEnumerator<EGGPGCCKPCO> DABEDPJJADN(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, bool LLHFCOBEOBK, DABLDDPEMFJ EGLKNPFFLAM, bool BCBFMFAAHLF)
		{
			return null;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnPreRender()
		{
		}

		private void Update()
		{
		}

		private void LFJDIBNMNCD()
		{
		}

		private void CCOHBAOPFLG()
		{
		}

		private ToolMenuScaleConfigs BABDLCJCCAK()
		{
			return default;
		}

		private float MDLAINLKCPL(float MKHIAOAJBOB, ToolMenuScaleConfigs FPJKGKBOAOA)
		{
			return 0f;
		}

		private void CPCMPJCBPNM()
		{
		}

		private bool AFEEKCMOMCM()
		{
			return false;
		}

		private void ADBECFHELFB(Transform GFCPAMJILIO)
		{
		}

		private bool OMHNCJFBHKL()
		{
			return false;
		}

		private bool DNJNGPDBMMG()
		{
			return false;
		}

		private void DELAHCNPKEM()
		{
		}

		public bool ShouldMirrorScreenTextureForToolMenu()
		{
			return false;
		}

		private int IOFKHLGKNFB()
		{
			return 0;
		}

		private LALFNFGHKHL.Resolution NGBDKNBGPHE(ShareCameraPreviewResolution KEDKDAKBIEJ)
		{
			return default;
		}

		private void PBIJCGBENCN(ShareCameraPreviewResolution LHIKNIKPOEE)
		{
		}

		public void Button_TakePicture()
		{
		}

		public void Toggle_SelfieMode(bool FAOCKDHDABE)
		{
		}

		public void Button_MainMenuTripod()
		{
		}

		public void Button_RecallCamera()
		{
		}

		public global::NCOKFFGPIJM<string> Button_Share(bool LPHLJGDKOND)
		{
			return null;
		}

		public void Button_ActiveState()
		{
		}

		public void Button_Print()
		{
		}

		public void SpawnPolaroidStandalone(Texture2D AEFCAFBMKNL)
		{
		}

		public void Button_Profile()
		{
		}

		public void Button_Cancel()
		{
		}

		private void DHEJILLCGGL()
		{
		}

		public void Button_Confirm()
		{
		}

		private void CGKHOFPDJFP()
		{
		}

		private void GGBFGHPOMCD()
		{
		}

		public LAHBDKNMNHN TakePicture()
		{
			return null;
		}

		private LAHBDKNMNHN JJOBFJECOMK(Camera GAPPCJHIBEK)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> LMOMBIPPMOJ(bool BGFLMFMFLGK)
		{
			return null;
		}

		private LAHBDKNMNHN NLPKLIGNIID(Camera DNIJGDPNEFB, RenderTexture MCIPPFBHOPI, Action<Camera> CDHICOIFLGB, Action<Camera> OPLGOMBHKIN, bool KGALAKOEKCH)
		{
			return null;
		}

		private LKGILLBEJEK MIIAAOENMMF(bool BGFLMFMFLGK)
		{
			return null;
		}

		private void HDMCCFHFGFD()
		{
		}

		private void LMNEJKOOECB()
		{
		}

		private void ANMLKDNJNNA(bool BGFLMFMFLGK)
		{
		}

		private IEnumerator<EGGPGCCKPCO> GPDPLDPNOHN(bool BGFLMFMFLGK)
		{
			return null;
		}

		private void OHBPLFJPHOP(Camera GAPPCJHIBEK)
		{
		}

		private void CLLNILGEGEL(Camera GAPPCJHIBEK)
		{
		}

		public void AddTakePictureMirror(Mirror LBINIIAEHLF)
		{
		}

		private void CPGEGCINNMG(UniversalAdditionalCameraData ICPLLOMMEAO)
		{
		}

		private void LPJEGOOFFFG(UniversalAdditionalCameraData ICPLLOMMEAO)
		{
		}

		private void JHINBGHBHPI()
		{
		}

		public static string GetUploadSuccessString(bool LPHLJGDKOND)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> GGIJEOOEPAO(bool LPHLJGDKOND, bool MIMGIOCKKOK = true)
		{
			return null;
		}

		private global::NCOKFFGPIJM<string> DGCKBKJGMFN(bool LPHLJGDKOND, bool MIMGIOCKKOK = true)
		{
			return null;
		}

		private void ICPMGILJDNM()
		{
		}

		public void NativeSharePhoto()
		{
		}

		private void CAFKOMIKBKF(Texture2D AEFCAFBMKNL = null)
		{
		}

		private void LODPCMOKMGO()
		{
		}

		private IEnumerator<EGGPGCCKPCO> EAGEMKHELMF(Texture2D AEFCAFBMKNL = null)
		{
			return null;
		}

		private bool FOFGNLJFLCM(Tool HICJJFCCEBB)
		{
			return false;
		}

		private global::NCOKFFGPIJM<byte[]> IHFCGKAMHJO(ManagedTexture BHCAFMNOLCK, Texture2D IKFMBJNODBO, int JBGBAKMACBA)
		{
			return null;
		}

		private void EMIMDABOFGJ(Tool HICJJFCCEBB)
		{
		}

		public static void ShowCannotUseFeedback()
		{
		}

		private bool PKEPICADDKO()
		{
			return false;
		}

		private bool PJCFBMINANN(Tool PMEFICGEDFK, Player FOCKAEINGKG, Vector3 AHKAICJEMCD, bool JFACAONMDFA)
		{
			return false;
		}

		public bool PreventPreviewAndCapture()
		{
			return false;
		}

		private bool NIFCLHCNIHK()
		{
			return false;
		}

		private void DGEFLNNJLFD(Texture CIONKGJFLOB = null)
		{
		}

		private void BKKNHGMGLNE()
		{
		}

		private void NLGCAHNKAFN(RecRoomAudioClip HFMBEKEICOC)
		{
		}

		private void GCNMFIHKBOO(string HLIGBKANEEA = null, string LMENANPGKBF = null, bool GFFCLHKHGJI = true)
		{
		}

		private IEnumerator<EGGPGCCKPCO> CKDOAEDNDPG(string HLIGBKANEEA, string LMENANPGKBF, bool GFFCLHKHGJI)
		{
			return null;
		}

		private bool GHNCHEJLMJC()
		{
			return false;
		}

		private void EHAENDNPKDI()
		{
		}

		private void HLHGMEHMMHE()
		{
		}

		[PBOMGCLBFHF]
		private void RpcMasterSpawnPolaroid(GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		private void RpcSpawnPolaroidResponse(Polaroid KKIGJEIMGDN)
		{
		}

		[PBOMGCLBFHF]
		private void RpcPlayRemoteTakePictureFeedback(bool BGFLMFMFLGK)
		{
		}

		[CompilerGenerated]
		private bool HELMGBPPKMJ()
		{
			return false;
		}

		[CompilerGenerated]
		private void AACEDKKJBAD()
		{
		}

		[CompilerGenerated]
		internal static float GKEJPKJFPCE(Transform GFCPAMJILIO)
		{
			return 0f;
		}

		[CompilerGenerated]
		private bool EKFHJAKJDOI(PlayerHand PMNLJGLDMJN)
		{
			return false;
		}

		[CompilerGenerated]
		private void MALFOLOHKNP()
		{
		}

		[CompilerGenerated]
		private void KBPCBDMJHGN()
		{
		}

		[CompilerGenerated]
		private void ONMHNEKBODA()
		{
		}

		[CompilerGenerated]
		private void BIGLJLJCJMC()
		{
		}

		[CompilerGenerated]
		private void DDBCDAIKEJB()
		{
		}

		[CompilerGenerated]
		private void OPFCJDJHIFN(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private void DJEDNJNOIML()
		{
		}

		[CompilerGenerated]
		private void ILGPOCHLICC()
		{
		}
	}
}
