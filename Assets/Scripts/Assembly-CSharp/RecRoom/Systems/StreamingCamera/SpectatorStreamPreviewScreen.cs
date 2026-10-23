using System;
using AGUI.StackedUI;
using UnityEngine;
using UnityEngine.UI;

namespace RecRoom.Systems.StreamingCamera
{
	public class SpectatorStreamPreviewScreen : MonoBehaviour
	{
		public enum FGNOBDGHJMH
		{
			SetPreview = 0,
			Next = 1,
			Previous = 2
		}

		private Action<SpectatorStreamPreviewScreen, FGNOBDGHJMH> JKJGOLHNPPC__BackingField;

		[SerializeField]
		private Button3DBase streamButton;

		[SerializeField]
		private Button3DBase nextButton;

		[SerializeField]
		private Button3DBase previousButton;

		[SerializeField]
		private Text screenName;

		[SerializeField]
		private RawImage targetImage;

		private AIJCNLJNCFM GPLFHIGFEEL;

		[NonSerialized]
		public Texture2D TargetTexture;

public Button3DBase StreamButton
{
get 		{
			return null;
		}

}

public Button3DBase NextButton
{
get 		{
			return null;
		}

}

public Button3DBase PreviousButton
{
get 		{
			return null;
		}

}

public RawImage TargetImage
{
get 		{
			return null;
		}

}

public AIJCNLJNCFM CameraTransform
{
get 		{
			return null;
		}

set {
		}
}

public event Action<SpectatorStreamPreviewScreen, FGNOBDGHJMH> ButtonPressedEvent {
add {
		}
remove {
		}
}

		private void INANOIJEDPJ()
		{
		}

		private void OnDestroy()
		{
		}

		public void ButtonPress_Next()
		{
		}

		public void ButtonPress_Previous()
		{
		}

		public void ButtonPress_SetStream()
		{
		}
	}
}
