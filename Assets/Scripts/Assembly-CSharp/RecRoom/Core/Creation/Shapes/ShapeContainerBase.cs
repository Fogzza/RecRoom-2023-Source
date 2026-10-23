using System;
using System.Collections.Generic;
using System.Text;
using RecRoom.ObjectModel;
using RecRoom.Persistence;
using UnityEngine;

namespace RecRoom.Core.Creation.Shapes
{
	public abstract class ShapeContainerBase<ShapeDataT> : OMAdapterBasePun, BJIJHMNPDCH, HEDGOEPMMFO, JPEAKDKPCGM, DJLCHGFCFAD
	{
		private sealed class IIBINIEMNDI
		{
			public ShapeContainerBase<ShapeDataT> _003C_003E4__this;

			public BJIJHMNPDCH otherToConsider;

			internal ShapeDataT _003CSpherecastPickShapes_003Eb__0(Collider c, float distanceSq)
			{
				return default;
			}
		}

		protected const float EBPAGGPBLJM = 1E-05f;

		protected const string GCIMIKGOACC = "PhysicsMode";

		private const string CJGPICDFJDP = "UGC.Shapes.OptimizedCollidersDefaultForExisting";

		private bool GDJCPNIDGDF;

		private bool HNEOLJMCJHM;

		private EEJKGDBGCCI PEPLNLMDLNA;

		private MDAFPBCOHEN DMFOPJPLMIF;

		protected bool PFAKOHNOJGH;

		protected int HKCDAOOGHFA;

		public bool isSelectedByShapeCreationContext;

		private Action FKBMDPOKOMO__BackingField;

		private Action DGCEDAMGNLD__BackingField;

private bool GDJEDMMMCAE
{
get 		{
			return false;
		}

}

public abstract IReadOnlyList<Guid> AllShapes
{
get ;
}

public abstract KMFOFDEOEAB BigDataTrackedObject
{
get ;
}

public abstract bool CanBeEditedAfterCreation
{
get ;
}

public abstract ShapeContainer.CEHPAMMILJA CanBeMerged
{
get ;
}

public abstract bool CanBeMirrored
{
get ;
}

public abstract bool CanBeSplit
{
get ;
}

public abstract string DebugName
{
get ;
}

public abstract bool DestroyIfEmpty
{
get ;
}

public abstract string FriendlyName
{
get ;
}

public abstract ShapeContainer.HFFJIFAOPOJ DefaultPhysicsMode
{
get ;
}

public abstract int MaxResources
{
get ;
}

public abstract bool CanModifyWithCircuits
{
get ;
set ;
}

public abstract bool OptimizedCollidersEnabled
{
get ;
set ;
}

public abstract ShapeContainer.HFFJIFAOPOJ CurrentPhysicsMode
{
get ;
set ;
}

public abstract DHJLEHBOGBG CreationObject
{
get ;
}

public FIHGBEHGLGB ShouldPersistWhenDestroyingAllFlag
{
get 		{
			return null;
		}

}

public bool IsCachedContainer
{
get 		{
			return false;
		}

set {
		}
}

protected virtual bool ONCDOHNEBKC
{
get 		{
			return false;
		}

}

protected virtual bool LPJFJMOOOFG
{
get 		{
			return false;
		}

}

public virtual bool IsEmpty
{
get 		{
			return false;
		}

}

public bool WillBeDestroyed
{
get 		{
			return false;
		}

}

public bool IsMovable
{
get 		{
			return false;
		}

}

public virtual bool IsPositionRotationValid
{
get 		{
			return false;
		}

set {
		}
}

public abstract PersistenceView PersistenceView
{
get ;
}

public EEJKGDBGCCI RootRenderFlags
{
get 		{
			return EEJKGDBGCCI.Static;
		}

set {
		}
}

public virtual MDAFPBCOHEN RootRenderHandle
{
get 		{
			return default;
		}

set {
		}
}

public int SandboxResourceCost
{
get 		{
			return 0;
		}

}

public abstract int ShapeCount
{
get ;
}

public abstract Transform ShapeRoot
{
get ;
}

public abstract Tool Tool
{
get ;
}

public abstract Transform Transform
{
get ;
}

protected static ShapeDataT ANKACLACPDC
{
get 		{
			return default;
		}

}

public virtual bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public virtual GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

public event Action OnShapesChangedEvent {
add {
		}
remove {
		}
}

public event Action OnShapesAddedFromDataEvent {
add {
		}
remove {
		}
}

