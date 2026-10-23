using System.Collections.Generic;
using AGUI.StackedUI;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public abstract class ModedCircuitNodeDisplay<T> : CircuitNodeDisplay where T : BNOPDNILAFA
	{
		[SerializeField]
		protected CircuitNodeModeEditableEnumUIControl uiControl;

		[SerializeField]
		protected Sprite[] circuitLabelSprites;

public override Sprite CircuitNodeSprite
{
get 		{
			return null;
		}

}

protected abstract Dictionary<string, MIBJNNKFLND> KHPAPKPOBDM
{
get ;
}

protected abstract object MCAHJCFKOHI
{
get ;
}

protected virtual bool DLCCOKDENBD
{
get 		{
			return false;
		}

}

		protected abstract int DDHDEHMADHG();

		public override void PopulateDynamicEditables()
		{
		}

		private void JGPFOOHACEI(int KEJGPMMMJIK)
		{
		}
	}
}
