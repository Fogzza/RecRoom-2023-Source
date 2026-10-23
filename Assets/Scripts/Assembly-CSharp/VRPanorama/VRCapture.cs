using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

namespace VRPanorama
{
	public class VRCapture : MonoBehaviour
	{
		public enum GPPLFOAAKMH
		{
			EquidistantStereo = 0,
			EquidistantStereoSBS = 1,
			EquidistantMono = 2,
			VideoCapture = 3
		}

		public enum BLNMMGDEANH
		{
			_360 = 0,
			_180 = 1
		}

		public enum PIMCNPLIJFH
		{
			JPG = 0,
			PNG = 1,
			EXR_HDRI = 2,
			Direct = 3
		}

		private sealed class CPLNIDPLKKH : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Texture2D SShot;

			public int jpg;

			public string filePathd;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public CPLNIDPLKKH(int _003C_003E1__state)
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

		private sealed class GNEBDHHBCJJ : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Texture2D SShot;

			public string filePathd;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public GNEBDHHBCJJ(int _003C_003E1__state)
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

		private sealed class HHJIFBHLDID : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Texture2D SShot;

			public string filePathd;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public HHJIFBHLDID(int _003C_003E1__state)
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

		private sealed class HFHFBPGHKLO : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Texture2D SShot;

			public string filePathd;

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
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public HFHFBPGHKLO(int _003C_003E1__state)
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

		public int cubemapSize;

		public bool oneFacePerFrame;

		public Camera cubeCam;

		public bool captureAudio;

		public float volume;

		public bool mute;

		private float EFADAEFGPCH;

		private int PLGMOBPIFEB;

		private int FIEHJFJAOGA;

		public bool alignPanoramaWithHorizont;

		private Material MGFADHAMFPK;

		private RenderTexture EJFDBOAEAAC;

		private GameObject BEOLPKEOAKM;

		private GameObject DHMMMIGPMIK;

		private GameObject EAMAACCIIIJ;

		private string HBPENBPHCKH;

		private RenderTexture CIFAMMPMDLD;

		private RenderTexture JNLELLOBLEP;

		private RenderTexture FIPDFCNCBHF;

		private RenderTexture DNPKBGOGAGF;

		private RenderTexture MBCMBHBKOCC;

		private RenderTexture BOKPDFJBKKO;

		private RenderTexture FNNNDHIKBGG;

		private RenderTexture IBGAIKBMILJ;

		private RenderTexture PEOGDCIBBAI;

		private RenderTexture IKHENJFIJDA;

		private RenderTexture KEGNPKDEGFJ;

		private RenderTexture MDLGONEFHHK;

		private RenderTexture MFIKIFLHOGN;

		private RenderTexture KJLALMMECAA;

		private RenderTexture INBMHLIDPON;

		private RenderTexture KOOPBMCPAFP;

		private Material NAILLMBNDKI;

		private Material IPCMIKBHJBL;

		private Material BDKJDDBKFGH;

		private Material CCMOMMKGCKC;

		private Material PPFHGOEGNGH;

		private Material DCCCLFICAMJ;

		private Material JCBJJBMCKAD;

		private Material GHKNPBLDEMK;

		private Material CEGCEPFHCPD;

		private Material OMHEHLBGIIO;

		private Material HNPECLAJOGM;

		private Material LPNLMDAGHNH;

		private Material FDCPMENFNDB;

		private Material BJJFOOCOOPF;

		private Material OADKEGIACCB;

		private Material JCGBHGBEFAO;

		private Material BIGOCEJCDHD;

		private RenderTexture JELBNCEFKFJ;

		private Texture2D MAPOIIPLNML;

		private Texture2D BBMFLOIOMGL;

		public Camera camLL;

		public Camera camRL;

		public Camera camTL;

		public Camera camBL;

		public Camera camFL;

		public Camera camDL;

		public Camera camLR;

		public Camera camRR;

		public Camera camTR;

		public Camera camBR;

		public Camera camFR;

		public Camera camDR;

		public Camera camDRX;

		public Camera camDLX;

		public Camera camTRX;

		public Camera camTLX;

		private GameObject GMIPNDKAIHG;

		private GameObject AIAINBDDLEB;

		private GameObject EKGOEKCEDNM;

		private GameObject HCIFHMHAIJD;

		private GameObject FNCPLPDFLCP;

		private GameObject EGNLFAHBHMM;

		private GameObject EGBLNNLCJKJ;

		private GameObject NJOAMILOIOK;

		private GameObject PDMEALNBLNJ;

		private GameObject PDFCLMEEHJI;

