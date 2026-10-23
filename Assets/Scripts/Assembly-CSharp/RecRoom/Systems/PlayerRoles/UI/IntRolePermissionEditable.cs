using CodeStage.AntiCheat.ObscuredTypes;
using RecRoom.Utils.OverridableFields;

namespace RecRoom.Systems.PlayerRoles.UI
{
	public abstract class IntRolePermissionEditable<TRole, RoleIdType, RolePermissionType> : SliderRoleEditableBase<TRole, ObscuredInt, RoleIdType, RolePermissionType> where TRole : global::NALCDCIGNGH<RolePermissionType> where RoleIdType : struct where RolePermissionType : struct
	{
		private MutableOverridableObscuredInt DOHCFOHLDPH;

public override global::PKKINNENDEC<ObscuredInt> CachedField
{
get 		{
			return null;
		}

}

		protected virtual int FCDPGJJIIEI(float BINCPCKFDFH)
		{
			return 0;
		}

		protected virtual float OKKODGGKKFF(int IPMIIEAGJKC)
		{
			return 0f;
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
