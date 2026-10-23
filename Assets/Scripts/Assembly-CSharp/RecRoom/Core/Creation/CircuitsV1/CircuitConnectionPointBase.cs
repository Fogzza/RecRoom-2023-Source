using RecRoom.Tools.MakerPenTools;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public abstract class CircuitConnectionPointBase : ConnectionPoint
	{
		private DHJLEHBOGBG BMDDJIDADKN;

public virtual EDBMANFHGGO? MyInputSlot
{
get 		{
			return null;
		}

}

public virtual BHEOAPLBNIE? MyOutputSlot
{
get 		{
			return null;
		}

}

public override MakerPenPinInfo.CHNJGMNEPOO DefaultPinOperationType
{
get 		{
			return MakerPenPinInfo.CHNJGMNEPOO.Wire;
		}

}

public override DHJLEHBOGBG CreationContextObject
{
get 		{
			return null;
		}

}

		public abstract bool GetInputConnection(out CircuitConnectionPointBase PKHHCMANEDG);

		public abstract bool IsInputConnected();

		public abstract string GetDescription();

		public void SetCreationContextObject(DHJLEHBOGBG IPMIIEAGJKC)
		{
		}

		public override void ConfigureHoverPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL)
		{
		}

		public override void ConfigureStartPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL, bool FMFJDHJAJKN, EBNPGOBCABE IFEOGBCJEBI)
		{
		}

		public override void ConfigureEndPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL, ConnectionPoint FLFPHDAAGNM)
		{
		}
	}
}
