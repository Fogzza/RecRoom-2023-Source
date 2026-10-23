using UnityEngine;

namespace RecRoom.Core.Creation.Preview
{
	internal abstract class ShapePreview : MonoBehaviour
	{
		private float HCFPGKMFLDE;

		private Vector3 PNOGIHGHBJL;

		private JLHLKDMLBPK HOCIPNPKLAM;

		private MJGMBIJIKFH NPDIBEHNHJN;

		private KEMJGOAMALL DGDNJPKFMBA;

public NCANNFMMHDJ Transform
{
get 		{
			return default;
		}

}

public bool IsPreview
{
get 		{
			return false;
		}

}

public bool UseLegacyRenderer
{
get 		{
			return false;
		}

}

public float UVScale
{
get 		{
			return 0f;
		}

private set {
		}
}

public Vector3 UVOffset
{
get 		{
			return default;
		}

private set {
		}
}

public JLHLKDMLBPK ShapeColor
{
get 		{
			return JLHLKDMLBPK.RRO_MIN_VALUE;
		}

private set {
		}
}

public MJGMBIJIKFH ShapeMaterial
{
get 		{
			return MJGMBIJIKFH.CARDBOARD;
		}

private set {
		}
}

		public static ShapePreview Create(EBLDPIPLLOP PCPEJHIMHJJ, Transform KPDGHDGLMHO)
		{
			return null;
		}

		protected virtual void OnDestroy()
		{
		}

		public virtual void Deserialize(EBLDPIPLLOP PCPEJHIMHJJ, Transform KPDGHDGLMHO)
		{
		}

		public abstract void GenerateVisuals(ShapeContainerPreview KPDGHDGLMHO);

		public abstract Bounds CalculateWorldBounds();
	}
}
