using UnityEngine;

namespace RecRoom.Core.Studio
{
	public class ShaderPropertyTranslatorMultiPropertyCondition : ShaderPropertyTranslatorCondition
	{
		public enum HPIKECFFIFB
		{
			None = 0,
			MustBeEmissive = 1,
			MustBeNonEmissive = 2
		}

		[SerializeField]
		public HPIKECFFIFB emissionRequirement;

		[SerializeField]
		public ShaderPropertyTranslatorPropertyCondition[] conditions;

		public override bool FCAHLKBLCAA(MaterialMap.MaterialEntry NEMLIPDJAJM)
		{
			return false;
		}
	}
}
