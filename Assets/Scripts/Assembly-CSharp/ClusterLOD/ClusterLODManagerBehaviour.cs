using System;
using System.Threading;
using System.Threading.Tasks;
using RecRoom.ClusterLODs;
using UnityEngine;

namespace ClusterLOD
{
	public class ClusterLODManagerBehaviour : SingletonMonoBehaviour<ClusterLODManagerBehaviour>, DFFMAPIHAEJ
	{
		private class RoomLoadListenerProvider : BJFFMFCOKNA
		{
			public Task WaitForShapes(global::FKCKMADGELN<string>.PPKAMDIDPFK worldStackTimer, CancellationToken cancellationToken)
			{
				return null;
			}
		}

		private class PlayerEyePositionProvider : MAMIPOIENDK
		{
			public Vector3 EyePosition => default;
		}

		private KMNLJIIJLMH clusterLODManager;

		private RoomLoadListenerProvider roomLoadListener;

		private MAMIPOIENDK playerEyePositionProvider;

		[SerializeField]
		private ClusterMeshRenderer clusterMeshRendererPrefab;

		[SerializeField]
		private MeshFilter clusterPrefab;

		private IDisposable deserializationHandlerToken;

		public ClusterLODConfig Config { get; private set; }

		public KMNLJIIJLMH ClusterLODManager => null;

		protected override void Awake()
		{
		}

		private ILODPOPFPAH CreateDeserializationHandler()
		{
			return null;
		}

		public Task StartCreateWorld(global::FKCKMADGELN<string>.PPKAMDIDPFK stackTimer, CancellationToken cancellationToken)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}
	}
}
