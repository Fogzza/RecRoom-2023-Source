using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RecRoom.CircuitsV2.Adapter;
using RecRoom.CircuitsV2.Config;
using RecRoom.CircuitsV2.Experience;
using RecRoom.Core.Creation;
using RecRoom.Core.Creation.CircuitsV1;
using RecRoom.Core.Creation.Tags;
using RecRoom.Tools;
using RecRoom.Tools.MakerPenTools;
using Unity.Serialization;
using UnityEngine;

namespace RecRoom.CircuitsV2
{
	public sealed class Chip : MonoBehaviour, DHJLEHBOGBG, JGLPGIIHGIM, JKKPILGMECP, MGPMJALOCBB, AKBNDDCCILB, FHOCFMCHHJF, MPEMFIPALDL, HFCCIAENGHB, NADHPLMICLB, MJJLJOABJIP, PEJNMGDGGAF, KJGJNBDHLED, HGNMOPCBKOI, FKFAGIFPJAE, BAJJBGMMMFA, BANEAOEMGBA, LKJAJFEHDDD, MHDKIPJKDBC, BKPFMIKGFKP, GOHLPMEFMDL.EJCKFNMCGAM, DJLCHGFCFAD, DFBGLPCFOHL
	{
		private sealed class NEOJHFJEKBO : AHCBMDMIAAM
		{
			private Chip JKCDKDCLIFD;

public bool PJAJGNFHPGD
{
get 			{
				return false;
			}

}

public AHCBMDMIAAM ParentGroup
{
get 			{
				return null;
			}

}

private IEnumerable<Chip> HCEBMHBEDBJ
{
get 			{
				return null;
			}

}

public IEnumerable<DHJLEHBOGBG> ObjectsInGroup
{
get 			{
				return null;
			}

}

public bool IncludeChildrenInTemplate
{
get 			{
				return false;
			}

}

public bool SupportsExtractingToParent
{
get 			{
				return false;
			}

}

