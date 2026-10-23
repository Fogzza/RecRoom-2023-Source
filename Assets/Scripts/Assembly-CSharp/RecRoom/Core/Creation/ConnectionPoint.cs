using System;
using RecRoom.Core.DataStructures;
using RecRoom.Tools.MakerPenTools;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class ConnectionPoint : MonoBehaviour, OONLONAIOPG
	{
		public enum FJKPIKFMPCC
		{
			SLOT_0 = 0,
			SLOT_1 = 1,
			SLOT_2 = 2
		}

		public delegate void PAPBNHDHKLP(ConnectionPoint PCJINKBIFLC, ININJKAJDDN LOHCFFGPEAA = null);

		public delegate void BHIGMFMEAKM(ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, ININJKAJDDN LOHCFFGPEAA = null);

		public delegate void ININJKAJDDN(IONEOHGOAML CDNLFEOBNKB, CHILKDJABBF FOILEMDKKCC);

		private PAPBNHDHKLP CKHKPHDPJKA__BackingField;

		private BHIGMFMEAKM KGBNIGCMDIC__BackingField;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private CreationObject creationObject;

		[SerializeField]
		public MeshRenderer highlightOverrideRenderer;

		[SerializeField]
		private bool forceHoverHighlightTool;

		[SerializeField]
		private FJKPIKFMPCC connectionSlot;

		[SerializeField]
		protected ReferencePoint attachmentPoint;

		private IDisposable MJNEFOJDBBC;

		[SerializeField]
		private MakerPenPinInfo.CHNJGMNEPOO defaultPinOperationType;

public virtual bool ImmediateStartConnection
{
get 		{
			return false;
		}

}

public virtual bool CanSelfConnect
{
get 		{
			return false;
		}

}

public virtual bool SelfConnectIsConfigure
{
get 		{
			return false;
		}

}

public virtual bool IsCV2
{
get 		{
			return false;
		}

}

public virtual bool Blocked
{
get 		{
			return false;
		}

}

public virtual Tool Tool
{
get 		{
			return null;
		}

}

public virtual DHJLEHBOGBG CreationContextObject
{
get 		{
			return null;
		}

}

public FJKPIKFMPCC SlotIndex
{
get 		{
			return FJKPIKFMPCC.SLOT_0;
		}

}

public Vector3 AttachmentPointPosition
{
get 		{
			return default;
		}

set {
		}
}

public virtual MakerPenPinInfo.CHNJGMNEPOO DefaultPinOperationType
{
get 		{
			return MakerPenPinInfo.CHNJGMNEPOO.Wire;
		}

}

public virtual Vector3 WireDirection
{
get 		{
			return default;
		}

}

public virtual Color ConnectionColor
{
get 		{
			return default;
		}

}

public virtual bool IsCircuitPoint
{
get 		{
			return false;
		}

}

public event PAPBNHDHKLP OnConnectionStart {
add {
		}
remove {
		}
}

public event BHIGMFMEAKM OnConnectionEnd {
add {
		}
remove {
		}
}

		protected virtual void Awake()
		{
		}

		public virtual void RenderHoverHighlight()
		{
		}

		public virtual void ConnectionStart(ConnectionCreationContext DELCOFCGDFF, ININJKAJDDN LOHCFFGPEAA = null)
		{
		}

		public virtual void ConnectionEnd(ConnectionCreationContext DELCOFCGDFF, ConnectionPoint PCJINKBIFLC, ConnectionPoint HLBJDAGMEND, EBNPGOBCABE IFEOGBCJEBI, ININJKAJDDN LOHCFFGPEAA = null)
		{
		}

		public virtual bool OperationOnSelect()
		{
			return false;
		}

		public bool IsValidDestinationConnection(AGDEBJCJJPB NLJHKMCGMPL)
		{
			return false;
		}

		public virtual void ConfigureHoverPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL)
		{
		}

		public virtual void ConfigureStartPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL, bool FMFJDHJAJKN, EBNPGOBCABE IFEOGBCJEBI)
		{
		}

		public virtual void ConfigureEndPinInfoDisplay(MakerPenPinInfo JLGDNNNOAPD, in Vector3 HJODBKHINKL, ConnectionPoint FLFPHDAAGNM)
		{
		}
	}
}
