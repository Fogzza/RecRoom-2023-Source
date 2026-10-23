using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Collections;
using JetBrains.Annotations;
using Photon.Pun;
using RecRoom.CircuitsV2;
using RecRoom.CircuitsV2.Config;
using RecRoom.Persistence;
using RecRoom.Systems.PlayerRoles;
using RecRoom.Utils.Image;
using Unity.Mathematics;
using UnityEngine;

namespace RecRoom.Core.Creation
{
	public class CreationManager : NetworkedSingletonMonoBehaviour<CreationManager>, GLJHIMBOIAI, KKFALCDBDNA
	{
		public class HGDLKGAFGLC : KBOJHNDEOPK, MNDEIFKJEDE
		{
			public struct PODFOMGJNCI
			{
				public IONEOHGOAML CDNLFEOBNKB;

				public OGAJLEFDLBK ANELHHICCEF;

				public long KBPFKPGOCFN;

				public int JGPDCPDKBGJ;

				public static PODFOMGJNCI AHICEAKCHLP;

				public static PODFOMGJNCI CDKEAHCELOF(OGAJLEFDLBK ANELHHICCEF)
				{
					return default;
				}
			}

			private enum CNNFIFHOFHN
			{
				Invalid = 0,
				SaveNew = 1,
				SaveVersion = 2
			}

			public enum PEJMEIDPDEC
			{
				Success = 0,
				Success_ButCannotSell = 1,
				Failure_NoObjectsSelected = 2,
				Failure_InvalidExtents = 3,
				Failure_InvalidCost = 4,
				Failure_InsufficientPermissions = 5,
				Failure_ObjectProhibitsSaving = 6,
				Failure_ProhibitedByServer = 7,
				Failure_InsufficientRolePermissions = 8
			}

			public struct CFCOCOCOILP
			{
				public PEJMEIDPDEC AJLDNMPIGNP;

				public CostInfo KOEIOBNAGMP;

				public string LOKKJFCDNHB;
			}

			private sealed class IFINEKNJABO
			{
				public HGDLKGAFGLC _003C_003E4__this;

				public Guid[] sourceObjectGuids;

				public IEnumerable<DHJLEHBOGBG> sourceObjects;

				public Guid anchorId;

				public global::PHLHFLLLDLK<PODFOMGJNCI> localPromise;

				public CNNFIFHOFHN saveType;

				public ManagedTexture image;

				public string name;

				public string description;

				public long inventionId;

				public Action<string> _003C_003E9__6;

				internal void _003CSaveInvention_003Eb__1(PODFOMGJNCI requestResult)
				{
				}

				internal void _003CSaveInvention_003Eb__2()
				{
				}

				internal void _003CSaveInvention_003Eb__3(CFCOCOCOILP result)
				{
				}

				internal void _003CSaveInvention_003Eb__6(string error)
				{
				}

				internal void _003CSaveInvention_003Eb__4(string error)
				{
				}
			}

			private sealed class JCDAPNCOLCN
			{
				public CFCOCOCOILP result;

				public IFINEKNJABO CS_0024_003C_003E8__locals1;

				internal void _003CSaveInvention_003Eb__5(BFEKGCMDJNM saveInventionResult)
				{
				}
			}

			private sealed class OLHBLEHNFCC
			{
				public global::PHLHFLLLDLK<BFEKGCMDJNM> saveInventionPromise;

				internal void _003CSaveNewInventionLocally_003Eb__0()
				{
				}
			}

			private sealed class HNMMCNPPONJ
			{
				public BFEKGCMDJNM serializationResult;

				public string serializationError;

				public global::NCOKFFGPIJM<BFEKGCMDJNM> serializationPromise;

				internal void _003CSaveNewInventionCoroutine_003Eb__0(BFEKGCMDJNM sr)
				{
				}

				internal void _003CSaveNewInventionCoroutine_003Eb__1(string e)
				{
				}

				internal bool _003CSaveNewInventionCoroutine_003Eb__2()
				{
					return false;
				}
			}

			private sealed class ACHMKIACHFO : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public IEnumerable<DHJLEHBOGBG> sourceObjects;

				public Guid anchorId;

				private HNMMCNPPONJ _003C_003E8__1;

				public global::PHLHFLLLDLK<BFEKGCMDJNM> saveInventionPromise;

				public HGDLKGAFGLC _003C_003E4__this;

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
				public ACHMKIACHFO(int _003C_003E1__state)
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

			private sealed class CKGLDGCHDJA
			{
				public global::PHLHFLLLDLK<PODFOMGJNCI> inventionUpdateRequest;

				public HGDLKGAFGLC _003C_003E4__this;

				public GAMIBKOFAAE inventionDataBlob;

				public string requestedName;

				public string requestedDescription;

				public int requestedInstantiateCost;

				public int requestedLightsCost;

				public int requestedChipsCost;

				public int requestedAiCost;

				public int requestedCloudVariableCost;

				public KADDOPFPEKJ referencedData;

				public BFEKGCMDJNM templateData;

				public Action<JLLIAMENNLJ> _003C_003E9__4;

				public Action<string> _003C_003E9__5;

				internal void _003CSendTemplateDataToServer_003Eb__0(string errMsg)
				{
				}

				internal void _003CSendTemplateDataToServer_003Eb__1(string imageName)
				{
				}

				internal void _003CSendTemplateDataToServer_003Eb__4(JLLIAMENNLJ inventionResponse)
				{
				}

				internal void _003CSendTemplateDataToServer_003Eb__5(string error)
				{
				}

				internal void _003CSendTemplateDataToServer_003Eb__2(JLLIAMENNLJ inventionResponse)
				{
				}

				internal void _003CSendTemplateDataToServer_003Eb__3(string error)
				{
				}
			}

			private sealed class HHKEEDEPGKG
			{
				public FBAMJOFKEKA restrictionsManager;

