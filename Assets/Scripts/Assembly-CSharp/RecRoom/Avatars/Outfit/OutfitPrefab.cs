using UnityEngine;

namespace RecRoom.Avatars.Outfit
{
	public class OutfitPrefab : MonoBehaviour
	{
		public SkinnedMeshRenderer SourceMeshRenderer;

		private LODGroup LGDLNDNHKMD;

		[SerializeField]
		public FitMeshHemisphere FitMeshHemisphereObject;

		[SerializeField]
		private Transform hairFitMeshHemispherePivot;

		[SerializeField]
		public Vector2 DefaultUVOverride;

		[SerializeField]
		public bool AllowFitMeshOverride;

		[SerializeField]
		public AnchorParamsRestrictions anchorParamRestrictions;

		[SerializeField]
		public Transform FitMeshPivot;

		[SerializeField]
		public bool UseHatUVOverride;

		[SerializeField]
		public Vector2 HatUVOverride;

public LODGroup LODGroup
{
get 		{
			return null;
		}

}

public bool IsHair
{
get 		{
			return false;
		}

}

public bool HatSupportsCustomization
{
get 		{
			return false;
		}

}
	}
}