			public NEOJHFJEKBO(Chip JJMNDCAFBDA)
			{
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

		private sealed class DKNCMCHKFCO
		{
			public HEJEFJABMHN circuitsViewDependencies;

			public Chip _003C_003E4__this;

			public ChipConfig chipConfig;

			internal DMJBOMHHBIJ _003CSetPorts_003Eb__0(IAFGPKMBMBF i)
			{
				return null;
			}
		}

		public const string CHIP_CONTEXT_PARAM_KEY = "v2con";

		public const string CHIP_NODE_PARAM_KEY = "v2cn";

		public const string COLOR_PROPERTY_ID = "Color";

		[SerializeField]
		private Transform tetherPoint;

		[SerializeField]
		private ChipView chipView;

		[SerializeField]
		private List<Renderer> highlightRenderers;

		public DisableObjectWhenManuallyHiddenOrCircuitsHidden DisableComponent;

		private static int JCEJDPDJGGL;

		private int KODKNCCMMJB;

		private bool LEFFGFMGCAP;

		private JHEMPDCLIFL BMAGPLLMLEJ;

		private bool NLEMMEKMEEJ;

		private readonly ChipConfigMenu CLDEPPMAICM;

		private NEOJHFJEKBO IIOAHOCEMAL;

		private HEJEFJABMHN JHGMCLBDPMP;

		private CCFFIDBNKOF HBBGPGMEPLC;

		private readonly object KIMLLPFBANA;

		private IReadOnlyList<DMJBOMHHBIJ> BIOJEIAJEGA;

		private Action OGKKFGCCKED__BackingField;

		[DontSerialize]
		public bool isVisibleInCamera;

		[DontSerialize]
		public AMBBOEBJPNH updateLOD;

		private LKGILLBEJEK GNMPDGLOGLC;

		private ConfigurableSubpiece HLPNONLNOFB;

		private CommentMakerPenPinInfo NGOPHKGPOFO;

		private BusConfigButton EFBNHNNEBJN;

		private bool ONCNLPAAGMJ;

		private Action<DHJLEHBOGBG> MEGLBPAPJFE__BackingField;

		private FIHGBEHGLGB FMOFIALFFHO;

		private Action<DHJLEHBOGBG> NEOJCLBPMLI__BackingField;

		private bool OIMGIEPBNDO;

		private bool MJBHDNFPBHN;

		[HideInInspector]
		[SerializeField]
		private ChipEditorProps editorProps;

		[SerializeField]
		private MockTypeAdapter newPortType;

		private PCOCEPINJKE GEELFKBGELJ;

		private static readonly PFOKMDIIIPA.MPADAPGBBII[] KMNDAGHAGDM;

		private readonly List<HEMJMJGHPIC> PFKAMPKCAEJ;

		private readonly List<JPFPJMOEEDB> DKFBEMPBNMJ;

		private readonly List<NMIHEFDDLJI> MKPDMIEFOEP;

public bool IsContainer
{
get 		{
			return false;
		}

}

public BOALOIBLNEO ObjectBoard
{
get 		{
			return null;
		}

}

public DHJLEHBOGBG ObjectBoardTarget
{
get 		{
			return null;
		}

}

public Transform TetherPoint
{
get 		{
			return null;
		}

}

internal int DBOKIKPKJEC
{
set {
		}
}

public JHEMPDCLIFL VisibilitySettings
{
get 		{
			return JHEMPDCLIFL.None;
		}

}

public ChipView ChipView
{
get 		{
			return null;
		}

}

public bool VisibleInScope
{
get 		{
			return false;
		}

}

public bool IsLockedByRoomOwners
{
get 		{
			return false;
		}

}

public bool IsLockedForLocalPlayer
{
get 		{
			return false;
		}

}

public CCFFIDBNKOF Adapter
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsObjectBoard
{
get 		{
			return false;
		}

}

public IReadOnlyList<DMJBOMHHBIJ> ChipGroups
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsPreviewObject
{
get 		{
			return false;
		}

}

public bool BlockObjectPersistance
{
get 		{
			return false;
		}

}

public GKDCHLMLHBJ RunDeserializationFor
{
get 		{
			return GKDCHLMLHBJ.RunForAuthorityOnly;
		}

}

		[DontSerialize]

public bool IsVisible
{
get 		{
			return false;
		}

}

public bool InScope
{
get 		{
			return false;
		}

}

public BusConfigButton BusConfigButton
{
get 		{
			return null;
		}

}

public string UniqueSynchronizedFieldKey
{
get 		{
			return null;
		}

}

public GameObject GameObject
{
get 		{
			return null;
		}

}

public IEnumerable<Collider> SelectionColliders
{
get 		{
			return null;
		}

}

public BoxCollider SelectionBoundsOverride
{
get 		{
			return null;
		}

}

public bool UsesSelectionBoundsOverride
{
get 		{
			return false;
		}

}

public Guid Guid
{
get 		{
			return default;
		}

}

public string Name
{
get 		{
			return null;
		}

}

public string Title
{
get 		{
			return null;
		}

}

public Vector3 WorldPosition
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 LocalPosition
{
get 		{
			return default;
		}

set {
		}
}

public Quaternion WorldRotation
{
get 		{
			return default;
		}

set {
		}
}

public Quaternion LocalRotation
{
get 		{
			return default;
		}

set {
		}
}

public float WorldUniformScale
{
get 		{
			return 0f;
		}

set {
		}
}

public float LocalUniformScale
{
get 		{
			return 0f;
		}

set {
		}
}

public Vector3 WorldDeformationScale
{
get 		{
			return default;
		}

set {
		}
}

public Vector3 LocalDeformationScale
{
get 		{
			return default;
		}

set {
		}
}

public DHJLEHBOGBG Parent
{
get 		{
			return null;
		}

}

public bool DynamicCollisionEnabled
{
get 		{
			return false;
		}

set {
		}
}

public NLOGLNAFFOA InventionPiece
{
get 		{
			return null;
		}

}

public IDHANFFPOIF Configurable
{
get 		{
			return null;
		}

}

public bool UsesLegacyUndo
{
get 		{
			return false;
		}

}

public CostInfo SandboxResourceCost
{
get 		{
			return default;
		}

}

public bool CanSaveIntoInventions
{
get 		{
			return false;
		}

}

public bool AlwaysCountCost
{
get 		{
			return false;
		}

set {
		}
}

public bool IsFrozen
{
get 		{
			return false;
		}

set {
		}
}

public bool CanEditWithMakerPen
{
get 		{
			return false;
		}

}

public Tool Tool
{
get 		{
			return null;
		}

}

public int SelectionPriority
{
get 		{
			return 0;
		}

}

private KLNOBKBCIEK JOACDLLOGLN
{
get 		{
			return KLNOBKBCIEK.AG_EVERYONE;
		}

}

public GKGPHHHJLML SynchedLock
{
get 		{
			return null;
		}

}

public FIHGBEHGLGB ShouldPersistWhenDestroyingAllFlag
{
get 		{
			return null;
		}

private set {
		}
}

public bool SupportsScaling
{
get 		{
			return false;
		}

}

public bool ScalingRestricted
{
get 		{
			return false;
		}

}

public Vector3 MinScalingRestriction
{
get 		{
			return default;
		}

}

public Vector3 MaxScalingRestriction
{
get 		{
			return default;
		}

}

public bool SupportsDeformation
{
get 		{
			return false;
		}

}

public bool SupportsMirroring
{
get 		{
			return false;
		}

}

public bool SupportsRecoloring
{
get 		{
			return false;
		}

}

public bool SupportsCloning
{
get 		{
			return false;
		}

}

public bool SupportsRotation
{
get 		{
			return false;
		}

}

public bool CanDestroy
{
get 		{
			return false;
		}

}

public bool SupportsCustomEditControls
{
get 		{
			return false;
		}

}

public bool SupportsRespawn
{
get 		{
			return false;
		}

}

public bool SupportsMerging
{
get 		{
			return false;
		}

}

public bool SupportsSplitting
{
get 		{
			return false;
		}

set {
		}
}

public bool SupportsKeys
{
get 		{
			return false;
		}

}

public Type BulkDeleteHandlerType
{
get 		{
			return null;
		}

}

public object BulkDeleteObject
{
get 		{
			return null;
		}

}

public Guid BulkDeletableId
{
get 		{
			return default;
		}

}

public ref ChipEditorProps EditorProps
{
get 		{
			throw null;
		}

}

public static string NameOfEditorProps
{
get 		{
			return null;
		}

}

public MockTypeAdapter NewPortType
{
get 		{
			return null;
		}

}

 IEnumerable<PFOKMDIIIPA.MPADAPGBBII> global::FKFAGIFPJAE.NavMeshSupportRestrictions
{
get 		{
			return null;
		}

}

 bool global::BAJJBGMMMFA.IsAnimated
{
get 		{
			return false;
		}

}

 bool global::LKJAJFEHDDD.IsGrabbable
{
get 		{
			return false;
		}

set {
		}
}

public ObjectGroup OwningGroup
{
get 		{
			return null;
		}

set {
		}
}

public TaggedEntity TaggedEntity
{
get 		{
			return null;
		}

}

public bool TaggableProviderPresent
{
get 		{
			return false;
		}

}

 Transform global::DFBGLPCFOHL.transform
{
get 		{
			return null;
		}

}

public event Action OnAdapterDestroyed {
add {
		}
remove {
		}
}

public event Action<bool> FrozenChangedEvent {
add {
		}
remove {
		}
}

public event Action ObjectScaled {
add {
		}
remove {
		}
}

public event Action<DHJLEHBOGBG> LockStatusChangeEvent {
add {
		}
remove {
		}
}

public event Action<DHJLEHBOGBG> OnCreationObjectWillDelete {
add {
		}
remove {
		}
}

 event Action global::BAJJBGMMMFA.AnimatedStatusChanged {
add {
		}
remove {
		}
}

		public void IsScopeRootChanged(bool JIOGPCBICOJ)
		{
		}

		private bool NOLKIFHOPBO(in Vector3 EDGHCIEJHLG, in Vector3 HLFIBIDOLEF, ref Vector3 BBOLIJMGKDH, ref Vector3 CHEKLLFMKBP)
		{
			return false;
		}

		bool MHDKIPJKDBC.BOGNPBBACOL(in Vector3 EDGHCIEJHLG, in Vector3 HLFIBIDOLEF, ref Vector3 BBOLIJMGKDH, ref Vector3 CHEKLLFMKBP)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NOLKIFHOPBO
			return this.NOLKIFHOPBO(in EDGHCIEJHLG, in HLFIBIDOLEF, ref BBOLIJMGKDH, ref CHEKLLFMKBP);
		}

