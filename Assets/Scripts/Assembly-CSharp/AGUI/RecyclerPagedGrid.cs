using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI
{
	public abstract class RecyclerPagedGrid<ListType, GridMemberType> : VirtualPagedGrid<ListType> where GridMemberType : Component
	{
		[SerializeField]
		protected GridMemberType childPrefab;

		[SerializeField]
		protected LayoutElement spacerElement;

		[SerializeField]
		private List<GridMemberType> prefilledChildUIElements;

		[SerializeField]
		protected int prefilledChildsCoundOverride;

		[NonSerialized]
		protected List<GridMemberType> IDFLJGFFCDJ;

		protected virtual void Awake()
		{
		}

		private void CADPDOEHAOK(int IDDLLNPENBK)
		{
		}

		public virtual void SetLoading()
		{
		}

		public void ForEachChildElement(Action<GridMemberType> ONAFALABHKI)
		{
		}

		protected override void MEMADKFHLND(IEnumerable<ListType> HGJJEHOKAGO, bool OPKEFNEECKK = true)
		{
		}

		protected virtual void LKIICDHGCMD(GridMemberType CCKCIFAHEJJ)
		{
		}

		protected abstract void ANLHNIJPJEC(ListType ONCGIPFNENB, GridMemberType JHAHOJKBMJD, int GNGEFBBFBLF);

		protected virtual void JIMAPDGCGHH(GridMemberType ENLIEGICKON)
		{
		}

		protected override void KLHEKFJOJIA(IList<ListType> HHDINJFMAFO)
		{
		}

		public override void SetPageSize(int IPMIIEAGJKC, bool JGGOPMDFPOE = true)
		{
		}

		private void HDJNLHIMONE(GridMemberType AAFNLLCIFBP, bool JGGOPMDFPOE = true)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
