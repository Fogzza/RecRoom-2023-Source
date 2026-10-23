using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AGUI.StackedUI
{
	public class RadioButton3D : ClickableReleaseButton
	{
		[Serializable]
		public class OnRadioButton3DClick : UnityEvent<RadioButton3D>
		{
		}

		[SerializeField]
		private bool forceCanInteract;

		[SerializeField]
		private Sprite onSprite;

		[SerializeField]
		private Sprite offSprite;

		[SerializeField]
		private Image swappableImage;

		public OnRadioButton3DClick OnClick;

		private Action DHEMDPAIEKI__BackingField;

		private bool JJMFFDANDJJ;

public Sprite OnSprite
{
get 		{
			return null;
		}

set {
		}
}

public Sprite OffSprite
{
get 		{
			return null;
		}

set {
		}
}

protected override float KOPIEMBDDFC
{
get 		{
			return 0f;
		}

}

public bool IsCurrent
{
get 		{
			return false;
		}

set {
		}
}

public event Action IsCurrentChanged {
add {
		}
remove {
		}
}

		protected override void OnEnable()
		{
		}

		protected override float ACLIGCDJKAM()
		{
			return 0f;
		}

		public override void SetAxisValue(float JFNHHMPHEMO, bool COPOILGLIAJ = false)
		{
		}

		public void ForceRelease()
		{
		}

		protected override void MLMKIMCLOAJ()
		{
		}

		protected override bool DJNICFDIFOH()
		{
			return false;
		}

		private void LFOBCMDJMFE()
		{
		}
	}
}
