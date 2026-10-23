using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	[DisallowMultipleComponent]
	public abstract class ConditionalButton : MonoBehaviour
	{
		protected const int IFDHNPEMEKF = 0;

		private int ONMKHCBEKPF;

		[SerializeField]
		protected Button3DBase button;

		[SerializeField]
		private TextMeshProUGUI labelText;

		[SerializeField]
		private Image buttonImage;

protected int HBLMHPAOECK
{
get 		{
			return this.ONMKHCBEKPF;
		}

set {
		}
}

protected TextMeshProUGUI HPJOICOAANE
{
get 		{
			return null;
		}

}

protected Image NOMEKOCINCN
{
get 		{
			return null;
		}

}

		public void Button_Action()
		{
		}

		protected virtual void OnEnable()
		{
		}

		public void UpdateButton()
		{
		}

		protected abstract void OEGMENAEEAE();

		protected virtual void IJBABHBJKGK()
		{
		}

		protected virtual bool FNINFCOHBOK()
		{
			return this.ONMKHCBEKPF != 0;
		}

		protected abstract void GFCICHDHHJG();
	}
	public abstract class ConditionalButton<T> : ConditionalButton where T : Button3DBase
	{

public T Button
{
get 		{
			return null;
		}

}
	}
}
