using System;
using RRUI.Theme;
using RecRoom.Core.Imposters;
using UnityEngine;

namespace RRUI.Data
{
	public class AnimatedPlayerPuppetRenderTextureModelController : ModelController<AnimatedPlayerPuppetRenderTextureModel>
	{
		[Serializable]
		private class AnimatedPlayerPuppetToRenderTextureModelImpl : RawImageControllerImpl<AnimatedPlayerPuppetRenderTextureModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ImposterRendererConfigByUIEnablerControllerImpl : ControllerImplementation<AnimatedPlayerPuppetRenderTextureModel>
		{
			[SerializeField]
			private ImposterRenderConfig imposterRenderConfig;

			[SerializeField]
			private AnimatedPlayerPuppetRenderTextureModel.PuppetRenderConfigPriority priority;

			private bool isInitialized;

			private bool showOnInitialize;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			private void JKEHLKPFBKO()
			{
			}

			private void GOKOGOPMCLD()
			{
			}
		}

		[Serializable]
		private class HideIfRenderConfigCannotBeZoomedOut : HideableControllerImpl<AnimatedPlayerPuppetRenderTextureModel>
		{
			[SerializeField]
			private ImposterRenderConfig zoomedInRenderConfig;

			protected override void NGFFCLPHKJN()
			{
			}
		}

		[Serializable]
		private class ZoomButtonImpl : ButtonControllerImpl<AnimatedPlayerPuppetRenderTextureModel>
		{
			[SerializeField]
			private ImposterRenderConfig zoomedOutRenderConfig;

			[SerializeField]
			private ImposterRenderConfig zoomedInRenderConfig;

			[SerializeField]
			private ToggleTheme theme;

			private bool IsZoomedOut => false;

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}

			private void GLKANOGAPIJ()
			{
			}

			private void LDLOBNLDDHO()
			{
			}
		}

		[Serializable]
		private class UploadProfilePhotoControllerImpl : ButtonControllerImpl<AnimatedPlayerPuppetRenderTextureModel>
		{
			protected override void NGFFCLPHKJN()
			{
			}

			protected override void BNFEJGHHHLO()
			{
			}
		}

		[Serializable]
		private class DraggableAvatarGraphicImpl : DragScrollDecoratorControllerImpl<AnimatedPlayerPuppetRenderTextureModel>
		{
			[SerializeField]
			private float dragYawSpeed;

			[SerializeField]
			private float dragPitchSpeed;

			[SerializeField]
			private float scrollYawSpeed;

			[SerializeField]
			private float scrollPitchSpeed;

			protected override void IHEKMEOIBOI()
			{
			}

			protected override void EHOFAGJCHPA()
			{
			}

			protected override void PLLBMDOLLBP()
			{
			}

			protected override void NGFFCLPHKJN()
			{
			}

			protected override void OnDrag(Vector2 FKHDPLPGMAK)
			{
			}

			protected override void OnScroll(Vector2 FKHDPLPGMAK)
			{
			}
		}
	}
}
