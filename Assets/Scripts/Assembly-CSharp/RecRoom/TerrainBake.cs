using System;
using UnityEngine;

namespace RecRoom
{
	public class TerrainBake : MonoBehaviour
	{
		[Serializable]
		public class MaterialPlatformSettings
		{
			public RuntimePlatform Platform;

			public Material Override;
		}

		public int meshResolution;

		public float lodSimplificationFactor;

		public float lowLodThreshold;

		public int divisions;

		public bool generateMeshColliders;

		public bool useDeleteHeight;

		public bool useTerrainFoliageRenderers;

		public Transform TreeRoot;

		public Transform TerrainRoot;

		public float deleteHeight;
	}
}
