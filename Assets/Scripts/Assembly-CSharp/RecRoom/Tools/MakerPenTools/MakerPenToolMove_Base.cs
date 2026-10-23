using System;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public abstract class MakerPenToolMove_Base<T> : MakerPenTool
	{
		protected global::JMLHLJFACAP<T> converter;

		protected global::DDLEHONFEBP<T> makerSelection;

		[NonSerialized]
		protected TranslationHandleManager translationHandleManager;

		[NonSerialized]
		private bool shouldPopStackWhenFinished;

		private global::BOEIHNMGKLM<T> enterWithTriggerDownArgs;

		private bool clearSelectionOnRelease;

		protected abstract global::PGGFNBAFDMB<T> SelectState { get; }

		protected abstract global::AIGGMOPIIKJ<T> Selection { get; }

		protected GJEAOEFGMJC ActiveDragState { get; set; }

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

		private void JCJEEDPJKPO(global::PGGFNBAFDMB<T>.FLDJMPPPIEO OEPDOIOJPHD)
		{
		}

		private GJEAOEFGMJC JFGGICEKHKD(AnchorHandle GPDDMFGCOCF)
		{
			return null;
		}

		private bool ONMGAKDFAPA(Vector3 BBODCPNAEHJ, T PBKOJJOJGMB, EHLHPNPGFLN FGGIPNDPEFP = null)
		{
			return false;
		}

		protected virtual void MAGGPBIBCKP()
		{
		}

		private void BLDKNEPNIBE()
		{
		}

		private void GPBOLLLDDEI(T PBKOJJOJGMB, Vector3 CBEDHLDJFFN, Vector3 JAEGDHEEDEP)
		{
		}

		protected abstract GJEAOEFGMJC MIOAGJGBIHH(Vector3 HJODBKHINKL, ECMNCNMENKO OJLJDHOEBMM, Vector3? FBEAOGFBGAD = null);

		protected abstract bool KJFLJGIEJPC();

		protected abstract bool ICKNPKFFJHD();

		protected abstract bool DPCBFEBENDL(T PBKOJJOJGMB);
	}
}
