using System.Collections.Generic;
using RecRoom.Core.Screens.PlayerController;
using UnityEngine;

namespace Delaunay
{
	public class Delaunay3DTestComponent : MonoBehaviour
	{
		public int pointCount;

		public MeshFilter meshFilter;

		public bool discardInteriorTriangles;

		[SerializeField]
		private PlayerAnimation3DBlendedPoseSet assignPoseSetToDebug;

		[SerializeField]
		private List<AnimationVertex> animationVertices;

		[SerializeField]
		private List<Tetrahedron> tetrahedra;

		[SerializeField]
		private List<int> exteriorTriangleIndices;

		[SerializeField]
		private Gradient gizmoColorByBarycentricWeight;

		private void Reset()
		{
		}

		public void GenerateDelaunayGraph()
		{
		}

		private void OnValidate()
		{
		}

		public void RandomizeGraphVertices()
		{
		}

		public void TestDelaunayMesh()
		{
		}

		public void SetVertices(List<AnimationVertex> LLMMDKBHFGP)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
