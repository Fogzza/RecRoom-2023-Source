using System;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolRotate_Base<T> : MakerPenTool
	{
		[NonSerialized]
		protected RotationHandleManager rotationHandleManager;

		[NonSerialized]
		private NEJCKADMGDL rotationVelocityTracker;

		[NonSerialized]
		private OEEBBDJIDDP rotationVelocityProvider;

		protected abstract global::PGGFNBAFDMB<T> SelectState { get; }

		public override string HudLabel => null;

		public override Sprite HudSprite => null;

		public override void IHEKMEOIBOI(HHNPLBOFAGE IACECANFEKI, FBEHJNCKJPN CIMCLAFMGFE)
		{
		}

		public override void BJDNGFKFKPK(JPAACPJFONC FFGKGJBJJIB, HHNPLBOFAGE HHOMFBOLLIJ)
		{
		}

		public override void KENBMBNOMKI(JPAACPJFONC FFGKGJBJJIB)
		{
		}

		private void JGGJALMLAOB()
		{
		}

		private void JCJEEDPJKPO(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		private void EFMIMBABNIN(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		private GJEAOEFGMJC JFGGICEKHKD(AnchorHandle GPDDMFGCOCF)
		{
			return null;
		}

		protected abstract bool GAFCELGPKBK(T ICHBECDKHOJ);

		protected abstract Pose GIOIFPFJPOI();

		protected abstract GJEAOEFGMJC AGCCOPGCBIC();

		protected abstract void GHJELLHMLJM(T ICHBECDKHOJ, Ray ANONPGKEDGP, Vector3 CEMHEJBNIBC);

		protected abstract void DMJEMNCKBKJ(T ICHBECDKHOJ);

		protected abstract GJEAOEFGMJC MEFAAEDEGDK(Ray ANONPGKEDGP, Vector3 PLKCNIBDCDC);

		protected abstract bool KJFLJGIEJPC();

		private float EILKHAOGGDJ()
		{
			return 0f;
		}
	}
}
