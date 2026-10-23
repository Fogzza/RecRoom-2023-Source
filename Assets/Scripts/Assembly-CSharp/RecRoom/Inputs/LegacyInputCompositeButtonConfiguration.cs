using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public class LegacyInputCompositeButtonConfiguration : JINAPIAOJIM
	{
		private sealed class BFNFGLIOMKJ : IEnumerable<KeyCode>, IEnumerable, IEnumerator<KeyCode>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private KeyCode _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public LegacyInputCompositeButtonConfiguration _003C_003E4__this;

			private LegacyInputButtonConfiguration[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private IEnumerator<KeyCode> _003C_003E7__wrap3;

			KeyCode IEnumerator<KeyCode>.Current
			{
				[DebuggerHidden]
				get
				{
					return KeyCode.None;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public BFNFGLIOMKJ(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<KeyCode> IEnumerable<KeyCode>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private sealed class PPPMGOAHLEL : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public LegacyInputCompositeButtonConfiguration _003C_003E4__this;

			private LegacyInputButtonConfiguration[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private IEnumerator<string> _003C_003E7__wrap3;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

 object global::System.Collections.IEnumerator.Current
{
get 				{
					return null;
				}

}

			[DebuggerHidden]
			public PPPMGOAHLEL(int _003C_003E1__state)
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
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public CCIIMHAOFIC sourceType;

		public LegacyInputButtonConfiguration[] buttons;

		public CCIIMHAOFIC SourceType => CCIIMHAOFIC.Continuous;

		public IEnumerable<KeyCode> DiscreteKeys => null;

		public IEnumerable<string> ContinuousSourceNames => null;
	}
}
