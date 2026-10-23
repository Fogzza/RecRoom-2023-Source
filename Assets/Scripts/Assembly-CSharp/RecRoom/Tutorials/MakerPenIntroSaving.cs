using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RecRoom.Tutorials.Helpers;
using UnityEngine;

namespace RecRoom.Tutorials
{
	[Serializable]
	public class MakerPenIntroSaving : MakerPenIntroStep
	{
		private sealed class MPBNPGFNLHM : IEnumerator<EGGPGCCKPCO>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private EGGPGCCKPCO _003C_003E2__current;

			public MakerPenIntroSaving _003C_003E4__this;

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
			public MPBNPGFNLHM(int _003C_003E1__state)
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

		[SerializeField]
		private MakerPenIntroOpenMenu prompt;

		[SerializeField]
		private ConditionalString subtitle;

		[HNDJNPOHFJK]
		[SerializeField]
		private string thisRoomButton;

		[SerializeField]
		private ConditionalString thisRoomButtonLabel;

		[HNDJNPOHFJK]
		[SerializeField]
		private string saveRoomButton;

		[SerializeField]
		private ConditionalString saveRoomButtonLabel;

		private const string FADEOUT_ELEMENT = "fadeout";

		private LKGILLBEJEK processingPromise;

		private AJBAOOEKCBF thisRoomButtonHighlight;

		private AJBAOOEKCBF saveRoomButtonHighlight;

		private BFABKMNDMMP highlightSystem;

		private readonly HashSet<string> pressedElements;

		public override bool Ready => false;

		public override void Init()
		{
		}

		public override void IFFGDKIHGNH()
		{
		}

		protected override void KMKMFENKIEM()
		{
		}

		protected override void JNIOJFAAGPE()
		{
		}

		protected override void DDNLOPKLINK()
		{
		}

		private IEnumerator<EGGPGCCKPCO> LHALCDOMAMH()
		{
			return null;
		}

		private void JIACICIDKAM(string OFFJPOMOLDJ)
		{
		}

		private void MJFDFIMOAGK()
		{
		}

		[CompilerGenerated]
		private bool GNCJHLEHKNM()
		{
			return false;
		}

		[CompilerGenerated]
		private bool DJONCJDDMNA()
		{
			return false;
		}
	}
}