				internal bool _003CMasterHandleSpawnInventionRequest_003Eb__1(JHHIIKFFNKM node)
				{
					return false;
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct OEDFILCDGIO : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<NNALMOBMGNE.NALLLFKFEFC> _003C_003Et__builder;

				public int senderId;

				public byte[] messagePayload;

				public CancellationToken cancellationToken;

				public HGDLKGAFGLC _003C_003E4__this;

				private CHILKDJABBF _003CrequestingPlayer_003E5__2;

				private JCEEAJBBJIJ _003CrequestData_003E5__3;

				private long _003CinventionId_003E5__4;

				private int _003CversionNum_003E5__5;

				private string _003CdataBlobName_003E5__6;

				private string _003CdataBlobHash_003E5__7;

				private GAMIBKOFAAE _003CinventionDataBlob_003E5__8;

				private TaskAwaiter<IONEOHGOAML> _003C_003Eu__1;

				private TaskAwaiter<GAMIBKOFAAE> _003C_003Eu__2;

				private TaskAwaiter<ALEFKNOEIAL> _003C_003Eu__3;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct LALPOOLIAJJ : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<GAMIBKOFAAE> _003C_003Et__builder;

				public KHPMKANLOIJ dataBlob;

				private TaskAwaiter<byte[]> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct AOICKKIJCGA : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<IONEOHGOAML> _003C_003Et__builder;

				public IEnumerable<OELBDAKHAFC> persistenceViews;

				public long inventionId;

				private IEnumerator<OELBDAKHAFC> _003C_003E7__wrap1;

				private JBGFOIKBKED _003CspawnableToolType_003E5__3;

				private TaskAwaiter<bool> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct GMKKOBLBBNM : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<CBONKEEONIN> _003C_003Et__builder;

				public HGDLKGAFGLC _003C_003E4__this;

				public OEBAEGDPBLA invention;

				public NNGLBNJCODC inventionTrialSource;

				public JFOADMEPNEL spawnTransformData;

				public bool checkAnchor;

				private IONEOHGOAML _003CvalidateResult_003E5__2;

				private TaskAwaiter<IONEOHGOAML> _003C_003Eu__1;

				private TaskAwaiter<OEBAEGDPBLA> _003C_003Eu__2;

				private TaskAwaiter<PJGPNHMNHPH> _003C_003Eu__3;

				private TaskAwaiter<ALEFKNOEIAL> _003C_003Eu__4;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct JNNCJIBDBNI : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<PJGPNHMNHPH> _003C_003Et__builder;

				public long inventionId;

				public int versionNum;

				private TaskAwaiter<PJGPNHMNHPH> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct ILJMIDJNFJJ : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<IONEOHGOAML> _003C_003Et__builder;

				public CHILKDJABBF requestingPlayer;

				public HGDLKGAFGLC _003C_003E4__this;

				public long inventionId;

				private TaskAwaiter<bool> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct CJBOFCELAMC : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

				public long inventionId;

				public HGDLKGAFGLC _003C_003E4__this;

				private TaskAwaiter<ODPHMCBLPNJ.OIKOMAFBJDC> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct BACIDFINIBL : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

				public OELBDAKHAFC viewData;

				public long? parentInventionId;

				private TaskAwaiter<OEBAEGDPBLA> _003C_003Eu__1;

				private TaskAwaiter<bool> _003C_003Eu__2;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			private sealed class PAKCIHDHIJM
			{
				public List<long> referencedInventionIds;

				public CostInfo instantiationCost;

				public Func<bool, CFCOCOCOILP> _003C_003E9__2;

				internal global::NCOKFFGPIJM<CFCOCOCOILP> _003CCheckObjectsCanBeSavedAsInvention_003Eb__1(bool isSavingPrevented)
				{
					return null;
				}

				internal CFCOCOCOILP _003CCheckObjectsCanBeSavedAsInvention_003Eb__2(bool isFullOwner)
				{
					return default;
				}
			}

			private sealed class IKHIGKBEPLH
			{
				public long inventionId;

				internal bool _003CCheckObjectsAreSameInvention_003Eb__0(DHJLEHBOGBG obj)
				{
					return false;
				}
			}

			private sealed class HGBJJFBAALF
			{
				public IEnumerable<DHJLEHBOGBG> objects;

				internal bool _003CCheckObjectsHaveMatchingPermissions_003Eb__0(IEnumerable<ODPHMCBLPNJ.OIKOMAFBJDC> permissionInfo)
				{
					return false;
				}
			}

			private sealed class GMOPCLAGEGI
			{
				public ODPHMCBLPNJ.OIKOMAFBJDC firstPermissionInfo;

				internal bool _003CCheckObjectsHaveMatchingPermissions_003Eb__2(ODPHMCBLPNJ.OIKOMAFBJDC i)
				{
					return false;
				}
			}

			private sealed class CKGFDPHMCBN
			{
				public IEnumerable<DHJLEHBOGBG> sourceObjects;

				public global::PHLHFLLLDLK<List<DHJLEHBOGBG>> promise;

				internal void _003CGetObjectsThatPreventSavingInvention_003Eb__0(List<long> result)
				{
				}

				internal void _003CGetObjectsThatPreventSavingInvention_003Eb__1(string error)
				{
				}
			}

			private sealed class PKAFPDHAOIG
			{
				public global::PHLHFLLLDLK<bool> promise;

				internal void _003CAreAnyObjectsPartOfInventionThatPreventsEditingOrSaving_003Eb__0(ODPHMCBLPNJ.OIKOMAFBJDC result)
				{
				}

				internal void _003CAreAnyObjectsPartOfInventionThatPreventsEditingOrSaving_003Eb__1(string error)
				{
				}
			}

			private readonly CreationManager JBGEMOFFKJO;

			private readonly GAKCKDDEEIK MBDJEOJKIPB;

			private global::PHLHFLLLDLK<PODFOMGJNCI> LOLAKAMLJEF;

			private float OAPNKDODGJL;

			private static readonly TimeSpan JDFEFIHDHCP;

			public HGDLKGAFGLC(CreationManager JBGEMOFFKJO, GAKCKDDEEIK MBDJEOJKIPB)
			{
			}

			public void IHEKMEOIBOI()
			{
			}

			public global::NCOKFFGPIJM<PODFOMGJNCI> PNPDANJCBCK(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, string KNOPFGAGMCN, string GKHMKKBKEKC, ManagedTexture IECDHEIBMJN, Guid FGCKBNAKAFN)
			{
				return null;
			}

			public global::NCOKFFGPIJM<PODFOMGJNCI> PNEFIGAEAJA(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, long KBPFKPGOCFN, Guid FGCKBNAKAFN)
			{
				return null;
			}

			private global::NCOKFFGPIJM<PODFOMGJNCI> MNNOODINBEC(CNNFIFHOFHN JKIGIFIJOMH, IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, string KNOPFGAGMCN, string GKHMKKBKEKC, ManagedTexture IECDHEIBMJN, long KBPFKPGOCFN, Guid FGCKBNAKAFN)
			{
				return null;
			}

			private void OELPANDGJDA(Guid CHJNDCLABED, long KBPFKPGOCFN, int HJOILIPECJE, Guid[] DFEMJNFJEMK)
			{
			}

			private global::NCOKFFGPIJM<BFEKGCMDJNM> LHONPBOOFBL(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, Guid FGCKBNAKAFN)
			{
				return null;
			}

			private IEnumerator<EGGPGCCKPCO> CKHJIHMEAMJ(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, global::PHLHFLLLDLK<BFEKGCMDJNM> CEFLLIGKKPK, Guid FGCKBNAKAFN)
			{
				return null;
			}

			private void EICKCHPFNBH(BFEKGCMDJNM GALPHDPIFCK, CNNFIFHOFHN KGAGKCEKNDJ, ManagedTexture AIKKGFNOEIH, string DLOGLEMIFOA, string GAFNMNFNMGO, long GDCBNFADEGB, int MFLCPBOBIFD, int FBCOJBEJGNM, int LJFDPGBKNHP, int DKJNFJHGMBP, int HCJPANHGPCD, global::PHLHFLLLDLK<PODFOMGJNCI> NGFACKBGFEK)
			{
			}

			public List<DHJLEHBOGBG> CHECEIDCFIF(Guid JNHFHEOCCND)
			{
				return null;
			}

			private Task<NNALMOBMGNE.NALLLFKFEFC> CHBKOAFLLLN(int PIHPHEMDPGD, byte[] PNOPBLNDCLO, CancellationToken NDKAKDJMDIF)
			{
				return null;
			}

			private Task<GAMIBKOFAAE> KJIMPHBHBOB(KHPMKANLOIJ OCOPJEJLDNJ)
			{
				return null;
			}

			private void NCMMJPBKOBJ(long KBPFKPGOCFN, int AMAEGEPNBAF, GAMIBKOFAAE BMMPMNDHPOP, Guid JNHFHEOCCND)
			{
			}

			private Task<IONEOHGOAML> MBPCIGODAME(long KBPFKPGOCFN, IEnumerable<OELBDAKHAFC> DLAEALAIMHE)
			{
				return null;
			}

			public Task<CBONKEEONIN> KMCALAINIJP(OEBAEGDPBLA EGDOIKMDMJM, JFOADMEPNEL JCAGIGMLOED, NNGLBNJCODC FMBHLAFIFOK = default(NNGLBNJCODC), bool BGBJKCNPOPJ = false)
			{
				return null;
			}

			private Task<PJGPNHMNHPH> AJMPMBFFIBB(long KBPFKPGOCFN, int AMAEGEPNBAF)
			{
				return null;
			}

			private Task<IONEOHGOAML> OKANDNFCNBK(long KBPFKPGOCFN, CHILKDJABBF OJMKLBPAANP)
			{
				return null;
			}

			private GNPJIJFFLAA EJFDGGMLBOF(PJGPNHMNHPH EOGFAFNNICF)
			{
				return GNPJIJFFLAA.Success;
			}

			private CostInfo EAIKLLCIFNO(PJGPNHMNHPH EOGFAFNNICF)
			{
				return default;
			}

			private Task<bool> KHOBPBLFGEN(long KBPFKPGOCFN)
			{
				return null;
			}

			private bool MALBKJPIHHH(long KBPFKPGOCFN)
			{
				return false;
			}

			private static Task<bool> CKOCGDBOCLK(OELBDAKHAFC FCJBDJOMIHI, long? EJHOKECBNAD = null)
			{
				return null;
			}

			public global::NCOKFFGPIJM<CFCOCOCOILP> GBGOCCFMEOB(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, long PKEAJPPOGAG)
			{
				return null;
			}

			public bool KIHLNJICPFM(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI)
			{
				return false;
			}

			public global::NCOKFFGPIJM<bool> NNCKOIOKAPG(IEnumerable<DHJLEHBOGBG> GLPABBNKNEO)
			{
				return null;
			}

			public bool MFJKLKANAKM(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI)
			{
				return false;
			}

			public bool CIJPGAEHKKO(CostInfo PNNCCFDIMEP)
			{
				return false;
			}

			public global::NCOKFFGPIJM<List<DHJLEHBOGBG>> BELMFLBMPMB(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, long HHKJAFFGPNO = -1L)
			{
				return null;
			}

			private void LFPLNLNDCDM(GAMIBKOFAAE GALPHDPIFCK, Vector3 DMDIBCPNDJK, Quaternion GOPMNANOGMC)
			{
			}

			private global::NCOKFFGPIJM<JLLIAMENNLJ> AAPMMHIJGAP(GAMIBKOFAAE LDNCPMPBLNN, string KNOPFGAGMCN, string GKHMKKBKEKC, string NPOEAPJKNFN, int PMDEENAONBI, int GEEOIJKKBLK, int LEIKKHPLMGA, int IBPDBJONFAM, int ACHBLHDJGAA, IReadOnlyCollection<string> OONOLGBNOJC, List<long> AMNAMEDOCND, List<string> OMKMDPNNHGD)
			{
				return null;
			}

			private global::NCOKFFGPIJM<JLLIAMENNLJ> LPIOGJFABGH(GAMIBKOFAAE LDNCPMPBLNN, long KBPFKPGOCFN, int PMDEENAONBI, int GEEOIJKKBLK, int LEIKKHPLMGA, int IBPDBJONFAM, int ACHBLHDJGAA, IReadOnlyCollection<string> OONOLGBNOJC, List<long> AMNAMEDOCND, List<string> OMKMDPNNHGD)
			{
				return null;
			}

			public global::NCOKFFGPIJM<DKDHCAHPJGP> OAFICMDCBLK(params DHJLEHBOGBG[] NOEEMHOGJBI)
			{
				return null;
			}

			public global::NCOKFFGPIJM<DKDHCAHPJGP> OAFICMDCBLK(IEnumerable<DHJLEHBOGBG> NOEEMHOGJBI, long PKEAJPPOGAG = -1L)
			{
				return null;
			}

			public global::NCOKFFGPIJM<bool> PGNIHLHMBFH(List<long> FADDFBEPIJM)
			{
				return null;
			}

			[CompilerGenerated]
			internal static bool GANJODBFNNA(FIFEEBEPCAP DCJDBKALJKL)
			{
				return false;
			}
		}