		public void SetVisibilitySettings(JHEMPDCLIFL HBEFMGDLBFD)
		{
		}

		private void AHABDCHNEAE()
		{
		}

		public void SetVisibility(bool BMGEHFPFCBJ, object MIOEMFMADHO)
		{
		}

		public void OMSetVisibilityInScope(bool MJDICEJIFLK)
		{
		}

		private void IBEECEBEKHM(bool MKBJCOECDLI, bool NBMFHFHOICC)
		{
		}

		private void LEOGMHAOEKN(bool BMGEHFPFCBJ)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OKGMAPGPPPJ()
		{
		}

		public void Bind(HEJEFJABMHN ELCLBJBCJFB, CCFFIDBNKOF AECGBKJAICN)
		{
		}

		private void HMBNJDPGAJN()
		{
		}

		public void Unbind(bool FFMPCEFMNIN = false)
		{
		}

		private void ODJOJKDGFEH(CCFFIDBNKOF AECGBKJAICN)
		{
		}

		private void NBDBDONPHGP()
		{
		}

		private void LJKCLKAKLNL()
		{
		}

		private void IGKEDIGCNNO()
		{
		}

		private void NKDKFCJKOKJ(CCFFIDBNKOF JJMNDCAFBDA)
		{
		}

		private void BJGKBLKHFEI(CCFFIDBNKOF JJMNDCAFBDA)
		{
		}

