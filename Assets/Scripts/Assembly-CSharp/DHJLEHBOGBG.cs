using System;
using RecRoom.Core.Creation;
using RecRoom.Tools;
using UnityEngine;

public interface DHJLEHBOGBG : JGLPGIIHGIM, JKKPILGMECP, MGPMJALOCBB, AKBNDDCCILB, FHOCFMCHHJF, MPEMFIPALDL, HFCCIAENGHB, NADHPLMICLB, MJJLJOABJIP, PEJNMGDGGAF, KJGJNBDHLED, HGNMOPCBKOI, FKFAGIFPJAE, BAJJBGMMMFA, BANEAOEMGBA, LKJAJFEHDDD, MHDKIPJKDBC, BKPFMIKGFKP
{

 Tool Tool
{
get ;
}

 DHJLEHBOGBG Parent
{
get ;
}

 ObjectGroup OwningGroup
{
get ;
set ;
}

 bool IsContainer
{
get ;
}

 BOALOIBLNEO ObjectBoard
{
get ;
}

 event Action<DHJLEHBOGBG> LockStatusChangeEvent;

 event Action<DHJLEHBOGBG> OnCreationObjectWillDelete;

	AHCBMDMIAAM AsGroup();

	void SetCustomEditControls(MakerPen BHCCDMJFHEO, FBEHJNCKJPN CIMCLAFMGFE);

	ECMNCNMENKO ModifyProperty(GGHECEJBHPI DELCOFCGDFF, string OPCKJKNEHGA, params object[] BHOKKEBBPNA);

	void AddPropertyHandler(string IDBLFHOOMPH, PCOCEPINJKE.NBEMBFBLMBB ODEFKCPHGJD);

	void RemovePropertyHandler(string IDBLFHOOMPH, PCOCEPINJKE.NBEMBFBLMBB ODEFKCPHGJD);

	BJIJHMNPDCH GetShapeContainerForCollider(Collider ADMCDJKKCIA);

	void SetShapeContainerForColliderGetter(Func<Collider, BJIJHMNPDCH> GOIOJEGDINC);
}
