using System;
using System.Collections.Generic;
using System.Text;
using RecRoom.Core.Creation.Shapes;
using RecRoom.Persistence;
using UnityEngine;

public interface BJIJHMNPDCH : HEDGOEPMMFO, JPEAKDKPCGM
{

 IReadOnlyList<Guid> AllShapes
{
get ;
}

 KMFOFDEOEAB BigDataTrackedObject
{
get ;
}

 bool BlockObjectPersistance
{
get ;
}

 bool CanBeEditedAfterCreation
{
get ;
}

 ShapeContainer.CEHPAMMILJA CanBeMerged
{
get ;
}

 bool CanBeMirrored
{
get ;
}

 bool CanBeSplit
{
get ;
}

 bool CanModifyWithCircuits
{
get ;
set ;
}

 DHJLEHBOGBG CreationObject
{
get ;
}

 ShapeContainer.HFFJIFAOPOJ CurrentPhysicsMode
{
get ;
set ;
}

 string DebugName
{
get ;
}

 ShapeContainer.HFFJIFAOPOJ DefaultPhysicsMode
{
get ;
}

 bool DestroyIfEmpty
{
get ;
}

 string FriendlyName
{
get ;
}

 bool IsCachedContainer
{
get ;
set ;
}

 bool IsEmpty
{
get ;
}

 bool IsMovable
{
get ;
}

 bool IsPositionRotationValid
{
get ;
}

 int MaxResources
{
get ;
}

 bool OptimizedCollidersEnabled
{
get ;
set ;
}

 PersistenceView PersistenceView
{
get ;
}

 EEJKGDBGCCI RootRenderFlags
{
get ;
}

 MDAFPBCOHEN RootRenderHandle
{
get ;
}

 int SandboxResourceCost
{
get ;
}

 int ShapeCount
{
get ;
}

 bool WillBeDestroyed
{
get ;
}

 Transform ShapeRoot
{
get ;
}

 FIHGBEHGLGB ShouldPersistWhenDestroyingAllFlag
{
get ;
}

 Tool Tool
{
get ;
}

 Transform Transform
{
get ;
}

 event Action OnShapesChangedEvent;

 event Action OnShapesAddedFromDataEvent;

	void AuthorityAddCurveShapeControlPoint(Guid GHLKBLAKLII, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool HGDCBEGLPDO);

	void AuthorityAddShapes(NCLIPFDBPBO OGBKIFBLMIO);

	Guid[] AuthorityCloneShapesToShapeContainer(Guid[] LLIIKIDHHNE, BJIJHMNPDCH MOFGFAAHLIF);

	Guid AuthorityCreateCurveShape(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 INLGLHIPOMC, Quaternion POIOCLOKJGH, float JFJMKFBANPE, FCOHGGHPPMJ KJABCIOBNAM, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM);

	Guid AuthorityCreatePrimitiveShape(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 INLGLHIPOMC, Quaternion POIOCLOKJGH, Vector3 CAPKFCHDLFA, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM);

	void AuthorityDeleteShapes(IEnumerable<Guid> LLIIKIDHHNE);

	void AuthorityInsertCurveShapeControlPoint(Guid GHLKBLAKLII, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool HGDCBEGLPDO, int KEECNENCNBF);

	void AuthorityMirrorShapes(Vector3 GMKLMMJPOEP, Vector3 CNBIDCLLAGA, Vector3 PHHHMNMIIJJ);

	void AuthorityRemoveCurveShapeControlPoint(Guid GHLKBLAKLII, int KEECNENCNBF);

	void AuthoritySetPrimitiveShapeAspectRatio(Guid GHLKBLAKLII, Vector3 GDMKKLNFDOP, bool BCFPNBDFMEI);

	void AuthoritySetPrimitiveShapeAspectRatios(Guid[] LLIIKIDHHNE, Vector3[] GNCLNCEBLHE);

	void AuthoritySetPrimitiveShapeLocalPosition(Guid GHLKBLAKLII, Vector3 EGJKEDKNNAD, bool BCFPNBDFMEI);

	void AuthoritySetShapeColors(Guid[] LLIIKIDHHNE, JLHLKDMLBPK LNBGDJLPKJM, MJGMBIJIKFH APGHJHBHCFA, float PALJJNGJNBE);

	void AuthoritySetShapeColors(Guid[] LLIIKIDHHNE, JLHLKDMLBPK[] IEHHIPOJDBG, MJGMBIJIKFH[] IAPNMPFINIK, float[] IKJDCOHDDIP);

	void AuthoritySetShapeColors(JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, float PALJJNGJNBE);

	void AuthoritySetShapeDensities(float HJFGFKEEKJD);

	void AuthoritySetShapeTransforms(Guid[] LLIIKIDHHNE, Vector3[] CCNNFGHHAPH, Quaternion[] DKMOFMMKDPO, float[] JHKJFIMEHBF);

	void AuthoritySetUVOffset(Guid NBGOLMPJOHO, Vector3 LAECBPNMBIE);

	void AuthoritySetUVScale(Guid NBGOLMPJOHO, float PALJJNGJNBE);

	void AuthorityTransferShapesToShapeContainer(Guid[] LLIIKIDHHNE, BJIJHMNPDCH MOFGFAAHLIF);

	void AuthorityTransferShapeToShapeContainer(Guid GHLKBLAKLII, BJIJHMNPDCH MOFGFAAHLIF);

	bool AuthorityTrySetCurveShapeSettings(FCOHGGHPPMJ KJABCIOBNAM, out string NLJOHEKGNDH);

	bool AuthorityTrySetShapeConfigFlags(OPKFOPKNLMG PANELIGGJGM, out string NLJOHEKGNDH);

