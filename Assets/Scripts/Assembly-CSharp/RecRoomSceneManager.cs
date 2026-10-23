using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Photon.Pun;
using RecRoom;
using RecRoom.Core.Pools;
using RecRoom.Core.Scene;
using RecRoom.Systems.PlayerRoles;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class RecRoomSceneManager : MonoBehaviourPun, OJIHDJHLFFI, ObjectPoolPreFill.CJKCIFNBNDH
{
	public enum KDJPEPDOBDE
	{
		NotLoaded = 0,
		SceneDataLoaded = 1,
		PersistentDataLoaded = 2
	}

	public delegate void DOLALOAEHFN();

	public delegate void JDKJNFGEPMH(int OOMCLENBFPI, GameObject[] HANOMGACFNO);

	[Serializable]
	public enum SceneCategory
	{
		None = 0,
		Paintball = 1,
		DiscGolf = 2
	}

	private sealed class FCMAEDGFGBK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecRoomSceneManager _003C_003E4__this;

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
		public FCMAEDGFGBK(int _003C_003E1__state)
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

	private sealed class JANKCHKNBGA
	{
		public RecRoomSceneManager _003C_003E4__this;

		public Scene roomScene;

		public Action _003C_003E9__1;

		internal void _003CLoadLevelRoomAsyncCoroutine_003Eb__0(Scene loadedScene)
		{
		}

		internal void _003CLoadLevelRoomAsyncCoroutine_003Eb__1()
		{
		}
	}

	private sealed class GFIPMDJICCH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RecRoomSceneManager _003C_003E4__this;

		public string roomSceneName;

		private JANKCHKNBGA _003C_003E8__1;

		public JDKJNFGEPMH callback;

		public int roomIndex;

		private MDKHKMMJIAB _003CpauseToken_003E5__2;

		private global::NCOKFFGPIJM<Scene> _003CloadScenePromise_003E5__3;

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
		public GFIPMDJICCH(int _003C_003E1__state)
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

	private const float LMBPEPHGAHH = 0.5f;

	[SerializeField]
	private string friendlyName;

	[SerializeField]
	private PlayerHand.NDABKGBECKM playerHandConcaveMeshCollisionMode;

	[SerializeField]
	private SceneAFKSettings afkSettings;

	[SerializeField]
	private SceneAudioSettings audioSettings;

	[SerializeField]
	private SceneInteractionSettings interactionSettings;

	[SerializeField]
	private ScenePhysicsSettings physicsSettings;

	[SerializeField]
	private SceneGeometrySettings geometrySettings;

	[SerializeField]
	private SceneMoodSettings sceneMoodSettings;

	[SerializeField]
	private SceneRenderingSettings sceneRenderingSettings;

	[SerializeField]
	private SceneSpawnManager spawnManager;

	[SerializeField]
	private ScenePresenceSettings presenceSettings;

	[SerializeField]
	private SceneCircuitsV2Settings circuitsV2Settings;

	[SerializeField]
	private OverridableGameRole sceneEveryoneGameRole;

	[SerializeField]
	private SceneCategory category;

	private KDJPEPDOBDE OLLLMNOMPGP;

	private const string ILFALNMMCDA = "subroom";

	private List<NMIKADGOIOE> LKPIDKEJPJC;

	private bool HEPPBPDCONK;

	private readonly object CCNDHHHAOJO;

	private readonly object KLFLEHGDEND;

	protected bool KCKFJEDOMDH;

	private static bool MGIOHFLDDCI;

	private static RecRoomSceneManager EGAIHCNFOEN;

	private readonly List<MDKHKMMJIAB> GGNNIEBALJC;

	private BHNJIBDJFAL FFPLKJLJJGB;

	private bool JLIGIBEIIOK;

	public static DOLALOAEHFN LevelRoomLoadedEvent;

	private static bool BNOBMKCNDKK;

	private static readonly string[] KDJABLEENBK;

	private static int KHIONHIAKPK;

	private static int CABIAJJOJPG;

	private static bool LNELEAMIPDC;

	private static int BLDDMLBEMML;

	private static IHMINMJPODI GGNPMAAMFGI;

	private static IHMINMJPODI DLEABBNBGKK;

public SceneAFKSettings AFKSettings
{
get 	{
		return null;
	}

}

public SceneAudioSettings AudioSettings
{
get 	{
		return null;
	}

}

public SceneInteractionSettings InteractionSettings
{
get 	{
		return null;
	}

}

public ScenePhysicsSettings PhysicsSettings
{
get 	{
		return null;
	}

}

public SceneGeometrySettings GeometrySettings
{
get 	{
		return null;
	}

}

public SceneMoodSettings SceneMoodSettings
{
get 	{
		return null;
	}

}

public SceneRenderingSettings SceneRenderingSettings
{
get 	{
		return null;
	}

}

public SceneSpawnManager SpawnManager
{
get 	{
		return null;
	}

}

public ScenePresenceSettings PresenceSettings
{
get 	{
		return null;
	}

}

public SceneCircuitsV2Settings CircuitsV2Settings
{
get 	{
		return null;
	}

}

public KDJPEPDOBDE SceneLoadState
{
get 	{
		return KDJPEPDOBDE.NotLoaded;
	}

private set {
	}
}

public bool SceneDataLoaded
{
get 	{
		return false;
	}

}

public static SceneCategory Category
{
get 	{
		return SceneCategory.None;
	}

}

public static string CurrentSceneFriendlyName
{
get 	{
		return null;
	}

}

public static string CurrentSceneName
{
get 	{
		return null;
	}

}

public static bool IsCurrentSceneAValidActivity
{
get 	{
		return false;
	}

}

private bool JLAEDOILNIL
{
get 	{
		return false;
	}

}

public static bool HasRunningGame
{
get 	{
		return false;
	}

}

public static RecRoomSceneManager Instance
{
get 	{
		return null;
	}

private set {
	}
}

public static bool IsInitialized
{
get 	{
		return false;
	}

}

public virtual bool SpawnPlayersInRoom
{
get 	{
		return false;
	}

}

protected virtual bool JDFKNCCLABG
{
get 	{
		return false;
	}

}

protected BHNJIBDJFAL PGHHCPJJBHA
{
get 	{
		return null;
	}

private set {
	}
}

 GameObject global::RecRoom.Core.Pools.ObjectPoolPreFill.CJKCIFNBNDH.OHIEJHNCFBD
{
get 	{
		return null;
	}

}

public GKDCHLMLHBJ PersistableRunFor
{
get 	{
		return GKDCHLMLHBJ.RunForAuthorityOnly;
	}

}

	public static void DeferInitialization()
	{
	}

	public static void FinishInitialization()
	{
	}

	protected override void Awake()
	{
	}

	protected virtual IEnumerator Start()
	{
		return null;
	}

	private void AJJLLGONKCJ()
	{
	}

	private void OnApplicationQuit()
	{
	}

	protected override void OnDestroy()
	{
	}

	protected virtual void Update()
	{
	}

	public int GetLevelRoomCount()
	{
		return 0;
	}

	public void LoadLevelRoomAsync(int OOMCLENBFPI, JDKJNFGEPMH ONAFALABHKI = null)
	{
	}

	public void UnloadLevelRoomAsync(int OOMCLENBFPI)
	{
	}

	private void GDOHKNLLHFJ()
	{
	}

	private IEnumerator KEJBGHHGCBG(string KEKEFNPGBFN, int OOMCLENBFPI, JDKJNFGEPMH ONAFALABHKI)
	{
		return null;
	}

	private void OKNFFGFGFHE()
	{
	}

	private void IHGLNDIFFNA()
	{
	}

	[PBOMGCLBFHF]
	public void RpcSpawnNewPlayer(byte AMGNCPLIAAC, Vector3 FCNGMPHKHAE, Quaternion EIKMPMAOMIA, PhotonView IGDDAMGFGCC)
	{
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestPlayerRespawn(bool CDEPAJILBJA, GGGMJMEFFOC BOCBPOADLNM)
	{
	}

	[PBOMGCLBFHF]
	public void RpcRespawnPlayer(Vector3 FCNGMPHKHAE, Quaternion EIKMPMAOMIA, PhotonView IGDDAMGFGCC, bool CDEPAJILBJA)
	{
	}

	public virtual void OnMasterClientSwitched(CHILKDJABBF GKNDJIKLPKK)
	{
	}

	private void EJKPMJDGCAE(GHCCKFEJDOA PKJIEOPNCHK)
	{
	}

	private Task CDDPDMKAEJF(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF)
	{
		return null;
	}

	Task OJIHDJHLFFI.DeserializeFrom(KHMOHFAFGBI KGMPBFBAMCF, CancellationToken NDKAKDJMDIF)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CDDPDMKAEJF
		return this.CDDPDMKAEJF(KGMPBFBAMCF, NDKAKDJMDIF);
	}

	private void PEMFPEGCDBN(ref KHMOHFAFGBI KGMPBFBAMCF)
	{
	}

	void OJIHDJHLFFI.SerializeTo(ref KHMOHFAFGBI KGMPBFBAMCF)
	{
		//ILSpy generated this explicit interface implementation from .override directive in PEMFPEGCDBN
		this.PEMFPEGCDBN(ref KGMPBFBAMCF);
	}

	private static void KBGDICCJHMJ(string PBHHDGBNFIN)
	{
	}

	public static void TrackLoadedScene(string IGMLFBLMOKC)
	{
	}

	public static string GetLastLoadedScenes()
	{
		return null;
	}

	private static void MAHAGEKGPMJ(CHILKDJABBF MMHMLFJPMDC)
	{
	}

	private static string JPGBPGCPDDC()
	{
		return null;
	}

	public static void TrackMessageQueueRunning()
	{
	}

	private static string LBNOMHPMABN()
	{
		return null;
	}

	public static void TrackLoadingPhaseFinished(IHMINMJPODI FGIOPLINBFL)
	{
	}

	public static void TrackLoadingPhaseStarted(IHMINMJPODI OCEFDMBALMA)
	{
	}

	private static string PCHACJJKLFK()
	{
		return null;
	}

	public static string GetDuplicatePhotonViewDebuggingDataMessage()
	{
		return null;
	}

	[PBOMGCLBFHF]
	public void RpcMasterRequestPlayerSpawn(byte AMGNCPLIAAC, GGGMJMEFFOC BOCBPOADLNM)
	{
	}

	[CompilerGenerated]
	private void LPEDICEGHDM()
	{
	}

	[CompilerGenerated]
	private void CAGCEALCAIG()
	{
	}

	[CompilerGenerated]
	private void PECFGLNLDNH(AsyncOperation PMBBGAEPKNL)
	{
	}

	[CompilerGenerated]
	private void PJNNNOFNACM()
	{
	}
}
