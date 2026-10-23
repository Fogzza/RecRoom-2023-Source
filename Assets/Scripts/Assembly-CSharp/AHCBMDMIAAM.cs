using System.Collections.Generic;

public interface AHCBMDMIAAM
{

 AHCBMDMIAAM ParentGroup
{
get ;
}

 IEnumerable<DHJLEHBOGBG> ObjectsInGroup
{
get ;
}

 bool IncludeChildrenInTemplate
{
get ;
}

 bool SupportsExtractingToParent
{
get ;
}

	DHJLEHBOGBG AsContextObject();

	bool Contains(DHJLEHBOGBG GLHOACNHHMF);

	void OnGroupPushed();

	void OnGroupPopped();

	void OnObjectsInGroupWillBeDeleted(IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO);

	bool ExtractToParentGroupOrRoot(DHJLEHBOGBG GLHOACNHHMF);

	bool ExtractToParentGroupOrRoot(IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO);

	void RenderWorldFadeMask();
}