		public readonly struct NNGLBNJCODC
		{
			public readonly string BACLNHFLMBH;

public bool MCFOGCPNGPB
{
get 			{
				return false;
			}

}

			public NNGLBNJCODC(string MGAGMGBLEKL)
			{
				BACLNHFLMBH = null;
			}
		}

		public readonly struct CBONKEEONIN
		{
			public readonly OEBAEGDPBLA ONANKMLMFDN;

			public readonly ALEFKNOEIAL LJNPDIKODMP;

			public CBONKEEONIN(OEBAEGDPBLA PDFPNIJDLNF, ALEFKNOEIAL NHMNHNNAAGA)
			{
				ONANKMLMFDN = null;
				LJNPDIKODMP = default;
			}
		}

		public struct ALEFKNOEIAL
		{
			public IONEOHGOAML CDNLFEOBNKB;

			public CHILKDJABBF MGLFJFEPBGA;

			public List<DHJLEHBOGBG> FNJMKMPKONK;

			public List<EKIIIJIOBCC> MFLFMGLEJGD;

			public Dictionary<Guid, Guid> JDJLCAPJLIH;
		}

		public class FHGNGDBHOCA : KBOJHNDEOPK
		{
			[StructLayout((LayoutKind)3)]
			private struct IBKLKEDOLPF : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<ALEFKNOEIAL> _003C_003Et__builder;

				public LOBKKNOBPKI spawnableTemplateData;

				public FHGNGDBHOCA _003C_003E4__this;

				public NNALMOBMGNE.JNEOCDDOFAO creationOp;

				public TimeSpan? requestTimeout;

				private TaskAwaiter<ALEFKNOEIAL> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct DBGOKNFFNLG : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<NNALMOBMGNE.NALLLFKFEFC> _003C_003Et__builder;

				public CHILKDJABBF requestingPlayer;

				public FHGNGDBHOCA _003C_003E4__this;

				public LOBKKNOBPKI localTemplateSpawnRequestData;

				public CancellationToken cancellationToken;

				private int _003CrequestingPlayerActorNumber_003E5__2;

				private TaskAwaiter<ALEFKNOEIAL> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			private sealed class DCEKFHJGKBE
			{
				public FHGNGDBHOCA _003C_003E4__this;

				public LOBKKNOBPKI spawnTemplateRequestData;

				internal object _003CLocalSpawnGenericTemplateViaRoutine_003Eb__0()
				{
					return null;
				}
			}

			[StructLayout((LayoutKind)3)]
			private struct KGNCPKLOIHE : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<ALEFKNOEIAL> _003C_003Et__builder;

				public FHGNGDBHOCA _003C_003E4__this;

				public NNALMOBMGNE.JNEOCDDOFAO creationOp;

				public byte[] requestPayload;

				public TimeSpan? requestTimeout;

