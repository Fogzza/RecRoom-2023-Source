using System;

public interface JCHALAAEDKN<RoleIdType, RolePermissionType, RoleType> : global::NALCDCIGNGH<RolePermissionType> where RoleType : global::JCHALAAEDKN<RoleIdType, RolePermissionType, RoleType>
{

 RoleIdType RoleId
{
get ;
}

 Guid RoleGuid
{
get ;
set ;
}

 string LowerRoleName
{
get ;
}

 bool IsRoleActive
{
get ;
set ;
}

 bool IsModifiedByPlayer
{
get ;
}

 bool CanMoveRole
{
get ;
}

	void IEAIPAAIHLM();

	void OECNDDFGMPC();

	byte[] EEMIIKLNPEK(RolePermissionType HEGLKMIJHAM, bool FMMJFLMIBAO, object NKBIKBGEKGL);

	void IODABDBJNCA(RolePermissionType HEGLKMIJHAM, byte[] IHBEKCJNCDP);

	RoleType JGMLMOAPKAE(RoleType LLCICIBAEOC);

	void PAKIMOKGMBI();

	void AFBHGNPCPMD(RoleType OEJILPJHPPG);

	void AGCLNMICBDA(string DPCMNOBDEDM);
}
