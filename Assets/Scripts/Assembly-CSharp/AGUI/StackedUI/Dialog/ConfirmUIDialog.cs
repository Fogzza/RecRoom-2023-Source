namespace AGUI.StackedUI.Dialog
{
	public abstract class ConfirmUIDialog : UIDialog<HGKINAOMNIF>
	{
		public virtual void Button_Affirmative()
		{
		}

		public void Button_Cancel()
		{
		}

		public void Button_Negative()
		{
		}

		public void Button_NotNow()
		{
		}

		public virtual void Button_Other()
		{
		}

		public override void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public override void ForceCancel(bool OANFJFDMNOM)
		{
		}
	}
	public abstract class ConfirmUIDialog<T1> : ConfirmUIDialog
	{
		public abstract global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(T1 FMLCCJGJPCD);
	}
	public abstract class ConfirmUIDialog<T1, T2> : ConfirmUIDialog
	{
		public abstract global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(T1 FMLCCJGJPCD, T2 MPCLNGKHMLO);
	}
	public abstract class ConfirmUIDialog<T1, T2, T3> : ConfirmUIDialog
	{
		public abstract global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, T3 KPIDGAICEOB);
	}
	public abstract class ConfirmUIDialog<T1, T2, T3, T4> : ConfirmUIDialog
	{
		public abstract global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, T3 KPIDGAICEOB, T4 IIBPJJDJKEG);
	}
	public abstract class ConfirmUIDialog<T1, T2, T3, T4, T5> : ConfirmUIDialog
	{
		public abstract global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, T3 KPIDGAICEOB, T4 IIBPJJDJKEG, T5 AHDEEDKHJMM);
	}
	public abstract class ConfirmUIDialog<T1, T2, T3, T4, T5, T6> : ConfirmUIDialog
	{
		public abstract global::NCOKFFGPIJM<HGKINAOMNIF> ShowDialog(T1 FMLCCJGJPCD, T2 MPCLNGKHMLO, T3 KPIDGAICEOB, T4 IIBPJJDJKEG, T5 AHDEEDKHJMM, T6 AOCALPHJNGB);
	}
}