		protected virtual int OJMKMPAFOIK(ShapeContainer.HFFJIFAOPOJ? HDADMGFHHCJ = null, bool? KCMGOCEGFAP = null)
		{
			return 0;
		}

		public bool CanAffordToAddShapes(int INLJFENGAEE)
		{
			return false;
		}

		protected abstract int JGEKDNDJCKM(ShapeDataT CEAJLCOCMNI);

		public int GetShapesCost(Guid[] CEAJLCOCMNI)
		{
			return 0;
		}

		protected int IDCCPCCFHCN(IEnumerable<Guid> IHLJHIFFNPM, ShapeContainer.HFFJIFAOPOJ HKBMDALBLBN, bool GIFPFHFNIMF)
		{
			return 0;
		}

		public static int GetShapesCost(int INLJFENGAEE, ShapeContainer.HFFJIFAOPOJ HKBMDALBLBN, bool GIFPFHFNIMF)
		{
			return 0;
		}

		public abstract int GetShapesCostWithSettings(ShapeContainer.HFFJIFAOPOJ HKBMDALBLBN, bool GIFPFHFNIMF);

		protected void LKGDJICBMDM()
		{
		}

		protected void OAALEIKMNFH()
		{
		}

		public abstract void AuthorityAddCurveShapeControlPoint(Guid GHLKBLAKLII, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool HGDCBEGLPDO);

		public abstract void AuthorityAddShapes(NCLIPFDBPBO OGBKIFBLMIO);

		public abstract Guid[] AuthorityCloneShapesToShapeContainer(Guid[] LLIIKIDHHNE, BJIJHMNPDCH MOFGFAAHLIF);

		public abstract Guid AuthorityCreateCurveShape(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 INLGLHIPOMC, Quaternion POIOCLOKJGH, float JFJMKFBANPE, FCOHGGHPPMJ KJABCIOBNAM, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM);

		public abstract Guid AuthorityCreatePrimitiveShape(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 INLGLHIPOMC, Quaternion POIOCLOKJGH, Vector3 CAPKFCHDLFA, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM);

		public abstract void AuthorityDeleteShapes(IEnumerable<Guid> LLIIKIDHHNE);

		public abstract void AuthorityInsertCurveShapeControlPoint(Guid GHLKBLAKLII, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool HGDCBEGLPDO, int KEECNENCNBF);

		public abstract void AuthorityRemoveCurveShapeControlPoint(Guid GHLKBLAKLII, int KEECNENCNBF);

		public abstract void AuthorityMirrorShapes(Vector3 GMKLMMJPOEP, Vector3 CNBIDCLLAGA, Vector3 PHHHMNMIIJJ);

		public abstract void AuthoritySetPrimitiveShapeAspectRatio(Guid GHLKBLAKLII, Vector3 GDMKKLNFDOP, bool BCFPNBDFMEI);

		public abstract void AuthoritySetPrimitiveShapeAspectRatios(Guid[] LLIIKIDHHNE, Vector3[] GNCLNCEBLHE);

		public abstract void AuthoritySetPrimitiveShapeLocalPosition(Guid GHLKBLAKLII, Vector3 EGJKEDKNNAD, bool BCFPNBDFMEI);

		public abstract void AuthoritySetShapeColors(Guid[] LLIIKIDHHNE, JLHLKDMLBPK[] IEHHIPOJDBG, MJGMBIJIKFH[] IAPNMPFINIK, float[] IKJDCOHDDIP);

		public abstract void AuthoritySetShapeColors(Guid[] LLIIKIDHHNE, JLHLKDMLBPK LNBGDJLPKJM, MJGMBIJIKFH APGHJHBHCFA, float PALJJNGJNBE);

		public abstract void AuthoritySetShapeColors(JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, float PALJJNGJNBE);

		public abstract void AuthoritySetShapeDensities(float HJFGFKEEKJD);

		public abstract void AuthoritySetShapeTransforms(Guid[] LLIIKIDHHNE, Vector3[] CCNNFGHHAPH, Quaternion[] DKMOFMMKDPO, float[] JHKJFIMEHBF);

		public abstract void AuthoritySetUVOffset(Guid NBGOLMPJOHO, Vector3 LAECBPNMBIE);

		public abstract void AuthoritySetUVScale(Guid NBGOLMPJOHO, float PALJJNGJNBE);

		public abstract void AuthorityTransferShapesToShapeContainer(Guid[] LLIIKIDHHNE, BJIJHMNPDCH MOFGFAAHLIF);

		public abstract void AuthorityTransferShapeToShapeContainer(Guid GHLKBLAKLII, BJIJHMNPDCH MOFGFAAHLIF);

