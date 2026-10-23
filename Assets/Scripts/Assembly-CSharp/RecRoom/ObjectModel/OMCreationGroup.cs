using System.Collections.Generic;

namespace RecRoom.ObjectModel
{
	public class OMCreationGroup : OMAdapterBase, AHCBMDMIAAM
	{

public bool IncludeChildrenInTemplate
{
get 		{
			return false;
		}

}

public bool SupportsExtractingToParent
{
get 		{
			return false;
		}

}

public AHCBMDMIAAM ParentGroup
{
get 		{
			return null;
		}

}

public IEnumerable<DHJLEHBOGBG> ObjectsInGroup
{
get 		{
			return null;
		}

}

		public DHJLEHBOGBG AsContextObject()
		{
			return null;
		}

		public bool Contains(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		public bool ExtractToParentGroupOrRoot(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		public bool ExtractToParentGroupOrRoot(IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO)
		{
			return false;
		}

		private void PNODLMKAJOO(IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO)
		{
		}

		public void OnGroupPopped()
		{
		}

		public void OnGroupPushed()
		{
		}

		public void OnObjectsInGroupWillBeDeleted(IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO)
		{
		}

		public void RenderWorldFadeMask()
		{
		}
	}
}
