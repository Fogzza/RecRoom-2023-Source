using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using RecRoom.Core.Creation.CircuitsV1;
using UnityEngine;

namespace RecRoom.Core.Creation.SandboxGizmos
{
	public abstract class SandboxGizmo : MonoBehaviourPun, DJLCHGFCFAD, GAAKCFPLMHN
	{
		[Serializable]
		public class DefaultPoseInfo
		{
			public bool IsDisconnected;

			public RigidbodyEx Parent;

			public Vector3 RelativePositionToParent;

			public Quaternion RelativeRotationToParent;

			public Vector3 DisconnectedWorldPosition;

			public Quaternion DisconnectedWorldRotation;

			public void PLCAKFAMFIL(RigidbodyEx HHFDFFDPCGO, Vector3 GJGMLLFCOAD, Quaternion FLINFHACPCC)
			{
			}

			public void MGLPPPEPPGL(bool GOGFJLGINLI)
			{
			}
		}

		private const float EBPAGGPBLJM = 1E-05f;

		[SerializeField]
		private CircuitEventNodeDisplay circuitNode;

		[SerializeField]
		protected CreationObject creationObject;

		[SerializeField]
		private ConnectableTool _connectableTool;

		private int MPFFBOBJOGD;

		private Action APOCMKLLGKK__BackingField;

		private bool MLNEMICGADO;

		private bool DMJMCIPIHFF;

		protected DefaultPoseInfo MHEGAJILILC;

public ConnectableTool ConnectableTool
{
get 		{
			return null;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

protected virtual string BLDIMIHMMGD
{
get 		{
			return null;
		}

}

public bool IsRunning
{
get 		{
			return false;
		}

private set {
		}
}

public virtual bool CanBeTurnedOn
{
get 		{
			return false;
		}

}

public Vector3 DefaultRelativePosition
{
get 		{
			return default;
		}

}

public Quaternion DefaultRelativeRotation
{
get 		{
			return default;
		}

}

public virtual bool IsCircuitsV2
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public event Action IsRunningChanged {
add {
		}
remove {
		}
}

		private bool DAINEHLHBNM(out PAOFKDGAONA BGDMKGJPDBD)
		{
			BGDMKGJPDBD = default;
			return false;
		}

		private void FCLDJCODIJD(PAOFKDGAONA BGDMKGJPDBD)
		{
		}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void FixedUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected virtual AKCHPHOMHLH MNECEOLGCKC()
		{
			return null;
		}

		private void HIHOIIMCLCH(bool FODAGELEEBM)
		{
		}

		private void HEHMICJPHNL(CreationObject BPEGJLIMPPJ)
		{
		}

		private void MEMBPBALAKE(Tool IEGMBEPJMGC)
		{
		}

		private void BEGHDDMMNNL()
		{
		}

		public void ChangeGizmoIgnition(Dictionary<EDBMANFHGGO, int> input)
		{
		}

		protected void NLGNGAKECDD(bool GPNMJLHPJCO)
		{
		}

		private void FKGJPONGHCC()
		{
		}

		private void OPBHAMDIMBE()
		{
		}

		protected virtual void OPBHAMDIMBE(Vector3 CPLLMPKBHAM, Quaternion IKEPGNGNPGC)
		{
		}

		public virtual void AuthorityResetToDefaultState()
		{
		}

		public void ResetObject()
		{
		}

		protected virtual void IHLNPHDKJOO()
		{
		}

		protected virtual void EADGFKAGGBD()
		{
		}

		public virtual void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public virtual void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void MANOIOFDEEM(RigidbodyEx BJHLKOMIJEL, bool LDEEGDEKBLJ)
		{
		}

		private void LIHGPFKPOOG(AGDEBJCJJPB CPOOFMLGBHG, int IPLPPBFMGCI, AGDEBJCJJPB NILIBFOHDDC, int KMDALLHAPFG, Vector3? GJGMLLFCOAD = null, Quaternion? FLINFHACPCC = null)
		{
		}
	}
}