		public abstract bool AuthorityTrySetCurveShapeSettings(FCOHGGHPPMJ KJABCIOBNAM, out string NLJOHEKGNDH);

		public abstract bool AuthorityTrySetShapeConfigFlags(OPKFOPKNLMG PANELIGGJGM, out string NLJOHEKGNDH);

		public abstract void AuthorityUpdateCurveShapeControlPoint(Guid GHLKBLAKLII, int KEECNENCNBF, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI);

		public virtual bool CanMergeShapeContainer(BJIJHMNPDCH GKIDOJICBIB)
		{
			return false;
		}

		protected virtual bool PPKBICNAKMJ(BJIJHMNPDCH GKIDOJICBIB, CHILKDJABBF OJMKLBPAANP)
		{
			return false;
		}

		public abstract void RequestMasterMergeShapeContainer(BJIJHMNPDCH GKIDOJICBIB);

		public abstract bool CheckShapeOverlaps(int MPJGCPAKKKA, QueryTriggerInteraction BAMJBELIHBB, Func<Collider, bool> ALFMOBIEEKP = null);

		public abstract bool ContainsAnyShape(IEnumerable<Guid> LLIIKIDHHNE);

		public abstract bool ContainsShape(Guid GHLKBLAKLII);

		public abstract IDHANFFPOIF GetIConfigurableForSelection();

		public abstract IEnumerable<Tool> GetSelfAndChildTools();

		public abstract Guid GetShapeIdFromToolCollider(ToolCollider BIBMKDDMLFI);

		public abstract bool Hack_ContainsDuplicateShapeIds(BJIJHMNPDCH MFLHIFFMHAO);

		public abstract bool IsCurveCollision(Collider ADMCDJKKCIA);

		public abstract bool IsCurveShape(Guid GHLKBLAKLII);

		public static bool IsCurveShape(AMEPDCGKFOG LJGNKMONIGD)
		{
			return false;
		}

		public static bool IsPrimitiveShape(AMEPDCGKFOG LJGNKMONIGD)
		{
			return false;
		}

		public abstract void LocalAddShapesFromData(NCLIPFDBPBO OGBKIFBLMIO);

		public void LocalAddShapesFromData(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI, short AJMCKPPKOFJ)
		{
		}

		protected abstract void PLEOGDPBEJG(NCLIPFDBPBO OGBKIFBLMIO, short AJMCKPPKOFJ);

		public void MarkPositionRotationInvalid()
		{
		}

		public abstract void OnDeselectedByShapeCreationContext();

		public abstract void OnSelectedByShapeCreationContext();

		protected abstract void JLIJNNIGBBN(EEJKGDBGCCI PANELIGGJGM);

		public ShapeDataT GetShapeFromToolCollider(ToolCollider BIBMKDDMLFI)
		{
			return default;
		}

		public bool TryGetShapeFromToolCollider(ToolCollider BIBMKDDMLFI, ShapeContainerBase<ShapeDataT> BLFAKBHLAAJ, out ShapeDataT NBGOLMPJOHO)
		{
			NBGOLMPJOHO = default;
			return false;
		}

		private bool NJBDCCGNFDA(ToolCollider BIBMKDDMLFI, out object NBGOLMPJOHO)
		{
			NBGOLMPJOHO = null;
			return false;
		}

		bool BJIJHMNPDCH.CLFGAPFKFLM(ToolCollider BIBMKDDMLFI, out object NBGOLMPJOHO)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NJBDCCGNFDA
			return this.NJBDCCGNFDA(BIBMKDDMLFI, out NBGOLMPJOHO);
		}

		public abstract bool TryGetShapeFromToolCollider(ToolCollider BIBMKDDMLFI, out ShapeDataT NBGOLMPJOHO);

		protected abstract Guid CEEFLKLEBDI(ShapeDataT CEAJLCOCMNI);

		protected abstract ShapeDataT OLEEKDHIEMJ(Guid JMIFIJDBMNM);

		public void PostDeserialize(GNFJMCHKBIK ALCJDCGEBLM)
		{
		}

		protected void LDCAHLGANMI()
		{
		}

		public bool RaycastShapes(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, out Guid EGCFPFNOEEP, out Vector3 FELHKDHHAOE, BJIJHMNPDCH BLFAKBHLAAJ = null)
		{
			EGCFPFNOEEP = default;
			FELHKDHHAOE = default;
			return false;
		}

