using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Creation.Shapes
{
	public class ShapeContainerDataBitPacker
	{
		private const float TubeControlPointRadiusCompressionErrorTolerance = 0.005f;

		private const int TubeControlPointRadiusCompressionMinBits = 4;

		private const int TubeControlPointRadiusCompressionMaxBits = 20;

		public const int NumShapeRotationBitsPerAxis = 12;

		private const int UV_OFFSET_BITS = 10;

		private static void RegisterRpcSerializationHandlers()
		{
		}

		private static void UnregisterRpcSerializationHandlers()
		{
		}

		private static void CompressShapeContainerCollection(LGCEMMAIGML bitPacker, ECKHAMFMDAI collection)
		{
		}

		private static ECKHAMFMDAI DecompressShapeContainerCollection(LGCEMMAIGML bitPacker)
		{
			return null;
		}

		private static void CompressShapeContainer(LGCEMMAIGML bitPacker, ECKHAMFMDAI.BBJFMALDNKA.JEHOADOABLF entry)
		{
		}

		private static ECKHAMFMDAI.BBJFMALDNKA.JEHOADOABLF DecompressShapeContainer(LGCEMMAIGML bitPacker)
		{
			return null;
		}

		private static void CompressShapeCollection(LGCEMMAIGML bitPackerBase, NCLIPFDBPBO collection)
		{
		}

		private static NCLIPFDBPBO DecompressShapeCollection(LGCEMMAIGML bitPackerBase)
		{
			return null;
		}

		private static void CompressShape(LGCEMMAIGML bitPackerBase, EBLDPIPLLOP shape, Vector3 minPositionExtent, Vector3 maxPositionExtent)
		{
		}

		private static EBLDPIPLLOP DecompressShape(LGCEMMAIGML bitPackerBase, Vector3 minPositionExtent, Vector3 maxPositionExtent)
		{
			return null;
		}

		private static Bounds GetShapePositionBounds(IList<EBLDPIPLLOP> shapes)
		{
			return default;
		}

		private static Bounds GetControlPointPositionBoundsAndMaxRadius(IList<NGPLOKJBIOJ> controlPoints, out float maxRadius)
		{
			maxRadius = default;
			return default;
		}

		private static void CompressTubeControlPoint(LGCEMMAIGML bitPackerBase, NGPLOKJBIOJ controlPoint, int radiusRequiredBits, float maxRadius, Vector3 minPositionExtent, Vector3 maxPositionExtent)
		{
		}

		private static NGPLOKJBIOJ DecompressTubeControlPoint(LGCEMMAIGML bitPackerBase, int radiusRequiredBits, float maxRadius, Vector3 minPositionExtent, Vector3 maxPositionExtent)
		{
			return null;
		}
	}
}
