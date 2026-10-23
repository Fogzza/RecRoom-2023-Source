using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Avatars.Data.Shared
{
	[Serializable]
	public class AvatarItemData : ISerializationCallbackReceiver
	{
		public string Name;

		[EFEFIKFHIDK]
		public string AvatarItemGuid;

		public OutfitType OutfitType;

		[SerializeField]
		[EFEFIKFHIDK]
		private bool LegacyHidesHair;

		public PJIBAFHHMLI HelmetHair;

		[EFEFIKFHIDK]
		public string helmetHairOverrideguid;

		public bool HidesHand;

		public bool HidesLeftEar;

		public bool HidesRightEar;

		public bool UsesHairColor;

		public bool UsesTeamColor;

		public bool UsesCustomImposterRotationOffset;

		public Vector3 CustomImposterRotationOffset;

		public bool UsesCustomImposterScale;

		public float CustomImposterScale;

		public bool IsUGCItem;

		public bool IsBaseAvatarItem;

		[SerializeField]
		public List<AvatarHairPatternOverride> HairPatternOverrides;

		public Dictionary<string, Texture2D> HairPatternOverrideMap;

		[SerializeField]
		public List<AvatarHairPatternOverride> BeardPatternOverrides;

		public Dictionary<string, Texture2D> BeardPatternOverrideMap;

		public bool IsFullBodyItem;

		public string FullBodyProxyAvatarItemGuid;

		public bool HasLeftAndRightMeshes;

		public bool DoesLegacyHidesHair => false;

		public Guid CustomAvatarItemId { get; private set; }

		public bool IsTeamItem => false;

		public static string PJHNDALDHEJ()
		{
			return null;
		}

		protected bool OFPEIHMPLIL(AvatarItemData HNPEBINPOBO)
		{
			return false;
		}

		public override bool Equals(object ICHBECDKHOJ)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		[SpecialName]
		public static bool IGOCGGBJBII(AvatarItemData DNDNMGOKFEI, AvatarItemData OHMMPNACNJO)
		{
			return false;
		}

		[SpecialName]
		public static bool BHBKJCPJNJN(AvatarItemData DNDNMGOKFEI, AvatarItemData OHMMPNACNJO)
		{
			return false;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void KBPIOPKFLDJ(AvatarUgcOutfitData JOIHKFDAJAJ)
		{
		}

		public void KBPIOPKFLDJ(Guid JGNABAMMKMP)
		{
		}

		public AvatarItemData EKNKDADOBNE()
		{
			return null;
		}
	}
}
