using CodeStage.AntiCheat.ObscuredTypes;
using RecRoom.Utils.OverridableFields;

namespace RecRoom.Systems.PlayerRoles.UI
{
	public abstract class BoolRolePermissionEditable<TRole, RoleIdType, RolePermissionType> : SliderRoleEditableBase<TRole, ObscuredBool, RoleIdType, RolePermissionType> where TRole : global::NALCDCIGNGH<RolePermissionType> where RoleIdType : struct where RolePermissionType : struct
	{
		private MutableOverridableObscuredBool DOHCFOHLDPH;

public override global::PKKINNENDEC<ObscuredBool> CachedField
{
get 		{
			return null;
		}

}

		private bool IKALNGENLGE(float BINCPCKFDFH)
		{
			return false;
		}

		private int MNHOODMNEMP(bool NGOLBPHCNGG)
		{
			return 0;
		}

		public void Slider_OnValueChanged(float sliderVal)
		{
		}

		public override void Button_ToggleOverride(bool newOverrides)
		{
		}

		protected override void AOMMEMMMDKL()
		{
		}
	}
}