		private IFCBCACOLMJ LKKAHDOMAEK(GGHECEJBHPI DELCOFCGDFF, params object[] BHOKKEBBPNA)
		{
			return null;
		}

		private void MPAGDCFIFOK()
		{
		}

		private void JJANKMPOGHC(int GADDGJANIGG, DGNNDGAENKL GOAGPPCPBIA)
		{
		}

		private void APEDBOJMHEM(int GADDGJANIGG)
		{
		}

		private void HIKBKOPKKIC(int GMEHLIHLGEH, IAFGPKMBMBF JHHODALFFAO)
		{
		}

		private void IHJIGNDJPPK(int GADDGJANIGG)
		{
		}

		private void FMMLDLCBDEF(int GADDGJANIGG, IAFGPKMBMBF JHHODALFFAO)
		{
		}

		private void AIHFJODMLBF()
		{
		}

		private void JJKJCACBEGO()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void KNMDEPDLDIM()
		{
		}

		private void ONPMJABJJOE(HEJEFJABMHN ELCLBJBCJFB, CCFFIDBNKOF JJMNDCAFBDA, ChipConfig KILCCDFGMGN)
		{
		}

		private static BusConfigButton ACJHMDIDIMK(BusConfigButton HHDMPJJAPJJ)
		{
			return null;
		}

		private static void GAAJOHPGPDF(BusConfigButton JGPJAPOKBHN)
		{
		}

		private void JFJGCICIEGN(CircuitsV2Config DJOEDCPNAOE, CCFFIDBNKOF AECGBKJAICN, ChipConfig KILCCDFGMGN)
		{
		}

		private void HLKOKMMLNLG()
		{
		}

		private void DLABDMINBDC()
		{
		}

		public void DeserializeFrom(NLOGDCDGECD FFILBGADKKN)
		{
		}

		public void SerializeTo(ref OELBDAKHAFC FCJBDJOMIHI, ref JMLPLALIKGL JIEECFLEPDI, StringBuilder AAMCGPPJPFM)
		{
		}

		private void ILKNLAHDPHC(in MPDEOEGEEIC FJDPKNPNDDO)
		{
		}

		private void KKBMNMIMGHB(in HIAGCLNJBPN CPOKLKIGKAG)
		{
		}

		public bool CanUpdateDeformation(Vector3 JMAKKPDDJFK, float MCNOMGBOOJI, float MKGJNLNNAKO)
		{
			return false;
		}

		public void UpdateDeformation(Vector3 JMAKKPDDJFK, float MCNOMGBOOJI)
		{
		}

		public bool CanBeRaycasted(Collider ADMCDJKKCIA)
		{
			return false;
		}

		public void TransferOwnership(int LFKIHFDBJNI)
		{
		}

		public Task RequestMasterDespawn()
		{
			return null;
		}

