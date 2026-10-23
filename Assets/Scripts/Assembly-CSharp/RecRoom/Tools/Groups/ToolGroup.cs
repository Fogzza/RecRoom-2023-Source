using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Photon.Pun;
using UnityEngine;

namespace RecRoom.Tools.Groups
{
	public abstract class ToolGroup : MonoBehaviourPun
	{
		private sealed class FDDILOJOJDP : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ToolGroupElement removedTool;

			public ToolGroup _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public FDDILOJOJDP(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private Tool GAPEICCMANI;

		protected List<ToolGroupElement> OKKDPEMOHMC;

		protected BoxCollider HFOIEMKLKJM;

		protected Bounds EGKBFGIPMFP;

		[SerializeField]
		protected GroupSearchCustomGeometry defaultSearchCollider;

		[SerializeField]
		protected GroupSearchCustomGeometry heldSearchCollider;

		private Coroutine BCDEJCKOOLF;

		protected static readonly Vector3[] NFKLAEHEFOA;

		private ToolGroup BNNGFHEFNLH;

		[SerializeField]
		private float removeMinDistance;

public Tool Tool
{
get 		{
			return null;
		}

private set {
		}
}

protected GroupSearchCustomGeometry GOIIMDKJDKK
{
get 		{
			return null;
		}

}

public int Size
{
get 		{
			return 0;
		}

}

public IEnumerable<ToolGroupElement> Children
{
get 		{
			return null;
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

protected bool EKGFJLGOPIE
{
get 		{
			return false;
		}

}

private bool JMINPDCAAFP
{
set {
		}
}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void AuthorityDestroy()
		{
		}

		public void AuthorityAddChildren(ToolGroupElement[] OKKDPEMOHMC)
		{
		}

		public void AuthorityAddChildren(ToolGroupElement[] OKKDPEMOHMC, Vector3[] CCNNFGHHAPH, Quaternion[] DKMOFMMKDPO)
		{
		}

		public void AuthorityAddChild(ToolGroupElement AAFNLLCIFBP)
		{
		}

		public void AuthorityAddChild(ToolGroupElement AAFNLLCIFBP, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI)
		{
		}

		public void AuthorityAddGroup(ToolGroup CIFHMNKCLNG)
		{
		}

		public void AuthorityRemoveChild(ToolGroupElement AAFNLLCIFBP)
		{
		}

		public void AuthorityClearTools()
		{
		}

		public void AuthorityReorderTools(int[] ALBNMMFAAFI)
		{
		}

		private void HDJNLHIMONE(ToolGroupElement AAFNLLCIFBP, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, int OJLNMFEHAFC, bool MEFIJGMFLPG = true)
		{
		}

		protected void FLMANBODCNL(ToolGroupElement ANCIFLINDGC)
		{
		}

		protected void JABLBNJAPJK()
		{
		}

		private IEnumerator HAGPBMAJHBG(ToolGroupElement ANCIFLINDGC)
		{
			return null;
		}

		private void DFCNILODFON(ToolGroupElement AAFNLLCIFBP, bool EBFMAPMOCKP = true)
		{
		}

		private void HBJNPLCDNJF()
		{
		}

		private void JLIMJFBKGGC(int[] OCCFFNKLNLI)
		{
		}

		protected virtual void FPBBAHGNJCL(ToolGroupElement AAFNLLCIFBP)
		{
		}

		protected virtual void COHMIBLFKKG(ToolGroupElement AAFNLLCIFBP)
		{
		}

		protected virtual int LPFICEIIDCA(ToolGroupElement DBBIMKPFDLH, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI)
		{
			return 0;
		}

		public virtual bool CanAddChild(ToolGroupElement AAFNLLCIFBP)
		{
			return false;
		}

		public virtual bool CanAddGroup(ToolGroup CIFHMNKCLNG)
		{
			return false;
		}

		public void AuthorityClone(ToolGroup HBLGPEPFDJJ)
		{
		}

		protected virtual void Update()
		{
		}

		protected void FONGCCJAKAL()
		{
		}

		protected void KACEMAFJANI()
		{
		}

		protected virtual void CCEJEDKMMCK(ToolGroup HBLGPEPFDJJ)
		{
		}

		public virtual void DisplayAddToolHighlight(ToolGroupElement JMHFDNPLCEM)
		{
		}

		public virtual void DisplayAddGroupHighlight(ToolGroup JGKOGEPGLCA)
		{
		}

		private void MNPLCFMNCJL(Tool IEGMBEPJMGC)
		{
		}

		public virtual ToolGroupElement GetHighlightedChildInGroup()
		{
			return null;
		}

		private Tool CBEDAMEDEOB()
		{
			return null;
		}

		private void LPEICKAIDDN(bool BMGEHFPFCBJ)
		{
		}

		private bool FADMDFGGDAC()
		{
			return false;
		}

		public virtual void OnChildInGroupHoverStart(ToolGroupElement AAFNLLCIFBP)
		{
		}

		public virtual void OnChildInGroupHoverEnd(ToolGroupElement AAFNLLCIFBP)
		{
		}

		protected virtual void EECLFJEMPGG(Tool PMEFICGEDFK)
		{
		}

		protected virtual void OBBFPIJMDAI(Tool PMEFICGEDFK)
		{
		}

		protected virtual void HIHAMKFEEIA()
		{
		}

		protected void FCNCIIKGLHL()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAddChild(ToolGroupElement AAFNLLCIFBP, Vector3 EGJKEDKNNAD, Quaternion IBHAEICNMJI, int OJLNMFEHAFC)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcAddChildren(int[] HDBDAMAEBOM, Vector3[] CCNNFGHHAPH, Quaternion[] DKMOFMMKDPO, int JMBOOMFLJJP)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcRemoveChild(ToolGroupElement AAFNLLCIFBP)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcClearChildren()
		{
		}

		[PBOMGCLBFHF]
		protected void RpcInitializeGroup(int[] HDBDAMAEBOM, Vector3[] MDMNFJEECNJ, Quaternion[] HLANKCPNPFD)
		{
		}

		[PBOMGCLBFHF]
		protected void RpcReorderChildren(int[] HDBDAMAEBOM)
		{
		}

		protected virtual void OnPhotonPlayerConnected(CHILKDJABBF PLNGHFIMCDB)
		{
		}

		protected void CAMOKCEHPKE(CHILKDJABBF CMNODMLEKGJ)
		{
		}
	}
}
