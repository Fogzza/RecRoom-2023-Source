using TMPro;
using UnityEngine;

namespace AGUI.StackedUI.Dialog
{
	public abstract class EnterTextDialog<T> : UIDialog<T, HENPPMLGJNP>
	{
		[SerializeField]
		private Button3D cancelButton;

		[SerializeField]
		private Button3D saveButton;

		[SerializeField]
		private TextMeshProUGUI cancelButtonText;

		[SerializeField]
		private TextMeshProUGUI saveButtonText;

		[SerializeField]
		protected ValidatedButtonInputField inputField;

		[SerializeField]
		protected TextMeshProUGUI infoText;

		protected string DPDMCDLGKOH;

protected virtual int PNMCDMNIBMH
{
get 		{
			return 0;
		}

}

		public override void Initialize(StackedUIBase MKHLKCMEBLE)
		{
		}

		protected bool GKDDPIMODBO(string HLIGBKANEEA)
		{
			return false;
		}

		protected virtual bool JIJCIHGJDGL(string EIBIHJOIINF)
		{
			return false;
		}

		public override global::NCOKFFGPIJM<HENPPMLGJNP> ShowDialog()
		{
			return null;
		}

		public override void ForceCancel(bool EDLFMMEDNGP)
		{
		}

		protected void OLDNMNIEIII(string AKOKILEPANJ, bool CEKBHBBHDCG)
		{
		}

		protected abstract void AALGBBFJEID();

		public void SetButtonText(string JINHPNDAHKP, string ABONDMLCNBK)
		{
		}

		public void Button_Cancel()
		{
		}

		public void Button_Save()
		{
		}
	}
}
