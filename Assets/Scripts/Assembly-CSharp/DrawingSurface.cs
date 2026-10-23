using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom.Utils.Image;
using UnityEngine;

public class DrawingSurface : MonoBehaviourPun, DJLCHGFCFAD, DKKOHMDPPEO
{
	public enum KMBMNLIAFCM
	{
		None = 0,
		Whiteboard = 1
	}

	private sealed class NEBJNHEMILI
	{
		public CHILKDJABBF specificPlayer;

		public DrawingSurface _003C_003E4__this;

		public int attempt;

		public bool uploadLocalState;

		internal void _003CSendDrawingSurfaceState_003Eb__0(string newImageName)
		{
		}

		internal void _003CSendDrawingSurfaceState_003Eb__1(string error)
		{
		}
	}

	private sealed class FNMKDPADCID : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public CHILKDJABBF specificPlayer;

		public DrawingSurface _003C_003E4__this;

		public bool useLocalState;

		public int attempt;

		private float _003CqueueTime_003E5__2;

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
		public FNMKDPADCID(int _003C_003E1__state)
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

	private sealed class GALDGONECNM
	{
		public DrawingSurface _003C_003E4__this;

		public string newImageName;

		internal void _003CRefreshImageFromCDN_003Eb__0(Texture2D texture)
		{
		}

		internal void _003CRefreshImageFromCDN_003Eb__1(string e)
		{
		}

		internal void _003CRefreshImageFromCDN_003Eb__2()
		{
		}
	}

	private sealed class PHOHICNBNDG : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public APFHIIGOAJG serializeType;

		public DrawingSurface _003C_003E4__this;

		private float _003Ctime_003E5__2;

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
		public PHOHICNBNDG(int _003C_003E1__state)
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

	[StructLayout((LayoutKind)3)]
	private struct EBGMKPHDBJN : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public APFHIIGOAJG serializeType;

		public DrawingSurface _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

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

	private sealed class PNJBPFPBENA
	{
		public DrawingSurface _003C_003E4__this;

		public RenderTexture output;

		internal void _003CShare_003Eb__2(string imageName)
		{
		}

		internal void _003CShare_003Eb__3()
		{
		}
	}

	private sealed class DHIOOOKNGMA : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EGGPGCCKPCO _003C_003E2__current;

		public DrawingSurface _003C_003E4__this;

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
		public DHIOOOKNGMA(int _003C_003E1__state)
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

	private const int GNLOACDNFCA = 5;

	private const float NAPOPIMEEBB = 15f;

	private GDHOAGNFOBD.KEIAPDLHGPG CCHMKKIAPPM;

	private static readonly List<DrawingSurface> OAKKGBDIIPB;

	[SerializeField]
	private KMBMNLIAFCM drawingSurfaceType;

	[SerializeField]
	private bool allowSharing;

	[SerializeField]
	private float sharingAspect;

	[SerializeField]
	private Material exportMaterial;

	[SerializeField]
	private bool editorSharingDebug;

	[SerializeField]
	private Transform drawingRectMin;

	[SerializeField]
	private Transform drawingRectMax;

	[SerializeField]
	private Texture2D clearTexture;

	[SerializeField]
	private Renderer surfaceRenderer;

	[SerializeField]
	private int resolution;

	private Texture2D NDAKAAIMBIG;

	private Material LKEGALEPHDH;

	private bool KFDJIKCEMGG;

	private bool GNNFEGCCIOM;

	private global::MOBDJNEDDKC<bool> EKGFCLHNEMF;

	private NGJPBEEINBG BJHFGBFCCEO;

	[SerializeField]
	private bool debugWaitForDownload;

	private RenderTexture KAACGMLIKHK;

	private KIFCHEAGKOK DLPCNCJKEEO;

	private float NFABGOEDMMB;

	private global::MOBDJNEDDKC<string> PHIOIEKKJPC;

	private global::MOBDJNEDDKC<Color> IJGNLCHHOCB;