	void AuthorityUpdateCurveShapeControlPoint(Guid GHLKBLAKLII, int KEECNENCNBF, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI);

	bool CanAffordToAddShapes(int INLJFENGAEE);

	bool CanMergeShapeContainer(BJIJHMNPDCH GKIDOJICBIB);

	bool CheckShapeOverlaps(int MPJGCPAKKKA, QueryTriggerInteraction BAMJBELIHBB, Func<Collider, bool> ALFMOBIEEKP = null);

	bool ContainsAnyShape(IEnumerable<Guid> LLIIKIDHHNE);

	bool ContainsShape(Guid GHLKBLAKLII);

	void DeserializeFrom(NLOGDCDGECD FFILBGADKKN);

	ShapeContainer.LEIOBPHGMAO GetCurveShape(Guid GHLKBLAKLII);

	IDHANFFPOIF GetIConfigurableForSelection();

	IEnumerable<Tool> GetSelfAndChildTools();

	Guid GetShapeIdFromToolCollider(ToolCollider BIBMKDDMLFI);

	int GetShapesCost(Guid[] LLIIKIDHHNE);

	int GetShapesCostWithSettings(ShapeContainer.HFFJIFAOPOJ HKBMDALBLBN, bool GIFPFHFNIMF);

	bool Hack_ContainsDuplicateShapeIds(BJIJHMNPDCH MFLHIFFMHAO);

	bool IsCurveCollision(Collider ADMCDJKKCIA);

	bool IsCurveShape(Guid GHLKBLAKLII);

	void LocalAddShapesFromData(NCLIPFDBPBO OGBKIFBLMIO);

	void LocalAddShapesFromData(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI, short AJMCKPPKOFJ);

	void MarkPositionRotationInvalid();

	void OnDeselectedByShapeCreationContext();

	void OnSelectedByShapeCreationContext();

	void PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM);

	bool RaycastShapes(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, out Guid EGCFPFNOEEP, out Vector3 FELHKDHHAOE, BJIJHMNPDCH BLFAKBHLAAJ = null);

	void RenderAsIgnored(Vector3 JOFBEGDENCK, Vector3 KGHKNCFKKMB, Vector3 OFKIOHHAEAC, float HNBOEPGMOJB, float EIGIKPJOLPF, IReadOnlyList<Camera> HFEBOPAJBLM, HGILLFNKECL MDILDPALOMC);

	void RenderBatchedOutline(LMKFOACECEG IEMMIFODLAI);

	void RenderSelection();

	void RenderShapeOutline(Guid GHLKBLAKLII, LMKFOACECEG IEMMIFODLAI);

	void RenderWorldFadeMask();

	void RequestMasterMergeShapeContainer(BJIJHMNPDCH GKIDOJICBIB);

	NCLIPFDBPBO SerializeShapes(NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

	NCLIPFDBPBO SerializeShapes(Guid[] LLIIKIDHHNE, NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

	NCLIPFDBPBO SerializeShapes(Guid[] LLIIKIDHHNE, out int INLJFENGAEE, NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

	NCLIPFDBPBO SerializeShapes(out int INLJFENGAEE, NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

	void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM);

	void SetLocalUniformScale(float PDNBMOJFPKO);

	int SpherecastPickShapes(Vector3 EDGHCIEJHLG, float CHFEMIAABLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, Guid[] DLHNFMICGOE, out Vector3 FELHKDHHAOE, out Collider KKIFJDLKMKG, BJIJHMNPDCH BLFAKBHLAAJ = null);

	bool TryGetClosestCurveEndPoint(Vector3 NPNNIGADHKA, ref float DNHMCFAOEHB, ref Guid MGAFKIFDLPI);

	bool TryGetClosestCurvePointInRay(Vector3 JAEGDHEEDEP, Vector3 KNGAEDPENOJ, ref float JNMBIEADIIH, ref float KEDBAELNJIE, ref Guid HGDPNJMPEHN, ref int GJEBMLHBHOH);

	bool TryGetCurveShapeControlPointCount(Guid GHLKBLAKLII, out int JHFKLKBDOLH);

	bool TryGetCurveShapeControlPointPositionRotationAndRadius(Guid GHLKBLAKLII, int KEECNENCNBF, out Vector3 NOOOJBNDGPN, out Quaternion DNEFKBEHEEC, out float NNLEGJGIGHA);

	bool TryGetEndControlPointInfoWorldSpace(Guid GHLKBLAKLII, ref Vector3 CDKEGFGDKMG, ref float NNLEGJGIGHA, ref Vector3 CHEKLLFMKBP, ref FCOHGGHPPMJ KJABCIOBNAM);

	bool TryGetPrimitiveShapeLocalScale(Guid GHLKBLAKLII, out Vector3 CAPKFCHDLFA);

	bool TryGetPrimitiveShapePosition(Guid GHLKBLAKLII, out Vector3 MDMGLACFCFC);

	ToolCollider TryGetShapeCollider(Guid GHLKBLAKLII);

	bool TryGetShapeWorldBounds(Guid GHLKBLAKLII, out Bounds DBPFJELGIGI);

	bool TryGetShapeMaterialInfo(Guid GHLKBLAKLII, out JLHLKDMLBPK LNBGDJLPKJM, out MJGMBIJIKFH APGHJHBHCFA, out float PALJJNGJNBE);

	bool TryGetShapeRotation(Guid GHLKBLAKLII, out Quaternion IENBPFILMGK);

	NCANNFMMHDJ TryGetShapeTransform(Guid GHLKBLAKLII);

	bool TrySetValidPositionRotation(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH);

	bool CLFGAPFKFLM(ToolCollider BIBMKDDMLFI, out object NBGOLMPJOHO);
}
