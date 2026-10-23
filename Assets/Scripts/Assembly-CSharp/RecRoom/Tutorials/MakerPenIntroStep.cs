using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RecRoom.Tutorials
{
	[Serializable]
	public abstract class MakerPenIntroStep : LHKOKHMDBEO, PMCNOFPBHIG
	{
		[Flags]
		public enum OMHBGKPLKKG
		{
			None = 0,
			HoldingMakerPen = 1,
			MenusAreClosed = 2,
			MakerPenMenuIsClosed = 4,
			MakerPenHasSelection = 8,
			MakerPenHasNoSelection = 0x10
		}

		[SerializeField]
		private string analyticsStepName;

		[SerializeField]
		[Space]
		private bool requiresMakerPenMenuOpen;

		[CompilerGenerated]
		private Action<EJFGIMBJACH> EffectAdded;

		[CompilerGenerated]
		private Action<EJFGIMBJACH> EffectRemoved;

		private MakerPenIntroOpenMenu openMakerPenMenuPrompt;

		private OILDLLGEMKP.JBBFMKDNGNI interactionCategory;

		private readonly HashSet<EJFGIMBJACH> cancelableEffects;

		private readonly CGHNCLKKGLK activePrompts;

		private readonly LGBMDLCLLCB activeControlsPrompts;

		private readonly LGGDEMJBLJJ activeSubtitles;

		public abstract bool Ready { get; }

		public EAFMJFAOFPI Result { get; private set; }

		protected string AnalyticsStepName => null;

		protected bool IsInVR => false;

public event Action<EJFGIMBJACH> OJDAPCHDGCL {
add {
		}
remove {
		}
}

public event Action<EJFGIMBJACH> NNPPNDDCHKL {
add {
		}
remove {
		}
}

		public virtual void Init()
		{
		}

		public void EPIJDNLKBJO(MakerPenIntroOpenMenu HHNMDIGPGKO)
		{
		}

		public void StartFlow()
		{
		}

		protected abstract void KMKMFENKIEM();

		public void ResetState()
		{
		}

		protected abstract void DDNLOPKLINK();

		public void CancelFlow()
		{
		}

		protected abstract void JNIOJFAAGPE();

		protected void KAIGLGINDDL()
		{
		}

		protected void CNLHDAKKLLE()
		{
		}

		public virtual void BABCIGBAFPD(float OKBAJEAPIHG)
		{
		}

		public virtual void IFFGDKIHGNH()
		{
		}

		protected void ACEICABLIJL(EJFGIMBJACH GHICKOKIDPF, bool NHDEHDHEJFD = false)
		{
		}

		protected void LLELENOALIP(EJFGIMBJACH GHICKOKIDPF)
		{
		}

		private void CCPCKOEJFAL()
		{
		}

		protected void JHIGMJOBIGH()
		{
		}

		protected void PNLINEHJOPO()
		{
		}

		protected void LPEPBHBJHNP(TutorialPromptContext HHNMDIGPGKO, OMHBGKPLKKG DAIIEFINCHO = OMHBGKPLKKG.HoldingMakerPen | OMHBGKPLKKG.MenusAreClosed)
		{
		}

		protected void AEPMJNCDBMI(TutorialPromptContext HHNMDIGPGKO)
		{
		}

		protected void LPEPBHBJHNP(MakerPenIntroControlsPrompt HHNMDIGPGKO, OMHBGKPLKKG DAIIEFINCHO = OMHBGKPLKKG.HoldingMakerPen | OMHBGKPLKKG.MenusAreClosed)
		{
		}

		protected void AEPMJNCDBMI(MakerPenIntroControlsPrompt HHNMDIGPGKO)
		{
		}

		protected void IPPEDOJKAEB(string OEEBIOPLOMG, OMHBGKPLKKG DAIIEFINCHO = OMHBGKPLKKG.HoldingMakerPen | OMHBGKPLKKG.MenusAreClosed)
		{
		}

		protected void OAFNCDIAJGP(string OEEBIOPLOMG)
		{
		}

		private void OHEHGLMGBEO()
		{
		}

		private void AFAACMGMBEJ()
		{
		}
	}
}