				private TaskAwaiter<NNALMOBMGNE.NCFNGOFOIBA<FCOKHDOBNIK>> _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			private sealed class ILDMNCBDCGA
			{
				public FHGNGDBHOCA _003C_003E4__this;

				public LOBKKNOBPKI spawnTemplateRequestData;

				internal object _003CSpawnTemplateCoroutine_003Eb__0()
				{
					return null;
				}
			}

			private sealed class AHEBECAPJDC : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private EGGPGCCKPCO _003C_003E2__current;

				public FHGNGDBHOCA _003C_003E4__this;

				public LOBKKNOBPKI spawnTemplateRequestData;

				public global::PHLHFLLLDLK<ALEFKNOEIAL> promise;

				public CHILKDJABBF requestingPlayer;

				private GAMIBKOFAAE _003CspawnableTemplateData_003E5__2;

				private JLLFDOEDIEA _003CspawnTemplateIdMapping_003E5__3;

				private JLLFDOEDIEA _003C_003E7__wrap3;

				private Task<global::LAFJBBFBCGA<IEnumerable<EKIIIJIOBCC>, HODHNINHENI>> _003CinstantiatedChips_003E5__5;

				private List<global::HBBHKKBNKHE<PersistenceView, OELBDAKHAFC>> _003CviewDataPairs_003E5__6;

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
				public AHEBECAPJDC(int _003C_003E1__state)
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

				private void _003C_003Em__Finally1()
				{
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

			private sealed class FLPEAPPNMCO
			{
				public Guid circuitGraphId;

				public GAMIBKOFAAE spawnableTemplateData;

				internal Task<global::LAFJBBFBCGA<IEnumerable<EKIIIJIOBCC>, HODHNINHENI>> _003CBulkInstantiatePersistenceViewsAndChips_003Eb__1()
				{
					return null;
				}
			}

			private readonly CreationManager JBGEMOFFKJO;

			public FHGNGDBHOCA(CreationManager JBGEMOFFKJO)
			{
			}

			public void IHEKMEOIBOI()
			{
			}

			public Task<ALEFKNOEIAL> GHMPDFLAGIK(LOBKKNOBPKI KDOHOHMMADB, NNALMOBMGNE.JNEOCDDOFAO BNPHIMADFKK, TimeSpan? AHKDPABHMII = null)
			{
				return null;
			}

			public Task<NNALMOBMGNE.NALLLFKFEFC> KOPFINBNFOG(CHILKDJABBF OJMKLBPAANP, LOBKKNOBPKI LIMLKOMACBK, CancellationToken NDKAKDJMDIF)
			{
				return null;
			}

			public global::NCOKFFGPIJM<ALEFKNOEIAL> LHNLMHFIFJM(CHILKDJABBF OJMKLBPAANP, LOBKKNOBPKI AGEEABNANOP)
			{
				return null;
			}

			public Task<ALEFKNOEIAL> EHHENDKIBMI<T>(NNALMOBMGNE.JNEOCDDOFAO BNPHIMADFKK, T CEAJNOPDGIH, TimeSpan? AHKDPABHMII = null) where T : IMessage<T>
			{
				return null;
			}

			public static FCOKHDOBNIK OOOHABDPHEC(ALEFKNOEIAL NHMNHNNAAGA)
			{
				return null;
			}

			public static ALEFKNOEIAL JMNPJDFDJJH(NNALMOBMGNE.NCFNGOFOIBA<FCOKHDOBNIK> OJCNLPIOJDO)
			{
				return default;
			}

			private Task<ALEFKNOEIAL> EHHENDKIBMI(NNALMOBMGNE.JNEOCDDOFAO BNPHIMADFKK, byte[] CEAJNOPDGIH, TimeSpan? AHKDPABHMII)
			{
				return null;
			}

			private IEnumerator<EGGPGCCKPCO> KNKGAEALCJM(CHILKDJABBF OJMKLBPAANP, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI, LOBKKNOBPKI AGEEABNANOP)
			{
				return null;
			}

			private bool CGNCMEMCIOK(OELBDAKHAFC FCJBDJOMIHI, FBLAHKFEHNM POFMFJFCBKE, JFOADMEPNEL? JCAGIGMLOED, Dictionary<string, object> PJHHIDJMLAB, out PHKAHHNJBNJ CIHDEJJMEEC)
			{
				CIHDEJJMEEC = null;
				return false;
			}

			private bool CLCABGOPFPK(List<OELBDAKHAFC> LCNKGHHIDHL, GameObject[] DBBILMBHEMC, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI, out List<global::HBBHKKBNKHE<PersistenceView, OELBDAKHAFC>> GIKFJPFCPKM)
			{
				GIKFJPFCPKM = null;
				return false;
			}

			private void DOJEFCMHHPM(OELBDAKHAFC FCJBDJOMIHI, GameObject IMHPMMJALIJ, List<global::HBBHKKBNKHE<PersistenceView, OELBDAKHAFC>> GIKFJPFCPKM)
			{
			}

			private bool GNPDOBHACPP(List<global::HBBHKKBNKHE<PersistenceView, OELBDAKHAFC>> GIKFJPFCPKM, FBLAHKFEHNM POFMFJFCBKE, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI)
			{
				return false;
			}

			private bool AHEPOFAHPCC(List<global::HBBHKKBNKHE<PersistenceView, OELBDAKHAFC>> GIKFJPFCPKM, FBLAHKFEHNM POFMFJFCBKE, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI)
			{
				return false;
			}

			private void DDPAEKFBIGG(GameObject[] DBBILMBHEMC)
			{
			}

			private bool JEDPHHKENAN(GAMIBKOFAAE KDOHOHMMADB, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI)
			{
				return false;
			}

			private bool CFIPMANLOCN(List<global::HBBHKKBNKHE<PersistenceView, OELBDAKHAFC>> GIKFJPFCPKM, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI)
			{
				return false;
			}

			private ALEFKNOEIAL OFKDBGCMBNC(GAMIBKOFAAE KDOHOHMMADB, List<global::HBBHKKBNKHE<PersistenceView, OELBDAKHAFC>> GIKFJPFCPKM, Task<global::LAFJBBFBCGA<IEnumerable<EKIIIJIOBCC>, HODHNINHENI>> DGHBCOLAMBF, Dictionary<Guid, Guid> JDJLCAPJLIH)
			{
				return default;
			}

			private bool DHCKIENFANA(GAMIBKOFAAE KDOHOHMMADB, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI)
			{
				return false;
			}

			private bool FLLFFCLEMDB(GAMIBKOFAAE KDOHOHMMADB, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI)
			{
				return false;
			}

			private bool NMGPLJJPDPB(GAMIBKOFAAE KDOHOHMMADB, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI, out List<OELBDAKHAFC> FJINHFNOCIF, out List<GameRole> DJAMPGEGOAB)
			{
				FJINHFNOCIF = null;
				DJAMPGEGOAB = null;
				return false;
			}

			private bool AGOAEOHEBEM(GAMIBKOFAAE KDOHOHMMADB, Guid OLNCKNNJIPA, List<GameRole> DJAMPGEGOAB, List<PHKAHHNJBNJ> EHEMLBOFJDG, global::PHLHFLLLDLK<ALEFKNOEIAL> BOJDPAGLBLI, out GameObject[] DBBILMBHEMC, out Task<global::LAFJBBFBCGA<IEnumerable<EKIIIJIOBCC>, HODHNINHENI>> DGHBCOLAMBF)
			{
				DBBILMBHEMC = null;
				DGHBCOLAMBF = null;
				return false;
			}
		}

