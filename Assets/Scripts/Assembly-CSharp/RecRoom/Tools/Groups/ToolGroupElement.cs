using System;
using Photon.Pun;
using RecRoom.Core.DataStructures;
using UnityEngine;

namespace RecRoom.Tools.Groups
{
	public abstract class ToolGroupElement : MonoBehaviourPun
	{
		[SerializeField]
		private Material addHighlightMaterial;

		[SerializeField]
		private Mesh addHighlightMesh;

		[SerializeField]
		private ReferencePoint frontAddHighlightPoint;

		[SerializeField]
		private ReferencePoint backAddHighlightPoint;

		[SerializeField]
		private Vector3 addHighlightScale;

		[SerializeField]
		protected GroupSearch defaultSearchCollider;

		[SerializeField]
		protected GroupSearch heldSearchCollider;

		[SerializeField]
		private Tool tool;

		[SerializeField]
		private VisibleInCamera visibleInCamera;

		private global::MOBDJNEDDKC<int> POBKBBJDHAE;

		[NonSerialized]
		public ToolGroup Group;

		private Vector3 ADGAKOMCNEM;

		private Quaternion MFGLIDCPIAD;

		private Vector3 DBMJFDHDDOC;

		private Quaternion IJICLHCCGLF;

		private Bounds KFCMKGNAPKP;

		private ToolGroupElement[] EJLHNOLBCOI;

		private ToolGroupElement IEOHBLIHDGA;

		private ToolGroup BNNGFHEFNLH;

		private IDisposable CCMBPEGNONE;

		private bool MHDLJIEEKBP;

		private IDisposable PKELJKABOLO;

		private bool FLKIICIJALD;

public ToolGroup ThisGroup
{
get 		{
			return null;
		}

set {
		}
}

public Vector3 GroupLocalPosition
{
get 		{
			return default;
		}

set {
		}
}

public Quaternion GroupLocalRotation
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 ColliderLocalPosition
{
get 		{
			return default;
		}

set {
		}
}

public Quaternion ColliderLocalRotation
{
get 		{
			return default;
		}

set {
		}
}

public Bounds LocalBoundingBox
{
get 		{
			return default;
		}

private set {
		}
}

public Tool Tool
{
get 		{
			return null;
		}

}

public VisibleInCamera VisibleInCamera
{
get 		{
			return null;
		}

}

public bool IsInGroup
{
get 		{
			return false;
		}

}

protected ToolGroupElement FFJMJANLEGG
{
get 		{
			return null;
		}

set {
		}
}

protected ToolGroup IFCCCMNBDCH
{
get 		{
			return null;
		}

set {
		}
}

public bool FrontAddHighlightEnabled
{
get 		{
			return false;
		}

set {
		}
}

public bool BackAddHighlightEnabled
{
get 		{
			return false;
		}

set {
		}
}

protected GroupSearch GOIIMDKJDKK
{
get 		{
			return null;
		}

}

protected abstract string CAJNEPLOHBK
{
get ;
}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public virtual bool CanAddTool(ToolGroupElement IEGMBEPJMGC)
		{
			return false;
		}

		protected virtual void Update()
		{
		}

		public void UpdateGroupLayout(Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, Vector3 MLLJHKGOBCI, Quaternion AFOLGLBBFNL)
		{
		}

		private void HAJACOHFHBE(Tool IEGMBEPJMGC)
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		private void FONGCCJAKAL()
		{
		}

		protected void KACEMAFJANI()
		{
		}

		private void FGBDMEIDDJK(ToolGroup GJMENLMHOGH)
		{
		}

		public ToolGroup CreateNewGroup()
		{
			return null;
		}

		private void LPLFPAGEKJF()
		{
		}

		private ToolGroup CKELPHJDDPH()
		{
			return null;
		}

		private ToolGroup MFPFBGOAAFN()
		{
			return null;
		}

		private void AFKPJFBHBNK(ToolGroup GJMENLMHOGH)
		{
		}

		public virtual void DisplayAddToolHighlight(ToolGroupElement JMHFDNPLCEM)
		{
		}

		private void ONDNKCCLCGD()
		{
		}

		private void HBGCLLBIHIL()
		{
		}

		private void IOHJLKOOGMN(Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI)
		{
		}

		private void EECLFJEMPGG(Tool PMEFICGEDFK)
		{
		}

		private void OBBFPIJMDAI(Tool PMEFICGEDFK)
		{
		}

		private Tool CBEDAMEDEOB()
		{
			return null;
		}

		[PBOMGCLBFHF]
		protected void RpcMasterCreateNewGroup(GGGMJMEFFOC BOCBPOADLNM)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcOnMasterGroupCreation(ToolGroup CIFHMNKCLNG)
		{
		}
	}
}
