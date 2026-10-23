using System;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public abstract class StackedUIFlowBase : MonoBehaviour, EBHFGBFDGJM
	{
		private Action AGLNBGJKOJI__BackingField;

		private Action<bool> KFDILCMHPPC__BackingField;

		public bool FirstFlow;

		[SerializeField]
		[HideInInspector]
		protected bool forceSpecificSize;

		[SerializeField]
		[HideInInspector]
		protected OMNLIPPAPDI forcedSize;

		[SerializeField]
		protected bool iosForceLargeSize;

		[SerializeField]
		private bool useCustomSizeForScaling;

		[SerializeField]
		private RectTransform customSizeRect;

		private UIInteractionRestriction[] GHBJKJELALJ;

		private ResizableElementBase[] LAKNINKICCN;

		private StackedUIBase NNCBALMPOAM;

		private bool FCKHHCNODNI;

		private string LDPCFDMCJLH;

		private bool NHEGOALHKEL;

		private Action<StackedUIFlowBase> DCNJJBJKLOP__BackingField;

public StackedUIBase UIBase
{
get 		{
			return null;
		}

private set {
		}
}

public bool IsCurrentFlow
{
get 		{
			return false;
		}

private set {
		}
}

protected virtual string NPNGNBNICFF
{
get 		{
			return null;
		}

}

public bool ForceSpecificSize
{
get 		{
			return false;
		}

}

public OMNLIPPAPDI ForcedSize
{
get 		{
			return OMNLIPPAPDI.NORMAL;
		}

}

protected virtual string CIKPANGLFGP
{
get 		{
			return null;
		}

}

protected string PNBJDAPDBGK
{
get 		{
			return null;
		}

}

public bool IsVisibleInStack
{
get 		{
			return false;
		}

set {
		}
}

public event Action FlowEntered {
add {
		}
remove {
		}
}

public event Action<bool> FlowExited {
add {
		}
remove {
		}
}

public event Action<StackedUIFlowBase> CloseRequested {
add {
		}
remove {
		}
}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public virtual void StackedUIOpened()
		{
		}

		public virtual void StackedUIClosed()
		{
		}

		public virtual void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		public void SetAmplitudeCommandContext(string DELCOFCGDFF)
		{
		}

		public void RefreshResizableElements()
		{
		}

		public bool TryGetCustomSizeForScaling(out Vector2 DIBFHDGJJGA)
		{
			DIBFHDGJJGA = default;
			return false;
		}

		public bool CanInteract(Selectable DNPIJEOOLKB)
		{
			return false;
		}

		public virtual void Show()
		{
		}

		public virtual void Hide()
		{
		}

		public virtual void OnFlowEntered(StackedUIFlowBase OHINCEKNIJF)
		{
		}

		public virtual void OnFlowExited(StackedUIFlowBase GGBPGKFCHDK, bool IFLEKNIGFGM)
		{
		}

		public virtual void Button_ExitFlow()
		{
		}

		public void ExitFlow()
		{
		}

		public void RequestClose()
		{
		}

		public virtual void Button_Share()
		{
		}

		protected virtual bool AOOGCBCALDP()
		{
			return false;
		}

		protected virtual bool MIGHBFJHBPN()
		{
			return false;
		}

		public virtual void Button_Invite()
		{
		}

		protected virtual bool HELGFGMCPMI()
		{
			return false;
		}

		protected virtual bool NPMIMMBFBAL()
		{
			return false;
		}

		public virtual void Button_EnterCode()
		{
		}

		protected virtual bool IMCMBEHDMAF()
		{
			return false;
		}

		protected virtual bool KNKKMJEKDNE()
		{
			return false;
		}

		public void Resize(OMNLIPPAPDI CAPKFCHDLFA)
		{
		}

		protected virtual void KMCIKAHLOHC(OMNLIPPAPDI CAPKFCHDLFA, bool IHLDMKBBMHJ)
		{
		}

		public virtual void UpdateUIElements()
		{
		}
	}
}
