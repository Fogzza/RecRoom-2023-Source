using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AGUI.StackedUI.Dialog;
using RecRoom.Audio;
using RecRoom.CircuitsV2.Config;
using RecRoom.CircuitsV2.GraphNodes;
using RecRoom.CircuitsV2.RoomSettings;
using RecRoom.Core.Creation;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RecRoom.CircuitsV2
{
	public sealed class CircuitsV2Manager : NetworkedSingletonMonoBehaviour<CircuitsV2Manager>, EPHNMPLOKJG, HFMANLPHJJA
	{
		private struct IIEMAAOEGBJ
		{
			private readonly CircuitsV2Manager NNFMBPLKBHH;

			public int EJGPMKCLEEL;

			public OBCPHIJMGBG CODHEPLAHMC;

			public int GMJNACBFOCA;

			public readonly OOEEKGDKFJH OJEOOFONHHI;

			public readonly OOEEKGDKFJH MAOJPBKPDDN;

			public readonly OOEEKGDKFJH LAMIPOCCEGA;

			public int NOICMCMOCOL;

			public int OIKBNPLDAND;

			public int POAPPKLELNE;

			public readonly OOEEKGDKFJH KHAOJPGHKFJ;

			public readonly OOEEKGDKFJH PMONMGMDIML;

			public IIEMAAOEGBJ(CircuitsV2Manager ACDHNMANGFE)
			{
				NNFMBPLKBHH = null;
				EJGPMKCLEEL = 0;
				CODHEPLAHMC = default;
				GMJNACBFOCA = 0;
				OJEOOFONHHI = null;
				MAOJPBKPDDN = null;
				LAMIPOCCEGA = null;
				NOICMCMOCOL = 0;
				OIKBNPLDAND = 0;
				POAPPKLELNE = 0;
				KHAOJPGHKFJ = null;
				PMONMGMDIML = null;
			}

			public void PAKIMOKGMBI()
			{
			}

			public KIDPMAMHDFB.DOFKJJOAGAG.EHCBINEHCEP OCBNDCOHLBA()
			{
				return default;
			}
		}

		public struct HFLMJPOEMCL
		{
			public enum CLOMDPAMNIM
			{
				Invalid = 0,
				NotInitialized = 1,
				RootInitialized = 2,
				GlobalCircuitGraphIdInitialized = 3,
				NetSysInitialized = 4,
				StateInitialized = 5,
				GameplayInitialized = 6,
				RootDestroyed = 7
			}

			private CLOMDPAMNIM LMMEGEIPPLM;

			private readonly CircuitsV2Manager NNFMBPLKBHH;

public bool GCALNEJPPNE
{
get 			{
				return false;
			}

}

public bool AEEGFDACAIB
{
get 			{
				return false;
			}

}

public bool NOPICGNJBMM
{
get 			{
				return false;
			}

}

public bool NLCPKFFJACP
{
get 			{
				return false;
			}

}

public bool ICMGBBBCEOG
{
get 			{
				return false;
			}

}

			[Obsolete]

public CLOMDPAMNIM APPOCJINGOK
{
get 			{
				return CLOMDPAMNIM.Invalid;
			}

}

public CLOMDPAMNIM MBHNCCMHIPK
{
set {
			}
}

			private static string GLFIBJGMEDI(CLOMDPAMNIM DMBDEPMHMNP, CLOMDPAMNIM ELCFDEFNBDD)
			{
				return null;
			}

			private HFLMJPOEMCL(CircuitsV2Manager ACDHNMANGFE, CLOMDPAMNIM IPMIIEAGJKC)
			{
				LMMEGEIPPLM = CLOMDPAMNIM.Invalid;
				NNFMBPLKBHH = null;
			}

			public static HFLMJPOEMCL ELCFDEFNBDD(CircuitsV2Manager ACDHNMANGFE)
			{
				return default;
			}
		}

		public enum EBHKOOFHMKO : byte
		{
			None = 0,
			GlobalGraph = 1,
			CurrentlyEditingGraph = 2
		}

		private readonly struct MONDAFGGJLN<T> where T : ControlPanelCircuitObjectBase
		{
			private readonly Dictionary<Guid, T> CBBLKENCLFN;

public IEnumerable<T> PAMDCECBKIB
{
get 			{
				return null;
			}

}

			private MONDAFGGJLN(Dictionary<Guid, T> GLPABBNKNEO)
			{
				CBBLKENCLFN = null;
			}

			public static MONDAFGGJLN<T> ELCFDEFNBDD()
			{
				return default;
			}

			public void CPCILMEHKPA(T ICHBECDKHOJ, CircuitsV2Manager ACDHNMANGFE)
			{
			}

			public void MILDLLFOGOM(T ICHBECDKHOJ)
			{
			}

			public T GFKLPGKFOPC(in Guid IKHNIJKGJFD)
			{
				return null;
			}

			public bool IPAADGPGDFJ(in Guid IKHNIJKGJFD)
			{
				return false;
			}

			public void GLBPPAIACJF()
			{
			}
		}

		private class KFMNICMMEOJ : IIEEBDFGDNI.MLBBNMNHNGD
		{
			public static KFMNICMMEOJ OFDKPDDLIJC;

public PMAPBPKCLDH PECPBEJBGBK
{
get 			{
				return null;
			}

}

public PMAPBPKCLDH GKPMEMAACNL
{
get 			{
				return null;
			}

}

			private KFMNICMMEOJ()
			{
			}

			private static global::FAIKNKAIPLB<bool> EPGPGGICPLB(JEGAPHLGBJA GCBHEJANCJK, in OHAJOLBEFND KLAFDLPDEPD, in OHAJOLBEFND HIIHPENGKBD)
			{
				return default;
			}

			private static global::FAIKNKAIPLB<bool> DEPMLPHEMBO(JEGAPHLGBJA GCBHEJANCJK, in OHAJOLBEFND KLAFDLPDEPD, in OHAJOLBEFND HIIHPENGKBD)
			{
				return default;
			}
		}

		private class IPMLIMKNFHC
		{
			private sealed class CNBLKKBIOMI
			{
				public IPMLIMKNFHC _003C_003E4__this;

				public Chip chip;

				internal object _003CRelease_003Eb__0()
				{
					return null;
				}
			}

			private readonly HashSet<Chip> NAJFAMFFDHG;

			private readonly Queue<Chip> EIOBHFODDLI;

			private static readonly object JBKNOMHANNF;

			private readonly Chip BFAAPJIBKAG;

			public IPMLIMKNFHC(Chip BFAAPJIBKAG)
			{
			}

			public Chip CKPFPCMEEHI()
			{
				return null;
			}

			public void MBLNKLCECMD(Chip JJMNDCAFBDA)
			{
			}

			[CompilerGenerated]
			private object GBPABEOHPBC()
			{
				return null;
			}
		}

		public sealed class MHCIPOHAABG : CreationManager.NDGKAPMPCHA<EKIIIJIOBCC>
		{
			[StructLayout((LayoutKind)3)]
			private struct HIJDOLKFMJN : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder<IEnumerable<Guid>> _003C_003Et__builder;

				public IEnumerable<EKIIIJIOBCC> objectsToDelete;

				private TaskAwaiter<TaskStatus> _003C_003Eu__1;

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

			public override Task<IEnumerable<Guid>> HMBAJKJDDBA(IEnumerable<EKIIIJIOBCC> LDMNKJLPAGG)
			{
				return null;
			}
		}

		private sealed class NPKKOFKDNEC
		{
			public global::NCOKFFGPIJM<(bool, string)> currentPromptPromise;

			public CircuitsV2Manager _003C_003E4__this;

			public Action _003C_003E9__2;

			internal Task<(bool, string)> _003CGetPromptForTextDelegate_003Eb__0(string promptTitle, string prompt)
			{
				return null;
			}

			internal void _003CGetPromptForTextDelegate_003Eb__2()
			{
			}
		}

		private sealed class HKBNJNGBOFE
		{
			[StructLayout((LayoutKind)3)]
			private struct _003C_003COnStateDidInitializeHandler_003Eb__1_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncTaskMethodBuilder _003C_003Et__builder;

				public HKBNJNGBOFE _003C_003E4__this;

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

			public CircuitsV2Manager _003C_003E4__this;

			public List<EKIIIJIOBCC> chipsToSpawn;

			internal object _003COnStateDidInitializeHandler_003Eb__0()
			{
				return null;
			}

			internal Task _003COnStateDidInitializeHandler_003Eb__1()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct HDNJKBBLNCN : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CircuitsV2Manager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private IDisposable _003C_003E7__wrap1;

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

		private sealed class BMGGOMMEFJL : IEnumerable<CAFMMAJMNLD>, IEnumerable, IEnumerator<CAFMMAJMNLD>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CAFMMAJMNLD _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private KHMOHFAFGBI roomData;

			public KHMOHFAFGBI _003C_003E3__roomData;

			private HashSet<Guid> _003CallUsedControlPanels_003E5__2;

			private IEnumerator<JHHIIKFFNKM> _003C_003E7__wrap2;

 CAFMMAJMNLD global::System.Collections.Generic.IEnumerator<global::CAFMMAJMNLD>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CCircuits_002EStatic_002ERecRoom_002EProtobuf_002EActionData_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public BMGGOMMEFJL(int _003C_003E1__state)
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
			private CAFMMAJMNLD System_002ECollections_002EGeneric_002EIEnumerator_003CCircuits_002EStatic_002ERecRoom_002EProtobuf_002EActionData_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<CAFMMAJMNLD> IEnumerable<CAFMMAJMNLD>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct OICNHMEPLGM
		{
			public DBJMAFIOFFK oldScope;

			public CircuitsV2Manager _003C_003E4__this;
		}

		private sealed class BAFLIOPHKIN
		{
			public CircuitsV2Manager _003C_003E4__this;

			public LAIGEMPFAMG dep;

			internal object _003CAddPendingPreviewGraphBinding_003Eb__0()
			{
				return null;
			}
		}

		private sealed class EAMPNHBDHHL
		{
			public CircuitsV2Manager _003C_003E4__this;

			public Guid circuitGraphId;

			internal object _003CTakePendingPreviewGraphBinding_003Eb__0()
			{
				return null;
			}
		}

		private sealed class BGFDLIGOOEN
		{
			public Action cancelAction;

			public Action affirmativeAction;

			public Action negativeAction;

			internal void _003CShowConfirmationDialogue_003Eb__0(HGKINAOMNIF response)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct LCOONDGCFCK : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CircuitsV2Manager _003C_003E4__this;

			public MHLDMCJALLH audioWrapper;

			public float playbackSpeedShift;

			public float volume;

			public HHOIEGJNNEC channel;

			public string subChannel;

			public bool is2D;

			public Vector3 position;

			public OGJHFKGLLGE rolloffCurve;

			public float maxRolloffDistance;

			private MGDHHGCAICD _003CaudioManager_003E5__2;

			private TaskAwaiter<AudioClip> _003C_003Eu__1;

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

		private sealed class FKCGOAPHKGG
		{
			public HashSet<EKIIIJIOBCC> removedNodes;

			internal void _003CGetRenderableCircuitObjectsPendingCreation_003Eg__OnNodeDestroyed_007C0(EKIIIJIOBCC node)
			{
			}
		}

		private sealed class LBEIKANNAPF : IEnumerable<EKIIIJIOBCC>, IEnumerable, IEnumerator<EKIIIJIOBCC>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EKIIIJIOBCC _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CircuitsV2Manager _003C_003E4__this;

			private FKCGOAPHKGG _003C_003E8__1;

			private int _003CtotalNodeCount_003E5__2;

			private EKIIIJIOBCC[] _003CallNodes_003E5__3;

			private int _003Ci_003E5__4;

 EKIIIJIOBCC global::System.Collections.Generic.IEnumerator<global::EKIIIJIOBCC>.Current
{
get 				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CCircuitsV2_002ELang_002ENode_003E_002Eget_Current();
				}

}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public LBEIKANNAPF(int _003C_003E1__state)
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
			private EKIIIJIOBCC System_002ECollections_002EGeneric_002EIEnumerator_003CCircuitsV2_002ELang_002ENode_003E_002Eget_Current()
			{
				return null;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<EKIIIJIOBCC> IEnumerable<EKIIIJIOBCC>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct IPAPIFDOGIH : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CircuitsV2Manager _003C_003E4__this;

			public List<EKIIIJIOBCC> nodes;

			public CancellationToken cancellationToken;

			private int _003Ci_003E5__2;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		private sealed class AIEFMOGNMJP
		{
			public Chip chip;

			public CircuitsV2Manager _003C_003E4__this;

			internal void _003CCreateChip_003Eg__onDestroyed_007C0()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		private struct BJDGFADPGCG : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<global::LAFJBBFBCGA<Chip, BBMENPGBPEA>> _003C_003Et__builder;

			public Type spawnableCircuitNodeType;

			public CircuitsV2Manager _003C_003E4__this;

			public Guid nodeId;

			public Vector3 localSpacePosition;

			public Quaternion localSpaceRotation;

			private int _003CmakerPenInteractionFilter_003E5__2;

			private EKIIIJIOBCC _003Cnode_003E5__3;

			private TaskAwaiter<global::LAFJBBFBCGA<EKIIIJIOBCC, HODHNINHENI>> _003C_003Eu__1;

			private TaskAwaiter<global::LAFJBBFBCGA<MFEHAEMCKCJ, HODHNINHENI>> _003C_003Eu__2;

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

		private sealed class HJGIDNPKNFB : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public CircuitsV2Manager _003C_003E4__this;

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
			public HJGIDNPKNFB(int _003C_003E1__state)
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
		private struct KPFJIFLJBIE : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public string blobName;

			public float sampleLength;

			public string audioName;

			public bool preload;

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
		private struct AENELEIGLME<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<global::LAFJBBFBCGA<T, HODHNINHENI>> _003C_003Et__builder;

			public Func<Task<global::LAFJBBFBCGA<T, HODHNINHENI>>> runOnce;

			private TaskAwaiter<global::LAFJBBFBCGA<T, HODHNINHENI>> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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
		private struct FOODCPAPENG : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CircuitsV2Manager _003C_003E4__this;

			public CancellationToken cancellationToken;

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

		[StructLayout((LayoutKind)3)]
		private struct PIODLDEPHFB : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CircuitsV2Manager _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private IDisposable _003Cnotification_003E5__2;

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
		private struct NAJIAGFNAAO : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CircuitsV2Manager self;

			public CircuitsV2Manager _003C_003E4__this;

			public int actorId_;

			public int requestId_;

			public CAFMMAJMNLD action_;

			private TaskAwaiter<global::LAFJBBFBCGA<object, HODHNINHENI>> _003C_003Eu__1;

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

		private LFHHMEALLBA GPJFOJPBHKA;

		private IIEMAAOEGBJ CKOCJBLHEEE;

		private BLHEIACBFCP LBEGKBKLKLE;

		private AHHKANHBKKN JAJAKJBHFOE;

		private Guid JGEBJGJNPCO;

		private HFLMJPOEMCL DPECJINODIN;

		private CancellationTokenSource CDOGMLHJCPN;

		private TaskCompletionSource<MFEHAEMCKCJ> GKECHGJNBOD;

		private global::IKPGIDNNNGG<string> BELDHPICHBD;

		private global::JEKNBGHMBJN<MFEHAEMCKCJ> MPOLDPOLJDG;

		private IHIGKPLCENK LDMMCHHPBGO;

		private ECNCNNBLHJH NFBANHJCMIG;

		private JFPOIAPCMPC GOAPMNJLAPJ;

		private DILENLPDIOG JNDFMJGGFDA;

		private Dictionary<Guid, Guid> JBBILLHJDEJ;

		private readonly FACLNBKLHPH BEIELFACKAH;

		private readonly FACLNBKLHPH EIDAFMDFIJA;

		private readonly global::IDFMPGILDJE<float, float> LJMCNLJNFGE;

		private readonly global::IDFMPGILDJE<long, long> KCJDJCDKJAB;

		private readonly global::IDFMPGILDJE<int, int> IONHFPAPLKN;

		private readonly global::BACHNFKGBAG<float, float> KHMDLJANLDH;

		private bool OCJCIMMFMEF;

		private bool CKMDOIJBDBA;

		private bool BNNACNNBLNL;

		private bool OFEHPJHNGNM;

		private INBDIKIJLGF GBIFNANKKKC;

		private BMGFCHFKJGF AFFIEEOCCFE;

		private HFHMJODNBMN CFIGNGEMGKI;

		private JEGAPHLGBJA FGCELJHIPDI;

		public const int MaximumSimultaneousCV2SFXAudioSources = 100;

		[SerializeField]
		public TextInputUIDialog textInputDialogPrefab;

		[SerializeField]
		private CircuitsV2Config config;

		[SerializeField]
		private Chip chipVisualPrefab;

		[SerializeField]
		public ControlPanelSerializedState EmptyObjectBoard;

		public RoomElementSettingsManager _roomElementSettingsManager;

		private IPMLIMKNFHC POJKLOJGPLL;

		private GODLDNHNMLJ KCBJOFCEEOA;

		private global::LGBBCGCNDJO<AIMOEBMLELO> GBLEONIKKIF;

		private DKDKBINIGAJ PDNHKIDKNHH;

		private global::MPNGGJINIEL<IPGAKKHFLAO> OLGGLAEDAFF;

		private IDisposable KMMDNNPDDMC;

		private FBAMJOFKEKA AHDEHKOLKFI;

		private JMNFKGGAGNP BNCCGBKAADM;

		private readonly Dictionary<Guid, Chip> MEFLAKIEPCN;

		private NNBAJLCGAOK KACDODJBMCM;

		private HLNFDOBEGJO MPGEAFIBHEK;

		private global::NMAELEDHCMF<MLOKAFMAHAD> PPDAIAOIKHI;

		private HEJEFJABMHN JHGMCLBDPMP;

		private JBDDBLBBGLC MKKDAGHAIHO;

		public global::FNJHELPKPHG<MDALFJIODBI, Sprite> ChipAdapterSprites;

		public global::MOBDJNEDDKC<bool> ProgressionTestMode;

		private readonly MONDAFGGJLN<ControlPanelCircuitObject> KECLLNCDKGP;

		private readonly MONDAFGGJLN<PlayerLogicComponent> KHDLGMEAEAO;

		private readonly List<CAFMMAJMNLD> FDFCCIBDJPH;

		private readonly IDictionary<Guid, LAIGEMPFAMG> AMIFEGKCHJO;

		private static readonly HDHGNNMHDMB GDMCOMILEMP;

		private KICJCEFKBGF FHEMOOMJCAK;

		private MPBBNJKOEPO GICEIJPKJPM;

		private const float LJPGAFIDONM = 5f;

		private JNODIIINKKJ.BLCIGIHGEAC NDCLODEPMBK;

		private double BGHEDFEEIEF;

		private int OJLEPHGIKNH;

		private int JGCAIFJMDOB;

		private static Action GFLHNICOLMO__BackingField;

		public static EEANDDJEMJC OnUgcRewardDataChanged;

		private LKGILLBEJEK BACOKDGEAFM;

		private readonly List<(int, int, CAFMMAJMNLD)> PGJAOJDHPNF;

public BLHEIACBFCP Root
{
get 		{
			return null;
		}

private set {
		}
}

public EGKNHDEIFON LegacyCircuitsManager
{
get 		{
			return null;
		}

}

public Guid GlobalCircuitGraphId
{
get 		{
			return default;
		}

private set {
		}
}

		[Obsolete]

public HFLMJPOEMCL.CLOMDPAMNIM CurrentStateDbg
{
get 		{
			return HFLMJPOEMCL.CLOMDPAMNIM.Invalid;
		}

}

public bool IsStateValid
{
get 		{
			return false;
		}

}

public bool IsGameplayPossible
{
get 		{
			return false;
		}

}

public Task StateInitializedTask
{
get 		{
			return null;
		}

}

public static EODEAJMANDC Request
{
get 		{
			return default;
		}

}

public static KMINNAAEKIB RequestExtended
{
get 		{
			return null;
		}

}

public LEPCMENIFGP GlobalCircuitGraph
{
get 		{
			return null;
		}

}

public FNKHIJAALCL CloudDataManager
{
get 		{
			return null;
		}

}

public PHEAADHJFDM RewardDataManager
{
get 		{
			return null;
		}

}

public IDPBEMNMNJH ProgressionManager
{
get 		{
			return null;
		}

}

public PLICFFMPCKE SuperRoomDataManager
{
get 		{
			return null;
		}

}

public NBJPDONDLFN PlayerSaveDataManager
{
get 		{
			return null;
		}

}

public NMKJMHGGLPO DataTableRegistry
{
get 		{
			return null;
		}

}

public IHIGKPLCENK Dependencies
{
get 		{
			return null;
		}

}

public JEGAPHLGBJA CurrentFrameExecParams
{
get 		{
			return null;
		}

}

public long Update60HzRecentMax
{
get 		{
			return 0L;
		}

}

public float CpuRecentMaxRatio
{
get 		{
			return 0f;
		}

}

public float NetRecentAverage
{
get 		{
			return 0f;
		}

}

public int RpcRecentMax
{
get 		{
			return 0;
		}

}

public bool IsCV2Enabled
{
get 		{
			return false;
		}

}

public CircuitsV2Config Config
{
get 		{
			return null;
		}

}

public bool IsWaitingForSnapshot
{
get 		{
			return false;
		}

}

public int PhotonBufferSizeSoFar
{
get 		{
			return 0;
		}

}

public DKDKBINIGAJ DynamicNetSys
{
get 		{
			return null;
		}

private set {
		}
}

public FBAMJOFKEKA RoomRestrictionsManager
{
get 		{
			return null;
		}

}

public JMNFKGGAGNP LogManager
{
get 		{
			return null;
		}

}

public JBDDBLBBGLC ChipCullingManager
{
get 		{
			return null;
		}

}

public int CurrentTotalPersistentChipCount
{
get 		{
			return 0;
		}

}

public IEnumerable<Chip> ActiveChips
{
get 		{
			return null;
		}

}

public MIEKHIHLDEK CurrentEditGraph
{
get 		{
			return null;
		}

}

public ref readonly Guid CurrentEditGraphId
{
get 		{
			throw null;
		}

}

public bool CurrentEditGraphIsGlobal
{
get 		{
			return false;
		}

}

public KICJCEFKBGF CircuitLockManager
{
get 		{
			return null;
		}

private set {
		}
}

public static event Action OnCloudDataLedgerChanged {
add {
		}
remove {
		}
}

		private void HMJOMIMLPEG()
		{
		}

		private void PEGHKKOEKDJ()
		{
		}

		public void RaisePlayerJoined(CHILKDJABBF OOLAMIKCKLH)
		{
		}

		public void RaiseLocalPlayerSpawned()
		{
		}

		private void OKNMLACINNC(CHILKDJABBF ANINOIFFADJ)
		{
		}

		private void OGAHPBCHCLN(Player BMFDMADJDLP, Player.NBPIPAJOGLC GADDGJANIGG, Player MABCGNKHNAC, Player.NBPIPAJOGLC GOAGPPCPBIA)
		{
		}

		private void BBLDBABHDHB(CHILKDJABBF GKNDJIKLPKK)
		{
		}

		private void BOCJEDMGGLO()
		{
		}

		private void KJEBOBEOHEN()
		{
		}

		public void RaiseConsumableUsedEvent(Guid GFGAKKMOHON)
		{
		}

		public void RaiseTestEvent()
		{
		}

		public void RaiseAISpawned(in OHAJOLBEFND HBEKDJPJIAD)
		{
		}

		public void RaiseAIDied(in OHAJOLBEFND HBEKDJPJIAD, in OHAJOLBEFND NJDHAACHDKF)
		{
		}

		private IHIGKPLCENK.CKIAKHPBNLG MBHIBLNPFBP()
		{
			return null;
		}

		[PBOMGCLBFHF]
		public void RpcSendMajorNotification(string PBOPFHHBNPO)
		{
		}

		[PBOMGCLBFHF]
		public void RpcRequestMasterRecalculateMaster()
		{
		}

		private void INEPLAFKIPF()
		{
		}

		public bool TryGetSpecialGraphId(EBHKOOFHMKO HBFBOFMBJFI, out Guid GLLFFIFLOAG)
		{
			GLLFFIFLOAG = default;
			return false;
		}

		private void DHHOMFCCFKP()
		{
		}

		private void KPOHBHPPGBM()
		{
		}

		private void BGJBKOLAPNO()
		{
		}

		private void GHJEJDJKGCK(EGKNHDEIFON GADDGJANIGG)
		{
		}

		private void NLACPMMFNOE(EGKNHDEIFON GADDGJANIGG)
		{
		}

		private void BFKEMMJJJIC()
		{
		}

		private void JHCDJPLIEJN(string PAKKJAPOGPN, LoadSceneMode OGCJOMHGAPD)
		{
		}

		private Task GELDODNPDOJ(CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private Task PLDMPOHCJGG(CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		[PBOMGCLBFHF]
		private void RpcClearCircuitsLifecycleStateForReloadAfterStateDestruction(int AMMLAHNGBBA, int AMGNCPLIAAC)
		{
		}

		private ILODPOPFPAH FFBDGACNKHN()
		{
			return null;
		}

		private IEnumerable<CAFMMAJMNLD> KFCAKBGAHBJ(KHMOHFAFGBI KGMPBFBAMCF)
		{
			return null;
		}

		private void IEDFGAGAGGG(IEnumerable<CAFMMAJMNLD> NKGAIHEAPGD)
		{
		}

		private void FGGIEEHIDNN(DDNDPJHCIHN OFCFPGACNJB, in HJDBOADFHMC? PANELIGGJGM = null)
		{
		}

		private void FGGIEEHIDNN<T>(global::NNEJJHCOBPO<T> BLHMBIIFFGG, in T ADCFFAJGNAM, in HJDBOADFHMC? PANELIGGJGM = null)
		{
		}

		public void OnScopeChanged(DBJMAFIOFFK JCNEOMGJFBL, DBJMAFIOFFK APOPENKHGDL)
		{
		}

		private bool DMHHBKLLCJM(MGLKJGICKPJ NNALINLCFLP, out Chip JJMNDCAFBDA)
		{
			JJMNDCAFBDA = null;
			return false;
		}

		private void GKEOIBPEFDE(MGLKJGICKPJ NNALINLCFLP)
		{
		}

		private void CKEKFLOKPBK(MGLKJGICKPJ NNALINLCFLP)
		{
		}

		private JEGAPHLGBJA IPMMKFOCJNH()
		{
			return null;
		}

		public bool TryGetChip(in Guid KKBFAENPLID, out Chip JJMNDCAFBDA)
		{
			JJMNDCAFBDA = null;
			return false;
		}

		public void AddObjectBoardObject(ControlPanelCircuitObject ICHBECDKHOJ)
		{
		}

		public void RemoveObjectBoardObject(ControlPanelCircuitObject ICHBECDKHOJ)
		{
		}

		private bool DHMIMDGIKOC(in Guid JMIFIJDBMNM)
		{
			return false;
		}

		private ADDCDIBDJKJ JGLAADLANFK(in Guid JMIFIJDBMNM)
		{
			return null;
		}

		public bool TryGetObjectBoardObject(in Guid JMIFIJDBMNM, out ControlPanelCircuitObject ICHBECDKHOJ)
		{
			ICHBECDKHOJ = null;
			return false;
		}

		public void AddPlayerBoardObject(PlayerLogicComponent ICHBECDKHOJ)
		{
		}

		public void RemovePlayerBoardObject(PlayerLogicComponent ICHBECDKHOJ)
		{
		}

		private bool IOPOLFKJHGB(in Guid JMIFIJDBMNM)
		{
			return false;
		}

		private ADDCDIBDJKJ GHJKMFACOEC(in Guid JMIFIJDBMNM)
		{
			return null;
		}

		public IEnumerable<CAFMMAJMNLD> GenerateSpawnPlayerBoardCircuitObjectsActions()
		{
			return null;
		}

		public void AddPendingObjectBoardAction(CAFMMAJMNLD ICHBECDKHOJ)
		{
		}

		public void AddPendingPreviewGraphBinding(LAIGEMPFAMG CEFOPKLKMJM)
		{
		}

		private LAIGEMPFAMG PLMHFILHFBE(Guid OLNCKNNJIPA)
		{
			return null;
		}

		private ADDCDIBDJKJ OOJEODFMECJ()
		{
			return null;
		}

		private global::LAFJBBFBCGA<ECNCNNBLHJH, BBMENPGBPEA> INILMHOPNKJ()
		{
			return default;
		}

		private DILENLPDIOG DKCFGDKIFNM()
		{
			return null;
		}

		private JFPOIAPCMPC BGPKIKDHCPF()
		{
			return null;
		}

		private static string CAIKJIAHKEC(int JGFCLDGKBAO)
		{
			return null;
		}

		private bool EIHOIFLLGDM(Guid JBLIAFMMHKH)
		{
			return false;
		}

		private static string JMMMLDOLOIJ(in OHAJOLBEFND MMJFAIFNOOK)
		{
			return null;
		}

		private static string BOLHEGPCMFB(in OHAJOLBEFND MMJFAIFNOOK, in string IPMICCELJED)
		{
			return null;
		}

		private static string PKIEFKHBGCO(in OHAJOLBEFND MMJFAIFNOOK)
		{
			return null;
		}

		private static string OHMNPHEKNNM(in OHAJOLBEFND MMJFAIFNOOK)
		{
			return null;
		}

		private static string CIHLNFAMJBP(in OHAJOLBEFND MMJFAIFNOOK)
		{
			return null;
		}

		private static string ONGEALJJBKO(in OHAJOLBEFND MMJFAIFNOOK)
		{
			return null;
		}

		private string KMHPIEDNKGP(in OHAJOLBEFND MMJFAIFNOOK)
		{
			return null;
		}

		private void PBNJFEDILHH(string BOGCJKAMALE, string HGIIJBKEGMK, Action ALJKAIDIOIF, Action BOKBFDBAEMC = null, Action FAFJGIFFBGA = null)
		{
		}

		private void EGAFFCBOKIK()
		{
		}

		public bool IsGlobal(MIEKHIHLDEK DCJDBKALJKL)
		{
			return false;
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void CAEMACAOCJK()
		{
		}

		private void CKBMJIDOKBF()
		{
		}

		private void DFPKHNIDFKF()
		{
		}

		private void CEPBJPHJDGL()
		{
		}

		private void NAFLDEGBGGK(Guid GLLFFIFLOAG)
		{
		}

		private void HLNHEABHAFL()
		{
		}

		private long KHIJMNGLLPI()
		{
			return 0L;
		}

		private long BADNLBLAEDO()
		{
			return 0L;
		}

		private IEnumerable<long> OJLGEHAHEMD()
		{
			return null;
		}

		private void HCBFIPACJEC(string JKDKPKBFNDE)
		{
		}

		private int OJEODBBDNIO()
		{
			return 0;
		}

		private MPBBNJKOEPO GHBHNKHLLOI(JNODIIINKKJ.BLCIGIHGEAC CGOGKMJGPMB)
		{
			return null;
		}

		private void IPIKFNEKKGK(string MANKFIKGIGJ, GJKDNHNGIAL MKNAFLPHLNJ, (Guid, string)[] HENHIPDBFAI)
		{
		}

		public void TryPlayErrorSFX(JNODIIINKKJ.BLCIGIHGEAC CGOGKMJGPMB)
		{
		}

		private static AudioRolloff CDFEFBLGMOH(OGJHFKGLLGE EMNKPFBIACK, float KHNMAMLOJCA)
		{
			return null;
		}

		[PBOMGCLBFHF]
		public void RpcPlayAudioClipAtPosition(Guid APDMBMBLBOL, Vector3 INLGLHIPOMC, float COFONCKAJCK, float GNDCFGOIDDP, bool OFCDFEJJGCO, OGJHFKGLLGE EMNKPFBIACK, float KHNMAMLOJCA, HHOIEGJNNEC LAEAGAJDAFO, string ILMHPJCNPFL)
		{
		}

		[PBOMGCLBFHF]
		public void RpcPlayAudioSampleAtPosition(string AIGKNOMENDE, float AAMPPPKCFEH, string OGDHBHIPPMA, Vector3 INLGLHIPOMC, float COFONCKAJCK, float GNDCFGOIDDP, bool OFCDFEJJGCO, OGJHFKGLLGE EMNKPFBIACK, float KHNMAMLOJCA, HHOIEGJNNEC LAEAGAJDAFO, string ILMHPJCNPFL)
		{
		}

		public Task PlayAudioAtPosition(MHLDMCJALLH LFHJCLPPJMG, Vector3 INLGLHIPOMC, float COFONCKAJCK, float GNDCFGOIDDP, bool OFCDFEJJGCO, OGJHFKGLLGE EMNKPFBIACK, float KHNMAMLOJCA, HHOIEGJNNEC LAEAGAJDAFO, string ILMHPJCNPFL)
		{
			return null;
		}

		private void EHHIIDDCBPA(int LMOJDCNCLPF)
		{
		}

		private void NBPEOPANJMK(GBAJDOHJDHJ GADDGJANIGG)
		{
		}

		public void OnRoomReset()
		{
		}

		private void OBLFNDKBBDK(EKIIIJIOBCC KNBPIEINLIG)
		{
		}

		private void IHHHMMIODNB()
		{
		}

		private void ACNBCJOILCG(float HOHFHDNPBAI)
		{
		}

		public void NotifyCircuitVisibilityChanged()
		{
		}

		private IEnumerable<EKIIIJIOBCC> CMDFPEOMBBM()
		{
			return null;
		}

		private bool HGEBDFKLDDM(EKIIIJIOBCC KNBPIEINLIG)
		{
			return false;
		}

		private Task GGEAJNLAMLF(List<EKIIIJIOBCC> BFEAIDOEPIH, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		private void AKOLCEOHFGA(MIEKHIHLDEK OLAIGOCOHJN, MIEKHIHLDEK BFPEFGIDOEM)
		{
		}

		private void HDAGGGCPAHO(EKIIIJIOBCC KNBPIEINLIG)
		{
		}

		public void Publish(in Guid JJLIIOCLCNA, in IENGILMPFNE IECPCEEBGJM)
		{
		}

		public bool TryGetOrCreateChip(Guid KKBFAENPLID, out Chip JJMNDCAFBDA)
		{
			JJMNDCAFBDA = null;
			return false;
		}

		public Chip GetOrCreateChip(EKIIIJIOBCC ACDDHCIMHIF)
		{
			return null;
		}

		public Chip CreateChip(EKIIIJIOBCC KNBPIEINLIG)
		{
			return null;
		}

		private static void BAAAAEIHONF(Chip JJMNDCAFBDA)
		{
		}

		private void LONCKDKGJAD(Chip JJMNDCAFBDA)
		{
		}

		public bool TryShowError(global::FAIKNKAIPLB<MFEHAEMCKCJ> GCBHEJANCJK)
		{
			return false;
		}

		public void LogCircuitsWarning(JEGAPHLGBJA GCBHEJANCJK, string NLJOHEKGNDH)
		{
		}

		private void PPJGBDNILJD(FEBAEOIGKOE HOFDCJAAGMA)
		{
		}

		private void HHNOKGEMAHL(FEBAEOIGKOE HOFDCJAAGMA)
		{
		}

		private void JCHPJHNOKIP()
		{
		}

		public Task<global::LAFJBBFBCGA<Chip, BBMENPGBPEA>> RequestCreateNewCircuitNode(Type DNOFOEDJABJ, Guid KKBFAENPLID, Vector3 GJODHPCIBLK, Quaternion BNAFAJDJMAK)
		{
			return null;
		}

		public ECNCNNBLHJH SerializeCircuits(bool MBOJPGKGPOI)
		{
			return null;
		}

		public void AddRoomSaveProperties(DPKIGFPJMOG AJHKINNLKAK)
		{
		}

		private (int, int, int) IFEKHDFBGAB(MIEKHIHLDEK DCJDBKALJKL)
		{
			return default;
		}

		private int DPHELEJLKBF(LEPCMENIFGP DCJDBKALJKL)
		{
			return 0;
		}

		private void AEBPMAACKNJ()
		{
		}

		private void CKEBOACDKEE()
		{
		}

		private void GHHPENDALAA()
		{
		}

		private IEnumerator<EGGPGCCKPCO> JAGNBPFNOAG()
		{
			return null;
		}

		public void RequestDeleteCloudDataEntry(MGBCICMHCOL KLMCNEIFLMA)
		{
		}

		public void RequestResetCloudDataEntry(MGBCICMHCOL KLMCNEIFLMA)
		{
		}

		private Task<bool> JAGCAOKKAID(string AIGKNOMENDE, float MHGGMDKJNLA, string OGDHBHIPPMA, bool NLHJEOIDFEF)
		{
			return null;
		}

		[PBOMGCLBFHF]
		public void RpcReceiveAction(int AMMLAHNGBBA, int AMGNCPLIAAC, CAFMMAJMNLD IBKGKDECOEG)
		{
		}

		[PBOMGCLBFHF]
		public void RpcObjectReceiveRpc(NDMIIOKAAIK PCPEJHIMHJJ)
		{
		}

		public static Task<global::LAFJBBFBCGA<T, HODHNINHENI>> SendReliable<T>(Func<Task<global::LAFJBBFBCGA<T, HODHNINHENI>>> NIMLDCKCIPL)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public void RequestModifyUGCReward(IGHPMNDHNII MPDLMFIPMII)
		{
		}

		public void RequestDeleteUGCReward(Guid IGBONJIMGNI)
		{
		}

		private bool DNMAJELLBOC(in Guid KKBFAENPLID, out Chip JJMNDCAFBDA)
		{
			JJMNDCAFBDA = null;
			return false;
		}

		bool EPHNMPLOKJG.TryGetChip(in Guid KKBFAENPLID, out Chip JJMNDCAFBDA)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DNMAJELLBOC
			return this.DNMAJELLBOC(in KKBFAENPLID, out JJMNDCAFBDA);
		}

		[CompilerGenerated]
		private void MOEHJKKMOII(GMBCDOMHMFF.CNIHIHBNGBO BHOEECKAJGN)
		{
		}

		[CompilerGenerated]
		private void NDEIGCPJOBB(string NLJOHEKGNDH)
		{
		}

		[CompilerGenerated]
		private object ADNFCCDMJEK()
		{
			return null;
		}

		[CompilerGenerated]
		private void BIAHPGFCONJ(float GADDGJANIGG)
		{
		}

		[CompilerGenerated]
		private object JLFEDMDIFBI()
		{
			return null;
		}

		[CompilerGenerated]
		private object EIHCCDAOPGG()
		{
			return null;
		}

		[CompilerGenerated]
		private object MIJIDJOBHGA()
		{
			return null;
		}

		[CompilerGenerated]
		private object ECKFHMBELFM()
		{
			return null;
		}

		[CompilerGenerated]
		private Task JPKIAPJOMEC(AHDBIFJNDCH ADCFFAJGNAM, CancellationToken NDKAKDJMDIF)
		{
			return null;
		}

		[CompilerGenerated]
		private void LFOODDDBPAP(AHDBIFJNDCH PCPEJHIMHJJ)
		{
		}

		[CompilerGenerated]
		private object NFEAEIIIMNC()
		{
			return null;
		}

		[CompilerGenerated]
		internal static Guid FCJNBEHBALN(long EPOBIFCHLNM, long FPPOCBBEOPL)
		{
			return default;
		}

		[CompilerGenerated]
		private global::LAFJBBFBCGA<ECNCNNBLHJH, KNMCMJNOLCC> PDCPLOGPBLA(KHMOHFAFGBI KGMPBFBAMCF)
		{
			return default;
		}

		[CompilerGenerated]
		private void CCMJGKEBDKJ(AHDBIFJNDCH ADCFFAJGNAM)
		{
		}

		[CompilerGenerated]
		private object PMLFHIGNBFE()
		{
			return null;
		}

		[CompilerGenerated]
		private void IEMNAOEPIEL(AHDBIFJNDCH ADCFFAJGNAM)
		{
		}

		[CompilerGenerated]
		private object PONJABLBBFG()
		{
			return null;
		}

		[CompilerGenerated]
		private object EKJPLHBEJGF()
		{
			return null;
		}

		[CompilerGenerated]
		private void HAANCFAGFJI(DBJMAFIOFFK AAFNLLCIFBP, ref OICNHMEPLGM P_1)
		{
		}

		[CompilerGenerated]
		private RecRoomAudioClip JIJGNILKKOP(JNODIIINKKJ.BLCIGIHGEAC NLJOHEKGNDH)
		{
			return null;
		}

		[CompilerGenerated]
		private void KLLNPKOLEPP()
		{
		}

		[CompilerGenerated]
		internal static JNODIIINKKJ.BLCIGIHGEAC AHKNMAKLMJJ(GJKDNHNGIAL KCIAKHCIGFA)
		{
			return JNODIIINKKJ.BLCIGIHGEAC.None;
		}

		[CompilerGenerated]
		private Task CLBCOKJPPFD()
		{
			return null;
		}

		[CompilerGenerated]
		internal static int DMJJIHNJHMH(CircuitsV2Manager DIJPFIMLAFB, List<EKIIIJIOBCC> BJHKOGLKONI, in CancellationToken MAGOODPOEPA, int NBALHANIENK, int HIJKHPMDNMK)
		{
			return 0;
		}

		[CompilerGenerated]
		private Task PIGIAHFEINI(CircuitsV2Manager DIJPFIMLAFB, int GFJMKHCFLOH, int MHJEILOAOFE, CAFMMAJMNLD CECOAPIEKGO)
		{
			return null;
		}
	}
}
