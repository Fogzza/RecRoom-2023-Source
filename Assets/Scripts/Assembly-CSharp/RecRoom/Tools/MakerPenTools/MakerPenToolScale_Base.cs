using System;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolScale_Base<T> : MakerPenTool
	{
		[NonSerialized]
		private ScaleHandleManager scaleHandleManager;

		protected virtual global::FNLEEFFPAAJ<T> SelectionContext { get; }

		protected abstract global::PGGFNBAFDMB<T> SelectState { get; }

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

		private void JGGJALMLAOB()
		{
		}

		private void BCKBCDJAHOM(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		private void JCJEEDPJKPO(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		private GJEAOEFGMJC JFGGICEKHKD(AnchorHandle GPDDMFGCOCF)
		{
			return null;
		}

		protected abstract GJEAOEFGMJC BBEIEDDNPAB(Vector3 CCINCOMNJAK, Vector3 HJODBKHINKL, Vector3 BDFEBHPONEM, ECMNCNMENKO MAIIBAAILHG);

		protected abstract GJEAOEFGMJC NOFHLJOGIPL(Quaternion MCANINBFBCC, Color HMCAFGCGFJF, Vector3 NJJFMDKHHLK, Vector3 EGCHNKDMODB);

		protected abstract bool KJFLJGIEJPC();

		protected abstract void ENPNICMKOEG(T PBKOJJOJGMB, Ray ANONPGKEDGP, Vector3 CEMHEJBNIBC);
	}
}
