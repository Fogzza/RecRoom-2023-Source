using System;
using System.Collections.Generic;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.Shapes;
using UnityEngine;

public interface MMMPKIMPKKC : global::FNLEEFFPAAJ<Guid>, CAMIJPMLKOA, global::DDLEHONFEBP<Guid>, AINHEFJAEPG, global::EOCHBHDFJOM<Guid>, global::CJOLMILKEEG<Guid>, global::AIGGMOPIIKJ<Guid>, global::GLEADKGGNKA<Guid>, MAGMDAGMOMO, global::JMLHLJFACAP<Guid>, GJPBOMNOBND, BMHNAMLFPHB, AHAGBOCIINO, global::BAIMOJOCJOK<Guid>, global::ANEBEINLICG<Guid>, global::ONMIGJKMOIP<Guid>, global::BHDCFHIHABO<Guid>, global::LIKLLLAINCP<Guid>, global::ENDMHNLLGFN<Guid>, global::AGNNPIOFKPK<Guid>, global::JNKPGKLPGFB<Guid>, global::OCGHADNNOCP<Guid>
{

 BKAOBFNMILE CreationShapeContainer
{
get ;
}

 bool HasSelectedShapeContainer
{
get ;
}

 bool IsEmpty
{
get ;
}

 bool IsOverCostLimit
{
get ;
}

 BJIJHMNPDCH SelectedShapeContainer
{
get ;
}

 Transform transform
{
get ;
}

 int ShapeCount
{
get ;
}

 EEANDDJEMJC ShapeCreationStarted
{
get ;
set ;
}

 EEANDDJEMJC ShapeCreationFinished
{
get ;
set ;
}

 EEANDDJEMJC CurveCreationStarted
{
get ;
set ;
}

 EEANDDJEMJC CurveCreationFinished
{
get ;
set ;
}

 EEANDDJEMJC SelectedShapeContainerChangedEvent
{
get ;
set ;
}

	void StartSelectionChanges();

	void FinishSelectionChanges();

	bool AnySelected(IEnumerable<Guid> LLIIKIDHHNE);

	void AuthorityHandleRoomPersistenceComplete();

	void AuthorityHandleRoomPersistenceStart();

	bool CanAffordNewShapeContainer(JBGFOIKBKED IDHLGPDCLCM, int JPECHJIJOJL);

	bool CanAffordToAddShapes(BJIJHMNPDCH IFLPNPBKNBA, int JPECHJIJOJL);

	bool CanSelectedContainerAffordResourceCost(int PNNCCFDIMEP);

	void CheckNotifyResourceLimits();

	global::NCOKFFGPIJM<BJIJHMNPDCH> CreateAndSelectShapeContainer();

	void DeselectShapeContainer();

	void FinishShape(bool ACDDBKAELFK);

	ShapeContainer.LEIOBPHGMAO GetCurveShape(Guid GHLKBLAKLII);

	IEnumerable<ToolCollider> GetSelectionToolColliders();

	void LockOwnershipToLocalPlayer();

	NCLIPFDBPBO SerializeSelectedShapes();

	NCLIPFDBPBO SerializeSelectedShapes(out int INLJFENGAEE);

	NCLIPFDBPBO SerializeShapesIncludingSelected(BJIJHMNPDCH MOFGFAAHLIF, Guid[] IHLJHIFFNPM);

	NCLIPFDBPBO SerializeShapesIncludingSelected(BJIJHMNPDCH MOFGFAAHLIF, Guid[] IHLJHIFFNPM, out int IKOAEBAPFIB);

	void SetSelectedPrimitiveShapeAspectRatios(Guid[] LLIIKIDHHNE, Vector3[] GNCLNCEBLHE);

	bool SetSelectedShapeTransforms(Guid[] LLIIKIDHHNE, Vector3[] CCNNFGHHAPH, Quaternion[] DKMOFMMKDPO, float[] JHKJFIMEHBF);

	void ShouldHideOriginVisualizer(bool IMGEJEOIKBO, object IALNODEHBNN);

	bool TryAddAndSelectShapesInSelectedShapeContainer(NCLIPFDBPBO CEAJLCOCMNI, int JPECHJIJOJL);

	IONEOHGOAML TryAddSelectedCurveShapeControlPoint(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool HGDCBEGLPDO, bool ANMENIMHEBE);

	IONEOHGOAML TryCloneSelectedShapes(CreationContext.IMHJKLGAICO LBINIIAEHLF);

	ShapeCreationContextBase.NDCCKBBFHAH TryCreateAndSelectCurveShapeInSelectedShapeContainer(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 PEJEOHJJKBA, Quaternion JMDALKJDKBF, float JFJMKFBANPE, FCOHGGHPPMJ KJABCIOBNAM, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM);

	ShapeCreationContextBase.NDCCKBBFHAH TryCreateAndSelectPrimitiveShapeInSelectedShapeContainer(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 PEJEOHJJKBA, Quaternion JMDALKJDKBF, Vector3 OILBNELDHCP, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM);

	bool TryGetClosestCurveEndPoint(Vector3 NPNNIGADHKA, float KEDBAELNJIE, out Guid MGAFKIFDLPI);

	bool TryGetEndControlPointInfoWorldSpace(Guid GHLKBLAKLII, out Vector3 CDKEGFGDKMG, out float NNLEGJGIGHA, out Vector3 CHEKLLFMKBP, out FCOHGGHPPMJ KJABCIOBNAM);

	bool TryGetSelectedClosestCurvePointInRay(Vector3 JAEGDHEEDEP, Vector3 KNGAEDPENOJ, out Guid NBGOLMPJOHO, out int GMEHLIHLGEH);

	bool TryGetSelectedCurvePointPositionRotationAndRadius(Guid GHLKBLAKLII, int GMEHLIHLGEH, out Vector3 BAGMHHCMNNF, out Quaternion DNEFKBEHEEC, out float NNLEGJGIGHA);

	bool TryGetSelectedCurveShapeFirstControlPointPosition(out Vector3 NOOOJBNDGPN);

	bool TryGetSelectedCurveShapeLastPointInfo(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float NNLEGJGIGHA);

	bool TryGetSelectedCurveShapePreviousControlPointInfo(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float NNLEGJGIGHA);

	bool TryGetSelectedPrimitiveShapeAspectRatio(out Vector3 CAPKFCHDLFA);

	bool TryGetSelectedPrimitiveShapePosition(out Vector3 INLGLHIPOMC);

	Transform TryGetSelectedPrimitiveShapeTransform();

	bool TryGetShapeRotation(Guid GHLKBLAKLII, out Quaternion IENBPFILMGK);

	bool TrySelectShapeContainer(BJIJHMNPDCH MOFGFAAHLIF);

	bool TrySetCurvePointPositionRotationAndRadius(Guid GHLKBLAKLII, int GMEHLIHLGEH, Vector3 BAGMHHCMNNF, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI);

	global::NCOKFFGPIJM<BJIJHMNPDCH> TrySplitSelectedShapes();

	void UpdateSelectedCurveShapeFirstControlPoint(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI);

	void UpdateSelectedCurveShapeLatestControlPoint(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI);

	void UpdateSelectedPrimitiveShapeAspectRatio(Vector3 GDMKKLNFDOP, bool BCFPNBDFMEI);
}