		public class BFEKGCMDJNM
		{
			public GAMIBKOFAAE KDOHOHMMADB;

			public List<string> OMKMDPNNHGD;

			public Vector3 DMDIBCPNDJK;

			public Quaternion GOPMNANOGMC;
		}

		public readonly struct LJGEDIDFFCO
		{
			public readonly bool EGJEBAFNALL;

			public readonly HashSet<Guid> CAPEJAGGAJO;

			private LJGEDIDFFCO(bool EGJEBAFNALL, IEnumerable<Guid> CAPEJAGGAJO)
			{
				this.EGJEBAFNALL = false;
				this.CAPEJAGGAJO = null;
			}

			public static LJGEDIDFFCO HAKIFALCEGD()
			{
				return default;
			}

			public static LJGEDIDFFCO NFPADFOMHPP(HashSet<Guid> FKPJBHFKLCA)
			{
				return default;
			}
		}

		public interface IGKDPEJAIAC
		{
			Task<IEnumerable<Guid>> OAMJAJKDOBH(IEnumerable<object> LDMNKJLPAGG);
		}

		public abstract class NDGKAPMPCHA<T> : IGKDPEJAIAC
		{
			private Task<IEnumerable<Guid>> DFANCCHAEMJ(IEnumerable<object> LDMNKJLPAGG)
			{
				return null;
			}

			Task<IEnumerable<Guid>> IGKDPEJAIAC.OAMJAJKDOBH(IEnumerable<object> LDMNKJLPAGG)
			{
				//ILSpy generated this explicit interface implementation from .override directive in DFANCCHAEMJ
				return this.DFANCCHAEMJ(LDMNKJLPAGG);
			}

			public abstract Task<IEnumerable<Guid>> HMBAJKJDDBA(IEnumerable<T> LDMNKJLPAGG);
		}

		public sealed class AFKPLKPFPAI : NDGKAPMPCHA<CreationObject>
		{
			[StructLayout((LayoutKind)3)]
			private struct IFEPAADBFMI : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<IEnumerable<Guid>> _003C_003Et__builder;

				public IEnumerable<CreationObject> objectsToDelete;

				private HashSet<Guid> _003CidsToDelete_003E5__2;

				private TaskAwaiter _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			public override Task<IEnumerable<Guid>> HMBAJKJDDBA(IEnumerable<CreationObject> LDMNKJLPAGG)
			{
				return null;
			}
		}

		public interface KBOJHNDEOPK
		{
			void IHEKMEOIBOI();
		}

		[StructLayout((LayoutKind)3)]
		private struct FGJCNGIDINB : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<NNALMOBMGNE.NALLLFKFEFC> _003C_003Et__builder;

			public int senderId;

			public byte[] messagePayload;

			public CreationManager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private TaskAwaiter<NNALMOBMGNE.NALLLFKFEFC> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct FGLKGGNJBHF : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<NNALMOBMGNE.NALLLFKFEFC> _003C_003Et__builder;

			public int senderId;

			public byte[] messagePayload;

			public CreationManager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private CHILKDJABBF _003CrequestingPlayer_003E5__2;

			private NPIJCDDJBPL _003CcloneRequestData_003E5__3;

			private List<DHJLEHBOGBG> _003CobjectsToClone_003E5__4;

			private CostInfo _003CcombinedCost_003E5__5;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<BFEKGCMDJNM> _003C_003Eu__2;

			private TaskAwaiter<NNALMOBMGNE.NALLLFKFEFC> _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct MDJEFBFLGHK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ALEFKNOEIAL> _003C_003Et__builder;

			public CreationManager _003C_003E4__this;

			public List<DHJLEHBOGBG> sourceObjects;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<ALEFKNOEIAL> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct NPINIGHMNDM : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public List<DHJLEHBOGBG> sourceObjects;

			public int requestingPlayerActorNumber;

			private TaskAwaiter<ODPHMCBLPNJ.OIKOMAFBJDC> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct FMHODIMEGBB : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<NNALMOBMGNE.NCFNGOFOIBA<byte[]>> _003C_003Et__builder;

			public CreationManager _003C_003E4__this;

			private TaskAwaiter<NNALMOBMGNE.NCFNGOFOIBA<byte[]>> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct INLCLPKPEMK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<NNALMOBMGNE.NALLLFKFEFC> _003C_003Et__builder;

			public int senderId;