		public void RenderSelection(PPKCAMHKMLL? LIHCICHMNHE)
		{
		}

		public void RenderOutline(LMKFOACECEG? IEMMIFODLAI)
		{
		}

		public void RenderWorldFadeMask()
		{
		}

		public Bounds GetWorldBounds()
		{
			return default;
		}

		public PBJALJMOJOB GetRotatedBounds()
		{
			return null;
		}

		public IONEOHGOAML CanBeSelected()
		{
			return IONEOHGOAML.Success;
		}

		public bool CanBeSelected(out IONEOHGOAML PEJNHHBEBPH, out CHILKDJABBF CGKHDFHDBBP)
		{
			PEJNHHBEBPH = default;
			CGKHDFHDBBP = null;
			return false;
		}

		public IONEOHGOAML CanPerformUndoRedoOnObject()
		{
			return IONEOHGOAML.Success;
		}

		public void GetTransformationDataForUndoRedo(out Vector3 INLGLHIPOMC, out Quaternion HEGBBJCMANH, out float PDNBMOJFPKO, out Vector3 IGMDHMAILAN)
		{
			INLGLHIPOMC = default;
			HEGBBJCMANH = default;
			PDNBMOJFPKO = default;
			IGMDHMAILAN = default;
		}

		public void SetTransformationDataForUndoRedo(Vector3? INLGLHIPOMC, Quaternion? HEGBBJCMANH, float? PDNBMOJFPKO, Vector3? IGMDHMAILAN)
		{
		}

		public CHILKDJABBF GetCulprit(IONEOHGOAML KEHFEFMDBHI)
		{
			return null;
		}

		public AHCBMDMIAAM AsGroup()
		{
			return null;
		}

		public void LocalPlayerTakeAuthority()
		{
		}

		public void RegisterConfigurablePiece(ConfigurableSubpiece OLAHJEEGADB)
		{
		}

		public void UnregisterConfigurablePiece(ConfigurableSubpiece OLAHJEEGADB)
		{
		}

		public ConfigurableSubpiece GetConfigurableSubpiece(Collider ADMCDJKKCIA)
		{
			return null;
		}

		public void Translate(Vector3 FDHEPLEOFLI)
		{
		}

		public void Rotate(Quaternion INFCJCBKCCF)
		{
		}

		public bool Scale(float LJCAHLAFIEP)
		{
			return false;
		}

		public Task DeleteAsync()
		{
			return null;
		}

