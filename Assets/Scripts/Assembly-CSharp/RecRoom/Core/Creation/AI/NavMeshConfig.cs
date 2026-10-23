using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Creation.AI
{
	[Serializable]
	public class NavMeshConfig : ScriptableObject
	{
		public Tool navMeshBakeVolumePrefab;

		public Vector3 minNavMeshBakeVolumeDimensions;

		public Vector3 maxNavMeshBakeVolumeDimensions;

		public AstarPath astarPathPrefab;

		public Material defaultVisualMaterial;

		public Material highEndVisualMaterial;

		[HideInInspector]
		public LayerMask colliderRasterizationLayerMask;

		[HideInInspector]
		public List<string> colliderRasterizationTagMask;
	}
}