			public CreationManager _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private sealed class DEMAJBHDBJG
		{
			public CAFMMAJMNLD[] multiActions;

			internal Task<global::LAFJBBFBCGA<JHFMIMDLHNN, HODHNINHENI>> _003CMasterDeleteAll_003Eb__0()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct MGLOLCGLAHC : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CreationManager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private DEMAJBHDBJG _003C_003E8__1;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<global::LAFJBBFBCGA<MFEHAEMCKCJ, HODHNINHENI>> _003C_003Eu__2;

			private TaskAwaiter<global::LAFJBBFBCGA<bool, HODHNINHENI>> _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct ILPMMGJMPOF : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ALEFKNOEIAL> _003C_003Et__builder;

			public LFIOJFLIPFC item;

			public Guid circuitGraphId;

			public JFOADMEPNEL spawnTransformData;

			public CreationManager _003C_003E4__this;

			private TaskAwaiter<ALEFKNOEIAL> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private sealed class BANAJPJMPPI
		{
			public Tool spawnedTool;

			public TaskCompletionSource<Tool> tcs;

			internal void _003CRequestSpawnToolV2_003Eb__1(ACPBHPEJKKH o)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct NACJEJMFOKI : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Tool> _003C_003Et__builder;

			public CreationManager _003C_003E4__this;

			public JBGFOIKBKED toolType;

			public Vector3 position;

			public Quaternion rotation;

			public float scale;

			public Guid id;

			private BANAJPJMPPI _003C_003E8__1;

			private TaskAwaiter<NNALMOBMGNE.NCFNGOFOIBA<Tool>> _003C_003Eu__1;

			private TaskAwaiter<Tool> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private sealed class NCDKEHPDNIH : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

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
			public NCDKEHPDNIH(int _003C_003E1__state)
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

		private sealed class DDKJEDGCABJ
		{
			public JBGFOIKBKED toolType;

			internal bool _003CCanAffordTool_003Eb__0(CreationObject x)
			{
				return false;
			}
		}

		private sealed class DACDDNHGNIG
		{
			public CreationManager _003C_003E4__this;

			public IEnumerable<PersistenceView> persistenceViews;

			public IEnumerable<EKIIIJIOBCC> circuitNodes;

			internal object _003CSerializeSpawnableTemplate_003Eb__0()
			{
				return null;
			}
		}

		private sealed class NABODJBPMMD
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003CSerializeSpawnableTemplateDataBlobCoroutine_003Eg__WaitForPreserializes_007C0_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public NABODJBPMMD _003C_003E4__this;

				private TaskAwaiter _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			public IEnumerable<PersistenceView> persistenceViews;

			public StringBuilder outputBuilder;

			public LAHBDKNMNHN waitForPreserializesPromise;

			public CreationManager _003C_003E4__this;

			public BFEKGCMDJNM result;

			internal Task _003CSerializeSpawnableTemplateDataBlobCoroutine_003Eg__WaitForPreserializes_007C0()
			{
				return null;
			}

			internal Task _003CSerializeSpawnableTemplateDataBlobCoroutine_003Eb__4(PersistenceView v)
			{
				return null;
			}

			internal bool _003CSerializeSpawnableTemplateDataBlobCoroutine_003Eb__1()
			{
				return false;
			}

			internal object _003CSerializeSpawnableTemplateDataBlobCoroutine_003Eb__2()
			{
				return null;
			}
		}

		private sealed class FHFFFBGGKFJ
		{
			public PersistenceView v;

			public NABODJBPMMD CS_0024_003C_003E8__locals1;

			internal Task _003CSerializeSpawnableTemplateDataBlobCoroutine_003Eb__5(CancellationToken timeoutToken)
			{
				return null;
			}
		}

		private sealed class AGPJGONEPID : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public IEnumerable<PersistenceView> persistenceViews;

			public CreationManager _003C_003E4__this;

			public bool forceWorldSpaceForCV2NodesAtRoot;

			public Dictionary<Guid, Transform> circuitsV2GuidToChipTransformMap;

			public global::PHLHFLLLDLK<BFEKGCMDJNM> promise;

			public bool verboseLogging;

			private NABODJBPMMD _003C_003E8__1;

			public IEnumerable<EKIIIJIOBCC> circuitNodes;

			public Guid anchorId;

			private float _003Ctime_003E5__2;

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
			public AGPJGONEPID(int _003C_003E1__state)
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

		private sealed class IJMIEHGAGOO
		{
			public global::PHLHFLLLDLK<IONEOHGOAML> promise;

			internal void _003CValidateCopy_003Eb__0(string i)
			{
			}

			internal void _003CValidateCopy_003Eb__1(ODPHMCBLPNJ.OIKOMAFBJDC i)
			{
			}
		}

		private sealed class GAPOJAAFIGH
		{
			public Guid prefabId;

			internal bool _003CExceedsToolCreationLimit_003Eb__0(OELBDAKHAFC p)
			{
				return false;
			}

			internal bool _003CExceedsToolCreationLimit_003Eb__1(OELBDAKHAFC p)
			{
				return false;
			}
		}

		private sealed class OIAPGOEKJKK : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public float delay;

			public CreationManager _003C_003E4__this;

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
			public OIAPGOEKJKK(int _003C_003E1__state)
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

		[StructLayout((LayoutKind)3)]
		private struct FDMMOHDMKBG : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<LJGEDIDFFCO> _003C_003Et__builder;

			public JGLPGIIHGIM[] objectsToDelete;

			private HashSet<Guid> _003CundeletedIds_003E5__2;

			private Dictionary<Type, HashSet<object>>.Enumerator _003C_003E7__wrap2;

			private Task<IEnumerable<Guid>> _003Ctask_003E5__4;

			private TaskAwaiter<Task> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct BDFLGKJJEGF : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public CreationManager _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private global::PHLHFLLLDLK<ALEFKNOEIAL> MNGDOHDCPHL;

		private float FECBOMFAPLO;

		private global::PHLHFLLLDLK<Tool> MFAAFDJKAGJ;

		private float GNCOMIOGMFF;

		private const int PPHMAPGLPPF = 30000;

		private const int DOOIJDFABIJ = 64;

		private const int BPFIONBMBDO = 101;

		private const int FMNKGMJAAJE = 1;

		private const int PECIMGHIJLH = 12;

		private static CostInfo BKAFGHHAPMK;

		private const float CFDAEOGFMKF = 5f;

		private const float OEFNHBBNEOI = 5f;

		public const float MAX_INVENTION_EXTENTS_COMPONENT_SIZE = 1000f;

		private const float LGKJLHJJGAG = 1f;

		private const float BHJFPBGJPCF = 1f;

		private const float NJEBPJECPCN = 10f;

		public const string COLOR_OVERRIDE_INSTANTIATION_KEY = "CRM_CO";

		public const string TEAM_OVERRIDE_INSTANTIATION_KEY = "CRM_TO";

		public const string MAKER_PEN_INTERACTION_FILTER_INSTANTIATION_KEY = "CRM_MPIF";

		public const string OBJECT_PICKUP_LOCKED_BY_KEY_ID_INSTANTIATION_KEY = "OBJ_PK";

		public const string COSTUME_EQUIP_LOCKED_BY_KEY_ID_INSTANTIATION_KEY = "CST_EQPK";

		private static readonly List<long> ANAKHCHCJPL;

		private static readonly List<PersistenceView> MKKBDACABPN;

		private static readonly Dictionary<Guid, Transform> BNPJENNOEPJ;

		private static readonly Dictionary<Guid, Guid> AJOIJBIEPMG;

		private static readonly Dictionary<Guid, LJEJHGJFNNO> CDHBHCGKHGI;

		private static readonly List<PersistenceView> DPAPDKODHCI;

		private static readonly List<long> BAFJEJIIJHP;

		public static EEANDDJEMJC ActiveSandboxResourcesChangedEvent;

		public static EEANDDJEMJC AllSpawnedObjectsDestroyedEvent;

		public static EEANDDJEMJC AllSpawnedObjectsDestroyWarningEvent;

		public static EEANDDJEMJC PostGameStartResetEvent;

		public static global::BPEPJJDICII<ALEFKNOEIAL, bool> OnMasterInventionSpawned;

		private static readonly List<CreationObject> FDCFCDLNBAP;

		private static Action<CreationObject> DDHFBPNBNJD__BackingField;

		private static Action<CreationObject> LCAPFPCDNIC__BackingField;

		private static Action BKBPELOAAJA__BackingField;

		private static CostInfo JJJMBNAOHIO;

		private static bool BGPNCHHPGBJ;

		private global::MOBDJNEDDKC<bool> HPMEAILCMBN;

		private GOHLPMEFMDL JFEDJEOMDIN;

		private GMNJJBHDNJM DKBDLHKGDOO;

		private GAKCKDDEEIK MBDJEOJKIPB;

		private LKFJJHJMFIB ADGPGMPOPNJ;

		private BEMCDCJBEIK LMEJMAINFPD;

		private FHGNGDBHOCA KBECPCEJFGK;

		private HGDLKGAFGLC CODLOGANHPA;

		private NNALMOBMGNE NDPOEAHPGNC;

		private float NBPDEDDOANA;

		private global::PHLHFLLLDLK<ALEFKNOEIAL> OIHHKLKOCBG;

		public readonly EEANDDJEMJC OnRoomReset;

		private JFMOJNIDLNH JAGCNLNGOFP;

		private readonly Dictionary<Type, IGKDPEJAIAC> DJAPFHJHNJM;

		private const int GCDNJKHBPIB = 5000;

		private const int BCHMJCDAMPD = 15;

		private static AKBJKJFMIAK FBODJKFMLFL;

		private static AKBJKJFMIAK KCDLMIKMMGB;

public static ref readonly CostInfo MAX_SANDBOX_RESOURCES
{
get 		{
			throw null;
		}

}

public static IReadOnlyList<CreationObject> AllCreationObjects
{
get 		{
			return null;
		}

}

public static ref readonly CostInfo ActiveSandboxResourceCost
{
get 		{
			throw null;
		}

}

public static bool WasMakerPenEverOut
{
get 		{
			return false;
		}

}

public GOHLPMEFMDL InventionPieceManager
{
get 		{
			return null;
		}

private set {
		}
}

public GMNJJBHDNJM RoomRestrictionsManager
{
get 		{
			return null;
		}

private set {
		}
}

public FHGNGDBHOCA Templates
{
get 		{
			return null;
		}

private set {
		}
}

public HGDLKGAFGLC Inventions
{
get 		{
			return null;
		}

private set {
		}
}

public static CostInfo MaxResourcesCost
{
get 		{
			return default;
		}

}

public static int MaxInkCost
{
get 		{
			return 0;
		}

}

public static int MaxLightsCost
{
get 		{
			return 0;
		}

}

public static int MaxAiCost
{
get 		{
			return 0;
		}

}

public static int MaxNumChips
{
get 		{
			return 0;
		}

}

public static int MaxCloudVariables
{
get 		{
			return 0;
		}

}

public GNPJIJFFLAA IsOverCostLimit
{
get 		{
			return GNPJIJFFLAA.Success;
		}

}

public bool DevOnlyIgnoreInk
{
get 		{
			return false;
		}

}

public bool IsOverInkLimit
{
get 		{
			return false;
		}

}

public bool IsOverLightsLimit
{
get 		{
			return false;
		}

}

public bool IsOverChipLimit
{
get 		{
			return false;
		}

}

public bool IsOverCloudVariablesLimit
{
get 		{
			return false;
		}

}

private JFMOJNIDLNH IOJMHALCFAI
{
get 		{
			return null;
		}

}

public static bool EnableInventionsInBetaRooms
{
get 		{
			return false;
		}

}

public static event Action<CreationObject> AddedCreationObject {
add {
		}
remove {
		}
}

public static event Action<CreationObject> RemovedCreationObject {
add {
		}
remove {
		}
}

public static event Action OnDestroyingAll {
add {
		}
remove {
		}
}

		private void IKJPJMKJMBM()
		{
		}

		private Task<NNALMOBMGNE.NALLLFKFEFC> LKPOGJGMJPP(int PIHPHEMDPGD, byte[] PNOPBLNDCLO, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private void BLEFDCDLEAF()
		{
		}

		private Task<NNALMOBMGNE.NALLLFKFEFC> FLKEMOMIPLE(int PIHPHEMDPGD, byte[] PNOPBLNDCLO, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public Task<ALEFKNOEIAL> RequestCloneObjectsV2(List<DHJLEHBOGBG> NOEEMHOGJBI)
		{
			return null;
		}

		private Task LLHBMBBABDE(List<DHJLEHBOGBG> NOEEMHOGJBI, int DMGLNDEGALK)
		{
			return null;
		}

		public global::NCOKFFGPIJM<ALEFKNOEIAL> RequestCloneObjects(List<DHJLEHBOGBG> NOEEMHOGJBI, bool JNFHEEOGBOK)
		{
			return null;
		}

		private void KJJCHAJOBKD()
		{
		}

		public Task<NNALMOBMGNE.NCFNGOFOIBA<byte[]>> RequestDeleteAll()
		{
			return null;
		}

		private Task<NNALMOBMGNE.NALLLFKFEFC> JNNJOGDJMAP(int PIHPHEMDPGD, byte[] PNOPBLNDCLO, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public Task MasterDeleteAll(CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcAllSpawnedObjectsDestroyed()
		{
		}

		[PBOMGCLBFHF]
		private void RpcAllSpawnedObjectsDestroyWarning()
		{
		}

		private void FALJJJEJNIL()
		{
		}

		public global::NCOKFFGPIJM<ALEFKNOEIAL> RequestPaste(LFIOJFLIPFC ONCGIPFNENB, JFOADMEPNEL JCAGIGMLOED, Guid OLNCKNNJIPA)
		{
			return null;
		}

		private Task<ALEFKNOEIAL> OBFAAPFKEDN(LFIOJFLIPFC ONCGIPFNENB, JFOADMEPNEL JCAGIGMLOED, Guid OLNCKNNJIPA)
		{
			return null;
		}

		private void JPFLBEIGFDD()
		{
		}

		public global::NCOKFFGPIJM<Tool> RequestSpawnTool(JBGFOIKBKED CKEPLIBLBFJ, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO, Guid IKHNIJKGJFD)
		{
			return null;
		}

		private Task<Tool> DHJGMAHDBNA(JBGFOIKBKED CKEPLIBLBFJ, Vector3 INLGLHIPOMC, Quaternion HEGBBJCMANH, float JDFDFBKKBPO, Guid IKHNIJKGJFD)
		{
			return null;
		}

		private Task<NNALMOBMGNE.NALLLFKFEFC> POLMDKKIMGO(int PIHPHEMDPGD, byte[] PNOPBLNDCLO, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		public static void OnCircuitsV2LimitsRefreshed(LimitConfig ICFHNANCOOG)
		{
		}

		public void SetMakerPenOut()
		{
		}

		public static void AddCreationObject(CreationObject BPEGJLIMPPJ)
		{
		}

		public static void RemoveCreationObject(CreationObject BPEGJLIMPPJ)
		{
		}

		public static void MarkResourceCostsDirty()
		{
		}

		public static CostInfo CalculateActiveResourceCost()
		{
			return default;
		}

		private static void OBAKJPAHEEN()
		{
		}

		private static IEnumerator<EGGPGCCKPCO> KJIFDHDKGCF()
		{
			return null;
		}

		public static bool SpawnedView(PhotonView LPHOEJICCFI)
		{
			return false;
		}

		public static bool TryGetColorOverrideFromInstantiationData(Dictionary<string, object> GGNINCPGCFF, out Color HMCAFGCGFJF)
		{
			HMCAFGCGFJF = default;
			return false;
		}

		public static bool TryGetTeamOverrideFromInstantiationData(Dictionary<string, object> GGNINCPGCFF, out GIBEGHKMCIE NEBNOBLPNEP)
		{
			NEBNOBLPNEP = default;
			return false;
		}

		public static bool TryGetMakerPenInteractionFilterOverrideFromInstantiationData(Dictionary<string, object> GGNINCPGCFF, out KLNOBKBCIEK HGBHOJBMCCA)
		{
			HGBHOJBMCCA = default;
			return false;
		}

		private static void BHHJCNMOMGC(CHILKDJABBF OJMKLBPAANP, ref Dictionary<string, object> PJHHIDJMLAB)
		{
		}

		public static string GetErrorDescription(IONEOHGOAML CDNLFEOBNKB, JDCIJIEOFOL FOILEMDKKCC)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public GNPJIJFFLAA CanAffordResourceCost(CostInfo PNNCCFDIMEP)
		{
			return GNPJIJFFLAA.Success;
		}

		public GNPJIJFFLAA CanAffordTool(JBGFOIKBKED CKEPLIBLBFJ, out CostInfo PNNCCFDIMEP)
		{
			PNNCCFDIMEP = default;
			return GNPJIJFFLAA.Success;
		}

		public GNPJIJFFLAA CanAffordTool(JBGFOIKBKED CKEPLIBLBFJ)
		{
			return GNPJIJFFLAA.Success;
		}

		public static PKAEKEMHEJH CircuitTemplateParamsFromCreationContextObjects(IEnumerable<DHJLEHBOGBG> KFAEEOIEEJG)
		{
			return null;
		}

		private static bool OIIDADFCNJJ(DHJLEHBOGBG BMDDJIDADKN, out Chip JJMNDCAFBDA, out EKIIIJIOBCC KNBPIEINLIG)
		{
			JJMNDCAFBDA = null;
			KNBPIEINLIG = null;
			return false;
		}

		public global::NCOKFFGPIJM<BFEKGCMDJNM> SerializeSpawnableTemplate(IEnumerable<DHJLEHBOGBG> KFAEEOIEEJG, bool GHFEAADAEMP = false, Guid FGCKBNAKAFN = default(Guid), bool OLLKGPGENGP = false)
		{
			return null;
		}

		private global::NCOKFFGPIJM<BFEKGCMDJNM> KIOIPPEHCCE(IEnumerable<PersistenceView> DLAEALAIMHE, IEnumerable<EKIIIJIOBCC> FBDEOBLEJED, bool GHFEAADAEMP = false, Guid FGCKBNAKAFN = default(Guid), bool OLLKGPGENGP = false, Dictionary<Guid, Transform> JDFFNKJNHKA = null)
		{
			return null;
		}

		private IEnumerator<EGGPGCCKPCO> FPJFGHAMLPD(IEnumerable<PersistenceView> DLAEALAIMHE, IEnumerable<EKIIIJIOBCC> FBDEOBLEJED, bool GHFEAADAEMP, global::PHLHFLLLDLK<BFEKGCMDJNM> BOJDPAGLBLI, Guid FGCKBNAKAFN = default(Guid), bool OLLKGPGENGP = false, Dictionary<Guid, Transform> JDFFNKJNHKA = null)
		{
			return null;
		}

		private void CMANKFHKKKI(ref JMLPLALIKGL JIEECFLEPDI, GAMIBKOFAAE KDOHOHMMADB)
		{
		}

		public global::NCOKFFGPIJM<IONEOHGOAML> ValidateCopy(List<DHJLEHBOGBG> NOEEMHOGJBI)
		{
			return null;
		}

		private global::NCOKFFGPIJM<GAMIBKOFAAE> KJIMPHBHBOB(long KBPFKPGOCFN, int AMAEGEPNBAF)
		{
			return null;
		}

		[PBOMGCLBFHF]
		public void RpcInvalidateInventionCache(long KBPFKPGOCFN)
		{
		}

		private static void AGIHINKLGBP(GAMIBKOFAAE KDOHOHMMADB, out Vector3 DMDIBCPNDJK, out Quaternion GOPMNANOGMC)
		{
			DMDIBCPNDJK = default;
			GOPMNANOGMC = default;
		}

		private bool EHLDIPNLCME(RepeatedField<OELBDAKHAFC> DLAEALAIMHE)
		{
			return false;
		}

		private bool OEAKIBBHBCI(int HNGOOFIPIMH, int AMJBPHCBCIA, JBGFOIKBKED CKEPLIBLBFJ, RepeatedField<OELBDAKHAFC> DLAEALAIMHE)
		{
			return false;
		}

		private string CNICKDNLGNM(JBGFOIKBKED CKEPLIBLBFJ)
		{
			return null;
		}

		public static void SafeUnsubscribeFromOnRoomReset(Action LJPDJPCDLDI)
		{
		}

		public void RoomResetAll()
		{
		}

		[PBOMGCLBFHF]
		private void RpcResetRoom()
		{
		}

		private void HDJBEAFJEHD()
		{
		}

		[PBOMGCLBFHF]
		private void RpcFinishedGameStartReset()
		{
		}

		private IEnumerator<EGGPGCCKPCO> LOBIGMIFEDG(float FHFDDKOBFLG)
		{
			return null;
		}

		public static Task<LJGEDIDFFCO> BulkDeleteAsync(JGLPGIIHGIM[] LDMNKJLPAGG)
		{
			return null;
		}

		public static void RegisterBulkDeleter<T>(T OEEFFPGCGKC) where T : IGKDPEJAIAC
		{
		}

		public static void UnregisterBulkDeleter<T>()
		{
		}

		[NotNull]
		public static IGKDPEJAIAC GetBulkDeleter(Type ACOIGGBCONB)
		{
			return null;
		}

		private BCDAPDDMMEO HJODHEFDCOL(JDCIJIEOFOL FBCDJHOIDJJ)
		{
			return null;
		}

		public static ByteString WriteForbiddenItemResult(ISet<JBGFOIKBKED> ECBPFCCNNNF)
		{
			return null;
		}

		public static ISet<JBGFOIKBKED> GetForbiddenItemTypesFromMessage(ByteString CBAOEBDONKD)
		{
			return null;
		}

		public IEnumerable<ByteString> GetValidRoomKeyReplicationIds()
		{
			return null;
		}

		public IEnumerable<ByteString> GetValidRoomCurrencies()
		{
			return null;
		}

		public IEnumerable<ByteString> GetValidRoomConsumables()
		{
			return null;
		}

		public bool TryGetPersistenceViewId(int CONBHIDACJO, out Guid KDDBKHKBKKK)
		{
			KDDBKHKBKKK = default;
			return false;
		}

		[CanBeNull]
		public Tool MasterSpawnCreationRequest([CanBeNull] PHKAHHNJBNJ BEODCPFFPCC)
		{
			return null;
		}

		[NotNull]
		public static FCFFDDNFCOB InstantiateRequestForSpawnableToolType(JBGFOIKBKED CKEPLIBLBFJ, string HAFKALLLGBE = null, bool GLJCMKDAPDG = true, Guid? KGKJHIPHLNB = null)
		{
			return null;
		}

		private static bool HBKFMOLBIIN(Guid HKEGNBMGHBK)
		{
			return false;
		}

		[NotNull]
		private static FCFFDDNFCOB OIKHEABIFOB(Guid HKEGNBMGHBK, bool NAOOBAMOCHJ)
		{
			return null;
		}

		public static bool TryGetTransform(OELBDAKHAFC FCJBDJOMIHI, FBLAHKFEHNM LJFNCCMLIDM, out (RigidTransform, Vector3) PMJBBDJHCEH)
		{
			PMJBBDJHCEH = default;
			return false;
		}

		[NotNull]
		public static FCFFDDNFCOB InstantiateRequestForViewData(OELBDAKHAFC FCJBDJOMIHI, FBLAHKFEHNM LJFNCCMLIDM, bool NAOOBAMOCHJ, bool GFHAAPIGHIF)
		{
			return null;
		}

		private static void ADOFJOOJBMI(OELBDAKHAFC FCJBDJOMIHI)
		{
		}

		private static void GLFEMJADLCC(FCFFDDNFCOB BKJILEGEHCG, OELBDAKHAFC FCJBDJOMIHI)
		{
		}

		private static void NPKOKEGLIGA(FCFFDDNFCOB BKJILEGEHCG, OELBDAKHAFC FCJBDJOMIHI)
		{
		}

		public static Guid ResolveViewDataPrefabId(OELBDAKHAFC FCJBDJOMIHI, FBLAHKFEHNM LJFNCCMLIDM)
		{
			return default;
		}

		[NotNull]
		private static FCFFDDNFCOB NHANHEHNAFE(string PEGANFDBJPA, JBGFOIKBKED CKEPLIBLBFJ, int OKEGMMHJAIP, bool BKPGDFEOFLN, bool GLJCMKDAPDG)
		{
			return null;
		}

		[CompilerGenerated]
		internal static Tool KAONFGCPPEE(byte[] JHHHAJGNLBL)
		{
			return null;
		}

		[CompilerGenerated]
		private void OBOIAJFKDBE()
		{
		}
	}
}
