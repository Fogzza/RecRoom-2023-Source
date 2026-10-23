using AGUI.StackedUI;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles.UI
{
	public abstract class SliderRoleEditableBase<TRole, InnerType, RoleIdType, RolePermissionType> : RoleEditableBase<TRole, InnerType, RoleIdType, RolePermissionType> where TRole : global::NALCDCIGNGH<RolePermissionType> where RoleIdType : struct where RolePermissionType : struct
	{
		[SerializeField]
		protected Slider3D valueSlider;

		[SerializeField]
		protected GameObject textLabels;

		protected override void AOMMEMMMDKL()
		{
		}
	}
}