	private CHILKDJABBF PNPLMLMLJAD;

	private bool GCELAEGAPIK;

	private bool HPHCAMBCHMF;

	public global::HHOBPMOCKMJ<ELPMJGMAIHC> OnUpdatedDrawTexture;

	private List<ELPMJGMAIHC> KPCEFHEKNAO;

	private List<ELPMJGMAIHC> KBADMFCDPEN;

	private ManagedTexture EPGPEKEMGFB;

	private Dictionary<ELPMJGMAIHC, DrawingObject> NGBFLAJHFFL;

	public List<DrawingObject> DrawingObjectPool;

	[SerializeField]
	private DrawingObject drawingObjectPrefab;

	[SerializeField]
	private float maxSerializeUploadWaitTime;

	private const int MKFIICGMOMD = 95;

private Rect BMMEBMGPKLE
{
get 	{
		return default;
	}

}

public bool SurfaceTextureIsDirty
{
get 	{
		return false;
	}

private set {
	}
}

public bool MasterSurfaceTextureModifiedFromDefault
{
get 	{
		return false;
	}

private set {
	}
}

public string LastUploadedImageName
{
get 	{
		return null;
	}

private set {
	}
}

public bool BlockObjectPersistance
{
get 	{
		return false;
	}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

public Color SurfaceColor
{
get 	{
		return default;
	}

set {
	}
}

public int PhotonId
{
get 	{
		return 0;
	}

}

public Vector3 Right
{
get 	{
		return default;
	}

}

public Vector3 Up
{
get 	{
		return default;
	}

}

public Vector3 Normal
{
get 	{
		return default;
	}

}

public Quaternion Rotation
{
get 	{
		return default;
	}

}

public Vector3 Center
{
get 	{
		return default;
	}

}

public float RendererScale
{
get 	{
		return 0f;
	}

}

public int Resolution
{
get 	{
		return 0;
	}

}

public Vector2 SizeWorldSpace
{
get 	{
		return default;
	}

}

public bool WaitingForUpload
{
get 	{
		return false;
	}

}

public bool WaitingForDownload
{
get 	{
		return false;
	}

private set {
	}
}

public bool MarkedDirtyDuringWait
{
get 	{
		return false;
	}

private set {
	}
}

private bool CNHPNAFLHCB
{
get 	{
		return false;
	}

}

	public bool IsDrawingEnabledForPlayer(CHILKDJABBF FBCDJHOIDJJ)
	{
		return false;
	}

	protected override void Awake()
	{
	}

	private void ILHKDLIAIOA()
	{
	}

	private void Start()
	{
	}

	private void GLKMAPHLIGF()
	{
	}

	private void OnDrawGizmos()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void Clear(Color? EIMOPEHNHKA = null)
	{
	}

	private void FGNJGDFKNAM()
	{
	}

	public void LoadDrawing(string NPOEAPJKNFN)
	{
	}

	private void EAHEDNIPACE()
	{
	}

	private void JPMNHLCAJHC(IReadOnlyList<ELPMJGMAIHC> KPCEFHEKNAO)
	{
	}

	public float DistanceToPlane(Vector3 MHCLBCIHING)
	{
		return 0f;
	}

	public Vector2 WorldToBoardSpace(Vector3 DLOLGDANPLJ, out bool ELKEFMAMBML, out float DCMJIFNHDBJ)
	{
		ELKEFMAMBML = default;
		DCMJIFNHDBJ = default;
		return default;
	}

	public Vector2 WorldToNormalizedBoardPos(Vector3 MHCLBCIHING)
	{
		return default;
	}

	public Vector3 OnDrawingPlane(Vector3 MHCLBCIHING)
	{
		return default;
	}

	public Vector2 NormalizedBoardSpace(Vector2 BOGIPKDGJNP)
	{
		return default;
	}

	public void OnSurfaceTriggerEnter(Collider HNPEBINPOBO)
	{
	}

	public void OnSurfaceTriggerExit(Collider HNPEBINPOBO)
	{
	}

	public void OnPhotonPlayerConnected(CHILKDJABBF DEODPCHAFKO)
	{
	}

	public void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
	{
	}

	public ManagedTexture ExportDrawingSurface()
	{
		return null;
	}

	private void DNHOJEANJGK(CHILKDJABBF DEODPCHAFKO)
	{
	}

	private void KILPLELMMFI()
	{
	}

	private void JDIMGLEIFHH(bool PPPCBJMFOMC, CHILKDJABBF IBOMIBGHGOH, int JKHANNEKGJL = 1)
	{
	}

	private IEnumerator<EGGPGCCKPCO> OIEFMNBHOKL(bool PKHJBNHPEEH, CHILKDJABBF IBOMIBGHGOH, int JKHANNEKGJL)
	{
		return null;
	}

	private global::NCOKFFGPIJM<string> LDLKEAPNPNL()
	{
		return null;
	}

	private void BGBICICFHBL()
	{
	}

	private void IMPIHLEKJCH()
	{
	}

	private void APIFGJBLMPH(Texture2D IKFMBJNODBO)
	{
	}

	[PBOMGCLBFHF]
	private void RpcRequestImage(GGGMJMEFFOC BDGGGHEOPBI)
	{
	}

	[PBOMGCLBFHF]
	private void RpcNotifyUploadPending(GGGMJMEFFOC BOCBPOADLNM)
	{
	}

	[PBOMGCLBFHF]
	private void RpcDownloadImage(string HMDOLELDGAG)
	{
	}

	[PBOMGCLBFHF]
	private void RpcRequestClear()
	{
	}

	[PBOMGCLBFHF]
	private void RpcClear()
	{
	}

	private void GDDLGDJJJPI(string HMDOLELDGAG)
	{
	}

	private void CICPNMKDKNH(Texture2D AHAEAMHEGFE)
	{
	}

	private void PHNLFGJLAEM(ELPMJGMAIHC BPHDCFLJNIJ, bool BCFJHEBBJFF)
	{
	}

	private bool HABCPCFNJMF(ELPMJGMAIHC BPHDCFLJNIJ)
	{
		return false;
	}

	public global::PJBFANJFIEG<ControlPointType> CreateStroke<ControlPointType>(ControlPointType IGMJIDHLCBG, Material PMPDPBDKGPF, bool BCFJHEBBJFF) where ControlPointType : class, global::DCHKNLBDGLD<ControlPointType>
	{
		return null;
	}

	public DrawingObject GetDrawingObject(ELPMJGMAIHC OEEHBAOMFMJ)
	{
		return null;
	}

	public void ReleaseDrawingObject(ELPMJGMAIHC OEEHBAOMFMJ)
	{
	}

	public void RenderHoverOutline()
	{
	}

	public IEnumerator<EGGPGCCKPCO> PreSerialize(StringBuilder AAMCGPPJPFM, APFHIIGOAJG LJBOPGAFHIA)
	{
		return null;
	}

	public Task PreSerializeAsync(StringBuilder AAMCGPPJPFM, APFHIIGOAJG LJBOPGAFHIA, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
	{
	}

	public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
	{
	}

	private void MIGHBFJHBPN()
	{
	}

	[CompilerGenerated]
	private bool FFPOGGGCOEK()
	{
		return false;
	}

	[CompilerGenerated]
	private void OBCPJIOICBC(string HMDOLELDGAG)
	{
	}

	[CompilerGenerated]
	private void HGIJKNKCGHF(string NLJOHEKGNDH)
	{
	}

	[CompilerGenerated]
	private IEnumerator<EGGPGCCKPCO> HLNDHHKFHMA()
	{
		return null;
	}

	[CompilerGenerated]
	private bool OPADNKKCIMF()
	{
		return false;
	}

	[CompilerGenerated]
	internal static void FCHCGEMJJCL(string OFCFPGACNJB, float FGBPJMKCMAO)
	{
	}
}
