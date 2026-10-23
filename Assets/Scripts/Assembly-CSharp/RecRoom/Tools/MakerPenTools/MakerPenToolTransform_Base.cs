using System;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolTransform_Base<T> : MakerPenTool
	{
		[NonSerialized]
		protected TransformHandleManager transformHandleManager;

		[NonSerialized]
		private bool shouldPopStackWhenFinished;

		private global::BOEIHNMGKLM<T> enterWithTriggerDownArgs;

		private bool clearSelectionOnRelease;

		protected abstract global::FNLEEFFPAAJ<T> SelectionContext { get; }

		protected abstract global::PGGFNBAFDMB<T> SelectState { get; }

		protected GJEAOEFGMJC ActiveDragState { get; set; }

		public global::FNLEEFFPAAJ<T> ExternalSelectionContext => null;

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

		public override LAHBDKNMNHN JAFIAHCBPBP(EHLHPNPGFLN HANBCMDMCAG)
		{
			return null;
		}

		private void JGGJALMLAOB()
		{
		}

		private void BCKBCDJAHOM(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		private bool LJCJEKKPMLK(Vector3 BBODCPNAEHJ, T PBKOJJOJGMB, EHLHPNPGFLN FGGIPNDPEFP = null)
		{
			return false;
		}

		protected virtual void GPEKJDFHOLB()
		{
		}

		private void DFOAFPMECNC()
		{
		}

		private void GPBOLLLDDEI(T PBKOJJOJGMB, Vector3 CBEDHLDJFFN, Vector3 JAEGDHEEDEP)
		{
		}

		protected abstract void ENPNICMKOEG(T PBKOJJOJGMB, Vector3 HJODBKHINKL, ECMNCNMENKO OJLJDHOEBMM);

		protected abstract bool KJFLJGIEJPC();

		protected abstract void EEKEKMPBLJJ(Vector3 GHBLBGFLEBE);
	}
}