		public int SpherecastPickShapes(Vector3 EDGHCIEJHLG, float CHFEMIAABLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, Guid[] DLHNFMICGOE, out Vector3 FELHKDHHAOE, out Collider KKIFJDLKMKG, BJIJHMNPDCH BLFAKBHLAAJ = null)
		{
			FELHKDHHAOE = default;
			KKIFJDLKMKG = null;
			return 0;
		}

		public bool TryGetClosestCurveEndPoint(Vector3 NPNNIGADHKA, ref float DNHMCFAOEHB, ref Guid MGAFKIFDLPI)
		{
			return false;
		}

		public abstract bool TryGetClosestCurvePointInRay(Vector3 JAEGDHEEDEP, Vector3 KNGAEDPENOJ, ref float JNMBIEADIIH, ref float KEDBAELNJIE, ref Guid HGDPNJMPEHN, ref int GJEBMLHBHOH);

		public abstract bool TryGetCurveShapeControlPointCount(Guid GHLKBLAKLII, out int JHFKLKBDOLH);

		public abstract bool TryGetCurveShapeControlPointPositionRotationAndRadius(Guid GHLKBLAKLII, int KEECNENCNBF, out Vector3 NOOOJBNDGPN, out Quaternion DNEFKBEHEEC, out float NNLEGJGIGHA);

		public abstract bool TryGetEndControlPointInfoWorldSpace(Guid GHLKBLAKLII, ref Vector3 CDKEGFGDKMG, ref float NNLEGJGIGHA, ref Vector3 CHEKLLFMKBP, ref FCOHGGHPPMJ KJABCIOBNAM);

		public void RenderAsIgnored(Vector3 JOFBEGDENCK, Vector3 KGHKNCFKKMB, Vector3 OFKIOHHAEAC, float HNBOEPGMOJB, float EIGIKPJOLPF, IReadOnlyList<Camera> HFEBOPAJBLM, HGILLFNKECL MDILDPALOMC)
		{
		}

		public void RenderBatchedOutline(LMKFOACECEG IEMMIFODLAI)
		{
		}

		public void RenderSelection()
		{
		}

		public abstract void RenderShapeOutline(Guid GHLKBLAKLII, LMKFOACECEG IEMMIFODLAI);

		public void RenderWorldFadeMask()
		{
		}

		public abstract NCLIPFDBPBO SerializeShapes(NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

		public abstract NCLIPFDBPBO SerializeShapes(Guid[] LLIIKIDHHNE, NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

		public abstract NCLIPFDBPBO SerializeShapes(Guid[] LLIIKIDHHNE, out int INLJFENGAEE, NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

		public abstract NCLIPFDBPBO SerializeShapes(out int INLJFENGAEE, NCANNFMMHDJ OENDBGBGBDH = default(NCANNFMMHDJ));

		public abstract void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM);

		public virtual void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		private void NBKLEHOGHFI(NCLIPFDBPBO OCPGJKDDMPG)
		{
		}

		public abstract void SetLocalUniformScale(float PDNBMOJFPKO);

		public abstract bool TryGetPrimitiveShapeLocalScale(Guid GHLKBLAKLII, out Vector3 CAPKFCHDLFA);

		public abstract bool TryGetPrimitiveShapePosition(Guid GHLKBLAKLII, out Vector3 MDMGLACFCFC);

		public abstract ToolCollider TryGetShapeCollider(Guid GHLKBLAKLII);

		public abstract bool TryGetShapeWorldBounds(Guid GHLKBLAKLII, out Bounds DBPFJELGIGI);

		public abstract bool TryGetShapeMaterialInfo(Guid GHLKBLAKLII, out JLHLKDMLBPK LNBGDJLPKJM, out MJGMBIJIKFH APGHJHBHCFA, out float PALJJNGJNBE);

		public abstract bool TryGetShapeRotation(Guid GHLKBLAKLII, out Quaternion IENBPFILMGK);

		public abstract ShapeContainer.LEIOBPHGMAO GetCurveShape(Guid GHLKBLAKLII);

		public abstract NCANNFMMHDJ TryGetShapeTransform(Guid GHLKBLAKLII);

		public abstract bool TrySetValidPositionRotation(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH);

		private void OBBKCGLNPNA(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
		{
		}

		private void FFKFMMLDOPP(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
		{
		}

		private void AGEKLODBAND(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
		{
		}

		private void EJDFADJGKDH(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
		{
		}

		private void HKBEMEHEJNL(FBLAHKFEHNM LJFNCCMLIDM, OELBDAKHAFC FCJBDJOMIHI)
		{
		}
	}
}
