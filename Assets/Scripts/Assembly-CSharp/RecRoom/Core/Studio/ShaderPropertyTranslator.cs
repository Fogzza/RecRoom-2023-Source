using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Studio
{
	[Serializable]
	public class ShaderPropertyTranslator
	{
		[SerializeField]
		private string sourceShaderName;

		[SerializeField]
		private Shader targetShader;

		[SerializeField]
		private ShaderPropertyTranslatorCondition condition;

		[SerializeField]
		private ShaderPropertyConverter converter;

		[SerializeField]
		private ShaderPropertyAssignment[] properties;

		private MaterialPropertyBlock sharedPropertyBlock;

		public string SourceShaderName => null;

		public Shader TargetShader => null;

		public IReadOnlyList<ShaderPropertyAssignment> Properties => null;

		public bool FCAHLKBLCAA(Material GLLFHCCFIGK)
		{
			return false;
		}

		public void KFIHMLODGME(MaterialMap.MaterialEntry NEMLIPDJAJM)
		{
		}

		private void IBOPAINHMNH(Material PMPDPBDKGPF, string PLCCFFIMOEP, string IDBLFHOOMPH)
		{
		}
	}
}
