using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolClone_Base<T> : MakerPenTool
	{
		private sealed class FCMENNEANJK
		{
			public MakerPenToolClone_Base<T> _003C_003E4__this;

			public global::PGGFNBAFDMB<T>.FLDJMPPPIEO eventData;

			internal void _003CSelectState_OnDragOrHoldStartEvent_003Eb__0()
			{
			}
		}

		[NonSerialized]
		private CloneHandleManager cloneHandleManager;

		[NonSerialized]
		private CloneHandleManager mirrorHandleManager;

		protected abstract global::FNLEEFFPAAJ<T> SelectionContext { get; }

		protected abstract global::PGGFNBAFDMB<T> SelectState { get; }

		public override string HudLabel => null;

		public override Sprite HudSprite => null;

		public abstract void OJFOBGBGLKN(Vector3 HJODBKHINKL);

		public override void BJDNGFKFKPK(JPAACPJFONC FFGKGJBJJIB, HHNPLBOFAGE HHOMFBOLLIJ)
		{
		}

		public override void EHMICKMBCPH()
		{
		}

		public override void KENBMBNOMKI(JPAACPJFONC FFGKGJBJJIB)
		{
		}

		protected abstract bool KJFLJGIEJPC();

		private void JGGJALMLAOB()
		{
		}

		private void EFMIMBABNIN(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		[CompilerGenerated]
		private bool? PKDKLJFOMDG()
		{
			return null;
		}

		[CompilerGenerated]
		private bool? AABGLCMCNEE()
		{
			return null;
		}
	}
}
