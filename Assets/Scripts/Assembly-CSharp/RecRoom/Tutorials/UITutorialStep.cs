using System;
using System.Runtime.CompilerServices;
using RRUI.Highlights.Visuals;
using UnityEngine;

namespace RecRoom.Tutorials
{
	[Serializable]
	public abstract class UITutorialStep : LHKOKHMDBEO, PMCNOFPBHIG
	{
		[SerializeField]
		protected string analyticsStepName;

		[CompilerGenerated]
		private Action<EJFGIMBJACH> EffectAdded;

		[CompilerGenerated]
		private Action<EJFGIMBJACH> EffectRemoved;

		[SerializeField]
		private bool useCustomHighlightId;

		[SerializeField]
		private string customHighlightId;

		[SerializeField]
		[HNDJNPOHFJK]
		private string buttonHighlightId;

		[TextArea]
		[SerializeField]
		private string tutorialLabelText;

		[SerializeField]
		private bool allowDiagonalTextPositioning;

		[SerializeField]
		private bool overrideTextBoxWidth;

		[SerializeField]
		private float textBoxWidth;

		[SerializeField]
		private bool overrideLineConnectionPosition;

		[SerializeField]
		private HighlightFadeout.PHAKCILPNCL positionOverride;

		private AJBAOOEKCBF highlightEffect;

		private BFABKMNDMMP highlightSystem;

		protected CJBLEJIPCAP tutorialManager;

		private IILDCCEMGBA gameConfigsProvider;

		protected abstract MAJPKEBMCFC Tutorial { get; }

		public bool Ready => false;

		public EAFMJFAOFPI Result { get; private set; }

		protected virtual string TutorialLabelTextGameConfig { get; }

		private HighlightFadeout.PHAKCILPNCL? PositionOverride => null;

		private string HighlightId => null;

		private bool BlockAllInputOnHighlight => false;

		private bool RemoveHighlightOnFinish => false;

		private float? TextBoxWidthOverride => null;

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

		public void Init()
		{
		}

		public void StartFlow()
		{
		}

		public void ResetState()
		{
		}

		public void CancelFlow()
		{
		}

		private void KAIGLGINDDL()
		{
		}

		public void BABCIGBAFPD(float OKBAJEAPIHG)
		{
		}

		protected virtual void EJLPBKHHOOC(bool GELIBHKPIBG = false)
		{
		}

		protected void ONHPMDCHMOK()
		{
		}

		private void OHEHGLMGBEO()
		{
		}

		private void AFAACMGMBEJ()
		{
		}

		protected virtual void MJFDFIMOAGK()
		{
		}

		private void JIACICIDKAM(string OFFJPOMOLDJ)
		{
		}

		private void ACEICABLIJL(EJFGIMBJACH GHICKOKIDPF)
		{
		}

		private void LLELENOALIP(EJFGIMBJACH GHICKOKIDPF)
		{
		}

		private void AAGLFDBKEKB()
		{
		}

		private void KGLDALMCKCG()
		{
		}
	}
}
