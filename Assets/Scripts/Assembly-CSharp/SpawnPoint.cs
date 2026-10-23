using System;
using Photon.Pun;
using RecRoom.Core;
using UnityEngine;

public abstract class SpawnPoint : MonoBehaviourPun
{
	[SerializeField]
	private bool testsForOverlap;

	[SerializeField]
	protected Transform[] backupSpawnPositions;

	[SerializeField]
	private PhotonView parent;

	[SerializeField]
	private SeatManagement attachedSeat;

	private const float FDPFIDABAMC = 3f;

	protected const float AABDPAABMPF = 2f;

	public const float OVERLAP_TEST_RADIUS = 0.5f;

	private const float CPNBKCEPOLC = 0.6f;

	private const float FDHFBLOKJPN = 1.4f;

	private const float CGPKJPLGAMK = 0.5f;

	private const float HACMKMBJOHC = 0.45f;

	[NonSerialized]
	private bool HBOAKNIEBHM;

	private global::MOBDJNEDDKC<int> AOFAGGMGEPF;

	private global::MOBDJNEDDKC<float> EBKOBAKIDEJ;

public virtual bool SpawnPointEnabled
{
get 	{
		return false;
	}

set {
	}
}

public Vector3 WorldPosition
{
get 	{
		return default;
	}

}

public Quaternion WorldRotation
{
get 	{
		return default;
	}

}

public Vector3 LocalPosition
{
get 	{
		return default;
	}

}

public Quaternion LocalRotation
{
get 	{
		return default;
	}

}

public PhotonView Parent
{
get 	{
		return null;
	}

}

public bool TestsForOverlap
{
get 	{
		return false;
	}

}

public SeatManagement AttachedSeat
{
get 	{
		return null;
	}

}

public int UseCount
{
get 	{
		return 0;
	}

private set {
	}
}

public bool IsOnCooldown
{
get 	{
		return false;
	}

}

private float FBLLOPGBCDK
{
get 	{
		return 0f;
	}

set {
	}
}

private float HGBPDJOBCCO
{
get 	{
		return 0f;
	}

}

public virtual bool IsBlockedByOverlaps
{
get 	{
		return false;
	}

}

protected abstract Color BAFJOOPEPHO
{
get ;
}

	private Vector3 GALIDLPMDIJ(Vector3 ADJINPMOILO)
	{
		return default;
	}

	private Quaternion DIBFIDPIMBO(Quaternion LLJPMBHCKEE)
	{
		return default;
	}

	protected override void Awake()
	{
	}

	public void MasterUse()
	{
	}

	public Transform GetFirstAvailableSpawnTransformLocalToParentView(out Vector3 EGJKEDKNNAD, out Quaternion IBHAEICNMJI, out PhotonView IGDDAMGFGCC)
	{
		EGJKEDKNNAD = default;
		IBHAEICNMJI = default;
		IGDDAMGFGCC = null;
		return null;
	}

	public virtual Transform GetFirstAvailableSpawnTransform(out Vector3 ADJINPMOILO, out Quaternion LLJPMBHCKEE)
	{
		ADJINPMOILO = default;
		LLJPMBHCKEE = default;
		return null;
	}

	public virtual bool IsBlockedAtPosition(Vector3 INLGLHIPOMC)
	{
		return false;
	}

	public static bool PlayerOverlapAtPosition(Vector3 INLGLHIPOMC)
	{
		return false;
	}

	public static bool ToolOrEnvironmentOverlapAtPosition(Vector3 INLGLHIPOMC)
	{
		return false;
	}

	public static bool IsInValidPosition(Vector3 INLGLHIPOMC)
	{
		return false;
	}

	public void Enable()
	{
	}

	public void Disable()
	{
	}

	protected virtual void OnDrawGizmos()
	{
	}

	protected virtual void OnDrawGizmosSelected()
	{
	}
}