		private GameObject KAALAOIDCHJ;

		private GameObject IMJAEJLPEBE;

		private GameObject GBCIJDKOPCA;

		private GameObject JIOLGDKALBA;

		private GameObject EFBDNEKDJFL;

		private GameObject KGFCFDLGFPD;

		private GameObject PAFEPOOHOLN;

		private GameObject FNKAFNLBHMJ;

		private GameObject KDOCIGNEHAF;

		private GameObject DOIMJPOFFFB;

		private GameObject FBFFFMGMIJA;

		private GameObject DJJBCEHICBG;

		public GameObject renderPanorama;

		private VRPanoInterface JPNCIGBPLPN;

		public int StartFrame;

		public GPPLFOAAKMH panoramaType;

		public BLNMMGDEANH captureAngle;

		public bool RT2Video;

		public PIMCNPLIJFH ImageFormatType;

		public string Folder;

		public KeyCode captureKey;

		public int FPS;

		private Color[] ONPILJDKHBG;

		public int resolution;

		public int resolutionH;

		public int step;

		public int NumberOfFramesToRender;

		public int renderFromFrame;

		[AFNIFINHBEO]
		public string sequenceLength;

		public float IPDistance;

		public float EnvironmentDistance;

		public float restoreFOV;

		public bool openDestinationFolder;

		public bool ambisonicsSupportTest;

		public string fullPath;

		public bool customPath;

		public string customPathFolder;

		public int Mp4Bitrate;

		public int jpgQuality;

		public int renderQuality;

		public string formatString;

		private int CJGNOPCFMJE;

		public bool mailme;

		public string _mailto;

		public string _pass;

		public string _mailfrom;

		public string _prefix;

		private TextureFormat DIMPJCJAADP;

		private RenderTextureFormat PECHEPEDJLL;

		[AFNIFINHBEO]
		public string RenderInfo;

		public int bufferSize;

		public int numBuffers;

		private int ODHEDAPLJKH;

		private int FMJGKLNGNNK;

		public bool recOutput;

		public bool depth;

		public int depthBufferSize;

		public bool ambisonics;

		public bool disableTracking;

		private FileStream OPALKIPDOLC;

		public ushort achannels;

		public bool hQ;

		public int steps;

		public bool useAlpha;

		public float smoothing;

		public bool playPanorama;

		private GameObject CNIBAKFHNBA;

		private VideoPlayer MKFFALHAFHP;

		private Material LJOAFGKOLPK;

		public int videoLenght;

		private BHNJIBDJFAL NJPJBDDAEFH;

public VRPanoInterface PanoramaInterface
{
get 		{
			return null;
		}

}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public void RenderPano()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void RenderVideo()
		{
		}

		private Texture2D MGIFDJBALCC(Texture2D CLNGEOJHLLB)
		{
			return null;
		}

		public void SaveScreenshot()
		{
		}

		private static IEnumerator EKNJOBMMOOM(string AMMPCFBAHNB, Texture2D CFLJLCIDEOG, int JFINLMHKDGN)
		{
			return null;
		}

		private static IEnumerator JDMDGGFIGGL(string AMMPCFBAHNB, Texture2D CFLJLCIDEOG)
		{
			return null;
		}

		private static IEnumerator HCDGOIAFKDB(string AMMPCFBAHNB, Texture2D CFLJLCIDEOG)
		{
			return null;
		}

		private static IEnumerator PGOHPAPLPBC(string AMMPCFBAHNB, Texture2D CFLJLCIDEOG)
		{
			return null;
		}

		public Texture2D GetScreenshot(bool CDHADFCPLAF)
		{
			return null;
		}

		public Texture2D GetScreenshotHQ(bool CDHADFCPLAF)
		{
			return null;
		}

		public void SendEmail()
		{
		}

		public Texture2D GetVideoScreenshot()
		{
			return null;
		}

		public void VideoRenderPrepare()
		{
		}

		public void SaveScreenshotVideo()
		{
		}

		public void CounterPost()
		{
		}

		public void QuitEditor()
		{
		}

		public void ClearBar()
		{
		}

		private void BOPLBEPBEAM(string KNOPFGAGMCN)
		{
		}

		private void OnAudioFilterRead(float[] PCPEJHIMHJJ, int IPCNJDBKKDB)
		{
		}

		private void PMJEGMFHPOD(float[] GBNIFLNDNAE)
		{
		}

		private void HHGNAJPJMPE()
		{
		}

		private void OnGUI()
		{
		}

		public void PreparePano()
		{
		}
	}
}
