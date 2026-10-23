using System;
using System.Collections.Generic;
using Delaunay;
using RecRoom.MathUtils.Springs;
using UnityEngine;

namespace RecRoom.Core.Screens.PlayerController
{
	[CreateAssetMenu]
	public class PlayerAnimation3DBlendedPoseSet : ScriptableObject
	{
		public IILJLGFHLGK PoseType;

		[SerializeField]
		private List<AnimationVertex> animationVertices;

		[SerializeField]
		private bool useOverrideSpring;

		[SerializeField]
		private SimpleSpring6DConfig overrideSpringParameters;

		[SerializeField]
		[HideInInspector]
		private List<Tetrahedron> tetrahedra;

		[SerializeField]
		[HideInInspector]
		private List<int> exteriorTriangleIndices;

		[NonSerialized]
		private readonly IMEEDLPMBNB pointLocator;

		public List<AnimationVertex> AnimationData => null;

		public bool UseOverrideSpring => false;

		public SimpleSpring6DConfig OverrideSpringParameters => null;

		public void BDFBELJKICH()
		{
		}

		public PlayerAnimationAsset[] CBPBJJIMMHK()
		{
			return null;
		}

		public void JIOHDBLOPEH(Vector3 OJBODCOIDJO, ref float[] OHAPKELHOFE)
		{
		}

		private Vector4 GLICEDABJEL(Vector4 JMIGJNODJGE)
		{
			return default;
		}
	}
}
