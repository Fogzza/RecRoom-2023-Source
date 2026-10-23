using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using JetBrains.Annotations;
using Photon.Pun;
using RecRoom.Core.Creation.Shapes;
using RecRoom.Core.Creation.UndoStack;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class CreationContext : MonoBehaviourPun, GGHECEJBHPI, global::FNLEEFFPAAJ<DHJLEHBOGBG>, CAMIJPMLKOA, global::DDLEHONFEBP<DHJLEHBOGBG>, AINHEFJAEPG, global::EOCHBHDFJOM<DHJLEHBOGBG>, global::CJOLMILKEEG<DHJLEHBOGBG>, global::AIGGMOPIIKJ<DHJLEHBOGBG>, global::GLEADKGGNKA<DHJLEHBOGBG>, MAGMDAGMOMO, global::JMLHLJFACAP<DHJLEHBOGBG>, GJPBOMNOBND, global::JNKPGKLPGFB<DHJLEHBOGBG>, global::BAIMOJOCJOK<DHJLEHBOGBG>, global::ANEBEINLICG<DHJLEHBOGBG>, global::ONMIGJKMOIP<DHJLEHBOGBG>, global::BHDCFHIHABO<DHJLEHBOGBG>, global::LIKLLLAINCP<DHJLEHBOGBG>, global::ENDMHNLLGFN<DHJLEHBOGBG>, CPNECPMDBEG, ALECMBNCDLJ, global::HJIKCMILJMA<DHJLEHBOGBG>
	{
		public delegate void DFIEIMNFHNC(IONEOHGOAML CDNLFEOBNKB, string PEOLHGGDCPN, DHJLEHBOGBG GLHOACNHHMF, JDCIJIEOFOL FOILEMDKKCC);

		public class IMHJKLGAICO
		{
			public readonly Vector3 MAGKPHJKDAG;

			public readonly Vector3 JPBOBPIHNBD;

			public IMHJKLGAICO(Transform LBINIIAEHLF)
			{
			}

			public IMHJKLGAICO(Vector3 CHEKLLFMKBP, Vector3 INLGLHIPOMC)
			{
			}
		}

		private sealed class GBJGHBJMLGB
		{
			private sealed class _003C_003CSetSelectionBoundsDirty_003Eg__Coroutine_007C1_003Ed : IEnumerator<object>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private object _003C_003E2__current;

				public GBJGHBJMLGB _003C_003E4__this;

				object IEnumerator<object>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CSetSelectionBoundsDirty_003Eg__Coroutine_007C1_003Ed(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			public bool dirtyLocalBounds;

			public CreationContext _003C_003E4__this;

			public int frameCount;

			internal void _003CSetSelectionBoundsDirty_003Eg__SetSelectionBoundsDirtyImmediately_007C0()
			{
			}

			internal IEnumerator _003CSetSelectionBoundsDirty_003Eg__Coroutine_007C1()
			{
				return null;
			}
		}

		private sealed class GBLBNBMOJHH
		{
			public CreationContext _003C_003E4__this;

			public Vector3 position;

			internal void _003CCreateObject_003Eb__1(Tool tool)
			{
			}
		}

		private sealed class GLHEIGCCCME
		{
			public global::NCOKFFGPIJM<Tool> toolPromise;

			internal global::NCOKFFGPIJM<Tool> _003CCreateObject_003Eb__2()
			{
				return null;
			}
		}

		private sealed class KHMGEPMGGJG
		{
			public CreationManager.ALEFKNOEIAL result;

			public CreationContext _003C_003E4__this;

			public List<DHJLEHBOGBG> objectsToClone;

			public IMHJKLGAICO mirror;

			internal LAHBDKNMNHN _003CCloneSelectionAndSelectWithResult_003Eb__1(CreationManager.ALEFKNOEIAL spawnResult)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<CreationManager.ALEFKNOEIAL> _003CCloneSelectionAndSelectWithResult_003Eb__2()
			{
				return null;
			}
		}

		private sealed class AGHEJHEOPBK
		{
			public CreationManager.ALEFKNOEIAL spawnResult;

			public KHMGEPMGGJG CS_0024_003C_003E8__locals1;

			internal LAHBDKNMNHN _003CCloneSelectionAndSelectWithResult_003Eb__3()
			{
				return null;
			}
		}

		private sealed class LODFMJIMCGF : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public CreationManager.ALEFKNOEIAL data;

			public IMHJKLGAICO mirror;

			public CreationContext _003C_003E4__this;

			public List<DHJLEHBOGBG> sourceObjects;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public LODFMJIMCGF(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private sealed class MFOOLBAPKOG
		{
			private sealed class _003C_003CValidateSpawnResultAndSelect_003Eg__WaitForValidSelection_007C0_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public MFOOLBAPKOG _003C_003E4__this;

				private Tool[] _003CspawnedTools_003E5__2;

				private int _003CframeCount_003E5__3;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CValidateSpawnResultAndSelect_003Eg__WaitForValidSelection_007C0_003Ed(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			public CreationManager.ALEFKNOEIAL spawnResult;

			public CreationContext _003C_003E4__this;

			internal IEnumerator<EGGPGCCKPCO> _003CValidateSpawnResultAndSelect_003Eg__WaitForValidSelection_007C0()
			{
				return null;
			}
		}

		private sealed class DOPBIFLFGNM
		{
			private sealed class _003C_003CPostProcessSpawnResult_003Eg__FinishSpawn_007C1_003Ed : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public DOPBIFLFGNM _003C_003E4__this;

 EGGPGCCKPCO global::System.Collections.Generic.IEnumerator<global::EGGPGCCKPCO>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CPostProcessSpawnResult_003Eg__FinishSpawn_007C1_003Ed(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				private EGGPGCCKPCO System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002EISchedule_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			public CreationContext _003C_003E4__this;

			public Action<Vector3> onSuccess;

			internal LAHBDKNMNHN _003CPostProcessSpawnResult_003Eb__0()
			{
				return null;
			}

			internal IEnumerator<EGGPGCCKPCO> _003CPostProcessSpawnResult_003Eg__FinishSpawn_007C1()
			{
				return null;
			}
		}

		private sealed class ELNGKKMGJOK
		{
			public BJIJHMNPDCH destContainer;

			public CreationContext _003C_003E4__this;

			public IReadOnlyList<BJIJHMNPDCH> containersToMerge;

			public global::PHLHFLLLDLK<bool> promise;

			internal void _003CTryMergeShapeSelection_003Eb__1(ODPHMCBLPNJ.OIKOMAFBJDC result)
			{
			}

			internal void _003CTryMergeShapeSelection_003Eb__2(string error)
			{
			}
		}

		private sealed class LMFCIFODOGL
		{
			public global::PHLHFLLLDLK<GAMIBKOFAAE> promise;

			internal void _003CSerializeSelection_003Eb__0(CreationManager.BFEKGCMDJNM result)
			{
			}

			internal void _003CSerializeSelection_003Eb__1(string e)
			{
			}
		}

		private sealed class OGKCIEGNHAK
		{
			public CreationContext _003C_003E4__this;

			public MJGMBIJIKFH newMaterial;

			internal void _003CQueueChangedMaterialEvent_003Eb__0()
			{
			}
		}

		private sealed class FJPGAFGBIBM
		{
			public Dictionary<Guid, bool> objectBoardDict;

			internal bool _003CEvaluateObjectPreventingDelete_003Eb__0(DHJLEHBOGBG cp)
			{
				return false;
			}
		}

		private sealed class NDGANJBIMEJ
		{
			public bool cachedUndoable;

			public FEKBKFLHKFG undoEntry;

			public List<DHJLEHBOGBG> cachedTargets;

			public CreationContext _003C_003E4__this;

			public AHCBMDMIAAM cachedActiveGroup;

			internal void _003CRecRoom_002EMaker_002ECore_002EIMakerCommandReceiverDelete_003CRecRoom_002ECore_002ECreation_002EICreationContextObject_003E_002EExecuteDelete_003Eb__0(GAMIBKOFAAE spawnableTemplate)
			{
			}

			internal void _003CRecRoom_002EMaker_002ECore_002EIMakerCommandReceiverDelete_003CRecRoom_002ECore_002ECreation_002EICreationContextObject_003E_002EExecuteDelete_003Eb__1()
			{
			}
		}

		public static readonly List<CreationContext> AllContexts;

		public const float MIN_SCALE_SIZE = 0.01f;

		public const float MAX_SCALE_SIZE = 1000f;

		private const int INLOOCGCINL = 5;

		private const int APKEHIPELOB = 10;

		[SerializeField]
		private ShapeCreationContextSelector shapeCreationContextSelector;

		[SerializeField]
		private ConnectionCreationContext connectableCreationContext;

		private List<DHJLEHBOGBG> DBDDPALKCCD;

		private List<AHCBMDMIAAM> JOLODPEOPOG;

		private NNBAJLCGAOK JGEGKOOCOEH;

		private HLNFDOBEGJO CHABDOLEEMD;

		private CAGEHBIELJJ ICGKILJKGKA;

		private bool OGKCOCJMIPE;

		private bool HGAJMBDLMFP;

		private bool ADCLMGIHBIK;

		private bool PIBIBJKMCFC;

		private bool JDCLHPPNJAK;

		private bool CGHGEHGEALP;

		private bool MNLKIGCDMHK;

		private bool JIBCCJGJBNM;

		private bool OOFOANGDKIM;

		private bool HHOEMIBPNOG;

		private bool GGLCKKDHLGN;

		private bool BHAEKNIGOCI;

		private bool EIMOOEJPLGI;

		private bool ADPKGIHNEGO;

		private readonly object MFAAIKJMEBA;

		private readonly object JACAJEPLIAJ;

		private readonly object ILKKMFMMOAL;

		private int LCCALGFHDFH;

		private DHJLEHBOGBG DIJHODEJMDH;

		public static JJKLEAMOPMO ObjectClipboard;

		public static BBDAPJGONDD ColorableClipboard;

		private Queue<DHJLEHBOGBG> BPFMNKNGGKL;

		private Dictionary<Guid, Guid> CFANNGCIBKM;

		private Dictionary<Guid, Guid> NKEBCCDFJLP;

		private Guid[] LGLJGPOLLEN;

		private LKGILLBEJEK NPANMDNBHJF;

		private LKGILLBEJEK JKAIODPEANM;

		public global::HHOBPMOCKMJ<Vector3> SelectionCloned;

		public global::HHOBPMOCKMJ<Vector3> Pasted;

		public EEANDDJEMJC SelectionDeleted;

		public global::HHOBPMOCKMJ<Vector3> ObjectCreated;

		public global::BPEPJJDICII<Transform, Vector3> ObjectPickedUp;

		public global::HHOBPMOCKMJ<Vector3> ObjectReleased;

		public global::BPEPJJDICII<Transform, Vector3> TranslationStarted;

		public EEANDDJEMJC TranslationFinished;

		public global::BPEPJJDICII<Transform, Vector3> RotationStarted;

		public EEANDDJEMJC RotationFinished;

		public global::BPEPJJDICII<Transform, Vector3> SelectionScalingStarted;

		public EEANDDJEMJC SelectionScalingFinished;

		public EEANDDJEMJC SelectionChangedColor;

		public global::HHOBPMOCKMJ<MJGMBIJIKFH> SelectionChangedMaterial;

		public global::HHOBPMOCKMJ<bool> FrozenCommandOccurredStatus;

		private readonly EEANDDJEMJC AAGFJAIHAMF;

		private readonly EEANDDJEMJC GLNCLJNLMHF;

		private bool IPIGEDMMCIF;

		private bool OFEOCDFBLII;

		private Bounds DICPPFLGFCH;

		private bool NODEHNIPMMI;

		private JNODIIINKKJ.IGACCMOLGBK IDMKEPNIJDF;

		private DFIEIMNFHNC JJMALMNIDOF__BackingField;

		public global::BPEPJJDICII<DHJLEHBOGBG, bool> OnSelectionChanged;

		private readonly global::HHOBPMOCKMJ<DHJLEHBOGBG> NEDNEDCIMMA;

		private readonly global::HHOBPMOCKMJ<DHJLEHBOGBG> COMBMLPMDIC;

		public global::HHOBPMOCKMJ<Vector3> HoverHighlightStarted;

		private Dictionary<Collider, DHJLEHBOGBG> PIMMJLIOMND;

		private List<DHJLEHBOGBG> ACDOIKJDDPN;

		private ECMNCNMENKO BGGNJDOOAOA;

		private List<DHJLEHBOGBG> EIEIBDMIHFK;

		private ECMNCNMENKO PAJMKDIEGHG;

		private Dictionary<DHJLEHBOGBG, Vector3> AMMMFDFPBMO;

		private DHJLEHBOGBG HBBMDIGGHEP;

		private static readonly string IJBFGIEABIM;

		private const int HGGGKIEIBCF = 20;

		private List<IReadOnlyCollection<Guid>> CPFPIEDOPFD;

		[SerializeField]
		private WireframeCube selectionBoundsPrefab;

		private WireframeCube FGHKKOKKOHA;

		private readonly FIHGBEHGLGB NEPDMGBFBJE;

		[SerializeField]
		private Color containerSelectionColor;

		[SerializeField]
		private Color pivotSelectionColor;

		[SerializeField]
		private Color leafSelectionColor;

		private readonly CancellationTokenSource HMHGCNBJGDN;

		private bool AFEHGFBEGLI;

		private Bounds LPCFPPCOBCD;

public Behaviour AsBehaviour
{
get 		{
			return null;
		}

}

public new JDCIJIEOFOL owner
{
get 		{
			return null;
		}

}

public CAGEHBIELJJ ConnectedGizmoSelectionManager
{
get 		{
			return null;
		}

private set {
		}
}

public EEANDDJEMJC SelectionChangedEvent
{
get 		{
			return null;
		}

}

public EEANDDJEMJC ActiveGroupChangedEvent
{
get 		{
			return null;
		}

}

public MMMPKIMPKKC ShapeCreationContext
{
get 		{
			return null;
		}

}

public ConnectionCreationContext ConnectionCreationContext
{
get 		{
			return null;
		}

}

public AHCBMDMIAAM ActiveGroup
{
get 		{
			return null;
		}

}

public bool HasActiveGroup
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

public bool ShouldRenderWorldFadeMask
{
get 		{
			return false;
		}

set {
		}
}

public bool AllowInsideObjectRayCast
{
get 		{
			return false;
		}

set {
		}
}

public Bounds SelectionBounds
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

public JNODIIINKKJ.IGACCMOLGBK ObjectsGrabbableOnCreate
{
get 		{
			return JNODIIINKKJ.IGACCMOLGBK.Off;
		}

set {
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

public bool CanScopeIn
{
get 		{
			return false;
		}

}

public bool CanScopeOut
{
get 		{
			return false;
		}

}

public bool CanMerge
{
get 		{
			return false;
		}

}

public bool CanBreak
{
get 		{
			return false;
		}

}

public bool CanSplitToRoom
{
get 		{
			return false;
		}

}

public bool CanSplitToParent
{
get 		{
			return false;
		}

}

public bool CanCenterPivot
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

private RecRoom.Core.Creation.UndoStack.UndoStack KBHGOBDBKDP
{
get 		{
			return null;
		}

}

public global::HHOBPMOCKMJ<DHJLEHBOGBG> OnObjectTransformed
{
get 		{
			return null;
		}

}

public global::HHOBPMOCKMJ<DHJLEHBOGBG> OnSelectionDeformed
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

public bool HasCreationObjectSelection
{
get 		{
			return false;
		}

}

public bool SupportsCenterPivotOperation
{
get 		{
			return false;
		}

}

public IEnumerable<DHJLEHBOGBG> CurrentSelection
{
get 		{
			return null;
		}

}

public IEnumerable<CreationObject> CurrentSelectionAsCreationObjects
{
get 		{
			return null;
		}

}

public DHJLEHBOGBG LastSelectedObject
{
get 		{
			return null;
		}

private set {
		}
}

 int global::AIGGMOPIIKJ<global::DHJLEHBOGBG>.SelectionCount
{
get 		{
			return 0;
		}

}

 IEnumerable<DHJLEHBOGBG> global::AIGGMOPIIKJ<global::DHJLEHBOGBG>.CurrentSelection
{
get 		{
			return null;
		}

}

public CancellationToken CancellationToken
{
get 		{
			return default;
		}

}

public Bounds LocalSelectionBounds
{
get 		{
			return default;
		}

}

public float LocalSelectionScale
{
get 		{
			return 0f;
		}

}

public Transform LocalSelectionTransform
{
get 		{
			return null;
		}

}

public event DFIEIMNFHNC OnCreationContextError {
add {
		}
remove {
		}
}

		public void SetSelectionBoundsDirty(bool OBBEGECCGCB = true, int MDJFLDPILCI = 0)
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void KKLPIHLNNIJ(DBJMAFIOFFK JCNEOMGJFBL, DBJMAFIOFFK APOPENKHGDL)
		{
		}

		private static void HIMGBACNCPJ()
		{
		}

		private void LateUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void GNGNNMCOJHK()
		{
		}

		private void KJLECEOAKMP()
		{
		}

		private void LOJBCNDAGKM(CreationObject EADCAOLPGIH)
		{
		}

		public GNPJIJFFLAA CanAffordObject(JBGFOIKBKED CKEPLIBLBFJ, out CostInfo PNNCCFDIMEP)
		{
			PNNCCFDIMEP = default;
			return GNPJIJFFLAA.Success;
		}

		public GNPJIJFFLAA CanAffordObject(JBGFOIKBKED CKEPLIBLBFJ)
		{
			return GNPJIJFFLAA.Success;
		}

		public global::NCOKFFGPIJM<Tool> CreateObject(JBGFOIKBKED CKEPLIBLBFJ, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO)
		{
			return null;
		}

		public bool ShouldCreateGrabbableObject(DHJLEHBOGBG BPEGJLIMPPJ)
		{
			return false;
		}

		public bool Raycast(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float GKJHODLJDHD, out DHJLEHBOGBG PBKOJJOJGMB, out Vector3 HJODBKHINKL, out Collider LPGAJGPGKFM)
		{
			PBKOJJOJGMB = null;
			HJODBKHINKL = default;
			LPGAJGPGKFM = null;
			return false;
		}

		private DHJLEHBOGBG GBLDJBLCGIJ(Collider DHNNLHJMKIH, float LHKDJHNNIBM)
		{
			return null;
		}

		private static DHJLEHBOGBG LHALFKBIIIH(Collider ADMCDJKKCIA, AHCBMDMIAAM CIFHMNKCLNG)
		{
			return null;
		}

		public int SpherecastPick(Vector3 EDGHCIEJHLG, Vector3 HLFIBIDOLEF, float CHFEMIAABLG, float GKJHODLJDHD, DHJLEHBOGBG[] FKMOAEBJBGP, out Vector3 FELHKDHHAOE, out Collider KKIFJDLKMKG)
		{
			FELHKDHHAOE = default;
			KKIFJDLKMKG = null;
			return 0;
		}

		public int SpherePick(Vector3 EDGHCIEJHLG, float NNLEGJGIGHA, Vector3 IMOPEMBMCBM, DHJLEHBOGBG[] LDOJHNNMHGI)
		{
			return 0;
		}

		public bool IsSelected(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		public bool SetSelection(int MNKGPEKFPKK, params DHJLEHBOGBG[] JNCAMPHBDNO)
		{
			return false;
		}

		public bool AddToSelection(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		public bool AddToSelection(int NFHBKPDBBIM, DHJLEHBOGBG[] GLPABBNKNEO)
		{
			return false;
		}

		public void RemoveFromSelection(DHJLEHBOGBG GLHOACNHHMF)
		{
		}

		public void RemoveAllFromSelection()
		{
		}

		public IReadOnlyDictionary<Collider, DHJLEHBOGBG> GetSelectionCollidersMap()
		{
			return null;
		}

		public IEnumerable<DHJLEHBOGBG> GetCurrentSelectionForTemplate()
		{
			return null;
		}

		private static void OCLPLPKFNJE(DHJLEHBOGBG BMDDJIDADKN, [NotNull] HashSet<DHJLEHBOGBG> HIFJGPDGJFA)
		{
		}

		public bool PushActiveGroup(AHCBMDMIAAM AEKLOPBONLG)
		{
			return false;
		}

		public void PopActiveGroup()
		{
		}

		public void PopAllActiveGroups()
		{
		}

		public void RenderHoverHighlight(DHJLEHBOGBG ICHBECDKHOJ, LMKFOACECEG? IEMMIFODLAI = null, bool CNDNAIPCEGH = true)
		{
		}

		public void RenderHoverHighlight(int NIBKEGDHNIO, IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO, bool CNDNAIPCEGH = true)
		{
		}

		public void RenderHoverHighlight(int NIBKEGDHNIO, IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO, LMKFOACECEG IEMMIFODLAI, bool CNDNAIPCEGH = true)
		{
		}

		private void BKKGOODCIDG(int NIBKEGDHNIO, IEnumerable<DHJLEHBOGBG> JNCAMPHBDNO, LMKFOACECEG? IEMMIFODLAI = null, bool CNDNAIPCEGH = true)
		{
		}

		public void OnSelectionPickedUp()
		{
		}

		public void OnSelectionReleased()
		{
		}

		public void UpdateHoverHighlightEvents(Vector3 JNILFCGDIHB, bool JLDJNNHCIEE)
		{
		}

		private bool OHJCLOALIMA(DHJLEHBOGBG HHFDFFDPCGO, DHJLEHBOGBG KPDGHDGLMHO)
		{
			return false;
		}

		private bool FLFLECAHCHN(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		private bool DKAHMJBFMOB(DHJLEHBOGBG GHMCGNBNLJN, List<DHJLEHBOGBG> GLPABBNKNEO)
		{
			return false;
		}

		public void StartScalingSelection()
		{
		}

		public bool ScaleSelection(float LJCAHLAFIEP, Vector3? CDOJOBEAINO = null)
		{
			return false;
		}

		private bool GFEJNIEOPCH(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		private bool KMHONLEBKKO(float LJCAHLAFIEP, DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		public bool DeformSelectionInDirection(Vector3 JMAKKPDDJFK, float LJCAHLAFIEP, Vector3 CDOJOBEAINO, bool DKOFNPIFHPG)
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

		private void CPBPLPOOEKJ(List<DHJLEHBOGBG> AAGLHJMICLO)
		{
		}

		public void SetObjectTransformations(Guid[] CEAJEFGGINJ, Vector3[] ODFEKFPHMMP, Quaternion[] HBBDCGHEPNC, float[] DKJGMECNBHL, Dictionary<Guid, Vector3> KFDIOMHMMGE)
		{
		}

		private bool MICALKBGDMG(global::GFEGMOFKLEN<DHJLEHBOGBG> EGOMBNOFBCH)
		{
			return false;
		}

		public bool CanCloneRepeat()
		{
			return false;
		}

		public Dictionary<Guid, Guid> GetPreviousCloneMapping()
		{
			return null;
		}

		public void TrySetPreviousCloneMapping(Dictionary<Guid, Guid> JKLENFFMHAP)
		{
		}

		private global::NCOKFFGPIJM<CreationManager.ALEFKNOEIAL> FEIDGLCJIIC(IMHJKLGAICO LBINIIAEHLF, List<DHJLEHBOGBG> HEPEIEFHLBH, bool JNFHEEOGBOK)
		{
			return null;
		}

		public LAHBDKNMNHN CloneSelectionAndSelect(IMHJKLGAICO LBINIIAEHLF)
		{
			return null;
		}

		public global::NCOKFFGPIJM<CreationManager.ALEFKNOEIAL> CloneSelectionAndSelectWithResult(IMHJKLGAICO LBINIIAEHLF, bool JNFHEEOGBOK = false)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> DBNDGPFDFBB(List<DHJLEHBOGBG> NOEEMHOGJBI, CreationManager.ALEFKNOEIAL PCPEJHIMHJJ, IMHJKLGAICO LBINIIAEHLF)
		{
			return null;
		}

		private static Dictionary<Guid, Guid> PEBGEFEJJAK(IEnumerable<DHJLEHBOGBG> GLLFHCCFIGK, IEnumerable<DHJLEHBOGBG> KMCABMMGNGK)
		{
			return null;
		}

		private LAHBDKNMNHN OMBEGJOKBJA(CreationManager.ALEFKNOEIAL MJKJPIOJMID, bool IHEEABHKMJE)
		{
			return null;
		}

		public LAHBDKNMNHN PostProcessSpawnResult(CreationManager.ALEFKNOEIAL MJKJPIOJMID, Action<Vector3> CIGLFDHALPM, bool IHEEABHKMJE = true)
		{
			return null;
		}

		public LAHBDKNMNHN PasteAndSelect(LFIOJFLIPFC ONCGIPFNENB, JFOADMEPNEL JCAGIGMLOED)
		{
			return null;
		}

		private void EOMFBBJCBOD(DHJLEHBOGBG[] LDMNKJLPAGG)
		{
		}

		public global::NCOKFFGPIJM<bool> TryMergeShapeSelection(BJIJHMNPDCH NLINPCMLDBE, IReadOnlyList<BJIJHMNPDCH> GJODKIOFJLP)
		{
			return null;
		}

		private void HMDLAKMLKGJ(BJIJHMNPDCH NLINPCMLDBE, IReadOnlyList<BJIJHMNPDCH> GJODKIOFJLP, global::PHLHFLLLDLK<bool> BOJDPAGLBLI)
		{
		}

		public bool ExistsUnselectedInventionObjects(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		public IONEOHGOAML TrySelectRestOfInvention(DHJLEHBOGBG DLBHMOGDODI)
		{
			return IONEOHGOAML.Success;
		}

		private bool MFACMFILMKE(in global::PCDAGPAILFA<DHJLEHBOGBG> CIIIHKEOONE)
		{
			return false;
		}

		bool global::ANEBEINLICG<DHJLEHBOGBG>.EJFONCHDJDL(in global::PCDAGPAILFA<DHJLEHBOGBG> CIIIHKEOONE)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MFACMFILMKE
			return this.MFACMFILMKE(in CIIIHKEOONE);
		}

		private bool EAMOCJDINJF(in global::CGNKLPAGFJA<DHJLEHBOGBG> CIIIHKEOONE)
		{
			return false;
		}

		bool global::ONMIGJKMOIP<DHJLEHBOGBG>.MLBHJGMBJKO(in global::CGNKLPAGFJA<DHJLEHBOGBG> CIIIHKEOONE)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EAMOCJDINJF
			return this.EAMOCJDINJF(in CIIIHKEOONE);
		}

		private bool BEJKJJCLBJI(in OKEOHOJLDAN CIIIHKEOONE)
		{
			return false;
		}

		bool global::ONMIGJKMOIP<DHJLEHBOGBG>.KIPLFFJJIJB(in OKEOHOJLDAN CIIIHKEOONE)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BEJKJJCLBJI
			return this.BEJKJJCLBJI(in CIIIHKEOONE);
		}

		private bool BIFBPFPCFLM()
		{
			return false;
		}

		bool global::ONMIGJKMOIP<DHJLEHBOGBG>.FKLKKKDHFHM()
		{
			//ILSpy generated this explicit interface implementation from .override directive in BIFBPFPCFLM
			return this.BIFBPFPCFLM();
		}

		private bool FGCFCCNKJME(IEnumerable<DHJLEHBOGBG> AAGLHJMICLO, bool LOFEDLIEEJD)
		{
			return false;
		}

		private bool CMHDLHEAAJI(Vector3 GHBLBGFLEBE)
		{
			return false;
		}

		private bool ONODADJALDM()
		{
			return false;
		}

		private bool BLIMDKOGEPE(in global::LJAAKHJNKPD<DHJLEHBOGBG> LDDCLBPOGGK)
		{
			return false;
		}

		bool global::BHDCFHIHABO<DHJLEHBOGBG>.EJFONCHDJDL(in global::LJAAKHJNKPD<DHJLEHBOGBG> LDDCLBPOGGK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BLIMDKOGEPE
			return this.BLIMDKOGEPE(in LDDCLBPOGGK);
		}

		private bool BGMENACIGDM(in global::BMPBIHEKJDL<DHJLEHBOGBG> LDDCLBPOGGK)
		{
			return false;
		}

		bool global::LIKLLLAINCP<DHJLEHBOGBG>.MLBHJGMBJKO(in global::BMPBIHEKJDL<DHJLEHBOGBG> LDDCLBPOGGK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BGMENACIGDM
			return this.BGMENACIGDM(in LDDCLBPOGGK);
		}

		private bool BDMJDAHCIEP(in GGDPKIJKHJD LDDCLBPOGGK)
		{
			return false;
		}

		bool global::LIKLLLAINCP<DHJLEHBOGBG>.KIPLFFJJIJB(in GGDPKIJKHJD LDDCLBPOGGK)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BDMJDAHCIEP
			return this.BDMJDAHCIEP(in LDDCLBPOGGK);
		}

		private bool NANOPAAFMMG()
		{
			return false;
		}

		bool global::LIKLLLAINCP<DHJLEHBOGBG>.FKLKKKDHFHM()
		{
			//ILSpy generated this explicit interface implementation from .override directive in NANOPAAFMMG
			return this.NANOPAAFMMG();
		}

		private bool HNPDNOKDPML(IEnumerable<DHJLEHBOGBG> AAGLHJMICLO, bool LOFEDLIEEJD)
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

		private bool GMDJLHLKNGK(List<DHJLEHBOGBG> AAGLHJMICLO, string LFMAAGPNLKI, string EKNGNJFECFC, out ECMNCNMENKO OJLJDHOEBMM, params object[] HMJOKPKOPCN)
		{
			OJLJDHOEBMM = null;
			return false;
		}

		public global::NCOKFFGPIJM<GAMIBKOFAAE> SerializeSelection(IEnumerable<DHJLEHBOGBG> LDMNKJLPAGG)
		{
			return null;
		}

		private bool PGCCHFMCEGF(Vector3 PDFEDMAOMNH, Collider ADMCDJKKCIA)
		{
			return false;
		}

		private bool DPLDIFICJJB(DHJLEHBOGBG GLHOACNHHMF)
		{
			return false;
		}

		private void OBLEPEGFOFD()
		{
		}

		private void OKCDGHDKHKK(DHJLEHBOGBG GLHOACNHHMF)
		{
		}

		private IONEOHGOAML JAALEMAHEBB(DHJLEHBOGBG GLHOACNHHMF)
		{
			return IONEOHGOAML.Success;
		}

		private DHJLEHBOGBG HGCGEFOHNDC(List<DHJLEHBOGBG> AAGLHJMICLO)
		{
			return null;
		}

		private DHJLEHBOGBG POMGPAGBADI(List<DHJLEHBOGBG> AAGLHJMICLO)
		{
			return null;
		}

		private void KKBIEEKGMCK()
		{
		}

		private static OBIIECHNFJK KMNDAGHAGDM()
		{
			return OBIIECHNFJK.NotSupported;
		}

		private void GPBLPLIKJLF()
		{
		}

		private Bounds KAFCELLDEGK(List<DHJLEHBOGBG> GLPABBNKNEO)
		{
			return default;
		}

		public void DisableDynamicCollisionForSelectionUntilDeSelected()
		{
		}

		private void MJDEKBHCLFD(DHJLEHBOGBG EIGHPAIHANK, ref int NIBKBMGAPAK, DHJLEHBOGBG[] NEGFIIDAJIF)
		{
		}

		private bool DPHFGEGIKOI(DHJLEHBOGBG GLHOACNHHMF, ref int HBHBBABCCNB, DHJLEHBOGBG[] NEGFIIDAJIF)
		{
			return false;
		}

		private void DNKKBCECMDE()
		{
		}

		public IONEOHGOAML NotifyOfError(IONEOHGOAML CDNLFEOBNKB, string PEOLHGGDCPN, DHJLEHBOGBG GLHOACNHHMF, JDCIJIEOFOL FOILEMDKKCC)
		{
			return IONEOHGOAML.Success;
		}

		public LAHBDKNMNHN NotifyAndReturnErroredPromise(IONEOHGOAML PEJNHHBEBPH, string PEOLHGGDCPN, DHJLEHBOGBG GLHOACNHHMF = null, CHILKDJABBF FOILEMDKKCC = null)
		{
			return null;
		}

		public void InvokeObjectCreatedEvent(Vector3 PJCILLPIJKM)
		{
		}

		public void InvokeSelectionClonedEvent(Vector3 HDCOHPOHJKD)
		{
		}

		public void InvokeSelectionDeletedEvent()
		{
		}

		public void InvokeTranslationStartedEvent(Transform NIMCBGIBPPC, Vector3 HDCOHPOHJKD)
		{
		}

		public void InvokeTranslationFinishedEvent()
		{
		}

		public void InvokeRotationStartedEvent(Transform EHPMDEAEOGI, Vector3 HDCOHPOHJKD)
		{
		}

		public void InvokeRotationFinishedEvent()
		{
		}

		public void InvokeSelectionScalingStartedEvent(Transform AACLLIEFHDF, Vector3 HDCOHPOHJKD)
		{
		}

		public void InvokeSelectionScalingFinishedEvent()
		{
		}

		public void QueueChangedColorEvent()
		{
		}

		public void QueueChangedMaterialEvent(MJGMBIJIKFH LLMJGJOEMPP)
		{
		}

		private void DAFKBHGEFHJ(CHILKDJABBF HIGOLKPFBPL)
		{
		}

		private void EOOMNHPNNOA(DHJLEHBOGBG ICHBECDKHOJ)
		{
		}

		private void NIJLENGEDME(bool MJOJMCPFBML)
		{
		}

		public void FrozenCommandOccurred(bool MJOJMCPFBML)
		{
		}

		public IONEOHGOAML NotifyOfAuthorityError()
		{
			return IONEOHGOAML.Success;
		}

		public bool TryNotifyOfFrozenObject(DHJLEHBOGBG HNGCPLGBBCA = null)
		{
			return false;
		}

		private void JEAPGMGAIPI()
		{
		}

		private void DGHKGPMFFBA(DHJLEHBOGBG HNGCPLGBBCA)
		{
		}

		private bool IKJPIEDNEFL(bool MDLIBBIEOJM = true)
		{
			return false;
		}

		private bool FAIMPBLGMCI(List<DHJLEHBOGBG> AAGLHJMICLO, bool MDLIBBIEOJM = true)
		{
			return false;
		}

		private bool IMGJAJJJGHA(List<DHJLEHBOGBG> AAGLHJMICLO)
		{
			return false;
		}

		private void IHFCEHEPBHI()
		{
		}

		private void MNOEAJBGFNG()
		{
		}

		private void LDHOLJHHCHA()
		{
		}

		private void LIFFNDNIMGJ(DHJLEHBOGBG HNGCPLGBBCA, bool OLANKFABOLE)
		{
		}

		private void ODMDJFPNBJD(List<DHJLEHBOGBG> AAGLHJMICLO)
		{
		}

		public static CreationContext Instantiate()
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

		public bool SetSelectionFromBuffer(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		public void ShouldHideSelectionBoundsPreview(bool IMGEJEOIKBO, object IALNODEHBNN)
		{
		}

		private void IPAHDBKIKMI()
		{
		}

		private Color NAOLHJNFNCI()
		{
			return default;
		}

		private void GDAKEJFOGGK(in global::AGPLBIICLOE<DHJLEHBOGBG> EGOMBNOFBCH)
		{
		}

		void global::HJIKCMILJMA<DHJLEHBOGBG>.EJFONCHDJDL(in global::AGPLBIICLOE<DHJLEHBOGBG> EGOMBNOFBCH)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GDAKEJFOGGK
			this.GDAKEJFOGGK(in EGOMBNOFBCH);
		}

		private bool GDAKEJFOGGK(in global::GFEGMOFKLEN<DHJLEHBOGBG> EGOMBNOFBCH)
		{
			return false;
		}

		bool global::HJIKCMILJMA<DHJLEHBOGBG>.EJFONCHDJDL(in global::GFEGMOFKLEN<DHJLEHBOGBG> EGOMBNOFBCH)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GDAKEJFOGGK
			return this.GDAKEJFOGGK(in EGOMBNOFBCH);
		}

		private bool DIDJLEMNIIB(in global::DNMKBCIPELF<DHJLEHBOGBG> LCCJICGEEAF)
		{
			return false;
		}

		bool global::CJOLMILKEEG<DHJLEHBOGBG>.EKOHPOJALAF(in global::DNMKBCIPELF<DHJLEHBOGBG> LCCJICGEEAF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DIDJLEMNIIB
			return this.DIDJLEMNIIB(in LCCJICGEEAF);
		}

		private void MAOLNMMLEFI(in global::DNMKBCIPELF<DHJLEHBOGBG> LCCJICGEEAF)
		{
		}

		void global::CJOLMILKEEG<DHJLEHBOGBG>.EDOHPNELGIN(in global::DNMKBCIPELF<DHJLEHBOGBG> LCCJICGEEAF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MAOLNMMLEFI
			this.MAOLNMMLEFI(in LCCJICGEEAF);
		}

		private void ABLPICPIOLH(in bool LOFEDLIEEJD)
		{
		}

		void global::CJOLMILKEEG<DHJLEHBOGBG>.MJEMOBIJDMF(in bool LOFEDLIEEJD)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ABLPICPIOLH
			this.ABLPICPIOLH(in LOFEDLIEEJD);
		}

		private bool EAFIENNBBOB(in global::DNMKBCIPELF<DHJLEHBOGBG> LCCJICGEEAF)
		{
			return false;
		}

		bool global::CJOLMILKEEG<DHJLEHBOGBG>.OLHOGMOIBOL(in global::DNMKBCIPELF<DHJLEHBOGBG> LCCJICGEEAF)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EAFIENNBBOB
			return this.EAFIENNBBOB(in LCCJICGEEAF);
		}

		private void IJKKEHEKEJD()
		{
		}

		void global::CJOLMILKEEG<DHJLEHBOGBG>.HODDDECDLPM()
		{
			//ILSpy generated this explicit interface implementation from .override directive in IJKKEHEKEJD
			this.IJKKEHEKEJD();
		}

		private bool PKCLAOGPCEE(in DHJLEHBOGBG DDGPLGMGCML)
		{
			return false;
		}

		bool global::CJOLMILKEEG<DHJLEHBOGBG>.HHNNECOGAMB(in DHJLEHBOGBG DDGPLGMGCML)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PKCLAOGPCEE
			return this.PKCLAOGPCEE(in DDGPLGMGCML);
		}

		private bool LJGHAHKLEIF(in global::ADAJLIPOFKI<DHJLEHBOGBG> FOIJJNFCPFH)
		{
			return false;
		}

		bool global::JNKPGKLPGFB<DHJLEHBOGBG>.EJFONCHDJDL(in global::ADAJLIPOFKI<DHJLEHBOGBG> FOIJJNFCPFH)
		{
			//ILSpy generated this explicit interface implementation from .override directive in LJGHAHKLEIF
			return this.LJGHAHKLEIF(in FOIJJNFCPFH);
		}

		private void HILMAFELFDB(in global::ECCACJMFPMK<DHJLEHBOGBG> IHADBGDLJKA)
		{
		}

		void global::ENDMHNLLGFN<DHJLEHBOGBG>.DPINEAANGIG(in global::ECCACJMFPMK<DHJLEHBOGBG> IHADBGDLJKA)
		{
			//ILSpy generated this explicit interface implementation from .override directive in HILMAFELFDB
			this.HILMAFELFDB(in IHADBGDLJKA);
		}

		private void NAKBNPPJAFK()
		{
		}

		public bool IsSelectable(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return false;
		}

		public ECMNCNMENKO CreateTransformationUndoEntry(string IEACNHGAIIE, IEnumerable<DHJLEHBOGBG> AAGLHJMICLO, bool LPEJLGKLDAG = false, bool NNAINJOHEAG = false, bool HNNFDAHEOHI = false)
		{
			return null;
		}

		public ECMNCNMENKO CreateCloneUndoEntry()
		{
			return null;
		}

		public void DisableSelectionObjectColliders()
		{
		}

		public void ScopeToSelection()
		{
		}

		public DHJLEHBOGBG ToCreationContextObject(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return null;
		}

		public DHJLEHBOGBG FromCreationContextObject(DHJLEHBOGBG ICHBECDKHOJ)
		{
			return null;
		}

		private void NBPEOPANJMK(GBAJDOHJDHJ GADDGJANIGG)
		{
		}

		private void OINHCBILFMK(GBAJDOHJDHJ GADDGJANIGG)
		{
		}

		private void KKCBGDOFNGB(GBAJDOHJDHJ GADDGJANIGG)
		{
		}

		[CompilerGenerated]
		private global::NCOKFFGPIJM<CreationManager.ALEFKNOEIAL> FCCAHHMMNCA(CreationManager.ALEFKNOEIAL MJKJPIOJMID)
		{
			return null;
		}

		[CompilerGenerated]
		private void ONENMENIEJE()
		{
		}
	}
}
