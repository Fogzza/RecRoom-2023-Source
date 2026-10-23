using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AGUI.StackedUI;
using CodeStage.AntiCheat.ObscuredTypes;
using RecRoom.Utils.OverridableFields;
using TMPro;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles.UI
{
	public abstract class RoleListRolePermissionEditable<TRole, RoleIdType, RolePermissionType> : RoleEditableBase<TRole, List<ObscuredString>, RoleIdType, RolePermissionType> where TRole : global::NALCDCIGNGH<RolePermissionType> where RoleIdType : struct where RolePermissionType : struct
	{
		[SerializeField]
		private RoleEditDialog roleEditDialog;

		[SerializeField]
		private TextMeshProUGUI previewText;

		[SerializeField]
		private Button3D editRolesButton;

		[SerializeField]
		private int maxRoles;

		private MutableOverridableListObscuredString DOHCFOHLDPH;

protected abstract RoleEditDialog.PNEIPJGNIAF IMMBBBIGCNH
{
get ;
}

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
		private global::NCOKFFGPIJM<RoleEditDialog.CAADGGIOLPL> KEIIKKKNCKN(RoleEditDialog GDMKJGAKCND)
		{
			return null;
		}

		[CompilerGenerated]
		private void FOGBLOIBCII(RoleEditDialog.CAADGGIOLPL GOJCEBCMFJK)
		{
		}
	}
}
