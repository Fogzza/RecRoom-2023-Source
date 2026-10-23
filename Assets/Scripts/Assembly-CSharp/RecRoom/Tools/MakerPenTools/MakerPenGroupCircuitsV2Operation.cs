using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Circuits.Static.Core.TypeSystem.Type;
using CircuitsV2.Lang;
using RecRoom.CircuitsV2;
using RecRoom.Core.Creation;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public class MakerPenGroupCircuitsV2Operation : MakerPenOperation
	{
		private sealed class HBOIHKMOLGP
		{
			private sealed class _003C_003CTryGroupCircuits_003Eg__GetPorts_007C4_003Ed : IEnumerable<GIGCLNPBBHL>, IEnumerable, IEnumerator<GIGCLNPBBHL>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private GIGCLNPBBHL _003C_003E2__current;

				private int _003C_003El__initialThreadId;

				public HBOIHKMOLGP _003C_003E4__this;

				private List<Edge>.Enumerator _003C_003E7__wrap1;

 GIGCLNPBBHL global::System.Collections.Generic.IEnumerator<global::GIGCLNPBBHL>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CCircuitsV2_002ELang_002EPortBase_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CTryGroupCircuits_003Eg__GetPorts_007C4_003Ed(int _003C_003E1__state)
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

				private void _003C_003Em__Finally2()
				{
				}

				[DebuggerHidden]
				private GIGCLNPBBHL System_002ECollections_002EGeneric_002EIEnumerator_003CCircuitsV2_002ELang_002EPortBase_003E_002Eget_Current()
				{
					return null;
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<GIGCLNPBBHL> IEnumerable<GIGCLNPBBHL>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private sealed class _003C_003CTryGroupCircuits_003Eg__boardCreateActions_007C20_003Ed : IEnumerable<CAFMMAJMNLD>, IEnumerable, IEnumerator<CAFMMAJMNLD>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private CAFMMAJMNLD _003C_003E2__current;

				private int _003C_003El__initialThreadId;

				public HBOIHKMOLGP _003C_003E4__this;

				private float _003CrightSide_003E5__2;

				private float _003CavgY_003E5__3;

				private int _003Ci_003E5__4;

				private Edge _003Cinput_003E5__5;

 CAFMMAJMNLD global::System.Collections.Generic.IEnumerator<global::CAFMMAJMNLD>.Current
{
get 					{
						return System_002ECollections_002EGeneric_002EIEnumerator_003CCircuits_002EStatic_002ERecRoom_002EProtobuf_002EActionData_003E_002Eget_Current();
					}

}

 object global::System.Collections.IEnumerator.Current
{
get 					{
						return null;
					}

}

				[DebuggerHidden]
				public _003C_003CTryGroupCircuits_003Eg__boardCreateActions_007C20_003Ed(int _003C_003E1__state)
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

			public Dictionary<Guid, Chip> selectedChips;

			public List<Edge> inputs;

			public MIEKHIHLDEK currentGraph;

			public List<Edge> outputs;

			public MakerPenGroupCircuitsV2Operation _003C_003E4__this;

			public bool containsDisallowedSpecificTypes;

			public Guid boardNodeId;

			public Vector3 localBoardPosition;

			public Quaternion localBoardRotation;

			public Guid boardGraphId;

			public MIEKHIHLDEK boardGraph;

			public Guid inBusId;

			public Guid outBusId;

			public List<DHJLEHBOGBG> creationContextSelection;

			public JNCJEOMBGGA remapper;

			public Quaternion worldBoardRotation;

			public JFOADMEPNEL originScope;

			public IEnumerable<Chip> allChips;

			public global::PHLHFLLLDLK<string> promise;

			public Action<BHANLMJAEPJ> _003C_003E9__14;

			internal bool _003CTryGroupCircuits_003Eb__2(Edge edge)
			{
				return false;
			}

			internal bool _003CTryGroupCircuits_003Eb__3(Edge edge)
			{
				return false;
			}

			internal IEnumerable<GIGCLNPBBHL> _003CTryGroupCircuits_003Eg__GetPorts_007C4()
			{
				return null;
			}

			internal void _003CTryGroupCircuits_003Eb__14(BHANLMJAEPJ type)
			{
			}

			internal global::NCOKFFGPIJM<global::LAFJBBFBCGA<Chip, BBMENPGBPEA>> _003CTryGroupCircuits_003Eb__6(IONEOHGOAML validateResult)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<CreationManager.BFEKGCMDJNM> _003CTryGroupCircuits_003Eb__7(global::LAFJBBFBCGA<Chip, BBMENPGBPEA> creationResult)
			{
				return null;
			}

			internal global::NCOKFFGPIJM<CreationManager.ALEFKNOEIAL> _003CTryGroupCircuits_003Eb__8(CreationManager.BFEKGCMDJNM serializeResult)
			{
				return null;
			}

			internal LAHBDKNMNHN _003CTryGroupCircuits_003Eb__9(CreationManager.ALEFKNOEIAL spawnResult)
			{
				return null;
			}

			internal IEnumerable<CAFMMAJMNLD> _003CTryGroupCircuits_003Eg__boardCreateActions_007C20()
			{
				return null;
			}

			internal void _003CTryGroupCircuits_003Eb__10()
			{
			}

			internal void _003CTryGroupCircuits_003Eb__11(string result)
			{
			}
		}

		private const float BOARD_POSITION_OFFSET = 0.25f;

		private const float BUS_POSITION_OFFSET = 0.5f;

		private const int MAX_PORT_COUNT = 64;

		private const string ERROR_MSG = "Could not create board.";

		private IReadOnlyList<TypeKind> DISALLOWED_SPECIFIC_TYPES;

		public bool CanGroupCircuits => false;

		private bool FAGEOAKAPCB(DHJLEHBOGBG BPEGJLIMPPJ)
		{
			return false;
		}

		public global::NCOKFFGPIJM<string> LLLMOJJEKLH()
		{
			return null;
		}
	}
}
