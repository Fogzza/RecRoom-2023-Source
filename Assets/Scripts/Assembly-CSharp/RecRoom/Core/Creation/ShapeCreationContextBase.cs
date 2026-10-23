using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using RecRoom.Core.Creation.Shapes;
using RecRoom.Core.Creation.UndoStack;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public abstract class ShapeCreationContextBase : MonoBehaviourPun, MMMPKIMPKKC, global::FNLEEFFPAAJ<Guid>, CAMIJPMLKOA, global::DDLEHONFEBP<Guid>, AINHEFJAEPG, global::EOCHBHDFJOM<Guid>, global::CJOLMILKEEG<Guid>, global::AIGGMOPIIKJ<Guid>, global::GLEADKGGNKA<Guid>, MAGMDAGMOMO, global::JMLHLJFACAP<Guid>, GJPBOMNOBND, BMHNAMLFPHB, AHAGBOCIINO, global::BAIMOJOCJOK<Guid>, global::ANEBEINLICG<Guid>, global::ONMIGJKMOIP<Guid>, global::BHDCFHIHABO<Guid>, global::LIKLLLAINCP<Guid>, global::ENDMHNLLGFN<Guid>, global::AGNNPIOFKPK<Guid>, global::JNKPGKLPGFB<Guid>, global::OCGHADNNOCP<Guid>
	{
		public struct NDCCKBBFHAH
		{
			public IONEOHGOAML CDNLFEOBNKB;

			public Guid PAFFNNDIBFA;

			public NDCCKBBFHAH(IONEOHGOAML CDNLFEOBNKB, Guid PAFFNNDIBFA)
			{
				this.CDNLFEOBNKB = IONEOHGOAML.Success;
				this.PAFFNNDIBFA = default;
			}
		}

		private sealed class LCBDMOAGMJF
		{
			public JLHLKDMLBPK color;

			public MJGMBIJIKFH material;

			public float uvScale;

			internal bool _003CRecRoom_002EMaker_002ECore_002EIMakerCommandReceiverRecolorContinuous_003CSystem_002EGuid_003E_002EExecuteUpdate_003Eb__0(EBLDPIPLLOP s)
			{
				return false;
			}

			internal bool _003CRecRoom_002EMaker_002ECore_002EIMakerCommandReceiverRecolorContinuous_003CSystem_002EGuid_003E_002EExecuteUpdate_003Eb__1(EBLDPIPLLOP s)
			{
				return false;
			}

			internal bool _003CRecRoom_002EMaker_002ECore_002EIMakerCommandReceiverRecolorContinuous_003CSystem_002EGuid_003E_002EExecuteUpdate_003Eb__2(EBLDPIPLLOP s)
			{
				return false;
			}
		}

		[SerializeField]
		protected CreationContext parentCreationContext;

		private int CBCGGLHDDDJ;

		private Guid GMMDEEEIACO;

		protected NNBAJLCGAOK JGEGKOOCOEH;

		private global::DAHHPCNLCBH<BJIJHMNPDCH> KELMOJGCCLA;

		private BJIJHMNPDCH NLPENMJCFNP;

		private global::DAHHPCNLCBH<KAHGNFIANNH> EFECPPDIOGC;

		protected KAHGNFIANNH LIJHENDMJKN;

		private bool HEOHFGCCOKO;

		private Bounds LPCFPPCOBCD;

		private int IEAGHGFHJII;

		private readonly Dictionary<Collider, DHJLEHBOGBG> PIMMJLIOMND;

		private const float IHKEDLEDFEA = 0.005f;

		private const int HGGGKIEIBCF = 20;

		private List<IReadOnlyCollection<Guid>> CPFPIEDOPFD;

		private EEANDDJEMJC ADANJAPHFKM;

		private EEANDDJEMJC JACCAJEFHMG;

		private EEANDDJEMJC GMNONLMMAAN;

		private EEANDDJEMJC GOKMHGBHLFB;

		private EEANDDJEMJC AAGFJAIHAMF;

		private EEANDDJEMJC AJAMDNODODB;

		private readonly object BNHHNOKBHKG;

		private GameObject IHFFIKGLODN;

		private FIHGBEHGLGB CGBDGKPEGNJ;

		private ECMNCNMENKO BGGNJDOOAOA;

		private ECMNCNMENKO PAJMKDIEGHG;

		[NonSerialized]
		private IBLPNKEDNHI KABCPNBMBOP;

public abstract BKAOBFNMILE CreationShapeContainer
{
get ;
}

public BJIJHMNPDCH SelectedShapeContainer
{
get 		{
			return null;
		}

set {
		}
}

protected KAHGNFIANNH PHHBKKMJJPF
{
get 		{
			return null;
		}

set {
		}
}

protected IReadOnlyList<Guid> HGEOAIHLJBP
{
get 		{
			return null;
		}

}

public Bounds SelectionBounds
{
get 		{
			return default;
		}

}

public Transform SelectionTransform
{
get 		{
			return null;
		}

}

public Vector3 SelectionPivot
{
get 		{
			return default;
		}

}

public float SelectionScale
{
get 		{
			return 0f;
		}

}

public float LocalSelectionScale
{
get 		{
			return 0f;
		}

}

public Bounds LocalSelectionBounds
{
get 		{
			return default;
		}

}

public Transform LocalSelectionTransform
{
get 		{
			return null;
		}

}

private bool HCEAOJFHFFN
{
get 		{
			return false;
		}

}

private RecRoom.Core.Creation.UndoStack.UndoStack KBHGOBDBKDP
{
get 		{
			return null;
		}

}

public bool HasSelection
{
get 		{
			return false;
		}

}

public int SelectionCount
{
get 		{
			return 0;
		}

}

public IEnumerable<Guid> CurrentSelection
{
get 		{
			return null;
		}

}

public int ShapeCount
{
get 		{
			return 0;
		}

}

public bool CanTranslateCurrentSelection
{
get 		{
			return false;
		}

}

public bool CanRotateCurrentSelection
{
get 		{
			return false;
		}

}

public bool CanScaleCurrentSelection
{
get 		{
			return false;
		}

}

public bool CanDeformCurrentSelection
{
get 		{
			return false;
		}

}

public bool CanCloneCurrentSelection
{
get 		{
			return false;
		}

}

public bool CanMirrorCurrentSelection
{
get 		{
			return false;
		}

}

public bool WorldAxisActive
{
get 		{
			return false;
		}

}

public bool RotateAroundPivot
{
get 		{
			return false;
		}

}

public bool RotateInPlace
{
get 		{
			return false;
		}

}

public bool ScaleInPlace
{
get 		{
			return false;
		}

}

public bool HasSelectedShapeContainer
{
get 		{
			return false;
		}

}

public bool IsEmpty
{
get 		{
			return false;
		}

}

public bool IsOverCostLimit
{
get 		{
			return false;
		}

}

private int OOFFMECKCFN
{
get 		{
			return 0;
		}

}

private int GBFILNMIGGH
{
get 		{
			return 0;
		}

}

public EEANDDJEMJC ShapeCreationStarted
{
get 		{
			return null;
		}

set {
		}
}

public EEANDDJEMJC ShapeCreationFinished
{
get 		{
			return null;
		}

set {
		}
}

public EEANDDJEMJC CurveCreationStarted
{
get 		{
			return null;
		}

set {
		}
}

public EEANDDJEMJC CurveCreationFinished
{
get 		{
			return null;
		}

set {
		}
}

public EEANDDJEMJC SelectionChangedEvent
{
get 		{
			return null;
		}

set {
		}
}

public EEANDDJEMJC SelectedShapeContainerChangedEvent
{
get 		{
			return null;
		}

set {
		}
}

private bool LPLPPHKJION
{
get 		{
			return false;
		}

}

 Transform global::MMMPKIMPKKC.transform
{
get 		{
			return null;
		}

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

		private void INDLPMJADEO()
		{
		}

		private void APDJIPNLIFB(BJIJHMNPDCH MOFGFAAHLIF)
		{
		}

		private void CHDHDODNIIO(BJIJHMNPDCH MOFGFAAHLIF)
		{
		}

		private void MOELLABOMJM()
		{
		}

		private void DLHLIEOAKOP(DHJLEHBOGBG ICHBECDKHOJ, bool FPMKKJKAHFN)
		{
		}

		protected void PDMPODFPEPG()
		{
		}

		private void JNLPNJGFDPK()
		{
		}

		public IReadOnlyDictionary<Collider, DHJLEHBOGBG> GetSelectionCollidersMap()
		{
			return null;
		}

		public virtual bool Raycast(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, out Guid DLHNFMICGOE, out Vector3 FELHKDHHAOE, out Collider KKIFJDLKMKG)
		{
			DLHNFMICGOE = default;
			FELHKDHHAOE = default;
			KKIFJDLKMKG = null;
			return false;
		}

		public virtual int SpherecastPick(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float NNLEGJGIGHA, float GKJHODLJDHD, Guid[] DLHNFMICGOE, out Vector3 FELHKDHHAOE, out Collider KKIFJDLKMKG)
		{
			FELHKDHHAOE = default;
			KKIFJDLKMKG = null;
			return 0;
		}

		public virtual int SpherePick(Vector3 EDGHCIEJHLG, float NNLEGJGIGHA, Vector3 IMOPEMBMCBM, Guid[] LDOJHNNMHGI)
		{
			return 0;
		}

		public bool IsSelected(Guid GHLKBLAKLII)
		{
			return false;
		}

		public bool AnySelected(IEnumerable<Guid> LLIIKIDHHNE)
		{
			return false;
		}

		public void StartSelectionChanges()
		{
		}

		public void FinishSelectionChanges()
		{
		}

		public bool AddAllToSelection()
		{
			return false;
		}

		public bool AddToSelection(Guid GHLKBLAKLII)
		{
			return false;
		}

		public bool AddToSelection(int JPOFFMMPKDI, Guid[] LLIIKIDHHNE)
		{
			return false;
		}

		public void RemoveFromSelection(Guid GHLKBLAKLII)
		{
		}

		public void RemoveAllFromSelection()
		{
		}

		public bool IsSelectable(Guid NBGOLMPJOHO)
		{
			return false;
		}

		protected void DNKKBCECMDE(bool ICPDKJCJLHA = false)
		{
		}

		public void RenderHoverHighlight(int JPOFFMMPKDI, IEnumerable<Guid> IHLJHIFFNPM, bool CNDNAIPCEGH = true)
		{
		}

		public void RenderHoverHighlight(Guid GHLKBLAKLII, LMKFOACECEG? IEMMIFODLAI = null, bool CNDNAIPCEGH = true)
		{
		}

		public void RenderHoverHighlight(int JPOFFMMPKDI, IEnumerable<Guid> IHLJHIFFNPM, LMKFOACECEG IEMMIFODLAI, bool CNDNAIPCEGH = true)
		{
		}

		public void OnSelectionPickedUp()
		{
		}

		public void OnSelectionReleased()
		{
		}

		public void StartScalingSelection()
		{
		}

		public bool ScaleSelection(float LJCAHLAFIEP, Vector3? CDOJOBEAINO = null)
		{
			return false;
		}

		public bool DeformSelectionInDirection(Vector3 LKBBJDNDCBM, float LJCAHLAFIEP, Vector3 CDOJOBEAINO, bool DKOFNPIFHPG)
		{
			return false;
		}

		public bool IsLoneShapeContainer(out Guid ELLOCGLOCEB, out ShapeContainer MOFGFAAHLIF)
		{
			ELLOCGLOCEB = default;
			MOFGFAAHLIF = null;
			return false;
		}

		public void FinishScalingSelection()
		{
		}

		public void TrySetPreviousCloneMapping(Dictionary<Guid, Guid> COCAFFCAMKK)
		{
		}

		public void DisableSelectionObjectColliders()
		{
		}

		public LAHBDKNMNHN CloneSelectionAndSelect(CreationContext.IMHJKLGAICO LBINIIAEHLF)
		{
			return null;
		}

		public IReadOnlyCollection<Guid> CacheCurrentSelection()
		{
			return null;
		}

		public void SetSelectionFromCache(IReadOnlyCollection<Guid> MGGAFPGBPKK)
		{
		}

		public void BufferCurrentSelection()
		{
		}

		public bool SetSelectionFromBuffer(Guid NBGOLMPJOHO)
		{
			return false;
		}

		public virtual ECMNCNMENKO CreateTransformationUndoEntry(string IEACNHGAIIE, IEnumerable<Guid> AAGLHJMICLO, bool LPEJLGKLDAG = false, bool NNAINJOHEAG = false, bool HNNFDAHEOHI = false)
		{
			return null;
		}

		public virtual ECMNCNMENKO CreateCloneUndoEntry()
		{
			return null;
		}

		public abstract DHJLEHBOGBG ToCreationContextObject(Guid ICHBECDKHOJ);

		public abstract Guid FromCreationContextObject(DHJLEHBOGBG ICHBECDKHOJ);

		public void AuthorityHandleRoomPersistenceStart()
		{
		}

		private void OnPhotonPlayerDisconnected(CHILKDJABBF EKOFNPFCLMO)
		{
		}

		private void MLDJHCNGKBO()
		{
		}

		public virtual void AuthorityHandleRoomPersistenceComplete()
		{
		}

		protected abstract global::NCOKFFGPIJM<BJIJHMNPDCH> HEGKHDGNINK();

		public bool CanSelectedContainerAffordResourceCost(int PNNCCFDIMEP)
		{
			return false;
		}

		private bool ANCJBLBKGCB(int JPECHJIJOJL)
		{
			return false;
		}

		public bool CanAffordToAddShapes(BJIJHMNPDCH IFLPNPBKNBA, int JPECHJIJOJL)
		{
			return false;
		}

		public bool CanAffordNewShapeContainer(JBGFOIKBKED IDHLGPDCLCM, int JPECHJIJOJL)
		{
			return false;
		}

		public void CheckNotifyResourceLimits()
		{
		}

		public virtual global::NCOKFFGPIJM<BJIJHMNPDCH> CreateAndSelectShapeContainer()
		{
			return null;
		}

		private void PCOJKPLPHAM(IEnumerable<Guid> CMHFANCIOPG, bool LOFEDLIEEJD)
		{
		}

		public void DeselectShapeContainer()
		{
		}

		private void CHONHILINIG(bool ACDDBKAELFK)
		{
		}

		public void FinishShape(bool ACDDBKAELFK)
		{
		}

		public IDHANFFPOIF GetConfigurableForShapeSelection()
		{
			return null;
		}

		public IEnumerable<ToolCollider> GetSelectionToolColliders()
		{
			return null;
		}

		public void LockOwnershipToLocalPlayer()
		{
		}

		public NCLIPFDBPBO SerializeSelectedShapes()
		{
			return null;
		}

		public NCLIPFDBPBO SerializeSelectedShapes(out int INLJFENGAEE)
		{
			INLJFENGAEE = default;
			return null;
		}

		public NCLIPFDBPBO SerializeShapesIncludingSelected(BJIJHMNPDCH MOFGFAAHLIF, Guid[] IHLJHIFFNPM)
		{
			return null;
		}

		public NCLIPFDBPBO SerializeShapesIncludingSelected(BJIJHMNPDCH MOFGFAAHLIF, Guid[] IHLJHIFFNPM, out int IKOAEBAPFIB)
		{
			IKOAEBAPFIB = default;
			return null;
		}

		public void SetSelectedPrimitiveShapeAspectRatios(Guid[] LLIIKIDHHNE, Vector3[] GNCLNCEBLHE)
		{
		}

		public bool SetSelectedShapeTransforms(Guid[] LLIIKIDHHNE, Vector3[] CCNNFGHHAPH, Quaternion[] DKMOFMMKDPO, float[] JHKJFIMEHBF)
		{
			return false;
		}

		protected virtual void Update()
		{
		}

		public void ShouldHideOriginVisualizer(bool IMGEJEOIKBO, object IALNODEHBNN)
		{
		}

		private void JPHLNPNHHIH()
		{
		}

		public bool TryAddAndSelectShapesInSelectedShapeContainer(NCLIPFDBPBO CEAJLCOCMNI, int JPECHJIJOJL)
		{
			return false;
		}

		public IONEOHGOAML TryCloneSelectedShapes(CreationContext.IMHJKLGAICO LBINIIAEHLF)
		{
			return IONEOHGOAML.Success;
		}

		protected bool JDGOPGLIDEF(BJIJHMNPDCH KFBGELLDGDM, BJIJHMNPDCH GOKOGHPIFHF, Guid GHLKBLAKLII)
		{
			return false;
		}

		protected void HEGENLMAODF()
		{
		}

		protected void EHGIKNGIHHG()
		{
		}

		public NDCCKBBFHAH TryCreateAndSelectCurveShapeInSelectedShapeContainer(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 PEJEOHJJKBA, Quaternion JMDALKJDKBF, float JFJMKFBANPE, FCOHGGHPPMJ KJABCIOBNAM, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM)
		{
			return default;
		}

		public NDCCKBBFHAH TryCreateAndSelectPrimitiveShapeInSelectedShapeContainer(AMEPDCGKFOG NIFOGEBEDNG, JLHLKDMLBPK HMCAFGCGFJF, MJGMBIJIKFH PMPDPBDKGPF, Vector3 PEJEOHJJKBA, Quaternion JMDALKJDKBF, Vector3 OILBNELDHCP, float PALJJNGJNBE, Vector3 LAECBPNMBIE, OPKFOPKNLMG PANELIGGJGM)
		{
			return default;
		}

		public IONEOHGOAML TryAddSelectedCurveShapeControlPoint(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool HGDCBEGLPDO, bool ANMENIMHEBE)
		{
			return IONEOHGOAML.Success;
		}

		public void UpdateSelectedCurveShapeFirstControlPoint(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI)
		{
		}

		public bool TryGetClosestCurveEndPoint(Vector3 NPNNIGADHKA, float KEDBAELNJIE, out Guid MGAFKIFDLPI)
		{
			MGAFKIFDLPI = default;
			return false;
		}

		public bool TryGetEndControlPointInfoWorldSpace(Guid GHLKBLAKLII, out Vector3 CDKEGFGDKMG, out float NNLEGJGIGHA, out Vector3 CHEKLLFMKBP, out FCOHGGHPPMJ KJABCIOBNAM)
		{
			CDKEGFGDKMG = default;
			NNLEGJGIGHA = default;
			CHEKLLFMKBP = default;
			KJABCIOBNAM = default;
			return false;
		}

		public bool TryGetSelectedClosestCurvePointInRay(Vector3 JAEGDHEEDEP, Vector3 KNGAEDPENOJ, out Guid NBGOLMPJOHO, out int GMEHLIHLGEH)
		{
			NBGOLMPJOHO = default;
			GMEHLIHLGEH = default;
			return false;
		}

		public bool TryGetSelectedCurvePointPositionRotationAndRadius(Guid GHLKBLAKLII, int GMEHLIHLGEH, out Vector3 BAGMHHCMNNF, out Quaternion DNEFKBEHEEC, out float NNLEGJGIGHA)
		{
			BAGMHHCMNNF = default;
			DNEFKBEHEEC = default;
			NNLEGJGIGHA = default;
			return false;
		}

		public bool TryGetSelectedCurveShapeFirstControlPointPosition(out Vector3 NOOOJBNDGPN)
		{
			NOOOJBNDGPN = default;
			return false;
		}

		public bool TryGetSelectedCurveShapePreviousControlPointInfo(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float NNLEGJGIGHA)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
			NNLEGJGIGHA = default;
			return false;
		}

		public bool TryGetSelectedCurveShapeLastPointInfo(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float NNLEGJGIGHA)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
			NNLEGJGIGHA = default;
			return false;
		}

		private bool PODGOELLCAB(int CCJNAAEEOHA, out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float NNLEGJGIGHA)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
			NNLEGJGIGHA = default;
			return false;
		}

		public bool TryGetSelectedPrimitiveShapeAspectRatio(out Vector3 CAPKFCHDLFA)
		{
			CAPKFCHDLFA = default;
			return false;
		}

		public bool TryGetSelectedPrimitiveShapePosition(out Vector3 INLGLHIPOMC)
		{
			INLGLHIPOMC = default;
			return false;
		}

		public Transform TryGetSelectedPrimitiveShapeTransform()
		{
			return null;
		}

		public bool TryGetShapeRotation(Guid GHLKBLAKLII, out Quaternion IENBPFILMGK)
		{
			IENBPFILMGK = default;
			return false;
		}

		public ShapeContainer.LEIOBPHGMAO GetCurveShape(Guid GHLKBLAKLII)
		{
			return null;
		}

		public bool TrySelectShapeContainer(BJIJHMNPDCH MOFGFAAHLIF)
		{
			return false;
		}

		private bool HMLGEFJOOFO(BJIJHMNPDCH MOFGFAAHLIF)
		{
			return false;
		}

		public bool TrySetCurvePointPositionRotationAndRadius(Guid GHLKBLAKLII, int GMEHLIHLGEH, Vector3 BAGMHHCMNNF, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI)
		{
			return false;
		}

		public abstract global::NCOKFFGPIJM<BJIJHMNPDCH> TrySplitSelectedShapes();

		private bool ABEBGMENFDA(Guid GHLKBLAKLII)
		{
			return false;
		}

		private bool FKPFMEPGIFO(Guid GHLKBLAKLII)
		{
			return false;
		}

		private void MIOKCIPINCD(Guid GHLKBLAKLII)
		{
		}

		protected void AGGBFAEAJBN(BJIJHMNPDCH IHOGCBJHHFL)
		{
		}

		public void UpdateSelectedCurveShapeLatestControlPoint(Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float NNLEGJGIGHA, bool BCFPNBDFMEI)
		{
		}

		public void UpdateSelectedPrimitiveShapeAspectRatio(Vector3 GDMKKLNFDOP, bool BCFPNBDFMEI)
		{
		}

		private IONEOHGOAML MMNPMIJMHGJ(IONEOHGOAML CDNLFEOBNKB, string PEOLHGGDCPN)
		{
			return IONEOHGOAML.Success;
		}

		private IONEOHGOAML HCFPJNONKBK()
		{
			return IONEOHGOAML.Success;
		}

		private bool OCPAOBOALNO(in global::DNMKBCIPELF<Guid> LCCJICGEEAF)
		{
			return false;
		}

		bool global::CJOLMILKEEG<Guid>.EKOHPOJALAF(in global::DNMKBCIPELF<Guid> LCCJICGEEAF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OCPAOBOALNO
			return this.OCPAOBOALNO(in LCCJICGEEAF);
		}

		private void FMJPGCPHFFK(in global::DNMKBCIPELF<Guid> LCCJICGEEAF)
		{
		}

		void global::CJOLMILKEEG<Guid>.EDOHPNELGIN(in global::DNMKBCIPELF<Guid> LCCJICGEEAF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FMJPGCPHFFK
			this.FMJPGCPHFFK(in LCCJICGEEAF);
		}

		private void ACAAOMKAJMC(in bool LOFEDLIEEJD)
		{
		}

		void global::CJOLMILKEEG<Guid>.MJEMOBIJDMF(in bool LOFEDLIEEJD)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ACAAOMKAJMC
			this.ACAAOMKAJMC(in LOFEDLIEEJD);
		}

		private bool BHDCHNDBJGI(in global::DNMKBCIPELF<Guid> LCCJICGEEAF)
		{
			return false;
		}

		bool global::CJOLMILKEEG<Guid>.OLHOGMOIBOL(in global::DNMKBCIPELF<Guid> LCCJICGEEAF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BHDCHNDBJGI
			return this.BHDCHNDBJGI(in LCCJICGEEAF);
		}

		private void DIJBADDJPGP()
		{
		}

		void global::CJOLMILKEEG<Guid>.HODDDECDLPM()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DIJBADDJPGP
			this.DIJBADDJPGP();
		}

		private bool BNCLGLMBKHH(in Guid DDGPLGMGCML)
		{
			return false;
		}

		bool global::CJOLMILKEEG<Guid>.HHNNECOGAMB(in Guid DDGPLGMGCML)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BNCLGLMBKHH
			return this.BNCLGLMBKHH(in DDGPLGMGCML);
		}

		private void DKFFMKLLAGI(in global::ECCACJMFPMK<Guid> IHADBGDLJKA)
		{
		}

		void global::ENDMHNLLGFN<Guid>.DPINEAANGIG(in global::ECCACJMFPMK<Guid> IHADBGDLJKA)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DKFFMKLLAGI
			this.DKFFMKLLAGI(in IHADBGDLJKA);
		}

		private bool NGMIINPODNE(in global::PCDAGPAILFA<Guid> CIIIHKEOONE)
		{
			return false;
		}

		bool global::ANEBEINLICG<Guid>.EJFONCHDJDL(in global::PCDAGPAILFA<Guid> CIIIHKEOONE)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NGMIINPODNE
			return this.NGMIINPODNE(in CIIIHKEOONE);
		}

		private bool ELHLINOMEJK(in global::CGNKLPAGFJA<Guid> CIIIHKEOONE)
		{
			return false;
		}

		bool global::ONMIGJKMOIP<Guid>.MLBHJGMBJKO(in global::CGNKLPAGFJA<Guid> CIIIHKEOONE)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ELHLINOMEJK
			return this.ELHLINOMEJK(in CIIIHKEOONE);
		}

		private bool NDEEMNNJLNP(in OKEOHOJLDAN KPKMBKGABJJ)
		{
			return false;
		}

		bool global::ONMIGJKMOIP<Guid>.KIPLFFJJIJB(in OKEOHOJLDAN KPKMBKGABJJ)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NDEEMNNJLNP
			return this.NDEEMNNJLNP(in KPKMBKGABJJ);
		}

		private bool DFJNEOCHDJA()
		{
			return false;
		}

		bool global::ONMIGJKMOIP<Guid>.FKLKKKDHFHM()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DFJNEOCHDJA
			return this.DFJNEOCHDJA();
		}

		private bool FGCFCCNKJME(IEnumerable<Guid> AAGLHJMICLO, bool LOFEDLIEEJD)
		{
			return false;
		}

		private bool CMHDLHEAAJI(Vector3 INLGLHIPOMC)
		{
			return false;
		}

		private bool ONODADJALDM()
		{
			return false;
		}

		private bool KHKCFDMLLHA(in global::LJAAKHJNKPD<Guid> LDDCLBPOGGK)
		{
			return false;
		}

		bool global::BHDCFHIHABO<Guid>.EJFONCHDJDL(in global::LJAAKHJNKPD<Guid> LDDCLBPOGGK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KHKCFDMLLHA
			return this.KHKCFDMLLHA(in LDDCLBPOGGK);
		}

		private bool CAMNKFDEPMO(in global::BMPBIHEKJDL<Guid> LDDCLBPOGGK)
		{
			return false;
		}

		bool global::LIKLLLAINCP<Guid>.MLBHJGMBJKO(in global::BMPBIHEKJDL<Guid> LDDCLBPOGGK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CAMNKFDEPMO
			return this.CAMNKFDEPMO(in LDDCLBPOGGK);
		}

		private bool GJONNGMKCPB(in GGDPKIJKHJD LDDCLBPOGGK)
		{
			return false;
		}

		bool global::LIKLLLAINCP<Guid>.KIPLFFJJIJB(in GGDPKIJKHJD LDDCLBPOGGK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GJONNGMKCPB
			return this.GJONNGMKCPB(in LDDCLBPOGGK);
		}

		private bool INMALPHCFKA()
		{
			return false;
		}

		bool global::LIKLLLAINCP<Guid>.FKLKKKDHFHM()
		{
			//ILSpy generated this explicit interface implementation from .override directive in INMALPHCFKA
			return this.INMALPHCFKA();
		}

		private bool HNPDNOKDPML(IEnumerable<Guid> AAGLHJMICLO, bool LOFEDLIEEJD)
		{
			return false;
		}

		private bool MGMPBAKKNDA(Quaternion HFKOEBDLFJD, Vector3? CDOJOBEAINO, bool GFAKJHENEEM)
		{
			return false;
		}

		private bool HCHHKBMMAJN()
		{
			return false;
		}

		private bool LJBONPBKGOB(in global::OEIICBOPOEH<Guid> FOIJJNFCPFH)
		{
			return false;
		}

		bool global::AGNNPIOFKPK<Guid>.KIPLFFJJIJB(in global::OEIICBOPOEH<Guid> FOIJJNFCPFH)
		{
			//ILSpy generated this explicit interface implementation from .override directive in LJBONPBKGOB
			return this.LJBONPBKGOB(in FOIJJNFCPFH);
		}

		private void DPNNJKFPCHP()
		{
		}

		void global::AGNNPIOFKPK<Guid>.FKLKKKDHFHM()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DPNNJKFPCHP
			this.DPNNJKFPCHP();
		}

		private bool DOBECCKOKHO(in global::ADAJLIPOFKI<Guid> FOIJJNFCPFH)
		{
			return false;
		}

		bool global::JNKPGKLPGFB<Guid>.EJFONCHDJDL(in global::ADAJLIPOFKI<Guid> FOIJJNFCPFH)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DOBECCKOKHO
			return this.DOBECCKOKHO(in FOIJJNFCPFH);
		}

		private void FLFJIOELOAG(in global::KJDDMCPOILH<Guid> FOIJJNFCPFH)
		{
		}

		void global::OCGHADNNOCP<Guid>.EJFONCHDJDL(in global::KJDDMCPOILH<Guid> FOIJJNFCPFH)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FLFJIOELOAG
			this.FLFJIOELOAG(in FOIJJNFCPFH);
		}

		protected void KNFGMPIDPLL(Guid[] LLIIKIDHHNE, JLHLKDMLBPK FMHCCJDJFBA, MJGMBIJIKFH LLMJGJOEMPP, float PALJJNGJNBE)
		{
		}

		protected void KNFGMPIDPLL(Guid[] LLIIKIDHHNE, JLHLKDMLBPK[] IEHHIPOJDBG, MJGMBIJIKFH[] IAPNMPFINIK, float[] IKJDCOHDDIP)
		{
		}

		[CompilerGenerated]
		private void JMDDKOEAMIJ()
		{
		}

		[CompilerGenerated]
		private void HPNAHKABFLC(BJIJHMNPDCH FMPHDMAKDKP)
		{
		}
	}
}
