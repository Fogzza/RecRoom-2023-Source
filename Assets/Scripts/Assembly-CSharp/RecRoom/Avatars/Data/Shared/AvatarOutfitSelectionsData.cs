using System;
using System.Collections.Generic;
using RecRoom.Avatars.Data.Runtime;
using UnityEngine;

namespace RecRoom.Avatars.Data.Shared
{
	[Serializable]
	public class AvatarOutfitSelectionsData
	{
		private sealed class GEOOFFLLMNJ
		{
			public AvatarOutfitSelectionData selection;

			internal bool _003Cget_AvatarItemSelections_003Eb__0(AvatarItemSelection item)
			{
				return false;
			}
		}

		[SerializeField]
		private AvatarOutfitSelectionData[] selections;

		private List<AvatarItemSelection> _avatarItemSelections;

		public List<AvatarItemSelection> AvatarItemSelections
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public AvatarOutfitSelectionsData(IEnumerable<AvatarItemSelection> KCHDKGFJMED)
		{
		}
	}
}
