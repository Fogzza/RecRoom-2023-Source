using System;
using System.Collections.Generic;
using RecRoom.Utils.OverridableFields;
using UnityEngine;

namespace RecRoom.Systems.PlayerRoles
{
	public class RolesConfig : ScriptableObject
	{
		[Serializable]
		public class PermissionConfig
		{
			public string UniqueName;

			public string FriendlyName;

			public string FieldName;

			public string PropertyName;

			public string PermissionTypeOld;

			public OverridableString CustomEnumMutableType;

			public string PermissionType;

			public string InnerType;

			public OverridableInt IntroducedAt;

			public bool IsDefaultable;
		}

		public List<PermissionConfig> PermissionConfigs;

		public string RoleTypeName;

		public int RoleVersion;

		public string ClassName => null;
	}
}
