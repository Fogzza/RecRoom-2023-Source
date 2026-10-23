using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace RecRoom.Inputs
{
	[Serializable]
	public class LegacyInputAxis2DConfiguration : JINAPIAOJIM
	{
		private sealed class FFEDPGHGHKN : IEnumerable<KeyCode>, IEnumerable, IEnumerator<KeyCode>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private KeyCode _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public LegacyInputAxis2DConfiguration _003C_003E4__this;

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
			public FFEDPGHGHKN(int _003C_003E1__state)
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

		private sealed class APIIPBOLBPG : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public LegacyInputAxis2DConfiguration _003C_003E4__this;

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
			public APIIPBOLBPG(int _003C_003E1__state)
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

		public string continuousHorizontalSourceName;

		public string continuousVerticalSourceName;

		public KeyCode discreteUpKey;

		public KeyCode discreteDownKey;

		public KeyCode discreteRightKey;

		public KeyCode discreteLeftKey;

		public bool canApplyDeadzone;

		public CCIIMHAOFIC SourceType => CCIIMHAOFIC.Continuous;

		public IEnumerable<KeyCode> DiscreteKeys => null;

		public IEnumerable<string> ContinuousSourceNames => null;
	}
}
