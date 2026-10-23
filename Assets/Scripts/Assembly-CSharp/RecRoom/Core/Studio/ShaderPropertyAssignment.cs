using System;
using UnityEngine;

namespace RecRoom.Core.Studio
{
	[Serializable]
	public class ShaderPropertyAssignment
	{
		[SerializeField]
		private string sourcePropertyName;

		[SerializeField]
		private string targetPropertyName;

		[SerializeField]
		private ShaderPropertyType propertyType;

		private int? sourcePropertyID;

		private int? targetPropertyID;

		private int? targetPropertyTextureScaleOffsetID;

		public string SourcePropertyName => null;

		public string TargetPropertyName => null;

		public ShaderPropertyType PropertyType => ShaderPropertyType.Float;

		public int SourcePropertyID => 0;

		public int TargetPropertyID => 0;

		public int TargetPropertyTextureScaleOffsetID => 0;

		public ShaderPropertyAssignment(ShaderPropertyType LIHPCDGPHCE, string JBMBMPNJFEE, string EHNBMJFIONK)
		{
		}

		public void BPBOPEIFIMP(Material AKIAMHHIMJL, MaterialPropertyBlock IJGNJGIJCGN)
		{
		}

		public void BBJDAGEOKGF(MaterialMap.MaterialEntry NEMLIPDJAJM)
		{
		}
	}
}