		public void SetCustomEditControls(MakerPen BHCCDMJFHEO, FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public void OnCreatedBySpawning()
		{
		}

		public void OnSelected()
		{
		}

		public void OnTranslationStart()
		{
		}

		public void OnRotationStart()
		{
		}

		public void OnScaleStart()
		{
		}

		public void OnDeformStart()
		{
		}

		public void OnMoveStart()
		{
		}

		public void OnTranslated()
		{
		}

		public void OnRotated()
		{
		}

		public void OnScaled()
		{
		}

		public void OnDeformed(Vector3 BEEINBKHHBI)
		{
		}

		public void OnTranslationFinished()
		{
		}

		public void OnRotationFinished()
		{
		}

		public void OnScaleFinished()
		{
		}

		public void OnDeformationFinished()
		{
		}

		public void OnMoveFinished()
		{
		}

		public void OnDeselected()
		{
		}

		public void OnHoverStart(FBEHJNCKJPN CIMCLAFMGFE, Collider LPGAJGPGKFM)
		{
		}

		public void OnHovering(FBEHJNCKJPN CIMCLAFMGFE, Collider LPGAJGPGKFM)
		{
		}

		public void OnHoverFinished(FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		private Vector3 LCPDFPOHDML()
		{
			return default;
		}

		private Vector3 BAHDAMOLEPP(Vector3 JKKAKJBFOKN)
		{
			return default;
		}

		private Vector3 NGFLFICAHGC(Vector3 DKMLNFLKGFN)
		{
			return default;
		}

		private Quaternion FLJJICLGKMK(Quaternion LLJPMBHCKEE)
		{
			return default;
		}

		private void OnValidate()
		{
		}

		public void ResetPosition()
		{
		}

		public void RaiseLockChangedEvent()
		{
		}

		public void AddPropertyHandler(string IDBLFHOOMPH, PCOCEPINJKE.NBEMBFBLMBB ODEFKCPHGJD)
		{
		}

		public void RemovePropertyHandler(string IDBLFHOOMPH, PCOCEPINJKE.NBEMBFBLMBB ODEFKCPHGJD)
		{
		}

		public ECMNCNMENKO ModifyProperty(GGHECEJBHPI DELCOFCGDFF, string IDBLFHOOMPH, params object[] HMJOKPKOPCN)
		{
			return null;
		}

		public bool CanModifyProperty(string OPCKJKNEHGA)
		{
			return false;
		}

		public void OnChangedDistanceBand(AMBBOEBJPNH MOCEBLJHGPF, AMBBOEBJPNH ELOPMNNDIJD)
		{
		}

		public void OnChangedVisibility(bool GMEKKCPLMOB)
		{
		}

		private void HBKFNAFCAFK(PFOKMDIIIPA.MPADAPGBBII NHJPBHJLFOD)
		{
		}

		void FKFAGIFPJAE.AddNavMeshSupportRestriction(PFOKMDIIIPA.MPADAPGBBII NHJPBHJLFOD)
		{
			//ILSpy generated this explicit interface implementation from .override directive in HBKFNAFCAFK
			this.HBKFNAFCAFK(NHJPBHJLFOD);
		}

		private void BLABDHEOOPJ(PFOKMDIIIPA.MPADAPGBBII NHJPBHJLFOD)
		{
		}

		void FKFAGIFPJAE.RemoveNavMeshSupportRestriction(PFOKMDIIIPA.MPADAPGBBII NHJPBHJLFOD)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BLABDHEOOPJ
			this.BLABDHEOOPJ(NHJPBHJLFOD);
		}

		private void FNNOJAABJAP(object IALNODEHBNN)
		{
		}

		void BAJJBGMMMFA.AddIsAnimated(object IALNODEHBNN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FNNOJAABJAP
			this.FNNOJAABJAP(IALNODEHBNN);
		}

		private void MLHJFDJONHN(object IALNODEHBNN)
		{
		}

		void BAJJBGMMMFA.RemoveIsAnimated(object IALNODEHBNN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MLHJFDJONHN
			this.MLHJFDJONHN(IALNODEHBNN);
		}

		private BJIJHMNPDCH JFAGJPHLCLB(Collider ADMCDJKKCIA)
		{
			return null;
		}

		BJIJHMNPDCH DHJLEHBOGBG.GetShapeContainerForCollider(Collider ADMCDJKKCIA)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JFAGJPHLCLB
			return this.JFAGJPHLCLB(ADMCDJKKCIA);
		}

		private void INBNKNHPGGO(Func<Collider, BJIJHMNPDCH> GOIOJEGDINC)
		{
		}

		void DHJLEHBOGBG.SetShapeContainerForColliderGetter(Func<Collider, BJIJHMNPDCH> GOIOJEGDINC)
		{
			//ILSpy generated this explicit interface implementation from .override directive in INBNKNHPGGO
			this.INBNKNHPGGO(GOIOJEGDINC);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void AddTransformChangedListener(HEMJMJGHPIC NFCDBEKMGLP)
		{
		}

		public void RemoveTransformChangedListener(HEMJMJGHPIC NFCDBEKMGLP)
		{
		}

		private void DBIMGCFABDM()
		{
		}

		public void AddEnabledChangedListener(JPFPJMOEEDB NFCDBEKMGLP)
		{
		}

		public void RemoveEnabledChangedListener(JPFPJMOEEDB NFCDBEKMGLP)
		{
		}

		private void EKGMMEIOEEI(bool EPDJDCDHLMP)
		{
		}

		public void AddVisibilityScopeChangedListener(NMIHEFDDLJI NFCDBEKMGLP)
		{
		}

		public void RemoveVisibilityScopeChangedListener(NMIHEFDDLJI NFCDBEKMGLP)
		{
		}

		private void HHINPIILPFA(bool MJDICEJIFLK)
		{
		}

		[CompilerGenerated]
		private void NJAODJPBIFK()
		{
		}

		[CompilerGenerated]
		internal static LMKFOACECEG OAJLKNPCHJC(LMKFOACECEG? LEDDIKLLHHE)
		{
			return LMKFOACECEG.Hover;
		}
	}
}
