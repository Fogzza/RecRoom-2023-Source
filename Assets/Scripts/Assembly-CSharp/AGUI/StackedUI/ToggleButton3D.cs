using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class ToggleButton3D : ClickableReleaseButton
	{
		[Serializable]
		public class OnToggleButton3DClick : UnityEvent<bool>
		{
		}

		private const float KLMHDLHOGNL = 1.5f;

		[SerializeField]
		private Sprite onSprite;

		[SerializeField]
		private Sprite offSprite;

		[SerializeField]
		private Image swappableImage;

		public OnToggleButton3DClick OnClick;

		private Action<ToggleButton3D, bool> AGHFJFCIAJD__BackingField;

		private bool CPIJAGDFBCG;

		private readonly FIHGBEHGLGB JOJABEPMDBI;

		private JFMOJNIDLNH ENDNIAFGGDI;

		private bool NCPDDNBABLF;

private bool NLNAPLANIDJ
{
get 		{
			return false;
		}

}

protected override float KOPIEMBDDFC
{
get 		{
			return 0f;
		}

}

public bool IsOn
{
get 		{
			return false;
		}

set {
		}
}

public event Action<ToggleButton3D, bool> OnValueChanged {
add {
		}
remove {
		}
}

		protected override void OnEnable()
		{
		}

		public void SetConstantSprite(Sprite DLADPCHJMME)
		{
		}

		public void SetRateLimitEnabled(bool HAONPOENDBJ, object IALNODEHBNN)
		{
		}

		public override void SetAxisValue(float JFNHHMPHEMO, bool COPOILGLIAJ = false)
		{
		}

		protected override float ACLIGCDJKAM()
		{
			return 0f;
		}

		public void ForceRelease()
		{
		}

		protected override bool DJNICFDIFOH()
		{
			return false;
		}

		protected override void MLMKIMCLOAJ()
		{
		}

		private void BJMIGKJAFFJ()
		{
		}

		private void GCKOCCKFKLP()
		{
		}

		[CompilerGenerated]
		private void JDGHAMEKBGO()
		{
		}
	}
}
