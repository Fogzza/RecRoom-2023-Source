using System.Collections.Generic;
using UnityEngine;

namespace RecRoom.Core.Creation.CircuitsV1
{
	public abstract class CircuitConnectionPoint : CircuitConnectionPointBase
	{
		public delegate void JAPBFODMFOI(CircuitConnectionPoint JGKEGMKHIFA);

		public CircuitNodeDisplay NodeDisplay;

		public BNOPDNILAFA Node;

		public List<CircuitGroupInterfaceNode> GroupInterfaceConnections;

		private JAPBFODMFOI HNIJOCMMEOE__BackingField;

		private bool EOEJALBFHKM;

		private float DGNGAADEJCE;

		private MaterialPropertyBlock HOOJEGOGAPE;

public override EDBMANFHGGO? MyInputSlot
{
get 		{
			return null;
		}

}

public override BHEOAPLBNIE? MyOutputSlot
{
get 		{
			return null;
		}

}

public override Tool Tool
{
get 		{
			return null;
		}

}

public override Color ConnectionColor
{
get 		{
			return default;
		}

}

public override bool IsCircuitPoint
{
get 		{
			return false;
		}

}

public bool IsDefaultPinDynamicScalingEnabled
{
get 		{
			return false;
		}

set {
		}
}

public float DefaultPinAdditionalScale
{
get 		{
			return 0f;
		}

set {
		}
}

public event JAPBFODMFOI OnDisconnectRequested {
add {
		}
remove {
		}
}

		public void UpdateColor()
		{
		}

		public void UpdateRendererColor(Renderer LPCBHIEOFOB, bool KFBPHINLKBF = true)
		{
		}

		public override void ConnectionStart(ConnectionCreationContext DELCOFCGDFF, ININJKAJDDN LOHCFFGPEAA = null)
		{
		}

		public override void ConnectionEnd(ConnectionCreationContext DELCOFCGDFF, ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, EBNPGOBCABE IFEOGBCJEBI, ININJKAJDDN LOHCFFGPEAA = null)
		{
		}

		private static bool OPBNDCDKBEI(BNOPDNILAFA KLNEGNGHFMK, BHEOAPLBNIE IHOMJCBGMCM, BNOPDNILAFA JEOKJGDJKAM, EDBMANFHGGO OBONMNBJMLD)
		{
			return false;
		}

		public override bool IsInputConnected()
		{
			return false;
		}

		public override bool GetInputConnection(out CircuitConnectionPointBase PKHHCMANEDG)
		{
			PKHHCMANEDG = null;
			return false;
		}

		public override string GetDescription()
		{
			return null;
		}
	}
}
