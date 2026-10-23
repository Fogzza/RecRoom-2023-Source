using System;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	public class MakerPenHandleManagerConfig : ScriptableObject
	{
		[Serializable]
		public class TransformToolParameters
		{
			[Serializable]
			public class HandlePriorityParameters
			{
				public int AxisScale;

				public int CenterScale;

				public int AxisTranslation;

				public int PlaneTranslation;

				public int SideTranslation;

				public int AxisRotation;

				public int ViewRotation;
			}

			[Serializable]
			public class AxisScaleHandleParameters
			{
				public float MinOffsetScale;

				public float MaxOffsetScale;

				public float ColliderRadius;
			}

			[Serializable]
			public class AxisTranslationHandleParameters
			{
				public TranslationArrowCenterHandle Prefab;

				public float Offset;

				public float Thickness;

				public float ColliderRadius;
			}

			[Serializable]
			public class PlaneTranslationHandleParameters
			{
				public float Offset;

				public float ColliderRadius;
			}

			[Serializable]
			public class SideTranslationHandleParameters
			{
				public float OffsetScale;

				public float ColliderRadius;
			}

			[Serializable]
			public class AxisRotationHandleParameters
			{
				public float MinOffsetScale;

				public float MaxOffsetScale;

				public float HoverScale;

				public RotationCircleAxisHandle Prefab;

				public Color ExteriorColor;

				public Color InteriorColor;

				public int MajorAxisSegments;

				public int MinorAxisSegments;

				public float MajorRadius;

				public float MinorRadius;

				public float ColliderRadius;
			}

			[Serializable]
			public class ViewRotationHandleParameters
			{
				public float HoverScale;

				public RotationCircleAxisHandle Prefab;

				public Color ExteriorColor;

				public Color InteriorColor;

				public int MajorAxisSegments;

				public int MinorAxisSegments;

				public float MajorRadius;

				public float MinorRadius;

				public float ColliderRadius;
			}

			public float OtherHoverAlpha;

			public HandlePriorityParameters HandlePriority;

			public AxisScaleHandleParameters AxisScaleHandle;

			public AxisTranslationHandleParameters AxisTranslationHandle;

			public PlaneTranslationHandleParameters PlaneTranslationHandle;

			public SideTranslationHandleParameters SideTranslationHandle;

			public AxisRotationHandleParameters AxisRotationHandle;

			public ViewRotationHandleParameters ViewRotationHandle;
		}

		[Serializable]
		public class ProUXParameters
		{
			public float AxisTranslationColliderRadius;

			public float PlaneTranslationColliderRadis;

			public float SideTranslationColliderRadius;

			public float PlaneTranslationScaleAdjust;

			public float PlaneTranslationOffset;

			public float AxisScaleColliderRadius;

			public float AxisRotationColliderRadius;

			public float ViewRotationColliderRadius;

			public float StickyAngle;
		}

		public TranslationArrowCenterHandle TranslationArrowCenterHandlePrefab;

		public TranslationPlaneHandle TranslationPlaneHandlePrefab;

		public TranslationSideHandle TranslationSideHandlePrefab;

		public MakerPenAxisRenderer MakerPenTranslateAxisRendererPrefab;

		public MakerPenAxisRenderer MakerPenRotateAxisRendererPrefab;

		public MakerPenAxisRenderer MakerPenScaleAxisRendererPrefab;

		public MakerPenGridPlaneRenderer MakerPenGridPlaneRendererPrefab;

		public RotationCircleCenterHandle RotationCircleCenterHandle;

		public ScaleAxisHandleBase ScaleCenterHandlePrefab;

		public ScaleAxisHandleBase ScaleSideHandlePrefab;

		public CloneAxisHandle CloneSideHandlePrefab;

		public CloneAxisHandle CloneCenterHandlePrefab;

		public CloneAxisHandle MirrorSideHandlePrefab;

		public AnchorHandleManager AnchorHandleManagerPrefab;

		public Color XAxisColor;

		public Color YAxisColor;

		public Color ZAxisColor;

		public Color CenterAxisColor;

		public float DistScale;

		public float MinSize;

		public float RotDistScale;

		public float RotMinSize;

		public float ScaleDistScale;

		public float ScaleMinSize;

		public float AnchorDistScale;

		public float AnchorMinSize;

		public float AnchorMaxSizeScalar;

		public float MinSideOffset;

		public float Handle2DAngleThreshold;

		public TransformToolParameters TransformTool;

		public ProUXParameters ProUX;

		public Color AFIONHECEGK(MakerPenHandle.KAAACAIMIBI OJBODCOIDJO)
		{
			return default;
		}

		public float EICLPPPJMHB(float CPJDNCEHDNO)
		{
			return 0f;
		}

		public float LPMLLKGIIOK(float CPJDNCEHDNO)
		{
			return 0f;
		}

		public float FOICHKMILLM(float CPJDNCEHDNO)
		{
			return 0f;
		}

		public float GOBMJMIOABC(float CPJDNCEHDNO, float NDGBFJDLHBN)
		{
			return 0f;
		}
	}
}
