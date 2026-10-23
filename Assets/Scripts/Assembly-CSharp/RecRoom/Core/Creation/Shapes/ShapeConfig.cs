using System;
using RecRoom.Tools;
using RecRoom.Tools.MakerPenTools;
using UnityEngine;

namespace RecRoom.Core.Creation.Shapes
{
	[Serializable]
	public class ShapeConfig : ScriptableObject
	{
		public enum MPFAKGOFOPJ
		{
			UniformCenter = 0,
			PyramidCenter = 1,
			WedgeCenter = 2,
			NumTypes = 3
		}

		public enum JMPDEFAFKAI
		{
			All = 0,
			Half = 1,
			Cylinder = 2,
			Pyramid = 3,
			Sphere = 4,
			HalfSphere = 5
		}

		public enum LBABONODJMI
		{
			Sphere = 0,
			Box = 1,
			Mesh = 2
		}

		[Serializable]
		public struct ShapeConfigData
		{
			public string name;

			public bool displayInPalette;

			public bool displayAsAdvanced;

			public bool displayAsBeta;

			public GameObject prefab;

			public GameObject prefabUIPreview;

			public Mesh collider;

			public MPFAKGOFOPJ centerOfMass;

			public JMPDEFAFKAI volumeCalculation;

			public LBABONODJMI colliderCost;

			public Vector3 boundsSize;
		}

		[Serializable]
		public class ShapeColorToColorDictionary : SerializedDictionary<JLHLKDMLBPK, Color, ShapeColorToColorDictionary.KeyVal>
		{
			[Serializable]
			public class KeyVal : SerializedKeyVal<JLHLKDMLBPK, Color>
			{
			}
		}

		[Serializable]
		private struct ShapeSwatchData
		{
			public JLHLKDMLBPK ColorId;

			public MJGMBIJIKFH MaterialId;

			public float UVScale;

			public ShapeSwatchData(JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, float PALJJNGJNBE)
			{
				ColorId = JLHLKDMLBPK.RRO_MIN_VALUE;
				MaterialId = MJGMBIJIKFH.CARDBOARD;
				UVScale = 0f;
			}
		}

		public GameObject TubeShapePrefab;

		public ShapeConfigData[] ShapeDatas;

		public TranslationSnappingVisualization SnappingVisualizationPrefab;

		public ShapeManipulationHandle ShapeManipulationHandlePrefab;

		public MakerPenDragSelectVisuals DragSelectVisuals;

		public MakerPenPinInfo MakerPenPinInfoPrefab;

		public MakerPenPinInfo CV2MakerPenPinInfoPrefab;

		public CommentMakerPenPinInfo CommentMakerPenPinInfoPrefab;

		public MakerPenHandleManager MakerPenHandleManagerPrefab;

		public MakerPenSelectionDecal MakerPenSelectionDecal;

		public GameObject ShapeContainerOriginVisualizerPrefab;

		public CurveControlPoint CurveControlPointPrefab;

		public float[] SnapGridSizes;

		public float[] AngleSnapIncrements;

		public float[] CurveThicknessModifiers;

		public float[] TubeHeightScale;

		public int[] TubeRingPoints;

		public float SmallBevelSizeMeters;

		public float RoundedBevelSizeMeters;

		public float BoxAuthoredBevelPercent;

		public float WedgeAuthoredBevelPercent;

		public float PyramidAuthoredBevelPercent;

		public bool BevelSizeBasedOnLargestPossibleDimension;

		public int ShapeContainerCostEnvironment;

		public int ShapeContainerCostDecoration;

		public int ShapeContainerCostPhysical;

		public int SphereColliderCost;

		public int BoxColliderCost;

		public int MeshColliderCost;

		public float PhysicalPhysicsModeMultiplier;

		public float EnvironmentPhysicsModeMultiplier;

		public float DecorationPhysicsModeMultiplier;

		public float OptimizedCollidersMultiplier;

		public Material UIPreviewMaterial;

		public Material ConvexHullVisualizationMaterial;

		public Shader BatchedMakerPenShader;

		public JLHLKDMLBPK[] CharadesColors;

		public ShapeColorInfo[] ShapeColorInfos;

		public ShapeMaterialInfo[] ShapeMaterialInfos;

		[HideInInspector]
		public ShapeColorToColorDictionary RROShapeColorAdditive;

		public ColorRemap SpecularRemap;

		public ColorRemap EmissiveRemap;

		[HideInInspector]
		[SerializeField]
		private ShapeSwatchData[] shapeSwatchInfos;

		public ShapeSwatchInfo[] ShapeSwatchInfos => null;
	}
}
