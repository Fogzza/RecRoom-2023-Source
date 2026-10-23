using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using CodeStage.AntiCheat.ObscuredTypes;
using RecRoom.Core.Creation.Tags;
using RecRoom.Utils.OverridableFields;
using TMPro;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles.UI
{
	public abstract class TagListRolePermissionEditable<TRole, RoleIdType, RolePermissionType> : RoleEditableBase<TRole, List<ObscuredString>, RoleIdType, RolePermissionType> where TRole : global::NALCDCIGNGH<RolePermissionType> where RoleIdType : struct where RolePermissionType : struct
	{
		[SerializeField]
		private TagEditDialog tagEditDialog;

		[SerializeField]
		private TextMeshProUGUI previewText;

		[SerializeField]
		private Button3D editTagsButton;

		[SerializeField]
		private int maxTags;

		private MutableOverridableListObscuredString DOHCFOHLDPH;

public override global::PKKINNENDEC<List<ObscuredString>> CachedField
{
get 		{
			return null;
		}

}

		public override void Button_ToggleOverride(bool newOverrides)
		{
		}

		public void Button_Edit()
		{
		}

		protected override void AOMMEMMMDKL()
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<TagEditDialog.OCNOGOPILIK> NHPHCEBEPFJ(TagEditDialog GDMKJGAKCND)
		{
			return null;
		}

		[CompilerGenerated]
		private void GNPLIDMMBJF(TagEditDialog.OCNOGOPILIK GOJCEBCMFJK)
		{
		}
	}
}
