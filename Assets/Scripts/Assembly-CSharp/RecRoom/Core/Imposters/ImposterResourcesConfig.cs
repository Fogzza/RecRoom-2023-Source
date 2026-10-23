using RecRoom.Avatars.Outfit;
using UnityEngine;

namespace RecRoom.Core.Imposters
{
	public class ImposterResourcesConfig : ScriptableObject
	{
		[SerializeField]
		private OutfitRenderSetup outfitImposterPrefab;

		[SerializeField]
		private ImposterRenderConfig defaultRenderConfig;

		[SerializeField]
		private HairDyeRenderSetup hairDyeImposterPrefab;

		[SerializeField]
		private GiftBoxMerchVisual giftBoxMerchVisualPrefab;

		public OutfitRenderSetup OutfitImposterPrefab => null;

		public ImposterRenderConfig DefaultRenderConfig => null;

		public HairDyeRenderSetup HairDyeImposterPrefab => null;

		public GiftBoxMerchVisual GiftBoxMerchVisualPrefab => null;
	}
}
