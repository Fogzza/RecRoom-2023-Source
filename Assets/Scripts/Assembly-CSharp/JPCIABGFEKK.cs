using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using RecNet;
using RecRoom.Core.Creation;
using UnityEngine;

public static class JPCIABGFEKK
{
	private sealed class EDBLFOFKFOB : IEnumerable<DHJLEHBOGBG>, IEnumerable, IEnumerator<DHJLEHBOGBG>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private DHJLEHBOGBG _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<Guid> creationContextObjectIds;

		public IEnumerable<Guid> _003C_003E3__creationContextObjectIds;

		private IEnumerator<Guid> _003C_003E7__wrap1;

 DHJLEHBOGBG global::System.Collections.Generic.IEnumerator<global::DHJLEHBOGBG>.Current
{
get 			{
				return System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002EICreationContextObject_003E_002Eget_Current();
			}

}

 object global::System.Collections.IEnumerator.Current
{
get 			{
				return null;
			}

}

		[DebuggerHidden]
		public EDBLFOFKFOB(int _003C_003E1__state)
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
		private DHJLEHBOGBG System_002ECollections_002EGeneric_002EIEnumerator_003CRecRoom_002ECore_002ECreation_002EICreationContextObject_003E_002Eget_Current()
		{
			return null;
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<DHJLEHBOGBG> IEnumerable<DHJLEHBOGBG>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private sealed class MFANELMEOLK
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CSpawnInventionHelper_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public MFANELMEOLK _003C_003E4__this;

			private TaskAwaiter<JLGDECHJNNO> _003C_003Eu__1;

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

		public OEBAEGDPBLA originalInvention;

		public string trialSource;

		public OEBAEGDPBLA spawnedInvention;

		internal Task _003CSpawnInventionHelper_003Eb__0()
		{
			return null;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct ADNBEAFIAAB : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public OEBAEGDPBLA originalInvention;

		public string trialSource;

		private MFANELMEOLK _003C_003E8__1;

		private TaskAwaiter<CreationManager.CBONKEEONIN> _003C_003Eu__1;

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

	public static IEnumerable<DHJLEHBOGBG> MDFBHNABOHG(IEnumerable<Guid> JKFFGGFKJDH)
	{
		return null;
	}

	public static CostInfo PDNLNPDLKKP(IEnumerable<DHJLEHBOGBG> GLPABBNKNEO)
	{
		return default;
	}

	public static CostInfo PDNLNPDLKKP(IEnumerable<Guid> FJOLNLJACNG)
	{
		return default;
	}

	public static bool JCONKAOEKIN(Guid IKHNIJKGJFD, out Tool IEGMBEPJMGC)
	{
		IEGMBEPJMGC = null;
		return false;
	}

	public static bool KDAMAFIFEBM(Guid IKHNIJKGJFD, out BJIJHMNPDCH MOFGFAAHLIF)
	{
		MOFGFAAHLIF = null;
		return false;
	}

	public static bool MAOKBKBEJIG(GameObject BMNLOPDIJGF, out Guid IKHNIJKGJFD)
	{
		IKHNIJKGJFD = default;
		return false;
	}

	public static void IIGBICOOOCG(RepeatedField<OELBDAKHAFC> AJDFPFGECMK, List<KeepsakeInstanceDTO> DCIPAEIKCEC)
	{
	}

	public static global::NCOKFFGPIJM<bool> DPHODICKJGM(OEBAEGDPBLA HGKKLODLHNC, string MGAGMGBLEKL)
	{
		return null;
	}

	public static global::NCOKFFGPIJM<bool> GBNLMPEGHNI(OEBAEGDPBLA HGKKLODLHNC)
	{
		return null;
	}

	private static Task<bool> GGHDKAGFHAC(OEBAEGDPBLA LONCPMKHLHK, string MGAGMGBLEKL = null)
	{
		return null;
	}

	private static void OPGPCPJELLK(OEBAEGDPBLA EGDOIKMDMJM, CreationManager.ALEFKNOEIAL PCPEJHIMHJJ)
	{
	}
}
