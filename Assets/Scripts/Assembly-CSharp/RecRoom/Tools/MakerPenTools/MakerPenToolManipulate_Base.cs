using System;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolManipulate_Base<T> : MakerPenTool
	{
		[NonSerialized]
		private ManipulateHandleManager manipulateHandleManager;

		protected abstract global::PGGFNBAFDMB<T> SelectState { get; }

		protected abstract global::FNLEEFFPAAJ<T> SelectionContext { get; }

		public override string HudLabel => null;

		public override Sprite HudSprite => null;

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

		protected virtual void PHFECJBLHHI(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		protected virtual void LLPBMAMBKBK(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}
	}
}
