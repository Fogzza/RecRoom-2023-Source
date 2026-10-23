namespace RecRoom.Systems.PlayerRoles.UI
{
	public abstract class RoleEditableBase<TRole, InnerType, RoleIdType, RolePermissionType> : RolePermissionEditableBase<TRole, RoleIdType, RolePermissionType> where TRole : global::NALCDCIGNGH<RolePermissionType> where RoleIdType : struct where RolePermissionType : struct
	{

public abstract global::PKKINNENDEC<InnerType> CachedField
{
get ;
}

		protected abstract (bool, InnerType) IEGLLGOLBJC(RolePermissionType GPEJMANPPHE, TRole KLBONOOHBND);

		protected abstract bool PBPALEMCEGE(RoleIdType GEHNEOOGNLP, RolePermissionType HEGLKMIJHAM, bool FMMJFLMIBAO, InnerType NKBIKBGEKGL);

		protected override void KHAIHIGFJHC(RolePermissionType DPNEPBHJELO)
		{
		}

		protected void AKAKFGPDABO(bool FMMJFLMIBAO, InnerType IPMIIEAGJKC)
		{
		}

		protected void MMHBDNILLNE(bool FMMJFLMIBAO, InnerType IPMIIEAGJKC)
		{
		}
	}
}
