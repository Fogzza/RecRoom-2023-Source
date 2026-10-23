using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI
{
	public abstract class VirtualPagedGrid : MonoBehaviour
	{
		[SerializeField]
		protected GameObject emptyDisplay;

		[SerializeField]
		protected TextMeshProUGUI emptyDisplayText;

		[SerializeField]
		protected GameObject nonEmptyInfoText;

		[SerializeField]
		protected RectTransform gridBaseTransform;

		[SerializeField]
		protected RectTransform pageControls;

		[SerializeField]
		private Selectable previousPageButton;

		[SerializeField]
		private Selectable nextPageButton;

		[SerializeField]
		private GameObject previousPageVisibilityContainer;

		[SerializeField]
		private GameObject nextPageVisibilityContainer;

		[SerializeField]
		protected PageDisplay pageDisplay;

		[SerializeField]
		private int pageSize;

		private Action NJMJJOFGJAF__BackingField;

		[NonSerialized]
		public bool PagingButtonsSupported;

		private int DNCODIGLNID;

		private int AAGJANDDPGM;

public RectTransform GridBaseTransform
{
get 		{
			return null;
		}

}

public Selectable PreviousPageButton
{
get 		{
			return null;
		}

}

public Selectable NextPageButton
{
get 		{
			return null;
		}

}

public GameObject PreviousPageVisibilityContainer
{
get 		{
			return null;
		}

}

public GameObject NextPageVisibilityContainer
{
get 		{
			return null;
		}

}

public int PageSize
{
get 		{
			return 0;
		}

}

protected virtual bool MECIIMDNMGD
{
get 		{
			return false;
		}

}

public int TotalPages
{
get 		{
			return 0;
		}

set {
		}
}

public int CurrentPage
{
get 		{
			return 0;
		}

}

public event Action PageChangeEvent {
add {
		}
remove {
		}
}

		public void SetEmptyDisplayText(string MAFKLMLIAOD)
		{
		}

		public virtual void SetPageSize(int IPMIIEAGJKC, bool JGGOPMDFPOE = true)
		{
		}

		public void SetCurrentPage(int MLCFEEOIEOE, bool JGGOPMDFPOE = true)
		{
		}

		public abstract void UpdateGrid();

		protected abstract void KHMGOKGDBAC();

		public void Button_GoBack()
		{
		}

		public void Button_GoForward()
		{
		}

		public bool EditorValidatePrefabSave()
		{
			return false;
		}

		protected virtual bool FMGFAEOLDKF()
		{
			return false;
		}
	}
	public abstract class VirtualPagedGrid<ListType> : VirtualPagedGrid
	{
		[NonSerialized]
		private List<ListType> KGGPHKBGGDE;

protected List<ListType> GELLDMLKOLO
{
get 		{
			return null;
		}

private set {
		}
}

		protected virtual void MEMADKFHLND(IEnumerable<ListType> HGJJEHOKAGO, bool OPKEFNEECKK = true)
		{
		}

		protected void MEKFAHAKGFB(IEnumerable<ListType> LPKNFCGBOAI)
		{
		}

		protected virtual void KLHEKFJOJIA(IList<ListType> HHDINJFMAFO)
		{
		}

		public override void UpdateGrid()
		{
		}

		protected virtual void GAJGEIBINPF()
		{
		}

		protected override void KHMGOKGDBAC()
		{
		}
	}
}
